using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VeulemanTrainingPlatform.Models;

namespace VeulemanTrainingPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ContentPage> ContentPages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().ToTable("Course");
            builder.Entity<Chapter>().ToTable("Chapter");
            builder.Entity<ContentPage>().ToTable("ContentPage");
            builder.Entity<QuizPage>().ToTable("QuizPage");
            builder.Entity<FinalPage>().ToTable("FinalPage");

            base.OnModelCreating(builder);
        }

        public DbSet<VeulemanTrainingPlatform.Models.QuizPage> QuizPage { get; set; }

        public DbSet<VeulemanTrainingPlatform.Models.FinalPage> FinalPage { get; set; }
    }
}