using Library_Project.Interface;
using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Library_Project.Repository
{
    public class DocumentSourceRepository : IDocumentSource
    {
        private readonly DLMSDatabaseEntities _context = new DLMSDatabaseEntities();
        public DocumentSourceRepository(DLMSDatabaseEntities context)
        {
            _context = context;
        }
        public int AddDocumentSource(DocumentSourceViewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                Document_Source docsource = new Document_Source()
                {
                    Name = model.Name,
                    IsDelete = false

                };

                context.Document_Source.Add(docsource);
                context.SaveChanges();
                return docsource.Id;
            }
        }

        public List<DocumentSourceViewModel> GetAllDocumentSource()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document_Source.Where(x=>x.IsDelete==false)
                    .Select(x => new DocumentSourceViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).ToList();

                return result;
            }

        }

        public DocumentSourceViewModel GetDocumentSource(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document_Source
                    .Where(x => x.Id == id && x.IsDelete==false)
                    .Select(x => new DocumentSourceViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateDocumentSource(int id, DocumentSourceViewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var docsource = context.Document_Source.FirstOrDefault(x => x.Id == id);
                if (docsource != null)
                {
                    docsource.Name = model.Name;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteDocumentSource(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var docsource = context.Document_Source.FirstOrDefault(x => x.Id == id);
                if (docsource != null && docsource.IsDelete==false)
                {
                    docsource.IsDelete = true;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
