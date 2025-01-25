# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /App

# # Copy everything
# COPY . ./
# # Restore as distinct layers
# RUN dotnet restore
# # Build and publish a release
# RUN dotnet publish -o out

# Build dev image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS development
WORKDIR /App
COPY . ./
CMD ["dotnet", "run", "--no-launch-profile"]