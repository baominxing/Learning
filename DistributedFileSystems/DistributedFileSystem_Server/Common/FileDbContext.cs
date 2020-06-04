using FileCenter.Model;
using System.Data.Entity;

namespace FileCenter
{
    public class FileCenterDbContext : DbContext
    {
        public FileCenterDbContext() : base("FileCenterEntities") { }

        public IDbSet<SystemFiles> SystemFiles { get; set; }

        public IDbSet<Operate> Operates { get; set; }

        public IDbSet<PartialFileModel> PartialFileModels { get; set; }
    }
}
