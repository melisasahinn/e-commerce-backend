using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogParamater
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
    }
}