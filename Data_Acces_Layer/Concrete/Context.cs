using EntityLayer.concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acces_Layer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=44SwapDB;Trusted_Connection=True;MultipleActiveResultSets=True ;TrustServerCertificate=true");

        }
        public DbSet<User_Login>User_Logins { get; set; }

        public DbSet<User_Wallet>User_Wallets { get; set;}
        public DbSet<Coin>Coins { get; set;}
    }
}
