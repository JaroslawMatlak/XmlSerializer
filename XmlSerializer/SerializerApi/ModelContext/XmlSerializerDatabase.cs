using System;
using System.Collections.Generic;
using System.Data.Entity;
using SerializerApi.Models;

namespace SerializerApi.ModelContext
{
    public class XmlSerializerDatabase:DbContext, ISerializerDataContext
    {
        public XmlSerializerDatabase() : base()
        {
        }
        
        public DbSet<RequestModel> RequestModels { get; set; }
    }
}