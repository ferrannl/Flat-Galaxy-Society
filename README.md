# Flat Galaxy Society

_De meeste van ons leven in de veronderstelling dat de aarde een bol is en het heelal een driedimensionale ruimte. Maar wat nou als het heelal een tweedimensionale ruimte is en alle planeten wel rond zijn, maar plat?_

Flat Galaxy Society is een C#/.NET-project dat een alternatieve kijk op ons universum modelleert: een plat, tweedimensionaal heelal waarin planeten rond zijn, maar zelf ook “plat” bestaan. Dit project is ontwikkeld als een Advanced Design Patterns–opdracht en laat zien hoe verschillende objectgeoriënteerde principes en patronen toegepast kunnen worden in een speels domein.

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

In Flat Galaxy Society wordt een denkbeeldig heelal uitgewerkt waarin:

- Het universum zelf als een **tweedimensionaal vlak** wordt gemodelleerd.
- Planeten **rond maar plat** zijn en op dat vlak bewegen.
- Relaties tussen planeten, trajecten, banen en “maatschappijen” (societies) binnen dit vlak worden vastgelegd.

Het doel van de codebase is niet alleen functioneel gedrag te tonen, maar vooral om **ontwerppatronen**, **clean architecture** en **testbare code** te demonstreren.

---

## Features

Enkele kernpunten van het project:

- 🌌 **2D-universum-model**  
  Een representatie van een vlakke galaxie met planetaire objecten en hun eigenschappen.

- 🪐 **Planet & Society-modellen**  
  Klassen om planeten, hun banen en eventuele “societies” of facties binnen het universum te modelleren.

- 🧩 **Toepassing van design patterns**  
  Ontwerppatronen (design patterns) worden gebruikt om de logica flexibel, uitbreidbaar en onderhoudbaar te houden.

- ✅ **Unit tests**  
  Een apart testproject (`FlatGalaxySociety.Tests`) valideert het gedrag van de belangrijkste domeincomponenten.

- 🗂 **Visuele en documentatiebestanden**  
  - Class diagram: `ClassDiagram_FlatGalaxySociety.jpg`  
  - Rubric / beoordelingsdocument: `Rubric_DPA_2021_Ferran_Hendriks_2130858.pdf`

---

## Architecture & Design

De focus van het project ligt op **Advanced Design Patterns** in C#. Denk hierbij aan:

- Scheiding tussen **domeinlogica** en **infrastructuur / presentatie**.
- Objectgeoriënteerde principes zoals **encapsulatie**, **polymorfisme** en **composition over inheritance**.
- Heldere modellering van entiteiten in de galaxie (bijv. planeten, banen, societies) met duidelijke verantwoordelijkheden.

De globale structuur en relaties tussen de belangrijkste klassen zijn terug te vinden in:

- `ClassDiagram_FlatGalaxySociety.jpg`
- `FlatGalaxySociety\ClassDiagram_FlatGalaxySociety.cd` (Visual Studio class diagram)

Gebruik deze bestanden om een snel overzicht te krijgen van de domeinmodellen en hoe ze samenwerken.

---

## Project Structure

Hoofdstructuur van de repository:

```text
Flat-Galaxy-Society/
├─ FlatGalaxySociety/           # Hoofdproject (C#)
├─ FlatGalaxySociety.Tests/     # Testproject
├─ FlatGalaxySociety.sln        # Visual Studio solution
├─ ClassDiagram_FlatGalaxySociety.jpg
├─ Rubric_DPA_2021_Ferran_Hendriks_2130858.pdf
├─ .gitattributes
├─ .gitignore
└─ README.md
