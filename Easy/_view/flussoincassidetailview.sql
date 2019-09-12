-- CREAZIONE VISTA flussoincassidetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[flussoincassidetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [flussoincassidetailview]
GO
--setuser 'amm'
-- clear_table_info 'flussoincassidetailview'
CREATE VIEW [flussoincassidetailview]
AS
SELECT   flussoincassidetail.idflusso, 
         flussoincassidetail.iddetail, 
		 flussoincassidetail.importo, 
		 flussoincassidetail.iuv, 
		 flussoincassidetail.cf, 
		 flussoincassidetail.lt, 
         flussoincassidetail.lu, 
		 flussoincassidetail.ct, 
		 flussoincassidetail.cu, 
		 flussoincassidetail.iduniqueformcode,
		 flussoincassi.codiceflusso,
		 flussoincassi.nbill,
		 flussoincassi.trn,
		 flussoincassi.dataincasso,
		 flussoincassi.ayear, 
		 flussoincassi.causale,
		 flussoincassi.importo as importotale,
		 flussoincassi.active,
		 flussoincassi.elaborato

FROM     flussoincassidetail 
	left outer JOIN flussoincassi 
	ON flussoincassidetail.idflusso = flussoincassi.idflusso

GO
