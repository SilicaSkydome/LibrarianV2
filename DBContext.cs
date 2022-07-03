using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Librarian
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=librarianDatabase")
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Request)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
