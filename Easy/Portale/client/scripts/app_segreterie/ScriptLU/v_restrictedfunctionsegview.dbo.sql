
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


-- CREAZIONE VISTA restrictedfunctionsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[restrictedfunctionsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[restrictedfunctionsegview]
GO

CREATE VIEW [dbo].[restrictedfunctionsegview] AS 
SELECT  restrictedfunction.ct AS restrictedfunction_ct, restrictedfunction.cu AS restrictedfunction_cu, restrictedfunction.description, restrictedfunction.idrestrictedfunction, restrictedfunction.lt AS restrictedfunction_lt, restrictedfunction.lu AS restrictedfunction_lu, restrictedfunction.variablename AS restrictedfunction_variablename,
 isnull('Descrizione: ' + restrictedfunction.description + '; ','') + ' ' + isnull('Variabile: ' + restrictedfunction.variablename + '; ','') as dropdown_title
FROM [dbo].restrictedfunction WITH (NOLOCK) 
WHERE  restrictedfunction.idrestrictedfunction IS NOT NULL 
GO

