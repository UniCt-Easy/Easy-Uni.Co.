
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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


/****** Object:  View [rendicontattivitaprogettooraview]    Script Date: 23/06/2020 11:44:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettooraview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettooraview]
GO

CREATE VIEW [rendicontattivitaprogettooraview]
AS
SELECT			rendicontattivitaprogettoora.idrendicontattivitaprogettoora, rendicontattivitaprogettoora.idrendicontattivitaprogetto, rendicontattivitaprogettoora.data, 
				rendicontattivitaprogettoora.ore, rendicontattivitaprogettoora.ct, rendicontattivitaprogettoora.cu, rendicontattivitaprogettoora.lt, rendicontattivitaprogettoora.lu, 
				'<b>Progetto:</b> ' + isnull(progetto.title,'') + 
				'; <b>Workpackage:</b> ' + isnull(workpackage.title,'') + 
				'; <b>Attivit√†:</b> ' + isnull(rendicontattivitaprogetto.description,'') + 
				'; <b>Ore:</b> ' +CAST(rendicontattivitaprogettoora.ore AS nvarchar(10)) AS titleancestor, 
                         rendicontattivitaprogetto.idreg
FROM            rendicontattivitaprogettoora 
INNER JOIN		rendicontattivitaprogetto ON rendicontattivitaprogettoora.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto
INNER JOIN		workpackage ON workpackage.idworkpackage = rendicontattivitaprogetto.idworkpackage
INNER JOIN		progetto ON progetto.idprogetto = workpackage.idprogetto
GO


