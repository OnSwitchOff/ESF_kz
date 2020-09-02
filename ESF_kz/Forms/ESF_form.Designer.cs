﻿using ESF_kz.Forms;
using System.Windows.Forms;

namespace ESF_kz
{
	partial class ESF_form
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

			this.PanelESFpartA = new panelESFpartA();
			this.PanelESFpartB = new panelESFpartB();

			this.PanelESFpartA.Dock = DockStyle.Fill;
			this.PanelESFpartB.Dock = DockStyle.Fill;

			//this.PanelESFpartA.Visible = false;
			//this.PanelESFpartB.Visible = false;

			

			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnESFpartL = new System.Windows.Forms.Button();
			this.btnESFpartK = new System.Windows.Forms.Button();
			this.btnESFpartJ = new System.Windows.Forms.Button();
			this.btnESFpartI = new System.Windows.Forms.Button();
			this.btnESFpartH = new System.Windows.Forms.Button();
			this.btnESFpartG = new System.Windows.Forms.Button();
			this.btnESFpartF = new System.Windows.Forms.Button();
			this.btnESFpartE = new System.Windows.Forms.Button();
			this.btnESFpartD = new System.Windows.Forms.Button();
			this.btnESFpartC = new System.Windows.Forms.Button();
			this.btnESFpartA = new System.Windows.Forms.Button();
			this.btnESFpartB = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();


