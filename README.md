Experimenting with GraphQL and .Net Core following [Building GraphQL APIs with ASP.NET Core](https://app.pluralsight.com/library/courses/building-graphql-apis-aspdotnet-core/table-of-contents) course on Pluralsight.

## Setup
* Ensure connection string is correct in `CarvedRock.Api/appsettings.json`
* Run migration in Package Manager Console:
  * Pick default project: `CarvedRock.Api`
  * `update-database`
  * Run the `CarvedRock.Api` project to seed the database

## Demonstrates
* Query
* Mutation
* Subscription

# Run
* Run `CarvedRock.Api` project
* Experiment with GraphQL Playground here: https://localhost:44369/ui/playground
* Use React + Apollo client application here: https://github.com/johnnyoshika/carvedrock-graphql-client

## Known Problems
### DbContext Scope
DbContext is scoped by default and DbContext doesn't support parallel requests, so queries like this results in an exception:
```
 {
	product(id: 1) {
		name
    reviews {
      review
    }
  }
  reviews(productId:2) {
    review
  }
}
```
Result:
```
{
  "data": {
    "product": {
      "name": "Mountain Walkers",
      "reviews": [
        {
          "review": "..."
        },
        ...
      ]
    },
    "reviews": null
  },
  "errors": [
    {
      "message": "GraphQL.ExecutionError: Error trying to resolve reviews.\r\n ---> System.InvalidOperationException: A second operation started on this context before a previous operation completed. This is usually caused by different threads using the same instance of DbContext.",
      ...
    }
  ]
}
```
A way around it is to make DbContext transient or other scoping strategy.

More info:
https://github.com/graphql-dotnet/graphql-dotnet/issues/863
https://github.com/CodeFuller/music-library-api/commit/5be7f79f5932be5741389e70d7b21020c7c045be