
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_verifica_distinte_trasmissione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_verifica_distinte_trasmissione]
GO
/****** Object:  StoredProcedure [amministrazione].[exp_verifica_distinte_trasmissione]    Script Date: 19/01/2015 11:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Gianni 16/12/2014
Procedura di esportazione che effettua il check della trasmissione delle distinte
*/

CREATE  PROCEDURE [exp_verifica_distinte_trasmissione]
(	
	@y int,
	@n int,
	@es char, -- E/S Distinta di trasmissione di entrata o di spesa
	--Mettere i parametri per la gestione della sicurezza
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

)
AS BEGIN

declare @procedura_di_check varchar(50)
set @procedura_di_check = 
	case when @es = 'E' 
		then (
			select top 1 spexportinc from treasurer 
				where (@idsor01 IS NULL OR idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR idsor05 = @idsor05))
		else (
			select top 1 spexportexp from treasurer 
				where (@idsor01 IS NULL OR idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR idsor05 = @idsor05))
		end

declare @query_da_lanciare varchar(200)
set @query_da_lanciare = (select  + @procedura_di_check  + ' ' + cast(@y as varchar(4)) + ', ' + cast(@n as varchar(6)))

print @query_da_lanciare

create table #risultato
(
	risultato varchar(8000)
)
insert into #risultato exec(@query_da_lanciare)
select risultato  from #risultato

END
