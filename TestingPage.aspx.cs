using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace TestingCSV
{
    public partial class TestingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Geth path where you will save the file after uploading it.
            // FileUpLoad1 is asp file upload control.
            string csvPath = Server.MapPath("~/Files") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);

            // We need to create datatable.
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5]
            {
                new DataColumn("Id",typeof(int)),
                new DataColumn("FirstName",typeof(string)),
                new DataColumn("LastName",typeof(string)),
                new DataColumn("Address",typeof(string)),
                new DataColumn("PhoneNumber",typeof(string)),
            });

            // Here we read the contents of CSV file.
            string csvData = File.ReadAllText(csvPath);

            // Run a loop over all rows.
            foreach(string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    
                    // Run a loop over columns
                    foreach(string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }
            // Bind what ever we read on csv file to this small grid.
            // Here you have option to display this in any way you want, usig grid in this case is easy.
            // you can also save this data in the database here instead of gridview.
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // First this we need to build a text file.

            string txtfileOne = string.Empty;




            foreach (TableCell cell in GridView1.HeaderRow.Cells)

            {

                // We also have to add the header row for our text file.

                txtfileOne += cell.Text + "\t\t";

            }

            // We need to add a new line.

            txtfileOne += "\r\n";




            foreach (GridViewRow row in GridView1.Rows)

            {

                foreach (TableCell cell in row.Cells)

                {

                    txtfileOne += cell.Text + "\t\t";

                }

                txtfileOne += "\r\n";

            }

            // We are downloading the textfile.

            Response.Clear();

            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.txt");

            Response.Charset = "";

            Response.ContentType = "application/text";

            Response.Output.Write(txtfileOne);

            Response.Flush();

            Response.End();
        }
    }
}