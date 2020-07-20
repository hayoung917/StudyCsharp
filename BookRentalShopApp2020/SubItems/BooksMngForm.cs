using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class BooksMngForm : MetroForm
    {
        readonly string strTblName = "bookstbl";
        //DB작동시 무조건 필요
        //private readonly string strConnectionString =
        //   "Data Source = localhost;" +
        //   "Port=3306;" +
        //   "Database=bookrentalshop;" +
        //   "Uid=root;" +
        //   "Password=mysql_p@ssw0rd";

        BaseMode myMode = BaseMode.NONE;
        public BooksMngForm()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {
            UpdateComBoDivision();
            UpdateData();

            InitControls();
        }

        private void UpdateComBoDivision()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))//strConnectionString
            {
                //"SELECT Division, Names FROM divTbl "
                string strQuery = $"SELECT Division, Names FROM divTbl ";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");
                while(reader.Read())
                {
                    //DB데이터 가져오기
                    temps.Add(reader[1].ToString(), reader[0].ToString());
                }

                CboDivision.DataSource = new BindingSource(temps, null);
                CboDivision.DisplayMember = "Key";
                CboDivision.ValueMember = "Value";
                CboDivision.SelectedIndex = 0;  //처음값에 선택이 들어가있어서 -1이 아닌 0
            }
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))//strConnectionString
            {
                //"SELECT Division, Names FROM divTbl "
                string strQuery = $"SELECT b.Idx, " +
                                   "       b.Author, " +
                                   "       b.Division, " +
                                   "       d.Names AS DivisionName, " +
                                   "       b.Names, " +
                                   "       b.ReleaseDate, " +
                                   "       b.ISBN, " +
                                   "       b.Price " +
                                   "  FROM bookstbl AS b " +
                                   " INNER JOIN divtbl AS d " +
                                   "    ON b.Division = d.Division " + 
                                   " ORDER BY b.Idx ASC ";  //정렬추가
                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "divTbl");

                GrdBooksTbl.DataSource = ds;
                GrdBooksTbl.DataMember = "divTbl";
            }
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            //데이터 그리드 뷰의 테이블 속성변경
            DataGridViewColumn column;
            column = GrdBooksTbl.Columns[0];
            column.Width = 50;
            column.HeaderText = "번호";

            column = GrdBooksTbl.Columns[1];
            column.Width = 120;
            column.HeaderText = "저자명";

            column = GrdBooksTbl.Columns[2];
            column.Visible = false;

            column = GrdBooksTbl.Columns[3];
            column.Width = 100;
            column.HeaderText = "장르";

            column = GrdBooksTbl.Columns[4];
            column.Width = 200;
            column.HeaderText = "이름";

            column = GrdBooksTbl.Columns[5];
            column.Width = 150;
            column.HeaderText = "출간일";

            column = GrdBooksTbl.Columns[6];
            column.Width = 150;
            column.HeaderText = "ISBN";

            column = GrdBooksTbl.Columns[7];
            column.Width = 100;
            column.HeaderText = "가격";
            //GrdDivTbl.Columns[0].Width = 100;
            //GrdDivTbl.Columns[0].HeaderText = "구분코드";
            //GrdDivTbl.Columns[1].Width = 150;
            //GrdDivTbl.Columns[1].HeaderText = "이름";

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(myMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }
            myMode = BaseMode.DELETE;
            //DeleteProcess();
            SaveData();

            InitControls();
        }

        private void InitControls()
        {
            //text박스 비워주기
            TxtIdx.Text = TxtAuthor.Text = string.Empty;
            TxtIsbn.Text = TxtNames.Text = TxtPrice.Text = string.Empty;
            CboDivision.SelectedIndex = 0; //선택
            TxtIdx.Focus();
            TxtIdx.ReadOnly = true;

            DtRealeasDate.CustomFormat = "yyyy-MM-dd";
            DtRealeasDate.Format = DateTimePickerFormat.Custom;
            DtRealeasDate.Value = DateTime.Now;

            myMode = BaseMode.NONE;

            #region 콤보박스
            ////콤보박스 데이터바인딩
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("선택", "00");
            //dic.Add("서울 특별시","11");
            //dic.Add("부산 광역시", "21");
            //dic.Add("대구 광역시", "22");
            //dic.Add("인천 광역시", "23");
            //dic.Add("광주 광역시", "24");
            //dic.Add("대전 광역시", "25");

            //CboDivision.DataSource = new BindingSource(dic, null);
            //CboDivision.DisplayMember = "Key";
            //CboDivision.ValueMember = "Value";
            #endregion

        }

        #region 삭제메서드 주석처리
        //private void DeleteProcess()
        //{
        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
        //        {
        //            //conn 만들면 무조건 open,close
        //            //using으로 쓰면 자동으로 해줌
        //            conn.Open();
        //            MySqlCommand cmd = new MySqlCommand();
        //            cmd.Connection = conn;
        //            cmd.CommandText = "DELETE FROM divtbl " +
        //                              " WHERE Division = @Division ";

        //            MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar);
        //            paramDivision.Value = TxtDivision.Text;
        //            cmd.Parameters.Add(paramDivision);

        //            var result = cmd.ExecuteNonQuery();

        //            MetroMessageBox.Show(this, $"{result}건이 삭제되었습니다.", "삭제");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MetroMessageBox.Show(this, $"에러발생 {ex.Message}", "에러",
        //                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        UpdateData();
        //    }
        //}
        #endregion

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //text박스 비워주기
            TxtIdx.Text = TxtAuthor.Text = string.Empty;
            TxtIdx.ReadOnly = true;

            TxtIdx.Focus();

            //신규는 INSERT
            myMode = BaseMode.INSERT;   //신규 입력모드
        }

        /// <summary>
        /// DB업데이트 및 입력처리
        /// </summary>
        private void SaveData()
        {
            //빈값비교 NULL체크
            //저장은 UPDATE
            //string.IsNullOrEmpty(TxtIdx.Text) ||
            if (string.IsNullOrEmpty(TxtAuthor.Text) ||
                CboDivision.SelectedIndex < 2 ||
                string.IsNullOrEmpty(TxtNames.Text) ||
                string.IsNullOrEmpty(TxtIsbn.Text))

            {
                MetroMessageBox.Show(this, "빈 값은 넣을 수 없습니다.", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;     //void라서 return;
            }

            //if(myMode != BaseMode.INSERT || myMode != BaseMode.UPDATE)
            //{
            //    MetroMessageBox.Show(this, "신규등록시 신규버튼을 눌러주세요.", "알림",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                {
                    //conn 만들면 무조건 open,close
                    //using으로 쓰면 자동으로 해줌
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if(myMode == BaseMode.UPDATE)
                    {
                        cmd.CommandText = "UPDATE bookstbl " +
                                          "   SET Author        = @Author, " +
                                          "       Division      = @Division, " +
                                          "       Names         = @Names, " +
                                          "       ReleaseDate   = @ReleaseDate, " +
                                          "       ISBN          = @ISBN, " +
                                          "       Price         = @Price " +
                                          " WHERE Idx = @Idx ";
                    }
                    else if(myMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = "INSERT INTO bookstbl " + 
                                          " ( " +
                                          "Author, " +
                                          "Division, " +
                                          "Names, " +
                                          "ReleaseDate, " +
                                          "ISBN, " +
                                          "Price) " +
                                          "VALUES " +
                                          " ( " +
                                          "@Author, " +
                                          "@Division, " +
                                          "@Names, " +
                                          "@ReleaseDate, " +
                                          "@ISBN, " +
                                          "@Price) ";
                    }

                    //삭제버튼 false로 바꿈
                    //else if(myMode == BaseMode.DELETE)
                    //{
                    //    cmd.CommandText = "DELETE FROM divtbl " +
                    //                      " WHERE Division = @Division ";
                    //}

                    //if (myMode == BaseMode.INSERT || myMode == BaseMode.UPDATE)
                    //{
                    //    //DB랑 속성 맞춰주기
                    //    MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45);
                    //    paramNames.Value = TxtAuthor.Text;
                    //    cmd.Parameters.Add(paramNames);
                    //}

                    MySqlParameter paramAuthor = new MySqlParameter("@Author", MySqlDbType.VarChar, 45)
                    {
                        Value = TxtAuthor.Text
                    };
                    cmd.Parameters.Add(paramAuthor);

                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar, 4)
                    {
                        Value = CboDivision.SelectedValue
                    };
                    cmd.Parameters.Add(paramDivision);

                    MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 100)
                    {
                        Value = TxtNames.Text
                    };
                    cmd.Parameters.Add(paramNames);

                    MySqlParameter paramReleaseDate = new MySqlParameter("@ReleaseDate", MySqlDbType.Date)
                    {
                        Value = DtRealeasDate.Value
                    };
                    cmd.Parameters.Add(paramReleaseDate);

                    MySqlParameter paramISBN = new MySqlParameter("@ISBN", MySqlDbType.VarChar, 13)
                    {
                        Value = TxtIsbn.Text
                    };
                    cmd.Parameters.Add(paramISBN);

                    MySqlParameter paramPrice = new MySqlParameter("@Price", MySqlDbType.Decimal, 10)
                    {
                        Value = TxtPrice.Text
                    };
                    cmd.Parameters.Add(paramPrice);

                    if(myMode == BaseMode.UPDATE)
                    {
                        MySqlParameter paramIdx = new MySqlParameter("@Idx", MySqlDbType.Int32)
                        {
                            Value = TxtIdx.Text
                        };
                        cmd.Parameters.Add(paramIdx);
                    }

                    var result = cmd.ExecuteNonQuery();

                    if (myMode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다.", "신규입력");
                    }
                    else if(myMode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정되었습니다.", "수정");
                    }
                    //else if(myMode == BaseMode.DELETE)
                    //{
                    //    MetroMessageBox.Show(this, $"{result}건이 삭제되었습니다.", "삭제");
                    //}
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"에러발생 {ex.Message}", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateData();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            InitControls();
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            InitControls();
        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdBooksTbl.Rows[e.RowIndex];
                //TODO : 클릭 시 입력컨트롤에 데이터 할당
                TxtIdx.Text = data.Cells[0].Value.ToString();
                TxtAuthor.Text = data.Cells[1].Value.ToString();

                //장르 콤보박스
                //로맨스, 추리 등 디스플레이되는 글자로 인덱스찾기
                //CboDivision.SelectedIndex = CboDivision.FindString(data.Cells[3].Value.ToString());
                //코드값을 그대로 할당하는 방법 b001,b002
                CboDivision.SelectedValue = data.Cells[2].Value;

                TxtNames.Text = data.Cells[4].Value.ToString();

                //TODO : 출간일 날짜픽커Cells[5]
                DtRealeasDate.CustomFormat = "yyyy-MM-dd";
                DtRealeasDate.Format = DateTimePickerFormat.Custom;
                DtRealeasDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());


                TxtIsbn.Text = data.Cells[6].Value.ToString();
                TxtPrice.Text = data.Cells[7].Value.ToString();

                TxtIdx.ReadOnly = true;        //pk값 수정 못하게 막기
                TxtAuthor.Focus();

                myMode = BaseMode.UPDATE;   //수정모드 변경
            }
        }
    }
}
