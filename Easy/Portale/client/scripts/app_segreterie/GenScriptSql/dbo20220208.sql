
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


-- CREAZIONE TABELLA strutturaresponsabile --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaresponsabile]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[strutturaresponsabile] (
idstrutturaresponsabile int NOT NULL,
idstruttura int NOT NULL,
idperfruolo varchar(50) NULL,
idreg int NULL,
start date NULL,
stop date NULL,
 CONSTRAINT xpkstrutturaresponsabile PRIMARY KEY (idstrutturaresponsabile,
idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA strutturaresponsabile --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idstrutturaresponsabile' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idstrutturaresponsabile int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturaresponsabile') and col.name = 'idstrutturaresponsabile' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturaresponsabile] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strutturaresponsabile') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strutturaresponsabile] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idperfruolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idperfruolo varchar(50) NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN idperfruolo varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD start date NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strutturaresponsabile' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strutturaresponsabile] ADD stop date NULL 
END
ELSE
	ALTER TABLE [strutturaresponsabile] ALTER COLUMN stop date NULL
GO

-- CREAZIONE TABELLA perfvalutazionepersonale --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazionepersonale] (
idperfvalutazionepersonale int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idafferenza int NULL,
idperfschedastatus int NULL,
idreg_appr int NULL,
idreg_val int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
perccomportamenti decimal(19,2) NULL,
percobiettivi decimal(19,2) NULL,
percperfuo decimal(19,2) NULL,
pesocomportamenti decimal(19,2) NULL,
pesoobiettivi decimal(19,2) NULL,
pesoperfuo decimal(19,2) NULL,
risultato decimal(19,2) NULL,
year int NULL,
 CONSTRAINT xpkperfvalutazionepersonale PRIMARY KEY (idperfvalutazionepersonale,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazionepersonale --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idperfvalutazionepersonale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idperfvalutazionepersonale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'idperfvalutazionepersonale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idafferenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idafferenza int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN idafferenza int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idperfschedastatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idperfschedastatus int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN idperfschedastatus int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idreg_appr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idreg_appr int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN idreg_appr int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'idreg_val' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD idreg_val int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN idreg_val int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonale') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'perccomportamenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD perccomportamenti decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN perccomportamenti decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'percobiettivi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD percobiettivi decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN percobiettivi decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'percperfuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD percperfuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN percperfuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'pesocomportamenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD pesocomportamenti decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN pesocomportamenti decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'pesoobiettivi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD pesoobiettivi decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN pesoobiettivi decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'pesoperfuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD pesoperfuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN pesoperfuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'risultato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD risultato decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN risultato decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonale' and C.name = 'year' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonale] ADD year int NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonale] ALTER COLUMN year int NULL
GO

-- CREAZIONE VISTA perfvalutazioneuodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazioneuodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfvalutazioneuodefaultview]
GO

