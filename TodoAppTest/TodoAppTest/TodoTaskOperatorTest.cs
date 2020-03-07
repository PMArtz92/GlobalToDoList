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
    public class TodoTaskOperatorTest
    {
        private ITodoTaskOperator _todoTaskOperator;

        [TestInitialize()]
        public void Startup()
        {
            _todoTaskOperator = new TodoTaskOperator(new ListStore(), new DummyData());
        }

        [TestMethod]
        public void SetItemTaskFinish_TodoItemOrTaskNotFound_ReturnFail()
        {
            int todoItemId = 1;
            int todoTaskId = 4;

            int results = _todoTaskOperator.SetItemTaskFinish(todoItemId, todoTaskId);

            Assert.IsTrue(results == OperationStatusCodes.NOT_FOUND);
        }

        [TestMethod]
        public void SetItemTaskFinish_TodoItemOrTaskFound_ReturnSuccess()
        {
            int todoItemId = 1;
            int todoTaskId = 2;

            int results = _todoTaskOperator.SetItemTaskFinish(todoItemId, todoTaskId);

            Assert.IsTrue(results == OperationStatusCodes.SUCCESS);
        }

        [TestMethod]
        public void DeleteItemTask_TodoItemOrTaskNotFound_ReturnFail()
        {
            int todoItemId = 1;
            int todoTaskId = 4;

            int results = _todoTaskOperator.DeleteItemTask(todoItemId, todoTaskId);

            Assert.IsTrue(results == OperationStatusCodes.NOT_FOUND);
        }

        [TestMethod]
        public void DeleteItemTask_TodoItemOrTaskFound_ReturnSuccess()
        {
            int todoItemId = 1;
            int todoTaskId = 2;

            int results = _todoTaskOperator.DeleteItemTask(todoItemId, todoTaskId);

            Assert.IsTrue(results == OperationStatusCodes.SUCCESS);
        }
    }
}
