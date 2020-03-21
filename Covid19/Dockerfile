#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["Covid19/Covid19.csproj", "Covid19/"]
RUN dotnet restore "Covid19/Covid19.csproj"
COPY . .
WORKDIR "/src/Covid19"
RUN dotnet build "Covid19.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Covid19.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Covid19.dll"]