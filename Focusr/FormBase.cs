namespace Focusr
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormBase : Form
    {
        #region Declarations

        private bool drag = false;
        private Point startPoint = new Point(0, 0);
        private string excludeList = "";

        private System.ComponentModel.IContainer components = null;

        #endregion

        #region Constructor , Dispose

        protected FormBase()
        {
            this.InitializeComponent();

            //
            //Adding Mouse Event Handlers for the Form
            //
            this.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            this.MouseUp += new MouseEventHandler(this.Form_MouseUp);
            this.MouseMove += new MouseEventHandler(this.Form_MouseMove);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // 
            // FormBase
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(369, 182);
            this.Name = "FormBase";
            this.Text = "AlerterForm";
        }

        #endregion

        #region Overriden Functions

        protected override void OnControlAdded(ControlEventArgs e)
        {
            //
            //Add Mouse Event Handlers for each control added into the form,
            //if Draggable property of the form is set to true and the control
            //name is not in the ExcludeList.Exclude list is the comma separated
            //list of the Controls for which you do not require the mouse handler 
            //to be added. For Example a button.  
            //
            if (this.Draggable && (this.ExcludeList.IndexOf(e.Control.Name, StringComparison.OrdinalIgnoreCase) < 0))
            {
                e.Control.MouseDown += new MouseEventHandler(this.Form_MouseDown);
                e.Control.MouseUp += new MouseEventHandler(this.Form_MouseUp);
                e.Control.MouseMove += new MouseEventHandler(this.Form_MouseMove);
            }
            base.OnControlAdded(e);
        }

        #endregion

        #region Event Handlers

        void Form_MouseDown(object sender, MouseEventArgs e)
        {
            //
            //On Mouse Down set the flag drag=true and 
            //Store the clicked point to the start_point variable
            //
            this.drag = true;
            this.startPoint = new Point(e.X, e.Y);
        }

        void Form_MouseUp(object sender, MouseEventArgs e)
        {
            //
            //Set the drag flag = false;
            //
            this.drag = false;
        }

        void Form_MouseMove(object sender, MouseEventArgs e)
        {
            //
            //If drag = true, drag the form
            //
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                    p2.Y - this.startPoint.Y);
                this.Location = p3;
            }
        }

        #endregion

        #region Properties

        public string ExcludeList
        {
            set { this.excludeList = value; }
            get { return this.excludeList.Trim(); }
        }

        public bool Draggable { set; get; } = true;

        #endregion
    }
}