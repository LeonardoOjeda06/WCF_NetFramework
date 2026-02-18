<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Registrar" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="DemoWCF.Presentation.User" %>

<asp:Content ID="ContainerUser"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="container d-flex flex-column justify-content-center align-items-center">

        <div class="form-floating m-4">
            <h1>Registrar usuario</h1>
        </div>

        <div class="container-fluid p-3" style="width: 300px;">

            <div id="contentMessage" runat="server" class="text-center d-flex flex-column justify-content-center mb-2" style="height: 30px;" visible="false">
                <asp:Label ID="LabelMessage" runat="server" Class="form-control border-0 p-0 m-0" />
            </div>

            <%--Input para el nombre del usuario--%>
            <div class="form-floating mb-3">
                <asp:TextBox ID="InputName" runat="server" CssClass="form-control" />
                <label for="floatingInputName">Nombre</label>

                <asp:RequiredFieldValidator
                    ID="RFV_InputName"
                    runat="server"
                    ControlToValidate="InputName"
                    ErrorMessage="Campo Obligatorio"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>

            <%--Input para la fecha de nacimiento del usuario--%>
            <div class="form-floating mb-3">
                <asp:TextBox ID="InputBirthdate" runat="server" TextMode="date" class="form-control" />
                <label for="floatingInputBirthdate">Fecha de nacimiento</label>

                <asp:RequiredFieldValidator
                    ID="rfvBirthdate"
                    runat="server"
                    ControlToValidate="InputBirthdate"
                    ErrorMessage="Fecha de nacimiento es obligatorio"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>

            <%--Dropdownlist para seleccionar el genero del usuario--%>
            <div class="mb-3">
                <label class="form-label">Género</label>

                <asp:DropDownList
                    ID="ddlGender"
                    runat="server"
                    CssClass="form-select">
                </asp:DropDownList>

                <asp:RequiredFieldValidator
                    ID="rfvGender"
                    runat="server"
                    ControlToValidate="ddlGender"
                    InitialValue=""
                    ErrorMessage="Debe seleccionar un género"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>

            <div class="form-floating mb-3 d-flex flex-column align-items-center">
                <asp:Button ID="Btn_Send" runat="server" Text="Enviar" OnClick="Btn_Send_Click" CssClass="btn btn-primary mt-5" Width="80%"/>
            </div>
            <asp:HiddenField ID="selectedGender" runat="server" />
        </div>

    </div>
</asp:Content>

