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
    public class User_LoginManager : IGenericService<User_Login>, IUser_LoginService
    {
        IUser_LoginDal user_LoginDal;

        public User_LoginManager(IUser_LoginDal user_LoginDal)
        {
            this.user_LoginDal = user_LoginDal;
        }

        public User_Login TGetById(int id)
        {
            return user_LoginDal.GetByID(id);
        }

        public void TDelete(User_Login t)
        {
            user_LoginDal.Delete(t);
        }

        public List<User_Login> TGetList()
        {
            return user_LoginDal.GetList();
        }

        public void TInsert(User_Login t)
        {
            user_LoginDal.Insert(t);    
        }

        public void TUpdate(User_Login t)
        {
            user_LoginDal.Update(t);
        }
    }
}
