
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_utenti_funzioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_utenti_funzioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
 

CREATE procedure  [exp_utenti_funzioni]
	@ayear int = NULL,
	@idcustomuser varchar(50) = NULL,
	@variablename varchar(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select
	f.ayear  [Esercizio],
	u.idcustomuser  [Utente], 
	r.description [Funzione], 
	f.codeflowchart [Cod. Organigramma], 
	f.title [Des. Organigramma], 
	u.title [Des. Ruolo (facoltativa)],
	u.flagdefault [Ruolo di default],
	u.start [Inizio Ruolo],
	u.stop [Fine Ruolo],
	s1.sortcode + ' - ' + s1.description [Attributo 1], 
	s2.sortcode [Attributo 2], 
	s3.sortcode [Attributo 3], 
	s4.sortcode [Attributo 4], 
	s5.sortcode [Attributo 5]
	from flowchartuser u 
	join flowchartview f on u.idflowchart = f.idflowchart
	join flowchartrestrictedfunction ru on ru.idflowchart = f.idflowchart
	join restrictedfunction r on ru.idrestrictedfunction= r.idrestrictedfunction
	left outer join sorting s1 on u.idsor01 = s1.idsor
	left outer join sorting s2 on u.idsor02 = s2.idsor
	left outer join sorting s3 on u.idsor03 = s3.idsor
	left outer join sorting s4 on u.idsor04 = s4.idsor
	left outer join sorting s5 on u.idsor05 = s5.idsor
	where ((f.ayear = @ayear) OR (@ayear is null))
	and ((u.idcustomuser = @idcustomuser) OR (@idcustomuser is null))
	and ((r.variablename = @variablename) OR (@variablename is null))
	order by 2, 4, u.title, u.flagdefault, r.idrestrictedfunction
END



