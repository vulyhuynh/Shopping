﻿using Model.Dao;
using Shop.Areas.Admin.Models;
using Shop.commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var res = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (res == 1)
                {
                    var user = dao.getByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserID = user.ID;
                    userSession.UserName = user.UserName;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");

                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!");

                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng!");

                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công!");
                }
            }
            return View("Index");
        }
    }
}