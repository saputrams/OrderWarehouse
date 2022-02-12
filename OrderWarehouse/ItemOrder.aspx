<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemOrder.aspx.cs" MasterPageFile="~/Site.Master" Inherits="OrderWarehouse.ItemOrder" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	
    <div class="container">
	  <div class="row">
		<div class="col-12">
			<asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"
                ClientIDMode="Static" >
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="50">
                        <HeaderTemplate>QR Code</HeaderTemplate>
                        <ItemTemplate>
                            <img src='data:image/jpg;base64,<%# Eval("ImageQR") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("ImageQR")) : string.Empty %>' alt="image" height="100" width="100"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ControlStyle-CssClass="w-25" DataField="ItemNo" HeaderText="Item No" />
                    <asp:BoundField ControlStyle-CssClass="w-25" DataField="Style" HeaderText="Style" />
                    <asp:BoundField ControlStyle-CssClass="w-25" DataField="Desc" HeaderText="Desc" />
                    <%--<asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" Text="Edit" runat="server" OnClick="Edit" CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView> 
		</div>
	  </div>
	</div>
</asp:Content>