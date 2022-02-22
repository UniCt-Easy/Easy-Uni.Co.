
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


-- CREAZIONE TABELLA nace --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[nace]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[nace] (
idnace nvarchar(50) NOT NULL,
activity nvarchar(max) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpknace PRIMARY KEY (idnace
)
)
END
GO

-- VERIFICA STRUTTURA nace --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nace' and C.name = 'idnace' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nace] ADD idnace nvarchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nace') and col.name = 'idnace' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nace] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nace' and C.name = 'activity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nace] ADD activity nvarchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('nace') and col.name = 'activity' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [nace] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [nace] ALTER COLUMN activity nvarchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nace' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nace] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [nace] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'nace' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [nace] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [nace] ALTER COLUMN lu varchar(64) NULL
GO

-- VERIFICA DI nace IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'nace'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nace','nvarchar(50)','ASSISTENZA','idnace','50','S','nvarchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nace','nvarchar(max)','ASSISTENZA','activity','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nace','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nace','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI nace IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'nace')
UPDATE customobject set isreal = 'S' where objectname = 'nace'
ELSE
INSERT INTO customobject (objectname, isreal) values('nace', 'S')
GO

-- GENERAZIONE DATI PER nace --
IF exists(SELECT * FROM [nace] WHERE idnace = '01')
UPDATE [nace] SET activity = 'Crop and animal production, hunting and related service activities',lt = null,lu = null WHERE idnace = '01'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01','Crop and animal production, hunting and related service activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.1')
UPDATE [nace] SET activity = 'Growing of non-perennial crops',lt = null,lu = null WHERE idnace = '01.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.1','Growing of non-perennial crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.11')
UPDATE [nace] SET activity = 'Growing of cereals (except rice), leguminous crops and oil seeds',lt = null,lu = null WHERE idnace = '01.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.11','Growing of cereals (except rice), leguminous crops and oil seeds',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.11.1')
UPDATE [nace] SET activity = 'Growing of cereals',lt = null,lu = null WHERE idnace = '01.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.11.1','Growing of cereals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.11.2')
UPDATE [nace] SET activity = 'Leguminous crops',lt = null,lu = null WHERE idnace = '01.11.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.11.2','Leguminous crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.12')
UPDATE [nace] SET activity = 'Growing of rice',lt = null,lu = null WHERE idnace = '01.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.12','Growing of rice',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.12.1')
UPDATE [nace] SET activity = 'Growing of rice',lt = null,lu = null WHERE idnace = '01.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.12.1','Growing of rice',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.13')
UPDATE [nace] SET activity = 'Growing of vegetables and melons, roots and tubers',lt = null,lu = null WHERE idnace = '01.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.13','Growing of vegetables and melons, roots and tubers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.13.1')
UPDATE [nace] SET activity = 'Growing potatoes',lt = null,lu = null WHERE idnace = '01.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.13.1','Growing potatoes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.13.2')
UPDATE [nace] SET activity = 'Growing of vegetables and melons',lt = null,lu = null WHERE idnace = '01.13.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.13.2','Growing of vegetables and melons',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.13.3')
UPDATE [nace] SET activity = 'Growing of mushrooms',lt = null,lu = null WHERE idnace = '01.13.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.13.3','Growing of mushrooms',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.13.4')
UPDATE [nace] SET activity = 'Production of vegetable seedlings',lt = null,lu = null WHERE idnace = '01.13.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.13.4','Production of vegetable seedlings',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.14')
UPDATE [nace] SET activity = 'Growing of sugar cane',lt = null,lu = null WHERE idnace = '01.14'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.14','Growing of sugar cane',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.14.1')
UPDATE [nace] SET activity = 'Growing of sugar cane',lt = null,lu = null WHERE idnace = '01.14.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.14.1','Growing of sugar cane',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.15')
UPDATE [nace] SET activity = 'Growing of tobacco',lt = null,lu = null WHERE idnace = '01.15'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.15','Growing of tobacco',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.15.1')
UPDATE [nace] SET activity = 'Growing of tobacco',lt = null,lu = null WHERE idnace = '01.15.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.15.1','Growing of tobacco',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.16')
UPDATE [nace] SET activity = 'Growing of fibre crops',lt = null,lu = null WHERE idnace = '01.16'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.16','Growing of fibre crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.16.1')
UPDATE [nace] SET activity = 'Growing of fibre crops',lt = null,lu = null WHERE idnace = '01.16.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.16.1','Growing of fibre crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.19')
UPDATE [nace] SET activity = 'Growing of other non-perennial crops',lt = null,lu = null WHERE idnace = '01.19'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.19','Growing of other non-perennial crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.19.1')
UPDATE [nace] SET activity = 'Growing of other non- perennial crops',lt = null,lu = null WHERE idnace = '01.19.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.19.1','Growing of other non- perennial crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.2')
UPDATE [nace] SET activity = 'Growing of perennial crops',lt = null,lu = null WHERE idnace = '01.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.2','Growing of perennial crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.21')
UPDATE [nace] SET activity = 'Growing of grapes',lt = null,lu = null WHERE idnace = '01.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.21','Growing of grapes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.21.1')
UPDATE [nace] SET activity = 'Growing of grapes',lt = null,lu = null WHERE idnace = '01.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.21.1','Growing of grapes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.22')
UPDATE [nace] SET activity = 'Growing of tropical and subtropical fruits',lt = null,lu = null WHERE idnace = '01.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.22','Growing of tropical and subtropical fruits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.22.1')
UPDATE [nace] SET activity = 'Growing of tropical and subtropical fruits',lt = null,lu = null WHERE idnace = '01.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.22.1','Growing of tropical and subtropical fruits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.23')
UPDATE [nace] SET activity = 'Growing of citrus fruits',lt = null,lu = null WHERE idnace = '01.23'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.23','Growing of citrus fruits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.23.1')
UPDATE [nace] SET activity = 'Growing of citrus fruits',lt = null,lu = null WHERE idnace = '01.23.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.23.1','Growing of citrus fruits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.24')
UPDATE [nace] SET activity = 'Growing of pome fruits and stone fruits',lt = null,lu = null WHERE idnace = '01.24'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.24','Growing of pome fruits and stone fruits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.24.1')
UPDATE [nace] SET activity = 'Growing of pome fruits and stone fruits',lt = null,lu = null WHERE idnace = '01.24.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.24.1','Growing of pome fruits and stone fruits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.25')
UPDATE [nace] SET activity = 'Growing of other tree and bush fruits and nuts',lt = null,lu = null WHERE idnace = '01.25'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.25','Growing of other tree and bush fruits and nuts',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.25.1')
UPDATE [nace] SET activity = 'Growing of edible nuts (almonds, walnuts, hazelnuts)',lt = null,lu = null WHERE idnace = '01.25.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.25.1','Growing of edible nuts (almonds, walnuts, hazelnuts)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.25.2')
UPDATE [nace] SET activity = 'Growing of carobs',lt = null,lu = null WHERE idnace = '01.25.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.25.2','Growing of carobs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.26')
UPDATE [nace] SET activity = 'Growing of oleaginous fruits',lt = null,lu = null WHERE idnace = '01.26'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.26','Growing of oleaginous fruits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.26.1')
UPDATE [nace] SET activity = 'Growing of oleaginous fruits',lt = null,lu = null WHERE idnace = '01.26.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.26.1','Growing of oleaginous fruits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.27')
UPDATE [nace] SET activity = 'Growing of beverage crops',lt = null,lu = null WHERE idnace = '01.27'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.27','Growing of beverage crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.27.1')
UPDATE [nace] SET activity = 'Growing of beverage crops',lt = null,lu = null WHERE idnace = '01.27.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.27.1','Growing of beverage crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.28')
UPDATE [nace] SET activity = 'Growing of spices, aromatic, drug and pharmaceutical crops',lt = null,lu = null WHERE idnace = '01.28'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.28','Growing of spices, aromatic, drug and pharmaceutical crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.28.1')
UPDATE [nace] SET activity = 'Growing of spices, aromatic, drug and pharmaceutical crops',lt = null,lu = null WHERE idnace = '01.28.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.28.1','Growing of spices, aromatic, drug and pharmaceutical crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.29')
UPDATE [nace] SET activity = 'Growing of other perennial crops',lt = null,lu = null WHERE idnace = '01.29'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.29','Growing of other perennial crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.29.1')
UPDATE [nace] SET activity = 'Growing of other perennial crops',lt = null,lu = null WHERE idnace = '01.29.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.29.1','Growing of other perennial crops',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.3')
UPDATE [nace] SET activity = 'Plant propagation',lt = null,lu = null WHERE idnace = '01.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.3','Plant propagation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.30')
UPDATE [nace] SET activity = 'Plant propagation',lt = null,lu = null WHERE idnace = '01.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.30','Plant propagation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.30.1')
UPDATE [nace] SET activity = 'Tree plant nurseries (incl. plants for ornamental purposes)',lt = null,lu = null WHERE idnace = '01.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.30.1','Tree plant nurseries (incl. plants for ornamental purposes)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.4')
UPDATE [nace] SET activity = 'Animal production',lt = null,lu = null WHERE idnace = '01.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.4','Animal production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.41')
UPDATE [nace] SET activity = 'Raising of dairy cattle',lt = null,lu = null WHERE idnace = '01.41'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.41','Raising of dairy cattle',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.41.1')
UPDATE [nace] SET activity = 'Raising of dairy cattle',lt = null,lu = null WHERE idnace = '01.41.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.41.1','Raising of dairy cattle',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.42')
UPDATE [nace] SET activity = 'Raising of other cattle and buffaloes',lt = null,lu = null WHERE idnace = '01.42'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.42','Raising of other cattle and buffaloes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.42.1')
UPDATE [nace] SET activity = 'Raising of other cattle and buffaloes',lt = null,lu = null WHERE idnace = '01.42.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.42.1','Raising of other cattle and buffaloes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.43')
UPDATE [nace] SET activity = 'Raising of horses and other equines',lt = null,lu = null WHERE idnace = '01.43'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.43','Raising of horses and other equines',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.43.1')
UPDATE [nace] SET activity = 'Raising of horses and other equines',lt = null,lu = null WHERE idnace = '01.43.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.43.1','Raising of horses and other equines',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.44')
UPDATE [nace] SET activity = 'Raising of camels and camelids',lt = null,lu = null WHERE idnace = '01.44'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.44','Raising of camels and camelids',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.44.1')
UPDATE [nace] SET activity = 'Raising of camels and camelids',lt = null,lu = null WHERE idnace = '01.44.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.44.1','Raising of camels and camelids',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.45')
UPDATE [nace] SET activity = 'Raising of sheep and goats',lt = null,lu = null WHERE idnace = '01.45'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.45','Raising of sheep and goats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.45.1')
UPDATE [nace] SET activity = 'Raising of sheep and goats',lt = null,lu = null WHERE idnace = '01.45.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.45.1','Raising of sheep and goats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.46')
UPDATE [nace] SET activity = 'Raising of swine/pigs',lt = null,lu = null WHERE idnace = '01.46'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.46','Raising of swine/pigs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.46.1')
UPDATE [nace] SET activity = 'Raising of swine / pigs',lt = null,lu = null WHERE idnace = '01.46.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.46.1','Raising of swine / pigs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.47')
UPDATE [nace] SET activity = 'Raising of poultry',lt = null,lu = null WHERE idnace = '01.47'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.47','Raising of poultry',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.47.1')
UPDATE [nace] SET activity = 'Raising of poultry',lt = null,lu = null WHERE idnace = '01.47.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.47.1','Raising of poultry',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.49')
UPDATE [nace] SET activity = 'Raising of other animals',lt = null,lu = null WHERE idnace = '01.49'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.49','Raising of other animals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.49.1')
UPDATE [nace] SET activity = 'Raising of quails',lt = null,lu = null WHERE idnace = '01.49.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.49.1','Raising of quails',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.49.2')
UPDATE [nace] SET activity = 'Raising of rabbits',lt = null,lu = null WHERE idnace = '01.49.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.49.2','Raising of rabbits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.49.3')
UPDATE [nace] SET activity = 'Raising of pigeons',lt = null,lu = null WHERE idnace = '01.49.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.49.3','Raising of pigeons',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.49.4')
UPDATE [nace] SET activity = 'Bee- keeping',lt = null,lu = null WHERE idnace = '01.49.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.49.4','Bee- keeping',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.49.5')
UPDATE [nace] SET activity = 'Breeding of dogs',lt = null,lu = null WHERE idnace = '01.49.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.49.5','Breeding of dogs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.49.9')
UPDATE [nace] SET activity = 'Farming of other animals (incl. game propagation, farming of ostriches, etc.)',lt = null,lu = null WHERE idnace = '01.49.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.49.9','Farming of other animals (incl. game propagation, farming of ostriches, etc.)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.5')
UPDATE [nace] SET activity = 'Mixed farming',lt = null,lu = null WHERE idnace = '01.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.5','Mixed farming',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.50')
UPDATE [nace] SET activity = 'Mixed farming',lt = null,lu = null WHERE idnace = '01.50'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.50','Mixed farming',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.50.1')
UPDATE [nace] SET activity = 'Mixed farming (growing of crops combined with farming of animals)',lt = null,lu = null WHERE idnace = '01.50.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.50.1','Mixed farming (growing of crops combined with farming of animals)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.6')
UPDATE [nace] SET activity = 'Support activities to agriculture and post-harvest crop activities',lt = null,lu = null WHERE idnace = '01.6'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.6','Support activities to agriculture and post-harvest crop activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.61')
UPDATE [nace] SET activity = 'Support activities for crop production',lt = null,lu = null WHERE idnace = '01.61'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.61','Support activities for crop production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.61.1')
UPDATE [nace] SET activity = 'Support activities for crop production',lt = null,lu = null WHERE idnace = '01.61.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.61.1','Support activities for crop production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.61.2')
UPDATE [nace] SET activity = 'Picking of fruit and vegetables on a fee or contract basis',lt = null,lu = null WHERE idnace = '01.61.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.61.2','Picking of fruit and vegetables on a fee or contract basis',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.62')
UPDATE [nace] SET activity = 'Support activities for animal production',lt = null,lu = null WHERE idnace = '01.62'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.62','Support activities for animal production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.62.1')
UPDATE [nace] SET activity = 'Support activities for animal production',lt = null,lu = null WHERE idnace = '01.62.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.62.1','Support activities for animal production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.63')
UPDATE [nace] SET activity = 'Post-harvest crop activities',lt = null,lu = null WHERE idnace = '01.63'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.63','Post-harvest crop activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.63.1')
UPDATE [nace] SET activity = 'Post- harvest crop activities',lt = null,lu = null WHERE idnace = '01.63.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.63.1','Post- harvest crop activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.64')
UPDATE [nace] SET activity = 'Seed processing for propagation',lt = null,lu = null WHERE idnace = '01.64'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.64','Seed processing for propagation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.64.1')
UPDATE [nace] SET activity = 'Seed processing for propagation',lt = null,lu = null WHERE idnace = '01.64.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.64.1','Seed processing for propagation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.7')
UPDATE [nace] SET activity = 'Hunting, trapping and related service activities',lt = null,lu = null WHERE idnace = '01.7'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.7','Hunting, trapping and related service activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.70')
UPDATE [nace] SET activity = 'Hunting, trapping and related service activities',lt = null,lu = null WHERE idnace = '01.70'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.70','Hunting, trapping and related service activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '01.70.1')
UPDATE [nace] SET activity = 'Hunting, trapping and related service activities (on commercial basis)',lt = null,lu = null WHERE idnace = '01.70.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('01.70.1','Hunting, trapping and related service activities (on commercial basis)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02')
UPDATE [nace] SET activity = 'Forestry and logging',lt = null,lu = null WHERE idnace = '02'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02','Forestry and logging',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.1')
UPDATE [nace] SET activity = 'Silviculture and other forestry activities',lt = null,lu = null WHERE idnace = '02.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.1','Silviculture and other forestry activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.10')
UPDATE [nace] SET activity = 'Silviculture and other forestry activities',lt = null,lu = null WHERE idnace = '02.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.10','Silviculture and other forestry activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.10.1')
UPDATE [nace] SET activity = 'Silviculture and other forestry activities',lt = null,lu = null WHERE idnace = '02.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.10.1','Silviculture and other forestry activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.2')
UPDATE [nace] SET activity = 'Logging',lt = null,lu = null WHERE idnace = '02.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.2','Logging',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.20')
UPDATE [nace] SET activity = 'Logging',lt = null,lu = null WHERE idnace = '02.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.20','Logging',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.20.1')
UPDATE [nace] SET activity = 'Logging',lt = null,lu = null WHERE idnace = '02.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.20.1','Logging',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.20.2')
UPDATE [nace] SET activity = 'Production of charcoal by means of traditional methods',lt = null,lu = null WHERE idnace = '02.20.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.20.2','Production of charcoal by means of traditional methods',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.3')
UPDATE [nace] SET activity = 'Gathering of wild growing non-wood products',lt = null,lu = null WHERE idnace = '02.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.3','Gathering of wild growing non-wood products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.30')
UPDATE [nace] SET activity = 'Gathering of wild growing non-wood products',lt = null,lu = null WHERE idnace = '02.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.30','Gathering of wild growing non-wood products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.30.1')
UPDATE [nace] SET activity = 'Gathering of wild growing non- wood products',lt = null,lu = null WHERE idnace = '02.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.30.1','Gathering of wild growing non- wood products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.4')
UPDATE [nace] SET activity = 'Support services to forestry',lt = null,lu = null WHERE idnace = '02.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.4','Support services to forestry',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.40')
UPDATE [nace] SET activity = 'Support services to forestry',lt = null,lu = null WHERE idnace = '02.40'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.40','Support services to forestry',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '02.40.1')
UPDATE [nace] SET activity = 'Support services to forestry',lt = null,lu = null WHERE idnace = '02.40.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('02.40.1','Support services to forestry',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03')
UPDATE [nace] SET activity = 'Fishing and aquaculture',lt = null,lu = null WHERE idnace = '03'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03','Fishing and aquaculture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.1')
UPDATE [nace] SET activity = 'Fishing',lt = null,lu = null WHERE idnace = '03.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.1','Fishing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.11')
UPDATE [nace] SET activity = 'Marine fishing',lt = null,lu = null WHERE idnace = '03.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.11','Marine fishing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.11.1')
UPDATE [nace] SET activity = 'Marine fishing',lt = null,lu = null WHERE idnace = '03.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.11.1','Marine fishing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.12')
UPDATE [nace] SET activity = 'Freshwater fishing',lt = null,lu = null WHERE idnace = '03.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.12','Freshwater fishing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.12.1')
UPDATE [nace] SET activity = 'Freshwater fishing',lt = null,lu = null WHERE idnace = '03.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.12.1','Freshwater fishing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.2')
UPDATE [nace] SET activity = 'Aquaculture',lt = null,lu = null WHERE idnace = '03.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.2','Aquaculture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.21')
UPDATE [nace] SET activity = 'Marine aquaculture',lt = null,lu = null WHERE idnace = '03.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.21','Marine aquaculture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.21.1')
UPDATE [nace] SET activity = 'Marine aquaculture',lt = null,lu = null WHERE idnace = '03.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.21.1','Marine aquaculture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.22')
UPDATE [nace] SET activity = 'Freshwater aquaculture',lt = null,lu = null WHERE idnace = '03.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.22','Freshwater aquaculture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '03.22.1')
UPDATE [nace] SET activity = 'Freshwater aquaculture',lt = null,lu = null WHERE idnace = '03.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('03.22.1','Freshwater aquaculture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '05')
UPDATE [nace] SET activity = 'Mining of coal and lignite',lt = null,lu = null WHERE idnace = '05'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('05','Mining of coal and lignite',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '05.1')
UPDATE [nace] SET activity = 'Mining of hard coal',lt = null,lu = null WHERE idnace = '05.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('05.1','Mining of hard coal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '05.10')
UPDATE [nace] SET activity = 'Mining of hard coal',lt = null,lu = null WHERE idnace = '05.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('05.10','Mining of hard coal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '05.10.1')
UPDATE [nace] SET activity = 'Mining of hard coal',lt = null,lu = null WHERE idnace = '05.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('05.10.1','Mining of hard coal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '05.2')
UPDATE [nace] SET activity = 'Mining of lignite',lt = null,lu = null WHERE idnace = '05.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('05.2','Mining of lignite',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '05.20')
UPDATE [nace] SET activity = 'Mining of lignite',lt = null,lu = null WHERE idnace = '05.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('05.20','Mining of lignite',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '05.20.1')
UPDATE [nace] SET activity = 'Mining of lignite',lt = null,lu = null WHERE idnace = '05.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('05.20.1','Mining of lignite',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '06')
UPDATE [nace] SET activity = 'Extraction of crude petroleum and natural gas',lt = null,lu = null WHERE idnace = '06'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('06','Extraction of crude petroleum and natural gas',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '06.1')
UPDATE [nace] SET activity = 'Extraction of crude petroleum',lt = null,lu = null WHERE idnace = '06.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('06.1','Extraction of crude petroleum',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '06.10')
UPDATE [nace] SET activity = 'Extraction of crude petroleum',lt = null,lu = null WHERE idnace = '06.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('06.10','Extraction of crude petroleum',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '06.10.1')
UPDATE [nace] SET activity = 'Extraction of crude petroleum',lt = null,lu = null WHERE idnace = '06.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('06.10.1','Extraction of crude petroleum',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '06.2')
UPDATE [nace] SET activity = 'Extraction of natural gas',lt = null,lu = null WHERE idnace = '06.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('06.2','Extraction of natural gas',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '06.20')
UPDATE [nace] SET activity = 'Extraction of natural gas',lt = null,lu = null WHERE idnace = '06.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('06.20','Extraction of natural gas',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '06.20.1')
UPDATE [nace] SET activity = 'Extraction of natural gas',lt = null,lu = null WHERE idnace = '06.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('06.20.1','Extraction of natural gas',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '07')
UPDATE [nace] SET activity = 'Mining of metal ores',lt = null,lu = null WHERE idnace = '07'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('07','Mining of metal ores',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '07.1')
UPDATE [nace] SET activity = 'Mining of iron ores',lt = null,lu = null WHERE idnace = '07.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('07.1','Mining of iron ores',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '07.10')
UPDATE [nace] SET activity = 'Mining of iron ores',lt = null,lu = null WHERE idnace = '07.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('07.10','Mining of iron ores',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '07.10.1')
UPDATE [nace] SET activity = 'Mining of iron ores',lt = null,lu = null WHERE idnace = '07.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('07.10.1','Mining of iron ores',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '07.2')
UPDATE [nace] SET activity = 'Mining of non-ferrous metal ores',lt = null,lu = null WHERE idnace = '07.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('07.2','Mining of non-ferrous metal ores',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '07.21')
UPDATE [nace] SET activity = 'Mining of uranium and thorium ores',lt = null,lu = null WHERE idnace = '07.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('07.21','Mining of uranium and thorium ores',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '07.21.1')
UPDATE [nace] SET activity = 'Mining of uranium and thorium ores',lt = null,lu = null WHERE idnace = '07.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('07.21.1','Mining of uranium and thorium ores',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '07.29')
UPDATE [nace] SET activity = 'Mining of other non-ferrous metal ores',lt = null,lu = null WHERE idnace = '07.29'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('07.29','Mining of other non-ferrous metal ores',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '07.29.1')
UPDATE [nace] SET activity = 'Mining of other non-ferrous metal ores',lt = null,lu = null WHERE idnace = '07.29.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('07.29.1','Mining of other non-ferrous metal ores',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08')
UPDATE [nace] SET activity = 'Other mining and quarrying',lt = null,lu = null WHERE idnace = '08'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08','Other mining and quarrying',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.1')
UPDATE [nace] SET activity = 'Quarrying of stone, sand and clay',lt = null,lu = null WHERE idnace = '08.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.1','Quarrying of stone, sand and clay',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.11')
UPDATE [nace] SET activity = 'Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate',lt = null,lu = null WHERE idnace = '08.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.11','Quarrying of ornamental and building stone, limestone, gypsum, chalk and slate',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.11.1')
UPDATE [nace] SET activity = 'Quarrying of ornamental and building stone',lt = null,lu = null WHERE idnace = '08.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.11.1','Quarrying of ornamental and building stone',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.11.2')
UPDATE [nace] SET activity = 'Quarrying of marble',lt = null,lu = null WHERE idnace = '08.11.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.11.2','Quarrying of marble',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.11.3')
UPDATE [nace] SET activity = 'Quarrying of havara',lt = null,lu = null WHERE idnace = '08.11.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.11.3','Quarrying of havara',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.11.4')
UPDATE [nace] SET activity = 'Quarrying of limestone and gypsum (gypsum raw)',lt = null,lu = null WHERE idnace = '08.11.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.11.4','Quarrying of limestone and gypsum (gypsum raw)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.11.5')
UPDATE [nace] SET activity = 'Quarrying of chalk and dolomite',lt = null,lu = null WHERE idnace = '08.11.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.11.5','Quarrying of chalk and dolomite',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.11.6')
UPDATE [nace] SET activity = 'Quarrying of slate',lt = null,lu = null WHERE idnace = '08.11.6'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.11.6','Quarrying of slate',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.12')
UPDATE [nace] SET activity = 'Operation of gravel and sand pits; mining of clays and kaolin',lt = null,lu = null WHERE idnace = '08.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.12','Operation of gravel and sand pits; mining of clays and kaolin',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.12.1')
UPDATE [nace] SET activity = 'Extraction, breaking and crushing of stone, gravel and sand',lt = null,lu = null WHERE idnace = '08.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.12.1','Extraction, breaking and crushing of stone, gravel and sand',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.12.2')
UPDATE [nace] SET activity = 'Mining of clays',lt = null,lu = null WHERE idnace = '08.12.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.12.2','Mining of clays',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.12.3')
UPDATE [nace] SET activity = 'Mining of bentonite and kaolin',lt = null,lu = null WHERE idnace = '08.12.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.12.3','Mining of bentonite and kaolin',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.9')
UPDATE [nace] SET activity = 'Mining and quarrying n.e.c.',lt = null,lu = null WHERE idnace = '08.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.9','Mining and quarrying n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.91')
UPDATE [nace] SET activity = 'Mining of chemical and fertilizer minerals',lt = null,lu = null WHERE idnace = '08.91'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.91','Mining of chemical and fertilizer minerals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.91.1')
UPDATE [nace] SET activity = 'Extraction of iron pyrites',lt = null,lu = null WHERE idnace = '08.91.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.91.1','Extraction of iron pyrites',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.91.2')
UPDATE [nace] SET activity = 'Mining of umber and other ochres',lt = null,lu = null WHERE idnace = '08.91.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.91.2','Mining of umber and other ochres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.92')
UPDATE [nace] SET activity = 'Extraction of peat',lt = null,lu = null WHERE idnace = '08.92'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.92','Extraction of peat',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.92.1')
UPDATE [nace] SET activity = 'Extraction of peat',lt = null,lu = null WHERE idnace = '08.92.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.92.1','Extraction of peat',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.93')
UPDATE [nace] SET activity = 'Extraction of salt',lt = null,lu = null WHERE idnace = '08.93'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.93','Extraction of salt',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.93.1')
UPDATE [nace] SET activity = 'Extraction of salt',lt = null,lu = null WHERE idnace = '08.93.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.93.1','Extraction of salt',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.99')
UPDATE [nace] SET activity = 'Other mining and quarrying n.e.c.',lt = null,lu = null WHERE idnace = '08.99'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.99','Other mining and quarrying n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.99.1')
UPDATE [nace] SET activity = 'Mining of asbestos',lt = null,lu = null WHERE idnace = '08.99.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.99.1','Mining of asbestos',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '08.99.9')
UPDATE [nace] SET activity = 'Other mining and quarrying n.e.c.',lt = null,lu = null WHERE idnace = '08.99.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('08.99.9','Other mining and quarrying n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '09')
UPDATE [nace] SET activity = 'Mining support service activities',lt = null,lu = null WHERE idnace = '09'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('09','Mining support service activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '09.1')
UPDATE [nace] SET activity = 'Support activities for petroleum and natural gas extraction',lt = null,lu = null WHERE idnace = '09.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('09.1','Support activities for petroleum and natural gas extraction',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '09.10')
UPDATE [nace] SET activity = 'Support activities for petroleum and natural gas extraction',lt = null,lu = null WHERE idnace = '09.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('09.10','Support activities for petroleum and natural gas extraction',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '09.10.1')
UPDATE [nace] SET activity = 'Support activities for petroleum and natural gas extraction',lt = null,lu = null WHERE idnace = '09.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('09.10.1','Support activities for petroleum and natural gas extraction',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '09.9')
UPDATE [nace] SET activity = 'Support activities for other mining and quarrying',lt = null,lu = null WHERE idnace = '09.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('09.9','Support activities for other mining and quarrying',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '09.90')
UPDATE [nace] SET activity = 'Support activities for other mining and quarrying',lt = null,lu = null WHERE idnace = '09.90'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('09.90','Support activities for other mining and quarrying',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '09.90.1')
UPDATE [nace] SET activity = 'Support activities for other mining and quarrying',lt = null,lu = null WHERE idnace = '09.90.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('09.90.1','Support activities for other mining and quarrying',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10')
UPDATE [nace] SET activity = 'Manufacture of food products',lt = null,lu = null WHERE idnace = '10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10','Manufacture of food products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.1')
UPDATE [nace] SET activity = 'Processing and preserving of meat and production of meat products',lt = null,lu = null WHERE idnace = '10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.1','Processing and preserving of meat and production of meat products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.11')
UPDATE [nace] SET activity = 'Processing and preserving of meat',lt = null,lu = null WHERE idnace = '10.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.11','Processing and preserving of meat',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.11.1')
UPDATE [nace] SET activity = 'Production of fresh, chilled or frozen meat',lt = null,lu = null WHERE idnace = '10.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.11.1','Production of fresh, chilled or frozen meat',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.11.2')
UPDATE [nace] SET activity = 'Production and drying of hides, skins and pulled wool',lt = null,lu = null WHERE idnace = '10.11.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.11.2','Production and drying of hides, skins and pulled wool',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.12')
UPDATE [nace] SET activity = 'Processing and preserving of poultry meat',lt = null,lu = null WHERE idnace = '10.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.12','Processing and preserving of poultry meat',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.12.1')
UPDATE [nace] SET activity = 'Production and preserving of poultry meat',lt = null,lu = null WHERE idnace = '10.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.12.1','Production and preserving of poultry meat',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.13')
UPDATE [nace] SET activity = 'Production of meat and poultry meat products',lt = null,lu = null WHERE idnace = '10.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.13','Production of meat and poultry meat products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.13.1')
UPDATE [nace] SET activity = 'Production of meat and poultry meat products',lt = null,lu = null WHERE idnace = '10.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.13.1','Production of meat and poultry meat products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.2')
UPDATE [nace] SET activity = 'Processing and preserving of fish, crustaceans and molluscs',lt = null,lu = null WHERE idnace = '10.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.2','Processing and preserving of fish, crustaceans and molluscs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.20')
UPDATE [nace] SET activity = 'Processing and preserving of fish, crustaceans and molluscs',lt = null,lu = null WHERE idnace = '10.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.20','Processing and preserving of fish, crustaceans and molluscs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.20.1')
UPDATE [nace] SET activity = 'Processing and preserving of fish, crustaceans and molluscs',lt = null,lu = null WHERE idnace = '10.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.20.1','Processing and preserving of fish, crustaceans and molluscs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.3')
UPDATE [nace] SET activity = 'Processing and preserving of fruit and vegetables',lt = null,lu = null WHERE idnace = '10.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.3','Processing and preserving of fruit and vegetables',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.31')
UPDATE [nace] SET activity = 'Processing and preserving of potatoes',lt = null,lu = null WHERE idnace = '10.31'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.31','Processing and preserving of potatoes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.31.1')
UPDATE [nace] SET activity = 'Processing and preserving of potatoes',lt = null,lu = null WHERE idnace = '10.31.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.31.1','Processing and preserving of potatoes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.31.2')
UPDATE [nace] SET activity = 'Manufacture of potatoes chips and other snacks',lt = null,lu = null WHERE idnace = '10.31.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.31.2','Manufacture of potatoes chips and other snacks',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.32')
UPDATE [nace] SET activity = 'Manufacture of fruit and vegetable juice',lt = null,lu = null WHERE idnace = '10.32'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.32','Manufacture of fruit and vegetable juice',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.32.1')
UPDATE [nace] SET activity = 'Manufacture of fruit and vegetable juice (incl. fruit drinks and nectars)',lt = null,lu = null WHERE idnace = '10.32.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.32.1','Manufacture of fruit and vegetable juice (incl. fruit drinks and nectars)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.39')
UPDATE [nace] SET activity = 'Other processing and preserving of fruit and vegetables',lt = null,lu = null WHERE idnace = '10.39'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.39','Other processing and preserving of fruit and vegetables',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.39.1')
UPDATE [nace] SET activity = 'Processing and preserving of fruit and vegetables n.e.c.',lt = null,lu = null WHERE idnace = '10.39.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.39.1','Processing and preserving of fruit and vegetables n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.39.2')
UPDATE [nace] SET activity = 'Processing of nuts',lt = null,lu = null WHERE idnace = '10.39.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.39.2','Processing of nuts',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.4')
UPDATE [nace] SET activity = 'Manufacture of vegetable and animal oils and fats',lt = null,lu = null WHERE idnace = '10.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.4','Manufacture of vegetable and animal oils and fats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.41')
UPDATE [nace] SET activity = 'Manufacture of oils and fats',lt = null,lu = null WHERE idnace = '10.41'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.41','Manufacture of oils and fats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.41.1')
UPDATE [nace] SET activity = 'Production of crude olive oil',lt = null,lu = null WHERE idnace = '10.41.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.41.1','Production of crude olive oil',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.41.2')
UPDATE [nace] SET activity = 'Production of refined olive-oil',lt = null,lu = null WHERE idnace = '10.41.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.41.2','Production of refined olive-oil',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.41.3')
UPDATE [nace] SET activity = 'Production of other crude vegetable oils',lt = null,lu = null WHERE idnace = '10.41.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.41.3','Production of other crude vegetable oils',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.41.4')
UPDATE [nace] SET activity = 'Production of other refined vegetable oils',lt = null,lu = null WHERE idnace = '10.41.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.41.4','Production of other refined vegetable oils',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.42')
UPDATE [nace] SET activity = 'Manufacture of margarine and similar edible fats',lt = null,lu = null WHERE idnace = '10.42'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.42','Manufacture of margarine and similar edible fats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.42.1')
UPDATE [nace] SET activity = 'Manufacture of margarine and similar edible fats',lt = null,lu = null WHERE idnace = '10.42.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.42.1','Manufacture of margarine and similar edible fats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.5')
UPDATE [nace] SET activity = 'Manufacture of dairy products',lt = null,lu = null WHERE idnace = '10.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.5','Manufacture of dairy products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.51')
UPDATE [nace] SET activity = 'Operation of dairies and cheese making',lt = null,lu = null WHERE idnace = '10.51'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.51','Operation of dairies and cheese making',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.51.1')
UPDATE [nace] SET activity = 'Production of pasteurised milk, milk cream and butter',lt = null,lu = null WHERE idnace = '10.51.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.51.1','Production of pasteurised milk, milk cream and butter',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.51.2')
UPDATE [nace] SET activity = 'Production of cheese and curd',lt = null,lu = null WHERE idnace = '10.51.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.51.2','Production of cheese and curd',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.51.3')
UPDATE [nace] SET activity = 'Production of dairy products n.e.c. (incl. yoghurt)',lt = null,lu = null WHERE idnace = '10.51.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.51.3','Production of dairy products n.e.c. (incl. yoghurt)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.52')
UPDATE [nace] SET activity = 'Manufacture of ice cream',lt = null,lu = null WHERE idnace = '10.52'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.52','Manufacture of ice cream',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.52.1')
UPDATE [nace] SET activity = 'Production of ice cream and other edible ice',lt = null,lu = null WHERE idnace = '10.52.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.52.1','Production of ice cream and other edible ice',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.6')
UPDATE [nace] SET activity = 'Manufacture of grain mill products, starches and starch products',lt = null,lu = null WHERE idnace = '10.6'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.6','Manufacture of grain mill products, starches and starch products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.61')
UPDATE [nace] SET activity = 'Manufacture of grain mill products',lt = null,lu = null WHERE idnace = '10.61'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.61','Manufacture of grain mill products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.61.1')
UPDATE [nace] SET activity = 'Production of flour from cereals and vegetables',lt = null,lu = null WHERE idnace = '10.61.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.61.1','Production of flour from cereals and vegetables',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.61.2')
UPDATE [nace] SET activity = 'Production of other grain mill products (e.g. groats)',lt = null,lu = null WHERE idnace = '10.61.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.61.2','Production of other grain mill products (e.g. groats)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.62')
UPDATE [nace] SET activity = 'Manufacture of starches and starch products',lt = null,lu = null WHERE idnace = '10.62'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.62','Manufacture of starches and starch products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.62.1')
UPDATE [nace] SET activity = 'Manufacture of starches and starch products',lt = null,lu = null WHERE idnace = '10.62.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.62.1','Manufacture of starches and starch products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.7')
UPDATE [nace] SET activity = 'Manufacture of bakery and farinaceous products',lt = null,lu = null WHERE idnace = '10.7'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.7','Manufacture of bakery and farinaceous products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.71')
UPDATE [nace] SET activity = 'Manufacture of bread; manufacture of fresh pastry goods and cakes',lt = null,lu = null WHERE idnace = '10.71'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.71','Manufacture of bread; manufacture of fresh pastry goods and cakes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.71.1')
UPDATE [nace] SET activity = 'Manufacture of bread and rolls',lt = null,lu = null WHERE idnace = '10.71.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.71.1','Manufacture of bread and rolls',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.71.2')
UPDATE [nace] SET activity = 'Manufacture of fresh pastry goods and cakes',lt = null,lu = null WHERE idnace = '10.71.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.71.2','Manufacture of fresh pastry goods and cakes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.72')
UPDATE [nace] SET activity = 'Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes',lt = null,lu = null WHERE idnace = '10.72'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.72','Manufacture of rusks and biscuits; manufacture of preserved pastry goods and cakes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.72.1')
UPDATE [nace] SET activity = 'Manufacture of rusks and biscuits and ''''dry'''' bakery products',lt = null,lu = null WHERE idnace = '10.72.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.72.1','Manufacture of rusks and biscuits and ''''dry'''' bakery products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.72.2')
UPDATE [nace] SET activity = 'Manufacture of preserved pastry goods and cakes',lt = null,lu = null WHERE idnace = '10.72.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.72.2','Manufacture of preserved pastry goods and cakes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.72.3')
UPDATE [nace] SET activity = 'Manufacture of snack products whether sweet or salted',lt = null,lu = null WHERE idnace = '10.72.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.72.3','Manufacture of snack products whether sweet or salted',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.73')
UPDATE [nace] SET activity = 'Manufacture of macaroni, noodles, couscous and similar farinaceous products',lt = null,lu = null WHERE idnace = '10.73'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.73','Manufacture of macaroni, noodles, couscous and similar farinaceous products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.73.1')
UPDATE [nace] SET activity = 'Manufacture of macaroni, noodles, couscous and similar farinaceous products',lt = null,lu = null WHERE idnace = '10.73.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.73.1','Manufacture of macaroni, noodles, couscous and similar farinaceous products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.8')
UPDATE [nace] SET activity = 'Manufacture of other food products',lt = null,lu = null WHERE idnace = '10.8'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.8','Manufacture of other food products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.81')
UPDATE [nace] SET activity = 'Manufacture of sugar',lt = null,lu = null WHERE idnace = '10.81'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.81','Manufacture of sugar',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.81.1')
UPDATE [nace] SET activity = 'Manufacture of sugar',lt = null,lu = null WHERE idnace = '10.81.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.81.1','Manufacture of sugar',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.82')
UPDATE [nace] SET activity = 'Manufacture of cocoa, chocolate and sugar confectionery',lt = null,lu = null WHERE idnace = '10.82'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.82','Manufacture of cocoa, chocolate and sugar confectionery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.82.1')
UPDATE [nace] SET activity = 'Manufacture of cocoa, chocolate, chocolate confectionery and sugar confectionery',lt = null,lu = null WHERE idnace = '10.82.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.82.1','Manufacture of cocoa, chocolate, chocolate confectionery and sugar confectionery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.83')
UPDATE [nace] SET activity = 'Processing of tea and coffee',lt = null,lu = null WHERE idnace = '10.83'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.83','Processing of tea and coffee',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.83.1')
UPDATE [nace] SET activity = 'Processing and packing of coffee and tea. Production of coffee products and herb infusions',lt = null,lu = null WHERE idnace = '10.83.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.83.1','Processing and packing of coffee and tea. Production of coffee products and herb infusions',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.84')
UPDATE [nace] SET activity = 'Manufacture of condiments and seasonings',lt = null,lu = null WHERE idnace = '10.84'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.84','Manufacture of condiments and seasonings',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.84.1')
UPDATE [nace] SET activity = 'Manufacture of spices, sauces, condiments, prepared mustard, vinegar and salt',lt = null,lu = null WHERE idnace = '10.84.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.84.1','Manufacture of spices, sauces, condiments, prepared mustard, vinegar and salt',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.85')
UPDATE [nace] SET activity = 'Manufacture of prepared meals and dishes',lt = null,lu = null WHERE idnace = '10.85'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.85','Manufacture of prepared meals and dishes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.85.1')
UPDATE [nace] SET activity = 'Manufacture of frozen prepared meals and dishes',lt = null,lu = null WHERE idnace = '10.85.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.85.1','Manufacture of frozen prepared meals and dishes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.86')
UPDATE [nace] SET activity = 'Manufacture of homogenized food preparations and dietetic food',lt = null,lu = null WHERE idnace = '10.86'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.86','Manufacture of homogenized food preparations and dietetic food',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.86.1')
UPDATE [nace] SET activity = 'Manufacture of homogenised food preparations and dietetic food',lt = null,lu = null WHERE idnace = '10.86.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.86.1','Manufacture of homogenised food preparations and dietetic food',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.89')
UPDATE [nace] SET activity = 'Manufacture of other food products n.e.c.',lt = null,lu = null WHERE idnace = '10.89'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.89','Manufacture of other food products n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.89.1')
UPDATE [nace] SET activity = 'Manufacture, processing and bottling of other food products n.e.c.',lt = null,lu = null WHERE idnace = '10.89.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.89.1','Manufacture, processing and bottling of other food products n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.9')
UPDATE [nace] SET activity = 'Manufacture of prepared animal feeds',lt = null,lu = null WHERE idnace = '10.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.9','Manufacture of prepared animal feeds',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.91')
UPDATE [nace] SET activity = 'Manufacture of prepared feeds for farm animals',lt = null,lu = null WHERE idnace = '10.91'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.91','Manufacture of prepared feeds for farm animals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.91.1')
UPDATE [nace] SET activity = 'Manufactures of prepared feeds for farm animals',lt = null,lu = null WHERE idnace = '10.91.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.91.1','Manufactures of prepared feeds for farm animals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.92')
UPDATE [nace] SET activity = 'Manufacture of prepared pet foods',lt = null,lu = null WHERE idnace = '10.92'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.92','Manufacture of prepared pet foods',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '10.92.1')
UPDATE [nace] SET activity = 'Manufactures of prepared pet foods',lt = null,lu = null WHERE idnace = '10.92.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('10.92.1','Manufactures of prepared pet foods',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11')
UPDATE [nace] SET activity = 'Manufacture of beverages',lt = null,lu = null WHERE idnace = '11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11','Manufacture of beverages',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.0')
UPDATE [nace] SET activity = 'Manufacture of beverages',lt = null,lu = null WHERE idnace = '11.0'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.0','Manufacture of beverages',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.01')
UPDATE [nace] SET activity = 'Distilling, rectifying and blending of spirits',lt = null,lu = null WHERE idnace = '11.01'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.01','Distilling, rectifying and blending of spirits',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.01.1')
UPDATE [nace] SET activity = 'Distilling, rectifying and blending of spirits(e.g. whisky, brandy, gin, liqueurs, etc.)',lt = null,lu = null WHERE idnace = '11.01.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.01.1','Distilling, rectifying and blending of spirits(e.g. whisky, brandy, gin, liqueurs, etc.)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.02')
UPDATE [nace] SET activity = 'Manufacture of wine from grape',lt = null,lu = null WHERE idnace = '11.02'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.02','Manufacture of wine from grape',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.02.1')
UPDATE [nace] SET activity = 'Manufacture of wine from grape',lt = null,lu = null WHERE idnace = '11.02.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.02.1','Manufacture of wine from grape',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.03')
UPDATE [nace] SET activity = 'Manufacture of cider and other fruit wines',lt = null,lu = null WHERE idnace = '11.03'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.03','Manufacture of cider and other fruit wines',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.03.1')
UPDATE [nace] SET activity = 'Manufacture of cider and other fruit wines',lt = null,lu = null WHERE idnace = '11.03.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.03.1','Manufacture of cider and other fruit wines',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.04')
UPDATE [nace] SET activity = 'Manufacture of other non-distilled fermented beverages',lt = null,lu = null WHERE idnace = '11.04'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.04','Manufacture of other non-distilled fermented beverages',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.04.1')
UPDATE [nace] SET activity = 'Manufacture of vermouth and similar beverages',lt = null,lu = null WHERE idnace = '11.04.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.04.1','Manufacture of vermouth and similar beverages',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.05')
UPDATE [nace] SET activity = 'Manufacture of beer',lt = null,lu = null WHERE idnace = '11.05'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.05','Manufacture of beer',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.05.1')
UPDATE [nace] SET activity = 'Manufacture of beer',lt = null,lu = null WHERE idnace = '11.05.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.05.1','Manufacture of beer',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.06')
UPDATE [nace] SET activity = 'Manufacture of malt',lt = null,lu = null WHERE idnace = '11.06'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.06','Manufacture of malt',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.06.1')
UPDATE [nace] SET activity = 'Manufacture of malt',lt = null,lu = null WHERE idnace = '11.06.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.06.1','Manufacture of malt',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.07')
UPDATE [nace] SET activity = 'Manufacture of soft drinks; production of mineral waters and other bottled waters',lt = null,lu = null WHERE idnace = '11.07'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.07','Manufacture of soft drinks; production of mineral waters and other bottled waters',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '11.07.1')
UPDATE [nace] SET activity = 'Production of soft drinks. Production and bottling of natural mineral waters',lt = null,lu = null WHERE idnace = '11.07.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('11.07.1','Production of soft drinks. Production and bottling of natural mineral waters',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '12')
UPDATE [nace] SET activity = 'Manufacture of tobacco products',lt = null,lu = null WHERE idnace = '12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('12','Manufacture of tobacco products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '12.0')
UPDATE [nace] SET activity = 'Manufacture of tobacco products',lt = null,lu = null WHERE idnace = '12.0'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('12.0','Manufacture of tobacco products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '12.00')
UPDATE [nace] SET activity = 'Manufacture of tobacco products',lt = null,lu = null WHERE idnace = '12.00'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('12.00','Manufacture of tobacco products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '12.00.1')
UPDATE [nace] SET activity = 'Processing of tobacco leaves and manufacture of tobacco products',lt = null,lu = null WHERE idnace = '12.00.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('12.00.1','Processing of tobacco leaves and manufacture of tobacco products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13')
UPDATE [nace] SET activity = 'Manufacture of textiles',lt = null,lu = null WHERE idnace = '13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13','Manufacture of textiles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.1')
UPDATE [nace] SET activity = 'Preparation and spinning of textile fibres',lt = null,lu = null WHERE idnace = '13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.1','Preparation and spinning of textile fibres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.10')
UPDATE [nace] SET activity = 'Preparation and spinning of textile fibres',lt = null,lu = null WHERE idnace = '13.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.10','Preparation and spinning of textile fibres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.10.1')
UPDATE [nace] SET activity = 'Preparation and spinning of textile fibres (cotton, wooll, worst and silk)',lt = null,lu = null WHERE idnace = '13.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.10.1','Preparation and spinning of textile fibres (cotton, wooll, worst and silk)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.10.2')
UPDATE [nace] SET activity = 'Manufacture of sewing threads of any textile material',lt = null,lu = null WHERE idnace = '13.10.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.10.2','Manufacture of sewing threads of any textile material',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.10.3')
UPDATE [nace] SET activity = 'Preparation and spinning of other textile fibres',lt = null,lu = null WHERE idnace = '13.10.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.10.3','Preparation and spinning of other textile fibres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.2')
UPDATE [nace] SET activity = 'Weaving of textiles',lt = null,lu = null WHERE idnace = '13.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.2','Weaving of textiles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.20')
UPDATE [nace] SET activity = 'Weaving of textiles',lt = null,lu = null WHERE idnace = '13.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.20','Weaving of textiles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.20.1')
UPDATE [nace] SET activity = 'Weaving of textiles (using cotton, silk, wool, linum)',lt = null,lu = null WHERE idnace = '13.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.20.1','Weaving of textiles (using cotton, silk, wool, linum)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.20.2')
UPDATE [nace] SET activity = 'Other textile weaving (using hemp, jute, bast, polypropylene fibres, etc.)',lt = null,lu = null WHERE idnace = '13.20.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.20.2','Other textile weaving (using hemp, jute, bast, polypropylene fibres, etc.)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.3')
UPDATE [nace] SET activity = 'Finishing of textiles',lt = null,lu = null WHERE idnace = '13.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.3','Finishing of textiles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.30')
UPDATE [nace] SET activity = 'Finishing of textiles',lt = null,lu = null WHERE idnace = '13.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.30','Finishing of textiles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.30.1')
UPDATE [nace] SET activity = 'Finishing of textiles (bleaching, dyeing, printing, etc.) of not self-produced textiles and textile articles including wearing apparel',lt = null,lu = null WHERE idnace = '13.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.30.1','Finishing of textiles (bleaching, dyeing, printing, etc.) of not self-produced textiles and textile articles including wearing apparel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.9')
UPDATE [nace] SET activity = 'Manufacture of other textiles',lt = null,lu = null WHERE idnace = '13.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.9','Manufacture of other textiles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.91')
UPDATE [nace] SET activity = 'Manufacture of knitted and crocheted fabrics',lt = null,lu = null WHERE idnace = '13.91'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.91','Manufacture of knitted and crocheted fabrics',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.91.1')
UPDATE [nace] SET activity = 'Manufacture of knitted and crocheted fabrics',lt = null,lu = null WHERE idnace = '13.91.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.91.1','Manufacture of knitted and crocheted fabrics',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.92')
UPDATE [nace] SET activity = 'Manufacture of made-up textile articles, except apparel',lt = null,lu = null WHERE idnace = '13.92'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.92','Manufacture of made-up textile articles, except apparel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.92.1')
UPDATE [nace] SET activity = 'Manufacture of made-up articles of any textile material for the household (e.g. blankets, table, toilet or kitchen linen, quilts, cushions, furniture or bed covers, curtains, etc.)',lt = null,lu = null WHERE idnace = '13.92.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.92.1','Manufacture of made-up articles of any textile material for the household (e.g. blankets, table, toilet or kitchen linen, quilts, cushions, furniture or bed covers, curtains, etc.)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.92.2')
UPDATE [nace] SET activity = 'Manufacture of other made-up textiles (e.g. tarpaulins, tents, covers for cars, flags, sleeping bags, camping goods, etc.)',lt = null,lu = null WHERE idnace = '13.92.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.92.2','Manufacture of other made-up textiles (e.g. tarpaulins, tents, covers for cars, flags, sleeping bags, camping goods, etc.)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.93')
UPDATE [nace] SET activity = 'Manufacture of carpets and rugs',lt = null,lu = null WHERE idnace = '13.93'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.93','Manufacture of carpets and rugs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.93.1')
UPDATE [nace] SET activity = 'Manufacture of carpets and rugs',lt = null,lu = null WHERE idnace = '13.93.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.93.1','Manufacture of carpets and rugs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.94')
UPDATE [nace] SET activity = 'Manufacture of cordage, rope, twine and netting',lt = null,lu = null WHERE idnace = '13.94'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.94','Manufacture of cordage, rope, twine and netting',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.94.1')
UPDATE [nace] SET activity = 'Manufacture of rope, twine and cables of textile fibres. Manufacture of nets and other products made of rope, twine or netting (incl. loading slings)',lt = null,lu = null WHERE idnace = '13.94.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.94.1','Manufacture of rope, twine and cables of textile fibres. Manufacture of nets and other products made of rope, twine or netting (incl. loading slings)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.95')
UPDATE [nace] SET activity = 'Manufacture of non-wovens and articles made from non-wovens, except apparel',lt = null,lu = null WHERE idnace = '13.95'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.95','Manufacture of non-wovens and articles made from non-wovens, except apparel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.95.1')
UPDATE [nace] SET activity = 'Manufacture of non-wovens and articles made from non-wovens, except apparel',lt = null,lu = null WHERE idnace = '13.95.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.95.1','Manufacture of non-wovens and articles made from non-wovens, except apparel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.96')
UPDATE [nace] SET activity = 'Manufacture of other technical and industrial textiles',lt = null,lu = null WHERE idnace = '13.96'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.96','Manufacture of other technical and industrial textiles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.96.1')
UPDATE [nace] SET activity = 'Manufacture of textile wadding and articles of wadding (sanitary towels or tampons), fabrics impregnated, coated, covered or laminated with plastic',lt = null,lu = null WHERE idnace = '13.96.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.96.1','Manufacture of textile wadding and articles of wadding (sanitary towels or tampons), fabrics impregnated, coated, covered or laminated with plastic',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.99')
UPDATE [nace] SET activity = 'Manufacture of other textiles n.e.c.',lt = null,lu = null WHERE idnace = '13.99'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.99','Manufacture of other textiles n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.99.1')
UPDATE [nace] SET activity = 'Manufacture of felt, labels, badges, lace and embroidery',lt = null,lu = null WHERE idnace = '13.99.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.99.1','Manufacture of felt, labels, badges, lace and embroidery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '13.99.9')
UPDATE [nace] SET activity = 'Manufacture of other textiles (incl. buttons and belt covering)',lt = null,lu = null WHERE idnace = '13.99.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('13.99.9','Manufacture of other textiles (incl. buttons and belt covering)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14')
UPDATE [nace] SET activity = 'Manufacture of wearing apparel',lt = null,lu = null WHERE idnace = '14'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14','Manufacture of wearing apparel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.1')
UPDATE [nace] SET activity = 'Manufacture of wearing apparel, except fur apparel',lt = null,lu = null WHERE idnace = '14.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.1','Manufacture of wearing apparel, except fur apparel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.11')
UPDATE [nace] SET activity = 'Manufacture of leather clothes',lt = null,lu = null WHERE idnace = '14.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.11','Manufacture of leather clothes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.11.1')
UPDATE [nace] SET activity = 'Manufacture of weaving apparel made of leather or imitation leather',lt = null,lu = null WHERE idnace = '14.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.11.1','Manufacture of weaving apparel made of leather or imitation leather',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.12')
UPDATE [nace] SET activity = 'Manufacture of workwear',lt = null,lu = null WHERE idnace = '14.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.12','Manufacture of workwear',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.12.1')
UPDATE [nace] SET activity = 'Manufacture of workwear',lt = null,lu = null WHERE idnace = '14.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.12.1','Manufacture of workwear',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.13')
UPDATE [nace] SET activity = 'Manufacture of other outerwear',lt = null,lu = null WHERE idnace = '14.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.13','Manufacture of other outerwear',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.13.1')
UPDATE [nace] SET activity = 'Manufacture of other outerwear made of woven knitted or crocheted fabric non-wovens, etc., for men, women and children',lt = null,lu = null WHERE idnace = '14.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.13.1','Manufacture of other outerwear made of woven knitted or crocheted fabric non-wovens, etc., for men, women and children',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.14')
UPDATE [nace] SET activity = 'Manufacture of underwear',lt = null,lu = null WHERE idnace = '14.14'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.14','Manufacture of underwear',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.14.1')
UPDATE [nace] SET activity = 'Manufacture of shirts, T-shirts and blouses',lt = null,lu = null WHERE idnace = '14.14.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.14.1','Manufacture of shirts, T-shirts and blouses',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.14.2')
UPDATE [nace] SET activity = 'Manufacture of pyjamas, night dresses, dressing gowns and underwear for men, women and children',lt = null,lu = null WHERE idnace = '14.14.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.14.2','Manufacture of pyjamas, night dresses, dressing gowns and underwear for men, women and children',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.19')
UPDATE [nace] SET activity = 'Manufacture of other wearing apparel and accessories',lt = null,lu = null WHERE idnace = '14.19'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.19','Manufacture of other wearing apparel and accessories',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.19.1')
UPDATE [nace] SET activity = 'Manufacture of babies'' garments',lt = null,lu = null WHERE idnace = '14.19.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.19.1','Manufacture of babies'' garments',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.19.2')
UPDATE [nace] SET activity = 'Manufacture of athlete''s wear, skisuits, swimwear, etc.',lt = null,lu = null WHERE idnace = '14.19.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.19.2','Manufacture of athlete''s wear, skisuits, swimwear, etc.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.19.3')
UPDATE [nace] SET activity = 'Manufacture of other clothing accessories (e.g. gloves, belts, shawls, ties, cravats, etc.)',lt = null,lu = null WHERE idnace = '14.19.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.19.3','Manufacture of other clothing accessories (e.g. gloves, belts, shawls, ties, cravats, etc.)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.19.4')
UPDATE [nace] SET activity = 'Manufacture of hats and caps',lt = null,lu = null WHERE idnace = '14.19.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.19.4','Manufacture of hats and caps',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.2')
UPDATE [nace] SET activity = 'Manufacture of articles of fur',lt = null,lu = null WHERE idnace = '14.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.2','Manufacture of articles of fur',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.20')
UPDATE [nace] SET activity = 'Manufacture of articles of fur',lt = null,lu = null WHERE idnace = '14.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.20','Manufacture of articles of fur',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.20.1')
UPDATE [nace] SET activity = 'Manufacture of articles made of furskins',lt = null,lu = null WHERE idnace = '14.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.20.1','Manufacture of articles made of furskins',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.3')
UPDATE [nace] SET activity = 'Manufacture of knitted and crocheted apparel',lt = null,lu = null WHERE idnace = '14.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.3','Manufacture of knitted and crocheted apparel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.31')
UPDATE [nace] SET activity = 'Manufacture of knitted and crocheted hosiery',lt = null,lu = null WHERE idnace = '14.31'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.31','Manufacture of knitted and crocheted hosiery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.31.1')
UPDATE [nace] SET activity = 'Manufacture of hosiery (incl. socks, tights and panty-hose)',lt = null,lu = null WHERE idnace = '14.31.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.31.1','Manufacture of hosiery (incl. socks, tights and panty-hose)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.39')
UPDATE [nace] SET activity = 'Manufacture of other knitted and crocheted apparel',lt = null,lu = null WHERE idnace = '14.39'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.39','Manufacture of other knitted and crocheted apparel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '14.39.1')
UPDATE [nace] SET activity = 'Manufacture of knitted and crocheted pullovers, cardigans, jerseys and similar articles',lt = null,lu = null WHERE idnace = '14.39.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('14.39.1','Manufacture of knitted and crocheted pullovers, cardigans, jerseys and similar articles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15')
UPDATE [nace] SET activity = 'Manufacture of leather and related products',lt = null,lu = null WHERE idnace = '15'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15','Manufacture of leather and related products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.1')
UPDATE [nace] SET activity = 'Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur',lt = null,lu = null WHERE idnace = '15.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.1','Tanning and dressing of leather; manufacture of luggage, handbags, saddlery and harness; dressing and dyeing of fur',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.11')
UPDATE [nace] SET activity = 'Tanning and dressing of leather; dressing and dyeing of fur',lt = null,lu = null WHERE idnace = '15.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.11','Tanning and dressing of leather; dressing and dyeing of fur',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.11.1')
UPDATE [nace] SET activity = 'Dressing (e.g. scraping, tanning, bleaching, etc.) and dyeing of furskins.',lt = null,lu = null WHERE idnace = '15.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.11.1','Dressing (e.g. scraping, tanning, bleaching, etc.) and dyeing of furskins.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.11.2')
UPDATE [nace] SET activity = 'Production of tanned leather. Manufacture of dressed leather and composition leather',lt = null,lu = null WHERE idnace = '15.11.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.11.2','Production of tanned leather. Manufacture of dressed leather and composition leather',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.12')
UPDATE [nace] SET activity = 'Manufacture of luggage, handbags and the like, saddlery and harness',lt = null,lu = null WHERE idnace = '15.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.12','Manufacture of luggage, handbags and the like, saddlery and harness',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.12.1')
UPDATE [nace] SET activity = 'Manufacture of luggage, handbags and the like of any material. Manufacture of saddlery, harness and other articles of leather or composition leather. Leather cutting',lt = null,lu = null WHERE idnace = '15.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.12.1','Manufacture of luggage, handbags and the like of any material. Manufacture of saddlery, harness and other articles of leather or composition leather. Leather cutting',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.2')
UPDATE [nace] SET activity = 'Manufacture of footwear',lt = null,lu = null WHERE idnace = '15.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.2','Manufacture of footwear',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.20')
UPDATE [nace] SET activity = 'Manufacture of footwear',lt = null,lu = null WHERE idnace = '15.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.20','Manufacture of footwear',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.20.1')
UPDATE [nace] SET activity = 'Manufacture of footwear of any material',lt = null,lu = null WHERE idnace = '15.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.20.1','Manufacture of footwear of any material',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '15.20.2')
UPDATE [nace] SET activity = 'Manufacture of parts of footwear (e.g. uppers and parts of uppers, outer and inner soles, heels, etc.) ( incl. sewing of footwear)',lt = null,lu = null WHERE idnace = '15.20.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('15.20.2','Manufacture of parts of footwear (e.g. uppers and parts of uppers, outer and inner soles, heels, etc.) ( incl. sewing of footwear)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16')
UPDATE [nace] SET activity = 'Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials',lt = null,lu = null WHERE idnace = '16'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16','Manufacture of wood and of products of wood and cork, except furniture; manufacture of articles of straw and plaiting materials',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.1')
UPDATE [nace] SET activity = 'Sawmilling and planing of wood',lt = null,lu = null WHERE idnace = '16.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.1','Sawmilling and planing of wood',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.10')
UPDATE [nace] SET activity = 'Sawmilling and planing of wood',lt = null,lu = null WHERE idnace = '16.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.10','Sawmilling and planing of wood',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.10.1')
UPDATE [nace] SET activity = 'Sawmilling and planing of wood. Impregnation of wood',lt = null,lu = null WHERE idnace = '16.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.10.1','Sawmilling and planing of wood. Impregnation of wood',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.2')
UPDATE [nace] SET activity = 'Manufacture of products of wood, cork, straw and plaiting materials',lt = null,lu = null WHERE idnace = '16.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.2','Manufacture of products of wood, cork, straw and plaiting materials',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.21')
UPDATE [nace] SET activity = 'Manufacture of veneer sheets and wood-based panels',lt = null,lu = null WHERE idnace = '16.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.21','Manufacture of veneer sheets and wood-based panels',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.21.1')
UPDATE [nace] SET activity = 'Manufacture of plywood, laminboard, particle board, fibre board, other panels and boards and veneer sheets',lt = null,lu = null WHERE idnace = '16.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.21.1','Manufacture of plywood, laminboard, particle board, fibre board, other panels and boards and veneer sheets',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.22')
UPDATE [nace] SET activity = 'Manufacture of assembled parquet floors',lt = null,lu = null WHERE idnace = '16.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.22','Manufacture of assembled parquet floors',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.22.1')
UPDATE [nace] SET activity = 'Manufacture of parquet floor blocks',lt = null,lu = null WHERE idnace = '16.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.22.1','Manufacture of parquet floor blocks',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.23')
UPDATE [nace] SET activity = 'Manufacture of other builders'' carpentry and joinery',lt = null,lu = null WHERE idnace = '16.23'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.23','Manufacture of other builders'' carpentry and joinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.23.1')
UPDATE [nace] SET activity = 'Manufacture of builders'' carpentry and joinery',lt = null,lu = null WHERE idnace = '16.23.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.23.1','Manufacture of builders'' carpentry and joinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.23.2')
UPDATE [nace] SET activity = 'Manufacture of prefabricated buildings or elements thereof of wood',lt = null,lu = null WHERE idnace = '16.23.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.23.2','Manufacture of prefabricated buildings or elements thereof of wood',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.24')
UPDATE [nace] SET activity = 'Manufacture of wooden containers',lt = null,lu = null WHERE idnace = '16.24'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.24','Manufacture of wooden containers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.24.1')
UPDATE [nace] SET activity = 'Manufacture of wooden packing cases, boxes, barrels, pallets, etc.',lt = null,lu = null WHERE idnace = '16.24.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.24.1','Manufacture of wooden packing cases, boxes, barrels, pallets, etc.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.29')
UPDATE [nace] SET activity = 'Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials',lt = null,lu = null WHERE idnace = '16.29'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.29','Manufacture of other products of wood; manufacture of articles of cork, straw and plaiting materials',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.29.1')
UPDATE [nace] SET activity = 'Manufacture of wooden frames, statuettes, ornaments and other products of wood n.e.c.(incl. wood terner)',lt = null,lu = null WHERE idnace = '16.29.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.29.1','Manufacture of wooden frames, statuettes, ornaments and other products of wood n.e.c.(incl. wood terner)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '16.29.2')
UPDATE [nace] SET activity = 'Manufacture of articles of cork, plaits, basketware and wickerwork of straw and plaiting materials',lt = null,lu = null WHERE idnace = '16.29.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('16.29.2','Manufacture of articles of cork, plaits, basketware and wickerwork of straw and plaiting materials',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17')
UPDATE [nace] SET activity = 'Manufacture of paper and paper products',lt = null,lu = null WHERE idnace = '17'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17','Manufacture of paper and paper products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.1')
UPDATE [nace] SET activity = 'Manufacture of pulp, paper and paperboard',lt = null,lu = null WHERE idnace = '17.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.1','Manufacture of pulp, paper and paperboard',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.11')
UPDATE [nace] SET activity = 'Manufacture of pulp',lt = null,lu = null WHERE idnace = '17.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.11','Manufacture of pulp',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.11.1')
UPDATE [nace] SET activity = 'Manufacture of pulp',lt = null,lu = null WHERE idnace = '17.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.11.1','Manufacture of pulp',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.12')
UPDATE [nace] SET activity = 'Manufacture of paper and paperboard',lt = null,lu = null WHERE idnace = '17.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.12','Manufacture of paper and paperboard',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.12.1')
UPDATE [nace] SET activity = 'Manufacture of paper and paperboard',lt = null,lu = null WHERE idnace = '17.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.12.1','Manufacture of paper and paperboard',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.2')
UPDATE [nace] SET activity = 'Manufacture of articles of paper and paperboard',lt = null,lu = null WHERE idnace = '17.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.2','Manufacture of articles of paper and paperboard',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.21')
UPDATE [nace] SET activity = 'Manufacture of corrugated paper and paperboard and of containers of paper and paperboard',lt = null,lu = null WHERE idnace = '17.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.21','Manufacture of corrugated paper and paperboard and of containers of paper and paperboard',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.21.1')
UPDATE [nace] SET activity = 'Manufacture of containers, boxes, sacks and bags of paper or paperboard',lt = null,lu = null WHERE idnace = '17.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.21.1','Manufacture of containers, boxes, sacks and bags of paper or paperboard',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.22')
UPDATE [nace] SET activity = 'Manufacture of household and sanitary goods and of toilet requisites',lt = null,lu = null WHERE idnace = '17.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.22','Manufacture of household and sanitary goods and of toilet requisites',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.22.1')
UPDATE [nace] SET activity = 'Manufacture of household and personal hygiene paper and wadding and articles of wadding',lt = null,lu = null WHERE idnace = '17.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.22.1','Manufacture of household and personal hygiene paper and wadding and articles of wadding',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.23')
UPDATE [nace] SET activity = 'Manufacture of paper stationary',lt = null,lu = null WHERE idnace = '17.23'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.23','Manufacture of paper stationary',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.23.1')
UPDATE [nace] SET activity = 'Manufacture of paper stationery, envelopes and letter - cards',lt = null,lu = null WHERE idnace = '17.23.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.23.1','Manufacture of paper stationery, envelopes and letter - cards',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.24')
UPDATE [nace] SET activity = 'Manufacture of wallpaper',lt = null,lu = null WHERE idnace = '17.24'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.24','Manufacture of wallpaper',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.24.1')
UPDATE [nace] SET activity = 'Manufacture of wallpaper',lt = null,lu = null WHERE idnace = '17.24.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.24.1','Manufacture of wallpaper',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.29')
UPDATE [nace] SET activity = 'Manufacture of other articles of paper and paperboard',lt = null,lu = null WHERE idnace = '17.29'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.29','Manufacture of other articles of paper and paperboard',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '17.29.1')
UPDATE [nace] SET activity = 'Manufacture of labels and other articles of paper and paperboard .',lt = null,lu = null WHERE idnace = '17.29.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('17.29.1','Manufacture of labels and other articles of paper and paperboard .',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18')
UPDATE [nace] SET activity = 'Printing and reproduction of recorded media',lt = null,lu = null WHERE idnace = '18'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18','Printing and reproduction of recorded media',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.1')
UPDATE [nace] SET activity = 'Printing and service activities related to printing',lt = null,lu = null WHERE idnace = '18.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.1','Printing and service activities related to printing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.11')
UPDATE [nace] SET activity = 'Printing of newspapers',lt = null,lu = null WHERE idnace = '18.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.11','Printing of newspapers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.11.1')
UPDATE [nace] SET activity = 'Printing of newspapers',lt = null,lu = null WHERE idnace = '18.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.11.1','Printing of newspapers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.12')
UPDATE [nace] SET activity = 'Other printing',lt = null,lu = null WHERE idnace = '18.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.12','Other printing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.12.1')
UPDATE [nace] SET activity = 'Other printing (excl. cloth printing)',lt = null,lu = null WHERE idnace = '18.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.12.1','Other printing (excl. cloth printing)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.13')
UPDATE [nace] SET activity = 'Pre-press and pre-media services',lt = null,lu = null WHERE idnace = '18.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.13','Pre-press and pre-media services',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.13.1')
UPDATE [nace] SET activity = 'Pre- press and pre-media services',lt = null,lu = null WHERE idnace = '18.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.13.1','Pre- press and pre-media services',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.14')
UPDATE [nace] SET activity = 'Binding and related services',lt = null,lu = null WHERE idnace = '18.14'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.14','Binding and related services',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.14.1')
UPDATE [nace] SET activity = 'Bookbinding',lt = null,lu = null WHERE idnace = '18.14.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.14.1','Bookbinding',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.14.9')
UPDATE [nace] SET activity = 'Ancillary activities related to printing',lt = null,lu = null WHERE idnace = '18.14.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.14.9','Ancillary activities related to printing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.2')
UPDATE [nace] SET activity = 'Reproduction of recorded media',lt = null,lu = null WHERE idnace = '18.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.2','Reproduction of recorded media',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.20')
UPDATE [nace] SET activity = 'Reproduction of recorded media',lt = null,lu = null WHERE idnace = '18.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.20','Reproduction of recorded media',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.20.1')
UPDATE [nace] SET activity = 'Reproduction of sound recording (I.e. reproduction from master copies of gramophone records, compact and DVD discs and tapes with music)',lt = null,lu = null WHERE idnace = '18.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.20.1','Reproduction of sound recording (I.e. reproduction from master copies of gramophone records, compact and DVD discs and tapes with music)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.20.2')
UPDATE [nace] SET activity = 'Reproduction of video recording (I.e. reproduction from master copies of tapes, records, compact and DVD discs and other video recordings with motion pictures )',lt = null,lu = null WHERE idnace = '18.20.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.20.2','Reproduction of video recording (I.e. reproduction from master copies of tapes, records, compact and DVD discs and other video recordings with motion pictures )',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '18.20.3')
UPDATE [nace] SET activity = 'Reproduction of computer media from master copies of software and data on discs and tapes',lt = null,lu = null WHERE idnace = '18.20.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('18.20.3','Reproduction of computer media from master copies of software and data on discs and tapes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '19')
UPDATE [nace] SET activity = 'Manufacture of coke and refined petroleum products',lt = null,lu = null WHERE idnace = '19'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('19','Manufacture of coke and refined petroleum products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '19.1')
UPDATE [nace] SET activity = 'Manufacture of coke oven products',lt = null,lu = null WHERE idnace = '19.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('19.1','Manufacture of coke oven products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '19.10')
UPDATE [nace] SET activity = 'Manufacture of coke oven products',lt = null,lu = null WHERE idnace = '19.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('19.10','Manufacture of coke oven products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '19.10.1')
UPDATE [nace] SET activity = 'Manufacture of coke oven products',lt = null,lu = null WHERE idnace = '19.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('19.10.1','Manufacture of coke oven products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '19.2')
UPDATE [nace] SET activity = 'Manufacture of refined petroleum products',lt = null,lu = null WHERE idnace = '19.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('19.2','Manufacture of refined petroleum products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '19.20')
UPDATE [nace] SET activity = 'Manufacture of refined petroleum products',lt = null,lu = null WHERE idnace = '19.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('19.20','Manufacture of refined petroleum products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '19.20.1')
UPDATE [nace] SET activity = 'Manufacture of refined petroleum products',lt = null,lu = null WHERE idnace = '19.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('19.20.1','Manufacture of refined petroleum products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20')
UPDATE [nace] SET activity = 'Manufacture of chemicals and chemical products',lt = null,lu = null WHERE idnace = '20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20','Manufacture of chemicals and chemical products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.1')
UPDATE [nace] SET activity = 'Manufacture of basic chemicals, fertilizers and nitrogen compounds, plastics and synthetic rubber in primary forms',lt = null,lu = null WHERE idnace = '20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.1','Manufacture of basic chemicals, fertilizers and nitrogen compounds, plastics and synthetic rubber in primary forms',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.11')
UPDATE [nace] SET activity = 'Manufacture of industrial gases',lt = null,lu = null WHERE idnace = '20.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.11','Manufacture of industrial gases',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.11.1')
UPDATE [nace] SET activity = 'Manufacture of oxygen, acetylene, carbon dioxide and other industrial gases',lt = null,lu = null WHERE idnace = '20.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.11.1','Manufacture of oxygen, acetylene, carbon dioxide and other industrial gases',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.12')
UPDATE [nace] SET activity = 'Manufacture of dyes and pigments',lt = null,lu = null WHERE idnace = '20.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.12','Manufacture of dyes and pigments',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.12.1')
UPDATE [nace] SET activity = 'Manufacture of dyes and pigments in basic form or as concentrate',lt = null,lu = null WHERE idnace = '20.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.12.1','Manufacture of dyes and pigments in basic form or as concentrate',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.13')
UPDATE [nace] SET activity = 'Manufacture of other inorganic basic chemicals',lt = null,lu = null WHERE idnace = '20.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.13','Manufacture of other inorganic basic chemicals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.13.1')
UPDATE [nace] SET activity = 'Manufacture of other inorganic basic chemicals',lt = null,lu = null WHERE idnace = '20.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.13.1','Manufacture of other inorganic basic chemicals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.14')
UPDATE [nace] SET activity = 'Manufacture of other organic basic chemicals',lt = null,lu = null WHERE idnace = '20.14'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.14','Manufacture of other organic basic chemicals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.14.1')
UPDATE [nace] SET activity = 'Manufacture of other organic basic chemicals (e.g. hydrocarbons, ethylic alcohol)',lt = null,lu = null WHERE idnace = '20.14.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.14.1','Manufacture of other organic basic chemicals (e.g. hydrocarbons, ethylic alcohol)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.14.2')
UPDATE [nace] SET activity = 'Production of charcoal by means of industrial methods (i.e.distillation of wood)',lt = null,lu = null WHERE idnace = '20.14.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.14.2','Production of charcoal by means of industrial methods (i.e.distillation of wood)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.15')
UPDATE [nace] SET activity = 'Manufacture of fertilizers and nitrogen compounds',lt = null,lu = null WHERE idnace = '20.15'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.15','Manufacture of fertilizers and nitrogen compounds',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.15.1')
UPDATE [nace] SET activity = 'Manufacture of fertilisers and nitrogen compounds',lt = null,lu = null WHERE idnace = '20.15.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.15.1','Manufacture of fertilisers and nitrogen compounds',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.16')
UPDATE [nace] SET activity = 'Manufacture of plastics in primary forms',lt = null,lu = null WHERE idnace = '20.16'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.16','Manufacture of plastics in primary forms',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.16.1')
UPDATE [nace] SET activity = 'Manufacture of plastics in primary forms',lt = null,lu = null WHERE idnace = '20.16.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.16.1','Manufacture of plastics in primary forms',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.17')
UPDATE [nace] SET activity = 'Manufacture of synthetic rubber in primary forms',lt = null,lu = null WHERE idnace = '20.17'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.17','Manufacture of synthetic rubber in primary forms',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.17.1')
UPDATE [nace] SET activity = 'Manufacture of synthetic rubber in primary forms',lt = null,lu = null WHERE idnace = '20.17.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.17.1','Manufacture of synthetic rubber in primary forms',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.2')
UPDATE [nace] SET activity = 'Manufacture of pesticides and other agrochemical products',lt = null,lu = null WHERE idnace = '20.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.2','Manufacture of pesticides and other agrochemical products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.20')
UPDATE [nace] SET activity = 'Manufacture of pesticides and other agrochemical products',lt = null,lu = null WHERE idnace = '20.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.20','Manufacture of pesticides and other agrochemical products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.20.1')
UPDATE [nace] SET activity = 'Manufacture of pesticides and other agrochemical products',lt = null,lu = null WHERE idnace = '20.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.20.1','Manufacture of pesticides and other agrochemical products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.3')
UPDATE [nace] SET activity = 'Manufacture of paints, varnishes and similar coatings, printing ink and mastics',lt = null,lu = null WHERE idnace = '20.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.3','Manufacture of paints, varnishes and similar coatings, printing ink and mastics',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.30')
UPDATE [nace] SET activity = 'Manufacture of paints, varnishes and similar coatings, printing ink and mastics',lt = null,lu = null WHERE idnace = '20.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.30','Manufacture of paints, varnishes and similar coatings, printing ink and mastics',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.30.1')
UPDATE [nace] SET activity = 'Manufacture of paints, varnishes, thinners, lacquers and similar products',lt = null,lu = null WHERE idnace = '20.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.30.1','Manufacture of paints, varnishes, thinners, lacquers and similar products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.30.2')
UPDATE [nace] SET activity = 'Manufacture of insulated construction materials and mastics',lt = null,lu = null WHERE idnace = '20.30.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.30.2','Manufacture of insulated construction materials and mastics',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.4')
UPDATE [nace] SET activity = 'Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations',lt = null,lu = null WHERE idnace = '20.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.4','Manufacture of soap and detergents, cleaning and polishing preparations, perfumes and toilet preparations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.41')
UPDATE [nace] SET activity = 'Manufacture of soap and detergents, cleaning and polishing preparations',lt = null,lu = null WHERE idnace = '20.41'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.41','Manufacture of soap and detergents, cleaning and polishing preparations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.41.1')
UPDATE [nace] SET activity = 'Manufacture of soap, washing powders, detergents and other cleaning preparations',lt = null,lu = null WHERE idnace = '20.41.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.41.1','Manufacture of soap, washing powders, detergents and other cleaning preparations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.41.2')
UPDATE [nace] SET activity = 'Manufacture of polishes and creams for leather, wood, glass, etc.',lt = null,lu = null WHERE idnace = '20.41.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.41.2','Manufacture of polishes and creams for leather, wood, glass, etc.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.42')
UPDATE [nace] SET activity = 'Manufacture of perfumes and toilet preparations',lt = null,lu = null WHERE idnace = '20.42'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.42','Manufacture of perfumes and toilet preparations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.42.1')
UPDATE [nace] SET activity = 'Manufacture of perfumes and toilet preparations',lt = null,lu = null WHERE idnace = '20.42.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.42.1','Manufacture of perfumes and toilet preparations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.5')
UPDATE [nace] SET activity = 'Manufacture of other chemical products',lt = null,lu = null WHERE idnace = '20.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.5','Manufacture of other chemical products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.51')
UPDATE [nace] SET activity = 'Manufacture of explosives',lt = null,lu = null WHERE idnace = '20.51'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.51','Manufacture of explosives',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.51.1')
UPDATE [nace] SET activity = 'Manufacture of explosives and pyrotechnic products',lt = null,lu = null WHERE idnace = '20.51.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.51.1','Manufacture of explosives and pyrotechnic products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.51.2')
UPDATE [nace] SET activity = 'Manufacture of matches',lt = null,lu = null WHERE idnace = '20.51.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.51.2','Manufacture of matches',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.52')
UPDATE [nace] SET activity = 'Manufacture of glues',lt = null,lu = null WHERE idnace = '20.52'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.52','Manufacture of glues',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.52.1')
UPDATE [nace] SET activity = 'Manufacture of glues',lt = null,lu = null WHERE idnace = '20.52.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.52.1','Manufacture of glues',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.53')
UPDATE [nace] SET activity = 'Manufacture of essential oils',lt = null,lu = null WHERE idnace = '20.53'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.53','Manufacture of essential oils',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.53.1')
UPDATE [nace] SET activity = 'Manufacture of essential oils',lt = null,lu = null WHERE idnace = '20.53.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.53.1','Manufacture of essential oils',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.59')
UPDATE [nace] SET activity = 'Manufacture of other chemical products n.e.c.',lt = null,lu = null WHERE idnace = '20.59'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.59','Manufacture of other chemical products n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.59.1')
UPDATE [nace] SET activity = 'Manufacture of photographic chemical material',lt = null,lu = null WHERE idnace = '20.59.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.59.1','Manufacture of photographic chemical material',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.59.2')
UPDATE [nace] SET activity = 'Manufacture of gelatine',lt = null,lu = null WHERE idnace = '20.59.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.59.2','Manufacture of gelatine',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.59.9')
UPDATE [nace] SET activity = 'Manufacture of other chemical products n.e.c.',lt = null,lu = null WHERE idnace = '20.59.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.59.9','Manufacture of other chemical products n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.6')
UPDATE [nace] SET activity = 'Manufacture of man-made fibres',lt = null,lu = null WHERE idnace = '20.6'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.6','Manufacture of man-made fibres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.60')
UPDATE [nace] SET activity = 'Manufacture of man-made fibres',lt = null,lu = null WHERE idnace = '20.60'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.60','Manufacture of man-made fibres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '20.60.1')
UPDATE [nace] SET activity = 'Manufacture of man-made fibres',lt = null,lu = null WHERE idnace = '20.60.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('20.60.1','Manufacture of man-made fibres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '21')
UPDATE [nace] SET activity = 'Manufacture of basic pharmaceutical products and pharmaceutical preparations',lt = null,lu = null WHERE idnace = '21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('21','Manufacture of basic pharmaceutical products and pharmaceutical preparations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '21.1')
UPDATE [nace] SET activity = 'Manufacture of basic pharmaceutical products',lt = null,lu = null WHERE idnace = '21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('21.1','Manufacture of basic pharmaceutical products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '21.10')
UPDATE [nace] SET activity = 'Manufacture of basic pharmaceutical products',lt = null,lu = null WHERE idnace = '21.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('21.10','Manufacture of basic pharmaceutical products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '21.10.1')
UPDATE [nace] SET activity = 'Manufacture of basic pharmaceutical products',lt = null,lu = null WHERE idnace = '21.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('21.10.1','Manufacture of basic pharmaceutical products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '21.2')
UPDATE [nace] SET activity = 'Manufacture of pharmaceutical preparations',lt = null,lu = null WHERE idnace = '21.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('21.2','Manufacture of pharmaceutical preparations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '21.20')
UPDATE [nace] SET activity = 'Manufacture of pharmaceutical preparations',lt = null,lu = null WHERE idnace = '21.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('21.20','Manufacture of pharmaceutical preparations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '21.20.1')
UPDATE [nace] SET activity = 'Manufacture of pharmaceutical preparations',lt = null,lu = null WHERE idnace = '21.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('21.20.1','Manufacture of pharmaceutical preparations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22')
UPDATE [nace] SET activity = 'Manufacture of rubber and plastic products',lt = null,lu = null WHERE idnace = '22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22','Manufacture of rubber and plastic products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.1')
UPDATE [nace] SET activity = 'Manufacture of rubber products',lt = null,lu = null WHERE idnace = '22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.1','Manufacture of rubber products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.11')
UPDATE [nace] SET activity = 'Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres',lt = null,lu = null WHERE idnace = '22.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.11','Manufacture of rubber tyres and tubes; retreading and rebuilding of rubber tyres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.11.1')
UPDATE [nace] SET activity = 'Manufacture of rubber tyres and tubes',lt = null,lu = null WHERE idnace = '22.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.11.1','Manufacture of rubber tyres and tubes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.11.2')
UPDATE [nace] SET activity = 'Retreading and rebuilding of rubber tyres',lt = null,lu = null WHERE idnace = '22.11.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.11.2','Retreading and rebuilding of rubber tyres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.19')
UPDATE [nace] SET activity = 'Manufacture of other rubber products',lt = null,lu = null WHERE idnace = '22.19'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.19','Manufacture of other rubber products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.19.1')
UPDATE [nace] SET activity = 'Manufacture of other rubber products',lt = null,lu = null WHERE idnace = '22.19.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.19.1','Manufacture of other rubber products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.2')
UPDATE [nace] SET activity = 'Manufacture of plastics products',lt = null,lu = null WHERE idnace = '22.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.2','Manufacture of plastics products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.21')
UPDATE [nace] SET activity = 'Manufacture of plastic plates, sheets, tubes and profiles',lt = null,lu = null WHERE idnace = '22.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.21','Manufacture of plastic plates, sheets, tubes and profiles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.21.1')
UPDATE [nace] SET activity = 'Manufacture of plastic plates, sheets, tubes, pipes and pipe fittings, expanded polystyrene and foam rubber',lt = null,lu = null WHERE idnace = '22.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.21.1','Manufacture of plastic plates, sheets, tubes, pipes and pipe fittings, expanded polystyrene and foam rubber',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.22')
UPDATE [nace] SET activity = 'Manufacture of plastic packing goods',lt = null,lu = null WHERE idnace = '22.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.22','Manufacture of plastic packing goods',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.22.1')
UPDATE [nace] SET activity = 'Manufacture of plastic packing goods',lt = null,lu = null WHERE idnace = '22.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.22.1','Manufacture of plastic packing goods',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.23')
UPDATE [nace] SET activity = 'Manufacture of builders'' ware of plastic',lt = null,lu = null WHERE idnace = '22.23'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.23','Manufacture of builders'' ware of plastic',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.23.1')
UPDATE [nace] SET activity = 'Manufacture of builders`ware of plastic',lt = null,lu = null WHERE idnace = '22.23.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.23.1','Manufacture of builders`ware of plastic',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.29')
UPDATE [nace] SET activity = 'Manufacture of other plastic products',lt = null,lu = null WHERE idnace = '22.29'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.29','Manufacture of other plastic products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '22.29.1')
UPDATE [nace] SET activity = 'Manufacture of other plastic products',lt = null,lu = null WHERE idnace = '22.29.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('22.29.1','Manufacture of other plastic products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23')
UPDATE [nace] SET activity = 'Manufacture of other non-metallic mineral products',lt = null,lu = null WHERE idnace = '23'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23','Manufacture of other non-metallic mineral products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.1')
UPDATE [nace] SET activity = 'Manufacture of glass and glass products',lt = null,lu = null WHERE idnace = '23.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.1','Manufacture of glass and glass products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.11')
UPDATE [nace] SET activity = 'Manufacture of flat glass',lt = null,lu = null WHERE idnace = '23.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.11','Manufacture of flat glass',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.11.1')
UPDATE [nace] SET activity = 'Manufacture of flat glass, including wired, coloured or tinted flat glass',lt = null,lu = null WHERE idnace = '23.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.11.1','Manufacture of flat glass, including wired, coloured or tinted flat glass',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.12')
UPDATE [nace] SET activity = 'Shaping and processing of flat glass',lt = null,lu = null WHERE idnace = '23.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.12','Shaping and processing of flat glass',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.12.1')
UPDATE [nace] SET activity = 'Shaping and processing of flat glass',lt = null,lu = null WHERE idnace = '23.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.12.1','Shaping and processing of flat glass',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.13')
UPDATE [nace] SET activity = 'Manufacture of hollow glass',lt = null,lu = null WHERE idnace = '23.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.13','Manufacture of hollow glass',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.13.1')
UPDATE [nace] SET activity = 'Manufacture of hollow glass and ornamental glass articles',lt = null,lu = null WHERE idnace = '23.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.13.1','Manufacture of hollow glass and ornamental glass articles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.14')
UPDATE [nace] SET activity = 'Manufacture of glass fibres',lt = null,lu = null WHERE idnace = '23.14'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.14','Manufacture of glass fibres',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.14.1')
UPDATE [nace] SET activity = 'Manufacture of glass fibres including glass wool',lt = null,lu = null WHERE idnace = '23.14.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.14.1','Manufacture of glass fibres including glass wool',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.19')
UPDATE [nace] SET activity = 'Manufacture and processing of other glass, including technical glassware',lt = null,lu = null WHERE idnace = '23.19'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.19','Manufacture and processing of other glass, including technical glassware',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.19.1')
UPDATE [nace] SET activity = 'Manufacture and processing of other glass, including technical glassware',lt = null,lu = null WHERE idnace = '23.19.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.19.1','Manufacture and processing of other glass, including technical glassware',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.2')
UPDATE [nace] SET activity = 'Manufacture of refractory products',lt = null,lu = null WHERE idnace = '23.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.2','Manufacture of refractory products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.20')
UPDATE [nace] SET activity = 'Manufacture of refractory products',lt = null,lu = null WHERE idnace = '23.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.20','Manufacture of refractory products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.20.1')
UPDATE [nace] SET activity = 'Manufacture of refractory products',lt = null,lu = null WHERE idnace = '23.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.20.1','Manufacture of refractory products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.3')
UPDATE [nace] SET activity = 'Manufacture of clay building materials',lt = null,lu = null WHERE idnace = '23.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.3','Manufacture of clay building materials',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.31')
UPDATE [nace] SET activity = 'Manufacture of ceramic tiles and flags',lt = null,lu = null WHERE idnace = '23.31'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.31','Manufacture of ceramic tiles and flags',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.31.1')
UPDATE [nace] SET activity = 'Manufacture of mosaic tiles',lt = null,lu = null WHERE idnace = '23.31.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.31.1','Manufacture of mosaic tiles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.32')
UPDATE [nace] SET activity = 'Manufacture of bricks, tiles and construction products, in baked clay',lt = null,lu = null WHERE idnace = '23.32'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.32','Manufacture of bricks, tiles and construction products, in baked clay',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.32.1')
UPDATE [nace] SET activity = 'Manufacture of bricks, roof tiles and construction products, in baked clay',lt = null,lu = null WHERE idnace = '23.32.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.32.1','Manufacture of bricks, roof tiles and construction products, in baked clay',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.4')
UPDATE [nace] SET activity = 'Manufacture of other porcelain and ceramic products',lt = null,lu = null WHERE idnace = '23.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.4','Manufacture of other porcelain and ceramic products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.41')
UPDATE [nace] SET activity = 'Manufacture of ceramic household and ornamental articles',lt = null,lu = null WHERE idnace = '23.41'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.41','Manufacture of ceramic household and ornamental articles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.41.1')
UPDATE [nace] SET activity = 'Pottery',lt = null,lu = null WHERE idnace = '23.41.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.41.1','Pottery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.42')
UPDATE [nace] SET activity = 'Manufacture of ceramic sanitary fixtures',lt = null,lu = null WHERE idnace = '23.42'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.42','Manufacture of ceramic sanitary fixtures',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.42.1')
UPDATE [nace] SET activity = 'Manufacture of ceramic sanitary fixtures',lt = null,lu = null WHERE idnace = '23.42.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.42.1','Manufacture of ceramic sanitary fixtures',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.43')
UPDATE [nace] SET activity = 'Manufacture of ceramic insulators and insulating fittings',lt = null,lu = null WHERE idnace = '23.43'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.43','Manufacture of ceramic insulators and insulating fittings',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.43.1')
UPDATE [nace] SET activity = 'Manufacture of ceramic insulators and insulating fittings',lt = null,lu = null WHERE idnace = '23.43.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.43.1','Manufacture of ceramic insulators and insulating fittings',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.44')
UPDATE [nace] SET activity = 'Manufacture of other technical ceramic products',lt = null,lu = null WHERE idnace = '23.44'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.44','Manufacture of other technical ceramic products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.44.1')
UPDATE [nace] SET activity = 'Manufacture of other technical ceramic products',lt = null,lu = null WHERE idnace = '23.44.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.44.1','Manufacture of other technical ceramic products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.49')
UPDATE [nace] SET activity = 'Manufacture of other ceramic products',lt = null,lu = null WHERE idnace = '23.49'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.49','Manufacture of other ceramic products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.49.1')
UPDATE [nace] SET activity = 'Manufacture of other ceramic products',lt = null,lu = null WHERE idnace = '23.49.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.49.1','Manufacture of other ceramic products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.5')
UPDATE [nace] SET activity = 'Manufacture of cement, lime and plaster',lt = null,lu = null WHERE idnace = '23.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.5','Manufacture of cement, lime and plaster',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.51')
UPDATE [nace] SET activity = 'Manufacture of cement',lt = null,lu = null WHERE idnace = '23.51'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.51','Manufacture of cement',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.51.1')
UPDATE [nace] SET activity = 'Manufacture of cement',lt = null,lu = null WHERE idnace = '23.51.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.51.1','Manufacture of cement',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.52')
UPDATE [nace] SET activity = 'Manufacture of lime and plaster',lt = null,lu = null WHERE idnace = '23.52'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.52','Manufacture of lime and plaster',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.52.1')
UPDATE [nace] SET activity = 'Manufacture of lime',lt = null,lu = null WHERE idnace = '23.52.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.52.1','Manufacture of lime',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.52.2')
UPDATE [nace] SET activity = 'Manufacture of plaster',lt = null,lu = null WHERE idnace = '23.52.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.52.2','Manufacture of plaster',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.6')
UPDATE [nace] SET activity = 'Manufacture of articles of concrete, cement and plaster',lt = null,lu = null WHERE idnace = '23.6'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.6','Manufacture of articles of concrete, cement and plaster',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.61')
UPDATE [nace] SET activity = 'Manufacture of concrete products for construction purposes',lt = null,lu = null WHERE idnace = '23.61'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.61','Manufacture of concrete products for construction purposes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.61.1')
UPDATE [nace] SET activity = 'Manufacture of cement pipes, cement blocks, cement slates',lt = null,lu = null WHERE idnace = '23.61.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.61.1','Manufacture of cement pipes, cement blocks, cement slates',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.61.2')
UPDATE [nace] SET activity = 'Prefabricated structural components for building or civil engineering of cement, concrete',lt = null,lu = null WHERE idnace = '23.61.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.61.2','Prefabricated structural components for building or civil engineering of cement, concrete',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.62')
UPDATE [nace] SET activity = 'Manufacture of plaster products for construction purposes',lt = null,lu = null WHERE idnace = '23.62'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.62','Manufacture of plaster products for construction purposes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.62.1')
UPDATE [nace] SET activity = 'Manufacture of plaster products for construction purposes',lt = null,lu = null WHERE idnace = '23.62.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.62.1','Manufacture of plaster products for construction purposes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.63')
UPDATE [nace] SET activity = 'Manufacture of ready-mixed concrete',lt = null,lu = null WHERE idnace = '23.63'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.63','Manufacture of ready-mixed concrete',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.63.1')
UPDATE [nace] SET activity = 'Manufacture of ready-mixed concrete',lt = null,lu = null WHERE idnace = '23.63.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.63.1','Manufacture of ready-mixed concrete',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.64')
UPDATE [nace] SET activity = 'Manufacture of mortars',lt = null,lu = null WHERE idnace = '23.64'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.64','Manufacture of mortars',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.64.1')
UPDATE [nace] SET activity = 'Manufacture of powdered mortars',lt = null,lu = null WHERE idnace = '23.64.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.64.1','Manufacture of powdered mortars',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.65')
UPDATE [nace] SET activity = 'Manufacture of fibre cement',lt = null,lu = null WHERE idnace = '23.65'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.65','Manufacture of fibre cement',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.65.1')
UPDATE [nace] SET activity = 'Manufacture of fibre cement',lt = null,lu = null WHERE idnace = '23.65.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.65.1','Manufacture of fibre cement',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.69')
UPDATE [nace] SET activity = 'Manufacture of other articles of concrete, plaster and cement',lt = null,lu = null WHERE idnace = '23.69'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.69','Manufacture of other articles of concrete, plaster and cement',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.69.1')
UPDATE [nace] SET activity = 'Manufacture of other articles of concrete, plaster and cement',lt = null,lu = null WHERE idnace = '23.69.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.69.1','Manufacture of other articles of concrete, plaster and cement',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.7')
UPDATE [nace] SET activity = 'Cutting, shaping and finishing of stone',lt = null,lu = null WHERE idnace = '23.7'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.7','Cutting, shaping and finishing of stone',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.70')
UPDATE [nace] SET activity = 'Cutting, shaping and finishing of stone',lt = null,lu = null WHERE idnace = '23.70'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.70','Cutting, shaping and finishing of stone',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.70.1')
UPDATE [nace] SET activity = 'Cutting, shaping and finishing of stone (incl. crushing of marble )',lt = null,lu = null WHERE idnace = '23.70.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.70.1','Cutting, shaping and finishing of stone (incl. crushing of marble )',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.9')
UPDATE [nace] SET activity = 'Manufacture of abrasive products and non-metallic mineral products n.e.c',lt = null,lu = null WHERE idnace = '23.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.9','Manufacture of abrasive products and non-metallic mineral products n.e.c',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.91')
UPDATE [nace] SET activity = 'Production of abrasive products',lt = null,lu = null WHERE idnace = '23.91'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.91','Production of abrasive products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.91.1')
UPDATE [nace] SET activity = 'Production of abrasive products',lt = null,lu = null WHERE idnace = '23.91.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.91.1','Production of abrasive products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.99')
UPDATE [nace] SET activity = 'Manufacture of other non-metallic mineral products n.e.c.',lt = null,lu = null WHERE idnace = '23.99'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.99','Manufacture of other non-metallic mineral products n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '23.99.1')
UPDATE [nace] SET activity = 'Manufacture of other non- metallic mineral products n.e.c. (incl. premix and processed umber, activated bentonite,etc. )',lt = null,lu = null WHERE idnace = '23.99.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('23.99.1','Manufacture of other non- metallic mineral products n.e.c. (incl. premix and processed umber, activated bentonite,etc. )',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24')
UPDATE [nace] SET activity = 'Manufacture of basic metals',lt = null,lu = null WHERE idnace = '24'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24','Manufacture of basic metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.1')
UPDATE [nace] SET activity = 'Manufacture of basic iron and steel and of ferro-alloys',lt = null,lu = null WHERE idnace = '24.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.1','Manufacture of basic iron and steel and of ferro-alloys',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.10')
UPDATE [nace] SET activity = 'Manufacture of basic iron and steel and of ferro-alloys',lt = null,lu = null WHERE idnace = '24.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.10','Manufacture of basic iron and steel and of ferro-alloys',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.10.1')
UPDATE [nace] SET activity = 'Manufacture of basic iron and steel and of ferro- alloys',lt = null,lu = null WHERE idnace = '24.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.10.1','Manufacture of basic iron and steel and of ferro- alloys',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.2')
UPDATE [nace] SET activity = 'Manufacture of tubes, pipes, hollow profiles and related fittings, of steel',lt = null,lu = null WHERE idnace = '24.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.2','Manufacture of tubes, pipes, hollow profiles and related fittings, of steel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.20')
UPDATE [nace] SET activity = 'Manufacture of tubes, pipes, hollow profiles and related fittings, of steel',lt = null,lu = null WHERE idnace = '24.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.20','Manufacture of tubes, pipes, hollow profiles and related fittings, of steel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.20.1')
UPDATE [nace] SET activity = 'Manufacture of tubes, pipes, hollow profiles and related fittings, of steel',lt = null,lu = null WHERE idnace = '24.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.20.1','Manufacture of tubes, pipes, hollow profiles and related fittings, of steel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.3')
UPDATE [nace] SET activity = 'Manufacture of other products of first processing of steel',lt = null,lu = null WHERE idnace = '24.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.3','Manufacture of other products of first processing of steel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.31')
UPDATE [nace] SET activity = 'Cold drawing of bars',lt = null,lu = null WHERE idnace = '24.31'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.31','Cold drawing of bars',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.31.1')
UPDATE [nace] SET activity = 'Cold drawing of bars',lt = null,lu = null WHERE idnace = '24.31.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.31.1','Cold drawing of bars',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.32')
UPDATE [nace] SET activity = 'Cold rolling of narrow strip',lt = null,lu = null WHERE idnace = '24.32'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.32','Cold rolling of narrow strip',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.32.1')
UPDATE [nace] SET activity = 'Cold rolling of narrow strip',lt = null,lu = null WHERE idnace = '24.32.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.32.1','Cold rolling of narrow strip',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.33')
UPDATE [nace] SET activity = 'Cold forming or folding',lt = null,lu = null WHERE idnace = '24.33'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.33','Cold forming or folding',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.33.1')
UPDATE [nace] SET activity = 'Cold forming or folding',lt = null,lu = null WHERE idnace = '24.33.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.33.1','Cold forming or folding',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.34')
UPDATE [nace] SET activity = 'Cold drawing of wire',lt = null,lu = null WHERE idnace = '24.34'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.34','Cold drawing of wire',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.34.1')
UPDATE [nace] SET activity = 'Wire drawing',lt = null,lu = null WHERE idnace = '24.34.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.34.1','Wire drawing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.4')
UPDATE [nace] SET activity = 'Manufacture of basic precious and non-ferrous metals',lt = null,lu = null WHERE idnace = '24.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.4','Manufacture of basic precious and non-ferrous metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.41')
UPDATE [nace] SET activity = 'Precious metals production',lt = null,lu = null WHERE idnace = '24.41'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.41','Precious metals production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.41.1')
UPDATE [nace] SET activity = 'Precious metals production',lt = null,lu = null WHERE idnace = '24.41.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.41.1','Precious metals production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.42')
UPDATE [nace] SET activity = 'Aluminium production',lt = null,lu = null WHERE idnace = '24.42'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.42','Aluminium production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.42.1')
UPDATE [nace] SET activity = 'Aluminium production',lt = null,lu = null WHERE idnace = '24.42.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.42.1','Aluminium production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.43')
UPDATE [nace] SET activity = 'Lead, zinc and tin production',lt = null,lu = null WHERE idnace = '24.43'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.43','Lead, zinc and tin production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.43.1')
UPDATE [nace] SET activity = 'Lead, zinc and tin production',lt = null,lu = null WHERE idnace = '24.43.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.43.1','Lead, zinc and tin production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.44')
UPDATE [nace] SET activity = 'Copper production',lt = null,lu = null WHERE idnace = '24.44'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.44','Copper production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.44.1')
UPDATE [nace] SET activity = 'Copper production',lt = null,lu = null WHERE idnace = '24.44.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.44.1','Copper production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.45')
UPDATE [nace] SET activity = 'Other non-ferrous metal production',lt = null,lu = null WHERE idnace = '24.45'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.45','Other non-ferrous metal production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.45.1')
UPDATE [nace] SET activity = 'Other non- ferrous metal production',lt = null,lu = null WHERE idnace = '24.45.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.45.1','Other non- ferrous metal production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.46')
UPDATE [nace] SET activity = 'Processing of nuclear fuel',lt = null,lu = null WHERE idnace = '24.46'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.46','Processing of nuclear fuel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.46.1')
UPDATE [nace] SET activity = 'Processing of nuclear fuel',lt = null,lu = null WHERE idnace = '24.46.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.46.1','Processing of nuclear fuel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.5')
UPDATE [nace] SET activity = 'Casting of metals',lt = null,lu = null WHERE idnace = '24.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.5','Casting of metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.51')
UPDATE [nace] SET activity = 'Casting of iron',lt = null,lu = null WHERE idnace = '24.51'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.51','Casting of iron',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.51.1')
UPDATE [nace] SET activity = 'Casting of iron',lt = null,lu = null WHERE idnace = '24.51.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.51.1','Casting of iron',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.51.2')
UPDATE [nace] SET activity = 'Manufacture of tubes, pipes and hollow profiles and of tube or pipe fittings of cast-iron',lt = null,lu = null WHERE idnace = '24.51.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.51.2','Manufacture of tubes, pipes and hollow profiles and of tube or pipe fittings of cast-iron',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.52')
UPDATE [nace] SET activity = 'Casting of steel',lt = null,lu = null WHERE idnace = '24.52'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.52','Casting of steel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.52.1')
UPDATE [nace] SET activity = 'Casting of steel',lt = null,lu = null WHERE idnace = '24.52.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.52.1','Casting of steel',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.53')
UPDATE [nace] SET activity = 'Casting of light metals',lt = null,lu = null WHERE idnace = '24.53'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.53','Casting of light metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.53.1')
UPDATE [nace] SET activity = 'Casting of light metals',lt = null,lu = null WHERE idnace = '24.53.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.53.1','Casting of light metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.54')
UPDATE [nace] SET activity = 'Casting of other non-ferrous metals',lt = null,lu = null WHERE idnace = '24.54'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.54','Casting of other non-ferrous metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '24.54.1')
UPDATE [nace] SET activity = 'Casting of other non- ferrous metals',lt = null,lu = null WHERE idnace = '24.54.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('24.54.1','Casting of other non- ferrous metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25')
UPDATE [nace] SET activity = 'Manufacture of fabricated metal products, except machinery and equipment',lt = null,lu = null WHERE idnace = '25'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25','Manufacture of fabricated metal products, except machinery and equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.1')
UPDATE [nace] SET activity = 'Manufacture of structural metal products',lt = null,lu = null WHERE idnace = '25.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.1','Manufacture of structural metal products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.11')
UPDATE [nace] SET activity = 'Manufacture of metal structures and parts of structures',lt = null,lu = null WHERE idnace = '25.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.11','Manufacture of metal structures and parts of structures',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.11.1')
UPDATE [nace] SET activity = 'Manufacture of metal structures and parts, construction site huts and prefabricated buildings mainly of metal',lt = null,lu = null WHERE idnace = '25.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.11.1','Manufacture of metal structures and parts, construction site huts and prefabricated buildings mainly of metal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.12')
UPDATE [nace] SET activity = 'Manufacture of doors and windows of metal',lt = null,lu = null WHERE idnace = '25.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.12','Manufacture of doors and windows of metal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.12.1')
UPDATE [nace] SET activity = 'Manufacture of doors and windows of metal',lt = null,lu = null WHERE idnace = '25.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.12.1','Manufacture of doors and windows of metal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.2')
UPDATE [nace] SET activity = 'Manufacture of tanks, reservoirs and containers of metal',lt = null,lu = null WHERE idnace = '25.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.2','Manufacture of tanks, reservoirs and containers of metal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.21')
UPDATE [nace] SET activity = 'Manufacture of central heating radiators and boilers',lt = null,lu = null WHERE idnace = '25.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.21','Manufacture of central heating radiators and boilers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.21.1')
UPDATE [nace] SET activity = 'Manufacture of central heating radiators and boilers',lt = null,lu = null WHERE idnace = '25.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.21.1','Manufacture of central heating radiators and boilers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.29')
UPDATE [nace] SET activity = 'Manufacture of other tanks, reservoirs and containers of metal',lt = null,lu = null WHERE idnace = '25.29'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.29','Manufacture of other tanks, reservoirs and containers of metal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.29.1')
UPDATE [nace] SET activity = 'Manufacture of other tanks, reservoirs and containers of metal',lt = null,lu = null WHERE idnace = '25.29.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.29.1','Manufacture of other tanks, reservoirs and containers of metal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.3')
UPDATE [nace] SET activity = 'Manufacture of steam generators, except central heating hot water boilers',lt = null,lu = null WHERE idnace = '25.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.3','Manufacture of steam generators, except central heating hot water boilers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.30')
UPDATE [nace] SET activity = 'Manufacture of steam generators, except central heating hot water boilers',lt = null,lu = null WHERE idnace = '25.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.30','Manufacture of steam generators, except central heating hot water boilers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.30.1')
UPDATE [nace] SET activity = 'Manufacture of steam generators, except central heating hot water boilers',lt = null,lu = null WHERE idnace = '25.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.30.1','Manufacture of steam generators, except central heating hot water boilers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.4')
UPDATE [nace] SET activity = 'Manufacture of weapons and ammunition',lt = null,lu = null WHERE idnace = '25.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.4','Manufacture of weapons and ammunition',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.40')
UPDATE [nace] SET activity = 'Manufacture of weapons and ammunition',lt = null,lu = null WHERE idnace = '25.40'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.40','Manufacture of weapons and ammunition',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.40.1')
UPDATE [nace] SET activity = 'Manufacture of weapons and ammunition',lt = null,lu = null WHERE idnace = '25.40.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.40.1','Manufacture of weapons and ammunition',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.5')
UPDATE [nace] SET activity = 'Forging, pressing, stamping and roll-forming of metal; powder metallurgy',lt = null,lu = null WHERE idnace = '25.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.5','Forging, pressing, stamping and roll-forming of metal; powder metallurgy',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.50')
UPDATE [nace] SET activity = 'Forging, pressing, stamping and roll-forming of metal; powder metallurgy',lt = null,lu = null WHERE idnace = '25.50'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.50','Forging, pressing, stamping and roll-forming of metal; powder metallurgy',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.50.1')
UPDATE [nace] SET activity = 'Forging, pressing, stamping and roll-forming of metal; powder metallurgy',lt = null,lu = null WHERE idnace = '25.50.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.50.1','Forging, pressing, stamping and roll-forming of metal; powder metallurgy',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.6')
UPDATE [nace] SET activity = 'Treatment and coating of metals; Machining',lt = null,lu = null WHERE idnace = '25.6'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.6','Treatment and coating of metals; Machining',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.61')
UPDATE [nace] SET activity = 'Treatment and coating of metals',lt = null,lu = null WHERE idnace = '25.61'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.61','Treatment and coating of metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.61.1')
UPDATE [nace] SET activity = 'Anodising, coating and colouring of metals',lt = null,lu = null WHERE idnace = '25.61.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.61.1','Anodising, coating and colouring of metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.61.2')
UPDATE [nace] SET activity = 'Other services in the processing of metals (plating, buffing, carving, cleaning, sand blasting, etc.)',lt = null,lu = null WHERE idnace = '25.61.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.61.2','Other services in the processing of metals (plating, buffing, carving, cleaning, sand blasting, etc.)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.62')
UPDATE [nace] SET activity = 'Machining',lt = null,lu = null WHERE idnace = '25.62'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.62','Machining',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.62.1')
UPDATE [nace] SET activity = 'Machining',lt = null,lu = null WHERE idnace = '25.62.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.62.1','Machining',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.7')
UPDATE [nace] SET activity = 'Manufacture of cutlery, tools and general hardware',lt = null,lu = null WHERE idnace = '25.7'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.7','Manufacture of cutlery, tools and general hardware',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.71')
UPDATE [nace] SET activity = 'Manufacture of cutlery',lt = null,lu = null WHERE idnace = '25.71'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.71','Manufacture of cutlery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.71.1')
UPDATE [nace] SET activity = 'Manufacture of cutlery',lt = null,lu = null WHERE idnace = '25.71.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.71.1','Manufacture of cutlery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.72')
UPDATE [nace] SET activity = 'Manufacture of locks and hinges',lt = null,lu = null WHERE idnace = '25.72'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.72','Manufacture of locks and hinges',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.72.1')
UPDATE [nace] SET activity = 'Manufacture of locks and hinges',lt = null,lu = null WHERE idnace = '25.72.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.72.1','Manufacture of locks and hinges',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.73')
UPDATE [nace] SET activity = 'Manufacture of tools',lt = null,lu = null WHERE idnace = '25.73'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.73','Manufacture of tools',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.73.1')
UPDATE [nace] SET activity = 'Manufacture of knives and cutting blades, saws and sawblades for machines or for mechanical appliances',lt = null,lu = null WHERE idnace = '25.73.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.73.1','Manufacture of knives and cutting blades, saws and sawblades for machines or for mechanical appliances',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.73.2')
UPDATE [nace] SET activity = 'Manufacture of hand tools, blacksmith tools and interchangeable parts for hand tools and machine tools',lt = null,lu = null WHERE idnace = '25.73.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.73.2','Manufacture of hand tools, blacksmith tools and interchangeable parts for hand tools and machine tools',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.9')
UPDATE [nace] SET activity = 'Manufacture of other fabricated metal products',lt = null,lu = null WHERE idnace = '25.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.9','Manufacture of other fabricated metal products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.91')
UPDATE [nace] SET activity = 'Manufacture of steel drums and similar containers',lt = null,lu = null WHERE idnace = '25.91'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.91','Manufacture of steel drums and similar containers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.91.1')
UPDATE [nace] SET activity = 'Manufacture of iron and steel drums, pails, cans and similar containers of a capacity less than 300',lt = null,lu = null WHERE idnace = '25.91.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.91.1','Manufacture of iron and steel drums, pails, cans and similar containers of a capacity less than 300',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.92')
UPDATE [nace] SET activity = 'Manufacture of light metal packaging',lt = null,lu = null WHERE idnace = '25.92'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.92','Manufacture of light metal packaging',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.92.1')
UPDATE [nace] SET activity = 'Manufacture of tins and cans for food products and metallic closures',lt = null,lu = null WHERE idnace = '25.92.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.92.1','Manufacture of tins and cans for food products and metallic closures',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.93')
UPDATE [nace] SET activity = 'Manufacture of wire products, chain and springs',lt = null,lu = null WHERE idnace = '25.93'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.93','Manufacture of wire products, chain and springs',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.93.1')
UPDATE [nace] SET activity = 'Manufacture of metal cable, barbed wire, wire fencing, grill, netting and similar products, manufacture of nails and pins, electrodes and similar products',lt = null,lu = null WHERE idnace = '25.93.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.93.1','Manufacture of metal cable, barbed wire, wire fencing, grill, netting and similar products, manufacture of nails and pins, electrodes and similar products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.93.2')
UPDATE [nace] SET activity = 'Manufacture of metal springs and chains',lt = null,lu = null WHERE idnace = '25.93.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.93.2','Manufacture of metal springs and chains',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.94')
UPDATE [nace] SET activity = 'Manufacture of fasteners and screw machine products',lt = null,lu = null WHERE idnace = '25.94'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.94','Manufacture of fasteners and screw machine products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.94.1')
UPDATE [nace] SET activity = 'Manufacture of bolts, rivets, screws, nuts and similar products',lt = null,lu = null WHERE idnace = '25.94.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.94.1','Manufacture of bolts, rivets, screws, nuts and similar products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.99')
UPDATE [nace] SET activity = 'Manufacture of other fabricated metal products n.e.c.',lt = null,lu = null WHERE idnace = '25.99'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.99','Manufacture of other fabricated metal products n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.99.1')
UPDATE [nace] SET activity = 'Manufacture of metal household articles non electrical',lt = null,lu = null WHERE idnace = '25.99.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.99.1','Manufacture of metal household articles non electrical',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '25.99.2')
UPDATE [nace] SET activity = 'Manufacture of products of tinsmithing, coppersmithing and other fabricated metal products n.e.c.',lt = null,lu = null WHERE idnace = '25.99.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('25.99.2','Manufacture of products of tinsmithing, coppersmithing and other fabricated metal products n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26')
UPDATE [nace] SET activity = 'Manufacture of computer, electronic and optical products',lt = null,lu = null WHERE idnace = '26'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26','Manufacture of computer, electronic and optical products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.1')
UPDATE [nace] SET activity = 'Manufacture of electronic components and boards',lt = null,lu = null WHERE idnace = '26.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.1','Manufacture of electronic components and boards',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.11')
UPDATE [nace] SET activity = 'Manufacture of electronic components',lt = null,lu = null WHERE idnace = '26.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.11','Manufacture of electronic components',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.11.1')
UPDATE [nace] SET activity = 'Manufacture of electronic components',lt = null,lu = null WHERE idnace = '26.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.11.1','Manufacture of electronic components',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.11.9')
UPDATE [nace] SET activity = 'Manufacture of other electronic valves and tubes including photovoltaic and electrical heaters',lt = null,lu = null WHERE idnace = '26.11.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.11.9','Manufacture of other electronic valves and tubes including photovoltaic and electrical heaters',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.12')
UPDATE [nace] SET activity = 'Manufacture of loaded electronic boards',lt = null,lu = null WHERE idnace = '26.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.12','Manufacture of loaded electronic boards',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.12.1')
UPDATE [nace] SET activity = 'Manufacture of loaded electronic boards',lt = null,lu = null WHERE idnace = '26.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.12.1','Manufacture of loaded electronic boards',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.2')
UPDATE [nace] SET activity = 'Manufacture of computers and peripheral equipment',lt = null,lu = null WHERE idnace = '26.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.2','Manufacture of computers and peripheral equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.20')
UPDATE [nace] SET activity = 'Manufacture of computers and peripheral equipment',lt = null,lu = null WHERE idnace = '26.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.20','Manufacture of computers and peripheral equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.20.1')
UPDATE [nace] SET activity = 'Manufacture of computers and peripheral equipment',lt = null,lu = null WHERE idnace = '26.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.20.1','Manufacture of computers and peripheral equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.3')
UPDATE [nace] SET activity = 'Manufacture of communication equipment',lt = null,lu = null WHERE idnace = '26.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.3','Manufacture of communication equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.30')
UPDATE [nace] SET activity = 'Manufacture of communication equipment',lt = null,lu = null WHERE idnace = '26.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.30','Manufacture of communication equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.30.1')
UPDATE [nace] SET activity = 'Manufacture of apparatus for line telephony and line telegraphy',lt = null,lu = null WHERE idnace = '26.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.30.1','Manufacture of apparatus for line telephony and line telegraphy',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.4')
UPDATE [nace] SET activity = 'Manufacture of consumer electronics',lt = null,lu = null WHERE idnace = '26.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.4','Manufacture of consumer electronics',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.40')
UPDATE [nace] SET activity = 'Manufacture of consumer electronics',lt = null,lu = null WHERE idnace = '26.40'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.40','Manufacture of consumer electronics',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.40.1')
UPDATE [nace] SET activity = 'Manufacture of consumer electronics',lt = null,lu = null WHERE idnace = '26.40.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.40.1','Manufacture of consumer electronics',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.5')
UPDATE [nace] SET activity = 'Manufacture of measuring, testing, navigating and control equipment; watches and clocks',lt = null,lu = null WHERE idnace = '26.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.5','Manufacture of measuring, testing, navigating and control equipment; watches and clocks',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.51')
UPDATE [nace] SET activity = 'Manufacture of instruments and appliances for measuring, testing and navigation',lt = null,lu = null WHERE idnace = '26.51'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.51','Manufacture of instruments and appliances for measuring, testing and navigation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.51.1')
UPDATE [nace] SET activity = 'Manufacture of instruments and appliances for measuring, testing and navigation',lt = null,lu = null WHERE idnace = '26.51.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.51.1','Manufacture of instruments and appliances for measuring, testing and navigation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.52')
UPDATE [nace] SET activity = 'Manufacture of watches and clocks',lt = null,lu = null WHERE idnace = '26.52'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.52','Manufacture of watches and clocks',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.52.1')
UPDATE [nace] SET activity = 'Manufacture of watches and clocks',lt = null,lu = null WHERE idnace = '26.52.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.52.1','Manufacture of watches and clocks',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.6')
UPDATE [nace] SET activity = 'Manufacture of irradiation, electromedical and electrotherapeutic equipment',lt = null,lu = null WHERE idnace = '26.6'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.6','Manufacture of irradiation, electromedical and electrotherapeutic equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.60')
UPDATE [nace] SET activity = 'Manufacture of irradiation, electromedical and electrotherapeutic equipment',lt = null,lu = null WHERE idnace = '26.60'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.60','Manufacture of irradiation, electromedical and electrotherapeutic equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.60.1')
UPDATE [nace] SET activity = 'Manufacture of irradiation, electromedical and electrotherapeutic equipment',lt = null,lu = null WHERE idnace = '26.60.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.60.1','Manufacture of irradiation, electromedical and electrotherapeutic equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.7')
UPDATE [nace] SET activity = 'Manufacture of optical instruments and equipment',lt = null,lu = null WHERE idnace = '26.7'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.7','Manufacture of optical instruments and equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.70')
UPDATE [nace] SET activity = 'Manufacture of optical instruments and photographic equipment',lt = null,lu = null WHERE idnace = '26.70'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.70','Manufacture of optical instruments and photographic equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.70.1')
UPDATE [nace] SET activity = 'Manufacture of optical instruments and photographic equipment',lt = null,lu = null WHERE idnace = '26.70.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.70.1','Manufacture of optical instruments and photographic equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.8')
UPDATE [nace] SET activity = 'Manufacture of magnetic and optical media',lt = null,lu = null WHERE idnace = '26.8'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.8','Manufacture of magnetic and optical media',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.80')
UPDATE [nace] SET activity = 'Manufacture of magnetic and optical media',lt = null,lu = null WHERE idnace = '26.80'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.80','Manufacture of magnetic and optical media',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '26.80.1')
UPDATE [nace] SET activity = 'Manufacture of magnetic and optical media',lt = null,lu = null WHERE idnace = '26.80.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('26.80.1','Manufacture of magnetic and optical media',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27')
UPDATE [nace] SET activity = 'Manufacture of electrical equipment',lt = null,lu = null WHERE idnace = '27'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27','Manufacture of electrical equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.1')
UPDATE [nace] SET activity = 'Manufacture of electric motors, generators, transformers and electricity distribution and controlapparatus',lt = null,lu = null WHERE idnace = '27.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.1','Manufacture of electric motors, generators, transformers and electricity distribution and controlapparatus',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.11')
UPDATE [nace] SET activity = 'Manufacture of electric motors, generators and transformers',lt = null,lu = null WHERE idnace = '27.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.11','Manufacture of electric motors, generators and transformers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.11.1')
UPDATE [nace] SET activity = 'Manufacture and assembling of electric motors',lt = null,lu = null WHERE idnace = '27.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.11.1','Manufacture and assembling of electric motors',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.11.2')
UPDATE [nace] SET activity = 'Manufacture of generators and electrical transformers',lt = null,lu = null WHERE idnace = '27.11.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.11.2','Manufacture of generators and electrical transformers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.12')
UPDATE [nace] SET activity = 'Manufacture of electricity distribution and control apparatus',lt = null,lu = null WHERE idnace = '27.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.12','Manufacture of electricity distribution and control apparatus',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.12.1')
UPDATE [nace] SET activity = 'Manufacture of distribution and control panels for electric power',lt = null,lu = null WHERE idnace = '27.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.12.1','Manufacture of distribution and control panels for electric power',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.12.2')
UPDATE [nace] SET activity = 'Manufacture of switches, fuses, plugs, sockets and similar apparatus',lt = null,lu = null WHERE idnace = '27.12.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.12.2','Manufacture of switches, fuses, plugs, sockets and similar apparatus',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.2')
UPDATE [nace] SET activity = 'Manufacture of batteries and accumulators',lt = null,lu = null WHERE idnace = '27.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.2','Manufacture of batteries and accumulators',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.20')
UPDATE [nace] SET activity = 'Manufacture of batteries and accumulators',lt = null,lu = null WHERE idnace = '27.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.20','Manufacture of batteries and accumulators',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.20.1')
UPDATE [nace] SET activity = 'Manufacture of batteries and accumulators',lt = null,lu = null WHERE idnace = '27.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.20.1','Manufacture of batteries and accumulators',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.3')
UPDATE [nace] SET activity = 'Manufacture of wiring and wiring devices',lt = null,lu = null WHERE idnace = '27.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.3','Manufacture of wiring and wiring devices',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.31')
UPDATE [nace] SET activity = 'Manufacture of fibre optic cables',lt = null,lu = null WHERE idnace = '27.31'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.31','Manufacture of fibre optic cables',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.31.1')
UPDATE [nace] SET activity = 'Manufacture of fibre optic cables',lt = null,lu = null WHERE idnace = '27.31.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.31.1','Manufacture of fibre optic cables',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.32')
UPDATE [nace] SET activity = 'Manufacture of other electronic and electric wires and cables',lt = null,lu = null WHERE idnace = '27.32'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.32','Manufacture of other electronic and electric wires and cables',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.32.1')
UPDATE [nace] SET activity = 'Manufacture of other electronic and electric wires and cables',lt = null,lu = null WHERE idnace = '27.32.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.32.1','Manufacture of other electronic and electric wires and cables',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.33')
UPDATE [nace] SET activity = 'Manufacture of wiring devices',lt = null,lu = null WHERE idnace = '27.33'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.33','Manufacture of wiring devices',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.33.1')
UPDATE [nace] SET activity = 'Manufacture of wiring devices',lt = null,lu = null WHERE idnace = '27.33.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.33.1','Manufacture of wiring devices',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.4')
UPDATE [nace] SET activity = 'Manufacture of electric lighting equipment',lt = null,lu = null WHERE idnace = '27.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.4','Manufacture of electric lighting equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.40')
UPDATE [nace] SET activity = 'Manufacture of electric lighting equipment',lt = null,lu = null WHERE idnace = '27.40'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.40','Manufacture of electric lighting equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.40.1')
UPDATE [nace] SET activity = 'Manufacture of electric lighting equipment',lt = null,lu = null WHERE idnace = '27.40.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.40.1','Manufacture of electric lighting equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.5')
UPDATE [nace] SET activity = 'Manufacture of domestic appliances',lt = null,lu = null WHERE idnace = '27.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.5','Manufacture of domestic appliances',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.51')
UPDATE [nace] SET activity = 'Manufacture of electric domestic appliances',lt = null,lu = null WHERE idnace = '27.51'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.51','Manufacture of electric domestic appliances',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.51.1')
UPDATE [nace] SET activity = 'Manufacture of electric domestic appliances',lt = null,lu = null WHERE idnace = '27.51.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.51.1','Manufacture of electric domestic appliances',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.52')
UPDATE [nace] SET activity = 'Manufacture of non-electric domestic appliances',lt = null,lu = null WHERE idnace = '27.52'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.52','Manufacture of non-electric domestic appliances',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.52.1')
UPDATE [nace] SET activity = 'Manufacture of non- electric domestic appliances (incl. solar heaters)',lt = null,lu = null WHERE idnace = '27.52.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.52.1','Manufacture of non- electric domestic appliances (incl. solar heaters)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.9')
UPDATE [nace] SET activity = 'Manufacture of other electrical equipment',lt = null,lu = null WHERE idnace = '27.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.9','Manufacture of other electrical equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.90')
UPDATE [nace] SET activity = 'Manufacture of other electrical equipment',lt = null,lu = null WHERE idnace = '27.90'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.90','Manufacture of other electrical equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '27.90.1')
UPDATE [nace] SET activity = 'Manufacture of other electrical equipment',lt = null,lu = null WHERE idnace = '27.90.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('27.90.1','Manufacture of other electrical equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28')
UPDATE [nace] SET activity = 'Manufacture of machinery and equipment n.e.c.',lt = null,lu = null WHERE idnace = '28'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28','Manufacture of machinery and equipment n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.1')
UPDATE [nace] SET activity = 'Manufacture of general - purpose machinery',lt = null,lu = null WHERE idnace = '28.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.1','Manufacture of general - purpose machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.11')
UPDATE [nace] SET activity = 'Manufacture of engines and turbines, except aircraft, vehicle and cycle engines',lt = null,lu = null WHERE idnace = '28.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.11','Manufacture of engines and turbines, except aircraft, vehicle and cycle engines',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.11.1')
UPDATE [nace] SET activity = 'Manufacture of engines and turbines, except aircraft, vehicle and cycle engines',lt = null,lu = null WHERE idnace = '28.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.11.1','Manufacture of engines and turbines, except aircraft, vehicle and cycle engines',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.12')
UPDATE [nace] SET activity = 'Manufacture of fluid power equipment',lt = null,lu = null WHERE idnace = '28.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.12','Manufacture of fluid power equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.12.1')
UPDATE [nace] SET activity = 'Manufacture of fluid power equipment',lt = null,lu = null WHERE idnace = '28.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.12.1','Manufacture of fluid power equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.13')
UPDATE [nace] SET activity = 'Manufacture of other pumps and compressors',lt = null,lu = null WHERE idnace = '28.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.13','Manufacture of other pumps and compressors',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.13.1')
UPDATE [nace] SET activity = 'Manufacture of other pumps and compressors',lt = null,lu = null WHERE idnace = '28.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.13.1','Manufacture of other pumps and compressors',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.14')
UPDATE [nace] SET activity = 'Manufacture of other taps and valves',lt = null,lu = null WHERE idnace = '28.14'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.14','Manufacture of other taps and valves',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.14.1')
UPDATE [nace] SET activity = 'Manufacture of other taps and valves',lt = null,lu = null WHERE idnace = '28.14.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.14.1','Manufacture of other taps and valves',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.15')
UPDATE [nace] SET activity = 'Manufacture of bearings, gears, gearing and driving elements',lt = null,lu = null WHERE idnace = '28.15'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.15','Manufacture of bearings, gears, gearing and driving elements',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.15.1')
UPDATE [nace] SET activity = 'Manufacture of bearings, gears, gearing and driving elements',lt = null,lu = null WHERE idnace = '28.15.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.15.1','Manufacture of bearings, gears, gearing and driving elements',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.2')
UPDATE [nace] SET activity = 'Manufacture of other general-purpose machinery',lt = null,lu = null WHERE idnace = '28.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.2','Manufacture of other general-purpose machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.21')
UPDATE [nace] SET activity = 'Manufacture of ovens, furnaces and furnace burners',lt = null,lu = null WHERE idnace = '28.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.21','Manufacture of ovens, furnaces and furnace burners',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.21.1')
UPDATE [nace] SET activity = 'Manufacture of ovens, furnaces and furnace burners',lt = null,lu = null WHERE idnace = '28.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.21.1','Manufacture of ovens, furnaces and furnace burners',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.22')
UPDATE [nace] SET activity = 'Manufacture of lifting and handling equipment',lt = null,lu = null WHERE idnace = '28.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.22','Manufacture of lifting and handling equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.22.1')
UPDATE [nace] SET activity = 'Manufacture of lifting and handling equipment',lt = null,lu = null WHERE idnace = '28.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.22.1','Manufacture of lifting and handling equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.23')
UPDATE [nace] SET activity = 'Manufacture of office machinery and equipment (except computers and peripheral equipment)',lt = null,lu = null WHERE idnace = '28.23'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.23','Manufacture of office machinery and equipment (except computers and peripheral equipment)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.23.1')
UPDATE [nace] SET activity = 'Manufacture of office machinery and equipment (except computers and peripheral equipment)',lt = null,lu = null WHERE idnace = '28.23.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.23.1','Manufacture of office machinery and equipment (except computers and peripheral equipment)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.24')
UPDATE [nace] SET activity = 'Manufacture of power-driven hand tools',lt = null,lu = null WHERE idnace = '28.24'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.24','Manufacture of power-driven hand tools',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.24.1')
UPDATE [nace] SET activity = 'Manufacture of power-driven hand tools',lt = null,lu = null WHERE idnace = '28.24.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.24.1','Manufacture of power-driven hand tools',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.25')
UPDATE [nace] SET activity = 'Manufacture of non-domestic cooling and ventilation equipment',lt = null,lu = null WHERE idnace = '28.25'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.25','Manufacture of non-domestic cooling and ventilation equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.25.1')
UPDATE [nace] SET activity = 'Manufacture of non- domestic cooling and ventilation equipment',lt = null,lu = null WHERE idnace = '28.25.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.25.1','Manufacture of non- domestic cooling and ventilation equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.29')
UPDATE [nace] SET activity = 'Manufacture of other general-purpose machinery n.e.c.',lt = null,lu = null WHERE idnace = '28.29'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.29','Manufacture of other general-purpose machinery n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.29.1')
UPDATE [nace] SET activity = 'Manufacture of other general purpose machinery n.e.c.',lt = null,lu = null WHERE idnace = '28.29.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.29.1','Manufacture of other general purpose machinery n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.3')
UPDATE [nace] SET activity = 'Manufacture of agricultural and forestry machinery',lt = null,lu = null WHERE idnace = '28.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.3','Manufacture of agricultural and forestry machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.30')
UPDATE [nace] SET activity = 'Manufacture of agricultural and forestry machinery',lt = null,lu = null WHERE idnace = '28.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.30','Manufacture of agricultural and forestry machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.30.1')
UPDATE [nace] SET activity = 'Manufacture of agricultural tractors',lt = null,lu = null WHERE idnace = '28.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.30.1','Manufacture of agricultural tractors',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.30.2')
UPDATE [nace] SET activity = 'Manufacture of agricultural and forestry machinery',lt = null,lu = null WHERE idnace = '28.30.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.30.2','Manufacture of agricultural and forestry machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.4')
UPDATE [nace] SET activity = 'Manufacture of metal forming machinery and machine tools',lt = null,lu = null WHERE idnace = '28.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.4','Manufacture of metal forming machinery and machine tools',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.41')
UPDATE [nace] SET activity = 'Manufacture of metal forming machinery',lt = null,lu = null WHERE idnace = '28.41'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.41','Manufacture of metal forming machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.41.1')
UPDATE [nace] SET activity = 'Manufacture of machine tools for working metals',lt = null,lu = null WHERE idnace = '28.41.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.41.1','Manufacture of machine tools for working metals',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.49')
UPDATE [nace] SET activity = 'Manufacture of other machine tools',lt = null,lu = null WHERE idnace = '28.49'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.49','Manufacture of other machine tools',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.49.1')
UPDATE [nace] SET activity = 'Manufacture of other machine tools',lt = null,lu = null WHERE idnace = '28.49.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.49.1','Manufacture of other machine tools',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.9')
UPDATE [nace] SET activity = 'Manufacture of other special-purpose machinery',lt = null,lu = null WHERE idnace = '28.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.9','Manufacture of other special-purpose machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.91')
UPDATE [nace] SET activity = 'Manufacture of machinery for metallurgy',lt = null,lu = null WHERE idnace = '28.91'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.91','Manufacture of machinery for metallurgy',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.91.1')
UPDATE [nace] SET activity = 'Manufacture of machinery for metallurgy',lt = null,lu = null WHERE idnace = '28.91.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.91.1','Manufacture of machinery for metallurgy',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.92')
UPDATE [nace] SET activity = 'Manufacture of machinery for mining, quarrying and construction',lt = null,lu = null WHERE idnace = '28.92'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.92','Manufacture of machinery for mining, quarrying and construction',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.92.1')
UPDATE [nace] SET activity = 'Manufacture of machinery for mining, quarrying and construction',lt = null,lu = null WHERE idnace = '28.92.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.92.1','Manufacture of machinery for mining, quarrying and construction',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.93')
UPDATE [nace] SET activity = 'Manufacture of machinery for food, beverage and tobacco processing',lt = null,lu = null WHERE idnace = '28.93'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.93','Manufacture of machinery for food, beverage and tobacco processing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.93.1')
UPDATE [nace] SET activity = 'Manufacture of machinery for food, beverage and tobacco processing',lt = null,lu = null WHERE idnace = '28.93.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.93.1','Manufacture of machinery for food, beverage and tobacco processing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.94')
UPDATE [nace] SET activity = 'Manufacture of machinery for textile, apparel and leather production',lt = null,lu = null WHERE idnace = '28.94'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.94','Manufacture of machinery for textile, apparel and leather production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.94.1')
UPDATE [nace] SET activity = 'Manufacture of machinery for textile, apparel and leather production',lt = null,lu = null WHERE idnace = '28.94.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.94.1','Manufacture of machinery for textile, apparel and leather production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.95')
UPDATE [nace] SET activity = 'Manufacture of machinery for paper and paperboard production',lt = null,lu = null WHERE idnace = '28.95'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.95','Manufacture of machinery for paper and paperboard production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.95.1')
UPDATE [nace] SET activity = 'Manufacture of machinery for paper and paperboard production',lt = null,lu = null WHERE idnace = '28.95.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.95.1','Manufacture of machinery for paper and paperboard production',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.96')
UPDATE [nace] SET activity = 'Manufacture of plastic and rubber machinery',lt = null,lu = null WHERE idnace = '28.96'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.96','Manufacture of plastic and rubber machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.96.1')
UPDATE [nace] SET activity = 'Manufacture of plastics and rubber machinery',lt = null,lu = null WHERE idnace = '28.96.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.96.1','Manufacture of plastics and rubber machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.99')
UPDATE [nace] SET activity = 'Manufacture of other special-purpose machinery n.e.c.',lt = null,lu = null WHERE idnace = '28.99'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.99','Manufacture of other special-purpose machinery n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '28.99.1')
UPDATE [nace] SET activity = 'Manufacture of other special purpose machinery n.e.c.',lt = null,lu = null WHERE idnace = '28.99.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('28.99.1','Manufacture of other special purpose machinery n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29')
UPDATE [nace] SET activity = 'Manufacture of motor vehicles, trailers and semi-trailers',lt = null,lu = null WHERE idnace = '29'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29','Manufacture of motor vehicles, trailers and semi-trailers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.1')
UPDATE [nace] SET activity = 'Manufacture of motor vehicles',lt = null,lu = null WHERE idnace = '29.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.1','Manufacture of motor vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.10')
UPDATE [nace] SET activity = 'Manufacture of motor vehicles',lt = null,lu = null WHERE idnace = '29.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.10','Manufacture of motor vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.10.1')
UPDATE [nace] SET activity = 'Manufacture of motor vehicles',lt = null,lu = null WHERE idnace = '29.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.10.1','Manufacture of motor vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.2')
UPDATE [nace] SET activity = 'Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers',lt = null,lu = null WHERE idnace = '29.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.2','Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.20')
UPDATE [nace] SET activity = 'Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers',lt = null,lu = null WHERE idnace = '29.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.20','Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.20.1')
UPDATE [nace] SET activity = 'Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers',lt = null,lu = null WHERE idnace = '29.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.20.1','Manufacture of bodies (coachwork) for motor vehicles; manufacture of trailers and semi-trailers',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.3')
UPDATE [nace] SET activity = 'Manufacture of parts and accessories for motor vehicles',lt = null,lu = null WHERE idnace = '29.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.3','Manufacture of parts and accessories for motor vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.31')
UPDATE [nace] SET activity = 'Manufacture of electrical and electronic equipment for motor vehicles',lt = null,lu = null WHERE idnace = '29.31'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.31','Manufacture of electrical and electronic equipment for motor vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.31.1')
UPDATE [nace] SET activity = 'Manufacture of electrical and electronic equipment for motor vehicles',lt = null,lu = null WHERE idnace = '29.31.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.31.1','Manufacture of electrical and electronic equipment for motor vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.32')
UPDATE [nace] SET activity = 'Manufacture of other parts and accessories for motor vehicles',lt = null,lu = null WHERE idnace = '29.32'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.32','Manufacture of other parts and accessories for motor vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '29.32.1')
UPDATE [nace] SET activity = 'Manufacture of other parts and accessories for motor vehicles',lt = null,lu = null WHERE idnace = '29.32.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('29.32.1','Manufacture of other parts and accessories for motor vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30')
UPDATE [nace] SET activity = 'Manufacture of other transport equipment',lt = null,lu = null WHERE idnace = '30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30','Manufacture of other transport equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.1')
UPDATE [nace] SET activity = 'Building of ships and boats',lt = null,lu = null WHERE idnace = '30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.1','Building of ships and boats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.11')
UPDATE [nace] SET activity = 'Building of ships and floating structures',lt = null,lu = null WHERE idnace = '30.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.11','Building of ships and floating structures',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.11.1')
UPDATE [nace] SET activity = 'Building of ships and floating structures',lt = null,lu = null WHERE idnace = '30.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.11.1','Building of ships and floating structures',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.12')
UPDATE [nace] SET activity = 'Building of pleasure and sporting boats',lt = null,lu = null WHERE idnace = '30.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.12','Building of pleasure and sporting boats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.12.1')
UPDATE [nace] SET activity = 'Building of pleasure and sporting boats',lt = null,lu = null WHERE idnace = '30.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.12.1','Building of pleasure and sporting boats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.2')
UPDATE [nace] SET activity = 'Manufacture of railway locomotives and rolling stock',lt = null,lu = null WHERE idnace = '30.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.2','Manufacture of railway locomotives and rolling stock',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.20')
UPDATE [nace] SET activity = 'Manufacture of railway locomotives and rolling stock',lt = null,lu = null WHERE idnace = '30.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.20','Manufacture of railway locomotives and rolling stock',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.20.1')
UPDATE [nace] SET activity = 'Manufacture of railway locomotives and rolling stock',lt = null,lu = null WHERE idnace = '30.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.20.1','Manufacture of railway locomotives and rolling stock',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.3')
UPDATE [nace] SET activity = 'Manufacture of air and spacecraft and related machinery',lt = null,lu = null WHERE idnace = '30.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.3','Manufacture of air and spacecraft and related machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.30')
UPDATE [nace] SET activity = 'Manufacture of air and spacecraft and related machinery',lt = null,lu = null WHERE idnace = '30.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.30','Manufacture of air and spacecraft and related machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.30.1')
UPDATE [nace] SET activity = 'Manufacture of air and spacecraft and related machinery',lt = null,lu = null WHERE idnace = '30.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.30.1','Manufacture of air and spacecraft and related machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.4')
UPDATE [nace] SET activity = 'Manufacture of military fighting vehicles',lt = null,lu = null WHERE idnace = '30.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.4','Manufacture of military fighting vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.40')
UPDATE [nace] SET activity = 'Manufacture of military fighting vehicles',lt = null,lu = null WHERE idnace = '30.40'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.40','Manufacture of military fighting vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.40.1')
UPDATE [nace] SET activity = 'Manufacture of military fighting vehicles',lt = null,lu = null WHERE idnace = '30.40.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.40.1','Manufacture of military fighting vehicles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.9')
UPDATE [nace] SET activity = 'Manufacture of transport equipment n.e.c.',lt = null,lu = null WHERE idnace = '30.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.9','Manufacture of transport equipment n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.91')
UPDATE [nace] SET activity = 'Manufacture of motorcycles',lt = null,lu = null WHERE idnace = '30.91'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.91','Manufacture of motorcycles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.91.1')
UPDATE [nace] SET activity = 'Manufacture of motorcycles',lt = null,lu = null WHERE idnace = '30.91.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.91.1','Manufacture of motorcycles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.92')
UPDATE [nace] SET activity = 'Manufacture of bicycles and invalid carriages',lt = null,lu = null WHERE idnace = '30.92'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.92','Manufacture of bicycles and invalid carriages',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.92.1')
UPDATE [nace] SET activity = 'Manufacture of bicycles',lt = null,lu = null WHERE idnace = '30.92.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.92.1','Manufacture of bicycles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.92.2')
UPDATE [nace] SET activity = 'Manufacture of invalid and baby carriages',lt = null,lu = null WHERE idnace = '30.92.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.92.2','Manufacture of invalid and baby carriages',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.99')
UPDATE [nace] SET activity = 'Manufacture of other transport equipment n.e.c.',lt = null,lu = null WHERE idnace = '30.99'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.99','Manufacture of other transport equipment n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '30.99.1')
UPDATE [nace] SET activity = 'Manufacture of other transport equipment n.e.c.',lt = null,lu = null WHERE idnace = '30.99.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('30.99.1','Manufacture of other transport equipment n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31')
UPDATE [nace] SET activity = 'Manufacture of furniture',lt = null,lu = null WHERE idnace = '31'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31','Manufacture of furniture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.0')
UPDATE [nace] SET activity = 'Manufacture of furniture',lt = null,lu = null WHERE idnace = '31.0'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.0','Manufacture of furniture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.01')
UPDATE [nace] SET activity = 'Manufacture of office and shop furniture',lt = null,lu = null WHERE idnace = '31.01'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.01','Manufacture of office and shop furniture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.01.1')
UPDATE [nace] SET activity = 'Manufacture of furniture for offices, shops, churches, schools,restaurants',lt = null,lu = null WHERE idnace = '31.01.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.01.1','Manufacture of furniture for offices, shops, churches, schools,restaurants',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.01.2')
UPDATE [nace] SET activity = 'Manufacture of chairs and seats (of any material ) except car seats, aircraft seats and railway car seats',lt = null,lu = null WHERE idnace = '31.01.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.01.2','Manufacture of chairs and seats (of any material ) except car seats, aircraft seats and railway car seats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.02')
UPDATE [nace] SET activity = 'Manufacture of kitchen furniture',lt = null,lu = null WHERE idnace = '31.02'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.02','Manufacture of kitchen furniture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.02.1')
UPDATE [nace] SET activity = 'Manufacture of kitchen furniture',lt = null,lu = null WHERE idnace = '31.02.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.02.1','Manufacture of kitchen furniture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.03')
UPDATE [nace] SET activity = 'Manufacture of mattresses',lt = null,lu = null WHERE idnace = '31.03'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.03','Manufacture of mattresses',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.03.1')
UPDATE [nace] SET activity = 'Manufacture of mattresses and mattresses supports',lt = null,lu = null WHERE idnace = '31.03.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.03.1','Manufacture of mattresses and mattresses supports',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.09')
UPDATE [nace] SET activity = 'Manufacture of other furniture',lt = null,lu = null WHERE idnace = '31.09'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.09','Manufacture of other furniture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.09.1')
UPDATE [nace] SET activity = 'Manufacture of wooden furniture',lt = null,lu = null WHERE idnace = '31.09.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.09.1','Manufacture of wooden furniture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.09.2')
UPDATE [nace] SET activity = 'Manufacture of metal furniture',lt = null,lu = null WHERE idnace = '31.09.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.09.2','Manufacture of metal furniture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.09.3')
UPDATE [nace] SET activity = 'Manufacture of furniture from other materials',lt = null,lu = null WHERE idnace = '31.09.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.09.3','Manufacture of furniture from other materials',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.09.4')
UPDATE [nace] SET activity = 'Upholstery of furniture (except of car seats)',lt = null,lu = null WHERE idnace = '31.09.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.09.4','Upholstery of furniture (except of car seats)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '31.09.5')
UPDATE [nace] SET activity = 'Painting and polishing of furniture',lt = null,lu = null WHERE idnace = '31.09.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('31.09.5','Painting and polishing of furniture',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32')
UPDATE [nace] SET activity = 'Other manufacturing',lt = null,lu = null WHERE idnace = '32'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32','Other manufacturing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.1')
UPDATE [nace] SET activity = 'Manufacture of jewellery, bijouterie and related articles',lt = null,lu = null WHERE idnace = '32.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.1','Manufacture of jewellery, bijouterie and related articles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.11')
UPDATE [nace] SET activity = 'Striking of coins',lt = null,lu = null WHERE idnace = '32.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.11','Striking of coins',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.11.1')
UPDATE [nace] SET activity = 'Striking of coins',lt = null,lu = null WHERE idnace = '32.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.11.1','Striking of coins',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.12')
UPDATE [nace] SET activity = 'Manufacture of jewellery and related articles',lt = null,lu = null WHERE idnace = '32.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.12','Manufacture of jewellery and related articles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.12.1')
UPDATE [nace] SET activity = 'Goldsmithing, silversmithing and working of precious and semi-precious stones',lt = null,lu = null WHERE idnace = '32.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.12.1','Goldsmithing, silversmithing and working of precious and semi-precious stones',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.13')
UPDATE [nace] SET activity = 'Manufacture of imitation jewellery and related articles',lt = null,lu = null WHERE idnace = '32.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.13','Manufacture of imitation jewellery and related articles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.13.1')
UPDATE [nace] SET activity = 'Manufacture of imitation jewellery and related articles',lt = null,lu = null WHERE idnace = '32.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.13.1','Manufacture of imitation jewellery and related articles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.2')
UPDATE [nace] SET activity = 'Manufacture of musical instruments',lt = null,lu = null WHERE idnace = '32.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.2','Manufacture of musical instruments',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.20')
UPDATE [nace] SET activity = 'Manufacture of musical instruments',lt = null,lu = null WHERE idnace = '32.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.20','Manufacture of musical instruments',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.20.1')
UPDATE [nace] SET activity = 'Manufacture of musical instruments',lt = null,lu = null WHERE idnace = '32.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.20.1','Manufacture of musical instruments',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.3')
UPDATE [nace] SET activity = 'Manufacture of sports goods',lt = null,lu = null WHERE idnace = '32.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.3','Manufacture of sports goods',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.30')
UPDATE [nace] SET activity = 'Manufacture of sports goods',lt = null,lu = null WHERE idnace = '32.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.30','Manufacture of sports goods',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.30.1')
UPDATE [nace] SET activity = 'Manufacture of sports goods',lt = null,lu = null WHERE idnace = '32.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.30.1','Manufacture of sports goods',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.4')
UPDATE [nace] SET activity = 'Manufacture of games and toys',lt = null,lu = null WHERE idnace = '32.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.4','Manufacture of games and toys',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.40')
UPDATE [nace] SET activity = 'Manufacture of games and toys',lt = null,lu = null WHERE idnace = '32.40'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.40','Manufacture of games and toys',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.40.1')
UPDATE [nace] SET activity = 'Manufacture of games and toys',lt = null,lu = null WHERE idnace = '32.40.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.40.1','Manufacture of games and toys',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.5')
UPDATE [nace] SET activity = 'Manufacture of medical and dental instruments and supplies',lt = null,lu = null WHERE idnace = '32.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.5','Manufacture of medical and dental instruments and supplies',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.50')
UPDATE [nace] SET activity = 'Manufacture of medical and dental instruments and supplies',lt = null,lu = null WHERE idnace = '32.50'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.50','Manufacture of medical and dental instruments and supplies',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.50.1')
UPDATE [nace] SET activity = 'Manufacture of artificial teeth, bridges, etc.',lt = null,lu = null WHERE idnace = '32.50.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.50.1','Manufacture of artificial teeth, bridges, etc.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.50.2')
UPDATE [nace] SET activity = 'Manufacture of medical and dental instruments and supplies',lt = null,lu = null WHERE idnace = '32.50.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.50.2','Manufacture of medical and dental instruments and supplies',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.50.3')
UPDATE [nace] SET activity = 'Manufacture of spectacle lenses and contact lenses',lt = null,lu = null WHERE idnace = '32.50.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.50.3','Manufacture of spectacle lenses and contact lenses',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.9')
UPDATE [nace] SET activity = 'Other manufacturing n.e.c.',lt = null,lu = null WHERE idnace = '32.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.9','Other manufacturing n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.91')
UPDATE [nace] SET activity = 'Manufacture of brooms and brushes',lt = null,lu = null WHERE idnace = '32.91'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.91','Manufacture of brooms and brushes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.91.1')
UPDATE [nace] SET activity = 'Manufacture of brooms and brushes',lt = null,lu = null WHERE idnace = '32.91.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.91.1','Manufacture of brooms and brushes',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.99')
UPDATE [nace] SET activity = 'Other manufacturing n.e.c.',lt = null,lu = null WHERE idnace = '32.99'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.99','Other manufacturing n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.99.1')
UPDATE [nace] SET activity = '?anufacture of pens, pencils, stamp pads, etc.',lt = null,lu = null WHERE idnace = '32.99.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.99.1','?anufacture of pens, pencils, stamp pads, etc.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.99.2')
UPDATE [nace] SET activity = 'Manufacture of umbrellas, buttons, fasteners and their parts',lt = null,lu = null WHERE idnace = '32.99.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.99.2','Manufacture of umbrellas, buttons, fasteners and their parts',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.99.3')
UPDATE [nace] SET activity = 'Manufacture of candles',lt = null,lu = null WHERE idnace = '32.99.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.99.3','Manufacture of candles',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.99.4')
UPDATE [nace] SET activity = 'Manufacture of burial coffins',lt = null,lu = null WHERE idnace = '32.99.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.99.4','Manufacture of burial coffins',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '32.99.5')
UPDATE [nace] SET activity = 'Other manufacturing n.e.c.',lt = null,lu = null WHERE idnace = '32.99.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('32.99.5','Other manufacturing n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33')
UPDATE [nace] SET activity = 'Repair and installation of machinery and equipment',lt = null,lu = null WHERE idnace = '33'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33','Repair and installation of machinery and equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.1')
UPDATE [nace] SET activity = 'Repair of fabricated metal products, machinery and equipment',lt = null,lu = null WHERE idnace = '33.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.1','Repair of fabricated metal products, machinery and equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.11')
UPDATE [nace] SET activity = 'Repair of fabricated metal products',lt = null,lu = null WHERE idnace = '33.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.11','Repair of fabricated metal products',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.11.1')
UPDATE [nace] SET activity = 'Repair of fabricated metal products of division 25',lt = null,lu = null WHERE idnace = '33.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.11.1','Repair of fabricated metal products of division 25',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.11.2')
UPDATE [nace] SET activity = 'Installation, maintenance and repair services of weapons and weapons systems (including sporting guns)',lt = null,lu = null WHERE idnace = '33.11.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.11.2','Installation, maintenance and repair services of weapons and weapons systems (including sporting guns)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.12')
UPDATE [nace] SET activity = 'Repair of machinery',lt = null,lu = null WHERE idnace = '33.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.12','Repair of machinery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.12.1')
UPDATE [nace] SET activity = 'Repair of machinery, mainly of division 28',lt = null,lu = null WHERE idnace = '33.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.12.1','Repair of machinery, mainly of division 28',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.13')
UPDATE [nace] SET activity = 'Repair of electronic and optical equipment',lt = null,lu = null WHERE idnace = '33.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.13','Repair of electronic and optical equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.13.1')
UPDATE [nace] SET activity = 'Repair of electronic and optical equipment',lt = null,lu = null WHERE idnace = '33.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.13.1','Repair of electronic and optical equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.14')
UPDATE [nace] SET activity = 'Repair of electrical equipment',lt = null,lu = null WHERE idnace = '33.14'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.14','Repair of electrical equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.14.1')
UPDATE [nace] SET activity = 'Repair of electrical equipment',lt = null,lu = null WHERE idnace = '33.14.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.14.1','Repair of electrical equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.15')
UPDATE [nace] SET activity = 'Repair and maintenance of ships and boats',lt = null,lu = null WHERE idnace = '33.15'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.15','Repair and maintenance of ships and boats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.15.1')
UPDATE [nace] SET activity = 'Repair and maintenance of ships and boats',lt = null,lu = null WHERE idnace = '33.15.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.15.1','Repair and maintenance of ships and boats',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.16')
UPDATE [nace] SET activity = 'Repair and maintenance of aircraft and spacecraft',lt = null,lu = null WHERE idnace = '33.16'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.16','Repair and maintenance of aircraft and spacecraft',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.16.1')
UPDATE [nace] SET activity = 'Repair and maintenance of aircraft and spacecraft',lt = null,lu = null WHERE idnace = '33.16.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.16.1','Repair and maintenance of aircraft and spacecraft',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.17')
UPDATE [nace] SET activity = 'Repair and maintenance of other transport equipment',lt = null,lu = null WHERE idnace = '33.17'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.17','Repair and maintenance of other transport equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.17.1')
UPDATE [nace] SET activity = 'Repair and maintenance of other transport equipment',lt = null,lu = null WHERE idnace = '33.17.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.17.1','Repair and maintenance of other transport equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.19')
UPDATE [nace] SET activity = 'Repair of other equipment',lt = null,lu = null WHERE idnace = '33.19'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.19','Repair of other equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.19.1')
UPDATE [nace] SET activity = 'Repair of other equipment (e.g. fishing nets, ropes, etc.)',lt = null,lu = null WHERE idnace = '33.19.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.19.1','Repair of other equipment (e.g. fishing nets, ropes, etc.)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.2')
UPDATE [nace] SET activity = 'Installation of industrial machinery and equipment',lt = null,lu = null WHERE idnace = '33.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.2','Installation of industrial machinery and equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.20')
UPDATE [nace] SET activity = 'Installation of industrial machinery and equipment',lt = null,lu = null WHERE idnace = '33.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.20','Installation of industrial machinery and equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '33.20.1')
UPDATE [nace] SET activity = 'Installation of industrial machinery and equipment',lt = null,lu = null WHERE idnace = '33.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('33.20.1','Installation of industrial machinery and equipment',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35')
UPDATE [nace] SET activity = 'Electricity, gas, steam and air conditioning supply',lt = null,lu = null WHERE idnace = '35'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35','Electricity, gas, steam and air conditioning supply',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.1')
UPDATE [nace] SET activity = 'Electric power generation, transmission and distribution',lt = null,lu = null WHERE idnace = '35.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.1','Electric power generation, transmission and distribution',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.11')
UPDATE [nace] SET activity = 'Production of electricity',lt = null,lu = null WHERE idnace = '35.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.11','Production of electricity',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.11.1')
UPDATE [nace] SET activity = 'Production of electricity',lt = null,lu = null WHERE idnace = '35.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.11.1','Production of electricity',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.12')
UPDATE [nace] SET activity = 'Transmission of electricity',lt = null,lu = null WHERE idnace = '35.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.12','Transmission of electricity',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.12.1')
UPDATE [nace] SET activity = 'Transmission of electricity',lt = null,lu = null WHERE idnace = '35.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.12.1','Transmission of electricity',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.13')
UPDATE [nace] SET activity = 'Distribution of electricity',lt = null,lu = null WHERE idnace = '35.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.13','Distribution of electricity',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.13.1')
UPDATE [nace] SET activity = 'Distribution of electricity',lt = null,lu = null WHERE idnace = '35.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.13.1','Distribution of electricity',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.14')
UPDATE [nace] SET activity = 'Trade of electricity',lt = null,lu = null WHERE idnace = '35.14'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.14','Trade of electricity',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.14.1')
UPDATE [nace] SET activity = 'Trade of electricity',lt = null,lu = null WHERE idnace = '35.14.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.14.1','Trade of electricity',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.2')
UPDATE [nace] SET activity = 'Manufacture of gas; distribution of gaseous fuels through mains',lt = null,lu = null WHERE idnace = '35.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.2','Manufacture of gas; distribution of gaseous fuels through mains',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.21')
UPDATE [nace] SET activity = 'Manufacture of gas',lt = null,lu = null WHERE idnace = '35.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.21','Manufacture of gas',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.21.1')
UPDATE [nace] SET activity = 'Manufacture of gas',lt = null,lu = null WHERE idnace = '35.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.21.1','Manufacture of gas',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.22')
UPDATE [nace] SET activity = 'Distribution of gaseous fuels through mains',lt = null,lu = null WHERE idnace = '35.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.22','Distribution of gaseous fuels through mains',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.22.1')
UPDATE [nace] SET activity = 'Distribution of gaseous fuels through mains',lt = null,lu = null WHERE idnace = '35.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.22.1','Distribution of gaseous fuels through mains',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.23')
UPDATE [nace] SET activity = 'Trade of gas through mains',lt = null,lu = null WHERE idnace = '35.23'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.23','Trade of gas through mains',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.23.1')
UPDATE [nace] SET activity = 'Trade of gaseous fuels through mains',lt = null,lu = null WHERE idnace = '35.23.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.23.1','Trade of gaseous fuels through mains',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.3')
UPDATE [nace] SET activity = 'Steam and air conditioning supply',lt = null,lu = null WHERE idnace = '35.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.3','Steam and air conditioning supply',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.30')
UPDATE [nace] SET activity = 'Steam and air conditioning supply',lt = null,lu = null WHERE idnace = '35.30'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.30','Steam and air conditioning supply',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.30.1')
UPDATE [nace] SET activity = 'Steam and air conditioning supply',lt = null,lu = null WHERE idnace = '35.30.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.30.1','Steam and air conditioning supply',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '35.30.2')
UPDATE [nace] SET activity = 'Manufacture of edible and non edible ice',lt = null,lu = null WHERE idnace = '35.30.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('35.30.2','Manufacture of edible and non edible ice',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '36')
UPDATE [nace] SET activity = 'Water collection, treatment and supply',lt = null,lu = null WHERE idnace = '36'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('36','Water collection, treatment and supply',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '36.0')
UPDATE [nace] SET activity = 'Water collection, treatment and supply',lt = null,lu = null WHERE idnace = '36.0'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('36.0','Water collection, treatment and supply',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '36.00')
UPDATE [nace] SET activity = 'Water collection, treatment and supply',lt = null,lu = null WHERE idnace = '36.00'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('36.00','Water collection, treatment and supply',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '36.00.1')
UPDATE [nace] SET activity = 'Collection and distribution of water',lt = null,lu = null WHERE idnace = '36.00.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('36.00.1','Collection and distribution of water',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '36.00.2')
UPDATE [nace] SET activity = 'Purification of water',lt = null,lu = null WHERE idnace = '36.00.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('36.00.2','Purification of water',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '36.00.3')
UPDATE [nace] SET activity = 'Desalting of sea water',lt = null,lu = null WHERE idnace = '36.00.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('36.00.3','Desalting of sea water',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '37')
UPDATE [nace] SET activity = 'Sewerage',lt = null,lu = null WHERE idnace = '37'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('37','Sewerage',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '37.0')
UPDATE [nace] SET activity = 'Sewerage',lt = null,lu = null WHERE idnace = '37.0'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('37.0','Sewerage',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '37.00')
UPDATE [nace] SET activity = 'Sewerage',lt = null,lu = null WHERE idnace = '37.00'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('37.00','Sewerage',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '37.00.1')
UPDATE [nace] SET activity = 'Sewage disposal boards',lt = null,lu = null WHERE idnace = '37.00.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('37.00.1','Sewage disposal boards',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '37.00.2')
UPDATE [nace] SET activity = 'Operation of sewage plant stations',lt = null,lu = null WHERE idnace = '37.00.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('37.00.2','Operation of sewage plant stations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '37.00.3')
UPDATE [nace] SET activity = 'Cesspool cleaning activities',lt = null,lu = null WHERE idnace = '37.00.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('37.00.3','Cesspool cleaning activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38')
UPDATE [nace] SET activity = 'Waste collection, treatment and disposal activities; materials recovery',lt = null,lu = null WHERE idnace = '38'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38','Waste collection, treatment and disposal activities; materials recovery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.1')
UPDATE [nace] SET activity = 'Waste collection',lt = null,lu = null WHERE idnace = '38.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.1','Waste collection',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.11')
UPDATE [nace] SET activity = 'Collection of non-hazardous waste',lt = null,lu = null WHERE idnace = '38.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.11','Collection of non-hazardous waste',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.11.1')
UPDATE [nace] SET activity = 'Refuse collection and disposal services of local authorities (e.g municipalities)',lt = null,lu = null WHERE idnace = '38.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.11.1','Refuse collection and disposal services of local authorities (e.g municipalities)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.11.2')
UPDATE [nace] SET activity = 'Private refuse collection and disposal services',lt = null,lu = null WHERE idnace = '38.11.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.11.2','Private refuse collection and disposal services',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.12')
UPDATE [nace] SET activity = 'Collection of hazardous waste',lt = null,lu = null WHERE idnace = '38.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.12','Collection of hazardous waste',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.12.1')
UPDATE [nace] SET activity = 'Collection of hazardous waste',lt = null,lu = null WHERE idnace = '38.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.12.1','Collection of hazardous waste',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.2')
UPDATE [nace] SET activity = 'Waste treatment and disposal',lt = null,lu = null WHERE idnace = '38.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.2','Waste treatment and disposal',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.21')
UPDATE [nace] SET activity = 'Treatment and disposal of non-hazardous waste',lt = null,lu = null WHERE idnace = '38.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.21','Treatment and disposal of non-hazardous waste',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.21.1')
UPDATE [nace] SET activity = 'Treatment and disposal of non- hazardous waste',lt = null,lu = null WHERE idnace = '38.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.21.1','Treatment and disposal of non- hazardous waste',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.22')
UPDATE [nace] SET activity = 'Treatment and disposal of hazardous waste',lt = null,lu = null WHERE idnace = '38.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.22','Treatment and disposal of hazardous waste',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.22.1')
UPDATE [nace] SET activity = 'Treatment and disposal of hazardous waste',lt = null,lu = null WHERE idnace = '38.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.22.1','Treatment and disposal of hazardous waste',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.3')
UPDATE [nace] SET activity = 'Materials recovery',lt = null,lu = null WHERE idnace = '38.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.3','Materials recovery',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.31')
UPDATE [nace] SET activity = 'Dismantling of wrecks',lt = null,lu = null WHERE idnace = '38.31'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.31','Dismantling of wrecks',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.31.1')
UPDATE [nace] SET activity = 'Dismantling of wrecks',lt = null,lu = null WHERE idnace = '38.31.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.31.1','Dismantling of wrecks',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.31.2')
UPDATE [nace] SET activity = 'Shipbreaking',lt = null,lu = null WHERE idnace = '38.31.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.31.2','Shipbreaking',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.32')
UPDATE [nace] SET activity = 'Recovery of sorted materials',lt = null,lu = null WHERE idnace = '38.32'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.32','Recovery of sorted materials',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '38.32.1')
UPDATE [nace] SET activity = 'Recycling of metal and non-metal waste and scrap',lt = null,lu = null WHERE idnace = '38.32.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('38.32.1','Recycling of metal and non-metal waste and scrap',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '39')
UPDATE [nace] SET activity = 'Remediation activities and other waste management services',lt = null,lu = null WHERE idnace = '39'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('39','Remediation activities and other waste management services',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '39.0')
UPDATE [nace] SET activity = 'Remediation activities and other waste management services',lt = null,lu = null WHERE idnace = '39.0'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('39.0','Remediation activities and other waste management services',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '39.00')
UPDATE [nace] SET activity = 'Remediation activities and other waste management services',lt = null,lu = null WHERE idnace = '39.00'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('39.00','Remediation activities and other waste management services',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '39.00.1')
UPDATE [nace] SET activity = 'Sanitary services of local authorities',lt = null,lu = null WHERE idnace = '39.00.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('39.00.1','Sanitary services of local authorities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '39.00.2')
UPDATE [nace] SET activity = 'Remediation activities and other waste management services n.e.c.',lt = null,lu = null WHERE idnace = '39.00.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('39.00.2','Remediation activities and other waste management services n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '41')
UPDATE [nace] SET activity = 'Construction of buildings',lt = null,lu = null WHERE idnace = '41'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('41','Construction of buildings',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '41.1')
UPDATE [nace] SET activity = 'Development of building projects',lt = null,lu = null WHERE idnace = '41.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('41.1','Development of building projects',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '41.10')
UPDATE [nace] SET activity = 'Development of building projects',lt = null,lu = null WHERE idnace = '41.10'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('41.10','Development of building projects',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '41.10.1')
UPDATE [nace] SET activity = 'Land Development Corporation',lt = null,lu = null WHERE idnace = '41.10.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('41.10.1','Land Development Corporation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '41.10.2')
UPDATE [nace] SET activity = 'Private firms of land development',lt = null,lu = null WHERE idnace = '41.10.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('41.10.2','Private firms of land development',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '41.2')
UPDATE [nace] SET activity = 'Construction of residential and non-residential buildings',lt = null,lu = null WHERE idnace = '41.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('41.2','Construction of residential and non-residential buildings',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '41.20')
UPDATE [nace] SET activity = 'Construction of residential and non-residential buidlings',lt = null,lu = null WHERE idnace = '41.20'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('41.20','Construction of residential and non-residential buidlings',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '41.20.1')
UPDATE [nace] SET activity = 'Construction of all types of buildings (private sector)',lt = null,lu = null WHERE idnace = '41.20.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('41.20.1','Construction of all types of buildings (private sector)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42')
UPDATE [nace] SET activity = 'Civil engineering',lt = null,lu = null WHERE idnace = '42'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42','Civil engineering',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.1')
UPDATE [nace] SET activity = 'Construction of roads and railways',lt = null,lu = null WHERE idnace = '42.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.1','Construction of roads and railways',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.11')
UPDATE [nace] SET activity = 'Construction of roads and motorways',lt = null,lu = null WHERE idnace = '42.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.11','Construction of roads and motorways',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.11.1')
UPDATE [nace] SET activity = 'Construction of streets and roads (private sector)',lt = null,lu = null WHERE idnace = '42.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.11.1','Construction of streets and roads (private sector)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.11.2')
UPDATE [nace] SET activity = 'Construction work of the Public Works Department',lt = null,lu = null WHERE idnace = '42.11.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.11.2','Construction work of the Public Works Department',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.11.3')
UPDATE [nace] SET activity = 'Construction work of the District Administrations',lt = null,lu = null WHERE idnace = '42.11.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.11.3','Construction work of the District Administrations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.11.4')
UPDATE [nace] SET activity = 'Construction work of Municipalities and Community Boards',lt = null,lu = null WHERE idnace = '42.11.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.11.4','Construction work of Municipalities and Community Boards',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.12')
UPDATE [nace] SET activity = 'Construction of railways and underground railways',lt = null,lu = null WHERE idnace = '42.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.12','Construction of railways and underground railways',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.12.1')
UPDATE [nace] SET activity = 'Construction of railways and underground railways',lt = null,lu = null WHERE idnace = '42.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.12.1','Construction of railways and underground railways',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.13')
UPDATE [nace] SET activity = 'Construction of bridges and tunnels',lt = null,lu = null WHERE idnace = '42.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.13','Construction of bridges and tunnels',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.13.1')
UPDATE [nace] SET activity = 'Construction of bridges and tunnels',lt = null,lu = null WHERE idnace = '42.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.13.1','Construction of bridges and tunnels',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.2')
UPDATE [nace] SET activity = 'Construction of utility projects',lt = null,lu = null WHERE idnace = '42.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.2','Construction of utility projects',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.21')
UPDATE [nace] SET activity = 'Construction of utility projects for fluids',lt = null,lu = null WHERE idnace = '42.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.21','Construction of utility projects for fluids',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.21.1')
UPDATE [nace] SET activity = 'Construction of utility projects for fluids (incl. canals and water mains)',lt = null,lu = null WHERE idnace = '42.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.21.1','Construction of utility projects for fluids (incl. canals and water mains)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.21.2')
UPDATE [nace] SET activity = 'Construction work of the Water Boards',lt = null,lu = null WHERE idnace = '42.21.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.21.2','Construction work of the Water Boards',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.21.3')
UPDATE [nace] SET activity = 'Construction work of the Sewage Boards',lt = null,lu = null WHERE idnace = '42.21.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.21.3','Construction work of the Sewage Boards',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.21.4')
UPDATE [nace] SET activity = 'Water well drilling',lt = null,lu = null WHERE idnace = '42.21.4'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.21.4','Water well drilling',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.21.5')
UPDATE [nace] SET activity = 'Construction work of the Water Development Dept.',lt = null,lu = null WHERE idnace = '42.21.5'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.21.5','Construction work of the Water Development Dept.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.22')
UPDATE [nace] SET activity = 'Construction of utility projects for electricity and telecommunications',lt = null,lu = null WHERE idnace = '42.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.22','Construction of utility projects for electricity and telecommunications',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.22.1')
UPDATE [nace] SET activity = 'Construction work of the Electricity Authority of Cyprus',lt = null,lu = null WHERE idnace = '42.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.22.1','Construction work of the Electricity Authority of Cyprus',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.22.2')
UPDATE [nace] SET activity = 'Construction work of the Telecommunications Authority of Cyprus',lt = null,lu = null WHERE idnace = '42.22.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.22.2','Construction work of the Telecommunications Authority of Cyprus',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.22.3')
UPDATE [nace] SET activity = 'Construction of utility projects for electricity and telecommunications',lt = null,lu = null WHERE idnace = '42.22.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.22.3','Construction of utility projects for electricity and telecommunications',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.9')
UPDATE [nace] SET activity = 'Construction of other civil engineering projects',lt = null,lu = null WHERE idnace = '42.9'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.9','Construction of other civil engineering projects',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.91')
UPDATE [nace] SET activity = 'Construction of water projects',lt = null,lu = null WHERE idnace = '42.91'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.91','Construction of water projects',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.91.1')
UPDATE [nace] SET activity = 'Construction of water projects (including dams, marinas)',lt = null,lu = null WHERE idnace = '42.91.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.91.1','Construction of water projects (including dams, marinas)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.99')
UPDATE [nace] SET activity = 'Construction of other civil engineering projects n.e.c.',lt = null,lu = null WHERE idnace = '42.99'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.99','Construction of other civil engineering projects n.e.c.',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '42.99.1')
UPDATE [nace] SET activity = 'Construction work of other civil engineering projects n.e.c. (incl. outdoor sports facilities, land subdivision)',lt = null,lu = null WHERE idnace = '42.99.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('42.99.1','Construction work of other civil engineering projects n.e.c. (incl. outdoor sports facilities, land subdivision)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43')
UPDATE [nace] SET activity = 'Specialised construction activities',lt = null,lu = null WHERE idnace = '43'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43','Specialised construction activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.1')
UPDATE [nace] SET activity = 'Demolition and site preparation',lt = null,lu = null WHERE idnace = '43.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.1','Demolition and site preparation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.11')
UPDATE [nace] SET activity = 'Demolition',lt = null,lu = null WHERE idnace = '43.11'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.11','Demolition',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.11.1')
UPDATE [nace] SET activity = 'Demolition of buildings and other structures',lt = null,lu = null WHERE idnace = '43.11.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.11.1','Demolition of buildings and other structures',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.12')
UPDATE [nace] SET activity = 'Site preparation',lt = null,lu = null WHERE idnace = '43.12'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.12','Site preparation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.12.1')
UPDATE [nace] SET activity = 'Earth moving',lt = null,lu = null WHERE idnace = '43.12.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.12.1','Earth moving',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.13')
UPDATE [nace] SET activity = 'Test drilling and boring',lt = null,lu = null WHERE idnace = '43.13'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.13','Test drilling and boring',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.13.1')
UPDATE [nace] SET activity = 'Test drilling and boring',lt = null,lu = null WHERE idnace = '43.13.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.13.1','Test drilling and boring',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.2')
UPDATE [nace] SET activity = 'Electrical, plumbing and other construction installation activities',lt = null,lu = null WHERE idnace = '43.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.2','Electrical, plumbing and other construction installation activities',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.21')
UPDATE [nace] SET activity = 'Electrical installation',lt = null,lu = null WHERE idnace = '43.21'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.21','Electrical installation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.21.1')
UPDATE [nace] SET activity = 'Electrical installations',lt = null,lu = null WHERE idnace = '43.21.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.21.1','Electrical installations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.21.2')
UPDATE [nace] SET activity = 'Other installations',lt = null,lu = null WHERE idnace = '43.21.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.21.2','Other installations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.21.3')
UPDATE [nace] SET activity = 'Other building installation',lt = null,lu = null WHERE idnace = '43.21.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.21.3','Other building installation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.22')
UPDATE [nace] SET activity = 'Plumbing, heat and air-conditioning installation',lt = null,lu = null WHERE idnace = '43.22'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.22','Plumbing, heat and air-conditioning installation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.22.1')
UPDATE [nace] SET activity = 'Plumbing installations',lt = null,lu = null WHERE idnace = '43.22.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.22.1','Plumbing installations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.22.2')
UPDATE [nace] SET activity = 'Central heating installations',lt = null,lu = null WHERE idnace = '43.22.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.22.2','Central heating installations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.22.3')
UPDATE [nace] SET activity = '?ir conditioning installations',lt = null,lu = null WHERE idnace = '43.22.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.22.3','?ir conditioning installations',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.29')
UPDATE [nace] SET activity = 'Other construction installation',lt = null,lu = null WHERE idnace = '43.29'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.29','Other construction installation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.29.1')
UPDATE [nace] SET activity = 'Lifts and elevators installation services',lt = null,lu = null WHERE idnace = '43.29.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.29.1','Lifts and elevators installation services',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.29.2')
UPDATE [nace] SET activity = 'Water-proofing, heat insulation or sound- proofing in buildings or other structures (incl. installation of blinds)',lt = null,lu = null WHERE idnace = '43.29.2'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.29.2','Water-proofing, heat insulation or sound- proofing in buildings or other structures (incl. installation of blinds)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.3')
UPDATE [nace] SET activity = 'Building completion and finishing',lt = null,lu = null WHERE idnace = '43.3'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.3','Building completion and finishing',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.31')
UPDATE [nace] SET activity = 'Plastering',lt = null,lu = null WHERE idnace = '43.31'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.31','Plastering',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.31.1')
UPDATE [nace] SET activity = 'Plastering',lt = null,lu = null WHERE idnace = '43.31.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.31.1','Plastering',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.32')
UPDATE [nace] SET activity = 'Joinery installation',lt = null,lu = null WHERE idnace = '43.32'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.32','Joinery installation',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.32.1')
UPDATE [nace] SET activity = 'Installation of non self-manufactured doors, windows, kitchens, frames and the like of wood or other materials',lt = null,lu = null WHERE idnace = '43.32.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.32.1','Installation of non self-manufactured doors, windows, kitchens, frames and the like of wood or other materials',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.33')
UPDATE [nace] SET activity = 'Floor and wall covering',lt = null,lu = null WHERE idnace = '43.33'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.33','Floor and wall covering',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = '43.33.1')
UPDATE [nace] SET activity = 'Floor and wall covering with parquet, carpets, linoleum coverings, ceramic, etc. (incl. Wall paper, marble-polishing and furred ceiling)',lt = null,lu = null WHERE idnace = '43.33.1'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('43.33.1','Floor and wall covering with parquet, carpets, linoleum coverings, ceramic, etc. (incl. Wall paper, marble-polishing and furred ceiling)',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = 'A')
UPDATE [nace] SET activity = 'AGRICULTURE, FORESTRY AND FISHING',lt = null,lu = null WHERE idnace = 'A'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('A','AGRICULTURE, FORESTRY AND FISHING',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = 'B')
UPDATE [nace] SET activity = 'MINING AND QUARRYING',lt = null,lu = null WHERE idnace = 'B'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('B','MINING AND QUARRYING',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = 'C')
UPDATE [nace] SET activity = 'MANUFACTURING',lt = null,lu = null WHERE idnace = 'C'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('C','MANUFACTURING',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = 'D')
UPDATE [nace] SET activity = 'ELECTRICITY, GAS, STEAM AND AIR CONDITIONING SUPPLY',lt = null,lu = null WHERE idnace = 'D'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('D','ELECTRICITY, GAS, STEAM AND AIR CONDITIONING SUPPLY',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = 'E')
UPDATE [nace] SET activity = 'WATER SUPPLY; SEWERAGE, WASTE MANAGEMENT AND REMEDIATION ACTIVITIES',lt = null,lu = null WHERE idnace = 'E'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('E','WATER SUPPLY; SEWERAGE, WASTE MANAGEMENT AND REMEDIATION ACTIVITIES',null,null)
GO

IF exists(SELECT * FROM [nace] WHERE idnace = 'F')
UPDATE [nace] SET activity = 'CONSTRUCTION',lt = null,lu = null WHERE idnace = 'F'
ELSE
INSERT INTO [nace] (idnace,activity,lt,lu) VALUES ('F','CONSTRUCTION',null,null)
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'nace')
UPDATE [tabledescr] SET description = 'VOCABOLARIO della classificazione NACE',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-17 10:46:20.177'},lu = 'assistenza',title = 'Classificazione NACE delle attività' WHERE tablename = 'nace'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('nace','VOCABOLARIO della classificazione NACE','2','S',{ts '2018-07-17 10:46:20.177'},'assistenza','Classificazione NACE delle attività')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'activity' AND tablename = 'nace')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:45:43.710'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'activity' AND tablename = 'nace'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('activity','nace','0',null,null,null,'S',{ts '2018-07-17 10:45:43.710'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnace' AND tablename = 'nace')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 10:45:43.713'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'nvarchar(50)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'idnace' AND tablename = 'nace'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnace','nace','50',null,null,null,'S',{ts '2018-07-17 10:45:43.713'},'assistenza','S','nvarchar(50)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

