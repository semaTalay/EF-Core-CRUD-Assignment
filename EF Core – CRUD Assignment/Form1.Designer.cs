namespace EF_Core___CRUD_Assignment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGetOrderList = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lstKisiler = new ListBox();
            lstTasima = new ListBox();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // btnGetOrderList
            // 
            btnGetOrderList.Location = new Point(15, 52);
            btnGetOrderList.Name = "btnGetOrderList";
            btnGetOrderList.Size = new Size(129, 38);
            btnGetOrderList.TabIndex = 0;
            btnGetOrderList.Text = "Get Order List";
            btnGetOrderList.UseVisualStyleBackColor = true;
            btnGetOrderList.Click += btnGetOrderList_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(190, 52);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(138, 39);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(353, 52);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(138, 39);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(533, 52);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(138, 39);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lstKisiler
            // 
            lstKisiler.FormattingEnabled = true;
            lstKisiler.ItemHeight = 15;
            lstKisiler.Location = new Point(12, 119);
            lstKisiler.Name = "lstKisiler";
            lstKisiler.Size = new Size(132, 214);
            lstKisiler.TabIndex = 4;
            lstKisiler.MouseClick += lstKisiler_MouseClick;
            // 
            // lstTasima
            // 
            lstTasima.FormattingEnabled = true;
            lstTasima.ItemHeight = 15;
            lstTasima.Location = new Point(15, 389);
            lstTasima.Name = "lstTasima";
            lstTasima.Size = new Size(129, 109);
            lstTasima.TabIndex = 5;
            lstTasima.MouseClick += lstTasima_MouseClick;
            // 
            // listView1
            // 
            listView1.Location = new Point(214, 119);
            listView1.Name = "listView1";
            listView1.Size = new Size(482, 380);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 511);
            Controls.Add(listView1);
            Controls.Add(lstTasima);
            Controls.Add(lstKisiler);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnGetOrderList);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            MouseClick += Form1_MouseClick;
            ResumeLayout(false);
        }

        #endregion

        private Button btnGetOrderList;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private ListBox lstKisiler;
        private ListBox lstTasima;
        private ListView listView1;
    }
}