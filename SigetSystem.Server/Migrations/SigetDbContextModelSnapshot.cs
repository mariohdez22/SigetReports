﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SigetSystem.Server.Models.Contexto;

#nullable disable

namespace SigetSystem.Server.Migrations
{
    [DbContext(typeof(SigetDbContext))]
    partial class SigetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.ComentarioSiget", b =>
                {
                    b.Property<int>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComentario"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaComentario")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdPersonal")
                        .HasColumnType("int");

                    b.Property<int?>("IdReporteInspeccion")
                        .HasColumnType("int");

                    b.Property<int?>("IdRepresentante")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoConformidad")
                        .HasColumnType("int");

                    b.Property<string>("MotivoComentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdComentario");

                    b.HasIndex("IdPersonal");

                    b.HasIndex("IdReporteInspeccion");

                    b.HasIndex("IdRepresentante");

                    b.HasIndex("IdTipoConformidad");

                    b.ToTable("ComentarioSigets");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.Organismo", b =>
                {
                    b.Property<int>("IdOrganismo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrganismo"));

                    b.Property<string>("CodigoUnico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEstadoAcreditacion")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonal")
                        .HasColumnType("int");

                    b.Property<string>("NombreOIA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOrganismo");

                    b.HasIndex("IdEstadoAcreditacion");

                    b.HasIndex("IdPersonal");

