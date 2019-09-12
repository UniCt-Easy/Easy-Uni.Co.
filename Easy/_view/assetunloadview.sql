-- CREAZIONE VISTA assetunloadview
-- clear_table_info'assetunloadview'
IF EXISTS(select * from sysobjects where id = object_id(N'[assetunloadview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetunloadview]
GO


CREATE     VIEW assetunloadview
(
	idassetunload,
	idassetunloadkind,
	codeassetunloadkind,
	assetunloadkind,
	yassetunload,
	nassetunload,
	idreg,
	registry,
	idmot,
	codemot,
	assetunloadmotive,
	doc,
	docdate,
	description,
	enactment,
	enactmentdate,
	adate,
	printdate,
	ratificationdate,
	transmitted,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
 	cu,
  	ct,
  	lu,
  	lt,
	assetcurrentvalue,
	assetamortizationamount,
	totalassetunload
)
AS SELECT
	assetunload.idassetunload,
	assetunload.idassetunloadkind,
	assetunloadkind.codeassetunloadkind,
	assetunloadkind.description,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idreg,
	registry.title,
	assetunload.idmot,
	assetunloadmotive.codemot,
	assetunloadmotive.description,
	assetunload.doc,
	assetunload.docdate,
	assetunload.description,
	assetunload.enactment,
	assetunload.enactmentdate,
	assetunload.adate,
	assetunload.printdate,
	assetunload.ratificationdate,
	assetunload.transmitted,
	assetunloadkind.idsor01,
	assetunloadkind.idsor02,
	assetunloadkind.idsor03,
	assetunloadkind.idsor04,
	assetunloadkind.idsor05,
  	assetunload.cu,
  	assetunload.ct,
 	assetunload.lu,
  	assetunload.lt,
	-- assetcurrentvalue
	(select sum(AC.currentvalue) from assetview_current AC
	join asset A
		on AC.idasset = A.idasset and AC.idpiece = A.idpiece
	JOIN assetunload UL 
		   ON UL.idassetunload= A.idassetunload
	 where UL.idassetunload = assetunload.idassetunload),

	-- assetamortizationamount
	- ( select sum( CONVERT(DECIMAL(19,2),ISNULL(assetamortization.assetvalue, 0) * ISNULL(assetamortization.amortizationquota, 0)) )
	from assetamortization
	where assetamortization.idassetunload = assetunload.idassetunload),

	-- totalassetunload
	isnull((select sum(AC.currentvalue) from assetview_current AC
	join asset A
		on AC.idasset = A.idasset and AC.idpiece = A.idpiece
	JOIN assetunload UL 
		   ON UL.idassetunload= A.idassetunload
	 where UL.idassetunload = assetunload.idassetunload),0)
	- isnull(( select sum( CONVERT(DECIMAL(19,2),ISNULL(assetamortization.assetvalue, 0) * ISNULL(assetamortization.amortizationquota, 0)) )
	from assetamortization
	where assetamortization.idassetunload = assetunload.idassetunload),0)
FROM assetunload
JOIN assetunloadkind
	ON assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
LEFT OUTER JOIN registry
	ON registry.idreg = assetunload.idreg
LEFT OUTER JOIN assetunloadmotive
	ON assetunloadmotive.idmot = assetunload.idmot







GO
