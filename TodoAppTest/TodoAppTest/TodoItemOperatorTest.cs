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
    }
}
