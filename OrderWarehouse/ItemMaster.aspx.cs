using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace OrderWarehouse
{
    public partial class ItemMaster : System.Web.UI.Page
    {

        Connection conn = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowGrid();
        }

        private void ShowGrid()
        {
            DataTable dt = new DataTable();


            ListDictionary list = new ListDictionary();

            DataTable dtOrderItem = conn.ExecProcedure("WEB_ItemMaster_GET", list);


            dt.Columns.Add(new DataColumn("ItemId", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("ImageQR", System.Type.GetType("System.Byte[]")));
            dt.Columns.Add(new DataColumn("ItemNo", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Style", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Desc", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Qty", System.Type.GetType("System.String")));

            DataRow dr;
            for (var i = 0; i < dtOrderItem.Rows.Count; i++)
            {
                dr = dt.NewRow();

                dr["ItemId"] = dtOrderItem.Rows[i].ItemArray[0].ToString();
                dr["ImageQR"] = GenerateCode(dtOrderItem.Rows[i].ItemArray[0].ToString());
                dr["ItemNo"] = dtOrderItem.Rows[i].ItemArray[1].ToString();
                dr["Style"] = dtOrderItem.Rows[i].ItemArray[2].ToString();
                dr["Desc"] = dtOrderItem.Rows[i].ItemArray[3].ToString();
                dr["Qty"] = dtOrderItem.Rows[i].ItemArray[4].ToString();
                dt.Rows.Add(dr);
            }

            this.gvItem.DataSource = dt;
            this.gvItem.DataBind();
        }


        private byte[] GenerateCode(string name)
        {
            byte[] bytes;
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            var result = writer.Write(name);
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                bytes = memory.ToArray();
            }
            return bytes;

        }
    }
}