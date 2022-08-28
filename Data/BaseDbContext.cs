using BookStoreMVCDemo.Models.Domain;
using Microsoft.EntityFrameworkCore;
using BookStoreMVCDemo.Models.Domain;

namespace BookStoreMVCDemo.Data
{
    public class BaseDbContext  : DbContext
    {
        public BaseDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<UserModel> UserModel { get; set; }

        public DbSet<BookModel> BookModel { get; set; }
    }
}
