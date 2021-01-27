
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


-- CREAZIONE VISTA [epexpvarview]
IF EXISTS(select * from sysobjects where id = object_id(N'[epexpvarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [epexpvarview]
GO

CREATE         VIEW [epexpvarview]
(
	idepexp,
	nvar,
	yvar,
	nphase,
	phase,
	yepexp,
	nepexp,
	flagvariation,
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
	epexpvar.idepexp,
	epexpvar.nvar,
	epexpvar.yvar,
	epexp.nphase,
	case when epexp.nphase = 1 then 'Preimpegno'
		else 'Impegno'
	end,
	epexp.yepexp,
	epexp.nepexp,
	epexp.flagvariation,
	epexpvar.description,
	epexpvar.amount,
	epexpvar.amount2,
	epexpvar.amount3,
	epexpvar.amount4,
	epexpvar.amount5,	
	--amountwithsign
	case when epexp.flagvariation ='N' 
					then ISNULL(epexpvar.amount,0)
					else -ISNULL(epexpvar.amount,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(epexpvar.amount2,0)
					else -ISNULL(epexpvar.amount2,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(epexpvar.amount3,0)
					else -ISNULL(epexpvar.amount3,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(epexpvar.amount4,0)
					else -ISNULL(epexpvar.amount4,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(epexpvar.amount5,0)
					else -ISNULL(epexpvar.amount5,0)
	end,			
	epexpvar.adate,
	epexpvar.cu,
	epexpvar.ct,
	epexpvar.lu,
	epexpvar.lt,
	account.idacc,
	account.codeacc,
	account.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	epexp.idman,
	upb.idtreasurer,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	epexp.idrelated
FROM epexpvar (NOLOCK)
JOIN epexp (NOLOCK)
	ON epexp.idepexp = epexpvar.idepexp
JOIN epexpyear (NOLOCK)
	ON epexpyear.idepexp= epexp.idepexp
     AND epexpyear.ayear= epexpvar.yvar
LEFT OUTER JOIN account (NOLOCK)
	ON account.idacc= epexpyear.idacc
LEFT OUTER JOIN upb (NOLOCK)
	ON upb.idupb= epexpyear.idupb
 


GO

 
