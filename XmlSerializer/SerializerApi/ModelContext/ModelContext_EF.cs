using System.Data.Entity;
using SerializerApi.Models;

namespace SerializerApi.ModelContext
{
    public class ModelContext_EF:DbContext, IModelContext
    {
        public ModelContext_EF() : base()
        { }

        public DbSet<RequestModel> RequestModels { get; set; }
    }
}