#!/bin/sh

./src/API/SFC.Scheme.Api/entrypoint.Common.sh
dotnet run --project /app/src/API/SFC.Scheme.Api/SFC.Scheme.Api.csproj --no-launch-profile