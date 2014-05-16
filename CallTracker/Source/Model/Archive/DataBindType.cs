using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallTracker.Model
{
    public class DataBindType
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public DataBindType(string _name, string _path)
        {
            Name = _name;
            Path = _path;
        }
    }
}
