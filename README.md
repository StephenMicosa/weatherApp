# Weather App (WinForms Learning Project)

A C# desktop weather application built as a learning project with WinForms and OpenWeather APIs.

The project is being developed step by step (models, services, UI wiring, favorites, forecast).

## Project Goals

- Search weather by city name
- Use geocoding to resolve city to latitude/longitude
- Display current weather and multi-day forecast
- Save favorite cities locally
- Keep the UI responsive with async API calls

## Tech Stack

- C# / .NET
- WinForms (desktop UI)
- OpenWeather Geocoding + Weather APIs
- HttpClient + JSON deserialization

## Current Status

This repository is in active development as part of a course exercise.

- Basic project initialized
- Environment file template present
- Backend models/services and UI wiring are in progress

## Prerequisites

- Windows machine
- .NET SDK installed
- OpenWeather API key (free tier is enough)

## Setup

1. Clone the repository

```bash
git clone <your-repo-url>
cd weatherApp
```

2. Create local environment file

```bash
copy .env.example .env
```

3. Put your API key in .env

Example:

```env
OPENWEATHER_API_KEY=your_key_here
OPENWEATHER_GEO_URL=http://api.openweathermap.org/geo/1.0
OPENWEATHER_WEATHER_URL=https://api.openweathermap.org/data/2.5
```

4. Run the app

```bash
dotnet run
```

## API Flow Used

1. Geocode city name

```text
GET /geo/1.0/direct?q={city}&limit=1&appid={API_KEY}
```

2. Fetch current weather using coordinates

```text
GET /data/2.5/weather?lat={lat}&lon={lon}&appid={API_KEY}&units=metric
```

3. Fetch forecast using coordinates

```text
GET /data/2.5/forecast?lat={lat}&lon={lon}&appid={API_KEY}&units=metric
```

## Suggested Project Structure

```text
weatherApp/
|- Program.cs
|- weatherApp.csproj
|- backend/
|  |- models/
|  |- services/
|  |- storage/
|- .env.example
|- .env
|- LESSON_PLAN_AND_ROADMAP.txt
|- README.md
```

## Development Roadmap

Full lesson plan and implementation checklist:

- LESSON_PLAN_AND_ROADMAP.txt

## Notes for VS Code + WinForms

- You can run/debug WinForms from VS Code.
- The visual drag-and-drop WinForms Designer is best in Visual Studio.
- It is common to edit logic in VS Code and UI layout in Visual Studio if needed.

## License

MIT
