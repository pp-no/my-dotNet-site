using Microsoft.EntityFrameworkCore;
using SampleMvcApp.Models;

namespace SampleMvcApp.Data
{
    public class AppDbContext : DbContext
    {
        // コンストラクタ：DIでオプション受け取り
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Productsテーブルを定義
        public DbSet<Product> Products { get; set; }
    }
}
