using Model.Dao;
using Model.EF;
using Shop.commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Shop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            var ses = Session[CommonConstants.USER_SESSION];
            if (ses == null)
                return RedirectToAction("Index", "Login");

            var dao = new UserDao();
            var model = dao.ListAll(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                user.Password = Encryptor.MD5Hash(user.Password); ;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công!");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var user = new UserDao().getByID(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    user.Password = Encryptor.MD5Hash(user.Password);
                }
                bool res = dao.Update(user);
                if (res)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thành công!");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            bool res = dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}