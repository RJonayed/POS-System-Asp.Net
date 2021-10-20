using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Module6ASPDotNet.DAL
{
    public static class Connection
    {
        public static string GetConnectionString()
        {
            string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            return conStr;
        }
    }
}