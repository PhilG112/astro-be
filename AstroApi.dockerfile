FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://*:80
EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build
WORKDIR "/"

# Copy project files and other needed files
COPY ./NuGet.config ./NuGet.config
COPY ./astro-be.ruleset ./astro-be.ruleset
COPY ./src/Astro.Abstractions/Astro.Abstractions.csproj ./src/Astro.Abstractions/Astro.Abstractions.csproj
COPY ./src/Astro.API/Astro.API.csproj ./src/Astro.API/Astro.API.csproj
COPY ./src/Astro.Application/Astro.Application.csproj ./src/Astro.Application/Astro.Application.csproj
COPY ./src/Astro.Domain/Astro.Domain.csproj ./src/Astro.Domain/Astro.Domain.csproj
COPY ./src/Astro.Infrastructure/Astro.Infrastructure.csproj ./src/Astro.Infrastructure/Astro.Infrastructure.csproj
COPY ./build/common.props ./build/common.props
COPY ./Directory.Build.props ./Directory.Build.props
COPY ./version.props ./version.props
COPY ./stylecop.json ./stylecop.json

# Restore as a distinct layer
RUN dotnet restore ./src/Astro.API/Astro.API.csproj

# Copy everything else
WORKDIR "/"
COPY ./src ./src

# Set working dir & build
WORKDIR "/src/Astro.API"
RUN dotnet build "Astro.API.csproj" -c Release -o /app/build

# Publish our build to a location to retrieve later
FROM build AS publish
RUN dotnet publish "Astro.API.csproj" -c Release -o /app/publish

# Copy the published files into our runtime container
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/ .
ENTRYPOINT ["dotnet", "Astro.API.dll"]

