#nullable enable // Habilita las características de referencia nula en C#, permitiendo anotaciones y advertencias relacionadas con posibles valores nulos.
using System; // Importa el espacio de nombres System, que contiene tipos fundamentales como Exception, Console, etc.
using System.Collections.Generic; // Importa el espacio de nombres para colecciones genéricas como Dictionary.
using System.Data; // Importa el espacio de nombres para acceder a clases relacionadas con bases de datos.
using System.Data.Common; // Importa el espacio de nombres que define la clase base para proveedores de datos.
using Microsoft.Data.SqlClient; // Importa el espacio de nombres necesario para trabajar con SQL Server y LocalDB.
using System.IO; // Importa el espacio de nombres para manejar archivos y directorios.
using Microsoft.AspNetCore.Hosting; // Importa el espacio de nombres para trabajar con el entorno de hospedaje de la aplicación.
using Microsoft.Extensions.Configuration; // Importa el espacio de nombres para trabajar con la configuración de la aplicación.

namespace BackendInnovacion.Services
{
    public class ControlConexion
    {
        private readonly IWebHostEnvironment _env; // Define una variable para almacenar el entorno de hospedaje web.
        private readonly IConfiguration _configuration; // Define una variable para almacenar la configuración de la aplicación.
        private IDbConnection? _dbConnection; // Define una variable para almacenar la conexión a la base de datos.

