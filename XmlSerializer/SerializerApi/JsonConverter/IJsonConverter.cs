﻿using SerializerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerApi.JsonConverter
{
    public interface IJsonConverter
    {
        RequestModel ConvertJsonStringToRequestModel(string jsonString);
    }
}