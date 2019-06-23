# Entity Framework Code First
## Overview

Project consists of the three projects that listed below:
1. DataAccess.Core
	Contains the following classes:
	- Entities
Entities is a representation of the database tables. All entities should be derived from the IEntity interface to define its primary key field to be able to use generic repositories.
	- Complex types
Complex types is a representation of results of functions, stored procedures and view results.
	- Repository interfaces
	Provides two base generic interfaces for the repositories with read-only and read-write functionality. Defines behavior of the base repositories. Also specific repositories interfaces can be defined here.

> Entities and repositories separated by the database to which it relates and by its **database schema**. Default (dbo) schema places in the root of the appropriate directory and no additional namespace provides.

2. DataAccess.Context
	Contains the following classes:
	- Context (main with partials)
		- Contains needed configuration implementation. CustomContext contains definitions of the database tables, views, stored procedures and functions of the appropriate database.
		- Uses by Repositories to provide needed database operations.
	- UnitOfWork
	Uses Repositories and defines main interface to access the databases.
	- Repository implementations
	There are two base implementations of repositories - with read-only and read-write methods. Both base classes can be used for repository definition. Also there are no need to define separate empty interface with its repository implementation if no additional actions needed, base repository can be used.
	- Migrations
	Describes database changes that should be applied to the database.
	- Entity configurations
	Configurations used to define mapping between object/properties names and appropriate database names.
	
> Repositories and Entity Configurations are also separated by its **database schema**.

3. DataAccess.Tests
Contains test configuration classes and unit tests.
Tests are configured by:
	- DI container configuration and DI module that contains binding definitions
	- Assembly initializer and disposer
	- In-memory database connection factory
	- Base test class that provide access to the UnitOfWork and instantiates it

> In-Memory database creates based on the context and not using migrations at all (not sure how it works with the stored procedures and it not supports schemas)

> In-Memory database clears after each test

## Configuration

Main configuration remarks:
- Define Entity
- Define Entity Configuration
- Add DbSet<Entity> to the Context
- Define Repository interface
- Define Repository class
- Add migration class

