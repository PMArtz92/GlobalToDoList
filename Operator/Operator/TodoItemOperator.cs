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

        public TodoResults GetAllFinishedItems()
        {
            TodoResults itemsResults = new TodoResults();
            itemsResults.results = _dummyData.AllItems().Where(t => t.IsFinished == true).ToList();

            itemsResults.status = itemsResults.results.Any() ? OperationStatusCodes.SUCCESS :OperationStatusCodes.NOT_FOUND;

            return itemsResults;
        }

        public TodoResults GetAllUnfinishedItems()
        {
            TodoResults itemsResults = new TodoResults();
            itemsResults.results = _dummyData.AllItems().Where(t => t.IsFinished == false).ToList();

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

            itemsResults.results = _dummyData.AllItems().Where(t => t.StartDate >= fromDate && t.EndDate <= toDate).ToList();

            if(!itemsResults.results.Any())
            {
                itemsResults.status = OperationStatusCodes.NOT_FOUND;
                return itemsResults;
            }

            itemsResults.status = OperationStatusCodes.SUCCESS;
            return itemsResults;
        }
    }
}
