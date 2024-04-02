using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Coin
    {
        [Key]
        public int CoinID { get; set; }
        public string? CoinUnit { get; set; }
        public string? CoinIcon { get; set; }
        public string? CoinBoild { get; set; }
    }
}
