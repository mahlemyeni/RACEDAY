# RACEDAY

RACEDAY is a Razor Pages web application targeting .NET 10. This repository contains the solution and source code for the web app.

## Prerequisites

- .NET 10 SDK
- Visual Studio 2026 (or later) with ASP.NET and web development workload
- (Optional) pwsh / PowerShell for preferred terminal

## Getting Started

1. Clone the repository (already cloned in this workspace):
   - Remote: https://github.com/mahlemyeni/RACEDAY
   - Local path in this workspace: `C:\Users\amahl\source\repos\RACEDAY`

2. Open the solution
   - Visual Studio: `C:\Users\amahl\source\repos\RACEDAY\RACEDAY.slnx`
   - Or from the terminal:
     ```
     cd C:\Users\amahl\source\repos\RACEDAY
     dotnet restore
     ```

3. Build and run
   - Visual Studio: Press F5 or use Debug > Start Debugging
   - CLI:
     ```
     dotnet build
     dotnet run --project <PathToRazorProject>.csproj
     ```
   Replace `<PathToRazorProject>.csproj` with the actual project file name for the Razor Pages app.

4. Tests
   - Run unit tests (if present):
     ```
     dotnet test
     ```

## Configuration

- App configuration files live in `appsettings.json` (and environment-specific variants).
- Update connection strings, logging, and other settings there before running in different environments.

## Project Structure (typical)

- /Pages — Razor Pages UI and handlers
- /wwwroot — static assets (css, js, images)
- /Data — data access, DbContext (if EF is used)
- /Tests — unit/integration tests (if present)

Adjust based on the actual repository layout.

## Contributing

1. Create a branch for your change: `git checkout -b feature/your-feature`
2. Commit and push to origin
3. Open a pull request

Follow repository coding standards and include tests where applicable.


## Contact

Repository: https://github.com/mahlemyeni/RACEDAY
