using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_ProcessRequest.Modules;

namespace Web_ProcessRequest.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_init(object sender, EventArgs e)
        {
            MyModule.WriteLog(this.GetType() + "Page:Init");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MyModule.WriteLog(this.GetType() + "Page:Load");
        }

        public override void Validate()
        {
            MyModule.WriteLog(this.GetType() + "Page:Validate");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MyModule.WriteLog(this.GetType() + "Page:Event");
        }

        protected override void Render(HtmlTextWriter output)
        {
            MyModule.WriteLog(this.GetType() + "Page:Render");
            base.Render(output);
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            MyModule.WriteLog(this.GetType() + "Page:UnLoad");
        }
    }
}