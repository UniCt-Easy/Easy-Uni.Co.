
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


-- CREAZIONE VISTA perfprogettoobiettivoattivitadocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivoattivitadocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivoattivitadocentiview]
GO

CREATE VIEW [dbo].[perfprogettoobiettivoattivitadocentiview] AS 
SELECT 
 [dbo].perfprogetto.title AS perfprogetto_title, perfprogettoobiettivoattivita.idperfprogetto, perfprogettoobiettivoattivita.description AS perfprogettoobiettivoattivita_description,
 [dbo].perfprogettoobiettivo.title AS perfprogettoobiettivo_title, perfprogettoobiettivoattivita.idperfprogettoobiettivo, perfprogettoobiettivoattivita.idreg AS perfprogettoobiettivoattivita_idreg,
 perfprogettoobiettivoattivitaparent.title AS perfprogettoobiettivoattivitaparent_title, perfprogettoobiettivoattivita.paridperfprogettoobiettivoattivita AS perfprogettoobiettivoattivita_paridperfprogettoobiettivoattivita, perfprogettoobiettivoattivita.title, perfprogettoobiettivoattivita.datainizioprevista AS perfprogettoobiettivoattivita_datainizioprevista, perfprogettoobiettivoattivita.datafineprevista AS perfprogettoobiettivoattivita_datafineprevista, perfprogettoobiettivoattivita.datainizioeffettiva AS perfprogettoobiettivoattivita_datainizioeffettiva, perfprogettoobiettivoattivita.datafineeffettiva AS perfprogettoobiettivoattivita_datafineeffettiva, perfprogettoobiettivoattivita.completamento AS perfprogettoobiettivoattivita_completamento, perfprogettoobiettivoattivita.ct AS perfprogettoobiettivoattivita_ct, perfprogettoobiettivoattivita.cu AS perfprogettoobiettivoattivita_cu, perfprogettoobiettivoattivita.lt AS perfprogettoobiettivoattivita_lt, perfprogettoobiettivoattivita.lu AS perfprogettoobiettivoattivita_lu, perfprogettoobiettivoattivita.idperfprogettoobiettivoattivita,
 isnull('Titolo: ' + perfprogettoobiettivoattivita.title + '; ','') as dropdown_title
FROM [dbo].perfprogettoobiettivoattivita WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfprogetto WITH (NOLOCK) ON perfprogettoobiettivoattivita.idperfprogetto = [dbo].perfprogetto.idperfprogetto
LEFT OUTER JOIN [dbo].perfprogettoobiettivo WITH (NOLOCK) ON perfprogettoobiettivoattivita.idperfprogettoobiettivo = [dbo].perfprogettoobiettivo.idperfprogettoobiettivo
LEFT OUTER JOIN [dbo].perfprogettoobiettivoattivita AS perfprogettoobiettivoattivitaparent WITH (NOLOCK) ON perfprogettoobiettivoattivita.paridperfprogettoobiettivoattivita = perfprogettoobiettivoattivitaparent.idperfprogettoobiettivoattivita
WHERE  perfprogettoobiettivoattivita.idperfprogetto IS NOT NULL  AND perfprogettoobiettivoattivita.idperfprogettoobiettivo IS NOT NULL  AND perfprogettoobiettivoattivita.idperfprogettoobiettivoattivita IS NOT NULL 
GO

