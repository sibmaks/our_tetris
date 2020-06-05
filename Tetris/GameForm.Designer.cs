namespace Tetris
{
    partial class GameForm
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.nextFigurePanel = new System.Windows.Forms.Panel();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 500;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(269, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(269, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // pauseLabel
            // 
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.pauseLabel.Font = new System.Drawing.Font("BERNIER Shade", 30.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLabel.ForeColor = System.Drawing.Color.Black;
            this.pauseLabel.Location = new System.Drawing.Point(258, 229);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(120, 49);
            this.pauseLabel.TabIndex = 2;
            this.pauseLabel.Text = "ПАУЗА";
            this.pauseLabel.Visible = false;
            // 
            // nextFigurePanel
            // 
            this.nextFigurePanel.BackColor = System.Drawing.Color.Transparent;
            this.nextFigurePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextFigurePanel.Location = new System.Drawing.Point(268, 8);
            this.nextFigurePanel.Name = "nextFigurePanel";
            this.nextFigurePanel.Size = new System.Drawing.Size(100, 100);
            this.nextFigurePanel.TabIndex = 3;
            this.nextFigurePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NextFigurePanel_Paint);
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.Color.Transparent;
            this.gamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel.Location = new System.Drawing.Point(8, 8);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(250, 500);
            this.gamePanel.TabIndex = 4;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tetris.Properties.Resources.back;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.nextFigurePanel);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Тетрис";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Panel nextFigurePanel;
        private System.Windows.Forms.Panel gamePanel;
    }
}

