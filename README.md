# DataReaderMapper

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
```
