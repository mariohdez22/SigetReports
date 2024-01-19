using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigetSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bitacoras",
                columns: table => new
                {
                    IdBitacora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombrePersonal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAccion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacoras", x => x.IdBitacora);
                });

            migrationBuilder.CreateTable(
                name: "CodigoConformidads",
                columns: table => new
                {
                    IdCodigoConformidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoConformidads", x => x.IdCodigoConformidad);
                });

            migrationBuilder.CreateTable(
                name: "CodigoSigets",
                columns: table => new
                {
                    IdCodigoSiget = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoSigets", x => x.IdCodigoSiget);
                });

            migrationBuilder.CreateTable(
                name: "ComentariosInconformidads",
                columns: table => new
                {
                    IdCodigoInconformidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosInconformidads", x => x.IdCodigoInconformidad);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentoInstalacions",
                columns: table => new
                {
                    IdDepartamentoInstalacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departamentos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoInstalacions", x => x.IdDepartamentoInstalacion);
                });

            migrationBuilder.CreateTable(
                name: "EstadoAcreditacions",
                columns: table => new
                {
                    IdEstadoAcreditacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estados = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAcreditacions", x => x.IdEstadoAcreditacion);
                });

            migrationBuilder.CreateTable(
                name: "EstadoComentarios",
                columns: table => new
                {
                    IdEstadoComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estados = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoComentarios", x => x.IdEstadoComentario);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPersonals",
                columns: table => new
                {
                    IdEstadoPersonal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estados = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPersonals", x => x.IdEstadoPersonal);
                });

            migrationBuilder.CreateTable(
                name: "EstadoReportes",
                columns: table => new
                {
                    IdEstadoReporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estados = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoReportes", x => x.IdEstadoReporte);
                });

            migrationBuilder.CreateTable(
                name: "EstadoRepresentantes",
                columns: table => new
                {
                    IdEstadoRepresentante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estados = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoRepresentantes", x => x.IdEstadoRepresentante);
                });

            migrationBuilder.CreateTable(
                name: "MunicipioInstalacions",
                columns: table => new
                {
                    IdMunicipioInstalacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Municipios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipioInstalacions", x => x.IdMunicipioInstalacion);
                });

            migrationBuilder.CreateTable(
                name: "RangoPersonals",
                columns: table => new
                {
                    IdRangoPersonal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rangos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangoPersonals", x => x.IdRangoPersonal);
                });

            migrationBuilder.CreateTable(
                name: "TipoConformidads",
                columns: table => new
                {
                    IdTipoConformidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConformidads", x => x.IdTipoConformidad);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    IdPersonal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRangoPersonal = table.Column<int>(type: "int", nullable: false),
                    IdEstadoPersonal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.IdPersonal);
                    table.ForeignKey(
                        name: "FK_Personals_EstadoPersonals_IdEstadoPersonal",
                        column: x => x.IdEstadoPersonal,
                        principalTable: "EstadoPersonals",
                        principalColumn: "IdEstadoPersonal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personals_RangoPersonals_IdRangoPersonal",
                        column: x => x.IdRangoPersonal,
                        principalTable: "RangoPersonals",
                        principalColumn: "IdRangoPersonal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organismos",
                columns: table => new
                {
                    IdOrganismo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreOIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoUnico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstadoAcreditacion = table.Column<int>(type: "int", nullable: false),
                    IdPersonal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organismos", x => x.IdOrganismo);
                    table.ForeignKey(
                        name: "FK_Organismos_EstadoAcreditacions_IdEstadoAcreditacion",
                        column: x => x.IdEstadoAcreditacion,
                        principalTable: "EstadoAcreditacions",
                        principalColumn: "IdEstadoAcreditacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organismos_Personals_IdPersonal",
                        column: x => x.IdPersonal,
                        principalTable: "Personals",
                        principalColumn: "IdPersonal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Representantes",
                columns: table => new
                {
                    IdRepresentante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComprobanteOIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstadoRepresentante = table.Column<int>(type: "int", nullable: false),
                    IdOrganismo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representantes", x => x.IdRepresentante);
                    table.ForeignKey(
                        name: "FK_Representantes_EstadoRepresentantes_IdEstadoRepresentante",
                        column: x => x.IdEstadoRepresentante,
                        principalTable: "EstadoRepresentantes",
                        principalColumn: "IdEstadoRepresentante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Representantes_Organismos_IdOrganismo",
                        column: x => x.IdOrganismo,
                        principalTable: "Organismos",
                        principalColumn: "IdOrganismo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitoMayors",
                columns: table => new
                {
                    IdMayores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoRequisito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Factibilidad = table.Column<bool>(type: "bit", nullable: true),
                    TotalFormularios = table.Column<bool>(type: "bit", nullable: true),
                    CopiaDuiPropietario = table.Column<bool>(type: "bit", nullable: true),
                    CopiaDuiRetiro = table.Column<bool>(type: "bit", nullable: true),
                    CopiaDuiElectricista = table.Column<bool>(type: "bit", nullable: true),
                    CopiaCarnetElectricista = table.Column<bool>(type: "bit", nullable: true),
                    PlanosDualesDeDiseñoMinimo = table.Column<bool>(type: "bit", nullable: true),
                    PlanosDualesDeConstruccion = table.Column<bool>(type: "bit", nullable: true),
                    CopiaFacturaDeMateriales = table.Column<bool>(type: "bit", nullable: true),
                    CopiaGarantiaDeTransformador = table.Column<bool>(type: "bit", nullable: true),
                    ComprobanteDePago = table.Column<bool>(type: "bit", nullable: true),
                    MemoriaDecalculo = table.Column<bool>(type: "bit", nullable: true),
                    AutocadCD = table.Column<bool>(type: "bit", nullable: true),
                    ArchivoCopiaDuiPropietario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoCopiaDuiRetiro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoCopiaDuiElectricista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoCopiaCarnetElectricista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoPlanosDualesDeDiseñoMinimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoPlanosDualesDeConstruccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoCopiaFacturaDeMateriales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoCopiaGarantiaDeTransformador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganismo = table.Column<int>(type: "int", nullable: true),
                    IdRepresentante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitoMayors", x => x.IdMayores);
                    table.ForeignKey(
                        name: "FK_RequisitoMayors_Organismos_IdOrganismo",
                        column: x => x.IdOrganismo,
                        principalTable: "Organismos",
                        principalColumn: "IdOrganismo");
                    table.ForeignKey(
                        name: "FK_RequisitoMayors_Representantes_IdRepresentante",
                        column: x => x.IdRepresentante,
                        principalTable: "Representantes",
                        principalColumn: "IdRepresentante");
                });

            migrationBuilder.CreateTable(
                name: "RequisitoMenors",
                columns: table => new
                {
                    IdMenores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoRequisito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Factibilidad = table.Column<bool>(type: "bit", nullable: true),
                    TotalFormularios = table.Column<bool>(type: "bit", nullable: true),
                    CopiaDuiPropietario = table.Column<bool>(type: "bit", nullable: true),
                    CopiaDuiRetiro = table.Column<bool>(type: "bit", nullable: true),
                    CopiaTarjetaIvaEmpresa = table.Column<bool>(type: "bit", nullable: true),
                    CopiaDuiElectricista = table.Column<bool>(type: "bit", nullable: true),
                    CopiaCarnetElectricista = table.Column<bool>(type: "bit", nullable: true),
                    CuadroDeCarga = table.Column<bool>(type: "bit", nullable: true),
                    CroquisDeUbicacion = table.Column<bool>(type: "bit", nullable: true),
                    EsquemaDeInstalacionElectrica = table.Column<bool>(type: "bit", nullable: true),
                    ComprobanteDepago = table.Column<bool>(type: "bit", nullable: true),
                    ArchivoCopiaDuiPropietario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoCopiaDuiRetiro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoCopiaDuiElectricista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoCopiaCarnetElectricista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganismo = table.Column<int>(type: "int", nullable: true),
                    IdRepresentante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitoMenors", x => x.IdMenores);
                    table.ForeignKey(
                        name: "FK_RequisitoMenors_Organismos_IdOrganismo",
                        column: x => x.IdOrganismo,
                        principalTable: "Organismos",
                        principalColumn: "IdOrganismo");
                    table.ForeignKey(
                        name: "FK_RequisitoMenors_Representantes_IdRepresentante",
                        column: x => x.IdRepresentante,
                        principalTable: "Representantes",
                        principalColumn: "IdRepresentante");
                });

            migrationBuilder.CreateTable(
                name: "ReporteInspeccions",
                columns: table => new
                {
                    IdReporteInspeccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoInspeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoDepartamentalInstElectrica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoMunicipioInstalacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColoniaInstalacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionInstalacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDepagoSolicitante = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPrimeraInspeccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUltimaInspeccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntregaConformidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EspecificacionesCertificado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontoSolicitante = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroCreditoFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdOrganismo = table.Column<int>(type: "int", nullable: true),
                    IdRepresentante = table.Column<int>(type: "int", nullable: true),
                    IdDepartamentoInstalacion = table.Column<int>(type: "int", nullable: true),
                    IdMunicipioInstalacion = table.Column<int>(type: "int", nullable: true),
                    IdCodigoConformidad = table.Column<int>(type: "int", nullable: true),
                    IdComentariosInconformidad = table.Column<int>(type: "int", nullable: true),
                    IdCodigoSiget = table.Column<int>(type: "int", nullable: true),
                    IdRequisitoMenor = table.Column<int>(type: "int", nullable: true),
                    IdRequisitoMayor = table.Column<int>(type: "int", nullable: true),
                    IdEstadoReporte = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteInspeccions", x => x.IdReporteInspeccion);
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_CodigoConformidads_IdCodigoConformidad",
                        column: x => x.IdCodigoConformidad,
                        principalTable: "CodigoConformidads",
                        principalColumn: "IdCodigoConformidad");
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_CodigoSigets_IdCodigoSiget",
                        column: x => x.IdCodigoSiget,
                        principalTable: "CodigoSigets",
                        principalColumn: "IdCodigoSiget");
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_ComentariosInconformidads_IdComentariosInconformidad",
                        column: x => x.IdComentariosInconformidad,
                        principalTable: "ComentariosInconformidads",
                        principalColumn: "IdCodigoInconformidad");
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_DepartamentoInstalacions_IdDepartamentoInstalacion",
                        column: x => x.IdDepartamentoInstalacion,
                        principalTable: "DepartamentoInstalacions",
                        principalColumn: "IdDepartamentoInstalacion");
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_EstadoReportes_IdEstadoReporte",
                        column: x => x.IdEstadoReporte,
                        principalTable: "EstadoReportes",
                        principalColumn: "IdEstadoReporte");
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_MunicipioInstalacions_IdMunicipioInstalacion",
                        column: x => x.IdMunicipioInstalacion,
                        principalTable: "MunicipioInstalacions",
                        principalColumn: "IdMunicipioInstalacion");
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_Organismos_IdOrganismo",
                        column: x => x.IdOrganismo,
                        principalTable: "Organismos",
                        principalColumn: "IdOrganismo");
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_Representantes_IdRepresentante",
                        column: x => x.IdRepresentante,
                        principalTable: "Representantes",
                        principalColumn: "IdRepresentante");
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_RequisitoMayors_IdRequisitoMayor",
                        column: x => x.IdRequisitoMayor,
                        principalTable: "RequisitoMayors",
                        principalColumn: "IdMayores");
                    table.ForeignKey(
                        name: "FK_ReporteInspeccions_RequisitoMenors_IdRequisitoMenor",
                        column: x => x.IdRequisitoMenor,
                        principalTable: "RequisitoMenors",
                        principalColumn: "IdMenores");
                });

            migrationBuilder.CreateTable(
                name: "ComentarioSigets",
                columns: table => new
                {
                    IdComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoComentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoConformidad = table.Column<int>(type: "int", nullable: false),
                    IdReporteInspeccion = table.Column<int>(type: "int", nullable: true),
                    IdRepresentante = table.Column<int>(type: "int", nullable: true),
                    IdPersonal = table.Column<int>(type: "int", nullable: true),
                    FechaComentario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioSigets", x => x.IdComentario);
                    table.ForeignKey(
                        name: "FK_ComentarioSigets_Personals_IdPersonal",
                        column: x => x.IdPersonal,
                        principalTable: "Personals",
                        principalColumn: "IdPersonal");
                    table.ForeignKey(
                        name: "FK_ComentarioSigets_ReporteInspeccions_IdReporteInspeccion",
                        column: x => x.IdReporteInspeccion,
                        principalTable: "ReporteInspeccions",
                        principalColumn: "IdReporteInspeccion");
                    table.ForeignKey(
                        name: "FK_ComentarioSigets_Representantes_IdRepresentante",
                        column: x => x.IdRepresentante,
                        principalTable: "Representantes",
                        principalColumn: "IdRepresentante");
                    table.ForeignKey(
                        name: "FK_ComentarioSigets_TipoConformidads_IdTipoConformidad",
                        column: x => x.IdTipoConformidad,
                        principalTable: "TipoConformidads",
                        principalColumn: "IdTipoConformidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioSigets_IdPersonal",
                table: "ComentarioSigets",
                column: "IdPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioSigets_IdReporteInspeccion",
                table: "ComentarioSigets",
                column: "IdReporteInspeccion");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioSigets_IdRepresentante",
                table: "ComentarioSigets",
                column: "IdRepresentante");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioSigets_IdTipoConformidad",
                table: "ComentarioSigets",
                column: "IdTipoConformidad");

            migrationBuilder.CreateIndex(
                name: "IX_Organismos_IdEstadoAcreditacion",
                table: "Organismos",
                column: "IdEstadoAcreditacion");

            migrationBuilder.CreateIndex(
                name: "IX_Organismos_IdPersonal",
                table: "Organismos",
                column: "IdPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_IdEstadoPersonal",
                table: "Personals",
                column: "IdEstadoPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_IdRangoPersonal",
                table: "Personals",
                column: "IdRangoPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdCodigoConformidad",
                table: "ReporteInspeccions",
                column: "IdCodigoConformidad");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdCodigoSiget",
                table: "ReporteInspeccions",
                column: "IdCodigoSiget");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdComentariosInconformidad",
                table: "ReporteInspeccions",
                column: "IdComentariosInconformidad");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdDepartamentoInstalacion",
                table: "ReporteInspeccions",
                column: "IdDepartamentoInstalacion");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdEstadoReporte",
                table: "ReporteInspeccions",
                column: "IdEstadoReporte");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdMunicipioInstalacion",
                table: "ReporteInspeccions",
                column: "IdMunicipioInstalacion");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdOrganismo",
                table: "ReporteInspeccions",
                column: "IdOrganismo");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdRepresentante",
                table: "ReporteInspeccions",
                column: "IdRepresentante");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdRequisitoMayor",
                table: "ReporteInspeccions",
                column: "IdRequisitoMayor");

            migrationBuilder.CreateIndex(
                name: "IX_ReporteInspeccions_IdRequisitoMenor",
                table: "ReporteInspeccions",
                column: "IdRequisitoMenor");

            migrationBuilder.CreateIndex(
                name: "IX_Representantes_IdEstadoRepresentante",
                table: "Representantes",
                column: "IdEstadoRepresentante");

            migrationBuilder.CreateIndex(
                name: "IX_Representantes_IdOrganismo",
                table: "Representantes",
                column: "IdOrganismo");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitoMayors_IdOrganismo",
                table: "RequisitoMayors",
                column: "IdOrganismo");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitoMayors_IdRepresentante",
                table: "RequisitoMayors",
                column: "IdRepresentante");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitoMenors_IdOrganismo",
                table: "RequisitoMenors",
                column: "IdOrganismo");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitoMenors_IdRepresentante",
                table: "RequisitoMenors",
                column: "IdRepresentante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacoras");

            migrationBuilder.DropTable(
                name: "ComentarioSigets");

            migrationBuilder.DropTable(
                name: "EstadoComentarios");

            migrationBuilder.DropTable(
                name: "ReporteInspeccions");

            migrationBuilder.DropTable(
                name: "TipoConformidads");

            migrationBuilder.DropTable(
                name: "CodigoConformidads");

            migrationBuilder.DropTable(
                name: "CodigoSigets");

            migrationBuilder.DropTable(
                name: "ComentariosInconformidads");

            migrationBuilder.DropTable(
                name: "DepartamentoInstalacions");

            migrationBuilder.DropTable(
                name: "EstadoReportes");

            migrationBuilder.DropTable(
                name: "MunicipioInstalacions");

            migrationBuilder.DropTable(
                name: "RequisitoMayors");

            migrationBuilder.DropTable(
                name: "RequisitoMenors");

            migrationBuilder.DropTable(
                name: "Representantes");

            migrationBuilder.DropTable(
                name: "EstadoRepresentantes");

            migrationBuilder.DropTable(
                name: "Organismos");

            migrationBuilder.DropTable(
                name: "EstadoAcreditacions");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "EstadoPersonals");

            migrationBuilder.DropTable(
                name: "RangoPersonals");
        }
    }
}
