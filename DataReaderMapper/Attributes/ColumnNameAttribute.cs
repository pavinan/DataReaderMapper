using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bharat.DataReaderMapper.Attributes
{
    public class ColumnNameAttribute : Attribute
    {
        public string Name { get; private set; }
        public ColumnNameAttribute(string name)
        {
            Name = name;
        }
    }
}
