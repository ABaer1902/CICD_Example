# syntax=docker/dockerfile:1

# Build
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

# Runtime
FROM dhi.io/dotnet:10 AS runtime

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        libx11-6 \
        libice6 \
        libsm6 \
        libfontconfig1 \
        xvfb \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app

COPY --from=build /publish .

ENTRYPOINT ["dotnet", "AvaloniaApplication1.dll"]