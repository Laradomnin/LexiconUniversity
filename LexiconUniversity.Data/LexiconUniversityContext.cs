using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LexiconUniversity.Core;

namespace LexiconUniversity.Data
{
    public class LexiconUniversityContext : DbContext
    {
        public LexiconUniversityContext (DbContextOptions<LexiconUniversityContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; } = default!;

        public DbSet<Student>? Student { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            // Fluent API
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Enrollment>(
                e => e.HasOne(e => e.Course).WithMany(c => c.Enrollments),
                e => e.HasOne(e => e.Student).WithMany(c => c.Enrollments));
        }

        
        
        

       
    }
}
