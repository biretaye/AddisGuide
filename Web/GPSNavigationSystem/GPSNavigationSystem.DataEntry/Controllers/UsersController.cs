using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GPSNavigationSystem.Domain.DAL;
using GPSNavigationSystem.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace GPSNavigationSystem.DataEntry.Controllers
{
    public class UsersController : Controller
    {
        private GPSNavigationSystemContext db = new GPSNavigationSystemContext();

        public PartialViewResult Menu()
        {
            return PartialView();
        }

        public ActionResult LogIn()
        {
            //string hash = getHashSha256("123");
            //ViewBag.Hashed = hash;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(string username, string password)
        {

            User u = db.Users.Find(username);
            //int x = password.GetHashCode();
            //string hashedpass = x.ToString();
            string hashedpass = getHashSha256(password);
            if (u == null)
            {
                return HttpNotFound();
                //return RedirectToAction("Index");
            }
            else if (u.password.Equals(hashedpass))
            {
                Session["user"] = new User()
                {
                    username = u.username,
                    fname = u.fname,
                    lanme = u.lanme
                };
                return RedirectToAction("Index","Home");
            }


            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            //Session["user"] = null;
            return RedirectToAction("Login", "Users");
        }



        private string getHashSha256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashManager = new SHA256Managed();
            byte[] hash = hashManager.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}",x);
            }
            return hashString;
        }

        // GET: Users
        public ActionResult Index(string name)
        {
            var users = from u in db.Users
                        select u;

            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(s => s.fname.Contains(name) || s.lanme.Contains(name));
            }
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,fname,lanme,password")] User user)
        {
            if (ModelState.IsValid)
            {
                string s = user.password;
                //int x = s.GetHashCode();
                //string hashed = x.ToString();
                string hashed = getHashSha256(s);
                user.password = hashed;

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,fname,lanme,password")] User user)
        {
            if (ModelState.IsValid)
            {
                string s = user.password;
                //int x = s.GetHashCode();
                //string hashed = x.ToString();
                string hashed = getHashSha256(s);
                user.password = hashed;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
