using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ForumContext : DbContext
    {

        public ForumContext(): base("name=ForumContext")
        {
            Database.SetInitializer(new ForumDBInitializer());
        }
        
        public DbSet<User> user{get;set;}
        public DbSet<Thread> thread { get; set; }
        public DbSet<Post> post { get; set; }
        public DbSet<Board> board { get; set; }
        public DbSet<Like> like { get; set; }
    }
}
