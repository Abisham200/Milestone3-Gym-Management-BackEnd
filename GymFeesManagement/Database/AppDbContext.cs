using GymFeesManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymFeesManagement.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //  .HasMany(u => u.Tasks)
            //  .WithOne(t => t.Assignee)
            //  .HasForeignKey(t => t.AssigneeId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet <User> Users { get; set; }
        public DbSet<Entrollment> Entrollments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<GymProgram> Programs { get; set; }
        public DbSet<SkippedPayment> SkippedPayments { get; set; }



    }
}
