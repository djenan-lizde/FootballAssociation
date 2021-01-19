using Microsoft.AspNetCore.Mvc.Filters;

namespace Transfermarkt.WebAPI.Attributes
{
    public class ExcelTemplateAttribute : ActionFilterAttribute
    {
        public ExcelTemplateAttribute(string template)
        {
            Template = template;
        }

        public string Template { get; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Request.Headers.Add("Template", Template);

            base.OnActionExecuting(context);
        }
    }
}
