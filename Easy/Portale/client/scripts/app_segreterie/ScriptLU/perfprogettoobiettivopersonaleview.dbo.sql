
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


-- CREAZIONE VISTA perfprogettoobiettivopersonaleview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivopersonaleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivopersonaleview]
GO




























CREATE VIEW [dbo].[perfprogettoobiettivopersonaleview]
AS
SELECT distinct dbo.perfprogettoobiettivo.idperfprogetto, dbo.perfprogettoobiettivo.idperfprogettoobiettivo, dbo.perfprogettoobiettivo.title, dbo.perfprogettoobiettivo.description, dbo.perfprogettoobiettivo.peso, 
                  dbo.perfprogettoobiettivo.completamento, dbo.strutturakind.title as perfprogetto_strutturakind_title,  dbo.struttura.title perfprogetto_struttura_title, dbo.perfprogetto.idstruttura as idstruttura_perfprogetto, dbo.perfprogetto.title AS progetto_title, dbo.perfvalutazioneuo.idperfvalutazioneuo, dbo.perfvalutazioneuo.idstruttura
FROM     dbo.perfprogettoobiettivo INNER JOIN
                  dbo.perfprogetto ON dbo.perfprogettoobiettivo.idperfprogetto = dbo.perfprogetto.idperfprogetto 
				  INNER JOIN
                  dbo.perfvalutazioneuo ON dbo.perfprogetto.idstruttura <> dbo.perfvalutazioneuo.idstruttura AND YEAR(dbo.perfprogetto.datainizioprevista) <= dbo.perfvalutazioneuo.year AND YEAR(dbo.perfprogetto.datafineprevista) 
                  <= dbo.perfvalutazioneuo.year 
				  INNER JOIN
                  dbo.afferenza ON dbo.perfvalutazioneuo.idstruttura = dbo.afferenza.idstruttura AND dbo.perfvalutazioneuo.year >= YEAR(dbo.afferenza.start) AND dbo.perfvalutazioneuo.year <= YEAR(dbo.afferenza.stop) 
				  INNER JOIN
                  dbo.perfprogettouo ON dbo.perfprogetto.idperfprogetto = dbo.perfprogettouo.idperfprogetto 
				  INNER JOIN dbo.struttura ON dbo.perfprogetto.idstruttura = dbo.struttura.idstruttura
				  INNER JOIN dbo.strutturakind ON dbo.struttura.idstrutturakind = dbo.strutturakind.idstrutturakind
				  INNER JOIN
                  dbo.perfprogettouomembro ON dbo.perfprogettouo.idperfprogetto = dbo.perfprogettouomembro.idperfprogetto AND dbo.perfprogettouo.idperfprogettouo = dbo.perfprogettouomembro.idperfprogettouo AND 
                  dbo.afferenza.idreg = dbo.perfprogettouomembro.idreg














GO

