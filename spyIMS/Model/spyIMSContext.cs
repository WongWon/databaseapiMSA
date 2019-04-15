using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace spyIMS.Model
{
    public partial class spyIMSContext : DbContext
    {
        public spyIMSContext()
        {
        }

        public spyIMSContext(DbContextOptions<spyIMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Spies> Spies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:spyims.database.windows.net,1433;Initial Catalog=spyIMS;Persist Security Info=False;User ID=dwon782;Password=Nzmsa123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Spies>(entity =>
            {
                entity.Property(e => e.FavouriteWeapon).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);
            });
        }
    }
}
