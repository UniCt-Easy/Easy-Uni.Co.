
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_rilevazioni_anac]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_rilevazioni_anac]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--setuser 'amministrazione'
--exec compute_rilevazioni_anac 2017, null
-- select * from mandateview
CREATE PROCEDURE [compute_rilevazioni_anac](
	@ayear int,
	@cigcode varchar(10)=null
)
AS BEGIN
create table #CIG(
	idmankind varchar(20),	yman smallint,	nman int,
	ycon int, ncon int,
	cigcode varchar(10),
	contractamount decimal(19,2),
	idavcp_choice varchar(10),
	idavcp int,
	description varchar(250),
	avcpchoice varchar(150),
	start_contract datetime,
	stop_contract datetime,
	numerooffertepervenute	int,
	allegati varchar(MAX),
	txt varchar(MAX)
)

if (@cigcode ='') set @cigcode = null
create table #Partecipanti(
	idmankind varchar(20), 	yman smallint,	nman int,
	ycon int ,ncon int,
	cigcode varchar(10),
	idreg int,
	title varchar(250)
)
-- Inserisce solo i partecipanti, non gli inviati.
insert into #Partecipanti(
	idmankind,yman,	nman ,	cigcode , idreg, title)
Select MD.idmankind , MD.yman, MD.nman, MD.cigcode , M.idreg, M.title
from mandateavcpdetail MD
	join mandateavcp M		on  MD.idmankind = M.idmankind and MD.yman = M.yman and MD.nman = M.nman and M.idavcp=MD.idavcp
where  MD.yman = @ayear and isnull(M.flagnonparticipating,'N')='N'
	and (MD.cigcode = @cigcode or @cigcode is null)

/*
insert into #Partecipanti(
	ycon,ncon ,	cigcode , idreg, title)
Select PD.ycon,PD.ncon, PD.cigcode , P.idreg, P.title
from profserviceavcpdetail PD
	join profserviceavcp P		on PD.ycon=PD.ycon and PD.ncon=PD.ncon
where  P.ycon = @ayear and isnull(P.flagnonparticipating,'N')='N'
	and (PD.cigcode = @cigcode or @cigcode is null)
*/


insert into #CIG(
	idmankind ,	yman ,	nman ,
	cigcode ,	contractamount ,
	idavcp_choice ,	idavcp ,	description ,	avcpchoice,
	start_contract,
	stop_contract,
	numerooffertepervenute,
	allegati)
SELECT M1.idmankind, M1.yman, M1.nman, 
	M1.cigcode, M1.contractamount, 
	M1.idavcp_choice, M1.idavcp, M1.description , avcpchoice.description,
	M1.start_contract,
	M1.stop_contract,
	(select count(*) from #Partecipanti P
	 where P.idmankind = M1.idmankind and P.yman = M1.yman and P.nman = M1.nman and P.cigcode = M1.cigcode ), -- Sommatoria dei partecipanti (non di tutti gli invitati)
	(select MA.idattachment as '@id', MA.filename from mandateattachment MA
	where MA.idmankind = M1.idmankind and MA.yman = M1.yman and MA.nman = M1.nman and MA.attachment is not null
	for xml path('Allegato'), root('Allegati'))
from mandatecig M1
left outer join  avcpchoice	on M1.idavcp_choice = avcpchoice.idavcp_choice
where M1.yman = @ayear	and (M1.cigcode = @cigcode or @cigcode is null)


/*
insert into #CIG(
	ycon,ncon , 
	cigcode ,	contractamount ,
	idavcp_choice ,	idavcp ,	description ,	avcpchoice,
	start_contract,
	stop_contract,
	numerooffertepervenute	)
SELECT P1.ycon,P1.ncon, 
	P1.cigcode, P1.contractamount, 
	P1.idavcp_choice, P1.idavcp, P1.description , avcpchoice.description,
	P1.start_contract,
	P1.stop_contract,
	(select count(*) from #Partecipanti P
		where P.ycon = P1.ycon and P.ncon = P1.ncon and P.cigcode = P1.cigcode ) -- Sommatoria dei partecipanti (non di tutti gli invitati)
from profservicecig P1
left outer join  avcpchoice	on P1.idavcp_choice = avcpchoice.idavcp_choice
where P1.ycon = @ayear	and (P1.cigcode = @cigcode or @cigcode is null)
*/



