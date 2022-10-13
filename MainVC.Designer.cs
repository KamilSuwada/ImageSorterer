
namespace Organizator_Zdjec
{
    partial class MainVC
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
            this.sourceLabel = new System.Windows.Forms.Label();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.sourceButton = new System.Windows.Forms.Button();
            this.destinationButton = new System.Windows.Forms.Button();
            this.deleteDestinationImagesCheckBox = new System.Windows.Forms.CheckBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.sourceLabelFolder = new System.Windows.Forms.Label();
            this.destinationLabelFolder = new System.Windows.Forms.Label();
            this.currentTaskLabel = new System.Windows.Forms.Label();
            this.destinationFolderTextBox = new System.Windows.Forms.TextBox();
            this.sourceFolderTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(12, 9);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(129, 15);
            this.sourceLabel.TabIndex = 0;
            this.sourceLabel.Text = "Sortuj zdjecia z folderu:";
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Location = new System.Drawing.Point(190, 9);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(138, 15);
            this.destinationLabel.TabIndex = 1;
            this.destinationLabel.Text = "Sortuj zdjecia do folderu:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 291);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(307, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 2;
            // 
            // sourceButton
            // 
            this.sourceButton.Location = new System.Drawing.Point(12, 27);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(129, 23);
            this.sourceButton.TabIndex = 3;
            this.sourceButton.Text = "Sortuj z folderu";
            this.sourceButton.UseVisualStyleBackColor = true;
            this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click);
            // 
            // destinationButton
            // 
            this.destinationButton.Location = new System.Drawing.Point(190, 27);
            this.destinationButton.Name = "destinationButton";
            this.destinationButton.Size = new System.Drawing.Size(129, 23);
            this.destinationButton.TabIndex = 4;
            this.destinationButton.Text = "Sortuj do folderu";
            this.destinationButton.UseVisualStyleBackColor = true;
            this.destinationButton.Click += new System.EventHandler(this.destinationButton_Click);
            // 
            // deleteDestinationImagesCheckBox
            // 
            this.deleteDestinationImagesCheckBox.AutoSize = true;
            this.deleteDestinationImagesCheckBox.Location = new System.Drawing.Point(12, 222);
            this.deleteDestinationImagesCheckBox.Name = "deleteDestinationImagesCheckBox";
            this.deleteDestinationImagesCheckBox.Size = new System.Drawing.Size(238, 19);
            this.deleteDestinationImagesCheckBox.TabIndex = 5;
            this.deleteDestinationImagesCheckBox.Text = "Usun zdjecia po zakonczeniu sortowania";
            this.deleteDestinationImagesCheckBox.UseVisualStyleBackColor = true;
            this.deleteDestinationImagesCheckBox.CheckStateChanged += new System.EventHandler(this.deleteDestinationImagesCheckBox_CheckStateChanged);
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(12, 247);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(307, 23);
            this.sortButton.TabIndex = 6;
            this.sortButton.Text = "Rozpocznij sortowanie";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // sourceLabelFolder
            // 
            this.sourceLabelFolder.AutoSize = true;
            this.sourceLabelFolder.Location = new System.Drawing.Point(12, 56);
            this.sourceLabelFolder.Name = "sourceLabelFolder";
            this.sourceLabelFolder.Size = new System.Drawing.Size(58, 15);
            this.sourceLabelFolder.TabIndex = 7;
            this.sourceLabelFolder.Text = "Z folderu:";
            // 
            // destinationLabelFolder
            // 
            this.destinationLabelFolder.AutoSize = true;
            this.destinationLabelFolder.Location = new System.Drawing.Point(13, 137);
            this.destinationLabelFolder.Name = "destinationLabelFolder";
            this.destinationLabelFolder.Size = new System.Drawing.Size(66, 15);
            this.destinationLabelFolder.TabIndex = 9;
            this.destinationLabelFolder.Text = "Do folderu:";
            // 
            // currentTaskLabel
            // 
            this.currentTaskLabel.AutoSize = true;
            this.currentTaskLabel.Location = new System.Drawing.Point(13, 273);
            this.currentTaskLabel.Name = "currentTaskLabel";
            this.currentTaskLabel.Size = new System.Drawing.Size(71, 15);
            this.currentTaskLabel.TabIndex = 11;
            this.currentTaskLabel.Text = "Current task";
            // 
            // destinationFolderTextBox
            // 
            this.destinationFolderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.destinationFolderTextBox.Location = new System.Drawing.Point(104, 137);
            this.destinationFolderTextBox.Multiline = true;
            this.destinationFolderTextBox.Name = "destinationFolderTextBox";
            this.destinationFolderTextBox.ReadOnly = true;
            this.destinationFolderTextBox.Size = new System.Drawing.Size(215, 75);
            this.destinationFolderTextBox.TabIndex = 12;
            // 
            // sourceFolderTextBox
            // 
            this.sourceFolderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sourceFolderTextBox.Location = new System.Drawing.Point(102, 56);
            this.sourceFolderTextBox.Multiline = true;
            this.sourceFolderTextBox.Name = "sourceFolderTextBox";
            this.sourceFolderTextBox.ReadOnly = true;
            this.sourceFolderTextBox.Size = new System.Drawing.Size(215, 75);
            this.sourceFolderTextBox.TabIndex = 13;
            // 
            // MainVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 323);
            this.Controls.Add(this.sourceFolderTextBox);
            this.Controls.Add(this.destinationFolderTextBox);
            this.Controls.Add(this.currentTaskLabel);
            this.Controls.Add(this.destinationLabelFolder);
            this.Controls.Add(this.sourceLabelFolder);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.deleteDestinationImagesCheckBox);
            this.Controls.Add(this.destinationButton);
            this.Controls.Add(this.sourceButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.destinationLabel);
            this.Controls.Add(this.sourceLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainVC";
            this.Text = "Organizator Zdjec";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button sourceButton;
        private System.Windows.Forms.Button destinationButton;
        private System.Windows.Forms.CheckBox deleteDestinationImagesCheckBox;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Label sourceLabelFolder;
        private System.Windows.Forms.Label destinationLabelFolder;
        private System.Windows.Forms.Label currentTaskLabel;
        private System.Windows.Forms.TextBox destinationFolderTextBox;
        private System.Windows.Forms.TextBox sourceFolderTextBox;
    }
}

