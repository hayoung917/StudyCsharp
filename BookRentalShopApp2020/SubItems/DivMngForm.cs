using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class DivMngForm : MetroForm
    {
        readonly string strTblName = "divTbl";
        //DB작동시 무조건 필요
        //private readonly string strConnectionString =
        //   "Data Source = localhost;" +
        //   "Port=3306;" +
        //   "Database=bookrentalshop;" +
        //   "Uid=root;" +
        //   "Password=mysql_p@ssw0rd";

        BaseMode myMode = BaseMode.NONE;
        public DivMngForm()
        {
            InitializeComponent();
        }

        private void DivMngForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))//strConnectionString
            {
                //"SELECT Division, Names FROM divTbl "
                string strQuery = $"SELECT Division, Names FROM {strTblName}";
                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "divTbl");

                GrdDivTbl.DataSource = ds;
                GrdDivTbl.DataMember = "divTbl";
            }
            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            //데이터 그리드 뷰의 테이블 속성변경
            DataGridViewColumn column;
            column = GrdDivTbl.Columns[0];
            column.Width = 100;
            column.HeaderText = "구분코드";

            column = GrdDivTbl.Columns[1];
            column.Width = 150;
            column.HeaderText = "이름";
            
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
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.Focus();

            myMode = BaseMode.NONE;
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
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false;

            TxtDivision.Focus();

            //신규는 INSERT
            myMode = BaseMode.INSERT;   //신규 입력모드
        }

        /// <summary>
        /// DB업데이트 및 입력처리
        /// </summary>
        private void SaveData()
        {
            //저장은 UPDATE
            if (string.IsNullOrEmpty(TxtDivision.Text) || string.IsNullOrEmpty(TxtNames.Text))
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
                        cmd.CommandText = "UPDATE divtbl " +
                                          "   SET Names = @Names " +
                                          " WHERE Division = @Division ";  //UPDATE문
                    }
                    else if(myMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = "INSERT INTO " +
                                          "divtbl (Division, Names) "+
                                          "VALUES (@Division, @Names) ";
                    }

                    else if(myMode == BaseMode.DELETE)
                    {
                        cmd.CommandText = "DELETE FROM divtbl " +
                                          " WHERE Division = @Division ";
                    }

                    if(myMode == BaseMode.INSERT || myMode == BaseMode.UPDATE)
                    {
                        //DB랑 속성 맞춰주기
                        MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45);
                        paramNames.Value = TxtNames.Text;
                        cmd.Parameters.Add(paramNames);
                    }
                    
                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar);
                    paramDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(paramDivision);

                    var result = cmd.ExecuteNonQuery();

                    if(myMode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다.", "신규입력");
                    }
                    else if(myMode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정되었습니다.", "수정");
                    }
                    else if(myMode == BaseMode.DELETE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 삭제되었습니다.", "삭제");
                    }
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
                DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];
                TxtDivision.Text = data.Cells[0].Value.ToString();
                TxtNames.Text = data.Cells[1].Value.ToString();

                TxtDivision.ReadOnly = true;        //pk값 수정 못하게 막기
                TxtNames.Focus();

                myMode = BaseMode.UPDATE;   //수정모드 변경
            }
        }
    }
}
