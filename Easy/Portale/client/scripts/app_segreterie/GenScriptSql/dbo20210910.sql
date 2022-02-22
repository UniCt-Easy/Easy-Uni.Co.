
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


IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[resetpassword]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[resetpassword](
	[date] [date] NOT NULL,
	[token] [nvarchar](max) NOT NULL,
	[idregistryreference] [int] NOT NULL,
	[status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

-- CREAZIONE TABELLA perfvalutazioneuoindicatori --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazioneuoindicatori]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazioneuoindicatori] (
idperfvalutazioneuo int NOT NULL,
idperfstruttura int NOT NULL,
idperfvalutazioneuoindicatori int NOT NULL,
idperfindicatore int NOT NULL,
completamento decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
peso decimal(19,2) NULL,
valorenumerico decimal(19,2) NULL,
 CONSTRAINT xpkperfvalutazioneuoindicatori PRIMARY KEY (idperfvalutazioneuo,
idperfstruttura,
idperfvalutazioneuoindicatori,
idperfindicatore
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazioneuoindicatori --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'idperfvalutazioneuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD idperfvalutazioneuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatori') and col.name = 'idperfvalutazioneuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatori] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'idperfstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD idperfstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatori') and col.name = 'idperfstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatori] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'idperfvalutazioneuoindicatori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD idperfvalutazioneuoindicatori int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatori') and col.name = 'idperfvalutazioneuoindicatori' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatori] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'idperfindicatore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD idperfindicatore int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatori') and col.name = 'idperfindicatore' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatori] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'completamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD completamento decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatori] ALTER COLUMN completamento decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatori') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatori] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatori] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatori') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatori] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatori] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatori') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatori] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatori] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazioneuoindicatori') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazioneuoindicatori] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatori] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'peso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD peso decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatori] ALTER COLUMN peso decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazioneuoindicatori' and C.name = 'valorenumerico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazioneuoindicatori] ADD valorenumerico decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazioneuoindicatori] ALTER COLUMN valorenumerico decimal(19,2) NULL
GO

-- CREAZIONE VISTA perfprogettoobiettivopersonaleview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivopersonaleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivopersonaleview]
GO



CREATE VIEW [dbo].[perfprogettoobiettivopersonaleview]
AS
SELECT distinct dbo.perfprogettoobiettivo.idperfprogetto, dbo.perfprogettoobiettivo.idperfprogettoobiettivo, dbo.perfprogettoobiettivo.title, dbo.perfprogettoobiettivo.description, dbo.perfprogettoobiettivo.peso, 
                  dbo.perfprogettoobiettivo.completamento, dbo.perfprogetto.idstruttura as idstruttura_perfprogetto, dbo.perfprogetto.title AS progetto_title, dbo.perfvalutazioneuo.idperfvalutazioneuo, dbo.perfvalutazioneuo.idstruttura
FROM     dbo.perfprogettoobiettivo INNER JOIN
                  dbo.perfprogetto ON dbo.perfprogettoobiettivo.idperfprogetto = dbo.perfprogetto.idperfprogetto 
				  INNER JOIN
                  dbo.perfvalutazioneuo ON dbo.perfprogetto.idstruttura <> dbo.perfvalutazioneuo.idstruttura AND YEAR(dbo.perfprogetto.datainizioprevista) <= dbo.perfvalutazioneuo.year AND YEAR(dbo.perfprogetto.datafineprevista) 
                  <= dbo.perfvalutazioneuo.year 
				  INNER JOIN
                  dbo.afferenza ON dbo.perfvalutazioneuo.idstruttura = dbo.afferenza.idstruttura AND dbo.perfvalutazioneuo.year >= YEAR(dbo.afferenza.start) AND dbo.perfvalutazioneuo.year <= YEAR(dbo.afferenza.stop) 
				  INNER JOIN
                  dbo.perfprogettouo ON dbo.perfprogetto.idperfprogetto = dbo.perfprogettouo.idperfprogetto 
				  INNER JOIN
                  dbo.perfprogettouomembro ON dbo.perfprogettouo.idperfprogetto = dbo.perfprogettouomembro.idperfprogetto AND dbo.perfprogettouo.idperfprogettouo = dbo.perfprogettouomembro.idperfprogettouo AND 
                  dbo.afferenza.idreg = dbo.perfprogettouomembro.idreg

GO

-- CREAZIONE TABELLA sostenimento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sostenimento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sostenimento] (
idsostenimento int NOT NULL,
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NOT NULL,
domande ntext NULL,
ects int NULL,
giudizio varchar(50) NULL,
idappello int NULL,
idattivform int NULL,
idcorsostudio int NULL,
iddidprog int NULL,
idiscrizione int NULL,
idprova int NULL,
idsostenimentoesito int NOT NULL,
idtitolostudio int NULL,
insecod varchar(50) NULL,
insedesc varchar(1024) NULL,
livello char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridsostenimento int NULL,
protanno int NULL,
protnumero int NULL,
voto decimal(9,2) NULL,
votolode char(1) NULL,
votosu int NULL,
 CONSTRAINT xpksostenimento PRIMARY KEY (idsostenimento,
idreg
)
)
END
GO

-- VERIFICA STRUTTURA sostenimento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idsostenimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idsostenimento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'idsostenimento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD data date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'data' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN data date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'domande' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD domande ntext NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'ects' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD ects int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN ects int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'giudizio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD giudizio varchar(50) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN giudizio varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idappello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idappello int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idappello int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idattivform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idattivform int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idattivform int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD iddidprog int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN iddidprog int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idiscrizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idiscrizione int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idiscrizione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idprova' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idprova int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idprova int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idsostenimentoesito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idsostenimentoesito int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'idsostenimentoesito' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idsostenimentoesito int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'idtitolostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD idtitolostudio int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN idtitolostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'insecod' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD insecod varchar(50) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN insecod varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'insedesc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD insedesc varchar(1024) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN insedesc varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'livello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD livello char(1) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN livello char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sostenimento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sostenimento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'paridsostenimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD paridsostenimento int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN paridsostenimento int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD protanno int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN protanno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD protnumero int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN protnumero int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'voto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD voto decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN voto decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'votolode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD votolode char(1) NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN votolode char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sostenimento' and C.name = 'votosu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sostenimento] ADD votosu int NULL 
END
ELSE
	ALTER TABLE [sostenimento] ALTER COLUMN votosu int NULL
GO

-- CREAZIONE TABELLA perfstrutturaperfindicatore --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfstrutturaperfindicatore]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfstrutturaperfindicatore] (
idstruttura int NOT NULL,
idperfindicatore int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkperfstrutturaperfindicatore PRIMARY KEY (idstruttura,
idperfindicatore
)
)
END
GO

-- VERIFICA STRUTTURA perfstrutturaperfindicatore --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfstrutturaperfindicatore' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfstrutturaperfindicatore] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfstrutturaperfindicatore') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfstrutturaperfindicatore] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfstrutturaperfindicatore' and C.name = 'idperfindicatore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfstrutturaperfindicatore] ADD idperfindicatore int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfstrutturaperfindicatore') and col.name = 'idperfindicatore' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfstrutturaperfindicatore] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfstrutturaperfindicatore' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfstrutturaperfindicatore] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfstrutturaperfindicatore') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfstrutturaperfindicatore] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfstrutturaperfindicatore] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfstrutturaperfindicatore' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfstrutturaperfindicatore] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfstrutturaperfindicatore') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfstrutturaperfindicatore] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfstrutturaperfindicatore] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfstrutturaperfindicatore' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfstrutturaperfindicatore] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfstrutturaperfindicatore') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfstrutturaperfindicatore] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfstrutturaperfindicatore] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfstrutturaperfindicatore' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfstrutturaperfindicatore] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfstrutturaperfindicatore') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfstrutturaperfindicatore] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfstrutturaperfindicatore] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- CREAZIONE TABELLA studprenotkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[studprenotkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[studprenotkind] (
idstudprenotkind int NOT NULL,
active char(1) NOT NULL,
description varchar(512) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortorder int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkstudprenotkind PRIMARY KEY (idstudprenotkind
)
)
END
GO

