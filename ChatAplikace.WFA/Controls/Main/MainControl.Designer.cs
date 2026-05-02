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
        messagesPanel = new System.Windows.Forms.Panel();
        chatNamePanel = new System.Windows.Forms.Panel();
        infoPanel = new System.Windows.Forms.Panel();
        tableLayoutPanel1.SuspendLayout();
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
        chatsPanel.Location = new System.Drawing.Point(3, 75);
        chatsPanel.Name = "chatsPanel";
        chatsPanel.Size = new System.Drawing.Size(186, 282);
        chatsPanel.TabIndex = 0;
        // 
        // messagesPanel
        // 
        messagesPanel.Location = new System.Drawing.Point(195, 75);
        messagesPanel.Name = "messagesPanel";
        messagesPanel.Size = new System.Drawing.Size(442, 282);
        messagesPanel.TabIndex = 1;
        // 
        // chatNamePanel
        // 
        chatNamePanel.Location = new System.Drawing.Point(195, 3);
        chatNamePanel.Name = "chatNamePanel";
        chatNamePanel.Size = new System.Drawing.Size(442, 66);
        chatNamePanel.TabIndex = 2;
        // 
        // infoPanel
        // 
        infoPanel.Location = new System.Drawing.Point(3, 3);
        infoPanel.Name = "infoPanel";
        infoPanel.Size = new System.Drawing.Size(186, 66);
        infoPanel.TabIndex = 3;
        // 
        // LoginControl
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(tableLayoutPanel1);
        Size = new System.Drawing.Size(640, 360);
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel chatsPanel;
    private System.Windows.Forms.Panel messagesPanel;
    private System.Windows.Forms.Panel chatNamePanel;

    private System.Windows.Forms.Panel infoPanel;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    #endregion
}