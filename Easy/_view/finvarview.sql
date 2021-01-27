
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


-- CREAZIONE VISTA finvarview
IF EXISTS(select * from sysobjects where id = object_id(N'[finvarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finvarview]
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
	moneytransfer,
	varflag, 
	annotation
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
	finvar.moneytransfer,
	finvar.varflag,
	finvar.annotation
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

 
