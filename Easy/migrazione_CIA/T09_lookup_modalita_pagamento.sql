-- Per il momento è una tabella temporanea, poi quando faremo la migrazione, diventarà una tabella fisica

IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_modalita_pagamento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_modalita_pagamento
END

create table lookup_modalita_pagamento(
codice varchar(10) NOT NULL,
descrizione varchar(40),
idpaymethod int
)
GO

/****** Object:  Index [PK_lookup_modalita_pagamento]    Script Date: 18/12/2013 07.48.26 ******/
ALTER TABLE [dbo].[lookup_modalita_pagamento] ADD  CONSTRAINT [PK_lookup_modalita_pagamento] PRIMARY KEY CLUSTERED 
(
	[codice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



go

insert into lookup_modalita_pagamento(codice, descrizione)
select codice,descrizione from rif_modalita_pagamento
order by descrizione
/*
1	-	Assegno circolare  (non ammette delegato o coordinate bancarie) 
3	-	Bonifico presso altre banche (non ammette delegato, coord.bancarie obbligatorie) 
4	-	Bonifico presso istituto cassiere (non ammette delegato, coord.bancarie obbligatorie) 
5	-	Conto corrente postale (ammette solo il cc) 
7	-	Sportello (ammette delegato e  non ammette coord.bancarie)
*/

update lookup_modalita_pagamento set idpaymethod = 1 where codice in ('AC','ACNT')
update lookup_modalita_pagamento set idpaymethod = 4 where codice in ('CCT','CC','CP','BE','CE','BB','CB','BP')
update lookup_modalita_pagamento set idpaymethod = 7 where codice in ('REGOLAR','MAV','F24','QUIE','GAU','AE','CD','CO','QPC','QE','CT','VINT','VPOS')


-- SELECT * FROM lookup_modalita_pagamento


GO