using _3.DAL;
using _4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BL
{
    public class UserManager
    {
        //referene to the DB.
        private Movies_Rental_DBEntities ctx;

        public UserManager()
        {
            ctx = new Movies_Rental_DBEntities();
        }

        //return all users from DB.
        public List<Users> Users
        {
            get
            {
                return ctx.Users.Where(u => u.IsSctiv == true).ToList();
            }
        }

        //return the selected user by his UserID.
        public Users GetById(int userId)
        {
            return ctx.Users.Where(u => u.UserID == userId).FirstOrDefault();
        }

        public bool Insert(Users newUser)
        {
            ctx = new Movies_Rental_DBEntities();
            
                ctx.Users.Add(newUser);
                int count = ctx.SaveChanges();

                return count > 0;
        }

      
    }
}
