using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using ComITBakery.Models;


namespace ComITBakery.DAL
{
    public class EFInventoryItemStorage : IStoreInventoryItems
    {
        readonly BakeryContext _context;

        public EFInventoryItemStorage(BakeryContext myContext) {
            _context = myContext;
        }

        public List<InventoryItem> GetAllItems(Guid userId) {
            var result = _context.Items
                .Include(x => x.Batches)
                .Where(x => x.IsDeleted == false && x.UserId == userId)
                .ToList();
            return result;
        }

        public InventoryItem GetById(Guid id) {
            var result = _context.Items
                .Include(x => x.Batches)
                .FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            return result;
        }

        public void CreateInventoryItem(InventoryItem itemToCreate) {
            _context.Add(itemToCreate);
            _context.SaveChanges();
        }

        public void UpdateInventoryItem(InventoryItem itemToUpdate) {
            _context.Update(itemToUpdate);
            _context.SaveChanges();
        }

        public void DeleteInventoryItem(Guid id) {
            var itemToDelete = GetById(id);
            itemToDelete.IsDeleted = true;
            _context.Update(itemToDelete);
            _context.SaveChanges();
        }

    }
}