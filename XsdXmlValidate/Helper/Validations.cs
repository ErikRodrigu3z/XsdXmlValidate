using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace XsdXmlValidate.Helper
{
    public class Validations
    {
        public string ValidateXmlUsingXSD(string xsd,string xml)
        { 
            try
            {

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add(null, XmlReader.Create(xsd)); 

                XmlReader xmlReader = XmlReader.Create(xml, settings);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);

                return "Success";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        } 


    }
}