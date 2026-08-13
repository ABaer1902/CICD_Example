# syntax=docker/dockerfile:1

FROM dhi.io/dotnet:10-sdk AS build

WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet build -c Release --no-restore
RUN dotnet test -c Release --no-build

RUN dotnet publish \
    -c Release \
    -r linux-x64 \
    --self-contained false \
    -o /publish

FROM dhi.io/dotnet:10 AS runtime

WORKDIR /app

COPY --from=build /publish .

ENTRYPOINT ["dotnet", "AvaloniaApplication1.dll"]