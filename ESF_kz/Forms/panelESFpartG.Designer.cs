namespace ESF_kz.Forms
{
	partial class panelESFpartG
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tbPartG_totalTurnoverSize = new System.Windows.Forms.TextBox();
			this.tbPartG_totalPriceWithTax = new System.Windows.Forms.TextBox();
			this.tbPartG_totalPriceWithoutTax = new System.Windows.Forms.TextBox();
			this.tbPartG_totalNdsAmount = new System.Windows.Forms.TextBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPartG_currencyRate = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbPartG_currencyCode = new System.Windows.Forms.TextBox();
			this.l_PartG_totalNdsAmount = new System.Windows.Forms.Label();
			this.l_PartG_totalPriceWithoutTax = new System.Windows.Forms.Label();
			this.l_PartG_totalPriceWithTax = new System.Windows.Forms.Label();
			this.l_PartG_totalTurnoverSize = new System.Windows.Forms.Label();
			this.tbPartG_totalExciseAmount = new System.Windows.Forms.TextBox();
			this.l_PartG_totalExciseAmount = new System.Windows.Forms.Label();
			this.l_PartG_ndsRateType = new System.Windows.Forms.Label();
			this.chbxPartG_withoutNDS = new System.Windows.Forms.CheckBox();
			this.rowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.typeTRN = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.nameTRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fullnameTRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TNVED = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.measure = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pricePerOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.priceWithoutTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.exciseRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.exciseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.turnoverSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ndsRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ndsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.priceWithTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.productDeclaration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.productNumberInDeclaration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.catalogTruId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.additional = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.tbPartG_totalTurnoverSize, 1, 9);
			this.tableLayoutPanel1.Controls.Add(this.tbPartG_totalPriceWithTax, 1, 8);
			this.tableLayoutPanel1.Controls.Add(this.tbPartG_totalPriceWithoutTax, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.tbPartG_totalNdsAmount, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbPartG_currencyRate, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbPartG_currencyCode, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.l_PartG_totalNdsAmount, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.l_PartG_totalPriceWithoutTax, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.l_PartG_totalPriceWithTax, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.l_PartG_totalTurnoverSize, 0, 9);
			this.tableLayoutPanel1.Controls.Add(this.tbPartG_totalExciseAmount, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.l_PartG_totalExciseAmount, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.l_PartG_ndsRateType, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.chbxPartG_withoutNDS, 1, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 10;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.266141F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.844283F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.844283F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.844283F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.00468F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.840035F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.840035F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.840035F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.840035F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.836195F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 792);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// tbPartG_totalTurnoverSize
			// 
			this.tbPartG_totalTurnoverSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tbPartG_totalTurnoverSize.Location = new System.Drawing.Point(479, 763);
			this.tbPartG_totalTurnoverSize.Name = "tbPartG_totalTurnoverSize";
			this.tbPartG_totalTurnoverSize.Size = new System.Drawing.Size(300, 20);
			this.tbPartG_totalTurnoverSize.TabIndex = 61;
			// 
			// tbPartG_totalPriceWithTax
			// 
			this.tbPartG_totalPriceWithTax.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tbPartG_totalPriceWithTax.Location = new System.Drawing.Point(479, 730);
			this.tbPartG_totalPriceWithTax.Name = "tbPartG_totalPriceWithTax";
			this.tbPartG_totalPriceWithTax.Size = new System.Drawing.Size(300, 20);
			this.tbPartG_totalPriceWithTax.TabIndex = 60;
			// 
			// tbPartG_totalPriceWithoutTax
			// 
			this.tbPartG_totalPriceWithoutTax.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tbPartG_totalPriceWithoutTax.Location = new System.Drawing.Point(479, 700);
			this.tbPartG_totalPriceWithoutTax.Name = "tbPartG_totalPriceWithoutTax";
			this.tbPartG_totalPriceWithoutTax.Size = new System.Drawing.Size(300, 20);
			this.tbPartG_totalPriceWithoutTax.TabIndex = 59;
			// 
			// tbPartG_totalNdsAmount
			// 
			this.tbPartG_totalNdsAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tbPartG_totalNdsAmount.Location = new System.Drawing.Point(479, 670);
			this.tbPartG_totalNdsAmount.Name = "tbPartG_totalNdsAmount";
			this.tbPartG_totalNdsAmount.Size = new System.Drawing.Size(300, 20);
			this.tbPartG_totalNdsAmount.TabIndex = 58;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowNumber,
            this.typeTRN,
            this.nameTRN,
            this.fullnameTRN,
            this.TNVED,
            this.measure,
            this.quantity,
            this.pricePerOne,
            this.priceWithoutTax,
            this.exciseRate,
            this.exciseAmount,
            this.turnoverSize,
            this.ndsRate,
            this.ndsAmount,
            this.priceWithTax,
            this.productDeclaration,
            this.productNumberInDeclaration,
            this.catalogTruId,
            this.additional});
			this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(4, 139);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(944, 493);
			this.dataGridView1.TabIndex = 51;
			// 
			// label1
			// 
			this.label1.AutoEllipsis = true;
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(4, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(468, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "33.1 код валюты";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(4, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(468, 30);
			this.label2.TabIndex = 1;
			this.label2.Text = "32.2 курс валюты";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPartG_currencyRate
			// 
			this.tbPartG_currencyRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPartG_currencyRate.Location = new System.Drawing.Point(479, 79);
			this.tbPartG_currencyRate.Name = "tbPartG_currencyRate";
			this.tbPartG_currencyRate.Size = new System.Drawing.Size(469, 20);
			this.tbPartG_currencyRate.TabIndex = 14;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label9, 2);
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(4, 1);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(944, 41);
			this.label9.TabIndex = 45;
			this.label9.Text = "Раздел G. Данные по товарам, работам, услугам";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbPartG_currencyCode
			// 
			this.tbPartG_currencyCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPartG_currencyCode.Location = new System.Drawing.Point(479, 48);
			this.tbPartG_currencyCode.Name = "tbPartG_currencyCode";
			this.tbPartG_currencyCode.Size = new System.Drawing.Size(469, 20);
			this.tbPartG_currencyCode.TabIndex = 46;
			// 
			// l_PartG_totalNdsAmount
			// 
			this.l_PartG_totalNdsAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.l_PartG_totalNdsAmount.AutoSize = true;
			this.l_PartG_totalNdsAmount.Location = new System.Drawing.Point(4, 674);
			this.l_PartG_totalNdsAmount.Name = "l_PartG_totalNdsAmount";
			this.l_PartG_totalNdsAmount.Size = new System.Drawing.Size(82, 13);
			this.l_PartG_totalNdsAmount.TabIndex = 53;
			this.l_PartG_totalNdsAmount.Text = "totalNdsAmount";
			// 
			// l_PartG_totalPriceWithoutTax
			// 
			this.l_PartG_totalPriceWithoutTax.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.l_PartG_totalPriceWithoutTax.AutoSize = true;
			this.l_PartG_totalPriceWithoutTax.Location = new System.Drawing.Point(4, 704);
			this.l_PartG_totalPriceWithoutTax.Name = "l_PartG_totalPriceWithoutTax";
			this.l_PartG_totalPriceWithoutTax.Size = new System.Drawing.Size(106, 13);
			this.l_PartG_totalPriceWithoutTax.TabIndex = 54;
			this.l_PartG_totalPriceWithoutTax.Text = "totalPriceWithoutTax";
			// 
			// l_PartG_totalPriceWithTax
			// 
			this.l_PartG_totalPriceWithTax.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.l_PartG_totalPriceWithTax.AutoSize = true;
			this.l_PartG_totalPriceWithTax.Location = new System.Drawing.Point(4, 734);
			this.l_PartG_totalPriceWithTax.Name = "l_PartG_totalPriceWithTax";
			this.l_PartG_totalPriceWithTax.Size = new System.Drawing.Size(91, 13);
			this.l_PartG_totalPriceWithTax.TabIndex = 55;
			this.l_PartG_totalPriceWithTax.Text = "totalPriceWithTax";
			// 
			// l_PartG_totalTurnoverSize
			// 
			this.l_PartG_totalTurnoverSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.l_PartG_totalTurnoverSize.AutoSize = true;
			this.l_PartG_totalTurnoverSize.Location = new System.Drawing.Point(4, 767);
			this.l_PartG_totalTurnoverSize.Name = "l_PartG_totalTurnoverSize";
			this.l_PartG_totalTurnoverSize.Size = new System.Drawing.Size(90, 13);
			this.l_PartG_totalTurnoverSize.TabIndex = 56;
			this.l_PartG_totalTurnoverSize.Text = "totalTurnoverSize";
			// 
			// tbPartG_totalExciseAmount
			// 
			this.tbPartG_totalExciseAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tbPartG_totalExciseAmount.Location = new System.Drawing.Point(479, 640);
			this.tbPartG_totalExciseAmount.Name = "tbPartG_totalExciseAmount";
			this.tbPartG_totalExciseAmount.Size = new System.Drawing.Size(300, 20);
			this.tbPartG_totalExciseAmount.TabIndex = 57;
			// 
			// l_PartG_totalExciseAmount
			// 
			this.l_PartG_totalExciseAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.l_PartG_totalExciseAmount.AutoSize = true;
			this.l_PartG_totalExciseAmount.Location = new System.Drawing.Point(4, 644);
			this.l_PartG_totalExciseAmount.Name = "l_PartG_totalExciseAmount";
			this.l_PartG_totalExciseAmount.Size = new System.Drawing.Size(94, 13);
			this.l_PartG_totalExciseAmount.TabIndex = 52;
			this.l_PartG_totalExciseAmount.Text = "totalExciseAmount";
			// 
			// l_PartG_ndsRateType
			// 
			this.l_PartG_ndsRateType.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.l_PartG_ndsRateType.AutoSize = true;
			this.l_PartG_ndsRateType.Location = new System.Drawing.Point(4, 113);
			this.l_PartG_ndsRateType.Name = "l_PartG_ndsRateType";
			this.l_PartG_ndsRateType.Size = new System.Drawing.Size(71, 13);
			this.l_PartG_ndsRateType.TabIndex = 62;
			this.l_PartG_ndsRateType.Text = "ndsRateType";
			// 
			// chbxPartG_withoutNDS
			// 
			this.chbxPartG_withoutNDS.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.chbxPartG_withoutNDS.AutoSize = true;
			this.chbxPartG_withoutNDS.Location = new System.Drawing.Point(479, 111);
			this.chbxPartG_withoutNDS.Name = "chbxPartG_withoutNDS";
			this.chbxPartG_withoutNDS.Size = new System.Drawing.Size(171, 17);
			this.chbxPartG_withoutNDS.TabIndex = 63;
			this.chbxPartG_withoutNDS.Text = "Тип НДС (\'Без НДС – не РК\')";
			this.chbxPartG_withoutNDS.UseVisualStyleBackColor = true;
			// 
			// rowNumber
			// 
			this.rowNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.rowNumber.HeaderText = "№ п/п";
			this.rowNumber.Name = "rowNumber";
			// 
			// typeTRN
			// 
			this.typeTRN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.typeTRN.HeaderText = "Признак происхождения товаров и услуг";
			this.typeTRN.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
			this.typeTRN.Name = "typeTRN";
			// 
			// nameTRN
			// 
			this.nameTRN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.nameTRN.FillWeight = 300F;
			this.nameTRN.HeaderText = "Наименование товаров, работ и услуг";
			this.nameTRN.Name = "nameTRN";
			// 
			// fullnameTRN
			// 
			this.fullnameTRN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.fullnameTRN.FillWeight = 400F;
			this.fullnameTRN.HeaderText = "Наименование товаров в соответствии с Декларацией на товары или заявления о ввозе" +
    " товаров и уплате косвенных налогов";
			this.fullnameTRN.Name = "fullnameTRN";
			// 
			// TNVED
			// 
			this.TNVED.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.TNVED.FillWeight = 200F;
			this.TNVED.HeaderText = "Код товара (ТНВЭД ЕАЭС)";
			this.TNVED.Name = "TNVED";
			// 
			// measure
			// 
			this.measure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.measure.HeaderText = "Единица измерения";
			this.measure.Name = "measure";
			// 
			// quantity
			// 
			this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.quantity.FillWeight = 150F;
			this.quantity.HeaderText = "Количество (объем)";
			this.quantity.Name = "quantity";
			// 
			// pricePerOne
			// 
			this.pricePerOne.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.pricePerOne.FillWeight = 150F;
			this.pricePerOne.HeaderText = "Цена (тариф) за единицу товара, работы, услуг и без косвенных налогов";
			this.pricePerOne.Name = "pricePerOne";
			// 
			// priceWithoutTax
			// 
			this.priceWithoutTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.priceWithoutTax.FillWeight = 150F;
			this.priceWithoutTax.HeaderText = "Стоимость товаров, работ, услуг без косвенных налогов";
			this.priceWithoutTax.Name = "priceWithoutTax";
			// 
			// exciseRate
			// 
			this.exciseRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.exciseRate.HeaderText = "Акциз ставка";
			this.exciseRate.Name = "exciseRate";
			// 
			// exciseAmount
			// 
			this.exciseAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.exciseAmount.FillWeight = 150F;
			this.exciseAmount.HeaderText = "Акциз сумма";
			this.exciseAmount.Name = "exciseAmount";
			// 
			// turnoverSize
			// 
			this.turnoverSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.turnoverSize.FillWeight = 150F;
			this.turnoverSize.HeaderText = "Размер оборота по реализации(облагаемый/необлагаемый оборот)";
			this.turnoverSize.Name = "turnoverSize";
			// 
			// ndsRate
			// 
			this.ndsRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ndsRate.HeaderText = "НДС ставка";
			this.ndsRate.Name = "ndsRate";
			// 
			// ndsAmount
			// 
			this.ndsAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ndsAmount.FillWeight = 150F;
			this.ndsAmount.HeaderText = "НДС сумма";
			this.ndsAmount.Name = "ndsAmount";
			// 
			// priceWithTax
			// 
			this.priceWithTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.priceWithTax.FillWeight = 150F;
			this.priceWithTax.HeaderText = "Стоимость товаров, работ, услуг с учетом косвенных налогов";
			this.priceWithTax.Name = "priceWithTax";
			// 
			// productDeclaration
			// 
			this.productDeclaration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.productDeclaration.FillWeight = 150F;
			this.productDeclaration.HeaderText = "№ Декларации на товары, заявления о ввозе товаров и уплате косвенных налогов, СТ-" +
    "1 или СТ-KZ";
			this.productDeclaration.Name = "productDeclaration";
			// 
			// productNumberInDeclaration
			// 
			this.productNumberInDeclaration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.productNumberInDeclaration.FillWeight = 150F;
			this.productNumberInDeclaration.HeaderText = "Номер товарной позиции из Декларации на товары или заявления о ввозе товаров и уп" +
    "лате косвенных налогов";
			this.productNumberInDeclaration.Name = "productNumberInDeclaration";
			// 
			// catalogTruId
			// 
			this.catalogTruId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.catalogTruId.FillWeight = 150F;
			this.catalogTruId.HeaderText = "Идентификатор товара, работы, услуг";
			this.catalogTruId.Name = "catalogTruId";
			// 
			// additional
			// 
			this.additional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.additional.FillWeight = 200F;
			this.additional.HeaderText = "Дополнительные данные";
			this.additional.Name = "additional";
			// 
			// panelESFpartG
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "panelESFpartG";
			this.Size = new System.Drawing.Size(952, 792);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbPartG_currencyRate;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbPartG_currencyCode;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
		private System.Windows.Forms.TextBox tbPartG_totalTurnoverSize;
		private System.Windows.Forms.TextBox tbPartG_totalPriceWithTax;
		private System.Windows.Forms.TextBox tbPartG_totalPriceWithoutTax;
		private System.Windows.Forms.TextBox tbPartG_totalNdsAmount;
		private System.Windows.Forms.Label l_PartG_totalNdsAmount;
		private System.Windows.Forms.Label l_PartG_totalPriceWithoutTax;
		private System.Windows.Forms.Label l_PartG_totalPriceWithTax;
		private System.Windows.Forms.Label l_PartG_totalTurnoverSize;
		private System.Windows.Forms.TextBox tbPartG_totalExciseAmount;
		private System.Windows.Forms.Label l_PartG_totalExciseAmount;
		private System.Windows.Forms.Label l_PartG_ndsRateType;
		private System.Windows.Forms.CheckBox chbxPartG_withoutNDS;
		private System.Windows.Forms.DataGridViewTextBoxColumn rowNumber;
		private System.Windows.Forms.DataGridViewComboBoxColumn typeTRN;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameTRN;
		private System.Windows.Forms.DataGridViewTextBoxColumn fullnameTRN;
		private System.Windows.Forms.DataGridViewTextBoxColumn TNVED;
		private System.Windows.Forms.DataGridViewTextBoxColumn measure;
		private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
		private System.Windows.Forms.DataGridViewTextBoxColumn pricePerOne;
		private System.Windows.Forms.DataGridViewTextBoxColumn priceWithoutTax;
		private System.Windows.Forms.DataGridViewTextBoxColumn exciseRate;
		private System.Windows.Forms.DataGridViewTextBoxColumn exciseAmount;
		private System.Windows.Forms.DataGridViewTextBoxColumn turnoverSize;
		private System.Windows.Forms.DataGridViewTextBoxColumn ndsRate;
		private System.Windows.Forms.DataGridViewTextBoxColumn ndsAmount;
		private System.Windows.Forms.DataGridViewTextBoxColumn priceWithTax;
		private System.Windows.Forms.DataGridViewTextBoxColumn productDeclaration;
		private System.Windows.Forms.DataGridViewTextBoxColumn productNumberInDeclaration;
		private System.Windows.Forms.DataGridViewTextBoxColumn catalogTruId;
		private System.Windows.Forms.DataGridViewTextBoxColumn additional;
	}
}
