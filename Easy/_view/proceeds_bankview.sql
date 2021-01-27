
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


-- CREAZIONE VISTA proceeds_bankview
IF EXISTS(select * from sysobjects where id = object_id(N'[proceeds_bankview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceeds_bankview]
GO
--setuser 'amm'
 --select * from proceeds_bankview where ypro = 2020
CREATE  VIEW proceeds_bankview
(
	kpro,
	ypro,
	npro,
	idpro,
	nmov,
	idreg,
	registry,
	description,
	amount,
	performed,
	notperformed,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	PB.idpro,
	E.nmov,
	PB.idreg,
	R.title,
	PB.description,
	PB.amount,
	-- ESITATO PERFORMED
	ISNULL((SELECT SUM(amount) from banktransaction P where
		P.kpro=PB.kpro  AND P.idpro=PB.idpro ),0),
	-- NON ESITATO NOT PERFORMED
	(SELECT SUM(curramount) from incometotal I join income S on I.idinc=S.idinc 
		JOIN incomelast IL ON IL.idinc = S.idinc
	  WHERE IL.kpro=PB.kpro AND IL.idpro=PB.idpro AND I.ayear = proceeds.ypro)
	  -ISNULL( (SELECT SUM(amount) from banktransaction P where
		P.kpro=PB.kpro  AND P.idpro=PB.idpro ),0),
	PB.ct,
	PB.cu,
	PB.lt,
	PB.lu
FROM proceeds_bank PB
JOIN proceeds 	ON proceeds.kpro = PB.kpro
left outer join incomelast EL on PB.idpro=EL.idpro and PB.kpro=EL.kpro
left outer join income E on EL.idinc=E.idinc
JOIN registry R	ON R.idreg = PB.idreg







GO
