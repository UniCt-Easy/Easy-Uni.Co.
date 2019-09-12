if exists (select * from dbo.sysobjects where id = object_id(N'[entrydetailcompleta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [entrydetailcompleta]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    procedure [entrydetailcompleta]
	@year  int ,
	@codepatrimony varchar(50),
	@codeplaccount varchar(50),
	@idupb varchar(36)
AS
BEGIN

--exec entrydetailcompleta 2015, null, null, '%'
if @codepatrimony is null
SET @codepatrimony = '%'

if @codeplaccount is null
SET @codeplaccount = '%'

set @idupb = isnull(@idupb,'%')

SELECT
	entrydetail.yentry as 'Anno Scrittura',
	entrydetail.nentry as'Numero Scrittura',
	entrydetail.ndetail as 'Numero dettaglio',
	account.codeacc as 'Codice Conto',
	account.title as 'Denominazione Conto',
	upb.codeupb as 'Codice UPB',
	upb.title as 'Denominazione UPB',
	placcount.codeplaccount as 'Codice CE',
	placcount.title as 'Denominazione CE',
	patrimony.codepatrimony as 'Codice SP',
	patrimony.title as 'Denominazione SP',
	CASE
		WHEN ISNULL(amount,0) < 0 THEN -amount
		ELSE NULL
	END as 'Dare',
	CASE
		WHEN ISNULL(amount,0) >= 0 THEN amount
		ELSE NULL
	END as 'Avere',
	(select sortcode from sorting where idsor = entrydetail.idsor1) as 'Centro di costo',
	COALESCE ((Select sortcode from sorting where idsor=entry.idsor01), (select sortcode from sorting where idsor =upb.idsor01)) as 'Organigramma',
	registry.title as 'Anagrafica', 
	entrydetail.idreg as 'Codice Anagrafica',
	entry.description as 'Descrizione Scrittura',
	entrydetail.description as 'Descrizione dettaglio scrittura',
	entry.adate as 'Data contabile',
	entry.doc as 'Documento collegato',
	entry.docdate as 'Data documento collegato',
	--entry.idrelated as 'Documento relazionato',
	accmotive.title as 'Descrizione causale',
	accmotive.codemotive as 'Codice causale',
	ek.description as 'Tipo Conto',
	entrydetail.competencystart as 'Data inizio comp.',
	entrydetail.competencystop as 'Data fine comp.',
	entrydetail.cu as 'Utente che ha creato',
	entrydetail.ct as 'Data/ora ultima modifica',
	entrydetail.lu as 'Utente Ultima modifica',
	entrydetail.lt as 'Data/ora Ultima modifica'		
FROM entrydetail
INNER JOIN entry
	ON entrydetail.yentry = entry.yentry
	AND entrydetail.nentry = entry.nentry
LEFT OUTER JOIN registry
	ON entrydetail.idreg = registry.idreg
LEFT OUTER JOIN upb
	ON entrydetail.idupb = upb.idupb
LEFT OUTER JOIN account
	ON entrydetail.idacc = account.idacc
LEFT OUTER JOIN  accmotive
	ON entrydetail.idaccmotive = accmotive.idaccmotive
LEFT OUTER JOIN  entrykind ek
	ON ek.identrykind = entry.identrykind
LEFT OUTER JOIN patrimony
	ON account.idpatrimony=patrimony.idpatrimony
LEFT OUTER JOIN placcount
	ON account.idplaccount = placcount.idplaccount
WHERE entry.yentry = @year
	and isnull(patrimony.codepatrimony,'') like @codepatrimony +'%'
	and isnull(placcount.codeplaccount,'') like @codeplaccount +'%'
	and upb.idupb like @idupb

END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

