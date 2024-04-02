using Business_Layer.Abstract;
using Data_Acces_Layer.Abstract;
using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concrete
{
    public class User_WalletManager : IGenericService<User_Wallet>, IUser_WalletService

    {
        IUser_WalletDal user_WalletDal;

        public User_WalletManager(IUser_WalletDal user_WalletDal)
        {
            this.user_WalletDal = user_WalletDal;
        }

        public User_Wallet TGetById(int id)
        {
            return user_WalletDal.GetByID(id);
        }

        public void TDelete(User_Wallet t)
        {
           user_WalletDal.Delete(t);
        }

        public List<User_Wallet> TGetList()
        {
            return user_WalletDal.GetList();
        }

        public void TInsert(User_Wallet t)
        {
            user_WalletDal.Insert(t);
        }

        public void TUpdate(User_Wallet t)
        {
            user_WalletDal.Update(t);
        }

		public List<User_Wallet> TGetWalletUserID(int id)
		{
           return user_WalletDal.GetWalletUserID(id);
		}
	}
}
