using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_Hello_
{
    public class TaskPanel : Control
    {
        public DateTimePicker dateOfTask;
        public DateTimePicker timeOfTask;
        public TextBox textOfTask;

        private Size size;
        private Point position;

        public bool isListTask = false;

        public TaskPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            size = new Size(0, 0);
            position = new Point(0, 0);

            TaskPanelSettings();
        }

        private void TaskPanelSettings()
        {
            Dock = DockStyle.Bottom;

            if(isListTask)
            {
                
            }        
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(BackColor);
            
            g.DrawRectangle(new Pen(Color.Brown), 0,0, size.Width - 1, size.Height - 1);
        }
       
        public void ControlsAdd()
        {
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
            textOfTask.Size = new Size(500, Height);
            textOfTask.BorderStyle = BorderStyle.None;
            textOfTask.Font = new Font(Font.Name, 12);
            
            RadioButton task = new RadioButton();
            task.Size = new Size(17, Height);
            task.Dock = DockStyle.Left;
            task.Enabled = false;
            task.FlatStyle = FlatStyle.Flat;

            Button funcButton = new Button();
            funcButton.Size = new Size(20, Height);
            funcButton.Dock = DockStyle.Right;

            //Добавление элементов на панель и раскрашивание
            Control[] controls = new Control[] { dateOfTask, timeOfTask, textOfTask, task, funcButton };
            foreach (Control control in controls)
            {
                Controls.Add(control);
                control.BackColor = BackColor;
            }

            //Определение функционала функциональной кнопки. Пока только цвета
            if (isListTask)
            {
                funcButton.BackColor = Color.Red;
            }
            else funcButton.BackColor = Color.Green;
        }
    }
}
