using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acces_Layer.Abstract
{
    public interface IUser_WalletDal:IGenericDal_<User_Wallet>
    {
		public List<User_Wallet> GetWalletUserID(int id);
	}
}
