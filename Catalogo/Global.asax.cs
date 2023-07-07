using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Catalogo
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string Host = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //if(Session.Count > 0)
            //    Session.Clear();
        }
    }
}