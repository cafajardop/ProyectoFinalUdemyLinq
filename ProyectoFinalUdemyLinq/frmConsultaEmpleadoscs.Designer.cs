namespace ProyectoFinalUdemyLinq
{
    partial class frmConsultaEmpleadoscs
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
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBuscarEmpleado = new MaterialSkin.Controls.MaterialFlatButton();
            this.dgvReserva = new System.Windows.Forms.DataGridView();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(162, 86);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(121, 21);
            this.cboEmpleado.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(27, 86);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(129, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Ingrese Empleado";
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.AutoSize = true;
            this.btnBuscarEmpleado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarEmpleado.Depth = 0;
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(301, 78);
            this.btnBuscarEmpleado.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscarEmpleado.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Primary = false;
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(65, 36);
            this.btnBuscarEmpleado.TabIndex = 2;
            this.btnBuscarEmpleado.Text = "Buscar";
            this.btnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.btnBuscarEmpleado_Click);
            // 
            // dgvReserva
            // 
            this.dgvReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReserva.Location = new System.Drawing.Point(21, 123);
            this.dgvReserva.Name = "dgvReserva";
            this.dgvReserva.ReadOnly = true;
            this.dgvReserva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReserva.Size = new System.Drawing.Size(453, 182);
            this.dgvReserva.TabIndex = 3;
            this.dgvReserva.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.obtenerDetalles);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Location = new System.Drawing.Point(375, 78);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(66, 36);
            this.materialFlatButton2.TabIndex = 4;
            this.materialFlatButton2.Text = "Limpiar";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(203, 325);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(56, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Detalle";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(21, 347);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(453, 182);
            this.dgvDetalle.TabIndex = 6;
            // 
            // frmConsultaEmpleadoscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 554);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.dgvReserva);
            this.Controls.Add(this.btnBuscarEmpleado);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.cboEmpleado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaEmpleadoscs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Reserva Empleado";
            this.Load += new System.EventHandler(this.frmConsultaEmpleadoscs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEmpleado;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton btnBuscarEmpleado;
        private System.Windows.Forms.DataGridView dgvReserva;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DataGridView dgvDetalle;
    }
}