-- Salta i lotti di importo 0 collegati solo a dettagli annullati
delete from #CIG
where (contractamount = 0) 
			and (select count(*) from mandatedetail MD where MD.stop is null 
					and MD.idmankind = #CIG.idmankind and MD.yman = #CIG.yman and MD.nman = #CIG.nman  and MD.cigcode = #CIG.cigcode)=0 
			and yman is not null

delete from #CIG
where (contractamount = 0) 
			and ycon is not null
  
;WITH CTE (idmankind, yman, nman, title2)  
AS   
(SELECT DISTINCT a.idmankind, a.yman, a.nman, (SELECT '; '+ mandateavcp.title +
			CASE 
				WHEN registry.cf IS NOT NULL THEN 	' {CF:' + registry.cf + '}'
				WHEN registry.p_iva IS NOT NULL THEN  ' {P. IVA:' + registry.p_iva + '}'
				WHEN registry.foreigncf IS NOT NULL THEN  ' {CF Estero:' + registry.foreigncf + '}'
				ELSE ' ' 
			END AS [text()]
			--' {CF/Piva:'+mandateavcp.cf+'}' 
            FROM #CIG b
			join mandateavcp
				on b.idmankind = mandateavcp.idmankind and b.yman = mandateavcp.yman and b.nman = mandateavcp.nman
			join registry on mandateavcp.idreg = registry.idreg
            WHERE b.idmankind = a.idmankind and b.yman = a.yman and b.nman = a.nman

            FOR XML PATH ('')
        ) as title2
  FROM #CIG a
 ) 	
UPDATE #CIG  
	SET txt = STUFF((SELECT title2
        FROM CTE c
        WHERE c.idmankind = #CIG.idmankind and c.yman = #CIG.yman and c.nman = #CIG.nman 
        ),1,2,'')

/*
;WITH CTE (ycon,ncon, title2)  
AS   
(SELECT DISTINCT a.ycon, a.ncon, (SELECT '; '+ profserviceavcp.title AS [text()]
            FROM #CIG b
			join profserviceavcp
				on b.ycon = profserviceavcp.ycon and b.ncon = profserviceavcp.ncon 
            WHERE b.ycon = a.ycon and b.ncon = a.ncon 
            FOR XML PATH ('')
        ) as title2
  FROM #CIG a
 ) 	
UPDATE #CIG  
	SET txt = STUFF((SELECT title2
        FROM CTE c
        WHERE c.ycon = #CIG.ycon and c.ncon = #CIG.ncon 
        ),1,2,'')
*/

-- Crea questa tabella perchè deve calcolare il pagato 

create table #impegni(idexp int,	
	idmankind varchar(20),	yman smallint,	nman int,	cigcode varchar(10), 
	importoimpegnato decimal(19,2), ImponibileOrdine decimal(19,2), PagatoDelSingoloImpegno decimal(19,2))

insert into #impegni(ImponibileOrdine, idexp, idmankind, yman ,nman ,cigcode)
select sum(taxable_euro), MD.idexp_taxable, MD.idmankind, MD.yman ,MD.nman ,MD.cigcode
from mandatedetailview MD 
join #CIG G
	on MD.idmankind=G.idmankind and MD.yman = G.yman and MD.nman = G.nman and MD.cigcode = G.cigcode
where MD.idexp_taxable is not null  and MD.stop is null
group by MD.idexp_taxable, MD.idmankind, MD.yman ,MD.nman ,MD.cigcode

update #impegni set importoimpegnato = (select expenseview.curramount 
										from expenseview 
										where expenseview.idexp = #impegni.idexp and  expenseview.ayear = @ayear)

