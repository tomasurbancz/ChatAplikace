using System.ComponentModel;

namespace ChatAplikace.WFA.Forms;

partial class AddChatForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        usernameBox = new System.Windows.Forms.TextBox();
        addButton = new System.Windows.Forms.Button();
        notFoundLabel = new System.Windows.Forms.Label();
        addLabel = new System.Windows.Forms.Label();
        chatNameBox = new System.Windows.Forms.TextBox();
        SuspendLayout();
        // 
        // usernameBox
        // 
        usernameBox.Location = new System.Drawing.Point(12, 42);
        usernameBox.Name = "usernameBox";
        usernameBox.PlaceholderText = "Username";
        usernameBox.Size = new System.Drawing.Size(188, 23);
        usernameBox.TabIndex = 0;
        // 
        // addButton
        // 
        addButton.Location = new System.Drawing.Point(12, 125);
        addButton.Name = "addButton";
        addButton.Size = new System.Drawing.Size(188, 30);
        addButton.TabIndex = 1;
        addButton.Text = "Add";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += addButton_Click;
        // 
        // notFoundLabel
        // 
        notFoundLabel.ForeColor = System.Drawing.Color.IndianRed;
        notFoundLabel.Location = new System.Drawing.Point(100, 99);
        notFoundLabel.Name = "notFoundLabel";
        notFoundLabel.Size = new System.Drawing.Size(100, 23);
        notFoundLabel.TabIndex = 2;
        notFoundLabel.Text = "Wrong data";
        notFoundLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        notFoundLabel.Visible = false;
        // 
        // addLabel
        // 
        addLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        addLabel.Location = new System.Drawing.Point(12, 9);
        addLabel.Name = "addLabel";
        addLabel.Size = new System.Drawing.Size(188, 30);
        addLabel.TabIndex = 3;
        addLabel.Text = "Add Chat";
        addLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // chatNameBox
        // 
        chatNameBox.Location = new System.Drawing.Point(12, 71);
        chatNameBox.Name = "chatNameBox";
        chatNameBox.PlaceholderText = "Chat name";
        chatNameBox.Size = new System.Drawing.Size(188, 23);
        chatNameBox.TabIndex = 4;
        // 
        // AddChatForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(212, 179);
        Controls.Add(chatNameBox);
        Controls.Add(addLabel);
        Controls.Add(notFoundLabel);
        Controls.Add(addButton);
        Controls.Add(usernameBox);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Text = "AddChatForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox chatNameBox;

    private System.Windows.Forms.Label addLabel;

    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.Label notFoundLabel;

    private System.Windows.Forms.TextBox usernameBox;

    #endregion
}