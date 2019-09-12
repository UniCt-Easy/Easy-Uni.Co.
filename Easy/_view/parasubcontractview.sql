-- CREAZIONE VISTA parasubcontractview
IF EXISTS(select * from sysobjects where id = object_id(N'[parasubcontractview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [parasubcontractview]
GO

--setuser'amministrazione'
--clear_table_info 'parasubcontractview'
--select * from parasubcontractview
CREATE   VIEW parasubcontractview
(
	ayear,
	idcon, ycon, ncon,
	idreg,
	idupb,
	codeupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	registry,
	iddaliaposition,
	codedaliaposition,
	daliaposition,
	matricula,
	duty,
	idpayrollkind,
	payroll,
	idser,
	service,
	codeser,
	idresidence, 
	city,
	idcountry,
	country,
	employed,
	payrollccinfo,
	start,
	stop, 
	monthlen,
	grossamount,
	activitycode,
	activity,
	idotherinsurance,
	otherinsurance,
	idpat, 
	patcode,
	pat,
	idmatriculabook,
	matriculabook,
	regionaltax, 
	countrytax,
	citytax,
	ratequantity,
	startmonth,
	suspendedregionaltax,
	suspendedcountrytax,
	suspendedcitytax,
	notaxappliance,
	applybrackets,
	highertax,
	taxablecud,
	cuddays,
	taxablecontract,
	ndays, 
	taxablepension,
	fiscaldeduction,
	notaxdeduction,
	taxablegross,
	taxablenet, 
	startcompetency,
	stopcompetency,
	idemenscontractkind,
	txt,
	emenscontractkind,
	annualincome,
	flagbonusappliance,
	flagexcludefromcertificate,
	citytax_account, ratequantity_account, startmonth_account,
	idaccmotive,
	codemotive,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	idsor1,idsor2,idsor3,
	idrelated,
	idsor_siope,
	requested_doc
)
AS SELECT 
	i1.ayear,
	c1.idcon, c1.ycon, c1.ncon,
	c1.idreg,
	c1.idupb,
	upb.codeupb,
	isnull(c1.idsor01,UPB.idsor01),
	isnull(c1.idsor02,UPB.idsor02),
	isnull(c1.idsor03,UPB.idsor03),
	isnull(c1.idsor04,UPB.idsor04),
	isnull(c1.idsor05,UPB.idsor05),
	c2.title,
	DP.iddaliaposition,
	DP.codedaliaposition,
	DP.description,
	c1.matricula,
	c1.duty, 
	c1.idpayrollkind,
	d1.description,
	c1.idser,
	t1.description,
	t1.codeser,
	i1.idresidence, 
	g1.title,
	g2.idcountry,
	g2.title,
	c1.employed,
	c1.payrollccinfo,
	c1.start,
	c1.stop, 
	c1.monthlen,
	c1.grossamount,
	i1.activitycode,
	a2.description,
	i1.idotherinsurance,
	a1.description,
	c1.idpat, 
	p1.patcode,
	p1.description,
	c1.idmatriculabook,
	t2.description,
	i1.regionaltax, 
	i1.countrytax,
	i1.citytax,
	i1.ratequantity,
	i1.startmonth,
	i1.suspendedregionaltax,
	i1.suspendedcountrytax,
	i1.suspendedcitytax,
	i1.notaxappliance,
	i1.applybrackets,
	i1.highertax,
	i1.taxablecud,
	i1.cuddays,
	i1.taxablecontract,
	i1.ndays,
	i1.taxablepension,
	i1.fiscaldeduction,
	i1.notaxdeduction,
	i1.taxablegross,
	i1.taxablenet, 
	i1.startcompetency,
	i1.stopcompetency,
	i1.idemenscontractkind,
	c1.txt,
	etr.description,
	i1.annualincome,
	i1.flagbonusappliance,
	i1.flagexcludefromcertificate,
	i1.citytax_account, i1.ratequantity_account, i1.startmonth_account,
	c1.idaccmotive,
	AM.codemotive,
	c1.idaccmotivedebit,
	DB.codemotive,
	c1.idaccmotivedebit_crg,
	CRG.codemotive,
	c1.idaccmotivedebit_datacrg,
	c1.idsor1,c1.idsor2,c1.idsor3,
	'parasubcontract§'+ convert(varchar(10),c1.idcon),
	idsor_siope,
	c1.requested_doc
FROM parasubcontract c1
INNER JOIN parasubcontractyear i1
	ON c1.idcon = i1.idcon
LEFT OUTER JOIN geo_city g1
	ON i1.idresidence = g1.idcity
LEFT OUTER JOIN geo_country g2
	ON g1.idcountry = g2.idcountry
LEFT OUTER JOIN registry c2
	ON c1.idreg = c2.idreg
LEFT OUTER JOIN service t1
	ON c1.idser = t1.idser
LEFT OUTER JOIN otherinsurance a1
	ON i1.idotherinsurance = a1.idotherinsurance AND a1.ayear = i1.ayear
LEFT OUTER JOIN inpsactivity a2
	ON i1.activitycode = a2.activitycode AND i1.ayear = a2.ayear
LEFT OUTER JOIN pat p1
	ON p1.idpat = c1.idpat
LEFT OUTER JOIN matriculabook t2
	ON t2.idmatriculabook = c1.idmatriculabook
LEFT OUTER JOIN payrollkind d1
	ON d1.idpayrollkind = c1.idpayrollkind
LEFT OUTER JOIN emenscontractkind etr
	ON etr.idemenscontractkind = i1.idemenscontractkind AND etr.ayear = i1.ayear
LEFT OUTER JOIN accmotive AM
	ON AM.idaccmotive = c1.idaccmotive
LEFT OUTER JOIN accmotive DB
	ON DB.idaccmotive =  c1.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG
	ON CRG.idaccmotive = c1.idaccmotivedebit_crg
LEFT OUTER JOIN upb 
	ON upb.idupb = c1.idupb
LEFT OUTER JOIN dalia_position DP
	ON DP.iddaliaposition = c1.iddaliaposition

GO

 