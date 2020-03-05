using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Operator;
using Interfaces;
using Entities;
using Store;

namespace TodoAppTest
{
    ////Commented by Pasan[04/03/2020] This testing class will test all methods in todo operator class.
    [TestClass]
    public class TodoListOperatorTest
    {
        private ITodoListOperator _todoOperator;

        [TestInitialize()]
        public void Startup()
        {
            _todoOperator = new TodoListOperator(new ListStore(), new DummyData());
        }

        [TestMethod]
        public void CreateTodoList_ListNameNull_CreateFail()
        {
            TodoListModel todoList = new TodoListModel();
            int result = _todoOperator.CreateTodoList(todoList);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void CreateTodoList_ListNameNotNull_CreateSuccess()
        {
            TodoListModel todoList = new TodoListModel
            {
                Name = "New List"
            };

            int result = _todoOperator.CreateTodoList(todoList);

            Assert.IsTrue(result == OperationStatusCodes.SUCCESS);
        }

        [TestMethod]
        public void AddItemToTodoList_ItemNameNull_AddingFail()
        {
            TodoItemModel todoItem = new TodoItemModel
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };

            int result = _todoOperator.AddItemToTodoList(todoItem);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void AddItemToTodoList_ItemNameNotNull_AddingSuccess()
        {
            TodoItemModel todoItem = new TodoItemModel
            {
                Name = "New Item",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };

            int result = _todoOperator.AddItemToTodoList(todoItem);

            Assert.IsTrue(result == OperationStatusCodes.SUCCESS);
        }

        [TestMethod]
        public void AddItemToTodoList_StartDateOrEndDateNull_AddingFail()
        {
            TodoItemModel todoItem01 = new TodoItemModel
            {
                Name = "New Item",
                EndDate = DateTime.Today.AddDays(1)
            };

            TodoItemModel todoItem02 = new TodoItemModel
            {
                Name = "New Item",
                StartDate = DateTime.Today
            };

            int result01 = _todoOperator.AddItemToTodoList(todoItem01);
            int result02 = _todoOperator.AddItemToTodoList(todoItem02);

            Assert.IsTrue(result01 == OperationStatusCodes.INVALID_PARAMTERS || result02 == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void AddItemToTodoList_StartDateAndEndDateNotNull_AddingSuccess()
        {
            TodoItemModel todoItem = new TodoItemModel
            {
                Name = "New Item",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };

            int result = _todoOperator.AddItemToTodoList(todoItem);

            Assert.IsTrue(result == OperationStatusCodes.SUCCESS);
        }

        [TestMethod]
        public void AddItemToTodoList_ItemReoccurringTrueAndReoccurringPeriodNUll_AddingFail()
        {
            TodoItemModel todoItem = new TodoItemModel
            {
                Name = "New Item",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                IsReoccurring = true
            };

            int result = _todoOperator.AddItemToTodoList(todoItem);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void AddItemToTodoList_ItemReoccurringTrueAndReoccurringPeriodNotNUll_AddingSuccess()
        {
            TodoItemModel todoItem = new TodoItemModel
            {
                Name = "New Item",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                IsReoccurring = true,
                ReoccurringPeriod = 2
            };

            int result = _todoOperator.AddItemToTodoList(todoItem);

            Assert.IsTrue(result == OperationStatusCodes.SUCCESS);
        }
        
        [TestMethod]
        public void RemoveItemFromTodoList_IfItemIdNotValid_RemoveFail()
        {
            TodoItemModel todoItem = new TodoItemModel
            {
                Name = "New Item",
            };

            int result = _todoOperator.RemoveItemFromTodoList(todoItem);

            Assert.IsTrue(result == OperationStatusCodes.INVALID_PARAMTERS);
        }

        [TestMethod]
        public void RemoveItemFromTodoList_IfItemIdNotFound_RemoveFail()
        {
            TodoItemModel todoItem = new TodoItemModel
            {
                Name = "New Item",
                ItemId = 11
            };

            int result = _todoOperator.RemoveItemFromTodoList(todoItem);

            Assert.IsTrue(result == OperationStatusCodes.NOT_FOUND);
        }

        [TestMethod]
        public void RemoveItemFromTodoList_IfItemIdFound_RemoveSuccess()
        {
            TodoItemModel todoItem = new TodoItemModel
            {
                Name = "Item02",
                ItemId = 2
            };

            int result = _todoOperator.RemoveItemFromTodoList(todoItem);

            Assert.IsTrue(result == OperationStatusCodes.SUCCESS);
        }
    }
}