update #impegni set PagatoDelSingoloImpegno = (select isnull(sum(ET.curramount),0) as curramount
										from expense E 
										JOIN expenselink ELK		ON ELK.idparent = E.idexp  
										JOIN expenselast EL 		on  ELK.idchild = EL.idexp 
										join expensetotal ET		ON ET.idexp = EL.idexp 
										where E.idexp = #impegni.idexp)

select 
		case WHEN #cig.ycon is not null then 'prof§'+convert(varchar(4),#cig.ycon)+'§'+convert(varchar(10),#cig.ncon)
			 when #cig.yman is not null then 'man§'+#cig.idmankind+'§'+convert(varchar(4),#cig.yman)+'§'+convert(varchar(10),#cig.nman)
		end as ID,
		#CIG.cigcode as CIG,
		MK.header as 'StrutturaProponente',
		isnull(RUP_mandate.title, RUP_mankind.title) as 'RUP',
		#CIG.description as 'Oggetto',
		M.motiveassignment as 'MotivazioneAffidamento',
		convert(varchar(20),#CIG.idavcp_choice)+'-'+#CIG.avcpchoice as 'ProceduraDiScelta',
		--A.cf as 'CF',
		--A.title as 'RagioneSociale',
		replace(#CIG.txt,'; ','; <br>')  as 'ElencoDegliOperatoriInvitatiAPresentareOfferte',
		M.tenderkinddescr as 'TipoGara',
		M.publishdate as 'DataPubblicazioneGara',
		M.publishdatekinddescr as 'TipoDataPubblicazione',
		#CIG.numerooffertepervenute as 'NumeroOffertePervenute',
		M.tenderresult as 'EsitoGara',
		M.registry +
		CASE 
				WHEN registry.cf IS NOT NULL THEN 	' {CF:' + registry.cf + '}'
				WHEN registry.p_iva IS NOT NULL THEN  ' {P. IVA:' + registry.p_iva + '}'
				WHEN registry.foreigncf IS NOT NULL THEN  ' {CF Estero:' + registry.foreigncf + '}'
				ELSE ' ' 
		END  as 'Aggiudicatario',
		M.anacreduced * 100 as 'Ribasso',
		#CIG.contractamount as 'ImportoAggiudicazione',
		--Totale liquidato
		SUM(
		case when isnull(I.ImportoImpegnato,0) <>0 then
			isnull(I.PagatoDelSingoloImpegno,0) * I.ImponibileOrdine / I.ImportoImpegnato 
			else  0 end
			)
		as 'TotaleLiquidato',
		start_contract as 'DataDiEffettivoInizioLavori',
		stop_contract as 'DataDiUltimazioneLavori',
		#CIG.allegati as 'Allegati'
	from mandateview M
	join registry on registry.idreg = M.idreg
	join mandatekind MK 		on MK.idmankind = M.idmankind
	join #CIG					on M.idmankind = #CIG.idmankind	and M.yman = #CIG.yman	and M.nman = #CIG.nman
	left outer join #impegni I	on I.idmankind = #CIG.idmankind	and I.yman = #CIG.yman	and I.nman = #CIG.nman
											and I.cigcode = #CIG.cigcode
	left outer join registry RUP_mandate	on M.idreg_rupanac = RUP_mandate.idreg
	left outer join registry RUP_mankind	on MK.idreg_rupanac = RUP_mankind.idreg
	group by #CIG.cigcode, MK.header,isnull(RUP_mandate.title, RUP_mankind.title),
		#CIG.description, M.motiveassignment, #CIG.avcpchoice, #CIG.txt, #CIG.numerooffertepervenute, M.tenderresult,
		M.registry, M.anacreduced,	#CIG.contractamount,
		start_contract, stop_contract,#cig.ycon,#cig.ncon,#cig.yman,#cig.nman,#cig.idmankind,#CIG.idavcp_choice,
		M.tenderkinddescr,M.publishdate,#CIG.allegati,M.publishdatekinddescr,registry.cf, registry.p_iva,registry.foreigncf
	order by #CIG.cigcode

END

GO

 
