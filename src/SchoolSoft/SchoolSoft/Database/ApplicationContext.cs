using Microsoft.EntityFrameworkCore;
using SchoolSoft.Model;

namespace SchoolSoft.Database
{
    /// <summary>
    /// Контекст для базы данных
    /// </summary>
    public class ApplicationContex : DbContext
    {
        // Три таблицы из базы данных

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Путь до базы данных
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}
