namespace Multithread_TCP_Client
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && ( components != null ))
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
		private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			this.IP_adress = new System.Windows.Forms.TextBox();
			this.Port = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.Status = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.Message_from_client = new System.Windows.Forms.TextBox();
			this.Send = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// IP_adress
			// 
			this.IP_adress.Location = new System.Drawing.Point(12, 38);
			this.IP_adress.Name = "IP_adress";
			this.IP_adress.Size = new System.Drawing.Size(154, 22);
			this.IP_adress.TabIndex = 0;
			// 
			// Port
			// 
			this.Port.Location = new System.Drawing.Point(227, 38);
			this.Port.Name = "Port";
			this.Port.Size = new System.Drawing.Size(100, 22);
			this.Port.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "IP Адрес Сервера";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(224, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Порт";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(366, 26);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(127, 46);
			this.button1.TabIndex = 2;
			this.button1.Text = "Подключиться";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Status
			// 
			this.Status.AutoSize = true;
			this.Status.Location = new System.Drawing.Point(13, 93);
			this.Status.Name = "Status";
			this.Status.Size = new System.Drawing.Size(0, 17);
			this.Status.TabIndex = 3;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(16, 134);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(410, 294);
			this.richTextBox1.TabIndex = 4;
			this.richTextBox1.Text = "";
			// 
			// Message_from_client
			// 
			this.Message_from_client.Location = new System.Drawing.Point(16, 456);
			this.Message_from_client.Name = "Message_from_client";
			this.Message_from_client.Size = new System.Drawing.Size(410, 22);
			this.Message_from_client.TabIndex = 5;
			// 
			// Send
			// 
			this.Send.Location = new System.Drawing.Point(476, 452);
			this.Send.Name = "Send";
			this.Send.Size = new System.Drawing.Size(104, 31);
			this.Send.TabIndex = 6;
			this.Send.Text = "Отправить";
			this.Send.UseVisualStyleBackColor = true;
			this.Send.Click += new System.EventHandler(this.Send_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 499);
			this.Controls.Add(this.Send);
			this.Controls.Add(this.Message_from_client);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.Status);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Port);
			this.Controls.Add(this.IP_adress);
			this.Name = "Form1";
			this.Text = "Connect to server";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox IP_adress;
		private System.Windows.Forms.TextBox Port;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label Status;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TextBox Message_from_client;
		private System.Windows.Forms.Button Send;
		private System.Windows.Forms.Timer timer1;
	}
}

