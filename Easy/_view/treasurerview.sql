-- CREAZIONE VISTA treasurerview
IF EXISTS(select * from sysobjects where id = object_id(N'[treasurerview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [treasurerview]
GO

CREATE  VIEW [treasurerview] (
	ayear,
	treasurerstart,
	currentfloatfund,
	idtreasurer,
	codetreasurer,
 	description,
	cin,
	idbank,
	banktitle,
	idcab,
	cabtitle,
	cc,
	iban,
	bic,
	address,
	cap,
	city,
	country,
	phoneprefix,
	phonenumber,
	faxprefix,
	faxnumber,
	flagdefault,
	agencycodefortransmission,
	depcodefortransmission,
	cabcodefortransmission,
	idaccmotive_proceeds,
	codemotive_proceeds,
	motive_proceeds,
	idaccmotive_payment,
	codemotive_payment,
	motive_payment,
	trasmcode,
	annotations,
	flagedisp,
	enable_ndoc_treasurer,
	header,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	active,
	flag,
	departmentname_fe,
	cu,
	ct,
	lu,
	lt
)
	AS
SELECT
	accountingyear.ayear,
	ISNULL(treasurerstart.amount, 0),
	isnull(treasurercashtotal.currentfloatfund,0),
	treasurer.idtreasurer,
	treasurer.codetreasurer,
	treasurer.description,
	treasurer.cin,
	treasurer.idbank,
	bank.description,
	treasurer.idcab,
	cab.description,
	treasurer.cc,
	treasurer.iban,
	treasurer.bic,
	treasurer.address,
	treasurer.cap,
	treasurer.city,
	treasurer.country,
	treasurer.phoneprefix,
	treasurer.phonenumber,
	treasurer.faxprefix,
	treasurer.faxnumber,
	treasurer.flagdefault,
	treasurer.agencycodefortransmission,
	treasurer.depcodefortransmission,
	treasurer.cabcodefortransmission,
	treasurer.idaccmotive_proceeds,
	acc_pro.codemotive,
	acc_pro.title,
	treasurer.idaccmotive_payment,
	acc_pay.codemotive,
	acc_pay.title,
	treasurer.trasmcode,
	treasurer.annotations,
	treasurer.flagedisp,
	treasurer.enable_ndoc_treasurer,
	treasurer.header,
	treasurer.idsor01,treasurer.idsor02,treasurer.idsor03,treasurer.idsor04,treasurer.idsor05,
	treasurer.active,
	treasurer.flag,
	treasurer.departmentname_fe,
	treasurer.cu,
	treasurer.ct,
	treasurer.lu,
	treasurer.lt
	FROM treasurer (NOLOCK)
	CROSS JOIN accountingyear
	LEFT OUTER JOIN treasurerstart
	ON treasurerstart.idtreasurer = treasurer.idtreasurer  
	and  treasurerstart.ayear = accountingyear.ayear
	LEFT OUTER JOIN treasurercashtotal
	ON treasurercashtotal.idtreasurer = treasurer.idtreasurer  
	and  treasurercashtotal.ayear = accountingyear.ayear
	LEFT OUTER JOIN bank (NOLOCK)
	ON bank.idbank = treasurer.idbank
	LEFT OUTER JOIN cab (NOLOCK)
	ON cab.idbank = treasurer.idbank
	AND cab.idcab = treasurer.idcab
	LEFT OUTER JOIN accmotive acc_pro
	ON acc_pro.idaccmotive = treasurer.idaccmotive_proceeds
	LEFT OUTER JOIN accmotive acc_pay
	ON acc_pay.idaccmotive = treasurer.idaccmotive_payment



GO


 