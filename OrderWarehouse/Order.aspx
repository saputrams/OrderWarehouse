<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="OrderWarehouse.Order" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	
    <div class="container">
	  <div class="row">
		<div class="col-12">
			<asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"
                ClientIDMode="Static" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="OrderId" runat="server" 
                                Value='<%# Eval("OrderId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ControlStyle-CssClass="w-25" DataField="OrderNo" HeaderText="Order No" />
                    <asp:BoundField ControlStyle-CssClass="w-25" DataField="OrderDate" HeaderText="Order Date" />
                    <asp:BoundField ControlStyle-CssClass="w-25" DataField="OrderType" HeaderText="Order Type" />
                    <asp:BoundField ControlStyle-CssClass="w-25" DataField="Status" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnView" Text="View Item" runat="server" OnClick="BtnView_Onclick" CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView> 
		</div>
	  </div>
	</div>
</asp:Content>
