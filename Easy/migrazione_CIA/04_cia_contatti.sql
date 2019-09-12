if exists (select * from dbo.sysobjects where id = object_id(N'[exp_contatti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_contatti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE [exp_contatti]

AS BEGIN
-- Il telefono dei dipendenti è presente solo in DIPENDENTI come campo, ma non vi sono record col questa info valorizzata. Non ci sono righe neanche in INDIRIZZI e CONTATTO.
SELECT distinct
	LKA.idreg as 'codice',
	I.TELEFONO,
	I.FAX,
	I.EMAIL
FROM ANAGRAFICO A
JOIN lookup_anagrafica LKA
	ON LKA.codice = A.codice
JOIN INDIRIZZO I
	ON A.codice = I.codice
WHERE LKA.tipo ='A' AND (I.TELEFONO is not null OR I.FAX is not null OR I.EMAIL is not null)
UNION ALL
SELECT distinct
	LKA.idreg as 'codice',
	C.TELEFONO,
	C.FAX,
	C.EMAIL
FROM ANAGRAFICO A
JOIN lookup_anagrafica LKA
	ON LKA.codice = A.codice
JOIN CONTATTO C
	ON C.codice = A.codice
WHERE LKA.tipo ='A' AND (C.TELEFONO is not null OR C.FAX is not null OR C.EMAIL is not null)


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

	--EXEC exp_contatti

------------------------------------------------------------------------------------------------------------------------------------------------------------
