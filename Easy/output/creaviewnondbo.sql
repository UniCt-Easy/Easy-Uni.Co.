IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetview_current') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetview_current
GO


CREATE     VIEW [assetview_current]
(
	idasset,
	idpiece,
	start,
	revals,
	revals_pending,
	subtractions,
	currentvalue,
	is_unloaded,
	is_loaded
)
AS SELECT
	asset.idasset,
	asset.idpiece,
	   CASE	
			WHEN (inventorykind.flag & 1 <> 0)
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
			ELSE
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
	END,
	--revals applied
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization
				/*JOIN  inventoryamortization
				 ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA
					ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL
					ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is not null)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is not null)
					)
			 	)
				)
				--AND   (inventoryamortization.flag & 2 <> 0)
		),0),
	--revals pending
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization
				/*JOIN  inventoryamortization
				ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA
					ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL
					ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is  null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is  null)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is  null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is  null)
					)
			 	)
				)				
				--AND   (inventoryamortization.flag & 2 <> 0)
				)
			,0),
	CASE	WHEN idpiece=1 THEN
	ISNULL(
			(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2)))
			 from assetacquire B
				join asset A
				on B.nassetacquire = A.nassetacquire
				where A.idasset = asset.idasset
				and   A.idpiece >1
				and   A.idassetunload IS NOT NULL
				and  ((B.flag & 1 <> 1) AND (B.flag & 2 <> 0)))
			,0)
	ELSE 0
	END,
	--valore iniziale cespiti
   CASE	
			----------------------------------------------------------------------------------
			----------------- Considera i buoni di carico cespiti precedenti al 2005   -------
			----------------------------------------------------------------------------------
			WHEN (inventorykind.flag & 1 <> 0) 
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
			ELSE
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))		
	END
	--ammortamenti e rivalutazioni ufficiali	
	+
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization
				/*JOIN  inventoryamortization
				ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA
					ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL
					ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
					( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is not null)
					))
					OR 
			            
					( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is not null)
					))
					)
				--AND   (inventoryamortization.flag & 2 <> 0)
				)
		,0)
	------------------------------------------------------------------------------------------
	-- Sottrae gli accessori scaricati caricati come posseduti e già inclusi nel cespite -----
	------------------------------------------------------------------------------------------	
	-
	CASE	WHEN idpiece=1 THEN
	ISNULL(
			(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2)))
			 from assetacquire B
				join asset A
				on B.nassetacquire = A.nassetacquire
				where A.idasset = asset.idasset
				and   A.idpiece >1
				and   A.idassetunload IS NOT NULL
				and  ((B.flag & 1 = 0) AND (B.flag & 2 <> 0)))
			,0)
	ELSE 0
	END,

	CASE 
		when assetunload.adate IS NOT NULL or (asset.flag & 1 = 0)
			THEN 'S'
		ELSE
			'N'
	END,
	CASE 
		when assetload.ratificationdate IS NOT NULL or ((assetacquire.flag & 1 = 0) AND (assetacquire.flag & 2 <> 0))
			THEN 'S'
		ELSE
			'N'
	END

FROM asset 
		 JOIN assetacquire 
		   ON assetacquire.nassetacquire = asset.nassetacquire
		 LEFT OUTER JOIN assetload
		   ON assetload.idassetload = assetacquire.idassetload
		 LEFT OUTER JOIN assetunload
		   ON assetunload.idassetunload= asset.idassetunload
		 JOIN inventory 
		   ON inventory.idinventory = assetacquire.idinventory
		 JOIN inventorykind
		   ON inventory.idinventorykind= inventorykind.idinventorykind  


GO

print '[assetview_current] OK'

IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'lcardvarview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW lcardvarview
GO

CREATE    VIEW [lcardvarview]
(
	ylvar,
	nlvar,
	idlcard,
	idlcardvar,
	amount,
	idupb,
	idfin,
	lt,
	lu,
	email,
	yvar,
	nvar,
	description,
	adate,
	title,
	lcard,
	extcode,
	codeupb,
	upb,
	paridupb,
	ayear,
	codefin,
	fin,
	nlevel,
	paridfin,
	parcodefin,
	parfintitle,
	parfinlevel,
	idman,
	manager,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT 
	lcardvar.ylvar,
	lcardvar.nlvar,
	lcardvar.idlcard,
	lcardvar.idlcardvar,
	lcardvar.amount,
	lcardvar.idupb,
	lcardvar.idfin,
	lcardvar.lt,
	lcardvar.lu,
	lcardvar.email,
	lcardvar.yvar,
	lcardvar.nvar,
	lcardvar.description,
	lcardvar.adate,
	lcard.title,
	lcard.description,
	lcard.extcode,
	upb.codeupb,
	upb.title,
	upb.paridupb,
	f.ayear,
	f.codefin,
	f.title,
	f.nlevel,
	f1.idfin,
	f1.codefin,
	f1.title,
	f1.nlevel,
	manager.idman,
	manager.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
FROM lcardvar
	JOIN lcard
		ON lcardvar.idlcard = lcard.idlcard
	LEFT OUTER JOIN upb
		ON lcardvar.idupb = upb.idupb
	LEFT OUTER  JOIN fin f
		ON f.idfin = lcardvar.idfin
		AND f.ayear = lcardvar.ylvar
	LEFT OUTER JOIN fin f1
		ON f.paridfin = f1.idfin
		AND f.ayear = f1.ayear
	LEFT OUTER JOIN manager
		on lcard.idman= manager.idman



GO

print '[lcardvarview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expenseclawbackview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expenseclawbackview
GO

CREATE              VIEW expenseclawbackview 
(
	idexp,
	idclawback,
	description,
	clawbackref,
	amount,
	rateableallowance,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expenseclawback.idexp,
	expenseclawback.idclawback,
	clawback.description,
	clawback.clawbackref,
	expenseclawback.amount,
	expenseclawback.amount,
	expenseclawback.cu,
	expenseclawback.ct,
	expenseclawback.lu,
	expenseclawback.lt
FROM expenseclawback
JOIN clawback
	ON clawback.idclawback = expenseclawback.idclawback




GO

print 'expenseclawbackview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatedetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatedetailview
GO



CREATE      VIEW [mandatedetailview]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mankind,
	idinv,
	codeinv,
	inventorytree,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	assetkind,
	start,
	stop,
	idexp_taxable,
	idexp_iva,	
	taxable_euro,
	iva_euro,
	rowtotal,
	idupb,
	codeupb,
	upb,
	idman,
	manager,
	cu,
	ct,
	lu,
	lt,
	idaccmotive,
	codemotive,
	idaccmotiveannulment,
	codemotiveannulment,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	competencystart,
	competencystop,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	toinvoice,
	exchangerate,
	description,
	flagactivity,
	va3type,
	flagintracom,
	ivanotes,
	idlist,
	intcode,
	idunit,
	idpackage,
	unitsforpackage,
	npackage,
	idstore,
	store,
	cupcode,
	flagto_unload,
	applierannotations,cigcode,ninvoiced,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	epkind
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.rownum,
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
 	mandatedetail.idreg,
  	registry.title,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	mandatedetail.taxable,
	mandatedetail.taxrate,
	mandatedetail.tax,
  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva,
 	    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		),
	ROUND(mandatedetail.tax,2),
	ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)+
	ROUND(mandatedetail.tax,2),
	mandatedetail.idupb,
	upb.codeupb,
	upb.title,
	mandate.idman,
	manager.title,
	mandatedetail.cu,
	mandatedetail.ct,
	mandatedetail.lu,
	mandatedetail.lt,
	mandatedetail.idaccmotive,
	accmotive.codemotive,
	mandatedetail.idaccmotiveannulment,
	accmotiveannulment.codemotive,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	mandatedetail.competencystart,
	mandatedetail.competencystop,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandate.exchangerate,
	mandate.description,
	mandatedetail.flagactivity,
	mandatedetail.va3type,
	mandate.flagintracom,
	mandatedetail.ivanotes,
	mandatedetail.idlist,
	list.intcode,
	mandatedetail.idunit,
	mandatedetail.idpackage,
	mandatedetail.unitsforpackage,
	mandatedetail.npackage,
	mandate.idstore,
	store.description,
	mandatedetail.cupcode,
	mandatedetail.flagto_unload,
	mandatedetail.applierannotations,mandatedetail.cigcode,mandatedetail.ninvoiced,
	COALESCE (mandate.idsor01,mandatekind.idsor01,upb.idsor01),
	COALESCE (mandate.idsor02,mandatekind.idsor02,upb.idsor02),
	COALESCE (mandate.idsor03,mandatekind.idsor03,upb.idsor03),
	COALESCE (mandate.idsor04,mandatekind.idsor04,upb.idsor04),
	COALESCE (mandate.idsor05,mandatekind.idsor05,upb.idsor05),
	mandatedetail.epkind
FROM mandatedetail with (nolock)
JOIN mandatekind with (nolock)
	ON mandatekind.idmankind = mandatedetail.idmankind
JOIN ivakind with (nolock)
	ON ivakind.idivakind = mandatedetail.idivakind
LEFT JOIN inventorytree with (nolock)
	ON inventorytree.idinv = mandatedetail.idinv
JOIN mandate with (nolock)
	ON mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN registry with (nolock)
	ON registry.idreg = mandatedetail.idreg
LEFT OUTER JOIN upb with (nolock)
	ON upb.idupb = mandatedetail.idupb
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = mandate.idman
LEFT OUTER JOIN accmotive with (nolock)
	ON accmotive.idaccmotive = mandatedetail.idaccmotive
LEFT OUTER JOIN accmotive accmotiveannulment with (nolock)
	ON accmotiveannulment.idaccmotive = mandatedetail.idaccmotiveannulment
LEFT OUTER JOIN sorting sorting1 with (nolock)
	ON sorting1.idsor = mandatedetail.idsor1
LEFT OUTER JOIN sorting sorting2 with (nolock)
	ON sorting2.idsor = mandatedetail.idsor2
LEFT OUTER JOIN sorting sorting3 with (nolock)
	ON sorting3.idsor = mandatedetail.idsor3
LEFT OUTER JOIN store  with (nolock)
	ON store.idstore = mandate.idstore
LEFT OUTER JOIN list with (nolock)
	ON list.idlist = mandatedetail.idlist




GO

print '[mandatedetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetlocationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetlocationview
GO


CREATE              VIEW [assetlocationview]
(
	idasset,
	start,
	idlocation,
	locationcode,
	location,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetlocation.idasset,
	assetlocation.start,
	assetlocation.idlocation,
	location.locationcode,
	location.description,
	assetlocation.cu,
	assetlocation.ct,
	assetlocation.lu,
	assetlocation.lt
FROM assetlocation
JOIN location
	ON location.idlocation = assetlocation.idlocation



GO

print '[assetlocationview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'casualcontractview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW casualcontractview
GO



CREATE VIEW [casualcontractview]
(
	ayear,
	ycon,
	ncon,
	start,
	stop,
	adate,
	idreg,
	registry,
	idupb,
	codeupb,
	upb,
	feegross,
	total,
	taxableotheragency,
	idser,
	service,
	codeser,
	description,
	ndays,
	activitycode,
	activity,
	idotherinsurance,
	otherinsurance,
	idemenscontractkind,
	emenscontractkind,
	flaghigherrate,
	completed,
	idaccmotive,
	codemotive,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	idsor1,
	idsor2,
	idsor3,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	authneeded,
	authdoc,
	authdocdate,
	noauthreason,
	cu,
	ct,
	lu,
	lt,
	txt
)
AS SELECT 
	ICOP.ayear,
	COP.ycon,
	COP.ncon,
	COP.start,
	COP.stop,
	COP.adate,
	COP.idreg,
	registry.title,
	COP.idupb,
	UPB.codeupb,
	UPB.title,
	COP.feegross,
	COP.feegross + isnull((select sum(CTAX.admintax)
		from casualcontracttax CTAX
		where  COP.ycon = CTAX.ycon AND COP.ncon = CTAX.ncon),0)
	,
	ICOP.taxableotheragency,
	COP.idser,
	service.description,
	service.codeser,
	COP.description,
	COP.ndays,
	ICOP.activitycode,
	API.description,
	ICOP.idotherinsurance,
	AFA.description,
	ICOP.idemenscontractkind,
	ETR.description,
	ICOP.flaghigherrate,
	COP.completed,
	COP.idaccmotive,
	AM.codemotive,
	COP.idaccmotivedebit,
	DB.codemotive,
	COP.idaccmotivedebit_crg,
	CRG.codemotive,
	COP.idaccmotivedebit_datacrg,
	COP.idsor1,
	COP.idsor2,
	COP.idsor3,
	isnull(COP.idsor01,UPB.idsor01),
	isnull(COP.idsor02,UPB.idsor02),
	isnull(COP.idsor03,UPB.idsor03),
	isnull(COP.idsor04,UPB.idsor04),
	isnull(COP.idsor05,UPB.idsor05),
	COP.authneeded,
	COP.authdoc,
	COP.authdocdate,
	COP.noauthreason,
	COP.cu,
	COP.ct,
	COP.lu,
	COP.lt,
	COP.txt
FROM casualcontract COP (nolock)
JOIN casualcontractyear ICOP (nolock)
	ON COP.ycon = ICOP.ycon
	AND COP.ncon = ICOP.ncon
JOIN registry (nolock)
	ON registry.idreg = COP.idreg
LEFT OUTER JOIN UPB (nolock)
	ON UPB.idupb=COP.idupb
JOIN service (nolock)
	ON service.idser = COP.idser
LEFT OUTER JOIN otherinsurance AFA (nolock)
	ON AFA.idotherinsurance = ICOP.idotherinsurance
	AND AFA.ayear = ICOP.ayear 
LEFT OUTER JOIN inpsactivity API (nolock)
	ON API.activitycode = ICOP.activitycode
	AND API.ayear = ICOP.ayear
LEFT OUTER JOIN emenscontractkind ETR (nolock)
	ON ETR.idemenscontractkind = ICOP.idemenscontractkind
	AND ETR.ayear = ICOP.ayear
LEFT OUTER JOIN accmotive AM (nolock)
	ON AM.idaccmotive = COP.idaccmotive
LEFT OUTER JOIN accmotive DB (nolock)
	ON DB.idaccmotive =  COP.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG (nolock)
	ON CRG.idaccmotive = COP.idaccmotivedebit_crg




GO

print '[casualcontractview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetmanagerview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetmanagerview
GO

CREATE              VIEW assetmanagerview
(
	idasset,
	start,
	idman,
	manager,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetmanager.idasset,
	assetmanager.start,
	assetmanager.idman,
	manager.title,
	assetmanager.cu,
	assetmanager.ct,
	assetmanager.lu,
	assetmanager.lt
FROM assetmanager
JOIN manager
	ON manager.idman = assetmanager.idman


GO

print 'assetmanagerview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensewageadditionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensewageadditionview
GO



CREATE     VIEW [expensewageadditionview]
(
	ycon,
	ncon,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	idpayment,
	totflag, 
	flagarrear,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expensewageaddition.ycon,
	expensewageaddition.ncon,
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,	
	upb.codeupb,	
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expense.idpayment,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration,
	expense.adate,
	expensewageaddition.cu,
	expensewageaddition.ct,
	expensewageaddition.lu,
	expensewageaddition.lt
FROM expensewageaddition
JOIN wageaddition
	ON expensewageaddition.ycon = wageaddition.ycon
	AND expensewageaddition.ncon = wageaddition.ncon
JOIN config
	ON config.ayear=expensewageaddition.ycon 
JOIN expense
	ON expense.idexp = expensewageaddition.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN expense former
	ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN payment
	ON expenselast.kpay = payment.kpay
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser





GO

print '[expensewageadditionview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'historypaymentview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW historypaymentview
GO


CREATE                  VIEW [historypaymentview]
(
	idexp,
	ymov,
	nmov,
	adate,
	idreg,
	idman,
	doc,
	docdate,
	description,
	competencydate,
	amount,
	curramount,
	--employtaxamount,
	--admintaxamount,
	--clawbackamount,
	totflag,
	flagarrear,
	kpay,
	ypay,
	npay,
	idfin,idupb
)
AS
SELECT  expense.idexp, 
	config.ayear, 
	expense.nmov, 
	expense.adate,
	expense.idreg, 
	expense.idman, 
	expense.doc, 
	expense.docdate, 
	expense.description, 
	payment.adate, 
	expenseyear.amount, 
	expensetotal.curramount, --expense.employtaxamount, expense.admintaxamount, expense.clawbackamount,
	expensetotal.flag, 
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	payment.kpay,
	payment.ypay, 
	payment.npay, 
	expenseyear.idfin,
	expenseyear.idupb   
FROM config
JOIN expense
	ON expense.ymov = config.ayear
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN expenseyear 
	ON expense.idexp = expenseyear.idexp
	AND config.ayear = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = config.ayear
WHERE  config.cashvaliditykind = 1  --EMITTED
UNION ALL
SELECT 
	expense.idexp, 
	config.ayear, 
	expense.nmov, 
	expense.adate,
	expense.idreg, 
	expense.idman, 
	expense.doc, 
	expense.docdate, 
	expense.description, 
	payment.printdate, 
	expenseyear.amount, 
	expensetotal.curramount, --expense.employtaxamount, expense.admintaxamount, expense.clawbackamount,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	--expenseyear.flagarrear, 
	payment.kpay,
	payment.ypay, 
	payment.npay,  
	expenseyear.idfin,
	expenseyear.idupb
FROM  config
JOIN expense
	ON expense.ymov = config.ayear
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp 
	AND expenseyear.ayear = config.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = config.ayear
WHERE config.cashvaliditykind = 2   --PAYMENT PRINTED
UNION  ALL
SELECT  expense.idexp, 
	config.ayear ,--P.ymov, 
	expense.nmov,
	expense.adate, 
	expense.idreg, 
	expense.idman, 
	expense.doc, 
	expense.docdate, 
	expense.description, 
	paymenttransmission.transmissiondate, 
	expenseyear.amount,
	expensetotal.curramount, --expense.employtaxamount, expense.admintaxamount, expense.clawbackamount,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	--expenseyear.flagarrear, 
	payment.kpay,
	payment.ypay, 
	payment.npay, 
	expenseyear.idfin,
	expenseyear.idupb
FROM config
JOIN expense
	ON expense.ymov = config.ayear
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN paymenttransmission 
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND config.ayear = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = config.ayear
WHERE config.cashvaliditykind = 3 -- PAYMENT COMMUNICATED
UNION ALL
SELECT 
	expense.idexp, 
	config.ayear, 
	expense.nmov, 
	expense.adate,
	expense.idreg, 
	expense.idman, 
	expense.doc, 
	expense.docdate, 
	expense.description, 
	banktransaction.transactiondate, 
	banktransaction.amount, 
	banktransaction.amount, --expense.employtaxamount, expense.admintaxamount, expense.clawbackamount,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	--expenseyear.flagarrear, 
	payment.kpay,
	payment.ypay, 
	payment.npay, 
	expenseyear.idfin,
	expenseyear.idupb
FROM  config 
JOIN expense
	ON expense.ymov = config.ayear
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND config.ayear = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = config.ayear
JOIN banktransaction
	ON banktransaction.idexp = expense.idexp
	AND banktransaction.yban = config.ayear        
WHERE  config.cashvaliditykind = 4  --PERFORMED


GO

print '[historypaymentview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'historyproceedsview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW historyproceedsview
GO

CREATE                 VIEW historyproceedsview
(
	idinc,
	ymov,
	nmov,
	adate,
	idreg,
	idman,
	doc,
	docdate,
	description,
	competencydate,
	amount,
	curramount,
	totflag,
	flagarrear,
	kpro,
	ypro,
	npro,
	idfin,idupb
)
AS
SELECT 
	income.idinc, 
	config.ayear, 
	income.nmov, 
	income.adate,
	income.idreg, 
	income.idman, 
	income.doc, 
	income.docdate, 
	income.description, 
	proceeds.adate, 
	--income.amount, 
	incomeyear.amount,
	incometotal.curramount, 
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	--incomeyear.flagarrear, 
	proceeds.kpro,
	proceeds.ypro, 
	proceeds.npro, 
	incomeyear.idfin,
	incomeyear.idupb
FROM config	
JOIN income
	ON income.ymov = config.ayear
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND config.ayear= incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = config.ayear
WHERE  config.cashvaliditykind = 1 --emitted
UNION ALL
SELECT 
	income.idinc, 
	config.ayear, 
	income.nmov, 
	income.adate,
	income.idreg,
	income.idman, 
	income.doc, 
	income.docdate, 
	income.description, 
	proceeds.printdate, 
	incomeyear.amount,
	--income.amount, 
	incometotal.curramount, 
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	--incomeyear.flagarrear, 
	proceeds.kpro,
	proceeds.ypro, 
	proceeds.npro, 
	incomeyear.idfin,
	incomeyear.idupb
FROM config	
JOIN income
	ON income.ymov = config.ayear
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND config.ayear = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = config.ayear
WHERE  config.cashvaliditykind = 2 --printed
UNION ALL

SELECT 
	income.idinc, 
	config.ayear, 
	income.nmov, 
	income.adate,
	income.idreg, 
	income.idman, 
	income.doc, 
	income.docdate, 
	income.description, 
	proceedstransmission.transmissiondate, 
	incomeyear.amount,
	--income.amount, 
	incometotal.curramount, 
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	--incomeyear.flagarrear, 	
	proceeds.kpro,
	proceeds.ypro, 
	proceeds.npro, 
	incomeyear.idfin,
	incomeyear.idupb
FROM config	
JOIN income
	ON income.ymov = config.ayear
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN proceedstransmission 
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND config.ayear = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = config.ayear
WHERE  config.cashvaliditykind = 3 --comm

UNION ALL
SELECT 
	income.idinc, 
	config.ayear, 
	income.nmov, 
	income.adate,
	income.idreg, 
	income.idman, 
	income.doc, 
	income.docdate, 
	income.description, 
	banktransaction.transactiondate, 
	banktransaction.amount, 
	banktransaction.amount,
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	--incomeyear.flagarrear, 
	proceeds.kpro,
	proceeds.ypro, 
	proceeds.npro, 
	incomeyear.idfin,
	incomeyear.idupb
FROM config
JOIN income
	ON income.ymov = config.ayear 
JOIN incomelast
	ON income.idinc = incomelast.idinc 
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN proceedstransmission 
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND config.ayear = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = config.ayear
JOIN banktransaction
	ON banktransaction.idinc = income.idinc
WHERE  config.cashvaliditykind = 4 -- bankt

GO

print 'historyproceedsview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'treasurerview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW treasurerview
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
	idsor01,idsor02,idsor03,idsor04,idsor05,
	active,
	flag,
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
	treasurer.idsor01,treasurer.idsor02,treasurer.idsor03,treasurer.idsor04,treasurer.idsor05,
	treasurer.active,
	treasurer.flag,
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

print '[treasurerview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimatedetailtoinvoice') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimatedetailtoinvoice
GO

CREATE  VIEW [estimatedetailtoinvoice]
(
	idestimkind,
	yestim,
	nestim,
	rownum,
	idgroup,
	estimatekind,
	idreg,
	registry,
	idcurrency,
	codecurrency, 
	detaildescription,
	ordered,
	invoiced,
	residual,
	taxrate,
	taxable,
	tax,
	discount,
	start,
	stop,
	competencystart,
	competencystop,
	idupb,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	idivakind,
	ivakind,
	toinvoice,
	linktoinvoice,
	multireg,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	epkind,exchangerate
)
AS SELECT 
	estimatedetail.idestimkind,
	estimatedetail.yestim, 
	estimatedetail.nestim, 
	estimatedetail.rownum, 
	estimatedetail.idgroup,
	estimatekind.description,
	--estimate.idreg,
	CASE
		WHEN (estimate.idreg is not null) THEN (estimate.idreg)
		WHEN (estimatedetail.idreg is not null) THEN (estimatedetail.idreg)
		ELSE null
	END,
	--registry.title, 
	CASE
		WHEN (estimate.idreg is not null) THEN (select title from
						registry 
						where idreg= estimate.idreg)
		WHEN (estimatedetail.idreg is not null) THEN (select title from
						registry 
						where idreg= estimatedetail.idreg)
		ELSE null
	END, 
	estimate.idcurrency,
	currency.codecurrency,
	estimatedetail.detaildescription, 
	estimatedetail.number,		-- ordered
	/*(SELECT ISNULL(SUM(number), 0)
		FROM invoicedetail
		WHERE estimatedetail.idestimkind = invoicedetail.idestimkind
		AND estimatedetail.yestim = invoicedetail.yestim
		AND estimatedetail.nestim = invoicedetail.nestim
		AND estimatedetail.rownum = invoicedetail.estimrownum), 	*/
	(SELECT  SUM (iv.number)
	FROM (SELECT DISTINCT number,idestimkind,yestim,nestim,estimrownum,idgroup
		FROM invoicedetail) 
		AS iv
	WHERE estimatedetail.idestimkind = iv.idestimkind
		AND estimatedetail.yestim = iv.yestim
		AND estimatedetail.nestim = iv.nestim
		AND estimatedetail.rownum = iv.estimrownum 
	),		-- invoiced
	/*ISNULL(estimatedetail.number, 0) -
	(SELECT ISNULL(SUM(number), 0)
		FROM invoicedetail
		WHERE estimatedetail.idestimkind = invoicedetail.idestimkind
		AND estimatedetail.yestim = invoicedetail.yestim
		AND estimatedetail.nestim = invoicedetail.nestim
		AND estimatedetail.rownum = invoicedetail.estimrownum), */
	ISNULL(estimatedetail.number, 0) 
	- 
	ISNULL(
	(SELECT SUM(iv.number)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  invoicedetail.idgroup as invidgroup,
				      invoicedetail.number,invoicedetail.idestimkind,invoicedetail.yestim,
				      invoicedetail.nestim, estimatedetail.idgroup as estimidgroup
		FROM invoicedetail 
        JOIN estimatedetail estimatedetail2
		  ON invoicedetail.idestimkind = estimatedetail2.idestimkind AND
		     invoicedetail.yestim = estimatedetail2.yestim AND
	         invoicedetail.nestim = estimatedetail2.nestim AND
		     invoicedetail.estimrownum = estimatedetail2.rownum 
		    WHERE  invoicedetail.idestimkind = estimatedetail.idestimkind AND
	               invoicedetail.yestim = estimatedetail.yestim AND
		           invoicedetail.nestim = estimatedetail.nestim AND
			       estimatedetail2.idgroup = estimatedetail.idgroup 
			) AS iv )  ,0)
	/*(SELECT  SUM (iv.number)
   	   FROM (SELECT DISTINCT number,idestimkind,yestim,nestim,estimrownum,idgroup
		FROM invoicedetail) 
		AS iv
	  WHERE estimatedetail.idestimkind = iv.idestimkind
		AND estimatedetail.yestim = iv.yestim
		AND estimatedetail.nestim = iv.nestim
		AND estimatedetail.rownum = iv.estimrownum 
	)*/, 	-- residual
	estimatedetail.taxrate,
	estimatedetail.taxable,
	estimatedetail.tax,
	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	estimatedetail.competencystart,
	estimatedetail.competencystop,
	estimatedetail.idupb,
	estimatedetail.idsor1,
	estimatedetail.idsor2,
	estimatedetail.idsor3,
	estimatedetail.idaccmotive,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimatekind.linktoinvoice,
	estimatekind.multireg,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	estimatedetail.epkind,
	estimate.exchangerate
	FROM estimatedetail WITH (NOLOCK)
	JOIN estimatekind WITH (NOLOCK)
	ON estimatekind.idestimkind = estimatedetail.idestimkind
	INNER JOIN estimate WITH (NOLOCK)
	ON estimate.idestimkind = estimatedetail.idestimkind
	AND estimate.yestim = estimatedetail.yestim
	AND estimate.nestim = estimatedetail.nestim
	--INNER JOIN registry WITH (NOLOCK) ON registry.idreg = estimate.idreg
	LEFT OUTER JOIN ivakind WITH (NOLOCK)
	ON ivakind.idivakind = estimatedetail.idivakind
	LEFT OUTER JOIN currency WITH (NOLOCK)
	ON currency.idcurrency = estimate.idcurrency
	WHERE estimatedetail.stop is null


GO

print '[estimatedetailtoinvoice] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'wageadditionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW wageadditionview
GO





CREATE VIEW [wageadditionview]
(
	ayear,
	ycon,
	ncon,
	start,
	stop,
	adate,
	idreg,
	registry,
	feegross,
	idser,
	service,
	codeser,
	description,
	ndays,
	idposition,
	position,
	idcontractlength,
	contractlength,
	idworkingtime,
	workingtime,
	idaccmotive,
	codemotive,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idsor1,
	idsor2,
	idsor3,
	authneeded,
	authdoc,
	authdocdate,
	noauthreason,
	idreg_distrained,
	registry_distrained,
	cu,
	ct,
	lu,
	lt,
	txt,
	completed
)
AS SELECT 
	ICD.ayear,
	CD.ycon,
	CD.ncon,
	CD.start,
	CD.stop,
	CD.adate,
	CD.idreg,
	registry.title as registry,
	CD.feegross,
	CD.idser,
	service.description,
	service.codeser,
	CD.description,
	CD.ndays,
	ICD.idposition,
	QR.description AS position,
	ICD.idcontractlength,
	DR.description AS contractlength,
	ICD.idworkingtime,
	ORAP.description AS workingtime,
	CD.idaccmotive,
	AM.codemotive,
	CD.idaccmotivedebit,
	DB.codemotive,
	CD.idaccmotivedebit_crg,
	CRG.codemotive,
	CD.idaccmotivedebit_datacrg,
	CD.idupb,
	upb.codeupb,
	upb.title,
	isnull(CD.idsor01,UPB.idsor01),
	isnull(CD.idsor02,UPB.idsor02),
	isnull(CD.idsor03,UPB.idsor03),
	isnull(CD.idsor04,UPB.idsor04),
	isnull(CD.idsor05,UPB.idsor05),
	CD.idsor1,
	CD.idsor2,
	CD.idsor3,
	CD.authneeded,
	CD.authdoc,
	CD.authdocdate,
	CD.noauthreason,
	RD.idreg,
	RD.title,
	CD.cu,
	CD.ct,
	CD.lu,
	CD.lt,
	CD.txt,
	CD.completed
FROM wageaddition CD
JOIN wageadditionyear ICD
	ON CD.ycon = ICD.ycon
	AND CD.ncon = ICD.ncon
JOIN registry
	ON registry.idreg = CD.idreg
JOIN service
	ON service.idser = CD.idser
LEFT OUTER JOIN upb
	ON upb.idupb=CD.idupb
LEFT OUTER JOIN positionworkcontract QR
	ON QR.idposition = ICD.idposition
	AND QR.ayear = ICD.ayear
LEFT OUTER JOIN contractlength DR
	ON DR.idcontractlength = ICD.idcontractlength
	AND DR.ayear = ICD.ayear
LEFT OUTER JOIN workingtime ORAP
	ON ORAP.idworkingtime = ICD.idworkingtime
	AND ORAP.ayear = ICD.ayear
LEFT OUTER JOIN accmotive AM
	ON AM.idaccmotive = CD.idaccmotive
LEFT OUTER JOIN accmotive DB
	ON DB.idaccmotive =  CD.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG
	ON CRG.idaccmotive = CD.idaccmotivedebit_crg
LEFT OUTER JOIN registry RD
	ON RD.idreg = CD.idreg_distrained

GO

print '[wageadditionview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetusageview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetusageview
GO

CREATE              VIEW assetusageview
(
	nassetacquire,
	idassetusagekind,
	codeassetusagekind,
	assetusagekind,
	usagequota,
	transmitted,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetusage.nassetacquire,
	assetusage.idassetusagekind,
	assetusagekind.codeassetusagekind,
	assetusagekind.description,
	assetusage.usagequota,
	assetusage.transmitted,
	assetusage.cu,
	assetusage.ct,
	assetusage.lu,
	assetusage.lt
FROM assetusage
JOIN assetusagekind
	ON assetusage.idassetusagekind = assetusagekind.idassetusagekind




GO

print 'assetusageview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'upbfinused') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW upbfinused
GO



CREATE  VIEW [upbfinused]
(
	ayear,
	idfin,
	codefin,
	finance,
	flag,
	finpart,
	paridfin,
	nlevel,
	leveldescr,
	idupb,
	codeupb,
	upb,
	paridupb,
	prevision,
	secondaryprev,
	totalarrears,
	totalcompetency,
	creditvariation,
	previsionvariation,
	proceedsvariation,
	secondaryvariation,
	totcreditpart,
	totproceedspart,
	limit,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	ct,
	cu,
	lt,
	lu
)
AS
SELECT
finyear.ayear,
finyear.idfin,
fin.codefin,
fin.title,
fin.flag,
CASE
	WHEN ((fin.flag&1)=0) THEN 'E'
	WHEN ((fin.flag&1)=1) THEN 'S'
END as finpart,
fin.paridfin,
fin.nlevel,
finlevel.description,
finyear.idupb,
upb.codeupb,
upb.title,
upb.paridupb,
ISNULL(finyear.prevision,0),
ISNULL(finyear.secondaryprev,0),
CASE 
	WHEN ((fin.flag&1)=0) THEN
	ISNULL(upbincometotal.totalarrears,0)
	ELSE
	ISNULL(upbexpensetotal.totalarrears,0)
END as totalarrears,
CASE 
	WHEN ((fin.flag&1)=0) THEN
	ISNULL(upbincometotal.totalcompetency,0)
	ELSE
	ISNULL(upbexpensetotal.totalcompetency,0)
END as totalcompetency,
ISNULL(upbtotal.creditvariation,0),
ISNULL(upbtotal.previsionvariation,0),
ISNULL(upbtotal.proceedsvariation,0),
ISNULL(upbtotal.secondaryvariation,0),
ISNULL(upbtotal.totcreditpart,0),
ISNULL(upbtotal.totproceedspart,0),
ISNULL(finyear.limit,0),
ISNULL(finyear.prevision2,0),
ISNULL(finyear.prevision3,0),
ISNULL(finyear.prevision4,0),
ISNULL(finyear.prevision5,0),
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05,
finyear.ct,
finyear.cu,
finyear.lt,
finyear.lu
FROM upbtotal
JOIN fin
	ON upbtotal.idfin = fin.idfin
JOIN upb
	ON upbtotal.idupb = upb.idupb
JOIN finlevel
	ON finlevel.nlevel = fin.nlevel
	AND finlevel.ayear = fin.ayear
LEFT OUTER JOIN upbincometotal
	ON upbincometotal.idupb = upbtotal.idupb
	AND upbincometotal.idfin = upbtotal.idfin
	AND upbincometotal.nphase = (select incomefinphase from uniconfig)
	LEFT OUTER JOIN upbexpensetotal
ON upbexpensetotal.idupb = upbtotal.idupb
	AND upbexpensetotal.idfin = upbtotal.idfin
	AND upbincometotal.nphase = (select expensefinphase from uniconfig)
LEFT OUTER JOIN finyear
	ON upbtotal.idupb = finyear.idupb
	AND upbtotal.idfin = finyear.idfin
WHERE
	ISNULL(finyear.prevision,0) <> 0 OR
	ISNULL(finyear.secondaryprev,0) <> 0 OR
	ISNULL(upbincometotal.totalarrears,0) <> 0 OR
	ISNULL(upbincometotal.totalcompetency,0) <> 0 OR
	ISNULL(upbexpensetotal.totalarrears,0) <> 0 OR
	ISNULL(upbexpensetotal.totalcompetency,0) <> 0 OR
	ISNULL(upbtotal.creditvariation,0) <> 0 OR
	ISNULL(upbtotal.previsionvariation,0) <> 0 OR
	ISNULL(upbtotal.proceedsvariation,0) <> 0 OR
	ISNULL(upbtotal.secondaryvariation,0) <> 0 OR
	ISNULL(upbtotal.totcreditpart,0) <> 0 OR
	ISNULL(upbtotal.totproceedspart,0) <> 0



GO

print '[upbfinused] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimatedetail_extview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimatedetail_extview
GO




CREATE  VIEW [estimatedetail_extview]
(
	idestimkind,
	yestim,
	nestim,
	rownum,
	idgroup,
	estimkind,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	start,
	stop,
	competencystart,
	competencystop,
	idinc_taxable,
	idinc_iva,	
	taxable_euro,
	iva_euro,
	rowtotal,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt,
	idaccmotive,
	codemotive,
	idaccmotiveannulment,
	codemotiveannulment,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	idivakind,
	ivakind,
	toinvoice,
	exchangerate,
	description,
	linkedtoinvoice,
	notlinkedtoinvoice,
	epkind
)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatedetail.rownum,
	estimatedetail.idgroup,
	estimatekind.description,
 	estimatedetail.idreg,
  	registry.title,
	estimatedetail.detaildescription,
	estimatedetail.annotations,
	estimatedetail.number,
	estimatedetail.taxable,
	estimatedetail.taxrate,
	estimatedetail.tax,
  	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	estimatedetail.competencystart,
	estimatedetail.competencystop,
	estimatedetail.idinc_taxable,
	estimatedetail.idinc_iva,
 	    ROUND(estimatedetail.taxable * estimatedetail.number * 
		  CONVERT(DECIMAL(19,6),estimate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0))),2
		),
	ROUND(estimatedetail.tax ,2),
 	    ROUND(estimatedetail.taxable * estimatedetail.number * 
		  CONVERT(DECIMAL(19,6),estimate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0))),2
		)+
	ROUND(estimatedetail.tax ,2),
	estimatedetail.idupb,
	upb.codeupb,
	upb.title,
	estimatedetail.cu,
	estimatedetail.ct,
	estimatedetail.lu,
	estimatedetail.lt,
	estimatedetail.idaccmotive,
	accmotive.codemotive,
	estimatedetail.idaccmotiveannulment,
	accmotiveannulment.codemotive,
	estimatedetail.idsor1,
	estimatedetail.idsor2,
	estimatedetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimate.exchangerate,
	estimate.description,
	-- linkedtoinvoice
	ISNULL(
		(SELECT  SUM (iv.number)
	FROM (SELECT DISTINCT number,idestimkind,yestim,nestim,estimrownum,idgroup
		FROM invoicedetail) 
		AS iv
	WHERE estimatedetail.idestimkind = iv.idestimkind
		AND estimatedetail.yestim = iv.yestim
		AND estimatedetail.nestim = iv.nestim
		AND estimatedetail.rownum = iv.estimrownum)
	,0),
	-- notlinkedtoinvoice
	estimatedetail.number -
	ISNULL(
		(SELECT  SUM (iv.number)
	FROM (SELECT DISTINCT number, idestimkind,yestim,nestim,estimrownum,idgroup
		FROM invoicedetail) 
		AS iv
	WHERE estimatedetail.idestimkind = iv.idestimkind
		AND estimatedetail.yestim = iv.yestim
		AND estimatedetail.nestim = iv.nestim
		AND estimatedetail.rownum = iv.estimrownum)
	,0),
	estimatedetail.epkind
FROM estimatedetail
JOIN estimatekind
	ON estimatekind.idestimkind = estimatedetail.idestimkind
JOIN estimate
	ON estimate.yestim = estimatedetail.yestim
	AND estimate.nestim = estimatedetail.nestim
	AND estimate.idestimkind = estimatedetail.idestimkind
JOIN ivakind
	ON ivakind.idivakind = estimatedetail.idivakind
LEFT OUTER JOIN registry
	ON registry.idreg = estimatedetail.idreg
LEFT OUTER JOIN upb
	ON upb.idupb = estimatedetail.idupb
LEFT OUTER JOIN accmotive
	ON accmotive.idaccmotive = estimatedetail.idaccmotive
LEFT OUTER JOIN accmotive accmotiveannulment
	ON accmotiveannulment.idaccmotive = estimatedetail.idaccmotiveannulment
LEFT OUTER JOIN sorting sorting1
	ON sorting1.idsor = estimatedetail.idsor1
LEFT OUTER JOIN sorting sorting2
	ON sorting2.idsor = estimatedetail.idsor2
LEFT OUTER JOIN sorting sorting3
	ON sorting3.idsor = estimatedetail.idsor3




GO

print '[estimatedetail_extview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'upbunderwritingyearview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW upbunderwritingyearview
GO


CREATE    VIEW [upbunderwritingyearview] (
	idunderwriting,
	codeunderwriting,
	underwriting,
	idupb,
	codeupb,	
	upb,
	idfin,
	codefin,
	fin,
	flag, 
	finpart,
	ayear,
	initialprevision,			-- previsione principale iniziale 
	varprevision,				-- variazioni di previsione principale
	actualprevision,			-- previsione principale CORRENTE 
	initialsecondaryprev,		-- previsione iniziale di cassa
	varsecondaryprev,			-- variazioni di previsione di cassa
	actualsecondaryprev,		-- previsione di cassa CORRENTE 
	totcreditpart,				-- tot. assegnazioni crediti
	totpreceedspart,			-- tot. assegnazioni incassi 
	assessment,		--accertamenti	(include anche i residui per chi gestisce solo la cassa)
	appropriation,	--impegni (include anche i residui per chi gestisce solo la cassa)
	proceeds,			--incassi	(include anche i residui per chi gestisce solo la cassa)
	payment,			--pagamenti (include anche i residui per chi gestisce solo la cassa)
	incomeprevavailable,	-- disp ad accertare =  previsione principale meno accertamenti (+ residui per chi ha sola cassa)
	expenseprevavailable,	-- disp. a impegnare = previsione principale meno impegni (+ residui per chi ha sola cassa)
	proceedsprevavailable,	-- disp. ad incassare = previsione principale di cassa meno incassi (+ residui per chi ha sola cassa),
	paymentprevavailable,	-- disp a pagare = previsione principale di cassa meno pagamenti (+ residui per chi ha sola cassa),
	creditavailable,	-- crediti disponibili  = totale crediti assegnati - impegni 
	proceedsavailable,	-- incassi disponibili = totale incassi assegnati - pagamenti
	active
)
AS SELECT
	upbunderwritingtotal.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	upbunderwritingtotal.idupb,
	upb.codeupb,
	upb.title,
	upbunderwritingtotal.idfin,
	fin.codefin,
	fin.title,
	fin.flag, 
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.ayear,
	-- initialprevision
	ISNULL(upbunderwritingtotal.currentprev,0),
	-- varprevision
	ISNULL(upbunderwritingtotal.previsionvariation,0),
	-- actualprevision,
	ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0),
	-- initialsecondaryprev
	ISNULL(upbunderwritingtotal.currentsecondaryprev,0),
	-- varsecondaryprev
	ISNULL(upbunderwritingtotal.secondaryvariation,0),
	-- actualsecondaryprev
	ISNULL(upbunderwritingtotal.currentsecondaryprev,0) + ISNULL(upbunderwritingtotal.secondaryvariation,0),
	-- totcreditpart
	ISNULL(upbunderwritingtotal.totcreditpart,0),
	-- tonpreceedspart
	ISNULL(upbunderwritingtotal.totproceedspart,0),
	--assessment = accertamenti
	Case when (( fin.flag & 1) = 0)
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Incomefinphase.totalcompetency,0)
			ELSE
					ISNULL(Incomefinphase.totalcompetency,0) + ISNULL(Incomefinphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- appropriation = impegni
	Case when (( fin.flag & 1) <> 0) 
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) 
				THEN
					ISNULL(Expensefinphase.totalcompetency,0)
				ELSE
					ISNULL(Expensefinphase.totalcompetency,0) + ISNULL(Expensefinphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- proceeds
	Case when (( fin.flag & 1) = 0)
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Incomemaxphase.totalcompetency,0)
			ELSE
					ISNULL(Incomemaxphase.totalcompetency,0) + ISNULL(Incomemaxphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- payment 
	Case when (( fin.flag & 1) <> 0) 
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) 
				THEN
					ISNULL(Expensemaxphase.totalcompetency,0)
				ELSE
					ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- incomeprevavailable = disp ad accertare
	Case when (( fin.flag & 1) = 0)
		Then
			ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0) 
			- (CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Incomefinphase.totalcompetency,0)
				ELSE
						ISNULL(Incomefinphase.totalcompetency,0) + ISNULL(Incomefinphase.totalarrears,0)
				END)
		Else 0
	End	,
	-- expenseprevavailable = disp. a impegnare
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0) 
			- (	CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Expensefinphase.totalcompetency,0)
				ELSE
					ISNULL(Expensefinphase.totalcompetency,0) + ISNULL(Expensefinphase.totalarrears,0)
				END)
		Else 0		
	End,
	-- proceedspreavailable = disp. ad incassare
		Case when (( fin.flag & 1) = 0) 
		Then
			ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0) 
			- (ISNULL(Incomemaxphase.totalcompetency,0) + ISNULL(Incomemaxphase.totalarrears,0))
		Else 0
	End	,
	-- paymentpreavailable = disp a pagare
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0) 
			- (ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0))
		Else 0		
	End,
	-- creditavailable
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbunderwritingtotal.totcreditpart,0) + ISNULL(upbunderwritingtotal.creditvariation,0) - ISNULL(Expensefinphase.totalcompetency,0)
		Else 0	
	End,
	-- proceedsavailable 
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbunderwritingtotal.totproceedspart,0) + ISNULL(upbunderwritingtotal.proceedsvariation,0) - (	ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0))
			
		Else 0	
	End,
	underwriting.active
FROM upbunderwritingtotal 
CROSS JOIN uniconfig
JOIN upb
	ON upbunderwritingtotal.idupb = upb.idupb
JOIN fin
	ON upbunderwritingtotal.idfin = fin.idfin
JOIN finlast 
	ON finlast.idfin=fin.idfin
JOIN underwriting
	ON upbunderwritingtotal.idunderwriting = underwriting.idunderwriting 
LEFT OUTER JOIN underwritingincometotal Incomefinphase
	ON Incomefinphase.idunderwriting = upbunderwritingtotal.idunderwriting
	AND Incomefinphase.idupb = upbunderwritingtotal.idupb
	AND Incomefinphase.idfin = upbunderwritingtotal.idfin
	AND Incomefinphase.nphase = uniconfig.incomefinphase
LEFT OUTER JOIN underwritingexpensetotal Expensefinphase
	ON Expensefinphase.idunderwriting = upbunderwritingtotal.idunderwriting
	AND Expensefinphase.idupb = upbunderwritingtotal.idupb
	AND Expensefinphase.idfin = upbunderwritingtotal.idfin
	AND Expensefinphase.nphase = uniconfig.expensefinphase
LEFT OUTER JOIN underwritingincometotal Incomemaxphase
	ON Incomemaxphase.idunderwriting = upbunderwritingtotal.idunderwriting
	AND Incomemaxphase.idupb = upbunderwritingtotal.idupb
	AND Incomemaxphase.idfin = upbunderwritingtotal.idfin
	AND Incomemaxphase.nphase = (select max(nphase) from incomephase)
LEFT OUTER JOIN underwritingexpensetotal Expensemaxphase
	ON Expensemaxphase.idunderwriting = upbunderwritingtotal.idunderwriting
	AND Expensemaxphase.idupb = upbunderwritingtotal.idupb
	AND Expensemaxphase.idfin = upbunderwritingtotal.idfin
	AND Expensemaxphase.nphase = (select max(nphase) from expensephase)
	

GO

print '[upbunderwritingyearview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimatedetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimatedetailview
GO


CREATE  VIEW [estimatedetailview]
(
	idestimkind,
	yestim,
	nestim,
	rownum,
	idgroup,
	estimkind,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	start,
	stop,
	competencystart,
	competencystop,
	idinc_taxable,
	idinc_iva,	
	taxable_euro,
	iva_euro,
	rowtotal,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt,
	idaccmotive,
	codemotive,
	idaccmotiveannulment,
	codemotiveannulment,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	idivakind,
	ivakind,
	toinvoice,
	exchangerate,
	description,
	flagintracom,
	ninvoiced,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	epkind
	)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatedetail.rownum,
	estimatedetail.idgroup,
	estimatekind.description,
 	estimatedetail.idreg,
  	registry.title,
	estimatedetail.detaildescription,
	estimatedetail.annotations,
	estimatedetail.number,
	estimatedetail.taxable,
	estimatedetail.taxrate,
	estimatedetail.tax,
  	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	estimatedetail.competencystart,
	estimatedetail.competencystop,
	estimatedetail.idinc_taxable,
	estimatedetail.idinc_iva,
 	    ROUND(estimatedetail.taxable * estimatedetail.number * 
		  CONVERT(DECIMAL(19,6),estimate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0))),2
		),
	ROUND(estimatedetail.tax,2),
 	    ROUND(estimatedetail.taxable * estimatedetail.number * 
		  CONVERT(DECIMAL(19,6),estimate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0))),2
		)+
	ROUND(estimatedetail.tax ,2),
	estimatedetail.idupb,
	upb.codeupb,
	upb.title,
	estimatedetail.cu,
	estimatedetail.ct,
	estimatedetail.lu,
	estimatedetail.lt,
	estimatedetail.idaccmotive,
	accmotive.codemotive,
	estimatedetail.idaccmotiveannulment,
	accmotiveannulment.codemotive,
	estimatedetail.idsor1,
	estimatedetail.idsor2,
	estimatedetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimate.exchangerate,
	estimate.description,
	estimate.flagintracom,
	estimatedetail.ninvoiced,
	COALESCE(estimate.idsor01,estimatekind.idsor01,upb.idsor01),
	COALESCE(estimate.idsor02,estimatekind.idsor02,upb.idsor02),
	COALESCE(estimate.idsor03,estimatekind.idsor03,upb.idsor03),
	COALESCE(estimate.idsor04,estimatekind.idsor04,upb.idsor04),
	COALESCE(estimate.idsor05,estimatekind.idsor05,upb.idsor05),
	estimatedetail.epkind
FROM estimatedetail WITH (NOLOCK)
JOIN estimatekind WITH (NOLOCK)
	ON estimatekind.idestimkind = estimatedetail.idestimkind
JOIN estimate WITH (NOLOCK)
	ON estimate.yestim = estimatedetail.yestim
	AND estimate.nestim = estimatedetail.nestim
	AND estimate.idestimkind = estimatedetail.idestimkind
JOIN ivakind WITH (NOLOCK)
	ON ivakind.idivakind = estimatedetail.idivakind
LEFT OUTER JOIN registry WITH (NOLOCK)
	ON registry.idreg = estimatedetail.idreg
LEFT OUTER JOIN upb WITH (NOLOCK)
	ON upb.idupb = estimatedetail.idupb
LEFT OUTER JOIN accmotive WITH (NOLOCK)
	ON accmotive.idaccmotive = estimatedetail.idaccmotive
LEFT OUTER JOIN accmotive accmotiveannulment WITH (NOLOCK)
	ON accmotiveannulment.idaccmotive = estimatedetail.idaccmotiveannulment
LEFT OUTER JOIN sorting sorting1 WITH (NOLOCK)
	ON sorting1.idsor = estimatedetail.idsor1
LEFT OUTER JOIN sorting sorting2 WITH (NOLOCK)
	ON sorting2.idsor = estimatedetail.idsor2
LEFT OUTER JOIN sorting sorting3 WITH (NOLOCK)
	ON sorting3.idsor = estimatedetail.idsor3



GO

print '[estimatedetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetvarview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetvarview
GO


CREATE              VIEW assetvarview
(
	idassetvar,
	yvar,
	nvar,
	idinventoryagency,
	codeinventoryagency,
	inventoryagency,
	description,
	enactment,
	flag,
	variationkind,
	nenactment,
	enactmentdate,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetvar.idassetvar,
	assetvar.yvar,
	assetvar.nvar,
	assetvar.idinventoryagency,
	inventoryagency.codeinventoryagency,
	inventoryagency.description,
	assetvar.description,
	assetvar.enactment,
	assetvar.flag,
	CASE 
		WHEN flag & 1 <> 0 THEN 'N'
		ELSE 'I'
	END,
	assetvar.nenactment,
	assetvar.enactmentdate,
	assetvar.adate,
	assetvar.cu,
	assetvar.ct,
	assetvar.lu,
	assetvar.lt
FROM assetvar
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = assetvar.idinventoryagency




GO

print 'assetvarview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensecasualcontractview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensecasualcontractview
GO


CREATE         VIEW [expensecasualcontractview]
(
	ycon,
	ncon,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	autokind,
	idpayment,
	totflag, 
	flagarrear,
	expiration,
	adate,
	cu, ct, lu, lt
)
AS SELECT
	expensecasualcontract.ycon,
	expensecasualcontract.ncon,
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expenselast.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount, 
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expense.autokind,
	expense.idpayment,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration,
	expense.adate,
	expensecasualcontract.cu,
	expensecasualcontract.ct,
	expensecasualcontract.lu,
	expensecasualcontract.lt
FROM expensecasualcontract
JOIN casualcontract
	ON expensecasualcontract.ycon = casualcontract.ycon
	AND expensecasualcontract.ncon = casualcontract.ncon
JOIN config
	ON config.ayear=expensecasualcontract.ycon 
JOIN expense
	ON expense.idexp = expensecasualcontract.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN expense former
	ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment 
	ON payment.kpay = expenselast.kpay


GO

print '[expensecasualcontractview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mainivapaydetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mainivapaydetailview
GO


CREATE    VIEW [mainivapaydetailview]
(
	ymainivapay,
	nmainivapay,
	nmonth,
	referenceyear,
	idivaregisterkind,
	codeivaregisterkind,
	description,
	registerclass,
	iva,
	ivadeferred,
	ivatotal,
	unabatable,
	unabatabledeferred,
	unabatabletotal,
	prorata,
	mixed,
	ivanet,
	ivanetdeferred,
	iddbdepartment,
	department,
	flagactivity,
	cu, 
	ct, 
	lu, 
	lt
	)	
AS SELECT
	mainivapaydetail.ymainivapay,
	mainivapaydetail.nmainivapay,
	mainivapay.nmonth,
	mainivapay.referenceyear,
	mainivapaydetail.idivaregisterkind,
	ivaregisterkind.codeivaregisterkind,
	ivaregisterkind.description,
	ivaregisterkind.registerclass,
	mainivapaydetail.iva,
	mainivapaydetail.ivadeferred,
	ISNULL(mainivapaydetail.iva,0) + ISNULL(mainivapaydetail.ivadeferred,0),
	mainivapaydetail.unabatable,
	mainivapaydetail.unabatabledeferred,
	ISNULL(mainivapaydetail.unabatable,0) + ISNULL(mainivapaydetail.unabatabledeferred,0),
	mainivapaydetail.prorata,
	mainivapaydetail.mixed,
	mainivapaydetail.ivanet,
	mainivapaydetail.ivanetdeferred,
    mainivapaydetail.iddbdepartment,
    dbdepartment.description,
	ivaregisterkind.flagactivity,
	mainivapaydetail.cu, 
	mainivapaydetail.ct, 
	mainivapaydetail.lu,
	mainivapaydetail.lt 
	FROM mainivapaydetail (NOLOCK)
	JOIN ivaregisterkind (NOLOCK)
		ON ivaregisterkind.idivaregisterkind = mainivapaydetail.idivaregisterkind
	JOIN mainivapay (NOLOCK)
		ON mainivapay.nmainivapay = mainivapaydetail.nmainivapay
		AND mainivapay.ymainivapay = mainivapaydetail.ymainivapay
	LEFT OUTER JOIN dbdepartment
        ON mainivapaydetail.iddbdepartment = dbdepartment.iddbdepartment


GO

print '[mainivapaydetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'unifiedf24epsanctionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW unifiedf24epsanctionview
GO



CREATE   VIEW [unifiedf24epsanctionview]
AS
SELECT DISTINCT 
a1.idunifiedf24ep,
a1.idsanction,
a1.idcity,
c1.title as city,
f1.idfiscaltaxregion,
f1.title as region
FROM unifiedf24epsanction a1
LEFT OUTER JOIN geo_city c1
ON a1.idcity= c1.idcity
LEFT OUTER JOIN fiscaltaxregion f1
ON a1.idfiscaltaxregion= f1.idfiscaltaxregion



GO

print '[unifiedf24epsanctionview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expenseinvoiceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expenseinvoiceview
GO


CREATE        VIEW expenseinvoiceview 
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	movkind,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag, 
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	expenseinvoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	expenseinvoice.yinv,
	expenseinvoice.ninv,
	expenseinvoice.movkind,
	expenseinvoice.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,	
	upb.codeupb,	
	upb.title,	
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expenselast.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expenseinvoice.cu,
	expenseinvoice.ct,
	expenseinvoice.lu,
	expenseinvoice.lt
	FROM expenseinvoice 
	JOIN invoicekind 
		ON invoicekind.idinvkind = expenseinvoice.idinvkind
	JOIN expense  
		ON expense.idexp = expenseinvoice.idexp
	JOIN expensephase 
		ON expensephase.nphase = expense.nphase
	JOIN expenseyear 
		ON expenseyear.idexp = expense.idexp
	JOIN expensetotal 
		ON expensetotal.idexp = expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	LEFT OUTER JOIN expense parentexpense  
		ON expense.parentidexp = parentexpense.idexp
	LEFT OUTER JOIN expense former
		ON expense.idformerexpense = former.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear
		ON expensetotal_firstyear.idexp = expense.idexp
		AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting 
		ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
		AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	LEFT OUTER JOIN expenselast  
		ON expense.idexp = expenselast.idexp
	LEFT OUTER JOIN fin 
		ON fin.idfin = expenseyear.idfin
	LEFT OUTER JOIN upb
		on upb.idupb = expenseyear.idupb
	LEFT OUTER JOIN registry 
		ON registry.idreg = expense.idreg
	LEFT OUTER JOIN manager 
		ON manager.idman = expense.idman
	LEFT OUTER JOIN service 
		ON service.idser = expenselast.idser
	LEFT OUTER JOIN payment 
		ON payment.kpay = expenselast.kpay


GO

print 'expenseinvoiceview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expenseitinerationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expenseitinerationview
GO


CREATE         VIEW [expenseitinerationview]
(
	iditineration,
	yitineration,
	nitineration,
	movkind,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	autokind,
	idpayment,
	totflag,
	flagarrear,
	expiration,
	adate,
	cu, ct, lu, lt
)
AS SELECT
	expenseitineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	expenseitineration.movkind,
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,	
	upb.codeupb,	
	upb.title,	
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expenselast.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expense.autokind,
	expense.idpayment,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration,
	expense.adate,
	expenseitineration.cu,
	expenseitineration.ct,
	expenseitineration.lu,
	expenseitineration.lt
FROM expenseitineration
JOIN itineration 
	ON itineration.iditineration = expenseitineration.iditineration
JOIN config
	ON config.ayear=itineration.yitineration 
JOIN expense
	ON expense.idexp = expenseitineration.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense 
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expense former
	ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN expenselast
	ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment 
	ON payment.kpay = expenselast.kpay


GO

print '[expenseitinerationview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'payrollavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW payrollavailable
GO

CREATE   VIEW [payrollavailable]
(
	idpayroll, fiscalyear, npayroll,
	idcon, ycon, ncon, registry, 
	feegross, netfee, disbursementdate, stop, start, 
	enabletaxrelief, currentrounding, flagcomputed, flagbalance, 
	workingdays, idresidence, cu, ct, lu, lt,
	idupb, idsor1, idsor2, idsor3, idaccmotive,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT 
	payroll.idpayroll, payroll.fiscalyear, payroll.npayroll, 
	payroll.idcon, parasubcontract.ycon, parasubcontract.ncon, registry.title, 
	payroll.feegross, payroll.netfee, payroll.disbursementdate, payroll.stop, payroll.start, 
	payroll.enabletaxrelief, payroll.currentrounding, payroll.flagcomputed, payroll.flagbalance, 
	payroll.workingdays, payroll.idresidence, payroll.cu, payroll.ct, payroll.lu, payroll.lt,
	parasubcontract.idupb, parasubcontract.idsor1, parasubcontract.idsor2, parasubcontract.idsor3, parasubcontract.idaccmotive,
	parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03,parasubcontract.idsor04,parasubcontract.idsor05
FROM payroll with (nolock)
JOIN parasubcontract with (nolock)
	ON payroll.idcon = parasubcontract.idcon
JOIN registry with (nolock)
	ON parasubcontract.idreg = registry.idreg
WHERE (payroll.flagcomputed='S')
AND (payroll.disbursementdate IS NULL) AND (payroll.flagbalance = 'N')
AND ((payroll.fiscalyear * 12 + npayroll) =
	(SELECT MIN(c.fiscalyear * 12 + c.npayroll)
    FROM payroll c
    WHERE c.disbursementdate IS NULL AND c.idcon = payroll.idcon AND c.flagbalance = 'N'))


GO

print '[payrollavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'revenuearrearssupposed') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW revenuearrearssupposed
GO

CREATE              VIEW [revenuearrearssupposed]
AS
-- Residui Attivi Presunti Anni Precedenti
SELECT DISTINCT 
	i1.ayear,
	e1.idinc,
	e1.ymov,
	e1.nmov,
	e1.adate,
	ISNULL(i2.curramount,0.0) - ISNULL(
		(SELECT SUM(ISNULL(i3.curramount,0.0)) 
		FROM income e3
		JOIN incometotal i3
			 ON e3.idinc = i3.idinc
		JOIN incomelast ls
			 ON e3.idinc = ls.idinc
		JOIN incomelink ilk
			ON ilk.idchild = i3.idinc
		WHERE ilk.idparent = e1.idinc    -- i3.idinc LIKE e1.idinc + '%'
	 		--AND e3.nphase = (SELECT MAX(nphase) FROM incomephase)
			AND i3.ayear = i1.ayear)
		,0.0) 	AS residualamount,
	--i1.flagarrear,
   	CASE
		when (( i2.flag & 1)=0) then 'C'
		when (( i2.flag & 1)=1) then 'R'
	End AS flagarrear,
	e1.expiration
FROM income e1
INNER JOIN incomeyear i1    
	ON e1.idinc = i1.idinc 
INNER JOIN incometotal i2
	ON i1.idinc = i2.idinc
	AND i1.ayear = i2.ayear
INNER JOIN config p1
	ON p1.assessmentphasecode = e1.nphase --i1.nphase
	AND p1.ayear = i1.ayear
WHERE (( i2.flag & 1)=1)--i1.flagarrear = 'R'
	AND i2.curramount >
		ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) 
			FROM income e3
			JOIN incometotal i3
	 			ON e3.idinc = i3.idinc
			JOIN incomelast ls
			 	ON e3.idinc = ls.idinc
			JOIN incomelink ilk
				ON ilk.idchild = i3.idinc
	 		WHERE ilk.idparent = e1.idinc    -- i3.idinc LIKE e1.idinc + '%'
	 			--AND e3.nphase = (SELECT MAX(nphase) FROM incomephase)
				AND i3.ayear = i1.ayear),0.0)
	AND e1.expiration IS NOT NULL
-- Residui Attivi Presunti Anno in corso
UNION
SELECT DISTINCT 
	i1.ayear,
	e1.idinc,
	e1.ymov,
	e1.nmov,
	e1.adate,
	ISNULL(i2.curramount,0.0) - ISNULL(
			(SELECT SUM(ISNULL(i3.curramount,0.0)) FROM income e3
	 		JOIN incometotal i3
	 			ON e3.idinc = i3.idinc
			JOIN incomelink ilk
				ON ilk.idchild = i3.idinc
			JOIN incomelast ls
			 	ON e3.idinc = ls.idinc
	 		WHERE ilk.idparent = e1.idinc    -- i3.idinc LIKE e1.idinc + '%'
	 			--AND e3.nphase = (SELECT MAX(nphase) FROM incomephase)
	 			AND i3.ayear = i1.ayear)
			,0.0)
			AS residualamount,
	--i1.flagarrear,
	CASE
		when (( i2.flag & 1)=0) then 'C'
		when (( i2.flag & 1)=1) then 'R'
	End,
	e1.expiration
FROM income e1
INNER JOIN incomeyear i1 
	ON e1.idinc = i1.idinc 
INNER JOIN incometotal i2
	ON i1.idinc = i2.idinc
	AND i1.ayear = i2.ayear
INNER JOIN config p1
	ON p1.assessmentphasecode = e1.nphase --i1.nphase
	AND p1.ayear = i1.ayear
WHERE (( i2.flag & 1)=0)
	AND i2.curramount >
		ISNULL(
		(SELECT SUM(ISNULL(i3.curramount,0.0)) 
		FROM income e3
	 	JOIN incometotal i3
			ON e3.idinc = i3.idinc
		JOIN incomelink ilk
			ON ilk.idchild = i3.idinc
		JOIN incomelast ls
			 ON e3.idinc = ls.idinc
		WHERE ilk.idparent = e1.idinc    -- i3.idinc LIKE e1.idinc + '%'
	 		--AND e3.nphase = (SELECT MAX(nphase) FROM incomephase)
		AND i3.ayear = i1.ayear)
		,0.0)
	AND e1.expiration IS NOT NULL




GO

print '[revenuearrearssupposed] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'epexpview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW epexpview
GO

CREATE                         VIEW [epexpview]
(
yepexp,
nepexp,
description,
amount,
start,
stop,
adate,
idacc,
codeacc,
account,
registry,
doc,
docdate,
idrelated
)
AS
SELECT
yepexp,
nepexp,
description,
amount,
start,
stop,
adate,
account.idacc,
account.codeacc,
account.title,
registry.title,
epexp.doc,
epexp.docdate,
idrelated
FROM epexp
JOIN account
ON epexp.idacc = account.idacc
JOIN registry
ON epexp.idreg= registry.idreg



GO

print '[epexpview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'payrolllinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW payrolllinked
GO

CREATE      VIEW [payrolllinked]
(
	ayear,
	idpayroll,
	fiscalyear,
	enabletaxrelief,
	currentrounding,
	feegross,
	netfee,
	ct,
	cu,
	disbursementdate,
	stop,
	start,
	flagcomputed,
	flagbalance,
	workingdays,
	idresidence,
	idcon,
	lt,
	lu,
	npayroll,
	ycon,
	ncon,
	registry,
	idreg,
	matricula,
	idser,
	service,
	codeser,
	residencecity,
	idupb,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	expenseyear.ayear,
	payroll.idpayroll,
	payroll.fiscalyear,
	payroll.enabletaxrelief,
	payroll.currentrounding,
	payroll.feegross,
	payroll.netfee,
	payroll.ct,
	payroll.cu,
	payroll.disbursementdate,
	payroll.stop,
	payroll.start,
	payroll.flagcomputed,
	payroll.flagbalance,
	payroll.workingdays,
	payroll.idresidence,
	payroll.idcon,
	payroll.lt,
	payroll.lu,
	payroll.npayroll,
	parasubcontract.ycon,
	parasubcontract.ncon, 
	registry.title,
	parasubcontract.idreg,
	parasubcontract.matricula, 
	parasubcontract.idser,
	service.description,
	service.codeser,
	geo_city.title,
	parasubcontract.idupb,
	parasubcontract.idsor1,
	parasubcontract.idsor2,
	parasubcontract.idsor3,
	parasubcontract.idaccmotive,
	parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03,parasubcontract.idsor04,parasubcontract.idsor05
FROM payroll  with (nolock)
JOIN parasubcontract  with (nolock)
	ON payroll.idcon = parasubcontract.idcon
JOIN service  with (nolock)
	ON parasubcontract.idser = service.idser
JOIN registry  with (nolock)
	ON parasubcontract.idreg = registry.idreg
LEFT OUTER JOIN geo_city  with (nolock)
	ON payroll.idresidence = geo_city.idcity 			       
JOIN expensepayroll  with (nolock)
	ON payroll.idpayroll = expensepayroll.idpayroll
JOIN expenseyear  with (nolock)
	ON expenseyear.idexp  = expensepayroll.idexp 
WHERE EXISTS(
	(SELECT * FROM expensepayroll
	WHERE expensepayroll.idpayroll = payroll.idpayroll))



GO

print '[payrolllinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'authpaymentview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW authpaymentview
GO


CREATE         VIEW authpaymentview
(
	idauthpayment,
	sent_date,
	authorize_date,
	attach_amount,
	payable_amount,
	payed_amount,
	idauthstatus,
	authstatus,
	yauthpayment,
	nauthpayment,
	description,
	doc,
	docdate,
	idreg,
	registry,
	ct, cu, lt, lu
)
AS SELECT
	P.idauthpayment,
	P.sent_date,
	P.authorize_date,
	P.attach_amount,
	CASE
		WHEN ISNULL(P.attach_amount,0) -
		ISNULL(
			(SELECT SUM(E.curramount)
			FROM expensetotal E
			JOIN authpaymentexpense PE
				ON E.idexp = PE.idexp
			WHERE PE.idauthpayment = P.idauthpayment)
		,0) < 0 THEN 0
		ELSE
		ISNULL(P.attach_amount,0) -
		ISNULL(
			(SELECT SUM(E.curramount)
			FROM expensetotal E
			JOIN authpaymentexpense PE
				ON E.idexp = PE.idexp
			WHERE PE.idauthpayment = P.idauthpayment)
		,0)
	END,
	ISNULL(
		(SELECT SUM(E.curramount)
		FROM expensetotal E
		JOIN authpaymentexpense PE
			ON E.idexp = PE.idexp
		WHERE PE.idauthpayment = P.idauthpayment)
	,0),
	P.idauthstatus,
	S.description,
	P.yauthpayment,
	P.nauthpayment,
	P.description,
	P.doc,
	P.docdate,
	P.idreg,
	R.title,
	P.ct, P.cu, P.lt, P.lu
FROM authpayment P
JOIN authstatus S
	ON S.idauthstatus = P.idauthstatus
LEFT OUTER JOIN registry R
	ON R.idreg = P.idreg


GO

print 'authpaymentview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationavailable
GO

CREATE               VIEW [itinerationavailable]
	(
	iditineration,
	yitineration,
	nitineration,
	description,
	idreg,
	registry,
	start,
	stop,
	totalgross,
	totadvance,
	active
	)
	AS SELECT
	itineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	itineration.idreg,
	registry.title,
	itineration.start,
	itineration.stop,
	itineration.totalgross,
	itineration.totadvance,
	itineration.active
	FROM itineration (NOLOCK)
	JOIN registry (NOLOCK)
	ON registry.idreg = itineration.idreg
	WHERE itineration.totalgross >
		ISNULL(
		(SELECT SUM(expenseyear_starting.amount)  
		FROM expenseitineration mov
		JOIN expense s
		ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  			ON expensetotal_firstyear.idexp = s.idexp
  			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.iditineration = itineration.iditineration
		AND (mov.movkind = 4 OR mov.movkind = 6)
		)
	,0) +
	ISNULL(
		(SELECT SUM(v.amount)
		FROM expenseitineration mov
		JOIN expense s
		ON s.idexp = mov.idexp
		JOIN expensevar v
		ON v.idexp = mov.idexp
		WHERE mov.iditineration = itineration.iditineration
		AND (mov.movkind = 4 OR mov.movkind = 6)
		AND (ISNULL(v.autokind,'')<>4)
		)
	,0) +
	ISNULL(
		(SELECT SUM(p.amount)
		FROM pettycashoperationitineration mov
		JOIN pettycashoperation p
		ON mov.idpettycash = p.idpettycash
		AND mov.yoperation = p.yoperation
		AND mov.noperation = p.noperation
		WHERE mov.iditineration = itineration.iditineration
		AND mov.movkind = 6)
	,0)

GO

print '[itinerationavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'payrollresidual') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW payrollresidual
GO


CREATE                                     VIEW [payrollresidual]
(
	idpayroll,
	fiscalyear,
	enabletaxrelief,
	currentrounding,
	feegross,
	netfee,
	ct,
	cu,
	disbursementdate,
	stop,
	start,
	flagcomputed,
	flagbalance,
	workingdays,
	idresidence,
	idcon,
	lt,
	lu,
	npayroll,
	linkedamount,
	residual,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
payroll.idpayroll,
payroll.fiscalyear,
payroll.enabletaxrelief,
payroll.currentrounding,
payroll.feegross,
payroll.netfee,
payroll.ct,
payroll.cu,
payroll.disbursementdate,
payroll.stop,
payroll.start,
payroll.flagcomputed,
payroll.flagbalance,
payroll.workingdays,
payroll.idresidence,
payroll.idcon,
payroll.lt,
payroll.lu,
payroll.npayroll,
(
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 	
	FROM expensepayroll mov
	JOIN expense s 
		ON s.idexp = mov.idexp  
	LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
		ON expensetotal_firstyear.idexp = s.idexp
		AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
		ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
		AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	WHERE mov.idpayroll = payroll.idpayroll)
	+
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM expensepayroll mov
	JOIN expense s  
		ON s.idexp = mov.idexp  
	LEFT OUTER JOIN expensevar v
		ON (v.idexp = mov.idexp) 
	WHERE mov.idpayroll =payroll.idpayroll)
),
CONVERT(decimal(23,6),payroll.feegross -
	(
		(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 	
		FROM expensepayroll mov
		JOIN expense s 
			ON s.idexp = mov.idexp  
		LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
			ON expensetotal_firstyear.idexp = s.idexp
			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.idpayroll = payroll.idpayroll)
		+
		(SELECT ISNULL(SUM(v.amount), 0.0) 
		FROM expensepayroll mov
		JOIN expense s  
			ON s.idexp = mov.idexp  LEFT OUTER JOIN expensevar v
			ON (v.idexp = mov.idexp)
		WHERE mov.idpayroll =payroll.idpayroll 
			AND ISNULL(v.autokind,0) <> 4)
	)
),
	parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03,parasubcontract.idsor04,parasubcontract.idsor05
FROM payroll  with (nolock)
JOIN parasubcontract with (nolock)
	ON payroll.idcon = parasubcontract.idcon





GO

print '[payrollresidual] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'authpaymentexpenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW authpaymentexpenseview
GO

CREATE       VIEW authpaymentexpenseview
(
	idautpayment,
	yauthpayment,
	nauthpayment,
	idexp,
	ymov,
	nmov,
	nphase,
	phase,
	amount,
	curramount,
	idreg,
	registry,
	ct, cu, lt, lu
)
AS SELECT
	PE.idauthpayment,
	P.yauthpayment,
	P.nauthpayment,
	PE.idexp,
	E.ymov,
	E.nmov,
	E.nphase,
	EP.description,
	EY.amount,
	ET.curramount,
	E.idreg,
	R.title,
	PE.ct, PE.cu, PE.lt, PE.lu
FROM authpaymentexpense PE
JOIN authpayment P
	ON P.idauthpayment = PE.idauthpayment
JOIN expense E
	ON E.idexp = PE.idexp
JOIN expenseyear EY
	ON EY.idexp = PE.idexp
JOIN expensetotal ET
	ON ET.idexp = PE.idexp
JOIN expensephase EP
	ON EP.nphase = E.nphase
JOIN registry R
	ON R.idreg = E.idreg


GO

print 'authpaymentexpenseview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationlapview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationlapview
GO

CREATE               VIEW itinerationlapview 
(
	iditineration,
	yitineration,
	nitineration,
	lapnumber,
	idforeigncountry,
	codeforeigncountry,
	location,
	flagitalian,
	description,
	starttime,
	stoptime,
	days,
	hours,
	idreduction,
	reduction,
	allowance,
	advancepercentage,
	ancereductionpercentage,
	cu, ct, lu, lt
)
AS SELECT
	itinerationlap.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itinerationlap.lapnumber,
	itinerationlap.idforeigncountry,
	foreigncountry.codeforeigncountry,
	foreigncountry.description,
	itinerationlap.flagitalian,
	itinerationlap.description,
	itinerationlap.starttime,
	itinerationlap.stoptime,
	itinerationlap.days,
	itinerationlap.hours,
	itinerationlap.idreduction,
	reduction.description,
	itinerationlap.allowance, 
	itinerationlap.advancepercentage, 
	itinerationlap.reductionpercentage,
	itinerationlap.cu, itinerationlap.ct, itinerationlap.lu, itinerationlap.lt
FROM itinerationlap
JOIN itineration
ON itineration.iditineration = itinerationlap.iditineration
LEFT OUTER JOIN foreigncountry
ON foreigncountry.idforeigncountry = itinerationlap.idforeigncountry
LEFT OUTER JOIN reduction
ON reduction.idreduction = itinerationlap.idreduction


GO

print 'itinerationlapview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'ivaregisterview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW ivaregisterview
GO

CREATE                               VIEW ivaregisterview 
  (
	idivaregisterkind,
	ivaregisterkind,
	codeivaregisterkind,
	registerclass,
	yivaregister,
	nivaregister,
 	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flagdeferred,
	idreg,
	registry,
	doc,
	docdate,
	adate,
	protocolnum,
	cu,
	ct,
	lu,
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
  )
  AS SELECT
	ivaregister.idivaregisterkind,
	ivaregisterkind.description,
	ivaregisterkind.codeivaregisterkind,
	ivaregisterkind.registerclass,
	ivaregister.yivaregister,
	ivaregister.nivaregister,
 	ivaregister.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	ivaregister.yinv,
	ivaregister.ninv,
	invoice.flagdeferred,
	invoice.idreg,
	registry.title,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	ivaregister.protocolnum,
	ivaregister.cu,
	ivaregister.ct,
	ivaregister.lu,
	ivaregister.lt,
	isnull(invoice.idsor01,invoicekind.idsor01),
	isnull(invoice.idsor02,invoicekind.idsor02),
	isnull(invoice.idsor03,invoicekind.idsor03),
	isnull(invoice.idsor04,invoicekind.idsor04),
	isnull(invoice.idsor05,invoicekind.idsor05)		
  	FROM ivaregister (NOLOCK)
	JOIN ivaregisterkind (NOLOCK)
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
	JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = ivaregister.idinvkind
	JOIN invoice (NOLOCK)
	ON invoice.idinvkind = ivaregister.idinvkind
  	AND invoice.yinv = ivaregister.yinv
  	AND invoice.ninv = ivaregister.ninv
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg



GO

print 'ivaregisterview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'payrollview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW payrollview
GO


--select * from payrollview
CREATE   VIEW [payrollview]
(
	idpayroll,
	fiscalyear,
	enabletaxrelief,
	currentrounding,
	feegross,
	netfee, 
	ct,
	cu,
	disbursementdate,
	stop,
	start,
	flagcomputed,
	flagbalance, 
	workingdays,
	idresidence,
	idcon,
	lt,
	lu,
	npayroll,
	ycon, 
	ncon,
	registry,
	idreg,
	matricula,
	idser, 
	service,
	codeser,
	residencecity,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	payroll.idpayroll,
	payroll.fiscalyear,
	payroll.enabletaxrelief,
	payroll.currentrounding,
	payroll.feegross,
	payroll.netfee, 
	payroll.ct,
	payroll.cu,
	payroll.disbursementdate,
	payroll.stop,
	payroll.start,
	payroll.flagcomputed,
	payroll.flagbalance, 
	payroll.workingdays,
	payroll.idresidence,
	payroll.idcon,
	payroll.lt,
	payroll.lu,
	payroll.npayroll,
	parasubcontract.ycon, 
	parasubcontract.ncon,
	registry.title,
	parasubcontract.idreg,
	parasubcontract.matricula,
	parasubcontract.idser,
	service.description,
	service.codeser,
	geo_city.title,
	parasubcontract.idsor01,parasubcontract.idsor02,parasubcontract.idsor03,parasubcontract.idsor04,parasubcontract.idsor05
FROM payroll with (nolock)
JOIN parasubcontract with (nolock)
	ON payroll.idcon = parasubcontract.idcon
JOIN service with (nolock)
	ON parasubcontract.idser = service.idser
INNER JOIN registry with (nolock)
	ON parasubcontract.idreg = registry.idreg
LEFT OUTER JOIN geo_city with (nolock)
	ON payroll.idresidence = geo_city.idcity


GO

print '[payrollview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationrefundview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationrefundview
GO

CREATE               VIEW itinerationrefundview 
(
	iditineration,
	yitineration,
	nitineration,
	nrefund,
	idcurrency,
	codecurrency,
	currency,
	iditinerationrefundkind,
	codeitinerationrefundkind,
	itinerationrefundkind,
	iditinerationrefundkindgroup,
	itinerationrefundkindgroup,
	description,
	amount,
	exchangerate,
	extraallowance,
	advancepercentage,
	starttime,
	stoptime,
	flagitalian,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	itinerationrefund.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itinerationrefund.nrefund,
	itinerationrefund.idcurrency,
	currency.codecurrency,
	currency.description,
	itinerationrefund.iditinerationrefundkind,
	itinerationrefundkind.codeitinerationrefundkind,
	itinerationrefundkind.description,
	itinerationrefundkindgroup.iditinerationrefundkindgroup,
	itinerationrefundkindgroup.description,
	itinerationrefund.description,
	itinerationrefund.amount,
	itinerationrefund.exchangerate,
	itinerationrefund.extraallowance,
	itinerationrefund.advancepercentage,
	itinerationrefund.starttime,
	itinerationrefund.stoptime,
	itinerationrefund.flag_geo,
	itinerationrefund.cu, 
	itinerationrefund.ct, 
	itinerationrefund.lu, 
	itinerationrefund.lt
FROM itinerationrefund
JOIN itineration
	ON itineration.iditineration = itinerationrefund.iditineration
LEFT OUTER JOIN currency
	ON currency.idcurrency = itinerationrefund.idcurrency
LEFT OUTER JOIN itinerationrefundkind
	ON itinerationrefundkind.iditinerationrefundkind = itinerationrefund.iditinerationrefundkind
LEFT OUTER JOIN itinerationrefundkindgroup
	ON itinerationrefundkindgroup.iditinerationrefundkindgroup = itinerationrefundkind.iditinerationrefundkindgroup


GO

print 'itinerationrefundview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatedetailgroupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatedetailgroupview
GO


--select * from mandatedetailgroupview
--clear_table_info'mandatedetailgroupview'
CREATE VIEW [mandatedetailgroupview]
(
	idmankind,
	yman,
	nman,
	idgroup,
	mankind,
	idinv,
	codeinv,
	inventorytree,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	assetkind,
	start,
	stop,
	taxable_euro,
	iva_euro,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	toinvoice,
	exchangerate,
	linktoinvoice,
	linktoasset,
	multireg,
	mandateidreg,
	mandatedetailidreg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	idlist,
	npackage,
	idunit,
	idpackage,
	unitsforpackage,
	flagto_unload,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
-- 	mandate.idreg,
	CASE
		WHEN (mandate.idreg is not null) THEN (mandate.idreg)
		WHEN (mandatedetail.idreg is not null) THEN (mandatedetail.idreg)
		ELSE null
	END,
	--registry.title, 
	CASE
		WHEN (mandate.idreg is not null) THEN (select title from
						registry 
						where idreg= mandate.idreg)
		WHEN (mandatedetail.idreg is not null) THEN (select title from
						registry 
						where idreg= mandatedetail.idreg)
		ELSE null
	END,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	ISNULL(ROUND(SUM(mandatedetail.taxable),2),0), 	
	mandatedetail.taxrate,
	ISNULL(SUM(mandatedetail.tax),0), 
  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	/* Prima facendo  Round(somma * x*y*z ) sbagliava gli arrotondamenti xkè avvenivano dettaglio x dettaglio 
	   adesso calcola   Round(somma) * x*y*z  prima si calcola il taxable poi fa le moltiplicazioni.
	isnull(sum(
 	    ROUND(mandatedetail.taxable * mandatedetail.number * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)
	),0) ,  */
	Round(
	(SELECT  ISNULL(SUM(MD1.taxable),0)
	FROM mandatedetail MD1
	JOIN mandate M1
		ON M1.yman = MD1.yman AND M1.nman = MD1.nman AND M1.idmankind = MD1.idmankind
	WHERE M1.idmankind = mandatedetail.idmankind
		AND M1.yman = mandatedetail.yman 
		AND M1.nman = mandatedetail.nman 
		AND MD1.idgroup = mandatedetail.idgroup)
	 * ISNULL(mandatedetail.npackage,mandatedetail.number)   * CONVERT(DECIMAL(19,6),mandate.exchangerate)  
	 * (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0)))
	,2)
	,
	isnull(sum(
		ROUND(mandatedetail.tax,2)
	),0) , -- sara
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	isnull(sum(mandatedetail.unabatable),0),
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandate.exchangerate,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandate.idreg,mandatedetail.idreg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.idlist,
	mandatedetail.npackage,
	mandatedetail.idunit,
	mandatedetail.idpackage,
	mandatedetail.unitsforpackage,
	mandatedetail.flagto_unload,
	isnull(mandate.idsor01,mandatekind.idsor01),
	isnull(mandate.idsor02,mandatekind.idsor02),
	isnull(mandate.idsor03,mandatekind.idsor03),
	isnull(mandate.idsor04,mandatekind.idsor04),
	isnull(mandate.idsor05,mandatekind.idsor05)
FROM mandatedetail (NOLOCK)
JOIN mandatekind
	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT JOIN inventorytree (NOLOCK)
	ON inventorytree.idinv = mandatedetail.idinv
JOIN mandate (NOLOCK)
	ON mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN ivakind
	ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus (NOLOCK)	
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
GROUP BY 
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
 	mandate.idreg,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	mandatedetail.npackage,	mandatedetail.idlist, mandatedetail.idunit,mandatedetail.idpackage,mandatedetail.unitsforpackage ,
	mandatedetail.taxrate,
  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandate.exchangerate,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandate.idreg,
	mandatedetail.idreg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.flagto_unload,
	isnull(mandate.idsor01,mandatekind.idsor01),
	isnull(mandate.idsor02,mandatekind.idsor02),
	isnull(mandate.idsor03,mandatekind.idsor03),
	isnull(mandate.idsor04,mandatekind.idsor04),
	isnull(mandate.idsor05,mandatekind.idsor05)


GO

print '[mandatedetailgroupview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'locationunusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW locationunusable
GO


CREATE              VIEW locationunusable
(
	idlocation,
	locationcode,
	nlevel,
	leveldescr,
	paridlocation,
	description,
	idman,
	manager,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	location.idlocation,
	location.locationcode,
	location.nlevel,
	locationlevel.description,
	location.paridlocation,
	location.description,
	location.idman,
	manager.title,
	location.cu, 
	location.ct, 
	location.lu,
	location.lt 
FROM location
JOIN locationlevel
	ON locationlevel.nlevel = location.nlevel
LEFT OUTER JOIN manager
	ON manager.idman = location.idman
WHERE locationlevel.flag & 2 <> 2
	OR location.idlocation IN
		(SELECT paridlocation FROM location
		WHERE paridlocation IS NOT NULL)



GO

print 'locationunusable OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'unifiedivapayview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW unifiedivapayview
GO

CREATE                       VIEW unifiedivapayview
(
yunifiedivapay,
nunifiedivapay,
iddepartment,
department,
assesmentdate,
creditamount,
creditamountdeferred,
debitamount,
debitamountdeferred,
paymentamount,
refundamount,
paymentkind,
start,
stop,
paymentdetails,
mixed,
prorata,
dateivapay,
ct,
cu,
lt,
lu
)
AS SELECT
unifiedivapay.yunifiedivapay,
unifiedivapay.nunifiedivapay,
unifiedivapay.iddepartment,
department.description,
unifiedivapay.assesmentdate,
unifiedivapay.creditamount,
unifiedivapay.creditamountdeferred,
unifiedivapay.debitamount,
unifiedivapay.debitamountdeferred,
unifiedivapay.paymentamount,
unifiedivapay.refundamount,
unifiedivapay.paymentkind,
unifiedivapay.start,
unifiedivapay.stop,
unifiedivapay.paymentdetails,
unifiedivapay.mixed,
unifiedivapay.prorata,
unifiedivapay.dateivapay,
unifiedivapay.ct,
unifiedivapay.cu,
unifiedivapay.lt,
unifiedivapay.lu
FROM unifiedivapay
JOIN department
ON unifiedivapay.iddepartment = department.iddepartment


GO

print 'unifiedivapayview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'showcaseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW showcaseview
GO

CREATE   view showcaseview as
(
	select showcase.idshowcase as idshowcase,
	showcase.title as showcasetitle,
	showcase.description as showcasedescription,
	showcase.idstore as idstore,
	store.description as storedescription,
	store.deliveryaddress as deliveryaddress
    from showcase join store on (showcase.idstore = store.idstore )
)

GO

print 'showcaseview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationtaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationtaxview
GO

CREATE               VIEW itinerationtaxview
(
	iditineration,
	yitineration,
	nitineration,
	taxcode,
	description,
	taxref,
	taxkind,
	taxablenumerator,
	taxabledenominator,
	adminrate,
 	adminnumerator,
  	admindenominator,
	employrate,
  	employnumerator,
  	employdenominator,
	admintax,
	employtax,
	taxable,
	flagunabatable, 
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	itinerationtax.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itinerationtax.taxcode,
	tax.description,
	tax.taxref,
	tax.taxkind,
	itinerationtax.taxablenumerator,
	itinerationtax.taxabledenominator,
	itinerationtax.adminrate,
  	itinerationtax.adminnumerator,
  	itinerationtax.admindenominator,
	itinerationtax.employrate,
  	itinerationtax.employnumerator,
  	itinerationtax.employdenominator,
	itinerationtax.admintax,
	itinerationtax.employtax,
	itinerationtax.taxable,
	tax.flagunabatable, 
	itinerationtax.cu,
	itinerationtax.ct,
	itinerationtax.lu,
	itinerationtax.lt
FROM itinerationtax
JOIN tax
	ON tax.taxcode = itinerationtax.taxcode
JOIN itineration
	ON itineration.iditineration = itinerationtax.iditineration

GO

print 'itinerationtaxview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'locationusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW locationusable
GO

CREATE              VIEW locationusable
(
	idlocation,
	locationcode,
	nlevel,
	leveldescr,
	paridlocation,
	description,
	idman,
	manager,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	location.idlocation,
	location.locationcode,
	location.nlevel,
	locationlevel.description,
	location.paridlocation,
	location.description,
	location.idman,
	manager.title,
	location.cu, 
	location.ct, 
	location.lu,
	location.lt 
FROM location
JOIN locationlevel
	ON locationlevel.nlevel = location.nlevel
LEFT OUTER JOIN manager
	ON manager.idman = location.idman
WHERE locationlevel.flag & 2 <> 0
	AND location.idlocation NOT IN
		(SELECT paridlocation FROM location
		WHERE paridlocation IS NOT NULL)



GO

print 'locationusable OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accountprevisionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accountprevisionview
GO

CREATE                     VIEW accountprevisionview
(
	idsorkind,
	codesorkind,
	sorkind,
	idsor,
	sortcode,
	sorting,
	paridsor,
	idacc,
	codeacc,
	account,
	paridacc,
	nlevel,
	leveldescr,
	prevision,
	previousprevision,
	ayear,
	ct,
	cu,
	lt,
	lu
)
AS
SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	sorting.idsor,
	sorting.sortcode,
	sorting.description,
	sorting.paridsor,
	account.idacc,
	account.codeacc,
	account.title,
	account.paridacc,
	account.nlevel,
	accountlevel.description,
	ISNULL(sortingtotal.currentprev,0),
	ISNULL(sortingtotal.previousprev,0),
	account.ayear,
	accountyear.ct,
	accountyear.cu,
	accountyear.lt,
	accountyear.lu
FROM sorting
CROSS JOIN account
LEFT OUTER JOIN sortingtotal
	ON account.idacc = sortingtotal.idacc
	AND sorting.idsor = sortingtotal.idsor
LEFT OUTER JOIN accountyear
	ON accountyear.idacc = account.idacc
	AND accountyear.idsor = sorting.idsor
LEFT OUTER JOIN sortingkind
	ON sorting.idsorkind = sortingkind.idsorkind
LEFT OUTER JOIN accountlevel
	ON accountlevel.nlevel = account.nlevel
	AND accountlevel.ayear = account.ayear


GO

print 'accountprevisionview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'ivapayexpenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW ivapayexpenseview
GO

CREATE               VIEW [ivapayexpenseview]
(
	yivapay,
	nivapay,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	netamount,
	totalamount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	ivapayexpense.yivapay,
	ivapayexpense.nivapay,
	ivapayexpense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	ISNULL(expenseyear_starting.amount,0)- ISNULL((SELECT SUM(employtax) from expensetax
				where idexp = expense.idexp ),0),
	ISNULL(expenseyear_starting.amount,0)+ ISNULL((SELECT SUM(admintax) from expensetax
				where idexp = expense.idexp ),0),
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
  	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	ivapayexpense.cu,
	ivapayexpense.ct,
	ivapayexpense.lu,
	ivapayexpense.lt
FROM ivapayexpense 
JOIN expense  
	ON expense.idexp = ivapayexpense.idexp
JOIN expensephase 
	ON expensephase.nphase = expense.nphase
JOIN expenseyear 
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal 
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN fin 
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb 
	ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry 
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager 
	ON manager.idman = expense.idman
LEFT OUTER JOIN expenselast  
	ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN payment  
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN service 
	ON service.idser = expenselast.idser
LEFT OUTER JOIN expense parentexpense 
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting 
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear

GO

print '[ivapayexpenseview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimatedetailgroupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimatedetailgroupview
GO

CREATE    VIEW [estimatedetailgroupview]
(
	idestimkind,
	yestim,
	nestim,
	idgroup,
	estimkind,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	start,
	stop,
	taxable_euro,
	iva_euro,
	idaccmotive,
	idivakind,
	ivakind,
	toinvoice,
	exchangerate,
	linktoinvoice,
	multireg,
	estimateidreg,
	estimatedetailidreg
)
AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatedetail.idgroup,
	estimatekind.description,
-- 	estimate.idreg,
	CASE
		WHEN (estimate.idreg is not null) THEN (estimate.idreg)
		WHEN (estimatedetail.idreg is not null) THEN (estimatedetail.idreg)
		ELSE null
	END,
	--registry.title, 
	CASE
		WHEN (estimate.idreg is not null) THEN (select title from
						registry 
						where idreg= estimate.idreg)
		WHEN (estimatedetail.idreg is not null) THEN (select title from
						registry 
						where idreg= estimatedetail.idreg)
		ELSE null
	END,
	estimatedetail.detaildescription,
	estimatedetail.annotations,
	estimatedetail.number,
	ISNULL(SUM(estimatedetail.taxable),0), 	
	estimatedetail.taxrate,
	ISNULL(SUM(estimatedetail.tax),0), 
  	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	Round(
	(SELECT  ROUND(ISNULL(SUM(MD1.taxable),0),2)
	FROM estimatedetail MD1
	JOIN estimate M1
		ON M1.yestim = MD1.yestim AND M1.nestim = MD1.nestim AND M1.idestimkind = MD1.idestimkind
	WHERE M1.idestimkind = estimatedetail.idestimkind
		AND M1.yestim = estimatedetail.yestim 
		AND M1.nestim = estimatedetail.nestim
		AND MD1.idgroup = estimatedetail.idgroup)
	 * ISNULL(estimatedetail.number,0)   * CONVERT(DECIMAL(19,6),estimate.exchangerate)  
	 * (1 - CONVERT(DECIMAL(19,6),ISNULL(estimatedetail.discount, 0.0)))
	,2)
	,
	isnull(sum(
		ROUND(estimatedetail.tax,2)
	),0) ,
	estimatedetail.idaccmotive,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimate.exchangerate,
	estimatekind.linktoinvoice,
	estimatekind.multireg,
	estimate.idreg,estimatedetail.idreg
FROM estimatedetail
JOIN estimatekind
	ON estimatekind.idestimkind = estimatedetail.idestimkind
JOIN estimate
	ON estimate.yestim = estimatedetail.yestim
	AND estimate.nestim = estimatedetail.nestim
	AND estimate.idestimkind = estimatedetail.idestimkind
JOIN ivakind
	ON ivakind.idivakind = estimatedetail.idivakind
GROUP BY 
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatedetail.idgroup,
	estimatekind.description,
 	estimate.idreg,
	estimatedetail.detaildescription,
	estimatedetail.annotations,
	estimatedetail.number,
	estimatedetail.taxrate,
  	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	estimatedetail.idaccmotive,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimate.exchangerate,
	estimatekind.linktoinvoice,
	estimatekind.multireg,
	estimate.idreg,
	estimatedetail.idreg


GO

print '[estimatedetailgroupview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accountvardetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accountvardetailview
GO


CREATE                   VIEW accountvardetailview
(
	yvar,
	nvar,
	variationdescription,
	enactment,
	nenactment,
	enactmentdate,
	codesorkind,
	idsorkind,
	idsor,
	sortcode,
	sorting,
	idacc,
	codeacc,
	account,
	ayear,
	description,
	amount,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	accountvardetail.yvar,
	accountvardetail.nvar,
	accountvar.description,
	accountvar.enactment,
	accountvar.nenactment,
	accountvar.enactmentdate,
	sortingkind.codesorkind,
	sorting.idsorkind,
	accountvardetail.idsor,
	sorting.sortcode,
	sorting.description,
	accountvardetail.idacc,
	account.codeacc,
	account.title,
	account.ayear,
	accountvardetail.description,
	accountvardetail.amount,
	accountvardetail.cu,
	accountvardetail.ct,
	accountvardetail.lu,
	accountvardetail.lt
FROM accountvardetail
JOIN accountvar
	ON accountvardetail.yvar = accountvar.yvar
	AND accountvardetail.nvar = accountvar.nvar
JOIN account
	ON accountvardetail.idacc = account.idacc
JOIN sorting
	ON accountvardetail.idsor = sorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind


GO

print 'accountvardetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'storeunloadview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW storeunloadview
GO


CREATE   VIEW storeunloadview
(
	idstoreunload,
	ystoreunload,
	nstoreunload,
	description,
	idstore,
	idstoreunload_motive,
	storeunload_motive,
	idreg,
	registry,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	storeunload.idstoreunload,
	storeunload.ystoreunload,
	storeunload.nstoreunload,
	storeunload.description,
	storeunload.idstore,
	storeunload.idstoreunload_motive,
	storeunload_motive.description,
	storeunload.idreg,
	registry.title,
	storeunload.adate,
	storeunload.cu,
	storeunload.ct,
	storeunload.lu,
	storeunload.lt
FROM storeunload
LEFT OUTER JOIN registry
	ON registry.idreg = storeunload.idreg
LEFT OUTER JOIN storeunload_motive
	ON storeunload.idstoreunload_motive = storeunload_motive.idstoreunload_motive


GO

print 'storeunloadview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'ivapayincomeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW ivapayincomeview
GO



CREATE               VIEW [ivapayincomeview]
	(
	yivapay,
	nivapay,
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	unpartitioned,
	flag,
	totflag,
	flagarrear,
  	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
	)
	AS SELECT
	ivapayincome.yivapay,
	ivapayincome.nivapay,
	ivapayincome.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	--income.ycreation,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	incomeyear.idupb,
	upb.codeupb,
	upb.title,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	--income.ypro,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	--income.amount,
	incomeyear_starting.amount,
	--incometotal.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	ISNULL(incometotal.curramount,0)-ISNULL(incometotal.partitioned,0),
	--income.fulfilled,
	incomelast.flag,
	incometotal.flag,
	--incomeyear.flagarrear,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	ivapayincome.cu,
	ivapayincome.ct,
	ivapayincome.lu,
	ivapayincome.lt
	FROM ivapayincome (NOLOCK)
	JOIN income (NOLOCK)
	ON income.idinc = ivapayincome.idinc
	JOIN incomephase (NOLOCK)
	ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)
	ON incomeyear.idinc = income.idinc
	JOIN incometotal (NOLOCK)
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN fin (NOLOCK)
	ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)
	ON upb.idupb = incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)
	ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)
	ON manager.idman = income.idman
	LEFT OUTER JOIN incomelast  (NOLOCK)
	ON income.idinc = incomelast.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)
	ON proceeds.kpro = incomelast.kpro
	LEFT OUTER JOIN income parentincome (NOLOCK)
	ON income.parentidinc = parentincome.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  	ON incometotal_firstyear.idinc = income.idinc
  	AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  	AND incomeyear_starting.ayear = incometotal_firstyear.ayear

GO

print '[ivapayincomeview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accountyearview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accountyearview
GO


CREATE               VIEW accountyearview
(
	ayear,
	idacc,
	codeacc,
	account,
	idsorkind,
	codesorkind,
	sorkind,
	idsor,
	sortcode,
	sorting,
	paridacc,
	paridsor,
	nlevel,
	leveldescr,
	prevision,
	previousprevision,
	ct,
	cu,
	lt,
	lu
)
AS SELECT 
accountyear.ayear,
accountyear.idacc,
account.codeacc,
account.title,
sorting.idsorkind,
sortingkind.codesorkind,
sortingkind.description, 
accountyear.idsor,
sorting.sortcode,
sorting.description,
account.paridacc,
sorting.paridsor,
account.nlevel,
accountlevel.description,
accountyear.prevision,
accountyear.previousprevision,
accountyear.ct,
accountyear.cu,
accountyear.lt,
accountyear.lu
FROM accountyear
JOIN account
	ON accountyear.idacc = account.idacc
JOIN sorting
	ON sorting.idsor = accountyear.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN accountlevel
	ON accountlevel.nlevel = account.nlevel
	AND accountlevel.ayear = account.ayear



GO

print 'accountyearview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'unifiedivapaydetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW unifiedivapaydetailview
GO

CREATE                       VIEW [unifiedivapaydetailview]
(
	yunifiedivapay,
	nunifiedivapay,
	iddepartment,
	department,
	start,
	stop,
	idivaregisterkindunified,
	description,
	registerclass,
	iva,
	ivadeferred,
	ivatotal,
	unabatable,
	unabatabledeferred,
	unabatabletotal,
	prorata,
	mixed,
	ivanet,
	ivanetdeferred,
	cu, 
	ct, 
	lu, 
	lt
	)
	AS SELECT
	unifiedivapaydetail.yunifiedivapay,
	unifiedivapaydetail.nunifiedivapay,
	unifiedivapaydetail.iddepartment,
	department.description,
	unifiedivapay.start,
	unifiedivapay.stop,
	unifiedivapaydetail.idivaregisterkindunified,
	ivaregisterkind.description,
	ivaregisterkind.registerclass,
	unifiedivapaydetail.iva,
	unifiedivapaydetail.ivadeferred,
	ISNULL(unifiedivapaydetail.iva,0) + ISNULL(unifiedivapaydetail.ivadeferred,0),
	unifiedivapaydetail.unabatable,
	unifiedivapaydetail.unabatabledeferred,
	ISNULL(unifiedivapaydetail.unabatable,0) + ISNULL(unifiedivapaydetail.unabatabledeferred,0),
	unifiedivapaydetail.prorata,
	unifiedivapaydetail.mixed,
	unifiedivapaydetail.ivanet,
	unifiedivapaydetail.ivanetdeferred,
	unifiedivapaydetail.cu, 
	unifiedivapaydetail.ct, 
	unifiedivapaydetail.lu,
	unifiedivapaydetail.lt 
	FROM unifiedivapaydetail (NOLOCK)
	JOIN ivaregisterkind (NOLOCK)
	ON ivaregisterkind.idivaregisterkindunified = unifiedivapaydetail.idivaregisterkindunified
	JOIN unifiedivapay (NOLOCK)
	ON unifiedivapay.nunifiedivapay = unifiedivapaydetail.nunifiedivapay
	AND unifiedivapay.yunifiedivapay = unifiedivapaydetail.yunifiedivapay
	JOIN department
	ON department.iddepartment = unifiedivapaydetail.iddepartment




GO

print '[unifiedivapaydetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'totinvoicedetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW totinvoicedetailview
GO


CREATE   VIEW [totinvoicedetailview]
(
	idinvkind,
	yinv,
	ninv,
	taxabletotal,
	ivatotal
)
AS SELECT
	invoicedetail.idinvkind,
	invoicedetail.yinv,
	invoicedetail.ninv,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN invoicedetail.idexp_taxable IS NOT NULL THEN
			    ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
				  CONVERT(decimal(19,6),invoice.exchangerate) *
				  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
				)
			ELSE
			   0
		    END
			
		   ),0)
		),
	   CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		 CASE
		 WHEN invoicedetail.idexp_iva IS NOT NULL THEN
			ROUND(invoicedetail.tax ,2)
		  ELSE 0
		END
		),0)
	   )
FROM invoicedetail (NOLOCK)
JOIN invoice (NOLOCK)
	ON invoicedetail.idinvkind = invoice.idinvkind
	AND invoicedetail.yinv = invoice.yinv
	AND invoicedetail.ninv = invoice.ninv
GROUP BY invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv


GO

print '[totinvoicedetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'totinvoiceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW totinvoiceview
GO

CREATE                                         VIEW [totinvoiceview]
(
	idinvkind,
	yinv,
	ninv,
	taxabletotal,
	ivatotal,
	unabatabletotal
)
	AS SELECT
	invoicedetail.idinvkind,
	invoicedetail.yinv,
	invoicedetail.ninv,
-- Arrotondamento effettuato come nella vista TOTMANDATEVIEW
	CONVERT(decimal(19,2),
		SUM(
		    ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
			  CONVERT(decimal(19,6),invoice.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2
			 )
		   )
		),
	CONVERT(decimal(19,2),
	SUM(ROUND(
		ISNULL(invoicedetail.tax, 0.0)  ,2))),
	CONVERT(decimal(19,2),	SUM(ISNULL(invoicedetail.unabatable, 0)))
	FROM invoicedetail (NOLOCK)
	JOIN invoice (NOLOCK)
  ON invoicedetail.idinvkind = invoice.idinvkind
  AND invoicedetail.yinv = invoice.yinv
  AND invoicedetail.ninv = invoice.ninv
	GROUP BY invoicedetail.idinvkind,
  invoicedetail.yinv, 
  invoicedetail.ninv,
  invoice.exchangerate





GO

print '[totinvoiceview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'budgetprevisionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW budgetprevisionview
GO

 
CREATE  VIEW [budgetprevisionview]
(
	ayear,
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	paridsor,
	nlevel,
	leveldescr,
	idupb,
	codeupb,
	upb,
	paridupb,
	prevision,
	previousprevision,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	ct,
	cu,
	lt,
	lu
)
AS
SELECT
budgetprevision.ayear,
sortingkind.idsorkind,
sortingkind.codesorkind,
sortingkind.description,
budgetprevision.idsor,
sorting.sortcode,
sorting.description,
sorting.paridsor,
sorting.nlevel,
sortinglevel.description,
budgetprevision.idupb,
upb.codeupb,
upb.title,
upb.paridupb,
budgetprevision.prevision,
budgetprevision.previousprevision,
budgetprevision.prevision2,
budgetprevision.prevision3,
budgetprevision.prevision4,
budgetprevision.prevision5,
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05,	
budgetprevision.ct,
budgetprevision.cu,
budgetprevision.lt,
budgetprevision.lu
FROM budgetprevision
JOIN sorting
ON budgetprevision.idsor = sorting.idsor
JOIN upb
ON budgetprevision.idupb = upb.idupb
JOIN sortingkind
ON sortingkind.idsorkind = sorting.idsorkind
JOIN sortinglevel
ON sortinglevel.nlevel = sorting.nlevel
AND sortingkind.idsorkind = sortinglevel.idsorkind


GO

print '[budgetprevisionview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'parentexpenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW parentexpenseview
GO


CREATE                  VIEW parentexpenseview
(
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idformerexpense,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	paymentadate,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idregistrypaymethod,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	iddeputy,
	deputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	autocode,
	idclawback,
	clawback,
	clawbackref,
	nbill,
	idpay,
	txt,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expensechild.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idformerexpense,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.adate,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idregistrypaymethod,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.iddeputy,  
	deputy.title,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expense.autocode,
	expense.idclawback,
	clawback.description,
	clawback.clawbackref,
	expenselast.nbill,
	expenselast.idpay,
	expense.txt,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt
FROM expense
JOIN expense expensechild
	ON expense.idexp= expensechild.parentidexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN expenselast 
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN registry deputy
	ON deputy.idreg = expenselast.iddeputy
LEFT OUTER JOIN clawback
	ON clawback.idclawback = expense.idclawback
LEFT OUTER JOIN expensetotal expensetotal_firstyear
  	ON expensetotal_firstyear.idexp = expense.idexp
  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear


GO

print 'parentexpenseview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'autoexpensesortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW autoexpensesortingview
GO


CREATE              VIEW autoexpensesortingview
(
	codefin,finance,
	codeupb,upb,
	regsortingkind,registrysortcode,registrykind,
	manager,
	sortingkind,sortingcode,sorting,
	ayear,
	idautosort,
	idsorkind,
	codesorkind,
	idsorkindreg,
	codesorkindreg,
	defaultn1,
	defaultn2,
	defaultn3,
	defaultn4,
	defaultn5,
	defaults1,
	defaults2,
	defaults3,
	defaults4,
	defaults5,
	denominator,
	flagnodate,
	idfin,
	idsor,
	idsorreg,
	numerator,
	ct,
	cu,
	lt,
	lu,
	idman,
	defaultv1,
	defaultv2,
	defaultv3,
	defaultv4,
	defaultv5,
	idupb
)
AS
SELECT     	
	fin.codefin, fin.title,
	upb.codeupb,upb.title,
	t2.description,c2.sortcode,c2.description,
	manager.title,
	sortingkind.description,sorting.sortcode,sorting.description,
	A.ayear,
	A.idautosort,
	sortingkind.idsorkind,
	sortingkind.codesorkind,
	t2.idsorkind,
	t2.codesorkind,
	A.defaultn1,
	A.defaultn2,
	A.defaultn3,
	A.defaultn4,
	A.defaultn5,
	A.defaults1,
	A.defaults2,
	A.defaults3,
	A.defaults4,
	A.defaults5,
	A.denominator,
	A.flagnodate,
	A.idfin,
	A.idsor,
	A.idsorreg,
	A.numerator,
	A.ct,
	A.cu,
	A.lt,
	A.lu,
	A.idman,
	A.defaultv1,
	A.defaultv2,
	A.defaultv3,
	A.defaultv4,
	A.defaultv5,
	A.idupb
FROM autoexpensesorting A
LEFT OUTER JOIN sorting
	ON A.idsor = sorting.idsor
LEFT OUTER JOIN sortingkind
	ON sorting.idsorkind = sortingkind.idsorkind
LEFT OUTER JOIN sorting c2
	ON A.idsorreg = c2.idsor
LEFT OUTER JOIN sortingkind t2
	ON c2.idsorkind = t2.idsorkind
LEFT OUTER JOIN fin
	ON fin.idfin = A.idfin
	AND fin.ayear = A.ayear
LEFT OUTER JOIN upb
	ON upb.idupb = A.idupb
LEFT OUTER JOIN manager
	ON A.idman = manager.idman


GO

print 'autoexpensesortingview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'totmandatedetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW totmandatedetailview
GO


CREATE    VIEW [totmandatedetailview]
(
	idmankind,
	yman,
	nman,
	taxabletotal,
	ivatotal
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
-- Modifica Rusciano Giuseppe
-- Aggiunto il comando CONVERT davanti ai campi FLOAT per non perdere informazione in fase di
-- prodotto. La perdita causa un errato arrotondamento
-- Il controllo non dovrebbe più servire se si cambia il tipo di campo a decimal(19,6) da float
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN mandatedetail.idexp_taxable IS NOT NULL THEN
			    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
				  CONVERT(decimal(19,6),mandate.exchangerate) *
				  (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2
				)
			ELSE
			   0
		    END
			
		   ),0)
		),
	   CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		 CASE
		 WHEN mandatedetail.idexp_iva IS NOT NULL THEN
			ROUND(mandatedetail.tax ,2)
			
		  ELSE 0
		END
		),0)
	   )
-- Fine Modifica
	FROM mandatedetail (NOLOCK)
	JOIN mandate (NOLOCK)
  	ON mandatedetail.idmankind = mandate.idmankind
	AND mandatedetail.yman = mandate.yman
  	AND mandatedetail.nman = mandate.nman
	WHERE mandatedetail.stop is null --and (mandatedetail.idexp_iva  is not null OR mandatedetail.idexp_taxable is not null)
	GROUP BY mandatedetail.idmankind, mandatedetail.yman, mandatedetail.nman


GO

print '[totmandatedetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'autoincomesortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW autoincomesortingview
GO


CREATE              VIEW autoincomesortingview
(
	codefin,finance,
	codeupb,upb,
	regsortingkind,registrysortcode,registrykind,
	manager,
	sortingkind,sortingcode,sorting,
	ayear,
	idautosort,
	idsorkind,
	codesorkind,
	idsorkindreg,
	codesorkindreg,
	defaultn1,
	defaultn2,
	defaultn3,
	defaultn4,
	defaultn5,
	defaults1,
	defaults2,
	defaults3,
	defaults4,
	defaults5,
	denominator,
	flagnodate,
	idfin,
	idsor,
	idsorreg,
	numerator,
	ct,
	cu,
	lt,
	lu,
	idman,
	defaultv1,
	defaultv2,
	defaultv3,
	defaultv4,
	defaultv5,
	idupb
)
AS
SELECT 
	fin.codefin, fin.title,
	upb.codeupb,upb.title,
	t2.description,c2.sortcode,c2.description,
	manager.title,
	sortingkind.description,sorting.sortcode,sorting.description,
	A.ayear,
	A.idautosort,
	sorting.idsorkind,
	sortingkind.codesorkind,
	c2.idsorkind,
	t2.codesorkind,
	A.defaultn1,
	A.defaultn2,
	A.defaultn3,
	A.defaultn4,
	A.defaultn5,
	A.defaults1,
	A.defaults2,
	A.defaults3,
	A.defaults4,
	A.defaults5,
	A.denominator,
	A.flagnodate,
	A.idfin,
	A.idsor,
	A.idsorreg,
	A.numerator,
	A.ct,
	A.cu,
	A.lt,
	A.lu,
	A.idman,
	A.defaultv1,
	A.defaultv2,
	A.defaultv3,
	A.defaultv4,
	A.defaultv5,
	A.idupb
FROM autoincomesorting A
LEFT OUTER JOIN sorting
	ON A.idsor = sorting.idsor
LEFT OUTER JOIN sortingkind
	ON sorting.idsorkind = sortingkind.idsorkind
LEFT OUTER JOIN sorting c2
	ON A.idsorreg = c2.idsor
LEFT OUTER JOIN sortingkind t2
	ON c2.idsorkind = t2.idsorkind
LEFT OUTER JOIN fin
	ON fin.idfin = A.idfin
	AND fin.ayear = A.ayear
LEFT OUTER JOIN upb
	ON upb.idupb = A.idupb
LEFT OUTER JOIN manager
	ON A.idman = manager.idman


GO

print 'autoincomesortingview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'totmandateview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW totmandateview
GO


CREATE                                                 VIEW [totmandateview]
(
	idmankind,
	yman,
	nman,
	taxabletotal,
	ivatotal
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
-- Modifica Rusciano Giuseppe
-- Aggiunto il comando CONVERT davanti ai campi FLOAT per non perdere informazione in fase di
-- prodotto. La perdita causa un errato arotondamento
-- Il controllo non dovrebbe più servire se si cambia il tipo di campo a decimal(19,6) da float
	ISNULL(CONVERT(decimal(19,2),
		SUM(
		    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
			  CONVERT(decimal(19,6),mandate.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2
			 )
		   )
		),0),
	ISNULL(
		CONVERT(decimal(19,2),
			SUM(
				ROUND(mandatedetail.tax ,2)
			)
		)
	,0)
/*
	ISNULL(
		CONVERT(decimal(19,2),
			SUM(
				ROUND(mandatedetail.taxable * mandatedetail.number *
					CONVERT(decimal(19,6),ISNULL(mandatedetail.taxrate, 0.0)) *   
					CONVERT(decimal(19,6),mandate.exchangerate) *
					(1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0)))
				,2)
			)
		)
	,0)
*/
-- Fine Modifica
	FROM mandatedetail (NOLOCK)
	JOIN mandate (NOLOCK)
  	ON mandatedetail.idmankind = mandate.idmankind
	AND mandatedetail.yman = mandate.yman
  	AND mandatedetail.nman = mandate.nman
	WHERE mandatedetail.stop is null
	GROUP BY mandatedetail.idmankind, mandatedetail.yman, mandatedetail.nman





GO

print '[totmandateview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paymentcommunicated') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paymentcommunicated
GO


CREATE                VIEW [paymentcommunicated]
(
	idexp,
	nphase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpay,
	ypay,
	npay,
	kpaymenttransmission,
	ypaymenttransmission,
	npaymenttransmission,
	doc,
	docdate,
	description,
	amount,
	curramount,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	iddeputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	printdate,
	competencydate,
	cu,
	ct,
	lu,
	lt,idfin,idupb
)
AS
SELECT
	expense.idexp,
	expense.nphase,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idreg,
	expense.idman,
	payment.kpay,
	payment.ypay,
	payment.npay,
	paymenttransmission.kpaymenttransmission,
	paymenttransmission.ypaymenttransmission,
	paymenttransmission.npaymenttransmission,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expensetotal.curramount,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.iddeputy,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END,
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	payment.printdate,
	paymenttransmission.transmissiondate,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt,
	expenseyear.idfin,expenseyear.idupb
FROM expense 
JOIN expenselast
	ON expenselast.idexp = expense.idexp
JOIN payment 
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND expense.ymov = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN service
	ON service.idser = expenselast.idexp
	

GO

print '[paymentcommunicated] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paymentemitted') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paymentemitted
GO


CREATE                VIEW [paymentemitted]
(
	idexp,
	nphase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	curramount,
	flag,
	totflag,
	flagarrear,
	idpaymethod,
	cin,
	idbank,
	idcab,
	cc,
	iddeputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	autokind,
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt,
	idfin,idupb
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idreg,
	expense.idman,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expensetotal.curramount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expenselast.idpaymethod,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.iddeputy,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	payment.adate, 
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt,
	expenseyear.idfin,expenseyear.idupb
FROM expense
JOIN expenselast
	ON expenselast.idexp = expense.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND expense.ymov = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser





GO

print '[paymentemitted] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paymentlogview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paymentlogview
GO


CREATE               VIEW paymentlogview
(
	idexp,
	nphase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	autokind,
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idreg,
	expense.idman,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	CASE config.taxvaliditykind 
		WHEN 1 THEN payment.adate 
		WHEN 2 THEN payment.printdate
		WHEN 4 THEN ( SELECT MIN(banktransaction.transactiondate )
				FROM banktransaction
				WHERE banktransaction.kpay = expenselast.kpay)
		ELSE	paymenttransmission.transmissiondate
	END,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt
FROM expense
JOIN expenselast
	ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN config
ON config.ayear = expense.ymov
LEFT OUTER JOIN expense parentexpense
	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission =  payment.kpaymenttransmission 
LEFT OUTER JOIN expensetotal expensetotal_firstyear
		ON expensetotal_firstyear.idexp = expense.idexp
		AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
		AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser



GO

print 'paymentlogview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'divisionsortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW divisionsortingview
GO


CREATE              VIEW [divisionsortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	iddivision,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	divisionsorting.idsor,
	sorting.sortcode,
	sorting.description,
	divisionsorting.iddivision,
	divisionsorting.cu,
	divisionsorting.ct,
	divisionsorting.lu,
	divisionsorting.lt
FROM divisionsorting
JOIN sorting
	ON sorting.idsor = divisionsorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind


GO

print '[divisionsortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paymentperformed') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paymentperformed
GO



CREATE                VIEW [paymentperformed]
(
	idexp,
	nphase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	curramount,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	iddeputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt,
	idfin,idupb
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idreg,
	expense.idman,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	banktransaction.amount,
	banktransaction.amount,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.iddeputy,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		when (( expensetotal.flag & 1)=0) then 'C'
		when (( expensetotal.flag & 1)=1) then 'R'
	End,
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	banktransaction.transactiondate,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt,
	expenseyear.idfin,expenseyear.idupb
FROM expense
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND expense.ymov = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN banktransaction
	ON banktransaction.idexp = expense.idexp
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser


GO

print '[paymentperformed] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'entrydetailaccrualview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW entrydetailaccrualview
GO


CREATE                 VIEW entrydetailaccrualview
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
	competencystop
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
	ABS(ISNULL(entrydetail.amount,0))
	- 
	ISNULL((SELECT SUM(amount) 
	        FROM   entrydetailaccrual 
	        WHERE  yentrylinked  = entrydetail.yentry AND
	               nentrylinked  = entrydetail.nentry AND
	               ndetaillinked = entrydetail.ndetail),0),
CASE 
WHEN ISNULL(entrydetail.amount,0)>0 THEN 'P'
ELSE 'A'
END,
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
entrydetail.competencystop
FROM entrydetail
INNER JOIN entry
ON entrydetail.yentry = entry.yentry
AND entrydetail.nentry = entry.nentry
LEFT OUTER JOIN registry
ON entrydetail.idreg = registry.idreg
LEFT OUTER JOIN upb
ON entrydetail.idupb = upb.idupb
LEFT OUTER JOIN account
ON entrydetail.idacc = account.idacc
LEFT OUTER JOIN  accmotive
ON entrydetail.idaccmotive = accmotive.idaccmotive
LEFT OUTER JOIN entrydetailaccrual
ON   entrydetail.yentry = entrydetailaccrual.yentrylinked 
AND  entrydetail.nentry = entrydetailaccrual.nentrylinked 
AND  entrydetail.ndetail = entrydetailaccrual.ndetaillinked 
JOIN config 
ON   entrydetail.yentry = config.ayear
AND  (entrydetail.idacc  = config.idacc_accruedcost OR
      entrydetail.idacc  = config.idacc_accruedrevenue)
WHERE entry.identrykind = '2' -- tipo scrittura = rateo



GO

print 'entrydetailaccrualview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paymentprinted') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paymentprinted
GO


CREATE                VIEW [paymentprinted]
(
	idexp,
	nphase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	curramount,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	iddeputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt,
	idfin,idupb
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idreg,
	expense.idman,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expensetotal.curramount,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.iddeputy,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN (( expensetotal.flag & 1)=0) THEN 'C'
		WHEN (( expensetotal.flag & 1)=1) THEN 'R'
	END,
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	payment.printdate,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt,
	expenseyear.idfin,expenseyear.idupb
FROM expense
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay 
JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND expense.ymov = expenseyear.ayear
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser



GO

print '[paymentprinted] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'upbfinview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW upbfinview
GO



CREATE                              VIEW  [upbfinview]
(
	idupb,
	codeupb,
	title,
	paridupb,
	idunderwriter,
	idman,
	manager,
	printingorder,
	requested,
	granted,
	previousappropriation,
	previousassessment,
	expiration,
	assured,
	active,
	idfin,
	codefin,
	fin,
	finpart,
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

AS 
SELECT 
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.paridupb,
	upb.idunderwriter,
	upb.idman,
	manager.title,
	upb.printingorder,
	upb.requested,
	upb.granted,
	upb.previousappropriation,
	upb.previousassessment,
	upb.expiration,
	upb.assured,
	upb.active,
	fin.idfin,
	fin.codefin,
	fin.title,
	CASE 
		when ( fin.flag & 1=0) then 'E'
		when ( fin.flag & 1=1) then 'S'
	End,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	upb.cu, 
	upb.ct, 
	upb.lu, 
	upb.lt
FROM 	upb
JOIN finyear
	on upb.idupb=finyear.idupb
JOIN fin 
	on fin.idfin = finyear.idfin
LEFT OUTER JOIN manager
	ON manager.idman = upb.idman





GO

print '[upbfinview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'allfinlookup') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW allfinlookup
GO


CREATE                 VIEW allfinlookup
(
	oldidfin,
	ayear,
	newidfin
)
AS
select idfin,F.ayear,idfin from fin F 
UNION ALL
select idfin,F.ayear+1,K1.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
UNION ALL
select idfin,F.ayear+2,K2.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
UNION ALL
select idfin,F.ayear+3,K3.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
UNION ALL
select idfin,F.ayear+4,K4.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
UNION ALL
select idfin,F.ayear+5,K5.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
UNION ALL
select idfin,F.ayear+6,K6.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
	join finlookup K6 on K6.oldidfin= K5.newidfin
UNION ALL
select idfin,F.ayear+7,K7.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
	join finlookup K6 on K6.oldidfin= K5.newidfin
	join finlookup K7 on K7.oldidfin= K6.newidfin
UNION ALL
select idfin,F.ayear+8,K8.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
	join finlookup K6 on K6.oldidfin= K5.newidfin
	join finlookup K7 on K7.oldidfin= K6.newidfin
	join finlookup K8 on K8.oldidfin= K7.newidfin
UNION ALL
select idfin,F.ayear+9,K9.newidfin from fin F 
	join finlookup K1 on K1.oldidfin= F.idfin
	join finlookup K2 on K2.oldidfin= K1.newidfin
	join finlookup K3 on K3.oldidfin= K2.newidfin
	join finlookup K4 on K4.oldidfin= K3.newidfin
	join finlookup K5 on K5.oldidfin= K4.newidfin
	join finlookup K6 on K6.oldidfin= K5.newidfin
	join finlookup K7 on K7.oldidfin= K6.newidfin
	join finlookup K8 on K8.oldidfin= K7.newidfin
	join finlookup K9 on K9.oldidfin= K8.newidfin


GO

print 'allfinlookup OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paymentsupposed') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paymentsupposed
GO

CREATE               VIEW [paymentsupposed]
(
	ayear,
	idexp,
	nphase,
	description,
	ymov,
	nmov,
	curramount,
	available,
	adate,
	expiration,
	kpay,
	ypay,
	npay,
	paymentadate,
	ypaymenttransmission,
	npaymenttransmission,
	transmissiondate
)
AS
-- Pagamenti trasmessi
	SELECT 
	i1.ayear,
	s1.idexp,
	s1.nphase,
	f1.description,
	s1.ymov,
	s1.nmov,
	i1.curramount,
	NULL,
	s1.adate,
	s1.expiration,
	d1.kpay,
	d1.ypay,
	d1.npay,
	d1.adate,
	t1.ypaymenttransmission,
	t1.npaymenttransmission,
	t1.transmissiondate
	FROM expense s1
	JOIN expenselast l1
	ON l1.idexp = s1.idexp
	JOIN expensetotal i1
	ON s1.idexp = i1.idexp
	JOIN expenseyear i2
	ON i1.idexp = i2.idexp
	AND i1.ayear = i2.ayear
	LEFT OUTER JOIN payment d1
	ON l1.kpay = d1.kpay
	LEFT OUTER JOIN paymenttransmission t1
	ON d1.kpaymenttransmission = t1.kpaymenttransmission
	JOIN expensephase f1
	ON f1.nphase = s1.nphase
	WHERE f1.nphase = (SELECT MAX(nphase) FROM expensephase)
	UNION
	SELECT
	i1.ayear,
	s1.idexp,
	s1.nphase,
	f1.description,
	s1.ymov,
	s1.nmov,
	NULL,
	i1.available,
	s1.adate,
	s1.expiration,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL
	FROM expense s1
	JOIN expensetotal i1
	ON s1.idexp = i1.idexp
	JOIN expenseyear i2
	ON i1.idexp = i2.idexp
	AND i1.ayear = i2.ayear
	JOIN expensephase f1
	ON f1.nphase = s1.nphase
	WHERE i1.available <> 0
	AND f1.nphase >= (SELECT appropriationphasecode FROM config WHERE ayear = i2.ayear)
	AND f1.nphase < (SELECT MAX(nphase) FROM expensephase)

GO

print '[paymentsupposed] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'upbview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW upbview
GO



CREATE   VIEW [upbview]
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
	upb.cu, 
	upb.ct, 
	upb.lu, 
	upb.lt
FROM 	upb with (nolock)
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = upb.idman
LEFT OUTER JOIN underwriter with (nolock)
	ON underwriter.idunderwriter = upb.idunderwriter
	


GO

print '[upbview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatedetailnoddttoinvoice') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatedetailnoddttoinvoice
GO

/* usato per prendere merce non preceduta da DDT */
/* Calcola il residuo come ordinato - (fatturato + in bolla non fatturato)  */
/* va bene anche per merce non di magazzino */
CREATE  VIEW [mandatedetailnoddttoinvoice]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mandatekind,
	idcurrency,
	codecurrency,
	idman,
	flagintracom,
	codeinv,
	inventorytree,
	idreg,
	registry,
	detaildescription,
	ordered,
	residual,
	taxrate,
	taxable,
	tax,
	discount,
	npackage,
	unitsforpackage,
	idunit,
	idpackage,
	number,
	assetkind,
	start,
	stop,
	idupb,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	competencystart,
	competencystop,
	toinvoice,
	linktoinvoice,
	linktoasset,
	multireg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	va3type,
	flagto_unload,
	idstore,
	store,
	idlist,
	list,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	epkind
)
AS SELECT 	
	mandatedetail.idmankind,
	mandatedetail.yman, 
	mandatedetail.nman, 
	mandatedetail.rownum, 
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.idcurrency,
	currency.codecurrency,
	mandate.idman,
	mandate.flagintracom,
	inventorytree.codeinv, 
	inventorytree.description,
	isnull(mandate.idreg,mandatedetail.idreg),
	CASE
		WHEN (mandate.idreg is not null) THEN (select title from
						registry 
						where idreg= mandate.idreg)
		WHEN (mandatedetail.idreg is not null) THEN (select title from
						registry 
						where idreg= mandatedetail.idreg)
		ELSE null
	END,
	mandatedetail.detaildescription, 
	ISNULL(mandatedetail.npackage,mandatedetail.number),	-- ordered
    ISNULL(mandatedetail.npackage, mandatedetail.number) -
	ISNULL(
	(SELECT SUM(iv.number)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  invoicedetail.idgroup as invidgroup,
				      invoicedetail.number,invoicedetail.idmankind,invoicedetail.yman,
				      invoicedetail.nman, mandatedetail.idgroup as manidgroup
		FROM invoicedetail 
        JOIN mandatedetail mandatedetail2
		  ON invoicedetail.idmankind = mandatedetail2.idmankind AND
		     invoicedetail.yman = mandatedetail2.yman AND
	         invoicedetail.nman = mandatedetail2.nman AND
		     invoicedetail.manrownum = mandatedetail2.rownum 
		    WHERE  invoicedetail.idmankind = mandatedetail.idmankind AND
	               invoicedetail.yman = mandatedetail.yman AND
		           invoicedetail.nman = mandatedetail.nman AND
			       mandatedetail2.idgroup = mandatedetail.idgroup 
			) AS iv )  ,0)
	- isnull((select sum(S.number/L.unitsforpackage) from stock S 
				JOIN list L on S.idlist=L.idlist				
				 where S.idmankind=mandatedetail.idmankind
				AND S.yman=mandatedetail.yman AND S.nman=mandatedetail.nman
				AND S.man_idgroup= mandatedetail.idgroup
				AND S.idinvkind is null
				),0), 	-- residual
	mandatedetail.taxrate,
	mandatedetail.taxable,
	mandatedetail.tax,
	mandatedetail.discount,
	mandatedetail.npackage,
	mandatedetail.unitsforpackage,
	mandatedetail.idunit,
	mandatedetail.idpackage,
	mandatedetail.number,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idupb,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.competencystart,
	mandatedetail.competencystop,
	mandatedetail.toinvoice,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.va3type,
	mandatedetail.flagto_unload,
	mandate.idstore,
	store.description,
	LIST.idlist,
	LIST.description ,
	COALESCE (mandate.idsor01,mandatekind.idsor01),
	COALESCE (mandate.idsor02,mandatekind.idsor02),
	COALESCE (mandate.idsor03,mandatekind.idsor03),
	COALESCE (mandate.idsor04,mandatekind.idsor04),
	COALESCE (mandate.idsor05,mandatekind.idsor05),
	mandatedetail.epkind
	
FROM mandatedetail 
JOIN mandatekind
	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN inventorytree ON inventorytree.idinv = mandatedetail.idinv
INNER JOIN mandate 
	ON mandate.idmankind = mandatedetail.idmankind
	AND mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
LEFT OUTER JOIN currency
	ON mandate.idcurrency = currency.idcurrency
JOIN ivakind
	ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus (NOLOCK)	
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN store 
	ON store.idstore = mandate.idstore
LEFT OUTER JOIN LIST
	ON mandatedetail.idlist = LIST.idlist
WHERE mandatedetail.stop is null


GO

print '[mandatedetailnoddttoinvoice] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'upbsortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW upbsortingview
GO



CREATE          VIEW [upbsortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	idupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	quota,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	upbsorting.idsor,
	sorting.sortcode, 
	sorting.description,
	upbsorting.idupb,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	upbsorting.quota,
	upbsorting.cu,
	upbsorting.ct,
	upbsorting.lu,
	upbsorting.lt
FROM upbsorting
JOIN sorting
	ON sorting.idsor = upbsorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN upb
	ON upb.idupb = upbsorting.idupb



GO

print '[upbsortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatedetailstockedtoinvoice') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatedetailstockedtoinvoice
GO



/* usato per prendere merce  preceduta da DDT */
/* Calcola il residuo in modo diverso in base al fatto che sia merce di magazzino oppureno
    se non di magazzino:
		= ordinato  - fatturato
	se di magazzino:
		= somma di quanto c'è in magazzino associato al dettaglio ordine ma non fatturato
	Attenzione: non deve prendere la merce di magazzino, quella sarà presa indicando direttamente 
	la bolla
  */
/* va bene anche per merce non di magazzino */

CREATE  VIEW [mandatedetailstockedtoinvoice]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mandatekind,
	idcurrency,
	codecurrency,
	idman,
	flagintracom,
	codeinv,
	inventorytree,
	idreg,
	registry,
	detaildescription,
	ordered,
	ddt,
	residual,
	taxrate,
	taxable,
	tax,
	discount,
	npackage,
	number,
	assetkind,
	start,
	stop,
	idupb,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	competencystart,
	competencystop,
	toinvoice,
	linktoinvoice,
	linktoasset,
	multireg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	va3type,
	flagto_unload,
	idstore,
	store,
	idlist,
	list,
	idunit,
	idpackage,
	unitsforpackage,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	epkind
)
AS SELECT 	
	mandatedetail.idmankind,
	mandatedetail.yman, 
	mandatedetail.nman, 
	mandatedetail.rownum, 
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.idcurrency,
	currency.codecurrency,
	mandate.idman,
	mandate.flagintracom,
	inventorytree.codeinv, 
	inventorytree.description,
	isnull(mandate.idreg,mandatedetail.idreg),
	CASE
		WHEN (mandate.idreg is not null) THEN (select title from
						registry 
						where idreg= mandate.idreg)
		WHEN (mandatedetail.idreg is not null) THEN (select title from
						registry 
						where idreg= mandatedetail.idreg)
		ELSE null
	END,
	mandatedetail.detaildescription, 
	ISNULL(mandatedetail.npackage,mandatedetail.number),	-- ordered
	isnull((select sum(S.number) from stock S 
				where S.idmankind=mandatedetail.idmankind
				AND S.yman=mandatedetail.yman AND S.nman=mandatedetail.nman
				AND S.man_idgroup= mandatedetail.idgroup
				AND S.idddt_in is not null
				)
		,0)
	,     --ddt 
	case when mandatedetail.idlist is null then
		 ISNULL(mandatedetail.npackage, mandatedetail.number) 
	- ISNULL(
	(SELECT SUM(iv.number)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  invoicedetail.idgroup as invidgroup,
				      invoicedetail.number,invoicedetail.idmankind,invoicedetail.yman,
				      invoicedetail.nman, mandatedetail.idgroup as manidgroup
		FROM invoicedetail 
        JOIN mandatedetail mandatedetail2
		  ON invoicedetail.idmankind = mandatedetail2.idmankind AND
		     invoicedetail.yman = mandatedetail2.yman AND
	         invoicedetail.nman = mandatedetail2.nman AND
		     invoicedetail.manrownum = mandatedetail2.rownum 
		    WHERE  invoicedetail.idmankind = mandatedetail.idmankind AND
	               invoicedetail.yman = mandatedetail.yman AND
		           invoicedetail.nman = mandatedetail.nman AND
			       mandatedetail2.idgroup = mandatedetail.idgroup 
			) AS iv )  ,0)
	ELSE
   		isnull((select sum(S.number) from stock S 
				where S.idmankind=mandatedetail.idmankind
				AND S.yman=mandatedetail.yman AND S.nman=mandatedetail.nman
				AND S.man_idgroup= mandatedetail.idgroup
				AND S.idddt_in is not null
				AND S.idinvkind is null
				),0)
	END
,     --residual
	mandatedetail.taxrate,
	mandatedetail.taxable,
	mandatedetail.tax,
	mandatedetail.discount,
	mandatedetail.npackage,
	mandatedetail.number,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idupb,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.competencystart,
	mandatedetail.competencystop,
	mandatedetail.toinvoice,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.va3type,
	mandatedetail.flagto_unload,
	mandate.idstore,
	store.description  ,
	LIST.idlist,
	LIST.description,
	mandatedetail.idunit,
	mandatedetail.idpackage,
	mandatedetail.unitsforpackage,
	COALESCE (mandate.idsor01,mandatekind.idsor01),
	COALESCE (mandate.idsor02,mandatekind.idsor02),
	COALESCE (mandate.idsor03,mandatekind.idsor03),
	COALESCE (mandate.idsor04,mandatekind.idsor04),
	COALESCE (mandate.idsor05,mandatekind.idsor05),
	mandatedetail.epkind
FROM mandatedetail 
JOIN mandatekind
	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN LIST 
	ON mandatedetail.idlist= LIST.idlist
LEFT OUTER JOIN inventorytree ON inventorytree.idinv = mandatedetail.idinv
INNER JOIN mandate 
	ON mandate.idmankind = mandatedetail.idmankind
	AND mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
LEFT OUTER JOIN currency
	ON mandate.idcurrency = currency.idcurrency
JOIN ivakind
	ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus (NOLOCK)	
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN store 
	ON store.idstore = mandate.idstore
WHERE mandatedetail.stop is null	
		AND mandatedetail.idlist is null


GO

print '[mandatedetailstockedtoinvoice] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'payment_bankview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW payment_bankview
GO


CREATE               VIEW payment_bankview
(
	kpay,
	ypay,
	npay,
	idpay,
	idreg,
	registry,
	description,
	amount,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	payment.kpay,
	payment.ypay,
	payment.npay,
	PB.idpay,
	PB.idreg,
	R.title,
	PB.description,
	PB.amount,
	PB.ct,
	PB.cu,
	PB.lt,
	PB.lu
FROM payment_bank PB
JOIN payment
	ON PB.kpay = payment.kpay
JOIN registry R
	ON R.idreg = PB.idreg




GO

print 'payment_bankview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mainivapayexpenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mainivapayexpenseview
GO


CREATE    VIEW [mainivapayexpenseview]
(
	ymainivapay,
	nmainivapay,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	netamount,
	totalamount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	mainivapayexpense.ymainivapay,
	mainivapayexpense.nmainivapay,
	mainivapayexpense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	ISNULL(expenseyear_starting.amount,0)- ISNULL((SELECT SUM(employtax) from expensetax
				where idexp = expense.idexp ),0),
	ISNULL(expenseyear_starting.amount,0)+ ISNULL((SELECT SUM(admintax) from expensetax
				where idexp = expense.idexp ),0),
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
  	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	mainivapayexpense.cu,
	mainivapayexpense.ct,
	mainivapayexpense.lu,
	mainivapayexpense.lt
FROM mainivapayexpense 
JOIN expense  
	ON expense.idexp = mainivapayexpense.idexp
JOIN expensephase 
	ON expensephase.nphase = expense.nphase
JOIN expenseyear 
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal 
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN fin 
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb 
	ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry 
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager 
	ON manager.idman = expense.idman
LEFT OUTER JOIN expenselast  
	ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN payment  
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN service 
	ON service.idser = expenselast.idser
LEFT OUTER JOIN expense parentexpense 
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting 
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear


GO

print '[mainivapayexpenseview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'pettycashexpenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW pettycashexpenseview
GO

CREATE                VIEW pettycashexpenseview 
(
	yoperation,
	noperation,
	idpettycash,
	pettycode,
	pettycash,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	autokind,
	idpayment,
	totflag,
	flagarrear,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	pettycashexpense.yoperation,
	pettycashexpense.noperation,
	pettycashexpense.idpettycash,
	pettycash.pettycode,
	pettycash.description,
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expense.autokind,
	expense.idpayment,
	expensetotal.flag,
	CASE
		when ((expensetotal.flag & 1)=0) then 'C'
		when ((expensetotal.flag & 1)=1) then 'R'
	End,
	expense.expiration,
	expense.adate,
	pettycashexpense.cu,
	pettycashexpense.ct,
	pettycashexpense.lu,
	pettycashexpense.lt
FROM pettycashexpense
JOIN pettycash
	ON pettycash.idpettycash = pettycashexpense.idpettycash
JOIN expense
	ON pettycashexpense.idexp = expense.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN expenselast
	ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp =expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear =expensetotal_firstyear.ayear
LEFT OUTER JOIN fin 
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN registry 
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager 
	ON manager.idman = expense.idman
LEFT OUTER JOIN service 
	ON service.idser = expenselast.idser
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear.idupb



GO

print 'pettycashexpenseview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mainivapayincomeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mainivapayincomeview
GO



CREATE    VIEW [mainivapayincomeview]
	(
	ymainivapay,
	nmainivapay,
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	unpartitioned,
	flag,
	totflag,
	flagarrear,
  	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
	)
	AS SELECT
	mainivapayincome.ymainivapay,
	mainivapayincome.nmainivapay,
	mainivapayincome.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	--income.ycreation,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	incomeyear.idupb,
	upb.codeupb,
	upb.title,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	--income.ypro,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	--income.amount,
	incomeyear_starting.amount,
	--incometotal.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	ISNULL(incometotal.curramount,0)-ISNULL(incometotal.partitioned,0),
	--income.fulfilled,
	incomelast.flag,
	incometotal.flag,
	--incomeyear.flagarrear,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	mainivapayincome.cu,
	mainivapayincome.ct,
	mainivapayincome.lu,
	mainivapayincome.lt
	FROM mainivapayincome (NOLOCK)
	JOIN income (NOLOCK)
		ON income.idinc = mainivapayincome.idinc
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)
		ON incomeyear.idinc = income.idinc
	JOIN incometotal (NOLOCK)
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN fin (NOLOCK)
		ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)
		ON upb.idupb = incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)
		ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)
		ON manager.idman = income.idman
	LEFT OUTER JOIN incomelast  (NOLOCK)
		ON income.idinc = incomelast.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON proceeds.kpro = incomelast.kpro
	LEFT OUTER JOIN income parentincome (NOLOCK)
		ON income.parentidinc = parentincome.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
	  	ON incometotal_firstyear.idinc = income.idinc
	  	AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
	  	AND incomeyear_starting.ayear = incometotal_firstyear.ayear


GO

print '[mainivapayincomeview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'pettycashincomeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW pettycashincomeview
GO



CREATE                VIEW pettycashincomeview 
(
	yoperation,
	noperation,
	idpettycash,
	pettycode,
	pettycash,
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	flag,
	idpayment,
	totflag,
	flagarrear,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	pettycashincome.yoperation,
	pettycashincome.noperation,
	pettycashincome.idpettycash,
	pettycash.pettycode,
	pettycash.description,
	income.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	incomeyear.idupb,
	upb.codeupb,
	upb.title,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	incomelast.flag, 
	income.idpayment,
	incometotal.flag,
	CASE
		when ((incometotal.flag & 1)=0) then 'C'
		when ((incometotal.flag & 1)=1) then 'R'
	End,
	income.expiration,
	income.adate,
	pettycashincome.cu,
	pettycashincome.ct,
	pettycashincome.lu,
	pettycashincome.lt
FROM pettycashincome
JOIN pettycash
	ON pettycash.idpettycash = pettycashincome.idpettycash
JOIN income
	ON pettycashincome.idinc = income.idinc
JOIN incomephase
	ON incomephase.nphase = income.nphase
JOIN incomeyear
	ON incomeyear.idinc = income.idinc
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
LEFT OUTER JOIN income parentincome
	ON parentincome.idinc = income.parentidinc
LEFT OUTER JOIN incomelast
	ON income.idinc = incomelast.idinc
LEFT OUTER JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
LEFT OUTER JOIN incometotal incometotal_firstyear
	ON incometotal_firstyear.idinc = income.idinc
	AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting
	ON incomeyear_starting.idinc =incometotal_firstyear.idinc
	AND incomeyear_starting.ayear =incometotal_firstyear.ayear
LEFT OUTER JOIN fin
	ON fin.idfin = incomeyear.idfin
LEFT OUTER JOIN registry
	ON registry.idreg = income.idreg
LEFT OUTER JOIN manager
	ON manager.idman = income.idman
LEFT OUTER JOIN upb
	ON upb.idupb = incomeyear.idupb



GO

print 'pettycashincomeview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'maintenanceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW maintenanceview
GO



CREATE                VIEW maintenanceview
(
	nmaintenance,
	idasset,
	idpiece,
	idmaintenancekind,
	codemaintenancekind,
	maintenancekind,
	idinventory,
	inventory,
	ninventory,
	loaddescription,
	description,
	amount,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	maintenance.nmaintenance,
	maintenance.idasset,
	maintenance.idpiece,-- <-
	maintenance.idmaintenancekind,
	maintenancekind.codemaintenancekind,
	maintenancekind.description,
	assetacquire.idinventory, 
	inventory.description,
	assetmain.ninventory, -- <- sa
	assetacquire.description,
	maintenance.description,
	maintenance.amount,
	maintenance.adate,
	maintenance.cu,
	maintenance.ct,
	maintenance.lu,
	maintenance.lt
FROM maintenance
JOIN asset
	ON asset.idasset = maintenance.idasset 
	and asset.idpiece = maintenance.idpiece
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN maintenancekind
	ON maintenancekind.idmaintenancekind = maintenance.idmaintenancekind
JOIN asset AS assetmain
ON (asset.idasset=assetmain.idasset)
WHERE (assetmain.idpiece = 1)




GO

print 'maintenanceview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'entrydetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW entrydetailview
GO




CREATE    VIEW entrydetailview
(
	yentry,
	nentry,
	ndetail,
	idacc,
	idreg,
	idupb,
	amount,
	give,
	have,
	idsor1,
	idsor2,
	idsor3,
	cu,
	ct,
	lu,
	lt,
	codeupb,
	codeacc,
	account,
	registry, 
	upb,
	idaccountkind,
	flagregistry,
	flagupb, 
	idplaccount,
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
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
entrydetail.yentry,
entrydetail.nentry,
entrydetail.ndetail,
entrydetail.idacc,
entrydetail.idreg,
entrydetail.idupb,
entrydetail.amount,
CASE
	WHEN ISNULL(amount,0) < 0 THEN -amount
	ELSE NULL
END,
CASE
	WHEN ISNULL(amount,0) >= 0 THEN amount
	ELSE NULL
END,
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
account.idplaccount,
entry.idrelated,
entry.description,
entry.adate,
entry.doc,
entry.docdate,
entrydetail.idaccmotive,
accmotive.title,
accmotive.codemotive,
entry.identrykind,
entrydetail.competencystart,
entrydetail.competencystop,
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05
FROM entrydetail
INNER JOIN entry
ON entrydetail.yentry = entry.yentry
AND entrydetail.nentry = entry.nentry
LEFT OUTER JOIN registry
ON entrydetail.idreg = registry.idreg
LEFT OUTER JOIN upb
ON entrydetail.idupb = upb.idupb
LEFT OUTER JOIN account
ON entrydetail.idacc = account.idacc
LEFT OUTER JOIN  accmotive
ON entrydetail.idaccmotive = accmotive.idaccmotive


GO

print 'entrydetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'totestimatedetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW totestimatedetailview
GO

CREATE                             VIEW [totestimatedetailview]
(
	idestimkind,
	yestim,
	nestim,
	taxabletotal,
	ivatotal
)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
-- Aggiunto il comando CONVERT davanti ai campi FLOAT per non perdere informazione in fase di
-- prodotto. La perdita causa un errato arrotondamento
-- Il controllo non dovrebbe più servire se si cambia il tipo di campo a decimal(19,6) da float
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN estimatedetail.idinc_taxable IS NOT NULL THEN
			    ROUND(estimatedetail.taxable * estimatedetail.number * 
				  CONVERT(decimal(19,6),estimate.exchangerate) *
				  (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2
				)
			ELSE
			   0
		    END
			
		   ),0)
		),
	   CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		 CASE
		 WHEN estimatedetail.idinc_iva IS NOT NULL THEN
			ROUND(estimatedetail.tax ,2)
		  ELSE 0
		END
		),0)
	   )
-- Fine Modifica
	FROM estimatedetail (NOLOCK)
	JOIN estimate (NOLOCK)
  	ON estimatedetail.idestimkind = estimate.idestimkind
	AND estimatedetail.yestim = estimate.yestim
  	AND estimatedetail.nestim = estimate.nestim
	WHERE estimatedetail.stop is null
	GROUP BY estimatedetail.idestimkind, estimatedetail.yestim, estimatedetail.nestim



GO

print '[totestimatedetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'wageadditionavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW wageadditionavailable
GO

CREATE                                          VIEW [wageadditionavailable]
	(
	ycon,
	ncon,
	idreg,
	registry,
	description,
	start,
	stop,
	feegross,
	linkedtotal,
	residual,
	idupb,
	coudeupb,
	upb,
	completed,
	idsor01,idsor02,idsor03,idsor04,idsor05
	)
	AS SELECT
	wageaddition.ycon,
	wageaddition.ncon,
	wageaddition.idreg,
	registry.title,
	wageaddition.description,
	wageaddition.start,
	wageaddition.stop,
	wageaddition.feegross,
-- Calcolo TOTALEMOVIMENTI
	CONVERT(decimal(19,2),
		ROUND(
			(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
			FROM expensewageaddition mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = wageaddition.ycon
				AND mov.ncon = wageaddition.ncon
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				) 
			+
			(SELECT ISNULL(SUM(v.amount), 0.0)
			FROM expensewageaddition mov
			JOIN expense s
				ON s.idexp = mov.idexp
			JOIN expensevar v
				ON v.idexp = mov.idexp
			WHERE mov.ycon = wageaddition.ycon
				AND mov.ncon = wageaddition.ncon
				AND (ISNULL(v.autokind,0)<> 4)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
		,2)
	),	
-- RESIDUO = costototale - totalemovimenti
	CONVERT(decimal(19,2),
		ROUND(
			wageaddition.feegross - 
			(
				(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
				FROM expensewageaddition mov
				JOIN expense s
					ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
				LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
				WHERE mov.ycon = wageaddition.ycon
					AND mov.ncon = wageaddition.ncon
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					) 
				+
				(SELECT ISNULL(SUM(v.amount), 0.0)
				FROM expensewageaddition mov
				JOIN expense s
					ON s.idexp = mov.idexp
				JOIN expensevar v
					ON v.idexp = mov.idexp
				WHERE mov.ycon = wageaddition.ycon
					AND mov.ncon = wageaddition.ncon
					AND (ISNULL(v.autokind,0)<> 4)
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					)
			)
		,2)
	),
	wageaddition.idupb,
	upb.codeupb,
	upb.title,
	wageaddition.completed,
	wageaddition.idsor01,wageaddition.idsor02,wageaddition.idsor03,wageaddition.idsor04,wageaddition.idsor05
	FROM wageaddition (NOLOCK)
	JOIN registry (NOLOCK)
		ON registry.idreg = wageaddition.idreg
	LEFT OUTER JOIN upb 	 (NOLOCK)
		ON upb.idupb = wageaddition.idupb
	WHERE wageaddition.feegross >
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
	FROM expensewageaddition mov
	JOIN expense s
		ON s.idexp = mov.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
		ON expensetotal_firstyear.idexp = s.idexp
		AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
		ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
		AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	WHERE mov.ycon = wageaddition.ycon
		AND mov.ncon = wageaddition.ncon
		--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
	) +
	(SELECT ISNULL(SUM(v.amount), 0.0)
	FROM expensewageaddition mov
	JOIN expense s
			ON s.idexp = mov.idexp
	JOIN expensevar v
		ON v.idexp = mov.idexp
	WHERE mov.ycon = wageaddition.ycon
		AND mov.ncon = wageaddition.ncon
		AND (v.autokind<>4)
		--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
	)

GO

print '[wageadditionavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceedscommunicated') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceedscommunicated
GO



CREATE                VIEW [proceedscommunicated]
(
	idinc,
	nphase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpro,
	ypro,
	npro,
	kproceedstransmission,
	yproceedstransmission,
	nproceedstransmission,
	doc,
	docdate,
	description,
	amount,
	curramount,
	totflag,
	flagarrear,
	flag,	
	autokind,
	idpayment,
	expiration,
	adate,
	printdate,
	competencydate,
	cu,
	ct,
	lu,
	lt,idfin,idupb
)
AS SELECT
	income.idinc,
	income.nphase,
	income.ymov,
	income.nmov,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	income.idreg,
	income.idman,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro, 
	proceedstransmission.kproceedstransmission,
	proceedstransmission.yproceedstransmission,
	proceedstransmission.nproceedstransmission,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount,
	incometotal.curramount,
	incometotal.flag, 
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 	
	incomelast.flag,
	income.autokind,
	income.idpayment,
	income.expiration,
	income.adate,
	proceeds.printdate,
	proceedstransmission.transmissiondate,
	income.cu,
	income.ct,
	income.lu,
	income.lt,
	incomeyear.idfin,
	incomeyear.idupb
FROM income
JOIN incomelast
	ON incomelast.idinc = income.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN proceedstransmission
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND income.ymov = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
LEFT OUTER JOIN income parentincome
	ON income.parentidinc = parentincome.idinc
LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
	ON incometotal_firstyear.idinc = income.idinc
	AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
	AND incomeyear_starting.ayear = incometotal_firstyear.ayear



GO

print '[proceedscommunicated] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'totestimateview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW totestimateview
GO

CREATE                                 VIEW [totestimateview]
(
	idestimkind,
	yestim,
	nestim,
	taxabletotal,
	ivatotal
)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
-- Aggiunto il comando CONVERT davanti ai campi FLOAT per non perdere informazione in fase di
-- prodotto. La perdita causa un errato arotondamento
-- Il controllo non dovrebbe più servire se si cambia il tipo di campo a decimal(19,6) da float
	ISNULL(CONVERT(decimal(19,2),
		SUM(
		    ROUND(estimatedetail.taxable * estimatedetail.number * 
			  CONVERT(decimal(19,6),estimate.exchangerate) *
			  (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2
			 )
		   )
		),0),
	ISNULL(
		CONVERT(decimal(19,2),
			SUM(
				ROUND(estimatedetail.tax ,2)
			)
		)
	,0)
	FROM estimatedetail (NOLOCK)
	JOIN estimate (NOLOCK)
  	ON estimatedetail.idestimkind = estimate.idestimkind
	AND estimatedetail.yestim = estimate.yestim
  	AND estimatedetail.nestim = estimate.nestim
	WHERE estimatedetail.stop is null
	GROUP BY estimatedetail.idestimkind, estimatedetail.yestim, estimatedetail.nestim



GO

print '[totestimateview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'wageadditionlinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW wageadditionlinked
GO



CREATE   VIEW [wageadditionlinked]
(
	ayear,
	ycon,
	ncon,
	idreg,
	registry,
	idser,
	service,
	codeser,
	feegross,
	adate,
	stop,
	start,
	description,
	ndays,
	txt,
	rtf,
	idaccmotive,
	idsor1,
	idsor2,
	idsor3,
	idupb,
	completed,
	ct,
	cu,
	lt,
	lu,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	expenseyear.ayear,
	wageaddition.ycon,
	wageaddition.ncon,
	wageaddition.idreg,
	registry.title,
	wageaddition.idser,
	service.description,
	service.codeser,
	wageaddition.feegross,
	wageaddition.adate,
	wageaddition.stop,
	wageaddition.start,
	wageaddition.description,
	wageaddition.ndays,
	wageaddition.txt,
	wageaddition.rtf,
	wageaddition.idaccmotive,
	wageaddition.idsor1,
	wageaddition.idsor2,
	wageaddition.idsor3,
	wageaddition.idupb,
	wageaddition.completed,
	wageaddition.ct,
	wageaddition.cu,
	wageaddition.lt,
	wageaddition.lu,
	wageaddition.idsor01,wageaddition.idsor02,wageaddition.idsor03,wageaddition.idsor04,wageaddition.idsor05
FROM wageaddition with (nolock)
JOIN service with (nolock)
	ON wageaddition.idser = service.idser
JOIN registry with (nolock)
	ON wageaddition.idreg = registry.idreg
JOIN expensewageaddition with (nolock)
	ON expensewageaddition.ycon = wageaddition.ycon
	AND expensewageaddition.ncon = wageaddition.ncon
JOIN expenseyear with (nolock)
	ON expenseyear.idexp = expensewageaddition.idexp 
WHERE EXISTS
	(SELECT * FROM expensewageaddition
	WHERE expensewageaddition.ycon = wageaddition.ycon
	AND expensewageaddition.ncon = wageaddition.ncon)



GO

print '[wageadditionlinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimatesortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimatesortingview
GO

-- SELECT * FROM estimatesortingview
CREATE VIEW [estimatesortingview](
	idestimkind,
	mankind,
	yestim,
	nestim,
	quota,
	idsor,
	sortingkind,
	sortcode,
	sorting,
	lt,lu,ct,cu
)
AS SELECT
	estimatesorting.idestimkind,
	estimatekind.description,
	estimatesorting.yestim,
	estimatesorting.nestim,
	estimatesorting.quota,
	estimatesorting.idsor,
	sortingkind.description ,
	sorting.sortcode,
	sorting.description,
	estimatesorting.lt,estimatesorting.lu,estimatesorting.ct,estimatesorting.cu
FROM estimatesorting
JOIN estimatekind 
	ON estimatekind.idestimkind = estimatesorting.idestimkind
join sorting
	on estimatesorting.idsor = sorting.idsor
join sortingkind
	on sortingkind.idsorkind = sorting.idsorkind

GO

print '[estimatesortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceedsemitted') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceedsemitted
GO



CREATE                VIEW [proceedsemitted]
(
	idinc,
	nphase,
	ymov,
	nmov,
	--ycreation,
	parentidinc,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	curramount,
	totflag,
	flagarrear,
	flag,
	autokind,
	--idproceeds,
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt,
	idfin,idupb
)
AS SELECT
	income.idinc,
	income.nphase,
	income.ymov,
	income.nmov,
	--income.ycreation,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	income.idreg,
	income.idman,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount, --income.amount,
	incometotal.curramount,
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	incomelast.flag,
	income.autokind,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	proceeds.adate, 
	income.cu,
	income.ct,
	income.lu,
	income.lt,
	incomeyear.idfin,
	incomeyear.idupb
FROM income
JOIN incomelast
	ON incomelast.idinc = income.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND income.ymov = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
LEFT OUTER JOIN income parentincome
	ON income.parentidinc = parentincome.idinc
LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
	ON incometotal_firstyear.idinc = income.idinc
	AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
	AND incomeyear_starting.ayear = incometotal_firstyear.ayear



GO

print '[proceedsemitted] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'lessexpenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW lessexpenseview
GO


--Pino Rana, elaborazione del 10/08/2005 15:17:44
CREATE                                      VIEW lessexpenseview
(
ayear,
idexp,
nphase,
phase,
expensedescription,
parentidexp,
parentymov,
parentnmov,
idformerexpense,
idchild,
ymov,
nmov,
doc,
docdate,
amount,
variationamount,
curramount,
available,
idreg,
registry,
--ycreation,
idfin,
codefin,
finance,
idupb,
codeupb,
upb,
idman,
manager
)
AS SELECT
expenseyear.ayear,
expense.idexp,
expense.nphase,
expensephase.description,
expense.description,
expense.parentidexp,
parentexpense.ymov,
parentexpense.nmov,
expense.idformerexpense,
s.idexp,
expense.ymov,
expense.nmov,
expense.doc,
expense.docdate,
expenseyear.amount,
expensevar.amount,
expensetotal.curramount,
expensetotal.available,
expense.idreg,
registry.title,
--expense.ycreation,
expenseyear.idfin,
fin.codefin,
fin.title,
expenseyear.idupb,
upb.codeupb,
upb.title,
expense.idman,
manager.title
FROM expense
JOIN expensephase
ON expense.nphase = expensephase.nphase
JOIN expenseyear
ON expense.idexp = expenseyear.idexp
JOIN expensetotal
ON expenseyear.idexp = expensetotal.idexp
AND expenseyear.ayear = expensetotal.ayear
LEFT OUTER JOIN registry
ON expense.idreg = registry.idreg
LEFT OUTER JOIN fin
ON expenseyear.idfin = fin.idfin
LEFT OUTER JOIN upb
ON expenseyear.idupb = upb.idupb
LEFT OUTER JOIN manager
ON manager.idman = expense.idman
LEFT OUTER JOIN expense parentexpense
ON expense.parentidexp = parentexpense.idexp
JOIN expensevar
ON expense.idexp = expensevar.idexp
AND expenseyear.ayear = expensevar.yvar
LEFT OUTER JOIN expense s
ON expense.idexp = s.idformerexpense
AND s.ymov = expensevar.yvar+1
WHERE expensevar.autokind = 9 --'ECONO'
--Select * from economiaspesaview




GO

print 'lessexpenseview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'wageadditionresidual') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW wageadditionresidual
GO


CREATE                                          VIEW [wageadditionresidual]
	(
	ycon,
	ncon,
	description,
	idreg,
	registry,
	start,
	stop,
	feegross,
	residual,
	linkedtotal,
	idsor01,idsor02,idsor03,idsor04,idsor05
	)
	AS SELECT
	wageaddition.ycon,
	wageaddition.ncon,
	wageaddition.description,
	wageaddition.idreg,
	registry.title,
	wageaddition.start,
	wageaddition.stop,
	wageaddition.feegross,
	CONVERT(decimal(23,6),
		wageaddition.feegross
		-
		(
			(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
			FROM expensewageaddition mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = wageaddition.ycon
				AND mov.ncon = wageaddition.ncon
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			) +
			(SELECT ISNULL(SUM(v.amount), 0.0)
			FROM expensewageaddition mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON (v.idexp = mov.idexp)
			WHERE mov.ycon = wageaddition.ycon 
			AND mov.ncon = wageaddition.ncon
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase =(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		)
	),
	CONVERT(decimal(23,6),
		(
			(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
			FROM expensewageaddition mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = wageaddition.ycon
			AND mov.ncon = wageaddition.ncon
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			) +
			(SELECT ISNULL(SUM(v.amount), 0.0)
			FROM expensewageaddition mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
			WHERE mov.ycon = wageaddition.ycon 
			AND mov.ncon = wageaddition.ncon
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = 	(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		)
	),
	wageaddition.idsor01,wageaddition.idsor02,wageaddition.idsor03,wageaddition.idsor04,wageaddition.idsor05
	FROM wageaddition (NOLOCK)
	JOIN registry (NOLOCK)
	ON registry.idreg = wageaddition.idreg





GO

print '[wageadditionresidual] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoicedetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoicedetailview
GO


CREATE  VIEW [invoicedetailview]
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	rownum,
	idgroup,
	detaildescription,
	idivakind,
	ivakind,
	rate,
	unabatabilitypercentage,
	number,
	taxable,
	discount,
	tax,
	unabatable,
	exchangerate,
	annotations,
	idmankind,
	mankind,
	yman,
	nman,
	manrownum,
	mandetaildescription,
	idestimkind,
	estimkind,
	yestim,
	nestim,
	estimrownum,
	estimatedetaildescription,
	idupb, 
	codeupb,	
	upb, 
	idupb_iva, 
	codeupb_iva,	
	upb_iva, 
	adate,
	idexp_iva,
	idexp_taxable,
	idexp_ivamand,
	idexp_taxablemand,
	idinc_iva,
	idinc_taxable,
	idinc_ivaestim,
	idinc_taxableestim,
	taxable_euro,
	iva_euro,
	unabatable_euro,
	rowtotal,
	competencystart,
	competencystop,
	paymentcompetency,
	yinv_main,
	ninv_main,
	description,
	idaccmotive,
	codemotive,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	idintrastatcode,
	code,
	intrastatcode,
	idintrastatmeasure,
	intrastatmeasure,
	weight,
	va3type,
	va3typedescription,
	servicecode,
	idintrastatservice ,
	intrastatservice, 
	intrastatoperationkind,
	supplymethodcode,
	idintrastatsupplymethod,
	intrastatsupplymethod,
	idlist,
	intcode,
	idunit,
	idpackage,
	unitsforpackage,
	npackage,
	flag_invoice,
	flag_invoicedetail,
	registry,
	exception12,
	intra12operationkind,
	move12,
	cu, 
	ct, 
	lu, 
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idinvkind_main
)
	AS SELECT
	invoicedetail.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoicedetail.yinv,
	invoicedetail.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoicedetail.rownum,
	invoicedetail.idgroup, 
	invoicedetail.detaildescription,
	invoicedetail.idivakind,
	ivakind.description,
	ivakind.rate,
	ivakind.unabatabilitypercentage,
	invoicedetail.number,
	invoicedetail.taxable,
	invoicedetail.discount,
	invoicedetail.tax,
	invoicedetail.unabatable,
	invoice.exchangerate,
	invoicedetail.annotations,
	invoicedetail.idmankind,
	mandatekind.description,
	invoicedetail.yman,
	invoicedetail.nman,
	invoicedetail.manrownum,
	mandatedetail.detaildescription,
	invoicedetail.idestimkind,
	estimatekind.description,
	invoicedetail.yestim,
	invoicedetail.nestim,
	invoicedetail.estimrownum,
	estimatedetail.detaildescription,
	invoicedetail.idupb, 
	upb.codeupb,	
	upb.title, 
	invoicedetail.idupb_iva, 
	upb_iva.codeupb,	
	upb_iva.title, 
	invoice.adate,
	invoicedetail.idexp_iva,
	invoicedetail.idexp_taxable,
	mandatedetail.idexp_iva,
	mandatedetail.idexp_taxable,
	invoicedetail.idinc_iva,
	invoicedetail.idinc_taxable,
	estimatedetail.idinc_iva,
	estimatedetail.idinc_taxable,
 	    CONVERT(decimal(19,2),
		ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		  CONVERT(DECIMAL(19,6),invoice.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(invoicedetail.discount, 0.0)))
		 ,2
		)),
	CONVERT(decimal(19,2),ROUND(invoicedetail.tax
				,2)
			),
	CONVERT(decimal(19,2), ROUND(invoicedetail.unabatable 
					
			       ,2)
			),
	CONVERT(decimal(19,2), ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
			  CONVERT(DECIMAL(19,6),ISNULL(invoice.exchangerate,1)) *
			  (1 - CONVERT(DECIMAL(19,6),ISNULL(invoicedetail.discount, 0.0))),2
		))+
	CONVERT(decimal(19,2),ROUND(ISNULL(invoicedetail.tax,0),2)),
	invoicedetail.competencystart,
	invoicedetail.competencystop,
	invoicedetail.paymentcompetency,
	invoicedetail.yinv_main,
	invoicedetail.ninv_main,
	invoice.description,
	invoicedetail.idaccmotive,
	accmotive.codemotive,
	invoicedetail.idsor1,
	invoicedetail.idsor2,
	invoicedetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	invoicedetail.idintrastatcode,
	intrastatcode.code,
	intrastatcode.description,
	invoicedetail.idintrastatmeasure,
	intrastatmeasure.description,
	invoicedetail.weight,
	invoicedetail.va3type,
        CASE invoicedetail.va3type
                WHEN 'S' THEN 'Beni ammortizzabili'
                WHEN 'N' THEN 'Beni strumentali non ammortizzabili'
                WHEN 'R' THEN 'Beni destinati alla rivendita ovvero alla produzione di beni e servizi'
                WHEN 'A' THEN ' Altri acquisti e importazioni'
        END,
intrastatservice.code,
intrastatservice.idintrastatservice ,
intrastatservice.description, 
invoicedetail.intrastatoperationkind,
intrastatsupplymethod.code,
intrastatsupplymethod.idintrastatsupplymethod,
intrastatsupplymethod.description,
invoicedetail.idlist,
list.intcode,
invoicedetail.idunit,
invoicedetail.idpackage,
invoicedetail.unitsforpackage,
invoicedetail.npackage,
invoice.flag,
invoicedetail.flag,
registry.title,
invoicedetail.exception12,
invoicedetail.intra12operationkind,
invoicedetail.move12,
invoicedetail.cu, 
invoicedetail.ct, 
invoicedetail.lu,
invoicedetail.lt,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05,
invoicedetail.idinvkind_main
FROM invoicedetail WITH (NOLOCK)	
JOIN ivakind WITH (NOLOCK)
	ON ivakind.idivakind = invoicedetail.idivakind
JOIN invoice WITH (NOLOCK)
	ON invoice.ninv = invoicedetail.ninv
	AND invoice.yinv = invoicedetail.yinv
	AND invoice.idinvkind = invoicedetail.idinvkind
JOIN invoicekind WITH (NOLOCK)
	ON invoicekind.idinvkind = invoicedetail.idinvkind
JOIN registry WITH (NOLOCK)
	ON registry.idreg = invoice.idreg
LEFT OUTER JOIN mandatedetail WITH (NOLOCK)
	ON invoicedetail.idmankind = mandatedetail.idmankind
	AND invoicedetail.yman = mandatedetail.yman
	AND invoicedetail.nman = mandatedetail.nman
	AND invoicedetail.manrownum = mandatedetail.rownum
LEFT OUTER JOIN mandatekind  WITH (NOLOCK)
	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN estimatedetail WITH (NOLOCK)
	ON invoicedetail.idestimkind = estimatedetail.idestimkind
	AND invoicedetail.yestim = estimatedetail.yestim
	AND invoicedetail.nestim = estimatedetail.nestim
	AND invoicedetail.estimrownum = estimatedetail.rownum
LEFT OUTER JOIN estimatekind  WITH (NOLOCK)
	ON estimatekind.idestimkind = estimatedetail.idestimkind
LEFT OUTER JOIN upb WITH (NOLOCK)
	ON upb.idupb = invoicedetail.idupb
LEFT OUTER JOIN upb upb_iva  WITH (NOLOCK)
	ON upb_iva.idupb = invoicedetail.idupb_iva
LEFT OUTER JOIN accmotive WITH (NOLOCK)
	ON accmotive.idaccmotive = invoicedetail.idaccmotive
LEFT OUTER JOIN sorting sorting1 WITH (NOLOCK)
	ON sorting1.idsor = invoicedetail.idsor1
LEFT OUTER JOIN sorting sorting2 WITH (NOLOCK)
	ON sorting2.idsor = invoicedetail.idsor2
LEFT OUTER JOIN sorting sorting3 WITH (NOLOCK)
	ON sorting3.idsor = invoicedetail.idsor3
LEFT OUTER JOIN intrastatcode WITH (NOLOCK)
	ON 	intrastatcode.idintrastatcode= invoicedetail.idintrastatcode
LEFT OUTER JOIN	intrastatmeasure WITH (NOLOCK)
	ON 	intrastatmeasure.idintrastatmeasure = invoicedetail.idintrastatmeasure
LEFT OUTER JOIN intrastatservice WITH (NOLOCK)
	ON invoicedetail.idintrastatservice=intrastatservice.idintrastatservice 
LEFT OUTER JOIN intrastatsupplymethod WITH (NOLOCK)
	ON invoicedetail.idintrastatsupplymethod = intrastatsupplymethod.idintrastatsupplymethod
LEFT OUTER JOIN list  WITH (NOLOCK)
	ON list.idlist = invoicedetail.idlist




GO

print '[invoicedetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceedslogview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceedslogview
GO

CREATE              VIEW proceedslogview
(
	idinc,
	nphase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	flag, 
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
  income.idinc,
  income.nphase,
  income.ymov,
  income.nmov,
  --income.ycreation,
  income.parentidinc,
 parentincome.ymov,
 parentincome.nmov,
  income.idreg,
  income.idman,
  proceeds.kpro,
  proceeds.ypro,
  proceeds.npro,
  income.doc,
  income.docdate,
  income.description,
 incomeyear_starting.amount,-- income.amount,
   incomelast.flag,--income.fulfilled, income.autokind,
  --- income.idproceeds,
  income.idpayment,
  income.expiration,
  income.adate,
	CASE config.cashvaliditykind  
		WHEN 1 THEN proceeds.adate 
		WHEN 2 THEN proceeds.printdate
		WHEN 4 THEN	( SELECT MIN(banktransaction.transactiondate)
				FROM banktransaction
				WHERE banktransaction.kpro=incomelast.kpro
				)
		ELSE proceedstransmission.transmissiondate --3
	END,
  income.cu,
  income.ct,
  income.lu,
  income.lt
FROM income
JOIN incomelast
	ON income.idinc = incomelast.idinc
LEFT OUTER JOIN config
	ON config.ayear = income.ymov
LEFT OUTER JOIN income parentincome (NOLOCK)
	ON parentincome.idinc = income.parentidinc
LEFT OUTER JOIN proceeds(NOLOCK) 
	ON proceeds.kpro = incomelast.kpro
LEFT OUTER JOIN proceedstransmission(NOLOCK) 
	ON proceedstransmission.kproceedstransmission =  proceeds.kproceedstransmission 
LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
		ON incometotal_firstyear.idinc = income.idinc
		AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
--WHERE income.nphase = (SELECT MAX(nphase) FROM incomephase)







GO

print 'proceedslogview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'underwritingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW underwritingview
GO


--clear_table_info'underwritingview'
CREATE   VIEW underwritingview 
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


GO

print 'underwritingview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceedsperformed') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceedsperformed
GO

CREATE               VIEW [proceedsperformed]
(
	idinc,
	nphase,
	ymov,
	nmov,
	--ycreation,
	parentidinc,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	curramount,
	flagarrear,
	totflag,
	flag, --fulfilled,autokind,
	--idproceeds,
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt,
	idfin,idupb
)
	AS SELECT DISTINCT
	income.idinc,
	income.nphase,
	income.ymov,
	income.nmov,
	--income.ycreation,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	income.idreg,
	income.idman,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	banktransaction.amount,
	banktransaction.amount,
 	CASE
		when (( incometotal.flag & 1)=0) then 'C'
		when (( incometotal.flag & 1)=1) then 'R'
	End,
	incometotal.flag,
	incomelast.flag, --income.fulfilled,income.autokind,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	banktransaction.transactiondate,
	income.cu,
	income.ct,
	income.lu,
	income.lt,
	incomeyear.idfin,incomeyear.idupb
	FROM income
	JOIN incomeyear
		ON income.idinc = incomeyear.idinc
		AND income.ymov = incomeyear.ayear
	JOIN incometotal
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	JOIN incomelast
		on income.idinc = incomelast.idinc
	JOIN proceeds
		ON incomelast.kpro = proceeds.kpro
	JOIN banktransaction
		ON banktransaction.idinc = income.idinc
	LEFT OUTER JOIN income parentincome 
		ON parentincome.idinc = income.parentidinc


GO

print '[proceedsperformed] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accountview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accountview
GO

CREATE   VIEW [accountview]
	(
		idacc,
		ayear,
		codeacc,
		paridacc,
		printingorder,
		title,
		flagtransitory,
		nlevel,
		leveldescr,
		idaccountkind,
		flagda,
		accountkinddescr,
		flagregistry,
		flagupb,
		idplaccount,
		codeplaccount,
		placcount,
		idpatrimony,
		codepatrimony,
		patrimony,
		flagcompetency,
		flagprofit,
		flagloss,
		placcount_sign,
		patrimony_sign,
		ignoreregistryonepilogue,
		ignoreupbonepilogue,
		flag_offbalance,
		flag,
		cu,
		ct,
		lu,
		lt
	)
	AS
	SELECT
		account.idacc,
		account.ayear,
		account.codeacc,
		account.paridacc,
		account.printingorder,
		account.title,
		account.flagtransitory,
		account.nlevel,
		accountlevel.description,
		account.idaccountkind,
		accountkind.flagda,
		accountkind.description,
		account.flagregistry,
		account.flagupb,
		placcount.idplaccount,
		placcount.codeplaccount,
		placcount.title,
		patrimony.idpatrimony,
		patrimony.codepatrimony,
		patrimony.title,
		account.flagcompetency,
		account.flagprofit,
		account.flagloss,
		account.placcount_sign,
		account.patrimony_sign,
		CASE
			when (( account.flag & 1) = 0)  then 'N'
			when (( account.flag & 1)<> 0)  then 'S'
		END,
		CASE
			when (( account.flag & 2) = 0)  then 'N'
			when (( account.flag & 2)<> 0)  then 'S'
		END,
		CASE
			when (( account.flag & 4) = 0)  then 'N'
			when (( account.flag & 4)<> 0)  then 'S'
		END,
		account.flag,
		account.cu,
		account.ct,
		account.lu,
		account.lt
		FROM account
		JOIN accountlevel
			ON account.nlevel = accountlevel.nlevel
			AND account.ayear = accountlevel.ayear
		LEFT OUTER JOIN accountkind
			ON accountkind.idaccountkind = account.idaccountkind
		LEFT OUTER JOIN patrimony
			ON account.idpatrimony=patrimony.idpatrimony
		LEFT OUTER JOIN placcount
			ON account.idplaccount = placcount.idplaccount



GO

print '[accountview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatesortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatesortingview
GO

-- SELECT * FROM mandatesortingview
CREATE VIEW [mandatesortingview](
	idmankind,
	mankind,
	yman,
	nman,
	quota,
	idsor,
	sortingkind,
	sortcode,
	sorting,
	lt,lu,ct,cu
)
AS SELECT
	mandatesorting.idmankind,
	mandatekind.description,
	mandatesorting.yman,
	mandatesorting.nman,
	mandatesorting.quota,
	mandatesorting.idsor,
	sortingkind.description ,
	sorting.sortcode,
	sorting.description,
	mandatesorting.lt,mandatesorting.lu,mandatesorting.ct,mandatesorting.cu
FROM mandatesorting
JOIN mandatekind 
	ON mandatekind.idmankind = mandatesorting.idmankind
join sorting
	on mandatesorting.idsor = sorting.idsor
join sortingkind
	on sortingkind.idsorkind = sorting.idsorkind


GO

print '[mandatesortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceedsprinted') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceedsprinted
GO


CREATE              VIEW [proceedsprinted]
(
	idinc,
	nphase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	idreg,
	idman,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	curramount,
	flagarrear,
	totflag,
	flag,
	idpayment,
	expiration,
	adate,
	competencydate,
	cu,
	ct,
	lu,
	lt,
	idfin,idupb
)
AS SELECT
	income.idinc,
	income.nphase,
	income.ymov,
	income.nmov,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	income.idreg,
	income.idman,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount,
	incometotal.curramount,
 	CASE
		when (( incometotal.flag & 1)=0) then 'C'
		when (( incometotal.flag & 1)=1) then 'R'
	End,
	incometotal.flag,
	incomelast.flag,
	income.idpayment,
	income.expiration,
	income.adate,
	proceeds.printdate,
	income.cu,
	income.ct,
	income.lu,
	income.lt,
	incomeyear.idfin,incomeyear.idupb
FROM income
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro 
JOIN incomeyear
	ON income.idinc = incomeyear.idinc
	AND income.ymov = incomeyear.ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
LEFT OUTER JOIN income parentincome
	ON parentincome.idinc = income.parentidinc
LEFT OUTER JOIN incometotal incometotal_firstyear
	ON incometotal_firstyear.idinc = income.idinc
	AND ((incometotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN incomeyear incomeyear_starting
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
	AND incomeyear_starting.ayear = incometotal_firstyear.ayear






GO

print '[proceedsprinted] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'entryview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW entryview
GO

--select * from entrykind
--select * from entry
--select * from entryview

CREATE    VIEW entryview
(
	yentry,
	nentry,
	adate,
	identrykind,
	entrykind,
	description,
	doc,
	docdate,
	locked,
	credit , 
	debit,
	idrelated,
	lt,lu,ct,cu
	
)
AS SELECT
e.yentry,
e.nentry,
e.adate,
e.identrykind,
	ek.description,
	e.description,
	e.doc,
	e.docdate,
	e.locked,
	-isnull( (SELECT SUM(amount) FROM entrydetail ed where  ed.yentry=e.yentry and ed.nentry=e.nentry and amount<0) ,0),
	isnull( (SELECT SUM(amount) FROM entrydetail ed where ed.yentry=e.yentry and ed.nentry=e.nentry and amount>0) , 0),
	e.idrelated,
	e.lt,e.lu,e.ct,e.cu
FROM  entry e
LEFT OUTER JOIN entrykind  ek with (nolock)  
	on e.identrykind=ek.identrykind

GO

print 'entryview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expenditurearrearssupposed') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expenditurearrearssupposed
GO


--Pino Rana, elaborazione del 10/08/2005 15:18:09
CREATE              VIEW [expenditurearrearssupposed]
(
	ayear,
	idexp,
	ymov,
	nmov,
	adate,
	residualamount,
	totflag,
	flagarrear,
	expiration
)
AS
-- Residui Passivi Presunti Anni Precedenti
SELECT DISTINCT 
	i1.ayear,s1.idexp,s1.ymov,s1.nmov,s1.adate,
	ISNULL(i2.curramount,0.0) - 
	ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense e3
	 	JOIN expensetotal i3
	 	ON e3.idexp = i3.idexp
		JOIN expenselast l1
	 	ON l1.idexp = e3.idexp
	 	JOIN expenselink el
	 	ON el.idparent = s1.idexp
	 	AND el.idchild = e3.idexp
		-- WHERE i3.idexp LIKE s1.idexp + '%'
		-- AND e3.nphase =
	 	-- (SELECT MAX(nphase) FROM expensephase)
	 	AND i3.ayear = i1.ayear),0.0)
	,i2.flag, 
	CASE
		WHEN ((i2.flag&1)=0) THEN 'C'
		WHEN ((i2.flag&1)=1) THEN 'R'
	END,
	s1.expiration
	FROM expense s1
	INNER JOIN expenseyear i1 
	ON s1.idexp = i1.idexp 
	INNER JOIN expensetotal i2
	ON i1.idexp = i2.idexp
	AND i1.ayear = i2.ayear
	INNER JOIN config p1
	ON p1.appropriationphasecode = s1.nphase
	AND p1.ayear = i1.ayear
	WHERE ((i2.flag&1)=1)  --'R'
	AND i2.curramount >
		ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense e3
	 		JOIN expensetotal i3
			 ON e3.idexp = i3.idexp
	 		JOIN expenselast l1
	 		ON l1.idexp = e3.idexp
			 JOIN expenselink el
	 		ON el.idparent = s1.idexp
	 		AND el.idchild = e3.idexp
	 	WHERE 
		--i3.idexp LIKE s1.idexp + '%'
		-- AND e3.nphase =
		--(SELECT MAX(nphase) FROM expensephase)
	  	i3.ayear = i1.ayear),0.0)
	AND s1.expiration IS NOT NULL
-- Residui Passivi Presunti Anno in corso
UNION
SELECT DISTINCT 
	i1.ayear,s1.idexp,s1.ymov,s1.nmov,s1.adate,
	ISNULL(i2.curramount,0.0) - 
	ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense e3
		 JOIN expensetotal i3
		 ON e3.idexp = i3.idexp
		  JOIN expenselast l1
		 ON l1.idexp = e3.idexp
		 JOIN expenselink el
		 ON el.idparent = s1.idexp
		 AND el.idchild = e3.idexp
		 WHERE 
			--i3.idexp LIKE s1.idexp + '%'
			-- AND e3.nphase =
			--(SELECT MAX(nphase) FROM expensephase)
		 	--AND 
		i3.ayear = i1.ayear),0.0)
	,i2.flag,
	CASE
		WHEN ((i2.flag&1)=0) THEN 'C'
		WHEN ((i2.flag&1)=1) THEN 'R'
	END,
	s1.expiration
FROM expense s1
INNER JOIN expenseyear i1 
ON s1.idexp = i1.idexp 
INNER JOIN expensetotal i2
ON i1.idexp = i2.idexp
AND i1.ayear = i2.ayear
INNER JOIN config p1
ON p1.appropriationphasecode = s1.nphase
AND p1.ayear = i1.ayear
WHERE ((i2.flag&1)=0)  --'C'
AND i2.curramount >
	  ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense e3
	  JOIN expensetotal i3
	 	ON e3.idexp = i3.idexp
	  JOIN expenselast l1
	  	ON l1.idexp = e3.idexp
	  JOIN expenselink el
		ON el.idparent = s1.idexp
		AND el.idchild = e3.idexp
	 WHERE 
		--i3.idexp LIKE s1.idexp + '%'
		-- AND e3.nphase =
		--(SELECT MAX(nphase) FROM expensephase)
		-- AND 
		i3.ayear = i1.ayear),0.0)
AND s1.expiration IS NOT NULL




GO

print '[expenditurearrearssupposed] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceedssupposed') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceedssupposed
GO


CREATE               VIEW [proceedssupposed]
(
	ayear,
	idinc,
	nphase,
	description,
	ymov,
	nmov,
	curramount,
	available,
	adate,
	expiration,
	kpro,
	ypro,
	npro,
	proceedsadate,
	kyproceedstransmission,
	yproceedstransmission,
	nproceedstransmission,
	transmissiondate
)
AS
-- Incassi trasmessi
	SELECT i1.ayear,
	e1.idinc,
	e1.nphase,
	f1.description,
	e1.ymov,
	e1.nmov,
	i1.curramount,
	NULL,
	e1.adate,
	e1.expiration,
	d1.kpro,
	d1.ypro,
	d1.npro,
	d1.adate,
	t1.kproceedstransmission,
	t1.yproceedstransmission,
	t1.nproceedstransmission,
	t1.transmissiondate
	FROM income e1
	JOIN incometotal i1
		ON e1.idinc = i1.idinc
	JOIN incomeyear i2
		ON i1.idinc = i2.idinc
		AND i1.ayear = i2.ayear
	join incomelast ls
		on e1.idinc = ls.idinc
	JOIN incomephase f1
		ON f1.nphase = e1.nphase
	LEFT OUTER JOIN proceeds d1
		ON ls.kpro = d1.kpro
	LEFT OUTER JOIN proceedstransmission t1
		ON d1.kproceedstransmission = t1.kproceedstransmission
	UNION
	SELECT 
	i1.ayear,
	e1.idinc,
	e1.nphase,
	f1.description,
	e1.ymov,
	e1.nmov,
	NULL,
	i1.available,
	e1.adate,
	e1.expiration,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL
	FROM income e1
	JOIN incometotal i1
		ON e1.idinc = i1.idinc
	JOIN incomeyear i2
		ON i1.idinc = i2.idinc
		AND i1.ayear = i2.ayear
	JOIN incomephase f1
		ON f1.nphase = e1.nphase
	WHERE i1.available <> 0
	AND f1.nphase >= (SELECT assessmentphasecode FROM config WHERE ayear = i2.ayear)
	AND f1.nphase < (SELECT MAX(nphase) FROM incomephase)


GO

print '[proceedssupposed] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceeds_bankview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceeds_bankview
GO


CREATE               VIEW proceeds_bankview
(
	kpro,
	ypro,
	npro,
	idpro,
	idreg,
	registry,
	description,
	amount,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	PB.idpro,
	PB.idreg,
	R.title,
	PB.description,
	PB.amount,
	PB.ct,
	PB.cu,
	PB.lt,
	PB.lu
FROM proceeds_bank PB
JOIN proceeds 
	ON proceeds.kpro = PB.kpro
JOIN registry R
	ON R.idreg = PB.idreg




GO

print 'proceeds_bankview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_contracttaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_contracttaxview
GO



--clear_table_info'csa_contractview'
--select * from csa_contracttax
CREATE      VIEW [csa_contracttaxview]
(
	ayear,
	idcsa_contract,
	idcsa_contracttax,
	vocecsa,idfin,idexp,idacc,ct,cu,lt,lu,idupb,idsor_siope,
	ymov,nmov,nphase,codeupb,codefin,codeacc,sortcode_siope
)
AS SELECT 
	C.ayear,
	C.idcsa_contract,
	C.idcsa_contracttax,
	C.vocecsa,C.idfin,C.idexp,C.idacc,C.ct,C.cu,C.lt,C.lu,C.idupb,C.idsor_siope,
	E.ymov,E.nmov,E.nphase,  U.codeupb, F.codefin, ACC.codeacc, S.sortcode
	
FROM csa_contracttax C
LEFT OUTER JOIN upb U
	ON U.idupb=C.idupb
LEFT OUTER JOIN fin F
	ON F.idfin=C.idfin
LEFT OUTER JOIN account ACC
	ON ACC.idacc=C.idacc
LEFT OUTER JOIN expense E
	ON C.idexp = E.idexp
LEFT OUTER JOIN sorting S
	ON S.idsor = C.idsor_siope




GO

print '[csa_contracttaxview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'payrolltaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW payrolltaxview
GO

CREATE       VIEW [payrolltaxview]
(
	idpayroll,
	idpayrolltax,
	adminrate,
	employrate,
	taxcode,
	deduction,
	abatements,
	taxablegross,
	taxablenet,
	annualtaxabletotal,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	admintax,
	employtax,
	employtaxgross,
	annualpayedemploytax,
	taxdescription,
	taxref,
	taxablecode,
	taxablekind,
	idcon,
	taxkind,
	flagbalance,
	fiscalyear,
	npayroll,
	geoappliance,
	idcity,
	city,
	provincecode,
	idfiscaltaxregion,
	fiscaltaxregion,
	ct, cu, lt, lu
)
AS
SELECT 
	cr.idpayroll,
	cr.idpayrolltax,
	cr.adminrate,
	cr.employrate,
	cr.taxcode,
	cr.deduction,
	cr.abatements,
	cr.taxablegross,
	cr.taxablenet,
	cr.annualtaxabletotal,
	cr.admindenominator,
	cr.employdenominator,
	cr.taxabledenominator,
	cr.adminnumerator,
	cr.employnumerator,
	cr.taxablenumerator,
	cr.admintax,
	cr.employtax,
	cr.employtaxgross,
	cr.annualpayedemploytax,
	tr.description,
	tr.taxref,
	ti.taxablecode,
	ti.description,
	c.idcon,
	tr.taxkind,
	c.flagbalance,
	c.fiscalyear,
	c.npayroll,
	tr.geoappliance,
	cr.idcity,
	geo_city.title,
	geo_country.province,
	cr.idfiscaltaxregion,
	fiscaltaxregion.title,
	cr.ct, cr.cu, cr.lt, cr.lu
FROM payrolltax cr
JOIN tax tr
	ON cr.taxcode = tr.taxcode
JOIN taxablekind ti
	ON tr.taxablecode = ti.taxablecode
JOIN payroll c
	ON c.idpayroll = cr.idpayroll
	AND c.fiscalyear = ti.ayear
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = cr.idcity
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
LEFT OUTER JOIN fiscaltaxregion
	ON fiscaltaxregion.idfiscaltaxregion = cr.idfiscaltaxregion


GO

print '[payrolltaxview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finlookupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finlookupview
GO

--Pino Rana, elaborazione del 10/08/2005 15:18:02
CREATE                                               VIEW finlookupview 
	(
	oldidfin,
	oldayear,
	oldpartfin,
	oldcodefin,
	oldtitle,
	newidfin,
	newayear,
	newpartfin,
	newfincode,
	newtitle,
	cu, 
	ct, 
	lu, 
	lt
	)
	AS SELECT
	finlookup.oldidfin,
	oldbilancio.ayear,
	--oldbilancio.finpart,
	CASE
		WHEN ((oldbilancio.flag&1)=0) THEN 'E'
		WHEN ((oldbilancio.flag&1)=1) THEN 'S'
	END,
	oldbilancio.codefin,
	oldbilancio.title,
	finlookup.newidfin,
	newbilancio.ayear,
	--newbilancio.finpart,
	CASE
		WHEN ((newbilancio.flag&1)=0) THEN 'E'
		WHEN ((newbilancio.flag&1)=1) THEN 'S'
	END,
	newbilancio.codefin,
	newbilancio.title,
	finlookup.cu,
	finlookup.ct,
	finlookup.lu,
	finlookup.lt
	FROM finlookup (NOLOCK)
	JOIN fin oldbilancio (NOLOCK)
	ON oldbilancio.idfin = finlookup.oldidfin
	JOIN fin newbilancio (NOLOCK)
	ON newbilancio.idfin = finlookup.newidfin



GO

print 'finlookupview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'trasmissionmanagerview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW trasmissionmanagerview
GO

CREATE                VIEW [trasmissionmanagerview]
(
	ayear,
	idreg,
	annotations,
	registry,
	cf,
	idtrasmissiondocument,
	description,
	surname,
	forename,
	birthdate,
	idcity,
	gender,
	city,
	province,
	idnation,
	nation,
	phonenumber,
	faxnumber,
	email,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	trasmissionmanager.ayear,
	trasmissionmanager.idreg,
	trasmissionmanager.annotations,
	registry.title,
	registry.cf,
	trasmissiondocument.idtrasmissiondocument,
	trasmissiondocument.description,
	registry.surname,
	registry.forename,
	registry.birthdate,
	registry.idcity,
	registry.gender,
	geo_city.title,
	geo_country.province,
	registry.idnation,
	geo_nation.title,
	registryreference.phonenumber,
	registryreference.faxnumber,
	registryreference.email,
	trasmissionmanager.cu,
	trasmissionmanager.ct,
	trasmissionmanager.lu,
	trasmissionmanager.lt
FROM trasmissionmanager
JOIN trasmissiondocument
	ON trasmissionmanager.idtrasmissiondocument = trasmissiondocument.idtrasmissiondocument
JOIN registry
	ON registry.idreg = trasmissionmanager.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registry.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registry.idnation
LEFT OUTER JOIN registryreference
	ON registryreference.idreg = trasmissionmanager.idreg
	AND registryreference.flagdefault = 'S'



GO

print '[trasmissionmanagerview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_contracttaxexpenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_contracttaxexpenseview
GO

--clear_table_info'csa_contracttaxexpenseview'
--select * from csa_contracttaxexpense
--select * from csa_contracttaxexpenseview

--clear_table_info'csa_contracttaxexpenseview'
CREATE      VIEW [csa_contracttaxexpenseview]
(
	ayear,
	idcsa_contract,
	idcsa_contracttax,
	ndetail,quota,cu,ct,lu,lt,idexp,
	ymov,nmov,phase
	
)
AS SELECT 
	C.ayear,
	C.idcsa_contract,
	C.idcsa_contracttax,
	C.ndetail,C.quota,C.cu,C.ct,C.lu,C.lt,C.idexp,	
	E.ymov,E.nmov,EF.description
FROM csa_contracttaxexpense C
LEFT OUTER JOIN expense E
	ON C.idexp = E.idexp
LEFT OUTER JOIN expensephase EF
	ON EF.nphase = E.nphase


GO

print '[csa_contracttaxexpenseview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'payrolltaxbracketview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW payrolltaxbracketview
GO



CREATE       VIEW [payrolltaxbracketview]
(
	taxcode,
	description,
	taxref,
	idcon,
	ycon,
	ncon,
	idpayroll,
	npayroll,
	fiscalyear,
	nbracket,
	adminrate,
	employrate,
	taxablegross,
	deduction,
	totaltaxablenet,
	taxablenet,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	totaladmintax,
	totalemploytax,
	admintax,
	employtax,
	employtaxgross,
	abatements,
	taxkind,
	geoappliance,
	idcity,
	city,
	provincecode,
	idfiscaltaxregion,
	fiscaltaxregion,
	lu,
	lt
)
AS SELECT
	PRT.taxcode,
	TR.description,
	TR.taxref,
	PSC.idcon,
	PSC.ycon,
	PSC.ncon,
	PRT.idpayroll,
	PR.npayroll,
	PR.fiscalyear,
	PRTB.nbracket,
	PRTB.adminrate,
	PRTB.employrate,
	PRT.taxablegross,
	PRT.deduction,
	PRT.taxablenet,
	PRTB.taxable,
	PRT.admindenominator,
	PRT.employdenominator,
	PRT.taxabledenominator,
	PRT.adminnumerator,
	PRT.employnumerator,
	PRT.taxablenumerator,
	PRT.admintax,
	PRT.employtax,
	PRTB.admintax,
	PRTB.employtax,
	PRT.employtaxgross,
	PRT.abatements,
	TR.taxkind,
	TR.geoappliance,
	PRT.idcity,
	geo_city.title,
	geo_country.province,
	PRT.idfiscaltaxregion,
	fiscaltaxregion.title,
	PRTB.lu,
	PRTB.lt
FROM payrolltaxbracket PRTB
JOIN payrolltax PRT
	ON PRTB.idpayroll = PRT.idpayroll
	AND PRTB.idpayrolltax = PRT.idpayrolltax
JOIN payroll PR
	ON PR.idpayroll = PRT.idpayroll
JOIN parasubcontract PSC
	ON PSC.idcon = PR.idcon
JOIN tax TR
	ON PRT.taxcode = TR.taxcode
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = PRT.idcity
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
LEFT OUTER JOIN fiscaltaxregion
	ON fiscaltaxregion.idfiscaltaxregion = PRT.idfiscaltaxregion


GO

print '[payrolltaxbracketview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'profservicetaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW profservicetaxview
GO



CREATE              VIEW [profservicetaxview]
(
	taxcode,
	description,
	taxref,
	ycon,
	ncon,
	adminrate,
	employrate,
	taxablegross,
	taxablenet,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	admintax,
	employtax,
	employtaxgross,
	taxkind
)
AS SELECT
	COPR.taxcode,
	TR.description,
	TR.taxref,
	COPR.ycon,
	COPR.ncon,
	COPR.adminrate,
	COPR.employrate,
	COPR.taxablegross,
	COPR.taxablenet,
	COPR.admindenominator,
	COPR.employdenominator,
	COPR.taxabledenominator,
	COPR.adminnumerator,
	COPR.employnumerator,
	COPR.taxablenumerator,
	COPR.admintax,
	COPR.employtax,
	COPR.employtaxgross,
	TR.taxkind
FROM profservicetax COPR
JOIN tax TR
	ON COPR.taxcode = TR.taxcode





GO

print '[profservicetaxview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'unifiedtaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW unifiedtaxview
GO



-- SELECT * FROM unifiedtaxview
CREATE       VIEW [unifiedtaxview]
(
        cf,
	address,
	cap,
	city,
	country,
	nation,
	location,
	payed_city,
	payed_country,
	payed_fiscaltaxregion,
	idexp,
	nbracket,
	abatements,
        ymov,
        nmov,
	idreg,
	registry,
        taxcode,
        fiscaltaxcode,
	taxref,
	description,
	taxkind,
        taxcategory,
	taxablegross,
	taxablenet,
	employrate,
	employnumerator,
	employdenominator,
	employtax,
	adminrate,
	adminnumerator,
	admindenominator,
	admintax,
	competencydate,
	idunifiedtax, 
	idunifiedf24ep,
        ayear,      
	f24ep_ayear,      
        nmonth,
        iddbdepartment,
        department,
        npay,
        servicestart,
		servicestop,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT     
	registry.cf, 
	registryaddress.address, 
	registryaddress.cap, 
	geo_city.title, 
	geo_country.province, 
	geo_nation.title, 
	registryaddress.location,
	pgc.title,
	pgc_country.province,
	pftr.title,
	unifiedtax.idexp, 
	unifiedtax.nbracket, 
	unifiedtax.abatements,
	unifiedtax.ymov, 
	unifiedtax.nmov, 
	unifiedtax.idreg, 
	registry.title, 
	unifiedtax.taxcode, 
        tax.fiscaltaxcode,
	tax.taxref,
	tax.description, 
	tax.taxkind, 
        CASE tax.taxkind
                WHEN 1 THEN 'Fiscale'
                WHEN 2 THEN 'Assistenziale'
                WHEN 3 THEN 'Previdenziale'
                WHEN 4 THEN 'Assicurativa'
                WHEN 5 THEN 'Arretrati'
                WHEN 6 THEN 'Altro'
        END,
	unifiedtax.taxablegross, 
	unifiedtax.taxablenet, 
	unifiedtax.employrate, 
	unifiedtax.employnumerator, 
	unifiedtax.employdenominator, 
	unifiedtax.employtax, 
	unifiedtax.adminrate, 
	unifiedtax.adminnumerator, 
	unifiedtax.admindenominator, 
	unifiedtax.admintax, 
	unifiedtax.competencydate, 
	unifiedtax.idunifiedtax, 
	unifiedtax.idunifiedf24ep,
        unifiedtax.ayear,
	unifiedf24ep.ayear,
        unifiedtax.nmonth,
        unifiedtax.iddbdepartment,
        dbdepartment.description,
        unifiedtax.npay,
          unifiedtax.servicestart,
		 unifiedtax.servicestop,
	unifiedtax.cu, unifiedtax.ct, unifiedtax.lu, unifiedtax.lt
FROM unifiedtax
JOIN tax
	ON tax.taxcode = unifiedtax.taxcode
LEFT OUTER JOIN unifiedf24ep
        ON unifiedtax.idunifiedf24ep = unifiedf24ep.idunifiedf24ep
LEFT OUTER JOIN dbdepartment
        ON unifiedtax.iddbdepartment = dbdepartment.iddbdepartment
LEFT OUTER JOIN registry
	ON registry.idreg = unifiedtax.idreg
LEFT OUTER JOIN registryaddress
	ON registryaddress.idreg = unifiedtax.idreg
LEFT OUTER JOIN geo_city
	ON registryaddress.idcity = geo_city.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON registryaddress.idnation = geo_nation.idnation
LEFT OUTER JOIN geo_city pgc
	ON pgc.idcity = unifiedtax.idcity
LEFT OUTER JOIN geo_country pgc_country
	ON pgc_country.idcountry = pgc.idcountry
LEFT OUTER JOIN fiscaltaxregion pftr
	ON pftr.idfiscaltaxregion = unifiedtax.idfiscaltaxregion
WHERE (registryaddress.idaddresskind IS NULL OR registryaddress.idaddresskind = 
		(select top 1 idaddresskind 
		   from registryaddress ci
		   join address ON registryaddress.idaddresskind = address.idaddress
		  where ci.idreg = registry.idreg
	       order by case codeaddress
				when '07_SW_DOM' then 1
				when '07_SW_DEF' then 2
				else 3
			end
		) and registryaddress.start = 
		(	select max(start)
			from registryaddress ci2
			where ci2.idreg = registry.idreg
			and ci2.idaddresskind = registryaddress.idaddresskind
		))






GO

print '[unifiedtaxview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'payrolltaxcorrigeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW payrolltaxcorrigeview
GO

CREATE        VIEW payrolltaxcorrigeview
(
	idpayroll,
	idpayrolltaxcorrige,
	taxcode,
	ayear,
	idcon,
	taxdescription,
	taxref,
	taxablegross,
	taxablenet,
	employamount,
	adminamount,
	taxkind,
	flagbalance,
	fiscalyear,
	npayroll,
	geoappliance,	
	idcity,
	city,
	provincecode,
	idfiscaltaxregion,
	fiscaltaxregion,
	ct, cu, lt, lu
)
AS
SELECT 
	cr.idpayroll,
	cr.idpayrolltaxcorrige,
	cr.taxcode,
	cr.ayear,
	c.idcon,
	tr.description,
	tr.taxref,
	cr.taxablegross,
	cr.taxablenet,
	cr.employamount,
	cr.adminamount,
	tr.taxkind,
	c.flagbalance,
	c.fiscalyear,
	c.npayroll,
	tr.geoappliance,
	cr.idcity,
	geo_city.title,
	geo_country.province,
	cr.idfiscaltaxregion,
	fiscaltaxregion.title,
	cr.ct, cr.cu, cr.lt, cr.lu
FROM payrolltaxcorrige cr
JOIN tax tr
	ON cr.taxcode = tr.taxcode
JOIN payroll c
	ON c.idpayroll = cr.idpayroll
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = cr.idcity
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
LEFT OUTER JOIN fiscaltaxregion
	ON fiscaltaxregion.idfiscaltaxregion = cr.idfiscaltaxregion


GO

print 'payrolltaxcorrigeview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paymentview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paymentview
GO


-- Inserire la ALTER  VIEW qui--
CREATE                                VIEW [paymentview]
	(
	kpay,
	ypay,
	npay,
	idstamphandling,
	stamphandling,
	idtreasurer,
	codetreasurer,
	flag,
	kind,
	idreg,
	registry,
	idfin,
	codefin,
	finance,
	idman,
	manager,
	kpaymenttransmission,
  	ypaymenttransmission,
  	npaymenttransmission,
  	transmissiondate,
	adate,
	printdate,
	annulmentdate,
	cu,
	ct,
	lu,
	lt,
	total,
	performed,
	notperformed,
	idsor01,idsor02,idsor03,idsor04,idsor05
	)
	AS SELECT
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.idstamphandling,
	stamphandling.description,
	payment.idtreasurer,
	treasurer.codetreasurer,
	payment.flag,
	CASE
		WHEN ((payment.flag&1)<> 0) THEN 'C'
		WHEN ((payment.flag&2)<> 0) THEN 'R'
		WHEN ((payment.flag&4)<> 0) THEN 'M'
	END, 
	payment.idreg,
	registry.title,
	payment.idfin,
	fin.codefin,
	fin.title,
	payment.idman,
	manager.title,
	payment.kpaymenttransmission,
  	paymenttransmission.ypaymenttransmission,
  	paymenttransmission.npaymenttransmission,
  	paymenttransmission.transmissiondate,
	payment.adate,
	payment.printdate,
	payment.annulmentdate,
	payment.cu,
	payment.ct,
	payment.lu,
	payment.lt,
	(SELECT SUM(curramount) from expensetotal I join expense S on I.idexp=S.idexp 
		JOIN expenselast EL ON EL.idexp = S.idexp
	 WHERE  EL.kpay=payment.kpay AND
	        I.ayear = payment.ypay),
	ISNULL((SELECT SUM(amount) from banktransaction P where
		P.kpay=payment.kpay),0),
	(SELECT SUM(curramount) from expensetotal I join expense S on I.idexp=S.idexp 
		JOIN expenselast EL ON EL.idexp = S.idexp
	  WHERE EL.kpay=payment.kpay AND I.ayear = payment.ypay)
	  -ISNULL( (SELECT SUM(amount) from banktransaction P where
		P.kpay=payment.kpay),0),
	COALESCE(payment.idsor01,treasurer.idsor01) ,COALESCE(payment.idsor02,treasurer.idsor02),COALESCE(payment.idsor03,treasurer.idsor03),
	COALESCE(payment.idsor04,treasurer.idsor04),COALESCE(payment.idsor05,treasurer.idsor05)
	FROM payment  with (nolock)
	LEFT OUTER JOIN registry  with (nolock)
	ON registry.idreg = payment.idreg
	LEFT OUTER JOIN fin  with (nolock)
	ON fin.idfin = payment.idfin  
	LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = payment.idman
	LEFT OUTER JOIN stamphandling with (nolock)
	ON stamphandling.idstamphandling = payment.idstamphandling
	LEFT OUTER JOIN paymenttransmission with (nolock)
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
	LEFT OUTER JOIN treasurer with (nolock)
	ON treasurer.idtreasurer = payment.idtreasurer


GO

print '[paymentview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'inventorytreesortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW inventorytreesortingview
GO


CREATE              VIEW [inventorytreesortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	codeinv,
	sorting,
	idinv,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	inventorytreesorting.idsor,
	sorting.sortcode,
	sorting.description,
	inventorytreesorting.idinv,
	inventorytreesorting.cu,
	inventorytreesorting.ct,
	inventorytreesorting.lu,
	inventorytreesorting.lt
FROM inventorytreesorting
JOIN sorting
	ON sorting.idsor = inventorytreesorting.idinv
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind


GO

print '[inventorytreesortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'unifiedtaxcorrigeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW unifiedtaxcorrigeview
GO

-- SELECT idexpensetaxcorrige,* FROM unifiedtaxcorrigeview
CREATE        VIEW [unifiedtaxcorrigeview]
(
        cf,
	address,
	cap,
	city,
	country,
	nation,
	location,
	payed_city,
	payed_country,
	payed_fiscaltaxregion,
	idexp,
        idexpensetaxcorrige,
        ymov,
        nmov,
	idreg,
	registry,
        taxcode,
        fiscaltaxcode,
	taxref,
	description,
	taxkind,
        taxcategory,
	adate,
        employamount,
        adminamount,
	idunifiedtaxcorrige, 
	idunifiedf24ep,
        ayear,                
        nmonth,
        iddbdepartment,
        department,
        npay,
        servicestart,
        servicestop,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT     
	registry.cf, 
	registryaddress.address, 
	registryaddress.cap, 
	geo_city.title, 
	geo_country.province, 
	geo_nation.title, 
	registryaddress.location,
	pgc.title,
	pgc_country.province,
	pftr.title,
	unifiedtaxcorrige.idexp, 
	unifiedtaxcorrige.idexpensetaxcorrige, 
	unifiedtaxcorrige.ymov, 
	unifiedtaxcorrige.nmov, 
	unifiedtaxcorrige.idreg, 
	registry.title, 
	unifiedtaxcorrige.taxcode, 
        tax.fiscaltaxcode,
	tax.taxref,
	tax.description, 
	tax.taxkind, 
        CASE tax.taxkind
                WHEN 1 THEN 'Fiscale'
                WHEN 2 THEN 'Assistenziale'
                WHEN 3 THEN 'Previdenziale'
                WHEN 4 THEN 'Assicurativa'
                WHEN 5 THEN 'Arretrati'
                WHEN 6 THEN 'Altro'
        END,
        unifiedtaxcorrige.adate, 
        unifiedtaxcorrige.employamount,
        unifiedtaxcorrige.adminamount,
	unifiedtaxcorrige.idunifiedtaxcorrige, 
	unifiedtaxcorrige.idunifiedf24ep,
        unifiedf24ep.ayear,
        unifiedtaxcorrige.nmonth,
        unifiedtaxcorrige.iddbdepartment,
        dbdepartment.description,
        unifiedtaxcorrige.npay,
		unifiedtaxcorrige.servicestart,
		unifiedtaxcorrige.servicestop,
	unifiedtaxcorrige.cu, unifiedtaxcorrige.ct, unifiedtaxcorrige.lu, unifiedtaxcorrige.lt
FROM unifiedtaxcorrige
JOIN tax
	ON tax.taxcode = unifiedtaxcorrige.taxcode
LEFT OUTER JOIN unifiedf24ep
        ON unifiedtaxcorrige.idunifiedf24ep = unifiedf24ep.idunifiedf24ep
LEFT OUTER JOIN dbdepartment
        ON unifiedtaxcorrige.iddbdepartment = dbdepartment.iddbdepartment
LEFT OUTER JOIN registry
	ON registry.idreg = unifiedtaxcorrige.idreg
LEFT OUTER JOIN registryaddress
	ON registryaddress.idreg = unifiedtaxcorrige.idreg
LEFT OUTER JOIN geo_city
	ON registryaddress.idcity = geo_city.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON registryaddress.idnation = geo_nation.idnation
LEFT OUTER JOIN geo_city pgc
	ON pgc.idcity = unifiedtaxcorrige.idcity
LEFT OUTER JOIN geo_country pgc_country
	ON pgc_country.idcountry = pgc.idcountry
LEFT OUTER JOIN fiscaltaxregion pftr
	ON pftr.idfiscaltaxregion = unifiedtaxcorrige.idfiscaltaxregion
WHERE (registryaddress.idaddresskind IS NULL OR registryaddress.idaddresskind = 
		(select top 1 idaddresskind 
		   from registryaddress ci
		   join address ON registryaddress.idaddresskind = address.idaddress
		  where ci.idreg = registry.idreg
	       order by case codeaddress
				when '07_SW_DOM' then 1
				when '07_SW_DEF' then 2
				else 3
			end
		) and registryaddress.start = 
		(	select max(start)
			from registryaddress ci2
			where ci2.idreg = registry.idreg
			and ci2.idaddresskind = registryaddress.idaddresskind
		))






GO

print '[unifiedtaxcorrigeview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'exhibitedcudview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW exhibitedcudview
GO

CREATE        VIEW exhibitedcudview
(
	idcon,
	ycon,
	ncon,
	idexhibitedcud,
	cfotherdeputy,
	citytax_account,
	citytaxapplied,
	fiscalyear,
	flagignoreprevcud,
	inpsowed,
	inpsretained,
	irpefapplied,
	irpefsuspended,
	ndays,
	nmonths,
	regionaltaxapplied,
	start,
	stop,
	suspendedcitytax,
	suspendedregionaltax,
	taxablegross,
	taxablenet,
	taxablepension,
	transfermotive,
	idlinkedcon,
	ylinkedcon,
	nlinkedcon,
	idcity,
	city0101,
	provincecode0101,
	region0101,
	idfiscaltaxregion,
	fiscaltaxregion,
	ct, cu, lt, lu
)
AS
SELECT
	E.idcon,
	P.ycon,
	P.ncon,
	E.idexhibitedcud,
	E.cfotherdeputy,
	E.citytax_account,
	E.citytaxapplied,
	E.fiscalyear,
	E.flagignoreprevcud,
	E.inpsowed,
	E.inpsretained,
	E.irpefapplied,
	E.irpefsuspended,
	E.ndays,
	E.nmonths,
	E.regionaltaxapplied,
	E.start,
	E.stop,
	E.suspendedcitytax,
	E.suspendedregionaltax,
	E.taxablegross,
	E.taxablenet,
	E.taxablepension,
	E.transfermotive,
	E.idlinkedcon,
	L.ycon,
	L.ncon,
	E.idcity,
	G0101.title,
	GC0101.province,
	GR0101.title,
	E.idfiscaltaxregion,
	F.title,
	E.ct, E.cu, E.lt, E.lu
FROM exhibitedcud E
JOIN parasubcontract P
	ON P.idcon = E.idcon
LEFT OUTER JOIN parasubcontract L
	ON L.idcon = E.idlinkedcon
LEFT OUTER JOIN geo_city G0101
	ON G0101.idcity = E.idcity
LEFT OUTER JOIN geo_country GC0101
	ON GC0101.idcountry = G0101.idcountry
LEFT OUTER JOIN geo_region GR0101
	ON GR0101.idregion = GC0101.idregion
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = E.idfiscaltaxregion


GO

print 'exhibitedcudview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'budgetvardetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW budgetvardetailview
GO

--select * from budgetvardetailview
CREATE       VIEW budgetvardetailview
(
	ybudgetvar,
	nbudgetvar,
	yvar,
	nvar,
	rownum,
	variationdescription,
	official,
	nofficial,
	idman,
	manager,
	idbudgetvarstatus,
	budgetvarstatus,
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	description,
	idupb,		
	codeupb,	
	upb,	
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	amount,
	annotation,
	adate,	
	cu,
	ct,
	lu,
	lt,
	flagactivity,
	activity,
	flagkind,
	kindd,
	kindr
	
)
AS SELECT
	budgetvardetail.ybudgetvar,
	budgetvardetail.nbudgetvar,
	budgetvar.yvar,
	budgetvar.nvar,
	budgetvardetail.rownum,
	budgetvar.description,
	budgetvar.official,
	budgetvar.nofficial,
	budgetvar.idman,
	manager.title,
	budgetvar.idbudgetvarstatus,
	budgetvarstatus.description,
	budgetvar.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	budgetvardetail.idsor,
	sorting.sortcode,
	sorting.description,
	budgetvardetail.description,
	upb.idupb,	
	upb.codeupb,		
	upb.title,	
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	budgetvardetail.amount,
	budgetvardetail.annotation,
	budgetvar.adate,	
	budgetvardetail.cu,
	budgetvardetail.ct,
	budgetvardetail.lu,
	budgetvardetail.lt,
	upb.flagactivity,
--	activity,
	case
	when upb.flagactivity ='1' then 'Istituzionale'
	when upb.flagactivity ='2' then 'Commerciale'
	-- when upb.flagactivity ='3' then 'p': l'upb non ha il promiscuo
	when upb.flagactivity ='4' then 'Qualsiasi/Non specificata'
	end,
	upb.flagkind,
--	kindd,
	CASE
		when (( upb.flagkind & 1)<> 0) then 'S'
	End,
--	kindr,
	CASE
		when (( upb.flagkind & 2)<>0) then 'S'
	End
FROM budgetvardetail with (nolock)
JOIN budgetvar with (nolock)
	ON budgetvardetail.ybudgetvar = budgetvar.ybudgetvar
	AND budgetvardetail.nbudgetvar = budgetvar.nbudgetvar
JOIN sortingkind with (nolock)
	ON budgetvar.idsorkind = sortingkind.idsorkind
JOIN sorting with (nolock)
	ON budgetvardetail.idsor = sorting.idsor
JOIN upb with (nolock)
	ON budgetvardetail.idupb=upb.idupb 	
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = budgetvar.idman
LEFT OUTER JOIN budgetvarstatus with (nolock)
	ON budgetvarstatus.idbudgetvarstatus = budgetvar.idbudgetvarstatus


GO

print 'budgetvardetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finunified') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finunified
GO





CREATE     VIEW [finunified]
(
	idfin,
	ayear,
	flag,
	finpart,
	codefin,
	paridfin,
	nlevel,
--	sortcode,
	idman,
	manager,
	printingorder,
	title,
	prevision,
	currentprevision,		--	+ corrente prev. princ.
	availableprevision,		--	+ disponibile prev. princ.
	previousprevision,
	secondaryprev,
	currentsecondaryprev,		--	+ corrente prev. sec.
	availablesecondaryprev,		--	+ disponibile prev. sec.
	previoussecondaryprev,
	currentarrears,
	previousarrears,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	expiration,
	cupcode,
	cu,
	ct,
	lu,
	lt
)
AS
SELECT
fin.idfin,
fin.ayear,
fin.flag,
CASE
	WHEN ((fin.flag&1)=0) THEN 'E'
	WHEN ((fin.flag&1)=1) THEN 'S'
END,
fin.codefin,
fin.paridfin,
fin.nlevel,
--fin.sortcode,
manager.idman,
manager.title,
fin.printingorder,
fin.title,
-- Previsione Principale Esercizio Corrente
(select sum(ISNULL(currentprev,0)) from upbtotal where idfin=fin.idfin),
--	Previsione Attuale: previsione corrente - variazioni di previsione. SA 
(select isnull(sum(ISNULL(currentprev,0) + ISNULL(previsionvariation,0)),0) 
	from upbtotal where idfin=fin.idfin),
--	Disponibile: previsione corrente + var.di previsione - movimenti di spesa. SA
 	(select isnull(sum( ISNULL(currentprev,0) + ISNULL(previsionvariation,0)),0)
		from upbtotal where idfin=fin.idfin)
	-
 	CASE
	WHEN ((fin.flag&1)=1) THEN
		(				
			CASE 
			WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
				(select isnull(sum(ISNULL(totalcompetency,0)),0) 
				from upbexpensetotal JOIN uniconfig 
				ON upbexpensetotal.nphase = uniconfig.expensefinphase
				where idfin = fin.idfin
				)
			ELSE
				(select isnull(sum(ISNULL(totalcompetency,0)+ ISNULL(totalarrears,0)),0) 
				from upbexpensetotal JOIN uniconfig 
				ON upbexpensetotal.nphase = uniconfig.expensefinphase
				where idfin = fin.idfin
				)
			END
		)
	WHEN ((fin.flag&1)=0)THEN
		(
			CASE 
			WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3)  THEN
				(select isnull(sum(ISNULL(totalcompetency,0)),0) 
				from upbincometotal JOIN uniconfig 
				ON upbincometotal.nphase = uniconfig.incomefinphase
				where idfin = fin.idfin
				)
			ELSE
				(select isnull(sum(ISNULL(totalcompetency,0) 
				+ ISNULL(totalarrears,0)),0)
				from upbincometotal JOIN uniconfig 
				ON upbincometotal.nphase = uniconfig.incomefinphase
				where idfin = fin.idfin
				)
			END
		) 
   	END,
-- Previsione Principale Esercizio Precedente
	(select sum(ISNULL(previousprev,0)) from upbtotal where idfin=fin.idfin),
-- Previsione Secondaria Esercizio Corrente
	(select sum(ISNULL(currentsecondaryprev,0)) from upbtotal where idfin=fin.idfin),
-- Calcolo Previsione Secondaria Attuale,	SA
	(select (sum(ISNULL(currentsecondaryprev,0) + ISNULL(secondaryvariation,0))) 
		from upbtotal where idfin=fin.idfin),
-- Calcolo Previsione Secondaria Disponibile  =  Previsione attuale - somma ( totalecompetenza+totaleresidui), SA
	(select isnull(sum(ISNULL(currentsecondaryprev,0) + ISNULL(secondaryvariation,0)),0)
		from upbtotal where idfin=fin.idfin)
   -
    CASE
	WHEN ((fin.flag&1)=1) THEN
		(select isnull(sum(ISNULL(totalcompetency,0)+ ISNULL(totalarrears,0)),0) 
			from upbexpensetotal JOIN uniconfig 
				ON upbexpensetotal.nphase = uniconfig.expensefinphase	
			where idfin = fin.idfin
			)
	WHEN ((fin.flag&1)=0) THEN
		(select isnull(sum(ISNULL(totalcompetency,0) + ISNULL(totalarrears,0)),0)
			from upbincometotal JOIN uniconfig 
				ON upbincometotal.nphase = uniconfig.incomefinphase	
			where idfin = fin.idfin
			)
   END,
-- Previsione Secondaria Esercizio Precedente
(select sum (previoussecondaryprev) from upbtotal where idfin=fin.idfin),
-- Residui Presunti (Correnti)
(select sum(currentarrears) from upbtotal where idfin=fin.idfin),
-- Residui Effettivi (Precendenti)
(select sum(previousarrears) from upbtotal where idfin=fin.idfin),
-- Previsione Anno 2
(select sum(prevision2) from finyear where idfin=fin.idfin),
-- Previsione Anno 3
(select sum(prevision3) from finyear where idfin=fin.idfin),
-- Previsione Anno 4
(select sum(prevision4) from finyear where idfin=fin.idfin),
-- Previsione Anno 5
(select sum(prevision5) from finyear where idfin=fin.idfin),
finlast.expiration,
finlast.cupcode,
fin.cu,
fin.ct,
fin.lu,
fin.lt
	FROM fin 
	(NOLOCK) INNER JOIN finlevel
	ON finlevel.ayear = fin.ayear
	AND finlevel.nlevel = fin.nlevel 
	LEFT OUTER JOIN finlast (NOLOCK)
	ON finlast.idfin = fin.idfin
	LEFT OUTER JOIN manager (NOLOCK)
	ON manager.idman = finlast.idman
	--LEFT OUTER JOIN manager managerfin
	--ON managerfin.idman = fin.idman
	



GO

print '[finunified] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'auditcheckview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW auditcheckview
GO

--Pino Rana, elaborazione del 10/08/2005 15:18:11
CREATE                                                 VIEW auditcheckview 
	(
	tablename,
	opkind,
	idcheck,
	idaudit,
	title,
	severity,
	sqlcmd, 
	message,
	precheck,
	flag_comp,
	flag_cash,
	flag_both,
	flag_credit,
	flag_proceeds
	)
	AS SELECT
	auditcheck.tablename,
	auditcheck.opkind,
	auditcheck.idcheck,
	auditcheck.idaudit,
	audit.title,
	audit.severity,
	auditcheck.sqlcmd, 
	auditcheck.message,
	auditcheck.precheck,
	auditcheck.flag_comp,
	auditcheck.flag_cash,
	auditcheck.flag_both,
	auditcheck.flag_credit,
	auditcheck.flag_proceeds
	FROM auditcheck (NOLOCK)
	JOIN audit (NOLOCK)
	ON audit.idaudit = auditcheck.idaudit



GO

print 'auditcheckview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxsetupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxsetupview
GO



CREATE       VIEW taxsetupview 
(
	taxcode,
	taxref,
	taxkind,
	ayear,
	flag,
	flagregionalagency,
	paymentagency,
	paymentagencytitle,
	idfinexpensecontra,
	codefinexpensecontra,
	finexpensecontra,
	idfinincomecontra,
	codefinincomecontra,
	finincomecontra,
	idfinincomeemploy,
	codefinincomeemploy,
	finincomeemploy,
	idfinexpenseemploy,
	codefinexpenseemploy,
	finexpenseemploy,
	flagadminfinance,
	idfinadmintax,
	codefinadmintax,
	finadmintax,
	idexpirationkind,
	expiringday,
	flagprevcurr,
	taxpaykind,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	taxsetup.taxcode,
	tax.taxref,
	tax.description,
	taxsetup.ayear,
	taxsetup.flag,
	CASE  -- bit 0 1 2 
		WHEN ((taxsetup.flag)&1) <> 0 THEN 'N'
		WHEN ((taxsetup.flag)&2) <> 0 THEN 'S'
		WHEN ((taxsetup.flag)&4) <> 0 THEN 'P'
	END,
	taxsetup.paymentagency,
	registry.title,
	taxsetup.idfinexpensecontra,
	bilancioversamento.codefin,
	bilancioversamento.title,
	taxsetup.idfinincomecontra,
	bilancioapplicazione.codefin,
	bilancioapplicazione.title,
	finincomeemploy.idfin,
	finincomeemploy.codefin,
	finincomeemploy.title,
	finexpenseemploy.idfin,
	finexpenseemploy.codefin,
	finexpenseemploy.title,
	taxsetup.flagadminfinance,
	taxsetup.idfinadmintax,
	bilanciocontributi.codefin,
	bilanciocontributi.title,
	taxsetup.idexpirationkind,
	taxsetup.expiringday,
	CASE 
		WHEN ((taxsetup.flag)&8) = 0 THEN 'C'
		WHEN ((taxsetup.flag)&8) <> 0 THEN 'P'
	END,
	taxsetup.taxpaykind,
	taxsetup.cu,
	taxsetup.ct,
	taxsetup.lu,
	taxsetup.lt
FROM taxsetup 
JOIN tax 
	ON tax.taxcode = taxsetup.taxcode
LEFT OUTER JOIN registry 
	ON registry.idreg = taxsetup.paymentagency
LEFT OUTER JOIN fin bilancioversamento 
	ON bilancioversamento.idfin = taxsetup.idfinexpensecontra
LEFT OUTER JOIN fin bilancioapplicazione 
	ON bilancioapplicazione.idfin = taxsetup.idfinincomecontra
LEFT OUTER JOIN fin bilanciocontributi 
	ON bilanciocontributi.idfin = taxsetup.idfinadmintax
LEFT OUTER JOIN fin finincomeemploy
	ON finincomeemploy.idfin = taxsetup.idfinincomeemploy
LEFT OUTER JOIN fin finexpenseemploy
	ON finexpenseemploy.idfin = taxsetup.idfinexpenseemploy


GO

print 'taxsetupview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finyearview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finyearview
GO



CREATE                                  VIEW [finyearview]
(
	ayear,
	idfin,
	codefin,
	finance,
	flag,
	finpart,
	paridfin,
	nlevel,
	leveldescr,
	idupb,
	codeupb,
	upb,
	paridupb,
	prevision,
	secondaryprev,
	previousprevision,
	previoussecondaryprev,
	currentarrears,
	previousarrears,
	limit,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	ct,
	cu,
	lt,
	lu
)
AS
SELECT
finyear.ayear,
finyear.idfin,
fin.codefin,
fin.title,
fin.flag,
CASE
	WHEN ((fin.flag&1)=0) THEN 'E'
	WHEN ((fin.flag&1)=1) THEN 'S'
END,
fin.paridfin,
fin.nlevel,
finlevel.description,
finyear.idupb,
upb.codeupb,
upb.title,
upb.paridupb,
finyear.prevision,
finyear.secondaryprev,
finyear.previousprevision,
finyear.previoussecondaryprev,
finyear.currentarrears,
finyear.previousarrears,
finyear.limit,
finyear.prevision2,
finyear.prevision3,
finyear.prevision4,
finyear.prevision5,
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05,	
finyear.ct,
finyear.cu,
finyear.lt,
finyear.lu
FROM finyear
JOIN fin
ON finyear.idfin = fin.idfin
JOIN upb
ON finyear.idupb = upb.idupb
JOIN finlevel
ON finlevel.nlevel = fin.nlevel
AND finlevel.ayear = fin.ayear




GO

print '[finyearview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'flowchartview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW flowchartview
GO

CREATE              VIEW flowchartview
(
	idflowchart,
	paridflowchart,
	codeflowchart,
	printingorder,
	ayear,
	title,
	nlevel,
	leveldescr,
	fax,
	phone,
	address,
	idcity,
	city,
	cap,
	location,
	ct, cu, lt, lu
)
AS SELECT
	F.idflowchart,
	F.paridflowchart,
	F.codeflowchart,
	F.printingorder,
	F.ayear,
	F.title,
	F.nlevel,
	L.description,
	F.fax,
	F.phone,
	F.address,
	F.idcity,
	G.title,
	F.cap,
	F.location,
	F.ct, F.cu, F.lt, F.lu
FROM flowchart F
JOIN flowchartlevel L
	ON L.ayear = F.ayear
	AND L.nlevel = F.nlevel
LEFT OUTER JOIN geo_city G
	ON G.idcity = F.idcity

GO

print 'flowchartview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetvardetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetvardetailview
GO


CREATE      VIEW [assetvardetailview]
(
	idassetvar,
	idassetvardetail,
	yvar,
	nvar,
	idinventoryagency,
	codeinventoryagency,
	inventoryagency,
	variationdescription,
	enactment,
	nenactment,
	enactmentdate,
	variationkind,
	idinv,
	codeinv,
	inventorytree,
	description,
	idinventory,
	inventory,
	amount,
	adate,
	idmot,
	motive,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	assetvardetail.idassetvar,
	assetvardetail.idassetvardetail,
	assetvar.yvar,
	assetvar.nvar,
	assetvar.idinventoryagency,
	inventoryagency.codeinventoryagency,
	inventoryagency.description,
	assetvar.description,
	assetvar.enactment,
	assetvar.nenactment,
	assetvar.enactmentdate,
	CASE
		WHEN assetvar.flag & 1 <> 0 THEN 'N'
		ELSE 'I'
	END,
	assetvardetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
	assetvardetail.description,
	assetvardetail.idinventory,
	inventory.description,
	assetvardetail.amount,
	assetvar.adate,
	assetloadmotive.idmot,
	assetloadmotive.description,
	assetvardetail.cu,
	assetvardetail.ct,
	assetvardetail.lu,
	assetvardetail.lt
FROM assetvardetail
JOIN assetvar
	ON assetvardetail.idassetvar = assetvar.idassetvar
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = assetvar.idinventoryagency
JOIN inventorytree
	ON assetvardetail.idinv = inventorytree.idinv
LEFT OUTER JOIN inventory
	ON inventory.idinventory = assetvardetail.idinventory
LEFT OUTER JOIN assetloadmotive
	ON assetloadmotive.idmot = assetvardetail.idmot




GO

print '[assetvardetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensetaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensetaxview
GO


CREATE             VIEW [expensetaxview]
(
	idexp,
	taxcode,
	nbracket,
	description,
	taxkind,
	taxablegross,
	taxablenet,
	taxableoriginal,
	taxref,
	exemptionquota,
	abatements,
	taxablenumerator,
	taxabledenominator,
	employrate,
	employnumerator,
	employdenominator,
	employtax,
	adminrate,
	adminnumerator,
	admindenominator,
	admintax,
	competencydate,
	datetaxpay,
	ytaxpay,
	ntaxpay,
	idaccmotive_debit,
	idaccmotive_pay,
	idcity,
	city,
	provincecode,
	idfiscaltaxregion,
	fiscaltaxregion,
	idinc,
	yincmov,
	nincmov,
	ayear,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expensetax.idexp,
	expensetax.taxcode,
	expensetax.nbracket,
	tax.description,
	tax.taxkind,
	expensetax.taxablegross,
	expensetax.taxablenet,
	expensetax.taxablegross,-- A cosa serve questo campo???
	tax.taxref,
	expensetax.exemptionquota,
	expensetax.abatements,
	expensetax.taxablenumerator,
	expensetax.taxabledenominator,
	expensetax.employrate,
	expensetax.employnumerator,
	expensetax.employdenominator,
	expensetax.employtax,
	expensetax.adminrate,
	expensetax.adminnumerator,
	expensetax.admindenominator,
	expensetax.admintax,
	expensetax.competencydate,
	CASE config.taxvaliditykind 
		-- data ultima fase di spesa
		WHEN '2' THEN expense.adate 
		WHEN '3' THEN payment.adate 
		WHEN '4' THEN payment.printdate
		WHEN '5' THEN  paymenttransmission.transmissiondate
		WHEN '6' THEN (SELECT MIN(banktransaction.transactiondate)
			FROM banktransaction 
			WHERE banktransaction.kpay=expenselast.kpay)
		ELSE expensetax.competencydate
	END,
	expensetax.ytaxpay,
	expensetax.ntaxpay,
	tax.idaccmotive_debit,
	tax.idaccmotive_pay,
	expensetax.idcity,
	geo_city.title,
	geo_country.province,
	expensetax.idfiscaltaxregion,
	fiscaltaxregion.title,
	expensetax.idinc,
	income.ymov,
	income.nmov,
	expensetax.ayear,
	expensetax.cu,
	expensetax.ct,
	expensetax.lu,
	expensetax.lt
FROM expensetax
JOIN tax
	ON tax.taxcode = expensetax.taxcode
JOIN expense
	ON expensetax.idexp = expense.idexp
JOIN expenselast
	ON expense.idexp = expenselast.idexp 
JOIN config
	ON expense.ymov = config.ayear
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay  
LEFT OUTER JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission =  payment.kpaymenttransmission 
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = expensetax.idcity
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
LEFT OUTER JOIN fiscaltaxregion
	ON fiscaltaxregion.idfiscaltaxregion = expensetax.idfiscaltaxregion
LEFT OUTER JOIN income
	ON income.idinc = expensetax.idinc








GO

print '[expensetaxview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'userenvironmentview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW userenvironmentview
GO
--Pino Rana, elaborazione del 10/08/2005 15:18:07
-- Inserire la CREATE VIEW qui--
CREATE                                                       VIEW [userenvironmentview]
AS
SELECT     
userenvironment.variablename, 
userenvironment.idcustomuser, 
customuser.username, 
userenvironment.value, 
userenvironment.flagadmin, 
userenvironment.kind, 
userenvironment.lu, 
userenvironment.lt
FROM         userenvironment WITH (NOLOCK) LEFT OUTER JOIN
             customuser WITH (NOLOCK) 
             ON userenvironment.idcustomuser = customuser.idcustomuser


GO

print '[userenvironmentview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'securityconditionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW securityconditionview
GO

CREATE              VIEW securityconditionview
(
	idsecuritycondition,
	idrestrictedfunction,
	restrictedfunction,
	tablename,
	operation,
	idcustomgroup,
	customgroup,
	groupname,
	allowcondition,
	denycondition,
	defaultisdeny,
	ct, cu, lt, lu
)
AS SELECT
	SC.idsecuritycondition,
	SC.idrestrictedfunction,
	RF.description,
	SC.tablename,
	SC.operation,
	SC.idcustomgroup,
	CG.description,
	CG.groupname,
	SC.allowcondition,
	SC.denycondition,
	SC.defaultisdeny,
	SC.ct, SC.cu, SC.lt, SC.lu
FROM securitycondition SC
JOIN restrictedfunction RF
	ON RF.idrestrictedfunction = SC.idrestrictedfunction
JOIN customgroup CG
	ON CG.idcustomgroup = SC.idcustomgroup

GO

print 'securityconditionview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'pettycashopunderwritingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW pettycashopunderwritingview
GO


CREATE       VIEW [pettycashopunderwritingview]
(
	idunderwriting,
	codeunderwriting,
	underwriting,
	idpettycash,
	pettycash,
	pettycode,
	yoperation,
	noperation,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	amount,
	adate,
	idexp,
	nrestore,
	yrestore,
	adaterestore,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	PCOU.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	PCO.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	PCO.yoperation,
	PCO.noperation,
	PCO.idfin,
	fin.codefin,
	fin.title,
	PCO.idupb,
	upb.codeupb,
	upb.title,
	PCO.idreg,
	registry.title,
	PCO.idman,
	manager.title,
	PCO.doc,
	PCO.docdate,
	PCO.description,
	PCO.amount,
	PCO.adate,
	PCO.idexp,
	PCO.nrestore,
	PCO.yrestore,
	restoreop.adate,
	PCOU.cu,
	PCOU.ct,
	PCOU.lu,
	PCOU.lt
FROM pettycashoperationunderwriting PCOU
JOIN pettycash
	ON pettycash.idpettycash = PCOU.idpettycash
JOIN pettycashoperation PCO
	ON PCO.idpettycash = PCOU.idpettycash
	AND PCO.yoperation = PCOU.yoperation
	AND PCO.noperation = PCOU.noperation
JOIN underwriting
	ON underwriting.idunderwriting = PCOU.idunderwriting
LEFT OUTER JOIN fin
	ON fin.idfin = PCO.idfin
LEFT OUTER JOIN upb
	on upb.idupb = PCO.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = PCO.idreg
LEFT OUTER JOIN manager
	ON manager.idman = PCO.idman
LEFT OUTER JOIN pettycashoperation restoreop 
	ON restoreop.yoperation = PCO.yrestore 
	AND restoreop.noperation = PCO.nrestore 
	AND restoreop.idpettycash = PCO.idpettycash 
	AND (restoreop.flag& 2)<>0 




GO

print '[pettycashopunderwritingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxpayexpenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxpayexpenseview
GO

CREATE                VIEW taxpayexpenseview 
(
	ytaxpay,
	ntaxpay,
	taxcode,
	taxref,
	taxdescription,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	autokind,
	idpayment,
	totflag,
	flagarrear,
	expiration,
	adate,
	txt,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	taxpayexpense.ytaxpay,
	taxpayexpense.ntaxpay,
	taxpayexpense.taxcode,
	tax.taxref,
	tax.description,
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman, 
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
  	expense.autokind,
	expense.idpayment,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration,
	expense.adate,
	expense.txt,
	taxpayexpense.cu,
	taxpayexpense.ct,
	taxpayexpense.lu,
	taxpayexpense.lt
FROM taxpayexpense
JOIN expense 
	ON taxpayexpense.idexp = expense.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear 
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expenselast
	ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN tax
	ON tax.taxcode = taxpayexpense.taxcode


GO

print 'taxpayexpenseview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'locationsortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW locationsortingview
GO


CREATE              VIEW [locationsortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	idlocation,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	locationsorting.idsor,
	sorting.sortcode,
	sorting.description,
	locationsorting.idlocation,
	locationsorting.cu,
	locationsorting.ct,
	locationsorting.lu,
	locationsorting.lt
FROM locationsorting
JOIN sorting
	ON sorting.idsor = locationsorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind



GO

print '[locationsortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensetaxofficialview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensetaxofficialview
GO


CREATE         VIEW expensetaxofficialview
(
	idreg,
	registry,
	idexp,
	idexpensetaxofficial,
	taxcode,
	taxref,
	description,
	taxkind,
	ymov,
	nmov,
	adate,
	expensedescription,
	phase,
	nbracket,
	ayear,
	exemptionquota,
	abatements,
	taxablenumerator,
	taxabledenominator,
	taxablegross,
	taxablenet,
	employrate,
	employnumerator,
	employdenominator,
	employtax,
	adminrate,
	adminnumerator,
	admindenominator,
	admintax,
	idcity,
	city,
	provincecode,
	idfiscaltaxregion,
	fiscaltaxregion,
	start,
	stop,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	registry.idreg,
	registry.title,
	expensetaxofficial.idexp,
	expensetaxofficial.idexpensetaxofficial,
	expensetaxofficial.taxcode,
	tax.taxref,
	tax.description,
	tax.taxkind,
	expense.ymov,
	expense.nmov,
	expense.adate,
	expense.description,
	expensephase.description,
	expensetaxofficial.nbracket,
	expensetaxofficial.ayear,
	expensetaxofficial.exemptionquota,
	expensetaxofficial.abatements,
	expensetaxofficial.taxablenumerator,
	expensetaxofficial.taxabledenominator,
	expensetaxofficial.taxablegross,
	expensetaxofficial.taxablenet,
	expensetaxofficial.employrate,
	expensetaxofficial.employnumerator,
	expensetaxofficial.employdenominator,
	expensetaxofficial.employtax,
	expensetaxofficial.adminrate,
	expensetaxofficial.adminnumerator,
	expensetaxofficial.admindenominator,
	expensetaxofficial.admintax,
	expensetaxofficial.idcity,
	geo_city.title,
	geo_country.province,
	expensetaxofficial.idfiscaltaxregion,
	fiscaltaxregion.title,
	expensetaxofficial.start,
	expensetaxofficial.stop,
	expensetaxofficial.ct,
	expensetaxofficial.cu,
	expensetaxofficial.lt,
	expensetaxofficial.lu
FROM expensetaxofficial
JOIN tax
	ON tax.taxcode = expensetaxofficial.taxcode
JOIN expense
	ON expense.idexp = expensetaxofficial.idexp
JOIN registry
	ON registry.idreg = expense.idreg
JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = expensetaxofficial.idcity
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
LEFT OUTER JOIN fiscaltaxregion
	ON fiscaltaxregion.idfiscaltaxregion = expensetaxofficial.idfiscaltaxregion



GO

print 'expensetaxofficialview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxpaymentpartsetupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxpaymentpartsetupview
GO



CREATE              VIEW taxpaymentpartsetupview 
	(
  taxcode,
  taxref,
  taxkind,
  ayear,
  idreg,
  registry,
  percentage,
	cu,
	ct,
	lu,
	lt
  )
  AS SELECT
  taxpaymentpartsetup.taxcode,
  tax.taxref,
  tax.description,
  taxpaymentpartsetup.ayear,
  taxpaymentpartsetup.idreg,
  registry.title,
	taxpaymentpartsetup.percentage,
  taxpaymentpartsetup.cu,
  taxpaymentpartsetup.ct,
  taxpaymentpartsetup.lu,
  taxpaymentpartsetup.lt
  FROM taxpaymentpartsetup (NOLOCK)
JOIN tax (NOLOCK)
  ON tax.taxcode = taxpaymentpartsetup.taxcode
  JOIN registry (NOLOCK)
  ON registry.idreg = taxpaymentpartsetup.idreg






GO

print 'taxpaymentpartsetupview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'moneytotransfer_available_view') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW moneytotransfer_available_view
GO

--clear_table_info'moneytotrasfer_available_view'
--select * from moneytotrasfer_available_view order by idtreasurer
CREATE    VIEW moneytotransfer_available_view 
	(
	y,   --anno
	n,    -- n.assegnazione o variazione
	kind, -- tipo (assegnazione o storno)
	adate,
	ndet,  --idinc o rownum in caso di storno
	nphase,
	phase,
	ymov,
	nmov,
	--parte comune
	idunderwriting,  --finanziamento di destinazione (ossia IN CUI bisogna girofondare)
	underwriting,
	idfin,			--bilancio di destinazione 
	codefin,
	finance,
	
	idupb,		--upb di destinazione 
	codeupb,
	upb,
	idtreasurer,	--cassiere di destinazione 
	treasurer,
	
	idupbincome,	-- upb di provenienza (ossia DA CUI bisogna girofondare)
	codeupbincome,
	upbincome,	
	idtreasurerincome, --cassiere di provenienza
	treasurerincome,
	idfinincome,			--bilancio di provenienza 
	codefinincome,	
	financeincome,
	description,
	amount,
	--	> Importo da Girofondare: importo che non è stato ancora girofondato;
	moneytotransfer,
	--	> Importo Girofondato: importo per cui è stato fatto il girofondo ala cassiere di destinazione;
	moneytransfered,
	idsor01,idsor02,idsor03,idsor04,idsor05
	)
	AS SELECT
	proceedspart.yproceedspart, 
	proceedspart.nproceedspart,
	'assegnazione',
	proceedspart.adate,

	proceedspart.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	income.idunderwriting, --finanziamento di destinazione (ossia IN CUI bisogna girofondare)
	underwriting.title,
	fin_dest.idfin,		--bilancio di destinazione
	fin_dest.codefin,
	fin_dest.title,
	
	U_dest.idupb, --upb di destinazione
	U_dest.codeupb,
	U_dest.title,
	T_dest.idtreasurer,		--cassiere di destinazione
	T_dest.description,
	U_origin.idupb,		--upb di origine
	U_origin.codeupb,
	U_origin.title,
	T_origin.idtreasurer,	--cassiere di origine (ossia quello della reversale con cui è effettuato l'incasso)
	T_origin.description,
	fin_origin.idfin,		--bilancio di origine
	fin_origin.codefin,
	fin_origin.title,
	
	proceedspart.description+'-'+income.description,
	proceedspart.amount,
	
	
	-- > moneytotransfer = Importo da Girofondare: importo che non è stato ancora girofondato;
		proceedspart.amount - 	ISNULL(	(SELECT SUM(moneytransfer.amount) FROM moneytransfer
												WHERE moneytransfer.nproceedspart = proceedspart.nproceedspart
												and moneytransfer.yproceedspart = proceedspart.yproceedspart)
												,0)
		
	,
	--	> moneytransfered = Importo Girofondato: importo per cui è stato fatto il girofondo la cassiere di destinazione;
		( SELECT SUM(moneytransfer.amount) FROM moneytransfer
						WHERE moneytransfer.nproceedspart = proceedspart.nproceedspart
						and moneytransfer.yproceedspart = proceedspart.yproceedspart)
		
	,
	U_dest.idsor01, --upb di destinazione dell'assegnazione
	U_dest.idsor02,
	U_dest.idsor03,
	U_dest.idsor04,
	U_dest.idsor05
	
	FROM proceedspart (NOLOCK)
	JOIN fin fin_dest (NOLOCK)
		ON fin_dest.idfin = proceedspart.idfin
	JOIN upb U_dest (NOLOCK)
		ON U_dest.idupb = proceedspart.idupb
	LEFT OUTER JOIN treasurer T_dest (NOLOCK)
		ON T_dest.idtreasurer = U_dest.idtreasurer	
	JOIN income (NOLOCK)
		ON income.idinc = proceedspart.idinc
	JOIN incomeyear (NOLOCK)
		ON incomeyear.idinc = proceedspart.idinc
	JOIN upb U_origin (NOLOCK)
		ON U_origin.idupb = incomeyear.idupb
	JOIN fin fin_origin (NOLOCK)
		ON fin_origin.idfin = incomeyear.idfin
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	LEFT OUTER JOIN underwriting (NOLOCK)
		ON underwriting.idunderwriting = income.idunderwriting 	
	JOIN incomelast (NOLOCK)
		ON incomelast.idinc = proceedspart.idinc	
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN treasurer T_origin (NOLOCK)
		ON T_origin.idtreasurer = proceeds.idtreasurer	
	WHERE T_origin.idtreasurer <> U_dest.idtreasurer
UNION ALL
	select	FV.yvar,
			FV.nvar,
			'storno',
			FV.adate,
			FVD_dest.rownum,
			null,null,null,null,
			--parte comune
			
	uw_dest.idunderwriting,  --finanziamento di destinazione (ossia IN CUI bisogna girofondare)
	uw_dest.title,
	f_dest.idfin,			--bilancio di destinazione 
	f_dest.codefin,
	f_dest.title,
	
	u_dest.idupb,		--upb di destinazione 
	u_dest.codeupb,
	u_dest.title,
	t_dest.idtreasurer,	--cassiere di destinazione 
	t_dest.description,
	
	u_origin.idupb,	-- upb di provenienza (ossia DA CUI bisogna girofondare)
	u_origin.codeupb,
	u_origin.title,	

	t_origin.idtreasurer, --cassiere di provenienza
	t_origin.description,
	
	f_origin.idfin,			--bilancio di provenienza 
	f_origin.codefin,
	f_origin.title,

	FVD_dest.description+'-'+FV.description,
	FVD_dest.amount,
	--	> Importo da Girofondare: importo che non è stato ancora girofondato;
		FVD_dest.amount - 	ISNULL(	(SELECT SUM(moneytransfer.amount) FROM moneytransfer
												WHERE moneytransfer.yvar = FVD_dest.yvar
												and moneytransfer.nvar = FVD_dest.nvar
												and moneytransfer.rownum = FVD_dest.rownum
								) ,0),
	--	> Importo Girofondato: importo per cui è stato fatto il girofondo al cassiere di destinazione;
		ISNULL(	(SELECT SUM(moneytransfer.amount) FROM moneytransfer
												WHERE moneytransfer.yvar = FVD_dest.yvar
												and moneytransfer.nvar = FVD_dest.nvar
												and moneytransfer.rownum = FVD_dest.rownum)
												,0),
	u_dest.idsor01,u_dest.idsor02,u_dest.idsor03,u_dest.idsor04,u_dest.idsor05
	
	from finvar FV (NOLOCK)
		join finvardetail FVD_dest (NOLOCK)
			ON FVD_dest.yvar=FV.yvar and FVD_dest.nvar=FV.nvar AND FVD_dest.amount > 0
		join fin f_dest (NOLOCK)
			on FVD_dest.idfin=f_dest.idfin and f_dest.flag&1<>0
		join upb u_dest (NOLOCK)
			on FVD_dest.idupb=u_dest.idupb 
		join treasurer t_dest (NOLOCK)
			on u_dest.idtreasurer=t_dest.idtreasurer 
		left outer join underwriting uw_dest (NOLOCK)
			on FVD_dest.idunderwriting=uw_dest.idunderwriting 
		join finvardetail FVD_origin (NOLOCK)
			ON FVD_origin.yvar=FV.yvar and FVD_origin.nvar=FV.nvar AND FVD_origin.amount < 0
		join fin f_origin  (NOLOCK)
			on FVD_origin.idfin=f_origin.idfin and f_origin.flag&1<>0
		join upb u_origin (NOLOCK)
			on FVD_origin.idupb=u_origin.idupb 
		join treasurer t_origin (NOLOCK)
			on u_origin.idtreasurer=t_origin.idtreasurer 
	where FV.moneytransfer='S'
AND FV.idfinvarstatus  = 5


GO

print 'moneytotransfer_available_view OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'stocklocationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW stocklocationview
GO

CREATE         VIEW [stocklocationview] 
(
	idstocklocation,
	stocklocationcode,
	nlevel,
	leveldescr,
	paridstocklocation,
	description,
	active,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	stocklocation.idstocklocation,
	stocklocation.stocklocationcode,
	stocklocation.nlevel,
	stocklocationlevel.description,
	stocklocation.paridstocklocation,
	stocklocation.description,
	stocklocation.active,
	stocklocation.cu, 
	stocklocation.ct, 
	stocklocation.lu,
	stocklocation.lt 
FROM stocklocation
JOIN stocklocationlevel
	ON stocklocationlevel.nlevel = stocklocation.nlevel





GO

print '[stocklocationview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandateexpavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandateexpavailable
GO

--Pino Rana, elaborazione del 10/08/2005 15:17:43
-- Rusciano G. 01.12.2005
CREATE        VIEW [mandateexpavailable]
(
	idmankind,
	yman,
	nman,
	mankind,
	registry,
	description,
	doc,
	docdate,
	adate,
	taxabletotal,
	ivatotal,
	detailtaxabletotal,
	detailivatotal,
	linkedtotal,
	residual,
	active,
	flagintracom,
	idman,
	manager,
	idmandatestatus,
	mandatestatus,
	isrequest
)
AS SELECT
	mandate.idmankind,
	mandate.yman,
	mandate.nman,
	mandatekind.description,
	registry.title,
	mandate.description,
	mandate.doc,
	mandate.docdate,
	mandate.adate,
	totmandateview.taxabletotal, -- totale imponibile su tutto l'ordine
	totmandateview.ivatotal,--totale iva su tutto l'ordine
	totmandatedetailview.taxabletotal,--totale imponibile dei dettagli associati a movimenti di spesa
	totmandatedetailview.ivatotal,--totale iva dei dettagli associati a movimenti di spesa
	--totale movimenti = somma (importo) del join di ordinegenericomovspesa con  spesa + 
        --somma (importo) del join di ordinegenericomovspesa con variazionespesa
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0)
	FROM expensemandate mov (NOLOCK)
	JOIN expense s (NOLOCK)
	ON s.idexp = mov.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
	ON expensetotal_firstyear.idexp = s.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	WHERE mov.idmankind = mandate.idmankind
	AND mov.yman = mandate.yman
	AND mov.nman = mandate.nman) +
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM expensemandate mov (NOLOCK)
	JOIN expense s (NOLOCK)
	ON s.idexp = mov.idexp
	JOIN expensevar v (NOLOCK)
	ON v.idexp = mov.idexp
	WHERE mov.idmankind = mandate.idmankind
	AND mov.yman = mandate.yman
	AND mov.nman = mandate.nman)
	,2)),
	--residuo :somma dei dett. ordine non contabilizzati o annullati
	(SELECT CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (mandatedetail.idexp_taxable IS  NULL) AND ( mandatedetail.idexp_iva IS  NOT NULL)
			THEN
			     ROUND((ISNULL(mandatedetail.taxable,0) * ISNULL(mandatedetail.npackage,mandatedetail.number))  ,2)
			WHEN ( mandatedetail.idexp_iva IS NULL) AND (mandatedetail.idexp_taxable IS  NOT NULL)
			THEN
			     ROUND( ISNULL(mandatedetail.tax,0)  ,2)
			WHEN ( mandatedetail.idexp_iva IS  NULL) AND (mandatedetail.idexp_taxable IS  NULL)
			THEN
			     ROUND((ISNULL(mandatedetail.taxable,0) * ISNULL(mandatedetail.npackage,mandatedetail.number) 
				 + ISNULL(mandatedetail.tax,0))  ,2)
			ELSE   0
		    END
		   ),0)
		)
	FROM mandatedetail 
	WHERE mandatedetail.idmankind = mandate.idmankind
	AND  mandatedetail.yman = mandate.yman
	AND  mandatedetail.nman = mandate.nman
	AND mandatedetail.stop is null),
	mandate.active,
	mandate.flagintracom,
	mandate.idman,
	manager.title,
	mandate.idmandatestatus,
	mandatestatus.description ,
	mandatekind.isrequest
	FROM mandate (NOLOCK)
	JOIN mandatekind
	ON mandatekind.idmankind = mandate.idmankind
	JOIN totmandateview (NOLOCK)
	ON totmandateview.idmankind = mandate.idmankind
	AND totmandateview.yman = mandate.yman
	AND totmandateview.nman = mandate.nman
	LEFT OUTER JOIN totmandatedetailview (NOLOCK)
	ON totmandatedetailview.idmankind = mandate.idmankind
	AND totmandatedetailview.yman = mandate.yman
	AND totmandatedetailview.nman = mandate.nman
	LEFT OUTER JOIN registry (NOLOCK)	
	ON registry.idreg = mandate.idreg
	LEFT OUTER JOIN manager (NOLOCK)	
	ON manager.idman = mandate.idman
	LEFT OUTER JOIN mandatestatus (NOLOCK)	
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
	

GO

print '[mandateexpavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'moneytransferview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW moneytransferview
GO



CREATE     VIEW [moneytransferview]
(
ytransfer,
ntransfer,
idtreasurersource,
treasurersource,
idtreasurerdest,
treasurerdest,
amount,
adate,
description,
nproceedspart,
yproceedspart,
yvar,
nvar,
rownum,
cu,
ct,
lu,
lt
)
AS SELECT
moneytransfer.ytransfer,
moneytransfer.ntransfer,
moneytransfer.idtreasurersource,
TRS.description,
moneytransfer.idtreasurerdest,
TRD.description,
moneytransfer.amount,
moneytransfer.adate,
moneytransfer.description,
moneytransfer.nproceedspart,
moneytransfer.yproceedspart,
moneytransfer.yvar,
moneytransfer.nvar,
moneytransfer.rownum,
moneytransfer.cu,
moneytransfer.ct,
moneytransfer.lu,
moneytransfer.lt
FROM moneytransfer
JOIN treasurer TRS
	ON moneytransfer.idtreasurersource = TRS.idtreasurer
JOIN treasurer TRD
	ON moneytransfer.idtreasurerdest = TRD.idtreasurer



GO

print '[moneytransferview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finvarview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finvarview
GO


CREATE         VIEW [finvarview]
(
	yvar,
	nvar,
	adate,
	description,
	enactment,
	enactmentdate,
	flagcredit,
	flagprevision,
	flagproceeds,
	flagsecondaryprev,
	nenactment,
	official,
	nofficial,
	variationkind,
	variationkinddescr,
	incometotal,
	expensetotal,
	total,
	ct,
	cu,
	lt,
	lu,
	idfinvarstatus,
	finvarstatus,
	reason,
	idenactment,
	yenactment,
	enactmentnumber,
	idman,
	manager,
	limit,
	statusimage,
	listingorder,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idfinvarkind,
	codefinvarkind,
	finvarkind,
	moneytransfer
)
AS SELECT
	finvar.yvar,
	finvar.nvar,
	finvar.adate,
	finvar.description,
	finvar.enactment,
	finvar.enactmentdate,
	finvar.flagcredit,
	finvar.flagprevision,
	finvar.flagproceeds,
	finvar.flagsecondaryprev,
	finvar.nenactment,
	finvar.official,
	finvar.nofficial,
	finvar.variationkind,
	variationkind.description,
	ISNULL(
		(SELECT SUM(amount)
		FROM finvardetail D
		JOIN fin F
			ON D.idfin = F.idfin
		WHERE D.yvar = finvar.yvar
			AND D.nvar = finvar.nvar
		AND (F.flag & 1) = 0)
	,0),
	ISNULL(
		(SELECT SUM(amount)
		FROM finvardetail D
		JOIN fin F
			ON D.idfin = F.idfin
		WHERE D.yvar = finvar.yvar
			AND D.nvar = finvar.nvar
		AND (F.flag & 1) <> 0)
	,0),
	ISNULL(
		(SELECT SUM(amount)
		FROM finvardetail D
		JOIN fin F
			ON D.idfin = F.idfin
		WHERE D.yvar = finvar.yvar
			AND D.nvar = finvar.nvar
		AND (F.flag & 1) = 0)
	,0) -
	ISNULL(
		(SELECT SUM(amount)
		FROM finvardetail D
		JOIN fin F
			ON D.idfin = F.idfin
		WHERE D.yvar = finvar.yvar
			AND D.nvar = finvar.nvar
		AND (F.flag & 1) <> 0)
	,0),
	finvar.ct,
	finvar.cu,
	finvar.lt,
	finvar.lu,
	finvar.idfinvarstatus,
	finvarstatus.description,
	finvar.reason,
	finvar.idenactment,
	enactment.yenactment,
	enactment.nenactment,
	finvar.idman,
	manager.title,
	finvar.limit,
	(case when finvar.idfinvarstatus=1 then '<center><img src="Immagini/bozza.png" title="Bozza" alt="Bozza"/></center>'
		  when finvar.idfinvarstatus=2 then '<center><img src="Immagini/richiesta.png" title="Richiesta" alt="Richiesta"/></center>'
		  when finvar.idfinvarstatus=3 then '<center><img src="Immagini/dacorreggere.png" title="Da Correggere" alt="Da Correggere"/></center>'
		  when finvar.idfinvarstatus=4 then '<center><img src="Immagini/inserito.png" title="Inserito" alt="Inserito"/></center>'
		  when finvar.idfinvarstatus=5 then '<center><img src="Immagini/approvato.png" title="Approvato" alt="Approvato"/></center>'
		  when finvar.idfinvarstatus=6 then '<center><img src="Immagini/annullato.png" title="Annullato" alt="Annullato"/></center>'
		  end
		  ),
	finvarstatus.listingorder,
	finvar.idsor01,
	finvar.idsor02,
	finvar.idsor03,
	finvar.idsor04,
	finvar.idsor05,
	finvarkind.idfinvarkind,
	finvarkind.codevarkind,
	finvarkind.description,
	finvar.moneytransfer
FROM finvar with (nolock)
JOIN variationkind with (nolock)
	ON variationkind.idvariationkind = finvar.variationkind
LEFT OUTER JOIN finvarstatus with (nolock)
	ON finvarstatus.idfinvarstatus = finvar.idfinvarstatus
LEFT OUTER JOIN enactment with (nolock)
	ON enactment.idenactment = finvar.idenactment
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = finvar.idman
LEFT OUTER JOIN finvarkind
	ON finvar.idfinvarkind = finvarkind.idfinvarkind


GO

print '[finvarview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'stocklocationusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW stocklocationusable
GO

CREATE        VIEW [stocklocationusable]
(
	idstocklocation,
	stocklocationcode,
	nlevel,
	leveldescr,
	paridstocklocation,
	description,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	stocklocation.idstocklocation,
	stocklocation.stocklocationcode,
	stocklocation.nlevel,
	stocklocationlevel.description,
	stocklocation.paridstocklocation,
	stocklocation.description,
	stocklocation.cu, 
	stocklocation.ct, 
	stocklocation.lu,
	stocklocation.lt 
FROM stocklocation
JOIN stocklocationlevel
	ON stocklocationlevel.nlevel = stocklocation.nlevel
WHERE stocklocationlevel.flag & 2 <> 0
	AND stocklocation.idstocklocation NOT IN
		(SELECT paridstocklocation FROM stocklocation
		WHERE paridstocklocation IS NOT NULL)




GO

print '[stocklocationusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'upbfinyearview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW upbfinyearview
GO


CREATE      VIEW [upbfinyearview] (
	idupb,
	codeupb,	
	upb,
	idfin,
	codefin,
	fin,
	flag, 
	finpart,
	ayear,
	initialprevision,
	varprevision,
	actualprevision,
	initialsecondaryprev,
	varsecondaryprev,
	actualsecondaryprev,
	totcreditpart,
	totpreceedspart,
	assessment,		--accertamenti	
	appropriation,	--impegni
	proceeds,
	payment,
	incomeprevavailable,	-- disp ad accertare
	expenseprevavailable,	-- disp. a impegnare
	proceedsprevavailable,	-- disp. ad incassare,
	paymentprevavailable,	-- disp a pagare
	creditavailable,	--crediti disponibili
	proceedsavailable,	-- incassi disponibili,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	upbtotal.idupb,
	upb.codeupb,
	upb.title,
	upbtotal.idfin,
	fin.codefin,
	fin.title,
	fin.flag, 
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.ayear,
	-- initialprevision
	ISNULL(upbtotal.currentprev,0),
	-- varprevision
	ISNULL(upbtotal.previsionvariation,0),
	-- actualprevision,
	ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0),
	-- initialsecondaryprev
	ISNULL(upbtotal.currentsecondaryprev,0),
	-- varsecondaryprev
	ISNULL(upbtotal.secondaryvariation,0),
	-- actualsecondaryprev
	ISNULL(upbtotal.currentsecondaryprev,0) + ISNULL(upbtotal.secondaryvariation,0),
	-- totcreditpart
	ISNULL(upbtotal.totcreditpart,0),
	-- tonpreceedspart
	ISNULL(upbtotal.totproceedspart,0),
	--assessment = accertamenti
	Case when (( fin.flag & 1) = 0)
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Incomefinphase.totalcompetency,0)
			ELSE
					ISNULL(Incomefinphase.totalcompetency,0) + ISNULL(Incomefinphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- appropriation = impegni
	Case when (( fin.flag & 1) <> 0) 
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) 
				THEN
					ISNULL(Expensefinphase.totalcompetency,0)
				ELSE
					ISNULL(Expensefinphase.totalcompetency,0) + ISNULL(Expensefinphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- proceeds
	Case when (( fin.flag & 1) = 0)
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Incomemaxphase.totalcompetency,0)
			ELSE
					ISNULL(Incomemaxphase.totalcompetency,0) + ISNULL(Incomemaxphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- payment 
	Case when (( fin.flag & 1) <> 0) 
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) 
				THEN
					ISNULL(Expensemaxphase.totalcompetency,0)
				ELSE
					ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- incomeprevavailable = disp ad accertare
	Case when (( fin.flag & 1) = 0)
		Then
			ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) 
			- (CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Incomefinphase.totalcompetency,0)
				ELSE
						ISNULL(Incomefinphase.totalcompetency,0) + ISNULL(Incomefinphase.totalarrears,0)
				END)
		Else 0
	End	,
	-- expenseprevavailable = disp. a impegnare
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) 
			- (	CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Expensefinphase.totalcompetency,0)
				ELSE
					ISNULL(Expensefinphase.totalcompetency,0) + ISNULL(Expensefinphase.totalarrears,0)
				END)
		Else 0		
	End,
	-- proceedspreavailable = disp. ad incassare
		Case when (( fin.flag & 1) = 0) 
		Then
			ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) 
			- (ISNULL(Incomemaxphase.totalcompetency,0) + ISNULL(Incomemaxphase.totalarrears,0))
		Else 0
	End	,
	-- paymentpreavailable = disp a pagare
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) 
			- (ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0))
		Else 0		
	End,
	-- creditavailable
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbtotal.totcreditpart,0)+ ISNULL(upbtotal.creditvariation,0) - ISNULL(Expensefinphase.totalcompetency,0)
		Else 0	
	End,
	-- proceedsavailable 
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbtotal.totproceedspart,0) + ISNULL(upbtotal.proceedsvariation,0) - (	ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0))
			
		Else 0	
	End,
	UPB.idsor01,
	UPB.idsor02,
	UPB.idsor03,
	UPB.idsor04,
	UPB.idsor05
FROM upbtotal 
CROSS JOIN uniconfig
JOIN upb
	ON upbtotal.idupb = upb.idupb
JOIN fin
	ON upbtotal.idfin = fin.idfin
JOIN finlast 
	ON finlast.idfin = fin.idfin
LEFT OUTER JOIN upbincometotal Incomefinphase
	ON Incomefinphase.idupb = upbtotal.idupb
	AND Incomefinphase.idfin = upbtotal.idfin
	AND Incomefinphase.nphase = uniconfig.incomefinphase
LEFT OUTER JOIN upbexpensetotal Expensefinphase
	ON Expensefinphase.idupb = upbtotal.idupb
	AND Expensefinphase.idfin = upbtotal.idfin
	AND Expensefinphase.nphase = uniconfig.expensefinphase
LEFT OUTER JOIN upbincometotal Incomemaxphase
	ON  Incomemaxphase.idupb = upbtotal.idupb
	AND Incomemaxphase.idfin = upbtotal.idfin
	AND Incomemaxphase.nphase = (select max(nphase) from incomephase)
LEFT OUTER JOIN upbexpensetotal Expensemaxphase
	ON  Expensemaxphase.idupb = upbtotal.idupb
	AND Expensemaxphase.idfin = upbtotal.idfin
	AND Expensemaxphase.nphase = (select max(nphase) from expensephase)
	


GO

print '[upbfinyearview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'listview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW listview
GO


CREATE VIEW [listview](
	idlist,
	description,
	intcode,
	intbarcode,
	extcode,
	extbarcode,
	validitystop,
	active,
	idpackage,
	package,
	idunit,
	unit,
	unitsforpackage,
	has_expiry,
	idlistclass,
	codelistclass,
	listclass,
	pic,
	timesupply,
	nmaxorder,
	authrequired,
	assetkind
)
AS 
SELECT 
	list.idlist,
	list.description,
	list.intcode,
	list.intbarcode,
	list.extcode,
	list.extbarcode,
	list.validitystop,
	list.active,
	list.idpackage,
	package.description,
	list.idunit,
	unit.description,
	list.unitsforpackage,
	list.has_expiry,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	list.pic,
	list.timesupply,
	list.nmaxorder,
	listclass.authrequired,
	listclass.assetkind             
FROM list
JOIN listclass
	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN unit
	ON list.idunit = unit.idunit
LEFT OUTER JOIN package
	ON list.idpackage = package.idpackage
	



GO

print '[listview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'stocklocationunusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW stocklocationunusable
GO

CREATE         VIEW [stocklocationunusable]
(
	idstocklocation,
	stocklocationcode,
	nlevel,
	leveldescr,
	paridstocklocation,
	description,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	stocklocation.idstocklocation,
	stocklocation.stocklocationcode,
	stocklocation.nlevel,
	stocklocationlevel.description,
	stocklocation.paridstocklocation,
	stocklocation.description,
	stocklocation.cu, 
	stocklocation.ct, 
	stocklocation.lu,
	stocklocation.lt 
FROM stocklocation
JOIN stocklocationlevel
	ON stocklocationlevel.nlevel = stocklocation.nlevel
WHERE stocklocationlevel.flag & 2 <> 2
	OR stocklocation.idstocklocation IN
		(SELECT paridstocklocation FROM stocklocation
		WHERE paridstocklocation IS NOT NULL)




GO

print '[stocklocationunusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'incomevarview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW incomevarview
GO


CREATE           VIEW [incomevarview]
(
	idinc,
	nvar,
	yvar,
	nphase,
	phase,
	ymov,
	nmov,
	description,
	amount,
	doc,
	docdate,
	adate,
	transferkind,
	autokind,
	cu,
	ct,
	lu,
	lt,
	codefin,
	finance,
	codeupb,
	upb,
	idunderwriting,
	codeunderwriting,
	underwriting,
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	movkind,
	kproceedstransmission,
	kpro,
	ypro,
	npro,
	kproceedstransmission_orig,
	idman,
	idtreasurer,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	incomevar.idinc,
	incomevar.nvar,
	incomevar.yvar,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	incomevar.description,
	incomevar.amount,
	incomevar.doc,
	incomevar.docdate,
	incomevar.adate,
	incomevar.transferkind,
	incomevar.autokind,
	incomevar.cu,
	incomevar.ct,
	incomevar.lu,
	incomevar.lt,
	fin.codefin,
	fin.title,
	upb.codeupb,
	upb.title,
	income.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	incomevar.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	incomevar.yinv,
	incomevar.ninv,
	incomevar.movkind,
	incomevar.kproceedstransmission,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	proceeds.kproceedstransmission,
	income.idman,
	proceeds.idtreasurer,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
FROM incomevar (NOLOCK)
JOIN income (NOLOCK)
	ON income.idinc = incomevar.idinc
JOIN incomephase (NOLOCK)
	ON incomephase.nphase = income.nphase
JOIN incomeyear (NOLOCK)
	ON incomeyear.idinc= income.idinc
	AND incomeyear.ayear= incomevar.yvar
LEFT OUTER JOIN incomelast (NOLOCK)
	ON incomelast.idinc= income.idinc
LEFT OUTER JOIN proceeds (NOLOCK)
	ON proceeds.kpro = incomelast.kpro
LEFT OUTER JOIN upb (NOLOCK)
	ON upb.idupb= incomeyear.idupb
LEFT OUTER JOIN fin (NOLOCK)
	ON fin.idfin= incomeyear.idfin
LEFT OUTER JOIN invoicekind
	ON incomevar.idinvkind = invoicekind.idinvkind
LEFT OUTER JOIN underwriting
	ON income.idunderwriting = underwriting.idunderwriting	
	





GO

print '[incomevarview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'pettycashsetupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW pettycashsetupview
GO




CREATE      VIEW pettycashsetupview 
(
	idpettycash,
	pettycash,
	pettycode,
	ayear,
	registrymanager,
	manager,
	idfinincome,
	finincomecode,
	finincometitle,
	idfinexpense,
	finexpensecode,
	finexpensetitle,
	amount,
	autoclassify,
	idacc,
	codeacc,
	account,
	flagmov,
	flag,
	idupb,
	upb,
	cu,
	ct,
	lu,
	lt,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
	pettycashsetup.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	pettycashsetup.ayear,
	pettycashsetup.registrymanager,
	registry.title,
	pettycashsetup.idfinincome,
	bilancioentrata.codefin,
	bilancioentrata.title,
	pettycashsetup.idfinexpense,
	bilanciospesa.codefin,
	bilanciospesa.title,
	pettycashsetup.amount,
	pettycashsetup.autoclassify,
	pettycashsetup.idacc,
	account.codeacc,
	account.title,
	CASE
		WHEN ((pettycashsetup.flag&1)=0) THEN 'S'
		WHEN ((pettycashsetup.flag&1)<>0) THEN 'N'
	END, 
	pettycashsetup.flag,
	pettycashsetup.idupb,
	upb.title,
	pettycashsetup.cu,
	pettycashsetup.ct,
	pettycashsetup.lu,
	pettycashsetup.lt,
	isnull(pettycash.idsor01,upb.idsor01),
	isnull(pettycash.idsor02,upb.idsor02),
	isnull(pettycash.idsor03,upb.idsor03),
	isnull(pettycash.idsor04,upb.idsor04),
	isnull(pettycash.idsor05,upb.idsor05)
FROM pettycashsetup 
LEFT OUTER JOIN registry 
	ON registry.idreg = pettycashsetup.registrymanager
LEFT OUTER JOIN pettycash 
	ON pettycash.idpettycash = pettycashsetup.idpettycash
LEFT OUTER JOIN fin bilancioentrata 
	ON bilancioentrata.idfin = pettycashsetup.idfinincome
LEFT OUTER JOIN fin bilanciospesa 
	ON bilanciospesa.idfin = pettycashsetup.idfinexpense
LEFT OUTER JOIN account 
	ON account.idacc = pettycashsetup.idacc
LEFT OUTER JOIN upb
	ON upb.idupb = pettycashsetup.idupb







GO

print 'pettycashsetupview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimateview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimateview
GO



CREATE      VIEW [estimateview]
(
	idestimkind,
	yestim,
	nestim,
	estimkind,
	idreg,
	registry,
	registryreference,
	description,
	idman,
	manager,
	deliveryexpiration,
	deliveryaddress,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	officiallyprinted,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	taxable_euro,
	iva_euro,
	total,
	active,
	flagintracom,
	idaccmotivecredit,
	codemotivecredit,
	idaccmotivecredit_crg,
	codemotivecredit_crg,
	idaccmotivecredit_datacrg,
	idunderwriting,
	underwriting,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05	
)
	AS SELECT
	estimate.idestimkind,
	estimate.yestim,
	estimate.nestim,
	estimatekind.description,
	estimate.idreg,
	registry.title,
	estimate.registryreference,
	estimate.description,
	estimate.idman,
	manager.title,
	estimate.deliveryexpiration,
	estimate.deliveryaddress,
	estimate.paymentexpiring,
	estimate.idexpirationkind,
	estimate.idcurrency,
	currency.codecurrency,
	currency.description,
	estimate.exchangerate,
	estimate.doc,
	estimate.docdate,
	estimate.adate,
	estimate.officiallyprinted,
	estimate.txt,
	estimate.cu, 
	estimate.ct, 
	estimate.lu, 
	estimate.lt,
	-- taxable_euro
	ISNULL(
		(SELECT
			SUM(
				ROUND(estimatedetail.taxable * estimatedetail.number * 
					CONVERT(decimal(19,6), m.exchangerate) *
					(1 - CONVERT(decimal(19,6), ISNULL(estimatedetail.discount, 0.0)))
				,2)
			)
		FROM estimatedetail
		JOIN estimate m
			ON estimatedetail.idestimkind = estimate.idestimkind
			AND estimatedetail.yestim = estimate.yestim
			AND estimatedetail.nestim = estimate.nestim
		WHERE m.idestimkind = estimate.idestimkind
			AND m.yestim = estimate.yestim
			AND m.nestim = estimate.nestim
			AND estimatedetail.stop IS NULL
		)
	,0),
	-- iva_euro
	ISNULL(
		(SELECT
			SUM(
				ROUND(estimatedetail.tax * CONVERT(decimal(19,6), m.exchangerate),2)
			)
		FROM estimatedetail
		JOIN estimate m
			ON estimatedetail.idestimkind = estimate.idestimkind
			AND estimatedetail.yestim = estimate.yestim
			AND estimatedetail.nestim = estimate.nestim
		WHERE m.idestimkind = estimate.idestimkind
			AND m.yestim = estimate.yestim
			AND m.nestim = estimate.nestim
			AND estimatedetail.stop IS NULL
		)
	,0),
	-- total
	ISNULL(
		(SELECT
			SUM(
				ISNULL(
					ROUND(estimatedetail.taxable * estimatedetail.number * 
						CONVERT(decimal(19,6), m.exchangerate) *
						(1 - CONVERT(decimal(19,6), ISNULL(estimatedetail.discount, 0.0)))
					,2)
				,0) +
				ISNULL(
					ROUND(estimatedetail.tax * CONVERT(decimal(19,6), m.exchangerate),2)
				,0)
			)
		FROM estimatedetail
		JOIN estimate m
			ON estimatedetail.idestimkind = estimate.idestimkind
			AND estimatedetail.yestim = estimate.yestim
			AND estimatedetail.nestim = estimate.nestim
		WHERE m.idestimkind = estimate.idestimkind
			AND m.yestim = estimate.yestim
			AND m.nestim = estimate.nestim
			AND estimatedetail.stop IS NULL
		)
	,0),
	estimate.active,
	estimate.flagintracom,
	AC.idaccmotive,
	AC.codemotive,
	ACCRG.idaccmotive,
	ACCRG.codemotive,
	estimate.idaccmotivecredit_datacrg,
	estimate.idunderwriting,
	underwriting.title	,
	isnull(estimate.idsor01,estimatekind.idsor01),
	isnull(estimate.idsor02,estimatekind.idsor02),
	isnull(estimate.idsor03,estimatekind.idsor03),
	isnull(estimate.idsor04,estimatekind.idsor04),
	isnull(estimate.idsor05,estimatekind.idsor05)
FROM estimate  with (nolock)
JOIN estimatekind  with (nolock)
	ON estimatekind.idestimkind = estimate.idestimkind
LEFT OUTER JOIN registry with (nolock)
	ON registry.idreg = estimate.idreg
LEFT OUTER JOIN currency with (nolock)
	ON currency.idcurrency = estimate.idcurrency
LEFT OUTER JOIN manager  with (nolock)
	ON manager.idman = estimate.idman
LEFT OUTER JOIN accmotive AC with (nolock)
	ON AC.idaccmotive = estimate.idaccmotivecredit
LEFT OUTER JOIN accmotive ACCRG with (nolock)
	ON ACCRG.idaccmotive = estimate.idaccmotivecredit_crg
LEFT OUTER JOIN underwriting with (nolock)
	ON underwriting.idunderwriting = estimate.idunderwriting


GO

print '[estimateview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandateview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandateview
GO

CREATE   VIEW [mandateview]
(
	idmankind,
	yman,
	nman,
	mankind,
	idreg,
	registry,
	registryreference,
	description,
	idman,
	manager,
	deliveryexpiration,
	deliveryaddress,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	officiallyprinted,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	taxable_euro,
	iva_euro,
	total,
	active,
	flagintracom,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	applierannotations,
	idmandatestatus,
	mandatestatus,
	idstore,
	store,
	statusimage,
	listingorder,
	linkedtotal,
	isrequest,
	cigcode,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	idconsipkind,
	flagdanger
)
AS SELECT
	mandate.idmankind,
	mandate.yman,
	mandate.nman,
	mandatekind.description,
	mandate.idreg,
	registry.title,
	mandate.registryreference,
	mandate.description,
	mandate.idman,
	manager.title,
	mandate.deliveryexpiration,
	mandate.deliveryaddress,
	mandate.paymentexpiring,
	mandate.idexpirationkind,
	mandate.idcurrency,
	currency.codecurrency,
	currency.description,
	mandate.exchangerate,
	mandate.doc,
	mandate.docdate,
	mandate.adate,
	mandate.officiallyprinted,
	mandate.txt,
	mandate.cu, 
	mandate.ct, 
	mandate.lu, 
	mandate.lt,
	-- taxable_euro
	ISNULL(
		(SELECT
			SUM(
				ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
					CONVERT(decimal(19,6), m.exchangerate) *
					(1 - CONVERT(decimal(19,6), ISNULL(mandatedetail.discount, 0.0)))
				,2)
			)
		FROM mandatedetail
		JOIN mandate m
			ON mandatedetail.idmankind = mandate.idmankind
			AND mandatedetail.yman = mandate.yman
			AND mandatedetail.nman = mandate.nman
		WHERE m.idmankind = mandate.idmankind
			AND m.yman = mandate.yman
			AND m.nman = mandate.nman
			AND mandatedetail.stop IS NULL
		)
	,0),
	-- iva_euro
	ISNULL(
		(SELECT
			SUM(
				ROUND(mandatedetail.tax ,2)
			)
		FROM mandatedetail
		JOIN mandate m
			ON mandatedetail.idmankind = mandate.idmankind
			AND mandatedetail.yman = mandate.yman
			AND mandatedetail.nman = mandate.nman
		WHERE m.idmankind = mandate.idmankind
			AND m.yman = mandate.yman
			AND m.nman = mandate.nman
			AND mandatedetail.stop IS NULL
		)
	,0),
	-- total
	ISNULL(
		(SELECT
			SUM(
				ISNULL(
					ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
						CONVERT(decimal(19,6), m.exchangerate) *
						(1 - CONVERT(decimal(19,6), ISNULL(mandatedetail.discount, 0.0)))
					,2)
				,0) +
				ISNULL(
					ROUND(mandatedetail.tax,2)
				,0)
			)
		FROM mandatedetail
		JOIN mandate m
			ON mandatedetail.idmankind = mandate.idmankind
			AND mandatedetail.yman = mandate.yman
			AND mandatedetail.nman = mandate.nman
		WHERE m.idmankind = mandate.idmankind
			AND m.yman = mandate.yman
			AND m.nman = mandate.nman
			AND mandatedetail.stop IS NULL
		)
	,0),
	mandate.active,
	mandate.flagintracom,
	AD.idaccmotive,
	AD.codemotive,
	ADCRG.idaccmotive,
	ADCRG.codemotive,
	mandate.idaccmotivedebit_datacrg,
	mandate.applierannotations,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandate.idstore,
	store.description,
	(case when mandate.idmandatestatus=1 then '<center><img src="Immagini/bozza.png" title="Bozza" alt="Bozza"/></center>'
		  when mandate.idmandatestatus=2 then '<center><img src="Immagini/richiesta.png" title="Richiesta" alt="Richiesta"/></center>'
		  when mandate.idmandatestatus=3 then '<center><img src="Immagini/dacorreggere.png" title="Da Correggere" alt="Da Correggere"/></center>'
		  when mandate.idmandatestatus=4 then '<center><img src="Immagini/inserito.png" title="Inserito" alt="Inserito"/></center>'
		  when mandate.idmandatestatus=5 then '<center><img src="Immagini/approvato.png" title="Approvato" alt="Approvato"/></center>'
		  when mandate.idmandatestatus=6 then '<center><img src="Immagini/annullato.png" title="Annullato" alt="Annullato"/></center>'
		  when mandate.idmandatestatus=null then ''
		  end
		  ),
	mandatestatus.listingorder,
	ISNULL(
	CONVERT(DECIMAL(19,2),
		(SELECT SUM(
		    CASE 
			WHEN (mandatedetail.idexp_taxable IS NOT NULL) AND ( mandatedetail.idexp_iva IS NULL)
			THEN
			     ROUND(
						ISNULL(mandatedetail.taxable,0) * 
							ISNULL(mandatedetail.npackage,mandatedetail.number)*
					CONVERT(decimal(19,6),md.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0)))
					,2)
			WHEN ( mandatedetail.idexp_iva IS NOT NULL) AND (mandatedetail.idexp_taxable IS  NULL)
			THEN
			     ROUND( ISNULL(mandatedetail.tax,0)  ,2)
			WHEN ( mandatedetail.idexp_iva IS NOT NULL) AND (mandatedetail.idexp_taxable IS NOT NULL)
			THEN
			     ROUND((ISNULL(mandatedetail.taxable,0) * ISNULL(mandatedetail.npackage,mandatedetail.number)* 
						CONVERT(decimal(19,6),md.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0)))
					
				 + ISNULL(mandatedetail.tax,0))  ,2)
			ELSE   0
		    END
		   )
		FROM mandatedetail 
			join mandate md on (
				mandatedetail.idmankind = md.idmankind
				AND  mandatedetail.yman = md.yman
				AND  mandatedetail.nman = md.nman
			)
				WHERE mandatedetail.idmankind = mandate.idmankind
				AND  mandatedetail.yman = mandate.yman
				AND  mandatedetail.nman = mandate.nman
			AND mandatedetail.stop is null
			)
			)			
		,0)
 
	AS linkedtotal,
	mandatekind.isrequest,
	mandate.cigcode,
	isnull(mandate.idsor01,mandatekind.idsor01),
	isnull(mandate.idsor02,mandatekind.idsor02),
	isnull(mandate.idsor03,mandatekind.idsor03),
	isnull(mandate.idsor04,mandatekind.idsor04),
	isnull(mandate.idsor05,mandatekind.idsor05),
	mandate.idconsipkind,
	isnull(mandate.flagdanger,'N')
FROM mandate with (nolock)
JOIN mandatekind with (nolock)
	ON mandatekind.idmankind = mandate.idmankind
LEFT OUTER JOIN registry with (nolock)
	ON registry.idreg = mandate.idreg
LEFT OUTER JOIN currency with (nolock)
	ON currency.idcurrency = mandate.idcurrency
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = mandate.idman
LEFT OUTER JOIN accmotive AD with (nolock)
	ON AD.idaccmotive = mandate.idaccmotivedebit
LEFT OUTER JOIN accmotive ADCRG with (nolock)
	ON ADCRG.idaccmotive = mandate.idaccmotivedebit_crg
LEFT OUTER JOIN mandatestatus with (nolock)
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN store  with (nolock)
	ON store.idstore = mandate.idstore

GO

print '[mandateview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finvardetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finvardetailview
GO




CREATE       VIEW finvardetailview
(
	yvar,
	nvar,
	rownum,
	variationdescription,
	enactment,
	nenactment,
	enactmentdate,
	variationkind,
	variationkinddescr,
	flagprevision,	
	flagcredit,
	flagproceeds,
	flagsecondaryprev,
	official,
	nofficial,
	enactmentnumber,
	idman,
	manager,
	idfinvarstatus,
	finvarstatus,
	idfin,
	ayear,
	flag,
	finpart,
	codefin,
	finance,
	description,
	idupb,		
	codeupb,	
	upb,	
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	amount,
	limit,
	annotation,
	idlcard,
	adate,	
	cu,
	ct,
	lu,
	lt,
	idunderwriting,
	underwriting,
	prevision2,
	prevision3,
	createexpense,
	idexp,
	phase,
	nmov,
	flagactivity,
	activity,
	flagkind,
	kindd,
	kindr
	
)
AS SELECT
	finvardetail.yvar,
	finvardetail.nvar,
	finvardetail.rownum,
	finvar.description,
	finvar.enactment,
	finvar.nenactment,
	finvar.enactmentdate,
	finvar.variationkind,
	variationkind.description,
	finvar.flagprevision,	
	finvar.flagcredit,
	finvar.flagproceeds,
	finvar.flagsecondaryprev,
	finvar.official,
	finvar.nofficial,
	enactment.nenactment,
	finvar.idman,
	manager.title,
	finvar.idfinvarstatus,
	finvarstatus.description,
	finvardetail.idfin,
	fin.ayear,
	fin.flag,
	CASE
		WHEN ((fin.flag&1)=0) THEN 'E'
		WHEN ((fin.flag&1)=1) THEN 'S'
	END,
	fin.codefin,
	fin.title,
	finvardetail.description,
	upb.idupb,	
	upb.codeupb,		
	upb.title,	
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	finvardetail.amount,
	finvardetail.limit,
	finvardetail.annotation,
	finvardetail.idlcard,
	finvar.adate,	
	finvardetail.cu,
	finvardetail.ct,
	finvardetail.lu,
	finvardetail.lt,
	finvardetail.idunderwriting,
	underwriting.title,
	finvardetail.prevision2,
	finvardetail.prevision3,
	finvardetail.createexpense,
	finvardetail.idexp,
	expensephase.description,
	expense.nmov,
	upb.flagactivity,
--	activity,
	case
	when upb.flagactivity ='1' then 'Istituzionale'
	when upb.flagactivity ='2' then 'Commerciale'
	-- when upb.flagactivity ='3' then 'p': l'upb non ha il promiscuo
	when upb.flagactivity ='4' then 'Qualsiasi/Non specificata'
	end,
	upb.flagkind,
--	kindd,
	CASE
		when (( upb.flagkind & 1)<> 0) then 'S'
	End,
--	kindr,
	CASE
		when (( upb.flagkind & 2)<>0) then 'S'
	End
FROM finvardetail with (nolock)
JOIN finvar with (nolock)
	ON finvardetail.yvar = finvar.yvar
	AND finvardetail.nvar = finvar.nvar
JOIN fin with (nolock)
	ON finvardetail.idfin = fin.idfin
JOIN upb with (nolock)
	ON finvardetail.idupb=upb.idupb 	
JOIN variationkind with (nolock)
	ON variationkind.idvariationkind = finvar.variationkind
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = finvar.idman
LEFT OUTER JOIN finvarstatus with (nolock)
	ON finvarstatus.idfinvarstatus = finvar.idfinvarstatus
LEFT OUTER JOIN enactment with (nolock)
	ON enactment.idenactment = finvar.idenactment
LEFT OUTER JOIN underwriting   with (nolock)
	ON finvardetail.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN expense  with (nolock)
	ON finvardetail.idexp=  expense.idexp
LEFT OUTER JOIN expensephase with (nolock)
	on expense.nphase= expensephase.nphase




GO

print 'finvardetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'underwritingappropriationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW underwritingappropriationview
GO



CREATE      VIEW [underwritingappropriationview]
(
	idexp,
	nphase,
	expensephase,
	ymov,
	nmov,
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	adate,
	idunderwriting,
	codeunderwriting,
	underwriting,
	amount,
	idfin,
	codefin,
	fin,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expense.doc,
	expense.docdate,
	expense.description,
	expense.adate,
	underwriting.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	underwritingappropriation.amount,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.idupb,
	upb.codeupb,
	underwritingappropriation.cu,
	underwritingappropriation.ct,
	underwritingappropriation.lu,
	underwritingappropriation.lt
FROM underwritingappropriation
JOIN expense
	ON underwritingappropriation.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp	
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN underwriting
	ON underwritingappropriation.idunderwriting = underwriting.idunderwriting
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb


GO

print '[underwritingappropriationview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'parasubcontractsummaryview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW parasubcontractsummaryview
GO

CREATE       VIEW parasubcontractsummaryview
(
	idcon,
	ayear,
	taxablepension,
	inpsinail,
	deduction,
	fiscaltaxablegross
)
AS
SELECT
	idcon, ayear, taxablepension,
	ISNULL(
		(SELECT SUM(payrolltax.employtax)
		FROM payrolltax
		JOIN payroll
			ON payroll.idpayroll = payrolltax.idpayroll
		JOIN tax
			ON payrolltax.taxcode = tax.taxcode
		WHERE payroll.idcon = parasubcontractyear.idcon
			AND payroll.fiscalyear = parasubcontractyear.ayear
			AND payroll.flagbalance = 'S'
			AND tax.taxkind IN (3,4))
	,0),
	ISNULL(
		(SELECT SUM(payrolldeduction.curramount)
		FROM payrolldeduction
		JOIN payroll
			ON payroll.idpayroll = payrolldeduction.idpayroll
		JOIN deduction
			ON deduction.iddeduction = payrolldeduction.iddeduction
		WHERE payroll.idcon = parasubcontractyear.idcon
			AND payroll.fiscalyear = parasubcontractyear.ayear
			AND payroll.flagbalance = 'S'
			AND deduction.flagdeductibleexpense = 'S'
			AND payrolldeduction.iddeduction <> 6) -- Per sicurezza scartiamo la deduzione 6 che sarebbe proprio INPS + INAIL
	,0),
	-- fiscaltaxablegross
	ISNULL(taxablepension,0) -
	ISNULL(
		(SELECT SUM(payrolltax.employtax)
		FROM payrolltax
		JOIN payroll
			ON payroll.idpayroll = payrolltax.idpayroll
		JOIN tax
			ON payrolltax.taxcode = tax.taxcode
		WHERE payroll.idcon = parasubcontractyear.idcon
			AND payroll.fiscalyear = parasubcontractyear.ayear
			AND payroll.flagbalance = 'S'
			AND tax.taxkind IN (3,4))
	,0) -
	ISNULL(
		(SELECT SUM(payrolldeduction.curramount)
		FROM payrolldeduction
		JOIN payroll
			ON payroll.idpayroll = payrolldeduction.idpayroll
		JOIN deduction
			ON deduction.iddeduction = payrolldeduction.iddeduction
		WHERE payroll.idcon = parasubcontractyear.idcon
			AND payroll.fiscalyear = parasubcontractyear.ayear
			AND payroll.flagbalance = 'S'
			AND deduction.flagdeductibleexpense = 'S'
			AND payrolldeduction.iddeduction <> 6) -- Per sicurezza scartiamo la deduzione 6 che sarebbe proprio INPS + INAIL
	,0)
FROM parasubcontractyear


GO

print 'parasubcontractsummaryview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'budgetvarview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW budgetvarview
GO

-- select * from [budgetvarview]
CREATE         VIEW [budgetvarview]
(
	idsorkind,
	ybudgetvar,
	nbudgetvar,
	yvar,
	nvar,
	adate,
	description,
	official,
	nofficial,
	total,
	ct,
	cu,
	lt,
	lu,
	idbudgetvarstatus,
	budgetvarstatus,
	reason,
	idman,
	manager,
	statusimage,
	listingorder,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05 
)
AS SELECT
	budgetvar.idsorkind,
	budgetvar.ybudgetvar,
	budgetvar.nbudgetvar,
	budgetvar.yvar,
	budgetvar.nvar,
	budgetvar.adate,
	budgetvar.description,
	budgetvar.official,
	budgetvar.nofficial,
	ISNULL(
		(SELECT SUM(amount)
		FROM budgetvardetail D
		 
		WHERE D.ybudgetvar = budgetvar.ybudgetvar
			AND D.nbudgetvar = budgetvar.nbudgetvar
	),0),
	budgetvar.ct,
	budgetvar.cu,
	budgetvar.lt,
	budgetvar.lu,
	budgetvar.idbudgetvarstatus,
	budgetvarstatus.description,
	budgetvar.reason,
	budgetvar.idman,
	manager.title,
	(case when budgetvar.idbudgetvarstatus=1 then '<center><img src="Immagini/bozza.png" title="Bozza" alt="Bozza"/></center>'
		  when budgetvar.idbudgetvarstatus=2 then '<center><img src="Immagini/richiesta.png" title="Richiesta" alt="Richiesta"/></center>'
		  when budgetvar.idbudgetvarstatus=3 then '<center><img src="Immagini/dacorreggere.png" title="Da Correggere" alt="Da Correggere"/></center>'
		  when budgetvar.idbudgetvarstatus=4 then '<center><img src="Immagini/inserito.png" title="Inserito" alt="Inserito"/></center>'
		  when budgetvar.idbudgetvarstatus=5 then '<center><img src="Immagini/approvato.png" title="Approvato" alt="Approvato"/></center>'
		  when budgetvar.idbudgetvarstatus=6 then '<center><img src="Immagini/annullato.png" title="Annullato" alt="Annullato"/></center>'
		  end
		  ),
	budgetvarstatus.listingorder,
	budgetvar.idsor01,
	budgetvar.idsor02,
	budgetvar.idsor03,
	budgetvar.idsor04,
	budgetvar.idsor05
FROM budgetvar with (nolock)
LEFT OUTER JOIN budgetvarstatus with (nolock)
	ON budgetvarstatus.idbudgetvarstatus = budgetvar.idbudgetvarstatus
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = budgetvar.idman
JOIN sortingkind with (nolock)
	ON sortingkind.idsorkind = budgetvar.idsorkind

GO

print '[budgetvarview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingusableyear') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingusableyear
GO




CREATE               VIEW [sortingusableyear]
(
	ayear,
	codesorkind,
	idsorkind,
	idsor,
	sortcode,
	nlevel,
	leveldescr,
	paridsor,
	description,
	start,
	stop,
	cu, 
	ct, 
	lu, 
	lt,
	movkind
)
AS SELECT 
	accountingyear.ayear,
	sortingkind.codesorkind,
	sorting.idsorkind,
	sorting.idsor,
	sorting.sortcode,
	sorting.nlevel,
	sortinglevel.description,
	sorting.paridsor,
	sorting.description,
	sorting.start, 
	sorting.stop, 
	sorting.cu, 
	sorting.ct, 
	sorting.lu,
	sorting.lt,
	sorting.movkind
FROM sorting
JOIN sortinglevel
	ON sortinglevel.nlevel = sorting.nlevel
	AND sortinglevel.idsorkind = sorting.idsorkind
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
cross join accountingyear
WHERE ((sortinglevel.flag & 2) <> 0)
	AND sorting.idsor NOT IN
		(SELECT c1.paridsor FROM sorting c1
		WHERE c1.paridsor IS NOT NULL)




GO

print '[sortingusableyear] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'serviceregistryview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW serviceregistryview
GO


CREATE                      VIEW [serviceregistryview]
	(
	yservreg,
	nservreg,
	id_service,
	employkind,
	iddepartment,
	department ,
	is_annulled,
	is_delivered,
	is_changed,
	is_blocked,
	idconsultingkind,
	consultingkind,
	p_iva,
	cf,
	flagforeign,
	title,
	codcity,
	city,
	surname,
	forename,
	birthdate,
	gender,
	referencesemester,
	pa_code,
	idacquirekind,
	acquirekind,
	idapcontractkind,
	apcontractkind,
	idfinancialactivity,
	financialactivity,
	description,
	start,
	stop,
	servicevariation,
	expectedamount,
	payment,
	ypay,
	--semesterpay,
	--payedamount,
	idapmanager,
	apmanager,	
	idapregistrykind,
	apregistrykind,
	idapactivitykind,
	apactivitykind,	
	pa_cf,
	pa_title,
	authorizationdate,
	officeduty,
	annotation,
	referencerule,
	idreg,
	idrelated,
	regulation,
	idapfinancialactivity,
	apfinancialactivitycode,
	apfinancialactivity,
	expectationsdate,
	rulespecifics,
	paragraph,
	article,
	articlenumber,
	referencedate,
	idreferencerule,
	referenceruledescription,
	senderreporting,
	flaghuman,
	idconferring,
	conferring_piva,
	conferring_forename,
	conferring_surname,
	conferring_flagforeign,
	conferring_birthdate,
	conferring_gender,
	conferring_codcity,
	conferring_idcity,
	conferring_city,
	idserviceregistrykind,
	serviceregistrykind,
	conferringstructure,
	ordinancelink,
	authorizingstructure,
	authorizinglink,
	actreference,
	announcementlink,
	otherservice,
	professionalservice,
	componentsvariable,
	cu,
	ct,
	lu,
	lt
	)
	AS SELECT
	serviceregistry.yservreg,
	serviceregistry.nservreg,
	serviceregistry.id_service,
	serviceregistry.employkind,
	serviceregistry.iddepartment,
	department.description ,
	serviceregistry.is_annulled,
	serviceregistry.is_delivered,
	serviceregistry.is_changed,
	serviceregistry.is_blocked,
	serviceregistry.idconsultingkind,
	consultingkind.description,
	serviceregistry.p_iva,
	serviceregistry.cf,
	serviceregistry.flagforeign,
	serviceregistry.title,
	serviceregistry.codcity,
	geo_city.title,
	serviceregistry.surname,
	serviceregistry.forename,
	serviceregistry.birthdate,
	serviceregistry.gender,
	serviceregistry.referencesemester,
	serviceregistry.pa_code,
	serviceregistry.idacquirekind,
	acquirekind.description,
	serviceregistry.idapcontractkind,
	apcontractkind.description,
	serviceregistry.idfinancialactivity,
	financialactivity.description,
	serviceregistry.description,
	serviceregistry.start,
	serviceregistry.stop,
	serviceregistry.servicevariation,
	serviceregistry.expectedamount,
	serviceregistry.payment,
	serviceregistry.ypay,
	--serviceregistry.semesterpay,
	--serviceregistry.payedamount,
	serviceregistry.idapmanager,
	apmanager.description,	
	serviceregistry.idapregistrykind,
	apregistrykind.description,
	serviceregistry.idapactivitykind,
	apactivitykind.description,	
	serviceregistry.pa_cf,
	serviceregistry.pa_title,
	serviceregistry.authorizationdate,
	serviceregistry.officeduty,
	serviceregistry.annotation,
	serviceregistry.referencerule,
	serviceregistry.idreg,
	serviceregistry.idrelated,
	serviceregistry.regulation,
	serviceregistry.idapfinancialactivity,
	apfinancialactivity.apfinancialactivitycode,
	apfinancialactivity.description,
	serviceregistry.expectationsdate,
	serviceregistry.rulespecifics,
	serviceregistry.paragraph,
	serviceregistry.article,
	serviceregistry.articlenumber,
	serviceregistry.referencedate,
	serviceregistry.idreferencerule,
	referencerule.description,
	serviceregistry.senderreporting,
	serviceregistry.flaghuman,
	serviceregistry.idconferring,
	serviceregistry.conferring_piva,
	serviceregistry.conferring_forename,
	serviceregistry.conferring_surname,
	serviceregistry.conferring_flagforeign,
	serviceregistry.conferring_birthdate,
	serviceregistry.conferring_gender,
	serviceregistry.conferring_codcity,
	serviceregistry.conferring_idcity,	
	geo_city_conferring.title,
	serviceregistry.idserviceregistrykind,
 	serviceregistrykind.description,
	serviceregistry.conferringstructure,
	serviceregistry.ordinancelink,
	serviceregistry.authorizingstructure,
	serviceregistry.authorizinglink,
	serviceregistry.actreference,
	serviceregistry.announcementlink,
	serviceregistry.otherservice,
	serviceregistry.professionalservice,
	serviceregistry.componentsvariable,
	serviceregistry.cu,
	serviceregistry.ct,
	serviceregistry.lu,
	serviceregistry.lt
	FROM serviceregistry (NOLOCK)
	left outer JOIN apcontractkind (NOLOCK)
		ON serviceregistry.idapcontractkind = apcontractkind.idapcontractkind
		and serviceregistry.yservreg = apcontractkind.ayear
	LEFT OUTER JOIN apregistrykind (NOLOCK)
		ON apregistrykind.idapregistrykind = serviceregistry.idapregistrykind
		and serviceregistry.yservreg = apregistrykind.ayear
	LEFT OUTER JOIN consultingkind (NOLOCK)
		ON consultingkind.idconsultingkind = serviceregistry.idconsultingkind
		and serviceregistry.yservreg = consultingkind.ayear
	LEFT OUTER JOIN apmanager (NOLOCK)
		ON apmanager.idapmanager = serviceregistry.idapmanager
		and serviceregistry.yservreg = apmanager.ayear
	LEFT OUTER join financialactivity (NOLOCK)
		on financialactivity.idfinancialactivity = serviceregistry.idfinancialactivity
		and serviceregistry.yservreg = financialactivity.ayear
	LEFT OUTER join acquirekind (NOLOCK)			
		on acquirekind.idacquirekind = serviceregistry.idacquirekind
		and serviceregistry.yservreg = acquirekind.ayear
	LEFT OUTER join apactivitykind(NOLOCK)	
		on apactivitykind.idapactivitykind = serviceregistry.idapactivitykind
		and serviceregistry.yservreg = apactivitykind.ayear
	LEFT OUTER join department(NOLOCK)	
		on department.iddepartment = serviceregistry.iddepartment
	LEFT OUTER join geo_city(NOLOCK)	
		on geo_city.idcity = serviceregistry.idcity
	LEFT OUTER JOIN apfinancialactivity
		ON serviceregistry.idapfinancialactivity = apfinancialactivity.idapfinancialactivity
	LEFT OUTER JOIN referencerule
		ON referencerule.idreferencerule = serviceregistry.idreferencerule
		AND referencerule.ayear = serviceregistry.yservreg 
	LEFT OUTER join geo_city as geo_city_conferring(NOLOCK)	
		on geo_city_conferring.idcity = serviceregistry.conferring_idcity
	LEFT OUTER JOIN serviceregistrykind 
		ON serviceregistrykind.idserviceregistrykind = serviceregistry.idserviceregistrykind


GO

print '[serviceregistryview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingview
GO




CREATE              VIEW [sortingview]
(
	codesorkind,
	idsorkind,
	sortingkind,
	idsor,
	sortcode,
	nlevel,
	leveldescr,
	paridsor,
	description,
	ayear,
	incomeprevision,
	expenseprevision,
	start,
	stop,
	cu, 
	ct, 
	lu, 
	lt,
	defaultn1, 
	defaultn2,
	defaultn3, 
	defaultn4, 
	defaultn5, 
	defaults1, 
	defaults2, 
	defaults3, 
	defaults4, 
	defaults5, 
	flagnodate,
	movkind
)
AS SELECT
	sortingkind.codesorkind,
  	sorting.idsorkind,
	sortingkind.description,
	sorting.idsor,
	sorting.sortcode,
	sorting.nlevel,
	sortinglevel.description,
	sorting.paridsor,
	sorting.description,
	accountingyear.ayear,
	sortingprev.incomeprevision,
	sortingprev.expenseprevision,
	sorting.start,
	sorting.stop,
	sorting.cu, 
	sorting.ct, 
	sorting.lu,
	sorting.lt, 
	sorting.defaultn1, 
	sorting.defaultn2,
	sorting.defaultn3, 
	sorting.defaultn4, 
	sorting.defaultn5, 
	sorting.defaults1, 
	sorting.defaults2, 
	sorting.defaults3, 
	sorting.defaults4, 
	sorting.defaults5, 
	sorting.flagnodate,
	sorting.movkind
FROM sorting
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
CROSS JOIN accountingyear
JOIN sortinglevel
	ON sortinglevel.nlevel = sorting.nlevel
	AND sortinglevel.idsorkind = sorting.idsorkind
LEFT OUTER JOIN sortingprev
	ON sortingprev.idsor = sorting.idsor
	AND sortingprev.ayear = accountingyear.ayear




GO

print '[sortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingyearview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingyearview
GO


CREATE              VIEW [sortingyearview]
	(
	codesorkind,
	idsorkind,
	sortingkind,
	idsor,
	sortcode,
	nlevel,
	leveldescr,
	paridsor,
	description,
	printingorder,
	ayear,
	incomeprevision,
	expenseprevision,
	totexpensevariation,
	totincomevariation,
	totexpense,
	totincome,
	currentincomeprevision,
	currentexpenseprevision,
	availableincomeprevision,
	availableexpenseprevision,
	idman,
	manager,
	start,
	stop,
	cu, 
	ct, 
	lu, 
	lt,
	defaultn1, 
	defaultn2,
	defaultn3, 
	defaultn4, 
	defaultn5, 
	defaults1, 
	defaults2, 
	defaults3, 
	defaults4, 
	defaults5, 
	flagnodate,
	movkind
	)
	AS SELECT
	sortingkind.codesorkind,
  	sorting.idsorkind,
	sortingkind.description,
	sorting.idsor,
	sorting.sortcode,
	sorting.nlevel,
	sortinglevel.description,
	sorting.paridsor,
	sorting.description,
	sorting.printingorder,
	accountingyear.ayear,
	sortingprev.incomeprevision,
	sortingprev.expenseprevision,
	sortedmovementtotal.totexpensevariation,
	sortedmovementtotal.totincomevariation,
	sortedmovementtotal.totexpense,
	sortedmovementtotal.totalincome,
	ISNULL(sortingprev.incomeprevision,0) + 
	ISNULL(sortedmovementtotal.totincomevariation,0),
	ISNULL(sortingprev.expenseprevision,0) + 
	ISNULL(sortedmovementtotal.totexpensevariation,0),
	ISNULL(sortingprev.incomeprevision,0) + 
	ISNULL(sortedmovementtotal.totincomevariation,0) -
	ISNULL(sortedmovementtotal.totalincome,0),
	ISNULL(sortingprev.expenseprevision,0) + 
	ISNULL(sortedmovementtotal.totexpensevariation,0) - 
	ISNULL(sortedmovementtotal.totexpense,0),
	manager.idman,
	manager.title,
	sorting.start,
	sorting.stop,
	sorting.cu, 
	sorting.ct, 
	sorting.lu,
	sorting.lt, 
	sorting.defaultn1, 
	sorting.defaultn2,
	sorting.defaultn3, 
	sorting.defaultn4, 
	sorting.defaultn5, 
	sorting.defaults1, 
	sorting.defaults2, 
	sorting.defaults3, 
	sorting.defaults4, 
	sorting.defaults5, 
	sorting.flagnodate,
	sorting.movkind
FROM sorting
JOIN sortingkind
 ON sortingkind.idsorkind = sorting.idsorkind
CROSS JOIN accountingyear
JOIN sortinglevel
 ON sortinglevel.nlevel = sorting.nlevel
 AND sortinglevel.idsorkind = sorting.idsorkind
LEFT OUTER JOIN sortingprev
 ON sortingprev.idsor = sorting.idsor
 AND sortingprev.ayear = accountingyear.ayear
LEFT OUTER JOIN sortedmovementtotal
 ON  sortedmovementtotal.idsor = sorting.idsor
 AND sortedmovementtotal.ayear = accountingyear.ayear
LEFT OUTER JOIN managersorting
 ON managersorting.idsor = sorting.idsor
LEFT OUTER JOIN manager
 ON manager.idman = managersorting.idman


--sp_help sortedmovementtotal
--sp_help managersorting



GO

print '[sortingyearview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_contractkindrulesview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_contractkindrulesview
GO




CREATE      VIEW [csa_contractkindrulesview]
(
	idcsa_contractkind,
	idcsa_rule,
	capitolocsa,
	ruolocsa,
	ayear,
	description,
	contractkindcode,
	flagcr,
	flagkeepalive,
	active,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	C.idcsa_contractkind,
	R.idcsa_rule,
	R.capitolocsa,
	R.ruolocsa,
	R.ayear,
	C.description,
	C.contractkindcode,
	C.flagcr,
	C.flagkeepalive,
	C.active,
	R.cu,
	R.ct,
	R.lu,
	R.lt
FROM csa_contractkindrules R
JOIN csa_contractkind C
	ON C.idcsa_contractkind = R.idcsa_contractkind
JOIN csa_contractkindyear CY
	ON C.idcsa_contractkind = CY.idcsa_contractkind


GO

print '[csa_contractkindrulesview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetamortizationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetamortizationview
GO

CREATE  VIEW [assetamortizationview]
(
	namortization,	idasset,	idpiece,	idinventoryamortization,	codeinventoryamortization,
	inventoryamortization,	official,	idinventory,	inventory,	ninventory,	loaddescription,	description,
	assetvalue,	amortizationquota,	amount,  	adate,	
	idassetunload, 	idassetunloadkind,	assetunloadkind,	yassetunload,	nassetunload,
	idassetload, 	idassetloadkind,	assetloadkind,	yassetload,	nassetload,
	flag,	flagunload,	flagload,	transmitted,	idinv,	codeinv,	inventorytree,
	cu,	ct,	lu,	lt,	rtf,	txt,
	am_year,ass_year,	idinv_lev1,	codeinv_lev1,inventorytree_lev1
)
	AS SELECT
	assetamortization.namortization,
	assetamortization.idasset,
	assetamortization.idpiece,
	assetamortization.idinventoryamortization,
	inventoryamortization.codeinventoryamortization,
	inventoryamortization.description,
	CASE 
		WHEN ((inventoryamortization.flag & 2) <> 0) THEN 'S'
		ELSE 'N'
	END,
	assetacquire.idinventory,
	inventory.description,
	assetmain.ninventory,
	assetacquire.description,
	assetamortization.description,
	assetamortization.assetvalue,
	assetamortization.amortizationquota,
	CONVERT(DECIMAL(19,2),ISNULL(assetamortization.assetvalue, 0) *
	ISNULL(assetamortization.amortizationquota, 0)),
	assetamortization.adate,
	assetamortization.idassetunload,
	assetunload.idassetunloadkind,
	assetunloadkind.description,
	assetunload.yassetunload,
	assetunload.nassetunload,	
	
	assetamortization.idassetload,
	assetload.idassetloadkind,	
	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
	assetamortization.flag,
	CASE 
		WHEN assetamortization.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	CASE 
		WHEN assetamortization.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetamortization.transmitted,
	assetacquire.idinv,
	inventorytree.codeinv,
	inventorytree.description,
	assetamortization.cu,
	assetamortization.ct,
	assetamortization.lu,
	assetamortization.lt,
	assetamortization.rtf,
	assetamortization.txt,
	year(assetamortization.adate),
	year(asset.lifestart),
	inventorytree1.idinv,
	inventorytree1.codeinv,
	inventorytree1.description
FROM assetamortization
JOIN asset
	ON asset.idasset = assetamortization.idasset 
	AND asset.idpiece = assetamortization.idpiece 
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset AS assetmain
	ON (asset.idasset = assetmain.idasset) AND (assetmain.idpiece = 1)
LEFT OUTER JOIN assetunload
	ON assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetunloadkind
	ON assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
LEFT OUTER JOIN assetload
	ON assetamortization.idassetload = assetload.idassetload
LEFT OUTER JOIN assetloadkind
	ON assetloadkind.idassetloadkind = assetload.idassetloadkind
LEFT OUTER JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
	AND inventorytreelink.nlevel=1
JOIN inventorytree inventorytree1
	ON inventorytree1.idinv = inventorytreelink.idparent
	



GO

print '[assetamortizationview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_contractkinddataview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_contractkinddataview
GO


--clear_table_info'csa_contractkinddataview'
CREATE      VIEW [csa_contractkinddataview]
(
	idcsa_contractkind,
	idcsa_contractkinddata,
	ayear,
	csa_contractkindcode,
	csa_contractkind,
	vocecsa,
	idfin,
	codefin,
	idacc,
	codeacc,
	idupb,codeupb,
	idsor_siope,
	sortcode_siope,
	ct,
	cu,
	lt,
	lu
)
AS SELECT 
	C.idcsa_contractkind,
	C.idcsa_contractkinddata,
	C.ayear,
	CK.contractkindcode,
	CK.description,
	
	C.vocecsa,
	C.idfin,
	fin.codefin,
	C.idacc,
	account.codeacc,
	C.idupb,
	upb.codeupb,
	C.idsor_siope,	
	sorting.sortcode,
	C.ct,
	C.cu,
	C.lt,
	C.lu
FROM csa_contractkinddata C
JOIN csa_contractkind CK
	ON C.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN upb 
	ON upb.idupb=C.idupb
LEFT OUTER JOIN fin 
	ON fin.idfin=C.idfin
LEFT OUTER JOIN account 
	ON account.idacc = C.idacc
LEFT OUTER JOIN sorting
	ON sorting.idsor = C.idsor_siope




GO

print '[csa_contractkinddataview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'listclassyearview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW listclassyearview
GO

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
	lt
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
	listclassyear.lt
FROM listclass
LEFT OUTER JOIN listclassyear
	ON listclass.idlistclass = listclassyear.idlistclass
LEFT OUTER JOIN intrastatcode
	ON intrastatcode.idintrastatcode = listclassyear.idintrastatcode
LEFT OUTER JOIN intrastatmeasure
	ON intrastatcode.idintrastatmeasure = intrastatmeasure.idintrastatmeasure
LEFT OUTER JOIN  intrastatservice
	ON intrastatservice.idintrastatservice= listclassyear.idintrastatservice
LEFT OUTER JOIN inventorytree
	ON inventorytree.idinv = listclass.idinv


GO

print '[listclassyearview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingusable
GO



CREATE              VIEW [sortingusable]
(
	codesorkind,
	idsorkind,
	idsor,
	sortcode,
	nlevel,
	leveldescr,
	paridsor,
	description,
	start,
	stop,
	cu, 
	ct, 
	lu, 
	lt,
	movkind
)
AS SELECT
	sortingkind.codesorkind,
	sorting.idsorkind,
	sorting.idsor,
	sorting.sortcode,
	sorting.nlevel,
	sortinglevel.description,
	sorting.paridsor,
	sorting.description,
	sorting.start, 
	sorting.stop, 
	sorting.cu, 
	sorting.ct, 
	sorting.lu,
	sorting.lt,
	sorting.movkind
FROM sorting
JOIN sortinglevel
	ON sortinglevel.nlevel = sorting.nlevel
	AND sortinglevel.idsorkind = sorting.idsorkind
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
WHERE ((sortinglevel.flag & 2) <> 0)
	AND sorting.idsor NOT IN
		(SELECT c1.paridsor FROM sorting c1
		WHERE c1.paridsor IS NOT NULL)



GO

print '[sortingusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetpieceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetpieceview
GO



CREATE    VIEW [assetpieceview]
(
	idasset,
	idpiece,
	lifestart,
	yearstart,
	nassetacquire,
	idupb,
	ninventory,
	idlocation,
	locationcode,
	location,
	idcurrlocation,
	currlocationcode,
	currlocation,
	idman,
	manager,
	idcurrman,
	currmanager,
	idinv,
	codeinv,
	idinv_lev1,
	codeinv_lev1,	
	inventorytree,
	inventorytree_lev1,
	idinventory,
	inventory,
	description,
	descriptionmain,
	idassetload,
	idassetloadkind,
	yassetload,
	nassetload,
	taxable,
	tax,
	taxrate,
	discount,
	cost,
	revals,
	revals_pending,
	subtractions,
	currentvalue,
	total,
	abatable,
	unabatable,
	idassetunload,
	idassetunloadkind,
	yassetunload,
	nassetunload,
	transmitted,
	flag,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	is_unloaded,
	is_loaded,	
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	asset.idasset,
	asset.idpiece,
	asset.lifestart,
	year(asset.lifestart),
	asset.nassetacquire,
	assetacquire.idupb,
	assetmain.ninventory,
	location.idlocation,
	location.locationcode,
	location.description,
	CL.idlocation,
	CL.locationcode,
	CL.description,
	manager.idman,
	manager.title,
	CM.idman,
	CM.title,
	assetacquire.idinv,
	inventorytree.codeinv,
	inventorytree1.idinv,
	inventorytree1.codeinv,
	inventorytree.description,
	inventorytree1.description,
	assetacquire.idinventory,
	inventory.description,
	assetacquire.description,
	CASE 
	 	WHEN (asset.idpiece = 1) THEN NULL 
		ELSE assetacquiremain.description
	END,
	assetacquire.idassetload, 
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	assetacquire.taxable,
	ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2),  --non era diviso prima
	assetacquire.taxrate,
	assetacquire.discount,
	AC.start,
	AC.revals,
	AC.revals_pending,
	AC.subtractions,
	AC.currentvalue,
	CONVERT(decimal(19,2),ROUND(
				ISNULL(assetacquire.taxable,0)
				*(1-ISNULL(assetacquire.discount,0))
				+ round(ISNULL(assetacquire.tax,0),2)/assetacquire.number
				,2)
		),
	ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) ,  --prima non era diviso
	ROUND((ISNULL(assetacquire.tax,0)-ISNULL(assetacquire.abatable,0)) / assetacquire.number,2),  --nuova colonna
	asset.idassetunload,
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	asset.transmitted,
	asset.flag,
	COALESCE(assetloadkind.idsor01, inventory.idsor01, upb.idsor01),
	COALESCE(assetloadkind.idsor02, inventory.idsor02, upb.idsor02),
	COALESCE(assetloadkind.idsor03, inventory.idsor03, upb.idsor03),
	COALESCE(assetloadkind.idsor04, inventory.idsor04, upb.idsor04),
	COALESCE(assetloadkind.idsor05, inventory.idsor05, upb.idsor05),	
	AC.is_unloaded,
	AC.is_loaded,	
	asset.cu,
	asset.ct,
	asset.lu,
	asset.lt
FROM asset
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
LEFT OUTER JOIN upb
	ON upb.idupb = assetacquire.idupb	
JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
	AND inventorytreelink.nlevel=1
JOIN inventorytree inventorytree1
	ON inventorytree1.idinv = inventorytreelink.idparent
JOIN asset AS assetmain
	ON (asset.idasset=assetmain.idasset) 
JOIN assetacquire AS assetacquiremain
	ON (assetacquiremain.nassetacquire = assetmain.nassetacquire)
JOIN assetview_current AC
	ON AC.idasset= asset.idasset and AC.idpiece = asset.idpiece
LEFT OUTER JOIN assetload
	ON assetload.idassetload = assetacquiremain.idassetload
LEFT OUTER JOIN assetloadkind
	ON assetloadkind.idassetloadkind = assetload.idassetloadkind	
LEFT OUTER JOIN assetunload
	ON assetunload.idassetunload = asset.idassetunload
LEFT OUTER JOIN assetlocation
	ON assetlocation.idasset = asset.idasset
	AND assetlocation.start IS NULL
LEFT OUTER JOIN location
	ON location.idlocation = assetlocation.idlocation
LEFT OUTER JOIN assetmanager
	ON assetmanager.idasset = asset.idasset
	AND assetmanager.start IS NULL
LEFT OUTER JOIN manager
	ON manager.idman = assetmanager.idman
LEFT OUTER JOIN location CL ON CL.idlocation= 
	(SELECT TOP 1 idlocation 
	FROM assetlocation 
	WHERE assetlocation.idasset = assetmain.idasset 
	ORDER BY start desc)
LEFT OUTER JOIN manager CM ON CM.idman= 
	(SELECT TOP 1 idman 
	FROM assetmanager 
	WHERE assetmanager.idasset = assetmain.idasset 
	ORDER BY start desc)
WHERE (assetmain.idpiece = 1)




GO

print '[assetpieceview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingunusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingunusable
GO



CREATE              VIEW [sortingunusable]
(
	codesorkind,
	idsorkind,
	idsor,
	sortcode,
	nlevel,
	leveldescr,
	paridsor,
	description,
	start,
	stop,
	cu, 
	ct, 
	lu, 
	lt,
	movkind
)
AS SELECT
	sortingkind.codesorkind,
	sorting.idsorkind,
	sorting.idsor,
	sorting.sortcode,
	sorting.nlevel,
	sortinglevel.description,
	sorting.paridsor,
	sorting.description,
	sorting.start, 
	sorting.stop, 
	sorting.cu, 
	sorting.ct, 
	sorting.lu,
	sorting.lt,
	sorting.movkind
FROM sorting
JOIN sortinglevel
	ON sortinglevel.nlevel = sorting.nlevel
	AND sortinglevel.idsorkind = sorting.idsorkind
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
WHERE (sortinglevel.flag & 2 = 0)
OR sorting.idsor IN
	(SELECT c1.paridsor FROM sorting c1
	WHERE c1.paridsor IS NOT NULL)



GO

print '[sortingunusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'intrastatcodeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW intrastatcodeview
GO




--Pino Rana, elaborazione del 10/08/2005 15:18:12
CREATE                                  VIEW intrastatcodeview 
  (
	ayear,
	idintrastatcode,
	code,
	description,
	idintrastatmeasure,
	measurecode,
	measuredescription,
	lt,
	lu
  )
  AS SELECT
	intrastatcode.ayear,
	intrastatcode.idintrastatcode,
	intrastatcode.code,
	intrastatcode.description,
	intrastatcode.idintrastatmeasure,
	intrastatmeasure.code,
	intrastatmeasure.description,
	intrastatcode.lt,
	intrastatcode.lu
  	FROM intrastatcode (NOLOCK)
	LEFT OUTER JOIN intrastatmeasure (NOLOCK)
	ON intrastatcode.idintrastatmeasure = intrastatmeasure.idintrastatmeasure


GO

print 'intrastatcodeview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetview
GO


CREATE     VIEW [assetview]
(
	idasset,
	idpiece,
	idasset_prev,
	idpiece_prev,
	idinventory_prev,
	codeinventory_prev,
	inventory_prev,
	ninventory_prev,
	idasset_next,
	idpiece_next,
	idinventory_next,
	codeinventory_next,
	inventory_next,
	ninventory_next,
	lifestart,
	yearstart,
	nassetacquire,
	ninventory,
	idlocation,
	locationcode,
	location,
	idcurrlocation,
	currlocationcode,
	currlocation,
	idman,
	manager,
	idcurrman,
	currmanager,
	idinv,
	codeinv,
	idinv_lev1,
	codeinv_lev1,	
	inventorytree,
	inventorytree_lev1,
	idinventory,
	codeinventory,
	inventory,
	description,
	idassetload,
	idassetloadkind,
	yassetload,
	nassetload,
	idloadmot,
	loadmotive,
	loaddescription,
	taxable,
	taxrate,
	tax,
	abatable,
	unabatable,
	number,
	discount,
	cost,
	revals,
	revals_pending,
	subtractions,
	currentvalue,
	total,
	idassetunload,
	idassetunloadkind,
	yassetunload,
	nassetunload,
	idunloadmot,
	unloadmotive,
	unloaddescription,
	unloaddoc,
	unloaddocdate,
	unloadenactment,
	unloadenactmentdate,
	unloadregistry,
	flag,
	flagunload,
	flagtransf,
	transmitted,
	flagload,
	loadkind,
	multifield,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	is_unloaded,
	is_loaded,
	cu,
	ct,
	lu,
	lt,
	rtf,
	txt
)
AS SELECT
	asset.idasset,
	asset.idpiece,
	asset.idasset_prev,
	asset.idpiece_prev,
	assetacquire_prev.idinventory,
	inventory_prev.codeinventory,
	inventory_prev.description,
	asset_prev.ninventory,
	asset_next.idasset,
	asset_next.idpiece,
	assetacquire_next.idinventory,
	inventory_next.codeinventory,
	inventory_next.description,
	asset_next.ninventory,
	asset.lifestart,
	year(asset.lifestart),
	asset.nassetacquire,
	assetmain.ninventory,
	location.idlocation,
	location.locationcode,
	location.description,
	CL.idlocation,
	CL.locationcode,
	CL.description,
	manager.idman,
	manager.title,
	CM.idman,
	CM.title,
	assetacquire.idinv,
	inventorytree.codeinv,
	inventorytree1.idinv,
	inventorytree1.codeinv,
	inventorytree.description,
	inventorytree1.description,
	assetacquire.idinventory,
	inventory.codeinventory,
	inventory.description,
	assetacquire.description,
	assetacquire.idassetload,
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	assetacquire.idmot,
	assetloadmotive.description,
	assetload.description,
	assetacquire.taxable,
	assetacquire.taxrate,
	ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2),
	ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) ,
	ROUND((ISNULL(assetacquire.tax,0)-ISNULL(assetacquire.abatable,0)) / assetacquire.number,2),
	assetacquire.number,
	assetacquire.discount,
-- Costo
	CASE	
			----------------------------------------------------------------------------------
			----------------- Considera i buoni di carico cespiti precedenti al 2005   -------
			----------------------------------------------------------------------------------
			WHEN (inventorykind.flag & 1 <> 0) 
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
			ELSE
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))		 		
	END,
	--revals applied
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization
				/*JOIN  inventoryamortization
				 ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA
					ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL
					ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is not null)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is not null)
					)
			 	)
				)
				--AND   (inventoryamortization.flag & 2 <> 0)
		),0),	
		--revals pending
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization
				/*JOIN  inventoryamortization
				ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA
					ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL
					ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is  null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is  null)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is  null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is  null)
					)
			 	)
				)				
				--AND   (inventoryamortization.flag & 2 <> 0)
				)
			,0),
	--subtractions
			CASE	WHEN asset.idpiece=1 THEN
	ISNULL(
			(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2)))
			 from assetacquire B
				join asset A
				on B.nassetacquire = A.nassetacquire
				where A.idasset = asset.idasset
				and   A.idpiece >1
				and   A.idassetunload IS NOT NULL
				and  ((B.flag & 1 <> 1) AND (B.flag & 2 <> 0)))
			,0)
	ELSE 0
	END,
	
	--valore iniziale cespiti
   CASE				
			WHEN (inventorykind.flag & 1 <> 0) 
			THEN
			CONVERT(decimal(19,2),ROUND(
				ROUND(ISNULL(assetacquire.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
				+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
				- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))
			ELSE
			CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
			,2))		 
		
	END
	--ammortamenti e rivalutazioni ufficiali	
	+
	ISNULL(
				(SELECT SUM(CONVERT(decimal(19,2),ROUND(
					ISNULL(assetamortization.assetvalue, 0.0) *
					ISNULL(assetamortization.amortizationquota,0.0)
					,2)))
				FROM  assetamortization
				/*JOIN  inventoryamortization
				ON    assetamortization.idinventoryamortization = 
				      inventoryamortization.idinventoryamortization
				*/
				LEFT OUTER JOIN assetunload AA
					ON  assetamortization.idassetunload = AA.idassetunload
				LEFT OUTER JOIN assetload AL
					ON  assetamortization.idassetload = AL.idassetload
				WHERE assetamortization.idasset = asset.idasset
				AND   assetamortization.idpiece = asset.idpiece
				AND (
					( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AL.adate is not null)
					))
					OR 
			            
					( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate is not null) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND AA.adate is not null)
					))
					)
				--AND   (inventoryamortization.flag & 2 <> 0)
				)
		,0)
	------------------------------------------------------------------------------------------
	-- Sottrae gli accessori scaricati caricati come posseduti e già inclusi nel cespite -----
	------------------------------------------------------------------------------------------	
	-
	CASE	WHEN asset.idpiece=1 THEN
	ISNULL(
			(SELECT SUM(CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
			+ ROUND(ISNULL(B.tax,0) / B.number,2)
			- ROUND(ISNULL(B.abatable,0) / B.number,2)))
			 from assetacquire B
				join asset A
				on B.nassetacquire = A.nassetacquire
				where A.idasset = asset.idasset
				and   A.idpiece >1
				and   A.idassetunload IS NOT NULL
				and  ((B.flag & 1 = 0) AND (B.flag & 2 <> 0)))
			,0)
	ELSE 0
	END,
	
	
	CONVERT(decimal(19,2),ROUND(
				ISNULL(assetacquire.taxable,0)
				*(1-ISNULL(assetacquire.discount,0))
				+ round(ISNULL(assetacquire.tax,0),2)/assetacquire.number
				,2)
		),
	asset.idassetunload,
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunload.idmot,
	assetunloadmotive.description,
	assetunload.description,
	assetunload.doc,
	assetunload.docdate,
	assetunload.enactment,
	assetunload.enactmentdate,
	assetunloadreg.title,
	asset.flag,
	CASE
		WHEN asset.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	CASE
		WHEN asset.flag & 4 <> 0 THEN 'S'
		ELSE 'N'
	END,
	asset.transmitted,
	CASE
		WHEN assetacquire.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	CASE
		WHEN assetacquire.flag & 2 <> 0 THEN 'R'
		ELSE 'N'
	END,
	asset.multifield,
	COALESCE(assetloadkind.idsor01, inventory.idsor01, upb.idsor01),
	COALESCE(assetloadkind.idsor02, inventory.idsor02, upb.idsor02),
	COALESCE(assetloadkind.idsor03, inventory.idsor03, upb.idsor03),
	COALESCE(assetloadkind.idsor04, inventory.idsor04, upb.idsor04),
	COALESCE(assetloadkind.idsor05, inventory.idsor05, upb.idsor05),
	CASE 
		when assetunload.adate IS NOT NULL or (asset.flag & 1 = 0)
			THEN 'S'
		ELSE
			'N'
	END,
	CASE 
		when assetload.ratificationdate IS NOT NULL or ((assetacquire.flag & 1 = 0) AND (assetacquire.flag & 2 <> 0))
			THEN 'S'
		ELSE
			'N'
	END,
	asset.cu,
	asset.ct,
	asset.lu,
	asset.lt,
	asset.rtf,
	asset.txt
FROM asset
JOIN asset AS assetmain	--
	ON (asset.idasset=assetmain.idasset) --
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventorykind
   ON inventory.idinventorykind= inventorykind.idinventorykind  
	
JOIN inventorytreelink
	ON inventorytreelink.idchild = assetacquire.idinv
	AND inventorytreelink.nlevel=1
JOIN inventorytree inventorytree1
	ON inventorytree1.idinv = inventorytreelink.idparent
LEFT OUTER JOIN assetload
	ON assetacquire.idassetload = assetload.idassetload
LEFT OUTER JOIN assetloadkind
	ON assetloadkind.idassetloadkind = assetload.idassetloadkind
LEFT OUTER JOIN upb
	ON upb.idupb = assetacquire.idupb
LEFT OUTER JOIN assetunload
	ON asset.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetlocation
	ON assetlocation.idasset = asset.idasset
	AND assetlocation.start IS NULL
LEFT OUTER JOIN location
	ON location.idlocation = assetlocation.idlocation
LEFT OUTER JOIN assetmanager
	ON assetmanager.idasset = asset.idasset
	AND assetmanager.start IS NULL
LEFT OUTER JOIN asset asset_prev
	ON asset.idasset_prev = asset_prev.idasset
	AND asset.idpiece_prev = asset_prev.idpiece
LEFT OUTER JOIN assetacquire assetacquire_prev
	ON asset_prev.nassetacquire = assetacquire_prev.nassetacquire
LEFT OUTER JOIN inventory inventory_prev
	ON inventory_prev.idinventory = assetacquire_prev.idinventory
LEFT OUTER JOIN asset asset_next
	ON asset.idasset = asset_next.idasset_prev
	AND asset.idpiece = asset_next.idpiece_prev
LEFT OUTER JOIN assetacquire assetacquire_next
	ON asset_next.nassetacquire = assetacquire_next.nassetacquire
LEFT OUTER JOIN inventory inventory_next
	ON inventory_next.idinventory = assetacquire_next.idinventory
LEFT OUTER JOIN manager
	ON manager.idman = assetmanager.idman
LEFT OUTER JOIN location CL on CL.idlocation = 
	(SELECT TOP 1 idlocation
	FROM assetlocation WHERE assetlocation.idasset = assetmain.idasset
	ORDER BY start desc)
LEFT OUTER JOIN manager CM ON CM.idman = 
	(SELECT TOP 1 idman
	FROM assetmanager
	WHERE assetmanager.idasset = assetmain.idasset
	ORDER BY start desc)
LEFT OUTER JOIN assetloadmotive 
	ON assetacquire.idmot = assetloadmotive.idmot
LEFT OUTER JOIN assetunloadmotive 
	ON assetunload.idmot = assetunloadmotive.idmot
LEFT OUTER JOIN registry assetunloadreg 
	ON assetunload.idreg = assetunloadreg.idreg
WHERE (assetmain.idpiece = 1)




GO

print '[assetview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingkindview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingkindview
GO



CREATE              VIEW sortingkindview
(
	idsorkind,
	codesorkind,
	description,
	nphaseincome,
	incomephase,
	nphaseexpense,
	expensephase,
	flagcheckavailability,
	flagforced,
	start,
	stop,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sortingkind.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	sortingkind.nphaseincome,
	incomephase.description,
	sortingkind.nphaseexpense,
	expensephase.description,
	CASE 
		WHEN  ((sortingkind.flag&2)<> 0) THEN 'S'
		ELSE  'N'
	END,
	CASE 
		WHEN  ((sortingkind.flag&1)<> 0) THEN 'S'
		ELSE 'N'
	END,
	sortingkind.start,
	sortingkind.stop,
	sortingkind.cu,
	sortingkind.ct,
	sortingkind.lu,
	sortingkind.lt
FROM sortingkind 
LEFT OUTER JOIN incomephase 
	ON incomephase.nphase = sortingkind.nphaseincome
LEFT OUTER JOIN expensephase 
	ON expensephase.nphase = sortingkind.nphaseexpense



GO

print 'sortingkindview OK'

GO

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'parasubcontractfamilyview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW parasubcontractfamilyview
GO


CREATE       VIEW [parasubcontractfamilyview]
(
	idcon,
	idreg,
	ayear,
	idfamily,
	surname,
	forename,
	idaffinity,
	affinity,
	idcitybirth,
	city,
	province,
	idnation,
	nation,
	birthdate,
	flagforeign,
	gender,
	cf,
	startapplication,
	stopapplication,
	appliancepercentage,
	starthandicap,
	foreignresident,
	flagdependent,
	amount,
	childasparent,
	ct, cu, lt, lu
)
AS
SELECT
	f.idcon,
	c.idreg,
	f.ayear,
	f.idfamily,
	f.surname,
	f.forename,
	f.idaffinity,
	tp.description,
	f.idcitybirth,
	gc.title,
	gp.province,
	f.idnation,
	gn.title,
	f.birthdate,
	f.flagforeign,
	f.gender,
	f.cf,
	f.startapplication,
	f.stopapplication,
	f.appliancepercentage,
	f.starthandicap,
	f.foreignresident,
	f.flagdependent,
	f.amount,
	f.childasparent,
	f.ct, f.cu, f.lt, f.lu
FROM parasubcontractfamily f
LEFT JOIN parasubcontract c
	ON f.idcon = c.idcon
LEFT OUTER JOIN registry cd
	ON c.idreg = cd.idreg
LEFT OUTER JOIN geo_city gc
	ON f.idcitybirth = gc.idcity
LEFT OUTER JOIN geo_country gp
	ON gc.idcountry = gp.idcountry
LEFT OUTER JOIN geo_nation gn
	ON f.idnation = gn.idnation
JOIN affinity tp
	ON f.idaffinity = tp.idaffinity



GO

print '[parasubcontractfamilyview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatedetailavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatedetailavailable
GO



CREATE  VIEW [mandatedetailavailable]
(
	idmankind,
	yman,
	nman,
	idgroup,
	mankind,
	codeinv,
	inventorytree,
	registry,
	detaildescription,
	ordered,
	loaded,
	residual,
	assetkind,
	start,
	stop,
	linktoinvoice,
	linktoasset,
	multireg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	flagto_unload,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT DISTINCT 
	mandatedetail.idmankind,
	mandatedetail.yman, 
	mandatedetail.nman, 
	mandatedetail.idgroup,
	mandatekind.description,
	inventorytree.codeinv, 
	inventorytree.description,
	--registry.title, 
	CASE
		WHEN mandate.idreg is not null THEN (select title from
						registry 
						where idreg= mandate.idreg)
		WHEN mandatedetail.idreg is not null THEN (select title from
						registry 
						where idreg= mandatedetail.idreg)
		ELSE null
	END,
	mandatedetail.detaildescription, 
	mandatedetail.number,	--ordered
	(SELECT ISNULL(SUM(number), 0)
		FROM assetacquire
		WHERE mandatedetail.idmankind = assetacquire.idmankind
		AND mandatedetail.yman = assetacquire.yman
		AND mandatedetail.nman = assetacquire.nman
		AND mandatedetail.idgroup = assetacquire.rownum), --loaded
	ISNULL(mandatedetail.number, 0) -
	(SELECT ISNULL(SUM(number), 0)
		FROM assetacquire
		WHERE mandatedetail.idmankind = assetacquire.idmankind
		AND mandatedetail.yman = assetacquire.yman
		AND mandatedetail.nman = assetacquire.nman
		AND mandatedetail.idgroup = assetacquire.rownum), --residual
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.flagto_unload,
	isnull(mandate.idsor01,mandatekind.idsor01),
	isnull(mandate.idsor02,mandatekind.idsor02),
	isnull(mandate.idsor03,mandatekind.idsor03),
	isnull(mandate.idsor04,mandatekind.idsor04),
	isnull(mandate.idsor05,mandatekind.idsor05)		
FROM mandatedetail
JOIN mandatekind with (nolock)
	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN inventorytree  ON inventorytree.idinv = mandatedetail.idinv
INNER JOIN mandate 
	ON mandate.idmankind = mandatedetail.idmankind
	AND mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
--INNER JOIN registry WITH (NOLOCK) ON registry.idreg = mandate.idreg
LEFT OUTER JOIN mandatestatus (NOLOCK)	
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
WHERE mandatedetail.stop is null
       


GO

print '[mandatedetailavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registrysortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registrysortingview
GO


CREATE              VIEW [registrysortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	quota,
	sortcode,
	sorting,
	idreg,
	registry,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	registrysorting.idsor,
	registrysorting.quota,
	sorting.sortcode,
	sorting.description,
	registrysorting.idreg,
	registry.title,
	registrysorting.cu,
	registrysorting.ct,
	registrysorting.lu,
	registrysorting.lt
FROM registrysorting 
JOIN sorting 
	ON sorting.idsor = registrysorting.idsor
JOIN sortingkind 
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN registry 
	ON registrysorting.idreg = registry.idreg


GO

print '[registrysortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandategroupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandategroupview
GO


CREATE     VIEW [mandategroupview]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mankind,
	idinv,
	codeinv,
	inventorytree,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	assetkind,
	start,
	stop,
	idexp_taxable,
	idexp_iva,	
	taxable_euro,
	iva_euro,
	idupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idman,
	cu,
	ct,
	lu,
	lt,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	toinvoice,
	exchangerate
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.rownum,
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
 	mandate.idreg,
  	registry.title,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	mandatedetail.taxable,
	mandatedetail.taxrate,
	mandatedetail.tax,
  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva,
 	    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		),
	ROUND(mandatedetail.tax,2),
	mandatedetail.idupb,
	COALESCE (mandate.idsor01,mandatekind.idsor01,upb.idsor01),
	COALESCE (mandate.idsor02,mandatekind.idsor02,upb.idsor02),
	COALESCE (mandate.idsor03,mandatekind.idsor03,upb.idsor03),
	COALESCE (mandate.idsor04,mandatekind.idsor04,upb.idsor04),
	COALESCE (mandate.idsor05,mandatekind.idsor05,upb.idsor05),
	mandate.idman,
	mandatedetail.cu,
	mandatedetail.ct,
	mandatedetail.lu,
	mandatedetail.lt,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandate.exchangerate
FROM mandatedetail
JOIN mandatekind with (nolock)
	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT JOIN inventorytree
	ON inventorytree.idinv = mandatedetail.idinv
LEFT OUTER JOIN upb
	ON upb.idupb = mandatedetail.idupb
JOIN ivakind
	ON ivakind.idivakind = mandatedetail.idivakind
JOIN mandate
	ON mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind
JOIN registry
	ON registry.idreg = mandate.idreg



GO

print '[mandategroupview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoiceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoiceview
GO



CREATE  VIEW [invoiceview]
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	idreg,
	registry,
	registryreference,
	description,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	packinglistnum,
	packinglistdate,
	officiallyprinted,
	flagdeferred,
	taxable,
	tax,
	unabatable,
	total,
	active,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	ycon,
	ncon,
	idintrastatnation_origin,
	intrastatnation_origin,
	idintrastatnation_provenance,	
	intrastatnation_provenance,
	idintrastatnation_destination,
	intrastatnation_destination,
	idcountry_origin,
	country_origin,
	idcountry_destination,
	country_destination,
	flagintracom,
	idintrastatkind,
	intrastatkind,
	idintrastatnation_payment,
	intrastatnation_payment,
	idintrastatpaymethod,
	intrastatpaymethod,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	flag_invoice,
	totransmit,
	idblacklist,
	idblnation,
	blnation,
	blcode,
	idinvkind_real,
	invkind_real,
	yinv_real, 
	ninv_real,
	autoinvoice,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05 	
	)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoice.yinv,
	invoice.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoice.idreg,
	registry.title,
	invoice.registryreference,
	invoice.description,
	invoice.paymentexpiring,
	invoice.idexpirationkind,
	invoice.idcurrency,
	currency.codecurrency,
	currency.description,
	invoice.exchangerate,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	invoice.packinglistnum,
	invoice.packinglistdate,
	--invoice.flagintra,
	invoice.officiallyprinted,
	invoice.flagdeferred,
	ISNULL(
		(SELECT
 	    	SUM(
			ROUND(D.taxable * ISNULL(D.npackage,D.number) * CONVERT(decimal(19,6),M.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(D.discount, 0.0)))
			,2)
		)
		FROM invoicedetail D
		JOIN invoice M
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0),
	ISNULL(
		(SELECT SUM(ROUND(D.tax ,2))
		FROM invoicedetail D
		JOIN invoice M 
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0),
	ISNULL(
		(SELECT
		SUM(ROUND(D.unabatable ,2))
		FROM invoicedetail D
		JOIN invoice M 
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0),
	ISNULL(
		(SELECT
 	    	SUM(
			ROUND(D.taxable * ISNULL(D.npackage,D.number)* CONVERT(decimal(19,6),M.exchangerate) *
				(1 - CONVERT(decimal(19,6),ISNULL(D.discount, 0.0)))
			,2)
		)
		FROM invoicedetail D
		JOIN invoice M 
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0) +
	ISNULL(
		(SELECT SUM(ROUND(D.tax,2))
		FROM invoicedetail D
		JOIN invoice M 
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0),
	invoice.active,
	invoice.txt,
	invoice.cu, 
	invoice.ct, 
	invoice.lu,
	invoice.lt,
	profservice.ycon,
	profservice.ncon,
	invoice.iso_origin,
	ination_origin.description,
	invoice.iso_provenance,
	ination_provenance.description,
	invoice.iso_destination,
	ination_destination.description,
	invoice.idcountry_origin,
	country_origin.title,
	idcountry_destination,
	country_destination.title,
	invoice.flagintracom,
	invoice.idintrastatkind,
	intrastatkind.description,
	invoice.iso_payment,
	ination_payment.description,
	intrastatpaymethod.idintrastatpaymethod,
	intrastatpaymethod.description,
	AD.idaccmotive,
	AD.codemotive,
	ADCRG.idaccmotive,
	ADCRG.codemotive,
	invoice.idaccmotivedebit_datacrg,
	invoice.flag,
	CASE
		WHEN (invoice.flag=0) THEN 'S' 
		WHEN (invoice.flag=1) THEN 'N' 
		WHEN (invoice.flag=2) THEN 'Non Spec.' 
	END, 
	invoice.idblacklist,
	blacklist.idnation,
	blacklist.description,
	blacklist.blcode,
	invoice.idinvkind_real,
	M.description,
	invoice.yinv_real, 
	invoice.ninv_real,
	invoice.autoinvoice,
	isnull(invoice.idsor01,invoicekind.idsor01),
	isnull(invoice.idsor02,invoicekind.idsor02),
	isnull(invoice.idsor03,invoicekind.idsor03),
	isnull(invoice.idsor04,invoicekind.idsor04),
	isnull(invoice.idsor05,invoicekind.idsor05)	
FROM invoice WITH (NOLOCK)
JOIN invoicekind WITH (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN registry  WITH (NOLOCK)
	ON registry.idreg = invoice.idreg
LEFT OUTER JOIN currency  WITH (NOLOCK)
	ON currency.idcurrency = invoice.idcurrency
LEFT OUTER JOIN profservice  WITH (NOLOCK)
	ON profservice.idinvkind=invoice.idinvkind and profservice.yinv=invoice.yinv and profservice.ninv=invoice.ninv
LEFT OUTER JOIN intrastatnation ination_origin  WITH (NOLOCK)
	ON ination_origin.idintrastatnation= invoice.iso_origin
LEFT OUTER JOIN intrastatnation ination_provenance  WITH (NOLOCK)
	ON ination_provenance.idintrastatnation= invoice.iso_provenance
LEFT OUTER JOIN intrastatnation ination_destination  WITH (NOLOCK)
	ON ination_destination.idintrastatnation= invoice.iso_destination
LEFT OUTER JOIN geo_country country_origin WITH (NOLOCK)
	ON country_origin.idcountry= invoice.idcountry_origin
LEFT OUTER JOIN geo_country country_destination WITH (NOLOCK)
	ON country_destination.idcountry= invoice.idcountry_destination
LEFT OUTER JOIN intrastatnation ination_payment  WITH (NOLOCK)
	ON ination_payment.idintrastatnation= invoice.iso_payment
LEFT OUTER JOIN intrastatpaymethod WITH (NOLOCK)
	ON invoice.idintrastatpaymethod = intrastatpaymethod.idintrastatpaymethod
LEFT OUTER JOIN intrastatkind WITH (NOLOCK)
	ON intrastatkind.idintrastatkind= invoice.idintrastatkind
LEFT OUTER JOIN accmotive AD WITH (NOLOCK)
	ON AD.idaccmotive = invoice.idaccmotivedebit
LEFT OUTER JOIN accmotive ADCRG WITH (NOLOCK)
	ON ADCRG.idaccmotive = invoice.idaccmotivedebit_crg
LEFT OUTER JOIN blacklist WITH (NOLOCK)
	ON blacklist.idblacklist = invoice.idblacklist
LEFT OUTER JOIN invoicekind M WITH (NOLOCK)
	ON M.idinvkind = invoice.idinvkind_real



GO

print '[invoiceview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'parasubcontractview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW parasubcontractview
GO







CREATE   VIEW parasubcontractview
(
	ayear,
	idcon, ycon, ncon,
	idreg,
	idupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	registry,
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
	citytax_account, ratequantity_account, startmonth_account,
	idaccmotive,
	codemotive,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	idsor1,idsor2,idsor3
)
AS SELECT 
	i1.ayear,
	c1.idcon, c1.ycon, c1.ncon,
	c1.idreg,
	c1.idupb,
	isnull(c1.idsor01,UPB.idsor01),
	isnull(c1.idsor02,UPB.idsor02),
	isnull(c1.idsor03,UPB.idsor03),
	isnull(c1.idsor04,UPB.idsor04),
	isnull(c1.idsor05,UPB.idsor05),
	c2.title,
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
	i1.citytax_account, i1.ratequantity_account, i1.startmonth_account,
	c1.idaccmotive,
	AM.codemotive,
	c1.idaccmotivedebit,
	DB.codemotive,
	c1.idaccmotivedebit_crg,
	CRG.codemotive,
	c1.idaccmotivedebit_datacrg,
	c1.idsor1,c1.idsor2,c1.idsor3
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




GO

print 'parasubcontractview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatelinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatelinked
GO


-- Rusciano G. 01.12.2005
CREATE                                 VIEW [mandatelinked]
(
	ayear,
	idmankind, yman, nman, mankind,
	idmandatestatus,mandatestatus,
	idreg, registry, registryreference, idman, 
	manager,	
	description, deliveryexpiration, deliveryaddress, paymentexpiring, 
	idexpirationkind, idcurrency, 	codecurrency, currency,
	exchangerate, doc, docdate, adate, officiallyprinted,
	txt, rtf,isrequest,
	cu, ct, lu, lt,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	accountingyear.ayear,
	mandate.idmankind, mandate.yman, mandate.nman, mandatekind.description,
	mandate.idmandatestatus,mandatestatus.description,
	mandate.idreg, registry.title, mandate.registryreference, mandate.idman, 
	manager.title,
	mandate.description, deliveryexpiration,
	deliveryaddress, paymentexpiring, 
	idexpirationkind, mandate.idcurrency, currency.codecurrency,
	currency.description,
	mandate.exchangerate, mandate.doc, 
	mandate.docdate, adate, officiallyprinted,
	mandate.txt, mandate.rtf, mandatekind.isrequest,
	mandate.cu, mandate.ct, mandate.lu, mandate.lt,
	isnull(mandate.idsor01,mandatekind.idsor01),
	isnull(mandate.idsor02,mandatekind.idsor02),
	isnull(mandate.idsor03,mandatekind.idsor03),
	isnull(mandate.idsor04,mandatekind.idsor04),
	isnull(mandate.idsor05,mandatekind.idsor05)
FROM mandate (NOLOCK)
JOIN mandatekind (NOLOCK)
	ON mandatekind.idmankind = mandate.idmankind
LEFT OUTER JOIN registry (NOLOCK)
	ON registry.idreg = mandate.idreg
LEFT OUTER JOIN currency (NOLOCK)
	ON currency.idcurrency = mandate.idcurrency
LEFT OUTER JOIN manager (NOLOCK)
	ON manager.idman = mandate.idman
LEFT OUTER JOIN mandatestatus (NOLOCK)
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
CROSS JOIN accountingyear (NOLOCK)
WHERE EXISTS (SELECT * 
	        FROM expensemandate AS MM 
		JOIN expenseyear II
		  ON II.idexp=MM.idexp
		 AND MM.idmankind = mandate.idmankind
		 AND MM.yman=mandate.yman
		 AND MM.nman=mandate.nman
		 WHERE  II.ayear = accountingyear.ayear)			


GO

print '[mandatelinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingexpensefilterview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingexpensefilterview
GO


CREATE              VIEW [sortingexpensefilterview]
(
	codefin,finance,
	codeupb,upb,
	regsortingkind, 
	registrysortcode, 
	registrykind, 
	manager, 
	sortingkind, 
	sortingcode, 
	sorting,
	ayear,
	idautosort,
	idsorkind,
	codesorkind,
	idsorkindreg,
	codesorkindreg,
	ct,
	cu,
	jointolessspecifics,
	idfin,
	idsor,
	idsorreg,
	lt,
	lu,
	idman,
	idupb
)
AS
SELECT     	
	fin.codefin, fin.title,
	upb.codeupb, upb.title, 
	t2.description, 
	c2.sortcode, 
	c2.description, 
	manager.title,
	sortingkind.description,
	sorting.sortcode,
	sorting.description,
	A.ayear,
	A.idautosort,
	sorting.idsorkind,
	sortingkind.codesorkind,
	c2.idsorkind,
	t2.codesorkind,
	A.ct,
	A.cu,
	A.jointolessspecifics,
	A.idfin,
	A.idsor,
	A.idsorreg,
	A.lt,
	A.lu,
	A.idman,
	A.idupb
FROM sortingexpensefilter A 
LEFT OUTER JOIN sorting
	ON A.idsor = sorting.idsor
JOIN sortingkind
	ON sorting.idsorkind = sortingkind.idsorkind
LEFT OUTER JOIN sorting c2
	ON A.idsorreg = c2.idsor
LEFT OUTER JOIN sortingkind t2
	ON c2.idsorkind = t2.idsorkind
LEFT OUTER JOIN fin
	ON fin.idfin = A.idfin  and fin.ayear = A.ayear
LEFT OUTER JOIN upb
	ON upb.idupb = A.idupb
LEFT OUTER JOIN manager
	ON A.idman = manager.idman


GO

print '[sortingexpensefilterview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingincomefilterview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingincomefilterview
GO


CREATE                     VIEW [sortingincomefilterview]
(
	codefin,finance,
	codeupb,upb,
	regsortingkind, 
	registrysortcode, 
	registrykind, 
	manager, 
	sortingkind, 
	sortingcode, 
	sorting,
	ayear,
	idautosort,
	idsorkind,
	codesorkind,
	idsorkindreg,
	codesorkindreg,
	ct,
	cu,
	jointolessspecifics,
	idfin,
	idsor,
	idsorreg,
	lt,
	lu,
	idman,
	idupb
)
AS
SELECT
	fin.codefin, fin.title,
	upb.codeupb, upb.title, 
	t2.description, 
	c2.sortcode, 
	c2.description, 
	manager.title,
	sortingkind.description,
	sorting.sortcode,
	sorting.description,
	A.ayear,
	A.idautosort,
	sorting.idsorkind,
	sortingkind.codesorkind,
	c2.idsorkind,
	t2.codesorkind,
	A.ct,
	A.cu,
	A.jointolessspecifics,
	A.idfin,
	A.idsor,
	A.idsorreg,
	A.lt,
	A.lu,
	A.idman,
	A.idupb
FROM sortingincomefilter A 
LEFT OUTER JOIN sorting
	ON A.idsor = sorting.idsor
JOIN sortingkind
	ON sorting.idsorkind = sortingkind.idsorkind
LEFT OUTER JOIN sorting c2
	ON A.idsorreg = c2.idsor
LEFT OUTER JOIN sortingkind t2
	ON c2.idsorkind = t2.idsorkind
LEFT OUTER JOIN fin
	ON fin.idfin = A.idfin  and fin.ayear = A.ayear
LEFT OUTER JOIN upb
	ON upb.idupb = A.idupb
LEFT OUTER JOIN manager
	ON A.idman = manager.idman


GO

print '[sortingincomefilterview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paydispositiondetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paydispositiondetailview
GO


CREATE VIEW [paydispositiondetailview]
(
	idpaydisposition,
	iddetail,
	surname,
	forename,
	title,
	gender,
	birthdate,
	flaghuman,
	idcity,
	city,
	provincecode,
	idnation,
	nation,
	cf,
	p_iva,
	address,
	location,
	province,
	cap,
	abi,
	bankdescription,
	cab,
	cabdescription,
	motive,
	email,
	amount,
	paymentcode,
	cc,
	cin,
	iban,
	kpay,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	D.idpaydisposition,
	D.iddetail,
	D.surname,
	D.forename,
	D.title,
	D.gender,
	D.birthdate,
	flaghuman,
	D.idcity,
	GC.title,
	GCO.province,
	D.idnation,
	GN.title,
	D.cf,
	D.p_iva,
	D.address,
	D.location,
	D.province,
	D.cap,
	D.abi,
	B.description,
	D.cab,
	C.description,
	D.motive,
	D.email,
	D.amount,
	D.paymentcode,
	D.cc,
	D.cin,
	D.iban,
	M.kpay,
	D.ct,
	D.cu,
	D.lt,
	D.lu
FROM paydispositiondetail D
JOIN paydisposition P
	ON P.idpaydisposition = D.idpaydisposition
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = D.idcity
LEFT OUTER JOIN geo_country GCO
	ON GCO.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN
	ON GN.idnation = D.idnation
LEFT OUTER JOIN bank B
	ON B.idbank = D.abi
LEFT OUTER JOIN cab C
	ON C.idbank = D.abi
	AND C.idcab = D.cab
LEFT OUTER JOIN payment M
	ON M.kpay = P.kpay


GO

print '[paydispositiondetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingprevexpensevarview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingprevexpensevarview
GO


CREATE              VIEW sortingprevexpensevarview
(
	yvar,
	nvar,
	idsorkind,
	codesorkind,
	idsor,
	sortcode,
	sorting,
	ayear,
	description,
	amount,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sortingprevexpensevar.yvar,
	sortingprevexpensevar.nvar,
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingprevexpensevar.idsor,
	sorting.sortcode,
	sorting.description,
	sortingprevexpensevar.ayear,
	sortingprevexpensevar.description,
	sortingprevexpensevar.amount,
	sortingprevexpensevar.adate,
	sortingprevexpensevar.cu,
	sortingprevexpensevar.ct,
	sortingprevexpensevar.lu,
	sortingprevexpensevar.lt
FROM sortingprevexpensevar 
JOIN sorting 
	ON sortingprevexpensevar.idsor = sorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind


GO

print 'sortingprevexpensevarview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'ivapaydetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW ivapaydetailview
GO




CREATE    VIEW [ivapaydetailview]
(
	yivapay,
	nivapay,
	start,
	stop,
	idivaregisterkind,
	codeivaregisterkind,
	description,
	registerclass,
	iva,
	ivadeferred,
	ivatotal,
	unabatable,
	unabatabledeferred,
	unabatabletotal,
	prorata,
	mixed,
	ivanet,
	ivanetdeferred,
	flagactivity,
	cu, 
	ct, 
	lu, 
	lt
	)
	AS SELECT
	ivapaydetail.yivapay,
	ivapaydetail.nivapay,
	ivapay.start,
	ivapay.stop,
	ivapaydetail.idivaregisterkind,
	ivaregisterkind.codeivaregisterkind,
	ivaregisterkind.description,
	ivaregisterkind.registerclass,
	ivapaydetail.iva,
	ivapaydetail.ivadeferred,
	ISNULL(ivapaydetail.iva,0) + ISNULL(ivapaydetail.ivadeferred,0),
	ivapaydetail.unabatable,
	ivapaydetail.unabatabledeferred,
	ISNULL(ivapaydetail.unabatable,0) + ISNULL(ivapaydetail.unabatabledeferred,0),
	ivapaydetail.prorata,
	ivapaydetail.mixed,
	ivapaydetail.ivanet,
	ivapaydetail.ivanetdeferred,
	ivaregisterkind.flagactivity,
	ivapaydetail.cu, 
	ivapaydetail.ct, 
	ivapaydetail.lu,
	ivapaydetail.lt 
	FROM ivapaydetail (NOLOCK)
	JOIN ivaregisterkind (NOLOCK)
	ON ivaregisterkind.idivaregisterkind = ivapaydetail.idivaregisterkind
  JOIN ivapay (NOLOCK)
	ON ivapay.nivapay = ivapaydetail.nivapay
	AND ivapay.yivapay = ivapaydetail.yivapay

GO

print '[ivapaydetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'partincomesetupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW partincomesetupview
GO

--Pino Rana, elaborazione del 10/08/2005 15:18:08
CREATE                                             VIEW partincomesetupview
	(
	idfinincome,
	yfinincome,
	finincomecode,
	finincometitle,
	idfinexpense,
	yfinexpense,
	finexpensecode,
	finexpensetitle,
  percentage,
  cu,
  ct,
  lu,
  lt
 	)
	AS SELECT
	partincomesetup.idfinincome,
	bilancioentrata.ayear,
	bilancioentrata.codefin,
	bilancioentrata.title,
	partincomesetup.idfinexpense,
	bilanciospesa.ayear,
	bilanciospesa.codefin,
	bilanciospesa.title,
	partincomesetup.percentage,
	partincomesetup.cu,
	partincomesetup.ct,
	partincomesetup.lu,
	partincomesetup.lt
	FROM partincomesetup (NOLOCK)
	JOIN fin bilancioentrata (NOLOCK)
	ON bilancioentrata.idfin = partincomesetup.idfinincome
	JOIN fin bilanciospesa (NOLOCK)
	ON bilanciospesa.idfin = partincomesetup.idfinexpense



GO

print 'partincomesetupview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatedetail_tostock') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatedetail_tostock
GO



---SELECT * FROM mandatedetail_tostock
CREATE VIEW [mandatedetail_tostock]
(
	idmankind,
	yman,
	nman,
	idgroup,
	mandatekind,
	adate,
 	idreg,
  	registry,
	detaildescription,
	annotations,
	npackage,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	start,
	stop,
	taxable_euro,
	iva_euro,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	exchangerate,
	linktoinvoice,
	multireg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	ordered,
	stocked,
	ntostock,
	idlist,
	description,
	intcode,
	intbarcode,
	extcode,
	extbarcode,
	validitystop,
	active,
	idpackage,
	package,
	idunit,
	unit,
	unitsforpackage,
	has_expiry,
	idlistclass,
	idstore,
	store,
	flagto_unload,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	isrequest
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.adate,
	CASE
		WHEN (mandate.idreg is not null) THEN (mandate.idreg)
		WHEN (mandatedetail.idreg is not null) THEN (mandatedetail.idreg)
		ELSE null
	END,
	CASE
		WHEN (mandate.idreg is not null) THEN (select title from
						registry 
						where idreg= mandate.idreg)
		WHEN (mandatedetail.idreg is not null) THEN (select title from
						registry 
						where idreg= mandatedetail.idreg)
		ELSE null
	END,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.npackage,
	mandatedetail.number,
	ISNULL(ROUND(SUM(mandatedetail.taxable),2),0), 	
	mandatedetail.taxrate,
	ISNULL(SUM(mandatedetail.tax),0), 
  	mandatedetail.discount,
	mandatedetail.start,
	mandatedetail.stop,
	Round(
	(SELECT  ISNULL(SUM(MD1.taxable),0)
	FROM mandatedetail MD1
	JOIN mandate M1
		ON M1.yman = MD1.yman AND M1.nman = MD1.nman AND M1.idmankind = MD1.idmankind
	WHERE M1.idmankind = mandatedetail.idmankind
		AND M1.yman = mandatedetail.yman 
		AND M1.nman = mandatedetail.nman 
		AND MD1.idgroup = mandatedetail.idgroup)
	 * ISNULL(ISNULL(mandatedetail.npackage,mandatedetail.number),0)   * CONVERT(DECIMAL(19,6),mandate.exchangerate)  
	 * (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0)))
	,2),
	isnull(sum(
		ROUND(mandatedetail.tax,2)
	),0),
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	isnull(sum(mandatedetail.unabatable),0),
	mandatedetail.flagmixed,
	mandate.exchangerate,
	mandatekind.linktoinvoice,
	mandatekind.multireg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.number,
	(SELECT  SUM (stock.number) 
   	   FROM stock
	  WHERE mandatedetail.idmankind = stock.idmankind
		AND mandatedetail.yman = stock.yman
		AND mandatedetail.nman = stock.nman
		AND mandatedetail.idgroup = stock.man_idgroup),
	mandatedetail.number 
	- ISNULL((SELECT  SUM (stock.number)
   	   FROM stock
	  WHERE mandatedetail.idmankind = stock.idmankind
		AND mandatedetail.yman = stock.yman
		AND mandatedetail.nman = stock.nman
		AND mandatedetail.idgroup = stock.man_idgroup 
	   ),0), 	-- ntostock 
	mandatedetail.idlist,
	list.description,
	list.intcode,
	list.intbarcode,
	list.extcode,
	list.extbarcode,
	list.validitystop,
	list.active,
	list.idpackage,
	package.description,
	list.idunit,
	unit.description,
	list.unitsforpackage,
	list.has_expiry,
	list.idlistclass,
	mandate.idstore,
	store.description,
	mandatedetail.flagto_unload,
	COALESCE (mandate.idsor01,mandatekind.idsor01),
	COALESCE (mandate.idsor02,mandatekind.idsor02),
	COALESCE (mandate.idsor03,mandatekind.idsor03),
	COALESCE (mandate.idsor04,mandatekind.idsor04),
	COALESCE (mandate.idsor05,mandatekind.idsor05),
	mandatekind.isrequest
FROM mandatedetail (NOLOCK)
JOIN mandatekind
	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT JOIN inventorytree (NOLOCK)
	ON inventorytree.idinv = mandatedetail.idinv
JOIN mandate (NOLOCK)
	ON mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN ivakind
	ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus (NOLOCK)	
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN list (NOLOCK)	
	ON mandatedetail.idlist = list.idlist
LEFT OUTER JOIN package
	ON package.idpackage = mandatedetail.idpackage
LEFT OUTER JOIN unit
	ON unit.idunit = mandatedetail.idunit
LEFT OUTER JOIN store
	ON store.idstore = mandate.idstore
GROUP BY 
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.idreg,
	mandate.adate,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.npackage,
	mandatedetail.number,
	mandatedetail.taxrate,
  	mandatedetail.discount,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandate.exchangerate,
	mandatekind.linktoinvoice,
	mandatekind.multireg,
	mandate.idreg,
	mandatedetail.idreg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandate.idstore,
	mandatedetail.idlist,
	store.description,
	list.description,
	list.intcode,
	list.intbarcode,
	list.extcode,
	list.extbarcode,
	list.validitystop,
	list.active,
	list.idpackage,package.description,
	list.idunit,unit.description,
	list.unitsforpackage,
	list.has_expiry,
	list.idlistclass,	
	mandatedetail.flagto_unload,
	COALESCE (mandate.idsor01,mandatekind.idsor01),
	COALESCE (mandate.idsor02,mandatekind.idsor02),
	COALESCE (mandate.idsor03,mandatekind.idsor03),
	COALESCE (mandate.idsor04,mandatekind.idsor04),
	COALESCE (mandate.idsor05,mandatekind.idsor05),
	mandatekind.isrequest
	



GO

print '[mandatedetail_tostock] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetamortizationunloadview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetamortizationunloadview
GO


CREATE      VIEW assetamortizationunloadview
(
	namortization,
	idasset,
	idpiece,
	idinventoryamortization,
	codeinventoryamortization,
	inventoryamortization,
	idinventory,
	inventory,
	ninventory,
	idlocation,
	locationcode,
	location,
	idcurrlocation,
	currlocationcode,
	currlocation,
	idman,
	manager,
	idcurrman,
	currmanager,
	nassetacquire,
	idupb,
	loaddescription,
	description,
	assetvalue,
	amortizationquota,
	amount,
  	adate,
	idassetunload, 
	idassetunloadkind,
	assetunloadkind,
	yassetunload,
	nassetunload,
	idassetload, 
	idassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
	flag,
	flagunload,
	flagload,
	transmitted,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	assetamortization.namortization,
	assetamortization.idasset,
	assetamortization.idpiece,
	assetamortization.idinventoryamortization,
	inventoryamortization.codeinventoryamortization,
	inventoryamortization.description,
	assetacquire.idinventory,
	inventory.description,
	assetmain.ninventory,
	location.idlocation,
	location.locationcode,
	location.description,
	CL.idlocation,
	CL.locationcode,
	CL.description,
	manager.idman,
	manager.title,
	CM.idman,
	CM.title,
	assetacquire.nassetacquire,
	assetacquire.idupb,
	assetacquire.description,
	assetamortization.description,
	assetamortization.assetvalue,
	assetamortization.amortizationquota,
	CONVERT(DECIMAL(19,2),ISNULL(assetamortization.assetvalue, 0) *
	ISNULL(assetamortization.amortizationquota, 0)),
	assetamortization.adate,
	assetamortization.idassetunload,
	assetunload.idassetunloadkind,
	assetunloadkind.description,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetamortization.idassetload,
	assetload.idassetloadkind,
	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,

	assetamortization.flag,
	CASE 
		WHEN assetamortization.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	CASE 
		WHEN assetamortization.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetamortization.transmitted,
	assetamortization.cu,
	assetamortization.ct,
	assetamortization.lu,
	assetamortization.lt
FROM assetamortization
JOIN asset
	ON asset.idasset = assetamortization.idasset 
	AND asset.idpiece = assetamortization.idpiece 
JOIN assetacquire
	ON assetacquire.nassetacquire = asset.nassetacquire
JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
JOIN inventoryamortization
	ON inventoryamortization.idinventoryamortization = assetamortization.idinventoryamortization
JOIN asset AS assetmain
	ON (asset.idasset = assetmain.idasset) 
LEFT OUTER JOIN assetunload
	ON assetamortization.idassetunload = assetunload.idassetunload
LEFT OUTER JOIN assetunloadkind
	ON assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
LEFT OUTER JOIN assetload
	ON assetamortization.idassetload = assetload.idassetload
LEFT OUTER JOIN assetloadkind
	ON assetloadkind.idassetloadkind = assetload.idassetloadkind
LEFT OUTER JOIN assetlocation
	ON assetlocation.idasset = asset.idasset
	AND assetlocation.start IS NULL
LEFT OUTER JOIN location
	ON location.idlocation = assetlocation.idlocation
LEFT OUTER JOIN assetmanager
	ON assetmanager.idasset = asset.idasset
	AND assetmanager.start IS NULL
LEFT OUTER JOIN manager
	ON manager.idman = assetmanager.idman
LEFT OUTER JOIN location CL ON CL.idlocation= 
	(SELECT TOP 1 idlocation 
	FROM assetlocation 
	WHERE assetlocation.idasset = assetmain.idasset 
	ORDER BY start desc)
LEFT OUTER JOIN manager CM ON CM.idman= 
	(SELECT TOP 1 idman 
	FROM assetmanager 
	WHERE assetmanager.idasset = assetmain.idasset 
	ORDER BY start desc)
WHERE (assetmain.idpiece = 1)
	








GO

print 'assetamortizationunloadview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingprevincomevarview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingprevincomevarview
GO


CREATE              VIEW sortingprevincomevarview
(
	yvar,
	nvar,
	idsorkind,
	codesorkind,
	idsor,
	sortcode,
	sorting,
	ayear,
	description,
	amount,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sortingprevincomevar.yvar,
	sortingprevincomevar.nvar,
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingprevincomevar.idsor,
	sorting.sortcode,
	sorting.description,
	sortingprevincomevar.ayear,
	sortingprevincomevar.description,
	sortingprevincomevar.amount,
	sortingprevincomevar.adate,
	sortingprevincomevar.cu,
	sortingprevincomevar.ct,
	sortingprevincomevar.lu,
	sortingprevincomevar.lt
FROM sortingprevincomevar
JOIN sorting
	ON sortingprevincomevar.idsor = sorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind



GO

print 'sortingprevincomevarview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'sortingapplicabilityview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW sortingapplicabilityview
GO


CREATE       VIEW  sortingapplicabilityview
(
	idsorkind,
	codesorkind,
	description,
	nphaseincome,
	incomephase,
	nphaseexpense,
	expensephase,
	flagcheckavailability,
	flagforced,
	active,
	cu,
	ct,
	lu,
	lt,
	tablename,
	start,
	stop
)
AS SELECT
	sortingkind.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	sortingkind.nphaseincome,
	incomephase.description,
	sortingkind.nphaseexpense,
	expensephase.description,
	CASE 
		WHEN  ((sortingkind.flag&2)<> 0) THEN 'S'
		ELSE  'N'
	END,
	CASE 
		WHEN  ((sortingkind.flag&1)<> 0) THEN 'S'
		ELSE 'N'
	END,
	sortingkind.active,
	sortingkind.cu,
	sortingkind.ct,
	sortingkind.lu,
	sortingkind.lt,
	sortingapplicability.tablename,
	sortingkind.start,
	sortingkind.stop
FROM sortingkind 
LEFT OUTER JOIN incomephase 
	ON incomephase.nphase = sortingkind.nphaseincome
LEFT OUTER JOIN expensephase 
	ON expensephase.nphase = sortingkind.nphaseexpense
JOIN sortingapplicability
	ON sortingapplicability.idsorkind = sortingkind.idsorkind


GO

print 'sortingapplicabilityview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxpayview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxpayview
GO




CREATE               VIEW taxpayview 
(
	taxcode,
	taxref,
	taxkind,
	ytaxpay,
	ntaxpay,
	start,
	stop,
	description,
	amount,
	adate,
	idf24ep,
	fiscaltaxcode,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	taxpay.taxcode,
	tax.taxref,
	tax.description,
	taxpay.ytaxpay,
	taxpay.ntaxpay,
	taxpay.start,
	taxpay.stop,
	taxpay.description,
	taxpay.amount,
	taxpay.adate,
	taxpay.idf24ep,
	tax.fiscaltaxcode,
	taxpay.cu,
	taxpay.ct,
	taxpay.lu,
	taxpay.lt
FROM taxpay
JOIN tax
	ON tax.taxcode = taxpay.taxcode




GO

print 'taxpayview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'incomelastview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW incomelastview
GO


--clear_table_info'incomelastview'
-- select * from incomelastview
CREATE    VIEW [incomelastview]
(
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	parentymov,
	parentnmov,
	parentidinc,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idreg,
	registry,
	idman,
	manager,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
  	unpartitioned,
	flag,
	totflag,
	flagarrear,
	autokind,
	autocode,
	idpayment,
	expiration,
	adate,
	nbill,
	idpro,
	cu,
	ct,
	lu,
	lt,
	idtreasurer_main,
	idtreasurer
)
AS SELECT
	income.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	parentincome.ymov,
	parentincome.nmov,
	--income.ycreation,
	income.parentidinc,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	--income.amount,
	incomeyear_starting.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	-- Modificato da Francesco per correggere la visualizzazione dell'importo da assegnare su movimenti residui
        case income.nphase 
	 WHEN (SELECT incomefinphase FROM uniconfig) THEN
		CASE   
			WHEN ((incometotal.flag&1) = 0) THEN  ISNULL(incometotal.curramount,0)-ISNULL(incometotal.partitioned,0)
			ELSE
			0
		END
	ELSE
		  ISNULL(incometotal.curramount,0)-ISNULL(incometotal.partitioned,0)
	END,
	incomelast.flag,
	incometotal.flag, 
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	income.autocode,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	incomelast.nbill,
	incomelast.idpro,
	incomelast.cu,
	incomelast.ct,
	incomelast.lu,
	incomelast.lt,
	payment.idtreasurer,
	proceeds.idtreasurer
	FROM income (NOLOCK)
	JOIN incomephase (NOLOCK)
	ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)
	ON incomeyear.idinc = income.idinc 
	JOIN incometotal (NOLOCK)
	ON incometotal.idinc = income.idinc
	AND incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN income parentincome (NOLOCK)
	ON income.parentidinc = parentincome.idinc
	JOIN incomelast  (NOLOCK)
	ON incomelast.idinc = income.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)
	ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN fin (NOLOCK)
	ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)
	ON upb.idupb=incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)
	ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)
	ON manager.idman = income.idman
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  	ON incometotal_firstyear.idinc = income.idinc
  	AND ((incometotal_firstyear.flag & 2) <> 0 )
 	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  	AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	LEFT OUTER JOIN expenselast  (NOLOCK)
			ON expenselast.idexp = income.idpayment
	LEFT OUTER JOIN payment (NOLOCK)
		 ON payment.kpay = expenselast.kpay


GO

print '[incomelastview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationlinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationlinked
GO


CREATE    VIEW [itinerationlinked]
(
	ayear,
	idreg, registry,
	idser, service, codeser,
	iditineration,yitineration, nitineration,
	description,
	authorizationdate, start, stop, adate,
	admincarkmcost, owncarkmcost, footkmcost,
	admincarkm, owncarkm, footkm, 
	grossfactor,
	netfee, 
	totalgross,
	total,
	totadvance,
	idupb,
	codeupb,
	upb,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	codemotive,
	iditinerationstatus,
	itinerationstatus,
	txt, rtf,
	ct, cu, lu, lt
)
AS
SELECT 
	accountingyear.ayear,
	itineration.idreg, registry.title,
	itineration.idser, service.description, service.codeser,
	itineration.iditineration,itineration.yitineration, itineration.nitineration,
	itineration.description,
	itineration.authorizationdate, itineration.start, itineration.stop, itineration.adate,
	itineration.admincarkmcost, itineration.owncarkmcost, itineration.footkmcost,
	itineration.admincarkm, itineration.owncarkm, itineration.footkm, 
	itineration.grossfactor,
	itineration.netfee, 
	itineration.totalgross,
	itineration.total,
	itineration.totadvance,
	itineration.idupb,
	upb.codeupb,
	upb.title,
	itineration.idsor1,
	itineration.idsor2,
	itineration.idsor3,
	itineration.idaccmotive,
	accmotive.codemotive,
	itineration.iditinerationstatus,
	itinerationstatus.description,
	itineration.txt, itineration.rtf,
	itineration.ct, itineration.cu, itineration.lu, itineration.lt
FROM itineration
INNER JOIN expenseitineration WITH (NOLOCK)
ON itineration.iditineration = expenseitineration.iditineration
CROSS JOIN accountingyear
JOIN registry
	ON itineration.idreg = registry.idreg 
JOIN service
	ON service.idser = itineration.idser  
LEFT OUTER JOIN upb
	ON upb.idupb = itineration.idupb
LEFT OUTER JOIN accmotive
	ON accmotive.idaccmotive = itineration.idaccmotive
LEFT OUTER JOIN itinerationstatus 
		ON itinerationstatus.iditinerationstatus= itineration.iditinerationstatus
WHERE EXISTS (SELECT * 
		FROM expenseitineration AS  MM 
		JOIN expenseyear AS II
		ON   II.idexp=MM.idexp
		AND  MM.iditineration=itineration.iditineration
		WHERE II.ayear = accountingyear.ayear
)


GO

print '[itinerationlinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatedetailview_compact') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatedetailview_compact
GO


CREATE        VIEW [mandatedetailview_compact]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	idreg,
	detaildescription,
	annotations,
	number,
	npackage,
	taxable,
	taxrate,
	tax,
  	discount,
	start,
	stop,
	idexp_taxable,
	idexp_iva,	
	taxable_euro,
	iva_euro,
	rowtotal,
	idupb,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.rownum,
	mandatedetail.idgroup,
	mandatedetail.idreg,
  	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	mandatedetail.npackage,
	mandatedetail.taxable,
	mandatedetail.taxrate,
	mandatedetail.tax,
  	mandatedetail.discount,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva,
 	    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		),
	ROUND(mandatedetail.tax,2),
	ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)+
	ROUND(mandatedetail.tax,2),
	mandatedetail.idupb,
	mandatedetail.cu,
	mandatedetail.ct,
	mandatedetail.lu,
	mandatedetail.lt
FROM mandatedetail
JOIN mandate
	ON mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind

GO

print '[mandatedetailview_compact] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetacquireview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetacquireview
GO





CREATE       VIEW [assetacquireview]
( 
	nassetacquire,
	idmankind,
	yman,
	nman,
	rownum,
  	idreg,
  	registry,
	idmot,
	assetloadmotive,
	idinv,
  	codeinv,
  	inventorytree,
	description,
	idinventory,
	codeinventory,
	inventory,
	idassetload,
	idassetloadkind,
	codeassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
 	number,
	taxable,
	abatable,
	tax,
	taxrate,
  	discount,
	cost,--taxabletotal,
	total,
	startnumber,
  	adate,
	flag,
	flagload,
	loadkind,
	ispieceacquire,
	transmitted,
	idupb,
	idsor1,
	idsor2,
	idsor3,
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
	assetacquire.nassetacquire,
	assetacquire.idmankind,
	assetacquire.yman,
	assetacquire.nman,
	assetacquire.rownum,
  	assetacquire.idreg,
 	registry.title,
  	assetacquire.idmot,
  	assetloadmotive.description,
	assetacquire.idinv,
  	inventorytree.codeinv,
  	inventorytree.description,
	assetacquire.description,
	assetacquire.idinventory,
	inventory.codeinventory,
  	inventory.description,
	assetacquire.idassetload, 
	assetload.idassetloadkind,
	assetloadkind.codeassetloadkind,
  	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
  	assetacquire.number,
	assetacquire.taxable,
	assetacquire.abatable,
	assetacquire.tax,
	assetacquire.taxrate,
 	assetacquire.discount,
	/*CONVERT(decimal(19,2),ROUND(ISNULL(assetacquire.taxable,0)*
		(ISNULL(assetacquire.number,0))*
		(1+ISNULL(assetacquire.taxrate,0))*
		(1-ISNULL(assetacquire.discount,0)),2)),*/
	CONVERT(decimal(19,2),ROUND(
	ISNULL(assetacquire.taxable,0)
	*(1-ISNULL(assetacquire.discount,0)),2) *(ISNULL(assetacquire.number,0))
	+ ROUND((ISNULL(assetacquire.tax,0.0)- ISNULL(assetacquire.abatable,0.0)),2))	
	,
	CONVERT(decimal(19,2),
		ROUND(
		ISNULL(assetacquire.taxable,0)*(1-ISNULL(assetacquire.discount,0))
		,2)
		*(ISNULL(assetacquire.number,0))
		+ ISNULL(assetacquire.tax,0.0)),
	assetacquire.startnumber,
  	assetacquire.adate,
	assetacquire.flag, 
	CASE
		WHEN assetacquire.flag & 1 <> 0 THEN 'S' 
		ELSE 'N'
	END,
	CASE
		WHEN assetacquire.flag & 2 <> 0 THEN 'R'
		ELSE 'N'
	END,
	CASE
		WHEN assetacquire.flag & 4 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetacquire.transmitted,
	assetacquire.idupb,
	assetacquire.idsor1,
	assetacquire.idsor2,
	assetacquire.idsor3,
	COALESCE(assetloadkind.idsor01, inventory.idsor01, upb.idsor01),
	COALESCE(assetloadkind.idsor02, inventory.idsor02, upb.idsor02),
	COALESCE(assetloadkind.idsor03, inventory.idsor03, upb.idsor03),
	COALESCE(assetloadkind.idsor04, inventory.idsor04, upb.idsor04),
	COALESCE(assetloadkind.idsor05, inventory.idsor05, upb.idsor05),
  	assetacquire.cu,
  	assetacquire.ct,
  	assetacquire.lu, 
  	assetacquire.lt
FROM assetacquire
LEFT OUTER JOIN inventory
	ON inventory.idinventory = assetacquire.idinventory
LEFT OUTER JOIN inventorytree
	ON inventorytree.idinv = assetacquire.idinv
LEFT OUTER JOIN registry
	ON registry.idreg = assetacquire.idreg 
LEFT OUTER JOIN assetloadmotive
	ON assetloadmotive.idmot = assetacquire.idmot
LEFT OUTER JOIN assetload
	ON assetload.idassetload = assetacquire.idassetload
LEFT OUTER JOIN assetloadkind
	ON assetloadkind.idassetloadkind = assetload.idassetloadkind
LEFT OUTER JOIN upb
	ON upb.idupb = assetacquire.idupb

GO

print '[assetacquireview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensemandateview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensemandateview
GO

CREATE    VIEW expensemandateview 
(
	idmankind,
	yman,
	nman,
	movkind,
	idexp,
	mankind,
	nphase,
	phase,
	ymov,
	nmov,
	--ycreation,
	parentidexp,
	parentymov,
	parentnmov,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	totdetail,
	deltavalue, 
	deltapercent, 
	limitvalue,
	limitpercent,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	expensemandate.idmankind,
	expensemandate.yman,
	expensemandate.nman,
	expensemandate.movkind,
	expensemandate.idexp,
	mandatekind.description,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and 
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0),
	-- deltaamount
	ISNULL(
		(SELECT Y.amount
		FROM expenseyear Y
		JOIN expensetotal T
			ON Y.idexp = T.idexp
			AND Y.ayear = T.ayear
		WHERE (T.flag & 2) <> 0
			AND Y.idexp = expensemandate.idexp)
	,0) +
	ISNULL(
		(SELECT SUM(V.amount)
		FROM expensevar V
		WHERE V.idexp = expensemandate.idexp
			AND V.yvar <= expenseyear.ayear)
	,0)
	-
	(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)),
/* -- J.T.R. Commentata questa gestione perché con i residui dava problemi!
	isnull(expensetotal.curramount,0) 
	-
	(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)),
*/
	-- deltapercentage
	case
	when  
	      (
		(ISNULL(
			(SELECT Y.amount
			FROM expenseyear Y
			JOIN expensetotal T
				ON Y.idexp = T.idexp
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idexp = expensemandate.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM expensevar V
			WHERE V.idexp = expensemandate.idexp
				AND V.yvar <= expenseyear.ayear)
		,0)) = 0 AND 
		(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
		+
		isnull((select sum(iva_euro)
			from mandatedetailview_compact
			where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)) = 0
	      )
	then  0
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM expenseyear Y
			JOIN expensetotal T
				ON Y.idexp = T.idexp
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idexp = expensemandate.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM expensevar V
			WHERE V.idexp = expensemandate.idexp
				AND V.yvar <= expenseyear.ayear)
		,0)) <> 0 AND 
		(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
		+
		isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)) = 0
	      )
	then  1000
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM expenseyear Y
			JOIN expensetotal T
				ON Y.idexp = T.idexp
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idexp = expensemandate.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM expensevar V
			WHERE V.idexp = expensemandate.idexp
				AND V.yvar <= expenseyear.ayear)
		,0)) <> 0 and 
		(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
		+
		isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)) <> 0
	      )
	then
	((
	(ISNULL(
		(SELECT Y.amount
		FROM expenseyear Y
		JOIN expensetotal T
			ON Y.idexp = T.idexp
			AND Y.ayear = T.ayear
		WHERE (T.flag & 2) <> 0
			AND Y.idexp = expensemandate.idexp)
	,0) +
	ISNULL(
		(SELECT SUM(V.amount)
		FROM expensevar V
		WHERE V.idexp = expensemandate.idexp
			AND V.yvar <= expenseyear.ayear)
	,0))
	-
	(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
	),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)))
	/
	(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
	+
	isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)))
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM expenseyear Y
			JOIN expensetotal T
				ON Y.idexp = T.idexp
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idexp = expensemandate.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM expensevar V
			WHERE V.idexp = expensemandate.idexp
				AND V.yvar <= expenseyear.ayear)
		,0)) = 0 and 
		(isnull((select sum(taxable_euro)
		from mandatedetailview_compact
		where idexp_taxable = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0) 
		+
		isnull((select sum(iva_euro)
		from mandatedetailview_compact
		where idexp_iva = expensemandate.idexp and
                    ( (mandatedetailview_compact.start is null) OR ( datepart(year,mandatedetailview_compact.start)<=expenseyear.ayear) ) and
		    ( (mandatedetailview_compact.stop is null) OR ( datepart(year,mandatedetailview_compact.stop)> expenseyear.ayear) )  		    	            
		),0)) <> 0
	      )
	then - 1
	end,
	mandatekind.deltaamount,
	mandatekind.deltapercentage,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expensemandate.cu,
	expensemandate.ct,
	expensemandate.lu,
	expensemandate.lt
	FROM expensemandate
	JOIN expense
		ON expense.idexp = expensemandate.idexp
	JOIN expensephase
		ON expensephase.nphase = expense.nphase
	JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
	JOIN expensetotal
		ON expensetotal.idexp = expenseyear.idexp
		AND expensetotal.ayear = expenseyear.ayear
	JOIN mandatekind
		ON mandatekind.idmankind = expensemandate.idmankind
	LEFT OUTER JOIN expense parentexpense
		ON expense.parentidexp = parentexpense.idexp
	LEFT OUTER JOIN expense former
		ON expense.idformerexpense = former.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear
		ON expensetotal_firstyear.idexp = expense.idexp
		AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting
		ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
		AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	LEFT OUTER JOIN expenselast
		ON expenselast.idexp = expense.idexp
	LEFT OUTER JOIN service
		ON service.idser = expenselast.idser
	LEFT OUTER JOIN fin
		ON fin.idfin = expenseyear.idfin
	LEFT OUTER JOIN upb
		ON upb.idupb = expenseyear.idupb
	LEFT OUTER JOIN registry
		ON registry.idreg = expense.idreg
	LEFT OUTER JOIN manager
		ON manager.idman = expense.idman
	LEFT OUTER JOIN payment
		ON payment.kpay = expenselast.kpay


GO

print 'expensemandateview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetloadkindview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetloadkindview
GO


CREATE   VIEW assetloadkindview 
(
	idassetloadkind,
	description,
	idinventory,
	inventory,
	startnumber,
	flag,
	flaglinear,
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
	assetloadkind.idassetloadkind,
	assetloadkind.description,
	assetloadkind.idinventory,
	inventory.description,
	assetloadkind.startnumber,
	assetloadkind.flag, 
	CASE
		WHEN assetloadkind.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetloadkind.idsor01,
	assetloadkind.idsor02,
	assetloadkind.idsor03,
	assetloadkind.idsor04,
	assetloadkind.idsor05,
	assetloadkind.cu,
	assetloadkind.ct,
	assetloadkind.lu,
	assetloadkind.lt
FROM assetloadkind
JOIN inventory
	ON inventory.idinventory = assetloadkind.idinventory




GO

print 'assetloadkindview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finsortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finsortingview
GO


CREATE              VIEW [finsortingview]
(
	idsorkind,
	codesorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	idfin,
	finpart,
	quota,
	ayear,
	codefin,
	title,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	sorting.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	finsorting.idsor,
	sorting.sortcode, 
	sorting.description,
	finsorting.idfin,
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	finsorting.quota,
	fin.ayear,
	fin.codefin,
	fin.title,
	finsorting.cu,
	finsorting.ct,
	finsorting.lu,
	finsorting.lt
FROM finsorting
JOIN sorting
	ON sorting.idsor = finsorting.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN fin
	ON fin.idfin = finsorting.idfin

GO

print '[finsortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxsortingsetupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxsortingsetupview
GO



CREATE              VIEW [taxsortingsetupview]
(
	ayear,
	idautotaxsor,
	taxcode,
	taxref, 
	descrritenuta,
	idser,
	codeser,
	service,
	flaginherit,
	idsorkind,
	codesorkind,
	sortingkind,
	idsor_employproc,
	sortcode_employproc,
	sorting_employproc,
	idsor_adminproc,
	sortcode_adminproc,
	sorting_adminproc,
	idsor_adminpay,
	sortcode_adminpay,
	sorting_adminpay,
	idsor_taxpay,
	sortcode_taxpay,
	sorting_taxpay,	
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	taxsortingsetup.ayear,
	taxsortingsetup.idautotaxsor,
	taxsortingsetup.taxcode,
	tax.taxref,
	tax.description,
	taxsortingsetup.idser,
	service.codeser,
	service.description,
	taxsortingsetup.flaginherit,
	taxsortingsetup.idsorkind,
	sortingkind.codesorkind,
	sortingkind.description,
	taxsortingsetup.idsor_employproc,
	CM_employproc.sortcode,
	CM_employproc.description,
	taxsortingsetup.idsor_adminproc,
	CM_adminproc.sortcode,
	CM_adminproc.description,
	taxsortingsetup.idsor_adminpay,
	CM_adminpay.sortcode,
	CM_adminpay.description,
	taxsortingsetup.idsor_taxpay,
	CM_taxpay.sortcode,
	CM_taxpay.description,
	taxsortingsetup.cu,
	taxsortingsetup.ct,
	taxsortingsetup.lu,
	taxsortingsetup.lt
FROM taxsortingsetup
LEFT OUTER JOIN tax
	ON taxsortingsetup.taxcode = tax.taxcode
LEFT OUTER JOIN service
	ON taxsortingsetup.idser = service.idser
LEFT OUTER JOIN sortingkind
	ON taxsortingsetup.idsorkind = sortingkind.idsorkind
LEFT OUTER JOIN sorting CM_employproc
	ON taxsortingsetup.idsorkind = CM_employproc.idsorkind
	AND taxsortingsetup.idsor_employproc = CM_employproc.idsor
LEFT OUTER JOIN sorting CM_adminproc
	ON taxsortingsetup.idsorkind = CM_adminproc.idsorkind
	AND taxsortingsetup.idsor_adminproc = CM_adminproc.idsor
LEFT OUTER JOIN sorting CM_adminpay
	ON taxsortingsetup.idsorkind = CM_adminpay.idsorkind
	AND taxsortingsetup.idsor_adminpay = CM_adminpay.idsor
LEFT OUTER JOIN sorting CM_taxpay
	ON taxsortingsetup.idsorkind = CM_taxpay.idsorkind
	AND taxsortingsetup.idsor_taxpay = CM_taxpay.idsor



GO

print '[taxsortingsetupview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'profserviceavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW profserviceavailable
GO


CREATE          VIEW [profserviceavailable]
	(
	ycon,
	ncon,
	idreg,
	registry,
	description,
	doc,
	docdate,
	start,
	stop,
	adate,
	idupb,
	feegross,
	totalcost,
	totalgross,
	taxabletotal,
	ivatotal,
	linkedtotal,
	residual,
	idsor01,idsor02,idsor03,idsor04,idsor05
	)
	AS SELECT
	profservice.ycon,
	profservice.ncon,
	profservice.idreg,
	registry.title,
	profservice.description,
 	profservice.doc,
	profservice.docdate,
	profservice.start,
	profservice.stop,
	profservice.adate,
	profservice.idupb,
	profservice.feegross,
	profservice.totalcost,
	profservice.totalgross,
-- TOTALEIMPONIBILE = importobeneficiario - importoiva
	CONVERT(decimal(19,2),
		ROUND(profservice.totalgross - ISNULL(profservice.ivaamount,0),2)
	),
	profservice.ivaamount,
-- Calcolo TOTALEMOVIMENTI
	CONVERT(decimal(19,2),
		ROUND(
			ISNULL(
				(SELECT SUM(expenseyear_starting.amount)
				FROM expenseprofservice mov
				JOIN expense s
					ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
				LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
				WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT SUM(v.amount)
				FROM expenseprofservice mov
				JOIN expense s
				ON s.idexp = mov.idexp
				JOIN expensevar v
				ON v.idexp = mov.idexp
				WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
				AND v.autokind<>4
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT SUM(p.amount)
				FROM pettycashoperationprofservice mov
				JOIN pettycashoperation p
				ON mov.idpettycash = p.idpettycash
				AND mov.yoperation = p.yoperation
				AND mov.noperation = p.noperation
				WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon)
			,0)
		,2)
	),
-- RESIDUO = importobeneficiario - totalemovimenti
	CONVERT(decimal(19,2),
		ROUND(
			profservice.totalgross - 
			(
				ISNULL(
					(SELECT SUM(expenseyear_starting.amount)
					FROM expenseprofservice mov
					JOIN expense s
						ON s.idexp = mov.idexp
					LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
						ON expensetotal_firstyear.idexp = s.idexp
						AND ((expensetotal_firstyear.flag & 2) <> 0 )
					LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
						ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
						AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
					WHERE mov.ycon = profservice.ycon
						AND mov.ncon = profservice.ncon
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
				,0) +
				ISNULL(
					(SELECT SUM(v.amount)
					FROM expenseprofservice mov
					JOIN expense s
					ON s.idexp = mov.idexp
					JOIN expensevar v
					ON v.idexp = mov.idexp
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon
					AND v.autokind<>4
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					)
				,0) +
				ISNULL(
					(SELECT SUM(p.amount)
					FROM pettycashoperationprofservice mov
					JOIN pettycashoperation p
					ON mov.idpettycash = p.idpettycash
					AND mov.yoperation = p.yoperation
					AND mov.noperation = p.noperation
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon)
				,0)
			)
		,2)
	),
	profservice.idsor01,profservice.idsor02,profservice.idsor03,profservice.idsor04,profservice.idsor05
	FROM profservice (NOLOCK)
	JOIN registry (NOLOCK)
	ON registry.idreg = profservice.idreg
	WHERE profservice.totalgross >
	ISNULL(
		(SELECT SUM(expenseyear_starting.amount)
		FROM expenseprofservice mov
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
			ON expensetotal_firstyear.idexp = s.idexp
			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		)
	,0) +
	ISNULL(
		(SELECT SUM(v.amount)
		FROM expenseprofservice mov
		JOIN expense s
		ON s.idexp = mov.idexp
		JOIN expensevar v
		ON v.idexp = mov.idexp
		WHERE mov.ycon = profservice.ycon
		AND mov.ncon = profservice.ncon
		AND v.autokind<>4
		--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		)
	,0) +
	ISNULL(
		(SELECT SUM(p.amount)
		FROM pettycashoperationprofservice mov
		JOIN pettycashoperation p
		ON mov.idpettycash = p.idpettycash
		AND mov.yoperation = p.yoperation
		AND mov.noperation = p.noperation
		WHERE mov.ycon = profservice.ycon
		AND mov.ncon = profservice.ncon)
	,0)





GO

print '[profserviceavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetloadview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetloadview
GO




CREATE     VIEW assetloadview
(
	idassetload, 
	idassetloadkind,
	codeassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
	idreg,
	registry,
	idmot,
	codemot,
	assetloadmotive,
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
	lt
)
AS SELECT
	assetload.idassetload,
	assetload.idassetloadkind,
	assetloadkind.codeassetloadkind,
	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idreg,
	registry.title,
	assetload.idmot,
	assetloadmotive.codemot,
	assetloadmotive.description,
	assetload.doc,
	assetload.docdate,
	assetload.description,
	assetload.enactment,
	assetload.enactmentdate,
	assetload.adate,
	assetload.printdate,
	assetload.ratificationdate,
	assetload.transmitted,
	assetloadkind.idsor01,
	assetloadkind.idsor02,
	assetloadkind.idsor03,
	assetloadkind.idsor04,
	assetloadkind.idsor05,
	assetload.cu,
	assetload.ct,
	assetload.lu,
	assetload.lt
FROM assetload
JOIN assetloadkind
	ON assetloadkind.idassetloadkind = assetload.idassetloadkind
LEFT OUTER JOIN registry
	ON registry.idreg = assetload.idreg
LEFT OUTER JOIN assetloadmotive
	ON assetloadmotive.idmot = assetload.idmot






GO

print 'assetloadview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetview_amquota') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetview_amquota
GO


CREATE       VIEW [assetview_amquota]
(
	ayear,
	age,
	idinv,
	codeinv,
	amortizationquota,
	agemin,
	agemax
)
AS 

select ACCY.ayear, IA.age,IT.idinv,IT.codeinv,
			ISNULL(t4.amortizationquota,ISNULL(t3.amortizationquota,
	    	ISNULL(t2.amortizationquota,t1.amortizationquota))),IA.age,IA.agemax
	from inventorytree IT 
	cross join accountingyear ACCY 
	LEFT OUTER JOIN inventorytreelink IL1  
    		ON IL1.idchild = IT.idinv AND IL1.nlevel  = 1 
	LEFT OUTER JOIN inventorytreelink IL2  
	    	ON IL2.idchild = IT.idinv  AND IL2.nlevel = 2
	LEFT OUTER JOIN inventorytreelink IL3 
	    	ON IL3.idchild = IT.idinv  AND IL3.nlevel = 3 
	LEFT OUTER JOIN inventorytreelink IL4  
	    	ON IL4.idchild = IT.idinv  AND IL4.nlevel = 4 
	LEFT OUTER JOIN inventorysortingamortizationyear t1
		ON t1.idinv = IL1.idparent AND t1.ayear = ACCY.ayear
	LEFT OUTER JOIN inventorysortingamortizationyear t2
		ON t2.idinv = IL2.idparent  AND t2.ayear =ACCY.ayear
	LEFT OUTER JOIN inventorysortingamortizationyear t3
		ON t3.idinv = IL3.idparent AND t3.ayear =ACCY.ayear
	LEFT OUTER JOIN inventorysortingamortizationyear t4
		ON t4.idinv = IL4.idparent AND t4.ayear =ACCY.ayear
	left outer join inventoryamortization IA on 
		IA.idinventoryamortization= 
		ISNULL(t4.idinventoryamortization,ISNULL(t3.idinventoryamortization,ISNULL(t2.idinventoryamortization,t1.idinventoryamortization)))
		AND 
		  (IA.flag & 2 <> 0)	--ufficiale
			--and (IA.valuemin is null or IA.valuemin <= A.cost)
			--and (IA.valuemax is null or IA.valuemax >= A.cost)
		--AND (IA.age is null or IA.age <= (ACCY.ayear - DATEPART(YEAR,A.lifestart)) + 1  )
		--AND (IA.agemax is null or IA.agemax >= (ACCY.ayear - DATEPART(YEAR,A.lifestart)) + 1 )
		


GO

print '[assetview_amquota] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'autoclawbacksortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW autoclawbacksortingview
GO

CREATE   VIEW [autoclawbacksortingview]
(
	idclawback, clawbackref, description,
	sortingkind,sortingcode,sorting,
	ayear,
	idautosort,
	idsorkind,
	codesorkind,
	ct,
	cu,
	lt,
	lu
)
AS
SELECT     	
	clawback.idclawback, clawback.clawbackref, clawback.description,
	sortingkind.description,sorting.sortcode,sorting.description,
	A.ayear,
	A.idautosort,
	sortingkind.idsorkind,
	sortingkind.codesorkind,
	clawback.ct,
	clawback.cu,
	clawback.lt,
	clawback.lu
FROM autoclawbacksorting A
JOIN sortingkind
	ON sortingkind.idsorkind = A.idsorkind
LEFT OUTER JOIN sorting
	ON A.idsor = sorting.idsor
LEFT OUTER JOIN clawback
	ON A.idclawback = clawback.idclawback


GO

print '[autoclawbacksortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'profservicelinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW profservicelinked
GO



CREATE VIEW [profservicelinked]
(
	ayear,
	ycon,
	ncon,
	socialsecurityrate,
	pensioncontributionrate,
	ivarate,
	idreg,
	registry,
	idser,
	service,
	codeser,
	feegross,
	totalcost,
	totalgross,
	adate,
	stop,
	start,
	ndays,
	ivaamount,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt,
	ivafieldnumber,
	txt,
	rtf,
	description,
	docdate,
	doc,
	flaginvoiced,
	idinvkind,
	yinv,
	ninv,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
	expenseyear.ayear,
	profservice.ycon,
	profservice.ncon,
	profservice.socialsecurityrate,
	profservice.pensioncontributionrate,
	profservice.ivarate,
	profservice.idreg,
	registry.title,
	profservice.idser,
	service.description,
	service.codeser,
	profservice.feegross,
	profservice.totalcost,
	profservice.totalgross,
	profservice.adate,
	profservice.stop,
	profservice.start,
	profservice.ndays,
	profservice.ivaamount,
	profservice.cu,
	profservice.ct,
	profservice.lu,
	profservice.lt,
	profservice.ivafieldnumber,
	upb.idupb,
	upb.codeupb,
	upb.title,
	profservice.txt,
	profservice.rtf,
	profservice.description,
	profservice.docdate,
	profservice.doc,
	profservice.flaginvoiced,
	profservice.idinvkind,
	profservice.yinv,
	profservice.ninv,
	profservice.idsor01,profservice.idsor02,profservice.idsor03,profservice.idsor04,profservice.idsor05
FROM profservice with (nolock)
JOIN service with (nolock)
	ON profservice.idser = service.idser
JOIN registry with (nolock)
	ON profservice.idreg = registry.idreg
JOIN expenseprofservice with (nolock)
	ON expenseprofservice.ycon = profservice.ycon
	AND expenseprofservice.ncon = profservice.ncon
JOIN expenseyear with (nolock)
	ON expenseyear.idexp = expenseprofservice.idexp
LEFT OUTER JOIN upb with (nolock)
	ON upb.idupb = profservice.idupb
WHERE EXISTS
	(SELECT * FROM expenseprofservice
	WHERE expenseprofservice.ycon = profservice.ycon
	AND expenseprofservice.ncon = profservice.ncon)



GO

print '[profservicelinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetunloadkindview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetunloadkindview
GO



CREATE   VIEW assetunloadkindview 
(
	idassetunloadkind,
	description,
	idinventory,
	inventory,
	startnumber,
	flag,
	flaglinear,
	active,
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
	assetunloadkind.idassetunloadkind,
	assetunloadkind.description,
	assetunloadkind.idinventory,
	inventory.description,
 	assetunloadkind.startnumber,
	assetunloadkind.flag,
	CASE
		WHEN assetunloadkind.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetunloadkind.active,
	assetunloadkind.idsor01,
	assetunloadkind.idsor02,
	assetunloadkind.idsor03,
	assetunloadkind.idsor04,
	assetunloadkind.idsor05,
	assetunloadkind.cu,
	assetunloadkind.ct,
	assetunloadkind.lu,
	assetunloadkind.lt
FROM assetunloadkind
JOIN inventory
	ON inventory.idinventory = assetunloadkind.idinventory


GO

print 'assetunloadkindview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'profserviceresidual') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW profserviceresidual
GO


CREATE   VIEW [profserviceresidual]
(
	ycon,
	ncon,
	description,
	idreg,
	registry,
	start,
	stop,
	feegross,
	totalcost,
	totalgross,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkeddocum,
	linkedtotal,
	linkedtotalexpense,
	idupb,
	codeupb,
	upb,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
profservice.ycon,
profservice.ncon,
profservice.description,
profservice.idreg,
registry.title,
profservice.start,
profservice.stop,
profservice.feegross,
profservice.totalcost,
profservice.totalgross,
-- TOTALEIMPONIBILE = costototale - importoiva
CONVERT(decimal(19,2),
	ROUND(profservice.totalgross - ISNULL(profservice.ivaamount,0),2)
),
profservice.ivaamount,
-- Calcolo del RESIDUO
CONVERT(decimal(19,2),
	ROUND(
--select top 1 totflag,flagarrear from historypaymentview
		profservice.totalgross -
		(
			ISNULL(
				(SELECT SUM(expenseyear_starting.amount)
				FROM expenseprofservice mov
				JOIN expense s
					ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensetotal expensetotal_firstyear
					ON expensetotal_firstyear.idexp = s.idexp
					AND ((expensetotal_firstyear.flag & 2) <> 0 )
				LEFT OUTER JOIN expenseyear expenseyear_starting 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
				WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT ISNULL(SUM(v.amount), 0.0)
				FROM expenseprofservice mov
				JOIN expense s
					ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensevar v
					ON (v.idexp = mov.idexp)
				WHERE mov.ycon = profservice.ycon 
					AND mov.ncon = profservice.ncon
					AND (ISNULL(v.autokind,0)<>4)
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT SUM(p.amount)
				FROM pettycashoperationprofservice mov
				JOIN pettycashoperation p
					ON mov.idpettycash = p.idpettycash
					AND mov.yoperation = p.yoperation
					AND mov.noperation = p.noperation
				WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon)
			,0)
		)
	,2)
),
-- Calcolo del CONTIMPON (imponibile contabilizzato)
CONVERT(decimal(19,2),
	(
		(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
		FROM expenseprofservice mov  
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensetotal expensetotal_firstyear
			ON expensetotal_firstyear.idexp = s.idexp
			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			AND (mov.movkind = 3)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		) +
		(SELECT ISNULL(SUM(v.amount), 0.0)
		FROM expenseprofservice mov
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			AND mov.movkind = 3
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
	)
),
-- Calcolo del CONTIMPOS (imposta contabilizzata)
CONVERT(decimal(19,2),
	(
		(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
		FROM expenseprofservice mov
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensetotal expensetotal_firstyear
			ON expensetotal_firstyear.idexp = s.idexp
			AND ((expensetotal_firstyear.flag & 2) <> 0 )
		LEFT OUTER JOIN expenseyear expenseyear_starting 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			AND (mov.movkind = 2)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		) +
		(SELECT ISNULL(SUM(v.amount), 0.0)
		FROM expenseprofservice mov
		JOIN expense s
			ON s.idexp = mov.idexp
		LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
		WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon
			AND mov.movkind = 2
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
	)
),
-- Calcolo del CONTDOCUM (totale del documento contabilizzato)
CONVERT(decimal(19,2),
	(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseprofservice mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear
				ON expensetotal_firstyear.idexp = s.idexp
				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
				AND (mov.movkind = 1)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expenseprofservice mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
				ON v.idexp = mov.idexp
			WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
				AND mov.movkind = 1
				AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0)
		+
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationprofservice mov
			JOIN pettycashoperation p
				ON mov.idpettycash = p.idpettycash
				AND mov.yoperation = p.yoperation
				AND mov.noperation = p.noperation
			WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon)
		,0)
	)
),
-- Calcolo di TOTCONTABILIZZATO
CONVERT(decimal(19,2),
	(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount) 
			FROM expenseprofservice mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear
				ON expensetotal_firstyear.idexp = s.idexp
				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(	
			(SELECT SUM(v.amount)
			FROM expenseprofservice mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
				ON v.idexp = mov.idexp
			WHERE mov.ycon = profservice.ycon 
				AND mov.ncon = profservice.ncon
				AND (ISNULL(v.autokind,0)<>4)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationprofservice mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.ycon = profservice.ycon
			AND mov.ncon = profservice.ncon)
		,0)
	)
),
-- TOTCONTABILIZZATOSPESA
CONVERT(decimal(19,2),
	(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount) 
			FROM expenseprofservice mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear
				ON expensetotal_firstyear.idexp = s.idexp
				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = profservice.ycon
				AND mov.ncon = profservice.ncon
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(	
			(SELECT SUM(v.amount)
			FROM expenseprofservice mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
			WHERE mov.ycon = profservice.ycon 
			AND mov.ncon = profservice.ncon
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0)
	)
),
	upb.idupb,
	upb.codeupb,
	upb.title,
	profservice.idsor01,profservice.idsor02,profservice.idsor03,profservice.idsor04,profservice.idsor05
FROM profservice  with (nolock)
JOIN registry  with (nolock)
ON registry.idreg = profservice.idreg
LEFT OUTER JOIN upb with (nolock)
	ON upb.idupb = profservice.idupb


GO

print '[profserviceresidual] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetunloadview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetunloadview
GO




CREATE       VIEW assetunloadview
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
  	lt
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
  	assetunload.lt
FROM assetunload
JOIN assetunloadkind
	ON assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
LEFT OUTER JOIN registry
	ON registry.idreg = assetunload.idreg
LEFT OUTER JOIN assetunloadmotive
	ON assetunloadmotive.idmot = assetunload.idmot





GO

print 'assetunloadview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'profserviceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW profserviceview
GO





CREATE VIEW [profserviceview]
(
	ycon,
	ncon,
	start,
	stop,
	adate,
	idreg,
	registry,
	feegross,
	idser,
	service,
	codeser,
	description,
	idivakind,
	ivakind,
	ivarate,
	ndays,
	ivaamount,
	totalcost, --costo totale
	totalgross,  --lordo al beneficiario
	taxabletotal, --totale imponibile
	cu,
	ct,
	lu,
	lt,
	ivafieldnumber,
	pensioncontributionrate,
	socialsecurityrate,
	txt,
	doc,
	docdate,
	idinvkind,
	codeinvkind,
	invkind,
	flaginvoiced,
	yinv,
	ninv,
	idaccmotive,
	codemotive,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	idsor1,
	idsor2,
	idsor3,
	idupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	authneeded,
	authdoc,
	authdocdate,
	noauthreason
)
AS SELECT 
	COP.ycon,
	COP.ncon,
	COP.start,
	COP.stop,
	COP.adate,
	COP.idreg,
	registry.title,
	COP.feegross,
	COP.idser,
	service.description,
	service.codeser,
	COP.description,
	COP.idivakind,
	ivakind.description,
	COP.ivarate,
	COP.ndays,
	COP.ivaamount,
	COP.totalcost,
	COP.totalgross,  --lordo al beneficiario
	COP.totalgross - COP.ivaamount,  --totale imponibile
	COP.cu,
	COP.ct,
	COP.lu,
	COP.lt,
	COP.ivafieldnumber,
	COP.pensioncontributionrate,
	COP.socialsecurityrate,
	COP.txt,
	COP.doc,
	COP.docdate,
	COP.idinvkind,
	IK.codeinvkind,
	IK.description,
	COP.flaginvoiced,
	COP.yinv,
	COP.ninv,
	COP.idaccmotive,
	AM.codemotive,
	COP.idaccmotivedebit,
	DB.codemotive,
	COP.idaccmotivedebit_crg,
	CRG.codemotive,
	COP.idaccmotivedebit_datacrg,
	COP.idsor1,
	COP.idsor2,
	COP.idsor3,
	COP.idupb,
	isnull(COP.idsor01,UPB.idsor01),
	isnull(COP.idsor02,UPB.idsor02),
	isnull(COP.idsor03,UPB.idsor03),
	isnull(COP.idsor04,UPB.idsor04),
	isnull(COP.idsor05,UPB.idsor05),
	COP.authneeded,
	COP.authdoc,
	COP.authdocdate,
	COP.noauthreason
FROM profservice COP  with (nolock)
JOIN ivakind with (nolock)
	ON ivakind.idivakind = COP.idivakind
LEFT OUTER JOIN registry with (nolock)
	ON registry.idreg = COP.idreg
LEFT OUTER JOIN service with (nolock)
	ON service.idser = COP.idser
LEFT OUTER JOIN invoice I with (nolock)
	ON COP.idinvkind = I.idinvkind
	AND COP.yinv = I.yinv
	AND COP.ninv = I.ninv
LEFT OUTER JOIN invoicekind IK with (nolock)
	ON I.idinvkind = IK.idinvkind
LEFT OUTER JOIN accmotive AM with (nolock)
	ON AM.idaccmotive = COP.idaccmotive
LEFT OUTER JOIN accmotive DB with (nolock)
	ON DB.idaccmotive =  COP.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG with (nolock)
	ON CRG.idaccmotive = COP.idaccmotivedebit_crg
LEFT OUTER JOIN upb with (nolock)
	ON upb.idupb = COP.idupb



GO

print '[profserviceview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_importriepview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_importriepview
GO


CREATE         VIEW [csa_importriepview]
(
	ayear,
	competency,
	idriep,
	idcsa_import,
	yimport,
	nimport,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	ruolocsa,	
	capitolocsa,
	competenza,
	importo,
	idreg,
	registry,
	matricola,
	idupb,
	codeupb,
	upb,
	idacc,
	codeacc,
	account,
	idfin,
	codefin,
	fin,
	idsor_siope,
	sortcode,
	sorting,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	flagcr,
	lu,
	lt
)
AS SELECT 
	IR.ayear,
	IR.competency,
	IR.idriep,
	IR.idcsa_import,
	I.yimport,
	I.nimport,
	IR.idcsa_contract,
	C.ycontract,
	C.ncontract,
	IR.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	IR.ruolocsa,	
	IR.capitolocsa,
	IR.competenza,
	IR.importo,
	IR.idreg,
	registry.title,
	IR.matricola,
	IR.idupb,
	upb.codeupb,
	upb.title,
	IR.idacc,
	account.codeacc,
	account.title,
	IR.idfin,
	fin.codefin,
	fin.title,
	IR.idsor_siope,
	sorting.sortcode,
	sorting.description,
	IR.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	IR.flagcr,
	IR.lu,
	IR.lt
FROM csa_importriep IR
JOIN csa_import I
	ON I.idcsa_import = IR.idcsa_import
LEFT OUTER JOIN csa_contractkind CK
	ON IR.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN csa_contract C
	ON C.idcsa_contract = IR.idcsa_contract
	AND C.idcsa_contractkind = IR.idcsa_contractkind
	AND C.ayear = IR.ayear
LEFT OUTER JOIN csa_contractkindyear CKY
	ON CKY.idcsa_contractkind =IR.idcsa_contractkind 
	AND CKY.ayear = IR.ayear
LEFT OUTER JOIN upb 
	ON upb.idupb=IR.idupb
LEFT OUTER JOIN fin 
	ON fin.idfin=IR.idfin
LEFT OUTER JOIN sorting	
	ON sorting.idsor = IR.idsor_siope
LEFT OUTER JOIN account 
	ON account.idacc=IR.idacc
LEFT OUTER JOIN registry
	ON IR.idreg = registry.idreg
LEFT OUTER JOIN expense
	ON IR.idexp = expense.idexp
LEFT OUTER JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN expenseyear
	ON expenseyear.idexp = IR.idexp
	AND expenseyear.ayear= IR.ayear
LEFT OUTER JOIN expensetotal
	ON  expensetotal.idexp = IR.idexp
	AND expensetotal.ayear = IR.ayear
	



GO

print '[csa_importriepview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'inventoryview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW inventoryview
GO


CREATE   VIEW inventoryview 
(
	idinventory,
	description,
	idinventoryagency,
	inventoryagency,
	idinventorykind,
	inventorykind,
	startnumber,
	flag,
	flagmixed,
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
	inventory.idinventory,
	inventory.description,
	inventory.idinventoryagency,
	inventoryagency.description,
	inventory.idinventorykind,
	inventorykind.description,
	inventory.startnumber,
	inventory.flag,
	CASE
		WHEN inventory.flag & 1 <> 0 THEN 'S'
		ELSE 'N'
	END,
	inventory.idsor01,
	inventory.idsor02,
	inventory.idsor03,
	inventory.idsor04,
	inventory.idsor05,
	inventory.cu,
	inventory.ct,
	inventory.lu,
	inventory.lt
FROM inventory
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind
	ON inventorykind.idinventorykind = inventory.idinventorykind



GO

print 'inventoryview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'casualcontractavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW casualcontractavailable
GO


CREATE    VIEW [casualcontractavailable]
(
	ycon,
	ncon,
	idreg,
	registry,
	description,
	start,
	stop,
	feegross,
	linkedtotal,
	residual,
	idupb,
	coudeupb,
	upb,
	completed,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	casualcontract.ycon,
	casualcontract.ncon,
	casualcontract.idreg,
	registry.title,
	casualcontract.description,
	casualcontract.start,
	casualcontract.stop,
	casualcontract.feegross,
-- Calcolo TOTALEMOVIMENTI
	CONVERT(decimal(19,2),
		ROUND(
			ISNULL(
				(SELECT SUM(expenseyear_starting.amount)
				FROM expensecasualcontract mov
				JOIN expense s
					ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  					ON expensetotal_firstyear.idexp = s.idexp
  					AND ((expensetotal_firstyear.flag & 2) <> 0 )
				LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
				WHERE mov.ycon = casualcontract.ycon
				AND mov.ncon = casualcontract.ncon
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT SUM(v.amount)
				FROM expensecasualcontract mov
				JOIN expense s
				ON s.idexp = mov.idexp
				JOIN expensevar v
				ON v.idexp = mov.idexp
				WHERE mov.ycon = casualcontract.ycon
				AND mov.ncon = casualcontract.ncon
				AND (ISNULL(v.autokind,0)<> 4)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
			,0) +
			ISNULL(
				(SELECT SUM(p.amount)
				FROM pettycashoperationcasualcontract mov
				JOIN pettycashoperation p
				ON mov.idpettycash = p.idpettycash
				AND mov.yoperation = p.yoperation
				AND mov.noperation = p.noperation
				WHERE mov.ycon = casualcontract.ycon
				AND mov.ncon = casualcontract.ncon)
			,0)
		,2)
	),	
-- RESIDUO = costototale - totalemovimenti
	CONVERT(decimal(19,2),
		ROUND(
			casualcontract.feegross - 
			(
				ISNULL(
					(SELECT SUM(expenseyear_starting.amount)
					FROM expensecasualcontract mov
					JOIN expense s
					ON s.idexp = mov.idexp
					LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  						ON expensetotal_firstyear.idexp = s.idexp
  						AND ((expensetotal_firstyear.flag & 2) <> 0 )
					LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
						ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  						AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
					WHERE mov.ycon = casualcontract.ycon
					AND mov.ncon = casualcontract.ncon
					
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
				,0) +
				ISNULL(
					(SELECT SUM(v.amount)
					FROM expensecasualcontract mov
					JOIN expense s
					ON s.idexp = mov.idexp
					JOIN expensevar v
					ON v.idexp = mov.idexp
					WHERE mov.ycon = casualcontract.ycon
					AND mov.ncon = casualcontract.ncon
					AND (ISNULL(v.autokind,0)<> 4)
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					)
				,0) +
				ISNULL(
					(SELECT SUM(p.amount)
					FROM pettycashoperationcasualcontract mov
					JOIN pettycashoperation p
					ON mov.idpettycash = p.idpettycash
					AND mov.yoperation = p.yoperation
					AND mov.noperation = p.noperation
					WHERE mov.ycon = casualcontract.ycon
					AND mov.ncon = casualcontract.ncon)
				,0)
			)
		,2)
	),
	casualcontract.idupb,
	upb.codeupb,
	upb.title,
	casualcontract.completed,
	casualcontract.idsor01,
	casualcontract.idsor02,
	casualcontract.idsor03,
	casualcontract.idsor04,
	casualcontract.idsor05
	FROM casualcontract (NOLOCK)
	JOIN registry (NOLOCK)
		ON registry.idreg = casualcontract.idreg
	LEFT OUTER JOIN upb 	
		ON upb.idupb=casualcontract.idupb
	WHERE (casualcontract.feegross >
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
				FROM expensecasualcontract mov
				JOIN expense s
				ON s.idexp = mov.idexp
				LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  					ON expensetotal_firstyear.idexp = s.idexp
  					AND ((expensetotal_firstyear.flag & 2) <> 0 )
				LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
				WHERE mov.ycon = casualcontract.ycon
				AND mov.ncon = casualcontract.ncon
				)
				--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
		
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expensecasualcontract mov
			JOIN expense s    ON s.idexp = mov.idexp
			JOIN expensevar v ON v.idexp = mov.idexp
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon
			AND (ISNULL(v.autokind,0)<>4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationcasualcontract mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon)
		,0)
		)
	OR
	 ((casualcontract.feegross = 
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationcasualcontract mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon)
		,0)
	   ) 
	   AND
	   NOT EXISTS (select * from expensecasualcontract E where 
				E.ycon=casualcontract.ycon  and E.ncon=casualcontract.ncon) 
	)




GO

print '[casualcontractavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_incomesetupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_incomesetupview
GO


--clear_table_info'csa_incomesetupview'

CREATE      VIEW [csa_incomesetupview]
(
	ayear,
	idcsa_incomesetup,
	vocecsa,
	idupb,
	codeupb,
	upb,
	idacc_debit,
	codeacc_debit,
	account_debit,
	idacc_ente,
	codeacc_ente,
	account_ente,
	idacc_internalcredit,
	codeacc_internalcredit,
	account_internalcredit,
	idacc_revenue,
	codeacc_revenue,
	account_revenue,
	idacc_agency_credit,
	codeacc_agency_credit,
	account_agency_credit,
	
	idfin_income,
	codefin_income,
	fin_income,
	idsor_siope_income,
	sortcode_income,
	sorting_income,
	
	idfin_expense,
	codefin_expense,
	fin_expense,
	idsor_siope_expense,
	sortcode_expense,
	sorting_expense,
	
	idfin_clawback,
	codefin_clawback,
	fin_clawback,
	idsor_siope_clawback,
	sortcode_clawback,
	sorting_clawback,
	
	flagdirectcsaclawback,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	C.ayear,
	C.idcsa_incomesetup,
	C.vocecsa,
	C.idupb,
	upb.codeupb,
	upb.title,
	C.idacc_debit,
	account_debit.codeacc,
	account_debit.title,
	C.idacc_expense,
	account_ente.codeacc,
	account_ente.title,
	C.idacc_internalcredit,
	account_internalcredit.codeacc,
	account_internalcredit.title,
	C.idacc_revenue,
	account_revenue.codeacc,
	account_revenue.title,
	C.idacc_agency_credit,
	account_agency_credit.codeacc,
	account_agency_credit.title,
	
	C.idfin_income,
	fin_income.codefin,
	fin_income.title,
	C.idsor_siope_income,
	sorting_income.sortcode,
	sorting_income.description,
	
	C.idfin_expense,
	fin_expense.codefin,
	fin_expense.title,
	
	C.idsor_siope_expense,
	sorting_expense.sortcode,
	sorting_expense.description,
	
	C.idfin_incomeclawback,
	fin_clawback.codefin,
	fin_clawback.title,
	
	C.idsor_siope_incomeclawback,
	sorting_clawback.sortcode,
	sorting_clawback.description,
	C.flagdirectcsaclawback,
	C.cu,
	C.ct,
	C.lu,
	C.lt
FROM csa_incomesetup C
LEFT OUTER JOIN upb 
	ON upb.idupb=C.idupb
LEFT OUTER JOIN fin fin_income
	ON fin_income.idfin=C.idfin_income
LEFT OUTER JOIN fin fin_expense
	ON fin_expense.idfin=C.idfin_expense
LEFT OUTER JOIN fin fin_clawback
	ON fin_clawback.idfin=C.idfin_incomeclawback
LEFT OUTER JOIN account account_debit
	ON account_debit.idacc=C.idacc_debit
LEFT OUTER JOIN account account_ente
	ON account_ente.idacc=C.idacc_expense
LEFT OUTER JOIN account account_internalcredit
	ON account_internalcredit.idacc=C.idacc_internalcredit
LEFT OUTER JOIN account account_revenue
	ON account_revenue.idacc=C.idacc_revenue
LEFT OUTER JOIN account account_agency_credit
	ON account_agency_credit.idacc=C.idacc_agency_credit
LEFT OUTER JOIN sorting sorting_income
	ON sorting_income.idsor = C.idsor_siope_income
LEFT OUTER JOIN sorting sorting_expense
	ON sorting_expense.idsor = C.idsor_siope_expense
LEFT OUTER JOIN sorting sorting_clawback
	ON sorting_clawback.idsor = C.idsor_siope_incomeclawback



GO

print '[csa_incomesetupview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'casualcontractlinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW casualcontractlinked
GO

CREATE     VIEW [casualcontractlinked]
(
	ayear,
	ycon,
	ncon,
	idreg,
	registry,
	idser,
	service,
	codeser,
	feegross,
	ct,
	cu,
	adate,
	stop,
	start,
	ndays,
	taxableotheragency,
	lt,
	lu,
	txt,
	rtf,
	description,
	higherrate,
	flaghigherrate,
	idupb,
	idaccmotive,
	idsor1,
	idsor2,
	idsor3,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS
SELECT
	accountingyear.ayear,
	casualcontract.ycon,
	casualcontract.ncon,
	casualcontract.idreg,
	registry.title,
	casualcontract.idser,
	service.description,
	service.codeser, 
	casualcontract.feegross,
	casualcontract.ct,
	casualcontract.cu,
	casualcontract.adate,
	casualcontract.stop,
	casualcontract.start,
	casualcontract.ndays,
	casualcontractyear.taxableotheragency,
	casualcontract.lt,
	casualcontract.lu,
	casualcontract.txt,
	casualcontract.rtf,
	casualcontract.description,
	casualcontractyear.higherrate,
	casualcontractyear.flaghigherrate,
	casualcontract.idupb,
	casualcontract.idaccmotive,
	casualcontract.idsor1,
	casualcontract.idsor2,
	casualcontract.idsor3,
	casualcontract.idsor01,
	casualcontract.idsor02,
	casualcontract.idsor03,
	casualcontract.idsor04,
	casualcontract.idsor05
FROM casualcontract (nolock)
JOIN service (nolock)
	ON casualcontract.idser = service.idser
JOIN casualcontractyear (nolock)
	ON casualcontract.ycon = casualcontractyear.ycon
	AND casualcontract.ncon = casualcontractyear.ncon
	AND casualcontract.ycon = casualcontractyear.ayear
JOIN registry (nolock)
	ON casualcontract.idreg = registry.idreg
JOIN expensecasualcontract (nolock)
	ON expensecasualcontract.ycon = casualcontract.ycon
	AND expensecasualcontract.ncon = casualcontract.ncon
CROSS JOIN accountingyear (nolock)
WHERE EXISTS (SELECT * FROM expensecasualcontract AS MM
		JOIN expenseyear II
		  ON  II.idexp=MM.idexp
		 AND  MM.ycon=casualcontract.ycon
		 AND  MM.ncon=casualcontract.ncon
	       WHERE II.ayear = accountingyear.ayear)

GO

print '[casualcontractlinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxregionsetupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxregionsetupview
GO


CREATE                                                       VIEW [taxregionsetupview]
	(
	taxcode,
	taxref,
	taxkind,
	ayear,
	autoid,
	kind,
	idplace,
	place,
	regionalagency,
	regionalagencytitle,
	cu,
	ct,
	lu,
	lt
  )
  AS SELECT
  taxregionsetup.taxcode,
  tax.taxref,
  tax.description,
  taxregionsetup.ayear,
  taxregionsetup.autoid,
  taxregionsetup.kind,
  taxregionsetup.idplace,
  CASE 
	WHEN (taxregionsetup.kind = 'R') THEN geo_region.title
	WHEN (taxregionsetup.kind = 'P') THEN geo_country.title
	WHEN (taxregionsetup.kind = 'E') THEN geo_nation.title
  END,
  taxregionsetup.regionalagency,
  registry.title,
  taxregionsetup.cu,
  taxregionsetup.ct,
  taxregionsetup.lu,
  taxregionsetup.lt
  FROM taxregionsetup (NOLOCK)
  JOIN tax (NOLOCK)
  ON tax.taxcode = taxregionsetup.taxcode
  LEFT OUTER JOIN registry (NOLOCK)
  ON registry.idreg = taxregionsetup.regionalagency
  LEFT OUTER JOIN geo_region (NOLOCK)
  ON geo_region.idregion = taxregionsetup.idplace
  LEFT OUTER JOIN geo_country (NOLOCK)
  ON geo_country.idcountry = taxregionsetup.idplace
  LEFT OUTER JOIN geo_nation (NOLOCK)
  ON geo_nation.idnation = taxregionsetup.idplace





GO

print '[taxregionsetupview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'revenuearrears') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW revenuearrears
GO


CREATE               VIEW [revenuearrears]
(
	ayear,
	idinc,
	ymov,
	nmov,
	adate,
	residualamount,
	flagarrear
)
AS
SELECT
i1.ayear,
e1.idinc,
e1.ymov,
e1.nmov,
e1.adate,
ISNULL(i2.curramount,0.0) - ISNULL(
	(SELECT SUM(ISNULL(i3.curramount,0.0)) 
	FROM income e3
	 JOIN incometotal i3
		 ON e3.idinc = i3.idinc
	JOIN incomelast ls
		ON e3.idinc = ls.idinc
	 JOIN proceeds d1
		 ON d1.kpro = ls.kpro
	 JOIN proceedstransmission t1
		 ON t1.kproceedstransmission = d1.kproceedstransmission
	JOIN incomelink ilk
		ON ilk.idchild = i3.idinc
	 WHERE  ilk.idparent = e1.idinc
	 AND i3.ayear = i1.ayear),0.0),
   	CASE
		when (( i2.flag & 1)=0) then 'C'
		when (( i2.flag & 1)=1) then 'R'
	End AS flagarrear
FROM income e1
INNER JOIN incomeyear i1 
	ON e1.idinc = i1.idinc 
INNER JOIN incometotal i2
	ON i1.idinc = i2.idinc
	AND i1.ayear = i2.ayear
INNER JOIN config p1			
	ON p1.assessmentphasecode = e1.nphase
	AND p1.ayear = i1.ayear
WHERE 
	 i2.curramount >
	ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) 
		FROM income e3
		 JOIN incometotal i3
			 ON e3.idinc = i3.idinc
		 	AND e3.ymov = i3.ayear
		JOIN incomelast ls
			ON e3.idinc = ls.idinc
		JOIN proceeds d1
		 	ON d1.kpro = ls.kpro
	 	JOIN proceedstransmission t1
	 		ON t1.kproceedstransmission = d1.kproceedstransmission
		JOIN incomelink ilk
			ON ilk.idchild = i3.idinc
	 	WHERE ilk.idparent = e1.idinc 
	 	AND i3.ayear = i1.ayear),0.0)

GO

print '[revenuearrears] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'casualcontractresidual') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW casualcontractresidual
GO


CREATE    VIEW [casualcontractresidual]
(
	ycon,
	ncon,
	description,
	idreg,
	registry,
	start,
	stop,
	feegross,
	residual,
	linkedtotal,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	casualcontract.ycon,
	casualcontract.ncon,
	casualcontract.description,
	casualcontract.idreg,
	registry.title,
	casualcontract.start,
	casualcontract.stop,
	casualcontract.feegross,
	CONVERT(decimal(23,6),
		casualcontract.feegross -
		(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expensecasualcontract mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon
			--AND s.nphase =
			--	(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expensecasualcontract mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON (v.idexp = mov.idexp)
			WHERE mov.ycon = casualcontract.ycon 
			AND mov.ncon = casualcontract.ncon
			AND (ISNULL(v.autokind,0)<> 4)
			--AND s.nphase =
			--	(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationcasualcontract mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon)
		,0)
		)
	),
	CONVERT(decimal(23,6),
		(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expensecasualcontract mov
			JOIN expense s
				ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon
			--AND s.nphase =
				--(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expensecasualcontract mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
			WHERE mov.ycon = casualcontract.ycon 
			AND mov.ncon = casualcontract.ncon
			AND (ISNULL(v.autokind,0)<> 4)
			--AND s.nphase =
				--(SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationcasualcontract mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.ycon = casualcontract.ycon
			AND mov.ncon = casualcontract.ncon)
		,0)
		)
	),
	casualcontract.idsor01,
	casualcontract.idsor02,
	casualcontract.idsor03,
	casualcontract.idsor04,
	casualcontract.idsor05
	FROM casualcontract (NOLOCK)
	JOIN registry (NOLOCK)
	ON registry.idreg = casualcontract.idreg


GO

print '[casualcontractresidual] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finsurplusview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finsurplusview
GO


CREATE            VIEW [finsurplusview]
(
ayear,
creditsurplus,
floatfund
)
AS 
SELECT --DISTINCT
p.ayear,
-- Algoritmo applicato per campo avanzoamministrazione
-- Controllo Previsione Principale:
-- SE 'C' ALLORA Calcola Avanzo di Amministrazione
-- SE 'S' ALLORA Controlla la Previsione Secondaria:
-- SE 'C' ALLORA Calcola Avanzo di Amministrazione
(SELECT 
	CASE  
	WHEN  (p.fin_kind in (1,3)) THEN 
		ISNULL(
			ISNULL(
				(
				SELECT(SUM(upbtotal.currentprev) + SUM(upbtotal.previsionvariation))
		 		FROM fin b 
				JOIN upbtotal ON b.idfin = upbtotal.idfin
				WHERE  b.ayear = p.ayear AND p.idfinincomesurplus = b.idfin
				),
				(SELECT 
				((ISNULL(s.startfloatfund,0.0) +
		  		ISNULL(s.competencyproceeds,0.0) +
				ISNULL(s.residualproceeds,0.0)-
		  		(ISNULL(s.competencypayments,0.0) + ISNULL(s.residualpayments,0.0))) +
		  		(ISNULL(s.previousrevenue,0.0) + ISNULL(s.currentrevenue,0.0)) -
		  		(ISNULL(s.previousexpenditure,0.0) + ISNULL(s.currentexpenditure,0.0)))
		 		FROM surplus s WHERE s.ayear = (p.ayear-1))
			)
		,0.0)
	WHEN  (p.fin_kind = 2) THEN
	(
		
			ISNULL(
				ISNULL(
					(
					SELECT(SUM(upbtotal.currentprev) + SUM(upbtotal.previsionvariation))
			 		FROM fin b 
			 		JOIN upbtotal ON b.idfin = upbtotal.idfin
					WHERE  b.ayear = p.ayear AND p.idfinincomesurplus = b.idfin
					),
					(SELECT 
						(ISNULL(s.startfloatfund,0.0) +
				  		ISNULL(s.competencyproceeds,0.0) +
						ISNULL(s.residualproceeds,0.0)-
				  		(ISNULL(s.competencypayments,0.0) + ISNULL(s.residualpayments,0.0))
						)
			 		FROM surplus s WHERE s.ayear = (p.ayear-1)
					)
				)
			,0.0)
		)
	END
	)
	,
-- Algoritmo applicato per campo fondocassa
-- Controllo Previsione Principale:
-- SE 'S' ALLORA Calcola Fondo di Cassa
-- SE 'C' ALLORA Controlla la Previsione Secondaria:
-- SE 'S' ALLORA Calcola Fondo di Cassa
(SELECT 
	CASE  
	WHEN (p.fin_kind = 2) THEN
		ISNULL( 
			ISNULL(
				(
				 SELECT(SUM(upbtotal.currentprev) + SUM(upbtotal.previsionvariation))
				 FROM fin b 
				 JOIN upbtotal ON b.idfin = upbtotal.idfin
		 		 WHERE  b.ayear = p.ayear AND p.idfinincomesurplus = b.idfin
				),
				(SELECT 
				 (ISNULL(s.startfloatfund,0.0) +
				  ISNULL(s.competencyproceeds,0.0) +
				  ISNULL(s.residualproceeds,0.0) - 
				  (ISNULL(s.competencypayments,0) + ISNULL(s.residualpayments,0.0)))
				 FROM surplus s WHERE s.ayear = (p.ayear-1))
			)
		,0.0)
	WHEN p.fin_kind IN (1,3) THEN
		(
		CASE p.fin_kind
			WHEN 3 THEN
				ISNULL(
					ISNULL(
						(
						 SELECT(SUM(upbtotal.currentsecondaryprev) + SUM(upbtotal.secondaryvariation))
						 FROM fin b
						 JOIN upbtotal ON b.idfin = upbtotal.idfin
						 WHERE  b.ayear = p.ayear AND p.idfinincomesurplus = b.idfin
						),
						(SELECT 
							(ISNULL(s.startfloatfund,0.0) +
							  ISNULL(s.competencyproceeds,0.0) +
							  ISNULL(s.residualproceeds,0.0) - 
							  (ISNULL(s.competencypayments,0) + ISNULL(s.residualpayments,0.0))
							)
							FROM surplus s WHERE s.ayear = (p.ayear-1)
						)
					)
				,0.0)
			ELSE
				ISNULL(
					ISNULL(
						(SELECT 
				 			(ISNULL(s.startfloatfund,0.0) +
							  ISNULL(s.competencyproceeds,0.0) +
				  			  ISNULL(s.residualproceeds,0.0) - 
				  			  (ISNULL(s.competencypayments,0) + ISNULL(s.residualpayments,0.0))
							)
						 	FROM surplus s WHERE s.ayear = (p.ayear-1)
						)
					,0.0)
				,0.0)
			END
		)
		END 
)
FROM config p


GO

print '[finsurplusview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'admpay_expenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW admpay_expenseview
GO



CREATE                VIEW admpay_expenseview
(
	yadmpay,
	nadmpay,
	nexpense,
	nappropriation,
	idreg,
	registry,
	idser,
	service,
	codeser, 
	start,
	stop,
	description,
	amount,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
admpay_expense.yadmpay,
admpay_expense.nadmpay,
admpay_expense.nexpense,
admpay_expense.nappropriation,
admpay_expense.idreg,
registry.title,
admpay_expense.idser,
service.description,
service.codeser,
admpay_expense.start,
admpay_expense.stop,
admpay_expense.description,
admpay_expense.amount,
admpay_expense.cu,
admpay_expense.ct,
admpay_expense.lu,
admpay_expense.lt
FROM admpay_expense
LEFT OUTER JOIN registry
	ON registry.idreg = admpay_expense.idreg
LEFT OUTER JOIN service
	ON service.idser = admpay_expense.idser




GO

print 'admpay_expenseview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_contractview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_contractview
GO



CREATE        VIEW [csa_contractview]
(
	ayear,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	title,	
	description,
	idupb,
	codeupb,
	upb,
	idupb_contractkind,
	codeupb_contractkind,
	upb_contractkind,
	idacc_main,
	codeacc_main,
	account_main,
	idfin_main,
	codefin_main,
	fin_main,
	idexp_main,
	nphase_main,
	phase_main,
	ymov_main,
	nmov_main,
	flagkeepalive,
	flagrecreate,
	active,
	idsor_siope_main,
	sortcode_main,
	sorting_main,
	idunderwriting,
	underwriting,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	C.ayear,
	C.idcsa_contract,
	C.ycontract,
	C.ncontract,
	CK.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	C.title,	
	C.description,
	C.idupb,
	upb.codeupb,
	upb.title,
	CKY.idupb,
	upbck.codeupb,
	upbck.title,
	C.idacc_main,
	account.codeacc,
	account.title,
	C.idfin_main,
	fin.codefin,
	fin.title,
	C.idexp_main,
	expensephase.nphase,
	expensephase.description, 
	expense.ymov,
	expense.nmov,
	C.flagkeepalive,
	C.flagrecreate,
	C.active,
	C.idsor_siope_main,
	sorting.sortcode,
	sorting.description, 
	C.idunderwriting,
	underwriting.title,
	C.cu,
	C.ct,
	C.lu,
	C.lt
FROM csa_contract C
JOIN csa_contractkind CK
	ON C.idcsa_contractkind = CK.idcsa_contractkind
JOIN csa_contractkindyear CKY
	ON C.idcsa_contractkind = CKY.idcsa_contractkind
	AND CKY.ayear = C.ayear
LEFT OUTER JOIN upb 
	ON upb.idupb=C.idupb
LEFT OUTER JOIN upb upbck 
	ON upbck.idupb=CKY.idupb
LEFT OUTER JOIN fin fin
	ON fin.idfin=C.idfin_main
LEFT OUTER JOIN account account
	ON account.idacc=C.idacc_main
LEFT OUTER JOIN expense
	ON C.idexp_main = expense.idexp
LEFT OUTER JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
	AND expenseyear.ayear = C.ayear
LEFT OUTER JOIN expensetotal
	ON  expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN sorting
	ON sorting.idsor = C.idsor_siope_main
LEFT OUTER JOIN underwriting
	ON C.idunderwriting = underwriting.idunderwriting



GO

print '[csa_contractview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_contractkindview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_contractkindview
GO


--clear_table_info'csa_contractkindview'

CREATE      VIEW [csa_contractkindview]
(
	ayear,
	idcsa_contractkind,
	idupb,
	codeupb,
	upb,
	description,
	idacc_main,
	codeacc_main,
	account_main,
	idfin_main,
	codefin_main,
	fin_main,
	contractkindcode,
	flagcr,
	flagkeepalive,
	active,
	idsor_siope_main,
	sortcode_main,
	sorting_main,
	idunderwriting,
	underwriting,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	CY.ayear,
	C.idcsa_contractkind,
	CY.idupb,
	upb.codeupb,
	upb.title,
	C.description,
	CY.idacc_main,
	account.codeacc,
	account.title,
	CY.idfin_main,
	fin.codefin, 
	fin.title, 
	C.contractkindcode,
	C.flagcr,
	C.flagkeepalive,
	C.active,
	CY.idsor_siope_main,
	sorting.sortcode,
	sorting.description, 
	C.idunderwriting,
	underwriting.title,
	C.cu,
	C.ct,
	C.lu,
	C.lt
FROM csa_contractkind C
JOIN csa_contractkindyear CY
	ON C.idcsa_contractkind = CY.idcsa_contractkind
LEFT OUTER JOIN upb 
	ON upb.idupb=CY.idupb
LEFT OUTER JOIN fin 
	ON fin.idfin=CY.idfin_main
LEFT OUTER JOIN account 
	ON account.idacc=CY.idacc_main
LEFT OUTER JOIN sorting
	ON sorting.idsor = CY.idsor_siope_main
LEFT OUTER JOIN underwriting
	ON C.idunderwriting = underwriting.idunderwriting


GO

print '[csa_contractkindview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimateavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimateavailable
GO


CREATE      VIEW [estimateavailable]
(
	idestimkind,
	yestim,
	nestim,
	estimkind,
	registry,
	idupb,
	description,
	doc,
	docdate,
	adate,
	idman,
	manager,
	taxabletotal,
	ivatotal,
	linkedtotal,
	residual,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatekind.description,
	CASE
	WHEN estimate.idreg is not null THEN (select title from
					registry 
					where idreg= estimate.idreg)
	WHEN estimatedetail.idreg is not null THEN (select title from
					registry 
					where idreg= estimatedetail.idreg)
	ELSE null
	END,
	estimatedetail.idupb,
	estimate.description,
	estimate.doc,
	estimate.docdate,
	estimate.adate,
	estimate.idman,
	manager.title,
	isnull(totestimateview.taxabletotal,0),
	isnull(totestimateview.ivatotal,0),
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(incomeyear_starting.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
	JOIN income e (NOLOCK)
		ON e.idinc = mov.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  		ON incometotal_firstyear.idinc = e.idinc
  		AND ((incometotal_firstyear.flag & 2) <> 0 )
 	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE mov.idestimkind = estimate.idestimkind
	AND mov.yestim = estimate.yestim
	AND mov.nestim = estimate.nestim) +
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
	JOIN income e (NOLOCK)
	ON e.idinc = mov.idinc
	JOIN incomevar v (NOLOCK)
	ON v.idinc = mov.idinc
	WHERE mov.idestimkind = estimate.idestimkind
	AND mov.yestim = estimate.yestim
	AND mov.nestim = estimate.nestim)
	,2)),
	--residuo = totaleimponibile + totaleiva - totale movimenti
	CONVERT(decimal(19,2),ROUND(
	ISNULL(totestimateview.taxabletotal, 0.0) +
	ISNULL(totestimateview.ivatotal, 0.0) -
	(SELECT ISNULL(SUM(incomeyear_starting.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
	JOIN income e (NOLOCK)
		ON e.idinc = mov.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  		ON incometotal_firstyear.idinc = e.idinc
  		AND ((incometotal_firstyear.flag & 2) <> 0 )
 	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE mov.idestimkind = estimate.idestimkind
	AND mov.yestim = estimate.yestim
	AND mov.nestim = estimate.nestim) -
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
	JOIN income e (NOLOCK)
	ON e.idinc = mov.idinc
	JOIN incomevar v (NOLOCK)
	ON v.idinc = mov.idinc
	WHERE mov.idestimkind = estimate.idestimkind
	AND mov.yestim = estimate.yestim
	AND mov.nestim = estimate.nestim)
	,2)),
	estimate.active,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05
FROM estimatedetail (NOLOCK)
JOIN estimate (NOLOCK)
  	ON estimatedetail.idestimkind = estimate.idestimkind
	AND estimatedetail.yestim = estimate.yestim
  	AND estimatedetail.nestim = estimate.nestim
JOIN estimatekind (nolock)
	ON estimate.idestimkind = estimatekind.idestimkind
LEFT OUTER JOIN totestimateview (NOLOCK)
	ON totestimateview.idestimkind = estimate.idestimkind
	AND totestimateview.yestim = estimate.yestim
	AND totestimateview.nestim = estimate.nestim
--JOIN registry (NOLOCK) 	ON registry.idreg = estimate.idreg
LEFT OUTER JOIN manager  (nolock)
	ON manager.idman = estimate.idman
GROUP BY estimatedetail.idestimkind,estimate.idestimkind, 
	estimatedetail.yestim,estimate.yestim,
	estimate.nestim,estimatedetail.nestim,
	estimate.idreg,estimatedetail.idreg,
	estimatedetail.idupb,
	estimatekind.description,estimate.description,
	estimate.doc,estimate.docdate,estimate.adate,estimate.active, 
	estimate.idman,manager.title,
	taxabletotal,ivatotal,estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05




GO

print '[estimateavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'payedtaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW payedtaxview
GO



CREATE     VIEW [payedtaxview]
(
	cf,
	address,
	cap,
	city,
	country,
	nation,
	location,
	payed_city,
	payed_fiscaltaxregion,
	idexp,
	nbracket,
	abatements,
	nphase,
	phase,
	ymov,
	nmov,
	idreg,
	registry,
	expensedescription,
	adate,
	idser,
	codeser,
	service,
	certificatekind,
	servicestart,
	servicestop,
	taxcode,
	taxref,
	description,
	taxkind,
        taxcategory,
	taxablegross,
	taxablenet,
	employrate,
	employnumerator,
	employdenominator,
	employtax,
	adminrate,
	adminnumerator,
	admindenominator,
	admintax,
	competencydate,
	datetaxpay,
	ytaxpay,
	ntaxpay,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT     
	registry.cf, 
	registryaddress.address, 
	registryaddress.cap, 
	geo_city.title, 
	geo_country.province, 
	geo_nation.title, 
	registryaddress.location,
	pgc.title,
	pftr.title,
	expensetax.idexp, 
	expensetax.nbracket, 
	expensetax.abatements,
	expense.nphase, 
	expensephase.description, 
	expense.ymov, 
	expense.nmov, 
	expense.idreg, 
	registry.title, 
	expense.description, 
	expense.adate, 
	expenselast.idser, 
	service.codeser,
	service.description, 
	certificationmodel.description,
	expenselast.servicestart, 
	expenselast.servicestop, 
	expensetax.taxcode, 
	tax.taxref,
	tax.description, 
	tax.taxkind, 
        CASE tax.taxkind
                WHEN 1 THEN 'Fiscale'
                WHEN 2 THEN 'Assistenziale'
                WHEN 3 THEN 'Previdenziale'
                WHEN 4 THEN 'Assicurativa'
                WHEN 5 THEN 'Arretrati'
                WHEN 6 THEN 'Altro'
        END,
	expensetax.taxablegross, 
	expensetax.taxablenet, 
	expensetax.employrate, 
	expensetax.employnumerator, 
	expensetax.employdenominator, 
	expensetax.employtax, 
	expensetax.adminrate, 
	expensetax.adminnumerator, 
	expensetax.admindenominator, 
	expensetax.admintax, 
	expensetax.competencydate, 
	CASE config.taxvaliditykind 
		WHEN 3 THEN payment.adate 
		WHEN 4 THEN payment.printdate
		WHEN 5 THEN  paymenttransmission.transmissiondate
		WHEN 6 THEN (SELECT MIN(banktransaction.transactiondate)
			FROM banktransaction 
			WHERE banktransaction.kpay=expenselast.kpay)
		-- data ultima fase di spesa
		WHEN 2 THEN expense.adate 
		ELSE expensetax.competencydate
	END,
	expensetax.ytaxpay, 
	expensetax.ntaxpay,
	expensetax.cu, expensetax.ct, expensetax.lu, expensetax.lt
FROM expensetax
JOIN tax
	ON tax.taxcode = expensetax.taxcode
JOIN expense
	ON expense.idexp = expensetax.idexp
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN config
	ON expense.ymov = config.ayear
JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN registryaddress
	ON registryaddress.idreg = expense.idreg
LEFT OUTER JOIN geo_city
	ON registryaddress.idcity = geo_city.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON registryaddress.idnation = geo_nation.idnation
LEFT OUTER JOIN geo_city pgc
	ON pgc.idcity = expensetax.idcity
LEFT OUTER JOIN fiscaltaxregion pftr
	ON pftr.idfiscaltaxregion = expensetax.idfiscaltaxregion
LEFT OUTER JOIN certificationmodel
	ON service.certificatekind = certificationmodel.idcertificationmodel
WHERE (registryaddress.idaddresskind IS NULL OR registryaddress.idaddresskind = 
		(select top 1 idaddresskind 
		   from registryaddress ci
		   join address ON registryaddress.idaddresskind = address.idaddress
		  where ci.idreg = registry.idreg
	       order by case codeaddress
				when '07_SW_DOM' then 1
				when '07_SW_DEF' then 2
				else 3
			end
		) and registryaddress.start = 
		(	select max(start)
			from registryaddress ci2
			where ci2.idreg = registry.idreg
			and ci2.idaddresskind = registryaddress.idaddresskind
		))



GO

print '[payedtaxview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'managersortingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW managersortingview
GO


CREATE       VIEW [managersortingview]
	(
	idsorkind,
	sortingkind,
	idsor,
	sortcode,
	sorting,
	idman,
	cu,
	ct,
	lu,
	lt
 	)
  AS SELECT
	sortingkind.idsorkind,
	sortingkind.description,
	managersorting.idsor,
	sorting.sortcode,
	sorting.description,
	managersorting.idman,
	managersorting.cu,
	managersorting.ct,
	managersorting.lu,
	managersorting.lt
FROM managersorting (NOLOCK)
JOIN sorting (NOLOCK)
ON sorting.idsor = managersorting.idsor
JOIN sortingkind (NOLOCK)
ON sortingkind.idsorkind = sorting.idsorkind




GO

print '[managersortingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expenselastview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expenselastview
GO


CREATE     VIEW expenselastview
(
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idformerexpense,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	paymentadate,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idregistrypaymethod,
	idpaymethod,
	iban,
	biccode,
	cin,
	idbank,
	idcab,
	cc,
	paymethod_allowdeputy,
	paymethod_flag,
	extracode,
	iddeputy,
	deputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	autocode,
	idclawback,
	clawback,
	clawbackref,
	nbill,
	idpay,
	txt,
	cu,
	ct,
	lu,
	lt,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idformerexpense,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expenselast.kpay,
	payment.ypay,
	payment.npay,
	payment.adate,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idregistrypaymethod,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.biccode,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymethod_allowdeputy,
	expenselast.paymethod_flag,
	expenselast.extracode,
	expenselast.iddeputy,  
	deputy.title,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expense.autocode,
	expense.idclawback,
	clawback.description,
	clawback.clawbackref,
	expenselast.nbill,
	expenselast.idpay,
	expense.txt,
	expenselast.cu,
	expenselast.ct,
	expenselast.lu,
	expenselast.lt,
	upb.idsor01,upb.idsor02,upb.idsor03,upb.idsor04,upb.idsor05
FROM expense
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON parentexpense.idexp = expense.parentidexp
JOIN expenselast 
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN registry deputy
	ON deputy.idreg = expenselast.iddeputy
LEFT OUTER JOIN clawback
	ON clawback.idclawback = expense.idclawback
LEFT OUTER JOIN expensetotal expensetotal_firstyear
  	ON expensetotal_firstyear.idexp = expense.idexp
  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear


GO

print 'expenselastview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expenseview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expenseview
GO



CREATE      VIEW expenseview
(
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idformerexpense,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idreg,
	registry,
	cf,
	p_iva,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	paymentadate,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idregistrypaymethod,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	biccode,
	paymethod_allowdeputy,
	paymethod_flag,
	extracode,
	iddeputy,
	deputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	autocode,
	idclawback,
	clawback,
	clawbackref,
	nbill,
	idpay,
	npaymenttransmission,
	transmissiondate,
	idaccdebit, 
	codeaccdebit,
	cigcode,	
	cupcode,
	txt,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idformerexpense,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expense.idreg,
	registry.title,
	registry.cf,
	registry.p_iva,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.adate,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idregistrypaymethod,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.biccode,
	expenselast.paymethod_allowdeputy,
	expenselast.paymethod_flag,
	extracode,
	expenselast.iddeputy,  
	deputy.title,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expense.autocode,
	expense.idclawback,
	clawback.description,
	clawback.clawbackref,
	expenselast.nbill,
	expenselast.idpay,
	paymenttransmission.npaymenttransmission,
	paymenttransmission.transmissiondate,
	expenselast.idaccdebit,
	account.codeacc,
	expense.cigcode,	
	expense.cupcode,
	expense.txt,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt
FROM expense
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN expense former
	ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expenselast 
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN registry deputy
	ON deputy.idreg = expenselast.iddeputy
LEFT OUTER JOIN clawback
	ON clawback.idclawback = expense.idclawback
LEFT OUTER JOIN expensetotal expensetotal_firstyear
  	ON expensetotal_firstyear.idexp = expense.idexp
  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
LEFT OUTER JOIN account 
	ON account.idacc =  expenselast.idaccdebit



GO

print 'expenseview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finunusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finunusable
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:00
CREATE                                                   VIEW finunusable
(
	idfin,
	ayear,
	finpart,
	codefin,
	nlevel,
	leveldescr,
	paridfin,
	printingorder,
	title,
	expiration,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	fin.idfin,
	fin.ayear,
	CASE
		WHEN ((fin.flag&1)=0) THEN 'E'
		WHEN ((fin.flag&1)=1) THEN 'S'
	END,
	fin.codefin,
	fin.nlevel,
	finlevel.description,
	fin.paridfin,
	fin.printingorder,
	fin.title,
	finlast.expiration,
	fin.cu, 
	fin.ct, 
	fin.lu,
	fin.lt 
	FROM fin (NOLOCK)
	JOIN finlevel (NOLOCK) 
	ON finlevel.ayear = fin.ayear
	AND finlevel.nlevel = fin.nlevel
	LEFT OUTER JOIN finlast (NOLOCK) 
	ON finlast.idfin = fin.idfin
	WHERE finlevel.flag&2 = 0
	OR finlast.idfin is null

GO

print 'finunusable OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'apfinancialactivityview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW apfinancialactivityview
GO



CREATE       VIEW [apfinancialactivityview] 
(
	idapfinancialactivity,
	apfinancialactivitycode,
	nlevel,
	leveldescr,
	paridapfinancialactivity,
	description,
	active,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	apfinancialactivity.idapfinancialactivity,
	apfinancialactivity.apfinancialactivitycode,
	apfinancialactivity.nlevel,
	apfinancialactivitylevel.description,
	apfinancialactivity.paridapfinancialactivity,
	apfinancialactivity.description,
	apfinancialactivity.active,
	apfinancialactivity.cu, 
	apfinancialactivity.ct, 
	apfinancialactivity.lu,
	apfinancialactivity.lt 
FROM apfinancialactivity
JOIN apfinancialactivitylevel
	ON apfinancialactivitylevel.nlevel = apfinancialactivity.nlevel





GO

print '[apfinancialactivityview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimateincavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimateincavailable
GO



CREATE     VIEW [estimateincavailable]
(
	idestimkind,
	yestim,
	nestim,
	estimkind,
	registry,
	description,
	doc,
	docdate,
	adate,
	taxabletotal,
	ivatotal,
	detailtaxabletotal,
	detailivatotal,
	linkedtotal,
	residual,
	active,
	flagintracom,
	idman,
	manager,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	estimate.idestimkind,
	estimate.yestim,
	estimate.nestim,
	estimatekind.description,
	registry.title,
	estimate.description,
	estimate.doc,
	estimate.docdate,
	estimate.adate,
	totestimateview.taxabletotal,       --totale imponibile su tutto l'ordine
	totestimateview.ivatotal,	    --totale iva su tutto l'ordine
	totestimatedetailview.taxabletotal, --totale imponibile dei dettagli associati a movimenti di entrata
	totestimatedetailview.ivatotal,     --totale iva dei dettagli associati a movimenti di entrata
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(incomeyear_starting.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
	JOIN income e (NOLOCK)
	ON e.idinc = mov.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  		ON incometotal_firstyear.idinc = e.idinc
  		AND ((incometotal_firstyear.flag & 2) <> 0 )
 	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE mov.idestimkind = estimate.idestimkind
	AND mov.yestim = estimate.yestim
	AND mov.nestim = estimate.nestim) +
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM incomeestimate mov (NOLOCK)
	JOIN income e (NOLOCK)
	ON e.idinc = mov.idinc
	JOIN incomevar v (NOLOCK)
	ON v.idinc = mov.idinc
	WHERE mov.idestimkind = estimate.idestimkind
	AND mov.yestim = estimate.yestim
	AND mov.nestim = estimate.nestim)
	,2)),
	--residuo :somma dei dett. ordine non contabilizzati o annullati
	(SELECT CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (estimatedetail.idinc_taxable IS  NULL) AND ( estimatedetail.idinc_iva IS  NOT NULL)
			THEN
			     ROUND((ISNULL(estimatedetail.taxable,0)* estimatedetail.number )  ,2)
			WHEN (estimatedetail.idinc_iva IS NULL) AND (estimatedetail.idinc_taxable IS  NOT NULL)
			THEN
			     ROUND( ISNULL(estimatedetail.tax,0)  ,2)
			WHEN (estimatedetail.idinc_iva IS  NULL) AND (estimatedetail.idinc_taxable IS  NULL)
			THEN
			     ROUND((ISNULL(estimatedetail.taxable,0)* estimatedetail.number + ISNULL(estimatedetail.tax,0))  ,2)
			ELSE   0
		    END
		   ),0)
		) 
	FROM estimatedetail 
	WHERE estimatedetail.idestimkind = estimate.idestimkind
	AND  estimatedetail.yestim = estimate.yestim
	AND  estimatedetail.nestim = estimate.nestim
	AND  estimatedetail.stop is null),
	estimate.active,
	estimate.flagintracom,
	estimate.idman,
	manager.title,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05
	FROM estimate (NOLOCK)
	JOIN estimatekind
	ON estimatekind.idestimkind = estimate.idestimkind
	JOIN totestimateview (NOLOCK)
	ON totestimateview.idestimkind = estimate.idestimkind
	AND totestimateview.yestim = estimate.yestim
	AND totestimateview.nestim = estimate.nestim
	LEFT OUTER JOIN totestimatedetailview (NOLOCK)
	ON totestimatedetailview.idestimkind = estimate.idestimkind
	AND totestimatedetailview.yestim = estimate.yestim
	AND totestimatedetailview.nestim = estimate.nestim
	LEFT OUTER JOIN registry (NOLOCK)
	ON registry.idreg = estimate.idreg
	LEFT OUTER JOIN manager (NOLOCK)
	ON manager.idman = estimate.idman






GO

print '[estimateincavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finusable
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:00
CREATE                                                   VIEW finusable
(
	idfin,
	ayear,
	flag,
	finpart,
	codefin,
	paridfin,
	nlevel,
	idman,
	manager,
	printingorder,
	title,
	expiration,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	fin.idfin,
	fin.ayear,
	fin.flag,
	CASE
		WHEN ((fin.flag&1)=0) THEN 'E'
		WHEN ((fin.flag&1)=1) THEN 'S'
	END,
	fin.codefin,
	fin.paridfin,
	fin.nlevel,
	finlast.idman,
	manager.title,
	fin.printingorder,
	fin.title,
	finlast.expiration,
	fin.cu, 
	fin.ct, 
	fin.lu,
	fin.lt 
	FROM fin (NOLOCK)
	JOIN finlevel (NOLOCK) 
	ON finlevel.ayear = fin.ayear
	AND finlevel.nlevel = fin.nlevel
	JOIN finlast (NOLOCK) 
	ON fin.idfin = finlast.idfin
	LEFT OUTER JOIN manager (NOLOCK) 
	ON manager.idman = finlast.idman
	WHERE finlevel.flag&2 <> 0





GO

print 'finusable OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'bookingview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW bookingview
GO



CREATE    VIEW [bookingview] as
(
	select booking.idbooking as idbooking,
		   booking.ybooking as ybooking,
		   booking.nbooking as nbooking,
		   booking.forename as forename,
		   booking.surname  as surname,
		   booking.cf as cf,
		   booking.idcustomuser as idcustomuser,
		   manager.title as managertitle,
		   manager.idman as idman,
		   booking.idlcard
	from booking join manager on (booking.idman = manager.idman)
)


GO

print '[bookingview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimatelinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimatelinked
GO



CREATE           VIEW [estimatelinked]
(
	ayear,
	idestimkind, yestim, nestim, estimkind,
	idreg, registry, registryreference, idman, 
	manager,	
	description, deliveryexpiration, deliveryaddress, paymentexpiring, 
	idexpirationkind, idcurrency, 	codecurrency, currency,
	exchangerate, doc, docdate, adate, officiallyprinted,
	txt, rtf,
	cu, ct, lu, lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS
SELECT
	accountingyear.ayear,
	estimate.idestimkind, estimate.yestim, estimate.nestim, estimatekind.description,
	estimate.idreg, registry.title, estimate.registryreference, estimate.idman, 
	manager.title,
	estimate.description, deliveryexpiration,
	deliveryaddress, paymentexpiring, 
	idexpirationkind, estimate.idcurrency, currency.codecurrency,
	currency.description,
	estimate.exchangerate, estimate.doc, 
	estimate.docdate, adate, officiallyprinted,
	estimate.txt, estimate.rtf, 
	estimate.cu, estimate.ct, estimate.lu, estimate.lt,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05
FROM estimate (NOLOCK)
JOIN estimatekind (NOLOCK)
	ON estimatekind.idestimkind = estimate.idestimkind
LEFT OUTER JOIN registry (NOLOCK)
	ON registry.idreg = estimate.idreg
LEFT OUTER JOIN currency (NOLOCK)
	ON currency.idcurrency = estimate.idcurrency
LEFT OUTER JOIN manager (NOLOCK)
	ON manager.idman = estimate.idman
CROSS JOIN accountingyear (NOLOCK)
	WHERE EXISTS (SELECT * FROM incomeestimate AS MM 
			JOIN incomeyear II
			  ON II.idinc=MM.idinc
			 AND MM.idestimkind = estimate.idestimkind
			 AND MM.yestim=estimate.yestim
			 AND MM.nestim=estimate.nestim
		      WHERE  II.ayear = accountingyear.ayear) 
			

GO

print '[estimatelinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'bookingdetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW bookingdetailview
GO



CREATE     VIEW [bookingdetailview]
(
	idstore,
	store,
	idbooking,
	ybooking,
	nbooking,
	idlist,
	idstock,
	list,
	intcode,
	idlistclass,
	codelistclass,
	listclass,
	number,
	price,
	authorizedimg,
	authorized,
	idman,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	fulfilled,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	bookingdetail.idstore,
	store.description,
	booking.idbooking,
	booking.ybooking,
	booking.nbooking,
	bookingdetail.idlist,
	bookingdetail.idstock,
	list.description,
	list.intcode,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	bookingdetail.number,
	bookingdetail.price,
	(
	case when bookingdetail.authorized='S' then '<center><img src="Immagini\tl_green.png"></center>'
		  when bookingdetail.authorized='N' then '<center><img src="Immagini\tl_red.png"></center>'
		  when bookingdetail.authorized is null then '<center><img src="Immagini\tl_yellow.png"></center>'
	end
	),
	bookingdetail.authorized,
	booking.idman,
	bookingdetail.idsor1,
	bookingdetail.idsor2,
	bookingdetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	CASE ISNULL(authorized,'N')
		 WHEN 'S' THEN bookingdetail.number - ISNULL((SELECT booktotal.number FROM booktotal 
													   WHERE booktotal.idstore = bookingdetail.idstore AND
															 booktotal.idlist = bookingdetail.idlist AND
															 booktotal.idbooking = bookingdetail.idbooking),0) 
		 ELSE 0
	END,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05,
	bookingdetail.cu,
	bookingdetail.ct,
	bookingdetail.lu,
	bookingdetail.lt
FROM bookingdetail
JOIN booking 
	ON booking.idbooking = bookingdetail.idbooking
JOIN store
	ON store.idstore = bookingdetail.idstore
JOIN list 
	ON bookingdetail.idlist = list.idlist
LEFT OUTER JOIN stock  -- togliere il left outer join tra un po'
	ON bookingdetail.idstock = stock.idstock
LEFT OUTER JOIN listclass 
	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN sorting sorting1
	ON sorting1.idsor = bookingdetail.idsor1
LEFT OUTER JOIN sorting sorting2
	ON sorting2.idsor = bookingdetail.idsor2
LEFT OUTER JOIN sorting sorting3
	ON sorting3.idsor = bookingdetail.idsor3

GO

print '[bookingdetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paydispositionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paydispositionview
GO


CREATE   VIEW paydispositionview
(
	idpaydisposition,
	ayear,
	description,
	motive,
	kpay,
	ypay,
	npay,
	kpaymenttransmission,
	ypaymenttransmission,
	npaymenttransmission,
	total,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	paydisposition.idpaydisposition,
	paydisposition.ayear,
	paydisposition.description,
	paydisposition.motive,
	paydisposition.kpay,
	payment.ypay,
	payment.npay,
	paymenttransmission.kpaymenttransmission,
	paymenttransmission.ypaymenttransmission,
	paymenttransmission.npaymenttransmission,
	ISNULL(
		(SELECT SUM(amount) FROM paydispositiondetail
		WHERE paydispositiondetail.idpaydisposition = paydisposition.idpaydisposition)
	,0),
	paydisposition.ct,
	paydisposition.cu,
	paydisposition.lt,
	paydisposition.lu
FROM paydisposition
LEFT OUTER JOIN payment
	ON payment.kpay = paydisposition.kpay
LEFT OUTER JOIN paymenttransmission
	ON payment.kpaymenttransmission= paymenttransmission.kpaymenttransmission


GO

print 'paydispositionview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'flowchartuserview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW flowchartuserview
GO


--	clear_table_info'flowchartuserview'
CREATE VIEW [flowchartuserview]
as 
SELECT 
	flowchart.ayear,
	flowchart.title as flowchart,
	flowchart.nlevel,
	flowchartuser.idflowchart,
	flowchartuser.ndetail,
	flowchartuser.idcustomuser,
	customuser.username,
	flowchartuser.start,
	flowchartuser.stop,
	flowchartuser.flagdefault,
	flowchartuser.idsor01,
	flowchartuser.idsor02,
	flowchartuser.idsor03,
	flowchartuser.idsor04,
	flowchartuser.idsor05,
	flowchartuser.title,
	flowchartuser.all_sorkind01,
	flowchartuser.all_sorkind02,
	flowchartuser.all_sorkind03,
	flowchartuser.all_sorkind04,
	flowchartuser.all_sorkind05,
	flowchartuser.sorkind01_withchilds,
	flowchartuser.sorkind02_withchilds,
	flowchartuser.sorkind03_withchilds,
	flowchartuser.sorkind04_withchilds,
	flowchartuser.sorkind05_withchilds
from flowchartuser 
join flowchart 
	on flowchartuser.idflowchart = flowchart.idflowchart
join customuser
	on customuser.idcustomuser = flowchartuser.idcustomuser	


GO

print '[flowchartuserview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'booktotalview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW booktotalview
GO


CREATE      VIEW [booktotalview]
(
	idstore,
	store,
	deliveryaddress,
	idlist,
	list,
	intcode,
	idlistclass,
	codelistclass,
	listclass,
	idbooking,
	ybooking,
	nbooking,
	number,
	allocated,
	price,
	idman,
	manager,
	booked,
	idstock,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	store.idstore,
	store.description,
	store.deliveryaddress,
	list.idlist,
	list.description,
	list.intcode,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	booking.idbooking,
	booking.ybooking,
	booking.nbooking,
	ISNULL(booktotal.number,0),
	ISNULL(booktotal.allocated,0),
	bookingdetail.price,
	booking.idman,
	manager.title,
	bookingdetail.number,
	bookingdetail.idstock,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05
	--- aggiungere il number del bookingdetail oltre a queello 
	--- (quantità originariamente prenotata) --booked
FROM bookingdetail  
JOIN list
	ON bookingdetail.idlist = list.idlist
JOIN store
	ON bookingdetail.idstore = store.idstore
JOIN  booking
	ON booking.idbooking = bookingdetail.idbooking
LEFT OUTER JOIN  booktotal
	ON bookingdetail.idbooking = booktotal.idbooking
	AND bookingdetail.idlist = booktotal.idlist
LEFT OUTER JOIN listclass 
	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN manager 
	ON manager.idman = booking.idman

GO

print '[booktotalview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'lcardview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW lcardview
GO


--clear_table_info'lcard'
CREATE    VIEW [lcardview](
	idlcard,
	title,
	description,
	ystart,
	ystop,
	active,
	idman,
	manager,
	idstore,
	store,
	extcode,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	lt,
	lu
)
AS
SELECT
	lcard.idlcard,
	lcard.title,
	lcard.description,
	lcard.ystart,
	lcard.ystop,
	lcard.active,
	lcard.idman,
	manager.title,
	lcard.idstore,
	store.description,
	lcard.extcode,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05,
	lcard.lt,
	lcard.lu
FROM lcard
JOIN store
	ON lcard.idstore = store.idstore
JOIN manager
	ON lcard.idman = manager.idman


GO

print '[lcardview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_roleview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_roleview
GO

CREATE      VIEW [csa_roleview]
(
	ruoloCSA,
	idreg,
	registry,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivecredit,
	codemotivecredit,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	C.ruoloCSA,
	C.idreg,
	R.title,
	C.idaccmotivedebit,
	accmotivedebit.codemotive,
	C.idaccmotivecredit,
	accmotivecredit.codemotive,
	C.cu,
	C.ct,
	C.lu,
	C.lt
FROM csa_role C 
LEFT OUTER JOIN registry R 
	ON R.idreg=C.idreg
LEFT OUTER JOIN accmotive accmotivedebit
	ON C.idaccmotivedebit = accmotivedebit.idaccmotive
LEFT OUTER JOIN accmotive accmotivecredit
	ON C.idaccmotivecredit = accmotivecredit.idaccmotive


GO

print '[csa_roleview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'locationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW locationview
GO


CREATE   VIEW locationview 
(
	idlocation,
	locationcode,
	newlocationcode,
	nlevel,
	leveldescr,
	paridlocation,
	description,
	idman,
	manager,
	active,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	location.idlocation,
	location.locationcode,
	location.newlocationcode,
	location.nlevel,
	locationlevel.description,
	location.paridlocation,
	location.description,
	location.idman,
	manager.title,
	location.active,
	location.cu, 
	location.ct, 
	location.lu,
	location.lt 
FROM location
JOIN locationlevel
	ON locationlevel.nlevel = location.nlevel
LEFT OUTER JOIN manager
	ON manager.idman = location.idman





GO

print 'locationview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'stocktotalview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW stocktotalview
GO


CREATE     VIEW [stocktotalview]
(
	idstore,
	store,
	deliveryaddress,
	idlist,
	list,
	intcode,
	idlistclass,
	codelistclass,
	listclass,
	number,
	ordered,
	booked,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS SELECT
	store.idstore,
	store.description,
	store.deliveryaddress,
	list.idlist,
	list.description,
	list.intcode,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	ISNULL(stocktotal.number,0),
	ISNULL(stocktotal.ordered,0),
	ISNULL(stocktotal.booked,0),
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05
FROM list
CROSS JOIN store 
LEFT OUTER JOIN stocktotal
	ON stocktotal.idstore = store.idstore
	AND stocktotal.idlist = list.idlist
LEFT OUTER JOIN listclass 
	ON list.idlistclass = listclass.idlistclass


GO

print '[stocktotalview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'stockview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW stockview
GO



--clear_table_info'stockview'
CREATE    VIEW [stockview]
(
	idstock,
	idstore,
	store,
	idlist,
	number,
	residual,
	available,
	amount,
	expiry,
	idmankind,
	mandatekind,
	yman,
	nman,
	man_idgroup,
	idinvkind,
	invoicekind,
	yinv,
	ninv,
	inv_idgroup,
	idddt_in,
	idstoreload_motive,
	storeload_motive,
	list,
	intcode,
	unit,
	yddt_in,
	nddt_in,
	codelistclass,
	listclass,
	authrequired,
	flagto_unload,
	adate,
	idstocklocation,
	stocklocationcode,
	stocklocation,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
AS
SELECT
	stock.idstock,
	store.idstore,
	store.description,
	stock.idlist,
	stock.number,
	stock.number -  ISNULL(
						(SELECT SUM(storeunloaddetail.number)
                       FROM storeunloaddetail 
					  WHERE storeunloaddetail.idstock = stock.idstock),0),
	-- disponibile da prenotare				  
	stock.number - ISNULL(
						(SELECT SUM(storeunloaddetail.number) 
                       FROM storeunloaddetail 
					  WHERE storeunloaddetail.idstock = stock.idstock
					  AND storeunloaddetail.idbooking is null),0)
				 -
				   ISNULL(
						(SELECT SUM(number)
						FROM bookingdetail 
						WHERE stock.idstock = bookingdetail.idstock),0),
	stock.amount,
	stock.expiry,
	stock.idmankind,
	mandatekind.description,
	stock.yman,
	stock.nman,
	stock.man_idgroup,
	stock.idinvkind,
	invoicekind.description,
	stock.yinv,
	stock.ninv,
	stock.inv_idgroup,
	stock.idddt_in,
	stock.idstoreload_motive,
	storeload_motive.description,
	list.description,
	list.intcode,
	unit.description,
	ddt_in.yddt_in,
	ddt_in.nddt_in,
	listclass.codelistclass,
	listclass.title,
	listclass.authrequired,
	flagto_unload,
	stock.adate,
	SL.idstocklocation,
	SL.stocklocationcode,
	SL.description,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05
FROM stock
JOIN store
	ON stock.idstore = store.idstore
JOIN list
	ON list.idlist = stock.idlist
LEFT OUTER JOIN unit
	ON list.idunit = unit.idunit
LEFT OUTER JOIN listclass
	ON listclass.idlistclass = list.idlistclass
LEFT OUTER JOIN mandatekind
	ON mandatekind.idmankind = stock.idmankind
LEFT OUTER JOIN invoicekind
	ON invoicekind.idinvkind = stock.idinvkind
LEFT OUTER JOIN  ddt_in
	ON ddt_in.idddt_in = stock.idddt_in
LEFT OUTER JOIN storeload_motive
	ON storeload_motive.idstoreload_motive = stock.idstoreload_motive
LEFT OUTER JOIN stocklocation SL
	ON SL.idstocklocation = stock.idstocklocation



GO

print '[stockview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensepayrollview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensepayrollview
GO



CREATE     VIEW [expensepayrollview]
(
	idpayroll, idexp, fiscalyear, npayroll, 
	nphase, phase, ymov, nmov, 
	parentidexp, parentymov,parentnmov, 
	formerymov,formernmov,
	ayear, idfin, 
	codefin, finance, 
	idupb,	codeupb,upb,
	idreg,registry,
	idman, manager,kpay, ypay,npay, 
	doc, docdate, description, 
	amount,
	ayearstartamount, 
	curramount, available, 
	idpaymethod, iban, cin, 
	idbank, idcab,cc, 
	paymentdescr, idser, 
	service, codeser, servicestart, 
	servicestop, ivaamount, 
	flag,
	autokind,
	idpayment, 
	totflag,
	flagarrear, 
	expiration, adate, cu, 
	ct, lu, lt, 
	idcon,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS
SELECT
	expensepayroll.idpayroll, expense.idexp, payroll.fiscalyear, 
	payroll.npayroll, 
	expense.nphase, expensephase.description , expense.ymov, expense.nmov, 
	expense.parentidexp, parentexpense.ymov, parentexpense.nmov,
	former.ymov,former.nmov,
	expenseyear.ayear, expenseyear.idfin, 
	fin.codefin, fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	expense.idreg, registry.title,
	expense.idman, manager.title , payment.kpay, payment.ypay, payment.npay, 
	expense.doc, expense.docdate, expense.description, 
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount, expensetotal.available, 
	expenselast.idpaymethod, expenselast.iban, expenselast.cin, 
	expenselast.idbank, expenselast.idcab, expenselast.cc, 
	expenselast.paymentdescr, expenselast.idser, 
	service.description, service.codeser, expenselast.servicestart, 
	expenselast.servicestop, expenselast.ivaamount, 
	expenselast.flag,
	expense.autokind, 
	expense.idpayment, 
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration, expense.adate, expensepayroll.cu, 
	expensepayroll.ct, expensepayroll.lu, expensepayroll.lt, 
	payroll.idcon,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
FROM expensepayroll
JOIN payroll 
	ON payroll.idpayroll = expensepayroll.idpayroll 
JOIN config
	ON config.ayear = payroll.fiscalyear 
JOIN expense
	ON expense.idexp=expensepayroll.idexp 
JOIN expensephase
	ON expensephase.nphase = expense.nphase 
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp 
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp 
	AND expensetotal.ayear = expenseyear.ayear 
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp 
LEFT OUTER JOIN expense former
	ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp 
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin 
LEFT OUTER JOIN upb
	ON  upb.idupb = expenseyear.idupb 
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg 
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman 
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay


GO

print '[expensepayrollview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'storeunloaddetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW storeunloaddetailview
GO



CREATE     VIEW [storeunloaddetailview]
(
	idstoreunload,
	ystoreunload,
	nstoreunload,
	idstoreunloaddetail,
	idstock,
	idstore,
	storeunload_motive,
	idlist,
	store,
	number,
	idbooking,
	ybooking,
	nbooking,
	forename,
	surname,
	idman,
	manager,
	idinvkind,
	invkind,
	yinv,
	ninv,
	detaildescription,
	rownum,
	adate,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	lu,
	cu,
	ct,
	lt
)
AS SELECT
	storeunloaddetail.idstoreunload,
	storeunload.ystoreunload,
	storeunload.nstoreunload,
	storeunloaddetail.idstoreunloaddetail,
	storeunloaddetail.idstock,
	storeunload.idstore,
	storeunload_motive.description,
	stock.idlist,
	store.description,
	storeunloaddetail.number,
	storeunloaddetail.idbooking,
	booking.ybooking,
	booking.nbooking,
	booking.forename,
	booking.surname,
	manager.idman,
	manager.title,
	storeunloaddetail.idinvkind,
	invoicekind.description,
	storeunloaddetail.yinv,
	storeunloaddetail.ninv,
	invoicedetail.detaildescription,
	storeunloaddetail.rownum,
	storeunload.adate,
	store.idsor01,store.idsor02,store.idsor03,store.idsor04,store.idsor05,
	storeunloaddetail.lu,
	storeunloaddetail.cu,
	storeunloaddetail.ct,
	storeunloaddetail.lt
FROM storeunloaddetail
JOIN storeunload 
	ON storeunloaddetail.idstoreunload = storeunload.idstoreunload
LEFT OUTER JOIN booking 
	ON booking.idbooking = storeunloaddetail.idbooking
LEFT OUTER JOIN manager 
	ON manager.idman = storeunloaddetail.idman
LEFT OUTER JOIN  store
	ON store.idstore = storeunload.idstore
LEFT OUTER JOIN  stock
	ON stock.idstock = storeunloaddetail.idstock
LEFT OUTER JOIN  list 
	ON stock.idlist = list.idlist
LEFT OUTER JOIN listclass 
	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN invoicedetail
	ON storeunloaddetail.idinvkind = invoicedetail.idinvkind AND 
	storeunloaddetail.yinv = invoicedetail.yinv AND 
	storeunloaddetail.ninv = invoicedetail.ninv 
LEFT OUTER JOIN invoicekind
	ON invoicekind.idinvkind = invoicedetail.idinvkind  
LEFT OUTER JOIN storeunload_motive
	ON storeunload_motive.idstoreunload_motive = storeunload.idstoreunload_motive


GO

print '[storeunloaddetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensecreditproceedsview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensecreditproceedsview
GO



CREATE          VIEW expensecreditproceedsview
(
	ayear,
	idexp,	ymov,	nmov, description,curramount,
	idfin,
	codefin,
	fin,
	idupb,
	codeupb,
	upb,
	idunderwriting,
	codeunderwriting,
	underwriting,
	appropriation,
	payments, 
	topay,
	paymentsavailable,
	proceedsavailable
)
AS
SELECT 
	i1.ayear,
	s1.idexp,s1.ymov,s1.nmov, s1.description,	i2.curramount,
	i1.idfin, f.codefin,f.title,
	i1.idupb, u.codeupb, u.title,
	UW.idunderwriting, UW.codeunderwriting, UW.title,
	--appropriation
	UA.amount + isnull( (select sum(amount) from expensevar EV 
							where EV.idexp=S1.idexp and EV.idunderwriting=UA.idunderwriting),0),
	--payments
	isnull( (select sum(amount) from underwritingpayment UP  
							join expenselink EL on EL.idparent=s1.idexp  and EL.idchild= UP.idexp 
												and UP.idunderwriting= UA.idunderwriting							
							),0)+
	isnull ( (select sum(amount) from expensevar PV  
							join expenselast ELA on PV.idexp=ELA.idexp
							join expenselink EL on EL.idparent=s1.idexp  and EL.idchild= PV.idexp
									and PV.idunderwriting= UA.idunderwriting
							),0),
	--topay = appropriation-payments
	UA.amount + isnull( (select sum(amount) from expensevar EV 
							where EV.idexp=S1.idexp and EV.idunderwriting=UA.idunderwriting),0)
	- isnull( (select sum(amount) from underwritingpayment UP  
							join expenselink EL on EL.idparent=s1.idexp  and EL.idchild= UP.idexp 
												and UP.idunderwriting= UA.idunderwriting
							),0)
	- isnull ( (select sum(amount) from expensevar PV  
							join expenselast ELA on PV.idexp=ELA.idexp
							join expenselink EL on EL.idparent=s1.idexp  and EL.idchild= PV.idexp
									and PV.idunderwriting= UA.idunderwriting
							),0),
	--paymentpreavailable = prev.secondaria - pagamenti	
	ISNULL(UWT.currentprev,0) + ISNULL(UWT.previsionvariation,0) 
			- (ISNULL(UET.totalcompetency,0) + ISNULL(UET.totalarrears,0)),
	--proceedsavailable = tot proceeds - pagamenti
	isnull( UWT.totproceedspart,0)
	- isnull( UET.totalcompetency ,0)- isnull(UET.totalarrears,0)
	
	
FROM expense s1
INNER JOIN expenseyear i1 
	  ON s1.idexp = i1.idexp 
INNER JOIN fin f
	  ON F.idfin= i1.idfin
INNER JOIN upb U 
      ON U.idupb= i1.idupb
INNER JOIN  underwritingappropriation UA
	  ON UA.idexp=s1.idexp	
INNER JOIN  underwriting UW
	  ON UW.idunderwriting = UA.idunderwriting		
INNER JOIN expensetotal i2
	ON i1.idexp = i2.idexp
	AND i1.ayear = i2.ayear
LEFT OUTER JOIN upbunderwritingtotal UWT
		on UWT.idfin=i1.idfin and UWT.idupb=i1.idupb and UWT.idunderwriting=UA.idunderwriting
LEFT OUTER JOIN underwritingexpensetotal UET
	ON UET.idunderwriting = UA.idunderwriting
	AND UET.idupb = i1.idupb
	AND UET.idfin = i1.idfin
	AND UET.nphase = (select max(nphase) from expensephase)


GO

print 'expensecreditproceedsview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expenseprofserviceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expenseprofserviceview
GO


CREATE     VIEW [expenseprofserviceview]
(
	ycon,
	ncon,
	movkind,
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,	
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	autokind,
	idpayment,
	totflag,
	flagarrear,
	expiration,
	adate,
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
	expenseprofservice.ycon,
	expenseprofservice.ncon,
	expenseprofservice.movkind,
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,	
	upb.codeupb,	
	upb.title,	
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	expense.doc,
	expense.docdate,
	expense.description,	
	expenseyear_starting.amount, 
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expense.autokind,
	expense.idpayment,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.expiration,
	expense.adate,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expenseprofservice.cu,
	expenseprofservice.ct,
	expenseprofservice.lu,
	expenseprofservice.lt
FROM expenseprofservice
JOIN profservice
	ON expenseprofservice.ycon = profservice.ycon
	AND expenseprofservice.ncon = profservice.ncon
JOIN config
	ON config.ayear=expenseprofservice.ycon 
JOIN expense
	ON expense.idexp = expenseprofservice.idexp
JOIN expensephase
	ON expensephase.nphase = expense.nphase
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON expensetotal.idexp = expenseyear.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense former
	ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expensetotal expensetotal_firstyear
	ON expensetotal_firstyear.idexp = expense.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN expense parentexpense
	ON expense.parentidexp = parentexpense.idexp
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN service
	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay



GO

print '[expenseprofserviceview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensevarview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensevarview
GO


CREATE           VIEW [expensevarview]
(
	idexp,
	nvar,
	yvar,
	nphase,
	phase,
	ymov,
	nmov,
	description,
	amount,
	doc,
	docdate,
	autokind,
	idpayment,
	adate,
	transferkind,
	cu,
	ct,
	lu,
	lt,
	codefin,
	finance,
	codeupb,
	upb,
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	movkind,
	kpaymenttransmission,
	kpay,
	ypay,
	npay,
	kpaymenttransmission_orig,
	idman,
	idtreasurer,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idunderwriting,
	underwriting
)
AS SELECT
	expensevar.idexp,
	expensevar.nvar,
	expensevar.yvar,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expensevar.description,
	expensevar.amount,
	expensevar.doc,
	expensevar.docdate,
	expensevar.autokind,
	expensevar.idpayment,
	expensevar.adate,
	expensevar.transferkind,
	expensevar.cu,
	expensevar.ct,
	expensevar.lu,
	expensevar.lt,
	fin.codefin,
	fin.title,
	upb.codeupb,
	upb.title,
	expensevar.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	expensevar.yinv,
	expensevar.ninv,
	expensevar.movkind,
	expensevar.kpaymenttransmission,
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.kpaymenttransmission,
	expense.idman,
	payment.idtreasurer,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expensevar.idunderwriting,
	underwriting.title
FROM expensevar (NOLOCK)
JOIN expense (NOLOCK)
	ON expense.idexp = expensevar.idexp
JOIN expensephase (NOLOCK)
	ON expensephase.nphase = expense.nphase
JOIN expenseyear (NOLOCK)
	ON expenseyear.idexp= expense.idexp
     AND expenseyear.ayear= expensevar.yvar
LEFT OUTER JOIN expenselast (NOLOCK)
	ON expenselast.idexp= expense.idexp
LEFT OUTER JOIN payment (NOLOCK)
	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN fin (NOLOCK)
	ON fin.idfin= expenseyear.idfin
LEFT OUTER JOIN upb (NOLOCK)
	ON upb.idupb= expenseyear.idupb
LEFT OUTER JOIN invoicekind
	ON expensevar.idinvkind = invoicekind.idinvkind
LEFT OUTER JOIN underwriting
	ON expensevar.idunderwriting = underwriting.idunderwriting


GO

print '[expensevarview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensesortedview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensesortedview
GO




CREATE    VIEW [expensesortedview]
(
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	idsubclass,
	idsorkind,
	codesorkind,
	idsor,
	sortcode,
	sorting,
	amount,
	description,
	adate,
	cu,
	ct,
	lu,
	lt,
	flagnodate, 
	tobecontinued, 
	start, 
	stop, 
	valuen1, 
	valuen2,                       
	valuen3, 
	valuen4, 
	valuen5, 
	values1, 
	values2, 
	values3, 
	values4, 
	values5, 
	valuev1, 
	valuev2, 
	valuev3, 
	valuev4, 
	valuev5, 
	paridsorkind, 
	parcodesorkind,
	paridsor, 
	paridsubclass,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	ayear,
	totflag,
	flagarrear,
	registry,
	npay
)
AS SELECT
	expensesorted.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expensesorted.idsubclass,
	sorting.idsorkind,
	sortingkind.codesorkind,
	expensesorted.idsor,
	sorting.sortcode,
	sorting.description,
	expensesorted.amount,
	expensesorted.description,
	expense.adate,
	expensesorted.cu,
	expensesorted.ct,
	expensesorted.lu,
	expensesorted.lt,
	expensesorted.flagnodate, 
	expensesorted.tobecontinued, 
	expensesorted.start, 
	expensesorted.stop, 
	expensesorted.valuen1, 
	expensesorted.valuen2,                       
	expensesorted.valuen3, 
	expensesorted.valuen4, 
	expensesorted.valuen5, 
	expensesorted.values1, 
	expensesorted.values2, 
	expensesorted.values3, 
	expensesorted.values4, 
	expensesorted.values5, 
	expensesorted.valuev1, 
	expensesorted.valuev2, 
	expensesorted.valuev3, 
	expensesorted.valuev4, 
	expensesorted.valuev5, 
	parsor.idsorkind, 
	parsorkind.codesorkind,
	expensesorted.paridsor, 
	expensesorted.paridsubclass,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expenseyear.ayear,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END,
	registry.title,
	payment.npay
FROM expensesorted 
JOIN expense 
	ON expense.idexp = expensesorted.idexp
JOIN expensephase 
	ON expensephase.nphase = expense.nphase
JOIN sorting 
	ON sorting.idsor = expensesorted.idsor
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
JOIN expenseyear 
	ON expenseyear.idexp = expense.idexp
	AND expenseyear.ayear= expensesorted.ayear
JOIN expensetotal 
	ON expensetotal.idexp = expense.idexp
	AND expensetotal.ayear= expenseyear.ayear
LEFT OUTER JOIN sorting parsor
	ON parsor.idsor = expensesorted.paridsor
LEFT OUTER JOIN sortingkind parsorkind
	ON parsorkind.idsorkind = parsor.idsorkind
LEFT OUTER JOIN fin 
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb  
	ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN expenselast
	ON expenselast.idexp = expensesorted.idexp
LEFT OUTER JOIN payment
	ON payment.kpay = expenselast.kpay


GO

print '[expensesortedview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'paymenttransmissionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW paymenttransmissionview
GO



CREATE    VIEW paymenttransmissionview 
	(
	kpaymenttransmission,
	ypaymenttransmission,
  	npaymenttransmission,
	idman,
	manager,
	idtreasurer,
	codetreasurer,
  	transmissiondate,
	total,
	flagmailsent,
	transmissionkind,
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
	paymenttransmission.kpaymenttransmission,
	paymenttransmission.ypaymenttransmission,
  	paymenttransmission.npaymenttransmission,
	paymenttransmission.idman,
	manager.title,
	paymenttransmission.idtreasurer,
	treasurer.codetreasurer,
 	paymenttransmission.transmissiondate,
	ISNULL((SELECT SUM(ISNULL(total,0)) FROM paymentview d 
	WHERE d.kpaymenttransmission = paymenttransmission.kpaymenttransmission ),0),
	paymenttransmission.flagmailsent,
	paymenttransmission.transmissionkind,
	treasurer.idsor01,
	treasurer.idsor02,
	treasurer.idsor03,
	treasurer.idsor04,
	treasurer.idsor05,
 	paymenttransmission.cu,
  	paymenttransmission.ct,
  	paymenttransmission.lu,
  	paymenttransmission.lt
	FROM paymenttransmission
	LEFT OUTER JOIN manager
	ON manager.idman = paymenttransmission.idman
	LEFT OUTER JOIN treasurer 
	ON treasurer.idtreasurer = paymenttransmission.idtreasurer




GO

print 'paymenttransmissionview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'incomeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW incomeview
GO



CREATE    VIEW [incomeview]
(
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	parentymov,
	parentnmov,
	parentidinc,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idreg,
	registry,
	idman,
	manager,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
  	unpartitioned,
	flag,
	totflag,
	flagarrear,
	autokind,
	autocode,
	idpayment,
	expiration,
	adate,
	nbill,
	idpro,
	nproceedstransmission,
	transmissiondate,
	idacccredit, 
	codeacccredit,
	cupcode,
	idunderwriting,
	underwriting,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	income.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	parentincome.ymov,
	parentincome.nmov,
	income.parentidinc,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	-- Modificato da Francesco per correggere la visualizzazione dell'importo da assegnare su movimenti residui
        case income.nphase 
	 WHEN (SELECT incomefinphase from uniconfig) THEN
		CASE   
			WHEN ((incometotal.flag&1) = 0) THEN  ISNULL(incometotal.curramount,0)-ISNULL(incometotal.partitioned,0)
			ELSE
			0
		END
	ELSE
		  ISNULL(incometotal.curramount,0)-ISNULL(incometotal.partitioned,0)
	END,
	incomelast.flag,
	incometotal.flag, 
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	income.autocode,
	income.idpayment,
	income.expiration,
	income.adate,
	incomelast.nbill,
	incomelast.idpro,
	proceedstransmission.nproceedstransmission,
	proceedstransmission.transmissiondate,
	incomelast.idacccredit,
	account.codeacc,
	income.cupcode,
	income.idunderwriting,
	underwriting.title,
	income.cu,
	income.ct,
	income.lu,
	income.lt
	FROM income (NOLOCK)
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)
		ON incomeyear.idinc = income.idinc 
	JOIN incometotal (NOLOCK)
		ON incometotal.idinc = income.idinc
		AND incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN income parentincome (NOLOCK)
		ON income.parentidinc = parentincome.idinc
	LEFT OUTER JOIN incomelast  (NOLOCK)
		ON incomelast.idinc = income.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN fin (NOLOCK)
		ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)
		ON upb.idupb=incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)
		ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)
		ON manager.idman = income.idman
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
	  	ON incometotal_firstyear.idinc = income.idinc
  		AND ((incometotal_firstyear.flag & 2) <> 0 )
 	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	LEFT OUTER JOIN proceedstransmission
		ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
	LEFT OUTER JOIN account 
		ON account.idacc =  incomelast.idacccredit
	LEFT OUTER JOIN underwriting
		ON income.idunderwriting = underwriting.idunderwriting		





GO

print '[incomeview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoicedetailgroupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoicedetailgroupview
GO


CREATE     VIEW invoicedetailgroupview
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	rownum,
	detaildescription,
	idivakind,
	ivakind,
	rate,
	unabatabilitypercentage,
	number,
	taxable,
	discount,
	tax,
	unabatable,
	exchangerate,
	annotations,
	idmankind,
	mankind,
	yman,
	nman,
	manrownum,
	manidgroup,
	mandetaildescription,
	adate,	
	idlist,
	npackage,
	idunit,
	idpackage,
	unitsforpackage,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05 
)
	AS SELECT
	invoicedetail.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoicedetail.yinv,
	invoicedetail.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)=1) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)=1) THEN 'S'
	END, 
	invoicedetail.rownum,
	invoicedetail.detaildescription,
	invoicedetail.idivakind,
	ivakind.description,
	ivakind.rate,
	ivakind.unabatabilitypercentage,
	invoicedetail.number,
	isnull(sum(invoicedetail.taxable),0),
	invoicedetail.discount,
	isnull(sum(invoicedetail.tax),0),
	isnull(sum(invoicedetail.unabatable),0),
	invoice.exchangerate,
	invoicedetail.annotations,
	invoicedetail.idmankind,
	mandatekind.description,
	invoicedetail.yman,
	invoicedetail.nman,
	invoicedetail.manrownum,
	mandatedetail.idgroup,
	mandatedetail.detaildescription,
	invoice.adate,
	invoicedetail.idlist,
	invoicedetail.npackage,
	invoicedetail.idunit,
	invoicedetail.idpackage,
	invoicedetail.unitsforpackage,
	invoice.active,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05
FROM invoicedetail (NOLOCK)
JOIN ivakind (NOLOCK)
	ON ivakind.idivakind = invoicedetail.idivakind
JOIN invoice (NOLOCK)
	ON invoice.ninv = invoicedetail.ninv
	AND invoice.yinv = invoicedetail.yinv
	AND invoice.idinvkind = invoicedetail.idinvkind
JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoicedetail.idinvkind
JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
LEFT OUTER JOIN mandatedetail (NOLOCK)
	ON invoicedetail.idmankind = mandatedetail.idmankind
	AND invoicedetail.yman = mandatedetail.yman
	AND invoicedetail.nman = mandatedetail.nman
	AND invoicedetail.manrownum = mandatedetail.rownum
LEFT OUTER JOIN mandatekind  (NOLOCK)
	ON mandatekind.idmankind = mandatedetail.idmankind
GROUP BY 
	invoicedetail.yman,
	invoicedetail.nman,
	invoicedetail.manrownum,
	mandatedetail.idgroup,
	invoicedetail.idinvkind,
	invoicedetail.yinv,
	invoicedetail.ninv,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoicekind.flag,
	(invoicekind.flag&1),
	(invoicekind.flag&4),
	invoicedetail.rownum,
	invoicedetail.detaildescription,
	invoicedetail.idivakind,
	ivakind.description,
	ivakind.rate,
	ivakind.unabatabilitypercentage,
	invoicedetail.number,
	invoicedetail.discount,
	invoice.exchangerate,
	invoicedetail.annotations,
	invoicedetail.idmankind,
	mandatekind.description,
	mandatedetail.detaildescription,
	invoice.adate,
	invoicedetail.idlist,
	invoicedetail.npackage,
	invoicedetail.idunit,
	invoicedetail.idpackage,
	invoicedetail.unitsforpackage ,
	invoice.active,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05





GO

print 'invoicedetailgroupview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'pettycashoperationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW pettycashoperationview
GO


CREATE  VIEW pettycashoperationview 
(
	yoperation,
	noperation,
	idpettycash,
	pettycash,
	pettycode,
	flag,
	kind,
	idreg,
	registry,
	idaccmotive_cost,
	codemotive_cost,
	motive_cost,
	idaccmotive_debit,
	codemotive_debit,
	motive_debit,
	flagdocumented,
	idfin,
	finpart,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	yrestore,
	nrestore,
	adaterestore,
	description,
	doc,
	docdate,
	amount,
	adate,
	nlist,
	nbill,
	cu,
	ct,
	lu,
	lt,
	idman,
	manager,
	idexp,
	idsor1,
	idsor2,
	idsor3,
	start,
	stop
)
AS SELECT
	pettycashoperation.yoperation,
	pettycashoperation.noperation,
	pettycashoperation.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	pettycashoperation.flag,
	CASE
		WHEN (pettycashoperation.flag & 1) <> 0 THEN 'A'
		WHEN (pettycashoperation.flag & 2) <> 0 THEN 'R'
		WHEN (pettycashoperation.flag & 4) <> 0 THEN 'C'
		WHEN (pettycashoperation.flag & 8) <> 0 THEN 'S'
	END,
	pettycashoperation.idreg,
	registry.title,
	pettycashoperation.idaccmotive_cost,
	AMC.codemotive,
	AMC.title,
	pettycashoperation.idaccmotive_debit,
	AMD.codemotive,
	AMD.title,
	CASE
		WHEN (pettycashoperation.flag & 16) <> 0 THEN 'S'
		ELSE 'N'
	END,
	pettycashoperation.idfin,
 	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	END,
	fin.codefin,
	fin.title,
	pettycashoperation.idupb,
	upb.codeupb,
	upb.title,
	pettycashoperation.idsor01,
	pettycashoperation.idsor02,
	pettycashoperation.idsor03,
	pettycashoperation.idsor04,
	pettycashoperation.idsor05,
	pettycashoperation.yrestore,
	pettycashoperation.nrestore,
	restoreop.adate,
	pettycashoperation.description,
	pettycashoperation.doc,
	pettycashoperation.docdate,
	pettycashoperation.amount,
	pettycashoperation.adate,
	pettycashoperation.nlist,
	pettycashoperation.nbill,
	pettycashoperation.cu,
	pettycashoperation.ct,
	pettycashoperation.lu,
	pettycashoperation.lt,
	pettycashoperation.idman,
	manager.title,
	pettycashoperation.idexp,
	pettycashoperation.idsor1,
	pettycashoperation.idsor2,
	pettycashoperation.idsor3,
	pettycashoperation.start,
	pettycashoperation.stop
FROM pettycashoperation
LEFT OUTER JOIN pettycash
	ON pettycash.idpettycash = pettycashoperation.idpettycash
LEFT OUTER JOIN fin
	ON fin.idfin = pettycashoperation.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = pettycashoperation.idupb
LEFT OUTER JOIN manager
	ON manager.idman = pettycashoperation.idman
LEFT OUTER JOIN registry
	ON registry.idreg = pettycashoperation.idreg
LEFT OUTER JOIN accmotive AMC
	ON AMC.idaccmotive = pettycashoperation.idaccmotive_cost
LEFT OUTER JOIN accmotive AMD
	ON AMD.idaccmotive = pettycashoperation.idaccmotive_debit
LEFT OUTER JOIN pettycashoperation restoreop 
	ON restoreop.yoperation = pettycashoperation.yrestore 
	AND restoreop.noperation = pettycashoperation.nrestore 
	AND restoreop.idpettycash = pettycashoperation.idpettycash 
	AND (restoreop.flag& 2)<>0 


GO

print 'pettycashoperationview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceedsview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceedsview
GO



CREATE    VIEW [proceedsview]
	(
	kpro,
	ypro,
	npro,
	idstamphandling,
	stamphandling,
	idtreasurer,
	codetreasurer,
	flag,
	kind,
	accountkind,
	idreg,
	registry,
	idfin,
	codefin,
	finance,
	idman,
	manager,
	kproceedstransmission,
	yproceedstransmission,
	nproceedstransmission,
	transmissiondate,
	adate,
	printdate,
	annulmentdate,
	cu,
	ct,
	lu,
	lt,	
	total,
	performed,
	notperformed,
	idsor01,idsor02,idsor03,idsor04,idsor05
	)
	AS 
	SELECT
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	proceeds.idstamphandling,
	stamphandling.description,
	proceeds.idtreasurer,
	treasurer.codetreasurer,
	proceeds.flag,
	CASE
		WHEN ((proceeds.flag&1) <>0) THEN 'C'
		WHEN ((proceeds.flag&2) <>0) THEN 'R'
		WHEN ((proceeds.flag&4) <>0) THEN 'M'
	END, 
	CASE
		WHEN ((proceeds.flag&8)=0)  THEN 'I'
		WHEN ((proceeds.flag&8)<>0) THEN 'F'
	END, 
        --treasurer.flagfruitful, 
	proceeds.idreg,
	registry.title,
	proceeds.idfin,
	fin.codefin,
	fin.title,
	proceeds.idman,
	manager.title,
	proceedstransmission.kproceedstransmission,
	proceedstransmission.yproceedstransmission,
	proceedstransmission.nproceedstransmission,
	proceedstransmission.transmissiondate,
	proceeds.adate,
	proceeds.printdate,
	proceeds.annulmentdate,
	proceeds.cu,
	proceeds.ct,
	proceeds.lu,
	proceeds.lt,
	(SELECT SUM(curramount) 
	from incometotal I 
	join income S 
		on I.idinc=S.idinc
	join incomelast ST
		on S.idinc = ST.idinc
	WHERE ST.kpro=proceeds.kpro
			AND I.ayear = proceeds.ypro
	),
	ISNULL( (SELECT SUM(amount) from banktransaction P where
					P.kpro=proceeds.kpro),0),
	(SELECT SUM(curramount) 
	from incometotal I 
	join income S 
		on I.idinc=S.idinc 
	join incomelast ST
		on S.idinc = ST.idinc
	WHERE ST.kpro=proceeds.kpro AND I.ayear = proceeds.ypro)
	-
	 ISNULL( (SELECT SUM(amount) from banktransaction P where
					P.kpro=proceeds.kpro),0)                ,
	COALESCE(proceeds.idsor01,treasurer.idsor01),COALESCE(proceeds.idsor02,treasurer.idsor02),COALESCE(proceeds.idsor03,treasurer.idsor03),
	COALESCE(proceeds.idsor04,treasurer.idsor04),COALESCE(proceeds.idsor05,treasurer.idsor05)             
	FROM proceeds  with (NOLOCK)
	LEFT OUTER JOIN registry  with (NOLOCK)
		ON registry.idreg = proceeds.idreg
	LEFT OUTER JOIN fin  with (NOLOCK)
		ON fin.idfin = proceeds.idfin
	LEFT OUTER JOIN manager with (NOLOCK)
		ON manager.idman = proceeds.idman
	LEFT OUTER JOIN stamphandling with (NOLOCK)
		ON stamphandling.idstamphandling = proceeds.idstamphandling
	LEFT OUTER JOIN proceedstransmission  with (NOLOCK)
		ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
 	LEFT OUTER JOIN treasurer with (NOLOCK)
		ON treasurer.idtreasurer = proceeds.idtreasurer




GO

print '[proceedsview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoiceresidual') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoiceresidual
GO


CREATE       VIEW [invoiceresidual]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	description,
	idreg,
	doc,
	docdate,
	idupb,
	registry,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkeddocum,
	flag,
	flagbuysell,
	flagvariation,
	ycon,
	ncon,
	active,
	upb,
	flagintracom,
	idupb_iva,
	upb_iva,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoice.yinv,
	invoice.ninv,
	invoice.description,
	invoice.idreg,
	invoice.doc,
	invoice.docdate,
	invoicedetail.idupb,
	registry.title,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	   ),0)
	),
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(ROUND(invoicedetail.tax,2)
	   ),0)
	),
	-- residuo :somma dei dett. fattura non contabilizzati 
	-- oppure 0 se la fattura è di ACQUISTO contabilizzata con fondo economale
	-- (la contabilizzazione totale è obbligatoria in questo caso)
	CASE 
	WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NOT NULL)
	THEN 0
	WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NULL)
	THEN CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoice.flagintracom<>'N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
				WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoicedetail.idexp_iva IS  NOT NULL)AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	
				WHEN (invoicedetail.idexp_iva IS NULL) AND (invoicedetail.idexp_taxable IS  NOT NULL)AND (invoice.flagintracom='N')
				THEN
				    ROUND(invoicedetail.tax ,2)
	
				WHEN (invoicedetail.idexp_iva IS  NULL) AND (invoicedetail.idexp_taxable IS  NULL)AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)  * 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
				     +
				     ROUND(invoicedetail.tax ,2)
				ELSE   0
	
			    END
			   ),0)
			)
	WHEN  ((invoicekind.flag&1)<>0)
	THEN	CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				WHEN (invoicedetail.idinc_taxable IS  NULL) AND (invoice.flagintracom <>'N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
				WHEN (invoicedetail.idinc_taxable IS  NULL) AND (invoicedetail.idinc_iva IS  NOT NULL)AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	
				WHEN (invoicedetail.idinc_iva IS NULL) AND (invoicedetail.idinc_taxable IS  NOT NULL)AND (invoice.flagintracom='N')
				THEN
				    ROUND(invoicedetail.tax ,2)
	
				WHEN (invoicedetail.idinc_iva IS  NULL) AND (invoicedetail.idinc_taxable IS  NULL)AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
				     +
				     ROUND(invoicedetail.tax ,2)
				ELSE   0
	
			    END
			   ),0)
			)
	END,
-- (mov.movkind = 'IMPON' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN ((((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
				AND (invoicedetail.idexp_iva IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) OR
			      ( ((invoicekind.flag&1)<>0) AND invoicedetail.idinc_taxable IS NOT NULL 
				AND (invoicedetail.idinc_iva IS NULL OR 
				invoicedetail.idinc_taxable<>invoicedetail.idinc_iva)) )
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		),
-- (mov.movkind = 'IMPOS')
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN ((((invoicekind.flag&1)=0) AND  invoicedetail.idexp_iva IS NOT NULL 
				AND  (invoicedetail.idexp_taxable IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) OR
			     ( ((invoicekind.flag&1)<>0) AND invoicedetail.idinc_iva IS NOT NULL 
				AND  (invoicedetail.idinc_taxable IS NULL OR 
				invoicedetail.idinc_taxable<>invoicedetail.idinc_iva)) )
			
			THEN
			       ROUND(invoicedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		),
	
--  (mov.movkind = 'DOCUM' )
	CASE 
		WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NOT NULL)
			THEN 
				CONVERT(DECIMAL(19,2),
						ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)*  
						     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
						     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
					   ),0)
					)
				+
				CONVERT(DECIMAL(19,2),
					ISNULL(SUM(ROUND(invoicedetail.tax ,2)
				   ),0)
				)
		ELSE
			CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				WHEN ((((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
					AND invoicedetail.idexp_iva= invoicedetail.idexp_taxable) OR
				     ( ((invoicekind.flag&1)<>0) AND invoicedetail.idinc_taxable IS NOT NULL 
					AND invoicedetail.idinc_iva= invoicedetail.idinc_taxable))
				THEN
		  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
				     +
				     ROUND(invoicedetail.tax ,2)			
				ELSE   0
			    END
			   ),0)
			)
	END,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	profservice.ycon,
	profservice.ncon,
	invoice.active,
	upb.title,
	invoice.flagintracom,
	invoicedetail.idupb_iva,
	upb2.title ,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05 
	FROM invoicedetail (NOLOCK) 
	JOIN invoice (NOLOCK)
  	ON invoicedetail.idinvkind = invoice.idinvkind
	AND invoicedetail.yinv = invoice.yinv
  	AND invoicedetail.ninv = invoice.ninv
	JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
	LEFT OUTER JOIN profservice  (NOLOCK)
	ON profservice.idinvkind=invoice.idinvkind 
	and profservice.yinv=invoice.yinv 
	and profservice.ninv=invoice.ninv
	LEFT OUTER JOIN upb (NOLOCK)
	on upb.idupb=invoicedetail.idupb
	LEFT OUTER JOIN upb upb2 (NOLOCK)
	on upb2.idupb=invoicedetail.idupb_iva
	LEFT OUTER JOIN  pettycashoperationinvoice (NOLOCK)
	ON pettycashoperationinvoice.idinvkind=invoice.idinvkind 
	and pettycashoperationinvoice.yinv=invoice.yinv 
	and pettycashoperationinvoice.ninv=invoice.ninv
	GROUP BY invoice.idinvkind, invoicekind.codeinvkind, invoice.yinv, invoice.ninv,
	invoice.description,invoice.idreg,invoice.doc,invoice.docdate,registry.title,invoicedetail.idupb,profservice.idinvkind,
	invoicekind.flag,(invoicekind.flag&1), (invoicekind.flag&4),profservice.ycon,
	profservice.ncon, pettycashoperationinvoice.idinvkind,invoice.active,upb.title,invoice.flagintracom,
	invoicedetail.idupb_iva, upb2.title,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05 




GO

print '[invoiceresidual] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'upbyearview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW upbyearview
GO


--clear_table_info'upbyearview'
--setuser 'amm'
CREATE     VIEW  upbyearview 
(
	idupb,
	codeupb,
	upb,
	idman,
	manager,
	iddivision,
	codedivision,
	division,
	requested,
	granted,
	assured,
	ayear,
	initialprevision,
	currentprevision,
	initialsecondaryprev,
	currentsecondaryprev,
	incomeprevavailable,
	expenseprevavailable,
	appropriation,
	assessment,
	payment,
	proceeds,
	active,
	cupcode,
	printingorder,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	flagactivity,
	activity,
	flagkind,
	kindd,
	kindr,
	idtreasurer,
	treasurer,	
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idman,
	manager.title,
	division.iddivision,
	division.codedivision,
	division.description,
	upb.requested,
	upb.granted,
	upb.assured,
	accountingyear.ayear,
	-- initialprevision
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal
		JOIN    fin
			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0),
	-- currentprevision
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal
		JOIN    fin
			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbtotal.previsionvariation)
		FROM    upbtotal
		JOIN    fin
			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0),
	-- initialsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbtotal.currentsecondaryprev)
				FROM    upbtotal
				JOIN    fin
					ON fin.idfin = upbtotal.idfin
				WHERE   upbtotal.idupb = upb.idupb
				AND     ( (fin.flag & 1) <>0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = accountingyear.ayear
				GROUP BY upbtotal.idupb)
			,0)
		ELSE NULL
	END,
	-- currentsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbtotal.currentsecondaryprev)
				FROM    upbtotal
				JOIN    fin
					ON fin.idfin = upbtotal.idfin
				WHERE   upbtotal.idupb = upb.idupb
				AND     ( (fin.flag & 1) <>0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = accountingyear.ayear
				GROUP BY upbtotal.idupb)
			,0)
			+ 
			ISNULL(
				(SELECT SUM(upbtotal.secondaryvariation)
				FROM    upbtotal
				JOIN    fin
					ON fin.idfin = upbtotal.idfin
				WHERE   upbtotal.idupb = upb.idupb
				AND     ( (fin.flag & 1) <>0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = accountingyear.ayear
				GROUP BY upbtotal.idupb)
			,0)
		ELSE NULL
	END,
	-- incomeprevavailable
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal
		JOIN    fin
			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbtotal.previsionvariation)
		FROM    upbtotal
		JOIN    fin
			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(upbincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    upbincometotal
		JOIN    fin
			ON fin.idfin = upbincometotal.idfin
		JOIN 	uniconfig 
			ON upbincometotal.nphase = uniconfig.incomefinphase
		WHERE   upbincometotal.idupb = upb.idupb
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbincometotal.idupb)
	,0),
	--expenseprevavailable
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal
		JOIN    fin
			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <> 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbtotal.previsionvariation)
		FROM    upbtotal
		JOIN    fin
			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0 )
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal
		JOIN fin
			ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig 
			ON upbexpensetotal.nphase = uniconfig.expensefinphase
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0),
	-- appropriation
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal
		JOIN fin
			ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig 
			ON upbexpensetotal.nphase = uniconfig.expensefinphase
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0),
	-- assessment
	ISNULL(
		(SELECT
			ISNULL(SUM(upbincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    upbincometotal
		JOIN    fin
			ON fin.idfin = upbincometotal.idfin
		JOIN 	uniconfig 
			ON upbincometotal.nphase = uniconfig.incomefinphase
		WHERE   upbincometotal.idupb = upb.idupb
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbincometotal.idupb)
	,0),
	-- payment
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			ISNULL(SUM(upbexpensetotal.totalarrears),0)
		FROM upbexpensetotal
		JOIN fin
			ON fin.idfin = upbexpensetotal.idfin
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		AND upbexpensetotal.nphase = (SELECT MAX(nphase) FROM expensephase)
		GROUP BY upbexpensetotal.idupb)
	,0),
	-- proceeds
	ISNULL(
		(SELECT
			ISNULL(SUM(upbincometotal.totalcompetency),0) + 
			ISNULL(SUM(upbincometotal.totalarrears),0)
		FROM    upbincometotal
		JOIN    fin
			ON fin.idfin = upbincometotal.idfin
		WHERE upbincometotal.idupb = upb.idupb
		AND fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		AND upbincometotal.nphase = (SELECT MAX(nphase) FROM incomephase)
		GROUP BY upbincometotal.idupb)
	,0),
	upb.active,
	upb.cupcode,
	upb.printingorder,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	upb.flagactivity,
--	activity,
	case
	when upb.flagactivity ='1' then 'Istituzionale'
	when upb.flagactivity ='2' then 'Commerciale'
	-- when upb.flagactivity ='3' then 'p': l'upb non ha il promiscuo
	when upb.flagactivity ='4' then 'Qualsiasi/Non specificata'
	end,
	upb.flagkind,
--	kindd,
	CASE
		when (( upb.flagkind & 1)<> 0) then 'S'
	End,
--	kindr,
	CASE
		when (( upb.flagkind & 2)<>0) then 'S'
	End,
	upb.idtreasurer,
	treasurer.description,
	upb.cu,
	upb.ct,
	upb.lu,
	upb.lt
FROM upb
CROSS JOIN accountingyear
JOIN config
	ON config.ayear = accountingyear.ayear
LEFT OUTER JOIN manager
	ON upb.idman = manager.idman
LEFT OUTER JOIN division
	ON division.iddivision = manager.iddivision
LEFT OUTER JOIN treasurer
	ON treasurer.idtreasurer = upb.idtreasurer



GO

print 'upbyearview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'incomesortedview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW incomesortedview
GO



CREATE    VIEW [incomesortedview]
(
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	idsubclass,
	idsorkind,
	codesorkind,
	idsor,
	sortcode,
	sorting,
	amount,
	description,
	adate,
	cu,
	ct,
	lu,
	lt,
	flagnodate, 
	tobecontinued, 
	start, 
	stop, 
	valuen1, 
	valuen2,                       
	valuen3, 
	valuen4, 
	valuen5, 
	values1, 
	values2, 
	values3, 
	values4, 
	values5, 
	valuev1, 
	valuev2, 
	valuev3, 
	valuev4, 
	valuev5, 
	paridsorkind, 
	parcodesorkind,
	paridsor, 
	paridsubclass,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	ayear,
	totflag,
	flagarrear,
	registry,
	npro
)
AS
SELECT
	incomesorted.idinc, 
	income.nphase, 
	incomephase.description AS phase, 
	income.ymov, income.nmov, 
	incomesorted.idsubclass, 
	sorting.idsorkind, 
	sortingkind.codesorkind,
	incomesorted.idsor, 
	sorting.sortcode, 
	sorting.description AS sorting, 
	incomesorted.amount, 
	incomesorted.description, 
	income.adate, 
	incomesorted.cu, 
	incomesorted.ct, 
	incomesorted.lu, 
	incomesorted.lt, 
	incomesorted.flagnodate, 
	incomesorted.tobecontinued, 
	incomesorted.start, 
	incomesorted.stop, 
	incomesorted.valuen1, 
	incomesorted.valuen2, 
	incomesorted.valuen3, 
	incomesorted.valuen4, 
	incomesorted.valuen5, 
	incomesorted.values1, 
	incomesorted.values2, 
	incomesorted.values3, 
	incomesorted.values4, 
	incomesorted.values5, 
	incomesorted.valuev1, 
	incomesorted.valuev2, 
	incomesorted.valuev3, 
	incomesorted.valuev4, 
	incomesorted.valuev5, 
	parsor.idsorkind, 
	parsorkind.codesorkind,
	incomesorted.paridsor, 
	incomesorted.paridsubclass, 
	incomeyear.idfin, 
	fin.codefin, 
	fin.title AS finance, 
	upb.idupb,
	upb.codeupb,
	upb.title AS upb,
	incomeyear.ayear,
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END,
	registry.title,
	npro
FROM incomesorted
JOIN income
	ON income.idinc = incomesorted.idinc 
JOIN incomephase
	ON incomephase.nphase = income.nphase 
JOIN sorting
	ON sorting.idsor = incomesorted.idsor 
JOIN sortingkind
	ON sortingkind.idsorkind = sorting.idsorkind
LEFT OUTER JOIN sorting parsor
	ON parsor.idsor = incomesorted.paridsor
LEFT OUTER JOIN sortingkind parsorkind
	ON parsorkind.idsorkind = parsor.idsorkind
JOIN incomeyear
	ON incomeyear.idinc = income.idinc 
	AND incomeyear.ayear= incomesorted.ayear	
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc 
	AND incometotal.ayear= incomeyear.ayear
LEFT OUTER JOIN fin
	ON fin.idfin = incomeyear.idfin 
LEFT OUTER JOIN upb
	ON upb.idupb=incomeyear.idupb
LEFT OUTER JOIN registry
	ON registry.idreg=income.idreg
LEFT OUTER JOIN incomelast
	ON incomelast.idinc = incomesorted.idinc
LEFT OUTER JOIN proceeds
	ON proceeds.kpro = incomelast.kpro





GO

print '[incomesortedview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'pettycashopinvoiceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW pettycashopinvoiceview
GO



CREATE     VIEW [pettycashopinvoiceview]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	idpettycash,
	pettycash,
	pettycode,
	yoperation,
	noperation,
	idaccmotive_cost,
	codemotive_cost,
	motive_cost,
	idaccmotive_debit,
	codemotive_debit,
	motive_debit,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	amount,
	invoicekind,
	adate,
	nbill,
	idsor1,
	idsor2,
	idsor3,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	PCOI.idinvkind,
	invoicekind.codeinvkind,
	PCOI.yinv,
	PCOI.ninv,
	PCO.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	PCO.yoperation,
	PCO.noperation,
	PCO.idaccmotive_cost,
	AMC.codemotive,
	AMC.title,
	PCO.idaccmotive_debit,
	AMD.codemotive,
	AMD.title,
	PCO.idfin,
	fin.codefin,
	fin.title,
	PCO.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	PCO.idreg,
	registry.title,
	PCO.idman,
	manager.title,
	PCO.doc,
	PCO.docdate,
	PCO.description,
	PCO.amount,
	invoicekind.description,
	invoice.adate,
	PCO.nbill,
	PCO.idsor1,
	PCO.idsor2,
	PCO.idsor3,
	PCOI.cu,
	PCOI.ct,
	PCOI.lu,
	PCOI.lt
FROM pettycashoperationinvoice PCOI
JOIN pettycash
	ON pettycash.idpettycash = PCOI.idpettycash
JOIN pettycashoperation PCO
	ON PCO.idpettycash = PCOI.idpettycash
	AND PCO.yoperation = PCOI.yoperation
	AND PCO.noperation = PCOI.noperation
JOIN invoice
	ON invoice.idinvkind = PCOI.idinvkind
	AND invoice.yinv = PCOI.yinv
	AND invoice.ninv = PCOI.ninv
JOIN invoicekind
	ON invoicekind.idinvkind = invoice.idinvkind
LEFT OUTER JOIN fin
	ON fin.idfin = PCO.idfin
LEFT OUTER JOIN upb
	on upb.idupb = PCO.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = PCO.idreg
LEFT OUTER JOIN manager
	ON manager.idman = PCO.idman
LEFT OUTER JOIN accmotive AMC
	ON AMC.idaccmotive = PCO.idaccmotive_cost
LEFT OUTER JOIN accmotive AMD
	ON AMD.idaccmotive = PCO.idaccmotive_debit



GO

print '[pettycashopinvoiceview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'treasurerstartview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW treasurerstartview
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:08
CREATE                                  VIEW treasurerstartview
	(
	idtreasurer,
	codetreasurer,
	treasurer,
	ayear,
	amount,
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
	treasurerstart.idtreasurer,
	treasurer.codetreasurer,
	treasurer.description,
	treasurerstart.ayear,
	treasurerstart.amount,
	treasurer.idsor01,
	treasurer.idsor02,
	treasurer.idsor03,
	treasurer.idsor04,
	treasurer.idsor05,
	treasurerstart.cu,
	treasurerstart.ct,
	treasurerstart.lu,
	treasurerstart.lt
	FROM treasurerstart (NOLOCK)
	JOIN treasurer (NOLOCK)
	ON treasurerstart.idtreasurer = treasurer.idtreasurer




GO

print 'treasurerstartview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationauthagencyview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationauthagencyview
GO

CREATE     VIEW [itinerationauthagencyview]
(
	iditineration,
	yitineration,
	nitineration,
	idauthagency,
	flagstatus,
	authagencytitle,
	authagencydescription,
	lu,
	lt
)
AS SELECT
	itinerationauthagency.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itinerationauthagency.idauthagency,
	itinerationauthagency.flagstatus,
	authagency.title,
	authagency.description,
	itinerationauthagency.lu,
	itinerationauthagency.lt
FROM itinerationauthagency
JOIN itineration
	ON itinerationauthagency.iditineration = itineration.iditineration
JOIN authagency
	ON itinerationauthagency.idauthagency = authagency.idauthagency


GO

print '[itinerationauthagencyview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'pettycashopitinerationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW pettycashopitinerationview
GO



CREATE  VIEW [pettycashopitinerationview]
(
	iditineration,
	yitineration,
	nitineration,
	movkind,
	idpettycash,
	pettycash,
	pettycode,
	yoperation,
	noperation,
	idaccmotive_cost,
	codemotive_cost,
	motive_cost,
	idaccmotive_debit,
	codemotive_debit,
	motive_debit,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	nbill,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	amount,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	adate,
	idsor1,
	idsor2,
	idsor3,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	itineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	PCOI.movkind,
	PCO.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	PCO.yoperation,
	PCO.noperation,
	PCO.idaccmotive_cost,
	AMC.codemotive,
	AMC.title,
	PCO.idaccmotive_debit,
	AMD.codemotive,
	AMD.title,
	PCO.idfin,
	fin.codefin,
	fin.title,
	PCO.idupb,
	upb.codeupb,
	upb.title,
	PCO.nbill,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	PCO.idreg,
	registry.title,
	PCO.idman,
	manager.title,
	PCO.doc,
	PCO.docdate,
	PCO.description,
	PCO.amount,
	itineration.idser,
	service.description,
	service.codeser,
	itineration.start,
	itineration.stop,
	itineration.adate,
	PCO.idsor1,
	PCO.idsor2,
	PCO.idsor3,
	PCOI.cu,
	PCOI.ct,
	PCOI.lu,
	PCOI.lt
FROM pettycashoperationitineration PCOI
JOIN pettycash
	ON pettycash.idpettycash = PCOI.idpettycash
JOIN pettycashoperation PCO
	ON PCO.idpettycash = PCOI.idpettycash
	AND PCO.yoperation = PCOI.yoperation
	AND PCO.noperation = PCOI.noperation
JOIN itineration
	ON itineration.iditineration = PCOI.iditineration
LEFT OUTER JOIN fin
	ON fin.idfin = PCO.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = PCO.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = PCO.idreg
LEFT OUTER JOIN manager
	ON manager.idman = PCO.idman
LEFT OUTER JOIN service
	ON service.idser = itineration.idser
LEFT OUTER JOIN accmotive AMC
	ON AMC.idaccmotive = PCO.idaccmotive_cost
LEFT OUTER JOIN accmotive AMD
	ON AMD.idaccmotive = PCO.idaccmotive_debit




GO

print '[pettycashopitinerationview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'admpay_incomeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW admpay_incomeview
GO


CREATE                VIEW admpay_incomeview
(
	yadmpay,
	nadmpay,
	nincome,
	nassessment,
	idreg,
	registry,
	description,
	amount,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	admpay_income.yadmpay,
	admpay_income.nadmpay,
	admpay_income.nincome,
	admpay_income.nassessment,
	admpay_income.idreg,
	registry.title, 
	admpay_income.description,
	admpay_income.amount,
	admpay_income.cu,
	admpay_income.ct,
	admpay_income.lu,
	admpay_income.lt
FROM admpay_income
LEFT OUTER JOIN registry
	ON registry.idreg = admpay_income.idreg


GO

print 'admpay_incomeview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'finview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW finview
GO



CREATE    VIEW [finview]
(
	idfin,
	ayear,
	finpart,
	codefin,
	nlevel,
	leveldescr,
	paridfin,
	idman,
	manager,
	printingorder,
	title,
	prevision,
	currentprevision,
	availableprevision,
	previousprevision,
	secondaryprev,
	currentsecondaryprev,
	availablesecondaryprev,
	previoussecondaryprev,
	currentarrears,
	previousarrears,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	expiration,
	flag,
	flagusable,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	cupcode,
	cu, 
	ct, 
	lu, 
	lt
)
AS 
SELECT fin.idfin, fin.ayear, 
   	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.codefin, 
    	fin.nlevel, finlevel.description, 
    	fin.paridfin,
    ISNULL(upb.idman,finlast.idman),
    ISNULL(manager.title,managerfin.title),
    fin.printingorder,
    fin.title,
-- Calcolo Previsione Esercizio Corrente = SOMMA delle prevesercizio corr sottostanti, sul primo livello operativo di bilancio
	ISNULL(upbtotal.currentprev,0),
-- Calcolo Previsione Attuale = SOMMA delle prevesercizio corr sottostanti, sul primo livello operativo di bilancio +  la SOMMA di totbilancio.totvarprevisione 
	ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0),
-- Calcolo Previsione Disponibile = Previsione attuale - somma totbilanciospesa.totalecompetenza (se bil.competenza) o  Previsione attuale - somma totalecompetenza-totaleresidui (se bil. Cassa)
	ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) -
    CASE
	WHEN ((fin.flag&1)=1)  THEN --Spesa
		(				
			CASE 
			WHEN (SELECT fin_kind from config where config.ayear=fin.ayear)IN (1,3) THEN
				ISNULL(upbexpensetotal.totalcompetency,0)
			ELSE
				ISNULL(upbexpensetotal.totalcompetency,0) + ISNULL(upbexpensetotal.totalarrears,0)
			END
		)
	WHEN  ((fin.flag&1)=0) THEN --Entrata
		(
			CASE 
			WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
				ISNULL(upbincometotal.totalcompetency,0)
			ELSE
				ISNULL(upbincometotal.totalcompetency,0) + ISNULL(upbincometotal.totalarrears,0)
			END
		)
   	END,
	-- Calcolo Previsione Esercizio Precedente = somma prevesercizioprec su livelli operativi sottostanti
	upbtotal.previousprev,
	-- Calcolo Previsione Secondaria Esercizio Corrente = somma prevseceserciziocorr su livelli operativi sottostanti
	upbtotal.currentsecondaryprev,
	-- Calcolo Previsione Secondaria Attuale
	ISNULL(upbtotal.currentsecondaryprev,0) + ISNULL(upbtotal.secondaryvariation,0),
	-- Calcolo Previsione Secondaria Disponibile  =  Previsione attuale - somma ( totalecompetenza+totaleresidui)
	ISNULL(upbtotal.currentsecondaryprev,0) + ISNULL(upbtotal.secondaryvariation,0) -
    	CASE
	WHEN ((fin.flag&1) = 1) THEN --Spesa
		ISNULL(upbexpensetotal.totalcompetency,0) + ISNULL(upbexpensetotal.totalarrears,0)
	WHEN ((fin.flag&1) = 0) THEN --Entrata
		ISNULL(upbincometotal.totalcompetency,0) + ISNULL(upbincometotal.totalarrears,0)
  	END,
	-- Calcolo Previsione Secondaria Esercizio Precedente
	upbtotal.previoussecondaryprev,
	-- Calcolo Ripartizione
	upbtotal.currentarrears,
	-- Calcolo Ripartizione Precedente
	upbtotal.previousarrears,
	finyear.prevision2,
	finyear.prevision3,
	finyear.prevision4,
	finyear.prevision5,
	finlast.expiration, 
	fin.flag,
   	CASE
		when (( finlevel.flag & 2)<>0) then 'S'
		else 'N'
	End,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	finlast.cupcode,
	fin.cu, 
	fin.ct, fin.lu, 
	fin.lt
	FROM fin 
	CROSS JOIN upb
	CROSS JOIN uniconfig
	(NOLOCK) INNER JOIN finlevel
		ON finlevel.ayear = fin.ayear	
		AND finlevel.nlevel = fin.nlevel 
	LEFT OUTER JOIN upbtotal (NOLOCK)
		ON fin.idfin = upbtotal.idfin 
		AND upb.idupb = upbtotal.idupb
	LEFT OUTER JOIN upbincometotal
		(NOLOCK) ON fin.idfin = upbincometotal.idfin
		AND upb.idupb = upbincometotal.idupb
		AND upbincometotal.nphase = uniconfig.incomefinphase
	LEFT OUTER JOIN	upbexpensetotal (NOLOCK)
		ON fin.idfin = upbexpensetotal.idfin
		AND upb.idupb = upbexpensetotal.idupb
		AND upbexpensetotal.nphase = uniconfig.expensefinphase
	LEFT OUTER JOIN finlast (NOLOCK)
		ON fin.idfin = finlast.idfin
	LEFT OUTER JOIN manager (NOLOCK)
		ON manager.idman = upb.idman
	LEFT OUTER JOIN manager managerfin
		ON managerfin.idman = finlast.idman
	LEFT OUTER JOIN finyear
		ON fin.idfin = finyear.idfin
		AND upb.idupb = finyear.idupb



GO

print '[finview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxview
GO





CREATE         VIEW taxview 
(
	taxcode,
	taxref,
	active,
	appliancebasis,
	description,
	fiscaltaxcode,
	flagunabatable,
	geoappliance,
	idaccmotive_cost,
	idaccmotive_debit,
	idaccmotive_pay,
	taxablecode,
	taxkind,
	maintaxcode,
	maintaxref,
	maintaxdescription,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	tax.taxcode,
	tax.taxref,
	tax.active,
	tax.appliancebasis,
	tax.description,
	tax.fiscaltaxcode,
	tax.flagunabatable,
	tax.geoappliance,
	tax.idaccmotive_cost,
	tax.idaccmotive_debit,
	tax.idaccmotive_pay,
	tax.taxablecode,
	tax.taxkind,
	tax.maintaxcode,
	ISNULL(maintax.taxref,tax.taxref),
	ISNULL(maintax.description,tax.description),
	tax.ct,
	tax.cu,
	tax.lt,
	tax.lu
FROM tax
LEFT OUTER JOIN tax maintax
ON tax.maintaxcode = maintax.taxcode

GO

print 'taxview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'pettycashopprofserviceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW pettycashopprofserviceview
GO




CREATE   VIEW [pettycashopprofserviceview]
(
	ycon,
	ncon,
	idpettycash,
	pettycash,
	pettycode,
	yoperation,
	noperation,
	idaccmotive_cost,
	codemotive_cost,
	motive_cost,
	idaccmotive_debit,
	codemotive_debit,
	motive_debit,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	amount,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	adate,
	nbill,
	idsor1,
	idsor2,
	idsor3,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	PCOPS.ycon,
	PCOPS.ncon,
	PCO.idpettycash,
	pettycash.description,
	pettycash.pettycode,
	PCO.yoperation,
	PCO.noperation,
	PCO.idaccmotive_cost,
	AMC.codemotive,
	AMC.title,
	PCO.idaccmotive_debit,
	AMD.codemotive,
	AMD.title,
	PCO.idfin,
	fin.codefin,
	fin.title,
	PCO.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	PCO.idreg,
	registry.title,
	PCO.idman,
	manager.title,
	PCO.doc,
	PCO.docdate,
	PCO.description,
	PCO.amount,
	profservice.idser,
	service.description,
	service.codeser,
	profservice.start,
	profservice.stop,
	profservice.adate,
	PCO.nbill,
	PCO.idsor1,
	PCO.idsor2,
	PCO.idsor3,
	PCOPS.cu,
	PCOPS.ct,
	PCOPS.lu,
	PCOPS.lt
FROM pettycashoperationprofservice PCOPS
JOIN pettycash
	ON pettycash.idpettycash = PCOPS.idpettycash
JOIN pettycashoperation PCO
	ON PCO.idpettycash = PCOPS.idpettycash
	AND PCO.yoperation = PCOPS.yoperation
	AND PCO.noperation = PCOPS.noperation
JOIN profservice
	ON profservice.ycon = PCOPS.ycon
	AND profservice.ncon = PCOPS.ncon
JOIN service
	ON service.idser = profservice.idser
LEFT OUTER JOIN fin
	ON fin.idfin = PCO.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = PCO.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = PCO.idreg
LEFT OUTER JOIN manager
	ON manager.idman = PCO.idman
LEFT OUTER JOIN accmotive AMC
	ON AMC.idaccmotive = PCO.idaccmotive_cost
LEFT OUTER JOIN accmotive AMD
	ON AMD.idaccmotive = PCO.idaccmotive_debit


GO

print '[pettycashopprofserviceview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'incomeestimateview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW incomeestimateview
GO




CREATE     VIEW incomeestimateview 
(
	idestimkind,
	yestim,
	nestim,
	movkind,
	idinc,
	estimkind,
	nphase,
	phase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idreg,
	registry,
	idman,
	manager,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	totdetail,
	deltavalue, 
	deltapercent, 
	limitvalue,
	limitpercent,
	incomelastflag,
	flag, 
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	incomeestimate.idestimkind,
	incomeestimate.yestim,
	incomeestimate.nestim,
	incomeestimate.movkind,
	incomeestimate.idinc,
	estimatekind.description,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	incomeyear.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	isnull((select sum(taxable_euro)
	from estimatedetailview
	where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) 
	+
	isnull((select sum(iva_euro)
	from estimatedetailview
	where idinc_iva = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0),
	-- deltaamount
	(
	(ISNULL(
		(SELECT Y.amount
		FROM incomeyear Y
		JOIN incometotal T
			ON Y.idinc = T.idinc
			AND Y.ayear = T.ayear
		WHERE (T.flag & 2) <> 0
			AND Y.idinc = incomeestimate.idinc)
	,0) +
	ISNULL(
		(SELECT SUM(V.amount)
		FROM incomevar V
		WHERE V.idinc = incomeestimate.idinc
			AND V.yvar <= incomeyear.ayear)
	,0))
	-
	(isnull((select sum(taxable_euro)
	from estimatedetailview
	where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0)  
	+
	isnull((select sum(iva_euro)
	from estimatedetailview
	where idinc_iva = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) )),
	-- deltapercentage
	case
	when  
	      (
		(ISNULL(
			(SELECT Y.amount
			FROM incomeyear Y
			JOIN incometotal T
				ON Y.idinc = T.idinc
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idinc = incomeestimate.idinc)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM incomevar V
			WHERE V.idinc = incomeestimate.idinc
				AND V.yvar <= incomeyear.ayear)
		,0)) = 0 and 
		(isnull((select sum(taxable_euro)
		from estimatedetailview
		where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) 
		+
		isnull((select sum(iva_euro)
		from estimatedetailview
		where idinc_iva = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) ) = 0
	      )
	then  0
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM incomeyear Y
			JOIN incometotal T
				ON Y.idinc = T.idinc
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idinc = incomeestimate.idinc)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM incomevar V
			WHERE V.idinc = incomeestimate.idinc
				AND V.yvar <= incomeyear.ayear)
		,0)) <> 0 and 
		(isnull((select sum(taxable_euro)
			from estimatedetailview
			where idinc_taxable = incomeestimate.idinc and 
        		( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
			( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
			),0)  
			+
			isnull((select sum(iva_euro)
			from estimatedetailview
			where idinc_iva = incomeestimate.idinc and 
        		( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
			( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
			),0) ) = 0
	      )
	then  1000
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM incomeyear Y
			JOIN incometotal T
				ON Y.idinc = T.idinc
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idinc = incomeestimate.idinc)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM incomevar V
			WHERE V.idinc = incomeestimate.idinc
				AND V.yvar <= incomeyear.ayear)
		,0)) <> 0 and 
		(isnull((select sum(taxable_euro)
		from estimatedetailview
		where idinc_taxable = incomeestimate.idinc and 
        	( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
		( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
		),0)  
		+
		isnull((select sum(iva_euro)
		from estimatedetailview
		where idinc_iva = incomeestimate.idinc and 
        	( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
		( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
		),0) ) <> 0
	      )
	then
	((
	(ISNULL(
		(SELECT Y.amount
		FROM incomeyear Y
		JOIN incometotal T
			ON Y.idinc = T.idinc
			AND Y.ayear = T.ayear
		WHERE (T.flag & 2) <> 0
			AND Y.idinc = incomeestimate.idinc)
	,0) +
	ISNULL(
		(SELECT SUM(V.amount)
		FROM incomevar V
		WHERE V.idinc = incomeestimate.idinc
			AND V.yvar <= incomeyear.ayear)
	,0))
	-
	(isnull((select sum(taxable_euro)
	from estimatedetailview
	where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) 
	+
	isnull((select sum(iva_euro)
	from estimatedetailview
	where idinc_iva= incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0) ))
	/
	(isnull((select sum(taxable_euro)
	from estimatedetailview
	where idinc_taxable = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0)  
	+
	isnull((select sum(iva_euro)
	from estimatedetailview
	where idinc_iva = incomeestimate.idinc and 
        ( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
	( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
	),0)))
	when   (
		(ISNULL(
			(SELECT Y.amount
			FROM incomeyear Y
			JOIN incometotal T
				ON Y.idinc = T.idinc
				AND Y.ayear = T.ayear
			WHERE (T.flag & 2) <> 0
				AND Y.idinc = incomeestimate.idinc)
		,0) +
		ISNULL(
			(SELECT SUM(V.amount)
			FROM incomevar V
			WHERE V.idinc = incomeestimate.idinc
				AND V.yvar <= incomeyear.ayear)
		,0)) = 0 and 
		(isnull((select sum(taxable_euro)
		from estimatedetailview
		where idinc_taxable = incomeestimate.idinc and 
        	( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
		( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
		),0)  
		+
		isnull((select sum(iva_euro)
		from estimatedetailview
		where idinc_iva = incomeestimate.idinc and 
        	( (estimatedetailview.start is null) OR ( datepart(year,estimatedetailview.start)<=incomeyear.ayear) ) and
		( (estimatedetailview.stop is null) OR ( datepart(year,estimatedetailview.stop)> incomeyear.ayear) )  		    	            
		),0) ) <> 0
	      )
	then - 1
	end,
	isnull(estimatekind.deltaamount,0),
	isnull(estimatekind.deltapercentage,0),
	incomelast.flag,
	incometotal.flag, 
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	incomeestimate.cu,
	incomeestimate.ct,
	incomeestimate.lu,
	incomeestimate.lt
	FROM incomeestimate (NOLOCK)
	JOIN income (NOLOCK)
		ON income.idinc = incomeestimate.idinc
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)
		ON incomeyear.idinc = income.idinc
	JOIN incometotal (NOLOCK)
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	JOIN estimatekind
		ON estimatekind.idestimkind = incomeestimate.idestimkind
	LEFT OUTER JOIN income parentincome (NOLOCK)
		ON income.parentidinc = parentincome.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
		ON incometotal_firstyear.idinc = income.idinc
		AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	LEFT OUTER JOIN incomelast  (NOLOCK)
		ON incomelast.idinc = income.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN fin (NOLOCK)
		ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)
		ON upb.idupb = incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)
		ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)
		ON manager.idman = income.idman





GO

print 'incomeestimateview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'pettycashopcasualcontractview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW pettycashopcasualcontractview
GO





CREATE      VIEW [pettycashopcasualcontractview]
(
	ycon,
	ncon,
	idpettycash,
	pettycode,
	pettycash,
	yoperation,
	noperation,
	idaccmotive_cost,
	codemotive_cost,
	motive_cost,
	idaccmotive_debit,
	codemotive_debit,
	motive_debit,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	amount,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	adate,
	nbill,
	idsor1,
	idsor2,
	idsor3,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	PCOCC.ycon,
	PCOCC.ncon,
	PCO.idpettycash,
	pettycash.pettycode,
	pettycash.description,
	PCO.yoperation,
	PCO.noperation,
	PCO.idaccmotive_cost,
	AMC.codemotive,
	AMC.title,
	PCO.idaccmotive_debit,
	AMD.codemotive,
	AMD.title,
	PCO.idfin,
	fin.codefin,
	fin.title,
	PCO.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	PCO.idreg,
	registry.title,
	PCO.idman,
	manager.title,
	PCO.doc,
	PCO.docdate,
	PCO.description,
	PCO.amount,
	casualcontract.idser,
	service.description,
	service.codeser,
	casualcontract.start,
	casualcontract.stop,
	casualcontract.adate,
	PCO.nbill,
	PCO.idsor1,
	PCO.idsor2,
	PCO.idsor3,
	PCOCC.cu,
	PCOCC.ct,
	PCOCC.lu,
	PCOCC.lt
FROM pettycashoperationcasualcontract PCOCC
JOIN pettycash 
	ON pettycash.idpettycash = PCOCC.idpettycash
JOIN pettycashoperation PCO
	ON PCO.idpettycash = PCOCC.idpettycash
	AND PCO.yoperation = PCOCC.yoperation
	AND PCO.noperation = PCOCC.noperation
JOIN casualcontract
	ON casualcontract.ycon = PCOCC.ycon
	AND casualcontract.ncon = PCOCC.ncon
JOIN service
	ON service.idser = casualcontract.idser
LEFT OUTER JOIN fin
	ON fin.idfin = PCO.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = PCO.idupb
LEFT OUTER JOIN registry
	ON registry.idreg = PCO.idreg
LEFT OUTER JOIN manager
	ON manager.idman = PCO.idman
LEFT OUTER JOIN accmotive AMC
	ON AMC.idaccmotive = PCO.idaccmotive_cost
LEFT OUTER JOIN accmotive AMD
	ON AMD.idaccmotive = PCO.idaccmotive_debit



GO

print '[pettycashopcasualcontractview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'underwritingyearview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW underwritingyearview
GO


CREATE    VIEW [underwritingyearview] 
(
	idunderwriting,
	underwriting,
	idunderwriter,
	underwriter,
	ayear,
	doc,
	docdate,
	prevision,-- è una previsione puramente indicativa, è extra-contabile
	initialprevision,
	currentprevision,
	initialsecondaryprev,
	currentsecondaryprev,
	incomeprevavailable,
	expenseprevavailable,
	appropriation,
	assessment,
	toassess,
	payment,
	proceeds,
	active,
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
	underwriting.title,
	underwriting.idunderwriter,
	underwriter.description,
	underwritingyear.ayear,
	underwriting.doc,
	underwriting.docdate,
	-- prevision
	ISNULL(underwritingyear.prevision,0),
	-- initialprevision							
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.currentprev)			
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) = 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)				
	,0),
	-- currentprevision
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.currentprev)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.previsionvariation)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0),
	-- initialsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbunderwritingtotal.currentsecondaryprev)
				FROM    upbunderwritingtotal
				JOIN    fin
					ON fin.idfin = upbunderwritingtotal.idfin
				WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
				AND     ( (fin.flag & 1) =0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = underwritingyear.ayear
				GROUP BY upbunderwritingtotal.idunderwriting)
			,0)
		ELSE NULL
	END,
	-- currentsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbunderwritingtotal.currentsecondaryprev)
				FROM    upbunderwritingtotal
				JOIN    fin
					ON fin.idfin = upbunderwritingtotal.idfin
				WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
				AND     ( (fin.flag & 1) =0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = underwritingyear.ayear
				GROUP BY upbunderwritingtotal.idunderwriting)
			,0)
			+ 
			ISNULL(
				(SELECT SUM(upbunderwritingtotal.secondaryvariation)
				FROM    upbunderwritingtotal
				JOIN    fin
					ON fin.idfin = upbunderwritingtotal.idfin
				WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
				AND     ( (fin.flag & 1) =0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = underwritingyear.ayear
				GROUP BY upbunderwritingtotal.idunderwriting)
			,0)
		ELSE NULL
	END,
	-- incomeprevavailable
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.currentprev)			
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.previsionvariation)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    underwritingincometotal
		JOIN    fin
			ON fin.idfin = underwritingincometotal.idfin
		JOIN 	uniconfig 
			ON underwritingincometotal.nphase = uniconfig.incomefinphase
		WHERE   underwritingincometotal.idunderwriting = underwriting.idunderwriting
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY underwritingincometotal.idunderwriting)
	,0),
	--expenseprevavailable
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.currentprev)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) = 1)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbunderwritingtotal.previsionvariation)
		FROM    upbunderwritingtotal
		JOIN    fin
			ON fin.idfin = upbunderwritingtotal.idfin
		WHERE   upbunderwritingtotal.idunderwriting = underwriting.idunderwriting
		AND     ( (fin.flag & 1) = 1)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY upbunderwritingtotal.idunderwriting)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM underwritingexpensetotal
		JOIN fin
			ON fin.idfin = underwritingexpensetotal.idfin
		JOIN uniconfig 
			ON underwritingexpensetotal.nphase = uniconfig.expensefinphase
		WHERE underwritingexpensetotal.idunderwriting = underwriting.idunderwriting
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = underwritingyear.ayear
		GROUP BY underwritingexpensetotal.idunderwriting)
	,0),
	-- appropriation
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM underwritingexpensetotal
		JOIN fin
			ON fin.idfin = underwritingexpensetotal.idfin
		JOIN uniconfig 
			ON underwritingexpensetotal.nphase = uniconfig.expensefinphase
		WHERE underwritingexpensetotal.idunderwriting = underwriting.idunderwriting
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = underwritingyear.ayear
		GROUP BY underwritingexpensetotal.idunderwriting)
	,0),
	-- assessment
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    underwritingincometotal
		JOIN    fin
			ON fin.idfin = underwritingincometotal.idfin
		JOIN 	uniconfig 
			ON underwritingincometotal.nphase = uniconfig.incomefinphase
		WHERE   underwritingincometotal.idunderwriting = underwriting.idunderwriting
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY underwritingincometotal.idunderwriting)
	,0),
	-- toassess, cioè da accertare. = prevision - assesment
	ISNULL(underwritingyear.prevision,0)
		- ISNULL(
		(SELECT
			ISNULL(SUM(underwritingincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(underwritingincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    underwritingincometotal
		JOIN    fin
			ON fin.idfin = underwritingincometotal.idfin
		JOIN 	uniconfig 
			ON underwritingincometotal.nphase = uniconfig.incomefinphase
		WHERE   underwritingincometotal.idunderwriting = underwriting.idunderwriting
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = underwritingyear.ayear
		GROUP BY underwritingincometotal.idunderwriting)
	,0),
	-- payment
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingexpensetotal.totalcompetency),0)  +
			ISNULL(SUM(underwritingexpensetotal.totalarrears),0)
		FROM underwritingexpensetotal
		JOIN fin
			ON fin.idfin = underwritingexpensetotal.idfin
		WHERE underwritingexpensetotal.idunderwriting = underwriting.idunderwriting
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = underwritingyear.ayear
		AND underwritingexpensetotal.nphase = (SELECT MAX(nphase) FROM expensephase)
		GROUP BY underwritingexpensetotal.idunderwriting)
	,0),
	-- proceeds
	ISNULL(
		(SELECT
			ISNULL(SUM(underwritingincometotal.totalcompetency),0) + 
			ISNULL(SUM(underwritingincometotal.totalarrears),0)
		FROM    underwritingincometotal
		JOIN    fin
			ON fin.idfin = underwritingincometotal.idfin
		WHERE underwritingincometotal.idunderwriting = underwriting.idunderwriting
		AND fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND fin.ayear = underwritingyear.ayear
		AND underwritingincometotal.nphase = (SELECT MAX(nphase) FROM incomephase)
		GROUP BY underwritingincometotal.idunderwriting)
	,0),
	underwriting.active,
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
JOIN underwritingyear
	ON underwriting.idunderwriting = underwritingyear.idunderwriting
JOIN config
	ON config.ayear = underwritingyear.ayear
LEFT OUTER JOIN underwriter
	ON underwriting.idunderwriter = underwriter.idunderwriter



GO

print '[underwritingyearview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'incomeinvoiceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW incomeinvoiceview
GO


-- select * from incomeinvoiceview
CREATE    VIEW incomeinvoiceview 
	(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	movkind,
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idreg,
	registry,
	idman,
	manager,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	unpartitioned,
	incomelastflag,
	flag, 
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
	)
	AS SELECT
	incomeinvoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	incomeinvoice.yinv,
	incomeinvoice.ninv,
	incomeinvoice.movkind,
	incomeinvoice.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	--income.ycreation,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	upb.idupb,	
	upb.codeupb,	
	upb.title,	
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount, --income.amount,
	incomeyear.amount,--incometotal.amount,
	incometotal.curramount,
	incometotal.available,
	ISNULL(incometotal.curramount,0) - ISNULL(incometotal.partitioned,0),
	incomelast.flag, --fulfilled
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	income.idpayment,
	income.expiration,
	income.adate,
	incomeinvoice.cu,
	incomeinvoice.ct,
	incomeinvoice.lu,
	incomeinvoice.lt
	FROM incomeinvoice (NOLOCK)
	JOIN invoicekind (NOLOCK)
		ON invoicekind.idinvkind = incomeinvoice.idinvkind
	JOIN income (NOLOCK)
		ON income.idinc = incomeinvoice.idinc
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)
		ON incomeyear.idinc = income.idinc
	JOIN incometotal (NOLOCK)
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
		ON incometotal_firstyear.idinc = income.idinc
		AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	LEFT OUTER JOIN income parentincome (NOLOCK)
		ON income.parentidinc = parentincome.idinc
	LEFT OUTER JOIN incomelast  (NOLOCK)
		ON incomelast.idinc = income.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN fin (NOLOCK)
		ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)
		ON upb.idupb=incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)
		ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)
		ON manager.idman = income.idman


GO

print 'incomeinvoiceview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'underwritingpaymentview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW underwritingpaymentview
GO



CREATE      VIEW [underwritingpaymentview]
(
	idexp,
	nphase,
	expensephase,
	ymov,
	nmov,
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	adate,
	idunderwriting,
	codeunderwriting,
	underwriting,
	amount,
	idfin,
	codefin,
	fin,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expense.doc,
	expense.docdate,
	expense.description,
	expense.adate,
	underwriting.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	underwritingpayment.amount,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.idupb,
	upb.codeupb,
	underwritingpayment.cu,
	underwritingpayment.ct,
	underwritingpayment.lu,
	underwritingpayment.lt
FROM underwritingpayment
JOIN expense
	ON underwritingpayment.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp	
JOIN underwriting
	ON underwritingpayment.idunderwriting = underwriting.idunderwriting
JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb


GO

print '[underwritingpaymentview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_agencyview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_agencyview
GO

CREATE         VIEW [csa_agencyview]
(
	idcsa_agency,
	ente,
	description,
	idreg,
	registry,
	isinternal,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	A.idcsa_agency,
	A.ente,
	A.description,
	A.idreg,
	R.title,
	A.isinternal,
	A.cu,
	A.ct,
	A.lu,
	A.lt
FROM csa_agency A
LEFT OUTER JOIN registry R
ON A.idreg = R.idreg


GO

print '[csa_agencyview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'creditpartview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW creditpartview
GO



CREATE                                     VIEW creditpartview 
	(
	idinc,
	ncreditpart,
	ycreditpart,
	nphase,
	phase,
	ymov,
	nmov,
	idunderwriting,
	underwriting,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	description,
	amount,
	financeincome,
	adate,
	cu,
	ct,
	lu,
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
	)
	AS SELECT
	creditpart.idinc,
	creditpart.ncreditpart,
	creditpart.ycreditpart,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	income.idunderwriting,
	underwriting.title,
	creditpart.idfin,
	fin.codefin,
	fin.title,
	creditpart.idupb,
	upb.codeupb,
	upb.title,
	creditpart.description,
	creditpart.amount,
	b2.codefin,
	creditpart.adate,
	creditpart.cu,
	creditpart.ct,
	creditpart.lu,
	creditpart.lt,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05
	FROM creditpart (NOLOCK)
	JOIN income (NOLOCK)
	ON income.idinc = creditpart.idinc
	LEFT OUTER JOIN incomeyear (nolock)
	ON income.idinc = incomeyear.idinc
	AND incomeyear.ayear = creditpart.ycreditpart
	JOIN incomephase (NOLOCK)
	ON incomephase.nphase = income.nphase
	JOIN fin (NOLOCK)
	ON fin.idfin = creditpart.idfin
	JOIN upb (NOLOCK)
	ON upb.idupb = creditpart.idupb
	LEFT OUTER JOIN fin b2 (NOLOCK)
	ON incomeyear.idfin = b2.idfin
	LEFT OUTER JOIN underwriting
		ON underwriting.idunderwriting = income.idunderwriting
		
	





GO

print 'creditpartview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'banktransactionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW banktransactionview
GO


CREATE               VIEW banktransactionview 
(
	yban,
	nban,
	kind,
	bankreference,
	transactiondate,
	valuedate,
	amount,
	kpay,
	ypay,
	npay,
	kpro,
	ypro,
	npro,
	income,
	expense,
	idexp,
	yexp,
	nexp,
	idinc,
	yinc,
	ninc,
	idpay,
	idpro,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	banktransaction.yban,
	banktransaction.nban,
	banktransaction.kind,
	banktransaction.bankreference,
	banktransaction.transactiondate,
	banktransaction.valuedate,
	banktransaction.amount,
	banktransaction.kpay,
	payment.ypay,
	payment.npay,
	banktransaction.kpro,
	proceeds.ypro,
	proceeds.npro,
	CASE
		WHEN banktransaction.kind = 'C'
		THEN banktransaction.amount
		ELSE NULL
	END,
	CASE
		WHEN banktransaction.kind = 'D'
		THEN banktransaction.amount
		ELSE NULL		
	END,
	banktransaction.idexp,
	expense.ymov,
	expense.nmov,
	banktransaction.idinc,
	income.ymov,
	income.nmov,
	banktransaction.idpay,
	banktransaction.idpro,
	banktransaction.cu,
	banktransaction.ct,
	banktransaction.lu,
	banktransaction.lt
FROM banktransaction
LEFT OUTER JOIN payment
	ON payment.kpay = banktransaction.kpay
LEFT OUTER JOIN proceeds
	ON proceeds.kpro = banktransaction.kpro
LEFT OUTER JOIN expense
	ON expense.idexp = banktransaction.idexp
LEFT OUTER JOIN income
	ON income.idinc = banktransaction.idinc

GO

print 'banktransactionview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_agencypaymethodview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_agencypaymethodview
GO


CREATE         VIEW [csa_agencypaymethodview]
(
	idcsa_agency,
	ente,
	agency,
	idcsa_agencypaymethod,
	idregistrypaymethod,
	vocecsa,
	idreg,
	registry,
	regmodcode,
	paymentdescr,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	A.idcsa_agency,
	A.ente,
	A.description,
	AP.idcsa_agencypaymethod,
	AP.idregistrypaymethod,
	AP.vocecsa,
	A.idreg,
	R.title,
	RP.regmodcode,
	RP.paymentdescr,
	AP.cu,
	AP.ct,
	AP.lu,
	AP.lt
FROM csa_agencypaymethod AP
LEFT OUTER JOIN csa_agency A
ON A.idcsa_agency = AP.idcsa_agency
LEFT OUTER JOIN registry R
ON A.idreg = R.idreg
LEFT OUTER JOIN registrypaymethod RP
ON RP.idreg = A.idreg
AND RP.idregistrypaymethod = AP.idregistrypaymethod



GO

print '[csa_agencypaymethodview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceedspartview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceedspartview
GO

--clear_table_info'proceedspartview'
--select * from proceedspartview
CREATE                                 VIEW proceedspartview 
	(
	idinc,
	nproceedspart,
	yproceedspart,
	nphase,
	phase,
	ymov,
	nmov,
	idunderwriting,
	underwriting,
	idfin,
	codefin,
	finance,
	
	idupb,
	codeupb,
	upb,
	idtreasurer,
	treasurer,
	
	idupbincome,
	codeupbincome,
	upbincome,	
	idtreasurerincome,
	treasurerincome,
	
	description,
	amount,
	financeincome,
	adate,
	--	> Importo destinato, valorizzato se Te<>Ts
	allocatedamount,
	--	> Importo da Girofondare: importo che non è stato ancora girofondato;
	moneytotransfer,
	--	> Importo Girofondato: importo per cui è stato fatto il girofondo ala cassiere di destinazione;
	moneytransfered,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	cu,
	ct,
	lu,
	lt,
	idtreasurerproceeds,
	treasurerproceeds
	)
	AS SELECT
	proceedspart.idinc,
	proceedspart.nproceedspart,
	proceedspart.yproceedspart,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	income.idunderwriting,
	underwriting.title,
	proceedspart.idfin,
	fin.codefin,
	fin.title,
	
	proceedspart.idupb,
	UU.codeupb,
	UU.title,
	UU.idtreasurer,
	TU.description,
	incomeyear.idupb,
	UE.codeupb,
	UE.title,
	UE.idtreasurer,
	TE.description,
	
	proceedspart.description,
	proceedspart.amount,
	b2.codefin,
	proceedspart.adate,
	--	> allocatedamount = Importo destinato, valorizzato se Te<>Ts
	case 
		when isnull(TP.idtreasurer,0) <>isnull(UU.idtreasurer,0) then proceedspart.amount
		else null
	end,	
	-- > moneytotransfer = Importo da Girofondare: importo che non è stato ancora girofondato;
		case 
		when  ( isnull(TP.idtreasurer,0) <>isnull(UU.idtreasurer,0)) 
				then (proceedspart.amount - 	ISNULL(	(SELECT SUM(moneytransfer.amount) FROM moneytransfer
												WHERE moneytransfer.nproceedspart = proceedspart.nproceedspart
												and moneytransfer.yproceedspart = proceedspart.yproceedspart)
												,0))
		else null
	end,
	--	> moneytransfered = Importo Girofondato: importo per cui è stato fatto il girofondo la cassiere di destinazione;
		case 
		when  ( isnull(TP.idtreasurer,0) <>isnull(UU.idtreasurer,0)) 
				then ( SELECT SUM(moneytransfer.amount) FROM moneytransfer
						WHERE moneytransfer.nproceedspart = proceedspart.nproceedspart
						and moneytransfer.yproceedspart = proceedspart.yproceedspart)
		else null
	end,
	UU.idsor01,
	UU.idsor02,
	UU.idsor03,
	UU.idsor04,
	UU.idsor05,
	proceedspart.cu,
	proceedspart.ct,
	proceedspart.lu,
	proceedspart.lt,
	TP.idtreasurer,
	TP.description
	FROM proceedspart (NOLOCK)
	JOIN income (NOLOCK)
		ON income.idinc = proceedspart.idinc
	JOIN incomelast (NOLOCK)
		ON incomelast.idinc = proceedspart.idinc	
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	JOIN fin (NOLOCK)
		ON fin.idfin = proceedspart.idfin
	JOIN upb UU (NOLOCK)
		ON UU.idupb = proceedspart.idupb
	LEFT OUTER JOIN treasurer T1
		ON UU.idtreasurer = T1.idtreasurer	
	LEFT OUTER JOIN incomeyear
		ON income.idinc = incomeyear.idinc
		AND incomeyear.ayear = proceedspart.yproceedspart
	LEFT OUTER JOIN fin b2
		ON b2.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb UE	
		ON UE.idupb = incomeyear.idupb
	LEFT OUTER JOIN treasurer TE 
		ON TE.idtreasurer = UE.idtreasurer
	LEFT OUTER JOIN treasurer TU
		ON TU.idtreasurer = UU.idtreasurer	
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN treasurer TP
		ON TP.idtreasurer = proceeds.idtreasurer	
	LEFT OUTER JOIN underwriting
		ON underwriting.idunderwriting = income.idunderwriting 	



GO

print 'proceedspartview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'billview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW billview
GO


CREATE   VIEW [billview]
(
	ybill,
	nbill,
	billkind,
	active,
	adate,
	registry,
	motive,
	total, 
	reduction,
	covered,
	regularizationnote,
	idtreasurer,
	treasurer,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	bill.ybill,
	bill.nbill,
	bill.billkind,
	bill.active,
	bill.adate,
	bill.registry,
	bill.motive,
	bill.total, 
	bill.reduction,
	CASE billkind
		WHEN 'D' THEN
			isnull((SELECT SUM(expensetotal.curramount)
			FROM expense
			JOIN expenselast
				ON expense.idexp = expenselast.idexp 
			LEFT OUTER JOIN expensetotal (NOLOCK)
  				ON expensetotal.idexp = expense.idexp
			WHERE expense.ymov = bill.ybill
				AND expenselast.nbill = bill.nbill),0)
				+
			isnull((SELECT SUM(operation.amount)
			FROM pettycashoperation operation
			WHERE operation.yoperation = bill.ybill
				AND operation.nbill = bill.nbill
				AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
					WHERE restoreop.yoperation = operation.yrestore
					AND restoreop.noperation = operation.nrestore
					AND restoreop.idpettycash = operation.idpettycash)),0)
		WHEN 'C' THEN
			isnull((SELECT SUM(incometotal.curramount)
			FROM income
			JOIN incomelast
				ON income.idinc = incomelast.idinc
			LEFT OUTER JOIN incometotal (NOLOCK)
  				ON incometotal.idinc = income.idinc
			WHERE income.ymov = bill.ybill
			AND incomelast.nbill = bill.nbill),0)
	END,
	bill.regularizationnote,
	bill.idtreasurer,
	treasurer.description,
	treasurer.idsor01,treasurer.idsor02,treasurer.idsor03,treasurer.idsor04,treasurer.idsor05,
	bill.cu,
	bill.ct,
	bill.lu,
	bill.lt
FROM bill
LEFT OUTER JOIN treasurer
	ON bill.idtreasurer = treasurer.idtreasurer

GO

print '[billview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'casualcontracttaxbracketview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW casualcontracttaxbracketview
GO


CREATE               VIEW [casualcontracttaxbracketview]
(
	taxcode,
	description,
	taxref,
	ycon,
	ncon,
	nbracket,
	adminrate,
	employrate,
	taxablegross,
	deduction,
	totaltaxablenet,
	taxablenet,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	totaladmintax,
	totalemploytax,
	admintax,
	employtax,
	employtaxgross,
	taxkind,
	lu,
	lt
)
AS SELECT
	CCT.taxcode,
	TR.description,
	TR.taxref,
	CCT.ycon,
	CCT.ncon,
	CCTB.nbracket,
	CCTB.adminrate,
	CCTB.employrate,
	CCT.taxablegross,
	CCT.deduction,
	CCT.taxablenet,
	CCTB.taxable,
	CCT.admindenominator,
	CCT.employdenominator,
	CCT.taxabledenominator,
	CCT.adminnumerator,
	CCT.employnumerator,
	CCT.taxablenumerator,
	CCT.admintax,
	CCT.employtax,
	CCTB.admintax,
	CCTB.employtax,
	CCT.employtaxgross,
	TR.taxkind,
	CCTB.lu,
	CCTB.lt
FROM casualcontracttaxbracket CCTB
JOIN casualcontracttax CCT
	ON CCTB.taxcode = CCT.taxcode
	AND CCTB.ycon = CCT.ycon
	AND CCTB.ncon = CCT.ncon
JOIN tax TR
	ON CCT.taxcode = TR.taxcode



GO

print '[casualcontracttaxbracketview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoiceavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoiceavailable
GO

CREATE      VIEW [invoiceavailable]
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	idreg,
	registry,
	registryreference,
	description,
	paymentexpiring,
	idexpirationkind,
	doc,
	docdate,
	ycon,
	ncon,
	adate,
	packinglistnum,
	packinglistdate,
	officiallyprinted,
	cu, 
	ct, 
	lu, 
	lt,
	taxabletotal,
	ivatotal,
	linkedamount,
	residual,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoice.yinv,
	invoice.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoice.idreg,
	registry.title,
	invoice.registryreference,
	invoice.description,
	invoice.paymentexpiring,
	invoice.idexpirationkind,
	invoice.doc,
	invoice.docdate,
	profservice.ycon,
	profservice.ncon,
	invoice.adate,
	invoice.packinglistnum,
	invoice.packinglistdate,
	invoice.officiallyprinted,
	invoice.cu, 
	invoice.ct, 
	invoice.lu, 
	invoice.lt,
	totinvoiceview.taxabletotal,
	totinvoiceview.ivatotal,
	CONVERT(decimal(23,5),
	CASE 
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)=0) THEN  
		ISNULL(
			(SELECT ISNULL(SUM(incomeyear_starting.amount), 0.0) 
			FROM incomeinvoice i
			JOIN income e
			ON e.idinc = i.idinc
			LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  			ON incometotal_firstyear.idinc = e.idinc
  			AND ((incometotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
			ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  			AND incomeyear_starting.ayear = incometotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)<>0) THEN
		ISNULL(
			(SELECT ABS(SUM(e.amount)) 
			FROM incomevar e 
			WHERE e.idinvkind = invoice.idinvkind
			AND e.yinv = invoice.yinv
			AND e.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0) THEN 
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  			ON expensetotal_firstyear.idexp = s.idexp
  			AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND s.idexp = i.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationinvoice mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.idinvkind = invoice.idinvkind
			AND mov.yinv = invoice.yinv
			AND mov.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)<>0) THEN 
		ISNULL(
			(SELECT ABS(SUM(s.amount)) 
			FROM expensevar s
			WHERE s.idinvkind = invoice.idinvkind
			AND s.yinv = invoice.yinv
			AND s.ninv = invoice.ninv)
		,0)
	END),
	--residuo = totaleimponibile + totaleiva - totale movimenti
	ISNULL(totinvoiceview.taxabletotal, 0.0) +
	ISNULL(totinvoiceview.ivatotal, 0.0) - 
	
	CONVERT(decimal(19,5),
	CASE 
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)=0) THEN 
		ISNULL(
			(SELECT SUM(incomeyear_starting.amount)
			FROM incomeinvoice i
			JOIN income e
			ON e.idinc = i.idinc
			LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  			ON incometotal_firstyear.idinc = e.idinc
  			AND ((incometotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
			ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  			AND incomeyear_starting.ayear = incometotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)<>0) THEN 
		ISNULL(
			(SELECT ABS(SUM(e.amount)) 
			FROM incomevar e
			WHERE e.idinvkind = invoice.idinvkind
			AND e.yinv = invoice.yinv
			AND e.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0) THEN
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  			ON expensetotal_firstyear.idexp = s.idexp
  			AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND s.idexp = i.idexp)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationinvoice mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.idinvkind = invoice.idinvkind
			AND mov.yinv = invoice.yinv
			AND mov.ninv = invoice.ninv)
		,0)
	WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)<>0) THEN 
		ISNULL(
			(SELECT ABS(SUM(s.amount)) 
			FROM expensevar s (NOLOCK)
			WHERE s.idinvkind = invoice.idinvkind
			AND s.yinv = invoice.yinv
			AND s.ninv = invoice.ninv)
		,0)
	END),
	invoice.active,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05
FROM invoice (NOLOCK)
JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
LEFT OUTER JOIN totinvoiceview (NOLOCK)
	ON totinvoiceview.idinvkind = invoice.idinvkind
	AND totinvoiceview.yinv = invoice.yinv
	AND totinvoiceview.ninv = invoice.ninv
LEFT OUTER JOIN profservice (NOLOCK)
ON profservice.idinvkind=invoice.idinvkind and profservice.yinv=invoice.yinv and profservice.ninv=invoice.ninv




GO

print '[invoiceavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'csa_importverview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW csa_importverview
GO




CREATE    VIEW [csa_importverview]
(
	ayear,
	competency,
	idver,
	idcsa_import,
	yimport,
	nimport,
	idcsa_contract,
	ycontract,
	ncontract,
	idcsa_contractkind,
	csa_contractkindcode,
	csa_contractkind,
	ruolocsa,
	capitolocsa,
	competenza,
	matricola,
	ente,
	vocecsa,
	importo,
	idreg,
	registry,
	idcsa_agency,
	agency, --description
	idreg_agency,
	registry_agency,
	idcsa_agencypaymethod,
	idregistrypaymethod,
	idcsa_contracttax,
	idcsa_contractkinddata,
	idcsa_incomesetup,
	idacc_debit,
	codeacc_debit,
	account_debit,
	idacc_expense,
	codeacc_expense,
	account_expense,
	idacc_internalcredit,
	codeacc_internalcredit,
	account_internalcredit,
	idacc_cost,
	codeacc_cost,
	account_cost,
	idacc_revenue,
	codeacc_revenue,
	account_revenue,
	codeacc_agency_credit,
	account_agency_credit,
	idfin_income,
	codefin_income,
	fin_income,
	idfin_expense,
	codefin_expense,
	fin_expense,
	idfin_incomeclawback,
	codefin_incomeclawback,
	fin_incomeclawback,
	idfin_cost,
	codefin_cost,
	fin_cost,

	idsor_siope_income,
	sortcode_income,
	sorting_income,
	idsor_siope_expense,
	sortcode_expense,
	sorting_expense,
	idsor_siope_incomeclawback,
	sortcode_incomeclawback,
	sorting_incomeclawback,
	idsor_siope_cost,
	sortcode_cost,
	sorting_cost,

	idupb,
	codeupb,
	upb,
	idexp_cost,
	nphase_cost,
	phase_cost,
	ymov_cost,
	nmov_cost,
	flagcr,
	flagclawback,
	flagdirectcsaclawback,
	idunderwriting,
	underwriting,
	lu,
	lt
)
AS SELECT 
	IV.ayear,
	IV.competency,
	IV.idver,
	IV.idcsa_import,
	I.yimport,
	I.nimport,
	IV.idcsa_contract,
	C.ycontract,
	C.ncontract,
	IV.idcsa_contractkind,
	CK.contractkindcode,
	CK.description,
	IV.ruolocsa,
	IV.capitolocsa,
	IV.competenza,
	IV.matricola,
	IV.ente,
	IV.vocecsa,
	IV.importo,
	IV.idreg,
	registry.title,
	IV.idcsa_agency,
	A.description, 
	IV.idreg_agency,
	registry_agency.title,
	IV.idcsa_agencypaymethod,
	AP.idregistrypaymethod,
	IV.idcsa_contracttax,
	IV.idcsa_contractkinddata,
	IV.idcsa_incomesetup,
	IV.idacc_debit,
	account_debit.codeacc,
	account_debit.title,
	IV.idacc_expense,
	account_expense.codeacc,
	account_expense.title,
	IV.idacc_internalcredit,
	account_internalcredit.codeacc,
	account_internalcredit.title,
	IV.idacc_cost,
	account_cost.codeacc,
	account_cost.title,
	IV.idacc_revenue,
	account_revenue.codeacc,
	account_revenue.title,
	account_agency_credit.codeacc,
	account_agency_credit.title,
	IV.idfin_income,
	fin_income.codefin,
	fin_income.title,
	IV.idfin_expense,
	fin_expense.codefin,
	fin_expense.title,
	IV.idfin_incomeclawback,
	fin_incomeclawback.codefin,
	fin_incomeclawback.title,
	IV.idfin_cost,
	fin_cost.codefin,
	fin_cost.title,

	IV.idsor_siope_income,
	sorting_income.sortcode,
	sorting_income.description,
	IV.idsor_siope_expense,
	sorting_expense.sortcode,
	sorting_expense.description,
	IV.idsor_siope_incomeclawback,
	sorting_incomeclawback.sortcode,
	sorting_incomeclawback.description,
	IV.idsor_siope_cost,
	sorting_cost.sortcode,
	sorting_cost.description,

	upb.idupb,
	upb.codeupb,
	upb.title,
	IV.idexp_cost,
	expensephase.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	IV.flagcr,
	IV.flagclawback,
	IV.flagdirectcsaclawback,
	IV.idunderwriting,
	underwriting.title,
	IV.lu,
	IV.lt
FROM csa_importver IV
JOIN csa_import I
	ON I.idcsa_import = IV.idcsa_import
LEFT OUTER JOIN csa_contractkind CK
	ON IV.idcsa_contractkind = CK.idcsa_contractkind
LEFT OUTER JOIN csa_contract C
	ON C.idcsa_contract = IV.idcsa_contract
	AND C.idcsa_contractkind = CK.idcsa_contractkind
	AND C.ayear = IV.ayear
LEFT OUTER JOIN csa_contractkindyear CKY
	ON C.idcsa_contractkind = CKY.idcsa_contractkind
	AND CKY.ayear = C.ayear
LEFT OUTER JOIN csa_agency A
	ON A.idcsa_agency = IV.idcsa_agency
LEFT OUTER JOIN csa_agencypaymethod AP
	ON AP.idcsa_agency = A.idcsa_agency
	AND AP.idcsa_agencypaymethod = IV.idcsa_agencypaymethod
LEFT OUTER JOIN registry registry_agency
	ON IV.idreg_agency = registry_agency.idreg
LEFT OUTER JOIN fin fin_income
	ON fin_income.idfin=IV.idfin_income
LEFT OUTER JOIN fin fin_expense
	ON fin_expense.idfin=IV.idfin_expense
LEFT OUTER JOIN fin fin_incomeclawback
	ON fin_incomeclawback.idfin=IV.idfin_incomeclawback
LEFT OUTER JOIN fin fin_cost
	ON fin_cost.idfin=IV.idfin_cost

LEFT OUTER JOIN sorting sorting_income
	ON sorting_income.idsor = IV.idsor_siope_income
LEFT OUTER JOIN sorting sorting_expense
	ON sorting_expense.idsor = IV.idsor_siope_expense
LEFT OUTER JOIN sorting sorting_incomeclawback
	ON sorting_incomeclawback.idsor = IV.idsor_siope_incomeclawback
LEFT OUTER JOIN sorting sorting_cost
	ON sorting_cost.idsor = IV.idsor_siope_cost

LEFT OUTER JOIN upb
	ON upb.idupb = IV.idupb
LEFT OUTER JOIN account account_debit
	ON account_debit.idacc=IV.idacc_debit
LEFT OUTER JOIN account account_expense
	ON account_expense.idacc=IV.idacc_expense
LEFT OUTER JOIN account account_internalcredit
	ON account_internalcredit.idacc=IV.idacc_internalcredit
LEFT OUTER JOIN account account_cost
	ON account_cost.idacc=IV.idacc_cost  
LEFT OUTER JOIN account account_revenue
	ON account_revenue.idacc=IV.idacc_revenue
LEFT OUTER JOIN account account_agency_credit
	ON account_agency_credit.idacc=IV.idacc_agency_credit
LEFT OUTER JOIN registry
	ON IV.idreg = registry.idreg
LEFT OUTER JOIN expense
	ON IV.idexp_cost = expense.idexp
LEFT OUTER JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN expenseyear
	ON expenseyear.idexp = expense.idexp
	AND expenseyear.ayear= IV.ayear
LEFT OUTER JOIN expensetotal
	ON  expensetotal.idexp = expense.idexp
	AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN underwriting
	ON IV.idunderwriting = underwriting.idunderwriting






GO

print '[csa_importverview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'casualcontracttaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW casualcontracttaxview
GO



CREATE              VIEW [casualcontracttaxview]
(
	taxcode,
	description,
	taxref,
	ycon,
	ncon,
	adminrate,
	employrate,
	taxablegross,
	taxablenet,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	admintax,
	employtax,
	employtaxgross,
	taxkind
)
AS SELECT
	COPR.taxcode,
	TR.description,
	TR.taxref,
	COPR.ycon,
	COPR.ncon,
	COPR.adminrate,
	COPR.employrate,
	COPR.taxablegross,
	COPR.taxablenet,
	COPR.admindenominator,
	COPR.employdenominator,
	COPR.taxabledenominator,
	COPR.adminnumerator,
	COPR.employnumerator,
	COPR.taxablenumerator,
	COPR.admintax,
	COPR.employtax,
	COPR.employtaxgross,
	TR.taxkind
FROM casualcontracttax COPR
JOIN tax TR
	ON COPR.taxcode = TR.taxcode




GO

print '[casualcontracttaxview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'estimateresidual') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW estimateresidual
GO



--clear_table_info'estimateresidual'
CREATE     VIEW [estimateresidual]
	(
	idestimkind,	
	yestim,
	nestim,
	estimkind,
	description,
	idreg,
	idupb,
	registry,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkedestim,
	active,
	upb,
	flagintracom,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
	)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatekind.description,
	estimate.description,
	isnull(estimate.idreg,estimatedetail.idreg),
	estimatedetail.idupb,
	CASE
	WHEN estimate.idreg is not null THEN (select title from
					registry 
					where idreg= estimate.idreg)
	WHEN estimatedetail.idreg is not null THEN (select title from
					registry 
					where idreg= estimatedetail.idreg)
	ELSE null
	END,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
	   	     ROUND(estimatedetail.taxable * estimatedetail.number * 
	     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
	     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
	   ),0)
	),
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
	   	     ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
	   ),0)
	),
	--residuo :somma dei dett. ordine non contabilizzati
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (estimatedetail.idinc_taxable IS  NULL) AND (estimatedetail.idinc_iva IS  NOT NULL)
			THEN
			     ROUND(estimatedetail.taxable * estimatedetail.number * 
		     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
			WHEN ( estimatedetail.idinc_iva IS NULL) AND (estimatedetail.idinc_taxable IS  NOT NULL)
			THEN
			      ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
			WHEN ( estimatedetail.idinc_iva IS  NULL) AND (estimatedetail.idinc_taxable IS  NULL)
			THEN
			     ROUND(estimatedetail.taxable * estimatedetail.number * 
		     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
			     +
			     ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
			ELSE   0
		    END
		   ),0)
		),
-- (mov.movkind = '3' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (estimatedetail.idinc_taxable IS NOT NULL 
				AND (estimatedetail.idinc_iva IS NULL OR estimatedetail.idinc_taxable<>estimatedetail.idinc_iva)) 
			THEN
			     ROUND(estimatedetail.taxable * estimatedetail.number * 
		     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		),
-- (mov.movkind = '2')
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (estimatedetail.idinc_iva IS NOT NULL 
			      AND (estimatedetail.idinc_taxable IS NULL OR estimatedetail.idinc_taxable<>estimatedetail.idinc_iva)) 
			THEN
			       ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
			ELSE   0
		    END
			
		   ),0)
		),
--  (mov.movkind = '1' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (estimatedetail.idinc_taxable IS NOT NULL AND estimatedetail.idinc_iva= estimatedetail.idinc_taxable)
			THEN
			     ROUND(estimatedetail.taxable * estimatedetail.number * 
		     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
			     +
			     ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
			ELSE   0
		    END
			
		   ),0)
		),
	estimate.active,
	upb.title,
	estimate.flagintracom,
	isnull(estimate.idsor01,estimatekind.idsor01),
	isnull(estimate.idsor02,estimatekind.idsor02),
	isnull(estimate.idsor03,estimatekind.idsor03),
	isnull(estimate.idsor04,estimatekind.idsor04),
	isnull(estimate.idsor05,estimatekind.idsor05)
FROM estimatedetail (NOLOCK)
JOIN estimate (NOLOCK)
  	ON estimatedetail.idestimkind = estimate.idestimkind
	AND estimatedetail.yestim = estimate.yestim
  	AND estimatedetail.nestim = estimate.nestim
JOIN estimatekind
	ON estimatekind.idestimkind = estimate.idestimkind
LEFT OUTER JOIN upb
	ON upb.idupb=estimatedetail.idupb
WHERE estimatedetail.STOP is null
GROUP BY estimatedetail.idestimkind, estimatedetail.yestim, estimatedetail.nestim,
	estimate.idreg,estimatedetail.idreg,estimatedetail.idupb,
	estimatekind.description,estimate.description,
	estimate.active,upb.title,estimate.flagintracom,
	isnull(estimate.idsor01,estimatekind.idsor01),
	isnull(estimate.idsor02,estimatekind.idsor02),
	isnull(estimate.idsor03,estimatekind.idsor03),
	isnull(estimate.idsor04,estimatekind.idsor04),
	isnull(estimate.idsor05,estimatekind.idsor05)



GO

print '[estimateresidual] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'admpay_appropriationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW admpay_appropriationview
GO


CREATE                  VIEW admpay_appropriationview
(
yadmpay,
nadmpay,
nappropriation,
description,
idfin,
codefin,
idupb,
codeupb,
idexp,
ymov,
nmov,
nphase,
phase,
amount,
available,
cu,
ct,
lu,
lt,
linked
)
AS SELECT
admpay_appropriation.yadmpay,
admpay_appropriation.nadmpay,
admpay_appropriation.nappropriation,
admpay_appropriation.description,
admpay_appropriation.idfin,
fin.codefin,
admpay_appropriation.idupb,
upb.codeupb,
admpay_appropriation.idexp,
expense.ymov,
expense.nmov,
expense.nphase,
expensephase.description,
admpay_appropriation.amount,
admpay_appropriation.amount -
ISNULL(
	(SELECT SUM(amount)
	FROM admpay_expense
	WHERE admpay_expense.yadmpay = admpay_appropriation.yadmpay
	AND admpay_expense.nadmpay = admpay_appropriation.nadmpay
	AND admpay_expense.nappropriation = admpay_appropriation.nappropriation)
,0) -
ISNULL(
	(SELECT SUM(amount)
	FROM admpay_admintax
	WHERE admpay_admintax.yadmpay = admpay_appropriation.yadmpay
	AND admpay_admintax.nadmpay = admpay_appropriation.nadmpay
	AND admpay_admintax.nappropriation = admpay_appropriation.nappropriation)
,0),
admpay_appropriation.cu,
admpay_appropriation.ct,
admpay_appropriation.lu,
admpay_appropriation.lt,
CASE
	WHEN
		(SELECT COUNT(*) FROM admpay_expense
		WHERE admpay_expense.yadmpay = admpay_appropriation.yadmpay
		AND admpay_expense.nadmpay = admpay_appropriation.nadmpay
		AND admpay_expense.nappropriation = admpay_appropriation.nappropriation) +
		(SELECT COUNT(*) FROM admpay_admintax
		WHERE admpay_admintax.yadmpay = admpay_appropriation.yadmpay
		AND admpay_admintax.nadmpay = admpay_appropriation.nadmpay
		AND admpay_admintax.nappropriation = admpay_appropriation.nappropriation)
		 > 0 THEN 'S'
	ELSE 'N'
END
FROM admpay_appropriation
LEFT OUTER JOIN fin
ON fin.idfin = admpay_appropriation.idfin
LEFT OUTER JOIN upb
ON upb.idupb = admpay_appropriation.idupb
LEFT OUTER JOIN expense
ON expense.idexp = admpay_appropriation.idexp
LEFT OUTER JOIN expensephase
ON expense.nphase = expensephase.nphase



GO

print 'admpay_appropriationview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expenditurearrears') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expenditurearrears
GO




CREATE               VIEW [expenditurearrears]
(
	ayear,
	idexp,
	ymov,
	nmov,
	adate,
	residualamount,
	totflag,
	flagarrear
)
AS
SELECT 
i1.ayear,s1.idexp,s1.ymov,s1.nmov,s1.adate,
ISNULL(i2.curramount,0.0) - ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense s3
	 JOIN expensetotal i3
	 ON s3.idexp = i3.idexp
	 JOIN expenselast l1
	 ON l1.idexp = s3.idexp
	 JOIN expenselink el
	 ON el.idparent = s1.idexp
	 AND el.idchild = s3.idexp
	 JOIN payment d1
	 ON d1.kpay = l1.kpay
	 JOIN paymenttransmission t1
	 ON t1.kpaymenttransmission = d1.kpaymenttransmission
	 WHERE i3.ayear = i1.ayear),0.0),
	i2.flag,
CASE
	WHEN ((i2.flag&1)=0) THEN 'C'
	WHEN ((i2.flag&1)=1) THEN 'R'
END
FROM expense s1
INNER JOIN expenseyear i1 
ON s1.idexp = i1.idexp 
INNER JOIN expensetotal i2
ON i1.idexp = i2.idexp
AND i1.ayear = i2.ayear
INNER JOIN config p1
ON p1.appropriationphasecode = s1.nphase
AND p1.ayear = i1.ayear
WHERE i2.curramount >
	ISNULL((SELECT SUM(ISNULL(i3.curramount,0.0)) FROM expense s3
	 JOIN expensetotal i3
	 ON s3.idexp = i3.idexp
	 JOIN expenselast l1
	 ON l1.idexp = s3.idexp
	 JOIN expenselink el
	 ON el.idparent = s1.idexp
	 AND el.idchild = s3.idexp
	 JOIN payment d1
	 ON d1.kpay = l1.kpay
	 JOIN paymenttransmission t1
	 ON t1.kpaymenttransmission = d1.kpaymenttransmission
	 WHERE i3.ayear = i1.ayear),0.0)


GO

print '[expenditurearrears] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'cafdocumentview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW cafdocumentview
GO


CREATE       VIEW [cafdocumentview]
(
	idcafdocument,
	idcon,
	ycon,
	ncon,
	idreg,
	registry,
	ayear,
	cafdocumentkind,
	docdate,
	citytaxtorefundhusband,
	citytaxtorefund,
	citytaxtoretainhusband,
	citytaxtoretain,
	regionaltaxtorefundhusband,
	regionaltaxtorefund,
	regionaltaxtoretainhusband,
	regionaltaxtoretain,
	idcity,
	citycode,
	idfiscaltaxregion,
	fiscaltaxregion,
	irpeftorefund,
	irpeftoretain,
	startmonth,
	monthfirstinstalment,
	monthsecondinstalment,
	ratequantity,
	nquotafirstinstalment,
	nquotasecondinstalment,
	firstrateadvance,
	separatedincomehusband,
	separatedincome,
	secondrateadvance,
	citytaxaccount,
	citytaxaccounthusband,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
cafdocument.idcafdocument,
cafdocument.idcon,
parasubcontract.ycon,
parasubcontract.ncon,
parasubcontract.idreg,
registry.title,
cafdocument.ayear,
CASE cafdocumentkind
	WHEN 'O' THEN 'Ordinaria'
	WHEN 'I' THEN 'Integrativa'
	WHEN 'R' THEN 'Rettificativa'
END,
docdate,
cafdocument.citytaxtorefundhusband,
cafdocument.citytaxtorefund,
cafdocument.citytaxtoretainhusband,
cafdocument.citytaxtoretain,
cafdocument.regionaltaxtorefundhusband,
cafdocument.regionaltaxtorefund,
cafdocument.regionaltaxtoretainhusband,
cafdocument.regionaltaxtoretain,
cafdocument.idcity,
A.value,
cafdocument.idfiscaltaxregion,
F.title,
cafdocument.irpeftorefund,
cafdocument.irpeftoretain,
cafdocument.startmonth,
cafdocument.monthfirstinstalment,
cafdocument.monthsecondinstalment,
cafdocument.ratequantity,
cafdocument.nquotafirstinstalment,
cafdocument.nquotasecondinstalment,
cafdocument.firstrateadvance,
cafdocument.separatedincomehusband,
cafdocument.separatedincome,
cafdocument.secondrateadvance,
cafdocument.citytaxaccount,
cafdocument.citytaxaccounthusband,
cafdocument.ct,
cafdocument.cu,
cafdocument.lt,
cafdocument.lu
FROM cafdocument
JOIN parasubcontract
ON parasubcontract.idcon = cafdocument.idcon
JOIN registry
ON registry.idreg = parasubcontract.idreg
LEFT OUTER JOIN geo_city_agencyview A
	ON A.idcity = cafdocument.idcity
	AND A.idagency = 1
	AND A.idcode = 1
	AND A.version = 1
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = cafdocument.idfiscaltaxregion



GO

print '[cafdocumentview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoiceexpavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoiceexpavailable
GO


CREATE    VIEW [invoiceexpavailable]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	invkind,
	registry,
	description,
	doc,
	docdate,
	adate,
	taxabletotal,
	ivatotal,
	detailtaxabletotal,
	detailivatotal,
	linkedtotal,
	residual,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoice.yinv,
	invoice.ninv,
	invoicekind.description,
	registry.title,
	invoice.description,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	totinvoiceview.taxabletotal, -- totale imponibile su tutta la fattura
	totinvoiceview.ivatotal,--totale iva su tutta la fattura
	totinvoicedetailview.taxabletotal,--totale imponibile dei dettagli associati a movimenti di spesa
	totinvoicedetailview.ivatotal,--totale iva dei dettagli associati a movimenti di spesa
	--totale movimenti = somma (importo) del join di expenseinvoice con expense
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0) 
	FROM expenseinvoice mov (NOLOCK)
	JOIN expense s (NOLOCK)
	ON s.idexp = mov.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
	ON expensetotal_firstyear.idexp = s.idexp
	AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
	WHERE mov.idinvkind = invoice.idinvkind
	AND mov.yinv = invoice.yinv
	AND mov.ninv = invoice.ninv)
	,2)),
	--residuo :somma dei dett. fattura non contabilizzati
	(SELECT CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoicedetail.idexp_iva IS  NOT NULL)
			THEN
			     ROUND((ISNULL(invoicedetail.taxable,0)* CONVERT(decimal(19,6),I.exchangerate) * ISNULL(invoicedetail.npackage,invoicedetail.number) )  ,2)
			WHEN ( invoicedetail.idexp_iva IS NULL) AND (invoicedetail.idexp_taxable IS  NOT NULL)
			THEN
			     ROUND( ISNULL(invoicedetail.tax,0)  ,2)
			WHEN ( invoicedetail.idexp_iva IS  NULL) AND (invoicedetail.idexp_taxable IS  NULL)
			THEN
			     ROUND((ISNULL(invoicedetail.taxable,0)* CONVERT(decimal(19,6),I.exchangerate) * ISNULL(invoicedetail.npackage,invoicedetail.number) + ISNULL(invoicedetail.tax,0))  ,2)
			ELSE   0
		    END
		   ),0)
		) 
	FROM invoicedetail 
	JOIN invoice I ON
		invoicedetail.idinvkind = I.idinvkind
		AND invoicedetail.yinv = I.yinv
		AND invoicedetail.ninv = I.ninv
	WHERE invoicedetail.idinvkind = invoice.idinvkind
		AND invoicedetail.yinv = invoice.yinv
		AND invoicedetail.ninv = invoice.ninv),
	invoice.active,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05
FROM invoice (NOLOCK)
JOIN invoicekind
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN totinvoiceview (NOLOCK)
	ON totinvoiceview.idinvkind = invoice.idinvkind
	AND totinvoiceview.yinv = invoice.yinv
	AND totinvoiceview.ninv = invoice.ninv
LEFT OUTER JOIN totinvoicedetailview (NOLOCK)
	ON totinvoicedetailview.idinvkind = invoice.idinvkind
	AND totinvoicedetailview.yinv = invoice.yinv
	AND totinvoicedetailview.ninv = invoice.ninv
LEFT OUTER JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
WHERE ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0)



GO

print '[invoiceexpavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoiceresidualestimate') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoiceresidualestimate
GO


CREATE     VIEW [invoiceresidualestimate]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	doc,
	docdate,
	description,
	idreg,
	idupb,
	idupb_iva,
	registry,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkeddocum,
	linkedtotal,
	flag,
	flagbuysell,
	flagvariation,
	idinc_taxableestim,
	idinc_ivaestim,
	idestimkind,
	estimatekind,
	yestim,
	nestim,
	estimrownum,
	active,
	upb,
	upb_iva,
	flagintracom,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05 
)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoice.yinv,
	invoice.ninv,
	invoice.doc,
	invoice.docdate,
	invoice.description,
	invoice.idreg,
	invoicedetail.idupb,
	invoicedetail.idupb_iva,
	registry.title,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	   ),0)
	),
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(ROUND(invoicedetail.tax ,2)
	   ),0)
	),
	-- residuo :somma dei dett. fattura non contabilizzati 
	-- oppure 0 se la fattura è di ACQUISTO contabilizzata con fondo economale
	-- (la contabilizzazione totale è obbligatoria in questo caso)
	CASE 
	WHEN ((invoicekind.flag&1)<>0) 
	THEN	CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				WHEN (invoicedetail.idinc_taxable IS  NULL) AND (invoice.flagintracom<>'N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
				WHEN (invoicedetail.idinc_taxable IS  NULL) AND (invoicedetail.idinc_iva IS  NOT NULL) AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)*  
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	
				WHEN (invoicedetail.idinc_iva IS NULL) AND (invoicedetail.idinc_taxable IS  NOT NULL)AND (invoice.flagintracom='N')
				THEN
				    ROUND(invoicedetail.tax ,2)
	
				WHEN (invoicedetail.idinc_iva IS  NULL) AND (invoicedetail.idinc_taxable IS  NULL) AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)*  
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
				     +
				     ROUND(invoicedetail.tax ,2)
				ELSE   0
	
			    END
			   ),0)
			)
	END,
-- (mov.movkind = '3' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)<>0)  AND invoicedetail.idinc_taxable IS NOT NULL 
				AND (invoicedetail.idinc_iva IS NULL OR 
				invoicedetail.idinc_taxable<>invoicedetail.idinc_iva)) 
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		),
-- (mov.movkind = '2')
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)<>0)  AND invoicedetail.idinc_iva IS NOT NULL 
				AND  (invoicedetail.idinc_taxable IS NULL OR 
				invoicedetail.idinc_taxable<>invoicedetail.idinc_iva)) 
			THEN
			       ROUND(invoicedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		),
	
--  (mov.movkind = '1' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)<>0)  AND invoicedetail.idinc_taxable IS NOT NULL 
				AND invoicedetail.idinc_iva= invoicedetail.idinc_taxable)
			THEN
	  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
			     +
			     ROUND(invoicedetail.tax ,2)			
			ELSE   0
		    END
		   ),0)
		),
-- linkedtotal = (mov.movkind = 'IMPON' ) + (mov.movkind = 'IMPOS') +  (mov.movkind = 'DOCUM' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)<>0)  AND invoicedetail.idinc_taxable IS NOT NULL 
				AND (invoicedetail.idinc_iva IS NULL OR 
				invoicedetail.idinc_taxable<>invoicedetail.idinc_iva)) 
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		)
	+	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)<>0)  AND invoicedetail.idinc_iva IS NOT NULL 
				AND  (invoicedetail.idinc_taxable IS NULL OR 
				invoicedetail.idinc_taxable<>invoicedetail.idinc_iva)) 
			THEN
			       ROUND(invoicedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		)
	+	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)<>0)  AND invoicedetail.idinc_taxable IS NOT NULL 
				AND invoicedetail.idinc_iva= invoicedetail.idinc_taxable)
			THEN
	  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
			     +
			     ROUND(invoicedetail.tax ,2)			
			ELSE   0
		    END
		   ),0)
		),
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	estimatedetail.idinc_taxable,
	estimatedetail.idinc_iva,
	estimatedetail.idestimkind,
	estimatekind.description,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatedetail.rownum,
	invoice.active,
	upb.title,
	upbiva.title ,
	invoice.flagintracom,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05  	
	FROM invoicedetail (NOLOCK)
	JOIN invoice (NOLOCK)
  	ON invoicedetail.idinvkind = invoice.idinvkind
	AND invoicedetail.yinv = invoice.yinv
  	AND invoicedetail.ninv = invoice.ninv
	JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
	LEFT OUTER JOIN estimatekind
	ON estimatekind.idestimkind = invoicedetail.idestimkind
	LEFT OUTER JOIN upb
	on upb.idupb=invoicedetail.idupb
	LEFT OUTER JOIN upb upbiva
	on upbiva.idupb=invoicedetail.idupb_iva
	LEFT OUTER JOIN estimatedetail
	ON  estimatedetail.idestimkind=invoicedetail.idestimkind 
	and estimatedetail.yestim=invoicedetail.yestim 
	and estimatedetail.nestim=invoicedetail.nestim
	and estimatedetail.rownum=invoicedetail.estimrownum
	GROUP BY invoice.idinvkind, invoicekind.codeinvkind,invoice.yinv, invoice.ninv,
	invoice.doc,invoice.docdate,
	invoicedetail.idestimkind, invoicedetail.yestim, invoicedetail.nestim,
	estimatedetail.idinc_taxable,estimatedetail.idinc_iva,
	invoice.description,invoice.idreg,registry.title,invoicedetail.idupb,invoicedetail.idupb_iva,upbiva.title,
	estimatedetail.idestimkind,estimatekind.description,estimatedetail.yestim,
	estimatedetail.nestim,estimatedetail.rownum,invoicekind.flag,
	(invoicekind.flag&1), (invoicekind.flag&4),invoice.active,upb.title,invoice.flagintracom,
	invoice.idsor01,invoice.idsor02,invoice.idsor03,invoice.idsor04,invoice.idsor05  	



GO

print '[invoiceresidualestimate] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'admpay_assessmentview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW admpay_assessmentview
GO



CREATE              VIEW admpay_assessmentview
(
	yadmpay,
	nadmpay,
	nassessment,
	description,
	idfin,
	codefin,
	idupb,
	codeupb,
	idinc,
	ymov,
	nmov,
	nphase,
	phase,
	amount,
	available,
	cu,
	ct,
	lu,
	lt,
	linked
)
AS SELECT
	admpay_assessment.yadmpay,
	admpay_assessment.nadmpay,
	admpay_assessment.nassessment,
	admpay_assessment.description,
	admpay_assessment.idfin,
	fin.codefin,
	admpay_assessment.idupb,
	upb.codeupb,
	admpay_assessment.idinc,
	income.ymov,
	income.nmov,
	income.nphase,
	incomephase.description,
	admpay_assessment.amount,
	admpay_assessment.amount -
	ISNULL(
		(SELECT SUM(amount)
		FROM admpay_income
		WHERE admpay_income.yadmpay = admpay_assessment.yadmpay
		AND admpay_income.nadmpay = admpay_assessment.nadmpay
		AND admpay_income.nassessment = admpay_assessment.nassessment)
	,0),
	admpay_assessment.cu,
	admpay_assessment.ct,
	admpay_assessment.lu,
	admpay_assessment.lt,
	CASE
		WHEN
			(SELECT COUNT(*) FROM admpay_income
			WHERE admpay_income.yadmpay = admpay_assessment.yadmpay
			AND admpay_income.nadmpay = admpay_assessment.nadmpay
			AND admpay_income.nassessment = admpay_assessment.nassessment)
			 > 0 THEN 'S'
		ELSE 'N'
	END
FROM admpay_assessment
LEFT OUTER JOIN fin
	ON fin.idfin = admpay_assessment.idfin
LEFT OUTER JOIN upb
	ON upb.idupb = admpay_assessment.idupb
LEFT OUTER JOIN income
	ON income.idinc = admpay_assessment.idinc
LEFT OUTER JOIN incomephase
	ON income.nphase = incomephase.nphase



GO

print 'admpay_assessmentview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoiceexpenselinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoiceexpenselinked
GO

CREATE                                     VIEW [invoiceexpenselinked]
	(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	idreg,
	registry,
	registryreference,
	description,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	packinglistnum,
	packinglistdate,
	officiallyprinted,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
	)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoice.yinv,
	invoice.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoice.idreg,
	registry.title,
	invoice.registryreference,
	invoice.description,
	invoice.paymentexpiring,
	invoice.idexpirationkind,
	invoice.idcurrency,
	currency.codecurrency,
	currency.description,
	invoice.exchangerate,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	invoice.packinglistnum,
	invoice.packinglistdate,
	invoice.officiallyprinted,
	invoice.txt,
	invoice.cu, 
	invoice.ct, 
	invoice.lu,
	invoice.lt,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05 
	FROM invoice (NOLOCK)
	JOIN invoicekind(NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
	LEFT OUTER JOIN currency (NOLOCK)
	ON currency.idcurrency = invoice.idcurrency
	WHERE EXISTS
		(SELECT * FROM expenseinvoice
		WHERE expenseinvoice.idinvkind = invoice.idinvkind
		AND expenseinvoice.yinv=invoice.yinv
		AND expenseinvoice.ninv=invoice.ninv)

GO

print '[invoiceexpenselinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoiceresidualmandate') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoiceresidualmandate
GO



CREATE       VIEW [invoiceresidualmandate]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	doc,
	docdate,
	description,
	idreg,
	idupb,
	idupb_iva,
	registry,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkeddocum,
	linkedtotal,
	flag,
	flagbuysell,
	flagvariation,
	idexp_taxablemand,
	idexp_ivamand,
	ycon,
	ncon,
	idmankind,
	mandatekind,
	yman,
	nman,
	manrownum,
	active,
	upb,
	upb_iva,
	flagintracom,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05 
)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoice.yinv,
	invoice.ninv,
	invoice.doc,
	invoice.docdate,
	invoice.description,
	invoice.idreg,
	invoicedetail.idupb,
	invoicedetail.idupb_iva,
	registry.title,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	   ),0)
	),
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(ROUND(invoicedetail.tax ,2)
	   ),0)
	),
	-- residuo :somma dei dett. fattura non contabilizzati 
	-- oppure 0 se la fattura è di ACQUISTO contabilizzata con fondo economale
	-- (la contabilizzazione totale è obbligatoria in questo caso)
	CASE 
	WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NOT NULL)
	THEN 0
	WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NULL)
	THEN CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
			    CASE 
				WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoice.flagintracom!='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
				WHEN (invoicedetail.idexp_taxable IS  NULL) AND (invoicedetail.idexp_iva IS  NOT NULL) AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
	
				WHEN (invoicedetail.idexp_iva IS NULL) AND (invoicedetail.idexp_taxable IS  NOT NULL)AND (invoice.flagintracom='N')
				THEN
				    ROUND(invoicedetail.tax ,2)
	
				WHEN (invoicedetail.idexp_iva IS  NULL) AND (invoicedetail.idexp_taxable IS  NULL)AND (invoice.flagintracom='N')
				THEN
				     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
			     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
			     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
				     +
				     ROUND(invoicedetail.tax ,2)
				ELSE   0
	
			    END
			   ),0)
			)
	END,
-- (mov.movkind = 'IMPON' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
				AND (invoicedetail.idexp_iva IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) 
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		),
-- (mov.movkind = 'IMPOS')
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)=0) AND  invoicedetail.idexp_iva IS NOT NULL 
				AND  (invoicedetail.idexp_taxable IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) 
			THEN
			       ROUND(invoicedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		),
	
--  (mov.movkind = 'DOCUM' )
	CASE 
		WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NOT NULL)
		THEN 
			CONVERT(DECIMAL(19,2),
					ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
					     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
					     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
				   ),0)
				)
			+
			CONVERT(DECIMAL(19,2),
				ISNULL(SUM(ROUND(invoicedetail.tax ,2)
			   ),0)
			)
		ELSE
			CONVERT(DECIMAL(19,2),
				ISNULL(SUM(
				    CASE 
					WHEN ((((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
						AND invoicedetail.idexp_iva= invoicedetail.idexp_taxable) )
					THEN
			  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number) * 
				     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
				     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
					     +
					     ROUND(invoicedetail.tax,2)			
					ELSE   0
				    END
				   ),0)
				)
	END,
-- linkedtotal = (mov.movkind = 'IMPON' ) + (mov.movkind = 'IMPOS') +  (mov.movkind = 'DOCUM' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
				AND (invoicedetail.idexp_iva IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) 
			THEN
			      ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
		     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		)
	+  -- ('IMPOS')
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (((invoicekind.flag&1)=0) AND  invoicedetail.idexp_iva IS NOT NULL 
				AND  (invoicedetail.idexp_taxable IS NULL OR 
				invoicedetail.idexp_taxable<>invoicedetail.idexp_iva)) 
			THEN
			       ROUND(invoicedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		)
	+	--  ('DOCUM')
	CASE 
		WHEN (((invoicekind.flag&1)=0) AND pettycashoperationinvoice.idinvkind IS NOT NULL)
		THEN 
			CONVERT(DECIMAL(19,2),
					ISNULL(SUM(  ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
					     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
					     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2)
				   ),0)
				)
			+
			CONVERT(DECIMAL(19,2),
				ISNULL(SUM(ROUND(invoicedetail.tax ,2)
			   ),0)
			)
		ELSE
			CONVERT(DECIMAL(19,2),
				ISNULL(SUM(
				    CASE 
					WHEN ((((invoicekind.flag&1)=0) AND invoicedetail.idexp_taxable IS NOT NULL 
						AND invoicedetail.idexp_iva= invoicedetail.idexp_taxable) )
					THEN
			  		     ROUND(invoicedetail.taxable * ISNULL(invoicedetail.npackage,invoicedetail.number)* 
				     	     CONVERT(decimal(19,6),invoice.exchangerate) * 
				     	     (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0.0))),2) 
					     +
					     ROUND(invoicedetail.tax,2)			
					ELSE   0
				    END
				   ),0)
				)
	END,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva,
	profservice.ycon,
	profservice.ncon,
	mandatedetail.idmankind,
	mandatekind.description,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.rownum,
	invoice.active,
	upb.title,
	upbiva.title ,
	invoice.flagintracom,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05  	
	FROM invoicedetail (NOLOCK)
	JOIN invoice (NOLOCK)
  	ON invoicedetail.idinvkind = invoice.idinvkind
	AND invoicedetail.yinv = invoice.yinv
  	AND invoicedetail.ninv = invoice.ninv
	JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
	LEFT OUTER JOIN profservice 
	ON profservice.idinvkind=invoice.idinvkind 
	and profservice.yinv=invoice.yinv 
	and profservice.ninv=invoice.ninv
	LEFT OUTER JOIN upb
	on upb.idupb=invoicedetail.idupb
	LEFT OUTER JOIN upb upbiva
	on upbiva.idupb=invoicedetail.idupb_iva
	LEFT OUTER JOIN mandatedetail
	ON  mandatedetail.idmankind=invoicedetail.idmankind 
	and mandatedetail.yman=invoicedetail.yman 
	and mandatedetail.nman=invoicedetail.nman
	and mandatedetail.rownum=invoicedetail.manrownum
	LEFT OUTER JOIN mandatekind
	ON mandatekind.idmankind = mandatedetail.idmankind
	LEFT OUTER JOIN  pettycashoperationinvoice
	ON pettycashoperationinvoice.idinvkind=invoice.idinvkind 
	and pettycashoperationinvoice.yinv=invoice.yinv 
	and pettycashoperationinvoice.ninv=invoice.ninv
	GROUP BY invoice.idinvkind, invoicekind.codeinvkind, invoice.yinv, invoice.ninv,invoice.doc,invoice.docdate,
	invoicedetail.idmankind, invoicedetail.yman, invoicedetail.nman,
	mandatedetail.idexp_taxable,mandatedetail.idexp_iva,
	invoice.description,invoice.idreg,registry.title,invoicedetail.idupb, invoicedetail.idupb_iva,	upbiva.title ,profservice.idinvkind,
	mandatedetail.idmankind,mandatekind.description,mandatedetail.yman,mandatedetail.nman, mandatedetail.rownum,
	invoicekind.flag,(invoicekind.flag&1),(invoicekind.flag&4),profservice.ycon,
	profservice.ncon, pettycashoperationinvoice.idinvkind,invoice.active,upb.title,invoice.flagintracom,
	invoice.idsor01,invoice.idsor02,invoice.idsor03,invoice.idsor04,invoice.idsor05  	





GO

print '[invoiceresidualmandate] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoiceincavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoiceincavailable
GO

CREATE    VIEW [invoiceincavailable]
(
	idinvkind,
	codeinvkind,
	yinv,
	ninv,
	invkind,
	registry,
	description,
	doc,
	docdate,
	adate,
	taxabletotal,
	ivatotal,
	detailtaxabletotal,
	detailivatotal,
	linkedtotal,
	residual,
	active,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoice.yinv,
	invoice.ninv,
	invoicekind.description,
	registry.title,
	invoice.description,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	totinvoiceview.taxabletotal, -- totale imponibile su tutta la fattura
	totinvoiceview.ivatotal,--totale iva su tutta la fattura
	totinvoicedetailview.taxabletotal,--totale imponibile dei dettagli associati a movimenti di spesa
	totinvoicedetailview.ivatotal,--totale iva dei dettagli associati a movimenti di spesa
	--totale movimenti = somma (importo) del join di expenseinvoice con expense
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(incomeyear_starting.amount), 0) 
	FROM incomeinvoice mov (NOLOCK)
	JOIN income s (NOLOCK)
	ON s.idinc = mov.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
	ON incometotal_firstyear.idinc = s.idinc
	AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
	ON incomeyear_starting.idinc = incometotal_firstyear.idinc
	AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE mov.idinvkind = invoice.idinvkind
	AND mov.yinv = invoice.yinv
	AND mov.ninv = invoice.ninv)
	,2)),
	--residuo :somma dei dett. ordine non contabilizzati
	(SELECT CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (invoicedetail.idinc_taxable IS  NULL) AND (invoicedetail.idinc_iva IS  NOT NULL)
			THEN
			     ROUND((ISNULL(invoicedetail.taxable,0)* CONVERT(decimal(19,6),I.exchangerate) * ISNULL(invoicedetail.npackage,invoicedetail.number))  ,2)
			WHEN ( invoicedetail.idinc_iva IS NULL) AND (invoicedetail.idinc_taxable IS  NOT NULL)
			THEN
			     ROUND( ISNULL(invoicedetail.tax,0)  ,2)
			WHEN ( invoicedetail.idinc_iva IS  NULL) AND (invoicedetail.idinc_taxable IS  NULL)
			THEN
			     ROUND((ISNULL(invoicedetail.taxable,0)* CONVERT(decimal(19,6),I.exchangerate) * ISNULL(invoicedetail.npackage,invoicedetail.number) + ISNULL(invoicedetail.tax,0))  ,2)
			ELSE   0
		    END
		   ),0)
		) 
	FROM invoicedetail 
	JOIN invoice I ON
		invoicedetail.idinvkind = I.idinvkind
		AND invoicedetail.yinv = I.yinv
		AND invoicedetail.ninv = I.ninv
	WHERE invoicedetail.idinvkind = invoice.idinvkind
		AND invoicedetail.yinv = invoice.yinv
		AND invoicedetail.ninv = invoice.ninv),
	invoice.active,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05 
FROM invoice (NOLOCK)
JOIN invoicekind  (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN totinvoiceview (NOLOCK)
	ON totinvoiceview.idinvkind = invoice.idinvkind
	AND totinvoiceview.yinv = invoice.yinv
	AND totinvoiceview.ninv = invoice.ninv
LEFT OUTER JOIN totinvoicedetailview (NOLOCK)
	ON totinvoicedetailview.idinvkind = invoice.idinvkind
	AND totinvoicedetailview.yinv = invoice.yinv
	AND totinvoicedetailview.ninv = invoice.ninv
LEFT OUTER JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
WHERE ((invoicekind.flag&1)<>0) AND ((invoicekind.flag&4)=0)


GO

print '[invoiceincavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandateresidual') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandateresidual
GO


CREATE     VIEW [mandateresidual]
	(
	idmankind,	
	yman,
	nman,
	mankind,
	description,
	idreg,
	idupb,
	idman,
	manager,
	registry,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkedordin,
	active,
	upb,
	flagintracom,
	idmandatestatus,
	mandatestatus,
	isrequest,
	idsor01,idsor02,idsor03,idsor04,idsor05
	)
AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatekind.description,
	mandate.description,
	isnull(mandate.idreg,mandatedetail.idreg),
	mandatedetail.idupb,
	mandate.idman,
	manager.title,
	CASE
	WHEN mandate.idreg is not null THEN (select title from
					registry 
					where idreg= mandate.idreg)
	WHEN mandatedetail.idreg is not null THEN (select title from
					registry 
					where idreg= mandatedetail.idreg)
	ELSE null
	END,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(  ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)
	   ),0)
	),
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(ROUND(mandatedetail.tax,2)
	   ),0)
	),
	--residuo :somma dei dett. ordine non contabilizzati
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (mandatedetail.idexp_taxable IS  NULL) AND (mandatedetail.idexp_iva IS  NOT NULL) 
			THEN
			     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)
			WHEN ( mandatedetail.idexp_iva IS NULL) AND (mandatedetail.idexp_taxable IS  NOT NULL)
			THEN
			    ROUND(mandatedetail.tax,2)
			WHEN ( mandatedetail.idexp_iva IS  NULL) AND (mandatedetail.idexp_taxable IS  NULL)
			THEN
			     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2) 
			     +
			     ROUND(mandatedetail.tax,2)
			ELSE   0
		    END
		   ),0)
		),
-- (mov.movkind = '3' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (mandatedetail.idexp_taxable IS NOT NULL 
				AND (mandatedetail.idexp_iva IS NULL OR mandatedetail.idexp_taxable<>mandatedetail.idexp_iva)) 
			THEN
			      ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		),
-- (mov.movkind = '2')
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (mandatedetail.idexp_iva IS NOT NULL 
				AND  (mandatedetail.idexp_taxable IS NULL OR mandatedetail.idexp_taxable<>mandatedetail.idexp_iva)) 
			THEN
			       ROUND(mandatedetail.tax ,2)
			ELSE   0
		    END
			
		   ),0)
		),
	
--  (mov.movkind = '1' )
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (mandatedetail.idexp_taxable IS NOT NULL AND mandatedetail.idexp_iva= mandatedetail.idexp_taxable)
			THEN
	  		     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2) 
			     +
			     ROUND(mandatedetail.tax,2)			
			ELSE   0
		    END
		   ),0)
		),
	mandate.active,
	upb.title,
	mandate.flagintracom,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatekind.isrequest,
	isnull(mandate.idsor01,mandatekind.idsor01),
	isnull(mandate.idsor02,mandatekind.idsor02),
	isnull(mandate.idsor03,mandatekind.idsor03),
	isnull(mandate.idsor04,mandatekind.idsor04),
	isnull(mandate.idsor05,mandatekind.idsor05)
FROM mandatedetail (NOLOCK)
JOIN mandate (NOLOCK)
  	ON mandatedetail.idmankind = mandate.idmankind
	AND mandatedetail.yman = mandate.yman
  	AND mandatedetail.nman = mandate.nman
JOIN mandatekind  (NOLOCK)
	ON mandatekind.idmankind = mandate.idmankind 
LEFT OUTER JOIN upb  (NOLOCK)
	on upb.idupb=mandatedetail.idupb
LEFT OUTER JOIN manager  (NOLOCK)
	on mandate.idman= manager.idman
LEFT OUTER JOIN mandatestatus   (NOLOCK)
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
WHERE mandatedetail.stop is null
GROUP BY mandatedetail.idmankind, mandatedetail.yman, mandatedetail.nman,
	mandate.idreg,mandatedetail.idreg,mandatedetail.idupb,
	mandatekind.description,mandate.description,mandate.idman, manager.title,
	mandate.active,upb.title, mandate.flagintracom, mandate.idmandatestatus, 
      mandatestatus.description,mandatekind.isrequest,
	isnull(mandate.idsor01,mandatekind.idsor01),
	isnull(mandate.idsor02,mandatekind.idsor02),
	isnull(mandate.idsor03,mandatekind.idsor03),
	isnull(mandate.idsor04,mandatekind.idsor04),
	isnull(mandate.idsor05,mandatekind.idsor05)


GO

print '[mandateresidual] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'ddt_inview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW ddt_inview
GO


CREATE   VIEW [ddt_inview](
idddt_in,
adate,
yddt_in,
nddt_in,
idreg,
registry,
terms,
idddt_in_motive,
ddt_in_motive,
idstore,
store
)
AS 
SELECT
	ddt_in.idddt_in,
	ddt_in.adate,
	ddt_in.yddt_in,
	ddt_in.nddt_in,
	ddt_in.idreg,
	registry.title,
	ddt_in.terms,
	ddt_in.idddt_in_motive,
	ddt_in_motive.description,
	ddt_in.idstore,
	store.description
FROM ddt_in
JOIN registry
	ON ddt_in.idreg = registry.idreg
LEFT OUTER JOIN store
	ON ddt_in.idstore = store.idstore
LEFT OUTER JOIN ddt_in_motive
	ON ddt_in.idddt_in_motive = ddt_in_motive.idddt_in_motive

GO

print '[ddt_inview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoiceincomelinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoiceincomelinked
GO


CREATE                                   VIEW [invoiceincomelinked]
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	idreg,
	registry,
	registryreference,
	description,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	packinglistnum,
	packinglistdate,
	officiallyprinted,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoice.yinv,
	invoice.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoice.idreg,
	registry.title,
	invoice.registryreference,
	invoice.description,
	invoice.paymentexpiring,
	invoice.idexpirationkind,
	invoice.idcurrency,
	currency.codecurrency,
	currency.description,
	invoice.exchangerate,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	invoice.packinglistnum,
	invoice.packinglistdate,
	invoice.officiallyprinted,
	invoice.txt,
	invoice.cu, 
	invoice.ct, 
	invoice.lu,
	invoice.lt ,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05 
	FROM invoice (NOLOCK)
	JOIN invoicekind(NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
	LEFT OUTER JOIN currency (NOLOCK)
	ON currency.idcurrency = invoice.idcurrency
	WHERE EXISTS
		(SELECT * FROM incomeinvoice
		WHERE incomeinvoice.idinvkind = invoice.idinvkind
		AND incomeinvoice.yinv=invoice.yinv
		AND incomeinvoice.ninv=invoice.ninv)


GO

print '[invoiceincomelinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoicekindyearview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoicekindyearview
GO


CREATE                                VIEW [invoicekindyearview]
(
	ayear,
	idinvkind,
	codeinvkind,
	description,
	flag,
	flagbuysell,
	flagmixed,
	flagvariation,
	idacc,
	idacc_deferred,
	idacc_discount,
	idacc_unabatable,
	proratarate,
	mixedrate,
	abatablerate,
	cu,
	ct,
	lu,
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT  
	IPR.ayear,	--IKY.ayear,
	IK.idinvkind,
	IK.codeinvkind,
	IK.description,
	IK.flag,
	CASE
		WHEN ((IK.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((IK.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((IK.flag&2)=0) THEN 'N'--flagmixed
		WHEN ((IK.flag&2)<>0) THEN 'S'
	END, 
	CASE
		WHEN ((IK.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((IK.flag&4)<>0) THEN 'S'
	END, 
	
	IKY.idacc,
	IKY.idacc_deferred,
	IKY.idacc_discount,
	IKY.idacc_unabatable,
	IPR.prorata,
	IM.mixed,
		CASE
		WHEN ((IK.flag&2)<>0) THEN IPR.prorata * IM.mixed
		ELSE IPR.prorata
	END,
	IK.cu,
	IK.ct,
	IK.lu,
	IK.lt,
	IK.idsor01,
	IK.idsor02,
	IK.idsor03,
	IK.idsor04,
	IK.idsor05 
FROM invoicekind IK WITH (NOLOCK)
CROSS JOIN iva_prorata IPR WITH (NOLOCK)
	--ON IPR.ayear = IKY.ayear
LEFT OUTER JOIN iva_mixed IM WITH (NOLOCK)
	ON IM.ayear = IPR.ayear
LEFT OUTER JOIN invoicekindyear IKY WITH (NOLOCK)
	ON IK.idinvkind = IKY.idinvkind
	AND IKY.ayear = IM.ayear

GO

print '[invoicekindyearview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'invoicelinked') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW invoicelinked
GO

CREATE                                   VIEW [invoicelinked]
	(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	idreg,
	registry,
	registryreference,
	description,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	packinglistnum,
	packinglistdate,
	--flagintra,
	officiallyprinted,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
	)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoice.yinv,
	invoice.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoice.idreg,
	registry.title,
	invoice.registryreference,
	invoice.description,
	invoice.paymentexpiring,
	invoice.idexpirationkind,
	invoice.idcurrency,
	currency.codecurrency,
	currency.description,
	invoice.exchangerate,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	invoice.packinglistnum,
	invoice.packinglistdate,
	--invoice.flagintra,
	invoice.officiallyprinted,
	invoice.txt,
	invoice.cu, 
	invoice.ct, 
	invoice.lu,
	invoice.lt ,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05 
	FROM invoice (NOLOCK)
	JOIN invoicekind(NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
	LEFT OUTER JOIN currency (NOLOCK)
	ON currency.idcurrency = invoice.idcurrency
	WHERE EXISTS
		(SELECT * FROM expenseinvoice
		WHERE expenseinvoice.idinvkind = invoice.idinvkind
		AND expenseinvoice.yinv=invoice.yinv
		AND expenseinvoice.ninv=invoice.ninv)


GO

print '[invoicelinked] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'managerview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW managerview
GO


--clear_table_info managerview
CREATE VIEW managerview 
(
	idman,
	title,
	iddivision,
	codedivision,
	division,
	email,
	phonenumber,
	userweb,
	passwordweb,
	active,
	financeactive,
	wantswarn,
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
	manager.idman,
	manager.title,
	manager.iddivision,
	division.codedivision,
	division.description,
	manager.email,
	manager.phonenumber,
	manager.userweb,
	manager.passwordweb,
	manager.active,
	manager.financeactive,
	manager.wantswarn,
	manager.idsor01,
	manager.idsor02,
	manager.idsor03,
	manager.idsor04,
	manager.idsor05,
	manager.cu, 
	manager.ct, 
	manager.lu,
	manager.lt 
FROM manager
LEFT OUTER JOIN division
	ON manager.iddivision = division.iddivision


GO

print 'managerview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'expensetaxcorrigeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW expensetaxcorrigeview
GO

--clear_table_info 'expensetaxcorrigeview'
-- select * from expensetaxcorrigeview
CREATE    VIEW [expensetaxcorrigeview]
(
	idexp,
	idexpensetaxcorrige,
	taxcode,
	taxref,
	tax,
	ayear,
	employamount,
	adminamount,
	idcity,
	city,
	provincecode,
	idfiscaltaxregion,
	fiscaltaxregion,
	linkedidinc,
	incomelinkedymov, 
	incomelinkednmov,
	linkedidexp,
	expenselinkedymov, 
	expenselinkednmov,
	ytaxpay,
	ntaxpay,
	adate,
	ymov,
	nmov,
	idreg,
	registry,
	expensedescription,
	expenseadate,
	ct,
	cu,
	lt,
	lu,
	phasedescription,
	descriptionrenumeration
)
AS SELECT
	expensetaxcorrige.idexp,
	expensetaxcorrige.idexpensetaxcorrige,
	expensetaxcorrige.taxcode,
	tax.taxref,
	tax.description,
	expensetaxcorrige.ayear,
	expensetaxcorrige.employamount,
	expensetaxcorrige.adminamount,
	expensetaxcorrige.idcity,
	geo_city.title,
	geo_country.province,
	expensetaxcorrige.idfiscaltaxregion,
	fiscaltaxregion.title,
	expensetaxcorrige.linkedidinc,
	incomelinked.ymov, 
	incomelinked.nmov,
	expensetaxcorrige.linkedidexp,
	expenselinked.ymov, 
	expenselinked.nmov,
	expensetaxcorrige.ytaxpay,
	expensetaxcorrige.ntaxpay,
	expensetaxcorrige.adate,
	expense.ymov, 
	expense.nmov, 
	expense.idreg,
	registry.title, 
	expense.description,
	expense.adate, 
	expensetaxcorrige.ct,
	expensetaxcorrige.cu,
	expensetaxcorrige.lt,
	expensetaxcorrige.lu,
	expensephase.description,
	service.description
FROM expensetaxcorrige
JOIN tax
	ON tax.taxcode = expensetaxcorrige.taxcode
JOIN expense
	ON expense.idexp = expensetaxcorrige.idexp
JOIN expensephase
	ON expense.nphase = expensephase.nphase
JOIN expenselast 
	ON expense.idexp = expenselast.idexp
LEFT OUTER JOIN service
	ON expenselast.idser = service.idser
JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN expense expenselinked
	ON expenselinked.idexp = expensetaxcorrige.linkedidexp
LEFT OUTER JOIN income incomelinked
	ON incomelinked.idinc = expensetaxcorrige.linkedidinc
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = expensetaxcorrige.idcity
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
LEFT OUTER JOIN fiscaltaxregion
	ON fiscaltaxregion.idfiscaltaxregion = expensetaxcorrige.idfiscaltaxregion


--select * from expensetaxcorrigeview

GO

print '[expensetaxcorrigeview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'f24epsanctionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW f24epsanctionview
GO



CREATE   VIEW [f24epsanctionview]
AS
SELECT DISTINCT 
a1.idsanctionf24,
a1.idf24ep,
a1.idsanction,
a1.idcity,
c1.title as city,
f1.idfiscaltaxregion,
f1.title as region
FROM f24epsanction a1
LEFT OUTER JOIN geo_city c1
ON a1.idcity= c1.idcity
LEFT OUTER JOIN fiscaltaxregion f1
ON a1.idfiscaltaxregion= f1.idfiscaltaxregion



GO

print '[f24epsanctionview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'inventorykindview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW inventorykindview
GO

CREATE       VIEW inventorykindview
(
	idinventorykind,
	codeinventorykind,
	description,
	flag,
	idinv_allow,
	codeinv_allow,
	inventorytree_allow,
	idinv_deny,
	codeinv_deny,
	inventorytree_deny,
	ct, cu, lt, lu
)
AS SELECT
	inventorykind.idinventorykind,
	inventorykind.codeinventorykind,
	inventorykind.description,
	inventorykind.flag,
	inventorykind.idinv_allow,
	it_allow.codeinv,
	it_allow.description,
	inventorykind.idinv_deny,
	it_deny.codeinv,
	it_deny.description,
	inventorykind.ct, inventorykind.cu, inventorykind.lt, inventorykind.lu
FROM inventorykind
LEFT OUTER JOIN inventorytree it_allow
	ON inventorykind.idinv_allow = it_allow.idinv
LEFT OUTER JOIN inventorytree it_deny
	ON inventorykind.idinv_deny = it_deny.idinv

GO

print 'inventorykindview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'assetconsigneeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW assetconsigneeview
GO

CREATE              VIEW [assetconsigneeview]
AS
SELECT     
	assetconsignee.idinventoryagency, 
	inventoryagency.description AS agency, 
	assetconsignee.start, 
	assetconsignee.qualification, 
	assetconsignee.title, 
	assetconsignee.lu, 
	assetconsignee.lt
FROM assetconsignee
JOIN inventoryagency
	ON assetconsignee.idinventoryagency = inventoryagency.idinventoryagency


GO

print '[assetconsigneeview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationresidual') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationresidual
GO

CREATE       VIEW [itinerationresidual]
	(
	iditineration,
	yitineration,
	nitineration,
	description,
	idreg,
	registry,
	start,
	stop,
	totalgross,
	totadvance,
	residual,
	linkedsaldo,
	linkedangir,
	linkedanpag,
	active,
	completed,
	idupb,
	codeupb,
	upb,
	idaccmotive,
	codemotive,
	idsor1,
	idsor2,
	idsor3,
	iditinerationstatus,
	itinerationstatus,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
	AS SELECT
	itineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	itineration.idreg,
	registry.title,
	itineration.start,      
	itineration.stop,
	itineration.totalgross,
	itineration.totadvance,
	--residual
	CONVERT(decimal(19,2),itineration.totalgross -
		(
		ISNULL(	
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseitineration mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.iditineration = itineration.iditineration
			AND ((mov.movkind = 4)OR(mov.movkind = 6))
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expenseitineration mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON (v.idexp = mov.idexp)
			WHERE mov.iditineration = itineration.iditineration
			AND ( (mov.movkind = 4 )OR(mov.movkind = 6 ))
			AND (ISNULL(v.autokind,0)<> 4) --'RITEN')
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationitineration mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.iditineration = itineration.iditineration
			AND mov.movkind = 6 )
			
		,0)
		)
	),
	--linkedsaldo
	CONVERT(decimal(19,2),
		(
		ISNULL(	
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseitineration mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.iditineration = itineration.iditineration
			AND (mov.movkind = 4)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expenseitineration mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
			WHERE mov.iditineration = itineration.iditineration
			AND (mov.movkind = 4)
			AND (ISNULL(v.autokind,0)<>4) --'RITEN')
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0)
		)
	) ,
	--linkedangir
	CONVERT(decimal(19,2),
		(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseitineration mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.iditineration = itineration.iditineration
			AND (mov.movkind = 5)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expenseitineration mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
			WHERE mov.iditineration = itineration.iditineration
			AND (mov.movkind = 5)
			AND (ISNULL(v.autokind,0)<>4 ) --'RITEN')
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationitineration mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.iditineration = itineration.iditineration
			AND mov.movkind = 5)
		,0)
		)
	),
	--linkedanpag
	CONVERT(decimal(19,2),
		(
		ISNULL(
			(SELECT SUM(expenseyear_starting.amount)
			FROM expenseitineration mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  				ON expensetotal_firstyear.idexp = s.idexp
  				AND ((expensetotal_firstyear.flag & 2) <> 0 )
			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
				ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  				AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			WHERE mov.iditineration = itineration.iditineration
			AND (mov.movkind = 6)
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(v.amount)
			FROM expenseitineration mov
			JOIN expense s
			ON s.idexp = mov.idexp
			LEFT OUTER JOIN expensevar v
			ON v.idexp = mov.idexp
			WHERE mov.iditineration = itineration.iditineration
			AND (mov.movkind = 6 )
			AND (ISNULL(v.autokind,0)<>4) --'RITEN')
			--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
			)
		,0) +
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationitineration mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.iditineration = itineration.iditineration
			AND mov.movkind = 6)
		,0)
		)
	),
	itineration.active,
	itineration.completed,
	itineration.idupb,
	upb.codeupb,
	upb.title,
	itineration.idaccmotive,
	accmotive.codemotive,
	itineration.idsor1,
	itineration.idsor2,
	itineration.idsor3,
	itineration.iditinerationstatus,
	itinerationstatus.description,
	itineration.idsor01,itineration.idsor02,itineration.idsor03,itineration.idsor04,itineration.idsor05
	FROM itineration with (nolock)
	JOIN registry with (nolock)
		ON registry.idreg = itineration.idreg
	LEFT OUTER JOIN upb with (nolock)
		ON upb.idupb = itineration.idupb
	LEFT OUTER JOIN accmotive with (nolock)
		ON accmotive.idaccmotive = itineration.idaccmotive
	LEFT OUTER JOIN itinerationstatus  with (nolock)
		ON itinerationstatus.iditinerationstatus= itineration.iditinerationstatus

GO

print '[itinerationresidual] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'wageadditiontaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW wageadditiontaxview
GO


CREATE              VIEW [wageadditiontaxview]
(
	taxcode,
	description,
	taxref,
	ycon,
	ncon,
	adminrate,
	employrate,
	taxable,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	admintax,
	employtax,
	taxkind
)
AS SELECT
	CDR.taxcode,
	TR.description,
	TR.taxref,
	CDR.ycon,
	CDR.ncon,
	CDR.adminrate,
	CDR.employrate,
	CDR.taxable,
	CDR.admindenominator,
	CDR.employdenominator,
	CDR.taxabledenominator,
	CDR.adminnumerator,
	CDR.employnumerator,
	CDR.taxablenumerator,
	CDR.admintax,
	CDR.employtax,
	TR.taxkind
FROM wageadditiontax CDR
JOIN tax TR
	ON CDR.taxcode = TR.taxcode





GO

print '[wageadditiontaxview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatedetail_extview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatedetail_extview
GO



CREATE VIEW [mandatedetail_extview]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mankind,
	idinv,
	codeinv,
	inventorytree,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	assetkind,
	start,
	stop,
	idexp_taxable,
	idexp_iva,	
	taxable_euro,
	iva_euro,
	rowtotal,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt,
	idaccmotive,
	codemotive,
	idaccmotiveannulment,
	codemotiveannulment,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	competencystart,
	competencystop,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	toinvoice,
	exchangerate,
	description,
	linkedtoasset,
	notlinkedtoasset,
	linkedtoinvoice,
	notlinkedtoinvoice,
	flagactivity,
	ivanotes,
	idlist,
	intcode,
	idunit,		
	idpackage,	
	unitsforpackage,	
	npackage,
	idstore,
	store,
	flagto_unload,
	cigcode,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	epkind
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.rownum,
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
 	mandatedetail.idreg,
  	registry.title,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	mandatedetail.taxable,
	mandatedetail.taxrate,
	mandatedetail.tax,
  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva,
 	    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number)* 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		),
	ROUND(mandatedetail.tax,2),
	ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number)* 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)+
	ROUND(mandatedetail.tax,2),
	mandatedetail.idupb,
	upb.codeupb,
	upb.title,
	mandatedetail.cu,
	mandatedetail.ct,
	mandatedetail.lu,
	mandatedetail.lt,
	mandatedetail.idaccmotive,
	accmotive.codemotive,
	mandatedetail.idaccmotiveannulment,
	accmotiveannulment.codemotive,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	mandatedetail.competencystart,
	mandatedetail.competencystop,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandate.exchangerate,
	mandate.description,
	-- linkedtoasset
	ISNULL(
		(SELECT SUM(number) FROM assetacquire AC
		WHERE AC.idmankind = mandatedetail.idmankind
			AND AC.yman = mandatedetail.yman
			AND AC.nman = mandatedetail.nman
			AND AC.rownum = mandatedetail.rownum)
	,0),
	-- notlinkedtoasset
	ISNULL(mandatedetail.npackage,mandatedetail.number) -
	ISNULL(
		(SELECT SUM(number) FROM assetacquire AC
		WHERE AC.idmankind = mandatedetail.idmankind
			AND AC.yman = mandatedetail.yman
			AND AC.nman = mandatedetail.nman
			AND AC.rownum = mandatedetail.rownum)
	,0),
	-- linkedtoinvoice
	ISNULL(
		(SELECT  SUM (iv.number)
	FROM (SELECT DISTINCT ISNULL(npackage,number) as number,idmankind,yman,nman,manrownum,idgroup
		FROM invoicedetail) 
		AS iv
	WHERE mandatedetail.idmankind = iv.idmankind
		AND mandatedetail.yman = iv.yman
		AND mandatedetail.nman = iv.nman
		AND mandatedetail.rownum = iv.manrownum)
	,0),
	-- notlinkedtoinvoice
	ISNULL(mandatedetail.npackage,mandatedetail.number) -
	ISNULL(
		(SELECT  SUM (iv.number)
	FROM (SELECT DISTINCT ISNULL(npackage,number) as number,idmankind,yman,nman,manrownum,idgroup
		FROM invoicedetail) 
		AS iv
	WHERE mandatedetail.idmankind = iv.idmankind
		AND mandatedetail.yman = iv.yman
		AND mandatedetail.nman = iv.nman
		AND mandatedetail.rownum = iv.manrownum)
	,0),
	mandatedetail.flagactivity,
	mandatedetail.ivanotes,
	mandatedetail.idlist,
	list.intcode,
	mandatedetail.idunit,		
	mandatedetail.idpackage,	
	mandatedetail.unitsforpackage,	
	mandatedetail.npackage,
	mandate.idstore,
	store.description,	
	mandatedetail.flagto_unload,
	isnull(mandatedetail.cigcode, mandate.cigcode),
	COALESCE (mandate.idsor01,mandatekind.idsor01,upb.idsor01),
	COALESCE (mandate.idsor02,mandatekind.idsor02,upb.idsor02),
	COALESCE (mandate.idsor03,mandatekind.idsor03,upb.idsor03),
	COALESCE (mandate.idsor04,mandatekind.idsor04,upb.idsor04),
	COALESCE (mandate.idsor05,mandatekind.idsor05,upb.idsor05),
	mandatedetail.epkind
FROM mandatedetail with (nolock)
JOIN mandatekind  with (nolock)
	ON mandatekind.idmankind = mandatedetail.idmankind
JOIN ivakind with (nolock)
	ON ivakind.idivakind = mandatedetail.idivakind
LEFT JOIN inventorytree with (nolock)
	ON inventorytree.idinv = mandatedetail.idinv
JOIN mandate with (nolock)
	ON mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
	AND mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN registry with (nolock)
	ON registry.idreg = mandatedetail.idreg
LEFT OUTER JOIN upb with (nolock)
	ON upb.idupb = mandatedetail.idupb
LEFT OUTER JOIN accmotive with (nolock)
	ON accmotive.idaccmotive = mandatedetail.idaccmotive
LEFT OUTER JOIN accmotive accmotiveannulment with (nolock)
	ON accmotiveannulment.idaccmotive = mandatedetail.idaccmotiveannulment
LEFT OUTER JOIN sorting sorting1 with (nolock)
	ON sorting1.idsor = mandatedetail.idsor1
LEFT OUTER JOIN sorting sorting2 with (nolock)
	ON sorting2.idsor = mandatedetail.idsor2
LEFT OUTER JOIN sorting sorting3 with (nolock)
	ON sorting3.idsor = mandatedetail.idsor3
LEFT OUTER JOIN list  with (nolock)
	ON list.idlist = mandatedetail.idlist
LEFT OUTER JOIN store with (nolock)
	ON store.idstore = mandate.idstore



GO

print '[mandatedetail_extview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'clawbacksetupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW clawbacksetupview
GO


CREATE              VIEW clawbacksetupview 
(
	idclawback,
	clawback,
	clawbackref,
	ayear,
	clawbackfinance,
	codefin,
	finance,
	idaccmotive,
	codemotive,
	accmotive,
	cu,
	ct,
	lu,
	lt
)
  AS SELECT
	clawbacksetup.idclawback,
	clawback.description,
	clawback.clawbackref,
	clawbacksetup.ayear,
	clawbacksetup.clawbackfinance,
	fin.codefin,
	fin.title,
	clawbacksetup.idaccmotive,
	accmotive.codemotive,
	accmotive.title,  
	clawbacksetup.cu,
	clawbacksetup.ct,
	clawbacksetup.lu,
	clawbacksetup.lt
FROM clawbacksetup
JOIN clawback
	ON clawback.idclawback = clawbacksetup.idclawback
LEFT OUTER JOIN fin
	ON fin.idfin = clawbacksetup.clawbackfinance
LEFT OUTER JOIN accmotive
	ON accmotive.idaccmotive = clawbacksetup.idaccmotive





GO

print 'clawbacksetupview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandatedetailtoinvoice') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandatedetailtoinvoice
GO


CREATE  VIEW [mandatedetailtoinvoice]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mandatekind,
	idcurrency,
	codecurrency,
	idman,
	flagintracom,
	codeinv,
	inventorytree,
	idreg,
	registry,
	detaildescription,
	ordered,
	invoiced,
	residual,
	taxrate,
	taxable,
	tax,
	discount,
	assetkind,
	start,
	stop,
	idupb,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	competencystart,
	competencystop,
	toinvoice,
	linktoinvoice,
	linktoasset,
	multireg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	va3type,
	idstore,
	store,
	flagto_unload,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	epkind,exchangerate
)
AS SELECT 	
	mandatedetail.idmankind,
	mandatedetail.yman, 
	mandatedetail.nman, 
	mandatedetail.rownum, 
	mandatedetail.idgroup,
	mandatekind.description,
	mandate.idcurrency,
	currency.codecurrency,
	mandate.idman,
	mandate.flagintracom,
	inventorytree.codeinv, 
	inventorytree.description,
	isnull(mandate.idreg,mandatedetail.idreg),
	CASE
		WHEN (mandate.idreg is not null) THEN (select title from
						registry 
						where idreg= mandate.idreg)
		WHEN (mandatedetail.idreg is not null) THEN (select title from
						registry 
						where idreg= mandatedetail.idreg)
		ELSE null
	END,
	mandatedetail.detaildescription, 
	ISNULL(mandatedetail.npackage,mandatedetail.number),	-- ordered
	ISNULL(
	(SELECT SUM(iv.npackage)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  invoicedetail.idgroup as invidgroup,
				      isnull(invoicedetail.npackage,invoicedetail.number) as npackage,invoicedetail.idmankind,invoicedetail.yman,
				      invoicedetail.nman, mandatedetail.idgroup as manidgroup
		FROM invoicedetail 
        JOIN mandatedetail mandatedetail2
		  ON invoicedetail.idmankind = mandatedetail2.idmankind AND
		     invoicedetail.yman = mandatedetail2.yman AND
	         invoicedetail.nman = mandatedetail2.nman AND
		     invoicedetail.manrownum = mandatedetail2.rownum 
		    WHERE  invoicedetail.idmankind = mandatedetail.idmankind AND
	               invoicedetail.yman = mandatedetail.yman AND
		           invoicedetail.nman = mandatedetail.nman AND
			       mandatedetail2.idgroup = mandatedetail.idgroup 
			) AS iv )  ,0),	-- invoiced
	ISNULL(mandatedetail.npackage, mandatedetail.number) 
	- 
	ISNULL(
	(SELECT SUM(iv.npackage)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  invoicedetail.idgroup as invidgroup,
				      isnull(invoicedetail.npackage,invoicedetail.number) as npackage,invoicedetail.idmankind,invoicedetail.yman,
				      invoicedetail.nman, mandatedetail.idgroup as manidgroup
		FROM invoicedetail 
        JOIN mandatedetail mandatedetail2
		  ON invoicedetail.idmankind = mandatedetail2.idmankind AND
		     invoicedetail.yman = mandatedetail2.yman AND
	         invoicedetail.nman = mandatedetail2.nman AND
		     invoicedetail.manrownum = mandatedetail2.rownum 
		    WHERE  invoicedetail.idmankind = mandatedetail.idmankind AND
	               invoicedetail.yman = mandatedetail.yman AND
		           invoicedetail.nman = mandatedetail.nman AND
			       mandatedetail2.idgroup = mandatedetail.idgroup 
			) AS iv )  ,0), 	-- residual
	mandatedetail.taxrate,
	mandatedetail.taxable,
	mandatedetail.tax,
	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idupb,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	mandatedetail.idaccmotive,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.competencystart,
	mandatedetail.competencystop,
	mandatedetail.toinvoice,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandatedetail.va3type,
	mandate.idstore,
	store.description,
	mandatedetail.flagto_unload,
	mandate.idsor01,mandate.idsor02,mandate.idsor03,mandate.idsor04,mandate.idsor05,
	mandatedetail.epkind,mandate.exchangerate
FROM mandatedetail with (nolock)
JOIN mandatekind  with (nolock)
	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN inventorytree  with (nolock)
	ON inventorytree.idinv = mandatedetail.idinv
INNER JOIN mandate   with (nolock)
	ON mandate.idmankind = mandatedetail.idmankind
	AND mandate.yman = mandatedetail.yman
	AND mandate.nman = mandatedetail.nman
LEFT OUTER JOIN currency  with (nolock)
	ON mandate.idcurrency = currency.idcurrency
JOIN ivakind  with (nolock)
	ON ivakind.idivakind = mandatedetail.idivakind
LEFT OUTER JOIN mandatestatus  with (nolock)
	ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN store   with (nolock)
	ON store.idstore = mandate.idstore
WHERE mandatedetail.stop is null





GO

print '[mandatedetailtoinvoice] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'mandateavailable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW mandateavailable
GO


CREATE   VIEW [mandateavailable]
(
	idmankind,
	yman,
	nman,
	mankind,
	registry,
	idupb,
	description,
	doc,
	docdate,
	adate,
	idman,
	manager,
	taxabletotal,
	ivatotal,
	linkedtotal,
	residual,
	active,
	isrequest,
	idsor01,idsor02,idsor03,idsor04,idsor05
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatekind.description,
	CASE
	WHEN mandate.idreg is not null THEN (select title from
					registry 
					where idreg= mandate.idreg)
	WHEN mandatedetail.idreg is not null THEN (select title from
					registry 
					where idreg= mandatedetail.idreg)
	ELSE null
	END,
	mandatedetail.idupb,
	mandate.description,
	mandate.doc,
	mandate.docdate,
	mandate.adate,
	mandate.idman,
	manager.title,
	isnull(totmandateview.taxabletotal,0),
	isnull(totmandateview.ivatotal,0),
	
	--totale movimenti = somma (amount) del join di expensemandate con  expense + 
             --                             somma (amount) del join di expensemandate con expensevar
	convert(decimal(19,2),ROUND(
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
	FROM expensemandate mov 
	JOIN expense s 
	ON s.idexp = mov.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear
  	ON expensetotal_firstyear.idexp = s.idexp
  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear		
	WHERE mov.idmankind = mandate.idmankind
	AND mov.yman = mandate.yman
	AND mov.nman = mandate.nman)
	 +
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM expensemandate mov 
	JOIN expense s 
	ON s.idexp = mov.idexp
	JOIN expensevar v 
	ON v.idexp = mov.idexp
	WHERE mov.idmankind = mandate.idmankind
	AND mov.yman = mandate.yman
	AND mov.nman = mandate.nman)
	,2)),
	--residuo = totaleimponibile + totaleiva - totale movimenti
	CONVERT(decimal(19,2),ROUND(
	ISNULL(totmandateview.taxabletotal, 0.0) +
	ISNULL(totmandateview.ivatotal, 0.0) -
	(SELECT ISNULL(SUM(expenseyear_starting.amount), 0.0) 
	FROM expensemandate mov 
	JOIN expense s 
	ON s.idexp = mov.idexp
	LEFT OUTER JOIN expensetotal expensetotal_firstyear
  	ON expensetotal_firstyear.idexp = s.idexp
  	AND ((expensetotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear expenseyear_starting
	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  	AND expenseyear_starting.ayear = expensetotal_firstyear.ayear		
	WHERE mov.idmankind = mandate.idmankind
	AND mov.yman = mandate.yman
	AND mov.nman = mandate.nman) -
	(SELECT ISNULL(SUM(v.amount), 0.0) 
	FROM expensemandate mov 
	JOIN expense s 
	ON s.idexp = mov.idexp
	JOIN expensevar v 
	ON v.idexp = mov.idexp
	WHERE mov.idmankind = mandate.idmankind
	AND mov.yman = mandate.yman
	AND mov.nman = mandate.nman)
	,2)),
	mandate.active,
	mandatekind.isrequest,
	mandate.idsor01,mandate.idsor02,mandate.idsor03,mandate.idsor04,mandate.idsor05
FROM mandatedetail with (nolock)
JOIN mandate  with (nolock)
  	ON mandatedetail.idmankind = mandate.idmankind
	AND mandatedetail.yman = mandate.yman
  	AND mandatedetail.nman = mandate.nman
JOIN mandatekind with (nolock)
	ON mandate.idmankind = mandatekind.idmankind
LEFT OUTER JOIN totmandateview  with (nolock)
	ON totmandateview.idmankind = mandate.idmankind
	AND totmandateview.yman = mandate.yman
	AND totmandateview.nman = mandate.nman
LEFT OUTER JOIN manager  with (nolock)
	ON manager.idman = mandate.idman
--JOIN registry (NOLOCK) ON registry.idreg = mandate.idreg
	--where (ordinegenerico.flagutilizzabile is null) or (ordinegenerico.flagutilizzabile='S')
GROUP BY mandatedetail.idmankind,mandate.idmankind, 
	mandatedetail.yman,mandate.yman,
	mandate.nman,mandatedetail.nman,
	mandate.idreg,mandatedetail.idreg,
	mandatedetail.idupb,
	mandatekind.description,mandate.description,
	mandate.doc,mandate.docdate,mandate.adate,mandate.active,
	mandate.idman,manager.title,
	taxabletotal,ivatotal,
	mandatekind.isrequest,
	mandate.idsor01,mandate.idsor02,mandate.idsor03,mandate.idsor04,mandate.idsor05

GO

print '[mandateavailable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationview
GO


CREATE  VIEW itinerationview 
(
	iditineration,
	yitineration,
	nitineration,
	description,
	idreg,
	registry,
	idser,
	service,
	codeser,
	admincarkmcost,
	owncarkmcost,
	footkmcost,
	admincarkm,
	owncarkm,
	footkm,
	authorizationdate,
	start,
	stop,
	adate,
	grossfactor,
	netfee,
	totalgross,
	total,
	totadvance,
	location,
	cu,
	ct,
	lu,
	lt,
	active,
	completed,
	iditinerationstatus,
	itinerationstatus,
	idaccmotive,
	codemotive,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	idupb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	idsor1,
	idsor2,
	idsor3,
	txt,
	rtf,
	position,
	incomeclass,
	incomeclassvalidity,
	extmatricula,
	foreigngroupnumber,
	idregistrylegalstatus,
	applierannotations,
	webwarn,
	idman,
	manager,
	flagweb,
	idauthmodel,
	authmodel,
	authmodtitle,
	statusimage,
	listingorder,
	authneeded,
	authdoc,
	authdocdate,
	noauthreason,
	clause_accepted,
	vehicle_info,
	vehicle_motive,
	advancelinked,
	totlinked,
	totresidual
)
AS SELECT
	itineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	itineration.description,
	itineration.idreg,
	registry.title,
	itineration.idser,
	service.description,
	service.codeser,
	itineration.admincarkmcost,
	itineration.owncarkmcost,
	itineration.footkmcost,
	itineration.admincarkm,
	itineration.owncarkm,
	itineration.footkm,
	itineration.authorizationdate,
	itineration.start,
	itineration.stop,
	itineration.adate,
	itineration.grossfactor,
	itineration.netfee,
	itineration.totalgross,
	itineration.total,
	itineration.totadvance,
	itineration.location,
	itineration.cu,
	itineration.ct,
	itineration.lu,
	itineration.lt,
	itineration.active,
	itineration.completed,
	itineration.iditinerationstatus,
	itinerationstatus.description,
	itineration.idaccmotive,
	AM.codemotive,
	itineration.idaccmotivedebit,
	DB.codemotive,
	itineration.idaccmotivedebit_crg,
	CRG.codemotive,
	itineration.idaccmotivedebit_datacrg,
	itineration.idupb,
	isnull(itineration.idsor01,UPB.idsor01),
	isnull(itineration.idsor02,UPB.idsor02),
	isnull(itineration.idsor03,UPB.idsor03),
	isnull(itineration.idsor04,UPB.idsor04),
	isnull(itineration.idsor05,UPB.idsor05),
	itineration.idsor1,
	itineration.idsor2,
	itineration.idsor3,
	itineration.txt,
	itineration.rtf,
	position.description,
	L1.incomeclass,
	L1.incomeclassvalidity,
	registry.extmatricula,
	foreigngroupruledetail.foreigngroupnumber,
	itineration.idregistrylegalstatus,
	itineration.applierannotations,
	itineration.webwarn,
	itineration.idman,
	manager.title,
	itineration.flagweb,
	itineration.idauthmodel,
	authmodel.description,
	authmodel.title,
	(case when itineration.iditinerationstatus=1 then '<center><img src="Immagini/bozza.png" title="Bozza" alt="Bozza"/></center>'
		  when itineration.iditinerationstatus=2 then '<center><img src="Immagini/richiesta.png" title="Richiesta" alt="Richiesta"/></center>'
		  when itineration.iditinerationstatus=3 then '<center><img src="Immagini/dacorreggere.png" title="Da Correggere" alt="Da Correggere"/></center>'
		  when itineration.iditinerationstatus=4 then '<center><img src="Immagini/inserito.png" title="Inserito" alt="Inserito"/></center>'
		  when itineration.iditinerationstatus=5 then '<center><img src="Immagini/inapprovazione.png" title="Autorizzazione" alt="In Fase di Approvazione"/></center>'
		  when itineration.iditinerationstatus=6 then '<center><img src="Immagini/approvato.png" title="Approvato" alt="Approvato"/></center>'
		  when itineration.iditinerationstatus=7 then '<center><img src="Immagini/annullato.png" title="Annullato" alt="Annullato"/></center>'
		  when itineration.iditinerationstatus=8 then '<center><img src="Immagini/inapprovazione.png" title="Autorizzazione rendiconto" alt="In Fase di Approvazione"/></center>'
		  when itineration.iditinerationstatus=null then ''
		  end
		  ),
	itinerationstatus.listingorder,
	itineration.authneeded,
	itineration.authdoc,
	itineration.authdocdate,
	itineration.noauthreason,
	itineration.clause_accepted,
	itineration.vehicle_info,
	itineration.vehicle_motive,
	IR.linkedangir+IR.linkedanpag, -- advancelinked
	(case when linkedsaldo>0 then IR.linkedsaldo+IR.linkedanpag else IR.linkedanpag+IR.linkedangir end) ,--totlinked,
	 IR.totalgross-(case when linkedsaldo>0 then IR.linkedsaldo+IR.linkedanpag else IR.linkedanpag+IR.linkedangir end)	--totresidual
	
FROM itineration with (nolock)
JOIN registry  with (nolock)
	ON registry.idreg = itineration.idreg
LEFT OUTER JOIN service  with (nolock)
	ON service.idser = itineration.idser
LEFT OUTER JOIN legalstatuscontract L1 with (nolock)
	ON L1.idreg = itineration.idreg 
	AND L1.idregistrylegalstatus = itineration.idregistrylegalstatus 
	--AND L1.start= (SELECT MAX(start) from legalstatuscontract L2 where L2.idreg=L1.idreg and L2.start<=itineration.start) 
LEFT OUTER JOIN position with (nolock)
	on position.idposition=L1.idposition
LEFT OUTER JOIN foreigngrouprule with (nolock)
	on idforeigngrouprule = (select max(idforeigngrouprule) from foreigngrouprule where start <= itineration.adate)
LEFT OUTER JOIN foreigngroupruledetail with (nolock)
	on foreigngroupruledetail.idforeigngrouprule=foreigngrouprule.idforeigngrouprule
	and foreigngroupruledetail.idposition=L1.idposition
	and L1.incomeclass between foreigngroupruledetail.minincomeclass and foreigngroupruledetail.maxincomeclass
LEFT OUTER JOIN accmotive AM with (nolock)
	ON AM.idaccmotive = itineration.idaccmotive
LEFT OUTER JOIN accmotive DB with (nolock)
	ON DB.idaccmotive =  itineration.idaccmotivedebit
LEFT OUTER JOIN accmotive CRG with (nolock)
	ON CRG.idaccmotive = itineration.idaccmotivedebit_crg
LEFT OUTER JOIN itinerationstatus  with (nolock)
	ON itinerationstatus.iditinerationstatus= itineration.iditinerationstatus
LEFT OUTER JOIN manager  with (nolock)
	ON manager.idman = itineration.idman
LEFT OUTER JOIN authmodel  with (nolock)
	ON authmodel.idauthmodel = itineration.idauthmodel
LEFT OUTER JOIN upb  with (nolock)
	ON upb.idupb = itineration.idupb
join itinerationresidual  IR with (nolock)
	on IR.iditineration= itineration.iditineration



GO

print 'itinerationview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'showcasedetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW showcasedetailview
GO

CREATE   view showcasedetailview
as
(
	select showcasedetail.idshowcase as idshowcase,
		   showcase.idstore as idstore,
		   stocktotalview.store as store,
		   showcasedetail.idlist as idlist,
		   stocktotalview.list as list,
		   stocktotalview.intcode as intcode,
		   stocktotalview.idlistclass as idlistclass,
		   stocktotalview.codelistclass as codelistclass,
		   stocktotalview.listclass as listclass,
		   stocktotalview.number as number,
		   stocktotalview.ordered as ordered,
		   stocktotalview.booked as booked
	from showcasedetail join showcase on (showcasedetail.idshowcase=showcase.idshowcase)
						join stocktotalview on (showcasedetail.idlist=stocktotalview.idlist and showcase.idstore=stocktotalview.idstore)
)

GO

print 'showcasedetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'creditproceedsview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW creditproceedsview
GO

CREATE VIEW [creditproceedsview] 
	(
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	ayear,
	credit,
	proceeds,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	description
	)
	AS SELECT
	creditpart.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	allfinlookup.newidfin,
	fin.codefin,
	fin.title,
	creditpart.idupb,
	upb.codeupb,
	upb.title,
	incomeyear.ayear,
	sum(creditpart.amount),
	isnull( (select sum(proceedspart.amount)   from  incomelink (NOLOCK) 
					join   proceedspart (NOLOCK)        
							ON incomelink.idchild=proceedspart.idinc		
							AND proceedspart.idfin in (select newidfin from allfinlookup AA where AA.oldidfin = creditpart.idfin)
						where  incomelink.idparent=creditpart.idinc)
						
			,0),
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	creditpart.description
	FROM creditpart (NOLOCK)
	JOIN income (NOLOCK)
		ON income.idinc = creditpart.idinc
	LEFT OUTER JOIN incomeyear (nolock)
		ON income.idinc = incomeyear.idinc
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase	
	JOIN allfinlookup (NOLOCK)
		ON allfinlookup.oldidfin = creditpart.idfin
		AND allfinlookup.ayear= incomeyear.ayear
	JOIN fin (NOLOCK)
		ON fin.idfin= allfinlookup.newidfin
	JOIN upb (NOLOCK)
		ON upb.idupb = creditpart.idupb
	
	group by 
	creditpart.idinc,	income.nphase,	incomephase.description,	income.ymov,
	income.nmov,	allfinlookup.newidfin,	fin.codefin,	fin.title,
		creditpart.idupb,	upb.codeupb,	upb.title,	incomeyear.ayear,
		upb.idsor01,	upb.idsor02,	upb.idsor03,	upb.idsor04,	upb.idsor05,
		creditpart.idfin, creditpart.description
			
	


GO

print '[creditproceedsview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'proceedstransmissionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW proceedstransmissionview
GO


CREATE    VIEW proceedstransmissionview 
	(
	kproceedstransmission,
	yproceedstransmission,
	nproceedstransmission,
	idman,
	manager,
	idtreasurer,
	codetreasurer,
	transmissiondate,
	total,
	transmissionkind,
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
	proceedstransmission.kproceedstransmission,
	proceedstransmission.yproceedstransmission,
 	proceedstransmission.nproceedstransmission,
	proceedstransmission.idman,
	manager.title,
	proceedstransmission.idtreasurer,
	treasurer.codetreasurer,
 	 proceedstransmission.transmissiondate,
	ISNULL((SELECT SUM(ISNULL(total,0)) FROM proceedsview d 
	WHERE d.kproceedstransmission = proceedstransmission.kproceedstransmission),0),
	proceedstransmission.transmissionkind,
	treasurer.idsor01,
	treasurer.idsor02,
	treasurer.idsor03,
	treasurer.idsor04,
	treasurer.idsor05,
	proceedstransmission.cu,
	proceedstransmission.ct,
	proceedstransmission.lu,
	proceedstransmission.lt
	FROM proceedstransmission 
	LEFT OUTER JOIN manager 
	ON manager.idman = proceedstransmission.idman
	LEFT OUTER JOIN treasurer 
	ON treasurer.idtreasurer = proceedstransmission.idtreasurer



GO

print 'proceedstransmissionview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationauthview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationauthview
GO



CREATE   view [itinerationauthview] as
(
select  
       itinerationview.iditineration as iditineration,
	   itinerationview.statusimage as statusimage,
	   itinerationview.nitineration as nitineration,
	   itinerationview.yitineration as yitineration,
	   (case when itinerationauthagency.flagstatus='S' then 'Approvata'
		when itinerationauthagency.flagstatus='D' then 'Da Definire'
		when itinerationauthagency.flagstatus='N' then 'Non Approvata' end) as authstatus,
	   (case when itinerationauthagency.flagstatus='S' then '<center><img src="Immagini\tl_green.png" title="Approvata" alt="Approvata" ></center>'
		when itinerationauthagency.flagstatus='N' then '<center><img src="Immagini\tl_red.png" title="Non Approvata" alt="Non Approvata"></center>'
		when itinerationauthagency.flagstatus='D' then '<center><img src="Immagini\tl_yellow.png" title="Da Definire" alt="Da Definire"></center>'
		end) as authstatusimage,	
       itinerationview.description as description,
	   itinerationview.idreg as idreg,
	   itinerationview.registry as registry,
       itinerationview.start as start,
       itinerationview.stop as stop,
	   itinerationview.adate as adate,
	   itinerationview.total as total,
	   (
			select sum(isnull(itinerationrefund.amount,0)) from itinerationrefund 
			where itinerationrefund.iditineration = itinerationview.iditineration and itinerationrefund.flagadvancebalance='A'
		) as totadvance,
       (select count(*) from itinerationlap where itinerationlap.iditineration=itinerationview.iditineration) as lapcount,
	   itinerationview.idman as idman,
	   manager.title as managertitle,
	   itinerationview.idauthmodel as idauthmodel,
	   itinerationauthagency.idauthagency as idauthagency,
	   authagency.title as authagencytitle,
	   authagency.priority as priority,
	   authagency.ismanager as ismanager,
	   itinerationauthagency.flagstatus as flagstatus,
	   itinerationview.authorizationdate as authorizationdate,
	   itinerationview.iditinerationstatus as iditinerationstatus,
	   itinerationview.location as location,
	   itinerationview.idsor01,
	   itinerationview.idsor02,
	   itinerationview.idsor03,
	   itinerationview.idsor04,
	   itinerationview.idsor05
from itinerationview 
join 
	itinerationstatus
on 
	itinerationview.iditinerationstatus=itinerationstatus.iditinerationstatus
join
    authmodel
on
	itinerationview.idauthmodel=authmodel.idauthmodel
join
	itinerationauthagency
on
    itinerationview.iditineration=itinerationauthagency.iditineration
join authagency
on 
    itinerationauthagency.idauthagency=authagency.idauthagency
join manager
on 
itinerationview.idman=manager.idman
)




GO

print '[itinerationauthview] OK'

GO
