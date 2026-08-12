# Use the .NET SDK image to build the app
FROM dhi.io/dotnet:10-sdk AS build AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

# Use the .NET runtime image for the final container
FROM dhi.io/dotnet:10-sdk AS build AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "AvaloniaApplication1.dll"]