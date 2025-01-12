namespace PresentaciónCompilador
{
    partial class FrmAplicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAplicacion));
            this.cmbPlaca = new System.Windows.Forms.ComboBox();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPin2 = new System.Windows.Forms.MaskedTextBox();
            this.txtPin1 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgTabla = new System.Windows.Forms.DataGridView();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.btnTraducir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPlaca
            // 
            this.cmbPlaca.BackColor = System.Drawing.Color.Honeydew;
            this.cmbPlaca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlaca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
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
            this.cmbPlaca.Location = new System.Drawing.Point(182, 14);
            this.cmbPlaca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPlaca.Name = "cmbPlaca";
            this.cmbPlaca.Size = new System.Drawing.Size(129, 28);
            this.cmbPlaca.TabIndex = 34;
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.BackColor = System.Drawing.Color.Honeydew;
            this.cmbPuerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuerto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4"});
            this.cmbPuerto.Location = new System.Drawing.Point(388, 14);
            this.cmbPuerto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(93, 28);
            this.cmbPuerto.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Puerto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Placa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(712, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "(9-11,6,5,3)";
            // 
            // txtPin2
            // 
            this.txtPin2.BackColor = System.Drawing.Color.LightCyan;
            this.txtPin2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin2.Location = new System.Drawing.Point(658, 13);
            this.txtPin2.Mask = "00";
            this.txtPin2.Name = "txtPin2";
            this.txtPin2.Size = new System.Drawing.Size(28, 26);
            this.txtPin2.TabIndex = 24;
            // 
            // txtPin1
            // 
            this.txtPin1.BackColor = System.Drawing.Color.LightCyan;
            this.txtPin1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin1.Location = new System.Drawing.Point(547, 13);
            this.txtPin1.Mask = "00";
            this.txtPin1.Name = "txtPin1";
            this.txtPin1.Size = new System.Drawing.Size(31, 26);
            this.txtPin1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Pin 2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Pin 1:";
            // 
            // dtgTabla
            // 
            this.dtgTabla.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dtgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTabla.Location = new System.Drawing.Point(618, 57);
            this.dtgTabla.Name = "dtgTabla";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTabla.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgTabla.Size = new System.Drawing.Size(93, 104);
            this.dtgTabla.TabIndex = 27;
            this.dtgTabla.TabStop = false;
            this.dtgTabla.Visible = false;
            // 
            // txtTexto
            // 
            this.txtTexto.BackColor = System.Drawing.Color.OldLace;
            this.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTexto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(0, 50);
            this.txtTexto.Multiline = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(814, 642);
            this.txtTexto.TabIndex = 26;
            this.txtTexto.TabStop = false;
            // 
            // btnTraducir
            // 
            this.btnTraducir.BackColor = System.Drawing.Color.PaleGreen;
            this.btnTraducir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTraducir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraducir.Image = global::PresentaciónCompilador.Properties.Resources.subir_archivo;
            this.btnTraducir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTraducir.Location = new System.Drawing.Point(12, 12);
            this.btnTraducir.Name = "btnTraducir";
            this.btnTraducir.Size = new System.Drawing.Size(95, 29);
            this.btnTraducir.TabIndex = 25;
            this.btnTraducir.Text = "Ejecutar";
            this.btnTraducir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraducir.UseVisualStyleBackColor = false;
            this.btnTraducir.Click += new System.EventHandler(this.btnTraducir_Click);
            // 
            // FrmAplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 692);
            this.Controls.Add(this.cmbPlaca);
            this.Controls.Add(this.cmbPuerto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPin2);
            this.Controls.Add(this.txtPin1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTraducir);
            this.Controls.Add(this.dtgTabla);
            this.Controls.Add(this.txtTexto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAplicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spindro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAplicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPlaca;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtPin2;
        private System.Windows.Forms.MaskedTextBox txtPin1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTraducir;
        private System.Windows.Forms.DataGridView dtgTabla;
        private System.Windows.Forms.TextBox txtTexto;
    }
}