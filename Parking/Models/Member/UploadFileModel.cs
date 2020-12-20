using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Member
{
    public class UploadFileModel
    {

        public string reqId { get; set; }
        
        public string DocTypeId { get; set; }
      
        public HttpPostedFileBase PathFile { get; set; }

        public List<DocTypeList> docTypeList { get; set; }
        public List<DocList> doc_list { get; set; }
    }

    public class DocTypeList
    {
        public string docTypeId { get; set; }

        public string docType { get; set; }
    }

    public class DocList
    {
        
        public string docType { get; set; }
        
        public string DocName { get; set; }
       
        public string UploadDate { get; set; }

        public string PathFile { get; set; }

    }
}