Experimenting with GraphQL and .Net Core following [Building GraphQL APIs with ASP.NET Core](https://app.pluralsight.com/library/courses/building-graphql-apis-aspdotnet-core/table-of-contents) course on Pluralsight.

## Setup
* Ensure connection string is correct in `CarvedRock.Api/appsettings.json`
* Run migration in Package Manager Console:
  * Pick default project: `CarvedRock.Api`
  * `update-database`
  * Run the `CarvedRock.Api` project to seed the database