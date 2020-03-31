
MAINTAINER iwenli<github.com/iwenli>

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Ali.TianChi.Competition/Ali.TianChi.Competition.csproj", "Ali.TianChi.Competition/"]
RUN dotnet restore "Ali.TianChi.Competition/Ali.TianChi.Competition.csproj"
COPY . .
WORKDIR "/src/Ali.TianChi.Competition"
RUN dotnet build "Ali.TianChi.Competition.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ali.TianChi.Competition.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["sh", "run.sh"