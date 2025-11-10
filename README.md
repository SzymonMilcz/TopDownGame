# Tactical-title-WIP-

## Główne założenia

- Gracz steruje postacią z perspektywy „lotu ptaka”, we wszystkich kierunkach.
- Postać jest w stanie atakować także we wszystkie strony, w kierunku myszki.
- Gracz ma limitowaną liczbę punktów zdrowia- utrata ich wszystkich poprzez kontakt z atakami wrogów, niebezpiecznym terenem lub samymi przeciwnikami oznacza porażkę.
- Gra toczy się w częściowo losowo generowanych pokojach z przeciwnikami różnych rodzajów; pierwszy pokój jest pusty i oferuje przejście w cztery inne sąsiednie pomieszczenia.
- Poziom trudności stopniowo się podnosi z każdym pokonanym pomieszczeniem.
- Po oczyszczeniu pomieszczenia dostaje się nagrodę w postaci przedmiotu odnawiającego zdrowie, lub ulepszenie bądź zamiana ataku- wybierane z puli ulepszeń losowo.
- Gra kończy się po oczyszczeniu 100 pokojów*.

## Ważne mechaniki

- Oczyszczanie pokoi podnosi licznik poziomu trudności, który wpływa na ilość, typ i ogólną moc przeciwników.
- To, kiedy pojawiają się przeciwnicy silniejsi bądź elitarni, powinno być zarządzane poprzez pulę punktów ustalaną za pomocą obecnego poziomu trudności.
- Pokonanie wszystkich przeciwników w pokoju oczyszcza go i otwiera ścieżkę do nowych pokojów, oraz umożliwia wzięcie jedno z trzech losowo wybranych ulepszeń.
Przykładowe ulepszenia zostały wypisane poniżej:
### Podstawowe
- Ulepszenia które nie są wyjątkowo ciekawe, ale zapewniają zwiększenie statystyk typu: zdrowie, szybkostrzelność, obrażenia, itd.
### Pancerz reaktywny
- Zwiększa nieznacznie zdrowie i wydłuża czas niewrażliwości po otrzymaniu obrażeń (do maks. 3 sekund?)
### Strzelec wyborowy
- Każdy trafiony pocisk zwiększa zadawane obrażenia do pewnego limitu, lecz ten bonus się resetuje przy spudłowaniu.
### Kule przeszywające
- Pocisk może przejść przez jednego wroga, tracąc część prędkości i obrażeń.

## Główna postać

Gracz steruje postacią, która zaczyna ze 100 punktami zdrowia i możliwością podstawowego ataku zasięgowego.
- Postać może zostać ulepszona poprzez znajdywane nagrody za oczyszczanie pokojów; można ulepszyć m. in. maksymalne zdrowie, możliwość ataku (szybkostrzelność, obrażenia, prędkość pocisku), szybkość ruchu, a nawet otrzymać nowe umiejętności.
- Gracz odzyskuje niewielką ilość zdrowia za oczyszczenie pokoju (20?).
- Atak jest celowany kursorem myszy, aktywowany lewym przyciskiem myszy.
  - Być może warto dać zdolność alternatywną na prawy przycisk myszy?
- Bezpośredni kontakt postaci z przeciwnikiem oznacza odepchnięcie gracza i otrzymanie obrażeń.

## Przeciwnicy

Wrogowie pojawiają się w ustalonych wcześniej miejscach (ich lokacja zależy od szablonu danego pokoju) z drobnym elementem losowym co do ich typu oraz siły.
- Im więcej pokojów zostanie oczyszczonych, tym więcej spotka się przeciwników, którzy także będą silniejsi.
- Przeciwnicy powinni atakować gracza tylko jeśli widzą go bezpośrednio, czyli nie przez ściany; jeśli nie ma go w polu widzenia, starają się ominąć przeszkodę i dotrzeć do gracza.
- Wszyscy przeciwnicy powinni mieć silniejszy wariant elitarny, który może pojawić się zamiast zwykłego gdy poziom trudności będzie odpowiednio wysoki.
Poniżej przedstawiono niektóre typy przeciwników:
### Strzelec
- Strzela pociskami w stronę postaci gracza z przeciętną częstotliwością, zadające umiarkowane obrażenia.
- Niezbyt wytrzymały, lecz często spotykany w większych ilościach.
### Agresor
- Wykonuje krótkie szarże w stronę gracza co około sekundę, starając się go staranować.
- Dość wytrzymały, zadający spore obrażenia przy kontakcie z graczem i odpychając zarówno jego, jak i siebie.
### Miotacz
- Miota dwoma kulami jednocześnie w seriach, lecz nie bezpośrednio w gracza: jedna leci przed gracza, a druga za niego.
- Dość rzadki i powolny, twardszy niż Strzelec.
### Maszynowiec
- Wystrzeliwuję serię pocisków w jednej linii; po wystrzeleniu pierwszego pocisku w serii kąt ostrzału pozostaje ten sam, dopóki seria się nie zakończy.
- Długie odstępy między seriami, podobna wytrzymałość do Miotacza.
