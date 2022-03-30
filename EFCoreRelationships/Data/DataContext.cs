using EFCoreRelationships.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Data
{
    public class DataContext : DbContext   
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        /// <summary>
        /// A Users DbSet for creating a table of Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// A Characters DbSet for creating a table of Characters
        /// </summary>
        public DbSet<Character> Characters { get; set; }

        /// <summary>
        /// A Weapons DbSet for creating a table of Weapons
        /// </summary>
        public DbSet<Weapon> Weapons { get; set; }

        /// <summary>
        /// A Skills DbSet for creating a table of Skills
        /// </summary>
        public DbSet<Skill> Skills { get; set; }
    }
}