-- VERIFICA STRUTTURA studprenotkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'idstudprenotkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD idstudprenotkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'idstudprenotkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD description varchar(512) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN description varchar(512) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'sortorder' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD sortorder int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'sortorder' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN sortorder int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'studprenotkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [studprenotkind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('studprenotkind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [studprenotkind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [studprenotkind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER studprenotkind --
IF exists(SELECT * FROM [studprenotkind] WHERE idstudprenotkind = '1')
UPDATE [studprenotkind] SET active = 'S',description = 'Iscritto ad un corso dell''Istituto',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortorder = '2',title = 'Interno' WHERE idstudprenotkind = '1'
ELSE
INSERT INTO [studprenotkind] (idstudprenotkind,active,description,lt,lu,sortorder,title) VALUES ('1','S','Iscritto ad un corso dell''Istituto',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Interno')
GO

IF exists(SELECT * FROM [studprenotkind] WHERE idstudprenotkind = '2')
UPDATE [studprenotkind] SET active = 'S',description = 'Iscritto ad un corso dell''Istituto e docente altrove',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortorder = '3',title = 'Docente' WHERE idstudprenotkind = '2'
ELSE
INSERT INTO [studprenotkind] (idstudprenotkind,active,description,lt,lu,sortorder,title) VALUES ('2','S','Iscritto ad un corso dell''Istituto e docente altrove',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Docente')
GO

IF exists(SELECT * FROM [studprenotkind] WHERE idstudprenotkind = '3')
UPDATE [studprenotkind] SET active = 'S',description = 'Non è iscritto ad un corso dell''Istituto ma può prenotarsi ad appelli dedicati',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortorder = '1',title = 'Esterno' WHERE idstudprenotkind = '3'
ELSE
INSERT INTO [studprenotkind] (idstudprenotkind,active,description,lt,lu,sortorder,title) VALUES ('3','S','Non è iscritto ad un corso dell''Istituto ma può prenotarsi ad appelli dedicati',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Esterno')
GO

-- CREAZIONE TABELLA registry_istituti --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_istituti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_istituti] (
idreg int NOT NULL,
codicemiur varchar(50) NULL,
codiceustat varchar(50) NULL,
comune varchar(64) NULL,
ct datetime NULL,
cu varchar(64) NOT NULL,
idistitutokind int NOT NULL,
idistitutoustat int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nome nchar(128) NULL,
sortcode int NULL,
title varchar(256) NULL,
title_en varchar(256) NULL,
 CONSTRAINT xpkregistry_istituti PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_istituti --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'codicemiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD codicemiur varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN codicemiur varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'codiceustat' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD codiceustat varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN codiceustat varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'comune' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD comune varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN comune varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'idistitutokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD idistitutokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'idistitutokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN idistitutokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'idistitutoustat' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD idistitutoustat int NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN idistitutoustat int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_istituti') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_istituti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'nome' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD nome nchar(128) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN nome nchar(128) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD title varchar(256) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN title varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_istituti' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_istituti] ADD title_en varchar(256) NULL 
END
ELSE
	ALTER TABLE [registry_istituti] ALTER COLUMN title_en varchar(256) NULL
GO

-- CREAZIONE TABELLA naturagiur --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[naturagiur]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[naturagiur] (
idnaturagiur int NOT NULL,
active char(1) NOT NULL,
flagforeign char(1) NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NOT NULL,
title nvarchar(200) NOT NULL,
 CONSTRAINT xpknaturagiur PRIMARY KEY (idnaturagiur
)
)
END
GO

-- VERIFICA STRUTTURA naturagiur --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'idnaturagiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD idnaturagiur int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('naturagiur') and col.name = 'idnaturagiur' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [naturagiur] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('naturagiur') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [naturagiur] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'flagforeign' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD flagforeign char(1) NULL 
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN flagforeign char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('naturagiur') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [naturagiur] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'naturagiur' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [naturagiur] ADD title nvarchar(200) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('naturagiur') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [naturagiur] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [naturagiur] ALTER COLUMN title nvarchar(200) NOT NULL
GO


-- GENERAZIONE DATI PER naturagiur --
IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '1')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = 'Associazioni fra artisti e professionisti' WHERE idnaturagiur = '1'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('1','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Associazioni fra artisti e professionisti')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '2')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = 'Associazioni non riconosciute e comitati' WHERE idnaturagiur = '2'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('2','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Associazioni non riconosciute e comitati')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '3')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = 'Associazioni riconosciute' WHERE idnaturagiur = '3'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('3','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Associazioni riconosciute')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '4')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '4',title = 'Aziende autonome di cura, soggiorno e turismo' WHERE idnaturagiur = '4'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('4','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','4','Aziende autonome di cura, soggiorno e turismo')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '5')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '5',title = 'Aziende coniugali' WHERE idnaturagiur = '5'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('5','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','5','Aziende coniugali')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '6')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '6',title = 'Aziende regionali, provinciali, comunali e loro consorzi' WHERE idnaturagiur = '6'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('6','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','6','Aziende regionali, provinciali, comunali e loro consorzi')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '7')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '7',title = 'Casse mutue e fondi di previdenza, assistenza, pensioni o simili con o senza personalità giuridica' WHERE idnaturagiur = '7'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('7','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','7','Casse mutue e fondi di previdenza, assistenza, pensioni o simili con o senza personalità giuridica')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '8')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '8',title = 'Consorzi con personalità giuridica' WHERE idnaturagiur = '8'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('8','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','8','Consorzi con personalità giuridica')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '9')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '9',title = 'Consorzi senza personalità giuridica' WHERE idnaturagiur = '9'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('9','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','9','Consorzi senza personalità giuridica')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '10')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '10',title = 'Enti ed istituti di previdenza e di assistenza sociale' WHERE idnaturagiur = '10'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('10','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','10','Enti ed istituti di previdenza e di assistenza sociale')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '11')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '11',title = 'Enti ospedalieri' WHERE idnaturagiur = '11'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('11','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','11','Enti ospedalieri')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '12')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '12',title = 'Enti pubblici economici' WHERE idnaturagiur = '12'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('12','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','12','Enti pubblici economici')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '13')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '13',title = 'Enti pubblici non economici' WHERE idnaturagiur = '13'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('13','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','13','Enti pubblici non economici')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '14')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '14',title = 'Fondazioni' WHERE idnaturagiur = '14'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('14','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','14','Fondazioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '15')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '15',title = 'GEIE' WHERE idnaturagiur = '15'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('15','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','15','GEIE')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '16')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '16',title = 'Mutue assicuratrici' WHERE idnaturagiur = '16'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('16','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','16','Mutue assicuratrici')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '17')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '17',title = 'Opere pie e società di mutuo soccorso' WHERE idnaturagiur = '17'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('17','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','17','Opere pie e società di mutuo soccorso')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '18')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '18',title = 'Società a responsabilità limitata' WHERE idnaturagiur = '18'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('18','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','18','Società a responsabilità limitata')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '19')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '19',title = 'Società cooperative e loro consorzi iscritti nei registri prefettizi o nello schedario generale della cooperazione' WHERE idnaturagiur = '19'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('19','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','19','Società cooperative e loro consorzi iscritti nei registri prefettizi o nello schedario generale della cooperazione')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '20')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '20',title = 'Società di armamento' WHERE idnaturagiur = '20'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('20','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','20','Società di armamento')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '21')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '21',title = 'Società in accomandita per azioni' WHERE idnaturagiur = '21'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('21','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','21','Società in accomandita per azioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '22')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '22',title = 'Società in accomandita semplice' WHERE idnaturagiur = '22'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('22','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','22','Società in accomandita semplice')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '23')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '23',title = 'Società in nome collettivo ed equiparate' WHERE idnaturagiur = '23'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('23','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','23','Società in nome collettivo ed equiparate')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '24')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '24',title = 'Società per azioni' WHERE idnaturagiur = '24'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('24','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','24','Società per azioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '25')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '25',title = 'Società per azioni, aziende speciali e consorzi di cui agli artt. 23, 25 e 60 della legge 8 giugno 1990, n. 142' WHERE idnaturagiur = '25'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('25','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','25','Società per azioni, aziende speciali e consorzi di cui agli artt. 23, 25 e 60 della legge 8 giugno 1990, n. 142')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '26')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '26',title = 'Società semplici ed equiparate ai sensi dell''art. 5, comma 3, lett. b, del Tuir' WHERE idnaturagiur = '26'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('26','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','26','Società semplici ed equiparate ai sensi dell''art. 5, comma 3, lett. b, del Tuir')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '27')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '27',title = 'Società, organizzazioni ed enti costituiti all''estero non altrimenti classificabili con sede dell''amministrazione od oggetto principale in Italia' WHERE idnaturagiur = '27'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('27','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','27','Società, organizzazioni ed enti costituiti all''estero non altrimenti classificabili con sede dell''amministrazione od oggetto principale in Italia')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '28')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '28',title = 'Altre organizzazioni di persone o di beni senza personalità giuridica (escluse le comunioni)' WHERE idnaturagiur = '28'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('28','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','28','Altre organizzazioni di persone o di beni senza personalità giuridica (escluse le comunioni)')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '29')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '29',title = 'Altre società cooperative' WHERE idnaturagiur = '29'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('29','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','29','Altre società cooperative')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '30')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'N',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '30',title = 'Altri enti ed istituti con personalità giuridica' WHERE idnaturagiur = '30'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('30','S','N',{ts '2019-02-28 18:02:19.867'},'Ferdinando','30','Altri enti ed istituti con personalità giuridica')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '31')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = 'Associazioni fra professionisti' WHERE idnaturagiur = '31'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('31','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Associazioni fra professionisti')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '32')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = 'Associazioni riconosciute, non riconosciute e di fatto' WHERE idnaturagiur = '32'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('32','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Associazioni riconosciute, non riconosciute e di fatto')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '33')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = 'Consorzi' WHERE idnaturagiur = '33'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('33','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Consorzi')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '34')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '4',title = 'Fondazioni' WHERE idnaturagiur = '34'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('34','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','4','Fondazioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '35')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '5',title = 'Opere pie e società di mutuo soccorso' WHERE idnaturagiur = '35'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('35','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','5','Opere pie e società di mutuo soccorso')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '36')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '6',title = 'Società a responsabilità limitata' WHERE idnaturagiur = '36'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('36','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','6','Società a responsabilità limitata')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '37')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '7',title = 'Società di armamento' WHERE idnaturagiur = '37'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('37','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','7','Società di armamento')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '38')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '8',title = 'Società in accomandita per azioni' WHERE idnaturagiur = '38'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('38','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','8','Società in accomandita per azioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '39')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '9',title = 'Società in accomandita semplice' WHERE idnaturagiur = '39'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('39','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','9','Società in accomandita semplice')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '40')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '10',title = 'Società in nome collettivo' WHERE idnaturagiur = '40'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('40','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','10','Società in nome collettivo')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '41')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '11',title = 'Società per azioni' WHERE idnaturagiur = '41'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('41','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','11','Società per azioni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '42')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '12',title = 'Società semplici irregolari e di fatto' WHERE idnaturagiur = '42'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('42','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','12','Società semplici irregolari e di fatto')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '43')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '13',title = 'Altre organizzazioni di persone e di beni' WHERE idnaturagiur = '43'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('43','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','13','Altre organizzazioni di persone e di beni')
GO

