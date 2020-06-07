namespace Tetris
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.arrowsButton = new System.Windows.Forms.Button();
            this.wasdButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PauseBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // arrowsButton
            // 
            this.arrowsButton.BackColor = System.Drawing.Color.Transparent;
            this.arrowsButton.BackgroundImage = global::Tetris.Properties.Resources.keyboard_buttons_arrows;
            this.arrowsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.arrowsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrowsButton.FlatAppearance.BorderSize = 0;
            this.arrowsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arrowsButton.ForeColor = System.Drawing.Color.Transparent;
            this.arrowsButton.Location = new System.Drawing.Point(169, 60);
            this.arrowsButton.Name = "arrowsButton";
            this.arrowsButton.Size = new System.Drawing.Size(123, 98);
            this.arrowsButton.TabIndex = 2;
            this.arrowsButton.UseVisualStyleBackColor = false;
            this.arrowsButton.Click += new System.EventHandler(this.arrowsButton_Click);
            // 
            // wasdButton
            // 
            this.wasdButton.BackColor = System.Drawing.Color.Transparent;
            this.wasdButton.BackgroundImage = global::Tetris.Properties.Resources.wasd_512;
            this.wasdButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wasdButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wasdButton.FlatAppearance.BorderSize = 0;
            this.wasdButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wasdButton.ForeColor = System.Drawing.Color.Transparent;
            this.wasdButton.Location = new System.Drawing.Point(12, 60);
            this.wasdButton.Name = "wasdButton";
            this.wasdButton.Size = new System.Drawing.Size(123, 98);
            this.wasdButton.TabIndex = 1;
            this.wasdButton.UseVisualStyleBackColor = false;
            this.wasdButton.Click += new System.EventHandler(this.wasdButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(85, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Управление";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пауза";
            // 
            // PauseBox
            // 
            this.PauseBox.BackColor = System.Drawing.Color.White;
            this.PauseBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PauseBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseBox.FormattingEnabled = true;
            this.PauseBox.Items.AddRange(new object[] {
            "Space",
            "F",
            "P"});
            this.PauseBox.Location = new System.Drawing.Point(90, 216);
            this.PauseBox.Name = "PauseBox";
            this.PauseBox.Size = new System.Drawing.Size(202, 21);
            this.PauseBox.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(90, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 48);
            this.button3.TabIndex = 6;
            this.button3.Text = "Применить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tetris.Properties.Resources.maxresdefault;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(304, 381);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.PauseBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.arrowsButton);
            this.Controls.Add(this.wasdButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 420);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 420);
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button arrowsButton;
        private System.Windows.Forms.Button wasdButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PauseBox;
        private System.Windows.Forms.Button button3;
    }
}