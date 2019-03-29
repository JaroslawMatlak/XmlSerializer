using SerializerApi.Models;
using System.Data.Entity;

namespace SerializerApi.ModelContext
{
    interface IModelContext
    {
        int SaveChanges();
        void Dispose();
        DbSet<RequestModel> RequestModels { get; set; }
    }
}
