namespace ProyectoFinalUdemyLinq
{
    partial class FrmPopupSala
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNombre = new System.Windows.Forms.ComboBox();
            this.txtNumeroSillas = new System.Windows.Forms.NumericUpDown();
            this.txtNumeroFilas = new System.Windows.Forms.NumericUpDown();
            this.txtNumeroColumnas = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorDatos = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroSillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroFilas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroColumnas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero de Sillas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero de Filas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Numero de Columnas";
            // 
            // cmbNombre
            // 
            this.cmbNombre.FormattingEnabled = true;
            this.cmbNombre.Location = new System.Drawing.Point(244, 61);
            this.cmbNombre.Name = "cmbNombre";
            this.cmbNombre.Size = new System.Drawing.Size(121, 21);
            this.cmbNombre.TabIndex = 4;
            // 
            // txtNumeroSillas
            // 
            this.txtNumeroSillas.Location = new System.Drawing.Point(244, 144);
            this.txtNumeroSillas.Name = "txtNumeroSillas";
            this.txtNumeroSillas.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroSillas.TabIndex = 5;
            // 
            // txtNumeroFilas
            // 
            this.txtNumeroFilas.Location = new System.Drawing.Point(244, 192);
            this.txtNumeroFilas.Name = "txtNumeroFilas";
            this.txtNumeroFilas.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroFilas.TabIndex = 6;
            // 
            // txtNumeroColumnas
            // 
            this.txtNumeroColumnas.Location = new System.Drawing.Point(244, 253);
            this.txtNumeroColumnas.Name = "txtNumeroColumnas";
            this.txtNumeroColumnas.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroColumnas.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(87, 326);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(277, 326);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // errorDatos
            // 
            this.errorDatos.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre Sala";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(244, 99);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 11;
            // 
            // FrmPopupSala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 471);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNumeroColumnas);
            this.Controls.Add(this.txtNumeroFilas);
            this.Controls.Add(this.txtNumeroSillas);
            this.Controls.Add(this.cmbNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPopupSala";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPopupSala";
            this.Load += new System.EventHandler(this.FrmPopupSala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroSillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroFilas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroColumnas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNombre;
        private System.Windows.Forms.NumericUpDown txtNumeroSillas;
        private System.Windows.Forms.NumericUpDown txtNumeroFilas;
        private System.Windows.Forms.NumericUpDown txtNumeroColumnas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorDatos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
    }
}