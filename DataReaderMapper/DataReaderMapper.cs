using Bharat.DataReaderMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bharat.DataReaderMapper
{
    public class DataReaderMap<T> where T : new()
    {

        private readonly Dictionary<string, PropertyDetails> propertyCache = new Dictionary<string, PropertyDetails>();

        private DataReaderMap()
        {

        }

        public static DataReaderMap<T> CreateMap()
        {
            var map = new DataReaderMap<T>();

            var type = typeof(T);

            foreach (var prop in type.GetProperties())
            {
                var details = new PropertyDetails()
                {
                    PropertyInfo = prop
                };

                var name = prop.Name;

                var nameAttr = prop.GetCustomAttributes<ColumnNameAttribute>();
                if (nameAttr.Any())
                {
                    name = nameAttr.First().Name;
                }

                var converterAttr = prop.GetCustomAttributes<ValueConverterAttribute>();

                if (converterAttr.Any())
                {
                    details.Converter = converterAttr.FirstOrDefault();
                }


                map.propertyCache.Add(name, details);

            }

            return map;
        }

        public IEnumerable<T> ProjectToEnumerable(IDataReader reader)
        {

            var columns = Enumerable.Range(0, reader.FieldCount).Select(x => reader.GetName(x)).Distinct().ToArray();

            var props = propertyCache.Where(x => columns.Any(y => y == x.Key)).ToArray();

            while (reader.Read())
            {
                var res = new T();

                foreach (var prop in props)
                {
                    var value = reader[prop.Key];

                    if (value != null && value != DBNull.Value)
                    {
                        if (prop.Value.Converter != null)
                        {
                            prop.Value.PropertyInfo.SetValue(res, prop.Value.Converter.Convert(value));
                        }
                        else
                        {
                            prop.Value.PropertyInfo.SetValue(res, value);
                        }
                    }
                }

                yield return res;
            }
        }

        private class PropertyDetails
        {
            public PropertyInfo PropertyInfo { get; set; }
            public ValueConverterAttribute Converter { get; set; }
        }
    }
}
