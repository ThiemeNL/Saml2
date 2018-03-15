﻿using Sustainsys.Saml2.Metadata;
using Sustainsys.Saml2.StubIdp.Models;
using System.Security.Cryptography.Xml;
using System.Web.Mvc;

namespace Sustainsys.Saml2.StubIdp.Controllers
{
    public class MetadataController : Controller
    {
        // GET: Metadata
        public ActionResult Index()
        {
            return Content(
                CreateMetadataString(),
                "application/samlmetadata+xml");
        }

        private static string CreateMetadataString()
        {
            return MetadataModel.CreateIdpMetadata()
                            .ToXmlString(CertificateHelper.SigningCertificate,
                            SignedXml.XmlDsigRSASHA256Url);
        }

        public ActionResult BrowserFriendly()
        {
            return Content(
                CreateMetadataString(),
                "text/xml");
        }
    }
}