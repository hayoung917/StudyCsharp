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

namespace ElectroCarChargeAPI.SubItems
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
            XmlDocument doc = new XmlDocument();

            StringBuilder str = new StringBuilder();

            //OpenAPI 기본 URL
            str.Append("http://open.ev.or.kr:8080/openapi/services/rest/EvChargerService");
            //일반 인증키
            str.Append(@"?serviceKey=uxpTfsGhsuP6%2BsjnRbCTLckrHnJLDY6yRFl81ds%2BFH8hYtGumNujpEKNHx50k1CddtYciTy2kT0b2pQJO48fTA%3D%3D");                     

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);

            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            DgvSearchItems.Rows.Clear();

            try
            {
                foreach (XmlNode item in items)
                {
                    //지역검색 변경
                    //if(item["addrDoro"].InnerText.Substring(0, TxtSearchItem.Text.Length) == TxtSearchItem.Text)
                    if (item["addrDoro"].InnerText.Contains(TxtSearchItem.Text))
                    {
                        string charT = "";
                        string stat = "";

                        if (item["chgerType"]?.InnerText == "01")
                        {
                            charT = "DC차데모";
                        }
                        else if (item["chgerType"]?.InnerText == "03")
                        {
                            charT = "DC차데모+AC3상";
                        }
                        else if (item["chgerType"]?.InnerText == "04")
                        {
                            charT = "DC콤보";
                        }
                        else if (item["chgerType"]?.InnerText == "05")
                        {
                            charT = "DC차데모+DC 콤보";
                        }
                        else if (item["chgerType"]?.InnerText == "06")
                        {
                            charT = "DC차데모 + AC3상 + DC콤보";
                        }
                        else if (item["chgerType"]?.InnerText == "07")
                        {
                            charT = "AC 3상";
                        }

                        if(item["stat"]?.InnerText == "1")
                        {
                            stat = "통신이상";
                        }
                        else if(item["stat"]?.InnerText == "2")
                        {
                            stat = "충전대기";
                        }
                        else if (item["stat"]?.InnerText == "3")
                        {
                            stat = "충전중";
                        }
                        else if (item["stat"]?.InnerText == "4")
                        {
                            stat = "운영중지";
                        }
                        else if (item["stat"]?.InnerText == "5")
                        {
                            stat = "점검중";
                        }
                        else if (item["stat"]?.InnerText == "9")
                        {
                            stat = "상태미확인";
                        }

                        DgvSearchItems.Rows.Add(item["statId"]?.InnerText,
                            item["statNm"]?.InnerText,
                            item["chgerId"]?.InnerText,
                            //item["chgerType"]?.InnerText,
                            charT,
                            //item["stat"]?.InnerText,
                            stat,
                            item["addrDoro"]?.InnerText,
                            item["useTime"]?.InnerText);
                    }
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
