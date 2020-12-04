using System;
using System.Drawing;

using System.Windows.Forms;

namespace CalendarFull
{
    public partial class Calendar : Form
    {
        public Calendar()
        {
            InitializeComponent();
        }

        //ilk olaraq real vaxti almaq*****************
        int ay = DateTime.Now.Month;
        int il = DateTime.Now.Year;
                         
        private void Calendar_Load(object sender, EventArgs e)
        {
            this.Controls.Add(pEsas2);
            numAy.Value = ay;numIl.Value = il;
            // ilk défe kalendari yazmaq
            lay.Text =AyAdlari(ay, il);            
            lil.Text = DateTime.Now.Year.ToString();                  
            GunleriDuz(pEsas,ay,il);
        }

               
        // gunleri panele yazmaq*****************************
        private void GunleriDuz(Panel p, int ay,int il)
        {
            p.Controls.Clear();

            int endDay = DateTime.DaysInMonth(il, ay);
            DateTime time = new DateTime(il, ay, 1);
            int beginDay = (int)time.DayOfWeek;
            if (beginDay == 0) { beginDay = 7; }

            int a = -beginDay+1;
            int yenigun = 1;
            for (int i = 1; i <= 6; i++)
            {
                
                for (int j = 1; j <= 7; j++)
                {
                    a++;
                    Label l = new Label();
                    l.AutoSize = false;
                    l.Width = 40; l.Height = 40;
                    l.Font = new Font("Arial", 18, FontStyle.Bold);
                    l.ForeColor = Color.Red;
                    l.BackColor = Color.Transparent;
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.Left = (j-1) * 40; l.Top = (i-1) * 40;

                    
                    if (a > 0 && a <= endDay)
                    {
                        l.Text = a.ToString();
                        if (a==DateTime.Now.Day&&ay== DateTime.Now.Month&& il== DateTime.Now.Year)
                        {
                            l.ForeColor=Color.DarkBlue;
                        }
                        l.MouseEnter += L_MouseEnter;
                        l.MouseLeave += L_MouseLeave;
                        l.MouseDoubleClick += L_MouseDoubleClick;
                        p.Controls.Add(l);
                    }
                    else if(a>endDay){
                        l.Text = yenigun.ToString();
                        l.ForeColor = Color.Silver;
                        l.MouseClick += L_MouseClick;
                        yenigun ++;
                        p.Controls.Add(l);
                    }else if (a <= 0)
                    {
                        int yenAy = ay - 1;
                        if (yenAy == 0) yenAy = 12;
                        int m=DateTime.DaysInMonth(il,yenAy);                   
                        l.Text = (m  + a).ToString();
                        l.MouseClick += L_MouseClick1;
                        l.ForeColor = Color.Silver;
                        p.Controls.Add(l);
                    }
                    

                }
            }
        }

        //ayin adlarini yazmaq ve ayin son gunu teyin etmek              
        private string AyAdlari(int ay,int il)
        {
            string a = null;
            int m = 28;
            if (il%4==0){ m = 29; }
            
            switch (ay)
            {
                case 1: a = "yanvar";  break;
                case 2: a = "fevral";  break;
                case 3: a = "mart"; break;
                case 4: a = "aprel";  break;
                case 5: a = "may";  break;
                case 6: a = "iyun";  break;
                case 7: a = "iyul";  break;
                case 8: a = "avqust";  break;
                case 9: a = "sentyabr";  break;
                case 10: a = "oktyabr";  break;
                case 11: a = "noyabr";  break;
                case 12: a = "dekabr";  break;
                default:
                    break;
            }
            return a;
        }

        // cari ay ve teyin olunmus ay********************************
        private void bCariAy_Click(object sender, EventArgs e)
        {
            ay = DateTime.Now.Month - 1; il = DateTime.Now.Year;
            numAy.Value = ay;numIl.Value = il; ;
            Ireli();
        }

        private void bTarixeGet_Click(object sender, EventArgs e)
        {
            ay = (int)numAy.Value - 1;
            il = (int)numIl.Value;
            Ireli();
        }
        // ireli ay deyisme*********************************************
        int deyismee = 1;
        private void bireli_Click(object sender, EventArgs e)
        {
            Ireli();
        }
        private void L_MouseClick(object sender, MouseEventArgs e)
        {
            Ireli();
        }

