@echo off
echo "start"
set migrations_name=%date:~,4%-%date:~5,2%-%date:~8,2%_%time:~,2%-%time:~3,2%-%time:~6,2%_migration
echo %migrations_name%
dotnet ef migrations add %migrations_name%
dotnet ef database update
echo "finish"
pause