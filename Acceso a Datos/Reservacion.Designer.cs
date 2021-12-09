
namespace Acceso_a_Datos
{
    partial class Reservacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservacion));
            this.cb_pelicula = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_ReservarAsiento = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_ConfirmaReservacion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_pelicula
            // 
            this.cb_pelicula.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_pelicula.FormattingEnabled = true;
            this.cb_pelicula.Location = new System.Drawing.Point(545, 38);
            this.cb_pelicula.Name = "cb_pelicula";
            this.cb_pelicula.Size = new System.Drawing.Size(212, 29);
            this.cb_pelicula.TabIndex = 0;
            this.cb_pelicula.Text = "Seleccionar Pelicula...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(350, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reservación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(445, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pelicula: ";
            // 
            // Btn_ReservarAsiento
            // 
            this.Btn_ReservarAsiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(187)))));
            this.Btn_ReservarAsiento.FlatAppearance.BorderSize = 0;
            this.Btn_ReservarAsiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(187)))));
            this.Btn_ReservarAsiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(161)))), ((int)(((byte)(230)))));
            this.Btn_ReservarAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ReservarAsiento.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ReservarAsiento.ForeColor = System.Drawing.Color.LightGray;
            this.Btn_ReservarAsiento.Location = new System.Drawing.Point(545, 101);
            this.Btn_ReservarAsiento.Name = "Btn_ReservarAsiento";
            this.Btn_ReservarAsiento.Size = new System.Drawing.Size(212, 34);
            this.Btn_ReservarAsiento.TabIndex = 30;
            this.Btn_ReservarAsiento.Text = "Reservar Asiento...";
            this.Btn_ReservarAsiento.UseVisualStyleBackColor = false;
            this.Btn_ReservarAsiento.Click += new System.EventHandler(this.Btn_ReservarAsiento_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(128, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // btn_ConfirmaReservacion
            // 
            this.btn_ConfirmaReservacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(187)))));
            this.btn_ConfirmaReservacion.FlatAppearance.BorderSize = 0;
            this.btn_ConfirmaReservacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(187)))));
            this.btn_ConfirmaReservacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(161)))), ((int)(((byte)(230)))));
            this.btn_ConfirmaReservacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ConfirmaReservacion.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConfirmaReservacion.ForeColor = System.Drawing.Color.LightGray;
            this.btn_ConfirmaReservacion.Location = new System.Drawing.Point(273, 431);
            this.btn_ConfirmaReservacion.Name = "btn_ConfirmaReservacion";
            this.btn_ConfirmaReservacion.Size = new System.Drawing.Size(329, 34);
            this.btn_ConfirmaReservacion.TabIndex = 32;
            this.btn_ConfirmaReservacion.Text = "Confirmación de Reservación";
            this.btn_ConfirmaReservacion.UseVisualStyleBackColor = false;
            this.btn_ConfirmaReservacion.Click += new System.EventHandler(this.btn_ConfirmaReservacion_Click);
            // 
            // panel1
            // 
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(85, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 223);
            this.panel1.TabIndex = 33;
            // 
            // Reservacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_ConfirmaReservacion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Btn_ReservarAsiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_pelicula);
            this.Name = "Reservacion";
            this.Text = "Reservacion";
            this.Load += new System.EventHandler(this.Reservacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_pelicula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_ReservarAsiento;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_ConfirmaReservacion;
        private System.Windows.Forms.Panel panel1;
    }
}