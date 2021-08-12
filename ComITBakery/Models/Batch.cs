using System;

namespace ComITBakery.Models
{
    public class Batch
    {
        public Guid Id {get;set;}
        public Guid InventoryItemId {get;set;}
        public int InitialQuantity {get;set;}
        public int RemainingQuantity {get;set;}
        public DateTime ProductionDate {get;set;}
        public bool IsDeleted {get;set;}
    }
}
