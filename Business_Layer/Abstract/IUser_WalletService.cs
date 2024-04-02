using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
    public interface IUser_WalletService:IGenericService<User_Wallet>
    {
		public List<User_Wallet> TGetWalletUserID(int id);
	}
}
