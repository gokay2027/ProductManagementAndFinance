**PREPARED ERP MODULE ARCHITECTURE FOR .NET**

Nowadays we are trying to find a shortcut to save time and money while developing modules for software. So as I researched, the ERP sector, some kind of the modules
were given as prepared and making some little changes helps the companies save time and money only for specific software technologies i.e SAP, ORACLE, ABAP, etc.
so I thought that why .NET does not have prepared modules for the ERP solutions so, created a path to develop a Finance and Product management module for a company,
this module is considered easy to develop and prepare core properties.

In the future, more features can be added and I want it to be the first step prepared modules for .NET ERP solutions.

In the future not only for Product and Finance, it might be developed as Customer management, Human resources, Currency and Bank processes, Production Following,
Ship and Container Management, Accounting and Logistics.

So main purpose is to develop a core backend architecture for Finance and Product for now.

Additional Note: The technology, libaries and patterns i used were learnt from the company i worked. I tried to use each method i learnt for a project.

Libraries which were used
- ASP.NET Core
- EntityFrameworkCore
- LinqKit (Filter builder)
- FluentValidation
- Dapper
- NewtonSoft (Planned to use to have communication external files)
- xUnit (For unit testing)

WORKFLOW:
- 1.Creating system Entities, relations between them and base entity roots
- 2.Thanks to entityframeworkcore, defining relations and database context
- 3.Creating configurations and applying into the context, Enabling-migration, Adding migration, updating database
- 4.Creating GENERIC repository pattern, defining each repository of entity
- 5.According to CQRS, Folder architecture for Commands and Queries for each entity
- 6.Defining Models for Command and Queries
- 7.Defining essential System business rules
- 8.Creating Controllers for each entity or business parts
- 9.Using Fluent Validation the businesses are validated to prevent system errors and provide reliability and security
- 10.Using xUnitTesting - TESTING (Functions can affect each other if there is a relation, if a function or command affects other, we need to see the
- testing errors before we build the project. It provides the system integrity)

  According to the software development methodologies the order of workflow may not be exact applied
because there might always be a bug or error on the system and customer, user or team leader demands
may cahange. In general, from "7" to "10" there is always be a loop for developing. And the project
development loop is goes like this. As mentioned order of the steps may change. But, teams should
obey the step orders carefully to prevent financial losts of the company.

CLEAN CODE IS A GOLDEN RULE:
- Comment lines

![image](https://github.com/gokay2027/ProductManagementAndFinance/assets/70948122/0a3f0dcb-7586-42ee-80eb-efff960fb626)


- Project coding standarts
- Regioning
- File Architecture


