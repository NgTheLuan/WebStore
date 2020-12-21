using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebStore.Models;
using System.Security.Cryptography;
using System.Text;


namespace WebStore.Controllers
{
    public class UserController : Controller
    {
        ModelWebStore db = new ModelWebStore();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel UserModel)
        {
            if (ModelState.IsValid)
            {
                USERMANAGER usermanager = new USERMANAGER();
                if (usermanager.checkUserName(UserModel.UserName) && usermanager.checkEmail(UserModel.Email))
                {
                    USER usr = new USER();
                    usr.FName = UserModel.FName;
                    usr.LName = UserModel.LName;
                    usr.PhoneNumber = UserModel.PhoneNumber;
                    usr.Address = UserModel.Address;
                    usr.UserName = UserModel.UserName;
                    usr.Email = UserModel.Email;
                    //Password encryption
                    usr.Password = Encryptor.MD5Hash(UserModel.Password);

                    db.USERs.Add(usr); //New add to dataset
                    db.SaveChanges(); //Update data to the database 
                    return RedirectToAction("Index", "Home"); //View("Success"); 
                }
                else
                {
                    ModelState.AddModelError("Register", "UserName already exists !");
                    return View(); //Returns the input form
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string UserNameLogin = form["TxtUserName"].ToString();
                string PassWordLogin = form["TxtPassword"].ToString();
                USER us = new USER();
                USERMANAGER usrmana = new USERMANAGER();
                if (usrmana.checkLogin(UserNameLogin, Encryptor.MD5Hash(PassWordLogin)))
                {
                    Session["logged"] = UserNameLogin;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Login", "Username or Password is wrong, please try again!");
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["Logged"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}