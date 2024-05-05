
namespace WarehouseMgmtSystem.UserControls
{
    partial class UcGoodsRecieval
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAddArticleHeader = new System.Windows.Forms.Label();
            this.txtBoxArticleName = new System.Windows.Forms.TextBox();
            this.txtBoxSKU = new System.Windows.Forms.TextBox();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            this.txtBoxStorage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddArticle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxSupplier = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblAddArticleHeader
            // 
            this.lblAddArticleHeader.AutoSize = true;
            this.lblAddArticleHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddArticleHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAddArticleHeader.Location = new System.Drawing.Point(197, 21);
            this.lblAddArticleHeader.Name = "lblAddArticleHeader";
            this.lblAddArticleHeader.Size = new System.Drawing.Size(97, 20);
            this.lblAddArticleHeader.TabIndex = 0;
            this.lblAddArticleHeader.Text = "Add Article";
            // 
            // txtBoxArticleName
            // 
            this.txtBoxArticleName.Location = new System.Drawing.Point(176, 72);
            this.txtBoxArticleName.Name = "txtBoxArticleName";
            this.txtBoxArticleName.Size = new System.Drawing.Size(133, 20);
            this.txtBoxArticleName.TabIndex = 1;
            // 
            // txtBoxSKU
            // 
            this.txtBoxSKU.Location = new System.Drawing.Point(176, 114);
            this.txtBoxSKU.Name = "txtBoxSKU";
            this.txtBoxSKU.Size = new System.Drawing.Size(133, 20);
            this.txtBoxSKU.TabIndex = 2;
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.Location = new System.Drawing.Point(176, 152);
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.Size = new System.Drawing.Size(133, 20);
            this.txtBoxQty.TabIndex = 3;
            // 
            // txtBoxStorage
            // 
            this.txtBoxStorage.Location = new System.Drawing.Point(176, 194);
            this.txtBoxStorage.Name = "txtBoxStorage";
            this.txtBoxStorage.Size = new System.Drawing.Size(133, 20);
            this.txtBoxStorage.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(173, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Article name (ex. Artikel1)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(173, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "SKU (ex. 1005)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(173, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantity (ex. 2)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(173, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Storage place (ex. 101)";
            // 
            // btnAddArticle
            // 
            this.btnAddArticle.Location = new System.Drawing.Point(201, 259);
            this.btnAddArticle.Name = "btnAddArticle";
            this.btnAddArticle.Size = new System.Drawing.Size(75, 23);
            this.btnAddArticle.TabIndex = 6;
            this.btnAddArticle.Text = "Add Article";
            this.btnAddArticle.UseVisualStyleBackColor = true;
            this.btnAddArticle.Click += new System.EventHandler(this.btnAddArticle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(173, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Supplier (ex. Sony)";
            // 
            // txtBoxSupplier
            // 
            this.txtBoxSupplier.Location = new System.Drawing.Point(176, 233);
            this.txtBoxSupplier.Name = "txtBoxSupplier";
            this.txtBoxSupplier.Size = new System.Drawing.Size(133, 20);
            this.txtBoxSupplier.TabIndex = 5;
            // 
            // UcGoodsRecieval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.txtBoxSupplier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddArticle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxStorage);
            this.Controls.Add(this.txtBoxQty);
            this.Controls.Add(this.txtBoxSKU);
            this.Controls.Add(this.txtBoxArticleName);
            this.Controls.Add(this.lblAddArticleHeader);
            this.Name = "UcGoodsRecieval";
            this.Size = new System.Drawing.Size(498, 375);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddArticleHeader;
        private System.Windows.Forms.TextBox txtBoxArticleName;
        private System.Windows.Forms.TextBox txtBoxSKU;
        private System.Windows.Forms.TextBox txtBoxQty;
        private System.Windows.Forms.TextBox txtBoxStorage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddArticle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxSupplier;
    }
}