        // Constructor que inicializa el entorno de hospedaje web y la configuración de la aplicación.
        public ControlConexion(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env)); // Inicializa _env y lanza una excepción si es null.
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration)); // Inicializa _configuration y lanza una excepción si es null.
            _dbConnection = null; // Inicializa la conexión a la base de datos como null.
        }

        // Método para abrir la base de datos, compatible con LocalDB y SQL Server.
        public void AbrirBd()
        {
            try
            {
                // Obtiene el proveedor de base de datos desde la configuración, lanza una excepción si no está configurado.
                string provider = _configuration["DatabaseProvider"] ?? throw new InvalidOperationException("DatabaseProvider not configured.");
                
                // Obtiene la cadena de conexión basada en el proveedor de base de datos.
                string? connectionString = _configuration.GetConnectionString(provider);

                // Verifica si la cadena de conexión es nula o está vacía, lanza una excepción si es así.
                if (string.IsNullOrEmpty(connectionString))
                    throw new InvalidOperationException("Connection string is null or empty.");

                // Abre la conexión basada en el proveedor de base de datos.
                switch (provider)
                {
                    case "LocalDb":
                        // Establece el directorio de datos para LocalDB y abre la conexión.
                        string appDataPath = Path.Combine(_env.ContentRootPath, "App_Data");
                        AppDomain.CurrentDomain.SetData("DataDirectory", appDataPath);
                        _dbConnection = new SqlConnection(connectionString);
                        _dbConnection.Open();
                        break;
                    case "SqlServer":
                        // Abre la conexión para SQL Server.
                        _dbConnection = new SqlConnection(connectionString);
                        _dbConnection.Open();
                        break;
                    default:
                        // Lanza una excepción si el proveedor no es compatible.
                        throw new InvalidOperationException("Unsupported database provider. Only LocalDb and SqlServer are supported.");
                }
            }
            catch (Exception ex)
            {
                // Lanza una excepción personalizada si la conexión falla.
                throw new InvalidOperationException("Failed to open the database connection.", ex);
            }
        }

        // Método específico para abrir una base de datos LocalDB.
        public void AbrirBdLocalDB(string archivoDb)
        {
            try
            {
                // Verifica si el nombre del archivo termina en .mdf, si no, lo agrega.
                string dbFileName = archivoDb.EndsWith(".mdf") ? archivoDb : archivoDb + ".mdf";
                
                // Define la ruta completa al archivo de base de datos en la carpeta App_Data.
                string appDataPath = Path.Combine(_env.ContentRootPath, "App_Data");
                string filePath = Path.Combine(appDataPath, dbFileName);

                // Crea la cadena de conexión para LocalDB con AttachDbFilename.
                string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={filePath};Integrated Security=True";
                
                // Abre la conexión a la base de datos LocalDB.
                _dbConnection = new SqlConnection(connectionString);
                _dbConnection.Open();
            }
            catch (Exception ex)
            {
                // Lanza una excepción personalizada si la conexión falla.
                throw new InvalidOperationException("Failed to open the LocalDB connection.", ex);
            }
        }

        // Método para cerrar la conexión a la base de datos.
        public void CerrarBd()
        {
            try
            {
                // Verifica si la conexión está abierta y luego la cierra.
                if (_dbConnection != null && _dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                // Lanza una excepción personalizada si la operación de cierre falla.
                throw new InvalidOperationException("Failed to close the database connection.", ex);
            }
        }

        // Método para ejecutar un comando SQL y devolver el número de filas afectadas.
        public int EjecutarComandoSql(string consultaSql, DbParameter[] parametros)
        {
            try
            {
                // Verifica si la conexión está abierta antes de ejecutar el comando.
                if (_dbConnection == null || _dbConnection.State != ConnectionState.Open)
                    throw new InvalidOperationException("Database connection is not open.");

                // Crea y configura un comando SQL.
                using (var comando = _dbConnection.CreateCommand())
                {
                    comando.CommandText = consultaSql; // Asigna la consulta SQL al comando.
                    foreach (var parametro in parametros)
                    {
                        // Agrega cada parámetro al comando.
                        Console.WriteLine($"Adding parameter: {parametro.ParameterName} = {parametro.Value}, DbType: {parametro.DbType}");
                        comando.Parameters.Add(parametro);
                    }
                    // Ejecuta el comando y devuelve el número de filas afectadas.
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas;
                }
            }
            catch (Exception ex)
            {
                // Lanza una excepción personalizada si la ejecución del comando falla.
                Console.WriteLine($"Exception occurred: {ex.Message}");
                throw new InvalidOperationException("Failed to execute SQL command.", ex);
            }
        }

        // Método para ejecutar una consulta SQL y devolver un DataTable con los resultados.
        public DataTable EjecutarConsultaSql(string consultaSql, DbParameter[]? parametros)
        {
            // Verifica si la conexión está abierta antes de ejecutar la consulta.
            if (_dbConnection == null || _dbConnection.State != ConnectionState.Open)
                throw new InvalidOperationException("Database connection is not open.");

            try
            {
                // Crea y configura un comando SQL.
                using (var comando = _dbConnection.CreateCommand())
                {
                    comando.CommandText = consultaSql; // Asigna la consulta SQL al comando.
                    if (parametros != null)
                    {
                        // Agrega los parámetros al comando si los hay.
                        foreach (var param in parametros)
                        {
                            Console.WriteLine($"Adding parameter: {param.ParameterName} = {param.Value}, DbType: {param.DbType}");
                            comando.Parameters.Add(param);
                        }
                    }

                    // Crea un DataSet para almacenar los resultados de la consulta.
                    var resultado = new DataSet();
                    var adaptador = new SqlDataAdapter((SqlCommand)comando); // Crea un adaptador de datos para SQL Server.

                    Console.WriteLine($"Executing command: {comando.CommandText}");
                    adaptador.Fill(resultado); // Llena el DataSet con los resultados de la consulta.
                    Console.WriteLine("DataSet filled");

                    // Verifica si el DataSet tiene al menos una tabla de resultados.
                    if (resultado.Tables.Count == 0)
                    {
                        Console.WriteLine("No tables returned in the DataSet");
                        throw new Exception("No tables returned in the DataSet");
                    }

                    Console.WriteLine($"Number of tables in DataSet: {resultado.Tables.Count}");
                    Console.WriteLine($"Number of rows in first table: {resultado.Tables[0].Rows.Count}");

                    return resultado.Tables[0]; // Retorna la primera tabla del DataSet.
                }
            }
            catch (Exception ex)
            {
                // Lanza una excepción personalizada si la consulta falla.
                Console.WriteLine($"Exception occurred: {ex.Message}");
                throw new Exception($"Failed to execute SQL query. Error: {ex.Message}", ex);
            }
        }

        // Método para crear un parámetro de consulta SQL.
        public DbParameter CreateParameter(string name, object? value)
        {
            try
            {
                // Obtiene el proveedor de base de datos desde la configuración, lanza una excepción si no está configurado.
                string provider = _configuration["DatabaseProvider"] ?? throw new InvalidOperationException("DatabaseProvider not configured.");
                
                // Crea un parámetro adecuado según el proveedor de base de datos.
                return provider switch
                {
                    "SqlServer" => new SqlParameter(name, value ?? DBNull.Value), // Crea un parámetro para SQL Server.
                    "LocalDb" => new SqlParameter(name, value ?? DBNull.Value), // Crea un parámetro para LocalDB.
                    _ => throw new InvalidOperationException("Unsupported database provider. Only LocalDb and SqlServer are supported."),
                };
            }
            catch (Exception ex)
            {
                // Lanza una excepción personalizada si la creación del parámetro falla.
                throw new InvalidOperationException("Failed to create parameter.", ex);
            }
        }

        // Método para obtener la conexión actual a la base de datos.
        public IDbConnection? GetConnection()
        {
            return _dbConnection; // Devuelve la conexión actual a la base de datos.
        }
    }
}
/*
IConfiguration
IConfiguration es una interfaz en ASP.NET Core que se utiliza para acceder a la configuración 
de la aplicación. La configuración puede provenir de diferentes fuentes, 
como archivos de configuración (por ejemplo, appsettings.json), 
variables de entorno, argumentos de la línea de comandos, y más.

IDbConnection
IDbConnection es una interfaz en ADO.NET que define los métodos y 
propiedades que debe implementar cualquier clase que represente una conexión a 
una base de datos. Esta interfaz es parte del espacio de nombres System.Data.

Características y uso:
Propósito: Proporciona una manera estandarizada de manejar conexiones a bases de datos, 
independientemente del tipo específico de base de datos 
(por ejemplo, SQL Server, MySQL, Oracle, etc.).
*/