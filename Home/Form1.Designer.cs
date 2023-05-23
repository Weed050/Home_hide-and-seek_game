namespace Home
{
    partial class Form1
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
            Exits = new ComboBox();
            DescriptionBox = new TextBox();
            goThere = new Button();
            goThroughTheDoor = new Button();
            checkOpponent = new Button();
            hideYourSelf = new Button();
            SuspendLayout();
            // 
            // Exits
            // 
            Exits.DropDownStyle = ComboBoxStyle.DropDownList;
            Exits.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Exits.FormattingEnabled = true;
            Exits.Location = new Point(168, 252);
            Exits.Name = "Exits";
            Exits.Size = new Size(279, 36);
            Exits.TabIndex = 0;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            DescriptionBox.Location = new Point(13, 12);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(434, 234);
            DescriptionBox.TabIndex = 1;
            // 
            // goThere
            // 
            goThere.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            goThere.Location = new Point(13, 253);
            goThere.Name = "goThere";
            goThere.Size = new Size(149, 35);
            goThere.TabIndex = 2;
            goThere.Text = "Idź tutaj:";
            goThere.UseVisualStyleBackColor = true;
            goThere.Click += goThere_Click;
            // 
            // goThroughTheDoor
            // 
            goThroughTheDoor.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            goThroughTheDoor.Location = new Point(12, 294);
            goThroughTheDoor.Name = "goThroughTheDoor";
            goThroughTheDoor.Size = new Size(434, 48);
            goThroughTheDoor.TabIndex = 3;
            goThroughTheDoor.Text = "Przejdź przez drzwi";
            goThroughTheDoor.UseVisualStyleBackColor = true;
            goThroughTheDoor.Click += goThroughTheDoor_Click;
            // 
            // checkOpponent
            // 
            checkOpponent.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            checkOpponent.Location = new Point(13, 348);
            checkOpponent.Name = "checkOpponent";
            checkOpponent.Size = new Size(434, 40);
            checkOpponent.TabIndex = 4;
            checkOpponent.Text = "sprawdź";
            checkOpponent.UseVisualStyleBackColor = true;
            checkOpponent.Click += checkOpponent_Click;
            // 
            // hideYourSelf
            // 
            hideYourSelf.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            hideYourSelf.Location = new Point(13, 394);
            hideYourSelf.Name = "hideYourSelf";
            hideYourSelf.Size = new Size(433, 44);
            hideYourSelf.TabIndex = 5;
            hideYourSelf.Text = "Kryj się!";
            hideYourSelf.UseVisualStyleBackColor = true;
            hideYourSelf.Click += hideYourSelf_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 450);
            Controls.Add(hideYourSelf);
            Controls.Add(checkOpponent);
            Controls.Add(goThroughTheDoor);
            Controls.Add(goThere);
            Controls.Add(DescriptionBox);
            Controls.Add(Exits);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Exits;
        private TextBox DescriptionBox;
        private Button goThere;
        private Button goThroughTheDoor;
        private Button checkOpponent;
        private Button hideYourSelf;
    }
}