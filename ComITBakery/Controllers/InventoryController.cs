using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComITBakery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using ComITBakery.DAL;

namespace ComITBakery.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        IStoreInventoryItems _inventoryStorage;
        private readonly UserManager<IdentityUser> _userManager;

        public InventoryController(IStoreInventoryItems myInventoryStorage, UserManager<IdentityUser> userManager)
        {
            _inventoryStorage = myInventoryStorage;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var items = _inventoryStorage.GetAllItems(UserId());
            return View(items);
        }

        public IActionResult Details(Guid id) {
            var item = _inventoryStorage.GetById(id);
            return View(item);
        }

        public IActionResult Create() {
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(InventoryItem newItem) {
            newItem.Id = Guid.NewGuid();
            newItem.Batches = new List<Batch>();
            newItem.IsDeleted = false;
            newItem.UserId = UserId();
            _inventoryStorage.CreateInventoryItem(newItem);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id) {
            var existingItem = _inventoryStorage.GetById(id);
            ViewBag.IsEditing = true;
            return View("Upsert", existingItem);
        }

        [HttpPost]
        public IActionResult Update(InventoryItem itemToUpdate) {
            itemToUpdate.UserId = UserId();
            _inventoryStorage.UpdateInventoryItem(itemToUpdate);
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult Delete(Guid id) {
            _inventoryStorage.DeleteInventoryItem(id);
            return RedirectToAction("Index"); 
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Guid UserId() {
            var userId = _userManager.GetUserId(User);
            return Guid.Parse(userId);
        }
    }
}
