# Step 1: Use a .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8/.0 AS build
WORKDIR /src
COPY ["C2/C2.csproj", "C2/"]
RUN dotnet restore "C2/C2.csproj"
COPY . .
WORKDIR "/src/C2"
RUN dotnet build "C2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "C2.csproj" -c Release -o /app/publish

# Step 2: Create a final image for runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "C2.dll"]