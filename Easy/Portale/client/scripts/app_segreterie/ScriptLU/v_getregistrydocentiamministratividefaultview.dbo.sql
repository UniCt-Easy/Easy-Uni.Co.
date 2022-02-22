
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


-- CREAZIONE VISTA getregistrydocentiamministratividefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getregistrydocentiamministratividefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getregistrydocentiamministratividefaultview]
GO

CREATE VIEW [dbo].[getregistrydocentiamministratividefaultview] AS 
SELECT  getregistrydocentiamministrativi.cf AS getregistrydocentiamministrativi_cf, getregistrydocentiamministrativi.contratto AS getregistrydocentiamministrativi_contratto, getregistrydocentiamministrativi.extmatricula AS getregistrydocentiamministrativi_extmatricula, getregistrydocentiamministrativi.forename AS getregistrydocentiamministrativi_forename, getregistrydocentiamministrativi.idreg, getregistrydocentiamministrativi.istituto AS getregistrydocentiamministrativi_istituto, getregistrydocentiamministrativi.ssd AS getregistrydocentiamministrativi_ssd, getregistrydocentiamministrativi.struttura AS getregistrydocentiamministrativi_struttura, getregistrydocentiamministrativi.surname,
 isnull('Cognome: ' + getregistrydocentiamministrativi.surname + '; ','') + ' ' + isnull('Nome: ' + getregistrydocentiamministrativi.forename + '; ','') + ' ' + isnull('Extmatricula: ' + getregistrydocentiamministrativi.extmatricula + '; ','') + ' ' + isnull('Contratto: ' + getregistrydocentiamministrativi.contratto + '; ','') as dropdown_title
FROM [dbo].getregistrydocentiamministrativi WITH (NOLOCK) 
WHERE  getregistrydocentiamministrativi.idreg IS NOT NULL 
GO

