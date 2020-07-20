namespace ElectroCarChargeAPI.SubItems
{
    partial class SearchItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchItemForm));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.MtlBack = new MetroFramework.Controls.MetroTile();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnSearch = new MetroFramework.Controls.MetroButton();
            this.TxtSearchItem = new MetroFramework.Controls.MetroTextBox();
            this.DgvSearchItems = new System.Windows.Forms.DataGridView();
            this.statId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chgerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chgerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addrDoro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearchItems)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Location = new System.Drawing.Point(25, 70);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1243, 548);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // MtlBack
            // 
            this.MtlBack.ActiveControl = null;
            this.MtlBack.Location = new System.Drawing.Point(1147, 624);
            this.MtlBack.Name = "MtlBack";
            this.MtlBack.Size = new System.Drawing.Size(121, 85);
            this.MtlBack.Style = MetroFramework.MetroColorStyle.White;
            this.MtlBack.TabIndex = 2;
            this.MtlBack.TileImage = global::ElectroCarChargeAPI.Properties.Resources.iconfinder_arrow_back_outline_216436;
            this.MtlBack.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlBack.UseSelectable = true;
            this.MtlBack.UseTileImage = true;
            this.MtlBack.Click += new System.EventHandler(this.MtlBack_Click);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.splitContainer1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1235, 506);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "충전소 지역검색";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TxtSearchItem);
            this.splitContainer1.Panel1.Controls.Add(this.BtnSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvSearchItems);
            this.splitContainer1.Size = new System.Drawing.Size(1235, 506);
            this.splitContainer1.TabIndex = 2;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(1097, 3);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(135, 44);
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "주소검색";
            this.BtnSearch.UseSelectable = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtSearchItem
            // 
            // 
            // 
            // 
            this.TxtSearchItem.CustomButton.Image = null;
            this.TxtSearchItem.CustomButton.Location = new System.Drawing.Point(225, 2);
            this.TxtSearchItem.CustomButton.Name = "";
            this.TxtSearchItem.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.TxtSearchItem.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtSearchItem.CustomButton.TabIndex = 1;
            this.TxtSearchItem.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtSearchItem.CustomButton.UseSelectable = true;
            this.TxtSearchItem.CustomButton.Visible = false;
            this.TxtSearchItem.Lines = new string[0];
            this.TxtSearchItem.Location = new System.Drawing.Point(824, 3);
            this.TxtSearchItem.MaxLength = 32767;
            this.TxtSearchItem.Name = "TxtSearchItem";
            this.TxtSearchItem.PasswordChar = '\0';
            this.TxtSearchItem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtSearchItem.SelectedText = "";
            this.TxtSearchItem.SelectionLength = 0;
            this.TxtSearchItem.SelectionStart = 0;
            this.TxtSearchItem.ShortcutsEnabled = true;
            this.TxtSearchItem.Size = new System.Drawing.Size(267, 44);
            this.TxtSearchItem.TabIndex = 2;
            this.TxtSearchItem.UseSelectable = true;
            this.TxtSearchItem.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtSearchItem.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TxtSearchItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearchItem_KeyPress);
            // 
            // DgvSearchItems
            // 
            this.DgvSearchItems.AllowUserToAddRows = false;
            this.DgvSearchItems.AllowUserToDeleteRows = false;
            this.DgvSearchItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSearchItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statId,
            this.statNm,
            this.chgerId,
            this.chgerType,
            this.stat,
            this.addrDoro,
            this.useTime});
            this.DgvSearchItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSearchItems.Location = new System.Drawing.Point(0, 0);
            this.DgvSearchItems.Name = "DgvSearchItems";
            this.DgvSearchItems.RowHeadersWidth = 62;
            this.DgvSearchItems.RowTemplate.Height = 30;
            this.DgvSearchItems.Size = new System.Drawing.Size(1235, 452);
            this.DgvSearchItems.TabIndex = 0;
            // 
            // statId
            // 
            this.statId.HeaderText = "충전소ID";
            this.statId.MinimumWidth = 8;
            this.statId.Name = "statId";
            this.statId.Width = 150;
            // 
            // statNm
            // 
            this.statNm.HeaderText = "충전소명";
            this.statNm.MinimumWidth = 8;
            this.statNm.Name = "statNm";
            this.statNm.Width = 150;
            // 
            // chgerId
            // 
            this.chgerId.HeaderText = "충전기ID";
            this.chgerId.MinimumWidth = 8;
            this.chgerId.Name = "chgerId";
            this.chgerId.Width = 150;
            // 
            // chgerType
            // 
            this.chgerType.HeaderText = "충전기타입";
            this.chgerType.MinimumWidth = 8;
            this.chgerType.Name = "chgerType";
            this.chgerType.Width = 150;
            // 
            // stat
            // 
            this.stat.HeaderText = "충전기상태";
            this.stat.MinimumWidth = 8;
            this.stat.Name = "stat";
            this.stat.Width = 150;
            // 
            // addrDoro
            // 
            this.addrDoro.HeaderText = "충전기주소";
            this.addrDoro.MinimumWidth = 8;
            this.addrDoro.Name = "addrDoro";
            this.addrDoro.Width = 150;
            // 
            // useTime
            // 
            this.useTime.HeaderText = "충전기이용시간";
            this.useTime.MinimumWidth = 8;
            this.useTime.Name = "useTime";
            this.useTime.Width = 180;
            // 
            // SearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.MtlBack);
            this.Controls.Add(this.metroTabControl1);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "SearchItemForm";
            this.Padding = new System.Windows.Forms.Padding(22, 67, 22, 22);
            this.Resizable = false;
            this.Text = "전기차 충전소 검색";
            this.Load += new System.EventHandler(this.SearchItemForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearchItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTile MtlBack;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroTextBox TxtSearchItem;
        private MetroFramework.Controls.MetroButton BtnSearch;
        private System.Windows.Forms.DataGridView DgvSearchItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn statId;
        private System.Windows.Forms.DataGridViewTextBoxColumn statNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn chgerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn chgerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn stat;
        private System.Windows.Forms.DataGridViewTextBoxColumn addrDoro;
        private System.Windows.Forms.DataGridViewTextBoxColumn useTime;
    }
}