IF exists(SELECT * FROM [naturagiur] WHERE idnaturagiur = '44')
UPDATE [naturagiur] SET active = 'S',flagforeign = 'S',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '14',title = 'Altri enti ed istituti' WHERE idnaturagiur = '44'
ELSE
INSERT INTO [naturagiur] (idnaturagiur,active,flagforeign,lt,lu,sortcode,title) VALUES ('44','S','S',{ts '2019-02-28 18:02:19.867'},'Ferdinando','14','Altri enti ed istituti')
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_nation' and C.name = 'lang' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_nation] ADD lang varchar(64) NULL 
END
ELSE
	ALTER TABLE [geo_nation] ALTER COLUMN lang varchar(64) NULL
GO


-- CREAZIONE TABELLA didprog --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprog] (
iddidprog int NOT NULL,
idcorsostudio int NOT NULL,
aa nvarchar(9) NULL,
annosolare int NULL,
attribdebiti nvarchar(max) NULL,
ciclo int NULL,
codice varchar(50) NULL,
codicemiur varchar(50) NULL,
dataconsmaxiscr date NULL,
freqobbl char(1) NULL,
idareadidattica int NULL,
idconvenzione int NULL,
iddidprognumchiusokind int NULL,
iddidprogsuddannokind int NULL,
iderogazkind int NULL,
idgraduatoria int NULL,
idnation_lang int NULL,
idnation_lang2 int NULL,
idnation_langvis int NULL,
idreg_docenti int NULL,
idsede int NULL,
idsessione int NULL,
idtitolokind int NULL,
immatoltreauth char(1) NULL,
modaccesso nvarchar(max) NULL,
modaccesso_en nvarchar(max) NULL,
obbformativi nvarchar(max) NULL,
obbformativi_en nvarchar(max) NULL,
preimmatoltreauth char(1) NULL,
progesamamm nvarchar(max) NULL,
prospoccupaz nvarchar(max) NULL,
provafinaledesc nvarchar(max) NULL,
regolamentotax nvarchar(max) NULL,
regolamentotaxurl varchar(512) NULL,
startiscrizioni datetime NULL,
stopiscrizioni datetime NULL,
title varchar(1024) NULL,
title_en varchar(1024) NULL,
utenzasost int NULL,
website varchar(512) NULL,
 CONSTRAINT xpkdidprog PRIMARY KEY (iddidprog,
idcorsostudio
)
)
END
GO

-- VERIFICA STRUTTURA didprog --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprog') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprog] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprog') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprog] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD aa nvarchar(9) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN aa nvarchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'annosolare' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD annosolare int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN annosolare int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'attribdebiti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD attribdebiti nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN attribdebiti nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'ciclo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD ciclo int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN ciclo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'codicemiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD codicemiur varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN codicemiur varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'dataconsmaxiscr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD dataconsmaxiscr date NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN dataconsmaxiscr date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'freqobbl' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD freqobbl char(1) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN freqobbl char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idareadidattica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idareadidattica int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idareadidattica int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idconvenzione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idconvenzione int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idconvenzione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iddidprognumchiusokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iddidprognumchiusokind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN iddidprognumchiusokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iddidprogsuddannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iddidprogsuddannokind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN iddidprogsuddannokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iderogazkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iderogazkind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN iderogazkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idgraduatoria int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idgraduatoria int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idnation_lang' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idnation_lang int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idnation_lang int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idnation_lang2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idnation_lang2 int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idnation_lang2 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idnation_langvis' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idnation_langvis int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idnation_langvis int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idreg_docenti int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idreg_docenti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idsede int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idsede int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idsessione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idsessione int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idsessione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idtitolokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idtitolokind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idtitolokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'immatoltreauth' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD immatoltreauth char(1) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN immatoltreauth char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'modaccesso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD modaccesso nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN modaccesso nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'modaccesso_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD modaccesso_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN modaccesso_en nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'obbformativi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD obbformativi nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN obbformativi nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'obbformativi_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD obbformativi_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN obbformativi_en nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'preimmatoltreauth' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD preimmatoltreauth char(1) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN preimmatoltreauth char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'progesamamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD progesamamm nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN progesamamm nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'prospoccupaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD prospoccupaz nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN prospoccupaz nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'provafinaledesc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD provafinaledesc nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN provafinaledesc nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'regolamentotax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD regolamentotax nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN regolamentotax nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'regolamentotaxurl' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD regolamentotaxurl varchar(512) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN regolamentotaxurl varchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'startiscrizioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD startiscrizioni datetime NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN startiscrizioni datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'stopiscrizioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD stopiscrizioni datetime NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN stopiscrizioni datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN title varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD title_en varchar(1024) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN title_en varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'utenzasost' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD utenzasost int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN utenzasost int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'website' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD website varchar(512) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN website varchar(512) NULL
GO

-- CREAZIONE TABELLA struttura --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[struttura]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[struttura] (
idstruttura int NOT NULL,
codice varchar(50) NULL,
codiceipa nchar(10) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email varchar(200) NULL,
fax varchar(50) NULL,
idaoo int NULL,
idreg int NULL,
idreg_resp int NULL,
idsede int NOT NULL,
idstrutturakind int NOT NULL,
idupb varchar(36) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
paridstruttura int NULL,
pesoindicatori decimal(19,2) NULL,
pesoobiettivi decimal(19,2) NULL,
pesoprogaltreuo decimal(19,2) NULL,
pesoproguo decimal(19,2) NULL,
telefono varchar(50) NULL,
title varchar(1024) NULL,
title_en varchar(1024) NULL,
 CONSTRAINT xpkstruttura PRIMARY KEY (idstruttura
)
)
END
GO

