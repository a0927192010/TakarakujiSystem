using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5大樂透
{
    public partial class Form1 : Form
    {
        bool sball = true;
        int timess = 0;
        int[] lotte;
        int[] number;
        Random ran = new Random();
        bool 開彩 = true;

        public Form1()
        {
            InitializeComponent();
        }
        private void 開彩Open(int a, int b)
        {
            lotte = new int[a - 1]; //共39個號碼
            for (int i = 0; i <= lotte.GetUpperBound(0); i++)
            {
                lotte[i] = i + 1;
            }

            number = new int[b]; //產生陣列,放入開獎的五個號碼
            Random r = new Random();
            for (int for4 = 0; for4 <= number.GetUpperBound(0); for4++) //生成五個號碼
            {

                int t = r.Next(1, a - 1);
                if (lotte[t] == 0)
                {

                    for4--; //如果是0表示已經用過 重新產生.
                }
                else
                {

                    number[for4] = lotte[t];
                    lotte[t] = 0;//開出的號碼設為0,以便偵測是否為重複號碼
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void btn威力_Click(object sender, EventArgs e)
        {
            timess = 0;
            排序號1.Text = "";
            排序號2.Text = "";
            排序號3.Text = "";
            排序號4.Text = "";
            排序號5.Text = "";
            二區號.Text = "";
            sball = true;
            開彩Open(49, 5);
            timer1.Enabled = true;


        }

        private void btn樂合_Click(object sender, EventArgs e)
        {
            timess = 0;
            排序號1.Text = "";
            排序號2.Text = "";
            排序號3.Text = "";
            排序號4.Text = "";
            排序號5.Text = "";
            排序號6.Text = "";
            二區號.Text = "";
            timer1.Enabled = true;
            sball = false;
            開彩Open(39, 5);

        }

        private void btn四星_Click(object sender, EventArgs e)
        {
            timess = 0;
            timer2.Enabled = true;

            int[] number = new int[4];
            Random r = new Random();
            for (int for4 = 0; for4 <= number.GetUpperBound(0); for4++)
            {
                int nine = r.Next(0, 9);
                number[for4] = nine;
            }

            四星1.Text = number[0].ToString();
            四星2.Text = number[1].ToString();
            四星3.Text = number[2].ToString();
            四星4.Text = number[3].ToString();
            開彩 = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timess++;
            if (timess < 20)
            {
                號碼1.Text = string.Format("{0:00} ", ran.Next(1, 49));
                號碼2.Text = string.Format("{0:00} ", ran.Next(1, 49));
                號碼3.Text = string.Format("{0:00} ", ran.Next(1, 49));
                號碼4.Text = string.Format("{0:00} ", ran.Next(1, 49));
                號碼5.Text = string.Format("{0:00} ", ran.Next(1, 49));
                號碼6.Text = string.Format("{0:00} ", ran.Next(1, 49));
                if (sball)
                {
                    二區號.Text = String.Format("{0:00} ", ran.Next(1, 49));
                }
            }
            if (timess == 20)
            {
                號碼1.Text = String.Format("{0:00} ", number[0]);
                號碼2.Text = String.Format("{0:00} ", number[1]);
                號碼3.Text = String.Format("{0:00} ", number[2]);
                號碼4.Text = String.Format("{0:00} ", number[3]);
                號碼5.Text = String.Format("{0:00} ", number[4]);

                //特別號產生
                if (sball)
                {
                    Random aaa = new Random();
                    int special = aaa.Next(1, 49);
                    二區號.Text = String.Format("{0:00} ", special);
                }
                if (timess > 26)
                {                //小到大排序
                    Array.Sort(number);
                    排序號1.Text = String.Format("{0:00} ", number[0]);
                    排序號2.Text = String.Format("{0:00} ", number[1]);
                    排序號3.Text = String.Format("{0:00} ", number[2]);
                    排序號4.Text = String.Format("{0:00} ", number[3]);
                    排序號5.Text = String.Format("{0:00} ", number[4]);
                    timer1.Enabled = false;
                }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timess++;
            if (timess < 20)
            {
                四星4.Text = string.Format("{0} ", ran.Next(1, 9));
                四星3.Text = string.Format("{0} ", ran.Next(1, 9));
                四星2.Text = string.Format("{0} ", ran.Next(1, 9));
                四星1.Text = string.Format("{0} ", ran.Next(1, 9));
            }
            if (timess == 20)
            {
                timer2.Enabled = false;
            }
        }

        private void 排序號3_Click(object sender, EventArgs e)
        {

        }
    }
}

