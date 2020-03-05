using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Interfaces;
using System.Linq;

namespace Operator
{
    //Commented by Pasan[05/03/2020] This class have the all methods related to todo items
    public class TodoItemOperator : ITodoItemOperator
    {
        private readonly IListStore _store;
        private readonly IDummyData _dummyData;
        public TodoItemOperator(IListStore store, IDummyData dummyData)
        {
            _store = store;
            _dummyData = dummyData;
        }

        public int CreateTodoItem(TodoItemModel todoItem)
        {
            if (todoItem.Name == null || todoItem.StartDate == null || todoItem.EndDate == null)
            {
                return OperationStatusCodes.INVALID_PARAMTERS;
            }

            if(todoItem.IsReoccurring == true && todoItem.ReoccurringPeriod == null)
            {
                return OperationStatusCodes.INVALID_PARAMTERS;
            }

            if (todoItem.IsReoccurring == false && todoItem.ReoccurringPeriod != null)
            {
                return OperationStatusCodes.INVALID_PARAMTERS;
            }

            _store.TodoList.TodoItems.Add(todoItem);
            return OperationStatusCodes.SUCCESS;
        }

        public TodoResults GetAllFinishedItems()
        {
            TodoResults itemsResults = new TodoResults();
            itemsResults.results = _dummyData.AllItems().Where(t => t.IsFinished == true && t.IsDeleted != true).ToList();

            itemsResults.status = itemsResults.results.Any() ? OperationStatusCodes.SUCCESS : OperationStatusCodes.NOT_FOUND;

            return itemsResults;
        }

        public TodoResults GetAllUnfinishedItems()
        {
            TodoResults itemsResults = new TodoResults();
            itemsResults.results = _dummyData.AllItems().Where(t => t.IsFinished == false && t.IsDeleted != true).ToList();

            itemsResults.status = itemsResults.results.Any() ? OperationStatusCodes.SUCCESS : OperationStatusCodes.NOT_FOUND;

            return itemsResults;
        }

        public TodoResults GetTodoItemsForGiveTimePeriod(int timePeriod)
        {
            TodoResults itemsResults = new TodoResults();
            DateTime fromDate = DateTime.Today;
            DateTime toDate = DateTime.Today.AddDays(timePeriod);

            if(timePeriod <= 1)
            {
                itemsResults.status = OperationStatusCodes.INVALID_PARAMTERS;
                return itemsResults;
            }

            itemsResults.results = _dummyData.AllItems().Where(t => t.StartDate >= fromDate && t.EndDate <= toDate && t.IsDeleted != true).ToList();

            if(!itemsResults.results.Any())
            {
                itemsResults.status = OperationStatusCodes.NOT_FOUND;
                return itemsResults;
            }

            itemsResults.status = OperationStatusCodes.SUCCESS;
            return itemsResults;
        }

        public int SetTodoItemComplete(TodoItemModel todoItem)
        {
            if (todoItem.ItemId == 0)
            {
                return OperationStatusCodes.INVALID_PARAMTERS;
            }

            TodoItemModel todoItemToComplete = _dummyData.AllItems().FirstOrDefault(t => t.ItemId == todoItem.ItemId);

            if(todoItemToComplete == null)
            {
                return OperationStatusCodes.NOT_FOUND;
            }

            todoItemToComplete.IsComplete = true;
            return OperationStatusCodes.SUCCESS;
        }

        public int SetTodoItemFinish(TodoItemModel todoItem)
        {
            TodoItemModel todoItemToFinish = _dummyData.AllItems().FirstOrDefault(t => t.ItemId == todoItem.ItemId);

            if (todoItemToFinish == null)
            {
                return OperationStatusCodes.NOT_FOUND;
            }

            if (!todoItemToFinish.IsComplete)
            {
                return OperationStatusCodes.INVALID_OPERARION;
            }

            todoItemToFinish.IsComplete = true;
            return OperationStatusCodes.SUCCESS;
        }
    }
}
