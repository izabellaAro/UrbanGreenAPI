﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrbanGreen.DataAcess.Persistence;

#nullable disable

namespace UrbanGreen.DataAcess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240714205805_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UrbanGreen.Core.Entities.Fornecedor", b =>
                {
                    b.Property<int>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FornecedorId"));

                    b.Property<int>("InsumoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PessoaJuridicaId")
                        .HasColumnType("int");

                    b.HasKey("FornecedorId");

                    b.HasIndex("InsumoId");

                    b.HasIndex("PessoaJuridicaId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.Inspecao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Colheita")
                        .HasColumnType("bit");

                    b.Property<bool>("ControlePragas")
                        .HasColumnType("bit");

                    b.Property<bool>("CuidadoSolo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Irrigacao")
                        .HasColumnType("bit");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<bool>("SelecaoSemente")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Inspecoes");
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemPedidoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeComprador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ItemPedidoId")
                        .IsUnique();

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("PessoaJuridica");
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Imagem")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasMaxLength(5000)
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasMaxLength(10000)
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("UrbanGreenAPI.Core.Entities.Insumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasMaxLength(5000)
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasMaxLength(10000)
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Insumos");
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.Fornecedor", b =>
                {
                    b.HasOne("UrbanGreenAPI.Core.Entities.Insumo", "Insumo")
                        .WithMany()
                        .HasForeignKey("InsumoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UrbanGreen.Core.Entities.PessoaJuridica", "PessoaJuridica")
                        .WithMany()
                        .HasForeignKey("PessoaJuridicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumo");

                    b.Navigation("PessoaJuridica");
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.Inspecao", b =>
                {
                    b.HasOne("UrbanGreen.Core.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.ItemPedido", b =>
                {
                    b.HasOne("UrbanGreen.Core.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.Pedido", b =>
                {
                    b.HasOne("UrbanGreen.Core.Entities.ItemPedido", null)
                        .WithOne("Pedido")
                        .HasForeignKey("UrbanGreen.Core.Entities.Pedido", "ItemPedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UrbanGreen.Core.Entities.ItemPedido", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
