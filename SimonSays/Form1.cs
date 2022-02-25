using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

namespace SimonSays
{
   
    public partial class Form1 : Form
    {
        //TODO: create a List to store the pattern. Must be accessable on other screens
        public static List<int> playerInput = new List<int>();

        


        public Form1()
        {
            InitializeComponent();
        }
        public static void ChangeScreen(UserControl current, UserControl next)

        {

            Form f = current.FindForm();

            f.Controls.Remove(current);



            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,

                (f.ClientSize.Height - next.Height) / 2);



            next.Focus();

            f.Controls.Add(next);



        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Launch MenuScreen
            MenuScreen ms = new MenuScreen();


            this.Controls.Add(ms);
            ms.Location = new Point((ClientSize.Width - ms.Width) / 2,
                (ClientSize.Height - ms.Height) / 2);


            this.Controls.Add(ms);
            ms.Focus();
        }
    }
}
