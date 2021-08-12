using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using ComITBakery.Models;


namespace ComITBakery.DAL
{
    public class EFBatchStorage : IStoreBatches
    {
        readonly BakeryContext _context;
        IStoreInventoryItems _inventoryStorage;

        public EFBatchStorage(BakeryContext myContext, IStoreInventoryItems myInventoryStorage) {
            _context = myContext;
            _inventoryStorage = myInventoryStorage;
        }

        public Batch GetBatch(Guid inventoryItemId, Guid batchId) {
            var item = _inventoryStorage.GetById(inventoryItemId);
            var batch = item.Batches.FirstOrDefault(x => x.Id == batchId);
            return batch;
        }

        public void CreateBatch(Batch batchToCreate) {
            var item = _inventoryStorage.GetById(batchToCreate.InventoryItemId);
            item.Batches.Add(batchToCreate);
            _context.SaveChanges();
        }

        public void UpdateBatch(Batch batchToUpdate) {
            var batch = GetBatch(batchToUpdate.InventoryItemId, batchToUpdate.Id);
            batch.RemainingQuantity = batchToUpdate.RemainingQuantity;
            _context.SaveChanges();
        }

        public void DeleteBatch(Guid inventoryItemId, Guid batchId) {
            var batch = GetBatch(inventoryItemId, batchId);
            batch.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}