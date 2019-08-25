namespace ProyectoFinalUdemyLinq
{
    partial class frmMantenimientoPelicula
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
            this.dgvPelicula = new System.Windows.Forms.DataGridView();
            this.lblNombrePelicula = new System.Windows.Forms.Label();
            this.txtNombrePelicula = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelicula)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPelicula
            // 
            this.dgvPelicula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPelicula.Location = new System.Drawing.Point(12, 112);
            this.dgvPelicula.Name = "dgvPelicula";
            this.dgvPelicula.Size = new System.Drawing.Size(776, 326);
            this.dgvPelicula.TabIndex = 0;
            // 
            // lblNombrePelicula
            // 
            this.lblNombrePelicula.AutoSize = true;
            this.lblNombrePelicula.Location = new System.Drawing.Point(107, 64);
            this.lblNombrePelicula.Name = "lblNombrePelicula";
            this.lblNombrePelicula.Size = new System.Drawing.Size(84, 13);
            this.lblNombrePelicula.TabIndex = 1;
            this.lblNombrePelicula.Text = "Nombre Pelicula";
            // 
            // txtNombrePelicula
            // 
            this.txtNombrePelicula.Location = new System.Drawing.Point(260, 61);
            this.txtNombrePelicula.Name = "txtNombrePelicula";
            this.txtNombrePelicula.Size = new System.Drawing.Size(285, 20);
            this.txtNombrePelicula.TabIndex = 2;
            // 
            // frmMantenimientoPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNombrePelicula);
            this.Controls.Add(this.lblNombrePelicula);
            this.Controls.Add(this.dgvPelicula);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMantenimientoPelicula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Pelicula";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelicula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPelicula;
        private System.Windows.Forms.Label lblNombrePelicula;
        private System.Windows.Forms.TextBox txtNombrePelicula;
    }
}