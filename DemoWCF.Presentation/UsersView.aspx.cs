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

        // Si la fila está en modo edición, busca el DropDownList de
        // género (ddlGender) y preselecciona el valor
        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow &&
                (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddl =
                    (DropDownList)e.Row.FindControl("ddlGender");

                //Lee dinamicamente la propiedad de un objeto
                //DataBinder.Eval(objeto, "NombrePropiedad")
                string gender = DataBinder.Eval(e.Row.DataItem, "Gender")?.ToString();

                if (!string.IsNullOrEmpty(gender))
                {

                    //if (gender == "Masculino")
                    //{
                    //    gender = "M";
                    //}
                    //else if (gender == "Femenino")
                    //{
                    //    gender = "F";
                    //}

                    // permite que pueda mostrar en el ddl la opcion 0 --- Seleccionar ---
                    ListItem item = ddl.Items.FindByValue(gender);
                    if (item != null)
                        ddl.SelectedValue = gender;
                }
            }
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // obtengo el id del usuario a actualizar
            int id = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            // obtengo la fila que se está editando
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

            // le digo al form ninguna fila está en modo edición
            gvUsers.EditIndex = -1;
            CargarGrid();
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Obtengo el número de la fila a editar
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
            //le digo al form ninguna fila está en modo edición
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