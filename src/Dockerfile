# 基准镜像 https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# 维护者信息
LABEL description="天池参赛" by="iwenli" maintainer="github.com/iwenli"

COPY *.sln .
COPY Ali.TianChi.Competition/*.csproj ./Ali.TianChi.Competition/
RUN dotnet restore

COPY Ali.TianChi.Competition/. ./Ali.TianChi.Competition/
WORKDIR /source/Ali.TianChi.Competition
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/core/runtime:3.1
COPY --from=build /app/* ./
WORKDIR /
CMD ["sh", "run.sh"]