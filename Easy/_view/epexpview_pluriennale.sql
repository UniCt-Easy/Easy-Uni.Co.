
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


-- CREAZIONE VISTA epexpview
IF EXISTS(select * from sysobjects where id = object_id(N'[epexpview_pluriennale]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [epexpview_pluriennale]
GO

-- setuser 'amm'
-- setuser 'amministrazione'
--clear_table_info'epexpview_pluriennale'
--select * from epexpview_pluriennale
CREATE    VIEW [epexpview_pluriennale]
(
	idepexp,yepexp,nepexp,nphase,
	flagvariation,
	description, 
	amount,amount2,amount3,amount4,amount5,totamount,
	curramount,curramount2,curramount3,curramount4,curramount5,totcurramount,	
	totalcost, 	totaldebit,
	paridepexp, idrelated, idaccmotive,
	idreg
)
AS
SELECT
	epexp.idepexp,epexp.yepexp,epexp.nepexp,epexp.nphase,
	epexp.flagvariation,
	epexp.description,
	firstyear.amount,firstyear.amount2,firstyear.amount3,firstyear.amount4,firstyear.amount5,
	-- totamount:
	isnull(firstyear.amount,0)+isnull(firstyear.amount2,0)+isnull(firstyear.amount3,0)+isnull(firstyear.amount4,0)+isnull(firstyear.amount5,0),	
	
	--ET.curramount,	ET.curramount2,ET.curramount3,ET.curramount4,ET.curramount5,
	isnull(firstyear.amount,0)+isnull( (select  sum(EV.amount) from epexpvar EV where EV.idepexp=epexp.idepexp),0),
	isnull(firstyear.amount2,0)+isnull( (select  sum(EV.amount2) from epexpvar EV where EV.idepexp=epexp.idepexp),0),
	isnull(firstyear.amount3,0)+isnull( (select  sum(EV.amount3) from epexpvar EV where EV.idepexp=epexp.idepexp),0),
	isnull(firstyear.amount4,0)+isnull( (select  sum(EV.amount4) from epexpvar EV where EV.idepexp=epexp.idepexp),0),
	isnull(firstyear.amount5,0)+isnull( (select  sum(EV.amount5) from epexpvar EV where EV.idepexp=epexp.idepexp),0),

	

	-- totcurramount :
	--isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0),
	isnull(firstyear.amount,0)+isnull(firstyear.amount2,0)+isnull(firstyear.amount3,0)+
				isnull(firstyear.amount4,0)+isnull(firstyear.amount5,0)+
	isnull( (select  sum(isnulL(EV.amount,0)+isnull(EV.amount2,0)+isnull(EV.amount3,0)+
								isnull(EV.amount4,0)+isnull(EV.amount5,0)) from epexpvar EV where EV.idepexp=epexp.idepexp),0),

	-- totalcost:
	case when epexp.nphase = 2 then
			case when epexp.flagvariation ='N' 
					then isnull((select sum(cost) from epexptotal ET where ET.idepexp=epexp.idepexp),0)
					else -isnull((select sum(cost) from epexptotal ET where ET.idepexp=epexp.idepexp),0)
			end		 
		else null
	end,
	
	 -- totaldebit:
	 case when epexp.nphase = 2 then
		case when epexp.flagvariation ='N' 
					then isnull((select sum(debit) from epexptotal ET where ET.idepexp=epexp.idepexp),0)
					else -isnull((select sum(debit) from epexptotal ET where ET.idepexp=epexp.idepexp),0)
		end 
		else null
	end,
	epexp.paridepexp,	epexp.idrelated,	epexp.idaccmotive,
	epexp.idreg

FROM epexp
join epexpyear firstyear on firstyear.idepexp= epexp.idepexp and firstyear.ayear=epexp.yepexp

GO

 
