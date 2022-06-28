#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIROMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CheckIn.WebApi/CheckIn.WebApi.csproj", "CheckIn.WebApi/"]
COPY ["CheckIn.Infraestructure/CheckIn.Infraestructure.csproj", "CheckIn.Infraestructure/"]
COPY ["CheckIn.Application/CheckIn.Application.csproj", "CheckIn.Application/"]
COPY ["CheckIn.Domain/CheckIn.Domain.csproj", "CheckIn.Domain/"]
COPY ["ShareKernel/ShareKernel.csproj", "ShareKernel/"]
RUN dotnet restore "CheckIn.WebApi/CheckIn.WebApi.csproj"
COPY . .
WORKDIR "/src/CheckIn.WebApi"
RUN dotnet build "CheckIn.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheckIn.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheckIn.WebApi.dll"]