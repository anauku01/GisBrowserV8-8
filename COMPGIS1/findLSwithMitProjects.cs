using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace COMPGIS1
{
    public partial class findLSwithMitProjects : Form
    {

        private int _retmode = 1; // 1 = All;2 = WIthout Projects;3 = specific project (get projectid)
        private int _projectid = 1;
        private string _connectionstring = "";
        private bool _applytocurrentselection = false;
        private bool _enableapplytocurrent = true;
        private List<int> projectidlist = new List<int>();

        public int Retmode
        {
            get { return _retmode; }
        }
        public int Projectid
        {
            get { return _projectid; }
        }

        public bool Applytocurrentselection
        {
            get { return _applytocurrentselection; }
        }


        //-----------------------------------------------------------------------------------
        // Contructor
        //-----------------------------------------------------------------------------------
        public findLSwithMitProjects(string connectionstring, bool enableapplytocurrent = true)
        {
            InitializeComponent();
            _connectionstring = connectionstring;
            _enableapplytocurrent = enableapplytocurrent;
            LoadFormData();
        }

        //-----------------------------------------------------------------------------------
        // Get Field Data from the Reader
        //-----------------------------------------------------------------------------------
        private string GetFieldDataStr(string DataFieldName, ref OleDbDataReader rdr)
        {
            int idx = rdr.GetOrdinal(DataFieldName);
            if (idx >= 0)
                return rdr[idx].ToString();
            else
                return "";
        }


        //-----------------------------------------------------------------------------------
        // Get Field Data from the Reader
        //-----------------------------------------------------------------------------------
        private int GetFieldDataInt(string DataFieldName, ref OleDbDataReader rdr)
        {
            int retval = -1;
            try
            {
                int idx = rdr.GetOrdinal(DataFieldName);
                if (idx >= 0)
                    retval = Convert.ToInt32(rdr[idx].ToString());
            }
            finally
            {
            }
            return retval;
        }


        //-----------------------------------------------------------------------------------
        // LoadFormData
        //-----------------------------------------------------------------------------------
        private bool LoadFormData()
        {
            bool ismitproj = false;
            int lineclasslookupid = -1;
            string queryString = "";
            OleDbCommand command;
            OleDbDataReader reader;
            OleDbConnection connection = new OleDbConnection(_connectionstring);

            // Load Mitigation Projecs (if any)
            if (connection != null)
            {
                connection.Open();

                queryString =
                    "SELECT [Dbf Mitigation Projects].ID, [Dbf Mitigation Projects].IsMitigation, [Dbf Mitigation Projects].[Project Name], [Dbf Mitigation Projects].[LCM Engage ID], " +
                    "[Dbf Mitigation Projects].[Mitigation Project Types], [Dbf Mitigation Projects].[Bridging Strategy Types], [Dbf Mitigation Projects].[Start Date], [Dbf Mitigation Projects].[End Date], " +
                    "[Dbf Mitigation Projects].[PHC/PRC Status], [Dbf Mitigation Projects].Comment FROM [Dbf Mitigation Projects]";

                command = new OleDbCommand(queryString, connection);
                int val = 0;
                try
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Fill in controls from the Lines Table
                        cboxProjects.Items.Add(GetFieldDataStr("Project Name",ref reader));
                        val = GetFieldDataInt("ID",ref reader);
                        if (val > 0)
                        {
                            projectidlist.Add(val);                            
                        }
                        reader.NextResult();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return false;
                }
                connection.Close();
            } // if connection!=null
            cboxProjects.SelectedIndex = -1;
            SetControls();
            return true;
        } // loadformdata  


        //-----------------------------------------------------------------------------------
        // User Changed Apply to Selection Checkbox
        //-----------------------------------------------------------------------------------
        private void cbApplyToSelection_CheckedChanged(object sender, EventArgs e)
        {
            _applytocurrentselection = cbApplyToSelection.Checked;
        }


        //-----------------------------------------------------------------------------------
        // Sets Controls on the form 
        //-----------------------------------------------------------------------------------
        private void SetControls()
        {
            cboxProjects.Enabled = (rbAssignedSpecific.Checked);
            btnOK.Enabled = ((rbAssignedSpecific.Checked && (cboxProjects.SelectedIndex >= 0)) || (!rbAssignedSpecific.Checked));
        }

        //-----------------------------------------------------------------------------------
        // Sets returnmode
        //-----------------------------------------------------------------------------------
        private void rbAssignedSpecific_CheckedChanged(object sender, EventArgs e)
        {

            if (rbAssignedToAny.Checked)
                _retmode = 1;
            else if (rbNotAssigned.Checked)
                _retmode = 2;
            else
                _retmode = 3;
            SetControls();
        }
    } 
}
