namespace SB_tllagile
{
    partial class EquipaDeProjeto
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
            this.labelPerfilProjeto = new System.Windows.Forms.Label();
            this.rectangleShape17 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewEquipa = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPerfilProjeto
            // 
            this.labelPerfilProjeto.AutoSize = true;
            this.labelPerfilProjeto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(222)))));
            this.labelPerfilProjeto.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPerfilProjeto.ForeColor = System.Drawing.Color.White;
            this.labelPerfilProjeto.Location = new System.Drawing.Point(280, 39);
            this.labelPerfilProjeto.Name = "labelPerfilProjeto";
            this.labelPerfilProjeto.Size = new System.Drawing.Size(418, 45);
            this.labelPerfilProjeto.TabIndex = 22;
            this.labelPerfilProjeto.Text = "Equipa do Projeto: ";
            // 
            // rectangleShape17
            // 
            this.rectangleShape17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(222)))));
            this.rectangleShape17.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape17.BorderColor = System.Drawing.Color.White;
            this.rectangleShape17.FillGradientColor = System.Drawing.Color.Transparent;
            this.rectangleShape17.Location = new System.Drawing.Point(-160, 0);
            this.rectangleShape17.Name = "rectangleShape17";
            this.rectangleShape17.Size = new System.Drawing.Size(1237, 135);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape17});
            this.shapeContainer1.Size = new System.Drawing.Size(1078, 518);
            this.shapeContainer1.TabIndex = 24;
            this.shapeContainer1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.listViewEquipa);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1054, 362);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Equipa";
            // 
            // listViewEquipa
            // 
            this.listViewEquipa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.listViewEquipa.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewEquipa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listViewEquipa.FullRowSelect = true;
            this.listViewEquipa.GridLines = true;
            this.listViewEquipa.Location = new System.Drawing.Point(19, 34);
            this.listViewEquipa.Name = "listViewEquipa";
            this.listViewEquipa.Size = new System.Drawing.Size(1029, 309);
            this.listViewEquipa.TabIndex = 12;
            this.listViewEquipa.UseCompatibleStateImageBehavior = false;
            this.listViewEquipa.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Identificador";
            this.columnHeader1.Width = 117;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 309;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Email";
            this.columnHeader4.Width = 438;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Função";
            this.columnHeader3.Width = 157;
            // 
            // ProjetoDeEquipa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1078, 518);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelPerfilProjeto);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "ProjetoDeEquipa";
            this.Text = "EquipaDeProjeto";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPerfilProjeto;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape17;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewEquipa;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}