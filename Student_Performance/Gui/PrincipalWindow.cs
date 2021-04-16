﻿using System;
using System.Windows.Forms;
using Student_Performance.Model;

namespace Student_Performance.Gui
{
    public partial class PrincipalWindow : Form
    {
        private DataManager manager = new DataManager();
        private string file;

        public PrincipalWindow()
        {
            InitializeComponent();
        }

        private void loadBT_Click(object sender, EventArgs e)
        {
            loadData.ShowDialog();
            string path = loadData.FileName;
            file = path;
            manager.createTable(path);

            if (manager.Table != null)
            {
                dataView.DataSource = manager.Table;
            }
        }

        private void maleButton_CheckedChanged(object sender, EventArgs e)
        {
            manager.filterBySex(file, "male");
        }

        private void femaleButton_CheckedChanged(object sender, EventArgs e)
        {
            manager.filterBySex(file, "female");
        }

        private void etniBox_SelectedIndexChanged(object sender, EventArgs e) => manager.filterByRace(file, etniBox.Text);

        private void parentBox_SelectedIndexChanged(object sender, EventArgs e) => manager.filterByPLevel(file, parentBox.Text);

        private void lunchBox_TextChanged(object sender, EventArgs e)
        {
            lunchBox.AutoCompleteCustomSource = loadLunchData();
            lunchBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            lunchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            OK1.Enabled = true;
        }

        private void testBox_TextChanged(object sender, EventArgs e)
        {
            testBox.AutoCompleteCustomSource = loadTestData();
            testBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            testBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            OK2.Enabled = true;
        }

        private AutoCompleteStringCollection loadLunchData()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            data.Add("standard");
            data.Add("free/reduced");

            return data;
        }

        private AutoCompleteStringCollection loadTestData()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            data.Add("none"); 
            data.Add("completed");

            return data;
        }

        private void OK1_Click(object sender, EventArgs e)
        {
            manager.filterByLunch(file, lunchBox.Text);
        }

        private void OK2_Click(object sender, EventArgs e)
        {
            manager.filterByTest(file,testBox.Text);
        }
    }
}
