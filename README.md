# BlogEngineWebApi
REST API storing data in a SQL database. Using DDD Architecture.

BlogEngineWebApi(Set as Startup Proyect)

The purpose of this API is to be able to search, create and edit blogs and categories. Only blog entries with a publication date equal to or prior to the current date should be exposed through the API. Lists of blog entries
should always be sorted by descending publication date. All routes must return JSON. The API mustimplement the following routes:

• /posts

• /posts/[ID]

• /categories

• /categories/[ID]

• /categories/[ID]/posts

Data Model
The blog consists of a series of posts which are grouped by category.

Technology stack

•.NET Core 3.1
•MediatR
•AutoMapper
•xUnit
•Moq
•SQLServer
