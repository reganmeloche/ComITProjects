using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using ComITBakery.Models;

namespace ComITBakery.DAL
{
    public class BakeryContext : IdentityDbContext
    {
        public BakeryContext(DbContextOptions<BakeryContext> options) : base(options) {}
        public DbSet<InventoryItem> Items {get;set;}
    }
}