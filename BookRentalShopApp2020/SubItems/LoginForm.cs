using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class LoginForm : MetroForm
    {
        //private readonly string strConnectionString =
        //    "Data Source = localhost;" +
        //    "Port=3306;" +
        //    "Database=bookrentalshop;" +
        //    "Uid=root;" +
        //    "Password=mysql_p@ssw0rd";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void LoginProcess()
        {
            if(string.IsNullOrEmpty(TxtUserID.Text) || 
                string.IsNullOrEmpty(TxtPassword.Text))
            {
                MetroMessageBox.Show(this, "아이디나 패스워드를 입력하세요!", "로그인",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtUserID.Focus();
                return;
            }

            //if(TxtUserID.Text == "" || TxtUserID.Text == null ||
            //    TxtPassword.Text == null || TxtPassword.Text == "")
            //{
            //    MetroMessageBox.Show(this,"아이디나 패스워드를 입력하세요!", "로그인",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //실제 DB처리
            string resultId = string.Empty; //""

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))//strConnectionString
                {
                    conn.Open();
                    //MetroMessageBox.Show(this, $"DB접속성공!!");
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    //줄맞추기 중요
                    cmd.CommandText = "SELECT userID FROM userTBL " +
                                      " WHERE userID = @userID " +
                                      "   AND password = @password ";
                    MySqlParameter paramUserId = new MySqlParameter("@userID", MySqlDbType.VarChar, 12);
                    paramUserId.Value = TxtUserID.Text.Trim();
                    MySqlParameter paramPassword = new MySqlParameter("@password", MySqlDbType.VarChar);
                    paramPassword.Value = TxtPassword.Text.Trim();
                    //보안설정
                    var md5Hash = MD5.Create();
                    var cryptoPassword = Commons.GetMd5Hash(md5Hash, TxtPassword.Text.Trim());
                    paramPassword.Value = cryptoPassword;

                    cmd.Parameters.Add(paramUserId);
                    cmd.Parameters.Add(paramPassword);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if(!reader.HasRows)
                    {
                        MetroMessageBox.Show(this, "아이디나 패스워드를 정확히 입력하세요", "로그인실패",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //잘못 입력시 공간 비워줌
                        TxtUserID.Text = TxtPassword.Text = string.Empty;
                        TxtUserID.Focus();
                        return;
                    }
                    else
                    {
                        resultId = reader["userID"] != null ? reader["userID"].ToString() : string.Empty;
                        Commons.USERID = resultId;
                        MetroMessageBox.Show(this, $"{resultId} 로그인 성공");
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"DB접속에러 : {ex.Message}", "로그인에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(resultId))
            {
                MetroMessageBox.Show(this, "아이디나 패스워드를 정확히 입력하세요.", "로그인 실패",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUserID.Text = TxtPassword.Text = "";
                TxtUserID.Focus();
                return;
            }
            // resultID의 결과가 있는 경우 로그인창 종료
            else
            {
                this.Close();
            }

        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            //종료하는 법
            Environment.Exit(0);
        }

        private void TxtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) //e.KeyChar == 13 -> Enter
            {
                TxtPassword.Focus();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) //e.KeyChar == 13 -> Enter
            {
                BtnOK_Click(sender, new EventArgs());
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
