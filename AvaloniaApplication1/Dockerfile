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