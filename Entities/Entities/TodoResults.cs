using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class TodoResults
    {
        public int status { get; set; }
        public List<TodoItemModel> results { get; set; }
    }
}
