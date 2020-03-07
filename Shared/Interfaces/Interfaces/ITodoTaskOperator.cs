using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Interfaces
{
    public interface ITodoTaskOperator
    {
        int SetItemTaskFinish(int todoItemId, int todoTaskId);
        int DeleteItemTask(int todoItemId, int todoTaskId);
    }
}
