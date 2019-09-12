if exists (select * from dbo.sysobjects where id = object_id(N'[exp_buoniscarico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_buoniscarico]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [exp_buoniscarico]
( @bilancio varchar(50)  = null 
)
AS BEGIN

DECLARE @ANAGR TABLE(
	ESERCIZIO int,
	NUMERO_DOCUMENTO int, 
	ID_INVENTARIO varchar(50), 
	idreg int
)
INSERT INTO @ANAGR(ESERCIZIO,NUMERO_DOCUMENTO,ID_INVENTARIO, idreg)
SELECT  D.ESERCIZIO, D.NUMERO_DOCUMENTO, D.ID_INVENTARIO, LKA.idreg
FROM CARICO_SCARICO_INVENT_DETT D
JOIN lookup_anagrafica LKA
	ON LKA.codice = D.codice_fornitore
WHERE (D.TIPO_DOCUMENTO ='S') --AND  C.bilancio = @bilancio
	AND (	SELECT COUNT(*)
		FROM CARICO_SCARICO_INVENT_DETT D2
		WHERE (D2.TIPO_DOCUMENTO ='S')
			and D2.bilancio = D.bilancio
			and D2.ESERCIZIO = D.ESERCIZIO 
			and D2.NUMERO_DOCUMENTO = D.NUMERO_DOCUMENTO 
			AND D2.ID_INVENTARIO = D.ID_INVENTARIO 
			AND ISNULL(D2.CODICE_FORNITORE,'') <> ISNULL(D.CODICE_FORNITORE,'')
		)=0


select 
	I.codiceinventario as 'codtipobuonoscar',
	case when I.tipo_LIB_ORD ='LIB' then I.codiceinventario + ' Libri'
		else I.codiceinventario + ' Ordinario'
	end as 'descrtipobuonoscar',
	I.codiceinventario as 'codiceinv',
	substring(I.descrizioneinventario,1,50) as 'descrinv',
	I.tipo_LIB_ORD  as 'codeinvkind',--> Codice Tipo Inventario
	CASE WHEN	I.tipo_LIB_ORD ='LIB' then 'Materiale bibliografico'
		WHEN	I.tipo_LIB_ORD ='ORD' then 'Inventario Ordinario'
		else 'ALTRO'
	end as 'descrinvkind', --> Descr. Tipo Inventario
	I.codiceente as 'codeinvagency',--> Codice Ente Inventariale
	substring(I.descrizioneente,1,150) as 'descrinvagency',--> Descrizione Ente Inventariale
	C.ESERCIZIO AS 'annobuono', --> buono scarico
	C.NUMERO_DOCUMENTO as 'numbuono',
	C.tipo_carico_scarico as 'codicecausalescar',							--> Codice Causale di carico
	substring(T.descrizione,1,50) as  'descrcausalescar',					--> Descrizione Causale di carico
	null as doc,-- Documento buono carico
	null as datadoc,--Data documento buono carico
	null as provv,-- Documento buono carico
	null as dataprovv,--Data documento buono carico
	null as descrizione,--> Descrizione buono carico
	C.DATA_DOCUMENTO as databuono,--> Data buono carico
	null as datarat, --> Data ratifica buono carico
	A.idreg as 'cessionario'
FROM CARICO_SCARICO_INVENT_DETT D
JOIN lookup_inventario I 
	ON D.ID_INVENTARIO = I.id_inventario
JOIN CARICO_SCARICO_INVENT C
	ON C.ESERCIZIO  = D.ESERCIZIO 
	AND C.TIPO_DOCUMENTO = D.TIPO_DOCUMENTO 
	AND C.NUMERO_DOCUMENTO  = D.NUMERO_DOCUMENTO 
	AND C.ID_INVENTARIO  = D.ID_INVENTARIO 
JOIN INVENTARIO_TIPO_CARICO_SCARICO T
	ON C.tipo_carico_scarico = T.codice
LEFT OUTER JOIN @ANAGR A
	ON A.ESERCIZIO  = D.ESERCIZIO 
	AND A.NUMERO_DOCUMENTO  = D.NUMERO_DOCUMENTO 
	AND A.ID_INVENTARIO  = D.ID_INVENTARIO 
WHERE (C.TIPO_DOCUMENTO ='S')
	---and C.bilancio = @bilancio
GROUP BY C.ESERCIZIO, C.NUMERO_DOCUMENTO, C.DATA_DOCUMENTO,A.idreg	,
	I.codiceinventario, I.codiceinventario, I.descrizioneinventario,I.tipo_LIB_ORD ,	I.codiceente, I.descrizioneente,
	C.tipo_carico_scarico, T.descrizione 
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

EXEC exp_buoniscarico 'A.AMMCE'		--'A.DIPEG'

------------------------------------------------------------------------------------------------------------------------------------------------------------