-- VERIFICA STRUTTURA struttura --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'codiceipa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD codiceipa nchar(10) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN codiceipa nchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'email' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD email varchar(200) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN email varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'fax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD fax varchar(50) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN fax varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idaoo int NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idaoo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idreg_resp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idreg_resp int NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idreg_resp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idsede int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idsede' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idsede int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idstrutturakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idstrutturakind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'idstrutturakind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idstrutturakind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD idupb varchar(36) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN idupb varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('struttura') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [struttura] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'paridstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD paridstruttura int NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN paridstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'pesoindicatori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD pesoindicatori decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN pesoindicatori decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'pesoobiettivi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD pesoobiettivi decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN pesoobiettivi decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'pesoprogaltreuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD pesoprogaltreuo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN pesoprogaltreuo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'pesoproguo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD pesoproguo decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN pesoproguo decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'telefono' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD telefono varchar(50) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN telefono varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN title varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'struttura' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [struttura] ADD title_en varchar(1024) NULL 
END
ELSE
	ALTER TABLE [struttura] ALTER COLUMN title_en varchar(1024) NULL
GO

-- CREAZIONE TABELLA perfvalutazionepersonaleobiettivo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfvalutazionepersonaleobiettivo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfvalutazionepersonaleobiettivo] (
idperfvalutazionepersonale int NOT NULL,
idperfvalutazionepersonaleobiettivo int NOT NULL,
completamento decimal(19,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
inverso char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
peso decimal(19,2) NULL,
title varchar(2048) NULL,
valorenumerico decimal(19,2) NULL,
 CONSTRAINT xpkperfvalutazionepersonaleobiettivo PRIMARY KEY (idperfvalutazionepersonale,
idperfvalutazionepersonaleobiettivo
)
)
END
GO

-- VERIFICA STRUTTURA perfvalutazionepersonaleobiettivo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'idperfvalutazionepersonale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD idperfvalutazionepersonale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleobiettivo') and col.name = 'idperfvalutazionepersonale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleobiettivo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'idperfvalutazionepersonaleobiettivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD idperfvalutazionepersonaleobiettivo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleobiettivo') and col.name = 'idperfvalutazionepersonaleobiettivo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleobiettivo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'completamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD completamento decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN completamento decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleobiettivo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleobiettivo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleobiettivo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleobiettivo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'inverso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD inverso char(1) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN inverso char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleobiettivo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleobiettivo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfvalutazionepersonaleobiettivo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfvalutazionepersonaleobiettivo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'peso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD peso decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN peso decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN title varchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfvalutazionepersonaleobiettivo' and C.name = 'valorenumerico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ADD valorenumerico decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfvalutazionepersonaleobiettivo] ALTER COLUMN valorenumerico decimal(19,2) NULL
GO

-- CREAZIONE TABELLA perfobiettiviuosoglia --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfobiettiviuosoglia]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfobiettiviuosoglia] (
idperfvalutazioneuo int NOT NULL,
idperfobiettiviuo int NOT NULL,
idperfobiettiviuosoglia int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
idperfsogliakind varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
percentuale decimal(19,2) NULL,
valorenumerico decimal(19,2) NULL,
 CONSTRAINT xpkperfobiettiviuosoglia PRIMARY KEY (idperfvalutazioneuo,
idperfobiettiviuo,
idperfobiettiviuosoglia
)
)
END
GO

-- VERIFICA STRUTTURA perfobiettiviuosoglia --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'idperfvalutazioneuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD idperfvalutazioneuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettiviuosoglia') and col.name = 'idperfvalutazioneuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettiviuosoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'idperfobiettiviuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD idperfobiettiviuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettiviuosoglia') and col.name = 'idperfobiettiviuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettiviuosoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'idperfobiettiviuosoglia' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD idperfobiettiviuosoglia int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettiviuosoglia') and col.name = 'idperfobiettiviuosoglia' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettiviuosoglia] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettiviuosoglia') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettiviuosoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfobiettiviuosoglia] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettiviuosoglia') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettiviuosoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfobiettiviuosoglia] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfobiettiviuosoglia] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'idperfsogliakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD idperfsogliakind varchar(50) NULL 
END
ELSE
	ALTER TABLE [perfobiettiviuosoglia] ALTER COLUMN idperfsogliakind varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettiviuosoglia') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettiviuosoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfobiettiviuosoglia] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettiviuosoglia') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettiviuosoglia] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfobiettiviuosoglia] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'percentuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD percentuale decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfobiettiviuosoglia] ALTER COLUMN percentuale decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuosoglia' and C.name = 'valorenumerico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuosoglia] ADD valorenumerico decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfobiettiviuosoglia] ALTER COLUMN valorenumerico decimal(19,2) NULL
GO

-- CREAZIONE TABELLA perfobiettiviuo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfobiettiviuo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfobiettiviuo] (
idperfvalutazioneuo int NOT NULL,
idperfobiettiviuo int NOT NULL,
completamento decimal(19,2) NULL,
description varchar(max) NULL,
peso decimal(19,2) NULL,
title varchar(2048) NULL,
valorenumerico decimal(19,2) NULL,
 CONSTRAINT xpkperfobiettiviuo PRIMARY KEY (idperfvalutazioneuo,
idperfobiettiviuo
)
)
END
GO

-- VERIFICA STRUTTURA perfobiettiviuo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuo' and C.name = 'idperfvalutazioneuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuo] ADD idperfvalutazioneuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettiviuo') and col.name = 'idperfvalutazioneuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettiviuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuo' and C.name = 'idperfobiettiviuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuo] ADD idperfobiettiviuo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettiviuo') and col.name = 'idperfobiettiviuo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettiviuo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuo' and C.name = 'completamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuo] ADD completamento decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfobiettiviuo] ALTER COLUMN completamento decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuo' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuo] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfobiettiviuo] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuo' and C.name = 'peso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuo] ADD peso decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfobiettiviuo] ALTER COLUMN peso decimal(19,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuo' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuo] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [perfobiettiviuo] ALTER COLUMN title varchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettiviuo' and C.name = 'valorenumerico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettiviuo] ADD valorenumerico decimal(19,2) NULL 
END
ELSE
	ALTER TABLE [perfobiettiviuo] ALTER COLUMN valorenumerico decimal(19,2) NULL
GO

-- CREAZIONE VISTA affidamentosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[affidamentosegview]
GO

CREATE VIEW [dbo].[affidamentosegview] AS 
SELECT  affidamento.aa, affidamento.ct AS affidamento_ct, affidamento.cu AS affidamento_cu,CASE WHEN affidamento.freqobbl = 'S' THEN 'Si' WHEN affidamento.freqobbl = 'N' THEN 'No' END AS affidamento_freqobbl, affidamento.frequenzaminima AS affidamento_frequenzaminima, affidamento.frequenzaminimadebito AS affidamento_frequenzaminimadebito,CASE WHEN affidamento.gratuito = 'S' THEN 'Si' WHEN affidamento.gratuito = 'N' THEN 'No' END AS affidamento_gratuito, affidamento.idaffidamento,
 [dbo].affidamentokind.title AS affidamentokind_title, affidamento.idaffidamentokind AS affidamento_idaffidamentokind, affidamento.idattivform, affidamento.idcanale, affidamento.idcorsostudio, affidamento.iddidprog, affidamento.iddidproganno, affidamento.iddidprogcurr, affidamento.iddidprogori, affidamento.iddidprogporzanno,
 [dbo].erogazkind.title AS erogazkind_title, affidamento.iderogazkind AS affidamento_iderogazkind, affidamento.idreg_docenti, affidamento.idsede AS affidamento_idsede, affidamento.json AS affidamento_json, affidamento.jsonancestor AS affidamento_jsonancestor, affidamento.lt AS affidamento_lt, affidamento.lu AS affidamento_lu, affidamento.orariric AS affidamento_orariric, affidamento.orariric_en AS affidamento_orariric_en, affidamento.paridaffidamento AS affidamento_paridaffidamento, affidamento.prog AS affidamento_prog, affidamento.prog_en AS affidamento_prog_en,CASE WHEN affidamento.riferimento = 'S' THEN 'Si' WHEN affidamento.riferimento = 'N' THEN 'No' END AS affidamento_riferimento, affidamento.start AS affidamento_start, affidamento.stop AS affidamento_stop, affidamento.testi AS affidamento_testi, affidamento.testi_en AS affidamento_testi_en, affidamento.title, affidamento.urlcorso AS affidamento_urlcorso,
 isnull('Denominazione: ' + affidamento.title + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT affidamentocaratteristica.json AS Caratteristiche FROM  dbo.affidamentocaratteristica
 WHERE affidamentocaratteristica.aa = affidamento.aa AND affidamentocaratteristica.idaffidamento = affidamento.idaffidamento AND affidamentocaratteristica.idattivform = affidamento.idattivform AND affidamentocaratteristica.idcanale = affidamento.idcanale AND affidamentocaratteristica.idcorsostudio = affidamento.idcorsostudio AND affidamentocaratteristica.iddidprog = affidamento.iddidprog AND affidamentocaratteristica.iddidproganno = affidamento.iddidproganno AND affidamentocaratteristica.iddidprogcurr = affidamento.iddidprogcurr AND affidamentocaratteristica.iddidprogori = affidamento.iddidprogori AND affidamentocaratteristica.iddidprogporzanno = affidamento.iddidprogporzanno FOR XML path, root)))) AS XXaffidamentocaratteristica 
