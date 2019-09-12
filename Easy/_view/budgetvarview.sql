-- CREAZIONE VISTA finvarview
IF EXISTS(select * from sysobjects where id = object_id(N'[budgetvarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [budgetvarview]
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
