#!/bin/sh

set -e

update-ca-certificates

apt-get update

apt-get install -y curl

dotnet run --project /app/src/API/SFC.Scheme.Api/SFC.Scheme.Api.csproj --no-launch-profile