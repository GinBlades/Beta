using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Beta.Models;
using Beta.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Beta.Controllers
{
    public class DemoController : Controller
    {
        private readonly IDemoService _service;
        public DemoController(IDemoService service) {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetDemosAsync());
        }

        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return BadRequest();
            }
            Demo demo = await _service.GetDemoByIdAsync(id.Value);
            if (demo == null) {
                return NotFound();
            }

            return View(demo);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Active,Email,Name,Price,PublishAt")]Demo demo) {
            if (ModelState.IsValid) {
                await _service.AddDemoAsync(demo);
                return RedirectToAction("Details", new { id = demo.Id });
            }
            return View(demo);
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return BadRequest();
            }

            Demo demo = await _service.GetDemoByIdAsync(id.Value);
            if (demo == null) {
                return NotFound();
            }

            return View(demo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Active,Email,Name,Price,PublishAt")]Demo demo) {
            if (id == null) {
                return BadRequest();
            }
            demo.Id = id.Value;

            if (ModelState.IsValid) {
                await _service.UpdateDemoAsync(demo);
                return RedirectToAction("Details", new { id = demo.Id });
            }

            return View(demo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return BadRequest();
            }

            Demo demo = await _service.GetDemoByIdAsync(id.Value);
            if (demo == null) {
                return NotFound();
            }
            await _service.DeleteDemoAsync(demo.Id);
            return RedirectToAction("Index");
        }
    }
}
