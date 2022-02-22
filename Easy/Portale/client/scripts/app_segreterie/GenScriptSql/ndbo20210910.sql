
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


--setuser 'demo'
-- CREAZIONE TABELLA progetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[progetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [progetto] (
idprogetto int NOT NULL,
bandoriferimentotxt nvarchar(2048) NULL,
budget decimal(14,2) NULL,
budgetcalcolato decimal(14,2) NULL,
budgetcalcolatodate datetime NULL,
capofilatxt nvarchar(2048) NULL,
codiceidentificativo varchar(2048) NULL,
contributo decimal(14,2) NULL,
contributoente decimal(14,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cup varchar(15) NULL,
data date NULL,
datacontabile date NULL,
dataesito date NULL,
description nvarchar(max) NULL,
durata int NULL,
finanziamento nvarchar(max) NULL,
finanziatoretxt nvarchar(2048) NULL,
idcorsostudio int NULL,
idcurrency int NULL,
idduratakind int NULL,
idprogettokind int NULL,
idprogettostatuskind int NULL,
idreg int NULL,
idreg_aziende int NULL,
idreg_aziende_fin int NULL,
idregistryprogfin int NULL,
idregistryprogfinbando int NULL,
idstrumentofin int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
progfinanziamentotxt nvarchar(2048) NULL,
start date NULL,
stop date NULL,
title nvarchar(4000) NULL,
titolobreve nvarchar(2048) NULL,
totalbudget decimal(14,2) NULL,
totalcontributo decimal(14,2) NULL,
url varchar(1024) NULL,
 CONSTRAINT xpkprogetto PRIMARY KEY (idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'bandoriferimentotxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD bandoriferimentotxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN bandoriferimentotxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budget decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budget decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budgetcalcolato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budgetcalcolato decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budgetcalcolato decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budgetcalcolatodate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budgetcalcolatodate datetime NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budgetcalcolatodate datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'capofilatxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD capofilatxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN capofilatxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'codiceidentificativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD codiceidentificativo varchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN codiceidentificativo varchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'contributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD contributo decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN contributo decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'contributoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD contributoente decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN contributoente decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'cup' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD cup varchar(15) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN cup varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD data date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'datacontabile' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD datacontabile date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN datacontabile date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'dataesito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD dataesito date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN dataesito date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'durata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD durata int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN durata int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'finanziamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD finanziamento nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN finanziamento nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'finanziatoretxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD finanziatoretxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN finanziatoretxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idcurrency int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idduratakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idduratakind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idduratakind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogettokind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idprogettokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogettostatuskind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idprogettostatuskind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg_aziende' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg_aziende int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg_aziende int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg_aziende_fin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg_aziende_fin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg_aziende_fin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idregistryprogfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idregistryprogfin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idregistryprogfin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idregistryprogfinbando' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idregistryprogfinbando int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idregistryprogfinbando int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idstrumentofin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idstrumentofin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idstrumentofin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'progfinanziamentotxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD progfinanziamentotxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN progfinanziamentotxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD start date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD stop date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD title nvarchar(4000) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN title nvarchar(4000) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'titolobreve' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD titolobreve nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN titolobreve nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'totalbudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD totalbudget decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN totalbudget decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'totalcontributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD totalcontributo decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN totalcontributo decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'url' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD url varchar(1024) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN url varchar(1024) NULL
GO

-- CREAZIONE VISTA progettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettosegview]
GO

CREATE VIEW [progettosegview] AS 
SELECT  progetto.bandoriferimentotxt AS progetto_bandoriferimentotxt, progetto.budget AS progetto_budget, progetto.budgetcalcolato AS progetto_budgetcalcolato, progetto.budgetcalcolatodate AS progetto_budgetcalcolatodate, progetto.capofilatxt AS progetto_capofilatxt, progetto.codiceidentificativo AS progetto_codiceidentificativo, progetto.contributo AS progetto_contributo, progetto.contributoente AS progetto_contributoente, progetto.ct AS progetto_ct, progetto.cu AS progetto_cu, progetto.cup AS progetto_cup, progetto.data AS progetto_data, progetto.datacontabile AS progetto_datacontabile, progetto.dataesito AS progetto_dataesito, progetto.description AS progetto_description, progetto.durata AS progetto_durata, progetto.finanziamento AS progetto_finanziamento, progetto.finanziatoretxt AS progetto_finanziatoretxt,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, progetto.idcorsostudio,
 [dbo].currency.codecurrency AS currency_codecurrency, progetto.idcurrency,
 [dbo].duratakind.title AS duratakind_title, progetto.idduratakind AS progetto_idduratakind, progetto.idprogetto,
 [dbo].progettokind.title AS progettokind_title, progetto.idprogettokind AS progetto_idprogettokind,
 [dbo].progettostatuskind.title AS progettostatuskind_title, progetto.idprogettostatuskind AS progetto_idprogettostatuskind,
 [dbo].registry.title AS registry_title, progetto.idreg,
 registry_registry_aziendeaziende.title AS registryaziende_title, progetto.idreg_aziende,
 registry_registry_aziendeaziende_fin.title AS registryaziende_fin_title, progetto.idreg_aziende_fin,
 [dbo].registryprogfin.title AS registryprogfin_title, [dbo].registryprogfin.code AS registryprogfin_code, progetto.idregistryprogfin AS progetto_idregistryprogfin,
 [dbo].registryprogfinbando.title AS registryprogfinbando_title, [dbo].registryprogfinbando.number AS registryprogfinbando_number, [dbo].registryprogfinbando.scadenza AS registryprogfinbando_scadenza, progetto.idregistryprogfinbando AS progetto_idregistryprogfinbando,
 [dbo].strumentofin.title AS strumentofin_title, progetto.idstrumentofin, progetto.lt AS progetto_lt, progetto.lu AS progetto_lu, progetto.progfinanziamentotxt AS progetto_progfinanziamentotxt, progetto.start AS progetto_start, progetto.stop AS progetto_stop, progetto.title AS progetto_title, progetto.titolobreve, progetto.totalbudget AS progetto_totalbudget, progetto.totalcontributo AS progetto_totalcontributo, progetto.url AS progetto_url,
 isnull('Titolo breve o acronimo: ' + progetto.titolobreve + '; ','') as dropdown_title
FROM progetto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON progetto.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].currency WITH (NOLOCK) ON progetto.idcurrency = [dbo].currency.idcurrency
LEFT OUTER JOIN [dbo].duratakind WITH (NOLOCK) ON progetto.idduratakind = [dbo].duratakind.idduratakind
LEFT OUTER JOIN [dbo].progettokind WITH (NOLOCK) ON progetto.idprogettokind = [dbo].progettokind.idprogettokind
LEFT OUTER JOIN [dbo].progettostatuskind WITH (NOLOCK) ON progetto.idprogettostatuskind = [dbo].progettostatuskind.idprogettostatuskind
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON progetto.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON progetto.idreg_aziende = registry_aziendeaziende.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg
LEFT OUTER JOIN [dbo].registry_aziende AS registry_aziendeaziende_fin WITH (NOLOCK) ON progetto.idreg_aziende_fin = registry_aziendeaziende_fin.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_aziendeaziende_fin WITH (NOLOCK) ON registry_aziendeaziende_fin.idreg = registry_registry_aziendeaziende_fin.idreg
LEFT OUTER JOIN [dbo].registryprogfin WITH (NOLOCK) ON progetto.idregistryprogfin = [dbo].registryprogfin.idregistryprogfin
LEFT OUTER JOIN [dbo].registryprogfinbando WITH (NOLOCK) ON progetto.idregistryprogfinbando = [dbo].registryprogfinbando.idregistryprogfinbando
LEFT OUTER JOIN [dbo].strumentofin WITH (NOLOCK) ON progetto.idstrumentofin = [dbo].strumentofin.idstrumentofin
WHERE  progetto.idprogetto IS NOT NULL 
GO

-- CREAZIONE VISTA perfprogettoobiettivouoviewdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[perfprogettoobiettivouoviewdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [perfprogettoobiettivouoviewdefaultview]
GO


-- CREAZIONE VISTA publicazdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[publicazdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [publicazdefaultview]
GO

CREATE VIEW [publicazdefaultview] AS 
SELECT  publicaz.abstractstring AS publicaz_abstractstring, publicaz.annocopyright AS publicaz_annocopyright, publicaz.annopub AS publicaz_annopub, publicaz.ct AS publicaz_ct, publicaz.cu AS publicaz_cu, publicaz.editore AS publicaz_editore, publicaz.fascicolo AS publicaz_fascicolo,
 [dbo].geo_city.title AS geo_city_title, publicaz.idcity,
 geo_city_publicaz.title AS geo_city_publicaz_title, publicaz.idcity_ed,
 geo_nationed.title AS geo_nationed_title, publicaz.idnation_ed,
 geo_nationlang.title AS geo_nationlang_title, publicaz.idnation_lang,
 progetto.titolobreve AS progetto_titolobreve, publicaz.idprogetto, publicaz.idpublicaz, publicaz.isbn AS publicaz_isbn, publicaz.lt AS publicaz_lt, publicaz.lu AS publicaz_lu, publicaz.numrivista AS publicaz_numrivista, publicaz.pagestart AS publicaz_pagestart, publicaz.pagestop AS publicaz_pagestop, publicaz.pagetot AS publicaz_pagetot, publicaz.title, publicaz.title2 AS publicaz_title2, publicaz.volume AS publicaz_volume,
 isnull('Titolo: ' + publicaz.title + '; ','') as dropdown_title
FROM [dbo].publicaz WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON publicaz.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].geo_city AS geo_city_publicaz WITH (NOLOCK) ON publicaz.idcity_ed = geo_city_publicaz.idcity
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationed WITH (NOLOCK) ON publicaz.idnation_ed = geo_nationed.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON publicaz.idnation_lang = geo_nationlang.idnation
LEFT OUTER JOIN progetto WITH (NOLOCK) ON publicaz.idprogetto = progetto.idprogetto
WHERE  publicaz.idpublicaz IS NOT NULL 
GO

