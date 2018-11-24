FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 62557
EXPOSE 44390

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["dot-net-core.api.core/dot-net-core.api.core.csproj", "dot-net-core.api.core/"]
RUN dotnet restore "dot-net-core.api.core/dot-net-core.api.core.csproj"
COPY . .
WORKDIR "/src/dot-net-core.api.core"
RUN dotnet build "dot-net-core.api.core.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dot-net-core.api.core.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dot-net-core.api.core.dll"]