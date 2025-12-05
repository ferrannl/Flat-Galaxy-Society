# Flat Galaxy Society

_De meeste van ons leven in de veronderstelling dat de aarde een bol is en het heelal een driedimensionale ruimte. Maar wat nou als het heelal een tweedimensionale ruimte is en alle planeten wel rond zijn, maar plat?_

Flat Galaxy Society is een C#/.NET-project dat een alternatieve kijk op ons universum modelleert: een plat, tweedimensionaal heelal waarin planeten rond zijn, maar zelf ook “plat” bestaan.  
Het project is ontwikkeld als **Advanced Design Patterns**–opdracht en laat zien hoe verschillende objectgeoriënteerde principes en patronen toegepast kunnen worden in een speels domein.

[![Flat Galaxy Society – Class Diagram](./ClassDiagram_FlatGalaxySociety.jpg "Flat Galaxy Society Class Diagram")](./ClassDiagram_FlatGalaxySociety.jpg)

---

## Table of Contents

- [Concept](#concept)
- [Features](#features)
- [Architecture & Design](#architecture--design)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Running the Application](#running-the-application)
- [Tests](#tests)
- [Class Diagram & Rubric](#class-diagram--rubric)
- [Future Improvements](#future-improvements)
- [Author](#author)
- [License](#license)

---

## Concept

In **Flat Galaxy Society** wordt een denkbeeldig heelal uitgewerkt waarin:

- Het universum zelf als een **tweedimensionaal vlak** wordt gemodelleerd.
- Planeten **rond maar plat** zijn en op dat vlak bewegen.
- Relaties tussen planeten, trajecten, banen en “maatschappijen” (societies / facties) binnen dit vlak worden vastgelegd.

Het doel van de codebase is niet alleen om functioneel gedrag te tonen, maar vooral om:

- **Ontwerppatronen (design patterns)** toe te passen,
- **Clean architecture** te demonstreren,
- En **testbare code** te schrijven binnen een klein, goed afgebakend domein.

---

## Features

Enkele kernpunten van het project:

- **2D-universum-model**  
  Een representatie van een vlakke galaxie met planetaire objecten en hun eigenschappen.

- **Planet & Society-modellen**  
  Klassen om planeten, hun banen en eventuele “societies” of facties binnen het universum te modelleren.

- **Toepassing van design patterns**  
  Ontwerppatronen worden gebruikt om de logica flexibel, uitbreidbaar en onderhoudbaar te houden.

- ✅ **Unit tests**  
  Een apart testproject (`FlatGalaxySociety.Tests`) valideert het gedrag van de belangrijkste domeincomponenten.

- **Visuele en documentatiebestanden**
  - Class diagram: `ClassDiagram_FlatGalaxySociety.jpg`
  - Visual Studio classdiagram: `FlatGalaxySociety\ClassDiagram_FlatGalaxySociety.cd`
  - Rubric / beoordelingsdocument: `Rubric_DPA_2021_Ferran_Hendriks_2130858.pdf`

---

## Architecture & Design

De focus van het project ligt op **Advanced Design Patterns** in C# en goede objectgeoriënteerde modellering.

Enkele belangrijke principes:

- **Scheiding van verantwoordelijkheden**  
  Duidelijke scheiding tussen domeinlogica, infrastructuur en eventuele presentatie.

- **Objectgeoriënteerde principes**
  - **Encapsulatie** – data en gedrag horen bij elkaar,
  - **Polymorfisme** – gedrag kan variëren per implementatie,
  - **Composition over inheritance** – waar mogelijk samenstellen in plaats van erven.

- **Domeinmodellering**  
  Entiteiten in de galaxie (bijv. planeten, banen, societies) hebben duidelijke verantwoordelijkheden en relaties.  
  De globale structuur en relaties tussen de belangrijkste klassen zijn terug te vinden in:
  - `ClassDiagram_FlatGalaxySociety.jpg`
  - `FlatGalaxySociety\ClassDiagram_FlatGalaxySociety.cd` (Visual Studio class diagram)

Gebruik deze bestanden om snel inzicht te krijgen in de domeinmodellen en hoe ze samenwerken.

---

## Project Structure

Hoofdstructuur van de repository:

```text
Flat-Galaxy-Society/
├─ FlatGalaxySociety/          # Hoofdproject (C#/.NET)
├─ FlatGalaxySociety.Tests/    # Unit test-project
├─ FlatGalaxySociety.sln       # Visual Studio solution
├─ ClassDiagram_FlatGalaxySociety.jpg
├─ Rubric_DPA_2021_Ferran_Hendriks_2130858.pdf
├─ .gitattributes
├─ .gitignore
└─ README.md

FlatGalaxySociety/
Bevat de domeinlogica, modellen en eventuele services die de vlakke galaxie beschrijven.

FlatGalaxySociety.Tests/
Bevat unit tests om het gedrag van de belangrijkste klassen en use-cases te verifiëren.



---

Getting Started

Prerequisites

Je kunt het project op twee manieren draaien:

1. Visual Studio (aanbevolen)

Visual Studio 2019 of nieuwer

Workload: “.NET desktop development” of “.NET” (afhankelijk van jouw VS-versie)



2. .NET SDK

Een recente .NET SDK geïnstalleerd (bijvoorbeeld .NET 6 of hoger)

Command line / terminal (PowerShell, CMD, Bash, etc.)




Controleer je .NET-installatie:

dotnet --version


---

Clone the Repository

git clone https://github.com/ferrannl/Flat-Galaxy-Society.git
cd Flat-Galaxy-Society


---

Running the Application

Via Visual Studio

1. Open FlatGalaxySociety.sln in Visual Studio.


2. Selecteer het project FlatGalaxySociety als startup project (rechtsklik → Set as StartUp Project).


3. Kies Debug → Start Debugging of druk op F5.



Via de command line

Zorg dat je in de root van de repository staat:

cd Flat-Galaxy-Society

Build het project:

dotnet build

Run het hoofdproject (als het een console-app is):

dotnet run --project FlatGalaxySociety/FlatGalaxySociety.csproj


---

Tests

Om alle tests uit te voeren:

dotnet test

Dit zal:

De solution bouwen,

Alle tests in FlatGalaxySociety.Tests uitvoeren,

Een overzicht geven van geslaagde en eventueel gefaalde tests.



---

Class Diagram & Rubric

De repository bevat extra documentatie om de structuur en beoordeling van het project te ondersteunen:

Class diagram (afbeelding)
ClassDiagram_FlatGalaxySociety.jpg
Dit bestand geeft een visueel overzicht van de belangrijkste klassen en hun relaties.

Visual Studio class diagram
FlatGalaxySociety\ClassDiagram_FlatGalaxySociety.cd
Dit kan geopend worden binnen Visual Studio om de klassendiagram-view te gebruiken.

Rubric / beoordelingsdocument
Rubric_DPA_2021_Ferran_Hendriks_2130858.pdf
Beschrijft de beoordelingscriteria en hoe het project zich verhoudt tot de eisen van de Advanced Design Patterns-opdracht.



---

Future Improvements

Enkele mogelijke uitbreidingen / verbeteringen:

Uitbreiding van het universummodel

Meer soorten objecten (bijv. asteroïdevelden, wormholes, stations).

Complexere interacties tussen planeten en societies.


Visualisatie

Een simpele UI of visualisatie van de vlakke galaxie (bijv. WPF, WinUI, Blazor of een kleine web-frontend).

Export van simulatiestatus naar JSON voor verdere analyse.


Meer ontwerppatronen

Extra patterns inzetten voor scenario’s zoals event-afhandeling, configuratie of simulatiesturing.


Uitgebreidere tests

Meer edge cases,

Property-based testing,

Code coverage verhogen.




---

Author

Naam: Ferran Hendriks

Studentnummer: 2130858



---

License

Er is geen expliciet licentiebestand opgenomen in deze repository.
Wil je (delen van) deze code hergebruiken, neem dan bij voorkeur eerst contact op met de auteur.
