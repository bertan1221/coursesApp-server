# CourseApp NET Core 3.1 App
The NET Core backend for the app

## Run the project
This should create a local database in (LocalDB)\MSSQLLocalDB, however if you receive an Access Denied error, create the database manually.
The database name is CoursesDb. Then run the project again and the migrations will be applied.

## Documentation
The documentation endpoint for the api is https://localhost:44358/documentation

If the documentation fails, change the the path of Swagger.xml

 <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    <DocumentationFile>C:\Users\Bertan\Desktop\projects\bertan\CoursesApp\API\Swagger.xml</DocumentationFile>
    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
    <WarningsAsErrors></WarningsAsErrors>
    <NoWarn>1701;1702;1591</NoWarn>
  </PropertyGroup>
