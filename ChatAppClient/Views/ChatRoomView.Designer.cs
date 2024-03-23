namespace ChatAppClient.Views
{
	partial class ChatRoomView
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
			messageTB = new TextBox();
			sendMSGBTN = new Button();
			chatMsgsTB = new TextBox();
			label1 = new Label();
			userNameLBL = new Label();
			label3 = new Label();
			connectedUsersLB = new ListBox();
			SuspendLayout();
			// 
			// messageTB
			// 
			messageTB.Enabled = false;
			messageTB.Location = new Point(12, 386);
			messageTB.Multiline = true;
			messageTB.Name = "messageTB";
			messageTB.Size = new Size(476, 52);
			messageTB.TabIndex = 0;
			// 
			// sendMSGBTN
			// 
			sendMSGBTN.Enabled = false;
			sendMSGBTN.Location = new Point(494, 386);
			sendMSGBTN.Name = "sendMSGBTN";
			sendMSGBTN.Size = new Size(75, 51);
			sendMSGBTN.TabIndex = 1;
			sendMSGBTN.Text = "Send";
			sendMSGBTN.UseVisualStyleBackColor = true;
			sendMSGBTN.Click += sendMSGBTN_Click;
			// 
			// chatMsgsTB
			// 
			chatMsgsTB.Location = new Point(95, 12);
			chatMsgsTB.Multiline = true;
			chatMsgsTB.Name = "chatMsgsTB";
			chatMsgsTB.ReadOnly = true;
			chatMsgsTB.Size = new Size(474, 368);
			chatMsgsTB.TabIndex = 2;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(5, 15);
			label1.Name = "label1";
			label1.Size = new Size(84, 15);
			label1.TabIndex = 3;
			label1.Text = "Connected As:";
			// 
			// userNameLBL
			// 
			userNameLBL.AutoSize = true;
			userNameLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			userNameLBL.Location = new Point(12, 30);
			userNameLBL.Name = "userNameLBL";
			userNameLBL.Size = new Size(64, 15);
			userNameLBL.TabIndex = 5;
			userNameLBL.Text = "Username";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 68);
			label3.Name = "label3";
			label3.RightToLeft = RightToLeft.No;
			label3.Size = new Size(65, 30);
			label3.TabIndex = 6;
			label3.Text = "Connected\r\nUsers:\r\n";
			// 
			// connectedUsersLB
			// 
			connectedUsersLB.FormattingEnabled = true;
			connectedUsersLB.ItemHeight = 15;
			connectedUsersLB.Location = new Point(12, 106);
			connectedUsersLB.Name = "connectedUsersLB";
			connectedUsersLB.Size = new Size(77, 274);
			connectedUsersLB.TabIndex = 7;
			// 
			// ChatRoomView
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(577, 450);
			Controls.Add(connectedUsersLB);
			Controls.Add(label3);
			Controls.Add(userNameLBL);
			Controls.Add(label1);
			Controls.Add(chatMsgsTB);
			Controls.Add(sendMSGBTN);
			Controls.Add(messageTB);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "ChatRoomView";
			Text = "Chat Room";
			FormClosed += ChatRoomView_FormClosed;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox messageTB;
		private Button sendMSGBTN;
		private TextBox chatMsgsTB;
		private Label label1;
		private Label userNameLBL;
		private Label label3;
		private ListBox connectedUsersLB;
	}
}
