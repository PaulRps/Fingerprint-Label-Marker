using System.Drawing;

namespace WinFormFingerprintLabelMarker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGroundTruthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCheckpointFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxImageNames = new System.Windows.Forms.ListBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.labelPreviewedImage = new System.Windows.Forms.Label();
            this.labelUpperLeftPoint = new System.Windows.Forms.Label();
            this.groupBoxLabelInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxMousePositionInfo = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelBottomRightPoint = new System.Windows.Forms.Label();
            this.pictureBoxPreviewedImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelNegCount = new System.Windows.Forms.Label();
            this.labelDeltaCount = new System.Windows.Forms.Label();
            this.labelCoreCount = new System.Windows.Forms.Label();
            this.labelFilesCount = new System.Windows.Forms.Label();
            this.labelImageDim = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBoxLabelInfo.SuspendLayout();
            this.groupBoxMousePositionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreviewedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(911, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveGroundTruthToolStripMenuItem,
            this.loadCheckpointFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = global::WinFormFingerprintLabelMarker.Properties.Resources.icons8_documents_folder_filled_52;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.loadToolStripMenuItem.Text = "Load dataset";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveGroundTruthToolStripMenuItem
            // 
            this.saveGroundTruthToolStripMenuItem.Image = global::WinFormFingerprintLabelMarker.Properties.Resources.icons8_save_52;
            this.saveGroundTruthToolStripMenuItem.Name = "saveGroundTruthToolStripMenuItem";
            this.saveGroundTruthToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveGroundTruthToolStripMenuItem.Text = "Save Ground Truth";
            this.saveGroundTruthToolStripMenuItem.Click += new System.EventHandler(this.saveGroundTruthToolStripMenuItem_Click);
            // 
            // loadCheckpointFileToolStripMenuItem
            // 
            this.loadCheckpointFileToolStripMenuItem.Image = global::WinFormFingerprintLabelMarker.Properties.Resources.icons8_txt_52;
            this.loadCheckpointFileToolStripMenuItem.Name = "loadCheckpointFileToolStripMenuItem";
            this.loadCheckpointFileToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.loadCheckpointFileToolStripMenuItem.Text = "Load Checkpoint File";
            this.loadCheckpointFileToolStripMenuItem.Click += new System.EventHandler(this.loadCheckpointFileToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // listBoxImageNames
            // 
            this.listBoxImageNames.BackColor = System.Drawing.Color.White;
            this.listBoxImageNames.FormattingEnabled = true;
            this.listBoxImageNames.Location = new System.Drawing.Point(29, 54);
            this.listBoxImageNames.Name = "listBoxImageNames";
            this.listBoxImageNames.Size = new System.Drawing.Size(137, 498);
            this.listBoxImageNames.Sorted = true;
            this.listBoxImageNames.TabIndex = 3;
            this.listBoxImageNames.SelectedIndexChanged += new System.EventHandler(this.listBoxImageNames_SelectedIndexChanged);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonNext.Location = new System.Drawing.Point(227, 226);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(100, 23);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonUndo.Location = new System.Drawing.Point(227, 185);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(100, 23);
            this.buttonUndo.TabIndex = 5;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = false;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonReset.Location = new System.Drawing.Point(227, 146);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(100, 23);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(198, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Core";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGreen;
            this.label2.Location = new System.Drawing.Point(258, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Delta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(149, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Neg";
            // 
            // labelPreviewedImage
            // 
            this.labelPreviewedImage.AutoSize = true;
            this.labelPreviewedImage.Location = new System.Drawing.Point(227, 278);
            this.labelPreviewedImage.Name = "labelPreviewedImage";
            this.labelPreviewedImage.Size = new System.Drawing.Size(70, 13);
            this.labelPreviewedImage.TabIndex = 12;
            this.labelPreviewedImage.Text = "Selected Box";
            // 
            // labelUpperLeftPoint
            // 
            this.labelUpperLeftPoint.AutoSize = true;
            this.labelUpperLeftPoint.Location = new System.Drawing.Point(306, 452);
            this.labelUpperLeftPoint.Name = "labelUpperLeftPoint";
            this.labelUpperLeftPoint.Size = new System.Drawing.Size(0, 13);
            this.labelUpperLeftPoint.TabIndex = 13;
            // 
            // groupBoxLabelInfo
            // 
            this.groupBoxLabelInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBoxLabelInfo.Controls.Add(this.labelCoreCount);
            this.groupBoxLabelInfo.Controls.Add(this.labelDeltaCount);
            this.groupBoxLabelInfo.Controls.Add(this.labelNegCount);
            this.groupBoxLabelInfo.Controls.Add(this.label3);
            this.groupBoxLabelInfo.Location = new System.Drawing.Point(177, 51);
            this.groupBoxLabelInfo.Name = "groupBoxLabelInfo";
            this.groupBoxLabelInfo.Size = new System.Drawing.Size(200, 72);
            this.groupBoxLabelInfo.TabIndex = 14;
            this.groupBoxLabelInfo.TabStop = false;
            this.groupBoxLabelInfo.Text = "Label Info";
            // 
            // groupBoxMousePositionInfo
            // 
            this.groupBoxMousePositionInfo.Controls.Add(this.label5);
            this.groupBoxMousePositionInfo.Controls.Add(this.label4);
            this.groupBoxMousePositionInfo.Location = new System.Drawing.Point(177, 424);
            this.groupBoxMousePositionInfo.Name = "groupBoxMousePositionInfo";
            this.groupBoxMousePositionInfo.Size = new System.Drawing.Size(200, 100);
            this.groupBoxMousePositionInfo.TabIndex = 15;
            this.groupBoxMousePositionInfo.TabStop = false;
            this.groupBoxMousePositionInfo.Text = "Box Position Info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Bottom Right Point (x, y):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Upper Left Point (x, y):";
            // 
            // labelBottomRightPoint
            // 
            this.labelBottomRightPoint.AutoSize = true;
            this.labelBottomRightPoint.Location = new System.Drawing.Point(308, 488);
            this.labelBottomRightPoint.Name = "labelBottomRightPoint";
            this.labelBottomRightPoint.Size = new System.Drawing.Size(0, 13);
            this.labelBottomRightPoint.TabIndex = 16;
            // 
            // pictureBoxPreviewedImage
            // 
            this.pictureBoxPreviewedImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxPreviewedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPreviewedImage.Location = new System.Drawing.Point(227, 294);
            this.pictureBoxPreviewedImage.Name = "pictureBoxPreviewedImage";
            this.pictureBoxPreviewedImage.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxPreviewedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreviewedImage.TabIndex = 11;
            this.pictureBoxPreviewedImage.TabStop = false;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxImage.InitialImage = null;
            this.pictureBoxImage.Location = new System.Drawing.Point(389, 54);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(437, 500);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 10;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImage_MouseClick);
            this.pictureBoxImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImage_MouseMove);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Title = "Choose the checkpoint file";
            // 
            // labelNegCount
            // 
            this.labelNegCount.AutoSize = true;
            this.labelNegCount.Location = new System.Drawing.Point(151, 53);
            this.labelNegCount.Name = "labelNegCount";
            this.labelNegCount.Size = new System.Drawing.Size(0, 13);
            this.labelNegCount.TabIndex = 10;
            // 
            // labelDeltaCount
            // 
            this.labelDeltaCount.AutoSize = true;
            this.labelDeltaCount.Location = new System.Drawing.Point(83, 53);
            this.labelDeltaCount.Name = "labelDeltaCount";
            this.labelDeltaCount.Size = new System.Drawing.Size(0, 13);
            this.labelDeltaCount.TabIndex = 11;
            // 
            // labelCoreCount
            // 
            this.labelCoreCount.AutoSize = true;
            this.labelCoreCount.Location = new System.Drawing.Point(23, 53);
            this.labelCoreCount.Name = "labelCoreCount";
            this.labelCoreCount.Size = new System.Drawing.Size(0, 13);
            this.labelCoreCount.TabIndex = 12;
            // 
            // labelFilesCount
            // 
            this.labelFilesCount.AutoSize = true;
            this.labelFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilesCount.Location = new System.Drawing.Point(27, 42);
            this.labelFilesCount.Name = "labelFilesCount";
            this.labelFilesCount.Size = new System.Drawing.Size(0, 12);
            this.labelFilesCount.TabIndex = 17;
            // 
            // labelImageDim
            // 
            this.labelImageDim.AutoSize = true;
            this.labelImageDim.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageDim.Location = new System.Drawing.Point(387, 42);
            this.labelImageDim.Name = "labelImageDim";
            this.labelImageDim.Size = new System.Drawing.Size(0, 12);
            this.labelImageDim.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(911, 579);
            this.Controls.Add(this.labelImageDim);
            this.Controls.Add(this.labelFilesCount);
            this.Controls.Add(this.labelBottomRightPoint);
            this.Controls.Add(this.labelUpperLeftPoint);
            this.Controls.Add(this.labelPreviewedImage);
            this.Controls.Add(this.pictureBoxPreviewedImage);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.listBoxImageNames);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxLabelInfo);
            this.Controls.Add(this.groupBoxMousePositionInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fingerprint Label Marker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxLabelInfo.ResumeLayout(false);
            this.groupBoxLabelInfo.PerformLayout();
            this.groupBoxMousePositionInfo.ResumeLayout(false);
            this.groupBoxMousePositionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreviewedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxImageNames;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.PictureBox pictureBoxPreviewedImage;
        private System.Windows.Forms.Label labelPreviewedImage;
        private System.Windows.Forms.Label labelUpperLeftPoint;
        private System.Windows.Forms.ToolStripMenuItem saveGroundTruthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCheckpointFileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxLabelInfo;
        private System.Windows.Forms.GroupBox groupBoxMousePositionInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelBottomRightPoint;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelCoreCount;
        private System.Windows.Forms.Label labelDeltaCount;
        private System.Windows.Forms.Label labelNegCount;
        private System.Windows.Forms.Label labelFilesCount;
        private System.Windows.Forms.Label labelImageDim;
    }
}

