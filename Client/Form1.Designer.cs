namespace Client
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
            button1 = new Button();
            label2 = new Label();
            tbPort = new TextBox();
            label1 = new Label();
            tbHost = new TextBox();
            listBox1 = new ListBox();
            label3 = new Label();
            tbMessage = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(29, 499);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(109, 31);
            button1.TabIndex = 11;
            button1.Text = "SendToServer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(158, 551);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 10;
            label2.Text = "PORT";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(208, 547);
            tbPort.Margin = new Padding(3, 4, 3, 4);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(131, 27);
            tbPort.TabIndex = 9;
            tbPort.Text = "8090";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 499);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 8;
            label1.Text = "HOST";
            // 
            // tbHost
            // 
            tbHost.Location = new Point(208, 495);
            tbHost.Margin = new Padding(3, 4, 3, 4);
            tbHost.Name = "tbHost";
            tbHost.Size = new Size(131, 27);
            tbHost.TabIndex = 7;
            tbHost.Text = "localhost";
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Top;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(0, 0);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(607, 464);
            listBox1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(158, 603);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 13;
            label3.Text = "Message";
            // 
            // tbMessage
            // 
            tbMessage.Location = new Point(225, 599);
            tbMessage.Margin = new Padding(3, 4, 3, 4);
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(131, 27);
            tbMessage.TabIndex = 12;
            tbMessage.Text = "Hello STEP";
            tbMessage.TextChanged += tbMessage_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(0, 592);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(151, 31);
            button2.TabIndex = 14;
            button2.Text = "SendToServerToFile";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(376, 499);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(151, 31);
            button3.TabIndex = 15;
            button3.Text = "Send TCP Server";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(362, 598);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(233, 31);
            button4.TabIndex = 16;
            button4.Text = "SendToServerToFileInArch";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 676);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(tbMessage);
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

        private Button button1;
        private Label label2;
        private TextBox tbPort;
        private Label label1;
        private TextBox tbHost;
        private ListBox listBox1;
        private Label label3;
        private TextBox tbMessage;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}