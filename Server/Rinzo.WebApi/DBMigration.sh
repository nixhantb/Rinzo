#!/bin/bash
# Run from Server/Rinzo.WebApi. DbContexts live in Rinzo.Infrastructure, so migrations
# are generated there with Rinzo.WebApi as the startup project (it has the DI/config wiring).

random_number() {
  echo $((RANDOM % 10000 + 1))
}

echo "Select the context for the migration:"
echo "1. ApplicationDbContext (AppDB)"
echo "2. BaseDbContext (BaseDB)"
read -p "Enter your choice (1 or 2): " choice

suffix=$(random_number)

# Handle user choice
case $choice in
  1)
    context="ApplicationDbContext"
    migration_name="AppDBCreate$suffix"
    ;;
  2)
    context="BaseDBContext"
    migration_name="BaseDBCreate$suffix"
    ;;
  *)
    echo "Invalid choice. Exiting."
    exit 1
    ;;
esac

# Run the EF Core migration and update database
project="../Rinzo.Infrastructure/Rinzo.Infrastructure.csproj"
startup_project="Rinzo.WebApi.csproj"

command="dotnet ef migrations add $migration_name --context $context --project $project --startup-project $startup_project"
echo "Running: $command"
$command

if [ $? -eq 0 ]; then
  echo "Migration created successfully."
  update_command="dotnet ef database update --context $context --project $project --startup-project $startup_project"
  echo "Running: $update_command"
  $update_command

  if [ $? -eq 0 ]; then
    echo "Database updated successfully."
  else
    echo "Failed to update the database."
  fi
else
  echo "Failed to create the migration."
fi