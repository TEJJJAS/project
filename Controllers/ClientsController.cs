using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ClientsController : Controller
    {
        // GET: ClientController
        public ActionResult Index()
        {
            List<Clients> lstCli = Clients.GetAllClients();
            return View(lstCli);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            Clients obj = Clients.GetSingleClient(id.Value);
            return View(obj);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clients obj)
        {
            try
            {
                Clients.InsertClient(obj);
                ViewBag.message = "Success!";
                return View();
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            Clients obj = Clients.GetSingleClient(id.Value);
            return View(obj);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Clients obj)
        {
            try
            {
                Clients.UpdateClient(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Clients obj = Clients.GetSingleClient(id.Value);
            return View(obj);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Clients obj)
        {
            try
            {
                Clients.DeleteClient(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
