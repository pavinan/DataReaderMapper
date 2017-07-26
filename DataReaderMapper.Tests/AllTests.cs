using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataReaderMapper.Attributes;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataReaderMapper.Tests
{
    [TestClass]
    public class AllTests
    {
        [TestMethod]
        public void Sample()
        {
            var mapper = DataReaderMap<Employee>.CreateMap();

            var list = mapper.ProjectToEnumerable(Authenticate().CreateDataReader()).ToList();

        }


        public static DataTable Authenticate()
        {
            var dt = new DataTable();

            // TODO: 

            return dt;
        }

        class Employee
        {
            [Int32ValueConverter]
            [ColumnName("employeeID")]
            public int Id { set; get; }
            public string Name { get; set; }
            public DateTime AddedAt { set; get; }
            public DateTime UpdatedAt { set; get; }
        }

    }
}
