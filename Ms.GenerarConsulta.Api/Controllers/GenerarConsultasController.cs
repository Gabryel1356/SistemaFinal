using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ms.GenerarConsulta.Api.Controllers
{
    [ApiController]

    public class GenerarConsultasController : Controller
    {
        




        public ActionResult Index()
        {
            return View();
        }

        // GET: GenerarConsultasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenerarConsultasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenerarConsultasController/Create
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

        // GET: GenerarConsultasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenerarConsultasController/Edit/5
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

        // GET: GenerarConsultasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenerarConsultasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
