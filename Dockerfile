FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS builder
WORKDIR /source

COPY . .

# Change the Directory
WORKDIR /source/

# aspnet-core
RUN dotnet restore src/CampaignManager.Console/CampaignManager.Console.csproj
RUN dotnet publish src/CampaignManager.Console/CampaignManager.Console.csproj --output /campaignmanager/ --configuration Release

## Runtime
FROM mcr.microsoft.com/dotnet/core/runtime:3.1-bionic

# Change the Directory
WORKDIR /campaignmanager

COPY --from=builder /campaignmanager .
ENTRYPOINT ["dotnet", "CampaignManager.Console.dll"]