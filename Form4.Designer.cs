namespace AgenciaViagens
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.Classes = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numAdulto = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numCrianca = new System.Windows.Forms.NumericUpDown();
            this.HoraIda = new System.Windows.Forms.CheckedListBox();
            this.HoraVolta = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.precoAdulto = new System.Windows.Forms.Label();
            this.precoCrianca = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAdulto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrianca)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(164, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 31);
            this.label8.TabIndex = 10;
            this.label8.Text = "Origem: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(164, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 31);
            this.label9.TabIndex = 11;
            this.label9.Text = "Destino: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(164, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 31);
            this.label10.TabIndex = 12;
            this.label10.Text = "Ida: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(162, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 31);
            this.label11.TabIndex = 13;
            this.label11.Text = "Volta:";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(630, 664);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 41);
            this.button3.TabIndex = 24;
            this.button3.Text = "Prosseguir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Classes
            // 
            this.Classes.BackColor = System.Drawing.Color.White;
            this.Classes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Classes.Cursor = System.Windows.Forms.Cursors.Default;
            this.Classes.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Classes.ForeColor = System.Drawing.Color.Black;
            this.Classes.FormattingEnabled = true;
            this.Classes.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Classes.Items.AddRange(new object[] {
            "Econômica  38,66",
            "Primeira Classe  96,50",
            "Executiva  115,82"});
            this.Classes.Location = new System.Drawing.Point(963, 487);
            this.Classes.Name = "Classes";
            this.Classes.Size = new System.Drawing.Size(272, 102);
            this.Classes.TabIndex = 27;
            this.Classes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(957, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 33);
            this.label1.TabIndex = 28;
            this.label1.Text = "CLASSES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(163, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 33);
            this.label3.TabIndex = 33;
            this.label3.Text = "HORÁRIO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(163, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 33);
            this.label7.TabIndex = 34;
            this.label7.Text = "DATA";
            // 
            // numAdulto
            // 
            this.numAdulto.BackColor = System.Drawing.Color.White;
            this.numAdulto.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAdulto.ForeColor = System.Drawing.Color.Black;
            this.numAdulto.Location = new System.Drawing.Point(1067, 260);
            this.numAdulto.Name = "numAdulto";
            this.numAdulto.Size = new System.Drawing.Size(64, 39);
            this.numAdulto.TabIndex = 36;
            this.numAdulto.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(957, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 33);
            this.label2.TabIndex = 37;
            this.label2.Text = "PASSAGEIROS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(957, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 31);
            this.label4.TabIndex = 38;
            this.label4.Text = "Adulto: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(957, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 31);
            this.label5.TabIndex = 39;
            this.label5.Text = "Criança: ";
            // 
            // numCrianca
            // 
            this.numCrianca.BackColor = System.Drawing.Color.White;
            this.numCrianca.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCrianca.ForeColor = System.Drawing.Color.Black;
            this.numCrianca.Location = new System.Drawing.Point(1067, 307);
            this.numCrianca.Name = "numCrianca";
            this.numCrianca.Size = new System.Drawing.Size(64, 39);
            this.numCrianca.TabIndex = 40;
            this.numCrianca.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // HoraIda
            // 
            this.HoraIda.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.HoraIda.BackColor = System.Drawing.Color.White;
            this.HoraIda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HoraIda.CheckOnClick = true;
            this.HoraIda.Cursor = System.Windows.Forms.Cursors.Default;
            this.HoraIda.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoraIda.ForeColor = System.Drawing.Color.Black;
            this.HoraIda.FormattingEnabled = true;
            this.HoraIda.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.HoraIda.Items.AddRange(new object[] {
            "00:00",
            "02:10",
            "03:34",
            "04:56",
            "06:30",
            "08:00",
            "10:25",
            "11:50",
            "13:10",
            "15:00",
            "16:40",
            "18:00",
            "19:35",
            "20:48",
            "22:00",
            "23:30"});
            this.HoraIda.Location = new System.Drawing.Point(170, 469);
            this.HoraIda.Name = "HoraIda";
            this.HoraIda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HoraIda.Size = new System.Drawing.Size(198, 150);
            this.HoraIda.TabIndex = 41;
            this.HoraIda.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox2_ItemCheck);
            // 
            // HoraVolta
            // 
            this.HoraVolta.BackColor = System.Drawing.Color.White;
            this.HoraVolta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HoraVolta.Cursor = System.Windows.Forms.Cursors.Default;
            this.HoraVolta.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoraVolta.ForeColor = System.Drawing.Color.Black;
            this.HoraVolta.FormattingEnabled = true;
            this.HoraVolta.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.HoraVolta.Items.AddRange(new object[] {
            "00:50",
            "02:00",
            "03:30",
            "05:00",
            "06:30",
            "07:50",
            "10:15",
            "12:00",
            "13:50",
            "14:58",
            "16:40",
            "18:00",
            "19:05",
            "20:08",
            "22:00",
            "23:20"});
            this.HoraVolta.Location = new System.Drawing.Point(441, 469);
            this.HoraVolta.Name = "HoraVolta";
            this.HoraVolta.Size = new System.Drawing.Size(198, 150);
            this.HoraVolta.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(163, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 33);
            this.label6.TabIndex = 44;
            this.label6.Text = "Ida";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(435, 433);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 33);
            this.label12.TabIndex = 45;
            this.label12.Text = "Volta";
            // 
            // precoAdulto
            // 
            this.precoAdulto.AutoSize = true;
            this.precoAdulto.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoAdulto.ForeColor = System.Drawing.Color.Black;
            this.precoAdulto.Location = new System.Drawing.Point(1137, 264);
            this.precoAdulto.Name = "precoAdulto";
            this.precoAdulto.Size = new System.Drawing.Size(52, 31);
            this.precoAdulto.TabIndex = 46;
            this.precoAdulto.Text = "R$ ";
            // 
            // precoCrianca
            // 
            this.precoCrianca.AutoSize = true;
            this.precoCrianca.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoCrianca.ForeColor = System.Drawing.Color.Black;
            this.precoCrianca.Location = new System.Drawing.Point(1137, 312);
            this.precoCrianca.Name = "precoCrianca";
            this.precoCrianca.Size = new System.Drawing.Size(52, 31);
            this.precoCrianca.TabIndex = 47;
            this.precoCrianca.Text = "R$ ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(-2, -12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 118);
            this.button2.TabIndex = 48;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(169, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1884, 108);
            this.button1.TabIndex = 49;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1464, 731);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.precoCrianca);
            this.Controls.Add(this.precoAdulto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.HoraVolta);
            this.Controls.Add(this.HoraIda);
            this.Controls.Add(this.numCrianca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numAdulto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Classes);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SML Travel - Passagem";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAdulto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCrianca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox Classes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numAdulto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCrianca;
        private System.Windows.Forms.CheckedListBox HoraVolta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckedListBox HoraIda;
        private System.Windows.Forms.Label precoAdulto;
        private System.Windows.Forms.Label precoCrianca;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}