using System.Windows.Forms;

namespace CallTracker.View
{
    partial class EditBookmarks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            CallTracker.DataSets.ServicesDataSet servicesDataSet;
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this._Name = new CallTracker.View.BorderedTextBox();
            this.bookmarksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this._Url = new CallTracker.View.BorderedTextBox();
            this._Done = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._MoveDown = new System.Windows.Forms.Button();
            this._MoveUp = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editBookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            servicesDataSet = new CallTracker.DataSets.ServicesDataSet();
            ((System.ComponentModel.ISupportInitialize)(servicesDataSet)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookmarksBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // servicesDataSet
            // 
            servicesDataSet.DataSetName = "ServicesDataSet";
            servicesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanel1.Controls.Add(this.listBox1);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this._Name);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this._Url);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 211);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(222, 160);
            this.listBox1.TabIndex = 14;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Name:";
            // 
            // _Name
            // 
            this._Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._Name.BorderColor = System.Drawing.Color.Gray;
            this._Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bookmarksBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Name.Enabled = false;
            this._Name.Location = new System.Drawing.Point(64, 165);
            this._Name.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._Name.Name = "_Name";
            this._Name.Size = new System.Drawing.Size(161, 19);
            this._Name.TabIndex = 9;
            this._Name.KeyUp += new System.Windows.Forms.KeyEventHandler(this._Name_KeyUp);
            // 
            // bookmarksBindingSource
            // 
            this.bookmarksBindingSource.DataMember = "Bookmarks";
            this.bookmarksBindingSource.DataSource = servicesDataSet;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 186);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "URL:";
            // 
            // _Url
            // 
            this._Url.BorderColor = System.Drawing.Color.Gray;
            this._Url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._Url.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bookmarksBindingSource, "Url", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._Url.Enabled = false;
            this._Url.Location = new System.Drawing.Point(64, 186);
            this._Url.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this._Url.Name = "_Url";
            this._Url.Size = new System.Drawing.Size(161, 19);
            this._Url.TabIndex = 13;
            this._Url.KeyUp += new System.Windows.Forms.KeyEventHandler(this._Name_KeyUp);
            // 
            // _Done
            // 
            this._Done.BackColor = System.Drawing.Color.LightGray;
            this._Done.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Done.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this._Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._Done.Location = new System.Drawing.Point(158, 236);
            this._Done.Name = "_Done";
            this._Done.Size = new System.Drawing.Size(75, 21);
            this._Done.TabIndex = 1;
            this._Done.Text = "Done";
            this._Done.UseVisualStyleBackColor = false;
            this._Done.Click += new System.EventHandler(this._Ok_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._MoveDown);
            this.panel1.Controls.Add(this._MoveUp);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this._Done);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 262);
            this.panel1.TabIndex = 2;
            // 
            // _MoveDown
            // 
            this._MoveDown.Image = global::CallTracker.Properties.Resources.bindingNavigatorDeleteItem_Image;
            this._MoveDown.Location = new System.Drawing.Point(85, 235);
            this._MoveDown.Margin = new System.Windows.Forms.Padding(0, 0, 120, 0);
            this._MoveDown.Name = "_MoveDown";
            this._MoveDown.Size = new System.Drawing.Size(27, 22);
            this._MoveDown.TabIndex = 18;
            this._MoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._MoveDown.UseVisualStyleBackColor = true;
            this._MoveDown.Visible = false;
            // 
            // _MoveUp
            // 
            this._MoveUp.Image = global::CallTracker.Properties.Resources.AddImage;
            this._MoveUp.Location = new System.Drawing.Point(58, 235);
            this._MoveUp.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this._MoveUp.Name = "_MoveUp";
            this._MoveUp.Size = new System.Drawing.Size(27, 22);
            this._MoveUp.TabIndex = 17;
            this._MoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._MoveUp.UseVisualStyleBackColor = true;
            this._MoveUp.Visible = false;
            this._MoveUp.Click += new System.EventHandler(this._MoveUp_Click);
            // 
            // button3
            // 
            this.button3.Image = global::CallTracker.Properties.Resources.bindingNavigatorDeleteItem_Image;
            this.button3.Location = new System.Drawing.Point(30, 235);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 0, 120, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 22);
            this.button3.TabIndex = 16;
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::CallTracker.Properties.Resources.AddImage;
            this.button2.Location = new System.Drawing.Point(3, 235);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 22);
            this.button2.TabIndex = 15;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 7F);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editBookmarksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(236, 18);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editBookmarksToolStripMenuItem
            // 
            this.editBookmarksToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.editBookmarksToolStripMenuItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editBookmarksToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.editBookmarksToolStripMenuItem.Name = "editBookmarksToolStripMenuItem";
            this.editBookmarksToolStripMenuItem.ReadOnly = true;
            this.editBookmarksToolStripMenuItem.Size = new System.Drawing.Size(113, 18);
            this.editBookmarksToolStripMenuItem.Text = "Edit Bookmarks";
            // 
            // EditBookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.CancelButton = this._Done;
            this.ClientSize = new System.Drawing.Size(238, 262);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBookmarks";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bind Smart Paste";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EditBookmarks_Load);
            this.VisibleChanged += new System.EventHandler(this.EditBookmarks_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(servicesDataSet)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookmarksBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _Done;
        private System.Windows.Forms.BindingSource bookmarksBindingSource;
        private System.Windows.Forms.Label label4;
        private BorderedTextBox _Name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private BorderedTextBox _Url;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private ToolStripTextBox editBookmarksToolStripMenuItem;
        private ListBox listBox1;
        private Button button3;
        private Button button2;
        private Button _MoveDown;
        private Button _MoveUp;
    }
}