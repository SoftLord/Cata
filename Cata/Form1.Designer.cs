
namespace Cata
{
    partial class Cata
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cata));
            this.reproductor = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnReproducir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reproductor)).BeginInit();
            this.SuspendLayout();
            // 
            // reproductor
            // 
            resources.ApplyResources(this.reproductor, "reproductor");
            this.reproductor.Name = "reproductor";
            this.reproductor.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("reproductor.OcxState")));
            // 
            // btnReproducir
            // 
            resources.ApplyResources(this.btnReproducir, "btnReproducir");
            this.btnReproducir.Image = global::Cata.Properties.Resources.mic_alargado;
            this.btnReproducir.Name = "btnReproducir";
            this.btnReproducir.UseVisualStyleBackColor = false;
            this.btnReproducir.Click += new System.EventHandler(this.btnReproducir_Click);
            // 
            // Cata
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.btnReproducir);
            this.Controls.Add(this.reproductor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Cata";
            this.Load += new System.EventHandler(this.Cata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reproductor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer reproductor;
        private System.Windows.Forms.Button btnReproducir;
    }
}

