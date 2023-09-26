using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Interface
{
    public interface IDocumentType
    {
        int AddDocumentType(DocumentTypeViewModel model);
        List<DocumentTypeViewModel> GetAllDocumentTypes();
        DocumentTypeViewModel GetDocumentType(int id);
        bool UpdateDocumentType(int id, DocumentTypeViewModel model);
        bool DeleteDocumentType(int id);
    }
}