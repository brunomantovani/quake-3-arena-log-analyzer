FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Execute tests
RUN dotnet test
# Build and publish a release
RUN dotnet publish src/Quake3ArenaLogAnalyzer -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Quake3ArenaLogAnalyzer.dll"]