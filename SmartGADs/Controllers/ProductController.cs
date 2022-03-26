using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGADs.Models;

namespace SmartGADs.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public JsonResult Index()
        {
            ProductDB db = new ProductDB();
            ModelState.Clear();
            return Json(db.GetProduct);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product pmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDB pdb = new ProductDB();
                    if (pdb.AddProduct(pmodel))
                    {
                        ViewBag.Message = "Product Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(string pname)
        {
            ProductDB prodb=new ProductDB();
            return View(prodb.GetProduct().Find(pmodel => pmodel.Name == pname));
        }
        [HttpPost]
        public ActionResult Edit(string pname, Product pmodel)
        {
            try
            {
                ProductDB prdtdb = new ProductDB();
                prdtdb.UpdateDetails(pmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ProductDB prdb=new ProductDB();
                if (prdb.DeleteProduct(id))
                {
                    ViewBag.AlertMsg = "Product Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
                   
            }
           
        }

        // POST: ProductController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
