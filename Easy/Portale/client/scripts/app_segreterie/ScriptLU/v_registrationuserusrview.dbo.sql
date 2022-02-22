
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


-- CREAZIONE VISTA registrationuserusrview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrationuserusrview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrationuserusrview]
GO

CREATE VIEW [dbo].[registrationuserusrview] AS 
SELECT  registrationuser.idregistrationuser, registrationuser.surname, registrationuser.forename AS registrationuser_forename, registrationuser.cf AS registrationuser_cf, registrationuser.esercizio AS registrationuser_esercizio, registrationuser.email AS registrationuser_email, registrationuser.login AS registrationuser_login, registrationuser.usertype,
 [dbo].registrationuserstatus.title AS registrationuserstatus_title, registrationuser.idregistrationuserstatus AS registrationuser_idregistrationuserstatus, registrationuser.matricola AS registrationuser_matricola, registrationuser.userkind AS registrationuser_userkind,
 isnull('Cognome: ' + registrationuser.surname + '; ','') + ' ' + isnull('Nome: ' + registrationuser.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registrationuser.cf + '; ','') as dropdown_title
FROM [dbo].registrationuser WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registrationuserstatus WITH (NOLOCK) ON registrationuser.idregistrationuserstatus = [dbo].registrationuserstatus.idregistrationuserstatus
WHERE  registrationuser.idregistrationuser IS NOT NULL 
GO

