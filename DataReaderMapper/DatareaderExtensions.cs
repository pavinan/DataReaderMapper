using Bharat.DataReaderMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data
{
    public static class DatareaderExtensions
    {
        public static IEnumerable<T> ProjectToEnumerable<T>(this IDataReader datareader, DataReaderMap<T> mapper) where T : new()
        {
            return mapper.ProjectToEnumerable(datareader);
        }

        public static IEnumerable<T> ProjectToEnumerable<T>(this IDataReader datareader) where T : new()
        {
            var mapper = DataReaderMap<T>.CreateMap();
            return mapper.ProjectToEnumerable(datareader);
        }

    }
}
