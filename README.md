# LorenzPerson

## Aufgabe

"Create a small ASP.NET 6 web API using Swagger/OpenAPI as UI. Implement one example controller that allows to create, read, update and delete an entity of a list of people. Please use the person attributes below (get request version 1) to define a person, you are free to add additional ones if needed. It is not needed to use any persistence layer like a database or a file. Storage in memory is sufficient. Please provide the API in two versions. The differences are shown below."
Person API version 1 Get request:
Firstname, Surename, Gender (m/w), Birthday

Person API version 2 Get request:
Firstname, Surename, Gender (m/w/d), Birthday, City, Country

All persons accessible through API version 1 have to be accessible through API version 2"

## Abgrenzung

* inmemory database
* ORM not defined -> EF
* versioning schema not defined -> URI & header
* authentication is not defined
* authorization is not defined

## Akzeptanzkriterien

* Person controller has full CRUD
* controller has 2 versions
* version 2 has additional properties
* data is not limited by either version
