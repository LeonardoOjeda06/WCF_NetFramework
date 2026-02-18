using DemoWCF.Presentation.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DemoWCF.Presentation
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadGender();
        }

        private void LoadGender()
        {
            var genders = new List<ListItem>
            {
                new ListItem("--- Seleccionar Genero ---", ""),
                new ListItem("Masculino", "M"),
                new ListItem("Femenino", "F")
            };

            ddlGender.DataSource = genders;
            ddlGender.DataTextField = "Text";
            ddlGender.DataValueField = "Value";
            ddlGender.DataBind();
        }

        protected void Btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                UserServiceClient client = new UserServiceClient();

                var userDto = new UserDto()
                {
                    Name = InputName.Text,
                    Birthdate = Convert.ToDateTime(InputBirthdate.Text),
                    Gender = ddlGender.SelectedItem.Text
                };

                client.Add(userDto);

                contentMessage.Visible = true;
                LabelMessage.ForeColor = System.Drawing.Color.Green;
                LabelMessage.Text = "Usuario agregado correctamente";
            }
            catch (FaultException ex)
            {
                contentMessage.Visible = true;
                LabelMessage.ForeColor = System.Drawing.Color.Red;
                LabelMessage.Text = ex.Message;
            }
        }
    }
}