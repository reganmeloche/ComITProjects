using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComITBakery.Models;

using ComITBakery.DAL;

namespace ComITBakery.Controllers
{
    public class BatchController : Controller
    {
        IStoreBatches _batchStorage;

        public BatchController(IStoreBatches myBatchStorage)
        {
            _batchStorage = myBatchStorage;
        }

        public IActionResult Create(Guid inventoryItemId) {
            var newBatch = new Batch();
            newBatch.InventoryItemId = inventoryItemId;
            return View(newBatch);
        }

        [HttpPost]
        public IActionResult Create(Batch newBatch) {
            newBatch.RemainingQuantity = newBatch.InitialQuantity;
            newBatch.IsDeleted = false;
            _batchStorage.CreateBatch(newBatch);
            return RedirectToAction("Index", "Inventory");
        }


        public IActionResult Update(Guid inventoryItemId, Guid batchId) {
            var existingItem = _batchStorage.GetBatch(inventoryItemId, batchId);
            return View(existingItem);
        }


        [HttpPost]
        public IActionResult Update(Batch batchToUpdate) {
            _batchStorage.UpdateBatch(batchToUpdate);
            return RedirectToAction("Index", "Inventory");
        }

        [HttpPost]
        public IActionResult Delete(Guid inventoryItemId, Guid id) {
            _batchStorage.DeleteBatch(inventoryItemId, id);
            return RedirectToAction("Index", "Inventory");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
