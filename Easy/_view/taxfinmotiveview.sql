
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


-- CREAZIONE VISTA taxfinmotiveview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxfinmotiveview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxfinmotiveview]
GO


CREATE  VIEW [taxfinmotiveview](
	taxcode,
	taxref,
	tax,
	idser,
	service,
	codeser,
	idmotincomeintra, codemotiveincomeintra,finmotive_incomeintra,
	idmotincomeemploy, codemotiveincomeemploy, finmotive_incomeemploy,
	idmotadmintax, codemotiveadmintax, finmotive_admintax,
	idmotexpenseemploy, codemotiveexpenseemploy, finmotive_expenseemploy,
	idmotexpensecontra, codemotiveexpensecontra, finmotive_expensecontra,
	lt,ct,lu,cu
)
AS SELECT
	taxfinmotive.taxcode,	tax.taxref,	tax.description,
	taxfinmotive.idser,	service.description,	service.codeser,
	taxfinmotive.idmotincomeintra,		finmotive_incomeintra.codemotive,	finmotive_incomeintra.title, 
	taxfinmotive.idmotincomeemploy,		finmotive_incomeemploy.codemotive,	finmotive_incomeemploy.title,
	taxfinmotive.idmotadmintax,			finmotive_admintax.codemotive,		finmotive_admintax.title,
	taxfinmotive.idmotexpenseemploy,	finmotive_expenseemploy.codemotive, finmotive_expenseemploy.title,
	taxfinmotive.idmotexpensecontra,	finmotive_expensecontra.codemotive, finmotive_expensecontra.title,
	taxfinmotive.lt,
	taxfinmotive.ct,
	taxfinmotive.lu,
	taxfinmotive.cu
FROM taxfinmotive
join tax
	on taxfinmotive.taxcode= tax.taxcode
join service
	on taxfinmotive.idser = service.idser
left outer join finmotive as finmotive_incomeintra
	on taxfinmotive.idmotincomeintra = finmotive_incomeintra.idfinmotive
left outer join finmotive as finmotive_incomeemploy
	on taxfinmotive.idmotincomeemploy = finmotive_incomeemploy.idfinmotive
left outer join finmotive as finmotive_admintax
	on taxfinmotive.idmotadmintax = finmotive_admintax.idfinmotive
left outer join finmotive as finmotive_expenseemploy
	on taxfinmotive.idmotexpenseemploy = finmotive_expenseemploy.idfinmotive
left outer join finmotive as finmotive_expensecontra
	on taxfinmotive.idmotexpensecontra = finmotive_expensecontra.idfinmotive


GO

