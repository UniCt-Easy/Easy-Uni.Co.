
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_trasmele_expense_opisiopeplus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_trasmele_expense_opisiopeplus]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE        PROCEDURE [check_trasmele_expense_opisiopeplus]
(
	@y int,
	@n int
)
as 

Begin
--setuser 'amministrazione'
-- EXEC check_trasmele_expense_opisiopeplus 2019, 95
DECLARE @k int
	SELECT  @k = kpaymenttransmission
	FROM paymenttransmission
	WHERE ypaymenttransmission = @y AND npaymenttransmission = @n

	DECLARE @transmissionkind char(1)
	SELECT @transmissionkind      = transmissionkind FROM   paymenttransmission  WHERE  npaymenttransmission = @n AND    ypaymenttransmission = @y

if	((SELECT COUNT(*) FROM paymenttransmission  WHERE  npaymenttransmission = @n AND    ypaymenttransmission = @y) = 0)
		BEGIN
			--  La distinta di trasmissione è vuota'
			return
		END


	CREATE TABLE  #errors (error varchar(400))

	CREATE TABLE #checktrace
	(
		kind char(30), 
		numero_mandato int,
		importo_mandato decimal(19,2),
		idpay int, 
		idexp int,
		importo_beneficiario decimal(19,2),
		anagrafica_beneficiario varchar(100),
		codice_cgu varchar(10),
		importoclassificazionemov decimal(19,2),

		tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE
		importo_siope  decimal(19,2),
		
		importo_codice_economico_siope  decimal(19,2), 
		importo_cofog_siope  decimal(19,2),
		tipo_operazione varchar(20),
		tipo_documento_siope varchar(20), 
		identificativo_lotto_sdi_siope varchar(20)
	)

	IF (ISNULL(@transmissionkind, 'I') = 'I')
	BEGIN
		INSERT INTO #checktrace(
			kind, numero_mandato, importo_mandato, idexp, 
			anagrafica_beneficiario,importo_beneficiario, 
			codice_cgu,	 importoclassificazionemov,
			tipo_debito_siope, importo_siope,
			importo_codice_economico_siope,	importo_cofog_siope,tipo_operazione,tipo_documento_siope,identificativo_lotto_sdi_siope
		)
		exec trasmele_expense_opisiopeplus_ins @y, @n,'S' 
	END

	IF (ISNULL(@transmissionkind, 'I') = 'V')
	BEGIN
	INSERT INTO #checktrace(
			kind, numero_mandato, importo_mandato, idexp, 
			anagrafica_beneficiario,importo_beneficiario, 
			codice_cgu,	 importoclassificazionemov,
			tipo_debito_siope, importo_siope,
			importo_codice_economico_siope,	importo_cofog_siope,tipo_operazione,tipo_documento_siope,identificativo_lotto_sdi_siope
		)
		exec trasmele_expense_opisiopeplus_var @y, @n,'S' 
	END


	--select * from 	#checktrace
	insert into #errors(error)
	select 'Sezione CLASSIFICAZIONI assente. Numero mandato : '+ convert(varchar(10),numero_mandato)+ '. Pagamento n.' + convert(varchar(10), E.nmov)
	from #checktrace T1
	join expense E on T1.idexp = E.idexp
	where not exists (select * 	from #checktrace T2
						where T1.idexp = T2.idexp
							and T2.kind='CLASSIFICAZIONI' )
	and T1.kind = 'INFO_BENEFICIARIO'
	and exists (select * 	from #checktrace T2
						where T1.numero_mandato = T2.numero_mandato
							and T2.tipo_operazione IN( 'INSERIMENTO' ,'VARIAZIONE') )


