
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


-- CREAZIONE VISTA entrydetailaccrualview
IF EXISTS(select * from sysobjects where id = object_id(N'[entrydetailaccrualview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [entrydetailaccrualview]
GO

--setuser 'amm'
--select * from entrydetailaccrualview


CREATE    VIEW entrydetailaccrualview
(
	yentry,
	nentry,
	ndetail,
	idacc,
	idreg,
	idupb,
	amount,
	rateamount,
	available,
	flagap,
	idsor1,
	idsor2,
	idsor3,
	ct,
	cu,
	lt,
	lu,
	codeupb,
	codeacc,
	account,
	registry, 
	upb,
	idaccountkind,
	flagregistry,
	flagupb, 
	idrelated,
	description,
	adate,
	doc,
	docdate,
	idaccmotive,
	accmotive,
	codemotive,
	identrykind,
	competencystart,
	competencystop,
	flagaccountusage,
	idepexp,
	idepacc
)
AS SELECT
entrydetail.yentry,
entrydetail.nentry,
entrydetail.ndetail,
entrydetail.idacc,
entrydetail.idreg,
entrydetail.idupb,
ABS(ISNULL(entrydetail.amount,0)),
ISNULL((SELECT SUM(amount) 
        FROM   entrydetailaccrual 
        WHERE  yentrylinked  = entrydetail.yentry AND
               nentrylinked  = entrydetail.nentry AND
               ndetaillinked = entrydetail.ndetail),0),
	ABS(ISNULL(entrydetail.amount,0)
	- 
	ISNULL((SELECT SUM(amount) 
	        FROM   entrydetailaccrual 
	        WHERE  yentrylinked  = entrydetail.yentry AND
	               nentrylinked  = entrydetail.nentry AND
	               ndetaillinked = entrydetail.ndetail),0)),
CASE 
WHEN ISNULL(entrydetail.amount,0)>0 THEN 'P'ELSE 'A'END,
entrydetail.idsor1,
entrydetail.idsor2,
entrydetail.idsor3,
entrydetail.cu,
entrydetail.ct,
entrydetail.lu,
entrydetail.lt,
upb.codeupb,
account.codeacc,
account.title,
registry.title, 
upb.title,
account.idaccountkind,
account.flagregistry,
account.flagupb,
entrydetail.idaccmotive,
entry.idrelated,
entry.description,
entry.adate,
entry.doc,
entry.docdate,
accmotive.title,
accmotive.codemotive,
entry.identrykind,
entrydetail.competencystart,
entrydetail.competencystop,
account.flagaccountusage,
entrydetail.idepexp,
entrydetail.idepacc
FROM entrydetail 
INNER JOIN entry		ON entrydetail.yentry = entry.yentry
					AND entrydetail.nentry = entry.nentry
LEFT OUTER JOIN registry	ON entrydetail.idreg = registry.idreg
LEFT OUTER JOIN upb			ON entrydetail.idupb = upb.idupb
LEFT OUTER JOIN account		ON entrydetail.idacc = account.idacc
LEFT OUTER JOIN  accmotive	ON entrydetail.idaccmotive = accmotive.idaccmotive
--LEFT OUTER JOIN entrydetailaccrual	ON   entrydetail.yentry = entrydetailaccrual.yentrylinked 
	--				AND  entrydetail.nentry = entrydetailaccrual.nentrylinked 
		--			AND  entrydetail.ndetail = entrydetailaccrual.ndetaillinked 
/*
JOIN config 
ON   entrydetail.yentry = config.ayear
AND  (entrydetail.idacc  = config.idacc_accruedcost OR
      entrydetail.idacc  = config.idacc_accruedrevenue OR	  	  
	  )
*/
--WHERE entry.identrykind = '2' -- tipo scrittura = rateo

--select * from entrydetailaccrualview


