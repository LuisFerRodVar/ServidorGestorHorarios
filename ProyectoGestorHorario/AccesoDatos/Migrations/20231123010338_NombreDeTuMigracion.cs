using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeTuMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    correo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    contrasenia = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Administ__2A586E0A9284BBFA", x => x.correo);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    carrera = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    ciclo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Curso__3213E83F5FDDD93B", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Espacio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Espacio__3213E83FB30BA208", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    apellidos = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    correo = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    contrasenia = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profesor__3213E83F7F39497D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dia = table.Column<int>(type: "int", nullable: false),
                    horaEntrada = table.Column<int>(type: "int", nullable: false),
                    horaSalida = table.Column<int>(type: "int", nullable: false),
                    idEncargado = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    espacio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Activida__3213E83FB031BF40", x => x.id);
                    table.ForeignKey(
                        name: "FK__Actividad__espac__5629CD9C",
                        column: x => x.espacio,
                        principalTable: "Espacio",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Actividad__idEnc__5535A963",
                        column: x => x.idEncargado,
                        principalTable: "Profesor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProfesorCurso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCurso = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    idProfesor = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    grupo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Profesor__3213E83F9F908F70", x => x.id);
                    table.ForeignKey(
                        name: "FK__ProfesorC__idCur__4F7CD00D",
                        column: x => x.idCurso,
                        principalTable: "Curso",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ProfesorC__idPro__5070F446",
                        column: x => x.idProfesor,
                        principalTable: "Profesor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "HorarioAsignado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idGrupo = table.Column<int>(type: "int", nullable: false),
                    dia = table.Column<int>(type: "int", nullable: false),
                    espacio = table.Column<int>(type: "int", nullable: false),
                    horaEntrada = table.Column<int>(type: "int", nullable: false),
                    horaSalida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioAsignado", x => x.Id);
                    table.ForeignKey(
                        name: "FK__HorarioAs__espac__628FA481",
                        column: x => x.espacio,
                        principalTable: "Espacio",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__HorarioAs__idGru__6383C8BA",
                        column: x => x.idGrupo,
                        principalTable: "ProfesorCurso",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_espacio",
                table: "Actividad",
                column: "espacio");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_idEncargado",
                table: "Actividad",
                column: "idEncargado");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioAsignado_espacio",
                table: "HorarioAsignado",
                column: "espacio");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioAsignado_idGrupo",
                table: "HorarioAsignado",
                column: "idGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorCurso_idCurso",
                table: "ProfesorCurso",
                column: "idCurso");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorCurso_idProfesor",
                table: "ProfesorCurso",
                column: "idProfesor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "HorarioAsignado");

            migrationBuilder.DropTable(
                name: "Espacio");

            migrationBuilder.DropTable(
                name: "ProfesorCurso");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Profesor");
        }
    }
}
