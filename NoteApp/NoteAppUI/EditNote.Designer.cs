namespace NoteAppUI
{
    partial class EditNote
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
            this.label1 = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreatedNoteDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ModifiedNoteDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TextNoteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RevokeButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTextBox.Location = new System.Drawing.Point(61, 8);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(347, 20);
            this.TitleTextBox.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Работа",
            "Дом",
            "Здоровье и Спорт",
            "Люди",
            "Документы",
            "Финансы",
            "Разное"});
            this.comboBox1.Location = new System.Drawing.Point(61, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(0, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(6, 39);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(52, 13);
            this.CategoryLabel.TabIndex = 3;
            this.CategoryLabel.Text = "Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Created:";
            // 
            // CreatedNoteDateTimePicker
            // 
            this.CreatedNoteDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CreatedNoteDateTimePicker.Location = new System.Drawing.Point(61, 61);
            this.CreatedNoteDateTimePicker.Name = "CreatedNoteDateTimePicker";
            this.CreatedNoteDateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.CreatedNoteDateTimePicker.TabIndex = 10;
            this.CreatedNoteDateTimePicker.Value = new System.DateTime(2019, 10, 13, 23, 45, 41, 0);
            // 
            // ModifiedNoteDateTimePicker
            // 
            this.ModifiedNoteDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ModifiedNoteDateTimePicker.Location = new System.Drawing.Point(275, 61);
            this.ModifiedNoteDateTimePicker.Name = "ModifiedNoteDateTimePicker";
            this.ModifiedNoteDateTimePicker.Size = new System.Drawing.Size(92, 20);
            this.ModifiedNoteDateTimePicker.TabIndex = 11;
            this.ModifiedNoteDateTimePicker.Value = new System.DateTime(2019, 10, 13, 23, 45, 41, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Modified:";
            // 
            // TextNoteRichTextBox
            // 
            this.TextNoteRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextNoteRichTextBox.Location = new System.Drawing.Point(12, 88);
            this.TextNoteRichTextBox.Name = "TextNoteRichTextBox";
            this.TextNoteRichTextBox.Size = new System.Drawing.Size(408, 173);
            this.TextNoteRichTextBox.TabIndex = 13;
            this.TextNoteRichTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.TitleTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CategoryLabel);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.ModifiedNoteDateTimePicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CreatedNoteDateTimePicker);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 84);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // RevokeButton
            // 
            this.RevokeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RevokeButton.Location = new System.Drawing.Point(345, 265);
            this.RevokeButton.Name = "RevokeButton";
            this.RevokeButton.Size = new System.Drawing.Size(75, 23);
            this.RevokeButton.TabIndex = 15;
            this.RevokeButton.Text = "Cancel";
            this.RevokeButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(264, 265);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 17;
            this.SaveButton.Text = "ОК";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // EditNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 293);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RevokeButton);
            this.Controls.Add(this.TextNoteRichTextBox);
            this.MinimumSize = new System.Drawing.Size(409, 200);
            this.Name = "EditNote";
            this.Text = "Add/EditNote";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker CreatedNoteDateTimePicker;
        private System.Windows.Forms.DateTimePicker ModifiedNoteDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TextNoteRichTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RevokeButton;
        private System.Windows.Forms.Button SaveButton;
    }
}