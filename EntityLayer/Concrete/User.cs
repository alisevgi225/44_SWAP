using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.concrete
{
    public class User_Login
    {
        [Key]
        public int User_ID { get; set; }
        public string? Words { get; set; }

    }
}
