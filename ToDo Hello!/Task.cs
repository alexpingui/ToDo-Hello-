using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Hello_
{
    public class Task
    {
        public string user;
        public string task;
        public DateTime date;
        public TimeSpan time;

        /// <summary>
        ///Создание новой задачи 
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="task">Текст задачи</param>
        /// <param name="date">Дата выполнения</param>
        public Task(string user, string task, DateTime date, TimeSpan time) 
        {
            this.user = user;
            this.task = task;
            this.date = date;
            this.time = time;
        }
    }
}
