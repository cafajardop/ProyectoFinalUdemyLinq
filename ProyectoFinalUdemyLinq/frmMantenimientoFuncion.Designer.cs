namespace ProyectoFinalUdemyLinq
{
    partial class frmMantenimientoFuncion
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
            this.dgvPeliculaFun = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPeliculaFun = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripNuevo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripEditar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripEliminar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculaFun)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPeliculaFun
            // 
            this.dgvPeliculaFun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeliculaFun.Location = new System.Drawing.Point(12, 88);
            this.dgvPeliculaFun.Name = "dgvPeliculaFun";
            this.dgvPeliculaFun.ReadOnly = true;
            this.dgvPeliculaFun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeliculaFun.Size = new System.Drawing.Size(447, 216);
            this.dgvPeliculaFun.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Pelicula";
            // 
            // cmbPeliculaFun
            // 
            this.cmbPeliculaFun.FormattingEnabled = true;
            this.cmbPeliculaFun.Location = new System.Drawing.Point(192, 43);
            this.cmbPeliculaFun.Name = "cmbPeliculaFun";
            this.cmbPeliculaFun.Size = new System.Drawing.Size(138, 21);
            this.cmbPeliculaFun.TabIndex = 2;
            this.cmbPeliculaFun.SelectionChangeCommitted += new System.EventHandler(this.filtrar);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNuevo,
            this.toolStripEditar,
            this.toolStripEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(471, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripNuevo
            // 
            this.toolStripNuevo.Name = "toolStripNuevo";
            this.toolStripNuevo.Size = new System.Drawing.Size(42, 22);
            this.toolStripNuevo.Text = "Nuevo";
            this.toolStripNuevo.Click += new System.EventHandler(this.toolStripNuevo_Click);
            // 
            // toolStripEditar
            // 
            this.toolStripEditar.Name = "toolStripEditar";
            this.toolStripEditar.Size = new System.Drawing.Size(37, 22);
            this.toolStripEditar.Text = "Editar";
            this.toolStripEditar.Click += new System.EventHandler(this.toolStripEditar_Click);
            // 
            // toolStripEliminar
            // 
            this.toolStripEliminar.Name = "toolStripEliminar";
            this.toolStripEliminar.Size = new System.Drawing.Size(50, 22);
            this.toolStripEliminar.Text = "Eliminar";
            this.toolStripEliminar.Click += new System.EventHandler(this.toolStripEliminar_Click);
            // 
            // frmMantenimientoFuncion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 318);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmbPeliculaFun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPeliculaFun);
            this.Name = "frmMantenimientoFuncion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Funcion";
            this.Load += new System.EventHandler(this.frmMantenimientoFuncion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculaFun)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPeliculaFun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeliculaFun;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripNuevo;
        private System.Windows.Forms.ToolStripLabel toolStripEditar;
        private System.Windows.Forms.ToolStripLabel toolStripEliminar;
    }
}