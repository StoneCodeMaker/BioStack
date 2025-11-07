# BioStack

BioStack is a fitness and supplement tracking dashboard built with Blazor Web App (.NET 8) that helps users monitor workouts, supplements, and recovery metrics.

![BioStack Logo](wwwroot/images/logo.svg)

## Features

- **Dashboard**: Daily snapshot with charts for energy, sleep, and recovery using MudChart.
- **Supplements**: Add/edit supplements (Name, Category, Dosage, Time, Notes) and mark them as "taken."
- **Workouts**: Log sets, reps, and weights per exercise.
- **Reports**: Weekly summaries of supplement adherence and workout volume.
- **Profile**: Basic user info (name, height, weight, goals).

## Tech Stack

- Blazor Web App (.NET 8, interactive server mode)
- C#
- Entity Framework Core with SQLite
- MudBlazor for modern UI components

## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or Visual Studio Code

### Installation

1. Clone the repository
2. Open the solution in Visual Studio or Visual Studio Code
3. Restore NuGet packages
4. Run the application

```bash
dotnet restore
dotnet run
```

## Database Setup

The application uses Entity Framework Core with SQLite. The database will be created automatically when the application starts.

```bash
# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migrations
dotnet ef database update
```

## Project Structure

- **Models**: Data models for Supplement, IntakeLog, Workout, ExerciseSet, HealthMetric, and UserProfile
- **Data**: DbContext and seed data
- **Components**: Blazor components and pages
- **wwwroot**: Static files

## Branding

- **Primary color**: #009688 (teal)
- **Accent color**: #37474F (slate gray)
- **Font**: "Inter" for UI readability

## License

This project is licensed under the MIT License.

## Acknowledgments

- MudBlazor team for the amazing UI components
- .NET team for Blazor
