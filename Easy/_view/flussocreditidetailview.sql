-- CREAZIONE VISTA flussocreditidetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[flussocreditidetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [flussocreditidetailview]
GO

-- select * from flussocreditidetailview
-- clear_table_info'flussocreditidetailview'

CREATE    VIEW flussocreditidetailview
 AS
	select 
	D.idflusso,
	C.idsor01,C.idsor02,C.idsor03,C.idsor04,C.idsor05,
	C.istransmitted,
	C.docdate,
	C.idestimkind as idestimkind_main,

	
	EK.description as estimkind_det,
	D.idestimkind,D.yestim,D.nestim,
	IK.description as invoicekind,
	D.idinvkind,D.yinv, D.ninv,
	D.description,
	D.iddetail, D.importoversamento, 
	D.idupb, U.title as upb,
	D.idupb_iva, Uiva.title as upb_iva,
	D.iduniqueformcode,
	D.idreg,R.title as registry,
	D.nform,
	D.cf,
	D.iuv,
	D.annulment,
	D.stop,D.flag,
	C.datacreazioneflusso,
	A1.codemotive as causalecredito,
	A2.codemotive as casualeentroanno,
	A3.codemotive as casualepostanno,
	A4.codemotive as casualericavo,
	FM.title as causalebilentrata,
	D.competencystart,
	D.competencystop,
	D.codiceavviso, D.idunivoco, D.expirationdate,  D.p_iva
 from flussocrediti C
		join flussocreditidetail D on C.idflusso=D.idflusso
	left outer join registry R
		on R.idreg= D.idreg
	left outer join estimatekind EK
		on D.idestimkind = EK.idestimkind
	left outer join upb U
		on U.idupb = D.idupb
	left outer join upb Uiva
		on Uiva.idupb = D.idupb_iva
	left outer join invoicekind IK
		on D.idinvkind = IK.idinvkind
	left outer join accmotive A1
		on A1.idaccmotive = D.idaccmotivecredit
	left outer join accmotive A2
		on A2.idaccmotive = D.idaccmotiveundotax
	left outer join accmotive A3
		on A3.idaccmotive = D.idaccmotiveundotaxpost
	left outer join accmotive A4
		on A4.idaccmotive = D.idaccmotiverevenue
	left outer join finmotive FM
		on D.idfinmotive = FM.idfinmotive
GO
 
 