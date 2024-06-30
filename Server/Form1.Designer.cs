namespace Server
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
            listBox1 = new ListBox();
            tbHost = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbPort = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Top;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(0, 0);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(544, 464);
            listBox1.TabIndex = 0;
            // 
            // tbHost
            // 
            tbHost.Location = new Point(202, 489);
            tbHost.Margin = new Padding(3, 4, 3, 4);
            tbHost.Name = "tbHost";
            tbHost.Size = new Size(131, 27);
            tbHost.TabIndex = 1;
            tbHost.Text = "localhost";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 493);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 2;
            label1.Text = "HOST";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(152, 545);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 4;
            label2.Text = "PORT";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(202, 541);
            tbPort.Margin = new Padding(3, 4, 3, 4);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(131, 27);
            tbPort.TabIndex = 3;
            tbPort.Text = "8090";
            // 
            // button1
            // 
            button1.Location = new Point(16, 507);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 5;
            button1.Text = "StartListen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(12, 578);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(137, 31);
            button2.TabIndex = 6;
            button2.Text = "StartListenToFile";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(352, 507);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(168, 31);
            button3.TabIndex = 7;
            button3.Text = "Start TCP Listener";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(328, 578);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(192, 31);
            button4.TabIndex = 8;
            button4.Text = "StartListenToFileInArch";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 683);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(tbPort);
            Controls.Add(label1);
            Controls.Add(tbHost);
            Controls.Add(listBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox tbHost;
        private Label label1;
        private Label label2;
        private TextBox tbPort;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}