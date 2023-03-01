<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Creacion_de_subasta.aspx.cs" Inherits="CdisMart.Subastas.Creacion_de_subasta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                
                <tr>
                    <td>Nombre: </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" Width="250px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" 
                            ControlToValidate="txtNombre" ValidationGroup="vlg1" display="Dynamic"
                            ErrorMessage="Nombre es requerido"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombre" runat="server" 
                            ControlToValidate="txtNombre" ValidationGroup="vlg1" display="Dynamic"
                            ErrorMessage="Solo son permitidas letras y numeros"
                            ValidationExpression="^[Ñ\wÀ-ÿñ]+[Ñ\wÀ-ÿñ\s]*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Descripcion: </td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_descripcion" runat="server" 
                            ControlToValidate="txtDescripcion" ValidationGroup="vlg1" display="Dynamic"
                            ErrorMessage="Descripcion es requerida"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_descripcion" runat="server" 
                            ControlToValidate="txtDescripcion" ValidationGroup="vlg1" display="Dynamic"
                            ErrorMessage="Solo son permitidas letras y numeros"
                            ValidationExpression="^[Ñ\wÀ-ÿñ]+[Ñ\wÀ-ÿñ\s]*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de inicio: </td>
                    <td>
                        <asp:TextBox ID="txtFechaInicio" runat="server" Width="250px" TextMode="DateTimeLocal"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_fechaInicio" runat="server" 
                            ControlToValidate="txtFechaInicio" ValidationGroup="vlg1" display="Dynamic"
                            ErrorMessage="Fecha es requerida"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td>Fecha de fin: </td>
                    <td>
                        <asp:TextBox ID="txtFechaFin" runat="server" Width="250px" TextMode="DateTimeLocal"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_fechaFin" runat="server" 
                            ControlToValidate="txtFechaFin" ValidationGroup="vlg1" display="Dynamic"
                            ErrorMessage="Fecha es requerida"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btn_Crear" runat="server" Text="Crear" ValidationGroup="vlg1" OnClick="btn_Crear_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtFechaInicio").datetimepicker({});
            $(".lista").chosen();
        });

        $(document).ready(function () {
            $("#MainContent_txtFechaFin").datetimepicker({});
            $(".lista").chosen();
        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {
            $("#MainContent_txtFechaInicio").datetimepicker({});
            $(".lista").chosen();
        })

        manager.add_endRequest(function () {
            $("#MainContent_txtFechaFin").datetimepicker({});
            $(".lista").chosen();
        })
    </script>

</asp:Content>
