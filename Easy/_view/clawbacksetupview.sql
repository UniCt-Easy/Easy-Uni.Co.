
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


-- CREAZIONE VISTA clawbacksetupview
IF EXISTS(select * from sysobjects where id = object_id(N'[clawbacksetupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [clawbacksetupview]
GO


-- select * from clawbacksetupview
--setuser 'amministrazione'
CREATE VIEW clawbacksetupview 
(
	idclawback,	clawback,	clawbackref,
	ayear,
	clawbackfinance,	codefin,	finance,
	idaccmotive,	codemotive,	accmotive,
	idreg,	registry,
	idfin_s,	codefin_s,	finance_s,
	cu,	ct,	lu,	lt
)
  AS SELECT
	clawbacksetup.idclawback,	clawback.description,	clawback.clawbackref,
	clawbacksetup.ayear,
	clawbacksetup.clawbackfinance,	fin.codefin,	fin.title,
	clawbacksetup.idaccmotive,	accmotive.codemotive,	accmotive.title,  
	registry.idreg,	registry.title,
	clawbacksetup.idfin_s,	fin_s.codefin,	fin_s.title,
	clawbacksetup.cu,	clawbacksetup.ct,	clawbacksetup.lu,	clawbacksetup.lt
FROM clawbacksetup
JOIN clawback 					ON clawback.idclawback = clawbacksetup.idclawback
LEFT OUTER JOIN fin				ON fin.idfin = clawbacksetup.clawbackfinance
LEFT OUTER JOIN fin fin_s			ON fin_s.idfin = clawbacksetup.idfin_s
LEFT OUTER JOIN accmotive		ON accmotive.idaccmotive = clawbacksetup.idaccmotive
LEFT OUTER JOIN registry		ON registry.idreg = clawback.idreg






GO
