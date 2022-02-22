
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


IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettokindsegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettokindsegview')
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatamanagedtable] WHERE [tablename] = 'progettosegview')
INSERT INTO [dbo].[metadatamanagedtable] ([tablename]) VALUES  ('progettosegview')
GO
 --insert metadatamanagedtable

IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progettokind')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progettokind', '"idprogettokind"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogettokind"' WHERE [tablename] = 'progettokind'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadataprimarykey] WHERE [tablename] = 'progetto')
INSERT INTO [dbo].[metadataprimarykey] ([tablename], [primarykey]) VALUES ('progetto', '"idprogetto"')
ELSE
UPDATE [dbo].[metadataprimarykey] SET [primarykey] = '"idprogetto"' WHERE [tablename] = 'progetto'
GO
 --insert metadataprimarykey

IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettokindsegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettokindsegview', 'seg', 'progettoactivitykind_title asc , title asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'progettoactivitykind_title asc , title asc ' WHERE [tablename] = 'progettokindsegview' AND [listtype] = 'seg'
GO
IF NOT EXISTS(SELECT * FROM [dbo].[metadatasorting] WHERE [tablename] = 'progettosegview' AND [listtype] = 'seg')
INSERT INTO [dbo].[metadatasorting] ([tablename], [listtype], [sorting]) VALUES ('progettosegview', 'seg', 'titolobreve asc ')
ELSE 
UPDATE [dbo].[metadatasorting] SET [sorting] = 'titolobreve asc ' WHERE [tablename] = 'progettosegview' AND [listtype] = 'seg'
GO
 --insert metadatasorting

 --insert metadatastaticfilter 
 
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostokindsegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostokindsegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostokindsegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostokindsegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostokindsegview'
END
GO
IF EXISTS(select * from [dbo].[metadatamanagedtable] where [tablename] = 'progettotipocostosegview')
BEGIN 
	DELETE [dbo].[metadataprimarykey] WHERE [tablename] = 'progettotipocostosegview'
	DELETE [dbo].[metadatastaticfilter] WHERE [tablename] = 'progettotipocostosegview'
	DELETE [dbo].[metadatasorting] WHERE [tablename] = 'progettotipocostosegview'
	DELETE [dbo].[metadatamanagedtable]  WHERE [tablename] = 'progettotipocostosegview'
END
GO
 --delete 
