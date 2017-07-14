using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Collections.Generic;

namespace COMPGIS1
{
    public partial class BPFindFeatureForm : Form
    {
        private int systemuse;
        private string _connectionstring = "";
        private int selectedid_int = 0;
        public int Selectedid_int
        {
            get { return selectedid_int; }
            set { selectedid_int = value; }
        }

        private string selectedid_str = "";
        public string Selectedid_str
        {
            get { return selectedid_str; }
            set { selectedid_str = value; }
        }

        private bool applytocurrentselection = false;

        public bool Applytocurrentselection
        {
            get { return applytocurrentselection; }
            set { applytocurrentselection = value; }
        }



        public BPFindFeatureForm(LayerSystemUse layersystemuse, string connectionstring)
        {
            InitializeComponent();
            systemuse = (int)layersystemuse;
            _connectionstring = connectionstring;
        }


        //............................................
        //............................................
        private void BPFindFeatureForm_Load(object sender, EventArgs e)
        {
            switch (systemuse)
            {
                case 1: // Lines

                    LoadBPLines();
                    break;

                case 2: // Line Sections
                    break;

                case 3: // Boring Locations
                    break;

                case 4: // Corrosion Probes
                    break;

                case 5: // Rectifiers
                    break;

                case 6: // Test Stations
                    break;

                case 7: // Monitoring Wells
                    break;

            }
        }


        //............................................
        //............................................
        public bool LoadBPLines() 
        {
            Text = "Find Features - [Line]";

            // Load Lines
            string queryString = "SELECT [Dbf Lines].[LineID], [Dbf Line].[Line] FROM [Dbf Lines]";
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(queryString, _connectionstring);
            DataTable dTable = new DataTable();

            //fill the DataTable
            dAdapter.Fill(dTable);
            //the DataGridView
            //DataGridView dgView = new DataGridView();
            BindingSource bSource = new BindingSource();

            bSource.DataSource = dTable;
            gridFeatures.DataSource = bSource;
            gridFeatures.Columns["LineID"].Visible = false;
            return false;
        }


    }
}


