using System.IO;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Transfermarkt.WebAPI.Providers
{
    public class ExcelProvider
    {
        public static void ConvertToStream(string templateFile, string data, Stream stream)
        {
            if (!string.IsNullOrEmpty(data))
            {
                XPathDocument xpd;

                using (StringReader sr = new StringReader(data))
                {
                    xpd = new XPathDocument(sr);
                }

#if DEBUG
                XslCompiledTransform xslt = new XslCompiledTransform(true);
#else
                XslCompiledTransform xslt = new XslCompiledTransform(false);
#endif
                xslt.Load(templateFile);
                xslt.Transform(xpd, null, stream);
            }
        }
    }
}
