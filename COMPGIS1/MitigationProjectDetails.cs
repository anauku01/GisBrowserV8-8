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
    public partial class formMitigationProjectDetails : Form
    {
        private string _connectionstring = "";
        private int _projectid = 0;
        
        //-----------------------------------------------------------------------------------
        // Contructor
        //-----------------------------------------------------------------------------------
        public formMitigationProjectDetails(int Project_ID, string connectionstring)
        {
            InitializeComponent();
            _connectionstring = connectionstring;
            if (_connectionstring.Length > 0)
            {
                _projectid = Project_ID;
                LoadFormData(_projectid);
                this.Text = "Project Details - [" + edProjectName.Text + "]";
            }
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
        // Load the Form Data
        //-----------------------------------------------------------------------------------
        public int LoadFormData(int Project_ID)
        {
            bool ismitproj = false;
            int lineclasslookupid = -1;
            string queryString = "";
            OleDbCommand command;
            OleDbDataReader reader;
            OleDbConnection connection = new OleDbConnection(_connectionstring);

            if (connection != null)
            {
                connection.Open();
                queryString =
                    "SELECT [Dbf Mitigation Projects].ID, [Dbf Mitigation Projects].IsMitigation, [Dbf Mitigation Projects].[Project Name], " +
                    "[Dbf Mitigation Projects].[LCM Engage ID], [Dbf Mitigation Projects].[Mitigation Project Types], [Dbf Mitigation Projects].[Bridging Strategy Types], " +
                    "[Dbf Mitigation Projects].[Start Date], [Dbf Mitigation Projects].[End Date], [Dbf Mitigation Projects].[PHC/PRC Status], [Dbf Mitigation Projects].Comment " +
                    "FROM [Dbf Mitigation Projects] WHERE ((([Dbf Mitigation Projects].ID)="+ Project_ID.ToString() + "))";
                command = new OleDbCommand(queryString, connection);
                try
                {
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Fill in controls from the Lines Table
                        edProjectName.Text = GetFieldDataStr("Project Name", ref reader);
                        edLCMEngageID.Text = GetFieldDataStr("LCM Engage ID", ref reader);
                        edPHCPRCStatus.Text = GetFieldDataStr("PHC/PRC Status", ref reader);
                        edComment.Text = GetFieldDataStr("Comment", ref reader);
                        edStartDate.Text = GetFieldDataStr("Start Date", ref reader);
                        edEndDate.Text = GetFieldDataStr("End Date", ref reader);

                        // Set project type radio buttons
                        ismitproj = (Convert.ToBoolean(GetFieldDataStr("IsMitigation", ref reader)));
                        if (ismitproj)
                        {
                            rbMitProject.Checked = true;
                            edProjectType.Text = GetFieldDataStr("Mitigation Project Types", ref reader);
                        }
                        else
                        {
                            rbBridgingStrategy.Checked = true;
                            edProjectType.Text = GetFieldDataStr("Bridging Strategy Types", ref reader);
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return -1;
                }
                connection.Close();
            } // if connection!=null

            return 0;
        } // loadformdata 






    }
}
