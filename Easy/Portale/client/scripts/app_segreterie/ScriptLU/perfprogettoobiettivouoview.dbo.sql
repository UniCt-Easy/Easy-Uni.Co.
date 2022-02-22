
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


-- CREAZIONE VISTA perfprogettoobiettivouoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivouoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivouoview]
GO











CREATE VIEW dbo.perfprogettoobiettivouoview
AS
SELECT dbo.perfprogettoobiettivo.idperfprogetto, dbo.perfprogettoobiettivo.idperfprogettoobiettivo, dbo.perfprogettoobiettivo.title, dbo.perfprogettoobiettivo.description, dbo.perfprogettoobiettivo.peso, 
                  dbo.perfprogettoobiettivo.completamento, dbo.perfprogetto.idstruttura, dbo.perfprogetto.title AS progetto_title, dbo.perfvalutazioneuo.idperfvalutazioneuo
FROM     dbo.perfprogettoobiettivo INNER JOIN
                  dbo.perfprogetto ON dbo.perfprogettoobiettivo.idperfprogetto = dbo.perfprogetto.idperfprogetto INNER JOIN
                  dbo.perfvalutazioneuo ON dbo.perfprogetto.idstruttura = dbo.perfvalutazioneuo.idstruttura AND YEAR(dbo.perfprogetto.datainizioprevista) <= dbo.perfvalutazioneuo.year AND YEAR(dbo.perfprogetto.datafineprevista) 
                  <= dbo.perfvalutazioneuo.year






GO

