<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta.aspx.cs" Inherits="CdisMart.Subastas.Subasta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <table>
                <tr>
                    <td># de subasta: </td>
                    <td style="width: 640px">
                        <asp:Label ID="lblNumSubasta" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Nombre del producto: </td>
                    <td style="width: 640px">
                        <asp:Label ID="lblNombreProducto" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Descripcion: </td>
                    <td style="width: 640px">
                        <asp:Label ID="lblDescripcion" runat="server"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de inicio: </td>
                    <td style="width: 640px">
                        <asp:Label ID="lblFechaInicio" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de fin: </td>
                    <td style="width: 640px">
                        <asp:Label ID="lblFechaFin" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Oferta mas alta: </td>
                    <td style="width: 640px">
                        <asp:Label ID="lblOfertaAlta" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Usuario que hizo la oferta mas alta: </td>
                    <td style="width: 640px">
                        <asp:Label ID="lblUsuarioOfertaAlta" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td></td><td style="width: 640px"></td></tr>
                <tr><td></td><td style="width: 640px"></td></tr>
                <tr>
                    <td>Mi oferta</td>
                    <td style="width: 640px">
                        <asp:TextBox ID="txtOferta" runat="server" Width="241px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="width: 640px">
                        <asp:Button ID="btnOferta" runat="server" Text="Realizar oferta" OnClick="btnOferta_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
