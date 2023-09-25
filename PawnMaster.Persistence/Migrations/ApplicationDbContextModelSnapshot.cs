﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PawnMaster.Persistence.Data;

#nullable disable

namespace PawnMaster.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PawnMaster.Persistence.Data.Ficha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("EnJuego")
                        .HasColumnType("bit");

                    b.Property<int>("NumeroMovimientos")
                        .HasColumnType("int");

                    b.Property<string>("PosiciónHorizontal")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("PosiciónVertical")
                        .HasColumnType("int");

                    b.Property<int>("partidaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("partidaId");

                    b.ToTable("Fichas");
                });

            modelBuilder.Entity("PawnMaster.Persistence.Data.Partida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Ganador")
                        .HasColumnType("int");

                    b.Property<int>("JugadorBlancoId")
                        .HasColumnType("int");

                    b.Property<int>("JugadorNegroId")
                        .HasColumnType("int");

                    b.Property<string>("ListaDeMovimientos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PartidaEnJuego")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("TiempoDeJuego")
                        .HasColumnType("time");

                    b.Property<int>("TurnoPartida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JugadorBlancoId");

                    b.HasIndex("JugadorNegroId");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("PawnMaster.Persistence.Data.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreacionCuenta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RutaImagen")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PawnMaster.Persistence.Data.Ficha", b =>
                {
                    b.HasOne("PawnMaster.Persistence.Data.Partida", "Partida")
                        .WithMany()
                        .HasForeignKey("partidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partida");
                });

            modelBuilder.Entity("PawnMaster.Persistence.Data.Partida", b =>
                {
                    b.HasOne("PawnMaster.Persistence.Data.Usuario", "JugadorBlanco")
                        .WithMany("PartidasJugadasComoBlancas")
                        .HasForeignKey("JugadorBlancoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PawnMaster.Persistence.Data.Usuario", "JugadorNegro")
                        .WithMany("PartidasJugadasComoNegras")
                        .HasForeignKey("JugadorNegroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JugadorBlanco");

                    b.Navigation("JugadorNegro");
                });

            modelBuilder.Entity("PawnMaster.Persistence.Data.Usuario", b =>
                {
                    b.Navigation("PartidasJugadasComoBlancas");

                    b.Navigation("PartidasJugadasComoNegras");
                });
#pragma warning restore 612, 618
        }
    }
}
