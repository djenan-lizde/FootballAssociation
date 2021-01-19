using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Transfermarkt.WebAPI.Providers;

namespace Transfermarkt.WebAPI.Formatters
{
    public class ExcelOutputFormatter : OutputFormatter
    {
        public ExcelOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/vnd.ms-excel"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            try
            {
                var response = context.HttpContext.Response;
                string xml = GetXMLFromObject(context.Object);

                var accept = context.HttpContext.Request.Headers["Accept"].FirstOrDefault();
                response.ContentType = accept;

                var templateFile = context.HttpContext.Request.Headers["Template"].FirstOrDefault();
                ExcelProvider.ConvertToStream(templateFile, xml, response.Body);

                return Task.CompletedTask;
            }
            catch
            {
                throw;
            }
        }

        private string GetXMLFromObject(object o)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter textWriter = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                textWriter = new XmlTextWriter(stringWriter);
                serializer.Serialize(textWriter, o);
            }
            finally
            {
                stringWriter.Close();
                if (textWriter != null)
                {
                    textWriter.Close();
                }
            }
            return stringWriter.ToString();
        }
    }
}
