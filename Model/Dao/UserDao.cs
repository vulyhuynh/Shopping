using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class UserDao
    {
        ShopDbContext db = null;

        public UserDao()
        {
            db = new ShopDbContext();
        }

        public int Login(string userName, string password)
        {
            var res = db.Users.SingleOrDefault(x => x.UserName == userName);
            if(res == null)
            {
                return 0;
            }
            else
            {
                if(res.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (res.Password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public IEnumerable<User> ListAll(int page, int pageSize)
        {
            return db.Users.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public long Insert(User entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(User entity)
        {
            var user = db.Users.Find(entity.ID);
            user.Name = entity.Name;
            user.Address = entity.Address;
            user.Email = entity.Email;
            user.Phone = entity.Phone;
            user.ModifiedDate = DateTime.Now;
            user.Status = entity.Status;
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }

        public User getByUserName(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public User getByID(int id)
        {
            return db.Users.Find(id);
        }
    }
}
