# DataReaderMapper

[![Build status](https://ci.appveyor.com/api/projects/status/x74id6uv4mqx6dg5/branch/master?svg=true)](https://ci.appveyor.com/project/pavinan/datareadermapper/branch/master)


Nuget link [https://www.nuget.org/packages/Bharat.DataReaderMapper/](https://www.nuget.org/packages/Bharat.DataReaderMapper/)

**Simple example**
```csharp
var list = (new DataTable()).CreateDataReader().ProjectToEnumerable<Employee>().ToList();
```

**With map**
```csharp
var mapper = DataReaderMap<Employee>.CreateMap();
var reader = (new DataTable()).CreateDataReader(); //example
var list = mapper.ProjectToEnumerable(reader).ToList();

public class Employee
{
    [Int32ValueConverter]
    [ColumnName("employeeID")]
    public int Id { set; get; }
    public string Name { get; set; }
    public DateTime AddedAt { set; get; }
    public DateTime UpdatedAt { set; get; }
}
```
