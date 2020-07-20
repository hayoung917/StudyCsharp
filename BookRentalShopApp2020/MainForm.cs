using BookRentalShopApp2020.SubItems;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace BookRentalShopApp2020
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();

            LbUserID.Text = $"LOGIN : {Commons.USERID}";
        }

        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            var result = MetroMessageBox.Show(this, "종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 위의 메세지 박스에서 Yes 버튼을 누른 경우 실행 -> 종료
            if (result == DialogResult.Yes)
            {
                // 위에서 발생한 메세지박스 이벤트(종료)의 캔슬을 하지 않음 -> 실행
                e.Cancel = false;
                Environment.Exit(0);         // 완전 종료
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void MnuItemExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MnuItemCodeMng_Click(object sender, EventArgs e)
        {
            DivMngForm form = new DivMngForm();
            ShowFormControl(form,"구분코드관리");
        }

        private void MnuItemBooksMng_Click(object sender, EventArgs e)
        {
            BooksMngForm form = new BooksMngForm();
            ShowFormControl(form,"도서관리");
        }

        private void MnuItemmemberMng_Click(object sender, EventArgs e)
        {
            MemberMngForm form = new MemberMngForm();
            ShowFormControl(form, "멤버관리");
        }

        private void MnuItemRentalMng_Click(object sender, EventArgs e)
        {
            RentalMngForm form = new RentalMngForm();
            ShowFormControl(form, "대여관리");
        }

        private void MnuItemUserMng_Click(object sender, EventArgs e)
        {
            //RentalMngForm form = new RentalMngForm();
            //ShowFormControl(form, "사용자관리");
        }

        private void ShowFormControl(Form form, string title)
        {
            form.MdiParent = this;
            form.Text = title;
            form.Dock = DockStyle.Fill;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }
    }
}
