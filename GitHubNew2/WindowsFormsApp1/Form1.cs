using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitHubNew2;

namespace WindowsFormsApp1
{
   

    public partial class Form1 : Form
    {
        List<ManUnited> squad = GitHubNew2.Program.GenerateList();
        List<ManUnited> squadStar = GitHubNew2.Program.GenerateList().Where(x => x.Attribute > 85).ToList();

        public Form1()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            comboBox1.DataSource = squad;
            comboBox1.DisplayMember = "Name";

            listBox1.DataSource = squad.Where(x => x.Attribute > 85).ToList();
            listBox1.DisplayMember = "Name";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        List<ManUnited> upSquad = new List<ManUnited>();

        private void button1_Click(object sender, EventArgs e)
        {

            
            ManUnited added = (ManUnited)comboBox1.SelectedItem;


            //upSquad = squad.Where(x => x.Attribute > 85).ToList();
            upSquad = squadStar;

            foreach (ManUnited player in squadStar)
            {
                if (player.Name == added.Name)
                {
                    return;
                }
            }
            upSquad.Add(added);

            listBox1.DataSource = upSquad.ToList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List<ManUnited> upSquad = new List<ManUnited>();

            int newIndex = listBox1.SelectedIndex - 1;

           
            upSquad = squadStar;
            ManUnited sel = (ManUnited)listBox1.SelectedItem;
            upSquad.Remove((ManUnited)listBox1.SelectedItem);
            listBox1.DataSource = upSquad.ToList();
        }
    }
}