CREATE VIEW [dbo].[perfvalutazioneuodefaultview] AS 
SELECT  perfvalutazioneuo.completamentopsauo AS perfvalutazioneuo_completamentopsauo, perfvalutazioneuo.completamentopsuo AS perfvalutazioneuo_completamentopsuo, perfvalutazioneuo.ct AS perfvalutazioneuo_ct, perfvalutazioneuo.cu AS perfvalutazioneuo_cu,
 [dbo].perfschedastatus.title AS perfschedastatus_title, perfvalutazioneuo.idperfschedastatus AS perfvalutazioneuo_idperfschedastatus, perfvalutazioneuo.idperfvalutazioneuo,
 registryappr.title AS registryappr_title, perfvalutazioneuo.idreg_appr AS perfvalutazioneuo_idreg_appr,
 registryval.title AS registryval_title, perfvalutazioneuo.idreg_val AS perfvalutazioneuo_idreg_val,
 [dbo].struttura.title AS struttura_title, strutturaparent.title AS strutturaparent_title, [dbo].struttura.paridstruttura AS struttura_paridstruttura, perfvalutazioneuo.idstruttura, perfvalutazioneuo.indicatori AS perfvalutazioneuo_indicatori, perfvalutazioneuo.lt AS perfvalutazioneuo_lt, perfvalutazioneuo.lu AS perfvalutazioneuo_lu, perfvalutazioneuo.obiettiviindividuali AS perfvalutazioneuo_obiettiviindividuali, perfvalutazioneuo.pesoindicatori AS perfvalutazioneuo_pesoindicatori, perfvalutazioneuo.pesoobiettivi AS perfvalutazioneuo_pesoobiettivi, perfvalutazioneuo.pesoprogaltreuo AS perfvalutazioneuo_pesoprogaltreuo, perfvalutazioneuo.pesoproguo AS perfvalutazioneuo_pesoproguo, perfvalutazioneuo.risultato AS perfvalutazioneuo_risultato, perfvalutazioneuo.year
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfprogettoobiettivouoview.progetto_title AS Progetto,isnull(CAST(perfprogettoobiettivouoview.peso AS NVARCHAR(64)),'0.00') AS Peso_per_il_progetto,perfprogettoobiettivouoview.title AS Titolo,isnull(CAST(perfprogettoobiettivouoview.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfprogettoobiettivouoview
 WHERE perfprogettoobiettivouoview.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo AND perfprogettoobiettivouoview.idstruttura = perfvalutazioneuo.idstruttura FOR XML path, root)))) AS XXperfprogettoobiettivouoview 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfprogettoobiettivopersonaleview.progetto_title AS Progetto,isnull(CAST(perfprogettoobiettivopersonaleview.peso AS NVARCHAR(64)),'0.00') AS Peso_per_il_progetto,perfprogettoobiettivopersonaleview.title AS Titolo,isnull(CAST(perfprogettoobiettivopersonaleview.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfprogettoobiettivopersonaleview
 WHERE perfprogettoobiettivopersonaleview.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo AND perfprogettoobiettivopersonaleview.idstruttura = perfvalutazioneuo.idstruttura FOR XML path, root)))) AS XXperfprogettoobiettivopersonaleview 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Titolo: ' +title from perfindicatore x where x.idperfindicatore = perfvalutazioneuoindicatori.idperfindicatore) + '; ','') AS Indicatore,isnull(CAST(perfvalutazioneuoindicatori.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfvalutazioneuoindicatori
 WHERE perfvalutazioneuoindicatori.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo FOR XML path, root)))) AS XXperfvalutazioneuoindicatori 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfobiettiviuo.title AS Titolo,isnull(CAST(perfobiettiviuo.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfobiettiviuo.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfobiettiviuo
 WHERE perfobiettiviuo.idperfvalutazioneuo = perfvalutazioneuo.idperfvalutazioneuo FOR XML path, root)))) AS XXperfobiettiviuo 
FROM [dbo].perfvalutazioneuo WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfschedastatus WITH (NOLOCK) ON perfvalutazioneuo.idperfschedastatus = [dbo].perfschedastatus.idperfschedastatus
LEFT OUTER JOIN [dbo].registry AS registryappr WITH (NOLOCK) ON perfvalutazioneuo.idreg_appr = registryappr.idreg
LEFT OUTER JOIN [dbo].registry AS registryval WITH (NOLOCK) ON perfvalutazioneuo.idreg_val = registryval.idreg
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON perfvalutazioneuo.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].struttura AS strutturaparent WITH (NOLOCK) ON [dbo].struttura.paridstruttura = strutturaparent.idstruttura
WHERE  perfvalutazioneuo.idperfvalutazioneuo IS NOT NULL  AND perfvalutazioneuo.idstruttura IS NOT NULL 
GO

-- CREAZIONE VISTA afferenzaammview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[afferenzaammview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[afferenzaammview]
GO

CREATE VIEW [dbo].[afferenzaammview] AS 
SELECT  afferenza.ct AS afferenza_ct, afferenza.cu AS afferenza_cu, afferenza.idafferenza,
 [dbo].mansionekind.title AS mansionekind_title, afferenza.idmansionekind AS afferenza_idmansionekind, afferenza.idreg,
 [dbo].struttura.title AS struttura_title, strutturaparent.title AS strutturaparent_title, [dbo].struttura.paridstruttura AS struttura_paridstruttura, afferenza.idstruttura, afferenza.lt AS afferenza_lt, afferenza.lu AS afferenza_lu, afferenza.start AS afferenza_start, afferenza.stop AS afferenza_stop,
 isnull('U.O.: ' + [dbo].struttura.title + '; ','') + ' ' + isnull('Denominazione U.O. madre: ' + strutturaparent.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, afferenza.start, 103),'') + ' ' + isnull('al ' + CONVERT(VARCHAR, afferenza.stop, 103),'') + ' ' + isnull('Mansione: ' + [dbo].mansionekind.title + '; ','') as dropdown_title
