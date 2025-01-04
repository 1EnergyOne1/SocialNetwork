   FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
   WORKDIR /app
   EXPOSE 80

   FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
   WORKDIR /src
   COPY ["Api.Main.csproj", "./"]
   RUN dotnet restore "./Api.Main.csproj"
   COPY . .
   WORKDIR "/src/."
   RUN dotnet build "Api.Main.csproj" -c Release -o /app/build

   FROM build AS publish
   RUN dotnet publish "Api.Main.csproj" -c Release -o /app/publish

   FROM base AS final
   WORKDIR /app
   COPY --from=publish /app/publish .
   ENTRYPOINT ["dotnet", "Api.Main.dll"]
   
