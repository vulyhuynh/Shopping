using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        ShopDbContext db = null;

        public ProductDao()
        {
            db = new ShopDbContext();
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderBy(y => y.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot < DateTime.Now).OrderBy(y => y.CreatedDate).Take(top).ToList();
        }
    }
}
