using System;
using Entities;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Operator
{
    public class TodoListOperator : ITodoListOperator
    {
        private readonly IListStore _store;
        private readonly IDummyData _dummyData;
        public TodoListOperator(IListStore store, IDummyData dummyData)
        {
            _store = store;
            _dummyData = dummyData;
        }

        //Commented by Pasan[04/03/2020] This method will creates the global todo list.
        public int CreateTodoList(TodoListModel todoList)
        {
            if(todoList.Name == null)
            {
                return OperationStatusCodes.INVALID_PARAMTERS;
            }

            TodoListModel newTodoList = new TodoListModel();
            newTodoList.Name = todoList.Name;

            return OperationStatusCodes.SUCCESS;
        }

        public int AddItemToTodoList(TodoItemModel todoItem)
        {
            if(todoItem.Name == null)
            {
                return OperationStatusCodes.INVALID_PARAMTERS;
            }

            if(todoItem.StartDate == null || todoItem.EndDate == null)
            {
                return OperationStatusCodes.INVALID_PARAMTERS;
            }

            if (todoItem.IsReoccurring == true && todoItem.ReoccurringPeriod == null)
            {
                return OperationStatusCodes.INVALID_PARAMTERS;
            }

            _store.TodoList.TodoItems.Add(todoItem);
            return OperationStatusCodes.SUCCESS;
        }

        public int RemoveItemFromTodoList(TodoItemModel todoItem)
        {
            if(todoItem.ItemId == 0)
            {
                return OperationStatusCodes.INVALID_PARAMTERS;
            }

            TodoItemModel itemToRemove = _dummyData.AllItems().FirstOrDefault(t => t.ItemId == todoItem.ItemId);

            if(itemToRemove == null)
            {
                return OperationStatusCodes.NOT_FOUND;
            }

            _store.TodoList.TodoItems.Remove(itemToRemove);
            return OperationStatusCodes.SUCCESS;

        }
    }
}
