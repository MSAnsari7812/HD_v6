using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.OleDb;

using System.IO;
using System.Web.Script;
using System.Configuration;
using System.Threading.Tasks;

public partial class ImportData : System.Web.UI.Page
{
    static DataTable dt = new DataTable();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            UploadFile();

        }


        if (!Page.IsPostBack)
        {
            // Button6.Visible = false;
            CreateTable();


        }
    }
    private void ShowPopUpMsg(string Msg)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("alert('");
        sb.Append(Msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
        sb.Append("');");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
    }
    private void WriteToFile(string strPath, ref byte[] Buffer)
    {
        try
        {
            // Create a file
            FileStream newFile = new FileStream(strPath, FileMode.Create);

            // Write data to the file
            newFile.Write(Buffer, 0, Buffer.Length);

            // Close file
            newFile.Close();
        }
        catch (Exception ex)
        {
            ShowPopUpMsg("Error: " + ex.Message.ToString());
        }
    }

    public static DataSet ImportExcelXLS(string FileName, bool hasHeaders)
    {
        string HDR = hasHeaders ? "Yes" : "No";
        string strConn;
        if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
        else
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

        DataSet output = new DataSet();

        using (OleDbConnection conn = new OleDbConnection(strConn))
        {
            conn.Open();

            DataTable schemaTable = conn.GetOleDbSchemaTable(
                OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            foreach (DataRow schemaRow in schemaTable.Rows)
            {
                string sheet = schemaRow["TABLE_NAME"].ToString();

                if (!sheet.EndsWith("_"))
                {
                    try
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                        cmd.CommandType = CommandType.Text;

                        DataTable outputTable = new DataTable(sheet);
                        output.Tables.Add(outputTable);
                        new OleDbDataAdapter(cmd).Fill(outputTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                    }
                }
            }
        }
        return output;
    } 

  

    protected void UploadFile()
    {
        string fpath = "";
        try
        {
            dt = null;
            var supportedTypes = new[] { "xls", "xlsx" };
            var fileExt = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).Substring(1);
            if (!supportedTypes.Contains(fileExt))
            {
                mc.ShowPopUpMsgM(this, "File Extension Is InValid - Only Upload EXCEL File");

            }
            else
            {

                if (FileUpload1.HasFile)
            {
               
                string filename = FileUpload1.PostedFile.FileName; // Path.GetFileName(fu1.FileName);

                string fname = Server.MapPath("~/") + filename;


                fpath = Server.MapPath("~/DATA/") + filename;


                //if (!File.Exists(@fpath))
                //{
                FileUpload1.PostedFile.SaveAs(fpath);
                // ShowPopUpMsg(fpath);
                //}
                string afpath = FileUpload1.ResolveClientUrl(fpath);

                dt = ImportExcelXLS(afpath, true).Tables[0];
                //ViewState["data"] = dt;
                if (dt.Rows.Count > 0)
                {

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Button6.Visible = true;
                }

            }
            else
            {
                mc.ShowPopUpMsgM(this, "No File Selected...");
            }
            }


        }
        catch (OleDbException er)
        {
            // Response.Write("<Script> alert('" + er.Message.ToString() + " Admin Error: File Not In .xls ')</Script>");
            ShowPopUpMsg(er.Message.ToString());
        }
    }

  protected void CreateTable()
    {
        try
        {
            dt.Columns.Add(new DataColumn { ColumnName = "username", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn { ColumnName = "password", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn { ColumnName = "name", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn { ColumnName = "email", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn { ColumnName = "mobileno", DataType = typeof(string) });
        }
        catch { }
     
    }


    CMSDAL.MsgClass mc = new CMSDAL.MsgClass();

    protected void Button6_Click(object sender, EventArgs e)
    {
        WS_CMS ws = new WS_CMS();
        if (dt != null)
        {
            string str = ws.ImportUsers(dt);
            if (str.Contains("success"))
            {
                mc.ShowPopUpMsgS(this, "Successfull Imported..");

                GridView1.DataSource = null;
                GridView1.DataBind();

            }
            else
            {
                mc.ShowPopUpMsgM(this, str);
            }
        }
       
    }
}
