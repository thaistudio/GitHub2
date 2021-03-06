﻿using System;
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
        List<ManUnited> squadStar = GitHubNew2.Program.GenerateList().Where(x => x.Attribute > 75).ToList();
        List<ManUnited> squad2 = GitHubNew2.Program.GenerateList();
        List<ManUnited> squadChanged = GitHubNew2.Program.GenerateList();
        int row;
        int col;

        public Form1()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            comboBox1.DataSource = squad;
            comboBox1.DisplayMember = "Name";

            listBox1.DataSource = squadStar;
            listBox1.DisplayMember = "Name";

            foreach (ManUnited player in squad)
            {
                var row = new string[] { player.Name, player.Number.ToString(), player.Attribute.ToString() };
                ListViewItem list = new ListViewItem(row);
                listView1.Items.Add(list);
            }

            dataGridView1.DataSource = squad;
            

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
            int newIndex = listBox1.SelectedIndex - 1;
                       
            upSquad = squadStar;
            ManUnited sel = (ManUnited)listBox1.SelectedItem;

            string st = sel.Name;

            if (newIndex == -1)
            {
                return;
            }
            upSquad.Remove(sel);
            upSquad.Insert(newIndex, sel);
            
            listBox1.DataSource = upSquad.ToList();
            listBox1.SetSelected(newIndex, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int newIndex = listBox1.SelectedIndex + 1;

            upSquad = squadStar;
            ManUnited sel = (ManUnited)listBox1.SelectedItem;

            string st = sel.Name;

            if (newIndex >= upSquad.Count)
            {
                return;
            }
            upSquad.Remove(sel);
            upSquad.Insert(newIndex, sel);

            listBox1.DataSource = upSquad.ToList();
            listBox1.SetSelected(newIndex, true);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (ManUnited player in squadChanged)
            {
                    var row = new string[] { player.Name, player.Number.ToString(), player.Attribute.ToString() };
                    ListViewItem list = new ListViewItem(row);
                    
                    listView1.Items.Add(list);
            }
            
        }


        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
            var val = dataGridView1.SelectedCells[0].Value.ToString();
            
            var val2 = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            squadChanged.RemoveAt(row);
            squadChanged.Insert(row, new ManUnited()
            {
                Name = dataGridView1[0, e.RowIndex].Value.ToString(),
                Number = Convert.ToInt32(dataGridView1[1, e.RowIndex].Value),
                Attribute = Convert.ToInt32(dataGridView1[2, e.RowIndex].Value)
            });

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<ManUnited> originSquad = GitHubNew2.Program.GenerateList();
            listView1.Items.Clear();
            foreach (ManUnited player in originSquad)
            {
                var row = new string[] { player.Name, player.Number.ToString(), player.Attribute.ToString() };
                ListViewItem list = new ListViewItem(row);

                listView1.Items.Add(list);
                dataGridView1.DataSource = originSquad;
            }
        }
    }
}
