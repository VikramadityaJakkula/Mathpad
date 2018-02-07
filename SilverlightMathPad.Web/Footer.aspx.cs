using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilverlightMathPad.Web
{
    public partial class Footer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // If cookie is USA then show USA Div 


            {
                if ((Request.Cookies["UserCountry"] != null))
                {

                    if (Request.Cookies["UserCountry"].Value.ToString() == "USA")
                    {

                        divIndia.Visible = false;
                        divUK.Visible = false;

                        divUSA.Visible = true;
                    }
                    else if (Request.Cookies["UserCountry"].Value.ToString() == "India")
                    {

                        divUSA.Visible = false;
                        divUK.Visible = false;

                        divIndia.Visible = true;
                    }
                    else if (Request.Cookies["UserCountry"].Value.ToString() == "UK")
                    {
                        divUSA.Visible = false;
                        divIndia.Visible = false;

                        divUK.Visible = true;
                    }
                }

                if ((Request.QueryString["UserCountry"] != null))
                {
                    if (Request.QueryString["UserCountry"] == "USA")
                    {

                        divIndia.Visible = false;
                        divUK.Visible = false;

                        divUSA.Visible = true;
                    }
                    else if (Request.QueryString["UserCountry"] == "India")
                    {

                        divUSA.Visible = false;
                        divUK.Visible = false;

                        divIndia.Visible = true;
                    }
                    else if (Request.QueryString["UserCountry"] == "UK")
                    {

                        divUSA.Visible = false;
                        divIndia.Visible = false;

                        divUK.Visible = true;
                    }
                    else if (Request.QueryString["UserCountry"] == "Other")
                    {

                        divIndia.Visible = false;
                        divUK.Visible = false;

                        divUSA.Visible = true;
                    }

                }



                if ((Request.QueryString["UserCountry"] != null))
                {


                    if (Request.QueryString["UserCountry"] == "India")
                    {


                        Response.Cookies["UserCountry"].Value = "India";


                        Response.Cookies["UserCountry"].Expires = DateTime.MaxValue;
                    }

                    if (Request.QueryString["UserCountry"] == "USA")
                    {


                        Response.Cookies["UserCountry"].Value = "USA";


                        Response.Cookies["UserCountry"].Expires = DateTime.MaxValue;
                    }

                    if (Request.QueryString["UserCountry"] == "Other")
                    {

                        Response.Cookies["UserCountry"].Value = "USA";


                        Response.Cookies["UserCountry"].Expires = DateTime.MaxValue;
                    }

                    if (Request.QueryString["UserCountry"] == "UK")
                    {

                        Response.Cookies["UserCountry"].Value = "UK";


                        Response.Cookies["UserCountry"].Expires = DateTime.MaxValue;

                    }
                }


            }

            // If cookie is India then show India Div 

            // If no cookie then show USA Div 

            //Put user code to initialize the page here 
            //If Not IsNothing(Request.Cookies("StudentId")) Then 
            // If (Request.Cookies("StudentId").Value <> "") Then 
            // If Not IsNothing(Request.Cookies("StudentMode")) Then 
            // If Request.Cookies("StudentMode").Value.ToLower <> "preview" Or Request.Cookies("StudentMode").Value = "" Then 
            // anchUserStatus.InnerHtml = "<span class=FooterOuterLink>Account</span>" 
            // anchUserStatus.HRef = "EditAccount.aspx" 
            // lnkPp.HRef = "Help.aspx" 
            // Else 
            // anchUserStatus.InnerHtml = "<span class=FooterOuterLink>Register</span>" 
            // anchUserStatus.HRef = "Registration.aspx" 
            // lnkPp.HRef = "help_school_inst.aspx" 
            // End If 
            // End If 
            // End If 
            //End If 

        }
    }
}