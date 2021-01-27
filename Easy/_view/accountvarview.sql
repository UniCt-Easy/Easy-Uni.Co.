
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


-- CREAZIONE VISTA accountvarview
IF EXISTS(select * from sysobjects where id = object_id(N'[accountvarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [accountvarview]
GO

--setuser 'amministrazione'
--setuser 'amm'
--select * from accountvarview
--clear_table_info'accountvarview'
CREATE         VIEW [accountvarview]
(
	yvar,
	nvar,
	adate,
	description,
	enactment,
	enactmentdate,
	nenactment,
	variationkind,
	variationkinddescr,
	aumento,
	diminuzione,
	saldo,
	amount2,
	amount3,
	amount4,
	amount5,
	ct,
	cu,
	lt,
	lu,
	idaccountvarstatus,
	accountvarstatus,
	reason,
	idman,
	manager,
	statusimage,
	listingorder,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idenactment,
	yenactment,
	enactmentnumber,
	flag,
	presunto
)
AS SELECT
	accountvar.yvar,
	accountvar.nvar,
	accountvar.adate,
	accountvar.description,
	accountvar.enactment,
	accountvar.enactmentdate,
	accountvar.nenactment,
	accountvar.variationkind,
	variationkind.description,
	--Aumento
	ISNULL(
		(SELECT SUM(amount)
		FROM accountvardetail D
		JOIN account F
			ON D.idacc = F.idacc
		WHERE D.yvar = accountvar.yvar
			AND D.nvar = accountvar.nvar
			AND (F.flagaccountusage & 128)<>0)
	,0),
	--Diminuziome 
	ISNULL(
		(SELECT SUM(amount)
		FROM accountvardetail D
		JOIN account F
			ON D.idacc = F.idacc
		WHERE D.yvar = accountvar.yvar
			AND D.nvar = accountvar.nvar
			AND (F.flagaccountusage & 320)<>0)
	,0),
	--Saldo	= aumento - diminuzione
	/*Aumento*/
	ISNULL(
		(SELECT SUM(amount)
		FROM accountvardetail D
		JOIN account F
			ON D.idacc = F.idacc
		WHERE D.yvar = accountvar.yvar
			AND D.nvar = accountvar.nvar
			AND (F.flagaccountusage & 128)<>0)
	,0)
	-
	/*Diminuzione*/
	ISNULL(
		(SELECT SUM(amount)
		FROM accountvardetail D
		JOIN account F
			ON D.idacc = F.idacc
		WHERE D.yvar = accountvar.yvar
			AND D.nvar = accountvar.nvar
			AND (F.flagaccountusage & 320)<>0)
	,0),
	ISNULL( 
		(SELECT SUM(case when (F.flagaccountusage & 128)<>0 then D.amount2 else -D.amount2 end )
		FROM accountvardetail D
		JOIN account F
			ON D.idacc = F.idacc
		WHERE D.yvar = accountvar.yvar
			AND D.nvar = accountvar.nvar),0),

	ISNULL( 
		(SELECT SUM(case when (F.flagaccountusage & 128)<>0 then D.amount3 else -D.amount3 end )
		FROM accountvardetail D
		JOIN account F
			ON D.idacc = F.idacc
		WHERE D.yvar = accountvar.yvar
			AND D.nvar = accountvar.nvar),0),

	ISNULL( 
		(SELECT SUM(case when (F.flagaccountusage & 128)<>0 then D.amount4 else -D.amount4 end )
		FROM accountvardetail D
		JOIN account F
			ON D.idacc = F.idacc
		WHERE D.yvar = accountvar.yvar
			AND D.nvar = accountvar.nvar),0),

	ISNULL( 
		(SELECT SUM(case when (F.flagaccountusage & 128)<>0 then D.amount5 else -D.amount5 end )
		FROM accountvardetail D
		JOIN account F
			ON D.idacc = F.idacc
		WHERE D.yvar = accountvar.yvar
			AND D.nvar = accountvar.nvar),0),

	accountvar.ct,
	accountvar.cu,
	accountvar.lt,
	accountvar.lu,
	accountvar.idaccountvarstatus,
	accountvarstatus.description,
	accountvar.reason,
	accountvar.idman,
	manager.title,
	(case when accountvar.idaccountvarstatus=1 then '<center><img src="Immagini/bozza.png" title="Bozza" alt="Bozza"/></center>'
		  when accountvar.idaccountvarstatus=2 then '<center><img src="Immagini/richiesta.png" title="Richiesta" alt="Richiesta"/></center>'
		  when accountvar.idaccountvarstatus=3 then '<center><img src="Immagini/dacorreggere.png" title="Da Correggere" alt="Da Correggere"/></center>'
		  when accountvar.idaccountvarstatus=4 then '<center><img src="Immagini/inserito.png" title="Inserito" alt="Inserito"/></center>'
		  when accountvar.idaccountvarstatus=5 then '<center><img src="Immagini/approvato.png" title="Approvato" alt="Approvato"/></center>'
		  when accountvar.idaccountvarstatus=6 then '<center><img src="Immagini/annullato.png" title="Annullato" alt="Annullato"/></center>'
		  end
		  ),
	accountvarstatus.listingorder,
	accountvar.idsor01,
	accountvar.idsor02,
	accountvar.idsor03,
	accountvar.idsor04,
	accountvar.idsor05,
	accountvar.idenactment,
	accountenactment.yenactment,
	accountenactment.nenactment,
	accountvar.flag,
	case when accountvar.flag& 1 <>0 then 'S' else 'N' end
FROM accountvar with (nolock)
JOIN variationkind with (nolock)
	ON variationkind.idvariationkind = accountvar.variationkind
LEFT OUTER JOIN accountvarstatus with (nolock)
	ON accountvarstatus.idaccountvarstatus = accountvar.idaccountvarstatus
LEFT OUTER JOIN manager with (nolock)
	ON manager.idman = accountvar.idman
LEFT OUTER JOIN accountenactment with (nolock)
	ON accountenactment.idenactment = accountvar.idenactment



GO
