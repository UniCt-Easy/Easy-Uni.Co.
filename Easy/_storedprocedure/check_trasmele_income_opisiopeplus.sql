
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_trasmele_income_opisiopeplus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_trasmele_income_opisiopeplus]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE        PROCEDURE [check_trasmele_income_opisiopeplus]
(
	@y int,
	@n int
)
as 
Begin
--	setuser 'amministrazione'
--	exec  check_trasmele_income_opisiopeplus 2012,525
DECLARE @k int
SELECT  @k = kproceedstransmission
FROM proceedstransmission
WHERE yproceedstransmission = @y AND nproceedstransmission = @n

if	((SELECT COUNT(*) FROM   proceedstransmission  WHERE  nproceedstransmission = @n 
			AND    yproceedstransmission = @y ) = 0)
		BEGIN
			--  La distinta di trasmissione è vuota'
			return
		END

DECLARE @transmissionkind char(1)
SELECT @transmissionkind      = transmissionkind FROM   proceedstransmission  WHERE  nproceedstransmission = @n AND    yproceedstransmission = @y

CREATE TABLE  #errors (error varchar(400))

	CREATE TABLE #checktrace
	(
		kind char(30), 
		numero_reversale int,
		importo_reversale decimal(19,2),
		idpro int, 
		idinc int,
		importo_versante decimal(19,2),
		anagrafica_versante varchar(100),
		codice_cge varchar(10),
		importoclassificazionemov decimal(19,2),

		tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE
		importo_siope  decimal(19,2),
		
		importo_codice_economico_siope  decimal(19,2),
		tipo_operazione varchar(20),
		tipo_documento_siope varchar(20), 
		identificativo_lotto_sdi_siope varchar(20)
		)

IF (ISNULL(@transmissionkind, 'I') = 'I')
BEGIN
	INSERT INTO #checktrace(
	 kind, numero_reversale, importo_reversale, idinc, 
	anagrafica_versante,importo_versante, 
	codice_cge,	 importoclassificazionemov,
	 tipo_debito_siope, importo_siope,
 	importo_codice_economico_siope,tipo_operazione,tipo_documento_siope,identificativo_lotto_sdi_siope
	)
	exec trasmele_income_opisiopeplus_ins @y, @n,'S' 
END

IF (ISNULL(@transmissionkind, 'I') = 'V')
BEGIN
	INSERT INTO #checktrace(
	 kind, numero_reversale, importo_reversale, idinc, 
	anagrafica_versante,importo_versante, 
	codice_cge,	 importoclassificazionemov,
	 tipo_debito_siope, importo_siope,
 	importo_codice_economico_siope,tipo_operazione,tipo_documento_siope,identificativo_lotto_sdi_siope
	)
	exec trasmele_income_opisiopeplus_var @y, @n,'S' 
END


	insert into #errors(error)
	select 'Sezione CLASSIFICAZIONI assente. Numero reversale : '+ convert(varchar(10),numero_reversale)+ '. Incasso n.' + convert(varchar(10), E.nmov)
	from 	#checktrace T1
	join income E on T1.idinc = E.idinc
	where not exists (select * 	from #checktrace T2
						where T1.idinc = T2.idinc
							and T2.kind='CLASSIFICAZIONI' )
	and T1.kind = 'INFO_VERSANTE'
		and exists (select * 	from #checktrace T2
						where T1.numero_reversale = T2.numero_reversale
							and T2.tipo_operazione IN( 'INSERIMENTO' ,'VARIAZIONE') )

	insert into #errors(error)
	select 'Documento elettronico privo dell''Identificativo del Lotto SDI con cui è stata trasmessa la FE. Numero reversale : '+ convert(varchar(10),numero_reversale) + '. Incasso n.' + convert(varchar(10), E.nmov)
	from 	#checktrace T1
		join income E on T1.idinc = E.idinc
	where kind='CLASSIFICAZIONI_FATTURASIOPE'
	and tipo_documento_siope='ELETTRONICO' and identificativo_lotto_sdi_siope is null

	insert into #errors(error)
	select 'Importo reversale non quadra con somma di Importo versante. Numero reversale : '+ convert(varchar(10),numero_reversale)+'.'
	from 	#checktrace T1
	where T1.importo_reversale <> (	select sum(importo_versante)
								from #checktrace T2
								where T1.numero_reversale = T2.numero_reversale)

	insert into #errors(error)
	select 'Importo versante non quadra con la somma di Importo classificazione. Numero reversale : '+ convert(varchar(10),numero_reversale) + ', versante '+anagrafica_versante+'.'
	from 	#checktrace T1
	where  T1.kind='INFO_VERSANTE'
		and T1.importo_versante <> (	select sum(importoclassificazionemov)
								from #checktrace T2
								where T1.numero_reversale = T2.numero_reversale
									and T1.idinc = T2.idinc
									and T2.kind='CLASSIFICAZIONI')


	insert into #errors(error)
	select 'Importo classificazione non quadra con la somma di Importo Siope di Fattura. Numero reversale : '+ convert(varchar(10),numero_reversale) 
	from 	#checktrace T1
	where  kind='CLASSIFICAZIONI'
		and T1.importoclassificazionemov <> (	select sum(importo_siope)
								from #checktrace T2
								where T1.numero_reversale = T2.numero_reversale
									and T1.idinc = T2.idinc
									and T1.codice_cge = T2.codice_cge )

  -- il controllo agisce solo se ci sono fatture di tipo commerciale
	and (select count(*) from #checktrace T3
		where T1.numero_reversale = T3.numero_reversale and T1.idinc = T3.idinc and T1.codice_cge = T3.codice_cge 
			and kind='CLASSIFICAZIONI_FATTURASIOPE' and isnull(T3.importo_siope,0) >0 )>0


	insert into #errors(error)
	select 'ARCONET-Importo versante non quadra con la somma di importo codice economico siope. Numero reversale : '+ convert(varchar(10),numero_reversale) + ', versante '+anagrafica_versante+'.'
	from 	#checktrace T1
	where T1.importo_versante <> isnull( (	select sum(importo_codice_economico_siope)
								from #checktrace T2
								where T1.numero_reversale = T2.numero_reversale
									and T1.idinc = T2.idinc),0)
	and (select count(*) from #checktrace T3
	where T1.numero_reversale = T3.numero_reversale and T1.idinc = T3.idinc and kind='ARCONET')>0

	-- SELECT * FROM #checktrace
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
