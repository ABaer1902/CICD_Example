# syntax=docker/dockerfile:1


# Test / Build environment      'test'
FROM dhi.io/dotnet:10-sdk AS test

WORKDIR /workspace

COPY . .

RUN dotnet restore

RUN dotnet build \
    -c Release \
    --no-restore



# Publish application           'publish'
FROM test AS publish

RUN dotnet publish \
    AvaloniaApplication1/AvaloniaApplication1.csproj \
    -c Release \
    -r linux-x64 \
    --self-contained false \
    --no-restore \
    -o /publish



# Runtime application           'runtime'
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS runtime

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        libx11-6 \
        libice6 \
        libsm6 \
        libfontconfig1 \
        xvfb \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app

COPY --from=publish /publish .

ENTRYPOINT ["dotnet", "AvaloniaApplication1.dll"]