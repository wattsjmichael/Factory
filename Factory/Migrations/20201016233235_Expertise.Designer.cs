﻿// <auto-generated />
using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Factory.Migrations
{
    [DbContext(typeof(FactoryContext))]
    [Migration("20201016233235_Expertise")]
    partial class Expertise
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Factory.Models.Engineer", b =>
                {
                    b.Property<int>("EngineerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EngineerDate");

                    b.Property<string>("EngineerName");

                    b.HasKey("EngineerId");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("Factory.Models.EngineerExpertise", b =>
                {
                    b.Property<int>("EngineerExpertiseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EngineerId");

                    b.Property<int>("ExpertiseId");

                    b.HasKey("EngineerExpertiseId");

                    b.HasIndex("EngineerId");

                    b.HasIndex("ExpertiseId");

                    b.ToTable("EngineerExpertise");
                });

            modelBuilder.Entity("Factory.Models.EngineerMachine", b =>
                {
                    b.Property<int>("EngineerMachineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EngineerId");

                    b.Property<int>("MachineId");

                    b.HasKey("EngineerMachineId");

                    b.HasIndex("EngineerId");

                    b.HasIndex("MachineId");

                    b.ToTable("EngineerMachine");
                });

            modelBuilder.Entity("Factory.Models.Expertise", b =>
                {
                    b.Property<int>("ExpertiseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExpertiseArea");

                    b.HasKey("ExpertiseId");

                    b.ToTable("Expertises");
                });

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MachineInstall");

                    b.Property<string>("MachineName");

                    b.HasKey("MachineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Factory.Models.EngineerExpertise", b =>
                {
                    b.HasOne("Factory.Models.Engineer", "Engineer")
                        .WithMany()
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.Expertise", "Expertise")
                        .WithMany("Engineers")
                        .HasForeignKey("ExpertiseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Factory.Models.EngineerMachine", b =>
                {
                    b.HasOne("Factory.Models.Engineer", "Engineer")
                        .WithMany("Machines")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.Machine", "Machine")
                        .WithMany("Engineers")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
