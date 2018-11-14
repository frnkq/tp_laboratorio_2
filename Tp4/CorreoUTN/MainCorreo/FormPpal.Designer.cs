namespace MainCorreo
{
    partial class FormPpal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstEstadoEntregado = new System.Windows.Forms.ListBox();
            this.MostrarToolstripMenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEstadoEntregado = new System.Windows.Forms.Label();
            this.lstEstadoEnViaje = new System.Windows.Forms.ListBox();
            this.lblEstadoEnViaje = new System.Windows.Forms.Label();
            this.lstEstadoIngresado = new System.Windows.Forms.ListBox();
            this.lblEstadoIngresado = new System.Windows.Forms.Label();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.mtxtTrackingId = new System.Windows.Forms.MaskedTextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.MostrarToolstripMenuItem.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstEstadoEntregado);
            this.groupBox1.Controls.Add(this.lblEstadoEntregado);
            this.groupBox1.Controls.Add(this.lstEstadoEnViaje);
            this.groupBox1.Controls.Add(this.lblEstadoEnViaje);
            this.groupBox1.Controls.Add(this.lstEstadoIngresado);
            this.groupBox1.Controls.Add(this.lblEstadoIngresado);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 282);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado Paquetes";
            // 
            // lstEstadoEntregado
            // 
            this.lstEstadoEntregado.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.lstEstadoEntregado.ContextMenuStrip = this.MostrarToolstripMenuItem;
            this.lstEstadoEntregado.FormattingEnabled = true;
            this.lstEstadoEntregado.Location = new System.Drawing.Point(550, 60);
            this.lstEstadoEntregado.Name = "lstEstadoEntregado";
            this.lstEstadoEntregado.Size = new System.Drawing.Size(253, 199);
            this.lstEstadoEntregado.TabIndex = 0;
            // 
            // MostrarToolstripMenuItem
            // 
            this.MostrarToolstripMenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem1});
            this.MostrarToolstripMenuItem.Name = "MostrarToolstripMenuItem";
            this.MostrarToolstripMenuItem.Size = new System.Drawing.Size(125, 26);
            // 
            // mostrarToolStripMenuItem1
            // 
            this.mostrarToolStripMenuItem1.Name = "mostrarToolStripMenuItem1";
            this.mostrarToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.mostrarToolStripMenuItem1.Text = "Mostrar...";
            this.mostrarToolStripMenuItem1.Click += new System.EventHandler(this.mostrarToolStripMenuItem1_Click);
            // 
            // lblEstadoEntregado
            // 
            this.lblEstadoEntregado.AutoSize = true;
            this.lblEstadoEntregado.Location = new System.Drawing.Point(547, 32);
            this.lblEstadoEntregado.Name = "lblEstadoEntregado";
            this.lblEstadoEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEstadoEntregado.TabIndex = 1;
            this.lblEstadoEntregado.Text = "Entregado";
            // 
            // lstEstadoEnViaje
            // 
            this.lstEstadoEnViaje.FormattingEnabled = true;
            this.lstEstadoEnViaje.Location = new System.Drawing.Point(286, 60);
            this.lstEstadoEnViaje.Name = "lstEstadoEnViaje";
            this.lstEstadoEnViaje.Size = new System.Drawing.Size(253, 199);
            this.lstEstadoEnViaje.TabIndex = 0;
            // 
            // lblEstadoEnViaje
            // 
            this.lblEstadoEnViaje.AutoSize = true;
            this.lblEstadoEnViaje.Location = new System.Drawing.Point(283, 32);
            this.lblEstadoEnViaje.Name = "lblEstadoEnViaje";
            this.lblEstadoEnViaje.Size = new System.Drawing.Size(46, 13);
            this.lblEstadoEnViaje.TabIndex = 1;
            this.lblEstadoEnViaje.Text = "En Viaje";
            // 
            // lstEstadoIngresado
            // 
            this.lstEstadoIngresado.FormattingEnabled = true;
            this.lstEstadoIngresado.Location = new System.Drawing.Point(15, 60);
            this.lstEstadoIngresado.Name = "lstEstadoIngresado";
            this.lstEstadoIngresado.Size = new System.Drawing.Size(253, 199);
            this.lstEstadoIngresado.TabIndex = 0;
            // 
            // lblEstadoIngresado
            // 
            this.lblEstadoIngresado.AutoSize = true;
            this.lblEstadoIngresado.Location = new System.Drawing.Point(12, 32);
            this.lblEstadoIngresado.Name = "lblEstadoIngresado";
            this.lblEstadoIngresado.Size = new System.Drawing.Size(54, 13);
            this.lblEstadoIngresado.TabIndex = 1;
            this.lblEstadoIngresado.Text = "Ingresado";
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Location = new System.Drawing.Point(4, 291);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(387, 172);
            this.rtbMostrar.TabIndex = 2;
            this.rtbMostrar.Text = "";
            // 
            // mtxtTrackingId
            // 
            this.mtxtTrackingId.Location = new System.Drawing.Point(17, 42);
            this.mtxtTrackingId.Mask = "000-000-0000";
            this.mtxtTrackingId.Name = "mtxtTrackingId";
            this.mtxtTrackingId.Size = new System.Drawing.Size(221, 20);
            this.mtxtTrackingId.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(244, 30);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(160, 42);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(244, 102);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(160, 42);
            this.btnMostrarTodos.TabIndex = 2;
            this.btnMostrarTodos.Text = "Mostrar todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.btnMostrarTodos);
            this.groupBox2.Controls.Add(this.mtxtTrackingId);
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblTrackingID);
            this.groupBox2.Location = new System.Drawing.Point(397, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 161);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paquete";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(17, 102);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(221, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dirección";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(14, 26);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(63, 13);
            this.lblTrackingID.TabIndex = 1;
            this.lblTrackingID.Text = "Tracking ID";
            // 
            // FormPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 478);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPpal";
            this.Text = "CorreoUTN Franco.Canevali.2C";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MostrarToolstripMenuItem.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstEstadoIngresado;
        private System.Windows.Forms.Label lblEstadoIngresado;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.MaskedTextBox mtxtTrackingId;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListBox lstEstadoEntregado;
        private System.Windows.Forms.Label lblEstadoEntregado;
        private System.Windows.Forms.ListBox lstEstadoEnViaje;
        private System.Windows.Forms.Label lblEstadoEnViaje;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.ContextMenuStrip MostrarToolstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem1;
    }
}

