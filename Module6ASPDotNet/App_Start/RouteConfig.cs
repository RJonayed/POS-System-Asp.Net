using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Module6ASPDotNet
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Temporary;
            routes.EnableFriendlyUrls(settings);         
            routes.MapPageRoute("Masters", "MasterInfo", "~/MasterInfo.aspx");
            routes.MapPageRoute("Default", "Home", "~/default.aspx");
            routes.MapPageRoute("ObjCRUD", "ObjCrud", "~/ObjectDSCRUD.aspx");
            routes.MapPageRoute("SQLCRUD", "SqlCrud", "~/SqlDS.aspx");
            routes.MapPageRoute("EntityCrud", "EntityCrud", "~/EntityCrud.aspx");
            routes.MapPageRoute("AllView", "View", "~/AllView.aspx");
            routes.MapPageRoute("ListView", "List", "~/ListView.aspx");
            routes.MapPageRoute("Details", "Details", "~/DetailsView.aspx");
            routes.MapPageRoute("FormViews", "FormView", "~/FormView.aspx");
            routes.MapPageRoute("MultiViews", "MultiView", "~/MultiView.aspx");
            routes.MapPageRoute("ErrorHandling", "DefaultError", "~/DefaultError.aspx");
            routes.MapPageRoute("Partys", "Party", "~/Party.aspx");
            routes.MapPageRoute("Purchases", "Purchase", "~/Purchase.aspx");
            routes.MapPageRoute("Reports", "Report", "~/Report.aspx");
            routes.MapPageRoute("Mails", "Mail", "~/SendMail.aspx");
            routes.MapPageRoute("Settings", "Setting", "~/Setting.aspx");
            routes.MapPageRoute("Sales", "Sale", "~/Sale.aspx");
        }
    }
}
