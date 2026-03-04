using MegaGS.DTO;
using MegaGS.GUI.Admin.Customer;
using MegaGS.GUI.Admin.Employee;
using MegaGS.GUI.Admin.Genre;
using MegaGS.GUI.Admin.Movie;
using MegaGS.GUI.Admin.Product;
using MegaGS.GUI.Admin.Showtime;
using MegaGS.GUI.Admin.Statistic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MegaGS
{
    public partial class fMain : Form
    {
        EmployeeDTO employee;

        fMovie fMovie;
        fShowtimes fShowtime;
        fGenre fGenre;
        fProduct fProduct;
        fCustomer fCustomer;
        fEmployee fEmployee;
        fStatistic fStatistic;
        public fMain(EmployeeDTO e)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.employee = e;
            mdiProp();

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(picHelp, "Hướng dẫn sử dụng");

            txtName.Text = employee.HoNV + " " + employee.TenNV;

            foreach (Control control in flpSidebarTransition.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.Click += Button_Click;
                }
            }
        }

        private void picHelp_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void picHelp_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        #region Methods
        private void mdiProp()
        {
            this.SetBevel(false);
            var mdiClient = Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdiClient != null)
            {
                mdiClient.BackColor = Color.FromArgb(232, 234, 237);
            }
            else
            {
                // Có thể ghi log hoặc xử lý nếu cần
                Console.WriteLine("Không tìm thấy MdiClient.");
            }
        }


        private void ResizeSidebarButtons(int width)
        {
            btnMovie.Width = width;
            btnShowTime.Width = width;
            btnGenre.Width = width;
            btnLogout.Width = width;
        }
        #endregion

        #region Events
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            foreach (Control control in flpSidebarTransition.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.BackColor = Color.Goldenrod;
                }
            }
        }

        private void picMenu_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void picMenu_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        bool sidebarExpand = true;
        private void tmrSidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                flpSidebarTransition.Width -= 5;
                if (flpSidebarTransition.Width <= 45)
                {
                    sidebarExpand = false;
                    tmrSidebarTransition.Stop();
                    ResizeSidebarButtons(flpSidebarTransition.Width);
                }
            }
            else
            {
                flpSidebarTransition.Width += 5;
                if (flpSidebarTransition.Width >= 230)
                {
                    sidebarExpand = true;
                    tmrSidebarTransition.Stop();
                    ResizeSidebarButtons(flpSidebarTransition.Width);
                }
            }
        }

        private void picMenu_Click(object sender, EventArgs e)
        {
            tmrSidebarTransition.Start();
        }

        private void btnMovie_Click(object sender, EventArgs e)
        {
            if (fMovie == null)
            {
                fMovie = new fMovie();
                fMovie.FormClosed += fMovie_FormClosed;
                fMovie.MdiParent = this;
                fMovie.Dock = DockStyle.Fill;
                fMovie.Show();
            }
            else
            {
                fMovie.Activate();
            }
        }

        private void fMovie_FormClosed(object sender, FormClosedEventArgs e)
        {
            fMovie = null;
        }

        private void btnGenre_Click(object sender, EventArgs e)
        {
            if (fGenre == null)
            {
                fGenre = new fGenre();
                fGenre.FormClosed += fGenre_FormClosed;
                fGenre.MdiParent = this;
                fGenre.Dock = DockStyle.Fill;
                fGenre.Show();
            }
            else
            {
                fGenre.Activate();
            }
        }

        private void fGenre_FormClosed(object sender, FormClosedEventArgs e)
        {
            fGenre = null;
        }

        private void btnShowTime_Click(object sender, EventArgs e)
        {
            if (fShowtime == null)
            {
                fShowtime = new fShowtimes();
                fShowtime.FormClosed += fShowtime_FormClosed;
                fShowtime.MdiParent = this;
                fShowtime.Dock = DockStyle.Fill;
                fShowtime.Show();
            }
            else
            {
                fShowtime.Activate();
            }
        }

        private void fShowtime_FormClosed(object sender, FormClosedEventArgs e)
        {
            fShowtime = null;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (fProduct == null)
            {
                fProduct = new fProduct();
                fProduct.FormClosed += fProduct_FormClosed;
                fProduct.MdiParent = this;
                fProduct.Dock = DockStyle.Fill;
                fProduct.Show();
            }
            else
            {
                fProduct.Activate();
            }
        }

        private void fProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            fProduct = null;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (fCustomer == null)
            {
                fCustomer = new fCustomer();
                fCustomer.FormClosed += fCustomer_FormClosed;
                fCustomer.MdiParent = this;
                fCustomer.Dock = DockStyle.Fill;
                fCustomer.Show();
            }
            else
            {
                fCustomer.Activate();
            }
        }

        private void fCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            fCustomer = null;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (fEmployee == null)
            {
                fEmployee = new fEmployee();
                fEmployee.FormClosed += fEmployee_FormClosed;
                fEmployee.MdiParent = this;
                fEmployee.Dock = DockStyle.Fill;
                fEmployee.Show();
            }
            else
            {
                fEmployee.Activate();
            }
        }

        private void fEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            fEmployee = null;
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            if (fStatistic == null)
            {
                fStatistic = new fStatistic();
                fStatistic.FormClosed += fStatistic_FormClosed;
                fStatistic.MdiParent = this;
                fStatistic.Dock = DockStyle.Fill;
                fStatistic.Show();
            }
            else
            {
                fStatistic.Activate();
            }
        }

        private void fStatistic_FormClosed(object sender, FormClosedEventArgs e)
        {
            fStatistic = null;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void picHelp_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn đến file hướng dẫn sử dụng (có thể là .doc hoặc .docx)
                string helpFilePath = Application.StartupPath + @"\HuongDanSuDung.docx";

                if (System.IO.File.Exists(helpFilePath))
                {
                    System.Diagnostics.Process.Start(helpFilePath);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file hướng dẫn sử dụng.\nVui lòng kiểm tra lại đường dẫn hoặc tên file.",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi mở file hướng dẫn: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }



        }
    }
}

