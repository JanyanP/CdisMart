<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="CdisMart.Subastas.Historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <table>
                 <tr>
                    <td>Nombre del producto: </td>
                    <td style="width: 506px">
                        <asp:Label ID="lblNombreProducto" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Descripcion: </td>
                    <td style="width: 506px">
                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr><td></td><td style="width: 506px;color:white;"><asp:Label ID="Label1" runat="server" ></asp:Label></td></tr>
                <tr><td></td><td style="width: 506px"><asp:Label ID="Label2" runat="server"></asp:Label></td></tr>
                <tr><td></td><td style="width: 506px"><asp:Label ID="Label3" runat="server"></asp:Label>
                    <br />
                    <br />
                    </td></tr>
            </table>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-NP30A1I\SQLEXPRESS;Initial Catalog=CdisMart;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT UserId, UserName FROM Users WHERE (UserName &lt;&gt; @UserName)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Ninguno" Name="UserName" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:DropDownList ID="ddlUserName" CssClass="lista" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserName" Width="273px">
                <asp:ListItem Selected="True">Selecciona Usuario</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />

            <asp:GridView ID="grd_historial" AutoGenerateColumns="False" runat="server" OnRowDataBound="grd_historial_RowDataBound" ShowFooter="True" CellPadding="4" DataSourceID="SqlDataSource3" GridLines="None" Width="633px" ForeColor="#333333" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Usuario que ofertó" DataField="UserName" />
                    <asp:BoundField HeaderText="Monto de la oferta" DataField="Amount" />
                    <asp:BoundField HeaderText="Fecha de la oferta" DataField="BidDate" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="Data Source=DESKTOP-NP30A1I\SQLEXPRESS;Initial Catalog=CdisMart;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="sp_recordPorAuctionYUser" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label1" Name="pAuctionId" Type="Int32" PropertyName="Text"  />
                    <asp:ControlParameter ControlID="ddlUserName" Name="pUserName" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            
            
            <!--
            <table>
                <tr>
                    <td></td>
                    <td>Monto Total: </td>
                    <td>
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            -->

        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".lista").chosen();
        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {
            $(".lista").chosen();
        })
    </script>
    <!--
    <script>
        let total = 0;
        let celdasMonto = document.querySelectorAll('asp:BoundField + asp:BoundField');

        for (let i = 0; i < celdasMonto.length; ++i) {
            total += parseFloat(celdasMonto[i].firstChild.nodeValue);
        }

        let nuevaFila = document.createElement('asp:BoundField');

        let celdaTotal = document.createElement('asp:BoundField');
        let textoCeldaTotal = document.createTextNode('Total');
        celdaTotal.appendChild(textoCeldaTotal);
        nuevaFila.appendChild(celdaTotal);

        let celdaValorTotal = document.createElement('asp:BoundField');
        let textoCeldaValorTotal = document.createTextNode(total);
        celdaValorTotal.appendChild(textoCeldaValorTotal);
        nuevaFila.appendChild(celdaValorTotal);

        document.getElementById('grd_historial.aspx').appendChild(nuevaFila);
    </script>
    -->    
    
</asp:Content>
