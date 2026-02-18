<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UsersView.aspx.cs" Inherits="DemoWCF.Presentation.UsersView" %>


<asp:Content ID="ContainerUsers"
    runat="server"
    ContentPlaceHolderID="MainContent">

    <div>
        <h1 class="m-3">Consultar usuarios</h1>
        <asp:GridView ID="gvUsers" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnRowDataBound="gvUsers_RowDataBound"
            OnRowUpdating="gvUsers_RowUpdating"
            OnRowEditing="gvUsers_RowEditing"
            OnRowCancelingEdit="gvUsers_RowCancelingEdit"
            OnRowDeleting="gvUsers_RowDeleting"
            HeaderStyle-CssClass="table-dark"
            CssClass="table table-striped table-hover table-bordered align-middle">

            <Columns>

                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombre"
                            runat="server"
                            Text='<%# Bind("Name") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate>
                        <%# Eval("Birthdate", "{0:dd/MM/yyyy}") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFecha"
                            runat="server"
                            Text='<%# Bind("Birthdate", "{0:yyyy-MM-dd}") %>'
                            TextMode="Date" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Genero">
                    <ItemTemplate>
                        <%# Eval("Gender") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlGender"
                            runat="server">
                            <asp:ListItem Text="--- Seleccionar ---" Value="" />
                            <asp:ListItem Text="Masculino" Value="M" />
                            <asp:ListItem Text="Femenino" Value="F" />
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField 
                    ShowEditButton="true"
                    ShowDeleteButton="true"
                    EditText="Modificar"
                    UpdateText="Guardar"
                    CancelText="Cancelar"
                    DeleteText="Eliminar"
                    ControlStyle-CssClass="btn btn-primary btn-sm" />

            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
