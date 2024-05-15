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
			clientGroupBox = new GroupBox();
			clientConnectButton = new Button();
			clientPortTextBox = new TextBox();
			clientPortLabel = new Label();
			clientIPLabel = new Label();
			clientIPTextBox = new TextBox();
			clientsGroupBox = new GroupBox();
			clientsListBox = new ListBox();
			queryButton = new Button();
			outputGroupBox = new GroupBox();
			outputTextBox = new TextBox();
			queryTextBox = new TextBox();
			clientGroupBox.SuspendLayout();
			clientsGroupBox.SuspendLayout();
			outputGroupBox.SuspendLayout();
			SuspendLayout();
			// 
			// clientGroupBox
			// 
			clientGroupBox.Controls.Add(queryTextBox);
			clientGroupBox.Controls.Add(clientConnectButton);
			clientGroupBox.Controls.Add(queryButton);
			clientGroupBox.Controls.Add(clientPortTextBox);
			clientGroupBox.Controls.Add(clientPortLabel);
			clientGroupBox.Controls.Add(clientIPLabel);
			clientGroupBox.Controls.Add(clientIPTextBox);
			clientGroupBox.Location = new Point(18, 12);
			clientGroupBox.Name = "clientGroupBox";
			clientGroupBox.Size = new Size(1372, 125);
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
			clientConnectButton.Click += clientConnectButton_Click;
			// 
			// clientPortTextBox
			// 
			clientPortTextBox.Location = new Point(344, 51);
			clientPortTextBox.Name = "clientPortTextBox";
			clientPortTextBox.PlaceholderText = "1234";
			clientPortTextBox.Size = new Size(176, 27);
			clientPortTextBox.TabIndex = 3;
			clientPortTextBox.Text = "1234";
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
			clientIPTextBox.ReadOnly = true;
			clientIPTextBox.Size = new Size(255, 27);
			clientIPTextBox.TabIndex = 0;
			clientIPTextBox.Text = "127.0.0.1";
			// 
			// clientsGroupBox
			// 
			clientsGroupBox.Controls.Add(clientsListBox);
			clientsGroupBox.Location = new Point(708, 143);
			clientsGroupBox.Name = "clientsGroupBox";
			clientsGroupBox.Size = new Size(682, 710);
			clientsGroupBox.TabIndex = 3;
			clientsGroupBox.TabStop = false;
			clientsGroupBox.Text = "Clients";
			// 
			// clientsListBox
			// 
			clientsListBox.FormattingEnabled = true;
			clientsListBox.Location = new Point(6, 38);
			clientsListBox.Name = "clientsListBox";
			clientsListBox.SelectionMode = SelectionMode.MultiSimple;
			clientsListBox.Size = new Size(670, 664);
			clientsListBox.TabIndex = 4;
			// 
			// queryButton
			// 
			queryButton.Location = new Point(1272, 50);
			queryButton.Name = "queryButton";
			queryButton.Size = new Size(94, 29);
			queryButton.TabIndex = 3;
			queryButton.Text = "Query";
			queryButton.UseVisualStyleBackColor = true;
			queryButton.Click += queryButton_Click;
			// 
			// outputGroupBox
			// 
			outputGroupBox.Controls.Add(outputTextBox);
			outputGroupBox.Location = new Point(12, 143);
			outputGroupBox.Name = "outputGroupBox";
			outputGroupBox.Size = new Size(690, 710);
			outputGroupBox.TabIndex = 4;
			outputGroupBox.TabStop = false;
			outputGroupBox.Text = "Output";
			// 
			// outputTextBox
			// 
			outputTextBox.Location = new Point(6, 38);
			outputTextBox.Multiline = true;
			outputTextBox.Name = "outputTextBox";
			outputTextBox.ReadOnly = true;
			outputTextBox.Size = new Size(665, 666);
			outputTextBox.TabIndex = 0;
			// 
			// queryTextBox
			// 
			queryTextBox.Location = new Point(696, 52);
			queryTextBox.Name = "queryTextBox";
			queryTextBox.PlaceholderText = "Enter Query";
			queryTextBox.Size = new Size(570, 27);
			queryTextBox.TabIndex = 5;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1427, 888);
			Controls.Add(outputGroupBox);
			Controls.Add(clientsGroupBox);
			Controls.Add(clientGroupBox);
			Name = "Form1";
			Text = "Form1";
			clientGroupBox.ResumeLayout(false);
			clientGroupBox.PerformLayout();
			clientsGroupBox.ResumeLayout(false);
			outputGroupBox.ResumeLayout(false);
			outputGroupBox.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private GroupBox clientGroupBox;
		private Button clientConnectButton;
		private TextBox clientPortTextBox;
		private Label clientPortLabel;
		private Label clientIPLabel;
		private TextBox clientIPTextBox;
		private GroupBox clientsGroupBox;
		private Button queryButton;
		private GroupBox outputGroupBox;
		private TextBox outputTextBox;
		private ListBox clientsListBox;
		private TextBox queryTextBox;
	}
}
