namespace SpaceRace
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameOperator = new System.Windows.Forms.Timer(this.components);
            this.p2 = new System.Windows.Forms.PictureBox();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.gameStarter = new System.Windows.Forms.Timer(this.components);
            this.gameEnder = new System.Windows.Forms.Timer(this.components);
            this.startEndBack = new System.Windows.Forms.Label();
            this.startPrompt = new System.Windows.Forms.Label();
            this.p1ScoreLabel = new System.Windows.Forms.Label();
            this.p2ScoreLabel = new System.Windows.Forms.Label();
            this.gameWinnerLabel = new System.Windows.Forms.Label();
            this.systemOperator = new System.Windows.Forms.Timer(this.components);
            this.timeDisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            this.SuspendLayout();
            // 
            // gameOperator
            // 
            this.gameOperator.Interval = 20;
            this.gameOperator.Tick += new System.EventHandler(this.gameOperator_Tick);
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.Transparent;
            this.p2.BackgroundImage = global::SpaceRace.Properties.Resources._2___1_;
            this.p2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2.Location = new System.Drawing.Point(946, 502);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(35, 50);
            this.p2.TabIndex = 1;
            this.p2.TabStop = false;
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.Transparent;
            this.p1.BackgroundImage = global::SpaceRace.Properties.Resources._1_1;
            this.p1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1.Location = new System.Drawing.Point(416, 993);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(35, 50);
            this.p1.TabIndex = 0;
            this.p1.TabStop = false;
            // 
            // gameStarter
            // 
            this.gameStarter.Tick += new System.EventHandler(this.gameStarter_Tick);
            // 
            // startEndBack
            // 
            this.startEndBack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startEndBack.Location = new System.Drawing.Point(-1, -5);
            this.startEndBack.Name = "startEndBack";
            this.startEndBack.Size = new System.Drawing.Size(9999, 9999);
            this.startEndBack.TabIndex = 2;
            // 
            // startPrompt
            // 
            this.startPrompt.BackColor = System.Drawing.Color.Transparent;
            this.startPrompt.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPrompt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startPrompt.Location = new System.Drawing.Point(92, 9);
            this.startPrompt.Name = "startPrompt";
            this.startPrompt.Size = new System.Drawing.Size(1834, 671);
            this.startPrompt.TabIndex = 3;
            this.startPrompt.Text = "ooooo";
            this.startPrompt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // p1ScoreLabel
            // 
            this.p1ScoreLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p1ScoreLabel.Font = new System.Drawing.Font("MS Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1ScoreLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.p1ScoreLabel.Location = new System.Drawing.Point(-1, 813);
            this.p1ScoreLabel.Name = "p1ScoreLabel";
            this.p1ScoreLabel.Size = new System.Drawing.Size(125, 143);
            this.p1ScoreLabel.TabIndex = 4;
            this.p1ScoreLabel.Text = "0";
            this.p1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2ScoreLabel
            // 
            this.p2ScoreLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p2ScoreLabel.Font = new System.Drawing.Font("MS Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2ScoreLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.p2ScoreLabel.Location = new System.Drawing.Point(1923, 813);
            this.p2ScoreLabel.Name = "p2ScoreLabel";
            this.p2ScoreLabel.Size = new System.Drawing.Size(125, 143);
            this.p2ScoreLabel.TabIndex = 5;
            this.p2ScoreLabel.Text = "0";
            this.p2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameWinnerLabel
            // 
            this.gameWinnerLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameWinnerLabel.Font = new System.Drawing.Font("MS Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameWinnerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.gameWinnerLabel.Location = new System.Drawing.Point(139, 680);
            this.gameWinnerLabel.Name = "gameWinnerLabel";
            this.gameWinnerLabel.Size = new System.Drawing.Size(1787, 310);
            this.gameWinnerLabel.TabIndex = 6;
            this.gameWinnerLabel.Text = "THE SOVIETS WIN THE SPACE RACE";
            this.gameWinnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // systemOperator
            // 
            this.systemOperator.Interval = 20;
            this.systemOperator.Tick += new System.EventHandler(this.systemOperator_Tick);
            // 
            // timeDisplay
            // 
            this.timeDisplay.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.timeDisplay.Font = new System.Drawing.Font("MS Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDisplay.ForeColor = System.Drawing.SystemColors.Control;
            this.timeDisplay.Location = new System.Drawing.Point(716, 946);
            this.timeDisplay.Name = "timeDisplay";
            this.timeDisplay.Size = new System.Drawing.Size(667, 44);
            this.timeDisplay.TabIndex = 7;
            this.timeDisplay.Text = "0";
            this.timeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SpaceRace.Properties.Resources.StarryNight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.timeDisplay);
            this.Controls.Add(this.gameWinnerLabel);
            this.Controls.Add(this.p2ScoreLabel);
            this.Controls.Add(this.p1ScoreLabel);
            this.Controls.Add(this.startPrompt);
            this.Controls.Add(this.startEndBack);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpaceRace";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameOperator;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.PictureBox p2;
        private System.Windows.Forms.Timer gameStarter;
        private System.Windows.Forms.Timer gameEnder;
        private System.Windows.Forms.Label startEndBack;
        private System.Windows.Forms.Label startPrompt;
        private System.Windows.Forms.Label p1ScoreLabel;
        private System.Windows.Forms.Label p2ScoreLabel;
        private System.Windows.Forms.Label gameWinnerLabel;
        private System.Windows.Forms.Timer systemOperator;
        private System.Windows.Forms.Label timeDisplay;
    }
}

