namespace diplomrestart.Model
{
    partial class frmStatusOrderAdd
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
            this.cbActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtC = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(156, 9);
            // 
            // cbActive
            // 
            this.cbActive.BackColor = System.Drawing.Color.Transparent;
            this.cbActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActive.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbActive.ItemHeight = 30;
            this.cbActive.Items.AddRange(new object[] {
            "Обрабатывается ",
            "Выполнен",
            "Отменен "});
            this.cbActive.Location = new System.Drawing.Point(85, 79);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(246, 36);
            this.cbActive.StartIndex = 0;
            this.cbActive.TabIndex = 5;
            this.cbActive.SelectedIndexChanged += new System.EventHandler(this.cbActive_SelectedIndexChanged);
            // 
            // txtC
            // 
            this.txtC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtC.DefaultText = "";
            this.txtC.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtC.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtC.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtC.Location = new System.Drawing.Point(85, 121);
            this.txtC.Name = "txtC";
            this.txtC.PasswordChar = '\0';
            this.txtC.PlaceholderText = "";
            this.txtC.SelectedText = "";
            this.txtC.Size = new System.Drawing.Size(200, 36);
            this.txtC.TabIndex = 6;
            // 
            // frmStatusOrderAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 277);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.cbActive);
            this.Name = "frmStatusOrderAdd";
            this.Text = "frmStatusOrderAdd";
            this.Load += new System.EventHandler(this.frmStatusOrderAdd_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbActive, 0);
            this.Controls.SetChildIndex(this.txtC, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2ComboBox cbActive;
        private Guna.UI2.WinForms.Guna2TextBox txtC;
    }
}