FROM [dbo].affidamento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].affidamentokind WITH (NOLOCK) ON affidamento.idaffidamentokind = [dbo].affidamentokind.idaffidamentokind
LEFT OUTER JOIN [dbo].erogazkind WITH (NOLOCK) ON affidamento.iderogazkind = [dbo].erogazkind.iderogazkind
WHERE  affidamento.aa IS NOT NULL  AND affidamento.idaffidamento IS NOT NULL  AND affidamento.idattivform IS NOT NULL  AND affidamento.idcanale IS NOT NULL  AND affidamento.idcorsostudio IS NOT NULL  AND affidamento.iddidprog IS NOT NULL  AND affidamento.iddidproganno IS NOT NULL  AND affidamento.iddidprogcurr IS NOT NULL  AND affidamento.iddidprogori IS NOT NULL  AND affidamento.iddidprogporzanno IS NOT NULL  AND affidamento.idreg_docenti IS NOT NULL 
GO

-- CREAZIONE VISTA affidamentodocenteview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentodocenteview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[affidamentodocenteview]
GO

CREATE VIEW [dbo].[affidamentodocenteview] AS 
SELECT  affidamento.aa, affidamento.ct AS affidamento_ct, affidamento.cu AS affidamento_cu,CASE WHEN affidamento.freqobbl = 'S' THEN 'Si' WHEN affidamento.freqobbl = 'N' THEN 'No' END AS affidamento_freqobbl, affidamento.frequenzaminima AS affidamento_frequenzaminima, affidamento.frequenzaminimadebito AS affidamento_frequenzaminimadebito,CASE WHEN affidamento.gratuito = 'S' THEN 'Si' WHEN affidamento.gratuito = 'N' THEN 'No' END AS affidamento_gratuito, affidamento.idaffidamento,
 [dbo].affidamentokind.title AS affidamentokind_title, affidamento.idaffidamentokind AS affidamento_idaffidamentokind, affidamento.idattivform, affidamento.idcanale, affidamento.idcorsostudio, affidamento.iddidprog, affidamento.iddidproganno, affidamento.iddidprogcurr, affidamento.iddidprogori, affidamento.iddidprogporzanno,
 [dbo].erogazkind.title AS erogazkind_title, affidamento.iderogazkind AS affidamento_iderogazkind, affidamento.idreg_docenti, affidamento.idsede AS affidamento_idsede, affidamento.json AS affidamento_json, affidamento.jsonancestor AS affidamento_jsonancestor, affidamento.lt AS affidamento_lt, affidamento.lu AS affidamento_lu, affidamento.orariric AS affidamento_orariric, affidamento.orariric_en AS affidamento_orariric_en, affidamento.paridaffidamento AS affidamento_paridaffidamento, affidamento.prog AS affidamento_prog, affidamento.prog_en AS affidamento_prog_en,CASE WHEN affidamento.riferimento = 'S' THEN 'Si' WHEN affidamento.riferimento = 'N' THEN 'No' END AS affidamento_riferimento, affidamento.start AS affidamento_start, affidamento.stop AS affidamento_stop, affidamento.testi AS affidamento_testi, affidamento.testi_en AS affidamento_testi_en, affidamento.title, affidamento.urlcorso AS affidamento_urlcorso,
 isnull('Denominazione: ' + affidamento.title + '; ','') as dropdown_title
 , (SELECT (SELECT dbo.CreateJSON((SELECT DISTINCT affidamentocaratteristica.json AS Caratteristiche FROM  dbo.affidamentocaratteristica
 WHERE affidamentocaratteristica.aa = affidamento.aa AND affidamentocaratteristica.idaffidamento = affidamento.idaffidamento AND affidamentocaratteristica.idattivform = affidamento.idattivform AND affidamentocaratteristica.idcanale = affidamento.idcanale AND affidamentocaratteristica.idcorsostudio = affidamento.idcorsostudio AND affidamentocaratteristica.iddidprog = affidamento.iddidprog AND affidamentocaratteristica.iddidproganno = affidamento.iddidproganno AND affidamentocaratteristica.iddidprogcurr = affidamento.iddidprogcurr AND affidamentocaratteristica.iddidprogori = affidamento.iddidprogori AND affidamentocaratteristica.iddidprogporzanno = affidamento.iddidprogporzanno FOR XML path, root)))) AS XXaffidamentocaratteristica 
FROM [dbo].affidamento WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].affidamentokind WITH (NOLOCK) ON affidamento.idaffidamentokind = [dbo].affidamentokind.idaffidamentokind
LEFT OUTER JOIN [dbo].erogazkind WITH (NOLOCK) ON affidamento.iderogazkind = [dbo].erogazkind.iderogazkind
WHERE  affidamento.aa IS NOT NULL  AND affidamento.idaffidamento IS NOT NULL  AND affidamento.idattivform IS NOT NULL  AND affidamento.idcanale IS NOT NULL  AND affidamento.idcorsostudio IS NOT NULL  AND affidamento.iddidprog IS NOT NULL  AND affidamento.iddidproganno IS NOT NULL  AND affidamento.iddidprogcurr IS NOT NULL  AND affidamento.iddidprogori IS NOT NULL  AND affidamento.iddidprogporzanno IS NOT NULL  AND affidamento.idreg_docenti IS NOT NULL 
GO

-- CREAZIONE VISTA studprenotkinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[studprenotkinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[studprenotkinddefaultview]
GO

CREATE VIEW [dbo].[studprenotkinddefaultview] AS 
SELECT CASE WHEN studprenotkind.active = 'S' THEN 'Si' WHEN studprenotkind.active = 'N' THEN 'No' END AS studprenotkind_active, studprenotkind.description AS studprenotkind_description, studprenotkind.idstudprenotkind, studprenotkind.lt AS studprenotkind_lt, studprenotkind.lu AS studprenotkind_lu, studprenotkind.sortorder AS studprenotkind_sortorder, studprenotkind.title,
 isnull('Titolo: ' + studprenotkind.title + '; ','') as dropdown_title
FROM [dbo].studprenotkind WITH (NOLOCK) 
WHERE  studprenotkind.idstudprenotkind IS NOT NULL 
GO

--[DBO]--
-- CREAZIONE TABELLA questionario --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[questionario]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[questionario] (
idquestionario int NOT NULL,
anonimo char(1) NULL,
ct datetime NOT NULL,
cu varchar(50) NOT NULL,
description varchar(255) NULL,
idquestionariokind int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(50) NULL,
 CONSTRAINT xpkquestionario PRIMARY KEY (idquestionario
)
)
END
GO

-- VERIFICA STRUTTURA questionario --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionario' and C.name = 'idquestionario' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionario] ADD idquestionario int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionario') and col.name = 'idquestionario' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionario] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionario' and C.name = 'anonimo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionario] ADD anonimo char(1) NULL 
END
ELSE
	ALTER TABLE [questionario] ALTER COLUMN anonimo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionario' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionario] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionario') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionario] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionario] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionario' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionario] ADD cu varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionario') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionario] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionario] ALTER COLUMN cu varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionario' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionario] ADD description varchar(255) NULL 
