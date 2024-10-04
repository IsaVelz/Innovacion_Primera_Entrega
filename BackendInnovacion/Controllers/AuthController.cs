using BackendInnovacion.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendInnovacion.Models;
using Microsoft.Data.SqlClient;

//AuthController para manejar la autenticación de los

namespace BackendInnovacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly ControlConexion _controlConexion; // Cambiado a ControlConexion

        public AuthController(TokenService tokenService, ControlConexion controlConexion) // Cambiado a ControlConexion
        {
            _tokenService = tokenService;
            _controlConexion = controlConexion;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            _controlConexion.AbrirBd();
            string comandoSQL = "SELECT COUNT(*) FROM usuario WHERE email = @Email AND contrasena = @Contrasena";
            var parametros = new[]
            {
                new SqlParameter("@Email", login.Email),
                new SqlParameter("@Contrasena", login.Contrasena)
            };
            var result = _controlConexion.EjecutarConsultaSql(comandoSQL, parametros);
            _controlConexion.CerrarBd();

            if (result.Rows[0][0].ToString() == "1")
            {
                var token = _tokenService.GenerateToken(login.Email);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
