# Portfolio.RESTAPI


# Project 2 YH01036-2023-1 Portfölj

Introduktion

Detta projekt är en utvecklarportfölj som visar mina tidigare projekt och kompetenser. Portföljen är driftsatt på Azure och innehåller en rad sektioner såsom:
- Porträttbild
- Ladda ner CV-knapp
- Navbar med länkar till sociala medier och GitHub
- "About Me"-sektion
- "Kunskap"-sektion
- "Portfölj"-sektion med mina projekt (inklusive länkar till GitHub och live-demo)
- "Referens"-sektion
- Kontaktformulär
- Footer

Utöver portföljen har jag också byggt en .NET REST-API som innehåller information om mina tidigare projekt (t.ex. BankAppen, Annons API med mera). API:et är driftsatt på Azure och konsumeras dynamiskt i portföljen genom att loopa igenom och visa projektinformation i form av "produktboxar".

## Teknologier och Stack

- **Frontend:**
-  jag har valt att använda ren HTML,CSS & JS för att skapa en responsiv och modern portfölj.

- **Backend / API:**  
  .NET REST-API med C#  
  Driftsatt på Azure

- **Övriga verktyg:**  
  Git & GitHub för versionskontroll  
  [Valfritt ramverk/bibliotek för UI-komponenter (t.ex. Bootstrap eller Tailwind CSS)]  

## API Beskrivning

API:et innehåller information om mina tidigare projekt med entiteter som bland annat innehåller:
- Projektnamn
- Teknologistack
- Datum
- Beskrivning av projektet
- Ytterligare relevant information

### Exempel på API-endpoint

- **GET /api/projects**  
  Returnerar en lista över projekt med all nödvändig information.  
  Konsumeras i portföljen för att dynamiskt visa mina projekt.

## Metoder, Mönster och Principer

Projektet är byggt med fokus på objektorienterad programmering (OOP) och följer principerna:

- **DRY (Don't Repeat Yourself):**  
  Återanvändbara klasser och metoder med tydliga namn har implementerats för att undvika duplicerad kod.

- **SOLID-principerna:**  
  Varje klass och metod har ett tydligt ansvar. Exempelvis hanterar ViewModels endast logik för data-bindning och validering, medan API-kontrollrar hanterar anrop och affärslogik.

- **MVVM (Model-View-ViewModel):**  
  Används i portföljen för att separera presentationen från logiken. Alla bindbara properties och kommandon finns i ViewModels vilket gör det enkelt att enhetstesta och underhålla koden.

- **Validering & Säkerhet:**  
  API:et och inmatningskontroller är testade och säkerställer att användaren inte kan mata in ogiltiga data. Data valideras både på klientsidan (via inbyggda kontroller såsom NumericUpDown och valideringslogik i ViewModel) och på serversidan i API:et.

## Installation & Körning

### Lokalt

