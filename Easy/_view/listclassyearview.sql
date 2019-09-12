-- CREAZIONE VISTA listclassyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[listclassyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [listclassyearview]
GO
--setuser 'amm'
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
	finmotive
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
	costofin.title
FROM listclass
LEFT OUTER JOIN listclassyear		ON listclass.idlistclass = listclassyear.idlistclass
LEFT OUTER JOIN intrastatcode		ON intrastatcode.idintrastatcode = listclassyear.idintrastatcode
LEFT OUTER JOIN intrastatmeasure	ON intrastatcode.idintrastatmeasure = intrastatmeasure.idintrastatmeasure
LEFT OUTER JOIN  intrastatservice	ON intrastatservice.idintrastatservice= listclassyear.idintrastatservice
LEFT OUTER JOIN inventorytree		ON inventorytree.idinv = listclass.idinv
left outer join accmotive costo			on costo.idaccmotive=listclass.idaccmotive
left outer join finmotive costofin			on costofin.idfinmotive=listclass.idfinmotive



GO
