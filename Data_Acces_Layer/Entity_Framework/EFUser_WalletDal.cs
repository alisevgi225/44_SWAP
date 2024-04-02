using Data_Acces_Layer.Abstract;
using Data_Acces_Layer.Concrete;
using Data_Acces_Layer.Repository;
using EntityLayer.concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acces_Layer.Entity_Framework
{
    public class EFUser_WalletDal:GenericRepository<User_Wallet>,IUser_WalletDal
    {

		public List<User_Wallet> GetWalletUserID(int id)
		{
			using (var c = new Context())
			{
				return c.Set<User_Wallet>().Include(y => y.Coin).Where(x => x.UserID == id).ToList();
			}

		}
	}
}
