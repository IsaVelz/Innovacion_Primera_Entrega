using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendInnovacion.Migrations
{
    /// <inheritdoc />
    public partial class CreacionBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliados",
                columns: table => new
                {
                    Nit = table.Column<int>(type: "int", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    NombreContacto = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliados", x => x.Nit);
                });

            migrationBuilder.CreateTable(
                name: "AreasConocimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GranArea = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Disciplina = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasConocimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspectosNormativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Fuente = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspectosNormativos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarInnovaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarInnovaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfoques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfoques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PracticasEstrategias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticasEstrategias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facultades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FechaFun = table.Column<DateTime>(type: "Date", nullable: false),
                    UniversidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facultades_Universidades_UniversidadId",
                        column: x => x.UniversidadId,
                        principalTable: "Universidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Nivel = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "Date", nullable: true),
                    NumeroCohortes = table.Column<int>(type: "int", nullable: false),
                    CantGraduados = table.Column<int>(type: "int", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "Date", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FacultadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programas_Facultades_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "Facultades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acreditaciones",
                columns: table => new
                {
                    Resolucion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Calificacion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "Date", nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acreditaciones", x => x.Resolucion);
                    table.ForeignKey(
                        name: "FK_Acreditaciones_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivAcademicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    NumCreditos = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    AreaFormacion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Hacom = table.Column<int>(type: "int", nullable: false),
                    Hindep = table.Column<int>(type: "int", nullable: false),
                    Idioma = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Espejo = table.Column<int>(type: "int", nullable: true),
                    EntidadEspejo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    PaisEspejo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Diseno = table.Column<int>(type: "int", nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivAcademicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivAcademicas_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alianzas",
                columns: table => new
                {
                    AliadoId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "Date", nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alianzas", x => new { x.AliadoId, x.DepartamentoId });
                    table.ForeignKey(
                        name: "FK_Alianzas_Aliados_AliadoId",
                        column: x => x.AliadoId,
                        principalTable: "Aliados",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alianzas_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnProgramas",
                columns: table => new
                {
                    AspectoNormativoId = table.Column<int>(type: "int", nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnProgramas", x => new { x.AspectoNormativoId, x.ProgramaId });
                    table.ForeignKey(
                        name: "FK_AnProgramas_AspectosNormativos_AspectoNormativoId",
                        column: x => x.AspectoNormativoId,
                        principalTable: "AspectosNormativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnProgramas_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocenteDepartamentos",
                columns: table => new
                {
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Dedicacion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Modalidad = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "Date", nullable: true),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteDepartamentos", x => new { x.DocenteId, x.DepartamentoId });
                    table.ForeignKey(
                        name: "FK_DocenteDepartamentos_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pasantias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasantias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pasantias_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Premios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    EntidadOtorgante = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Premios_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaACs",
                columns: table => new
                {
                    ProgramaId = table.Column<int>(type: "int", nullable: false),
                    AreaConocimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaACs", x => new { x.ProgramaId, x.AreaConocimientoId });
                    table.ForeignKey(
                        name: "FK_ProgramaACs_AreasConocimiento_AreaConocimientoId",
                        column: x => x.AreaConocimientoId,
                        principalTable: "AreasConocimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramaACs_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaCIs",
                columns: table => new
                {
                    ProgramaId = table.Column<int>(type: "int", nullable: false),
                    CarInnovacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaCIs", x => new { x.ProgramaId, x.CarInnovacionId });
                    table.ForeignKey(
                        name: "FK_ProgramaCIs_CarInnovaciones_CarInnovacionId",
                        column: x => x.CarInnovacionId,
                        principalTable: "CarInnovaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramaCIs_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaPEs",
                columns: table => new
                {
                    ProgramaId = table.Column<int>(type: "int", nullable: false),
                    PracticaEstrategiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaPEs", x => new { x.ProgramaId, x.PracticaEstrategiaId });
                    table.ForeignKey(
                        name: "FK_ProgramaPEs_PracticasEstrategias_PracticaEstrategiaId",
                        column: x => x.PracticaEstrategiaId,
                        principalTable: "PracticasEstrategias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramaPEs_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosCalificados",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantCreditos = table.Column<int>(type: "int", nullable: false),
                    HoraAcom = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    HoraInd = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Metodologia = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "Date", nullable: false),
                    DuracionAños = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    DuracionSemestres = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TipoTitulacion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosCalificados", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_RegistrosCalificados_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AaRcs",
                columns: table => new
                {
                    ActivAcademicaId = table.Column<int>(type: "int", nullable: false),
                    RegistroCalificadoId = table.Column<int>(type: "int", nullable: false),
                    Componente = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Semestre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AaRcs", x => new { x.ActivAcademicaId, x.RegistroCalificadoId });
                    table.ForeignKey(
                        name: "FK_AaRcs_ActivAcademicas_ActivAcademicaId",
                        column: x => x.ActivAcademicaId,
                        principalTable: "ActivAcademicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AaRcs_RegistrosCalificados_RegistroCalificadoId",
                        column: x => x.RegistroCalificadoId,
                        principalTable: "RegistrosCalificados",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnfoquesRCs",
                columns: table => new
                {
                    EnfoqueId = table.Column<int>(type: "int", nullable: false),
                    RegistroCalificadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfoquesRCs", x => new { x.EnfoqueId, x.RegistroCalificadoId });
                    table.ForeignKey(
                        name: "FK_EnfoquesRCs_Enfoques_EnfoqueId",
                        column: x => x.EnfoqueId,
                        principalTable: "Enfoques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnfoquesRCs_RegistrosCalificados_RegistroCalificadoId",
                        column: x => x.RegistroCalificadoId,
                        principalTable: "RegistrosCalificados",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AaRcs_RegistroCalificadoId",
                table: "AaRcs",
                column: "RegistroCalificadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Acreditaciones_ProgramaId",
                table: "Acreditaciones",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivAcademicas_ProgramaId",
                table: "ActivAcademicas",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alianzas_ProgramaId",
                table: "Alianzas",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnProgramas_ProgramaId",
                table: "AnProgramas",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_DocenteDepartamentos_ProgramaId",
                table: "DocenteDepartamentos",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfoquesRCs_RegistroCalificadoId",
                table: "EnfoquesRCs",
                column: "RegistroCalificadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Facultades_UniversidadId",
                table: "Facultades",
                column: "UniversidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasantias_ProgramaId",
                table: "Pasantias",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_Premios_ProgramaId",
                table: "Premios",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaACs_AreaConocimientoId",
                table: "ProgramaACs",
                column: "AreaConocimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaCIs_CarInnovacionId",
                table: "ProgramaCIs",
                column: "CarInnovacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaPEs_PracticaEstrategiaId",
                table: "ProgramaPEs",
                column: "PracticaEstrategiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Programas_FacultadId",
                table: "Programas",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosCalificados_ProgramaId",
                table: "RegistrosCalificados",
                column: "ProgramaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AaRcs");

            migrationBuilder.DropTable(
                name: "Acreditaciones");

            migrationBuilder.DropTable(
                name: "Alianzas");

            migrationBuilder.DropTable(
                name: "AnProgramas");

            migrationBuilder.DropTable(
                name: "DocenteDepartamentos");

            migrationBuilder.DropTable(
                name: "EnfoquesRCs");

            migrationBuilder.DropTable(
                name: "Pasantias");

            migrationBuilder.DropTable(
                name: "Premios");

            migrationBuilder.DropTable(
                name: "ProgramaACs");

            migrationBuilder.DropTable(
                name: "ProgramaCIs");

            migrationBuilder.DropTable(
                name: "ProgramaPEs");

            migrationBuilder.DropTable(
                name: "ActivAcademicas");

            migrationBuilder.DropTable(
                name: "Aliados");

            migrationBuilder.DropTable(
                name: "AspectosNormativos");

            migrationBuilder.DropTable(
                name: "Enfoques");

            migrationBuilder.DropTable(
                name: "RegistrosCalificados");

            migrationBuilder.DropTable(
                name: "AreasConocimiento");

            migrationBuilder.DropTable(
                name: "CarInnovaciones");

            migrationBuilder.DropTable(
                name: "PracticasEstrategias");

            migrationBuilder.DropTable(
                name: "Programas");

            migrationBuilder.DropTable(
                name: "Facultades");

            migrationBuilder.DropTable(
                name: "Universidades");
        }
    }
}