        private void Ireli()
        {
            if (timer1.Enabled == false && timer2.Enabled == false)
            {
                ay += 1;
                if (ay == 13)
                {
                    ay = 1;
                    il += 1;
                }
                lay.Text = AyAdlari(ay, il);
                lil.Text = il.ToString();

                if (deyismee % 2 == 1)
                {
                    pEsas2.Left = 12;
                  //  pEsas2.Controls.Clear();
                    GunleriDuz( pEsas2,ay,il);
                    pEsas2.Visible = true;
                    pEsas2.SendToBack();
                    timer1.Start();
                }
                else
                {
                    pEsas.Left = 12;
                   // pEsas.Controls.Clear();
                    GunleriDuz( pEsas,ay,il);
                    pEsas.Visible = true;
                    pEsas.SendToBack();
                    timer1.Start();
                }

                deyismee++;
            }
        }

        //geri ay deyisme*****************************************
        private void bgeri_Click(object sender, EventArgs e)
        {
            Geri();
        }
        private void L_MouseClick1(object sender, MouseEventArgs e)
        {
            Geri();
        }

        private void Geri()
        {
            if (timer1.Enabled == false && timer2.Enabled == false)
            {
                ay -= 1;
                if (ay == 0)
                {
                    ay = 12;
                    il -= 1;
                }
                lay.Text = AyAdlari(ay, il);
                lil.Text = il.ToString();

                if (deyismee % 2 == 1)
                {
                    pEsas2.Left = 12;
                    //pEsas2.Controls.Clear();
                    GunleriDuz( pEsas2,ay,il);
                    pEsas2.Visible = true;
                    pEsas2.SendToBack();
                    timer2.Start();

                }
                else
                {
                    pEsas.Left = 12;
                    //pEsas.Controls.Clear();
                    GunleriDuz(pEsas,ay,il);
                    pEsas.Visible = true;
                    pEsas.SendToBack();
                    timer2.Start();
                }

                deyismee++;
            }
        }

        // ireli ucun timer****************************************
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (deyismee % 2 == 0)
            {
                pEsas.Left -= 16;
                if (pEsas.Left < -280)
                {
                    pEsas.Visible = false;
                    timer1.Stop();
                }
            }
            else
            {
                pEsas2.Left -= 16;
                if (pEsas2.Left < -280)
                {
                    pEsas2.Visible = false;
                    timer1.Stop();
                }

            }
        }

        //geri ucun timer********************************************
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (deyismee % 2 == 0)
            {
                pEsas.Left += 16;
                if (pEsas.Left > 300)
                {
                    pEsas.Visible = false;
                    timer2.Stop();
                }
            }
            else
            {
                pEsas2.Left += 16;
                if (pEsas2.Left > 300)
                {
                    pEsas2.Visible = false;
                    timer2.Stop();
                }

            }

        }
        
        // forumun hereketi*************************************
        int mos, mosX, mosY;
        private void Calendar_MouseDown(object sender, MouseEventArgs e)
        {
            mos = 1; mosX = e.X; mosY = e.Y;
        }

        private void Calendar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mos==1)
            {
                this.SetDesktopLocation(MousePosition.X - mosX, MousePosition.Y - mosY);
            }
            
        }
        private void Calendar_MouseUp(object sender, MouseEventArgs e)
        {
            mos = 0;
        }

        // gunun isiqlanmasi*********************************
        private void L_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Transparent;
        }        

        private void L_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Yellow;
        }
          
        
        // Stoping*********************************************
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //qeyd aparma********************************************
        private void L_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            ListViewItem v = new ListViewItem();
            v.SubItems[0].Text = il + "." + ay + "." + ((Label)sender).Text;
            v.SubItems.Add("Bura ucun qeyd yazan forum yazacam");
            lvQeydler.Items.Add(v);
        }


        //Qeydler*************************************************
        private void button2_Click(object sender, EventArgs e)
        {
            if (lvQeydler.Visible == false)
            {
                lvQeydler.Visible = true;
                button2.Text = "Qeydləri gizlə";
            }
            else
            {
                lvQeydler.Visible = false;
                button2.Text = "Qeydləri gösər";
            }
        }

        //Qeyd Silmek********************************************
        
    }
}
