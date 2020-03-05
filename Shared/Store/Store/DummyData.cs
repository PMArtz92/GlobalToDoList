using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Interfaces;

namespace Store
{
    public class DummyData : IDummyData
    {
        public List<TodoItemModel> AllItems()
        {
            List<TodoItemModel> allItems = new List<TodoItemModel>();
            allItems.Add(new TodoItemModel { Name = "Item01", ItemId = 1, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3) });
            allItems.Add(new TodoItemModel { Name = "Item02", ItemId = 2, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(2) });
            allItems.Add(new TodoItemModel { Name = "Item03", ItemId = 3, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3) });
            allItems.Add(new TodoItemModel { Name = "Item04", ItemId = 4, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(4) });
            allItems.Add(new TodoItemModel { Name = "Item05", ItemId = 5, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3) });

            return allItems;
        }
    }
}
