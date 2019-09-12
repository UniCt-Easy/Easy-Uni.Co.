-- CREAZIONE TABELLA lookup_bilancio --
IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_aliquote]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_aliquote
END
GO
CREATE TABLE lookup_aliquote
(	bilancio varchar(120),
	codice_easy varchar(20),
	codice_cia varchar(20) not null,
	percentuale  decimal(19,2) not null,
	descrizione varchar(150)
	CONSTRAINT xpklookup_aliquote PRIMARY KEY (bilancio,codice_cia,percentuale)
)

insert into lookup_aliquote (D.bilancio,codice_cia, PERCENTUALE)
select distinct D.BILANCIO,ltrim(rtrim(D.CODICE_IVA)),D.PERCENTUALE_IVA
	from ordine O 
	join ordine_dettaglio D
		on O.esercizio = d.esercizio and O.bilancio = d.bilancio and O.numero_ordine = d.numero_ordine  
	left outer join CODICE_IVA C
		on C.CODICE= D.CODICE_IVA and C.PERCENTUALE=D.PERCENTUALE_IVA
	where C.CODICE is null


insert into lookup_aliquote (bilancio, codice_cia, PERCENTUALE)
select distinct DF.bilancio,  ltrim(rtrim(DF.CODICE_IVA)),DF.PERCENTUALE_IVA
	from FATTURA F 
	join fattura_dettaglio DF
		on F.bilancio = DF.bilancio 
		and F.numero_fattura = DF.numero_fattura
		and F.esercizio = DF.esercizio
	left outer join CODICE_IVA C
		on C.CODICE= DF.CODICE_IVA and C.PERCENTUALE=DF.PERCENTUALE_IVA
	left outer join lookup_aliquote lk
		on lk.codice_cia= DF.CODICE_IVA and lk.PERCENTUALE=DF.PERCENTUALE_IVA and lk.bilancio=DF.BILANCIO
	where C.CODICE is null and lk.codice_cia is null



insert into lookup_aliquote (codice_cia, PERCENTUALE)
select distinct ltrim(rtrim(DF2.CODICE_IVA)),DF2.PERCENTUALE_IVA
from FATTURA_att F2 
	join fattura_att_dettaglio DF2
		on F2.bilancio = DF2.bilancio 
		and F2.numero_fattura = DF2.numero_fattura
		and F2.esercizio = DF2.esercizio
		and F2.RICHIESTA_FATTURAZIONE = DF2.RICHIESTA_FATTURAZIONE
	left outer join CODICE_IVA C
		on C.CODICE= DF2.CODICE_IVA and C.PERCENTUALE=DF2.PERCENTUALE_IVA
	left outer join lookup_aliquote lk
		on lk.codice_cia= DF2.CODICE_IVA and lk.PERCENTUALE=DF2.PERCENTUALE_IVA and lk.bilancio=DF2.BILANCIO
	where C.CODICE is null and lk.codice_cia is null 


 update lookup_aliquote set codice_easy= codice_cia+CONVERT(varchar(10),percentuale)

 update lookup_aliquote set descrizione= 'da importazione:'+
		codice_cia+' usato al  '+CONVERT(varchar(10),isnull(percentuale,0))+'% in '+bilancio


insert into lookup_aliquote (D.bilancio,codice_cia, PERCENTUALE)
select distinct D.BILANCIO,ltrim(rtrim(C.CODICE)),C.PERCENTUALE
	from ordine O 
	join ordine_dettaglio D
		on O.esercizio = d.esercizio and O.bilancio = d.bilancio and O.numero_ordine = d.numero_ordine  
	 join CODICE_IVA C
		on C.CODICE= D.CODICE_IVA and C.PERCENTUALE=D.PERCENTUALE_IVA
	



insert into lookup_aliquote (bilancio, codice_cia, PERCENTUALE)
select distinct DF.bilancio, ltrim(rtrim(C.CODICE)),C.PERCENTUALE
	from FATTURA F 
	join fattura_dettaglio DF
		on F.bilancio = DF.bilancio 
		and F.numero_fattura = DF.numero_fattura
		and F.esercizio = DF.esercizio
	 join CODICE_IVA C
		on C.CODICE= DF.CODICE_IVA and C.PERCENTUALE=DF.PERCENTUALE_IVA
	left outer join lookup_aliquote lk
		on lk.codice_cia= DF.CODICE_IVA and lk.PERCENTUALE=DF.PERCENTUALE_IVA and lk.bilancio=DF.BILANCIO
	where lk.codice_cia is null

insert into lookup_aliquote (bilancio,codice_cia, PERCENTUALE)
select distinct DF2.bilancio,ltrim(rtrim(DF2.CODICE_IVA)),DF2.PERCENTUALE_IVA
from FATTURA_att F2 
	join fattura_att_dettaglio DF2
		on F2.bilancio = DF2.bilancio 
		and F2.numero_fattura = DF2.numero_fattura
		and F2.esercizio = DF2.esercizio
		and F2.RICHIESTA_FATTURAZIONE = DF2.RICHIESTA_FATTURAZIONE
	join CODICE_IVA C
		on C.CODICE= DF2.CODICE_IVA and C.PERCENTUALE=DF2.PERCENTUALE_IVA
	left outer join lookup_aliquote lk
		on lk.codice_cia= DF2.CODICE_IVA and lk.PERCENTUALE=DF2.PERCENTUALE_IVA and lk.bilancio=DF2.BILANCIO
	where lk.codice_cia is null 

	
 update lookup_aliquote set codice_easy= codice_cia
		where codice_easy is null

 update lookup_aliquote set descrizione=CODICE_IVA.DESCRIZIONE
 from lookup_aliquote join CODICE_IVA on lookup_aliquote.codice_cia=CODICE_IVA.CODICE
		where lookup_aliquote.descrizione is null
GO

--select * from lookup_aliquote
--select * from CODICE_IVA