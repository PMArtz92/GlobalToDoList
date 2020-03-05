using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    //Commented by Pasan[04/03/2020] Created TodoTaskModel to store Todo tasks properties. Todo item can have many Todo Items.
    public class TodoTaskModel
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public bool IsFinished { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}
