FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
MAINTAINER iwenli<github.com/iwenli>
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ../*.sln .
COPY *.csproj ./coreapp/
RUN dotnet restore

# copy everything else and build app
COPY coreapp/. ./coreapp/
WORKDIR /source/coreapp
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=build /app ./
CMD ["sh", "run.sh"]