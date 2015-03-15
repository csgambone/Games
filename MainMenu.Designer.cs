namespace Games
{
    partial class MainMenu
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticTacToeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flippyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tic Tac Toe";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(90, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Flippy";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(90, 210);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "2048";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(90, 239);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "LogiX";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(90, 352);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Realvirtue", 35.95F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(30, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(274, 80);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Main Menu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gamesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(334, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // gamesToolStripMenuItem
            // 
            this.gamesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ticTacToeToolStripMenuItem,
            this.flippyToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.logixToolStripMenuItem});
            this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            this.gamesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.gamesToolStripMenuItem.Text = "Games";
            // 
            // ticTacToeToolStripMenuItem
            // 
            this.ticTacToeToolStripMenuItem.Name = "ticTacToeToolStripMenuItem";
            this.ticTacToeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ticTacToeToolStripMenuItem.Text = "Tic Tac Toe";
            // 
            // flippyToolStripMenuItem
            // 
            this.flippyToolStripMenuItem.Name = "flippyToolStripMenuItem";
            this.flippyToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.flippyToolStripMenuItem.Text = "Flippy";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.ToolStripMenuItem1.Text = "2048";
            // 
            // logixToolStripMenuItem
            // 
            this.logixToolStripMenuItem.Name = "logixToolStripMenuItem";
            this.logixToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.logixToolStripMenuItem.Text = "LogiX";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 412);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Games Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ticTacToeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flippyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logixToolStripMenuItem;
    }
}