                    b.ToTable("Organismos");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.Personal", b =>
                {
                    b.Property<int>("IdPersonal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonal"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DUI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEstadoPersonal")
                        .HasColumnType("int");

                    b.Property<int>("IdRangoPersonal")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersonal");

                    b.HasIndex("IdEstadoPersonal");

                    b.HasIndex("IdRangoPersonal");

                    b.ToTable("Personals");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.ReporteInspeccion", b =>
                {
                    b.Property<int>("IdReporteInspeccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReporteInspeccion"));

                    b.Property<string>("CodigoDepartamentalInstElectrica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoInspeccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoMunicipioInstalacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColoniaInstalacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionInstalacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EspecificacionesCertificado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDepagoSolicitante")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEntregaConformidad")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPrimeraInspeccion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaUltimaInspeccion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCodigoConformidad")
                        .HasColumnType("int");

                    b.Property<int?>("IdCodigoSiget")
                        .HasColumnType("int");

                    b.Property<int?>("IdComentariosInconformidad")
                        .HasColumnType("int");

                    b.Property<int?>("IdDepartamentoInstalacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdEstadoReporte")
                        .HasColumnType("int");

                    b.Property<int?>("IdMunicipioInstalacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdOrganismo")
                        .HasColumnType("int");

                    b.Property<int?>("IdRepresentante")
                        .HasColumnType("int");

                    b.Property<int?>("IdRequisitoMayor")
                        .HasColumnType("int");

                    b.Property<int?>("IdRequisitoMenor")
                        .HasColumnType("int");

                    b.Property<decimal>("MontoSolicitante")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NombreSolicitante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCreditoFiscal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdReporteInspeccion");

                    b.HasIndex("IdCodigoConformidad");

                    b.HasIndex("IdCodigoSiget");

                    b.HasIndex("IdComentariosInconformidad");

                    b.HasIndex("IdDepartamentoInstalacion");

                    b.HasIndex("IdEstadoReporte");

                    b.HasIndex("IdMunicipioInstalacion");

                    b.HasIndex("IdOrganismo");

                    b.HasIndex("IdRepresentante");

                    b.HasIndex("IdRequisitoMayor");

                    b.HasIndex("IdRequisitoMenor");

                    b.ToTable("ReporteInspeccions");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.Representante", b =>
                {
                    b.Property<int>("IdRepresentante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRepresentante"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComprobanteOIA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DUI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEstadoRepresentante")
                        .HasColumnType("int");

                    b.Property<int>("IdOrganismo")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRepresentante");

                    b.HasIndex("IdEstadoRepresentante");

                    b.HasIndex("IdOrganismo");

                    b.ToTable("Representantes");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.RequisitoMayor", b =>
                {
                    b.Property<int>("IdMayores")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMayores"));

                    b.Property<string>("ArchivoCopiaCarnetElectricista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoCopiaDuiElectricista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoCopiaDuiPropietario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoCopiaDuiRetiro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoCopiaFacturaDeMateriales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoCopiaGarantiaDeTransformador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoPlanosDualesDeConstruccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoPlanosDualesDeDiseñoMinimo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("AutocadCD")
                        .HasColumnType("bit");

                    b.Property<string>("CodigoRequisito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ComprobanteDePago")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaCarnetElectricista")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaDuiElectricista")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaDuiPropietario")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaDuiRetiro")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaFacturaDeMateriales")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaGarantiaDeTransformador")
                        .HasColumnType("bit");

                    b.Property<bool?>("Factibilidad")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdOrganismo")
                        .HasColumnType("int");

                    b.Property<int?>("IdRepresentante")
                        .HasColumnType("int");

                    b.Property<bool?>("MemoriaDecalculo")
                        .HasColumnType("bit");

                    b.Property<bool?>("PlanosDualesDeConstruccion")
                        .HasColumnType("bit");

                    b.Property<bool?>("PlanosDualesDeDiseñoMinimo")
                        .HasColumnType("bit");

                    b.Property<bool?>("TotalFormularios")
                        .HasColumnType("bit");

                    b.HasKey("IdMayores");

                    b.HasIndex("IdOrganismo");

                    b.HasIndex("IdRepresentante");

                    b.ToTable("RequisitoMayors");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.RequisitoMenor", b =>
                {
                    b.Property<int>("IdMenores")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMenores"));

                    b.Property<string>("ArchivoCopiaCarnetElectricista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoCopiaDuiElectricista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoCopiaDuiPropietario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchivoCopiaDuiRetiro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoRequisito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ComprobanteDepago")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaCarnetElectricista")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaDuiElectricista")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaDuiPropietario")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaDuiRetiro")
                        .HasColumnType("bit");

                    b.Property<bool?>("CopiaTarjetaIvaEmpresa")
                        .HasColumnType("bit");

                    b.Property<bool?>("CroquisDeUbicacion")
                        .HasColumnType("bit");

                    b.Property<bool?>("CuadroDeCarga")
                        .HasColumnType("bit");

                    b.Property<bool?>("EsquemaDeInstalacionElectrica")
                        .HasColumnType("bit");

                    b.Property<bool?>("Factibilidad")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdOrganismo")
                        .HasColumnType("int");

                    b.Property<int?>("IdRepresentante")
                        .HasColumnType("int");

                    b.Property<bool?>("TotalFormularios")
                        .HasColumnType("bit");

                    b.HasKey("IdMenores");

                    b.HasIndex("IdOrganismo");

                    b.HasIndex("IdRepresentante");

                    b.ToTable("RequisitoMenors");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Independientes.Bitacora", b =>
                {
                    b.Property<int>("IdBitacora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBitacora"));

                    b.Property<DateTime>("FechaAccion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombrePersonal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoAccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBitacora");

                    b.ToTable("Bitacoras");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Independientes.JobReporte", b =>
                {
                    b.Property<int>("IdJob")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJob"));

                    b.Property<int>("IdReporteInspeccion")
                        .HasColumnType("int");

                    b.Property<string>("TokenJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJob");

                    b.ToTable("JobReportes");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.CodigoConformidad", b =>
                {
                    b.Property<int?>("IdCodigoConformidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdCodigoConformidad"));

                    b.Property<string>("Codigos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCodigoConformidad");

                    b.ToTable("CodigoConformidads");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.CodigoSiget", b =>
                {
                    b.Property<int?>("IdCodigoSiget")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdCodigoSiget"));

                    b.Property<string>("Codigos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCodigoSiget");

                    b.ToTable("CodigoSigets");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.ComentariosInconformidad", b =>
                {
                    b.Property<int>("IdComentarioInconformidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComentarioInconformidad"));

                    b.Property<string>("ComentarioInconformidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaComentario")
                        .HasColumnType("datetime2");

                    b.HasKey("IdComentarioInconformidad");

                    b.ToTable("ComentariosInconformidads");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.DepartamentoInstalacion", b =>
                {
                    b.Property<int?>("IdDepartamentoInstalacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdDepartamentoInstalacion"));

                    b.Property<string>("Departamentos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDepartamentoInstalacion");

                    b.ToTable("DepartamentoInstalacions");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.EstadoAcreditacion", b =>
                {
                    b.Property<int?>("IdEstadoAcreditacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdEstadoAcreditacion"));

                    b.Property<string>("Estados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadoAcreditacion");

                    b.ToTable("EstadoAcreditacions");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.EstadoComentario", b =>
                {
                    b.Property<int?>("IdEstadoComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdEstadoComentario"));

                    b.Property<string>("Estados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadoComentario");

                    b.ToTable("EstadoComentarios");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.EstadoPersonal", b =>
                {
                    b.Property<int?>("IdEstadoPersonal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdEstadoPersonal"));

                    b.Property<string>("Estados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadoPersonal");

                    b.ToTable("EstadoPersonals");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.EstadoReporte", b =>
                {
                    b.Property<int?>("IdEstadoReporte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdEstadoReporte"));

                    b.Property<string>("Estados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadoReporte");

                    b.ToTable("EstadoReportes");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.EstadoRepresentante", b =>
                {
                    b.Property<int?>("IdEstadoRepresentante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdEstadoRepresentante"));

                    b.Property<string>("Estados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadoRepresentante");

                    b.ToTable("EstadoRepresentantes");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.MunicipioInstalacion", b =>
                {
                    b.Property<int?>("IdMunicipioInstalacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdMunicipioInstalacion"));

                    b.Property<string>("Municipios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMunicipioInstalacion");

                    b.ToTable("MunicipioInstalacions");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.RangoPersonal", b =>
                {
                    b.Property<int?>("IdRangoPersonal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdRangoPersonal"));

                    b.Property<string>("Rangos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRangoPersonal");

                    b.ToTable("RangoPersonals");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Padres.TipoConformidad", b =>
                {
                    b.Property<int?>("IdTipoConformidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdTipoConformidad"));

                    b.Property<string>("Tipos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoConformidad");

                    b.ToTable("TipoConformidads");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.ComentarioSiget", b =>
                {
                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("IdPersonal");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.ReporteInspeccion", "ReporteInspeccion")
                        .WithMany()
                        .HasForeignKey("IdReporteInspeccion");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Representante", "Representante")
                        .WithMany()
                        .HasForeignKey("IdRepresentante");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.TipoConformidad", "TipoConformidad")
                        .WithMany()
                        .HasForeignKey("IdTipoConformidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personal");

                    b.Navigation("ReporteInspeccion");

                    b.Navigation("Representante");

                    b.Navigation("TipoConformidad");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.Organismo", b =>
                {
                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.EstadoAcreditacion", "EstadoAcreditacion")
                        .WithMany()
                        .HasForeignKey("IdEstadoAcreditacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("IdPersonal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoAcreditacion");

                    b.Navigation("Personal");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.Personal", b =>
                {
                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.EstadoPersonal", "EstadoPersonal")
                        .WithMany()
                        .HasForeignKey("IdEstadoPersonal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.RangoPersonal", "RangoPersonal")
                        .WithMany()
                        .HasForeignKey("IdRangoPersonal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoPersonal");

                    b.Navigation("RangoPersonal");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.ReporteInspeccion", b =>
                {
                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.CodigoConformidad", "CodigoConformidad")
                        .WithMany()
                        .HasForeignKey("IdCodigoConformidad");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.CodigoSiget", "CodigoSiget")
                        .WithMany()
                        .HasForeignKey("IdCodigoSiget");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.ComentariosInconformidad", "ComentariosInconformidad")
                        .WithMany()
                        .HasForeignKey("IdComentariosInconformidad");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.DepartamentoInstalacion", "DepartamentoInstalacion")
                        .WithMany()
                        .HasForeignKey("IdDepartamentoInstalacion");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.EstadoReporte", "EstadoReporte")
                        .WithMany()
                        .HasForeignKey("IdEstadoReporte");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.MunicipioInstalacion", "MunicipioInstalacion")
                        .WithMany()
                        .HasForeignKey("IdMunicipioInstalacion");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Organismo", "Organismo")
                        .WithMany()
                        .HasForeignKey("IdOrganismo");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Representante", "Representante")
                        .WithMany()
                        .HasForeignKey("IdRepresentante");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.RequisitoMayor", "RequisitoMayor")
                        .WithMany()
                        .HasForeignKey("IdRequisitoMayor");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.RequisitoMenor", "RequisitoMenor")
                        .WithMany()
                        .HasForeignKey("IdRequisitoMenor");

                    b.Navigation("CodigoConformidad");

                    b.Navigation("CodigoSiget");

                    b.Navigation("ComentariosInconformidad");

                    b.Navigation("DepartamentoInstalacion");

                    b.Navigation("EstadoReporte");

                    b.Navigation("MunicipioInstalacion");

                    b.Navigation("Organismo");

                    b.Navigation("Representante");

                    b.Navigation("RequisitoMayor");

                    b.Navigation("RequisitoMenor");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.Representante", b =>
                {
                    b.HasOne("SigetSystem.Server.Models.Entidades.Padres.EstadoRepresentante", "EstadoRepresentante")
                        .WithMany()
                        .HasForeignKey("IdEstadoRepresentante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Organismo", "Organismo")
                        .WithMany()
                        .HasForeignKey("IdOrganismo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoRepresentante");

                    b.Navigation("Organismo");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.RequisitoMayor", b =>
                {
                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Organismo", "Organismo")
                        .WithMany()
                        .HasForeignKey("IdOrganismo");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Representante", "Representante")
                        .WithMany()
                        .HasForeignKey("IdRepresentante");

                    b.Navigation("Organismo");

                    b.Navigation("Representante");
                });

            modelBuilder.Entity("SigetSystem.Server.Models.Entidades.Hijas.RequisitoMenor", b =>
                {
                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Organismo", "Organismo")
                        .WithMany()
                        .HasForeignKey("IdOrganismo");

                    b.HasOne("SigetSystem.Server.Models.Entidades.Hijas.Representante", "Representante")
                        .WithMany()
                        .HasForeignKey("IdRepresentante");

                    b.Navigation("Organismo");

                    b.Navigation("Representante");
                });
#pragma warning restore 612, 618
        }
    }
}
