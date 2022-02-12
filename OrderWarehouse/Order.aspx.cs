using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderWarehouse
{
    public partial class Order : System.Web.UI.Page
    {
        Connection conn = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                ShowOrder();
            }
        }

        private void ShowOrder()
        {
            ListDictionary list = new ListDictionary();

            DataTable dtOrder = conn.ExecProcedure("WEB_Order_GET", list);

            this.gvOrder.DataSource = dtOrder;
            this.gvOrder.DataBind();
        }



        protected void BtnView_Onclick(object sender, EventArgs e)
        {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;

            string orderId = ((HiddenField)row.Cells[0].FindControl("OrderId")).Value;
            Response.Redirect("ItemOrder.aspx?ID="+orderId);
        }
    }
}