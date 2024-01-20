FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish BlazorApp1/BlazorApp1.csproj -c Release -o out/BlazorApp1
RUN dotnet publish WebApplication1/WebApplication1.csproj -c Release -o out/WebApplication1

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out/BlazorApp1 ./BlazorApp1
COPY --from=build-env /App/out/WebApplication1 ./WebApplication1
ENTRYPOINT ["dotnet"]