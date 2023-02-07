using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SlideDao
    {
        ShopDbContext db = null;

        public SlideDao()
        {
            db = new ShopDbContext();
        }

        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.ID == 1).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}