END
ELSE
	ALTER TABLE [questionario] ALTER COLUMN description varchar(255) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionario' and C.name = 'idquestionariokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionario] ADD idquestionariokind int NULL 
END
ELSE
	ALTER TABLE [questionario] ALTER COLUMN idquestionariokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionario' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionario] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionario') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionario] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionario] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionario' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionario] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('questionario') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [questionario] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [questionario] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'questionario' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [questionario] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [questionario] ALTER COLUMN title varchar(50) NULL
GO

--[DBO]--
-- CREAZIONE TABELLA valutazionekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[valutazionekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[valutazionekind] (
idvalutazionekind int NOT NULL,
active char(19) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkvalutazionekind PRIMARY KEY (idvalutazionekind
)
)
END
GO

-- VERIFICA STRUTTURA valutazionekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'idvalutazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD idvalutazionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'idvalutazionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD active char(19) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN active char(19) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'valutazionekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [valutazionekind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('valutazionekind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [valutazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [valutazionekind] ALTER COLUMN title varchar(50) NOT NULL
GO
-- GENERAZIONE DATI PER valutazionekind --
IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '1')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'prova scritta' WHERE idvalutazionekind = '1'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','1','prova scritta')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '2')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'prova orale' WHERE idvalutazionekind = '2'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','2','prova orale')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '3')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-01-09 21:02:07.797'},lu = 'riccardotest',sortcode = '3',title = 'prova pratica' WHERE idvalutazionekind = '3'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-01-09 21:02:07.797'},'riccardotest','3','prova pratica')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '4')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2020-01-09 21:02:21.283'},lu = 'riccardotest',sortcode = '4',title = 'test attitudinale' WHERE idvalutazionekind = '4'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2020-01-09 21:02:21.283'},'riccardotest','4','test attitudinale')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '5')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'valutazione di un progetto' WHERE idvalutazionekind = '5'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('5','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','5','valutazione di un progetto')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '6')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '6',title = 'tirocinio' WHERE idvalutazionekind = '6'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('6','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','6','tirocinio')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '7')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = null,lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '7',title = 'laboratorio' WHERE idvalutazionekind = '7'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('7','S                  ',{ts '2018-06-11 11:35:00.653'},'ferdinando',null,{ts '2018-06-11 11:35:00.653'},'ferdinando','7','laboratorio')
GO

IF exists(SELECT * FROM [valutazionekind] WHERE idvalutazionekind = '8')
UPDATE [valutazionekind] SET active = 'S                  ',ct = {ts '2020-01-21 18:16:21.273'},cu = 'riccardotest',description = null,lt = {ts '2020-01-21 18:16:21.273'},lu = 'riccardotest',sortcode = '8',title = 'Dettato' WHERE idvalutazionekind = '8'
ELSE
INSERT INTO [valutazionekind] (idvalutazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('8','S                  ',{ts '2020-01-21 18:16:21.273'},'riccardotest',null,{ts '2020-01-21 18:16:21.273'},'riccardotest','8','Dettato')
GO

--[DBO]--
-- CREAZIONE TABELLA commiss --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[commiss]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[commiss] (
idcommiss int NOT NULL,
idprova int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idappello int NULL,
idcorsostudio int NULL,
iddidprog int NULL,
idreg_docenti int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkcommiss PRIMARY KEY (idcommiss,
idprova
)
)
END
GO

-- VERIFICA STRUTTURA commiss --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idcommiss' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idcommiss int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'idcommiss' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idprova' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idprova int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'idprova' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idappello' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idappello int NULL 
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN idappello int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD iddidprog int NULL 
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN iddidprog int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN idreg_docenti int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'commiss' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [commiss] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('commiss') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [commiss] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [commiss] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- GENERAZIONE DATI PER studprenotkinddefaultview --
-- CREAZIONE VISTA provaingressoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[provaingressoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[provaingressoview]
GO

CREATE VIEW [dbo].[provaingressoview] AS 
SELECT  prova.ct AS prova_ct, prova.cu AS prova_cu, prova.idappello AS prova_idappello, prova.idattivform AS prova_idattivform, prova.idcorsostudio, prova.iddidprog, prova.idprova,
 [dbo].questionario.title AS questionario_title, prova.idquestionario,
 [dbo].valutazionekind.title AS valutazionekind_title, prova.idvalutazionekind AS prova_idvalutazionekind, prova.lt AS prova_lt, prova.lu AS prova_lu, prova.programma AS prova_programma, prova.start AS prova_start, prova.stop AS prova_stop, prova.title,(select top 1 idreg_docenti 
						from dbo.commiss 
						where dbo.commiss.idprova = prova.idprova
						 order by commiss.idcommiss asc ) as idreg_docenti,
 isnull('Denominazione: ' + prova.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, prova.start, 103),'') as dropdown_title
FROM [dbo].prova WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].questionario WITH (NOLOCK) ON prova.idquestionario = [dbo].questionario.idquestionario
LEFT OUTER JOIN [dbo].valutazionekind WITH (NOLOCK) ON prova.idvalutazionekind = [dbo].valutazionekind.idvalutazionekind
WHERE  prova.idcorsostudio IS NOT NULL  AND prova.iddidprog IS NOT NULL  AND prova.idprova IS NOT NULL 
GO

-- CREAZIONE VISTA provadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[provadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[provadefaultview]
GO

CREATE VIEW [dbo].[provadefaultview] AS 
SELECT  prova.ct AS prova_ct, prova.cu AS prova_cu, prova.idappello, prova.idattivform AS prova_idattivform, prova.idcorsostudio AS prova_idcorsostudio, prova.iddidprog AS prova_iddidprog, prova.idprova,
 [dbo].questionario.title AS questionario_title, prova.idquestionario,
 [dbo].valutazionekind.title AS valutazionekind_title, prova.idvalutazionekind AS prova_idvalutazionekind, prova.lt AS prova_lt, prova.lu AS prova_lu, prova.programma AS prova_programma, prova.start AS prova_start, prova.stop AS prova_stop, prova.title,(select top 1 idreg_docenti 
						from dbo.commiss 
						where dbo.commiss.idprova = prova.idprova
						 order by commiss.idcommiss asc ) as idreg_docenti,
 isnull('Denominazione: ' + prova.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, prova.start, 103),'') as dropdown_title
FROM [dbo].prova WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].questionario WITH (NOLOCK) ON prova.idquestionario = [dbo].questionario.idquestionario
LEFT OUTER JOIN [dbo].valutazionekind WITH (NOLOCK) ON prova.idvalutazionekind = [dbo].valutazionekind.idvalutazionekind
WHERE  prova.idappello IS NOT NULL  AND prova.idprova IS NOT NULL 
GO

