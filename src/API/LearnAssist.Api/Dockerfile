FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
#WORKDIR /src
COPY ["src/API/LearnAssist.Api/LearnAssist.Api.csproj", "src/API/LearnAssist.Api/"]
RUN dotnet restore "src/API/LearnAssist.Api/LearnAssist.Api.csproj"
COPY . .
WORKDIR "/src/API/LearnAssist.Api"
RUN dotnet build "LearnAssist.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LearnAssist.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# Install vsdbg debugger inside the container
#RUN apt-get update && apt-get install -y unzip curl && \
#    curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg \
    
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearnAssist.Api.dll"]
