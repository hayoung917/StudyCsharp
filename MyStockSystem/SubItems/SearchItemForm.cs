using MetroFramework.Forms;
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
    public partial class SearchItemForm : MetroForm
    {
        public SearchItemForm()
        {
            InitializeComponent();
        }

        private void SearchItemForm_Load(object sender, EventArgs e)
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

        private void DgvSearchItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient { Encoding = Encoding.UTF8 };
            XmlDocument doc = new XmlDocument();

            StringBuilder str = new StringBuilder();

            //OpenAPI 기본 URL
            str.Append("http://api.seibro.or.kr/openapi/service/StockSvc/getStkIsinByNmN1");
            //일반 인증키
            str.Append("?serviceKey=uxpTfsGhsuP6%2BsjnRbCTLckrHnJLDY6yRFl81ds%2BFH8hYtGumNujpEKNHx50k1CddtYciTy2kT0b2pQJO48fTA%3D%3D");

            str.Append($"&secnNm={TxtSearchItem.Text}");    //검색어
            str.Append("&numOfRows=4");                   //읽어올 데이터 수
            str.Append("&pageNo=1");                        //페이지번호
            str.Append("&martTpcd=11");                     //주식 시장 공유 11 유가증권

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);

            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            DgvSearchItems.Rows.Clear();

            try
            {
                foreach (XmlNode item in items)
                {
                    DgvSearchItems.Rows.Add(item["isin"].InnerText, //isin 표준코드
                        item["issuDt"] == null ? string.Empty : item["issuDt"].InnerText,     //issuDt 주식발행일자
                        //item["issuDt"].InnerText,
                        item["korSecnNm"].InnerText,                //korSecnNm 한글 종목명
                        item["secnKacdNm"].InnerText,               //secnKacdNm 보통주/우선주
                        item["shotnIsin"].InnerText);               //shotnIsin 단축코드
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"에러발생 : {ex.Message}", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
