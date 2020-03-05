using System;
using System.Collections.Generic;
using System.Text;
using Operator;
using Entities;
using Interfaces;
using Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TodoAppTest
{
    //Commented by Pasan[05/03/2020] This class have the all test methods related to TodoItemOperator.
    [TestClass]
    public class TodoItemOperatorTest
    {
        private ITodoItemOperator _todoItemOperator;

        [TestInitialize()]
        public void Startup()
        {
            _todoItemOperator = new TodoItemOperator(new ListStore(), new DummyData());
        }

        [TestMethod]
        public void CreateTodoItem_ItemNameNull_ReturnFail()
        {
            TodoItemModel item = new TodoItemModel();

            int result = _todoItemOperator.CreateTodoItem(item);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void CreateTodoItem_ItemStartDateOrEndDateNull_ReturnFail()
        {
            TodoItemModel item = new TodoItemModel { 
                Name = "New Item"
            };

            int result = _todoItemOperator.CreateTodoItem(item);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void CreateTodoItem_ItemHaveReoccurringPeriodWithoutReoccurringTrue_ReturnFail()
        {
            TodoItemModel item = new TodoItemModel
            {
                Name = "New Item",
                ReoccurringPeriod = 2
            };

            int result = _todoItemOperator.CreateTodoItem(item);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void CreateTodoItem_ItemHaveReoccurringTrueNoReoccuringPeriod_ReturnFail()
        {
            TodoItemModel item = new TodoItemModel
            {
                Name = "New Item",
                IsReoccurring = true
            };

            int result = _todoItemOperator.CreateTodoItem(item);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void CreateTodoItem_ItemHaveAllValidData_ReturnSuccess()
        {
            TodoItemModel item = new TodoItemModel
            {
                Name = "New Item",
                IsReoccurring = true,
                ReoccurringPeriod = 2,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(2)
            };

            int result = _todoItemOperator.CreateTodoItem(item);

            Assert.IsTrue(result == OperationStatusCodes.SUCCESS);
        }

        [TestMethod]
        public void GetAllFinishedItems_NoItemsFound_ReturnNotFound()
        {
            TodoResults result = _todoItemOperator.GetAllFinishedItems();

            Assert.IsTrue(result.status == OperationStatusCodes.NOT_FOUND);
        }

        [TestMethod]
        public void GetAllUnfinishedItems_ItemsFound_ReturnList()
        {
            TodoResults result = _todoItemOperator.GetAllUnfinishedItems();

            Assert.IsTrue(result.status == OperationStatusCodes.SUCCESS);
        }

        [TestMethod]
        public void GetTodoItemsForGiveTimePeriod_InvalidPeriod_ReturnFail()
        {
            TodoResults result = _todoItemOperator.GetTodoItemsForGiveTimePeriod(0);

            Assert.IsTrue(result.status == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void GetTodoItemsForGiveTimePeriod_ItemsFound_ReturnList()
        {
            TodoResults result = _todoItemOperator.GetTodoItemsForGiveTimePeriod(2);

            Assert.IsTrue(result.status == OperationStatusCodes.SUCCESS);
        }

        [TestMethod]
        public void SetTodoItemComplete_ItemIdNotValid_ReturnFail()
        {
            TodoItemModel item = new TodoItemModel
            {
                Name = "Item11"
            };

            int result = _todoItemOperator.SetTodoItemComplete(item);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void SetTodoItemComplete_ItemNotFound_ReturnFail()
        {
            TodoItemModel item = new TodoItemModel {
                Name = "Item11",
                ItemId = 11
            };

            int result = _todoItemOperator.SetTodoItemComplete(item);

            Assert.IsTrue(result == OperationStatusCodes.NOT_FOUND);
        }

        [TestMethod]
        public void SetTodoItemComplete_ItemFound_ReturnSuccess()
        {
            TodoItemModel item = new TodoItemModel
            {
                Name = "Item11",
                ItemId = 1
            };

            int result = _todoItemOperator.SetTodoItemComplete(item);

            Assert.IsTrue(result == OperationStatusCodes.SUCCESS);
        }

        [TestMethod]
        public void SetTodoItemFinish_ItemNotFound_ReturnFail()
        {
            TodoItemModel item = new TodoItemModel
            {
                Name = "Item11",
                ItemId = 11,
                IsComplete = true
            };

            int result = _todoItemOperator.SetTodoItemFinish(item);

            Assert.IsTrue(result == OperationStatusCodes.NOT_FOUND);
        }

        [TestMethod]
        public void SetTodoItemFinish_ItemNotCompleted_ReturnSuccess()
        {
            TodoItemModel item = new TodoItemModel
            {
                Name = "Item11",
                ItemId = 1,
                IsComplete = false
            };

            int result = _todoItemOperator.SetTodoItemFinish(item);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_OPERARION);
        }

        [TestMethod]
        public void SetTodoItemFinish_ItemFound_ReturnSuccess()
        {
            TodoItemModel item = new TodoItemModel
            {
                Name = "Item11",
                ItemId = 1,
                IsComplete = true
            };

            int result = _todoItemOperator.SetTodoItemFinish(item);

            Assert.IsTrue(result == OperationStatusCodes.SUCCESS);
        }
    }
}
