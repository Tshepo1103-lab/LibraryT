FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/LibraryT.Web.Host/LibraryT.Web.Host.csproj", "src/LibraryT.Web.Host/"]
COPY ["src/LibraryT.Web.Core/LibraryT.Web.Core.csproj", "src/LibraryT.Web.Core/"]
COPY ["src/LibraryT.Application/LibraryT.Application.csproj", "src/LibraryT.Application/"]
COPY ["src/LibraryT.Core/LibraryT.Core.csproj", "src/LibraryT.Core/"]
COPY ["src/LibraryT.EntityFrameworkCore/LibraryT.EntityFrameworkCore.csproj", "src/LibraryT.EntityFrameworkCore/"]
WORKDIR "/src/src/LibraryT.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LibraryT.Web.Host", "src/LibraryT.Web.Host"]
COPY ["src/LibraryT.Web.Core", "src/LibraryT.Web.Core"]
COPY ["src/LibraryT.Application", "src/LibraryT.Application"]
COPY ["src/LibraryT.Core", "src/LibraryT.Core"]
COPY ["src/LibraryT.EntityFrameworkCore", "src/LibraryT.EntityFrameworkCore"]
WORKDIR "/src/src/LibraryT.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LibraryT.Web.Host.dll"]
