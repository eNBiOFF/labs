namespace lab04
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.FindWord_Click = new System.Windows.Forms.Button();
            this.buttonFileTake_click = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFindword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTimeSearch = new System.Windows.Forms.TextBox();
            this.listBoxFoundWords = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Location = new System.Drawing.Point(170, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(361, 22);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(170, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(182, 22);
            this.textBox2.TabIndex = 1;
            // 
            // FindWord_Click
            // 
            this.FindWord_Click.Location = new System.Drawing.Point(12, 105);
            this.FindWord_Click.Name = "FindWord_Click";
            this.FindWord_Click.Size = new System.Drawing.Size(127, 23);
            this.FindWord_Click.TabIndex = 2;
            this.FindWord_Click.Text = "Поиск";
            this.FindWord_Click.UseVisualStyleBackColor = true;
            this.FindWord_Click.Click += new System.EventHandler(this.FindWord_Click_Click);
            // 
            // buttonFileTake_click
            // 
            this.buttonFileTake_click.Location = new System.Drawing.Point(12, 12);
            this.buttonFileTake_click.Name = "buttonFileTake_click";
            this.buttonFileTake_click.Size = new System.Drawing.Size(127, 23);
            this.buttonFileTake_click.TabIndex = 3;
            this.buttonFileTake_click.Text = "выбрать";
            this.buttonFileTake_click.UseVisualStyleBackColor = true;
            this.buttonFileTake_click.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Время считывания:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxFindword
            // 
            this.textBoxFindword.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBoxFindword.Location = new System.Drawing.Point(170, 105);
            this.textBoxFindword.Name = "textBoxFindword";
            this.textBoxFindword.Size = new System.Drawing.Size(182, 22);
            this.textBoxFindword.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Время поиска:";
            // 
            // textBoxTimeSearch
            // 
            this.textBoxTimeSearch.Location = new System.Drawing.Point(170, 140);
            this.textBoxTimeSearch.Name = "textBoxTimeSearch";
            this.textBoxTimeSearch.Size = new System.Drawing.Size(182, 22);
            this.textBoxTimeSearch.TabIndex = 7;
            // 
            // listBoxFoundWords
            // 
            this.listBoxFoundWords.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listBoxFoundWords.FormattingEnabled = true;
            this.listBoxFoundWords.ItemHeight = 16;
            this.listBoxFoundWords.Location = new System.Drawing.Point(12, 193);
            this.listBoxFoundWords.Name = "listBoxFoundWords";
            this.listBoxFoundWords.Size = new System.Drawing.Size(519, 244);
            this.listBoxFoundWords.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Завершить работу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 481);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxFoundWords);
            this.Controls.Add(this.textBoxTimeSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFindword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFileTake_click);
            this.Controls.Add(this.FindWord_Click);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button FindWord_Click;
        private System.Windows.Forms.Button buttonFileTake_click;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFindword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTimeSearch;
        private System.Windows.Forms.ListBox listBoxFoundWords;
        private System.Windows.Forms.Button button1;
    }
}

