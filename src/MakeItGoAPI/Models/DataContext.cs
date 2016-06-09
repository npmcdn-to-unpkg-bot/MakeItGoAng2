
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MakeItGoAPI.Models
{
    public class DataContext : DbContext{
        public virtual  DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }




        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {


            modelBuilder.Entity<DoctorSpeciality>()
             .HasKey(t => new { t.DoctorId, t.SpecialityId });

            modelBuilder.Entity<DoctorSpeciality>()
                .HasOne(pt => pt.Doctor)
                .WithMany(p => p.DoctorSpecialities)
                .HasForeignKey(pt => pt.DoctorId);

            modelBuilder.Entity<DoctorSpeciality>()
                .HasOne(pt => pt.Speciality)
                .WithMany(t => t.DoctorSpecialities)
                .HasForeignKey(pt => pt.SpecialityId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WellBell;Trusted_Connection=True;");
        }



    }
}
