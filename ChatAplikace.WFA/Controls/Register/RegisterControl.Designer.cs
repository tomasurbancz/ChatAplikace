using System.ComponentModel;

namespace ChatAplikace.WFA.Controls.Register;

partial class RegisterControl
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
        registerPanel = new System.Windows.Forms.Panel();
        passwordBox = new System.Windows.Forms.TextBox();
        usernameBox = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        registerButton = new System.Windows.Forms.Button();
        registerLabel = new System.Windows.Forms.Label();
        tableLayoutPanel1.SuspendLayout();
        registerPanel.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
        tableLayoutPanel1.Controls.Add(registerPanel, 1, 1);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.944445F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.77778F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.944445F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.77778F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel1.Size = new System.Drawing.Size(640, 360);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // registerPanel
        // 
        registerPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
        registerPanel.Controls.Add(passwordBox);
        registerPanel.Controls.Add(usernameBox);
        registerPanel.Controls.Add(label1);
        registerPanel.Controls.Add(registerButton);
        registerPanel.Controls.Add(registerLabel);
        registerPanel.Location = new System.Drawing.Point(216, 82);
        registerPanel.Name = "registerPanel";
        registerPanel.Size = new System.Drawing.Size(207, 184);
        registerPanel.TabIndex = 0;
        // 
        // passwordBox
        // 
        passwordBox.Location = new System.Drawing.Point(3, 72);
        passwordBox.Name = "passwordBox";
        passwordBox.PlaceholderText = "Password";
        passwordBox.Size = new System.Drawing.Size(201, 23);
        passwordBox.TabIndex = 4;
        // 
        // usernameBox
        // 
        usernameBox.Location = new System.Drawing.Point(3, 43);
        usernameBox.Name = "usernameBox";
        usernameBox.PlaceholderText = "Username";
        usernameBox.Size = new System.Drawing.Size(201, 23);
        usernameBox.TabIndex = 3;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(104, 125);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 2;
        label1.Text = "Login";
        label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        label1.Click += label1_Click;
        // 
        // registerButton
        // 
        registerButton.Location = new System.Drawing.Point(3, 151);
        registerButton.Name = "registerButton";
        registerButton.Size = new System.Drawing.Size(201, 30);
        registerButton.TabIndex = 1;
        registerButton.Text = "Register";
        registerButton.UseVisualStyleBackColor = true;
        registerButton.Click += registerButton_Click;
        // 
        // registerLabel
        // 
        registerLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
        registerLabel.Location = new System.Drawing.Point(0, 0);
        registerLabel.Name = "registerLabel";
        registerLabel.Size = new System.Drawing.Size(207, 31);
        registerLabel.TabIndex = 0;
        registerLabel.Text = "Register";
        registerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // RegisterControl
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        Controls.Add(tableLayoutPanel1);
        Location = new System.Drawing.Point(15, 15);
        Size = new System.Drawing.Size(640, 360);
        tableLayoutPanel1.ResumeLayout(false);
        registerPanel.ResumeLayout(false);
        registerPanel.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox usernameBox;
    private System.Windows.Forms.TextBox passwordBox;

    private System.Windows.Forms.Button registerButton;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Label registerLabel;

    private System.Windows.Forms.Panel registerPanel;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    #endregion
}