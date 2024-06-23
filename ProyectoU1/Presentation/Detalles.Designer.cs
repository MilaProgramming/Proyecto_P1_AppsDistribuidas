namespace GUI_V_2
{
    partial class Detalles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detalles));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreAutor = new System.Windows.Forms.TextBox();
            this.txtIdAutor = new System.Windows.Forms.TextBox();
            this.btnGuardarAutor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGuardarEditorial = new System.Windows.Forms.Button();
            this.btnGuardarCategoria = new System.Windows.Forms.Button();
            this.txtIdEditorial = new System.Windows.Forms.TextBox();
            this.txtNombreEditorial = new System.Windows.Forms.TextBox();
            this.txtIdCategoria = new System.Windows.Forms.TextBox();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.TablaProductos = new System.Windows.Forms.DataGridView();
            this.btnVerCategoria = new System.Windows.Forms.Button();
            this.btnVerAutor = new System.Windows.Forms.Button();
            this.btnVerEditorial = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TablaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(59, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 52);
            this.label7.TabIndex = 26;
            this.label7.Text = "Nombre \r\nEditorial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 26);
            this.label6.TabIndex = 25;
            this.label6.Text = "ID Editorial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 759);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 26);
            this.label5.TabIndex = 24;
            this.label5.Text = "Categoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 698);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 26);
            this.label4.TabIndex = 23;
            this.label4.Text = "ID Categoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 52);
            this.label3.TabIndex = 22;
            this.label3.Text = "Nombre\r\nAutor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "ID Autor";
            // 
            // txtNombreAutor
            // 
            this.txtNombreAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreAutor.Location = new System.Drawing.Point(196, 159);
            this.txtNombreAutor.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreAutor.Name = "txtNombreAutor";
            this.txtNombreAutor.Size = new System.Drawing.Size(259, 28);
            this.txtNombreAutor.TabIndex = 20;
            this.txtNombreAutor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreAutor_KeyPress);
            // 
            // txtIdAutor
            // 
            this.txtIdAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAutor.Location = new System.Drawing.Point(196, 96);
            this.txtIdAutor.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdAutor.Name = "txtIdAutor";
            this.txtIdAutor.Size = new System.Drawing.Size(259, 28);
            this.txtIdAutor.TabIndex = 19;
            this.txtIdAutor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdAutor_KeyPress);
            // 
            // btnGuardarAutor
            // 
            this.btnGuardarAutor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGuardarAutor.FlatAppearance.BorderSize = 0;
            this.btnGuardarAutor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnGuardarAutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarAutor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarAutor.ForeColor = System.Drawing.Color.White;
            this.btnGuardarAutor.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarAutor.Image")));
            this.btnGuardarAutor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarAutor.Location = new System.Drawing.Point(196, 224);
            this.btnGuardarAutor.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarAutor.Name = "btnGuardarAutor";
            this.btnGuardarAutor.Size = new System.Drawing.Size(240, 43);
            this.btnGuardarAutor.TabIndex = 18;
            this.btnGuardarAutor.Text = "GUARDAR";
            this.btnGuardarAutor.UseVisualStyleBackColor = false;
            this.btnGuardarAutor.Click += new System.EventHandler(this.btnGuardarAutor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 43);
            this.label1.TabIndex = 31;
            this.label1.Text = "AUTOR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(210, 323);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 43);
            this.label8.TabIndex = 32;
            this.label8.Text = "EDITORIAL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(201, 619);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 43);
            this.label9.TabIndex = 33;
            this.label9.Text = "CATEGORIA";
            // 
            // btnGuardarEditorial
            // 
            this.btnGuardarEditorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGuardarEditorial.FlatAppearance.BorderSize = 0;
            this.btnGuardarEditorial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnGuardarEditorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEditorial.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarEditorial.ForeColor = System.Drawing.Color.White;
            this.btnGuardarEditorial.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarEditorial.Image")));
            this.btnGuardarEditorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarEditorial.Location = new System.Drawing.Point(196, 522);
            this.btnGuardarEditorial.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarEditorial.Name = "btnGuardarEditorial";
            this.btnGuardarEditorial.Size = new System.Drawing.Size(240, 43);
            this.btnGuardarEditorial.TabIndex = 34;
            this.btnGuardarEditorial.Text = "GUARDAR";
            this.btnGuardarEditorial.UseVisualStyleBackColor = false;
            // 
            // btnGuardarCategoria
            // 
            this.btnGuardarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGuardarCategoria.FlatAppearance.BorderSize = 0;
            this.btnGuardarCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnGuardarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCategoria.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCategoria.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarCategoria.Image")));
            this.btnGuardarCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCategoria.Location = new System.Drawing.Point(196, 840);
            this.btnGuardarCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarCategoria.Name = "btnGuardarCategoria";
            this.btnGuardarCategoria.Size = new System.Drawing.Size(240, 43);
            this.btnGuardarCategoria.TabIndex = 35;
            this.btnGuardarCategoria.Text = "GUARDAR";
            this.btnGuardarCategoria.UseVisualStyleBackColor = false;
            // 
            // txtIdEditorial
            // 
            this.txtIdEditorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdEditorial.Location = new System.Drawing.Point(196, 399);
            this.txtIdEditorial.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdEditorial.Name = "txtIdEditorial";
            this.txtIdEditorial.Size = new System.Drawing.Size(259, 28);
            this.txtIdEditorial.TabIndex = 36;
            // 
            // txtNombreEditorial
            // 
            this.txtNombreEditorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreEditorial.Location = new System.Drawing.Point(196, 461);
            this.txtNombreEditorial.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreEditorial.Name = "txtNombreEditorial";
            this.txtNombreEditorial.Size = new System.Drawing.Size(259, 28);
            this.txtNombreEditorial.TabIndex = 37;
            // 
            // txtIdCategoria
            // 
            this.txtIdCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCategoria.Location = new System.Drawing.Point(196, 696);
            this.txtIdCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdCategoria.Name = "txtIdCategoria";
            this.txtIdCategoria.Size = new System.Drawing.Size(259, 28);
            this.txtIdCategoria.TabIndex = 38;
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCategoria.Location = new System.Drawing.Point(196, 760);
            this.txtNombreCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(259, 28);
            this.txtNombreCategoria.TabIndex = 39;
            // 
            // TablaProductos
            // 
            this.TablaProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TablaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TablaProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TablaProductos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.TablaProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TablaProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.TablaProductos.ColumnHeadersHeight = 30;
            this.TablaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaProductos.DefaultCellStyle = dataGridViewCellStyle6;
            this.TablaProductos.EnableHeadersVisualStyles = false;
            this.TablaProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TablaProductos.Location = new System.Drawing.Point(541, 159);
            this.TablaProductos.Margin = new System.Windows.Forms.Padding(4);
            this.TablaProductos.Name = "TablaProductos";
            this.TablaProductos.RowHeadersVisible = false;
            this.TablaProductos.RowHeadersWidth = 51;
            this.TablaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaProductos.Size = new System.Drawing.Size(834, 712);
            this.TablaProductos.TabIndex = 40;
            // 
            // btnVerCategoria
            // 
            this.btnVerCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVerCategoria.FlatAppearance.BorderSize = 0;
            this.btnVerCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnVerCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerCategoria.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCategoria.ForeColor = System.Drawing.Color.White;
            this.btnVerCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btnVerCategoria.Image")));
            this.btnVerCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerCategoria.Location = new System.Drawing.Point(541, 81);
            this.btnVerCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerCategoria.Name = "btnVerCategoria";
            this.btnVerCategoria.Size = new System.Drawing.Size(268, 43);
            this.btnVerCategoria.TabIndex = 41;
            this.btnVerCategoria.Text = "CATEGORIAS";
            this.btnVerCategoria.UseVisualStyleBackColor = false;
            // 
            // btnVerAutor
            // 
            this.btnVerAutor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVerAutor.FlatAppearance.BorderSize = 0;
            this.btnVerAutor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnVerAutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerAutor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerAutor.ForeColor = System.Drawing.Color.White;
            this.btnVerAutor.Image = ((System.Drawing.Image)(resources.GetObject("btnVerAutor.Image")));
            this.btnVerAutor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerAutor.Location = new System.Drawing.Point(855, 81);
            this.btnVerAutor.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerAutor.Name = "btnVerAutor";
            this.btnVerAutor.Size = new System.Drawing.Size(240, 43);
            this.btnVerAutor.TabIndex = 42;
            this.btnVerAutor.Text = "AUTORES";
            this.btnVerAutor.UseVisualStyleBackColor = false;
            // 
            // btnVerEditorial
            // 
            this.btnVerEditorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVerEditorial.FlatAppearance.BorderSize = 0;
            this.btnVerEditorial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnVerEditorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerEditorial.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerEditorial.ForeColor = System.Drawing.Color.White;
            this.btnVerEditorial.Image = ((System.Drawing.Image)(resources.GetObject("btnVerEditorial.Image")));
            this.btnVerEditorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerEditorial.Location = new System.Drawing.Point(1135, 81);
            this.btnVerEditorial.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerEditorial.Name = "btnVerEditorial";
            this.btnVerEditorial.Size = new System.Drawing.Size(240, 43);
            this.btnVerEditorial.TabIndex = 43;
            this.btnVerEditorial.Text = "EDITORIALES";
            this.btnVerEditorial.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(883, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 43);
            this.label10.TabIndex = 44;
            this.label10.Text = "VER";
            // 
            // Detalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 926);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnVerEditorial);
            this.Controls.Add(this.btnVerAutor);
            this.Controls.Add(this.btnVerCategoria);
            this.Controls.Add(this.TablaProductos);
            this.Controls.Add(this.txtNombreCategoria);
            this.Controls.Add(this.txtIdCategoria);
            this.Controls.Add(this.txtNombreEditorial);
            this.Controls.Add(this.txtIdEditorial);
            this.Controls.Add(this.btnGuardarCategoria);
            this.Controls.Add(this.btnGuardarEditorial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreAutor);
            this.Controls.Add(this.txtIdAutor);
            this.Controls.Add(this.btnGuardarAutor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Detalles";
            this.Text = "Detalles";
            ((System.ComponentModel.ISupportInitialize)(this.TablaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreAutor;
        private System.Windows.Forms.TextBox txtIdAutor;
        private System.Windows.Forms.Button btnGuardarAutor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGuardarEditorial;
        private System.Windows.Forms.Button btnGuardarCategoria;
        private System.Windows.Forms.TextBox txtIdEditorial;
        private System.Windows.Forms.TextBox txtNombreEditorial;
        private System.Windows.Forms.TextBox txtIdCategoria;
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.DataGridView TablaProductos;
        private System.Windows.Forms.Button btnVerCategoria;
        private System.Windows.Forms.Button btnVerAutor;
        private System.Windows.Forms.Button btnVerEditorial;
        private System.Windows.Forms.Label label10;
    }
}