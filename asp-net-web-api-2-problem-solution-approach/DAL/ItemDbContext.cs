﻿using Model;
using System;
using System.Data.Entity;

namespace DAL
{
    public class ItemDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ItemDbContext() : base("DefaultConnection")
        {
        }

        internal void SaveItem(Item newItem)
        {
            Items.Add(newItem);
            SaveChanges();
        }
    }
}