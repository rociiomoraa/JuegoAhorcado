namespace JuegoAhorcado
{
    partial class FormHistorial
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRachaMaxima = new System.Windows.Forms.Label();
            this.lblAcierto = new System.Windows.Forms.Label();
            this.lblPerdidas = new System.Windows.Forms.Label();
            this.lblGanadas = new System.Windows.Forms.Label();
            this.lblTotalPartidas = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Palabra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("CF Crayons", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(224, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "HISTORIAL Y ESTADÍSTICAS";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRachaMaxima);
            this.panel1.Controls.Add(this.lblAcierto);
            this.panel1.Controls.Add(this.lblPerdidas);
            this.panel1.Controls.Add(this.lblGanadas);
            this.panel1.Controls.Add(this.lblTotalPartidas);
            this.panel1.Location = new System.Drawing.Point(27, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 44);
            this.panel1.TabIndex = 3;
            // 
            // lblRachaMaxima
            // 
            this.lblRachaMaxima.AutoSize = true;
            this.lblRachaMaxima.BackColor = System.Drawing.Color.Transparent;
            this.lblRachaMaxima.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRachaMaxima.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRachaMaxima.Location = new System.Drawing.Point(662, 17);
            this.lblRachaMaxima.Name = "lblRachaMaxima";
            this.lblRachaMaxima.Size = new System.Drawing.Size(102, 19);
            this.lblRachaMaxima.TabIndex = 107;
            this.lblRachaMaxima.Text = "Racha Máxima:";
            // 
            // lblAcierto
            // 
            this.lblAcierto.AutoSize = true;
            this.lblAcierto.BackColor = System.Drawing.Color.Transparent;
            this.lblAcierto.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcierto.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAcierto.Location = new System.Drawing.Point(508, 17);
            this.lblAcierto.Name = "lblAcierto";
            this.lblAcierto.Size = new System.Drawing.Size(59, 19);
            this.lblAcierto.TabIndex = 106;
            this.lblAcierto.Text = "Acierto:";
            // 
            // lblPerdidas
            // 
            this.lblPerdidas.AutoSize = true;
            this.lblPerdidas.BackColor = System.Drawing.Color.Transparent;
            this.lblPerdidas.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerdidas.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPerdidas.Location = new System.Drawing.Point(353, 17);
            this.lblPerdidas.Name = "lblPerdidas";
            this.lblPerdidas.Size = new System.Drawing.Size(66, 19);
            this.lblPerdidas.TabIndex = 105;
            this.lblPerdidas.Text = "Perdidas:";
            // 
            // lblGanadas
            // 
            this.lblGanadas.AutoSize = true;
            this.lblGanadas.BackColor = System.Drawing.Color.Transparent;
            this.lblGanadas.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanadas.ForeColor = System.Drawing.SystemColors.Control;
            this.lblGanadas.Location = new System.Drawing.Point(201, 17);
            this.lblGanadas.Name = "lblGanadas";
            this.lblGanadas.Size = new System.Drawing.Size(67, 19);
            this.lblGanadas.TabIndex = 104;
            this.lblGanadas.Text = "Ganadas:";
            // 
            // lblTotalPartidas
            // 
            this.lblTotalPartidas.AutoSize = true;
            this.lblTotalPartidas.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPartidas.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPartidas.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalPartidas.Location = new System.Drawing.Point(25, 17);
            this.lblTotalPartidas.Name = "lblTotalPartidas";
            this.lblTotalPartidas.Size = new System.Drawing.Size(108, 19);
            this.lblTotalPartidas.TabIndex = 103;
            this.lblTotalPartidas.Text = "Total Partidas:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvHistorial);
            this.panel2.Location = new System.Drawing.Point(27, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 309);
            this.panel2.TabIndex = 4;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Palabra,
            this.Categoria,
            this.Resultado,
            this.Puntos,
            this.Fecha});
            this.dgvHistorial.Location = new System.Drawing.Point(17, 16);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(796, 280);
            this.dgvHistorial.TabIndex = 7;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID Partida";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Palabra
            // 
            this.Palabra.HeaderText = "Palabra";
            this.Palabra.Name = "Palabra";
            this.Palabra.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Resultado
            // 
            this.Resultado.HeaderText = "Resultado";
            this.Resultado.Name = "Resultado";
            this.Resultado.ReadOnly = true;
            // 
            // Puntos
            // 
            this.Puntos.HeaderText = "Puntos";
            this.Puntos.Name = "Puntos";
            this.Puntos.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Transparent;
            this.btnVolver.CausesValidation = false;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnVolver.FlatAppearance.BorderSize = 3;
            this.btnVolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVolver.Location = new System.Drawing.Point(408, 469);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(105, 31);
            this.btnVolver.TabIndex = 102;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(882, 531);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.FormHistorial_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Palabra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        public System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lblRachaMaxima;
        private System.Windows.Forms.Label lblAcierto;
        private System.Windows.Forms.Label lblPerdidas;
        private System.Windows.Forms.Label lblGanadas;
        private System.Windows.Forms.Label lblTotalPartidas;
        private System.Windows.Forms.Button btnVolver;
    }
}