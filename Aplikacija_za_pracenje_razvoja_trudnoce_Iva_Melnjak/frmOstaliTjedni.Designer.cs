
namespace Aplikacija_za_pracenje_razvoja_trudnoce_Iva_Melnjak
{
    partial class frmOstaliTjedni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOstaliTjedni));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbTjedni = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rtbVelicinaT = new System.Windows.Forms.RichTextBox();
            this.rtbBebaT = new System.Windows.Forms.RichTextBox();
            this.rtbMajkaT = new System.Windows.Forms.RichTextBox();
            this.btnZatvori = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(206)))), ((int)(((byte)(245)))));
            this.panel2.Controls.Add(this.cmbTjedni);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(880, 54);
            this.panel2.TabIndex = 2;
            // 
            // cmbTjedni
            // 
            this.cmbTjedni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTjedni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbTjedni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbTjedni.FormattingEnabled = true;
            this.cmbTjedni.Location = new System.Drawing.Point(348, 12);
            this.cmbTjedni.Name = "cmbTjedni";
            this.cmbTjedni.Size = new System.Drawing.Size(180, 30);
            this.cmbTjedni.TabIndex = 3;
            this.cmbTjedni.SelectionChangeCommitted += new System.EventHandler(this.cmbTjedni_SelectionChangeCommitted);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(142, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(169, 155);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Location = new System.Drawing.Point(557, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(169, 155);
            this.panel4.TabIndex = 9;
            // 
            // rtbVelicinaT
            // 
            this.rtbVelicinaT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.rtbVelicinaT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbVelicinaT.Enabled = false;
            this.rtbVelicinaT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbVelicinaT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbVelicinaT.Location = new System.Drawing.Point(42, 285);
            this.rtbVelicinaT.Name = "rtbVelicinaT";
            this.rtbVelicinaT.Size = new System.Drawing.Size(380, 73);
            this.rtbVelicinaT.TabIndex = 10;
            this.rtbVelicinaT.Text = "";
            // 
            // rtbBebaT
            // 
            this.rtbBebaT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.rtbBebaT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbBebaT.Enabled = false;
            this.rtbBebaT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbBebaT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbBebaT.Location = new System.Drawing.Point(42, 373);
            this.rtbBebaT.Name = "rtbBebaT";
            this.rtbBebaT.Size = new System.Drawing.Size(380, 115);
            this.rtbBebaT.TabIndex = 11;
            this.rtbBebaT.Text = "";
            // 
            // rtbMajkaT
            // 
            this.rtbMajkaT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.rtbMajkaT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMajkaT.Enabled = false;
            this.rtbMajkaT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbMajkaT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbMajkaT.Location = new System.Drawing.Point(457, 285);
            this.rtbMajkaT.Name = "rtbMajkaT";
            this.rtbMajkaT.Size = new System.Drawing.Size(380, 166);
            this.rtbMajkaT.TabIndex = 12;
            this.rtbMajkaT.Text = "";
            // 
            // btnZatvori
            // 
            this.btnZatvori.BackColor = System.Drawing.Color.White;
            this.btnZatvori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZatvori.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnZatvori.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(206)))), ((int)(((byte)(245)))));
            this.btnZatvori.Location = new System.Drawing.Point(687, 516);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(150, 48);
            this.btnZatvori.TabIndex = 13;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseVisualStyleBackColor = false;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // frmOstaliTjedni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 588);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.rtbMajkaT);
            this.Controls.Add(this.rtbBebaT);
            this.Controls.Add(this.rtbVelicinaT);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOstaliTjedni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOstaliTjedni";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbTjedni;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox rtbVelicinaT;
        private System.Windows.Forms.RichTextBox rtbBebaT;
        private System.Windows.Forms.RichTextBox rtbMajkaT;
        private System.Windows.Forms.Button btnZatvori;
    }
}