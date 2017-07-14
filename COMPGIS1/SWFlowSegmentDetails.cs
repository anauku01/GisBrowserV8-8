using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Reflection;

namespace COMPGIS1
{
    public partial class SWFlowSegmentDetails : Form
    {

        private string _connectionstring = "";
        private int _zoneid = 0;
        private int _lineid = -1;
        private int _systemid = -1;
        private int _beginpoint = -1;
        private int _endpoint = -1;
        private bool _allow_open_lines = false;

        //-----------------------------------------------------------------------------------
        // Contructor
        //-----------------------------------------------------------------------------------
        public SWFlowSegmentDetails(int Zone_ID, string connectionstring, bool allow_open_lines)
        {
            InitializeComponent();
            _connectionstring = connectionstring;
            _allow_open_lines = allow_open_lines;
            if (_connectionstring.Length > 0)
            {
                _zoneid = Zone_ID;
                LoadFormData(_zoneid);
                this.Text = "Flow Segment Details - [" + tbFlowSegment.Text + "]";
            }
        }


        //-----------------------------------------------------------------------------------
        // Create the connection to the database
        //-----------------------------------------------------------------------------------
        private bool OpenDataConnection()
        {

            return true;
        }


        //-----------------------------------------------------------------------------------
        // Get Double Field Data from the Reader
        //-----------------------------------------------------------------------------------
        private bool GetFieldDataDouble(string DataFieldName, ref OleDbDataReader rdr, ref double dblvalue)
        {
            dblvalue = 0;
            try
            {
                int idx = rdr.GetOrdinal(DataFieldName);
                if (idx >= 0)
                {
                    string str = rdr[idx].ToString();
                    if (str.Length > 0)
                    {
                        dblvalue = Convert.ToDouble(str);
                        return true;
                    }                    
                }                    
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }


        //-----------------------------------------------------------------------------------
        // Get Field Data from the Reader
        //-----------------------------------------------------------------------------------
        private string GetFieldDataStr(string DataFieldName, ref OleDbDataReader rdr)
        {
            string retval = "";
            try
            {
                int idx = rdr.GetOrdinal(DataFieldName);
                if (idx >= 0)
                    retval = rdr[idx].ToString();
            }
            finally
            {
            }
            return retval;
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
        // Form On Load Event
        //-----------------------------------------------------------------------------------
        private void SWFlowSegmentDetails_Load(object sender, EventArgs e)
        {

            //var settings = ConfigurationManager.ConnectionStrings[ 0 ];
            //var fi = typeof( ConfigurationElement ).GetField( "_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic );
            //fi.SetValue(settings, false);
            //settings.ConnectionString = _connectionstring;

        } 


        //-----------------------------------------------------------------------------------
        // Load the Form Data
        //-----------------------------------------------------------------------------------
        public int LoadFormData(int Zone_ID)
        {
            int contentlookupid = -1;
            int lineclasslookupid = -1;
            string queryString = "";
            string queryStringLine = "";
            btnShowLine.Visible = _allow_open_lines;
            OleDbCommand command;
            OleDbDataReader reader;
            OleDbConnection connection = new OleDbConnection(_connectionstring);
            if (connection != null)
                try
                {
                    connection.Open();
                    string ZoneStr = Zone_ID.ToString();
                    queryString =
                        "SELECT [Dbf Zone].[Zone ID], [Dbf Zone].[Flow Segment], [Dbf Zone].[Flow Segment Ref #], [Dbf Zone].[Flow Segment Type], [Dbf Zone].[Flow Segment Description], " +
                        "[Dbf Zone].Node, [Dbf Zone].[Flow (gpm)], [Dbf Zone].[Flow Density], [Dbf Zone].[Nominal Pipe Size], [Dbf Zone].[Pipe OD], [Dbf Zone].[Pipe ID], [Dbf Zone].Area, " +
                        "[Dbf Zone].Velocity, [Dbf Zone].Comments, [Dbf Zone].Scheduled, [Dbf Zone].PID, [Dbf Zone].Iso, [Dbf Zone].PRA, [Dbf Zone].LCO, [Dbf Zone].Accessablility, " +
                        "[Dbf Zone].LineSize, [Dbf Zone].Building, [Dbf Zone].Elevation, [Dbf Zone].Row, [Dbf Zone].Col, [Dbf Zone].SR, [Dbf Zone].Schedule, [Dbf Zone].Category, " +
                        "[Dbf Zone].ChemTF, [Dbf Zone].Online, [Dbf Zone].SRB, [Dbf Zone].TAB, [Dbf Zone].APB, [Dbf Zone].IRB, [Dbf Zone].Cl, [Dbf Zone].SO3, [Dbf Zone].HCO2, [Dbf Zone].CO2, " +
                        "[Dbf Zone].Comments2, [Dbf Zone].InspLocation, [Dbf Zone].Drawing1, [Dbf Zone].Drawing2, [Dbf Zone].Unit, [Dbf Zone].SubSystemID, [Dbf Zone].LineID, [Dbf Zone].SystemID, " +
                        "[Dbf Zone].[Tnom Main], [Dbf Zone].BeginPoint, [Dbf Zone].EndPoint, [Dbf Zone].MapFeatureID FROM [Dbf Zone] WHERE ((([Dbf Zone].[Zone ID])=" + ZoneStr + "))";
                    command = new OleDbCommand(queryString, connection);
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            // Fill in controls from the Line Section Table
                            tbFlowSegment.Text = GetFieldDataStr("Flow Segment", ref reader);
                            tbFlowSegmentRef.Text = GetFieldDataStr("Flow Segment Ref #", ref reader);
                            tbBeginPoint.Text = GetFieldDataStr("BeginPoint", ref reader);
                            tbEndPoint.Text = GetFieldDataStr("EndPoint", ref reader);
                            if (tbBeginPoint.Text.Length>0) 
                                _beginpoint = Convert.ToInt32(tbBeginPoint.Text);
                            if (tbEndPoint.Text.Length>0)
                                _endpoint = Convert.ToInt32(tbEndPoint.Text);
                            tbFlowSegmentType.Text = GetFieldDataStr("Flow Segment Type", ref reader);
                            tbPID.Text = GetFieldDataStr("PID", ref reader);
                            tbISO.Text = GetFieldDataStr("Iso", ref reader);
                            tbAccessibility.Text = GetFieldDataStr("Accessablility", ref reader);
                            tbBuilding.Text = GetFieldDataStr("Building", ref reader);
                            tbElevation.Text = GetFieldDataStr("Elevation", ref reader);

                            try
                            {
                                cbSafetyRelated.Checked =
                                    (Convert.ToBoolean(GetFieldDataStr("Safety Related", ref reader)));
                            }
                            catch (Exception ex)
                            {
                                
                            }
                            tbRow.Text = GetFieldDataStr("Row", ref reader);
                            tbCol.Text = GetFieldDataStr("Col", ref reader);
                            tbNode.Text = GetFieldDataStr("Node", ref reader);
                            tbCategory.Text = GetFieldDataStr("Category", ref reader);
                            tbOnline.Text = GetFieldDataStr("Online", ref reader);
                            tbInspectionLocation.Text = GetFieldDataStr("InspLocation", ref reader);
                            tbUnit.Text = GetFieldDataStr("Unit", ref reader);
                            tbFlowSegmentDesc.Text = GetFieldDataStr("Flow Segment Description", ref reader);

                            double dbl = 0;

                            // Design Tab Controls
                            GetFieldDataDouble("Pipe ID", ref reader, ref dbl);
                            if (dbl>0)
                                tbPipeID.Text = String.Format("{0:0.000}", dbl);

                            GetFieldDataDouble("Area", ref reader, ref dbl);
                            if (dbl > 0)
                                tbArea.Text = String.Format("{0:0.000}", dbl);

                            GetFieldDataDouble("Velocity", ref reader, ref dbl);
                            if (dbl > 0)
                                tbVelocity.Text = String.Format("{0:0.000}", dbl);

                            GetFieldDataDouble("Flow (gpm)", ref reader, ref dbl);
                            if (dbl > 0)
                                tbFlow.Text = String.Format("{0:0.000}", dbl);

                            GetFieldDataDouble("Flow Density", ref reader, ref dbl);
                            if (dbl > 0)
                                tbFlowDensity.Text = String.Format("{0:0.000}", dbl);

                            GetFieldDataDouble("Nominal Pipe Size", ref reader, ref dbl);
                            if (dbl > 0)
                                tbNomPipeSize.Text = String.Format("{0:0.000}", dbl);
                            tbPipeSchedule.Text = GetFieldDataStr("Schedule", ref reader);

                            GetFieldDataDouble("Tnom Main", ref reader, ref dbl);
                            if (dbl > 0)
                                tbTnom.Text = String.Format("{0:0.000}", dbl);

                            GetFieldDataDouble("Pipe OD", ref reader, ref dbl);
                            if (dbl > 0)
                                tbPipeOD.Text = String.Format("{0:0.000}", dbl);

                            tbPRA.Text = GetFieldDataStr("PRA", ref reader);
                            tbLCO.Text = GetFieldDataStr("LCO", ref reader);
                            tbSRB.Text = GetFieldDataStr("SRB", ref reader);
                            tbTAB.Text = GetFieldDataStr("TAB", ref reader);
                            tbAPB.Text = GetFieldDataStr("APB", ref reader);
                            tbIRB.Text = GetFieldDataStr("IRB", ref reader);
                            tbCl.Text = GetFieldDataStr("Cl", ref reader);
                            tbSO3.Text = GetFieldDataStr("SO3", ref reader);
                            tbHCO2.Text = GetFieldDataStr("HCO2", ref reader);
                            tbCO2.Text = GetFieldDataStr("CO2", ref reader);
                            
                            // Lookup Fields
                            _lineid = Convert.ToInt32(GetFieldDataStr("LineID", ref reader));
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        return -1;
                    }

                    //...............
                    // Get the Parent Line information
                    //...............
                    if (_lineid > 0)
                    {
                        queryString = "SELECT * FROM [Dbf Lines] WHERE ([Dbf Lines].LineID=" + _lineid + ")";
                        command = new OleDbCommand(queryString, connection);
                        try
                        {
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                tbLine.Text = GetFieldDataStr("Line", ref reader);
                                lineclasslookupid = Convert.ToInt32(GetFieldDataStr("LineClass", ref reader));
                                tbLineSafetyGrade.Text = GetFieldDataStr("LineSafetyGrade", ref reader);
                                _systemid = GetFieldDataInt("SystemID", ref reader);
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            connection.Close();
                            return -1;
                        }
                    }

                    //...............
                    // Line Class
                    //...............
                    if (lineclasslookupid > 0)
                    {
                        queryString =
                            "SELECT [Dbf Setup -  Data].SetupID, [Dbf Setup -  Data].ValueData, [Dbf Setup -  Data].Type, [Dbf Setup -  Data].Description, [Dbf Setup -  Data].GUID, [Dbf Setup -  Data].GenericID FROM [Dbf Setup -  Data] WHERE (([Dbf Setup -  Data].SetupID)=" +
                            lineclasslookupid + ") AND (([Dbf Setup -  Data].Type)=\"LineCodeClass\")";
                        command = new OleDbCommand(queryString, connection);
                        try
                        {
                            reader = command.ExecuteReader();
                            if (reader.Read())
                                tbLineClass.Text = GetFieldDataStr("ValueData", ref reader);
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                        }
                    } // if lineclasslookupid>0          

                    //...............
                    // Get the System information
                    //...............
                    if (_systemid > 0)
                    {
                        queryString = "SELECT * FROM [Dbf Systems] WHERE ([Dbf Systems].SystemID=" + _lineid + ")";
                        command = new OleDbCommand(queryString, connection);
                        try
                        {
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                tbSystem.Text = GetFieldDataStr("System", ref reader);
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            connection.Close();
                            return -1;
                        }
                    }
                } // try...
                finally
                {
//                    connection.Close();
                }
            // Now load the Line Section Risk Ranking Values
            return 0;
        }

        //-----------------------------------------------------------------------------------
        // Show the Line Form
        //-----------------------------------------------------------------------------------
        private void btnShowLine_Click(object sender, EventArgs e)
        {
            if (_allow_open_lines)
            {
                if (_lineid > 0)
                {
                    SWLineDetails ldform = new SWLineDetails(_lineid, _connectionstring, false);
                    ldform.ShowDialog();
                    ldform.Dispose();
                }
            }
        }




    }
}
