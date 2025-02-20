namespace AppLojaInstrumentosForms
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConsultarInstrumentos = new System.Windows.Forms.Button();
            this.btCadastrarInstrumentos = new System.Windows.Forms.Button();
            this.btCadastrarLoja = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btConsultarInstrumentos
            // 
            this.btConsultarInstrumentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btConsultarInstrumentos.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultarInstrumentos.Location = new System.Drawing.Point(100, 322);
            this.btConsultarInstrumentos.Name = "btConsultarInstrumentos";
            this.btConsultarInstrumentos.Size = new System.Drawing.Size(579, 59);
            this.btConsultarInstrumentos.TabIndex = 0;
            this.btConsultarInstrumentos.Text = "CONSULTAR INSTRUMENTOS";
            this.btConsultarInstrumentos.UseVisualStyleBackColor = false;
            this.btConsultarInstrumentos.Click += new System.EventHandler(this.btConsultarInstrumentos_Click);
            // 
            // btCadastrarInstrumentos
            // 
            this.btCadastrarInstrumentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btCadastrarInstrumentos.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCadastrarInstrumentos.Location = new System.Drawing.Point(100, 199);
            this.btCadastrarInstrumentos.Name = "btCadastrarInstrumentos";
            this.btCadastrarInstrumentos.Size = new System.Drawing.Size(579, 55);
            this.btCadastrarInstrumentos.TabIndex = 1;
            this.btCadastrarInstrumentos.Text = "CADASTRAR INSTRUMENTOS";
            this.btCadastrarInstrumentos.UseVisualStyleBackColor = false;
            this.btCadastrarInstrumentos.Click += new System.EventHandler(this.btCadastrarInstrumentos_Click);
            // 
            // btCadastrarLoja
            // 
            this.btCadastrarLoja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btCadastrarLoja.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCadastrarLoja.Location = new System.Drawing.Point(100, 80);
            this.btCadastrarLoja.Name = "btCadastrarLoja";
            this.btCadastrarLoja.Size = new System.Drawing.Size(579, 53);
            this.btCadastrarLoja.TabIndex = 2;
            this.btCadastrarLoja.Text = "CADASTAR LOJA";
            this.btCadastrarLoja.UseVisualStyleBackColor = false;
            this.btCadastrarLoja.Click += new System.EventHandler(this.btCadastrarLoja_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "FILLIPE REIS TOMAZELLI";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCadastrarLoja);
            this.Controls.Add(this.btCadastrarInstrumentos);
            this.Controls.Add(this.btConsultarInstrumentos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConsultarInstrumentos;
        private System.Windows.Forms.Button btCadastrarInstrumentos;
        private System.Windows.Forms.Button btCadastrarLoja;
        private System.Windows.Forms.Label label1;
    }
}

