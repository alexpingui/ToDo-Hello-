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
        private bool isTaskPanelActive;
        Panel newTaskPanel;
        DateTimePicker dateOfTask;
        DateTimePicker timeOfTask;
        TextBox textOfTask;
        string user;
        public Form1()
        {
            InitializeComponent();
        }

        public void NewTaskPanelCreation()
        {
            //Создание панели редактирования задачи
            newTaskPanel = new Panel();
            newTaskPanel.Location = new Point(createTaskBtn.Location.X, createTaskBtn.Location.Y - createTaskBtn.Size.Height);
            newTaskPanel.Size = new Size(createTaskBtn.Width, createTaskBtn.Height);
            newTaskPanel.BackColor = Color.White;
            newTaskPanel.Dock = DockStyle.Bottom;
            
            splitContainer1.Panel2.Controls.Add(newTaskPanel);
           
            //Создание элементов редактирования задачи
            dateOfTask = new DateTimePicker();
            dateOfTask.Format = DateTimePickerFormat.Long;
            dateOfTask.Dock = DockStyle.Top;
            dateOfTask.ShowCheckBox = true;

            timeOfTask = new DateTimePicker();
            timeOfTask.Format = DateTimePickerFormat.Time;
            timeOfTask.ShowUpDown = true;
            timeOfTask.Dock = DockStyle.Bottom;
            timeOfTask.ShowCheckBox = true;

            textOfTask = new TextBox();
            textOfTask.Multiline = true;           
            textOfTask.Dock = DockStyle.Left;
            textOfTask.Size = new Size(500, newTaskPanel.Height);
            textOfTask.BorderStyle = BorderStyle.None;
            textOfTask.Font = new Font(Font.Name,12);

            RadioButton task = new RadioButton();
            task.Size = new Size(17, newTaskPanel.Size.Height);
            task.Dock = DockStyle.Left;
            task.Enabled = false;
            task.FlatStyle = FlatStyle.Flat;

            Button reminderBtn = new Button();
            reminderBtn.Size = new Size(20, newTaskPanel.Size.Height);
            reminderBtn.Dock = DockStyle.Right;

            //Добавление элементов на панель и раскрашивание
            Control[] controls = new Control[] { dateOfTask, timeOfTask, textOfTask, task, reminderBtn };
            foreach (Control control in controls)
            {
                newTaskPanel.Controls.Add(control);
                control.BackColor = Color.White;
            }
            textOfTask.Focus();

            isTaskPanelActive = true;
        }

        private void createTaskBtn_MouseClick(object sender, MouseEventArgs e)
        { 
            createTaskBtn.Visible = false;
            createTaskBtn.Enabled = false;
            NewTaskPanelCreation();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isTaskPanelActive)
            {
                splitContainer1.Panel2.Controls.Remove(newTaskPanel);
                createTaskBtn.Visible = true;
                createTaskBtn.Enabled = true;
                Task task = new Task(user, textOfTask.Text, dateOfTask.Value.Date, timeOfTask.Value.TimeOfDay);
            }
        }
    }
}
