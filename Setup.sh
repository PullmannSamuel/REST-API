#!/bin/bash
echo "Restoring project dependencies..."
dotnet restore
echo "Building project..."
dotnet build
echo "Setup complete."
cmd /k