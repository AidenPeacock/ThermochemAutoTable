using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Thermochem
{
    public partial class Form1 : Form
    {
        int counter = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private SqlConnection SqlConnect()
        {
            string connectionstring = "SERVER=DESKTOP-28KA6OU\\SQLEXPRESS;DATABASE=Thermochem;Trusted_Connection=yes;TrustServerCertificate=True";
            SqlConnection con = new SqlConnection(connectionstring);
            return con;
        }

        private double LinInt()
        {
            return 0.01;
        }

        private double tripleLinInt()
        {
            return 0.01;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int j = 0;
            int index1 = comboBox1.Text.IndexOf(" ");
            string queryvar1 = comboBox1.Text.Substring(0, index1);
            int index2 = comboBox2.Text.IndexOf("(");
            string queryvar2 = comboBox2.Text.Substring(0, index2 - 1);
            string condition = "";
            string columnsquery = "";
            queryvar2 = queryvar2.Replace(" ", "_");
            string[] columns = { "Temperature", "Pressure", "Specific_Volume_Liquid", "Specific_Volume_Gas",
                "Internal_Energy_Liquid", "Internal_Energy_Gas",
                "Enthalpy_Liquid", "Enthalpy_Gas"};

            string[] columnsSelect = new string[7];
            string[] columns1 = { "Temperature", "Pressure", "Specific_Volume", "Internal_Energy", "Enthalpy"};
            string[] columnsSelect1 = new string[5];
            string table = "";
            int satcheck = 0;
            int satcheckabove = 0;
            int satcheckbelow = 0;
            string abovespec = "";
            string belowspec = "";

            outputTemp.Text = "";
            outputPress.Text = "";
            outputSpecVol.Text = "";
            outputIntEng.Text = "";
            outputEnthalpy.Text = "";
            IEnumerable<System.Windows.Forms.TextBox> textBoxes = resultpanel.Controls.OfType<System.Windows.Forms.TextBox>();

            j = 0;
            if ((queryvar1.Equals("Temperature") || queryvar1.Equals("Temperature") && !VarEnter1.Text.Equals("Pressure")) && double.Parse(VarEnter1.Text) < 373.95)
            {
                table = "A4_TEMP_TABLE_SAT_WATER";
                for (int i = 0; i < columns.Length; i++)
                {
                    if (!columns[i].Equals(queryvar1))
                    {
                        columnsSelect[j] = columns[i];
                        j += 1;
                    }

                }
            }
            else if (queryvar1.Equals("Pressure"))
            {
                table = "A5_PRESS_TABLE_SAT_WATER";
                for (int i = 0; i < columns.Length; i++)
                {
                    if (!columns[i].Equals(queryvar1))
                    {
                        columnsSelect[j] = columns[i];
                        j += 1;
                    }

                }
            }
            else
            {
                table = "A6_TABLE_SUPERHEATED_WATER";
                for (int i = 0; i < columns1.Length; i++)
                {
                    if (!columns1[i].Equals(queryvar1))
                    {
                        columnsSelect1[j] = columns1[i];
                        j += 1;
                    }

                }

            }
            if (!queryvar2.Equals("Temperature") && !queryvar2.Equals("Pressure"))
            {
                abovespec = queryvar2 + "_Gas";
                belowspec = queryvar2 + "_Liquid";
            }
            if (abovespec.Equals(""))
            {
                satcheck = Array.IndexOf(columnsSelect, queryvar2);
            }
            else
            {
                satcheckabove = Array.IndexOf(columnsSelect, abovespec);
                satcheckbelow = Array.IndexOf(columnsSelect, belowspec);
            }

            if (double.Parse(VarEnter1.Text) > 373.95 && comboBox1.Text.Equals("Temperature (Celcius)"))
            {
                columnsquery = string.Join(", ", columnsSelect1);
                columnsquery = columnsquery.Substring(0, columnsquery.Length - 2);
                condition = queryvar2 + " = " + VarEnter2.Text + " AND ";
            }

            else
            {
                columnsquery = string.Join(", ", columnsSelect);
            }
            condition += queryvar1 + " = " + VarEnter1.Text;
            SqlConnection con = SqlConnect();
            string querystate = string.Format("SELECT {0} FROM {1} WHERE {2}", columnsquery, table, condition);
            con.Open();
            SqlCommand command = new SqlCommand(querystate, con);
            SqlDataReader read = command.ExecuteReader();
            Console.WriteLine(querystate);
            if (read.Read())
            { 
                if (table.Equals("A4_TEMP_TABLE_SAT_WATER"))
                {
                    if (abovespec.Equals(""))
                        // Temp and Pressure
                    {
                        if (decimal.Parse(VarEnter2.Text)  > decimal.Parse(read.GetString(satcheck)))
                        {
                            outputTemp.Text = VarEnter1.Text;
                            outputPress.Text = VarEnter2.Text;
                            outputSpecVol.Text = read.GetDecimal(1).ToString();
                            outputIntEng.Text = read.GetDecimal(3).ToString();
                            outputEnthalpy.Text = read.GetDecimal(5).ToString();
                            outputState.Text = "Compressed Liquid";
                        }
                        else if (decimal.Parse(VarEnter2.Text) < decimal.Parse(read.GetString(satcheck)))
                        {

                            con.Close();
                            querystate = string.Format("SELECT Temperature, Pressure, Specific_Volume, Internal_Energy, Enthalpy FROM A6_TABLE_SUPERHEATED_WATER WHERE {0} AND {1} = {2}", condition, queryvar2, VarEnter2.Text);
                            con.Open();
                            command = new SqlCommand(querystate, con);
                            read = command.ExecuteReader();
                            if (read.Read())
                            {
                                if (comboBox1.Text.Equals("Temperature (Celcius)") || comboBox2.Text.Equals("Temperature (Celcius)"))
                                {
                                    outputTemp.Text = VarEnter1.Text;
                                }
                                else if (comboBox1.Text.Equals("Pressure (kPa)") || comboBox2.Text.Equals("Pressure (kPa)"))
                                {
                                    outputPress.Text = VarEnter1.Text;
                                }
                                if (comboBox2.Text.Equals("Specific Volume (m^3/kg)"))
                                {
                                    outputSpecVol.Text = VarEnter2.Text;
                                }
                                else if (comboBox2.Text.Equals("Internal Energy (kJ/kg)"))
                                {
                                    outputIntEng.Text = VarEnter2.Text;
                                }
                                else if (comboBox2.Text.Equals("Enthalpy (kJ/kg)"))
                                {
                                    outputEnthalpy.Text = VarEnter2.Text;
                                }
                                foreach (System.Windows.Forms.TextBox textBox in textBoxes)
                                {
                                    if (textBox.Text.Equals(""))
                                    {
                                        if (textBox == outputTemp)
                                        {
                                            outputTemp.Text = read.GetValue(0).ToString();
                                        }
                                        if (textBox == outputPress)
                                        {
                                            outputPress.Text = read.GetValue(0).ToString();
                                        }
                                        if (textBox == outputSpecVol)
                                        {
                                            outputSpecVol.Text = read.GetDecimal(2).ToString();
                                        }
                                        if (textBox == outputIntEng)
                                        {
                                            outputIntEng.Text = read.GetDecimal(3).ToString();
                                        }
                                        if (textBox == outputEnthalpy)
                                        {
                                            outputEnthalpy.Text = read.GetDecimal(4).ToString();
                                        }
                                        outputState.Text = "Superheated Vapour";
                                    }
                                }

                            }
                        }
                        else
                        {
                            // saturated liquid
                            if (comboBox3.Text.Equals("") && VarEnter3.Text.Equals(""))
                            {

                                outputTemp.Text = "Not Enough Information";
                            }
                            else if (comboBox3.Text.Equals("Saturated Mixture"))
                            {
                                if (VarEnter3.Text.Equals(""))
                                {
                                    outputTemp.Text = "Not Enough Information";
                                }
                                else if (double.Parse(VarEnter3.Text) <= 1 && double.Parse(VarEnter3.Text) >= 0)
                                {
                                    outputTemp.Text = VarEnter1.Text;
                                    outputPress.Text = VarEnter2.Text;
                                    outputSpecVol.Text = (read.GetDecimal(1) + decimal.Parse(VarEnter3.Text) * (read.GetDecimal(2) - read.GetDecimal(1))).ToString();
                                    outputIntEng.Text = (read.GetDecimal(3) + decimal.Parse(VarEnter3.Text) * (read.GetDecimal(4) - read.GetDecimal(3))).ToString();
                                    outputEnthalpy.Text = (read.GetDecimal(5) + decimal.Parse(VarEnter3.Text) * (read.GetDecimal(6) - read.GetDecimal(5))).ToString();
                                    outputState.Text = "Saturated Mixture";
                                }

                            }
                            else if (comboBox3.Text.Equals("Saturated Liquid"))
                            {
                                outputTemp.Text = VarEnter1.Text;
                                outputPress.Text = VarEnter2.Text;
                                outputSpecVol.Text = read.GetDecimal(1).ToString();
                                outputIntEng.Text = read.GetDecimal(3).ToString();
                                outputEnthalpy.Text = read.GetDecimal(5).ToString();
                                outputState.Text = "Saturated Liquid";
                            }
                            else if (comboBox3.Text.Equals("Saturated Vapour"))
                            {
                                outputTemp.Text = VarEnter1.Text;
                                outputPress.Text = VarEnter2.Text;
                                outputSpecVol.Text = read.GetDecimal(2).ToString();
                                outputIntEng.Text = read.GetDecimal(4).ToString();
                                outputEnthalpy.Text = read.GetDecimal(6).ToString();
                                outputState.Text = "Saturated Vapour";
                            }
                        }
                        
                    }
                    else
                    {
                        if (comboBox1.Text.Equals("Temperature (Celcius)") || comboBox2.Text.Equals("Temperature (Celcius)"))
                        {
                            outputTemp.Text = VarEnter1.Text;
                        }
                        else if (comboBox1.Text.Equals("Pressure (kPa)") || comboBox2.Text.Equals("Pressure (kPa)"))
                        {
                            outputPress.Text = VarEnter1.Text;
                        }
                        if (comboBox2.Text.Equals("Specific Volume (m^3/kg)"))
                        {
                            outputSpecVol.Text = VarEnter2.Text;
                        }
                        else if (comboBox2.Text.Equals("Internal Energy (kJ/kg)"))
                        {
                            outputIntEng.Text = VarEnter2.Text;
                        }
                        else if (comboBox2.Text.Equals("Enthalpy (kJ/kg)"))
                        {
                            outputEnthalpy.Text = VarEnter2.Text;
                        }

                        if (read.GetDecimal(satcheckabove) < decimal.Parse(VarEnter2.Text))
                        {
                            
                            con.Close();
                            querystate = string.Format("SELECT Temperature, Pressure, Specific_Volume, Internal_Energy, Enthalpy FROM A6_TABLE_SUPERHEATED_WATER WHERE {0} AND {1} = {2}", condition, queryvar2, VarEnter2.Text);
                            Console.WriteLine(querystate);
                            con.Open();
                            command = new SqlCommand(querystate, con);
                            read = command.ExecuteReader();
                            if (read.Read())
                            {
                                foreach (System.Windows.Forms.TextBox textBox in textBoxes)
                                {
                                    if (textBox.Text.Equals(""))
                                    {
                                        if (textBox == outputTemp)
                                        {
                                            outputTemp.Text = read.GetValue(0).ToString();
                                        }
                                        if (textBox == outputPress)
                                        {
                                            outputPress.Text = read.GetValue(0).ToString();
                                        }
                                        if (textBox == outputSpecVol)
                                        {
                                            outputSpecVol.Text = read.GetDecimal(2).ToString();
                                        }
                                        if (textBox == outputIntEng)
                                        {
                                            outputIntEng.Text = read.GetDecimal(3).ToString();
                                        }
                                        if (textBox == outputEnthalpy)
                                        {
                                            outputEnthalpy.Text = read.GetDecimal(4).ToString();
                                        }
                                    }
                                }
                                outputState.Text = "Superheated Vapour";
                            }
                        }
                        else if (read.GetDecimal(satcheckbelow) > decimal.Parse(VarEnter2.Text))
                        {
                            foreach (System.Windows.Forms.TextBox textBox in textBoxes)
                            {
                                if (textBox.Text.Equals(""))
                                {
                                    if (textBox == outputTemp)
                                    {
                                        outputTemp.Text = read.GetValue(0).ToString();
                                    }
                                    if (textBox == outputPress)
                                    {
                                        outputPress.Text = read.GetValue(0).ToString();
                                    }
                                    if (textBox == outputSpecVol)
                                    {
                                        outputSpecVol.Text = read.GetDecimal(1).ToString();
                                    }
                                    if (textBox == outputIntEng)
                                    {
                                        outputIntEng.Text = read.GetDecimal(3).ToString();
                                    }
                                    if (textBox == outputEnthalpy)
                                    {
                                        outputEnthalpy.Text = read.GetDecimal(5).ToString();
                                    }
                                }
                            }
                            outputState.Text = "Compressed Liquid";

                        }
                    }
                }
                else if (table.Equals("A5_PRESS_TABLE_SAT_WATER"))
                {

                }
                else if (table.Equals("A6_TABLE_SUPERHEATED_WATER"))
                {
                    // Temp and Pressure, Values are on table
                    if (comboBox1.Text.Equals("Temperature (Celcius)") || comboBox2.Text.Equals("Temperature (Celcius)"))
                    {
                        outputTemp.Text = VarEnter1.Text;
                    }
                    else if (comboBox1.Text.Equals("Pressure (kPa)") || comboBox2.Text.Equals("Pressure (kPa)"))
                    {
                        outputPress.Text = VarEnter1.Text;
                    }
                    if (comboBox2.Text.Equals("Specific Volume (m^3/kg)"))
                    {
                        outputSpecVol.Text = VarEnter2.Text;
                    }
                    else if (comboBox2.Text.Equals("Internal Energy (kJ/kg)"))
                    {
                        outputIntEng.Text = VarEnter2.Text;
                    }
                    else if (comboBox2.Text.Equals("Enthalpy (kJ/kg)"))
                    {
                        outputEnthalpy.Text = VarEnter2.Text;
                    }
                    foreach (System.Windows.Forms.TextBox textBox in textBoxes)
                    {
                        if (textBox.Text.Equals(""))
                        {
                            if (textBox == outputTemp)
                            {
                                outputTemp.Text = read.GetValue(0).ToString();
                            }
                            if (textBox == outputPress)
                            {
                                outputPress.Text = read.GetValue(0).ToString();
                            }
                            if (textBox == outputSpecVol)
                            {
                                outputSpecVol.Text = read.GetDecimal(1).ToString();
                            }
                            if (textBox == outputIntEng)
                            {
                                outputIntEng.Text = read.GetDecimal(2).ToString();
                            }
                            if (textBox == outputEnthalpy)
                            {
                                outputEnthalpy.Text = read.GetDecimal(3).ToString();
                            }

                        }
                    }
                    outputState.Text = "Superheated Vapour";
                    
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
