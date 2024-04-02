using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.concrete
{
    public class User_Wallet
    {
        [Key]
        public int WalletID { get; set; }
        [ForeignKey("User_ID")]
        public int UserID { get; set; }
        public User_Login User { get; set; }
        [ForeignKey("CoinID")]
        public int CoinID { get; set; }
        public Coin Coin { get; set; }

        public double Value { get; set; }


    }
}
