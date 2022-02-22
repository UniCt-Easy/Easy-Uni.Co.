
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


IF EXISTS(select * from sysobjects where id = object_id(N'[epaccvarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [epaccvarview]
GO

CREATE         VIEW [epaccvarview]
(
	idepacc,
	nvar,
	yvar,
	nphase,
	phase,
	yepacc,
	nepacc,
	description,
	amount,
	amount2,
	amount3,
	amount4,
	amount5,
	amountwithsign,
	amountwithsign2,
	amountwithsign3,
	amountwithsign4,
	amountwithsign5,
	adate,
	cu,
	ct,
	lu,
	lt,
	idacc,
	codeacc,
	account,
	idupb,
	codeupb,
	upb,
	idman,
	idtreasurer,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idrelated
)
AS SELECT
	epaccvar.idepacc,
	epaccvar.nvar,
	epaccvar.yvar,
	epacc.nphase,
	case when epacc.nphase = 1 then 'Preaccertamento'
		else 'Accertamento'
	end,
	epacc.yepacc,
	epacc.nepacc,
	epaccvar.description,
	epaccvar.amount,
	epaccvar.amount2,
	epaccvar.amount3,
	epaccvar.amount4,
	epaccvar.amount5,	
	--amountwithsign
	case when epacc.flagvariation ='N' 
					then ISNULL(epaccvar.amount,0)
					else -ISNULL(epaccvar.amount,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(epaccvar.amount2,0)
					else -ISNULL(epaccvar.amount2,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(epaccvar.amount3,0)
					else -ISNULL(epaccvar.amount3,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(epaccvar.amount4,0)
					else -ISNULL(epaccvar.amount4,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(epaccvar.amount5,0)
					else -ISNULL(epaccvar.amount5,0)
	end,				
	epaccvar.adate,
	epaccvar.cu,
	epaccvar.ct,
	epaccvar.lu,
	epaccvar.lt,
	account.idacc,
	account.codeacc,
	account.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	epacc.idman,
	upb.idtreasurer,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	epacc.idrelated
FROM epaccvar (NOLOCK)
JOIN epacc (NOLOCK)
	ON epacc.idepacc = epaccvar.idepacc
JOIN epaccyear (NOLOCK)
	ON epaccyear.idepacc= epacc.idepacc
     AND epaccyear.ayear= epaccvar.yvar
LEFT OUTER JOIN account (NOLOCK)
	ON account.idacc= epaccyear.idacc
LEFT OUTER JOIN upb (NOLOCK)
	ON upb.idupb= epaccyear.idupb
 



GO


 
