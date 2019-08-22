namespace ProyectoFinalUdemyLinq
{
    partial class frmMantenimientoCine
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripNuevo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripEditar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripCancelar = new System.Windows.Forms.ToolStripLabel();
            this.dgvCine = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreCine = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCine)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNuevo,
            this.toolStripEditar,
            this.toolStripCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(687, 25);
            this.toolStrip1.TabIndex = 0;
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
            // toolStripCancelar
            // 
            this.toolStripCancelar.Name = "toolStripCancelar";
            this.toolStripCancelar.Size = new System.Drawing.Size(53, 22);
            this.toolStripCancelar.Text = "Cancelar";
            // 
            // dgvCine
            // 
            this.dgvCine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCine.Location = new System.Drawing.Point(12, 78);
            this.dgvCine.Name = "dgvCine";
            this.dgvCine.ReadOnly = true;
            this.dgvCine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCine.Size = new System.Drawing.Size(658, 335);
            this.dgvCine.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // txtNombreCine
            // 
            this.txtNombreCine.Location = new System.Drawing.Point(313, 38);
            this.txtNombreCine.Name = "txtNombreCine";
            this.txtNombreCine.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCine.TabIndex = 3;
            this.txtNombreCine.TextChanged += new System.EventHandler(this.Filtrar);
            // 
            // frmMantenimientoCine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 435);
            this.Controls.Add(this.txtNombreCine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCine);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoCine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Cine";
            this.Load += new System.EventHandler(this.frmMantenimientoCine_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripNuevo;
        private System.Windows.Forms.ToolStripLabel toolStripEditar;
        private System.Windows.Forms.ToolStripLabel toolStripCancelar;
        private System.Windows.Forms.DataGridView dgvCine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreCine;
    }
}