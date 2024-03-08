
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[compute_flussoincassiflagelaborato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [compute_flussoincassiflagelaborato]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- setuser 'amm'
-- setuser 'amministrazione'
-- compute_flussoincassiflagelaborato 2018,1

CREATE PROCEDURE compute_flussoincassiflagelaborato
	@ayear int,
	@idflusso int
AS
BEGIN

if (select elaborato from flussoincassi where idflusso=@idflusso)='S' return

update  flussoincassi 
 set elaborato='S' , lu='compute_flussoincassinewNtoS', lt = getdate()
where idflusso = @idflusso and ayear = @ayear 
	and elaborato = 'N' and
not exists(  --NON esiste un dettaglio NON incassato
 select * from flussoincassidetail
	where flussoincassidetail.idflusso=flussoincassi.idflusso AND
	
	--chiedo che il dettaglio non sia incassato, ossia che non esista un incasso
	-- attenzione però che l'incasso potrebbe essere parziale e questa update imposterebbe comunque il flusso come elaborato=S
  NOT(  --prendo la condizione che vuol dire 'incassato' e la nego
   
   --incassata come dettaglio contratto attivo
   ( 
   exists(
     select * from flussocreditidetail f3 
			join  estimatedetail ed on ed.iduniqueformcode = f3.iduniqueformcode  and ed.idestimkind = f3.idestimkind  and f3.yestim=ed.yestim 
						and f3.nestim=ed.nestim and f3.rownum=ed.rownum
			where ed.stop is null 
				and (f3.iuv=flussoincassidetail.iuv or f3.iduniqueformcode=flussoincassidetail.iduniqueformcode) 
				and f3.stop is null and f3.annulment is null  				
				     
   ) --si accerta che l'incasso sia collegato a credito e che il credito sia nel c.attivo altrimenti non hanno senso le altre in and
   and
    (select count( * ) from  flussocreditidetail f3  
				join  estimatedetail ed on ed.iduniqueformcode = f3.iduniqueformcode  and ed.idestimkind = f3.idestimkind  and f3.yestim=ed.yestim 
						and f3.nestim=ed.nestim and f3.rownum=ed.rownum       
			where ed.stop is null and ed.yestim>=2016 
				and (f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
				and f3.stop is null and f3.annulment is null  				
			    and ed.idinc_taxable is null )=0 --si accerta che sia tutto contabilizzato altrimenti non ha senso vedere il disponibile
   and
    (
		(
		exists(
				 select * from flussocreditidetail f3 
				 join incomelastestimatedetailview iled ON iled.iduniqueformcode=f3.iduniqueformcode
			where (f3.iuv=flussoincassidetail.iuv or f3.iduniqueformcode=flussoincassidetail.iduniqueformcode) 
				and f3.stop is null and f3.annulment is null			
		)   --incassata con nuova tabella incassi dettagli contratti
		OR
		(select sum(available) from incomeview iv
			join estimatedetail ed on  iv.idinc = ed.idinc_taxable and iv.ayear=@ayear
			join flussocreditidetail f3 on ed.iduniqueformcode=f3.iduniqueformcode and f3.idestimkind=ed.idestimkind
							and f3.yestim=ed.yestim and f3.nestim=ed.nestim and f3.rownum=ed.rownum
			where  ed.stop is null 
					and (f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode) 
					and f3.stop is null and f3.annulment is null  			 		 	
			) =0   --accertamenti collegati sono completamente incassati 
		)   
		)
		)
   OR
   (--incassata tramite fattura
     exists(
		 select * from flussocreditidetail f3 
			join invoicedetail  id on id.iduniqueformcode = f3.iduniqueformcode and id.idinvkind= f3.idinvkind  and id.yinv=id.yinv and id.ninv=f3.ninv and id.rownum=f3.invrownum    
			where  f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode				
     ) --si accerta che l'incasso sia collegato a credito e che il credito sia nel c.attivo altrimenti non hanno senso le altre in and
    AND
	 (select count( * ) from flussocreditidetail f3 
			left outer join invoicedetail id on  id.iduniqueformcode =f3.iduniqueformcode
			where  (f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
					and id.idinc_taxable is null  and f3.stop is null and f3.annulment is null	
			)=0 --si accerta che sia tutto contabilizzato     
   )  
 )
  
 ) 


--pongo a N se collegato a tipo contratto attivo ma mancano i dett. attivi contabilizzati (condizione non contemplata nell'ultimo branch)
update flussoincassi 
 set elaborato='N' , lu='flagelaboratoStoN_cause_estim', lt = getdate()
 where idflusso = @idflusso and 
	elaborato='S' and ayear = @ayear and
   exists(  --esiste un dettaglio flusso incassi collegato a flussicrediti con tipo contratto attivo ma senza dett.contratti
		select * from flussoincassidetail	
			join flussocreditidetail f3  on  f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode
		where flussoincassidetail.idflusso=flussoincassi.idflusso AND
				f3.idinvkind is null and f3.idestimkind is not null	and f3.stop is null and f3.annulment is null  							
				and f3.importoversamento > 0 
				and not exists ( select * from estimatedetail where idestimkind=f3.idestimkind and yestim=f3.yestim and nestim=f3.nestim and rownum=f3.rownum and stop is null and iduniqueformcode=f3. iduniqueformcode and idinc_taxable is not null)				
	)

--pongo a N se collegato a tipo fattura  ma mancano i dett. fattura (condizione non contemplata nell'ultimo branch)
update flussoincassi 
 set elaborato='N' , lu='flagelaboratoStoN_cause_invoice', lt = getdate()
 where idflusso = @idflusso and 
	elaborato='S' and ayear = @ayear and
   exists(  --esiste un dettaglio flusso incassi collegato a flussicrediti con tipo fattura valorizzato ma manca un dett. fattura
		select * from flussoincassidetail	
		join  flussocreditidetail f3  on f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode
		where flussoincassidetail.idflusso=flussoincassi.idflusso 
				and f3.idinvkind is not null and f3.idestimkind is null	and f3.stop is null and f3.annulment is null  			
				and f3.importoversamento > 0 													
				and not exists ( select * from invoicedetail where idinvkind=f3.idinvkind and iduniqueformcode=f3. iduniqueformcode and yinv=f3.yinv and ninv=f3.ninv and rownum=f3.invrownum and idinc_taxable is not null)				
	)

--pongo a N se collegato a tipo contratto attivo e c'è la contabilizzazione del dett.contratto attivo ma non è incassato
update flussoincassi 
 set elaborato='N' , lu='flagelaboratoStoN_cause_estim2', lt = getdate()
 where idflusso = @idflusso and 
	elaborato='S' and ayear = @ayear and
   exists(  --esiste un dettaglio flusso incassi collegato a flussicrediti con tipo contratto attivo ma senza dett.contratti
	select * from flussoincassidetail	
		join flussocreditidetail f3  on f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode
		join  estimatedetail ed on ed.iduniqueformcode=f3. iduniqueformcode  and ed.idestimkind=f3.idestimkind and ed.yestim=f3.yestim and f3.nestim=ed.nestim and f3.rownum=ed.rownum
		join incomeview iv on iv.idinc=ed.idinc_taxable and iv.ayear=@ayear	
		where flussoincassidetail.idflusso=flussoincassi.idflusso AND
				f3.idinvkind is null and f3.stop is null and f3.annulment is null  								
				and ed.stop is null 			
				and iv.available <> 0		
	)
		



 END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
