
namespace Cata
{
    partial class instalacionPythonYdependencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(instalacionPythonYdependencias));
            this.etiquetaLibrerias = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // etiquetaLibrerias
            // 
            this.etiquetaLibrerias.AutoSize = true;
            this.etiquetaLibrerias.Location = new System.Drawing.Point(12, 9);
            this.etiquetaLibrerias.Name = "etiquetaLibrerias";
            this.etiquetaLibrerias.Size = new System.Drawing.Size(0, 13);
            this.etiquetaLibrerias.TabIndex = 0;
            // 
            // instalacionPythonYdependencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.etiquetaLibrerias);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "instalacionPythonYdependencias";
            this.Text = "instalacionPythonYdependencias";
            this.Load += new System.EventHandler(this.instalacionPythonYdependencias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label etiquetaLibrerias;
    }
}