			splitContainer1.Panel2.Controls.Add(PanelESFpartA);
			splitContainer1.Panel2.Controls.Add(PanelESFpartB);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.902598F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0974F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1073, 648);
			this.tableLayoutPanel1.TabIndex = 4;
			this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 67);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Size = new System.Drawing.Size(1067, 578);
			this.splitContainer1.SplitterDistance = 256;
			this.splitContainer1.TabIndex = 5;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1067, 58);
			this.panel1.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1067, 58);
			this.label1.TabIndex = 0;
			this.label1.Text = "ЭЛЕКТРОННЫЙ СЧЕТ ФАКТУРА";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartL, 0, 11);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartK, 0, 10);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartJ, 0, 9);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartI, 0, 8);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartH, 0, 7);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartG, 0, 6);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartF, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartE, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartD, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartC, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartA, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnESFpartB, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 12;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(256, 578);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// btnESFpartL
			// 
			this.btnESFpartL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartL.Location = new System.Drawing.Point(3, 531);
			this.btnESFpartL.Name = "btnESFpartL";
			this.btnESFpartL.Size = new System.Drawing.Size(250, 44);
			this.btnESFpartL.TabIndex = 11;
			this.btnESFpartL.Text = "Раздел L. Сведения по ЭЦП";
			this.btnESFpartL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartL.UseVisualStyleBackColor = true;
			// 
			// btnESFpartK
			// 
			this.btnESFpartK.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartK.Location = new System.Drawing.Point(3, 483);
			this.btnESFpartK.Name = "btnESFpartK";
			this.btnESFpartK.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartK.TabIndex = 10;
			this.btnESFpartK.Text = "Раздел K. Дополнительные сведения";
			this.btnESFpartK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartK.UseVisualStyleBackColor = true;
			// 
			// btnESFpartJ
			// 
			this.btnESFpartJ.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartJ.Location = new System.Drawing.Point(3, 435);
			this.btnESFpartJ.Name = "btnESFpartJ";
			this.btnESFpartJ.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartJ.TabIndex = 9;
			this.btnESFpartJ.Text = "Раздел J. Реквизиты поверенного (оператора) получателя";
			this.btnESFpartJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartJ.UseVisualStyleBackColor = true;
			// 
			// btnESFpartI
			// 
			this.btnESFpartI.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartI.Location = new System.Drawing.Point(3, 387);
			this.btnESFpartI.Name = "btnESFpartI";
			this.btnESFpartI.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartI.TabIndex = 8;
			this.btnESFpartI.Text = "Раздел I. Реквизиты поверенного (оператора) поставщика";
			this.btnESFpartI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartI.UseVisualStyleBackColor = true;
			// 
			// btnESFpartH
			// 
			this.btnESFpartH.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartH.Location = new System.Drawing.Point(3, 339);
			this.btnESFpartH.Name = "btnESFpartH";
			this.btnESFpartH.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartH.TabIndex = 7;
			this.btnESFpartH.Text = "Раздел H. Данные по товарам, работам, услугам участников совместной деятельности";
			this.btnESFpartH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartH.UseVisualStyleBackColor = true;
			// 
			// btnESFpartG
			// 
			this.btnESFpartG.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartG.Location = new System.Drawing.Point(3, 291);
			this.btnESFpartG.Name = "btnESFpartG";
			this.btnESFpartG.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartG.TabIndex = 6;
			this.btnESFpartG.Text = "Раздел G. Данные по товарам, работам, услугам";
			this.btnESFpartG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartG.UseVisualStyleBackColor = true;
			// 
			// btnESFpartF
			// 
			this.btnESFpartF.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartF.Location = new System.Drawing.Point(3, 243);
			this.btnESFpartF.Name = "btnESFpartF";
			this.btnESFpartF.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartF.TabIndex = 5;
			this.btnESFpartF.Text = "Раздел F. Реквизиты документов, подтверждающих поставку товаров, работ, услуг";
			this.btnESFpartF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartF.UseVisualStyleBackColor = true;
			// 
			// btnESFpartE
			// 
			this.btnESFpartE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartE.Location = new System.Drawing.Point(3, 195);
			this.btnESFpartE.Name = "btnESFpartE";
			this.btnESFpartE.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartE.TabIndex = 4;
			this.btnESFpartE.Text = "Раздел Е. Договор (контракт)";
			this.btnESFpartE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartE.UseVisualStyleBackColor = true;
			// 
			// btnESFpartD
			// 
			this.btnESFpartD.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartD.Location = new System.Drawing.Point(3, 147);
			this.btnESFpartD.Name = "btnESFpartD";
			this.btnESFpartD.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartD.TabIndex = 3;
			this.btnESFpartD.Text = "Раздел D. Реквизиты грузоотправителя и грузополучателя";
			this.btnESFpartD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartD.UseVisualStyleBackColor = true;
			// 
			// btnESFpartC
			// 
			this.btnESFpartC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartC.Location = new System.Drawing.Point(3, 99);
			this.btnESFpartC.Name = "btnESFpartC";
			this.btnESFpartC.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartC.TabIndex = 2;
			this.btnESFpartC.Text = "Раздел С. Реквизиты получателя";
			this.btnESFpartC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartC.UseVisualStyleBackColor = true;
			// 
			// btnESFpartA
			// 
			this.btnESFpartA.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartA.Location = new System.Drawing.Point(3, 3);
			this.btnESFpartA.Name = "btnESFpartA";
			this.btnESFpartA.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartA.TabIndex = 0;
			this.btnESFpartA.Text = "Раздел А. Общий раздел";
			this.btnESFpartA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartA.UseVisualStyleBackColor = true;
			this.btnESFpartA.Click += new System.EventHandler(this.btnESFpartA_Click);
			// 
			// btnESFpartB
			// 
			this.btnESFpartB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnESFpartB.Location = new System.Drawing.Point(3, 51);
			this.btnESFpartB.Name = "btnESFpartB";
			this.btnESFpartB.Size = new System.Drawing.Size(250, 42);
			this.btnESFpartB.TabIndex = 1;
			this.btnESFpartB.Text = "Раздел В. Реквизиты поставщика";
			this.btnESFpartB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnESFpartB.UseVisualStyleBackColor = true;
			this.btnESFpartB.Click += new System.EventHandler(this.btnESFpartB_Click);
			// 
			// ESF_form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1073, 648);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "ESF_form";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "ESF_form";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnESFpartL;
		private System.Windows.Forms.Button btnESFpartK;
		private System.Windows.Forms.Button btnESFpartJ;
		private System.Windows.Forms.Button btnESFpartI;
		private System.Windows.Forms.Button btnESFpartH;
		private System.Windows.Forms.Button btnESFpartG;
		private System.Windows.Forms.Button btnESFpartF;
		private System.Windows.Forms.Button btnESFpartE;
		private System.Windows.Forms.Button btnESFpartD;
		private System.Windows.Forms.Button btnESFpartC;
		private System.Windows.Forms.Button btnESFpartA;
		private System.Windows.Forms.Button btnESFpartB;
		private panelESFpartA PanelESFpartA;
		private panelESFpartB PanelESFpartB;
	}
}