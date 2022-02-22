
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


-- CREAZIONE VISTA appellosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appellosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[appellosegview]
GO

CREATE VIEW [dbo].[appellosegview] AS 
SELECT  appello.aa, appello.basevoto AS appello_basevoto, appello.cftoend AS appello_cftoend, appello.ct AS appello_ct, appello.cu AS appello_cu, appello.description, appello.esteroend AS appello_esteroend, appello.esterostart AS appello_esterostart, appello.idappello,
 [dbo].appelloazionekind.title AS appelloazionekind_title, appello.idappelloazionekind AS appello_idappelloazionekind,
 [dbo].appellokind.title AS appellokind_title, appello.idappellokind AS appello_idappellokind,
 [dbo].sessionekind.title AS sessionekind_title, [dbo].sessionekind.idsessionekind AS sessionekind_idsessionekind, [dbo].sessione.start AS sessione_start, [dbo].sessione.stop AS sessione_stop, appello.idsessione,
 [dbo].studprenotkind.title AS studprenotkind_title, appello.idstudprenotkind AS appello_idstudprenotkind,CASE WHEN appello.lavoratori = 'S' THEN 'Si' WHEN appello.lavoratori = 'N' THEN 'No' END AS appello_lavoratori, appello.lt AS appello_lt, appello.lu AS appello_lu, appello.minanniiscr AS appello_minanniiscr, appello.minvoto AS appello_minvoto,CASE WHEN appello.passaggio = 'S' THEN 'Si' WHEN appello.passaggio = 'N' THEN 'No' END AS appello_passaggio, appello.penotend AS appello_penotend, appello.posti AS appello_posti, appello.prenotstart AS appello_prenotstart,CASE WHEN appello.prointermedia = 'S' THEN 'Si' WHEN appello.prointermedia = 'N' THEN 'No' END AS appello_prointermedia,CASE WHEN appello.publicato = 'S' THEN 'Si' WHEN appello.publicato = 'N' THEN 'No' END AS appello_publicato, appello.surmanestop AS appello_surmanestop, appello.surnamestart AS appello_surnamestart,
 isnull('Descrizione: ' + appello.description + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].sessionekind.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + CAST( [dbo].sessionekind.idsessionekind AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno accademico: ' + appello.aa + '; ','') as dropdown_title
FROM [dbo].appello WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].appelloazionekind WITH (NOLOCK) ON appello.idappelloazionekind = [dbo].appelloazionekind.idappelloazionekind
LEFT OUTER JOIN [dbo].appellokind WITH (NOLOCK) ON appello.idappellokind = [dbo].appellokind.idappellokind
LEFT OUTER JOIN [dbo].sessione WITH (NOLOCK) ON appello.idsessione = [dbo].sessione.idsessione
LEFT OUTER JOIN [dbo].sessionekind WITH (NOLOCK) ON sessione.idsessionekind = [dbo].sessionekind.idsessionekind
LEFT OUTER JOIN [dbo].studprenotkind WITH (NOLOCK) ON appello.idstudprenotkind = [dbo].studprenotkind.idstudprenotkind
WHERE  appello.idappello IS NOT NULL 
GO

