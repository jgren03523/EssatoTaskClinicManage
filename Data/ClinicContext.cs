using EssatoTaskClinicManage.Models;
using Microsoft.EntityFrameworkCore;

namespace EssatoTaskClinicManage.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
