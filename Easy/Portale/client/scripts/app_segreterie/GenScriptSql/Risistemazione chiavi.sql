
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


--setuser 'amministrazione'
---------------------------------------------------
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idworkpackage int /*NOT NULL*/ DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN idworkpackage int /*NOT NULL*/
GO

UPDATE rendicontattivitaprogettoora
SET rendicontattivitaprogettoora.idworkpackage = rendicontattivitaprogetto.idworkpackage
FROM rendicontattivitaprogettoora INNER JOIN rendicontattivitaprogetto
ON rendicontattivitaprogettoora.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto


ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN idworkpackage int NOT NULL
GO

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE amministrazione.rendicontattivitaprogettoora
	DROP CONSTRAINT PK_rendicontattivitaprogettoora
GO
ALTER TABLE amministrazione.rendicontattivitaprogettoora ADD CONSTRAINT
	PK_rendicontattivitaprogettoora PRIMARY KEY CLUSTERED 
	(
	idrendicontattivitaprogettoora,
	idrendicontattivitaprogetto,
	idworkpackage
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE amministrazione.rendicontattivitaprogettoora SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

------------------------------------------------ rendicontattivitaprogetto
/* Per evitare potenziali problemi di perdita di dati, si consiglia di esaminare dettagliatamente lo script prima di eseguirlo al di fuori del contesto di Progettazione database.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE amministrazione.rendicontattivitaprogetto
	DROP CONSTRAINT xpkrendicontattivitaprogetto
GO
ALTER TABLE amministrazione.rendicontattivitaprogetto ADD CONSTRAINT
	xpkrendicontattivitaprogetto PRIMARY KEY CLUSTERED 
	(
	idrendicontattivitaprogetto,
	idworkpackage
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE amministrazione.rendicontattivitaprogetto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
-------------------------------------------------------

---------------------------------------------------
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiaryora' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiaryora] ADD idworkpackage int /*NOT NULL*/ DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiaryora') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiaryora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiaryora] ALTER COLUMN idworkpackage int /*NOT NULL*/
GO

UPDATE assetdiaryora
SET assetdiaryora.idworkpackage = assetdiary.idworkpackage
FROM assetdiaryora INNER JOIN assetdiary
ON assetdiaryora.idassetdiary = assetdiary.idassetdiary


ALTER TABLE [assetdiaryora] ALTER COLUMN idworkpackage int NOT NULL
GO

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE amministrazione.assetdiaryora
	DROP CONSTRAINT xpkassetdiaryora
GO
ALTER TABLE amministrazione.assetdiaryora ADD CONSTRAINT
	xpkassetdiaryora PRIMARY KEY CLUSTERED 
	(
	idassetdiaryora,
	idassetdiary,
	idworkpackage
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE amministrazione.assetdiaryora SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
--------------------------------------------------------------------------
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE amministrazione.assetdiary
	DROP CONSTRAINT xpkassetdiary
GO
ALTER TABLE amministrazione.assetdiary ADD CONSTRAINT
	xpkassetdiary PRIMARY KEY CLUSTERED 
	(
	idassetdiary,
	idworkpackage
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE amministrazione.assetdiary SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



