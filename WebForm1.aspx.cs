using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace inventory_list
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataSet cur_ds;
          protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack == true)  
                {  
                    Get_Xml();
                }
            }

        void Get_Xml()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("inventory_list.xml"));
            if (ds != null && ds.HasChanges())
            {
                XmlGridView.DataSource = ds;
                XmlGridView.DataBind();
            }
            else
            {
                XmlGridView.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String searchKey = TextBox1.Text;

            if (searchKey.Equals("")) {
                Get_Xml();
                return;
            }

            DataSet ori_ds = new DataSet();
            ori_ds.ReadXml(Server.MapPath("inventory_list.xml"));

            DataSet temp_ds = new DataSet();
            temp_ds = ori_ds.Clone();
            for (int i = 0; i < ori_ds.Tables[0].Rows.Count; i++) {
                if (ori_ds.Tables[0].Rows[i]["Name"].Equals(searchKey))
                {
                    temp_ds.Tables[0].ImportRow(ori_ds.Tables[0].Rows[i]);
                    XmlGridView.DataSource = null;
                    XmlGridView.DataSource = temp_ds;
                    XmlGridView.DataBind();
                    break;
                }
                else { 
                }
            }

        }

        protected void BtnInsert_Click(object sender, EventArgs e) {
            Insert_XML();
        }
        void Insert_XML()
        {
            TextBox new_id = XmlGridView.FooterRow.FindControl("NewInventory_ID") as TextBox;
            TextBox new_name = XmlGridView.FooterRow.FindControl("NewName") as TextBox;
            TextBox new_desc = XmlGridView.FooterRow.FindControl("NewDesc") as TextBox;
            TextBox new_unit_price = XmlGridView.FooterRow.FindControl("NewUnitPrice") as TextBox;
            TextBox new_qty = XmlGridView.FooterRow.FindControl("NewQUantity") as TextBox;
            TextBox new_reprder_level = XmlGridView.FooterRow.FindControl("NewReorderLevel") as TextBox;
            XmlDocument MyXmlDocument = new XmlDocument();
            MyXmlDocument.Load(Server.MapPath("inventory_list.xml"));
            XmlElement ParentElement = MyXmlDocument.CreateElement("inventory_item");
            XmlElement ID = MyXmlDocument.CreateElement("inventory_id");
            ID.InnerText = new_id.Text;
            XmlElement Name = MyXmlDocument.CreateElement("name");
            Name.InnerText = new_name.Text;
            XmlElement Desc = MyXmlDocument.CreateElement("desc");
            Desc.InnerText = new_desc.Text;
            XmlElement Unit_price = MyXmlDocument.CreateElement("unit_price");
            Unit_price.InnerText = new_unit_price.Text;
            XmlElement QTY = MyXmlDocument.CreateElement("qty_in_stock");
            QTY.InnerText = new_qty.Text;
            XmlElement ReorderLevel = MyXmlDocument.CreateElement("reorder_level");
            ReorderLevel.InnerText = new_reprder_level.Text;
            ParentElement.AppendChild(ID);
            ParentElement.AppendChild(Name);
            ParentElement.AppendChild(Desc);
            ParentElement.AppendChild(Unit_price);
            ParentElement.AppendChild(QTY);
            ParentElement.AppendChild(ReorderLevel);
            MyXmlDocument.DocumentElement.AppendChild(ParentElement);
            MyXmlDocument.Save(Server.MapPath("inventory_list.xml"));
            Get_Xml();
        }

        protected void XmlGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            XmlGridView.EditIndex = e.NewEditIndex;
            Get_Xml();
        }
        protected void XmlGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            XmlGridView.EditIndex = -1;
            Get_Xml();
        }
        protected void XmlGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = XmlGridView.Rows[e.RowIndex].DataItemIndex;
            TextBox Name = XmlGridView.Rows[e.RowIndex].FindControl("NewEditName") as TextBox;
            TextBox Desc = XmlGridView.Rows[e.RowIndex].FindControl("NewEditDesc") as TextBox;
            TextBox UnitPrice = XmlGridView.Rows[e.RowIndex].FindControl("NewEditUnitPrice") as TextBox;
            TextBox QTY = XmlGridView.Rows[e.RowIndex].FindControl("NewEditQuantity") as TextBox;
            TextBox ReorderLevel = XmlGridView.Rows[e.RowIndex].FindControl("NewEditReorderLevel") as TextBox;
            XmlGridView.EditIndex = -1;
            Get_Xml();
            DataSet ds = XmlGridView.DataSource as DataSet;
            ds.Tables[0].Rows[id]["Name"] = Name.Text;
            ds.Tables[0].Rows[id]["Desc"] = Desc.Text;
            ds.Tables[0].Rows[id]["unit_price"] = UnitPrice.Text;
            ds.Tables[0].Rows[id]["qty_in_stock"] = QTY.Text;
            ds.Tables[0].Rows[id]["reorder_level"] = ReorderLevel.Text;
            ds.WriteXml(Server.MapPath("Inventory_list.xml"));
            Get_Xml();
        }
        protected void XmlGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String deleteKey = XmlGridView.SelectedRow.Cells[1].Text ;

            Get_Xml();
            DataSet ds = XmlGridView.DataSource as DataSet;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Name"].Equals(deleteKey))
                {
                    ds.Tables[0].Rows[XmlGridView.Rows[i].DataItemIndex].Delete();
                    break;
                }
                else
                {
                }
            }
            ds.WriteXml(Server.MapPath("inventory_list.xml"));
            Get_Xml();
        }
    }
}