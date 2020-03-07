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
            //Commented by Pasan[06/03/2020] When we retrieving the tasks we consider the Todo Item Id and task Id both. So Task can have same Ids.            
            List<TodoTaskModel> item01Tasks = new List<TodoTaskModel>();
            item01Tasks.Add(new TodoTaskModel { TaskId = 1, Name = "task01", IsFinished = true});
            item01Tasks.Add(new TodoTaskModel { TaskId = 2, Name = "task02", IsFinished = true });
            item01Tasks.Add(new TodoTaskModel { TaskId = 3, Name = "task03" });

            List<TodoTaskModel> item02Tasks = new List<TodoTaskModel>();
            item02Tasks.Add(new TodoTaskModel { TaskId = 1, Name = "task01", IsFinished = true });
            item02Tasks.Add(new TodoTaskModel { TaskId = 2, Name = "task02", IsFinished = true });
            item02Tasks.Add(new TodoTaskModel { TaskId = 3, Name = "task03", IsFinished = true });

            List<TodoItemModel> allItems = new List<TodoItemModel>();
            allItems.Add(new TodoItemModel { Name = "Item01", ItemId = 1, IsComplete = true, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3), TodoTasks = item01Tasks });
            allItems.Add(new TodoItemModel { Name = "Item02", ItemId = 2, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(2), TodoTasks = item02Tasks });
            allItems.Add(new TodoItemModel { Name = "Item03", ItemId = 3, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3) });
            allItems.Add(new TodoItemModel { Name = "Item04", ItemId = 4, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(4) });
            allItems.Add(new TodoItemModel { Name = "Item05", ItemId = 5, StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(3) });

            return allItems;
        }
    }
}
