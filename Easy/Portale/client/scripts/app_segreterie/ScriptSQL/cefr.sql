
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


--[DBO]--
-- CREAZIONE TABELLA cefr --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[cefr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[cefr] (
idcefr int NOT NULL,
active char(1) NOT NULL,
descriptioncompasc varchar(512) NOT NULL,
descriptioncomplett varchar(512) NOT NULL,
descriptionparlinter varchar(512) NOT NULL,
descriptionparlprod varchar(512) NOT NULL,
descriptionscritto varchar(512) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkcefr PRIMARY KEY (idcefr
)
)
END
GO

-- VERIFICA STRUTTURA cefr --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'idcefr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD idcefr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'idcefr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'descriptioncompasc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD descriptioncompasc varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'descriptioncompasc' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN descriptioncompasc varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'descriptioncomplett' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD descriptioncomplett varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'descriptioncomplett' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN descriptioncomplett varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'descriptionparlinter' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD descriptionparlinter varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'descriptionparlinter' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN descriptionparlinter varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'descriptionparlprod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD descriptionparlprod varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'descriptionparlprod' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN descriptionparlprod varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'descriptionscritto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD descriptionscritto varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'descriptionscritto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN descriptionscritto varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'cefr' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [cefr] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('cefr') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [cefr] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [cefr] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI cefr IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'cefr'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','int','ASSISTENZA','idcefr','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','varchar(512)','ASSISTENZA','descriptioncompasc','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','varchar(512)','ASSISTENZA','descriptioncomplett','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','varchar(512)','ASSISTENZA','descriptionparlinter','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','varchar(512)','ASSISTENZA','descriptionparlprod','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','varchar(512)','ASSISTENZA','descriptionscritto','512','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','cefr','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI cefr IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'cefr')
UPDATE customobject set isreal = 'S' where objectname = 'cefr'
ELSE
INSERT INTO customobject (objectname, isreal) values('cefr', 'S')
GO

