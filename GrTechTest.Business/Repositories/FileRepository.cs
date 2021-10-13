using GrTechTest.Business.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GrTechTest.Business.Repositories
{
    public class FileRepository
    {
        public int InsertFile(File file)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            grTechTestDbContext.File.Add(file);
            return grTechTestDbContext.SaveChanges();
        }

        public int UpdateFile(File file)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var fileExist = grTechTestDbContext.File.Find(file.Id);
            grTechTestDbContext.Entry(fileExist).State = EntityState.Detached;
            grTechTestDbContext.Entry(file).State = EntityState.Modified;
            return grTechTestDbContext.SaveChanges();
        }

        public int PermanentDeleteFile(string id)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var file = grTechTestDbContext.File.Find(id);
            grTechTestDbContext.File.Remove(file);
            return grTechTestDbContext.SaveChanges();
        }

        public List<File> GetFiles()
        {
            return new GrTechTestDbContext().File.Where(file => !file.IsDeleted).OrderByDescending(file => file.UpdatedOn).ToList();
        }

        public List<File> GetDeletedFiles()
        {
            return new GrTechTestDbContext().File.Where(file => file.IsDeleted).OrderByDescending(file => file.UpdatedOn).ToList();
        }

        public File GetFileById(string id)
        {
            return new GrTechTestDbContext().File.FirstOrDefault(file => !file.IsDeleted && file.Id == id);
        }

        public File GetDeletedFileById(string id)
        {
            return new GrTechTestDbContext().File.FirstOrDefault(file => file.IsDeleted && file.Id == id);
        }
    }
}