using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    //Commented by Pasan[04/03/2020] Created TodoItemModel to store Todo Items properties. Todo list can have many Todo Items.
    public class TodoItemModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsComplete { get; set; }
        public bool IsFinished { get; set; }
        public bool? IsReoccurring { get; set; }
        public int? ReoccurringPeriod { get; set; } //This to indicate the which period of time does this item should reoccurred.
        public bool IsDeleted { get; set; }
        public List<TodoTaskModel> TodoTasks { get; set; }
    }
}
