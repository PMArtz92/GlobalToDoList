using System;
using Entities;

namespace Interfaces
{
    public interface ITodoListOperator
    {
        int CreateTodoList(TodoListModel todoList);
        int AddItemToTodoList(TodoItemModel todoItem);

        int RemoveItemFromTodoList(TodoItemModel todoId);
    }
}
