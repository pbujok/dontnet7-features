﻿// <auto-generated />
using System;
using EfCoreSevenFeatures.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreSevenFeatures.Migrations
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.Company.Company", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.Company.CompanyGeographicalLocation", b =>
                {
                    b.Property<decimal>("CompanyId")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("GeographicalLocationId")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId", "GeographicalLocationId");

                    b.HasIndex("GeographicalLocationId");

                    b.ToTable("CompanyGeographicalLocation");
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.Company.GeographicalLocation", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeographicalLocation");
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.People.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactEmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactTelephoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups", (string)null);

                    b.SplitToTable("GroupContactInfo", null, t =>
                        {
                            t.Property("Id")
                                .HasColumnName("PersonId");

                            t.Property("ContactEmailAddress");

                            t.Property("ContactTelephoneNumber");
                        });
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.People.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People", null, t =>
                        {
                            t.HasTrigger("SomeTrigger");
                        });
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("GroupPerson", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PeopleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "PeopleId");

                    b.HasIndex("PeopleId");

                    b.ToTable("GroupPerson");
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.Vehicles.Bike", b =>
                {
                    b.HasBaseType("EfCoreSevenFeatures.Entity.Vehicles.Vehicle");

                    b.Property<string>("FrameNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FrameSize")
                        .HasColumnType("int");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.Vehicles.Car", b =>
                {
                    b.HasBaseType("EfCoreSevenFeatures.Entity.Vehicles.Vehicle");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.Company.CompanyGeographicalLocation", b =>
                {
                    b.HasOne("EfCoreSevenFeatures.Entity.Company.Company", "Company")
                        .WithMany("GeographicalLocations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreSevenFeatures.Entity.Company.GeographicalLocation", "GeographicalLocation")
                        .WithMany("Companies")
                        .HasForeignKey("GeographicalLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("GeographicalLocation");
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.People.Group", b =>
                {
                    b.HasOne("EfCoreSevenFeatures.Entity.People.Group", null)
                        .WithOne()
                        .HasForeignKey("EfCoreSevenFeatures.Entity.People.Group", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.People.Person", b =>
                {
                    b.OwnsOne("EfCoreSevenFeatures.Entity.People.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId");

                            b1.ToTable("People");

                            b1.ToJson("Address");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("GroupPerson", b =>
                {
                    b.HasOne("EfCoreSevenFeatures.Entity.People.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreSevenFeatures.Entity.People.Person", null)
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.Company.Company", b =>
                {
                    b.Navigation("GeographicalLocations");
                });

            modelBuilder.Entity("EfCoreSevenFeatures.Entity.Company.GeographicalLocation", b =>
                {
                    b.Navigation("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
