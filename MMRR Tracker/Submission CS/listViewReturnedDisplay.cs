using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace MMRR_Tracker
{
    public class listViewReturnedDisplay
    {
        public DataTable GetDataFromSqlServer(string connectionString, string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                connection.Close();
            }
            return dataTable;
        }



        public DataTable GetDataFromSqlServer(string connectionString)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("getRTAView", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
  
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                connection.Close();
            }
            return dataTable;
        }

        public DataTable GetDataFromSqlServer(string connectionString, string group, string owner)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("getRTAViewGetGroup", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@group", group);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                connection.Close();
            }
            return dataTable;
        }

       

        public DataTable GetDataFromSqlServerViewCurrent(string connectionString, string assignedUser)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("viewCurrent", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@assignedUser", assignedUser);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                connection.Close();
            }
            return dataTable;
        }

        public DataTable GetDataFromSqlServerViewLastTouch(string connectionString, string assignedUser)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("viewLastTouch", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@lastTouch", assignedUser);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                connection.Close();
            }
            return dataTable;
        }



        public void TransferDataToListView(DataTable dataTable, ListView listView)
        {
            listView.Columns.Clear();
            listView.Items.Clear();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                listView.Columns.Add(dataTable.Columns[i].ColumnName);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dataTable.Rows[i][0].ToString());

                for (int j = 1; j < dataTable.Columns.Count; j++)
                {
                    item.SubItems.Add(dataTable.Rows[i][j].ToString());
                }
                if (item.SubItems[20].Text.Contains("Escalated - Invoice"))
                {
                    if (item.SubItems[29].Text == "NO")
                    {
                        item.BackColor = Color.FromArgb(255, 202, 202);
                    }
                    else
                    {
                        item.BackColor = Color.LightGreen;
                    }
                }
                else if (item.SubItems[20].Text.Contains("Escalated - No roles"))
                {
                    if (item.SubItems[29].Text == "NO")
                    {
                        item.BackColor = Color.FromArgb(255, 224, 202);
                    }
                    else
                    {
                        item.BackColor = Color.LightGreen;
                    }
                }
                else if (item.SubItems[20].Text.Contains("Escalated - No Signed HIPAA"))
                {
                    if (item.SubItems[29].Text == "NO")
                    {
                        item.BackColor = Color.FromArgb(255, 255, 202);
                    }
                    else
                    {
                        item.BackColor = Color.LightGreen;
                    }
                }
                else if (item.SubItems[20].Text.Contains("Escalated - General Escalation"))
                {
                    if (item.SubItems[29].Text == "NO")
                    {
                        item.BackColor = Color.FromArgb(202, 255, 255);
                    }
                    else
                    {
                        item.BackColor = Color.LightGreen;
                    }
                }
                else if (item.SubItems[20].Text.Contains("Escalated - Digital Signature not accepted"))
                {
                    if (item.SubItems[29].Text == "NO")
                    {
                        item.BackColor = Color.FromArgb(202, 202, 255);
                    }
                    else
                    {
                        item.BackColor = Color.LightGreen;
                    }
                }
                else if (item.SubItems[20].Text.Contains("Escalated - Client Priority"))
                {
                    if (item.SubItems[29].Text == "NO")
                    {
                        item.BackColor = Color.FromArgb(255, 202, 255);
                    }
                    else
                    {
                        item.BackColor = Color.LightGreen;
                    }
                }
                else if (item.SubItems[29].Text == "YES")
                {
                    item.BackColor = Color.LightGreen;
                }


                listView.Items.Add(item);
            }
            try
            {
                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

 
                foreach (ColumnHeader header in listView.Columns)
                {
                    int headerWidth = header.Width;
                    int maxWidth = header.Width;

                    Size headerTextSize = TextRenderer.MeasureText(header.Text, header.ListView.Font);
                    if (headerTextSize.Width > headerWidth)
                    {
                        maxWidth = headerTextSize.Width;
                    }

                    foreach (ListViewItem item in listView.Items)
                    {
                        int cellWidth = TextRenderer.MeasureText(item.SubItems[header.Index].Text, header.ListView.Font).Width;
                        if (cellWidth > maxWidth)
                        {
                            maxWidth = cellWidth;
                        }
                    }

                    header.Width = maxWidth;
                }



            }
            catch{}
       
        }


        public void TransferDataToListViewPrevious(DataTable dataTable, ListView listView)
        {

            try
            {
                listView.Columns.Clear();
                listView.Items.Clear();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    listView.Columns.Add(dataTable.Columns[i].ColumnName);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dataTable.Rows[i][0].ToString());

                    for (int j = 1; j < dataTable.Columns.Count; j++)
                    {
                        item.SubItems.Add(dataTable.Rows[i][j].ToString());
                    }

                    if (item.SubItems[29].Text == "YES")
                    {
                        item.BackColor = Color.LightGreen;
                    }


                    listView.Items.Add(item);
                }
                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

                foreach (ColumnHeader header in listView.Columns)
                {
                    int headerWidth = header.Width;
                    int maxWidth = header.Width;

                    Size headerTextSize = TextRenderer.MeasureText(header.Text, header.ListView.Font);
                    if (headerTextSize.Width > headerWidth)
                    {
                        maxWidth = headerTextSize.Width;
                    }

                    foreach (ListViewItem item in listView.Items)
                    {
                        int cellWidth = TextRenderer.MeasureText(item.SubItems[header.Index].Text, header.ListView.Font).Width;
                        if (cellWidth > maxWidth)
                        {
                            maxWidth = cellWidth;
                        }
                    }

                    header.Width = maxWidth;
                }
            }
            catch
            {

            }

           
        }

        public void TransferDataToList(DataTable dataTable, ListView listView)
        {
            try
            {
                listView.Columns.Clear();
                listView.Items.Clear();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    listView.Columns.Add(dataTable.Columns[i].ColumnName);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(dataTable.Rows[i][0].ToString());

                    for (int j = 1; j < dataTable.Columns.Count; j++)
                    {
                        item.SubItems.Add(dataTable.Rows[i][j].ToString());
                    }

                    float productivity = 0;
                    if (float.TryParse(dataTable.Rows[i][dataTable.Columns.Count - 1].ToString(), out productivity))
                    {
                        Color rowColor = GetRowColorForProductivity(productivity);
                        item.BackColor = rowColor;
                    }
                    listView.Items.Add(item);
                }
                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

                foreach (ColumnHeader header in listView.Columns)
                {
                    int headerWidth = header.Width;
                    int maxWidth = header.Width;

                    Size headerTextSize = TextRenderer.MeasureText(header.Text, header.ListView.Font);
                    if (headerTextSize.Width > headerWidth)
                    {
                        maxWidth = headerTextSize.Width;
                    }

                    foreach (ListViewItem item in listView.Items)
                    {
                        int cellWidth = TextRenderer.MeasureText(item.SubItems[header.Index].Text, header.ListView.Font).Width;
                        if (cellWidth > maxWidth)
                        {
                            maxWidth = cellWidth;
                        }
                    }
                    header.Width = maxWidth;
                }


            }
            catch
            {

            }
        
        }

        private Color GetRowColorForProductivity(float productivity)
        {
      
            Color color;
            if (productivity <= 10.0)
            {
                // red
                color = Color.FromArgb(250, 128, 82);
            }
            else if (productivity <= 20.0)
            {
                // orange
                color = Color.FromArgb(250, 165, 132);
            }
            else if (productivity <= 30.0)
            {
                // light orange
                color = Color.FromArgb(247, 185, 161);
            }
            else if (productivity <= 40.0)
            {
                // yellow
                color = Color.FromArgb(252, 195, 88);
            }
            else if (productivity <= 50.0)
            {
                // light green
                color = Color.FromArgb(252, 246, 73);
            }
            else if (productivity <= 60.0)
            {
                // green
                color = Color.FromArgb(208, 250, 160);
            }
            else if (productivity <= 70.0)
            {
                // teal
                color = Color.FromArgb(182, 247, 106);
            }
            else if (productivity <= 80.0)
            {
                // blue-green
                color = Color.FromArgb(115, 247, 106);
            }
            else if (productivity <= 90.0)
            {
                // blue
                color = Color.FromArgb(81, 250, 70);
            }
            else
            {
                // dark blue
                color = Color.FromArgb(0, 255, 42);
            }
            return color;
        }
    }





    
}
