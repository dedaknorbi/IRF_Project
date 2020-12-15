A program egy olyan biztosításokat kötő cég dolgozóinak monitorozására való, ahol a ledolgozott órákat és az ügynökök által megkötött szerződések számát összehangolva ad ki egy hatékonysági mutatót a dolgozóknak a szoftver.
A program gombnyomásra kiválasztja nekünk a listából a valamennyi legjobb mutatójú dolgozót, ezeket pedig zöld színnel ki is emeli. Ez a fő funkciója.
Eredetileg arra lett kitalálva, hogy ennek segítségével lehessen eldönteni azt, hogy ki dolgozzon homeofficeban, de ettől elvonatkoztatva egy egyszerű teljesítménymérő alkalmazásként is tekinthető.
Ezeket a feladatokat kellett megvalósítanom:
-adatbázisból beolvasás: az adatbázisból LINQ-val listába olvasok be
-listából történő törlés: ez a képen látható szűrő funkciójú checkbox-okkal történik, amikor is az adott feltételek függvényében történik a lista bizonyos elemeinek törlése
-diagram rajzolás: itt a datagridview-ben kijelölt személy teljesítményét mutatja meg egy vonaldiagram a három hónapra visszamenőleg
-enumerációk: enumerációkat a szűrőfeltételeknél alkalmaztam. A két checkbox kombinációja kiad valamilyen enumerációs értéket, amit a törlésfunkció fog vizsgálni, és ennek függvényében fog a listából elemeket törölni. 
