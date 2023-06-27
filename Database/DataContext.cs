using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frolov_Cinema.Database
{
    internal class DataContext : DbContext 
    {
        public DataContext() : base ("ConnectionString") 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Category_Film> Category_Films { get; set; }
        public DbSet<Comment_Film> Comment_Films { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Ganre_Film> Ganre_Films { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Meterage> Meterages { get; set; }
        public DbSet<Score_Film> Score_Films { get; set; }
        public DbSet<Logs> logs { get; set; }
    }
}
