using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Utilities;

namespace ApplyTemplateToSubSiteBug
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string subSiteUrl = "https://yoursharepointonlineurlwithsubsite";
                var username = "username";
                var password = "password";

                using (var context = new ClientContext(subSiteUrl))
                {
                    context.Credentials = new SharePointOnlineCredentials(username, EncryptionUtility.ToSecureString(password));

                    // Applying a empty template to a subsite gives exception: startIndex cannot be larger than length of string.\r\nParameter name: startIndex  
                    var template = new ProvisioningTemplate();
                    context.Web.ApplyProvisioningTemplate(template);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
