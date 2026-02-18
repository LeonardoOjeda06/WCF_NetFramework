using DemoWCF.Presentation.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWCF.Presentation
{
    public partial class UsersView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGrid();
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow &&
                (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddl =
                    (DropDownList)e.Row.FindControl("ddlGender");

                string gender = DataBinder.Eval(e.Row.DataItem, "Gender")?.ToString();

                if (!string.IsNullOrEmpty(gender))
                {
                    ListItem item = ddl.Items.FindByValue(gender);
                    if (item != null)
                        ddl.SelectedValue = gender;
                }
            }
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvUsers.Rows[e.RowIndex];

            TextBox txtNombre = (TextBox)row.FindControl("txtNombre");
            TextBox txtFecha = (TextBox)row.FindControl("txtFecha");
            DropDownList ddlGenero = (DropDownList)row.FindControl("ddlGender");

            UserDto dto = new UserDto
            {
                Id = id,
                Name = txtNombre.Text,
                Birthdate = Convert.ToDateTime(txtFecha.Text),
                Gender = ddlGenero.SelectedItem.Text,
            };

            UserServiceClient client = new UserServiceClient();
            client.Update(dto);

            gvUsers.EditIndex = -1;
            CargarGrid();
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            CargarGrid();
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            UserServiceClient client = new UserServiceClient();
            client.Delete(id);

            CargarGrid();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            CargarGrid();
        }

        private void CargarGrid()
        {
            UserServiceClient client = new UserServiceClient();

            var listaUsuarios = client.GetAll();

            gvUsers.DataSource = listaUsuarios;
            gvUsers.DataBind();
        }
    }
}