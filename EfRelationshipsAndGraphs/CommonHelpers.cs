using System.IO;
using System.Web.Mvc;

namespace EfRelationshipsAndGraphs
{
    public static class CommonHelpers
    {
        public static string RenderPartialToString(Controller controller, string viewName, ViewDataDictionary viewData, object model)
        {
            if (viewData == null)
            {
                controller.ViewData.Model = model;
            }
            else
            {
                viewData.Model = model;
            }

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext,
                                                  viewResult.View,
                                                  (viewData == null) ? controller.ViewData : viewData,
                                                  controller.TempData,
                                                  sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}