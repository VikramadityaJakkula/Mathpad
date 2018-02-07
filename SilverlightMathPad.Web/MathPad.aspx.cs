using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SilverlightMathPad.Web
{
    public partial class MathPad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Put user code to initialize the page here 
            // This code checks for community link, its not visible at the main page 
            // This is settin community link to false so that it is not visible 


            {
                string ExamId = null;
                string ExamIdTemp = null;

                ExamId = System.Configuration.ConfigurationManager.AppSettings["ExamId"];
                ExamIdTemp = System.Configuration.ConfigurationManager.AppSettings["ExamIdTemp"];

                if ((ExamId != null))
                {
                    if (!string.IsNullOrEmpty(ExamId))
                    {
                        dvHelp.Visible = true;
                    }
                }
                hrefComunity.Visible = false;
                // This is an html server anchor control 

                DataSet ds = default(DataSet);
                int TotalPoints = 0;
                DataSet dsExamname = default(DataSet);

                //DONE 
                if (((ExamId == null)))
                {
                    if (((ExamIdTemp != null)))
                    {
                        if ((!string.IsNullOrEmpty(ExamIdTemp)))
                        {

                          //  dsExamname = GetDataSet("GetExamNameForGivenExamID '" + ExamIdTemp + "'");
                            // Now we are executing a stored procedure GetExamNameForGivenExamID 

                            //if ((dsExamname.Tables(0).Rows.Count > 0))
                            //{
                              //  hrefHelp.Visible = true;
                               // hrefHelp.HRef = "http://www.quizmine.com/help.aspx?ExamId=" + ExamId + "&HelpId=" + dsExamname.Tables(1).Rows(0).Item(0).ToString;
                            //}
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(ExamId))
                    {
                    }
                    
                }

                //DONEE 
                if (((ExamIdTemp != null)))
                {
                    if ((!string.IsNullOrEmpty(ExamIdTemp)))
                    {
                        DataSet dsForumid = default(DataSet);
                        if (((ExamId == null)))
                        {
                       //     dsForumid = GetDataSet("GetForumId'" + ExamIdTemp + "'");
                        }
                        else
                        {
                         //   dsForumid = GetDataSet("GetForumId'" + ExamId + "'");

                        }
                    }
                    

                }


                if (!Page.IsPostBack)
                {

                }
                
                if (Request.Url.ToString().ToLower().IndexOf("login.aspx") > -1)
                {
                    //Or Request.Url.ToString.ToLower.IndexOf("viewpreview.aspx") > -1 Then 
                    //Login.Visible = false;
                    //anchRegistration.Visible = false;
                    //lblSeperator.Visible = false;
                    //lblGuest.Visible = false;
                    Response.Cookies["StudentId"].Value = "";
                    //divOfModes.Visible = false;
                }
                // Response.Write("") 
                //ProgressReport.Visible = true;
                if ((ExamIdTemp == null))
                {
                  //  ProgressReport.Visible = false;
                   // anchRegistration.Visible = false;
                    //lblSeperator.Visible = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(ExamIdTemp))
                    {
                        //if (anchRegistration.Visible == true)
                        //{
                        //    if (!string.IsNullOrEmpty(ExamId) & Request.Url.ToString().ToLower().IndexOf("categories.aspx") > -1)
                        //    {
                        //        anchRegistration.HRef = "http://www.quizmine.com/Registration.aspx?ExamId=" + ExamId;
                        //        Login.HRef = "http://www.quizmine.com/login.aspx?EId=" + ExamId;
                        //    }
                        //    else
                        //    {
                        //        anchRegistration.HRef = "http://www.quizmine.com/Registration.aspx?ExamId=" + ExamIdTemp;
                        //        Login.HRef = "http://www.quizmine.com/login.aspx?EId=" + ExamIdTemp;

                        //    }
                       // }
                    }
                }
                EnableStudentSuccess.Visible = false;
                if (Request.Url.ToString().ToLower().IndexOf("default.aspx") > -1 | Request.Url.ToString().ToLower().IndexOf("registration.aspx") > -1 | Request.Url.ToString().ToLower().IndexOf("login.aspx") > -1)
                {
                    //ProgressReport.Visible = false;
                    //StudyMode.Visible = false;
                    //CoachingMode.Visible = false;
                    //ExamMode.Visible = false;
                    //referFriend.Visible = false;
                    hrefComunity.Visible = false;
                    hrefHelp.Visible = false;
                }
                // EnableStudentSuccess.Visible = True 

                if ((Request.Url.ToString().ToLower().IndexOf("registration.aspx") > -1))
                {
                    //divForLoginStudent.Visible = false;
                    //divOfModes.Visible = false;
                    //anchRegistration.Visible = false;
                    //lblSeperator.Visible = false;
                }
            }
         
        }
    }
}