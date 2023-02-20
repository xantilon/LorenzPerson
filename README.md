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
* authentication is not defined -> no IdentityServer
* authorization is not defined
* SSL is not defined
* async is not defined -> no async
* not defined: howto handle people with gender diverse in v1
* not defined: 

## Akzeptanzkriterien

* Person controller has full CRUD
* controller has 2 versions
* version 2 has additional properties
* data is not limited by either version
* v1 does not show (or crash) people with gender diverse 

## Umsetzung

### Gender Erweiterung

Mein Ansatz: 

  Ausblenden der Diversen in v1. Diese sind nicht darstellbar

Nachteile:
  
  * v1 kann die mit v2 angelegten sehen, und auch bearbeiten. Dabei werden aber die Zusatzfelder gelöscht! RISIKO hoch!
  
--- 

mögliche Verbesserung: 

  Erweiterung des Models mit Info welche Version erstellt hat. Anzeige und Bearbeitung darf dann nur von gleicher oder höherer Version erfolgen.
  
Nachteile:

  wenn v2 einen Datensatz von v1 updated, wird er für v1 verschwinden 
