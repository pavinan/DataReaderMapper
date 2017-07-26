# DataReaderMapper

Nuget link [https://www.nuget.org/packages/Bharat.DataReaderMapper/](https://www.nuget.org/packages/Bharat.DataReaderMapper/)

```csharp
var mapper = DataReaderMap<Employee>.CreateMap();
var reader = (new DataTable()).CreateDataReader(); //example
var list = mapper.ProjectToEnumerable(reader).ToList();
```
