using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Interfaces
{
    public interface IListStore 
    {
        TodoListModel TodoList { get; }
        TodoItemModel TodoItem { get; }
    }
}
