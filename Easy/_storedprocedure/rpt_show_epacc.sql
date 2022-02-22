
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_show_epacc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_show_epacc]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- select * from epacc where yepacc=2020
-- rpt_show_epacc 1, 2020, null, 2020, '31-12-2020'


CREATE           PROCEDURE rpt_show_epacc(
	@nphase int,
	@yepacc int,
	@nepacc int,
	@ayear int,
	@date datetime ,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN
---exec rpt_show_epacc 2,2014,3996,2014,{ts '2014-12-31 01:02:03'}
	select
	 idepacc,
	 phase as Fase,
	 yepacc,
	 nepacc,
	 description,
	 registry,
	 codeacc,
	 account,
	 codeupb,
	 upb,
	 flagvariation,
	 amount,amount2,amount3,amount4,amount5,
	 curramount,
	 available as Disp_Eesercizio,
	 curramount2 ,
	 available2 as Disp_Eesercizio2,
	 curramount3,
	 available3 as Disp_Eesercizio3,
	 curramount4,
	 available4 as Disp_Eesercizio4,
	 curramount5,
	 available5 as Disp_Eesercizio5,
	 revenueavailable as Disp_per_ricavi,
	 CONVERT(datetime, adate)  as adate, 
	 start as Inizio_Competenza,
	 stop as Fine_Competenza,
	 doc,
	 CONVERT(datetime, docdate)  as docdate, 
	 totalrevenue as Ricavi_totali,
	totalcredit as Crediti_totali,
	 totamount as Tolale_Iniziale_Pluriennale,
	 totavailable as Totale_Disp_Pluriennale,
	 totcurramount as Totale_Corrente_Pluriennale
	from epaccview
	where ayear = @ayear
	and ( nphase = @nphase or @nphase is null)
	and ( yepacc = @yepacc)
	and	( nepacc = @nepacc or @nepacc is null)
	and (adate <= @date or @date is null)
	AND (@idsor01 IS NULL OR idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR idsor05 = @idsor05)	

end 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
