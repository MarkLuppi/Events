
# Events Portal

This is the Events Portal project as required in the previously provided document.  

The stated requirements were noted and addressed.  In the interest of completing the project on time, only limited work was done on test coverage and look-and-feel. Obviously, more could be done in both areas. 

## Implementation Notes

This deliverable was developed and built in Visual Studio 2022 on a Windows 11 machine, using the ASP Net Core 6 template for Angular.  The template's default package.json was modified to use Angular 13, as required.

The UI components were implemented with Angular Material, the List and Card components, and others.

The backend was implemented with Asp Net Web API and Entity Framework Core 6, using a Repository design pattern where entities are mapped to DTOs, which are the payloads returned in responses to Client App requests.

The database server was SQL Server 2022 (the free Developer license, not SQL Express). 

Table setup for the Events info and initial values for test are provided as an EF migration (see the Migrations directory).

As mentioned in the document, security (credentials, authorization, CORS, etc) is not implemented.

An artificial delay of 2 seconds is added in the AppComponent.ts to show the Spinner transition when the route changes.  The code line is below.

 transitionShowSpinnerTime = 2000; // artificial delay to show spinner behavior


## Getting Started

After cloning the project at https://github.com/MarkLuppi/Events, it should be buildable and runnable as a Visual Studio 2022 solution.

It has only been tested and run in Visual Studio 2022 as a Development environment on Windows 11.

The database integration requires a couple of steps.  SQL Server 2022 should be used.
Step 1.  Change the "Data Source" field in the connection string to the name of your server. This connection string is presently in an unsecured location (appsettings.Development.json).
Step 2.  Apply the EF migration to your server using the package manager console, with "Update-Database".

## Prerequisites

The Automapper package was used for the EF Entities to DTOs mapping. 

Angular version 13 was used (see the package.json).  Angular Material was used for the UI.   

No testing or eslint rules included because of time constraints.  I'd be glad to do all in a second pass, as well as code cleanup, directory structure revisions, if it's useful.