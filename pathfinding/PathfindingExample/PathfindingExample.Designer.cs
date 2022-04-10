namespace PathfindingExample
{
	partial class PathfindingExample
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathfindingExample));
			this.pnlTitle = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.dgvLog = new System.Windows.Forms.DataGridView();
			this.tlpOperation = new System.Windows.Forms.TableLayoutPanel();
			this.rdoJPS = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.rdoAStar = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.btnFindPath = new System.Windows.Forms.Button();
			this.tlpMap = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pbMap = new System.Windows.Forms.PictureBox();
			this.lblIcon = new System.Windows.Forms.Label();
			this.btnInformation = new System.Windows.Forms.Button();
			this.btnMinimize = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.pnlTitle.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.tlpLog.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
			this.tlpOperation.SuspendLayout();
			this.tlpMap.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTitle
			// 
			this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
			this.pnlTitle.Controls.Add(this.lblTitle);
			this.pnlTitle.Controls.Add(this.lblIcon);
			this.pnlTitle.Controls.Add(this.btnInformation);
			this.pnlTitle.Controls.Add(this.btnMinimize);
			this.pnlTitle.Controls.Add(this.btnClose);
			this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTitle.Location = new System.Drawing.Point(0, 0);
			this.pnlTitle.Name = "pnlTitle";
			this.pnlTitle.Size = new System.Drawing.Size(650, 20);
			this.pnlTitle.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lblTitle.Location = new System.Drawing.Point(20, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(570, 20);
			this.lblTitle.TabIndex = 5;
			this.lblTitle.Text = "Pathfinding Example";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrlTitle_MouseDown);
			// 
			// pnlMain
			// 
			this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.pnlMain.Controls.Add(this.tlpLog);
			this.pnlMain.Controls.Add(this.tlpOperation);
			this.pnlMain.Controls.Add(this.tlpMap);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 20);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(2);
			this.pnlMain.Size = new System.Drawing.Size(650, 310);
			this.pnlMain.TabIndex = 1;
			// 
			// tlpLog
			// 
			this.tlpLog.ColumnCount = 1;
			this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tlpLog.Controls.Add(this.dgvLog, 0, 2);
			this.tlpLog.Controls.Add(this.panel3, 0, 1);
			this.tlpLog.Controls.Add(this.label3, 0, 0);
			this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpLog.Location = new System.Drawing.Point(202, 222);
			this.tlpLog.Name = "tlpLog";
			this.tlpLog.RowCount = 3;
			this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpLog.Size = new System.Drawing.Size(446, 86);
			this.tlpLog.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Gray;
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 23);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(440, 1);
			this.panel3.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label3.Location = new System.Drawing.Point(3, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Log";
			// 
			// dgvLog
			// 
			this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvLog.DefaultCellStyle = dataGridViewCellStyle1;
			this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvLog.Location = new System.Drawing.Point(3, 28);
			this.dgvLog.Name = "dgvLog";
			this.dgvLog.RowTemplate.Height = 18;
			this.dgvLog.Size = new System.Drawing.Size(440, 55);
			this.dgvLog.TabIndex = 2;
			// 
			// tlpOperation
			// 
			this.tlpOperation.ColumnCount = 2;
			this.tlpOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tlpOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpOperation.Controls.Add(this.rdoJPS, 0, 3);
			this.tlpOperation.Controls.Add(this.panel2, 0, 1);
			this.tlpOperation.Controls.Add(this.rdoAStar, 0, 2);
			this.tlpOperation.Controls.Add(this.label2, 0, 0);
			this.tlpOperation.Controls.Add(this.btnFindPath, 1, 2);
			this.tlpOperation.Dock = System.Windows.Forms.DockStyle.Left;
			this.tlpOperation.Location = new System.Drawing.Point(2, 222);
			this.tlpOperation.Name = "tlpOperation";
			this.tlpOperation.RowCount = 4;
			this.tlpOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpOperation.Size = new System.Drawing.Size(200, 86);
			this.tlpOperation.TabIndex = 1;
			// 
			// rdoJPS
			// 
			this.rdoJPS.Appearance = System.Windows.Forms.Appearance.Button;
			this.rdoJPS.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rdoJPS.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
			this.rdoJPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdoJPS.Location = new System.Drawing.Point(3, 58);
			this.rdoJPS.Name = "rdoJPS";
			this.rdoJPS.Size = new System.Drawing.Size(74, 25);
			this.rdoJPS.TabIndex = 3;
			this.rdoJPS.Text = "JPS";
			this.rdoJPS.UseVisualStyleBackColor = true;
			this.rdoJPS.CheckedChanged += new System.EventHandler(this.rdoAlgorithm_CheckedChanged);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gray;
			this.tlpOperation.SetColumnSpan(this.panel2, 2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 23);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(194, 1);
			this.panel2.TabIndex = 0;
			// 
			// rdoAStar
			// 
			this.rdoAStar.Appearance = System.Windows.Forms.Appearance.Button;
			this.rdoAStar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rdoAStar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
			this.rdoAStar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rdoAStar.Location = new System.Drawing.Point(3, 28);
			this.rdoAStar.Name = "rdoAStar";
			this.rdoAStar.Size = new System.Drawing.Size(74, 24);
			this.rdoAStar.TabIndex = 2;
			this.rdoAStar.Text = "A*";
			this.rdoAStar.UseVisualStyleBackColor = true;
			this.rdoAStar.CheckedChanged += new System.EventHandler(this.rdoAlgorithm_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.tlpOperation.SetColumnSpan(this.label2, 2);
			this.label2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label2.Location = new System.Drawing.Point(3, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Operation";
			// 
			// btnFindPath
			// 
			this.btnFindPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnFindPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFindPath.Location = new System.Drawing.Point(83, 28);
			this.btnFindPath.Name = "btnFindPath";
			this.tlpOperation.SetRowSpan(this.btnFindPath, 2);
			this.btnFindPath.Size = new System.Drawing.Size(114, 55);
			this.btnFindPath.TabIndex = 4;
			this.btnFindPath.Text = "Find Path";
			this.btnFindPath.UseVisualStyleBackColor = true;
			this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
			// 
			// tlpMap
			// 
			this.tlpMap.ColumnCount = 1;
			this.tlpMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMap.Controls.Add(this.panel1, 0, 1);
			this.tlpMap.Controls.Add(this.label1, 0, 0);
			this.tlpMap.Controls.Add(this.pbMap, 0, 2);
			this.tlpMap.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpMap.Location = new System.Drawing.Point(2, 2);
			this.tlpMap.Name = "tlpMap";
			this.tlpMap.RowCount = 3;
			this.tlpMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMap.Size = new System.Drawing.Size(646, 220);
			this.tlpMap.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gray;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 23);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(640, 1);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Map";
			// 
			// pbMap
			// 
			this.pbMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.pbMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbMap.Location = new System.Drawing.Point(3, 28);
			this.pbMap.Name = "pbMap";
			this.pbMap.Size = new System.Drawing.Size(640, 189);
			this.pbMap.TabIndex = 2;
			this.pbMap.TabStop = false;
			this.pbMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseDown);
			this.pbMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseMove);
			this.pbMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseUp);
			// 
			// lblIcon
			// 
			this.lblIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblIcon.Image = global::PathfindingExample.Properties.Resources.icons8_waypoint_map_16px;
			this.lblIcon.Location = new System.Drawing.Point(0, 0);
			this.lblIcon.Name = "lblIcon";
			this.lblIcon.Size = new System.Drawing.Size(20, 20);
			this.lblIcon.TabIndex = 4;
			this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrlTitle_MouseDown);
			// 
			// btnInformation
			// 
			this.btnInformation.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnInformation.FlatAppearance.BorderSize = 0;
			this.btnInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInformation.Image = global::PathfindingExample.Properties.Resources.icons8_info_16px;
			this.btnInformation.Location = new System.Drawing.Point(590, 0);
			this.btnInformation.Name = "btnInformation";
			this.btnInformation.Size = new System.Drawing.Size(20, 20);
			this.btnInformation.TabIndex = 3;
			this.btnInformation.UseVisualStyleBackColor = true;
			this.btnInformation.Click += new System.EventHandler(this.btnInformation_Click);
			// 
			// btnMinimize
			// 
			this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnMinimize.FlatAppearance.BorderSize = 0;
			this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMinimize.Image = global::PathfindingExample.Properties.Resources.icons8_minimize_window_16px;
			this.btnMinimize.Location = new System.Drawing.Point(610, 0);
			this.btnMinimize.Name = "btnMinimize";
			this.btnMinimize.Size = new System.Drawing.Size(20, 20);
			this.btnMinimize.TabIndex = 1;
			this.btnMinimize.UseVisualStyleBackColor = true;
			this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Image = global::PathfindingExample.Properties.Resources.icons8_close_window_16px;
			this.btnClose.Location = new System.Drawing.Point(630, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(20, 20);
			this.btnClose.TabIndex = 0;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// PathfindingExample
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(650, 330);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlTitle);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PathfindingExample";
			this.Text = "PathfindingExample";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PathfindingExample_FormClosing);
			this.Load += new System.EventHandler(this.PathfindingExample_Load);
			this.pnlTitle.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			this.tlpLog.ResumeLayout(false);
			this.tlpLog.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
			this.tlpOperation.ResumeLayout(false);
			this.tlpOperation.PerformLayout();
			this.tlpMap.ResumeLayout(false);
			this.tlpMap.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTitle;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.TableLayoutPanel tlpLog;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TableLayoutPanel tlpOperation;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TableLayoutPanel tlpMap;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnInformation;
		private System.Windows.Forms.Button btnMinimize;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblIcon;
		private System.Windows.Forms.RadioButton rdoJPS;
		private System.Windows.Forms.RadioButton rdoAStar;
		private System.Windows.Forms.Button btnFindPath;
		private System.Windows.Forms.DataGridView dgvLog;
		private System.Windows.Forms.PictureBox pbMap;
	}
}

