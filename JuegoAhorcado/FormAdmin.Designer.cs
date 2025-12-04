namespace JuegoAhorcado
{
    partial class FormAdmin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCategorias = new System.Windows.Forms.TextBox();
            this.btnEliminarCat = new System.Windows.Forms.Button();
            this.btnModificarCat = new System.Windows.Forms.Button();
            this.btnAnadirCat = new System.Windows.Forms.Button();
            this.lblCategorias = new System.Windows.Forms.Label();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoría = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbElegirCategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPalabra = new System.Windows.Forms.TextBox();
            this.btnEliminarPalabra = new System.Windows.Forms.Button();
            this.btnModificarPalabra = new System.Windows.Forms.Button();
            this.btnAnadirPalabra = new System.Windows.Forms.Button();
            this.lblPalabras = new System.Windows.Forms.Label();
            this.dgvPalabras = new System.Windows.Forms.DataGridView();
            this.ID_Palabra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Palabra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("CF Crayons", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(230, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "PANEL DE ADMINISTRACIÓN.";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(21, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(836, 394);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage1.Controls.Add(this.txtCategorias);
            this.tabPage1.Controls.Add(this.btnEliminarCat);
            this.tabPage1.Controls.Add(this.btnModificarCat);
            this.tabPage1.Controls.Add(this.btnAnadirCat);
            this.tabPage1.Controls.Add(this.lblCategorias);
            this.tabPage1.Controls.Add(this.dgvCategorias);
            this.tabPage1.ForeColor = System.Drawing.Color.Transparent;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(828, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Categorías.";
            // 
            // txtCategorias
            // 
            this.txtCategorias.Location = new System.Drawing.Point(185, 21);
            this.txtCategorias.Name = "txtCategorias";
            this.txtCategorias.Size = new System.Drawing.Size(221, 20);
            this.txtCategorias.TabIndex = 109;
            // 
            // btnEliminarCat
            // 
            this.btnEliminarCat.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarCat.CausesValidation = false;
            this.btnEliminarCat.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnEliminarCat.FlatAppearance.BorderSize = 3;
            this.btnEliminarCat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEliminarCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEliminarCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCat.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarCat.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminarCat.Location = new System.Drawing.Point(570, 327);
            this.btnEliminarCat.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarCat.Name = "btnEliminarCat";
            this.btnEliminarCat.Size = new System.Drawing.Size(105, 31);
            this.btnEliminarCat.TabIndex = 108;
            this.btnEliminarCat.Text = "Eliminar";
            this.btnEliminarCat.UseVisualStyleBackColor = false;
            this.btnEliminarCat.Click += new System.EventHandler(this.btnEliminarCat_Click);
            // 
            // btnModificarCat
            // 
            this.btnModificarCat.BackColor = System.Drawing.Color.Transparent;
            this.btnModificarCat.CausesValidation = false;
            this.btnModificarCat.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnModificarCat.FlatAppearance.BorderSize = 3;
            this.btnModificarCat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnModificarCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnModificarCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarCat.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarCat.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModificarCat.Location = new System.Drawing.Point(363, 327);
            this.btnModificarCat.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarCat.Name = "btnModificarCat";
            this.btnModificarCat.Size = new System.Drawing.Size(105, 31);
            this.btnModificarCat.TabIndex = 107;
            this.btnModificarCat.Text = "Modificar";
            this.btnModificarCat.UseVisualStyleBackColor = false;
            this.btnModificarCat.Click += new System.EventHandler(this.btnModificarCat_Click);
            // 
            // btnAnadirCat
            // 
            this.btnAnadirCat.BackColor = System.Drawing.Color.Transparent;
            this.btnAnadirCat.CausesValidation = false;
            this.btnAnadirCat.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnAnadirCat.FlatAppearance.BorderSize = 3;
            this.btnAnadirCat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAnadirCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAnadirCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnadirCat.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnadirCat.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAnadirCat.Location = new System.Drawing.Point(158, 327);
            this.btnAnadirCat.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnadirCat.Name = "btnAnadirCat";
            this.btnAnadirCat.Size = new System.Drawing.Size(105, 31);
            this.btnAnadirCat.TabIndex = 106;
            this.btnAnadirCat.Text = "Añadir";
            this.btnAnadirCat.UseVisualStyleBackColor = false;
            this.btnAnadirCat.Click += new System.EventHandler(this.btnAnadirCat_Click);
            // 
            // lblCategorias
            // 
            this.lblCategorias.AutoSize = true;
            this.lblCategorias.BackColor = System.Drawing.Color.Transparent;
            this.lblCategorias.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategorias.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCategorias.Location = new System.Drawing.Point(12, 22);
            this.lblCategorias.Name = "lblCategorias";
            this.lblCategorias.Size = new System.Drawing.Size(167, 19);
            this.lblCategorias.TabIndex = 104;
            this.lblCategorias.Text = "Nombre de la categoría:";
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.AllowUserToDeleteRows = false;
            this.dgvCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Categoría});
            this.dgvCategorias.Location = new System.Drawing.Point(16, 56);
            this.dgvCategorias.MultiSelect = false;
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorias.Size = new System.Drawing.Size(795, 254);
            this.dgvCategorias.TabIndex = 0;
            this.dgvCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellClick_1);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Categoría
            // 
            this.Categoría.HeaderText = "Categoría";
            this.Categoría.Name = "Categoría";
            this.Categoría.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage2.Controls.Add(this.cbElegirCategoria);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtPalabra);
            this.tabPage2.Controls.Add(this.btnEliminarPalabra);
            this.tabPage2.Controls.Add(this.btnModificarPalabra);
            this.tabPage2.Controls.Add(this.btnAnadirPalabra);
            this.tabPage2.Controls.Add(this.lblPalabras);
            this.tabPage2.Controls.Add(this.dgvPalabras);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(828, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Palabras";
            // 
            // cbElegirCategoria
            // 
            this.cbElegirCategoria.FormattingEnabled = true;
            this.cbElegirCategoria.Location = new System.Drawing.Point(161, 16);
            this.cbElegirCategoria.Name = "cbElegirCategoria";
            this.cbElegirCategoria.Size = new System.Drawing.Size(221, 21);
            this.cbElegirCategoria.TabIndex = 118;
            this.cbElegirCategoria.SelectedIndexChanged += new System.EventHandler(this.cbElegirCategoria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 19);
            this.label2.TabIndex = 116;
            this.label2.Text = "Elige una categoría:";
            // 
            // txtPalabra
            // 
            this.txtPalabra.Location = new System.Drawing.Point(593, 15);
            this.txtPalabra.Name = "txtPalabra";
            this.txtPalabra.Size = new System.Drawing.Size(221, 20);
            this.txtPalabra.TabIndex = 115;
            this.txtPalabra.TextChanged += new System.EventHandler(this.txtPalabra_TextChanged);
            // 
            // btnEliminarPalabra
            // 
            this.btnEliminarPalabra.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarPalabra.CausesValidation = false;
            this.btnEliminarPalabra.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnEliminarPalabra.FlatAppearance.BorderSize = 3;
            this.btnEliminarPalabra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEliminarPalabra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEliminarPalabra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPalabra.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPalabra.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminarPalabra.Location = new System.Drawing.Point(573, 322);
            this.btnEliminarPalabra.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarPalabra.Name = "btnEliminarPalabra";
            this.btnEliminarPalabra.Size = new System.Drawing.Size(105, 31);
            this.btnEliminarPalabra.TabIndex = 114;
            this.btnEliminarPalabra.Text = "Eliminar";
            this.btnEliminarPalabra.UseVisualStyleBackColor = false;
            this.btnEliminarPalabra.Click += new System.EventHandler(this.btnEliminarPalabra_Click);
            // 
            // btnModificarPalabra
            // 
            this.btnModificarPalabra.BackColor = System.Drawing.Color.Transparent;
            this.btnModificarPalabra.CausesValidation = false;
            this.btnModificarPalabra.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnModificarPalabra.FlatAppearance.BorderSize = 3;
            this.btnModificarPalabra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnModificarPalabra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnModificarPalabra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPalabra.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarPalabra.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModificarPalabra.Location = new System.Drawing.Point(366, 322);
            this.btnModificarPalabra.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificarPalabra.Name = "btnModificarPalabra";
            this.btnModificarPalabra.Size = new System.Drawing.Size(105, 31);
            this.btnModificarPalabra.TabIndex = 113;
            this.btnModificarPalabra.Text = "Modificar";
            this.btnModificarPalabra.UseVisualStyleBackColor = false;
            this.btnModificarPalabra.Click += new System.EventHandler(this.btnModificarPalabra_Click);
            // 
            // btnAnadirPalabra
            // 
            this.btnAnadirPalabra.BackColor = System.Drawing.Color.Transparent;
            this.btnAnadirPalabra.CausesValidation = false;
            this.btnAnadirPalabra.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnAnadirPalabra.FlatAppearance.BorderSize = 3;
            this.btnAnadirPalabra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAnadirPalabra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAnadirPalabra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnadirPalabra.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnadirPalabra.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAnadirPalabra.Location = new System.Drawing.Point(161, 322);
            this.btnAnadirPalabra.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnadirPalabra.Name = "btnAnadirPalabra";
            this.btnAnadirPalabra.Size = new System.Drawing.Size(105, 31);
            this.btnAnadirPalabra.TabIndex = 112;
            this.btnAnadirPalabra.Text = "Añadir";
            this.btnAnadirPalabra.UseVisualStyleBackColor = false;
            this.btnAnadirPalabra.Click += new System.EventHandler(this.btnAnadirPalabra_Click);
            // 
            // lblPalabras
            // 
            this.lblPalabras.AutoSize = true;
            this.lblPalabras.BackColor = System.Drawing.Color.Transparent;
            this.lblPalabras.Font = new System.Drawing.Font("CF Crayons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalabras.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPalabras.Location = new System.Drawing.Point(443, 16);
            this.lblPalabras.Name = "lblPalabras";
            this.lblPalabras.Size = new System.Drawing.Size(144, 19);
            this.lblPalabras.TabIndex = 111;
            this.lblPalabras.Text = "Escribe una palabra:";
            // 
            // dgvPalabras
            // 
            this.dgvPalabras.AllowUserToAddRows = false;
            this.dgvPalabras.AllowUserToDeleteRows = false;
            this.dgvPalabras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPalabras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPalabras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Palabra,
            this.Palabra,
            this.ID_Categoria});
            this.dgvPalabras.Location = new System.Drawing.Point(19, 51);
            this.dgvPalabras.MultiSelect = false;
            this.dgvPalabras.Name = "dgvPalabras";
            this.dgvPalabras.ReadOnly = true;
            this.dgvPalabras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPalabras.Size = new System.Drawing.Size(795, 254);
            this.dgvPalabras.TabIndex = 110;
            this.dgvPalabras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPalabras_CellClick_1);
            // 
            // ID_Palabra
            // 
            this.ID_Palabra.HeaderText = "ID";
            this.ID_Palabra.Name = "ID_Palabra";
            this.ID_Palabra.ReadOnly = true;
            // 
            // Palabra
            // 
            this.Palabra.HeaderText = "Palabra";
            this.Palabra.Name = "Palabra";
            this.Palabra.ReadOnly = true;
            // 
            // ID_Categoria
            // 
            this.ID_Categoria.HeaderText = "Categoría";
            this.ID_Categoria.Name = "ID_Categoria";
            this.ID_Categoria.ReadOnly = true;
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
            this.btnVolver.Location = new System.Drawing.Point(391, 481);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(105, 28);
            this.btnVolver.TabIndex = 116;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(882, 531);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPalabras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.Button btnEliminarCat;
        private System.Windows.Forms.Button btnModificarCat;
        private System.Windows.Forms.Button btnAnadirCat;
        private System.Windows.Forms.TextBox txtCategorias;
        private System.Windows.Forms.Label lblCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoría;
        private System.Windows.Forms.TextBox txtPalabra;
        private System.Windows.Forms.Button btnEliminarPalabra;
        private System.Windows.Forms.Button btnModificarPalabra;
        private System.Windows.Forms.Button btnAnadirPalabra;
        private System.Windows.Forms.Label lblPalabras;
        private System.Windows.Forms.DataGridView dgvPalabras;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Palabra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Palabra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Categoria;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cbElegirCategoria;
        private System.Windows.Forms.Label label2;
    }
}