-- CREAZIONE VISTA invoicekindyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicekindyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicekindyearview]
GO



CREATE                              VIEW [invoicekindyearview]
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
CROSS JOIN iva_prorata IPR WITH (NOLOCK)		--ON IPR.ayear = IKY.ayear
LEFT OUTER JOIN iva_mixed IM WITH (NOLOCK)			ON IM.ayear = IPR.ayear
LEFT OUTER JOIN invoicekindyear IKY WITH (NOLOCK)	ON IK.idinvkind = IKY.idinvkind
	AND IKY.ayear = IM.ayear
GO