--	Se ci sono più classificazioni sul movimento e : più dati distinti in fattura o fattura senza siope => diventa obbligatorio il Siope in fatura

	insert into #errors(error)
	select 'Sezione CLASSIFICAZIONI assente. Inserire il siope nei dettagli fattura. Numero mandato : '+ convert(varchar(10),numero_mandato) + '. Pagamento n.' + convert(varchar(10), E.nmov)
	from #checktrace T1
	join expense E on T1.idexp = E.idexp
	where not exists (select * 	from #checktrace T2
						where T1.idexp = T2.idexp
							and T2.kind='CLASSIFICAZIONI' )
	and T1.kind = 'INFO_BENEFICIARIO'
	and (select count(distinct expensesorted.idsor)
			from expensesorted
			where expensesorted.idexp = T1.idexp ) >1
	AND 	
	(
	(select count(distinct D.idpccdebitstatus )
		from expenseinvoice E 
		join invoicedetail D		on E.idexp = D.idexp_taxable
		where E.idexp= T1.idexp		and D.idsor_siope is not null )>1
	OR
	EXISTS (SELECT * FROM invoicedetail d where d.idexp_taxable = T1.idexp and d.idsor_siope is null)
	)
	and exists (select * 	from #checktrace T2
						where T1.numero_mandato = T2.numero_mandato
							and T2.tipo_operazione IN( 'INSERIMENTO' ,'VARIAZIONE') )



	                      
	insert into #errors(error)
	select 'Documento elettronico privo dell''Identificativo del Lotto SDI con cui è stata trasmessa la FE. Numero mandato : '+ convert(varchar(10),numero_mandato) + '. Pagamento n.' + convert(varchar(10), E.nmov)
	from 	#checktrace T1
		join expense E on T1.idexp = E.idexp
	where kind='CLASSIFICAZIONI_FATTURASIOPE'
	and tipo_documento_siope='ELETTRONICO' and identificativo_lotto_sdi_siope is null
	
	insert into #errors(error)
	select 'Importo mandato non quadra con somma di Importo beneficiario. Numero mandato : '+ convert(varchar(10),numero_mandato)+'.'
	from 	#checktrace T1
	where T1.importo_mandato <> (	select sum(importo_beneficiario)
								from #checktrace T2
								where T1.numero_mandato = T2.numero_mandato)

	insert into #errors(error)
	select 'Importo beneficiario non quadra con la somma di Importo classificazione. Numero mandato : '+ convert(varchar(10),numero_mandato) + ', beneficiario '+anagrafica_beneficiario+'.'
	from 	#checktrace T1
	where T1.kind='INFO_BENEFICIARIO             '
		and T1.importo_beneficiario <> (	select sum(importoclassificazionemov)
								from #checktrace T2
								where T1.numero_mandato = T2.numero_mandato
									and T1.idexp = T2.idexp
									and T2.kind='CLASSIFICAZIONI')
	insert into #errors(error)
	select 'Importo classificazione non quadra con la somma di Importo Siope di Fattura. Numero mandato : '+ convert(varchar(10),numero_mandato)
	from 	#checktrace T1
	where kind='CLASSIFICAZIONI'
		and T1.importoclassificazionemov <> isnull((select sum(importo_siope)
								from #checktrace T2
								where T1.numero_mandato = T2.numero_mandato
									and T1.idexp = T2.idexp
									and T1.codice_cgu = T2.codice_cgu ),0)
  -- il controllo agisce solo se ci sono fatture di tipo commerciale
	and (select count(*) from #checktrace T3
		where T1.numero_mandato = T3.numero_mandato and T1.idexp = T3.idexp and T1.codice_cgu = T3.codice_cgu 
			and kind='CLASSIFICAZIONI_FATTURASIOPE' and isnull(T3.importo_siope,0) >0 )>0

	insert into #errors(error)
	select 'ARCONET-Importo codice economico siope non quadra con la somma di Importo COFOG siope. Numero mandato : '+ convert(varchar(10),numero_mandato) + ', beneficiario '+anagrafica_beneficiario+'.'
	from 	#checktrace T1
	where T1.importo_codice_economico_siope  <> ISNULL( (select sum(importo_cofog_siope)
								from #checktrace T2
								where T1.numero_mandato = T2.numero_mandato
									and T1.idexp = T2.idexp
									and T1.codice_cgu = T2.codice_cgu
									),0)
	and (select count(*) from #checktrace T3
		where T1.numero_mandato = T3.numero_mandato and T1.idexp = T3.idexp and kind='ARCONET')>0


	insert into #errors(error)
	select 'ARCONET-Importo beneficiario non quadra con la somma di importo codice economico siope. Numero mandato : '+ convert(varchar(10),numero_mandato) + ', beneficiario '+anagrafica_beneficiario+'.'
	from 	#checktrace T1
	where T1.importo_beneficiario <> isnull( (	select sum(importo_codice_economico_siope)
								from #checktrace T2
								where T1.numero_mandato = T2.numero_mandato
									and T1.idexp = T2.idexp),0)
	--il controllo deve agire solo se c'è la sezione ARCONET
	and (select count(*) from #checktrace T3
		where T1.numero_mandato = T3.numero_mandato and T1.idexp = T3.idexp and kind='ARCONET')>0

	IF ((SELECT COUNT(*) FROM #errors) >0)
	Begin
		SELECT * FROM #errors
		
	End

	drop table #checktrace
	drop table #errors

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 

GO
