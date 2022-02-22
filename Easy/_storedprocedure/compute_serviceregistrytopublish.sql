
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_serviceregistrytopublish]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_serviceregistrytopublish]
GO

/****** Object:  StoredProcedure [compute_serviceregistrytopublish]    Script Date: 07/10/2014 09.34.22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- exec  compute_serviceregistrytopublish 2015,'C'
 
/*
Aggiunti i campi Annullato e Note per fornire indicazioni circa l'annullamento
Richiesta di Roma
Gianni 07-10-2014

*/
CREATE     PROCEDURE [compute_serviceregistrytopublish]
(
	@ayear smallint,	
	@employkind char(1)	
)

AS BEGIN

create table #pagamenti(amount decimal(19,2), yservreg int, nservreg int) 
insert into #pagamenti(yservreg,nservreg, amount)
select P.yservreg,P.nservreg, sum(P.payedamount)		
from serviceregistry S
join servicepayment P
		on S.yservreg = P.yservreg
		and S.nservreg = P.nservreg	
where S.yservreg = @ayear and 
	( @employkind= 'D' and  S.employkind = @employkind	 
		OR @employkind	<>'D'  and S.employkind in ('C','A')	)
group by S.idreg,P.yservreg,P.nservreg


-- kind = C or A
if(@employkind <> 'D')
Begin

	;with CV(idreg, idregistrycvattachment) 
	 as 
	(select V.idreg, V.idregistrycvattachment 
			from registrycvattachment V	
		  where V.idreg in (select S.idreg from serviceregistry S where  S.yservreg = @ayear and S.employkind = @employkind)
				and
				V.referencedate = (select max(V2.referencedate) from registrycvattachment V2
										where V2.idreg = V.idreg)	

	)
	select 
		@employkind+'\'+convert(varchar(4),S.yservreg)+'\'+convert(varchar(6),S.nservreg) as 'ID',
		S.title as 'Incaricato',
		-- S.authorizationdate as 'DataConferimento', -- rimossa col task 4934
		S.apactivitykind as 'Oggetto',
		S.description as 'DescrAttivita',
		S.start as 'InizioIncarico',
		S.stop as 'FineIncarico',
		S.actreference as 'AttoConferimento',
		S.otherservice as 'AltriIncarichiInEntiDiDirittoPrivatoFinanziatiDaPA',
		CV.idregistrycvattachment as idcv,
		-- verifica insussistenza conflitto di interessi (SI/NO)
		S.expectedamount as 'Importo',
		isnull(P.amount,0) as 'ImportoErogato',
		S.conferringstructure as 'StrutturaConferente', 	
		S.ordinancelink as 'LinkAlDecretoDiConferimentoIncarico',
		S.authorizingstructure as 'StrutturaCheAutorizza',	
		S.authorizinglink as 'LinkAttoDiAutorizzazione',	
		S.announcementlink as 'LinkAlBando',
		S.professionalservice as 'EventualiAttivitaProfessionali',	
		S.componentsvariable as 'ComponentiVariabiliDelCompenso',
		S.employtime as 'DurataIncarico',
		S.certinterestconflicts as 'AttestazioneConflittiDiInteresse',
		S.idreg,
		CASE 
		   WHEN S.is_annulled = 'S'  THEN 'S'
		   ELSE S.website_annulled 
		END 'Annullato'
	from serviceregistryview S
	join serviceregistrykind K		ON S.idserviceregistrykind = K.idserviceregistrykind
	left outer join CV				on Cv.idreg = S.idreg
   left outer join #pagamenti P		on P.yservreg = S.yservreg AND P.nservreg = S.nservreg 
	where S.yservreg = @ayear 
			and S.employkind <> 'D'-- @employkind
			and isnull(K.topublish,'N') = 'S'	
	order by S.yservreg, S.nservreg
End

-- kind = D
if(@employkind = 'D')
Begin

	;with CV(idreg, idregistrycvattachment) 
	 as 
	(select V.idreg, V.idregistrycvattachment 
			from registrycvattachment V	
		  where V.idreg in (select S.idreg from serviceregistry S where  S.yservreg = @ayear and S.employkind = @employkind)
				and
				V.referencedate = (select max(V2.referencedate) from registrycvattachment V2
										where V2.idreg = V.idreg)	

	)

	select 
		@employkind+'\'+convert(varchar(4),S.yservreg)+'\'+convert(varchar(6),S.nservreg) as 'ID',
		S.title as 'Incaricato',
		S.pa_title as 'Conferente',
		S.conferringstructure as 'StrutturaConferente',
		S.apactivitykind as 'Oggetto',
		S.description as 'DescrAttivita',
		S.start as 'InizioIncarico',
		S.stop as 'FineIncarico',
		S.officeduty as 'DoveriUfficio',
		case when expectedamount = 0 then 'S' else 'N' end as 'TitoloGratuito',
		S.expectedamount as 'Importo',
		isnull(P.amount,0) as 'ImportoErogato',
		S.ordinancelink as 'LinkAlDecretoDiConferimentoIncarico',
		S.authorizingstructure as 'StrutturaCheAutorizza',	
		S.authorizinglink as 'LinkAttoDiAutorizzazione',	
		S.actreference as 'AttoConferimento',	
		S.announcementlink as 'LinkAlBando',
		S.otherservice as 'AltriIncarichiInEntiDiDirittoPrivatoFinanziatiDaPA',
		S.professionalservice as 'EventualiAttivitaProfessionali',	
		S.componentsvariable as 'ComponentiVariabiliDelCompenso',
		S.employtime as 'DurataIncarico',
		S.certinterestconflicts as 'AttestazioneConflittiDiInteresse',
		CV.idregistrycvattachment as idcv,
		S.idreg,
		CASE 
		   WHEN S.is_annulled = 'S'  THEN 'S'
		   ELSE S.website_annulled 
		END 'Annullato'
	from serviceregistryview S
	join serviceregistrykind K
		ON S.idserviceregistrykind = K.idserviceregistrykind
	left outer join CV
		on Cv.idreg = S.idreg
   left outer join #pagamenti P		on P.yservreg = S.yservreg AND P.nservreg = S.nservreg 
	where S.yservreg = @ayear 
			and S.employkind = @employkind
			and isnull(K.topublish,'N') = 'S'	
			and S.authorizationdate is not null -- esclude i Dip senza data conferimento
	order by S.yservreg, S.nservreg
End


END





GO

