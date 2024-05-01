namespace Proiect_Retele_Echipa_Retele_Muntenia
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
			serverGroupBox = new GroupBox();
			serverStartButton = new Button();
			serverPortTextBox = new TextBox();
			serverPortLabel = new Label();
			serverIPLabel = new Label();
			serverIPTextBox = new TextBox();
			clientGroupBox = new GroupBox();
			clientConnectButton = new Button();
			clientPortTextBox = new TextBox();
			clientPortLabel = new Label();
			clientIPLabel = new Label();
			clientIPTextBox = new TextBox();
			clientsListBox = new CheckedListBox();
			clientsGroupBox = new GroupBox();
			queryButton = new Button();
			outputGroupBox = new GroupBox();
			textBox1 = new TextBox();
			serverGroupBox.SuspendLayout();
			clientGroupBox.SuspendLayout();
			clientsGroupBox.SuspendLayout();
			outputGroupBox.SuspendLayout();
			SuspendLayout();
			// 
			// serverGroupBox
			// 
			serverGroupBox.Controls.Add(serverStartButton);
			serverGroupBox.Controls.Add(serverPortTextBox);
			serverGroupBox.Controls.Add(serverPortLabel);
			serverGroupBox.Controls.Add(serverIPLabel);
			serverGroupBox.Controls.Add(serverIPTextBox);
			serverGroupBox.Location = new Point(12, 12);
			serverGroupBox.Name = "serverGroupBox";
			serverGroupBox.Size = new Size(690, 125);
			serverGroupBox.TabIndex = 0;
			serverGroupBox.TabStop = false;
			serverGroupBox.Text = "Server";
			// 
			// serverStartButton
			// 
			serverStartButton.Location = new Point(532, 50);
			serverStartButton.Name = "serverStartButton";
			serverStartButton.Size = new Size(94, 29);
			serverStartButton.TabIndex = 4;
			serverStartButton.Text = "START";
			serverStartButton.UseVisualStyleBackColor = true;
			// 
			// serverPortTextBox
			// 
			serverPortTextBox.Location = new Point(344, 51);
			serverPortTextBox.Name = "serverPortTextBox";
			serverPortTextBox.Size = new Size(176, 27);
			serverPortTextBox.TabIndex = 3;
			serverPortTextBox.Text = "3000";
			// 
			// serverPortLabel
			// 
			serverPortLabel.AutoSize = true;
			serverPortLabel.Location = new Point(294, 55);
			serverPortLabel.Name = "serverPortLabel";
			serverPortLabel.Size = new Size(44, 20);
			serverPortLabel.TabIndex = 2;
			serverPortLabel.Text = "PORT";
			// 
			// serverIPLabel
			// 
			serverIPLabel.AutoSize = true;
			serverIPLabel.Location = new Point(6, 55);
			serverIPLabel.Name = "serverIPLabel";
			serverIPLabel.Size = new Size(21, 20);
			serverIPLabel.TabIndex = 1;
			serverIPLabel.Text = "IP";
			// 
			// serverIPTextBox
			// 
			serverIPTextBox.Location = new Point(27, 51);
			serverIPTextBox.Name = "serverIPTextBox";
			serverIPTextBox.Size = new Size(261, 27);
			serverIPTextBox.TabIndex = 0;
			serverIPTextBox.Text = "127.0.0.1";
			// 
			// clientGroupBox
			// 
			clientGroupBox.Controls.Add(clientConnectButton);
			clientGroupBox.Controls.Add(clientPortTextBox);
			clientGroupBox.Controls.Add(clientPortLabel);
			clientGroupBox.Controls.Add(clientIPLabel);
			clientGroupBox.Controls.Add(clientIPTextBox);
			clientGroupBox.Location = new Point(708, 12);
			clientGroupBox.Name = "clientGroupBox";
			clientGroupBox.Size = new Size(682, 125);
			clientGroupBox.TabIndex = 1;
			clientGroupBox.TabStop = false;
			clientGroupBox.Text = "Client";
			// 
			// clientConnectButton
			// 
			clientConnectButton.Location = new Point(526, 51);
			clientConnectButton.Name = "clientConnectButton";
			clientConnectButton.Size = new Size(100, 29);
			clientConnectButton.TabIndex = 4;
			clientConnectButton.Text = "CONNECT";
			clientConnectButton.UseVisualStyleBackColor = true;
			// 
			// clientPortTextBox
			// 
			clientPortTextBox.Location = new Point(344, 51);
			clientPortTextBox.Name = "clientPortTextBox";
			clientPortTextBox.Size = new Size(176, 27);
			clientPortTextBox.TabIndex = 3;
			clientPortTextBox.Text = "3000";
			// 
			// clientPortLabel
			// 
			clientPortLabel.AutoSize = true;
			clientPortLabel.Location = new Point(294, 58);
			clientPortLabel.Name = "clientPortLabel";
			clientPortLabel.Size = new Size(44, 20);
			clientPortLabel.TabIndex = 2;
			clientPortLabel.Text = "PORT";
			// 
			// clientIPLabel
			// 
			clientIPLabel.AutoSize = true;
			clientIPLabel.Location = new Point(6, 54);
			clientIPLabel.Name = "clientIPLabel";
			clientIPLabel.Size = new Size(21, 20);
			clientIPLabel.TabIndex = 1;
			clientIPLabel.Text = "IP";
			// 
			// clientIPTextBox
			// 
			clientIPTextBox.Location = new Point(33, 51);
			clientIPTextBox.Name = "clientIPTextBox";
			clientIPTextBox.Size = new Size(255, 27);
			clientIPTextBox.TabIndex = 0;
			clientIPTextBox.Text = "127.0.0.1";
			// 
			// clientsListBox
			// 
			clientsListBox.FormattingEnabled = true;
			clientsListBox.Location = new Point(33, 38);
			clientsListBox.Name = "clientsListBox";
			clientsListBox.Size = new Size(593, 554);
			clientsListBox.TabIndex = 2;
			// 
			// clientsGroupBox
			// 
			clientsGroupBox.Controls.Add(queryButton);
			clientsGroupBox.Controls.Add(clientsListBox);
			clientsGroupBox.Location = new Point(708, 143);
			clientsGroupBox.Name = "clientsGroupBox";
			clientsGroupBox.Size = new Size(682, 710);
			clientsGroupBox.TabIndex = 3;
			clientsGroupBox.TabStop = false;
			clientsGroupBox.Text = "Clients";
			// 
			// queryButton
			// 
			queryButton.Location = new Point(302, 641);
			queryButton.Name = "queryButton";
			queryButton.Size = new Size(94, 29);
			queryButton.TabIndex = 3;
			queryButton.Text = "Query";
			queryButton.UseVisualStyleBackColor = true;
			// 
			// outputGroupBox
			// 
			outputGroupBox.Controls.Add(textBox1);
			outputGroupBox.Location = new Point(12, 143);
			outputGroupBox.Name = "outputGroupBox";
			outputGroupBox.Size = new Size(690, 710);
			outputGroupBox.TabIndex = 4;
			outputGroupBox.TabStop = false;
			outputGroupBox.Text = "Output";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(6, 38);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(665, 666);
			textBox1.TabIndex = 0;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1402, 865);
			Controls.Add(outputGroupBox);
			Controls.Add(clientsGroupBox);
			Controls.Add(clientGroupBox);
			Controls.Add(serverGroupBox);
			Name = "Form1";
			Text = "Form1";
			serverGroupBox.ResumeLayout(false);
			serverGroupBox.PerformLayout();
			clientGroupBox.ResumeLayout(false);
			clientGroupBox.PerformLayout();
			clientsGroupBox.ResumeLayout(false);
			outputGroupBox.ResumeLayout(false);
			outputGroupBox.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox serverGroupBox;
		private Label serverIPLabel;
		private TextBox serverIPTextBox;
		private Label serverPortLabel;
		private TextBox serverPortTextBox;
		private Button serverStartButton;
		private GroupBox clientGroupBox;
		private Button clientConnectButton;
		private TextBox clientPortTextBox;
		private Label clientPortLabel;
		private Label clientIPLabel;
		private TextBox clientIPTextBox;
		private CheckedListBox clientsListBox;
		private GroupBox clientsGroupBox;
		private Button queryButton;
		private GroupBox outputGroupBox;
		private TextBox textBox1;
	}
}
