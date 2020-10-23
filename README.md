# Campaign Manager

[![Actions Status](https://github.com/mennan/campaign-manager/workflows/Test/badge.svg)](https://github.com/mennan/campaign-manager/actions)

## Used Technologies

- .NET Core 3.1
- Docker

## Installation

### Source Code

First of all, you must install .NET Core from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

If you've installed .NET Core, run the commands below:

```bash
git clone https://github.com/mennan/campaign-manager.git
cd src/CampaignManager.Console
dotnet run
```

### Docker

Type below code on your terminal:

```bash
docker build -t campaignmanager .
docker run --name campaignmanager campaignmanager
```

## Run Tests

Type below code on your terminal:

```bash
git clone https://github.com/mennan/campaign-manager.git
dotnet test
```
