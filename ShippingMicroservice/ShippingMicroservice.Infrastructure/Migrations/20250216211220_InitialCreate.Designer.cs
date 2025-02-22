﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingMicroservice.Infrastructure.Data;

#nullable disable

namespace ShippingMicroservice.Infrastructure.Migrations
{
    [DbContext(typeof(ShippingMicroserviceDbContext))]
    [Migration("20250216211220_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShippingMicroservice.Domain.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("ShippingMicroservice.Domain.Entities.Shipper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("ShippingMicroservice.Domain.Entities.ShipperRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("ShipperId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("ShipperId");

                    b.ToTable("ShipperRegions");
                });

            modelBuilder.Entity("ShippingMicroservice.Domain.Entities.ShippingDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ShipperId")
                        .HasColumnType("int");

                    b.Property<string>("ShippingStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShipperId");

                    b.ToTable("ShippingDetails");
                });

            modelBuilder.Entity("ShippingMicroservice.Domain.Entities.ShipperRegion", b =>
                {
                    b.HasOne("ShippingMicroservice.Domain.Entities.Region", "Region")
                        .WithMany("ShipperRegions")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingMicroservice.Domain.Entities.Shipper", "Shipper")
                        .WithMany("ShipperRegions")
                        .HasForeignKey("ShipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("ShippingMicroservice.Domain.Entities.ShippingDetails", b =>
                {
                    b.HasOne("ShippingMicroservice.Domain.Entities.Shipper", "Shipper")
                        .WithMany()
                        .HasForeignKey("ShipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("ShippingMicroservice.Domain.Entities.Region", b =>
                {
                    b.Navigation("ShipperRegions");
                });

            modelBuilder.Entity("ShippingMicroservice.Domain.Entities.Shipper", b =>
                {
                    b.Navigation("ShipperRegions");
                });
#pragma warning restore 612, 618
        }
    }
}
