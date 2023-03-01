<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CdisMart.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/Login.css" rel="stylesheet" />
    <title>Registro</title>
</head>
<body>
    <form id="formRegistro" runat="server">
        <div id="titulo">Crear una cuenta</div>
        <div>
            <table>
                <tr></tr>
                <tr></tr>
                <tr>
                <td>Nombre completo:</td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" 
                             ControlToValidate="txtNombre" ValidationGroup="vlg2" Display="Dynamic"
                            ErrorMessage="Nombre Requerido">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombre" 
                            runat="server" ErrorMessage="Respeta un formato solo alfabetico"
                            ControlToValidate="txtNombre" ValidationGroup="vlg2" Display="Dynamic"
                             ValidationExpression="^[Ña-zA-ZÀ-ÿñ]+[Ña-zA-ZÀ-ÿñ\s]*">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" TextMode="Email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_email" runat="server" 
                            ErrorMessage="Email requerido"
                            ControlToValidate="txtEmail" ValidationGroup="vlg2" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_email" 
                            runat="server" ErrorMessage="Formato invalido"
                            ControlToValidate="txtEmail" ValidationGroup="vlg2" Display="Dynamic"
                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                             
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nombre de usuario:</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" 
                            ErrorMessage="Nombre de usuario requerido"
                            ControlToValidate="txtUsuario" ValidationGroup="vlg2" Display="Dynamic"
                            ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_usuario" runat="server" 
                            ErrorMessage="Siga un formato alfanumérico" 
                            ControlToValidate="txtUsuario" ValidationGroup="vlg2" Display="Dynamic"
                            ValidationExpression="[\w]*"
                            ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_contraseña" runat="server" 
                            ErrorMessage="Contraseña requerida"
                            ControlToValidate="txtContraseña" ValidationGroup="vlg2" Display="Dynamic"
                            ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_contraseña" runat="server" 
                            ErrorMessage="Siga un formato alfanumérico" 
                            ControlToValidate="txtContraseña" ValidationGroup="vlg2" Display="Dynamic"
                            ValidationExpression="[\w]*"
                            ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Confirmar contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtConfirm" TextMode="Password" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_confirm" runat="server" 
                            ErrorMessage="Contraseña requerida"
                            ControlToValidate="txtConfirm" ValidationGroup="vlg2" Display="Dynamic"
                            ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_confirm" runat="server" 
                            ErrorMessage="Siga un formato alfanumérico" 
                            ControlToValidate="txtConfirm" ValidationGroup="vlg2" Display="Dynamic"
                            ValidationExpression="[\w]*"
                            ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnCuenta" runat="server" Text="Registrarse" OnClick="btnCuenta_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
