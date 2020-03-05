using System;
using System.Collections.Generic;

namespace Entities
{
    //Commented by Pasan[04/03/2020] Created TodoListModel to store global Todo list properties. 
    public class TodoListModel
    {
        public int TodoId { get; set; }
        public string Name { get; set; }
        public List<TodoItemModel> TodoItems { get; set; }
    }
}
