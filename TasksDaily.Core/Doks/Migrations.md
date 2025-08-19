## Migration Commands for TasksDaily

dotnet ef migrations add InitialCreate --output-dir Data/Migrations --context TasksDailyDbContext --project . --startup-project ../TasksDaily.Api/
dotnet ef database update --context TasksDailyDbContext --startup-project ..\TasksDaily.Api\