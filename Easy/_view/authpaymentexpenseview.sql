
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


-- CREAZIONE VISTA authpaymentexpenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[authpaymentexpenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [authpaymentexpenseview]
GO


CREATE VIEW authpaymentexpenseview
(
	idautpayment,
	yauthpayment,
	nauthpayment,
	idexp,
	ymov,
	nmov,
	nphase,
	phase,
	amount,
	curramount,
	netamount,
	idreg,
	registry,
	ct, cu, lt, lu
)
AS SELECT
	PE.idauthpayment,
	P.yauthpayment,
	P.nauthpayment,
	PE.idexp,
	E.ymov,
	E.nmov,
	E.nphase,
	EP.description,
	EY.amount,
	ET.curramount,
	ET.curramount
		- isnull( (SELECT sum(IIT.curramount) from income II with (nolock) 
				join incometotal IIT  with (nolock)  on II.idinc=IIT.idinc and IIT.ayear=E.ymov	
				join incomelast IL with (nolock) on IL.idinc=II.idinc 
		WHERE E.idexp=II.idpayment and 
						((II.autokind=4 and II.idreg = E.idreg ) or II.autokind in (6,14,20,21))
		  
         ),0),
	E.idreg,
	R.title,
	PE.ct, PE.cu, PE.lt, PE.lu
FROM authpaymentexpense PE
JOIN authpayment P
	ON P.idauthpayment = PE.idauthpayment
JOIN expense E
	ON E.idexp = PE.idexp
JOIN expenseyear EY
	ON EY.idexp = PE.idexp
JOIN expensetotal ET
	ON ET.idexp = PE.idexp
JOIN expensephase EP
	ON EP.nphase = E.nphase
JOIN registry R
	ON R.idreg = E.idreg



GO