FROM [dbo].afferenza WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].mansionekind WITH (NOLOCK) ON afferenza.idmansionekind = [dbo].mansionekind.idmansionekind
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON afferenza.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].struttura AS strutturaparent WITH (NOLOCK) ON [dbo].struttura.paridstruttura = strutturaparent.idstruttura
WHERE  afferenza.idafferenza IS NOT NULL  AND afferenza.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA perfvalutazionepersonaledefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonaledefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfvalutazionepersonaledefaultview]
GO

CREATE VIEW [dbo].[perfvalutazionepersonaledefaultview] AS 
SELECT  perfvalutazionepersonale.ct AS perfvalutazionepersonale_ct, perfvalutazionepersonale.cu AS perfvalutazionepersonale_cu,
 [dbo].struttura.title AS struttura_title, [dbo].struttura.paridstruttura AS struttura_paridstruttura, [dbo].afferenza.idstruttura AS afferenza_idstruttura, [dbo].afferenza.start AS afferenza_start, [dbo].afferenza.stop AS afferenza_stop, [dbo].mansionekind.title AS mansionekind_title, [dbo].afferenza.idmansionekind AS afferenza_idmansionekind, perfvalutazionepersonale.idafferenza AS perfvalutazionepersonale_idafferenza,
 [dbo].perfschedastatus.title AS perfschedastatus_title, perfvalutazionepersonale.idperfschedastatus AS perfvalutazionepersonale_idperfschedastatus, perfvalutazionepersonale.idperfvalutazionepersonale,
 [dbo].registry.title AS registry_title, perfvalutazionepersonale.idreg,
 registryappr.title AS registryappr_title, perfvalutazionepersonale.idreg_appr AS perfvalutazionepersonale_idreg_appr,
 registryval.title AS registryval_title, perfvalutazionepersonale.idreg_val AS perfvalutazionepersonale_idreg_val, perfvalutazionepersonale.lt AS perfvalutazionepersonale_lt, perfvalutazionepersonale.lu AS perfvalutazionepersonale_lu, perfvalutazionepersonale.perccomportamenti AS perfvalutazionepersonale_perccomportamenti, perfvalutazionepersonale.percobiettivi AS perfvalutazionepersonale_percobiettivi, perfvalutazionepersonale.percperfuo AS perfvalutazionepersonale_percperfuo, perfvalutazionepersonale.pesocomportamenti AS perfvalutazionepersonale_pesocomportamenti, perfvalutazionepersonale.pesoobiettivi AS perfvalutazionepersonale_pesoobiettivi, perfvalutazionepersonale.pesoperfuo AS perfvalutazionepersonale_pesoperfuo, perfvalutazionepersonale.risultato AS perfvalutazionepersonale_risultato, perfvalutazionepersonale.year,
 isnull('Valutato: ' + [dbo].registry.title + '; ','') + ' ' + isnull((Select top 1 'Identificativo: ' +CAST( year AS NVARCHAR(64)) from year x where x.year = perfvalutazionepersonale.year) + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Tipo: ' +CAST( idstrutturakind AS NVARCHAR(64)) from struttura x where x.idstruttura = perfvalutazionepersonaleuo.idstruttura) + '; ','') AS Unità_organizzativa,isnull(CAST(perfvalutazionepersonaleuo.afferenza AS NVARCHAR(64)),'0.00') AS Tempo_di_afferenza,isnull(CAST(perfvalutazionepersonaleuo.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfvalutazionepersonaleuo.punteggio AS NVARCHAR(64)),'0.00') AS Punteggio,isnull(CAST(perfvalutazionepersonaleuo.punteggiopesato AS NVARCHAR(64)),'0.00') AS Punteggio_pesato FROM  dbo.perfvalutazionepersonaleuo
 WHERE perfvalutazionepersonaleuo.idperfvalutazionepersonale = perfvalutazionepersonale.idperfvalutazionepersonale FOR XML path, root)))) AS XXperfvalutazionepersonaleuo 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT isnull((Select top 1 'Titolo: ' +title from perfcomportamento x where x.idperfcomportamento = perfvalutazionepersonalecomportamento.idperfcomportamento) + '; ','') AS Comportamento,isnull(CAST(perfvalutazionepersonalecomportamento.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfvalutazionepersonalecomportamento.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfvalutazionepersonalecomportamento
 WHERE perfvalutazionepersonalecomportamento.idperfvalutazionepersonale = perfvalutazionepersonale.idperfvalutazionepersonale FOR XML path, root)))) AS XXperfvalutazionepersonalecomportamento 
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT perfvalutazionepersonaleobiettivo.title AS Titolo,isnull(CAST(perfvalutazionepersonaleobiettivo.peso AS NVARCHAR(64)),'0.00') AS Peso,isnull(CAST(perfvalutazionepersonaleobiettivo.completamento AS NVARCHAR(64)),'0.00') AS Percentuale_di_completamento FROM  dbo.perfvalutazionepersonaleobiettivo
 WHERE perfvalutazionepersonaleobiettivo.idperfvalutazionepersonale = perfvalutazionepersonale.idperfvalutazionepersonale FOR XML path, root)))) AS XXperfvalutazionepersonaleobiettivo 
