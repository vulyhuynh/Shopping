using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        ShopDbContext db = null;

        public MenuDao()
        {
            db = new ShopDbContext();
        }

        public List<Menu> ListByGroupID(int groupID)
        {
            return db.Menus.Where(x => x.TypeID == groupID).ToList();
        }
    }
}
