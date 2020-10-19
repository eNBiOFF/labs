namespace lab05
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFindWr = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MaxDistant = new System.Windows.Forms.TextBox();
            this.listBoxFoundWR = new System.Windows.Forms.ListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Максимальное расстояние:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxFindWr
            // 
            this.textBoxFindWr.Location = new System.Drawing.Point(147, 13);
            this.textBoxFindWr.Name = "textBoxFindWr";
            this.textBoxFindWr.Size = new System.Drawing.Size(223, 22);
            this.textBoxFindWr.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MaxDistant
            // 
            this.MaxDistant.Location = new System.Drawing.Point(196, 41);
            this.MaxDistant.Name = "MaxDistant";
            this.MaxDistant.Size = new System.Drawing.Size(174, 22);
            this.MaxDistant.TabIndex = 3;
            // 
            // listBoxFoundWR
            // 
            this.listBoxFoundWR.FormattingEnabled = true;
            this.listBoxFoundWR.ItemHeight = 16;
            this.listBoxFoundWR.Location = new System.Drawing.Point(3, 80);
            this.listBoxFoundWR.Name = "listBoxFoundWR";
            this.listBoxFoundWR.Size = new System.Drawing.Size(759, 324);
            this.listBoxFoundWR.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(556, 13);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(206, 22);
            this.textBox3.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(391, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Выбрать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(3, 415);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(160, 23);
            this.buttonCloseProgram.TabIndex = 7;
            this.buttonCloseProgram.Text = "Завршить";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCloseProgram);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listBoxFoundWR);
            this.Controls.Add(this.MaxDistant);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxFindWr);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFindWr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox MaxDistant;
        private System.Windows.Forms.ListBox listBoxFoundWR;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonCloseProgram;
    }
}

