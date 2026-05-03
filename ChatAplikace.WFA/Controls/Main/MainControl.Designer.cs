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
        messagesLayout = new System.Windows.Forms.FlowLayoutPanel();
        chatNamePanel = new System.Windows.Forms.Panel();
        chatNameLabel = new System.Windows.Forms.Label();
        infoPanel = new System.Windows.Forms.Panel();
        logOutLabel = new System.Windows.Forms.Label();
        chatsLabel = new System.Windows.Forms.Label();
        tableLayoutPanel1.SuspendLayout();
        chatsPanel.SuspendLayout();
        messagesPanel.SuspendLayout();
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
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
        tableLayoutPanel1.Size = new System.Drawing.Size(640, 360);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // chatsPanel
        // 
        chatsPanel.Controls.Add(chatsLayout);
        chatsPanel.Location = new System.Drawing.Point(3, 75);
        chatsPanel.Name = "chatsPanel";
        chatsPanel.Size = new System.Drawing.Size(186, 282);
        chatsPanel.TabIndex = 0;
        // 
        // chatsLayout
        // 
        chatsLayout.Location = new System.Drawing.Point(3, 3);
        chatsLayout.Name = "chatsLayout";
        chatsLayout.Size = new System.Drawing.Size(183, 279);
        chatsLayout.TabIndex = 0;
        // 
        // messagesPanel
        // 
        messagesPanel.Controls.Add(messagesLayout);
        messagesPanel.Location = new System.Drawing.Point(195, 75);
        messagesPanel.Name = "messagesPanel";
        messagesPanel.Size = new System.Drawing.Size(442, 282);
        messagesPanel.TabIndex = 1;
        // 
        // messagesLayout
        // 
        messagesLayout.Location = new System.Drawing.Point(3, 3);
        messagesLayout.Name = "messagesLayout";
        messagesLayout.Size = new System.Drawing.Size(439, 276);
        messagesLayout.TabIndex = 0;
        // 
        // chatNamePanel
        // 
        chatNamePanel.Controls.Add(chatNameLabel);
        chatNamePanel.Location = new System.Drawing.Point(195, 3);
        chatNamePanel.Name = "chatNamePanel";
        chatNamePanel.Size = new System.Drawing.Size(442, 66);
        chatNamePanel.TabIndex = 2;
        // 
        // chatNameLabel
        // 
        chatNameLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        chatNameLabel.Location = new System.Drawing.Point(3, 0);
        chatNameLabel.Name = "chatNameLabel";
        chatNameLabel.Size = new System.Drawing.Size(439, 66);
        chatNameLabel.TabIndex = 0;
        chatNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // infoPanel
        // 
        infoPanel.Controls.Add(logOutLabel);
        infoPanel.Controls.Add(chatsLabel);
        infoPanel.Location = new System.Drawing.Point(3, 3);
        infoPanel.Name = "infoPanel";
        infoPanel.Size = new System.Drawing.Size(186, 66);
        infoPanel.TabIndex = 3;
        // 
        // logOutLabel
        // 
        logOutLabel.Location = new System.Drawing.Point(86, 0);
        logOutLabel.Name = "logOutLabel";
        logOutLabel.Size = new System.Drawing.Size(100, 23);
        logOutLabel.TabIndex = 1;
        logOutLabel.Text = "Log Out";
        logOutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        logOutLabel.Click += logOutLabel_Click;
        // 
        // chatsLabel
        // 
        chatsLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        chatsLabel.Location = new System.Drawing.Point(3, 23);
        chatsLabel.Name = "chatsLabel";
        chatsLabel.Size = new System.Drawing.Size(183, 43);
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
        chatNamePanel.ResumeLayout(false);
        infoPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label chatNameLabel;

    private System.Windows.Forms.Label logOutLabel;

    private System.Windows.Forms.Label chatsLabel;

    private System.Windows.Forms.FlowLayoutPanel chatsLayout;

    private System.Windows.Forms.FlowLayoutPanel messagesLayout;

    private System.Windows.Forms.Panel chatsPanel;
    private System.Windows.Forms.Panel messagesPanel;
    private System.Windows.Forms.Panel chatNamePanel;

    private System.Windows.Forms.Panel infoPanel;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    #endregion
}