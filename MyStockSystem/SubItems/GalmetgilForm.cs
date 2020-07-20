using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MyStockSystem.SubItems
{
    public partial class GalmetgilForm : MetroForm
    {
        public GalmetgilForm()
        {
            InitializeComponent();
        }

        private void GalmetgilForm_Load(object sender, EventArgs e)
        {
            DgvSearchItems.Font = new Font(@"NanumBarunGothic", 9, FontStyle.Regular);
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void MtlBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            MainForm main = new MainForm();
            main.Location = this.Location;
            main.ShowDialog();

            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient { Encoding = Encoding.UTF8 };

            StringBuilder str = new StringBuilder();

            //OpenAPI 기본 URL
            str.Append("http://apis.data.go.kr/6260000/BusanGalmaetGilService/getGalmaetGilInfo");
            str.Append("?ServiceKey=uxpTfsGhsuP6%2BsjnRbCTLckrHnJLDY6yRFl81ds%2BFH8hYtGumNujpEKNHx50k1CddtYciTy2kT0b2pQJO48fTA%3D%3D");
            str.Append("&pageNo=1");
            str.Append("&numOfRows=10");
            str.Append("&resultType=json");

            string json = wc.DownloadString(str.ToString());
            JObject obj = JObject.Parse(json);

            JArray items = JArray.Parse(obj.SelectToken("getGalmaetGilInfo.item").ToString());
            
            DgvSearchItems.Rows.Clear();

            foreach (var item in items)
            {
                //kosNm,kosType,kosTxt,img,txt1,title,txt2
                DgvSearchItems.Rows.Add(
                    $"{item.SelectToken("kosNm")}",
                    $"{item.SelectToken("kosType")}",
                    $"{item.SelectToken("kosTxt")}",
                    $"{item.SelectToken("img")}",
                    $"{item.SelectToken("txt1")}",
                    $"{item.SelectToken("title")}",
                    $"{item.SelectToken("txt2")}"
                    );
            }

            //들어오는 data마다 알아서 늘어남
            DgvSearchItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void TxtSearchItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) //e.KeyChar == 13 -> Enter
            {
                BtnSearch_Click(sender, new EventArgs());
            }
        }

        private void DgvSearchItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //cells[3] -> 이미지속성
            var selvalue = DgvSearchItems.Rows[e.RowIndex].Cells[3].Value.ToString();
            //MessageBox.Show(selvalue);

            //자식창 여는 법(downloadForm)
            DownloadForm form = new DownloadForm();
            form.ParentUrl = selvalue;
            form.ShowDialog();
        }
    }
}
