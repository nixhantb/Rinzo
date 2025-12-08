#!/bin/bash


execute_command() {
  command="$1"
  echo "Running: $command"
  $command

  if [ $? -ne 0 ]; then
    echo "Command failed: $command"
    exit 1
  fi
}


execute_command "dotnet clean"


execute_command "dotnet restore"


execute_command "dotnet build"

execute_command "dotnet run"
