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
        
        public BPFindFeatureForm(LayerSystemUse layersystemuse)
        {
            InitializeComponent();
            switch ((int)layersystemuse) 
            {
                case 1: // Lines

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
        public bool LoadBPLines() 
        {

            return false;
        }



    }
}