-- GENERAZIONE DATI PER cefr --
IF exists(SELECT * FROM [cefr] WHERE idcefr = '1')
UPDATE [cefr] SET active = 'S',descriptioncompasc = 'Riesco a riconoscere parole che mi sono familiari ed espressioni molto semplici riferite a me stesso, alla mia famiglia e al mio ambiente, purché le persone parlino lentamente e chiaramente.',descriptioncomplett = 'Riesco a capire i nomi e le persone che mi sono familiari e frasi molto semplici, per esempio quelle di annunci, cartelloni, cataloghi.',descriptionparlinter = 'Riesco a interagire in modo semplice se l’interlocutore é disposto a ripetere o a riformulare più lentamente certe cose e mi aiuta a formulare ciò che cerco di dire. Riesco a porre e a rispondere a domande semplici su argomenti molto familiari o che riguardano bisogni immediati.',descriptionparlprod = 'Riesco a usare espressioni e frasi semplici per descrivere il luogo dove abito e la gente che conosco.',descriptionscritto = 'Riesco a scrivere una breve e semplice cartolina , ad esempio per mandare i saluti delle vacanze. Riesco a compilare moduli con dati personali scrivendo per esempio il mio nome, la nazionalità e l’indirizzo sulla scheda di registrazione di un albergo.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'A1 utente base ' WHERE idcefr = '1'
ELSE
INSERT INTO [cefr] (idcefr,active,descriptioncompasc,descriptioncomplett,descriptionparlinter,descriptionparlprod,descriptionscritto,lt,lu,sortcode,title) VALUES ('1','S','Riesco a riconoscere parole che mi sono familiari ed espressioni molto semplici riferite a me stesso, alla mia famiglia e al mio ambiente, purché le persone parlino lentamente e chiaramente.','Riesco a capire i nomi e le persone che mi sono familiari e frasi molto semplici, per esempio quelle di annunci, cartelloni, cataloghi.','Riesco a interagire in modo semplice se l’interlocutore é disposto a ripetere o a riformulare più lentamente certe cose e mi aiuta a formulare ciò che cerco di dire. Riesco a porre e a rispondere a domande semplici su argomenti molto familiari o che riguardano bisogni immediati.','Riesco a usare espressioni e frasi semplici per descrivere il luogo dove abito e la gente che conosco.','Riesco a scrivere una breve e semplice cartolina , ad esempio per mandare i saluti delle vacanze. Riesco a compilare moduli con dati personali scrivendo per esempio il mio nome, la nazionalità e l’indirizzo sulla scheda di registrazione di un albergo.',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','A1 utente base ')
GO

IF exists(SELECT * FROM [cefr] WHERE idcefr = '2')
UPDATE [cefr] SET active = 'S',descriptioncompasc = 'Riesco a capire espressioni e parole di uso molto frequente relative a ciò che mi riguarda direttamente (per esempio informazioni di base sulla mia persona e sulla mia famiglia, gli acquisti, l’ambiente circostante e il lavoro). Riesco ad afferrare l’essenziale di messaggi e annunci brevi, semplici e chiari.',descriptioncomplett = 'Riesco a leggere testi molto brevi e semplici e a trovare informazioni specifiche e prevedibili in materiale di uso quotidiano, quali pubblicità, programmi, menù e orari. Riesco a capire lettere personali semplici e brevi.',descriptionparlinter = 'Riesco a comunicare affrontando compiti semplici e di routine che richiedano solo uno scambio semplice e diretto di informazioni su argomenti e attività consuete. Riesco a partecipare a brevi conversazioni, anche se di solito non capisco abbastanza per riuscire a sostenere la conversazione.',descriptionparlprod = 'Riesco ad usare una serie di espressioni e frasi per descrivere con parole semplici la mia famiglia ed altre persone, le mie condizioni di vita, la carriera scolastica e il mio lavoro attuale o il più recente.',descriptionscritto = 'Riesco a prendere semplici appunti e a scrivere brevi messaggi su argomenti riguardanti bisogni immediati. Riesco a scrivere una lettera personale molto semplice, per esempio per ringraziare qualcuno.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'A2 utente base' WHERE idcefr = '2'
ELSE
INSERT INTO [cefr] (idcefr,active,descriptioncompasc,descriptioncomplett,descriptionparlinter,descriptionparlprod,descriptionscritto,lt,lu,sortcode,title) VALUES ('2','S','Riesco a capire espressioni e parole di uso molto frequente relative a ciò che mi riguarda direttamente (per esempio informazioni di base sulla mia persona e sulla mia famiglia, gli acquisti, l’ambiente circostante e il lavoro). Riesco ad afferrare l’essenziale di messaggi e annunci brevi, semplici e chiari.','Riesco a leggere testi molto brevi e semplici e a trovare informazioni specifiche e prevedibili in materiale di uso quotidiano, quali pubblicità, programmi, menù e orari. Riesco a capire lettere personali semplici e brevi.','Riesco a comunicare affrontando compiti semplici e di routine che richiedano solo uno scambio semplice e diretto di informazioni su argomenti e attività consuete. Riesco a partecipare a brevi conversazioni, anche se di solito non capisco abbastanza per riuscire a sostenere la conversazione.','Riesco ad usare una serie di espressioni e frasi per descrivere con parole semplici la mia famiglia ed altre persone, le mie condizioni di vita, la carriera scolastica e il mio lavoro attuale o il più recente.','Riesco a prendere semplici appunti e a scrivere brevi messaggi su argomenti riguardanti bisogni immediati. Riesco a scrivere una lettera personale molto semplice, per esempio per ringraziare qualcuno.',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','A2 utente base')
GO

IF exists(SELECT * FROM [cefr] WHERE idcefr = '3')
UPDATE [cefr] SET active = 'S',descriptioncompasc = 'Riesco a capire gli elementi principali in un discorso chiaro in lingua standard su argomenti familiari, che affronto frequentemente al lavoro, a scuola, nel tempo libero ecc. Riesco a capire l’essenziale di molte trasmissioni radiofoniche e televisive su argomenti di attualità o temi di mio interesse personale o professionale, purché il discorso sia relativamente lento e chiaro.',descriptioncomplett = 'Riesco a capire testi scritti di uso corrente legati alla sfera quotidiana o al lavoro. Riesco a capire la descrizione di avvenimenti, di sentimenti e di desideri contenuta in lettere personali.',descriptionparlinter = 'Riesco a comunicare con un grado di spontaneità e scioltezza sufficiente per interagire in modo normale con parlanti nativi. Riesco a partecipare attivamente a una discussione in contesti familiari, esponendo e sostenendo le mie opinioni.',descriptionparlprod = 'Riesco a descrivere, collegando semplici espressioni, esperienze ed avvenimenti, i miei sogni, le mie speranze e le mie ambizioni. Riesco a motivare e spiegare brevemente opinioni e progetti. Riesco a narrare una storia e la trama di un libro o di un film e a descrivere le mie impressioni. .',descriptionscritto = 'Riesco a scrivere testi semplici e coerenti su argomenti a me noti o di mio interesse. Riesco a scrivere lettere personali esponendo esperienze e impressioni. ',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'B1 utente autonomo' WHERE idcefr = '3'
ELSE
INSERT INTO [cefr] (idcefr,active,descriptioncompasc,descriptioncomplett,descriptionparlinter,descriptionparlprod,descriptionscritto,lt,lu,sortcode,title) VALUES ('3','S','Riesco a capire gli elementi principali in un discorso chiaro in lingua standard su argomenti familiari, che affronto frequentemente al lavoro, a scuola, nel tempo libero ecc. Riesco a capire l’essenziale di molte trasmissioni radiofoniche e televisive su argomenti di attualità o temi di mio interesse personale o professionale, purché il discorso sia relativamente lento e chiaro.','Riesco a capire testi scritti di uso corrente legati alla sfera quotidiana o al lavoro. Riesco a capire la descrizione di avvenimenti, di sentimenti e di desideri contenuta in lettere personali.','Riesco a comunicare con un grado di spontaneità e scioltezza sufficiente per interagire in modo normale con parlanti nativi. Riesco a partecipare attivamente a una discussione in contesti familiari, esponendo e sostenendo le mie opinioni.','Riesco a descrivere, collegando semplici espressioni, esperienze ed avvenimenti, i miei sogni, le mie speranze e le mie ambizioni. Riesco a motivare e spiegare brevemente opinioni e progetti. Riesco a narrare una storia e la trama di un libro o di un film e a descrivere le mie impressioni. .','Riesco a scrivere testi semplici e coerenti su argomenti a me noti o di mio interesse. Riesco a scrivere lettere personali esponendo esperienze e impressioni. ',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','B1 utente autonomo')
GO

IF exists(SELECT * FROM [cefr] WHERE idcefr = '4')
UPDATE [cefr] SET active = 'S',descriptioncompasc = 'Riesco a capire discorsi di una certa lunghezza e conferenze e a seguire argomentazioni anche complesse purché il tema mi sia relativamente familiare. Riesco a capire la maggior parte dei notiziari e delle trasmissioni TV che riguardano fatti d’attualità e la maggior parte dei film in lingua standard.',descriptioncomplett = 'Riesco a leggere articoli e relazioni su questioni d’attualità in cui l’autore prende posizione ed esprime un punto di vista determinato. Riesco a comprendere un testo narrativo contemporaneo.',descriptionparlinter = 'Riesco a comunicare con un grado di spontaneità e scioltezza sufficiente per interagire in modo normale con parlanti nativi. Riesco a partecipare attivamente a una discussione in contesti familiari, esponendo e sostenendo le mie opinioni.',descriptionparlprod = 'Riesco a esprimermi in modo chiaro e articolato su una vasta gamma di argomenti che mi interessano. Riesco a esprimere un’ opinione su un argomento d’attualità, indicando vantaggi e svantaggi delle diverse opzioni.',descriptionscritto = 'Riesco a scrivere testi chiari e articolati su un’ampia gamma di argomenti che mi interessano. Riesco a scrivere saggi e relazioni, fornendo informazioni e ragioni a favore o contro una determinata opinione. Riesco a scrivere lettere mettendo in evidenza il significato che attribuisco personalmente agli avvenimenti e alle esperienze.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'B2 utente autonomo' WHERE idcefr = '4'
ELSE
INSERT INTO [cefr] (idcefr,active,descriptioncompasc,descriptioncomplett,descriptionparlinter,descriptionparlprod,descriptionscritto,lt,lu,sortcode,title) VALUES ('4','S','Riesco a capire discorsi di una certa lunghezza e conferenze e a seguire argomentazioni anche complesse purché il tema mi sia relativamente familiare. Riesco a capire la maggior parte dei notiziari e delle trasmissioni TV che riguardano fatti d’attualità e la maggior parte dei film in lingua standard.','Riesco a leggere articoli e relazioni su questioni d’attualità in cui l’autore prende posizione ed esprime un punto di vista determinato. Riesco a comprendere un testo narrativo contemporaneo.','Riesco a comunicare con un grado di spontaneità e scioltezza sufficiente per interagire in modo normale con parlanti nativi. Riesco a partecipare attivamente a una discussione in contesti familiari, esponendo e sostenendo le mie opinioni.','Riesco a esprimermi in modo chiaro e articolato su una vasta gamma di argomenti che mi interessano. Riesco a esprimere un’ opinione su un argomento d’attualità, indicando vantaggi e svantaggi delle diverse opzioni.','Riesco a scrivere testi chiari e articolati su un’ampia gamma di argomenti che mi interessano. Riesco a scrivere saggi e relazioni, fornendo informazioni e ragioni a favore o contro una determinata opinione. Riesco a scrivere lettere mettendo in evidenza il significato che attribuisco personalmente agli avvenimenti e alle esperienze.',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','B2 utente autonomo')
GO

IF exists(SELECT * FROM [cefr] WHERE idcefr = '5')
UPDATE [cefr] SET active = 'S',descriptioncompasc = 'Riesco a capire un discorso lungo anche se non é chiaramente strutturato e le relazioni non vengono segnalate, ma rimangono implicite. Riesco a capire senza troppo sforzo le trasmissioni televisive e i film.',descriptioncomplett = 'Riesco a capire testi letterari e informativi lunghi e complessi e so apprezzare le differenze di stile. Riesco a capire articoli specialistici e istruzioni tecniche piuttosto lunghe, anche quando non appartengono al mio settore.',descriptionparlinter = 'Riesco ad esprimermi in modo sciolto e spontaneo senza dover cercare troppo le parole. Riesco ad usare la lingua in modo flessibile ed efficace nelle relazioni sociali e professionali. Riesco a formulare idee e opinioni in modo preciso e a collegare abilmente i miei interventi con quelli di altri interlocutori.',descriptionparlprod = 'Riesco a presentare descrizioni chiare e articolate su argomenti complessi, integrandovi temi secondari, sviluppando punti specifici e concludendo il tutto in modo appropriato.',descriptionscritto = 'Riesco a scrivere testi chiari e ben strutturati sviluppando analiticamente il mio punto di vista. Riesco a scrivere lettere, saggi e relazioni esponendo argomenti complessi, evidenziando i punti che ritengo salienti. Riesco a scegliere lo stile adatto ai lettori ai quali intendo rivolgermi.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'C1 utente avanzato' WHERE idcefr = '5'
ELSE
INSERT INTO [cefr] (idcefr,active,descriptioncompasc,descriptioncomplett,descriptionparlinter,descriptionparlprod,descriptionscritto,lt,lu,sortcode,title) VALUES ('5','S','Riesco a capire un discorso lungo anche se non é chiaramente strutturato e le relazioni non vengono segnalate, ma rimangono implicite. Riesco a capire senza troppo sforzo le trasmissioni televisive e i film.','Riesco a capire testi letterari e informativi lunghi e complessi e so apprezzare le differenze di stile. Riesco a capire articoli specialistici e istruzioni tecniche piuttosto lunghe, anche quando non appartengono al mio settore.','Riesco ad esprimermi in modo sciolto e spontaneo senza dover cercare troppo le parole. Riesco ad usare la lingua in modo flessibile ed efficace nelle relazioni sociali e professionali. Riesco a formulare idee e opinioni in modo preciso e a collegare abilmente i miei interventi con quelli di altri interlocutori.','Riesco a presentare descrizioni chiare e articolate su argomenti complessi, integrandovi temi secondari, sviluppando punti specifici e concludendo il tutto in modo appropriato.','Riesco a scrivere testi chiari e ben strutturati sviluppando analiticamente il mio punto di vista. Riesco a scrivere lettere, saggi e relazioni esponendo argomenti complessi, evidenziando i punti che ritengo salienti. Riesco a scegliere lo stile adatto ai lettori ai quali intendo rivolgermi.',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','C1 utente avanzato')
GO

IF exists(SELECT * FROM [cefr] WHERE idcefr = '6')
UPDATE [cefr] SET active = 'S',descriptioncompasc = 'Non ho nessuna difficoltà a capire qualsiasi lingua parlata, sia dal vivo sia trasmessa, anche se il discorso è tenuto in modo veloce da un madrelingua, purché abbia il tempo di abituarmi all’accento.',descriptioncomplett = 'Riesco a capire con facilità praticamente tutte le forme di lingua scritta inclusi i testi teorici, strutturalmente o linguisticamante complessi, quali manuali, articoli specialistici e opere letterarie.',descriptionparlinter = 'Riesco a partecipare senza sforzi a qualsiasi conversazione e discussione ed ho familiarità con le espressioni idiomatiche e colloquiali. Riesco ad esprimermi con scioltezza e a rendere con precisione sottili sfumature di significato. In caso di difficoltà, riesco a ritornare sul discorso e a riformularlo in modo cosí scorrevole che difficilmente qualcuno se ne accorge.',descriptionparlprod = 'Riesco a presentare descrizioni o argomentazioni chiare e scorrevoli, in uno stile adeguato al contesto e con una struttura logica efficace, che possa aiutare il destinatario a identificare i punti salienti da rammentare.',descriptionscritto = 'Riesco a scrivere testi chiari, scorrevoli e stilisticamente appropriati. Riesco a scrivere lettere, relazioni e articoli complessi, supportando il contenuto con una struttura logica efficace che aiuti il destinatario a identificare i punti salienti da rammentare. Riesco a scrivere riassunti e recensioni di opere letterarie e di testi specialisti.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'C2 utente avanzato' WHERE idcefr = '6'
ELSE
INSERT INTO [cefr] (idcefr,active,descriptioncompasc,descriptioncomplett,descriptionparlinter,descriptionparlprod,descriptionscritto,lt,lu,sortcode,title) VALUES ('6','S','Non ho nessuna difficoltà a capire qualsiasi lingua parlata, sia dal vivo sia trasmessa, anche se il discorso è tenuto in modo veloce da un madrelingua, purché abbia il tempo di abituarmi all’accento.','Riesco a capire con facilità praticamente tutte le forme di lingua scritta inclusi i testi teorici, strutturalmente o linguisticamante complessi, quali manuali, articoli specialistici e opere letterarie.','Riesco a partecipare senza sforzi a qualsiasi conversazione e discussione ed ho familiarità con le espressioni idiomatiche e colloquiali. Riesco ad esprimermi con scioltezza e a rendere con precisione sottili sfumature di significato. In caso di difficoltà, riesco a ritornare sul discorso e a riformularlo in modo cosí scorrevole che difficilmente qualcuno se ne accorge.','Riesco a presentare descrizioni o argomentazioni chiare e scorrevoli, in uno stile adeguato al contesto e con una struttura logica efficace, che possa aiutare il destinatario a identificare i punti salienti da rammentare.','Riesco a scrivere testi chiari, scorrevoli e stilisticamente appropriati. Riesco a scrivere lettere, relazioni e articoli complessi, supportando il contenuto con una struttura logica efficace che aiuti il destinatario a identificare i punti salienti da rammentare. Riesco a scrivere riassunti e recensioni di opere letterarie e di testi specialisti.',{ts '2018-06-11 11:35:00.653'},'ferdinando','6','C2 utente avanzato')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'cefr')
UPDATE [tabledescr] SET description = 'VOCABOLARIO UE utilizzato per definire il livello di conoscenza delle lingue nei learning agreement e negli accordi internazionali
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:15:57.637'},lu = 'assistenza',title = 'VOCABOLARIO UE utilizzato per definire il livello di conoscenza delle lingue nei learning agreement ' WHERE tablename = 'cefr'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('cefr','VOCABOLARIO UE utilizzato per definire il livello di conoscenza delle lingue nei learning agreement e negli accordi internazionali
',null,'N',{ts '2018-07-27 13:15:57.637'},'assistenza','VOCABOLARIO UE utilizzato per definire il livello di conoscenza delle lingue nei learning agreement ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Attivo',kind = 'S',lt = {ts '2020-09-07 12:23:07.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','cefr','1',null,null,'Attivo','S',{ts '2020-09-07 12:23:07.970'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'descriptioncompasc' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Comprensione ascolto',kind = 'S',lt = {ts '2020-09-07 12:23:07.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'descriptioncompasc' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('descriptioncompasc','cefr','512',null,null,'Comprensione ascolto','S',{ts '2020-09-07 12:23:07.970'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'descriptioncomplett' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Comprensione lettura',kind = 'S',lt = {ts '2020-09-07 12:23:07.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'descriptioncomplett' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('descriptioncomplett','cefr','512',null,null,'Comprensione lettura','S',{ts '2020-09-07 12:23:07.970'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'descriptionparlinter' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Parlato interazione',kind = 'S',lt = {ts '2020-09-07 12:23:07.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'descriptionparlinter' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('descriptionparlinter','cefr','512',null,null,'Parlato interazione','S',{ts '2020-09-07 12:23:07.970'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'descriptionparlprod' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Parlato produzione',kind = 'S',lt = {ts '2020-09-07 12:23:07.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'descriptionparlprod' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('descriptionparlprod','cefr','512',null,null,'Parlato produzione','S',{ts '2020-09-07 12:23:07.970'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'descriptionscritto' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Scritto',kind = 'S',lt = {ts '2020-09-07 12:23:07.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'descriptionscritto' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('descriptionscritto','cefr','512',null,null,'Scritto','S',{ts '2020-09-07 12:23:07.970'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcefr' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:16:13.683'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcefr' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcefr','cefr','4',null,null,null,'S',{ts '2018-07-27 13:16:13.683'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:16:13.683'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','cefr','8',null,null,null,'S',{ts '2018-07-27 13:16:13.683'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:16:13.683'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','cefr','64',null,null,null,'S',{ts '2018-07-27 13:16:13.683'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine',kind = 'S',lt = {ts '2020-09-07 12:23:07.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','cefr','4',null,null,'Ordine','S',{ts '2020-09-07 12:23:07.970'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'cefr')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-09-07 12:23:07.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'cefr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','cefr','50',null,null,'Titolo','S',{ts '2020-09-07 12:23:07.970'},'assistenza','N','varchar(50)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

