/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_progetti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_progetti]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [exp_progetti](
	@ayearstart smallint,
	@ayearstop smallint,
	@idreg_aziende int =null,
	@idprogettostatuskind int,
	@unita_organizzativa varchar(200)
)

AS BEGIN
--setuser 'AMMINISTRAZIONE'
SELECT [idprogetto] AS '# progetto'
	  ,[progettokind_title] as 'Modello di progetto'
	  ,[progetto_codiceidentificativo] as 'Codice Identificativo assegnato dall''Ente Finaiziatore'
	  ,SUBSTRING([dropdown_title], 27, len([dropdown_title])) AS   'Titolo breve o acronimo'
	  ,[titolobreve] as 'Titolo breve'
      ,[progetto_title]as 'Titolo Esteso IT'
      ,[progetto_title_en] as 'Titolo EN'
	  ,[registryaziende_fin_title] 'Ente finanziatore'
      ,[progetto_finanziatoretxt] 'Ente Finanziatore non censito in Anagrafica'
	  ,[idreg_aziende_fin] 'Codice Anagrafico Ente Fin.'
	  ,[progetto_progfinanziamentotxt] 'Programma di finanziamento Ente Fin.'
      ,[registryprogfinbando_title] 'Bando di finanziamento Ente Fin.'
	  ,[progetto_unitaorganizzativa] as 'Unità organizzativa'
	  ,[progetto_start] as 'Inizio'
      ,[progetto_stop] as 'Fine'
	  ,[progettostatuskind_title] as 'Stato'
	  ,[progetto_contributoente] as 'Contributo Ente'
	  ,[progetto_finanziamento] 'Finanziamento'
	  ,[progetto_cup] as 'CUP'
	  ,[progetto_ulteriorecup] 'Secondo CUP'
	  ,[progetto_respamministrativi] as 'Responsabili Amministrativi'
      ,[progetto_respscientifici] as 'Responsabili Scientifici'
	  ,[idreg_aziende] as 'Cod. Azienda'
	  ,[registryaziende_title] as 'Denom. Azienda'
	  ,[partnerkind_title] as 'Tipo Partner'
      ,[progetto_capofilatxt] as 'Progetto Capofila'
	  ,isnull(convert(varchar(10),[progetto_durata]),'') + ' '+ isnull([duratakind_title],'') as 'Durata'
  FROM [amministrazione].[progettogriglieview] P
  WHERE (year(P.progetto_start) =  @ayearstart OR @ayearstart IS NULL) AND
		(year(P.progetto_stop)=  @ayearstop  OR @ayearstop IS NULL) AND
		(P.idreg_aziende = @idreg_aziende  OR @idreg_aziende IS NULL) AND
		(P.progetto_idprogettostatuskind= @idprogettostatuskind OR @idprogettostatuskind IS NULL) AND
		(P.progetto_unitaorganizzativa = @unita_organizzativa  OR @unita_organizzativa IS NULL)
  ORDER BY  [idprogetto] 
 
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




 --select *     FROM [amministrazione].[progettogriglieview]