<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista_de_subasta.aspx.cs" Inherits="CdisMart.Subastas.Lista_de_subasta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <table>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Filtro:</td>
                    <td>
                        <asp:TextBox ID="txtFiltro" runat="server" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbl1" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>

            <asp:GridView ID="grd_subastas" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="grd_subastas_SelectedIndexChanged" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Horizontal" style="margin-right: 0px" Width="1270px">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField HeaderText="# de subasta" DataField="AuctionId" SortExpression="AuctionId"/>
                    <asp:HyperLinkField HeaderText="Nombre del producto" DataTextField="ProductName" DataNavigateUrlFields="AuctionId"
                         DataNavigateUrlFormatString="~/Subastas/Subasta.aspx?AuctionId={0}" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Description" SortExpression="Description"/>
                    <asp:BoundField HeaderText="Fecha de inicio de la subasta" DataField="StartDate" SortExpression="StartDate"/>
                    <asp:BoundField HeaderText="Fecha de fin de la subasta" DataField="EndDate" SortExpression="EndDate"/>
                    <asp:HyperLinkField HeaderText="Historial de subastas" Text="Ver Historial" DataNavigateUrlFields="AuctionId"
                        DataNavigateUrlFormatString="~/Subastas/Historial.aspx?AuctionId={0}"/>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>

    
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="Data Source=DESKTOP-NP30A1I\SQLEXPRESS;Initial Catalog=CdisMart;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="SELECT [AuctionId], [ProductName], [Description], [StartDate], [EndDate] FROM [Auction] WHERE ([Description] LIKE '%' + @Description + '%')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtFiltro" DefaultValue=" " Name="Description" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

