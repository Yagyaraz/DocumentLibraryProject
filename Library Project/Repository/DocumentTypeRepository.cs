using Library_Project.Interface;
using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project.Repository
{
    public class DocumentTypeRepository:IDocumentType
    {
        private readonly DLMSDatabaseEntities _context = new DLMSDatabaseEntities();
        public DocumentTypeRepository(DLMSDatabaseEntities context)
        {
            _context = context;
        }
        public int AddDocumentType(DocumentTypeViewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                Document_Type dt = new Document_Type()
                {
                    Name = model.Name,
                    IsDelete=false

                };

                context.Document_Type.Add(dt);
                context.SaveChanges();
                return dt.Id;
            }
        }

        public List<DocumentTypeViewModel> GetAllDocumentTypes()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document_Type.Where(x=>x.IsDelete==false)
                    .Select(x => new DocumentTypeViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).ToList();

                return result;
            }

        }

        public DocumentTypeViewModel GetDocumentType(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document_Type.Where(x => x.Id == id && x.IsDelete == false)
                    .Select(x => new DocumentTypeViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateDocumentType(int id, DocumentTypeViewModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var dtype = context.Document_Type.FirstOrDefault(x => x.Id == id);
                if (dtype != null)
                {
                    dtype.Name = model.Name;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteDocumentType(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var dtype = context.Document_Type.FirstOrDefault(x => x.Id == id);
                if (dtype != null && dtype.IsDelete==false)
                {
                    dtype.IsDelete=true;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
