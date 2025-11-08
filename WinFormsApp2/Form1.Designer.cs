namespace WinFormsApp2
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
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Violet;
            button1.Font = new Font("Segoe Script", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button1.ForeColor = SystemColors.Info;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(776, 78);
            button1.TabIndex = 0;
            button1.Text = "Пуск";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(12, 93);
            label1.Name = "label1";
            label1.Size = new Size(776, 348);
            label1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "ЛАА Демо Інтерфейс";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label label1;
    }
}
