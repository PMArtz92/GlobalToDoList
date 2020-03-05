using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Entities;

namespace Interfaces
{
    public interface ITodoItemOperator
    {
        int CreateTodoItem(TodoItemModel todoItem);
        TodoResults GetAllFinishedItems();
        TodoResults GetAllUnfinishedItems();
        TodoResults GetTodoItemsForGiveTimePeriod(int timePeriod);
        int SetTodoItemComplete(TodoItemModel todoItem);
        int SetTodoItemFinish(TodoItemModel todoItem);
    }
}
