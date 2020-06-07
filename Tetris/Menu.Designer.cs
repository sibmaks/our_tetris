namespace Tetris
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnPlay
            // 
            this.BtnPlay.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlay.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnPlay.ForeColor = System.Drawing.Color.Transparent;
            this.BtnPlay.Location = new System.Drawing.Point(83, 50);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(136, 67);
            this.BtnPlay.TabIndex = 0;
            this.BtnPlay.Text = "Играть";
            this.BtnPlay.UseVisualStyleBackColor = false;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnSetting
            // 
            this.BtnSetting.BackColor = System.Drawing.Color.Transparent;
            this.BtnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetting.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSetting.ForeColor = System.Drawing.Color.Transparent;
            this.BtnSetting.Location = new System.Drawing.Point(83, 123);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(136, 61);
            this.BtnSetting.TabIndex = 1;
            this.BtnSetting.Text = "Настройки";
            this.BtnSetting.UseVisualStyleBackColor = false;
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.BackColor = System.Drawing.Color.Transparent;
            this.BtnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAbout.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnAbout.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAbout.Location = new System.Drawing.Point(83, 190);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(136, 57);
            this.BtnAbout.TabIndex = 2;
            this.BtnAbout.Text = "О создателях";
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnExit.ForeColor = System.Drawing.Color.Transparent;
            this.BtnExit.Location = new System.Drawing.Point(83, 253);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(136, 55);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Выход";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tetris.Properties.Resources.maxresdefault;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(304, 361);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnSetting);
            this.Controls.Add(this.BtnPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 400);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тетрис";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.Button BtnSetting;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.Button BtnExit;
    }
}

