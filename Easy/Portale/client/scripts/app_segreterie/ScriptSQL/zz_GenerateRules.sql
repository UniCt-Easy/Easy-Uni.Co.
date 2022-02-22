
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


exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogettokind  
	from progettotipocostokindaccmotive
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idaccmotive, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogettokind  
	from progettotipocostokindcontrattokind
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idcontrattokind, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogettokind  
	from progettotipocostokindinventorytree
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idinv, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogettokind  
	from progettotipocostokindtax
	where idprogettokind = %<progettokind.idprogettokind>%
	group by taxcode, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogetto  
	from progettotipocostoaccmotive
	where idprogetto = %<progetto.idprogetto>%
	group by idaccmotive, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogetto  
	from progettotipocostocontrattokind
	where idprogetto = %<progetto.idprogetto>%
	group by idcontrattokind, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogetto  
	from progettotipocostoinventorytree
	where idprogetto = %<progetto.idprogetto>%
	group by idinv, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'workpackageupb', @code = 'WORKPACKAGEUPB01', @message = 'L''UPB risulta già  associato ad un''altro Workpackage.', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '[(select cc from (
select count(*)as cc, idprogetto, idupb  from workpackageupb
group by idprogetto, idupb) tbl1
where idupb= %<workpackageupb.idupb>% and idprogetto = %<workpackageupb.idprogetto>%)]{I} =1', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO05', @message = 'Bisogna caricare tutti gli allegati del progetto, per questo specifico stato selezionato', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna caricare tutti gli allegati del progetto, per questo specifico stato selezionato
([
select count(idprogettostatuskind) from progettoattachkindprogettostatuskind 
	where 
	idprogettoattachkind IN 
		(
			select  idprogettoattachkind from progettoattachkind where idprogettokind = (select idprogettokind from progetto where idprogetto = %<progetto.idprogetto>%)
			AND
			title IN (select title from progettoattach where idprogetto = %<progetto.idprogetto>% and idattach is null)
		) 
	AND
	idprogettostatuskind = (select idprogettostatuskind from progetto where idprogetto = %<progetto.idprogetto>%)
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO06', @message = 'Bisogna inserire le descrizioni per tutti i testi del progetto, per questo specifico stato selezionato', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna inserire le descrizioni per tutti i testi del progetto, per questo specifico stato selezionato
([
select count(idprogettotestokind) from progettotestokindprogettostatuskind 
	where 
	idprogettotestokind IN 
		(
			select idprogettotestokind from progettotestokind where idprogettokind = (select idprogettokind from progetto where idprogetto = %<progetto.idprogetto>%)
			AND
			titolo in (select title from progettotesto where idprogetto = %<progetto.idprogetto>% and description is null)
		) 
	AND
	idprogettostatuskind = (select idprogettostatuskind from progetto where idprogetto = %<progetto.idprogetto>%)
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettoattach', @code = 'PROGETTOATTACH01', @message = 'Bisogna caricare tutti gli allegati del progetto, per questo specifico stato selezionato', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna caricare tutti gli allegati del progetto, per questo specifico stato selezionato
([
select count(idprogettostatuskind) from progettoattachkindprogettostatuskind 
	where 
	idprogettoattachkind IN 
		(
			select  idprogettoattachkind from progettoattachkind where idprogettokind = (select idprogettokind from progetto where idprogetto = %<progettoattach.idprogetto>%)
			AND
			title IN (select title from progettoattach where idprogetto = %<progettoattach.idprogetto>% and idattach is null)
		) 
	AND
	idprogettostatuskind = (select idprogettostatuskind from progetto where idprogetto = %<progettoattach.idprogetto>%)
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO07', @message = 'Bisogna inserire sia l''ente capofila che finanziatore, se lo stato è operativo', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna inserire sia l''''ente capofila che finanziatore, se lo stato è operativo
([select count(*) from progetto
	    where
	    ((progetto.idreg_aziende is not null and progetto.idreg_aziende_fin is not null and %<progetto.idprogettostatuskind>% >= 8) OR
	     (%<progetto.idprogettostatuskind>% < 8)) AND
	     idprogetto = %<progetto.idprogetto>%
]{I} = 1)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettotesto', @code = 'PROGETTOTESTO01', @message = 'Bisogna inserire descrizioni per tutti i testi del progetto, per questo specifico stato selezionato', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Bisogna inserire le descrizioni per tutti i testi del progetto, per questo specifico stato selezionato
([
select count(idprogettotestokind) from progettotestokindprogettostatuskind 
	where 
	idprogettotestokind IN 
		(
			select idprogettotestokind from progettotestokind where idprogettokind = (select idprogettokind from progetto where idprogetto = %<progettotesto.idprogetto>%)
			AND
			titolo in (select title from progettotesto where idprogetto = %<progettotesto.idprogetto>% and isnull(description ,'''') = '''')
		) 
	AND
	idprogettostatuskind = (select idprogettostatuskind from progetto where idprogetto = %<progettotesto.idprogetto>%)
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfrequestobbindividuale', @code = 'PERFREQUESTOBBINDIVIDUALE01', @message = 'Il responsabile può gestire gli obiettivi solo per i propri collaboratori', @post = 'R', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'S', @sql = '[(select count(idreg) from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg in (select idreg from registryreference where userweb = %<sys_idcustomuser>%) and idperfruolo = ''Responsabile'') and idreg =  %<perfrequestobbindividuale.idreg>%)]{I} > 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfrequestobbunatantum', @code = 'PERFREQUESTOBBUNATANTUM01', @message = 'Il responsabile può gestire le richieste di obiettivi solo per le proprie unità organizzative', @post = 'R', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'S', @sql = '[(select count(idstruttura) from strutturaparentresponsabiliview where idreg in (select idreg from registryreference where userweb = %<sys_idcustomuser>%) and idperfruolo = ''Responsabile'' and idstruttura  = %<perfrequestobbunatantum.idstruttura>%)]{I} > 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfprogetto', @code = 'PERFPROGETTO01', @message = 'Non è possibile assegnare al progetto lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'S', @upd = 'N', @del = 'N', @sql = '[
[(select count(*) 
from perfprogettocambiostato  p
inner join strutturaparentresponsabiliview s on s.idperfruolo = p.idperfruolo 
and convert(date,start,103) <= convert(date,GETDATE(),103) and CONVERT(date,stop,103)>= convert(date,GETDATE(),103)
inner join registryreference r on s.idreg=r.idreg
where  userweb= %<sys_idcustomuser>% and s.idstruttura =ISNULL(%<perfprogetto.idstruttura>%,0) 
and (%<perfprogetto.idperfprogettostatus>% is null 
or (p.idperfprogettostatus is null and p.idperfprogettostatus_to= %<perfprogetto.idperfprogettostatus>%)
))]{I} > 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfprogetto', @code = 'PERFPROGETTO01', @message = 'Non è possibile assegnare al progetto lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'N', @upd = 'S', @del = 'N', @sql = '[
[(SELECT count(*) FROM perfprogettocambiostato p
inner join strutturaparentresponsabiliview s on s.idperfruolo = p.idperfruolo 
and convert(date,start,103) <= convert(date,GETDATE(),103) and CONVERT(date,stop,103)>= convert(date,GETDATE(),103)
inner join registryreference r on s.idreg=r.idreg
left join perfprogetto pp on pp.idstruttura=s.idstruttura
where  userweb= %<sys_idcustomuser>% and s.idstruttura =ISNULL(%<perfprogetto.idstruttura>%,0) and
pp.idperfprogetto = %<perfprogetto.idperfprogetto>% and 
(isnull(p.idperfprogettostatus,0) = isnull(%<perfprogetto.idperfprogettostatus>%,0) or 
(isnull(p.idperfprogettostatus,0)=isnull(pp.idperfprogettostatus,0) and isnull(p.idperfprogettostatus_to,0)=isnull(
%<perfprogetto.idperfprogettostatus>%,0))))]{I}> 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfvalutazionepersonale', @code = 'PERFVALUTAZIONEPERSONALE02', @message = 'Non è possibile assegnare alla scheda lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'S', @upd = 'N', @del = 'N', @sql = '
[(SELECT count(*) FROM
  perfschedacambiostato p
left join strutturaparentresponsabiliafferenzaview s on   p.idperfruolo=s.idperfruolo
inner join strutturaparentresponsabiliview sr on sr.idreg = s.idreg and sr.start <= s.start and sr.stop>=s.stop and sr.idstruttura = s.idstruttura
inner join registryreference r on s.idreg=r.idreg
where r.idreg <>s.afferente_idreg
and 
userweb= %<sys_idcustomuser>%      and  afferente_idreg =%<perfvalutazionepersonale.idreg>%  
and (%<perfvalutazionepersonale.idperfschedastatus>% is null or (
 p.idperfschedastatus is null and p.idperfschedastatus_to= %<perfvalutazionepersonale.idperfschedastatus>% 
)))]{I} > 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfvalutazionepersonale', @code = 'PERFVALUTAZIONEPERSONALE02', @message = 'Non è possibile assegnare alla scheda lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'N', @upd = 'S', @del = 'N', @sql = '
[(SELECT count(*) FROM(
SELECT distinct p.idperfruolo,r.userweb,p.idperfschedastatus,p.idperfschedastatus_to,pv.idperfvalutazionepersonale, pv.idperfschedastatus as pv_idperfschedastatus,s.afferente_idreg  FROM  perfschedacambiostato p
left join strutturaparentresponsabiliafferenzaview s on   p.idperfruolo=s.idperfruolo
inner join strutturaparentresponsabiliview sr on sr.idreg = s.idreg and sr.start <= s.start and sr.stop>=s.stop and sr.idstruttura = s.idstruttura
inner join registryreference r on s.idreg=r.idreg
left join perfvalutazionepersonale pv on pv.idreg=s.afferente_idreg
where r.idreg <>s.afferente_idreg
UNION 
SELECT  distinct p.idperfruolo, r.userweb, p.idperfschedastatus,p.idperfschedastatus_to,pv.idperfvalutazionepersonale,pv.idperfschedastatus as pv_idperfschedastatus,pv.idreg as afferente_idreg FROM   perfschedacambiostato p
left join perfvalutazionepersonale pv on p.idperfschedastatus = pv.idperfschedastatus or pv.idperfschedastatus is null 
left join registryreference r on r.idreg=pv.idreg
where   p.idperfruolo=''Valutato'' 
) as a
where  userweb= %<sys_idcustomuser>%  and  afferente_idreg =%<perfvalutazionepersonale.idreg>%  and isnull(idperfvalutazionepersonale,0) = ISNULL(%<perfvalutazionepersonale.idperfvalutazionepersonale>%,0)  and (
isnull(pv_idperfschedastatus,0) = isnull(%<perfvalutazionepersonale.idperfschedastatus>%,0) or 
(isnull(idperfschedastatus,0)=isnull(pv_idperfschedastatus,0) and isnull(idperfschedastatus_to,0)=isnull(%<perfvalutazionepersonale.idperfschedastatus>%,0))))]{I} > 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfvalutazioneuo', @code = 'PERFVALUTAZIONEUO02', @message = 'Non è possibile assegnare alla scheda lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'S', @upd = 'N', @del = 'N', @sql = '
[(SELECT count(*) FROM perfschedacambiostato p
inner join strutturaparentresponsabiliview s on s.idperfruolo = p.idperfruolo 
and convert(date,start,103) <= convert(date,GETDATE(),103) and CONVERT(date,stop,103)>= convert(date,GETDATE(),103)
inner join registryreference r on s.idreg=r.idreg
where  userweb= %<sys_idcustomuser>% and s.idstruttura =ISNULL(%<perfvalutazioneuo.idstruttura>%,0) 
and (%<perfvalutazioneuo.idperfschedastatus>% is null or (
 p.idperfschedastatus is null and p.idperfschedastatus_to= %<perfvalutazioneuo.idperfschedastatus>% 
)))]{I}> 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfvalutazioneuo', @code = 'PERFVALUTAZIONEUO02', @message = 'Non è possibile assegnare alla scheda lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'N', @upd = 'S', @del = 'N', @sql = '[(SELECT count(*) FROM perfschedacambiostato p
inner join strutturaparentresponsabiliview s on s.idperfruolo = p.idperfruolo 
and convert(date,start,103) <= convert(date,GETDATE(),103) and CONVERT(date,stop,103)>= convert(date,GETDATE(),103)
inner join registryreference r on s.idreg=r.idreg
left join perfvalutazioneuo pv on pv.idstruttura=s.idstruttura
where  userweb= %<sys_idcustomuser>% and s.idstruttura =ISNULL(%<perfvalutazioneuo.idstruttura>%,0) and
idperfvalutazioneuo = %<perfvalutazioneuo.idperfvalutazioneuo>% and 
(isnull(pv.idperfschedastatus,0) = isnull(%<perfvalutazioneuo.idperfschedastatus>%,0) or 
(isnull(p.idperfschedastatus,0)=isnull(pv.idperfschedastatus,0) and isnull(p.idperfschedastatus_to,0)=isnull(
%<perfvalutazioneuo.idperfschedastatus>%,0))))]{I}> 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfprogetto', @code = 'PERFPROGETTO01', @message = 'Non è possibile assegnare al progetto lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'N', @upd = 'S', @del = 'N', @sql = '[(select count(*) 
from perfprogettocambiostato  p
inner join strutturaparentresponsabiliview s on s.idperfruolo = p.idperfruolo 
and convert(date,start,103) <= convert(date,GETDATE(),103) and CONVERT(date,stop,103)>= convert(date,GETDATE(),103)
inner join registryreference r on s.idreg=r.idreg
where  userweb= %<sys_idcustomuser>% and s.idstruttura =ISNULL(%<perfprogetto.idstruttura>%,0) 
and (%<perfprogetto.idperfprogettostatus>% is null 
or (p.idperfprogettostatus is null and p.idperfprogettostatus_to= %<perfprogetto.idperfprogettostatus>%)
))]{I} > 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfvalutazioneuo', @code = 'PERFVALUTAZIONEUO01', @message = 'Il responsabile può gestire la scheda di valutazione solo per le proprie unità organizzative', @post = 'R', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'S', @sql = '-- le valutazioni degli utenti appartenenti alla gerarchia delle unità organizzative di cui %<sys_idcustomuser>% è responsabile, 
--escluse quelle in cui %<sys_idcustomuser>% è tra i membri 

[(select count(*) from strutturaparentresponsabiliview where idreg in (select idreg from registryreference where userweb = %<sys_idcustomuser>%) and (idperfruolo = ''Responsabile'' or idperfruolo = ''Approvatore'' or idperfruolo=''Valutatore'') and  %<perfvalutazioneuo.idstruttura>% in  (select idstruttura from perfprogetto where idperfprogetto in (select idperfprogetto from perfprogettouo where idperfprogettouo in (select idperfprogettouo from perfprogettouomembro where  idreg not in  (select idreg from registryreference where userweb = %<sys_idcustomuser>%)))))]{I} > 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfvalutazionepersonale', @code = 'PERFVALUTAZIONEPERSONALE01', @message = 'Il responsabile può gestire la scheda di valutazione solo per i propri collaboratori', @post = 'R', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'S', @sql = '[(select count(*) from afferenza where idstruttura in (select idstruttura from strutturaparentresponsabiliview where idreg in (select idreg from registryreference where userweb = %<sys_idcustomuser>%) and idperfruolo = ''Responsabile'' or idperfruolo = ''Valutatore'' or idperfruolo = ''Approvatore'') and idreg =  %<perfvalutazionepersonale.idreg>% and (select idreg from registryreference where userweb = %<sys_idcustomuser>%) <>  %<perfvalutazionepersonale.idreg>%)]{I} > 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfprogetto', @code = 'PERFPROGETTO01', @message = 'Non è possibile assegnare al progetto lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'S', @upd = 'N', @del = 'N', @sql = '[(select count(*) 
from perfprogettocambiostato  p
inner join strutturaparentresponsabiliview s on s.idperfruolo = p.idperfruolo 
and convert(date,start,103) <= convert(date,GETDATE(),103) and CONVERT(date,stop,103)>= convert(date,GETDATE(),103)
inner join registryreference r on s.idreg=r.idreg
where  userweb= %<sys_idcustomuser>% and s.idstruttura =ISNULL(%<perfprogetto.idstruttura>%,0) 
and (%<perfprogetto.idperfprogettostatus>% is null 
or (p.idperfprogettostatus is null and p.idperfprogettostatus_to= %<perfprogetto.idperfprogettostatus>%)
))]{I} > 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfvalutazioneuo', @code = 'PERFVALUTAZIONEUO02', @message = 'Non è possibile assegnare alla scheda lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'N', @upd = 'S', @del = 'N', @sql = '[(SELECT count(*) FROM perfschedacambiostato p
inner join strutturaparentresponsabiliview s on s.idperfruolo = p.idperfruolo 
and convert(date,start,103) <= convert(date,GETDATE(),103) and (CONVERT(date,stop,103)>= convert(date,GETDATE(),103) or stop is null)
inner join registryreference r on s.idreg=r.idreg
left join perfvalutazioneuo pv on pv.idstruttura=s.idstruttura
where  userweb= %<sys_idcustomuser>% and s.idstruttura =ISNULL(%<perfvalutazioneuo.idstruttura>%,0) and
idperfvalutazioneuo = %<perfvalutazioneuo.idperfvalutazioneuo>% and 
(isnull(pv.idperfschedastatus,0) = isnull(%<perfvalutazioneuo.idperfschedastatus>%,0) or 
(isnull(p.idperfschedastatus,0)=isnull(pv.idperfschedastatus,0) and isnull(p.idperfschedastatus_to,0)=isnull(
%<perfvalutazioneuo.idperfschedastatus>%,0))))]{I}> 0', @executor = 'rulesGenerator';
exec GenerateRule @table = 'perfvalutazionepersonale', @code = 'PERFVALUTAZIONEPERSONALE02', @message = 'Non è possibile assegnare alla scheda lo stato selezionato', @post = 'R', @warning = 'B', @ins = 'N', @upd = 'S', @del = 'N', @sql = '[(SELECT count(*) FROM(
SELECT distinct p.idperfruolo,r.userweb,p.idperfschedastatus,p.idperfschedastatus_to,pv.idperfvalutazionepersonale, pv.idperfschedastatus as pv_idperfschedastatus,s.afferente_idreg  FROM  perfschedacambiostato p
left join strutturaparentresponsabiliafferenzaview s on   p.idperfruolo=s.idperfruolo
inner join strutturaparentresponsabiliview sr on sr.idreg = s.idreg and sr.start <= s.start and (sr.stop>=s.stop or s.stop is null) and sr.idstruttura = s.idstruttura
inner join registryreference r on s.idreg=r.idreg
left join perfvalutazionepersonale pv on pv.idreg=s.afferente_idreg
where r.idreg <>s.afferente_idreg
UNION 
SELECT  distinct p.idperfruolo, r.userweb, p.idperfschedastatus,p.idperfschedastatus_to,pv.idperfvalutazionepersonale,pv.idperfschedastatus as pv_idperfschedastatus,pv.idreg as afferente_idreg FROM   perfschedacambiostato p
left join perfvalutazionepersonale pv on p.idperfschedastatus = pv.idperfschedastatus or pv.idperfschedastatus is null 
left join registryreference r on r.idreg=pv.idreg
where   p.idperfruolo=''Valutato'' 
) as a
where  userweb= %<sys_idcustomuser>%  and  afferente_idreg =%<perfvalutazionepersonale.idreg>%  and isnull(idperfvalutazionepersonale,0) = ISNULL(%<perfvalutazionepersonale.idperfvalutazionepersonale>%,0)  and (
isnull(pv_idperfschedastatus,0) = isnull(%<perfvalutazionepersonale.idperfschedastatus>%,0) or 
(isnull(idperfschedastatus,0)=isnull(pv_idperfschedastatus,0) and isnull(idperfschedastatus_to,0)=isnull(%<perfvalutazionepersonale.idperfschedastatus>%,0))))]{I} > 0', @executor = 'rulesGenerator';
--rule	
