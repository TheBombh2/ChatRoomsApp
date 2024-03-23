namespace ChatAppClient.Views
{
	partial class HUB
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
			userNameTB = new TextBox();
			roomsLB = new ListBox();
			connectToRoomBTN = new Button();
			createRoomBTN = new Button();
			label1 = new Label();
			connectToServerBTN = new Button();
			newRoomTB = new TextBox();
			label2 = new Label();
			SuspendLayout();
			// 
			// userNameTB
			// 
			userNameTB.Location = new Point(206, 35);
			userNameTB.Name = "userNameTB";
			userNameTB.Size = new Size(212, 23);
			userNameTB.TabIndex = 0;
			// 
			// roomsLB
			// 
			roomsLB.FormattingEnabled = true;
			roomsLB.ItemHeight = 15;
			roomsLB.Location = new Point(12, 12);
			roomsLB.Name = "roomsLB";
			roomsLB.Size = new Size(177, 424);
			roomsLB.TabIndex = 1;
			// 
			// connectToRoomBTN
			// 
			connectToRoomBTN.Enabled = false;
			connectToRoomBTN.Location = new Point(206, 388);
			connectToRoomBTN.Name = "connectToRoomBTN";
			connectToRoomBTN.Size = new Size(212, 50);
			connectToRoomBTN.TabIndex = 2;
			connectToRoomBTN.Text = "Connect To Room";
			connectToRoomBTN.UseVisualStyleBackColor = true;
			connectToRoomBTN.Click += connectToRoomBTN_Click;
			// 
			// createRoomBTN
			// 
			createRoomBTN.Enabled = false;
			createRoomBTN.Location = new Point(206, 249);
			createRoomBTN.Name = "createRoomBTN";
			createRoomBTN.Size = new Size(212, 50);
			createRoomBTN.TabIndex = 3;
			createRoomBTN.Text = "Create Room";
			createRoomBTN.UseVisualStyleBackColor = true;
			createRoomBTN.Click += createRoomBTN_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11F);
			label1.Location = new Point(206, 12);
			label1.Name = "label1";
			label1.Size = new Size(105, 20);
			label1.TabIndex = 4;
			label1.Text = "Display Name:";
			// 
			// connectToServerBTN
			// 
			connectToServerBTN.Location = new Point(206, 64);
			connectToServerBTN.Name = "connectToServerBTN";
			connectToServerBTN.Size = new Size(212, 35);
			connectToServerBTN.TabIndex = 5;
			connectToServerBTN.Text = "Connect To Server";
			connectToServerBTN.UseVisualStyleBackColor = true;
			connectToServerBTN.Click += connectToServerBTN_Click;
			// 
			// newRoomTB
			// 
			newRoomTB.Location = new Point(206, 208);
			newRoomTB.Name = "newRoomTB";
			newRoomTB.Size = new Size(212, 23);
			newRoomTB.TabIndex = 6;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 11F);
			label2.Location = new Point(206, 185);
			label2.Name = "label2";
			label2.Size = new Size(142, 20);
			label2.TabIndex = 7;
			label2.Text = "Create a New Room";
			// 
			// HUB
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(430, 450);
			Controls.Add(label2);
			Controls.Add(newRoomTB);
			Controls.Add(connectToServerBTN);
			Controls.Add(label1);
			Controls.Add(createRoomBTN);
			Controls.Add(connectToRoomBTN);
			Controls.Add(roomsLB);
			Controls.Add(userNameTB);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "HUB";
			Text = "HUB";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox userNameTB;
		private ListBox roomsLB;
		private Button connectToRoomBTN;
		private Button createRoomBTN;
		private Label label1;
		private Button connectToServerBTN;
		private TextBox newRoomTB;
		private Label label2;
	}
}