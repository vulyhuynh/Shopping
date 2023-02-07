﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FooterDao
    {
        ShopDbContext db = null;

        public FooterDao()
        {
            db = new ShopDbContext();
        }

        public Footer GetFooter(int id)
        {
            return db.Footers.SingleOrDefault(x => x.ID == id);
        }
    }
}
