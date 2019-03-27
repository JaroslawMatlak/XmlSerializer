﻿using System;

namespace SerializerApi.Models
{
    public class RequestModel
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public int? Visits { get; set; }
        public DateTime Date { get; set; }
    }
}