﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftSensConf
{
    internal class Databaseconnection
    {
        string SoftSensConf = ConfigurationManager.ConnectionStrings["SoftSensConf"].ConnectionString;
        SqlConnection con;
        DataGrid dataGrid = new DataGrid();
        public bool connectToDatabase()
        {
             if (con == null) con = new SqlConnection(SoftSensConf);
            try
            { 
                con.Open();
                return true;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void closeDatabaseConnection()
        {
            if (con == null) return; 
            con.Close();
        }

        public List<string> selectQueryAsList(string table, string column, string order)
        {
            connectToDatabase();
            string sqlQuery = String.Concat("SELECT ", column ," FROM ", table ," ORDER BY ", column, " " , order.ToUpper());
            SqlCommand sql = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = sql.ExecuteReader();
            List<string> areaList = new List<string>();
            while (dr.Read() == true)
            {

                sqlQuery = dr[0].ToString().Trim();
                areaList.Add(sqlQuery);
                
            }
            dr.Close();
            closeDatabaseConnection();
            return areaList;
        }

        public void insertQueryForRDC(string table, string column, string value, string column2, string value2)
        {
            connectToDatabase();
            string sqlQuery = String.Concat(@"INSERT INTO ", table , " (", column ,", ", column2, ") " +
                "VALUES ('", value,"', '", value2, "')"); 
            Console.WriteLine(sqlQuery);

            SqlCommand command = new SqlCommand(sqlQuery, con);
            command.ExecuteNonQuery();
            closeDatabaseConnection();
        }
        public void insertQueryForDataLog(string table, string column, string column1, 
                                          string column2, string column3, string column4, 
                                          int value,  int value1, float value2, DateTime value3, string value4)
        {
            connectToDatabase();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO ");
            stringBuilder.Append(table);
            stringBuilder.Append(" (");
            stringBuilder.Append(column);
            stringBuilder.Append(", ");
            stringBuilder.Append(column1);
            stringBuilder.Append(", ");
            stringBuilder.Append(column2);
            stringBuilder.Append(", ");
            stringBuilder.Append(column3);
            stringBuilder.Append(", ");
            stringBuilder.Append(column4);
            stringBuilder.Append(") ");
            stringBuilder.Append("VALUES ('");
            stringBuilder.Append(value);
            stringBuilder.Append("', ");
            stringBuilder.Append(value1);
            stringBuilder.Append(", ");
            stringBuilder.Append(value2);
            stringBuilder.Append(", '");
            stringBuilder.Append(value3);
            stringBuilder.Append("', '");
            stringBuilder.Append(value4);
            stringBuilder.Append("')");

            Console.WriteLine(stringBuilder.ToString());

            SqlCommand command = new SqlCommand(stringBuilder.ToString(), con);
            command.ExecuteNonQuery();
            closeDatabaseConnection();
        }
        public void insertQueryForInstrument(string table, string column, string column1, string column2, string column3, string column4, 
                                             string column5, string column6, string column7, string column8, string column9,
                                             string value,  string value1,
                                             string value2, string value3,
                                             string value4, string value5,
                                             string value6, string value7,
                                             string value8, string value9)
        {
            connectToDatabase();
            string sqlQuery = String.Concat(@"INSERT INTO ", table, " (", column, ", ", column1, ", ", column2, 
                ", ", column3, ", ", column4, ", ", column5, ", ", column6, ", ", column7, ", ", column8, ", ", column9, ") " +
                "VALUES ('", value, "', '", value1, "', '", value2, "', '", value3, "', '", value4, "', '", value5, "" +
                "', '", value6, "', '", value7, "', '", value8, "', '", value9, "' )");
            Console.WriteLine(sqlQuery);


            SqlCommand command = new SqlCommand(sqlQuery, con);
            try 
            {
            command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDatabaseConnection();
        }

        internal void insertConfigWithDictionary(string table ,Dictionary<string, string> dict)
        {
            connectToDatabase();
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert INTO ");
            sb.Append(table);
            sb.Append(" (");
            foreach (string column in dict.Keys)
            {
                sb.Append(column);
                if (dict.Last().Key == column) break;
                sb.Append(", ");
            }
            sb.Append(") VALUES (");
            foreach (string value in dict.Values)
            {
                sb.Append(value);
                if (dict.Last().Value == value) break;
                sb.Append(", ");
            }
            sb.Append(")");

            Console.WriteLine(sb.ToString());


            SqlCommand command = new SqlCommand(sb.ToString(), con);
            command.ExecuteNonQuery();
            closeDatabaseConnection();

        }
        public DataTable getInstrumentTableInGrid()
        {
           
            string sqlQuery = @"SELECT * FROM INSTRUMENT ORDER BY TagID ASC";
        
            return viweInstrumentTableInGrid(sqlQuery);
            
        }

        private DataTable viweInstrumentTableInGrid(string sqlQuery)
        {
            try
            {
                SqlDataAdapter sda;
                DataTable dt;
                connectToDatabase();
                sda = new SqlDataAdapter(sqlQuery, con);
                dt = new DataTable();
                sda.Fill(dt);
                closeDatabaseConnection();
                return dt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            
            }
            return null;
        }
    }
}
