# LorenzPerson

## Aufgabe

"Create a small ASP.NET 6 web API using Swagger/OpenAPI as UI. Implement one example controller that allows to create, read, update and delete an entity of a list of people. Please use the person attributes below (get request version 1) to define a person, you are free to add additional ones if needed. It is not needed to use any persistence layer like a database or a file. Storage in memory is sufficient. Please provide the API in two versions. The differences are shown below."
Person API version 1 Get request:
Firstname, Surename, Gender (m/w), Birthday

Person API version 2 Get request:
Firstname, Surename, Gender (m/w/d), Birthday, City, Country

All persons accessible through API version 1 have to be accessible through API version 2"

## Abgrenzung

* inmemory database -> no migrations possible
* ORM not defined -> EF
* versioning schema not defined -> URI & header
* authentication is not defined -> no IdentityServer
* authorization is not defined
* SSL is not defined
* async is not defined -> no async
* not defined: howto handle people with gender diverse in v1
* not defined: howto handle v1 updates on v2 data

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


---
``` mermaid
flowchart TB
    %% Styles
    classDef client fill:#f9f,stroke:#333,stroke-width:2px
    classDef api fill:#aef,stroke:#333,stroke-width:2px
    classDef service fill:#afa,stroke:#333,stroke-width:2px
    classDef data fill:#fea,stroke:#333,stroke-width:2px
    classDef middleware fill:#ddd,stroke:#333,stroke-width:2px
    classDef v1 fill:#cef,stroke:#333,stroke-width:2px
    classDef v2 fill:#cfe,stroke:#333,stroke-width:2px

    %% Client Layer
    SwaggerUI["Swagger UI"]:::client
    RESTClients["REST Clients"]:::client
    click RESTClients "https://github.com/xantilon/LorenzPerson/blob/master/RESTtesting/Person.rest"

    %% API Layer
    ApiVersioning["API Versioning Middleware"]:::middleware
    click ApiVersioning "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Helpers/Versioning/ConfigureApiVersioning.cs"
    
    SwaggerConfig["Swagger Configuration"]:::middleware
    click SwaggerConfig "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Helpers/Swagger/ConfigureSwaggerOptions.cs"

    V1Controller["v1 PersonController"]:::v1
    click V1Controller "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Controllers/v1/PersonController.cs"
    V2Controller["v2 PersonController"]:::v2
    click V2Controller "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Controllers/v2/PersonController.cs"

    %% Service Layer
    V1DTOs["v1 DTOs"]:::v1
    click V1DTOs "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Data/DTOs/v1/PersonDto.cs"
    V2DTOs["v2 DTOs"]:::v2
    click V2DTOs "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Data/DTOs/v2/PersonDto.cs"
    
    V1Mapping["v1 Mapping Service"]:::v1
    click V1Mapping "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Services/Mapping/v1/PersonMappingService.cs"
    V2Mapping["v2 Mapping Service"]:::v2
    click V2Mapping "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Services/Mapping/v2/PersonMappingService.cs"

    V1Gender["v1 Gender Enum"]:::v1
    click V1Gender "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Helpers/Enums/v1/eGender.cs"
    V2Gender["v2 Gender Enum"]:::v2
    click V2Gender "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Helpers/Enums/v2/eGender.cs"

    %% Data Layer
    PersonEntity["Person Entity Model"]:::data
    click PersonEntity "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Data/Models/Person.cs"
    Database["LorenzContext\n(In-Memory Database)"]:::data
    click Database "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Data/LorenzContext.cs"
    SampleData["Sample Data Generator"]:::data
    click SampleData "https://github.com/xantilon/LorenzPerson/blob/master/PersonApi/Helpers/SampleData/PersonFaker.cs"

    %% Connections
    SwaggerUI & RESTClients --> ApiVersioning
    ApiVersioning --> V1Controller & V2Controller
    SwaggerConfig -.-> SwaggerUI
    
    V1Controller --> V1DTOs
    V2Controller --> V2DTOs
    
    V1DTOs <--> V1Mapping
    V2DTOs <--> V2Mapping
    
    V1Gender --> V1Mapping
    V2Gender --> V2Mapping
    
    V1Mapping & V2Mapping --> PersonEntity
    PersonEntity --> Database
    SampleData --> Database

    %% Legend
    subgraph Legend
        Client["Client Component"]:::client
        API["API Component"]:::api
        Service["Service Component"]:::service
        DataStore["Data Component"]:::data
        V1Comp["Version 1"]:::v1
        V2Comp["Version 2"]:::v2
        Middle["Middleware"]:::middleware
    end
```
