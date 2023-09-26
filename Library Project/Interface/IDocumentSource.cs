using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Interface
{
    public interface IDocumentSource
    {
        int AddDocumentSource(DocumentSourceViewModel model);
        List<DocumentSourceViewModel> GetAllDocumentSource();
        DocumentSourceViewModel GetDocumentSource(int id);
        bool UpdateDocumentSource(int id, DocumentSourceViewModel model);
        bool DeleteDocumentSource(int id);

    }
}