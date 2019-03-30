using SerializerApi.Models;
using System.Data.Entity;

namespace SerializerApi.ModelContext
{
    public interface ISerializerDataContext
    {
        DbSet<RequestModel> RequestModels { get; set; }
        int SaveChanges();
    }
}
