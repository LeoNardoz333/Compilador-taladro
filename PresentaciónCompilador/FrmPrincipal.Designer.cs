namespace PresentaciónCompilador
{
    partial class FrmPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSintactico = new System.Windows.Forms.Button();
            this.btnLexico = new System.Windows.Forms.Button();
            this.dtgTabla = new System.Windows.Forms.DataGridView();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.btnSemantico = new System.Windows.Forms.Button();
            this.txtTraduccion = new System.Windows.Forms.TextBox();
            this.btnTraducir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPin1 = new System.Windows.Forms.MaskedTextBox();
            this.txtPin2 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPlaca = new System.Windows.Forms.ComboBox();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSintactico
            // 
            this.btnSintactico.BackColor = System.Drawing.Color.Turquoise;
            this.btnSintactico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSintactico.Location = new System.Drawing.Point(110, 277);
            this.btnSintactico.Name = "btnSintactico";
            this.btnSintactico.Size = new System.Drawing.Size(131, 48);
            this.btnSintactico.TabIndex = 5;
            this.btnSintactico.Text = "Sintáctico";
            this.btnSintactico.UseVisualStyleBackColor = false;
            this.btnSintactico.Click += new System.EventHandler(this.btnSintactico_Click);
            // 
            // btnLexico
            // 
            this.btnLexico.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLexico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLexico.Location = new System.Drawing.Point(12, 277);
            this.btnLexico.Name = "btnLexico";
            this.btnLexico.Size = new System.Drawing.Size(92, 48);
            this.btnLexico.TabIndex = 6;
            this.btnLexico.Text = "Léxico";
            this.btnLexico.UseVisualStyleBackColor = false;
            this.btnLexico.Click += new System.EventHandler(this.btnLexico_Click);
            // 
            // dtgTabla
            // 
            this.dtgTabla.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dtgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTabla.Location = new System.Drawing.Point(247, 12);
            this.dtgTabla.Name = "dtgTabla";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTabla.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgTabla.Size = new System.Drawing.Size(700, 367);
            this.dtgTabla.TabIndex = 5;
            this.dtgTabla.TabStop = false;
            // 
            // txtTexto
            // 
            this.txtTexto.BackColor = System.Drawing.Color.OldLace;
            this.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(12, 12);
            this.txtTexto.Multiline = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(228, 259);
            this.txtTexto.TabIndex = 4;
            this.txtTexto.TabStop = false;
            // 
            // btnSemantico
            // 
            this.btnSemantico.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnSemantico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemantico.Location = new System.Drawing.Point(12, 331);
            this.btnSemantico.Name = "btnSemantico";
            this.btnSemantico.Size = new System.Drawing.Size(108, 48);
            this.btnSemantico.TabIndex = 4;
            this.btnSemantico.Text = "Semántico";
            this.btnSemantico.UseVisualStyleBackColor = false;
            this.btnSemantico.Click += new System.EventHandler(this.btnSemantico_Click);
            // 
            // txtTraduccion
            // 
            this.txtTraduccion.BackColor = System.Drawing.Color.Snow;
            this.txtTraduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTraduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraduccion.Location = new System.Drawing.Point(953, 12);
            this.txtTraduccion.Multiline = true;
            this.txtTraduccion.Name = "txtTraduccion";
            this.txtTraduccion.Size = new System.Drawing.Size(342, 293);
            this.txtTraduccion.TabIndex = 9;
            this.txtTraduccion.TabStop = false;
            // 
            // btnTraducir
            // 
            this.btnTraducir.BackColor = System.Drawing.Color.Khaki;
            this.btnTraducir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraducir.Location = new System.Drawing.Point(126, 331);
            this.btnTraducir.Name = "btnTraducir";
            this.btnTraducir.Size = new System.Drawing.Size(115, 48);
            this.btnTraducir.TabIndex = 3;
            this.btnTraducir.Text = "Traducir";
            this.btnTraducir.UseVisualStyleBackColor = false;
            this.btnTraducir.Click += new System.EventHandler(this.btnTraducir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1208, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Traducción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(953, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Pin 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1034, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pin 2:";
            // 
            // txtPin1
            // 
            this.txtPin1.BackColor = System.Drawing.Color.Linen;
            this.txtPin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin1.Location = new System.Drawing.Point(997, 353);
            this.txtPin1.Mask = "00";
            this.txtPin1.Name = "txtPin1";
            this.txtPin1.Size = new System.Drawing.Size(31, 26);
            this.txtPin1.TabIndex = 1;
            // 
            // txtPin2
            // 
            this.txtPin2.BackColor = System.Drawing.Color.Linen;
            this.txtPin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin2.Location = new System.Drawing.Point(1078, 355);
            this.txtPin2.Mask = "00";
            this.txtPin2.Name = "txtPin2";
            this.txtPin2.Size = new System.Drawing.Size(28, 26);
            this.txtPin2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1112, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "(9-11,6,5,3)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(953, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Placa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1142, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Puerto:";
            // 
            // cmbPlaca
            // 
            this.cmbPlaca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlaca.FormattingEnabled = true;
            this.cmbPlaca.Items.AddRange(new object[] {
            "1 - Arduino Uno",
            "2 - Arduino Leonardo",
            "3 - Arduino Esplora",
            "4 - Arduino Micro",
            "5 - Arduino Duemilanove (328)",
            "6 - Arduino Duemilanove (168)",
            "7 - Arduino Nano (328)",
            "8 - Arduino Nano (168)",
            "9 - Arduino Mini (328)",
            "10 - Arduino Mini (168)",
            "11 - Arduino Pro Mini (328)",
            "12 - Arduino Pro Mini (168)",
            "13 - Arduino Mega 2560/ADK",
            "14 - Arduino Mega 1280",
            "15 - Arduino Mega 8",
            "16 - Microduino Core+ (644P)",
            "17 - Freematics OBD-II Adapter (644P)"});
            this.cmbPlaca.Location = new System.Drawing.Point(1012, 322);
            this.cmbPlaca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPlaca.Name = "cmbPlaca";
            this.cmbPlaca.Size = new System.Drawing.Size(129, 28);
            this.cmbPlaca.TabIndex = 22;
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4"});
            this.cmbPuerto.Location = new System.Drawing.Point(1202, 324);
            this.cmbPuerto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(93, 28);
            this.cmbPuerto.TabIndex = 21;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 386);
            this.Controls.Add(this.cmbPlaca);
            this.Controls.Add(this.cmbPuerto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPin2);
            this.Controls.Add(this.txtPin1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTraducir);
            this.Controls.Add(this.txtTraduccion);
            this.Controls.Add(this.btnSemantico);
            this.Controls.Add(this.btnSintactico);
            this.Controls.Add(this.btnLexico);
            this.Controls.Add(this.dtgTabla);
            this.Controls.Add(this.txtTexto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSintactico;
        private System.Windows.Forms.Button btnLexico;
        private System.Windows.Forms.DataGridView dtgTabla;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Button btnSemantico;
        private System.Windows.Forms.TextBox txtTraduccion;
        private System.Windows.Forms.Button btnTraducir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtPin1;
        private System.Windows.Forms.MaskedTextBox txtPin2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPlaca;
        private System.Windows.Forms.ComboBox cmbPuerto;
    }
}