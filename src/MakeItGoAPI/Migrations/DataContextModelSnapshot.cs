using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MakeItGoAPI.Models;

namespace MakeItGoAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MakeItGoAPI.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<int?>("DoctorId");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("AddressId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MakeItGoAPI.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Title");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MakeItGoAPI.Models.DoctorSpeciality", b =>
                {
                    b.Property<int>("DoctorId");

                    b.Property<int>("SpecialityId");

                    b.HasKey("DoctorId", "SpecialityId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("DoctorSpeciality");
                });

            modelBuilder.Entity("MakeItGoAPI.Models.Speciality", b =>
                {
                    b.Property<int>("SpecialityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SpecialityName");

                    b.HasKey("SpecialityId");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("MakeItGoAPI.Models.Address", b =>
                {
                    b.HasOne("MakeItGoAPI.Models.Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("MakeItGoAPI.Models.DoctorSpeciality", b =>
                {
                    b.HasOne("MakeItGoAPI.Models.Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MakeItGoAPI.Models.Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
