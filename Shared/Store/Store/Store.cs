using System;
using Interfaces;
using Entities;
using System.Collections.Generic;


namespace Store
{
    //Commented by Pasan[04/03/2020] Created this store class for testing purposes, since we dont have any persistance storage will use this store class in operators to interact with Linq queries. This class will return mock todo list, todoitem. 
    public class ListStore : IListStore
    {
        private readonly TodoListModel _todoList = new TodoListModel {
            Name = "Global TodoList",
            TodoItems = new List<TodoItemModel>()
        };

        private readonly TodoItemModel _todoItem = new TodoItemModel
        {
            TodoTasks = new List<TodoTaskModel>()
        };


        public TodoListModel TodoList
        {
            get
            {
                return _todoList;
            }
        }

        public TodoItemModel TodoItem
        {
            get
            {
                return _todoItem;
            }
        }
    }
}
