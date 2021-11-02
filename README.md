# SimpleTodoList

## EF Core Nuget Package:
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

## EF Core Command:
- add-migration [MigrationName]. Ex: add-migraion InitialCreate
- update-database
- update-database [Specific Migation]. Ex: Update-Database 20210117085732_AddTableJobTracking
- update-database -Migration 0 => undo all migration change in database
- remove-migration => it's not undo change in database
- Script-Migration -From AddBitcoinDominanceTable -To AddingExclusionCoinsTable > generate migration script sql from A to B
- Script-Migration 0 Init => generate migration script sql for first migration

## What is Antifogery Token
- https://stackoverflow.com/questions/3955766/what-is-the-html-antiforgerytoken-helper-function-for/3955831

## what is the different between asp-validation-summary="ModelOnly" asp-validation-summary="All" ?