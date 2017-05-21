using MVCHomeWork.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVCHomeWork.Controllers
{
    public class CustomerContactPersonController : Controller
    {

        private 客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();
        private 客戶聯絡人Repository custrepo;
        //private CustomerEntities db = new CustomerEntities();

       public CustomerContactPersonController()
        {
            custrepo = RepositoryHelper.Get客戶聯絡人Repository(repo.UnitOfWork);
        }


        // GET: CustomerContactPerson
        public ActionResult Index()
        {
            var 客戶聯絡人 = repo.All().Include(c => c.客戶資料).Where(c => c.is刪除 != true);
            return View(客戶聯絡人.ToList());
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var 客戶聯絡人 = repo.All().Include(c => c.客戶資料).Where(s => s.姓名.Contains(search)).Where(c => c.is刪除 != true);
            return View(客戶聯絡人.ToList());
        }

        // GET: CustomerContactPerson/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: CustomerContactPerson/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(custrepo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: CustomerContactPerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                repo.Add(客戶聯絡人);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(custrepo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: CustomerContactPerson/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(custrepo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: CustomerContactPerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        {
            var 客戶聯絡人 = repo.Find(id);
            if (TryUpdateModel<客戶聯絡人>(客戶聯絡人))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(custrepo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: CustomerContactPerson/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: CustomerContactPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = repo.Find(id);
            //repo.All().Remove(客戶聯絡人);
            客戶聯絡人.is刪除 = true;
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}