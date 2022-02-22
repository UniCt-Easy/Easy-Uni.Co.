
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


-- CREAZIONE VISTA listclassyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[listclassyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [listclassyearview]
GO
--setuser 'amministrazione'
--clear_table_info 'listclassyearview'
--select * from amm.listclassyearview
CREATE     VIEW  [listclassyearview]
(
	idlistclass, 
	ayear,
	active,
	codelistclass,
	paridlistclass,
	printingorder,
	title,
	authrequired,
	idaccmotive,
	codemotive,
	motive,
	idinv,
	codeinv,
	inventorytree,
	assetkind,
	va3type,
	flag,
	idintrastatsupplymethod,
	intra12operationkind,
	idintrastatservice,
	codeintrastatservice,
	intrastatservice,
	idintrastatcode,
	codeintrastatcode,
	intrastatcode,
	idintrastatmeasure,
	measurecode,
	measuredescription,
	cu,
	ct,
	lu,
	lt,
	flagvisiblekind,
	idfinmotive,
	fincodemotive,
	finmotive,
	idaccmotivecredit,
	codemotivecredit,
	motivecredit
)
AS SELECT
	listclassyear.idlistclass, 
	listclassyear.ayear, 
	listclass.active,
	listclass.codelistclass,
	listclass.paridlistclass,
	listclass.printingorder,
	listclass.title,
	listclass.authrequired,
	listclass.idaccmotive,
	costo.codemotive,
	costo.title,
	listclass.idinv,
	inventorytree.codeinv,
	inventorytree.description,
	listclass.assetkind,
	listclass.va3type,
	listclass.flag,
	listclass.idintrastatsupplymethod,
	listclass.intra12operationkind,
	listclassyear.idintrastatservice,
	intrastatservice.code,
	intrastatservice.description,
	listclassyear.idintrastatcode,
	intrastatcode.code,
	intrastatcode.description,
	intrastatcode.idintrastatmeasure,
	intrastatmeasure.code,
	intrastatmeasure.description,
	listclassyear.cu,
	listclassyear.ct,
	listclassyear.lu,
	listclassyear.lt,
	listclass.flagvisiblekind,
	listclass.idfinmotive,
	costofin.codemotive,
	costofin.title,
	listclass.idaccmotivecredit,
	creddeb.codemotive,
	creddeb.title
FROM listclass
LEFT OUTER JOIN listclassyear		ON listclass.idlistclass = listclassyear.idlistclass
LEFT OUTER JOIN intrastatcode		ON intrastatcode.idintrastatcode = listclassyear.idintrastatcode
LEFT OUTER JOIN intrastatmeasure	ON intrastatcode.idintrastatmeasure = intrastatmeasure.idintrastatmeasure
LEFT OUTER JOIN  intrastatservice	ON intrastatservice.idintrastatservice= listclassyear.idintrastatservice
LEFT OUTER JOIN inventorytree		ON inventorytree.idinv = listclass.idinv
left outer join accmotive costo			on costo.idaccmotive=listclass.idaccmotive
left outer join finmotive costofin			on costofin.idfinmotive=listclass.idfinmotive
left outer join accmotive creddeb			on creddeb.idaccmotive=listclass.idaccmotivecredit



GO
