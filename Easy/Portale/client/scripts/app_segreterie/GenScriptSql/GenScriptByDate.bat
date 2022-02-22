forfiles /P ..\ScriptLU /S /D +31/07/2021 >> GenScriptLU20210910.bat
REM devo controllare anche qui per viste fatte a mano
forfiles /P ..\ScriptSQL /S /D +31/07/2021 >> GenScriptLU20210910.bat

REM metti data inizio e fine su questo file :
REM -normalmente la data inizio è quell'a dell'ultimo update e quella di fine è oggi
REM -nel caso devi ripetere qualche giorno dopo la data inizio e fine sono il giorno dell'ultimo tentativo 
REM lanci questo bat 
REM naviga il repository di scriptLU e copia incolla i path sul file ordinando per data decrescente
REM riordina i files prima le tabelle poi le viste poi le procedure
REM metti il path all'inizio e fi i replace alla fine dei .dbo.sql con .dbo.sql >> dbo<DATA LU>.sql
REM lanci lo script e produci i files
REM li testi (PRIMA Spunta e poi esegui) e li copi sul nas e avvisi maria