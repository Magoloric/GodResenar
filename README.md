# GodResenär: Ett projekt för bättre kollektivtrafik

![Banner](https://i.imgur.com/fYKNsI3.png)

>***TIP: Looking for English version? Check README-EN.md***

## Innehåll

  - [Förord](#förord)
  - [Introduktion](#introduktion)
  - [För resenärer](#för-resenärer)
  - [För företagen](#för-företagen)
  - [Att göra](#att-göra)

## Förord

Just nu är detta endast en prototyp, som är inte redo för normalt bruk. Ni är dock välkomna med era förslag eller tillägg, eftersom koden utvecklas med syftet att vara lätt implementerat oavsett miljön den kan behöva samarbeta med. 

## Introduktion

I snabbväxande Sverige blir det allt mer trångt för bilar. Många börjar tänka på miljön och föredrar kollektivtrafiken. Men för att kunna hålla kvalitet och locka ännu fler, måste man se till att möta resenärernas behov i komfortabel, snabb, ren och högteknologisk transport. Även alltid fungerande biljettmaskiner, icke-fyllda bussar och välfungerande tjänster är ett måste. Vem om inte resenärer vet vad de vill ha av kollektivtrafiken? Och här kommer vi i spelet.

**GodResenär** är en mobilapplikation för frivilliga resenärer som vill rapportera problem och misstag inom kollektivtrafiken med omnejd. Rapporter kommer direkt till ansvariga för kollektivtrafiken i regionen, vilka i sin tur snabbt kontaktar ansvariga för specifika områden (Bussbolag, Trafikverket m.fl.), vilka fixar problemet. På så sätt, fler störningar åtgärdas snabbare, vilket ökar kollektivtrafikens kvalitet och attraktivitet. De mest aktiva och noggranna deltagare belönas med värdecheckar och andra förmåner hos företagen eller partners. Både resenärer, företag och miljön vinner på det!

Mer information om projektet och utveckling finns i [examensarbetet som projektet var tänkt för](https://www.diva-portal.org/smash/record.jsf?dswid=-471&pid=diva2%3A1436753&c=4&searchType=SIMPLE&language=en&query=Lazarev&af=%5B%5D&aq=%5B%5B%5D%5D&aq2=%5B%5B%5D%5D&aqe=%5B%5D&noOfRows=50&sortOrder=author_sort_asc&sortOrder2=title_sort_asc&onlyFullText=false&sf=all)

## För resenärer

Allt kan hända inom kollektivtrafiken. Resenärer kan bli försenade av ett eller annat skäl. Ibland strular tekniken och biljettmaskinerna inte funkar för att köpa biljetter. Bussar och tåg kan bli överfulla. Och mycket annat som sänker komfortnivån.

Du som resenär kan nu bidra till bättre kollektivtrafik genom att använda GodResenär - mobilapplikation för att enkelt rapportera om störningar och problem i kollektivtrafiken med omnejd.

Via appen kan du som resenär:

* Rapportera störningar eller problem i kollektivtrafiken. Exempel på dessa kan vara:
  * Trängsel/fullsatta fordon
  * Trasiga biljettmaskiner eller biljettautomater
  * Farliga, trasiga, väldigt nedskräpade hållplatser, trasiga "Live"-tablåer
  * Trasiga bälten eller andra problem ombord på fordon.
  * Annat som rör kollektivtrafiken i specifika regionen.

* Läsa och rösta på andras rapporter i ett flöde. Poster kan göras anonymt. Ju fler röster har ett förslag, desto snabbare behövs åtgärder.
* Bifoga bild, film, text och röstmeddelande till rapporten.
* Få poäng för godkända rapporter. Poängen kan sedan bytas mot värdecheckar och rabattkoder i poängshopen.  

## För företagen

Oavsett om kollektivtrafiken arrangeras av privata aktörer eller av offentliga sektorn, GodResenär kan hjälpa med:

* Statistik om resande och mest populära tider. Om trängsel i bussen rapporteras alltför ofta, vet man att det är dags att ta åtgärder.
* De problem som rapporteras, inkommer i realtid - på så sätt kan man snabbt agera om det finns behov.
* Förebygga skador: om samma plats rapporteras alltför ofta, vet man att det är dags att ta reda på orsaken till det.
* Locka fler att resa kollektivt genom att åtgärda fel i tid och öka komforten. 

*Backend är inte skapad ännu*


## Att göra

- [ ] Kommentera koden (på engelska)
- [ ] Komplettera prototypen:
  * [ ] Skriva om koden som ansvarar för användarsystemet
  * [x] Implementera poängshop-exempel
  * [ ] Implementera röstmeddelanden vid rapporteringen
  * [ ] Implementera videomeddelanden vid rapporteringen 
  * [ ] Koppla rapporteringen till exempeldatabas (koden för rapportsändning)
  * [ ] Skapa exempeldatabas för användare samt skapa registreringsprocess. 
  * [ ] Optimera flödet för stora mängder rapporter.
  * [ ] Komplettera dokumentation och inställningar
 - [ ] Göra om logotypen för appen
 - [ ] Göra om inrapporteringssida 

Följande saker är inte aktuella just nu:
-  Version för iOS: Apples politik gör att en Mac måste användas för utvecklingen av iOS-appar. Inte aktuellt för att jag saknar Mac och en aktuell iPhone för testning. Då appen är skriven i Xamarin, själva möjligheten för en iOS-app var tänkt från början.
- Backend och netcode: dessa varierar, beroende på miljön hos kundföretagen. Ett exempelbackend kan komma att utvecklas senare som separat projekt. För tillfället finns exempeldatabaser i JSON-format i själva appen. 
- UX/UI-redesign: Vid behov, kan justeras för specifikt företag.