-- CREAZIONE VISTA naturagiurdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[naturagiurdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[naturagiurdefaultview]
GO

CREATE VIEW [dbo].[naturagiurdefaultview] AS 
SELECT CASE WHEN naturagiur.active = 'S' THEN 'Si' WHEN naturagiur.active = 'N' THEN 'No' END AS naturagiur_active,CASE WHEN naturagiur.flagforeign = 'S' THEN 'Si' WHEN naturagiur.flagforeign = 'N' THEN 'No' END AS naturagiur_flagforeign, naturagiur.idnaturagiur, naturagiur.lt AS naturagiur_lt, naturagiur.lu AS naturagiur_lu, naturagiur.sortcode AS naturagiur_sortcode, naturagiur.title,
 isnull('Titolo: ' + naturagiur.title + '; ','') as dropdown_title
FROM [dbo].naturagiur WITH (NOLOCK) 
WHERE  naturagiur.idnaturagiur IS NOT NULL 
GO


-- GENERAZIONE DATI PER naturagiurdefaultview --
-- CREAZIONE VISTA didprogingressoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogingressoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[didprogingressoview]
GO

CREATE VIEW [dbo].[didprogingressoview] AS 
SELECT  didprog.aa, didprog.annosolare AS didprog_annosolare, didprog.attribdebiti AS didprog_attribdebiti, didprog.ciclo AS didprog_ciclo, didprog.codice AS didprog_codice, didprog.codicemiur AS didprog_codicemiur, didprog.dataconsmaxiscr AS didprog_dataconsmaxiscr,CASE WHEN didprog.freqobbl = 'S' THEN 'Si' WHEN didprog.freqobbl = 'N' THEN 'No' END AS didprog_freqobbl, didprog.idareadidattica AS didprog_idareadidattica, didprog.idconvenzione AS didprog_idconvenzione,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, didprog.idcorsostudio, didprog.iddidprog,
 [dbo].didprognumchiusokind.title AS didprognumchiusokind_title, didprog.iddidprognumchiusokind AS didprog_iddidprognumchiusokind, didprog.iddidprogsuddannokind AS didprog_iddidprogsuddannokind, didprog.iderogazkind AS didprog_iderogazkind,
 [dbo].graduatoria.title AS graduatoria_title, didprog.idgraduatoria,
 geo_nationlang.lang AS geo_nationlang_lang, didprog.idnation_lang,
 geo_nationlang2.lang AS geo_nationlang2_lang, didprog.idnation_lang2,
 geo_nationlangvis.lang AS geo_nationlangvis_lang, didprog.idnation_langvis, didprog.idreg_docenti AS didprog_idreg_docenti,
 [dbo].sede.title AS sede_title, didprog.idsede,
 [dbo].sessionekind.title AS sessionekind_title, [dbo].sessione.idsessionekind AS sessione_idsessionekind, [dbo].sessione.start AS sessione_start, [dbo].sessione.stop AS sessione_stop, didprog.idsessione,
 [dbo].titolokind.title AS titolokind_title, didprog.idtitolokind AS didprog_idtitolokind,CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth, didprog.modaccesso AS didprog_modaccesso, didprog.modaccesso_en AS didprog_modaccesso_en, didprog.obbformativi AS didprog_obbformativi, didprog.obbformativi_en AS didprog_obbformativi_en,CASE WHEN didprog.preimmatoltreauth = 'S' THEN 'Si' WHEN didprog.preimmatoltreauth = 'N' THEN 'No' END AS didprog_preimmatoltreauth, didprog.progesamamm AS didprog_progesamamm, didprog.prospoccupaz AS didprog_prospoccupaz, didprog.provafinaledesc AS didprog_provafinaledesc, didprog.regolamentotax AS didprog_regolamentotax, didprog.regolamentotaxurl AS didprog_regolamentotaxurl, didprog.startiscrizioni AS didprog_startiscrizioni, didprog.stopiscrizioni AS didprog_stopiscrizioni, didprog.title, didprog.title_en AS didprog_title_en, didprog.utenzasost AS didprog_utenzasost, didprog.website AS didprog_website,
 isnull('Denominazione: ' + didprog.title + '; ','') + ' ' + isnull('Anno accademico: ' + didprog.aa + '; ','') as dropdown_title
FROM [dbo].didprog WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON didprog.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprognumchiusokind WITH (NOLOCK) ON didprog.iddidprognumchiusokind = [dbo].didprognumchiusokind.iddidprognumchiusokind
LEFT OUTER JOIN [dbo].graduatoria WITH (NOLOCK) ON didprog.idgraduatoria = [dbo].graduatoria.idgraduatoria
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang WITH (NOLOCK) ON didprog.idnation_lang = geo_nationlang.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlang2 WITH (NOLOCK) ON didprog.idnation_lang2 = geo_nationlang2.idnation
LEFT OUTER JOIN [dbo].geo_nation AS geo_nationlangvis WITH (NOLOCK) ON didprog.idnation_langvis = geo_nationlangvis.idnation
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].sessione WITH (NOLOCK) ON didprog.idsessione = [dbo].sessione.idsessione
LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON sessione.idsessionekind = [dbo].sessionekind.idsessionekind
LEFT OUTER JOIN [dbo].titolokind WITH (NOLOCK) ON didprog.idtitolokind = [dbo].titolokind.idtitolokind
WHERE  didprog.idcorsostudio IS NOT NULL  AND didprog.iddidprog IS NOT NULL 
GO

-- CREAZIONE VISTA corsostudioingressoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudioingressoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudioingressoview]
GO

