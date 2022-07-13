<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="inventory_list.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Width="164px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" Width="75px" />
        </div>

        <table>
            <tr>
                <td>
                    <asp:GridView ID="XmlGridView" runat="server" AutoGenerateColumns="false"
                        Height="247px" Width="795px" BackColor="White" BorderColor="#999999"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3"
                        GridLines="Vertical" ShowFooter="true"
                        OnRowCancelingEdit="XmlGridView_RowCancelingEdit" OnRowDeleting="XmlGridView_RowDeleting"
                        OnRowEditing="XmlGridView_RowEditing" OnRowUpdating="XmlGridView_RowUpdating">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:TemplateField HeaderText="Inventory ID">
                                <ItemTemplate>
                                    <asp:Label ID="Inventory_ID" runat="server" Text='<%# Bind("inventory_id")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="NewInventory_ID" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="Name" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="NewEditName" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="NewName" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="Description" runat="server" Text='<%# Bind("desc") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="NewEditDesc" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="NewDesc" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Price">
                                <ItemTemplate>
                                    <asp:Label ID="UnitPrice" runat="server" Text='<%# Bind("unit_price") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="NewEditUnitPrice" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="NewUnitPrice" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity in Stock">
                                <ItemTemplate>
                                    <asp:Label ID="QUantity" runat="server" Text='<%# Bind("qty_in_stock") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="NewEditQuantity" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="NewQUantity" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reorder Level">
                                <ItemTemplate>
                                    <asp:Label ID="ReorderLevel" runat="server" Text='<%# Bind("reorder_level") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="NewEditReorderLevel" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="NewReorderLevel" runat="server"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Operations">
                                <ItemTemplate>
                                    <asp:Button ID="BtnEdit" runat="server" CommandName="Edit" Text="Edit" />
                                    <asp:Button ID="BtnDelete" runat="server" CommandName="Delete" Text="Delete" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="BthUpdate" runat="server" CommandName="Update" Text="Update" />
                                    <asp:Button ID="BtnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="BtnInsert" runat="server" Text="Insert" OnClick="BtnInsert_Click" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
