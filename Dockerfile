FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY published\ .
ENTRYPOINT ["dotnet", "CheckIn.WebApi.dll"]
