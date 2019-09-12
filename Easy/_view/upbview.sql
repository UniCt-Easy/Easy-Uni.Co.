-- CREAZIONE VISTA upbview
IF EXISTS(select * from sysobjects where id = object_id(N'[upbview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbview]
GO

--setuser 'amm'
--clear_table_info 'upb,upbview'
--select * from upbview

CREATE VIEW [upbview]
(
	idupb,
	codeupb,
	title,
	paridupb,
	idunderwriter,
	idman,
	manager,
	underwriter,
	printingorder,
	requested,
	granted,
	previousappropriation,
	previousassessment,
	expiration,
	assured,
	active,
	cupcode,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	flagactivity,
	flagkind,
	newcodeupb,
	start,
	stop,
	cigcode,
	idtreasurer,
	codetreasurer,
	idepupbkind,
	flag,
	cu, 
	ct, 
	lu, 
	lt
)
AS 
SELECT 
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.paridupb,
	upb.idunderwriter,
	upb.idman,
	manager.title,
	underwriter.description,
	upb.printingorder,
	upb.requested,
	upb.granted,
	upb.previousappropriation,
	upb.previousassessment,
	upb.expiration,
	upb.assured,
	upb.active,
	upb.cupcode,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	upb.flagactivity,
	upb.flagkind,
	upb.newcodeupb,
	upb.start,
	upb.stop,
	upb.cigcode,
	upb.idtreasurer,
	treasurer.codetreasurer,
	upb.idepupbkind,
	upb.flag,
	upb.cu, 
	upb.ct, 
	upb.lu, 
	upb.lt
FROM 	upb with (nolock)
LEFT OUTER JOIN manager with (nolock)	ON manager.idman = upb.idman
LEFT OUTER JOIN underwriter with (nolock)	ON underwriter.idunderwriter = upb.idunderwriter
LEFT OUTER JOIN treasurer 	ON upb.idtreasurer=treasurer.idtreasurer
GO
