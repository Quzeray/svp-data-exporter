namespace ExportVegasData
{
    partial class ScriptForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.exportDataButton = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.exportVideoCheckBox = new System.Windows.Forms.CheckBox();
            this.exportAudioCheckBox = new System.Windows.Forms.CheckBox();
            this.settingsGroup = new System.Windows.Forms.GroupBox();
            this.settingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportDataButton
            // 
            this.exportDataButton.Location = new System.Drawing.Point(16, 104);
            this.exportDataButton.Name = "exportDataButton";
            this.exportDataButton.Size = new System.Drawing.Size(112, 38);
            this.exportDataButton.TabIndex = 2;
            this.exportDataButton.Text = "Export data";
            this.exportDataButton.Click += new System.EventHandler(this.ExportData);
            // 
            // richTextBox
            // 
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox.Location = new System.Drawing.Point(144, 8);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(128, 136);
            this.richTextBox.TabIndex = 3;
            this.richTextBox.Text = "Было экспортировано:\n...";
            // 
            // exportVideoCheckBox
            // 
            this.exportVideoCheckBox.AutoSize = true;
            this.exportVideoCheckBox.Location = new System.Drawing.Point(16, 24);
            this.exportVideoCheckBox.Name = "exportVideoCheckBox";
            this.exportVideoCheckBox.Size = new System.Drawing.Size(85, 17);
            this.exportVideoCheckBox.TabIndex = 4;
            this.exportVideoCheckBox.Text = "Export video";
            this.exportVideoCheckBox.UseVisualStyleBackColor = true;
            // 
            // exportAudioCheckBox
            // 
            this.exportAudioCheckBox.AutoSize = true;
            this.exportAudioCheckBox.Location = new System.Drawing.Point(16, 56);
            this.exportAudioCheckBox.Name = "exportAudioCheckBox";
            this.exportAudioCheckBox.Size = new System.Drawing.Size(85, 17);
            this.exportAudioCheckBox.TabIndex = 4;
            this.exportAudioCheckBox.Text = "Export audio";
            this.exportAudioCheckBox.UseVisualStyleBackColor = true;
            // 
            // settingsGroup
            // 
            this.settingsGroup.Controls.Add(this.exportVideoCheckBox);
            this.settingsGroup.Controls.Add(this.exportAudioCheckBox);
            this.settingsGroup.Location = new System.Drawing.Point(16, 8);
            this.settingsGroup.Name = "settingsGroup";
            this.settingsGroup.Size = new System.Drawing.Size(112, 88);
            this.settingsGroup.TabIndex = 5;
            this.settingsGroup.TabStop = false;
            this.settingsGroup.Text = "Settings";
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 157);
            this.Controls.Add(this.settingsGroup);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.exportDataButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScriptForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Экспорт данных";
            this.settingsGroup.ResumeLayout(false);
            this.settingsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exportDataButton;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.CheckBox exportVideoCheckBox;
        private System.Windows.Forms.CheckBox exportAudioCheckBox;
        private System.Windows.Forms.GroupBox settingsGroup;
    }
}

