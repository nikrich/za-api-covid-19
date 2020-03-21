# Stage 1 - Restoring & Compiling
FROM microsoft/dotnet:2.2-sdk-alpine3.8 as builder
WORKDIR /source
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/

# Stage 2 - Creating Image for compiled app
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine3.8 as baseimage
RUN apk add --update nodejs nodejs-npm
WORKDIR /app
COPY --from=builder /app .
ENV ASPNETCORE_URLS=http://+:8080

# Run the application. REPLACE the name of dll with the name of the dll produced by your application
EXPOSE 8080
CMD ["dotnet", "Covid19.dll"]
