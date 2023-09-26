using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Interface
{
    public interface IDocument
    {
        int AddDocument(DocumentViewModel model);
        List<DocumentViewModel> GetAllDocuments();
        DocumentViewModel GetDocument(int id);

        bool UpdateDocument(int id, DocumentViewModel model);
        bool DeleteDocument(int id);

    }
}