FROM [dbo].perfvalutazionepersonale WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].afferenza WITH (NOLOCK) ON perfvalutazionepersonale.idafferenza = [dbo].afferenza.idafferenza
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON [dbo].afferenza.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].mansionekind WITH (NOLOCK) ON [dbo].afferenza.idmansionekind = [dbo].mansionekind.idmansionekind
LEFT OUTER JOIN [dbo].perfschedastatus WITH (NOLOCK) ON perfvalutazionepersonale.idperfschedastatus = [dbo].perfschedastatus.idperfschedastatus
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON perfvalutazionepersonale.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].registry AS registryappr WITH (NOLOCK) ON perfvalutazionepersonale.idreg_appr = registryappr.idreg
LEFT OUTER JOIN [dbo].registry AS registryval WITH (NOLOCK) ON perfvalutazionepersonale.idreg_val = registryval.idreg
WHERE  perfvalutazionepersonale.idperfvalutazionepersonale IS NOT NULL  AND perfvalutazionepersonale.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA afferenzastruview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[afferenzastruview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[afferenzastruview]
GO

CREATE VIEW [dbo].[afferenzastruview] AS 
SELECT  afferenza.ct AS afferenza_ct, afferenza.cu AS afferenza_cu, afferenza.idafferenza,
 [dbo].mansionekind.title AS mansionekind_title, afferenza.idmansionekind AS afferenza_idmansionekind,
 [dbo].registry.title AS registry_title, afferenza.idreg,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, afferenza.idstruttura, afferenza.lt AS afferenza_lt, afferenza.lu AS afferenza_lu, afferenza.start AS afferenza_start, afferenza.stop AS afferenza_stop,
 isnull('Struttura: ' + [dbo].struttura.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, afferenza.start, 103),'') + ' ' + isnull('Tipologia Tipo: ' + [dbo].strutturakind.title + '; ','') + ' ' + isnull('al ' + CONVERT(VARCHAR, afferenza.stop, 103),'') as dropdown_title
FROM [dbo].afferenza WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].mansionekind WITH (NOLOCK) ON afferenza.idmansionekind = [dbo].mansionekind.idmansionekind
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON afferenza.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON afferenza.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  afferenza.idafferenza IS NOT NULL  AND afferenza.idreg IS NOT NULL  AND afferenza.idstruttura IS NOT NULL 
GO

-----------------------------------------------
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'strutturaperfelenchiview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('strutturaperfelenchiview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'afferenzastruview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('afferenzastruview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'afferenzaammview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('afferenzaammview')
GO
------------------------------------

IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaperfelenchiview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('strutturaperfelenchiview', '"idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idstruttura"' WHERE [tablename] = 'strutturaperfelenchiview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzastruview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('afferenzastruview', '"idafferenza","idreg","idstruttura"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idafferenza","idreg","idstruttura"' WHERE [tablename] = 'afferenzastruview'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'afferenzaammview')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('afferenzaammview', '"idafferenza","idreg"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idafferenza","idreg"' WHERE [tablename] = 'afferenzaammview'
GO
-------------------------
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'strutturaperfelenchiview' AND [listtype] = 'perfelenchi')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('strutturaperfelenchiview', 'perfelenchi', 'title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'title asc ' WHERE [tablename] = 'strutturaperfelenchiview' AND [listtype] = 'perfelenchi'
GO
---------------------------------

IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'strutturaperfelenchiparentview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'strutturaperfelenchiparentview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'strutturaperfelenchiparentview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'strutturaperfelenchiparentview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'strutturaperfelenchiparentview'
END
GO
