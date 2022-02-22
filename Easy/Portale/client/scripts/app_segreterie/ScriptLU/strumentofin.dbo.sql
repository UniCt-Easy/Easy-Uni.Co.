
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


-- CREAZIONE TABELLA strumentofin --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strumentofin]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[strumentofin] (
idstrumentofin int NOT NULL,
active char(1) NULL,
description varchar(max) NULL,
sortcode int NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkstrumentofin PRIMARY KEY (idstrumentofin
)
)
END
GO

-- VERIFICA STRUTTURA strumentofin --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strumentofin' and C.name = 'idstrumentofin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strumentofin] ADD idstrumentofin int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('strumentofin') and col.name = 'idstrumentofin' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [strumentofin] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strumentofin' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strumentofin] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [strumentofin] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strumentofin' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strumentofin] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [strumentofin] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strumentofin' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strumentofin] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [strumentofin] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'strumentofin' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [strumentofin] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [strumentofin] ALTER COLUMN title varchar(2048) NULL
GO


-- GENERAZIONE DATI PER strumentofin --
IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '1')
UPDATE [strumentofin] SET active = 'S',description = 'ERC ADVANCED GRANT',sortcode = '1',title = 'ERC-ADG' WHERE idstrumentofin = '1'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('1','S','ERC ADVANCED GRANT','1','ERC-ADG')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '2')
UPDATE [strumentofin] SET active = 'S',description = 'ERC CONSOLIDATOR GRANTS',sortcode = '2',title = 'ERC-COG' WHERE idstrumentofin = '2'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('2','S','ERC CONSOLIDATOR GRANTS','2','ERC-COG')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '3')
UPDATE [strumentofin] SET active = 'S',description = 'Bio-Based Industries - Innovation Action - Demonstration',sortcode = '3',title = 'BBI-IA-DEMO' WHERE idstrumentofin = '3'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('3','S','Bio-Based Industries - Innovation Action - Demonstration','3','BBI-IA-DEMO')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '4')
UPDATE [strumentofin] SET active = 'S',description = 'Clean Sky 2 - Innovation action',sortcode = '4',title = 'CS2-IA' WHERE idstrumentofin = '4'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('4','S','Clean Sky 2 - Innovation action','4','CS2-IA')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '5')
UPDATE [strumentofin] SET active = 'S',description = 'Electronics Components and Systems for European Leadership - RESEARCH AND INNOVATION ACTIONS',sortcode = '5',title = 'ECSEL-RIA' WHERE idstrumentofin = '5'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('5','S','Electronics Components and Systems for European Leadership - RESEARCH AND INNOVATION ACTIONS','5','ECSEL-RIA')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '6')
UPDATE [strumentofin] SET active = 'S',description = 'RESEARCH AND INNOVATION ACTIONS',sortcode = '6',title = 'RIA' WHERE idstrumentofin = '6'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('6','S','RESEARCH AND INNOVATION ACTIONS','6','RIA')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '7')
UPDATE [strumentofin] SET active = 'S',description = 'INNOVATION ACTIONS',sortcode = '7',title = 'IA' WHERE idstrumentofin = '7'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('7','S','INNOVATION ACTIONS','7','IA')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '8')
UPDATE [strumentofin] SET active = 'S',description = 'Marie Sklodowska Curie  - Individual Fellowships - Global Fellowships',sortcode = '8',title = 'MSCA-IF-GF' WHERE idstrumentofin = '8'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('8','S','Marie Sklodowska Curie  - Individual Fellowships - Global Fellowships','8','MSCA-IF-GF')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '9')
UPDATE [strumentofin] SET active = 'S',description = 'Marie Sklodowska Curie - Individual Fellowships – Standard European Fellowships',sortcode = '9',title = 'MSCA-IF-EF-ST' WHERE idstrumentofin = '9'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('9','S','Marie Sklodowska Curie - Individual Fellowships – Standard European Fellowships','9','MSCA-IF-EF-ST')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '10')
UPDATE [strumentofin] SET active = 'S',description = 'Marie Sklodowska Curie - Innovative Training Networks - European Industrial Doctorates',sortcode = '10',title = 'MSCA-ITN-EID' WHERE idstrumentofin = '10'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('10','S','Marie Sklodowska Curie - Innovative Training Networks - European Industrial Doctorates','10','MSCA-ITN-EID')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '11')
UPDATE [strumentofin] SET active = 'S',description = 'Marie Sklodowska Curie - Innovative Training Networks - European Training Networks',sortcode = '11',title = 'MSCA-ITN-ETN' WHERE idstrumentofin = '11'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('11','S','Marie Sklodowska Curie - Innovative Training Networks - European Training Networks','11','MSCA-ITN-ETN')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '12')
UPDATE [strumentofin] SET active = 'S',description = 'Marie Sklodowska Curie - Research and Innovation Staff Exchange Evaluations',sortcode = '12',title = 'MSCA-RISE' WHERE idstrumentofin = '12'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('12','S','Marie Sklodowska Curie - Research and Innovation Staff Exchange Evaluations','12','MSCA-RISE')
GO

IF exists(SELECT * FROM [strumentofin] WHERE idstrumentofin = '13')
UPDATE [strumentofin] SET active = 'S',description = 'Coordination and Support Action',sortcode = '13',title = 'CSA' WHERE idstrumentofin = '13'
ELSE
INSERT INTO [strumentofin] (idstrumentofin,active,description,sortcode,title) VALUES ('13','S','Coordination and Support Action','13','CSA')
GO

