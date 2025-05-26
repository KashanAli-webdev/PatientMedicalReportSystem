using Microsoft.EntityFrameworkCore;
using PatientRecordCURDWebApp.Models;

namespace PatientRecordCURDWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
    }
}
