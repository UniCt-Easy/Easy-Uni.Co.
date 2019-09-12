
-- CREAZIONE VISTA underwritingview
IF EXISTS(select * from sysobjects where id = object_id(N'[underwritingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [underwritingview]
GO


--clear_table_info'underwritingview'
CREATE VIEW underwritingview 
(
	idunderwriting,
	ayear,
	title,
	codeunderwriting,
	idunderwriter,
	underwriter,
	active,	
	doc,
	docdate,		
	prevision,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	underwriting.idunderwriting,
	underwritingyear.ayear,
	underwriting.title,
	underwriting.codeunderwriting,
	underwriting.idunderwriter,
	underwriter.description,
	underwriting.active,
	underwriting.doc,
	underwriting.docdate,	
	underwritingyear.prevision,
	underwriting.idsor01,
	underwriting.idsor02,
	underwriting.idsor03,
	underwriting.idsor04,
	underwriting.idsor05,
	underwriting.cu, 
	underwriting.ct, 
	underwriting.lu,
	underwriting.lt 
FROM underwriting
LEFT OUTER JOIN underwriter
	ON underwriting.idunderwriter = underwriter.idunderwriter
LEFT OUTER JOIN underwritingyear
	ON underwriting.idunderwriting = underwritingyear.idunderwriting


