﻿namespace WolframAlphaNETClient
{
    partial class Forma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forma));
            this.pictureNameTb = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.resenjertx = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureNameTb
            // 
            this.pictureNameTb.Location = new System.Drawing.Point(117, 61);
            this.pictureNameTb.Name = "pictureNameTb";
            this.pictureNameTb.ReadOnly = true;
            this.pictureNameTb.Size = new System.Drawing.Size(393, 20);
            this.pictureNameTb.TabIndex = 25;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(12, 59);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(99, 23);
            this.browseButton.TabIndex = 24;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.resenjertx);
            this.panel2.Location = new System.Drawing.Point(784, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 504);
            this.panel2.TabIndex = 23;
            // 
            // resenjertx
            // 
            this.resenjertx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resenjertx.Location = new System.Drawing.Point(3, 3);
            this.resenjertx.Name = "resenjertx";
            this.resenjertx.ReadOnly = true;
            this.resenjertx.Size = new System.Drawing.Size(279, 493);
            this.resenjertx.TabIndex = 0;
            this.resenjertx.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 509);
            this.panel1.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(761, 499);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(781, 65);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(59, 20);
            this.resultLabel.TabIndex = 27;
            this.resultLabel.Text = "Result:";
            // 
            // solveButton
            // 
            this.solveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("solveButton.BackgroundImage")));
            this.solveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.solveButton.Location = new System.Drawing.Point(516, 59);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(26, 23);
            this.solveButton.TabIndex = 26;
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(841, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 29;
            // 
            // Forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 612);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureNameTb);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.solveButton);
            this.Name = "Forma";
            this.Text = "Equation solver";
            this.Load += new System.EventHandler(this.Forma_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pictureNameTb;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.RichTextBox resenjertx;
        private System.Windows.Forms.Label label1;
    }
}