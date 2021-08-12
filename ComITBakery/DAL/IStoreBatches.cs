using System;
using System.Collections.Generic;

using ComITBakery.Models;

namespace ComITBakery.DAL
{
    public interface IStoreBatches
    {
        Batch GetBatch(Guid inventoryItemId, Guid batchId);

        void CreateBatch(Batch batchToCreate);

        void UpdateBatch(Batch batchToUpdate);

        void DeleteBatch(Guid inventoryItemId, Guid id);
    }
}