# Use official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["Project1_withAliBaba.csproj", "./"]
RUN dotnet restore "./Project1_withAliBaba.csproj"

# Copy the rest of the project and publish
COPY . .
RUN dotnet publish "Project1_withAliBaba.csproj" -c Release -o /app/publish

# Use official .NET runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# ✅ Fix: Set correct port
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Start the API
ENTRYPOINT ["dotnet", "Project1_withAliBaba.dll"]