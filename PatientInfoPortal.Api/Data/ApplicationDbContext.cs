using Microsoft.EntityFrameworkCore;
using PatientInfoPortal.Api.Models;
using System.Collections.Generic;

namespace PatientInfoPortal.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<Epilepsy> Epilepsy { get; set; }
        public DbSet<NCD> NCD { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<NCD_Details> NCD_Details { get; set; }
        public DbSet<Allergies_Details> Allergies_Details { get; set; }
    }
}
