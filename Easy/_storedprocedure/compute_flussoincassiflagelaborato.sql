IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[compute_flussoincassiflagelaborato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [compute_flussoincassiflagelaborato]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE compute_flussoincassiflagelaborato
	@ayear int,
	@idflusso int
AS
BEGIN

update  flussoincassi 
 set elaborato='S' , lu='compute_flussoincassiflagelaboratoNtoS', lt = getdate()
 where idflusso = @idflusso and ayear = @ayear 
	and elaborato = 'N' and
  not exists(  --non esiste un dettaglio NON incassato
 select * from flussoincassidetail
  where flussoincassidetail.idflusso=flussoincassi.idflusso AND
  
  NOT(  --prendo la condizione che vuol dire 'incassato' e la nego
   --incassata come dettaglio contratto attivo
   ( 
   exists(
     select * from estimatedetail where yestim>2016 and stop is null and iduniqueformcode in 
      (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
     ) --si accerta che l'incasso sia collegato a credito e che il credito sia nel c.attivo altrimenti non hanno senso le altre in and
   and
    (select count( * ) from estimatedetail where stop is null and yestim>2016 and iduniqueformcode in 
     (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
     and idinc_taxable is null )=0 --si accerta che sia tutto contabilizzato altrimenti non ha senso vedere il disponibile
   and
    (select sum(available) from incomeview where  ayear = @ayear and idinc in 
     (select idinc_taxable from estimatedetail where stop is null and yestim>2016 and iduniqueformcode in 
     (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
     ) )=0    
   )
   OR
   (--incassata tramite fattura
     exists(
     select * from invoicedetail where iduniqueformcode in 
      (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
     ) --si accerta che l'incasso sia collegato a credito e che il credito sia nel c.attivo altrimenti non hanno senso le altre in and
    AND
    (select count( * ) from invoicedetail where  iduniqueformcode in 
     (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
       and idinc_taxable is null )=0 --si accerta che sia tutto contabilizzato 

   )
  )
 ) 



update flussoincassi 
 set elaborato='N' , lu='compute_flussoincassiflagelaboratoStoN', lt = getdate()
 where idflusso = @idflusso and 
	elaborato='S' and ayear = @ayear and
   exists(  --non esiste un dettaglio NON incassato
  select * from flussoincassidetail
  where flussoincassidetail.idflusso=flussoincassi.idflusso AND
  
  NOT(  --prendo la condizione che vuol dire 'incassato' e la nego
   --incassata come dettaglio contratto attivo
   ( 
   exists(
     select * from estimatedetail where yestim>2016 and stop is null and iduniqueformcode in 
      (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
     ) --si accerta che l'incasso sia collegato a credito e che il credito sia nel c.attivo altrimenti non hanno senso le altre in and
   and
    (select count( * ) from estimatedetail where stop is null and yestim>2016 and iduniqueformcode in 
     (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
     and idinc_taxable is null )=0 --si accerta che sia tutto contabilizzato altrimenti non ha senso vedere il disponibile
   and
    (select sum(available) from incomeview where ayear = @ayear and	idinc in 
     (select idinc_taxable from estimatedetail where stop is null and yestim>2016 and iduniqueformcode in 
     (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
     ) )=0    
   )
   OR
   (--incassata tramite fattura
     exists(
     select * from invoicedetail where iduniqueformcode in 
      (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
     ) --si accerta che l'incasso sia collegato a credito e che il credito sia nel c.attivo altrimenti non hanno senso le altre in and
    AND
    (select count( * ) from invoicedetail where  iduniqueformcode in 
     (select f3.iduniqueformcode from flussocreditidetail f3 where f3.iuv=flussoincassidetail.iuv or  f3.iduniqueformcode=flussoincassidetail.iduniqueformcode)
       and idinc_taxable is null )=0 --si accerta che sia tutto contabilizzato 

   )
  )
 ) 

 END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 