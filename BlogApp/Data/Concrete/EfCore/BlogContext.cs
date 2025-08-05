using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class BlogContext:DbContext
    {
        //connection string ile dışarıdan bağlayacağız
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            
        }
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();
    }
}