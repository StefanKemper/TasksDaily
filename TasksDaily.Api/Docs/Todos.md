# TODO-Liste

## Zielsetzung

Durch die TODO-Liste sollen eine strukturierte Übersicht über Routinen und Aufgaben geboten werden, die folgendes erleichtert:

- wichtige Aufgaben nicht vergessen
- Aufgaben unter Berücksichtigung von Priorität und Aufwand zeitoptimiert erledigen
- Die Bildung von Routinen fördern, um wiederkehrende Aufgaben strukturiert abzuarbeiten


## Anwendungsfälle

(- Zeitfenster erfassen, bearbeiten, löschen) => Stage 2 Feature: Zeitmanagement
(- Vorschlag für Tagesplan anzeigen)
- Aufgabe erfassen, bearbeiten, archivieren
- Aufgabenliste anzeigen (sortiert)


## Domain-Modell

* User: Guid, UserName, Email, CreatedAt
* Timeslot: Uhrzeit von/bis, Wochentage, Modus (Arbeit, Wochenende, Urlaub) - Default 0:00-0:00
* Category: Arbeit, Haushalt, Organisation, Familie & Bekannte, Gesundheit & Fitness
* Task: Bezeichnung, Priorität, Fälligkeit, Links, Beschreibung/Referenz, (Abhängig von Kategorie zusätzliche Metainfos, z.B. Arbeit +Projekt, +Kunde, +Kunde-Icon)

## Feature-Ideen (ChatGPT)

📆 Intelligente Tagesplanung mit Vorschlagslogik (Server- oder Client-seitig)
🔄 Drag & Drop zur Priorisierung (Angular CDK)
🔔 Erinnerungen per Push oder E-Mail (z. B. über Cron + Mailer-Service)
💾 Persistenz von Benutzer-Einstellungen
📊 Statistiken über erledigte Aufgaben, Routinen etc.
🔐 Rollenmodell oder Userverwaltung (optional für Fortgeschrittene)

Bonus-Tipps für deine Demo
Zeige Clean Architecture und SOLID-Prinzipien
Nutze Swagger UI für deine API
Verwende DTOs & AutoMapper
Trenne sauber: Services, Repositories, Controller
Dokumentiere deine Entscheidungen in der README (z. B. warum REST statt GraphQL)

# Architektur

## Frontend

- Angular mit Material UI
- Tailwind CSS oder SCSS
- State-Management mit Signal-Store
- Login mit OIDC und Keycloak
- FormBuilder, Reactive Forms, RxJS, Drag & Drop

## Backend

- Controllerbasierte (ASP.NET) REST-API (versioniert)
- NSwag Typescript-Generator für HTTP-Clients
- OIDC mit Authorization-Code-Flow
- EF-Core code first
- Serilog (versch. Sinks)
- Redis-Cache

## DB

- MSSQL-Server (Docker)
- EF-Core Migrations

## DevOps

- Versionskontrolle: Git + GitHub
- Build: GitHub Actions oder dotnet CLI
- Deployment: Docker + Docker Compose (Frontend + Backend + DB)
- Doku: README.md + evtl. Swagger/OpenAPI
- Tests: xUnit (Backend), Jasmine/Karma (Frontend)

## Bonus: KI-Agenten anbinden

- Abfrage über API
- Vorschläge für Tages-/Wochenplan
- Analyse erledigter Aufgaben:
	- Optimierungsvorschläge
	- Motivation & Feedback
	- ...


# Roadmap

* Leere Anwendung mit Dummy-Dashboard (Angular) und Authentifizierung über Keycloak (OIDC)
* Public-API: Listen-Endpunkt (docker Container) mit Dummy-Ausgabe in Dashboard


