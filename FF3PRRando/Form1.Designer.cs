namespace FF3PRRando
{
    partial class FF3PRRandoForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FF3PRRandoForm));
            magiciteDirectoryTxtBx = new TextBox();
            directoryBrowseBtn = new Button();
            seedTxtBox = new TextBox();
            InputDirectoryLabel = new Label();
            SeedLabel = new Label();
            randomizeBtn = new Button();
            outputPath = new TextBox();
            outputLabel = new Label();
            outputBrowseBtn = new Button();
            shuffleJobsBox = new CheckBox();
            shuffleShopsBox = new CheckBox();
            shuffleChestsBox = new CheckBox();
            shuffleBGMBox = new CheckBox();
            jobsToolTip = new ToolTip(components);
            shopsToolTip = new ToolTip(components);
            chestsToolTip = new ToolTip(components);
            bgmToolTip = new ToolTip(components);
            label1 = new Label();
            SuspendLayout();
            // 
            // magiciteDirectoryTxtBx
            // 
            magiciteDirectoryTxtBx.Location = new Point(169, 64);
            magiciteDirectoryTxtBx.Name = "magiciteDirectoryTxtBx";
            magiciteDirectoryTxtBx.Size = new Size(544, 23);
            magiciteDirectoryTxtBx.TabIndex = 0;
            // 
            // directoryBrowseBtn
            // 
            directoryBrowseBtn.Location = new Point(719, 63);
            directoryBrowseBtn.Name = "directoryBrowseBtn";
            directoryBrowseBtn.Size = new Size(69, 23);
            directoryBrowseBtn.TabIndex = 1;
            directoryBrowseBtn.Text = "Browse";
            directoryBrowseBtn.UseVisualStyleBackColor = true;
            directoryBrowseBtn.Click += directoryBrowseBtn_Click;
            // 
            // seedTxtBox
            // 
            seedTxtBox.Location = new Point(169, 318);
            seedTxtBox.Name = "seedTxtBox";
            seedTxtBox.Size = new Size(243, 23);
            seedTxtBox.TabIndex = 2;
            // 
            // InputDirectoryLabel
            // 
            InputDirectoryLabel.AutoSize = true;
            InputDirectoryLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            InputDirectoryLabel.Location = new Point(40, 67);
            InputDirectoryLabel.Name = "InputDirectoryLabel";
            InputDirectoryLabel.Size = new Size(123, 15);
            InputDirectoryLabel.TabIndex = 3;
            InputDirectoryLabel.Text = "Magicite Export Path";
            InputDirectoryLabel.Click += InputDirectoryLabel_Click;
            // 
            // SeedLabel
            // 
            SeedLabel.AutoSize = true;
            SeedLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SeedLabel.Location = new Point(79, 321);
            SeedLabel.Name = "SeedLabel";
            SeedLabel.Size = new Size(84, 15);
            SeedLabel.TabIndex = 4;
            SeedLabel.Text = "Seed Number";
            // 
            // randomizeBtn
            // 
            randomizeBtn.Location = new Point(346, 382);
            randomizeBtn.Name = "randomizeBtn";
            randomizeBtn.Size = new Size(112, 56);
            randomizeBtn.TabIndex = 5;
            randomizeBtn.Text = "Randomize!";
            randomizeBtn.UseVisualStyleBackColor = true;
            randomizeBtn.Click += randomizeBtn_Click;
            // 
            // outputPath
            // 
            outputPath.Location = new Point(169, 102);
            outputPath.Name = "outputPath";
            outputPath.Size = new Size(544, 23);
            outputPath.TabIndex = 6;
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            outputLabel.Location = new Point(88, 105);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(75, 15);
            outputLabel.TabIndex = 7;
            outputLabel.Text = "Output Path";
            // 
            // outputBrowseBtn
            // 
            outputBrowseBtn.Location = new Point(719, 101);
            outputBrowseBtn.Name = "outputBrowseBtn";
            outputBrowseBtn.Size = new Size(69, 23);
            outputBrowseBtn.TabIndex = 8;
            outputBrowseBtn.Text = "Browse";
            outputBrowseBtn.UseVisualStyleBackColor = true;
            outputBrowseBtn.Click += outputBrowseBtn_Click;
            // 
            // shuffleJobsBox
            // 
            shuffleJobsBox.AutoSize = true;
            shuffleJobsBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            shuffleJobsBox.Location = new Point(169, 267);
            shuffleJobsBox.Name = "shuffleJobsBox";
            shuffleJobsBox.Size = new Size(94, 19);
            shuffleJobsBox.TabIndex = 9;
            shuffleJobsBox.Text = "Shuffle Jobs";
            jobsToolTip.SetToolTip(shuffleJobsBox, resources.GetString("shuffleJobsBox.ToolTip"));
            shuffleJobsBox.UseVisualStyleBackColor = true;
            // 
            // shuffleShopsBox
            // 
            shuffleShopsBox.AutoSize = true;
            shuffleShopsBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            shuffleShopsBox.Location = new Point(169, 151);
            shuffleShopsBox.Name = "shuffleShopsBox";
            shuffleShopsBox.Size = new Size(133, 19);
            shuffleShopsBox.TabIndex = 10;
            shuffleShopsBox.Text = "Shuffle Shop Items";
            shopsToolTip.SetToolTip(shuffleShopsBox, resources.GetString("shuffleShopsBox.ToolTip"));
            shuffleShopsBox.UseVisualStyleBackColor = true;
            // 
            // shuffleChestsBox
            // 
            shuffleChestsBox.AutoSize = true;
            shuffleChestsBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            shuffleChestsBox.Location = new Point(169, 191);
            shuffleChestsBox.Name = "shuffleChestsBox";
            shuffleChestsBox.Size = new Size(157, 19);
            shuffleChestsBox.TabIndex = 11;
            shuffleChestsBox.Text = "Shuffle Treasure Chests";
            chestsToolTip.SetToolTip(shuffleChestsBox, "Shuffle all chest contents.\r\nThis also includes items obtained from pots\r\nand the like. Items gifted by NPCs, Key Items\r\nand other items obtained throught the story\r\nare not included.");
            shuffleChestsBox.UseVisualStyleBackColor = true;
            // 
            // shuffleBGMBox
            // 
            shuffleBGMBox.AutoSize = true;
            shuffleBGMBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            shuffleBGMBox.Location = new Point(169, 227);
            shuffleBGMBox.Name = "shuffleBGMBox";
            shuffleBGMBox.Size = new Size(172, 19);
            shuffleBGMBox.TabIndex = 12;
            shuffleBGMBox.Text = "Shuffle Background Music";
            bgmToolTip.SetToolTip(shuffleBGMBox, resources.GetString("shuffleBGMBox.ToolTip"));
            shuffleBGMBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(269, 268);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 13;
            label1.Text = "(Experimental)";
            // 
            // FF3PRRandoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 464);
            Controls.Add(label1);
            Controls.Add(shuffleBGMBox);
            Controls.Add(shuffleChestsBox);
            Controls.Add(shuffleShopsBox);
            Controls.Add(shuffleJobsBox);
            Controls.Add(outputBrowseBtn);
            Controls.Add(outputLabel);
            Controls.Add(outputPath);
            Controls.Add(randomizeBtn);
            Controls.Add(SeedLabel);
            Controls.Add(InputDirectoryLabel);
            Controls.Add(seedTxtBox);
            Controls.Add(directoryBrowseBtn);
            Controls.Add(magiciteDirectoryTxtBx);
            Name = "FF3PRRandoForm";
            Text = "FF3PR Randomizer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox magiciteDirectoryTxtBx;
        private Button directoryBrowseBtn;
        private TextBox seedTxtBox;
        private Label InputDirectoryLabel;
        private Label SeedLabel;
        private Button randomizeBtn;
        private TextBox outputPath;
        private Label outputLabel;
        private Button outputBrowseBtn;
        private CheckBox shuffleJobsBox;
        private CheckBox shuffleShopsBox;
        private CheckBox shuffleChestsBox;
        private CheckBox shuffleBGMBox;
        private ToolTip jobsToolTip;
        private ToolTip shopsToolTip;
        private ToolTip chestsToolTip;
        private ToolTip bgmToolTip;
        private Label label1;
    }
}
