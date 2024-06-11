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
        public Form1()
        {
            InitializeComponent();
            NewTaskPanelCreation();
        }

        private void NewTaskPanelCreation()
        {
            Panel newTaskPanel = new Panel();

            newTaskPanel.Location = new Point(createTaskBtn.Location.X, createTaskBtn.Location.Y - createTaskBtn.Size.Height);
            newTaskPanel.Size = new Size(createTaskBtn.Width, createTaskBtn.Height);
            newTaskPanel.BackColor = Color.Green  ;

           
            splitContainer1.Panel2.Controls.Add(newTaskPanel);
            
            Button b = new Button();
            b.Size = new Size(70, newTaskPanel.Size.Height);
            b.BackColor = Color.Red;
            newTaskPanel.Controls.Add(b);
            b.Dock = DockStyle.Right;
            
        }
    }
}
