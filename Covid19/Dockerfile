FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ["Covid19/Covid19.csproj", "Covid19/"]
RUN dotnet restore "Covid19/Covid19.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:3.0
WORKDIR /app
COPY --from=build-env /app/out .
CMD dotnet --info
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Covid19.dll