CREATE VIEW [dbo].[corsostudioingressoview] AS 
SELECT CASE WHEN corsostudio.almalaureasurvey = 'S' THEN 'Si' WHEN corsostudio.almalaureasurvey = 'N' THEN 'No' END AS corsostudio_almalaureasurvey, corsostudio.annoistituz AS corsostudio_annoistituz, corsostudio.basevoto AS corsostudio_basevoto, corsostudio.codice AS corsostudio_codice, corsostudio.codicemiur AS corsostudio_codicemiur, corsostudio.codicemiurlungo AS corsostudio_codicemiurlungo, corsostudio.crediti AS corsostudio_crediti, corsostudio.ct AS corsostudio_ct, corsostudio.cu AS corsostudio_cu, corsostudio.durata AS corsostudio_durata, corsostudio.idcorsostudio, corsostudio.idcorsostudiokind AS corsostudio_idcorsostudiokind, corsostudio.idcorsostudiolivello AS corsostudio_idcorsostudiolivello, corsostudio.idcorsostudionorma AS corsostudio_idcorsostudionorma, corsostudio.idduratakind AS corsostudio_idduratakind,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, corsostudio.idstruttura, corsostudio.lt AS corsostudio_lt, corsostudio.lu AS corsostudio_lu, corsostudio.obbform AS corsostudio_obbform, corsostudio.sboccocc AS corsostudio_sboccocc, corsostudio.title, corsostudio.title_en AS corsostudio_title_en,(select top 1 aa 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_aa,
						(select top 1 iddidprognumchiusokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_iddidprognumchiusokind,
						(select top 1 iddidprogsuddannokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_iddidprogsuddannokind,
						(select top 1 idgraduatoria 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idgraduatoria,
						(select top 1 idnation_lang 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_lang,
						(select top 1 idnation_lang2 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_lang2,
						(select top 1 idnation_langvis 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_langvis,
						(select top 1 idsede 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idsede,
						(select top 1 idsessione 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idsessione,
						(select top 1 idtitolokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_idtitolokind,
						(select top 1 CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_immatoltreauth,
						(select top 1 modaccesso 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_modaccesso,
						(select top 1 modaccesso_en 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_modaccesso_en,
						(select top 1 CASE WHEN didprog.preimmatoltreauth = 'S' THEN 'Si' WHEN didprog.preimmatoltreauth = 'N' THEN 'No' END AS didprog_preimmatoltreauth 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_preimmatoltreauth,
						(select top 1 progesamamm 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_progesamamm,
						(select top 1 provafinaledesc 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_provafinaledesc,
						(select top 1 regolamentotax 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_regolamentotax,
						(select top 1 regolamentotaxurl 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_regolamentotaxurl,
						(select top 1 startiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_startiscrizioni,
						(select top 1 stopiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_stopiscrizioni,
						(select top 1 title 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title,
						(select top 1 title_en 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title_en,
						(select top 1 utenzasost 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_utenzasost,
						(select top 1 website 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_website,
 isnull('Denominazione: ' + corsostudio.title + '; ','') as dropdown_title
FROM [dbo].corsostudio WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON corsostudio.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  corsostudio.idcorsostudio IS NOT NULL  AND corsostudio.idcorsostudiokind = 12
GO


-- CREAZIONE VISTA perfstrutturaperfindicatoredefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfstrutturaperfindicatoredefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfstrutturaperfindicatoredefaultview]
GO
-- CREAZIONE VISTA registryistitutiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryistitutiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryistitutiview]
GO

CREATE VIEW [dbo].[registryistitutiview] AS 
SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'S' THEN 'Si' WHEN registry.gender = 'N' THEN 'No' END AS registry_gender, registry.idaccmotivecredit AS registry_idaccmotivecredit, registry.idaccmotivedebit AS registry_idaccmotivedebit, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory,
 [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, registry.idmaritalstatus AS registry_idmaritalstatus, registry.idnation AS registry_idnation, registry.idreg, registry.idregistryclass AS registry_idregistryclass, registry.idregistrykind AS registry_idregistrykind, registry.idtitle AS registry_idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, registry.residence AS registry_residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_istituti.codicemiur AS registry_istituti_codicemiur, registry_istituti.codiceustat AS registry_istituti_codiceustat, registry_istituti.comune AS registry_istituti_comune, registry_istituti.ct AS registry_istituti_ct, registry_istituti.cu AS registry_istituti_cu,
 [dbo].istitutokind.tipoistituto AS istitutokind_tipoistituto, registry_istituti.idistitutokind AS registry_istituti_idistitutokind, registry_istituti.idistitutoustat AS registry_istituti_idistitutoustat, registry_istituti.idreg AS registry_istituti_idreg, registry_istituti.lt AS registry_istituti_lt, registry_istituti.lu AS registry_istituti_lu, registry_istituti.nome AS registry_istituti_nome, registry_istituti.sortcode AS registry_istituti_sortcode, registry_istituti.title AS registry_istituti_title, registry_istituti.title_en AS registry_istituti_title_en,
 isnull('Denominazione: ' + registry.title + '; ','') as dropdown_title
FROM [dbo].registry WITH (NOLOCK) 
INNER JOIN registry_istituti WITH (NOLOCK) ON registry.idreg = registry_istituti.idreg
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].istitutokind WITH (NOLOCK) ON registry_istituti.idistitutokind = [dbo].istitutokind.idistitutokind
WHERE  registry.idreg IS NOT NULL  AND registry_istituti.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA registryistituti_princview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryistituti_princview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryistituti_princview]
GO

CREATE VIEW [dbo].[registryistituti_princview] AS 
SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'S' THEN 'Si' WHEN registry.gender = 'N' THEN 'No' END AS registry_gender,
 [dbo].accmotive.codemotive AS accmotive_codemotive, [dbo].accmotive.title AS accmotive_title, registry.idaccmotivecredit,
 accmotive_registry.codemotive AS accmotive_registry_codemotive, accmotive_registry.title AS accmotive_registry_title, registry.idaccmotivedebit,
 [dbo].category.description AS category_description, registry.idcategory,
 [dbo].centralizedcategory.description AS centralizedcategory_description, registry.idcentralizedcategory,
 [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal,
 [dbo].maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus,
 [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg,
 [dbo].registryclass.description AS registryclass_description, registry.idregistryclass,
 [dbo].registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind,
 [dbo].title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe,
 [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_istituti.codicemiur AS registry_istituti_codicemiur, registry_istituti.codiceustat AS registry_istituti_codiceustat, registry_istituti.comune AS registry_istituti_comune, registry_istituti.ct AS registry_istituti_ct, registry_istituti.cu AS registry_istituti_cu,
 [dbo].istitutokind.tipoistituto AS istitutokind_tipoistituto, registry_istituti.idistitutokind AS registry_istituti_idistitutokind, registry_istituti.idistitutoustat AS registry_istituti_idistitutoustat, registry_istituti.idreg AS registry_istituti_idreg, registry_istituti.lt AS registry_istituti_lt, registry_istituti.lu AS registry_istituti_lu, registry_istituti.nome AS registry_istituti_nome, registry_istituti.sortcode AS registry_istituti_sortcode, registry_istituti.title AS registry_istituti_title, registry_istituti.title_en AS registry_istituti_title_en,(select top 1 acronimo 
						from dbo.istitutoprinc 
						where dbo.istitutoprinc.idreg = registry_istituti.idreg
						 order by istitutoprinc.idreg desc) as istitutoprinc_acronimo,
 isnull('Denominazione: ' + registry.title + '; ','') as dropdown_title
FROM [dbo].registry WITH (NOLOCK) 
INNER JOIN registry_istituti WITH (NOLOCK) ON registry.idreg = registry_istituti.idreg
LEFT OUTER JOIN [dbo].accmotive WITH (NOLOCK) ON registry.idaccmotivecredit = [dbo].accmotive.idaccmotive
LEFT OUTER JOIN [dbo].accmotive AS accmotive_registry WITH (NOLOCK) ON registry.idaccmotivedebit = accmotive_registry.idaccmotive
LEFT OUTER JOIN [dbo].category WITH (NOLOCK) ON registry.idcategory = [dbo].category.idcategory
LEFT OUTER JOIN [dbo].centralizedcategory WITH (NOLOCK) ON registry.idcentralizedcategory = [dbo].centralizedcategory.idcentralizedcategory
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = [dbo].maritalstatus.idmaritalstatus
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation
LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass
LEFT OUTER JOIN [dbo].registrykind WITH (NOLOCK) ON registry.idregistrykind = [dbo].registrykind.idregistrykind
LEFT OUTER JOIN [dbo].title WITH (NOLOCK) ON registry.idtitle = [dbo].title.idtitle
LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence
LEFT OUTER JOIN [dbo].istitutokind WITH (NOLOCK) ON registry_istituti.idistitutokind = [dbo].istitutokind.idistitutokind
WHERE  registry.idreg IS NOT NULL  AND registry_istituti.idreg IS NOT NULL 
GO

-- CREAZIONE VISTA registryaziende_roview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryaziende_roview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryaziende_roview]
GO

CREATE VIEW [dbo].[registryaziende_roview] AS 
SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'S' THEN 'Si' WHEN registry.gender = 'N' THEN 'No' END AS registry_gender, registry.idaccmotivecredit AS registry_idaccmotivecredit, registry.idaccmotivedebit AS registry_idaccmotivedebit,
 [dbo].category.description AS category_description, registry.idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory,
 [dbo].geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, registry.idmaritalstatus AS registry_idmaritalstatus,
 [dbo].geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg,
 [dbo].registryclass.description AS registryclass_description, registry.idregistryclass,
 [dbo].registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind, registry.idtitle AS registry_idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe,
 [dbo].residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_aziende.ct AS registry_aziende_ct, registry_aziende.cu AS registry_aziende_cu,
 [dbo].ateco.codice AS ateco_codice, [dbo].ateco.title AS ateco_title, registry_aziende.idateco,
 [dbo].nace.idnace AS nace_idnace, [dbo].nace.activity AS nace_activity, registry_aziende.idnace,
 [dbo].naturagiur.title AS naturagiur_title, registry_aziende.idnaturagiur,
 [dbo].numerodip.title AS numerodip_title, registry_aziende.idnumerodip, registry_aziende.idreg AS registry_aziende_idreg, registry_aziende.lt AS registry_aziende_lt, registry_aziende.lu AS registry_aziende_lu, registry_aziende.pic AS registry_aziende_pic, registry_aziende.title_en AS registry_aziende_title_en, registry_aziende.txt_en AS registry_aziende_txt_en,
 isnull('Denominazione: ' + registry.title + '; ','') as dropdown_title
FROM [dbo].registry WITH (NOLOCK) 
INNER JOIN registry_aziende WITH (NOLOCK) ON registry.idreg = registry_aziende.idreg
LEFT OUTER JOIN [dbo].category WITH (NOLOCK) ON registry.idcategory = [dbo].category.idcategory
LEFT OUTER JOIN [dbo].geo_city WITH (NOLOCK) ON registry.idcity = [dbo].geo_city.idcity
LEFT OUTER JOIN [dbo].geo_nation WITH (NOLOCK) ON registry.idnation = [dbo].geo_nation.idnation
LEFT OUTER JOIN [dbo].registryclass WITH (NOLOCK) ON registry.idregistryclass = [dbo].registryclass.idregistryclass
LEFT OUTER JOIN [dbo].registrykind WITH (NOLOCK) ON registry.idregistrykind = [dbo].registrykind.idregistrykind
LEFT OUTER JOIN [dbo].residence WITH (NOLOCK) ON registry.residence = [dbo].residence.idresidence
LEFT OUTER JOIN [dbo].ateco WITH (NOLOCK) ON registry_aziende.idateco = [dbo].ateco.idateco
LEFT OUTER JOIN [dbo].nace WITH (NOLOCK) ON registry_aziende.idnace = [dbo].nace.idnace
LEFT OUTER JOIN [dbo].naturagiur WITH (NOLOCK) ON registry_aziende.idnaturagiur = [dbo].naturagiur.idnaturagiur
LEFT OUTER JOIN [dbo].numerodip WITH (NOLOCK) ON registry_aziende.idnumerodip = [dbo].numerodip.idnumerodip
WHERE  registry.idreg IS NOT NULL  AND registry_aziende.idreg IS NOT NULL 
GO

