using Google.Protobuf.WellKnownTypes;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class RentalMngForm : MetroForm
    {
        #region 멤버변수 영역
        readonly string strTblName = "membertbl";
        //DB작동시 무조건 필요
        //private readonly string strConnectionString =
        //   "Data Source = localhost;" +
        //   "Port=3306;" +
        //   "Database=bookrentalshop;" +
        //   "Uid=root;" +
        //   "Password=mysql_p@ssw0rd";

        BaseMode myMode = BaseMode.NONE;    //기본

        #endregion

        #region 생성자 영역
        public RentalMngForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 이벤트핸들러
        private void DivMngForm_Load(object sender, EventArgs e)
        {
            UpdateComboMember();
            UpdateComboBook();
            UpdateData();

            InitControls();
        }

        private void UpdateComboBook()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))//strConnectionString
            {
                string strQuery = $"SELECT b.Idx, b.Names, " +
                                   " (SELECT Names FROM divtbl WHERE Division = b.Division) AS Division " +
                                   "FROM bookstbl AS b ";
                
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");
                while (reader.Read())
                {
                    //DB데이터 가져오기
                    temps.Add($"[{reader[2]}] {reader[1]}", $"{reader[0]}");
                    
                }
                CboBook.DataSource = new BindingSource(temps, null);
                CboBook.DisplayMember = "Key";
                CboBook.ValueMember = "Value";
                //CboBook.SelectedIndex = 0;  //처음값에 선택이 들어가있어서 -1이 아닌 0
            }
        }
        #endregion

        #region 커스텀영역
        private void UpdateComboMember()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))//strConnectionString
            {
                string strQuery = $"SELECT Idx, Names FROM membertbl ";
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

                ////comboBox A, B, C, D 위의 방법과 같음
                //var keyValues = new Dictionary<string, string>();
                //keyValues.Add("선택", "");
                //keyValues.Add("A", "A");
                //keyValues.Add("B", "B");
                //keyValues.Add("C", "C");
                //keyValues.Add("D", "D");

                //CboLvDivision.DataSource = new BindingSource(keyValues, null);
                //CboLvDivision.DisplayMember = "Key";        //필수
                //CboLvDivision.ValueMember = "Value";

                CboMember.DataSource = new BindingSource(temps, null);
                CboMember.DisplayMember = "Key";
                CboMember.ValueMember = "Value";
                CboMember.SelectedIndex = 0;  //처음값에 선택이 들어가있어서 -1이 아닌 0
            }
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))//strConnectionString
            {
                string strQuery = $"SELECT r.idx AS '대여번호', " +
                                   "       m.Names AS '대여회원', " +
                                   "       b.Names AS '대여책제목', " +
                                   "       b.ISBN, " +
                                   "       r.rentalDate AS '대여일', " +
                                   "       r.returnDate AS '반납일', " +
                                   "       r.memberIdx, " +
                                   "       r.bookIdx " +
                                   "  FROM rentaltbl AS r " +
                                   "INNER JOIN " +
                                   "       membertbl AS m ON r.memberIdx = m.Idx " +
                                   "INNER JOIN " +
                                   "       bookstbl AS b ON r.bookIdx = b.Idx ";
                
                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "memberTbl");

                GrdRentalTbl.DataSource = ds;
                GrdRentalTbl.DataMember = "memberTbl";
            }
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            //데이터 그리드 뷰의 테이블 속성변경
            DataGridViewColumn column;
            column = GrdRentalTbl.Columns[0];
            column.Width = 50;
            column.HeaderText = "번호";

            column = GrdRentalTbl.Columns[1];
            column.Width = 90;
            column.HeaderText = "회원";

            column = GrdRentalTbl.Columns[2];
            column.Width = 150;
            column.HeaderText = "책";

            column = GrdRentalTbl.Columns[3];
            column.Width = 150;
            column.HeaderText = "ISBN";

            column = GrdRentalTbl.Columns[4];   //대여일
            column.Width = 90;

            column = GrdRentalTbl.Columns[5];   //반납일
            column.Width = 90;

            column = GrdRentalTbl.Columns[6];
            column.Visible = false;

            column = GrdRentalTbl.Columns[7];
            column.Visible = false;
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
            TxtIdx.Text = string.Empty;
            TxtIdx.Focus();
            TxtIdx.ReadOnly = true;

            CboMember.SelectedIndex = CboBook.SelectedIndex = 0;

            DtpRentalDate.CustomFormat = "yyyy-MM-dd";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;
            DtpRentalDate.Value = DateTime.Now;

            //빈값을 넣으려면 비워주기 (반납일)
            DtpReturnDate.CustomFormat = " ";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;

            TxtIdx.ReadOnly = true;
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
            InitControls();
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
            //if (string.IsNullOrEmpty(TxtNames.Text) ||
            //    CboBook.SelectedIndex < 1 ||
            //    string.IsNullOrEmpty(TxtAddr.Text) ||
            //    string.IsNullOrEmpty(TxtMobile.Text) ||
            //    string.IsNullOrEmpty(TxtEmail.Text))
            //{
            //    MetroMessageBox.Show(this, "빈 값은 넣을 수 없습니다.", "오류",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;     //void라서 return;
            //}

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
                        cmd.CommandText = "UPDATE rentaltbl " +
                                          "   SET " + 
                                          "       memberIdx = @memberIdx, " +
                                          "       bookIdx = @bookIdx, " + 
                                          "       rentalDate = @rentalDate, " +
                                          "       returnDate = @returnDate " +
                                          " WHERE Idx = @Idx ";
                        ;

                    }
                    else if(myMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = "INSERT INTO rentaltbl " +
                                          "(           memberIdx, " +
                                          "            bookIdx, " +
                                          "            rentalDate, " +
                                          "            returnDate) " +
                                          "VALUES " +
                                          "( " +
                                          "            @memberIdx, " +
                                          "            @bookIdx, " +
                                          "            @rentalDate, " +
                                          "            @returnDate " +
                                          ") ";
;
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

                    MySqlParameter paramMemberIdx = new MySqlParameter("@memberIdx", MySqlDbType.Int32);
                    paramMemberIdx.Value = CboMember.SelectedValue;
                    cmd.Parameters.Add(paramMemberIdx);

                    MySqlParameter parambookIdx = new MySqlParameter("@bookIdx", MySqlDbType.Int32);
                    parambookIdx.Value = CboBook.SelectedValue;
                    cmd.Parameters.Add(parambookIdx);

                    MySqlParameter paramrentalDate = new MySqlParameter("@rentalDate", MySqlDbType.Date);
                    paramrentalDate.Value = DtpRentalDate.Value;
                    cmd.Parameters.Add(paramrentalDate);

                    MySqlParameter paramreturnDate = new MySqlParameter("@returnDate", MySqlDbType.Date);
                    if (myMode == BaseMode.INSERT)
                        paramreturnDate.Value = null;
                    else
                        paramreturnDate.Value = DtpReturnDate.Value;
                    cmd.Parameters.Add(paramreturnDate);

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

        #endregion

        private void GrdRentalTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                // (e)이벤트가 발생한 Row의 모든 값들을 가져온다.
                DataGridViewRow data = GrdRentalTbl.Rows[e.RowIndex];

                // 텍스트 박스에 값을 출력한다.
                // 위에서 생성한 ColumnHeader의 순서에 맞춰서 설정한다.
                TxtIdx.Text = data.Cells[0].Value.ToString();
                CboMember.SelectedValue = data.Cells[6].Value.ToString();
                CboBook.SelectedValue = data.Cells[7].Value.ToString();
                DtpRentalDate.Value = DateTime.Parse(data.Cells[4].Value.ToString());

                if (string.IsNullOrEmpty(data.Cells[5].Value.ToString())!= true)
                {
                    DtpReturnDate.CustomFormat = "yyyy-MM-dd";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                    DtpReturnDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());
                }
                else
                {
                    DtpReturnDate.CustomFormat = " ";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                }
                myMode = BaseMode.UPDATE;   //수정모드 변경
            }
        }

        private void DtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            //날짜 클릭했을때
            DtpReturnDate.CustomFormat = "yyyy-MM-dd";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;
        }

        //Excel로 값 보내기
        private void BtnExcelExport_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = new HSSFWorkbook();//xls //XSSFWorkbook(); ->XLSX확장자
            ISheet sheet1 = workbook.CreateSheet("sheet1");
            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Rental Book Data");
            int x = 1;

            DataSet ds = GrdRentalTbl.DataSource as DataSet;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i);
                for (int j = 0; j < ds.Tables[0].Rows[0].ItemArray.Length; j++)
                {
                    if(j==4||j==5)
                    {
                        var value = string.IsNullOrEmpty(ds.Tables[0].Rows[i].ItemArray[j].ToString()) ? "" : ds.Tables[0].Rows[i].ItemArray[j].ToString().Substring(0, 10);
                        row.CreateCell(j).SetCellValue(value);
                    }
                    else if(j > 5)
                    {
                        break;
                    }
                    else
                    {
                        row.CreateCell(j).SetCellValue(ds.Tables[0].Rows[i].ItemArray[j].ToString());
                    }
                }
            }
            FileStream file = File.Create(Environment.CurrentDirectory + $@"\export.xls");
            workbook.Write(file);
            file.Close();

            MessageBox.Show("Export done!!");
        }
    }
}
