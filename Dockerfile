FROM microsoft/dotnet:2.0.6-sdk-2.1.101 AS build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

COPY ./src/RoboWars/RoboWars.csproj ./RoboWars/
COPY ./src/RoboWars.Game/RoboWars.Game.csproj ./RoboWars.Game/
RUN dotnet restore RoboWars/RoboWars.csproj

COPY ./src/ .
WORKDIR /RoboWars/
RUN dotnet publish -c $BUILDCONFIG -o out /p:Version=$VERSION

FROM microsoft/dotnet:2.0.6-runtime 
WORKDIR /app
COPY --from=build RoboWars/out .

ENTRYPOINT ["dotnet", "RoboWars.dll"]