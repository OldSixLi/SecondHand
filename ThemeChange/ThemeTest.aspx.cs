using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CST.InnovationVolumeSystem.UI;
using SecondHand.DAL;
using ThemeChange.Extension;

namespace ThemeChange
{
    public partial class ThemeTest : System.Web.UI.Page
    {
        protected void page_PreInit(object sender, EventArgs e)
        {
            //ThemeStatic.Getthemename(1006);
            Page.Theme = ThemeStatic.Theme;
        }

     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
            }
        }

        public void Class()
        {
            Theme = Theme == "Bootstrap" ? "Admin" : "Bootstrap";
        }




        public void ChangeTheme(string theme, int userid)
        {
            string sql = @"update Users set UUU='" + theme + "' where userid=" + userid;


            DBHelper.ExecuteNonQuery(sql);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
     
      
    }
}