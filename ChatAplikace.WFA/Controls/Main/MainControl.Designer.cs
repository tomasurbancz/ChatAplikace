using System.ComponentModel;

namespace ChatAplikace.WFA.Controls.Login;

partial class MainControl
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        chatsPanel = new System.Windows.Forms.Panel();
        chatsLayout = new System.Windows.Forms.FlowLayoutPanel();
        messagesPanel = new System.Windows.Forms.Panel();
        inputPanel = new System.Windows.Forms.Panel();
        sendButton = new System.Windows.Forms.Button();
        messageBox = new System.Windows.Forms.TextBox();
        messagesLayout = new System.Windows.Forms.FlowLayoutPanel();
        chatNamePanel = new System.Windows.Forms.Panel();
        chatNameLabel = new System.Windows.Forms.Label();
        infoPanel = new System.Windows.Forms.Panel();
        logOutLabel = new System.Windows.Forms.Label();
        chatsLabel = new System.Windows.Forms.Label();
        tableLayoutPanel1.SuspendLayout();
        chatsPanel.SuspendLayout();
        messagesPanel.SuspendLayout();
        inputPanel.SuspendLayout();
        chatNamePanel.SuspendLayout();
        infoPanel.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
        tableLayoutPanel1.Controls.Add(chatsPanel, 0, 1);
        tableLayoutPanel1.Controls.Add(messagesPanel, 1, 1);
        tableLayoutPanel1.Controls.Add(chatNamePanel, 1, 0);
        tableLayoutPanel1.Controls.Add(infoPanel, 0, 0);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel1.Size = new System.Drawing.Size(640, 360);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // chatsPanel
        // 
        chatsPanel.Controls.Add(chatsLayout);
        chatsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        chatsPanel.Location = new System.Drawing.Point(3, 73);
        chatsPanel.Name = "chatsPanel";
        chatsPanel.Padding = new System.Windows.Forms.Padding(8);
        chatsPanel.Size = new System.Drawing.Size(186, 284);
        chatsPanel.TabIndex = 0;
        // 
        // chatsLayout
        // 
        chatsLayout.AutoScroll = true;
        chatsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
        chatsLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        chatsLayout.Location = new System.Drawing.Point(8, 8);
        chatsLayout.Name = "chatsLayout";
        chatsLayout.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
        chatsLayout.Size = new System.Drawing.Size(170, 268);
        chatsLayout.TabIndex = 0;
        chatsLayout.WrapContents = false;
        // 
        // messagesPanel
        // 
        messagesPanel.Controls.Add(inputPanel);
        messagesPanel.Controls.Add(messagesLayout);
        messagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        messagesPanel.Location = new System.Drawing.Point(195, 73);
        messagesPanel.Name = "messagesPanel";
        messagesPanel.Padding = new System.Windows.Forms.Padding(8);
        messagesPanel.Size = new System.Drawing.Size(442, 284);
        messagesPanel.TabIndex = 1;
        // 
        // inputPanel
        // 
        inputPanel.Controls.Add(sendButton);
        inputPanel.Controls.Add(messageBox);
        inputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        inputPanel.Location = new System.Drawing.Point(8, 238);
        inputPanel.Name = "inputPanel";
        inputPanel.Size = new System.Drawing.Size(426, 38);
        inputPanel.TabIndex = 2;
        // 
        // sendButton
        // 
        sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        sendButton.Location = new System.Drawing.Point(322, 3);
        sendButton.Name = "sendButton";
        sendButton.Size = new System.Drawing.Size(101, 32);
        sendButton.TabIndex = 0;
        sendButton.Text = "Send";
        sendButton.UseVisualStyleBackColor = true;
        sendButton.Click += sendButton_Click;
        // 
        // messageBox
        // 
        messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        messageBox.Location = new System.Drawing.Point(0, 7);
        messageBox.Name = "messageBox";
        messageBox.PlaceholderText = "Message";
        messageBox.Size = new System.Drawing.Size(316, 23);
        messageBox.TabIndex = 1;
        // 
        // messagesLayout
        // 
        messagesLayout.AutoScroll = true;
        messagesLayout.Dock = System.Windows.Forms.DockStyle.Fill;
        messagesLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        messagesLayout.Location = new System.Drawing.Point(8, 8);
        messagesLayout.Name = "messagesLayout";
        messagesLayout.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
        messagesLayout.Size = new System.Drawing.Size(426, 268);
        messagesLayout.TabIndex = 0;
        messagesLayout.WrapContents = false;
        // 
        // chatNamePanel
        // 
        chatNamePanel.Controls.Add(chatNameLabel);
        chatNamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
        chatNamePanel.Location = new System.Drawing.Point(195, 3);
        chatNamePanel.Name = "chatNamePanel";
        chatNamePanel.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
        chatNamePanel.Size = new System.Drawing.Size(442, 64);
        chatNamePanel.TabIndex = 2;
        // 
        // chatNameLabel
        // 
        chatNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        chatNameLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        chatNameLabel.Location = new System.Drawing.Point(8, 6);
        chatNameLabel.Name = "chatNameLabel";
        chatNameLabel.Size = new System.Drawing.Size(426, 52);
        chatNameLabel.TabIndex = 0;
        chatNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // infoPanel
        // 
        infoPanel.Controls.Add(logOutLabel);
        infoPanel.Controls.Add(chatsLabel);
        infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        infoPanel.Location = new System.Drawing.Point(3, 3);
        infoPanel.Name = "infoPanel";
        infoPanel.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
        infoPanel.Size = new System.Drawing.Size(186, 64);
        infoPanel.TabIndex = 3;
        // 
        // logOutLabel
        // 
        logOutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        logOutLabel.Location = new System.Drawing.Point(75, 6);
        logOutLabel.Name = "logOutLabel";
        logOutLabel.Size = new System.Drawing.Size(103, 23);
        logOutLabel.TabIndex = 1;
        logOutLabel.Text = "Log Out";
        logOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        logOutLabel.Click += logOutLabel_Click;
        // 
        // chatsLabel
        // 
        chatsLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
        chatsLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        chatsLabel.Location = new System.Drawing.Point(8, 15);
        chatsLabel.Name = "chatsLabel";
        chatsLabel.Size = new System.Drawing.Size(170, 43);
        chatsLabel.TabIndex = 0;
        chatsLabel.Text = "Chats";
        chatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // MainControl
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(tableLayoutPanel1);
        Size = new System.Drawing.Size(640, 360);
        Load += MainControl_Load;
        tableLayoutPanel1.ResumeLayout(false);
        chatsPanel.ResumeLayout(false);
        messagesPanel.ResumeLayout(false);
        inputPanel.ResumeLayout(false);
        inputPanel.PerformLayout();
        chatNamePanel.ResumeLayout(false);
        infoPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button sendButton;

    private System.Windows.Forms.TextBox messageBox;

    private System.Windows.Forms.Label chatNameLabel;

    private System.Windows.Forms.Label logOutLabel;

    private System.Windows.Forms.Label chatsLabel;

    private System.Windows.Forms.FlowLayoutPanel chatsLayout;

    private System.Windows.Forms.FlowLayoutPanel messagesLayout;

    private System.Windows.Forms.Panel chatsPanel;
    private System.Windows.Forms.Panel messagesPanel;
    private System.Windows.Forms.Panel inputPanel;
    private System.Windows.Forms.Panel chatNamePanel;

    private System.Windows.Forms.Panel infoPanel;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    #endregion
}