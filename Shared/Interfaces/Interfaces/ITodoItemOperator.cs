using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Entities;

namespace Interfaces
{
    public interface ITodoItemOperator
    {
        TodoResults GetAllFinishedItems();
        TodoResults GetAllUnfinishedItems();
        TodoResults GetTodoItemsForGiveTimePeriod(int timePeriod);
    }
}
