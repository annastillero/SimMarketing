using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimMarketing.Models;

namespace SimMarketing.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SimMarketing.Models.InquiryInformation> InquiryInformation { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=54.174.175.109;Initial Catalog=SIMMarketing;User ID=dbayadmin;Password=Aam@2006;Trust Server Certificate=True;");

        public DbSet<SimMarketing.Models.CompanyInformation> CompanyInformation { get; set; } = default!;

        public DbSet<SimMarketing.Models.ProductInformation> ProductInformation { get; set; } = default!;

    }
}
