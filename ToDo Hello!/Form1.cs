using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_Hello_
{
    public partial class Form1 : Form
    {
        TaskPanel taskPanel;

        private bool isTaskPanelActive;

        string user;

        public Form1()
        {
            InitializeComponent();
            Controls.Remove(HiddenTabControl);
            Controls.Add(splitContainer1);
        }

        public void NewTaskPanelCreation()
        {           
            //добавление в сплитконтейнер редактора задачи вместо кнопки
            taskPanel = new TaskPanel();
            taskPanel.ControlsAdd();
            taskPanel.Dock = DockStyle.Bottom;
            taskPanel.Size = new Size(createTaskBtn.Width, createTaskBtn.Height);
            taskPanel.Location = new Point(createTaskBtn.Location.X, createTaskBtn.Location.Y - createTaskBtn.Height);

            splitContainer1.Panel2.Controls.Add(taskPanel);

            isTaskPanelActive = true;

            taskPanel.textOfTask.Focus();
        }
        private void createTaskBtn_MouseClick_1(object sender, MouseEventArgs e)
        {
            createTaskBtn.Visible = false;
            createTaskBtn.Enabled = false;
            NewTaskPanelCreation();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isTaskPanelActive)
            {
                splitContainer1.Panel2.Controls.Remove(taskPanel);
                createTaskBtn.Visible = true;
                createTaskBtn.Enabled = true;
                Task task = new Task(user, taskPanel.textOfTask.Text, taskPanel.dateOfTask.Value.Date, taskPanel.timeOfTask.Value.TimeOfDay);
                isTaskPanelActive = false;
                
                AddNewTaskInLists(taskPanel);
            }
        }

        private void AddNewTaskInLists(TaskPanel taskPanel)
        {
            AddNewTaskInTodayList(taskPanel);
        }

        private void AddNewTaskInTodayList(TaskPanel taskPanel)
        {
            TaskPanel todayTaskPanel = new TaskPanel();

            todayTaskPanel.isListTask = true;
            todayTaskPanel.ControlsAdd();

            todayTaskPanel.Dock = DockStyle.Top;
            todayTaskPanel.Size = new Size(createTaskBtn.Width, createTaskBtn.Height);

            todayTaskPanel.dateOfTask.Value = taskPanel.dateOfTask.Value;
            todayTaskPanel.timeOfTask.Value = taskPanel.timeOfTask.Value;
            todayTaskPanel.textOfTask.Text = taskPanel.textOfTask.Text;

            splitContainer1.Panel2.Controls.Add(todayTaskPanel);
        }

        private void AddNewTaskInPlansList(Task task)
        {
                
        }
    }
}
