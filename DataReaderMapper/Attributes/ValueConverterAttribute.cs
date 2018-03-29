using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bharat.DataReaderMapper.Attributes
{
    public abstract class ValueConverterAttribute : Attribute
    {
        public abstract object Convert(object value);
    }

    public class Int32ValueConverter : ValueConverterAttribute
    {
        public override object Convert(object value)
        {
            return System.Convert.ToInt32(value);
        }
    }

}
