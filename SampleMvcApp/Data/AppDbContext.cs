using Microsoft.EntityFrameworkCore;
using SampleMvcApp.Models;

namespace SampleMvcApp.Data
{
    public class AppDbContext : DbContext
    {
        // �R���X�g���N�^�FDI�ŃI�v�V�����󂯎��
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Products�e�[�u�����`
        public DbSet<Product> Products { get; set; }
    }
}
