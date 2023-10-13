﻿// <auto-generated />
using System;
using BlockChain.Data.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blockchain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlockChain.Data.Entities.SmartContract", b =>
                {
                    b.Property<string>("PublicKey")
                        .HasMaxLength(26)
                        .HasColumnType("nvarchar(26)");

                    b.Property<int>("MaxSupply")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(26)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("SuppySold")
                        .HasColumnType("int");

                    b.HasKey("PublicKey");

                    b.HasIndex("OwnerId");

                    b.ToTable("SmartContracts");
                });

            modelBuilder.Entity("BlockChain.Data.Entities.TransactionPurchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("AmountExchanged")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FromAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(26)");

                    b.Property<string>("ToAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(26)");

                    b.HasKey("Id");

                    b.HasIndex("FromAddress");

                    b.HasIndex("ToAddress");

                    b.ToTable("TransactionPurchases");
                });

            modelBuilder.Entity("Blockchain.Data.Entities.Account", b =>
                {
                    b.Property<string>("PublicKey")
                        .HasMaxLength(26)
                        .HasColumnType("nvarchar(26)");

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateKey")
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("nvarchar(26)");

                    b.HasKey("PublicKey");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Blockchain.Data.Entities.Nft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CollectionKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(26)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnSale")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerKey")
                        .HasColumnType("nvarchar(26)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionKey");

                    b.HasIndex("OwnerKey");

                    b.ToTable("Nfts");
                });

            modelBuilder.Entity("Blockchain.Data.Entities.TransactionContract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(26)");

                    b.Property<string>("ToAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(26)");

                    b.HasKey("Id");

                    b.HasIndex("FromAddress");

                    b.HasIndex("ToAddress");

                    b.ToTable("TransactionContracts");
                });

            modelBuilder.Entity("BlockChain.Data.Entities.SmartContract", b =>
                {
                    b.HasOne("Blockchain.Data.Entities.Account", "Owner")
                        .WithMany("SmartContracts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BlockChain.Data.Entities.TransactionPurchase", b =>
                {
                    b.HasOne("BlockChain.Data.Entities.SmartContract", "FromSmartContract")
                        .WithMany("TransactionPurchases")
                        .HasForeignKey("FromAddress")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Blockchain.Data.Entities.Account", "ToAccount")
                        .WithMany("TransactionPurchases")
                        .HasForeignKey("ToAddress")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FromSmartContract");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("Blockchain.Data.Entities.Nft", b =>
                {
                    b.HasOne("BlockChain.Data.Entities.SmartContract", "Collection")
                        .WithMany("Nfts")
                        .HasForeignKey("CollectionKey")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Blockchain.Data.Entities.Account", "Owner")
                        .WithMany("Nfts")
                        .HasForeignKey("OwnerKey")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Collection");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Blockchain.Data.Entities.TransactionContract", b =>
                {
                    b.HasOne("Blockchain.Data.Entities.Account", "FromAccount")
                        .WithMany("TransactionContracts")
                        .HasForeignKey("FromAddress")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BlockChain.Data.Entities.SmartContract", "ToSmartContract")
                        .WithMany("TransactionContracts")
                        .HasForeignKey("ToAddress")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("ToSmartContract");
                });

            modelBuilder.Entity("BlockChain.Data.Entities.SmartContract", b =>
                {
                    b.Navigation("Nfts");

                    b.Navigation("TransactionContracts");

                    b.Navigation("TransactionPurchases");
                });

            modelBuilder.Entity("Blockchain.Data.Entities.Account", b =>
                {
                    b.Navigation("Nfts");

                    b.Navigation("SmartContracts");

                    b.Navigation("TransactionContracts");

                    b.Navigation("TransactionPurchases");
                });
#pragma warning restore 612, 618
        }
    }
}
