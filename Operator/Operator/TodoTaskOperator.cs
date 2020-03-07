using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Entities;
using Store;
using System.Linq;


namespace Operator
{
    public class TodoTaskOperator : ITodoTaskOperator
    {
        private readonly IListStore _store;
        private readonly IDummyData _dummyData;
        public TodoTaskOperator(IListStore store, IDummyData dummyData)
        {
            _store = store;
            _dummyData = dummyData;
        }
        public int SetItemTaskFinish(int todoItemId, int todoTaskId)
        {
            TodoItemModel todoItem = _dummyData.AllItems().FirstOrDefault(t => t.ItemId == todoItemId);
            TodoTaskModel todoTask = todoItem.TodoTasks.FirstOrDefault(s => s.TaskId == todoTaskId);

            if (todoItem == null || todoTask == null)
            {
                return OperationStatusCodes.NOT_FOUND;
            }

            todoTask.IsFinished = true;
            return OperationStatusCodes.SUCCESS;
        }
       public  int DeleteItemTask(int todoItemId, int todoTaskId)
        {
            TodoItemModel todoItem = _dummyData.AllItems().FirstOrDefault(t => t.ItemId == todoItemId);
            TodoTaskModel todoTask = todoItem.TodoTasks.FirstOrDefault(s => s.TaskId == todoTaskId);

            if (todoItem == null || todoTask == null)
            {
                return OperationStatusCodes.NOT_FOUND;
            }

            todoTask.IsDeleted = true;
            return OperationStatusCodes.SUCCESS;
        }
    }
}
