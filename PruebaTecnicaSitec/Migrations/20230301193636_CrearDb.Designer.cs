﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PruebaTecnicaSitec.Data;

#nullable disable

namespace PruebaTecnicaSitec.Migrations
{
    [DbContext(typeof(ContextoDb))]
    [Migration("20230301193636_CrearDb")]
    partial class CrearDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("DNICliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TelefonoCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("DescripcionProducto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("integer");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PrecioProducto")
                        .HasColumnType("numeric");

                    b.Property<int>("StockProducto")
                        .HasColumnType("integer");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Venta", b =>
                {
                    b.Property<int>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdVenta"));

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<decimal?>("TotalAntesDeImpuestos")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("TotalDespuesDeImpuestos")
                        .HasColumnType("numeric");

                    b.HasKey("IdVenta");

                    b.HasIndex("IdCliente");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.VentaProducto", b =>
                {
                    b.Property<int>("IdVentaProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdVentaProducto"));

                    b.Property<int>("CantidadProducto")
                        .HasColumnType("integer");

                    b.Property<int>("IdProducto")
                        .HasColumnType("integer");

                    b.Property<int>("IdVenta")
                        .HasColumnType("integer");

                    b.Property<decimal>("SubtotalProducto")
                        .HasColumnType("numeric");

                    b.HasKey("IdVentaProducto");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdVenta");

                    b.ToTable("VentaProductos");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Producto", b =>
                {
                    b.HasOne("PruebaTecnicaSitec.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Venta", b =>
                {
                    b.HasOne("PruebaTecnicaSitec.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.VentaProducto", b =>
                {
                    b.HasOne("PruebaTecnicaSitec.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaTecnicaSitec.Models.Venta", "Venta")
                        .WithMany()
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });
#pragma warning restore 612, 618
        }
    }
}
