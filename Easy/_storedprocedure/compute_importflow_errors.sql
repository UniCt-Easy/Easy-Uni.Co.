
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_importflow_errors]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_importflow_errors]
GO

--setuser 'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--[compute_importflow_errors] 2020

CREATE  PROCEDURE [compute_importflow_errors]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #errors (idriga varchar(12), errordescr varchar(600))
 
DECLARE @ayearstr varchar(4)
SET @ayearstr = CONVERT(varchar(4), @ayear)

-------------------------------------------------
----- 1 idreg non valorizzato -------------------
-------------------------------------------------
 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND idreg is null)
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow, 'idreg non valorizzato(codice anagrafica).'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND idreg is null
--END

-------------------------------------------------
----- 2 anagrafica non trovata ------------------
-------------------------------------------------

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND idreg is not null
--and not exists (select * from registry R where R.idreg = idreg))
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'anagrafica non trovata.'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND idreg is not null 
	and not exists (select * from registry R where R.idreg = idreg)
--END

------------------------------------------------------------------
----- 3 idregistrypaymethod non valorizzato (S)-------------------
------------------------------------------------------------------

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND idregistrypaymethod is null and E_S = 'S')
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'idregistrypaymethod non valorizzato(codice modalità pagamento anagrafica).'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND idregistrypaymethod is null and E_S = 'S'
--END

--------------------------------------------------------------------
----- 4 modalità pagamento anagrafica non trovata ------------------
--------------------------------------------------------------------
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--AND idregistrypaymethod is not null and E_S = 'S' AND NOT EXISTS (select * from registrypaymethod R where 
--R.idreg = idreg and R.idregistrypaymethod = idregistrypaymethod))
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'idregistrypaymethod non trovato(codice modalità pagamento anagrafica).'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND idregistrypaymethod is not null and E_S = 'S' AND NOT EXISTS (select * from registrypaymethod R where 
	R.idreg = idreg and R.idregistrypaymethod = idregistrypaymethod) and E_S = 'S'
--END

---------------------------------------------------------------
----- 5 importo non valorizzato -------------------------------
---------------------------------------------------------------

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND isnull(importo,0 ) = 0 )
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'importo non valorizzato.'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND isnull(importo,0 ) = 0 
--END
---------------------------------------------------------------
----- 6 importo negativo ------ -------------------------------
---------------------------------------------------------------

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND isnull(importo,0 ) < 0 )
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'importo negativo.'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND isnull(importo,0 ) < 0 
--END


---------------------------------------------------------------
----- 7 E_S non corretto --------------------------------------
---------------------------------------------------------------

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND upper(ltrim(rtrim(isnull(E_S,'' )))) NOT IN ('E', 'S'))
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'Tipo Movimento (E_S) non corretto.'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null AND upper(ltrim(rtrim(isnull(E_S,'' )))) NOT IN ('E', 'S')
--END


---------------------------------------------------------------
----- 8 codefin  not null e idfin is null  -------------------- 
---------------------------------------------------------------

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  (codefin is not null) AND idfin is null)
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'Voce bilancio non individuata.'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND  (codefin is not null) AND idfin is null
--END

	INSERT INTO #errors 
	SELECT idimportflow,'Voce bilancio non specificata.'
	FROM import_flow WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND  codefin is null and Anno_accimp is null



---------------------------------------------------------------
----- 9 codeupb  not null e idupb is null  --------------------
---------------------------------------------------------------

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  (codeupb  is not null) AND idupb is null)
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'Upb non individuato'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND  (codeupb is not null) AND idupb is null 
--END

	INSERT INTO #errors 
	SELECT idimportflow,'Upb non specificato'
	FROM import_flow WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND  codeupb is null  and Anno_accimp is null 

-------------------------------------------------------------------------------
----- 10 codtipoclass1 /sortcode1 not null e idsor1 is null -------------------- 
-------------------------------------------------------------------------------
 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  (codtipoclass1 is not null or sortcode1 is not null) AND idsor1 is null)
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'idsor1 non individuato (Codice classificazione 1).'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	 AND  (codtipoclass1 is not null or sortcode1 is not null) AND idsor1 is null  
--END

 

-------------------------------------------------------------------------------
----- 11 codtipoclass2 /sortcode2 not null e idsor2 is null -------------------- 
-------------------------------------------------------------------------------
 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  (codtipoclass2 is not null or sortcode2 is not null) AND (idsor2 is null))
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'idsor2 non individuato (Codice classificazione 2).'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	 AND  (codtipoclass2 is not null or sortcode2 is not null) AND (idsor2 is null)
--END

 


-------------------------------------------------------------------------------
----- 12 codtipoclass3 /sortcode3 not null e idsor3 is null -------------------- 
-------------------------------------------------------------------------------
 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  (codtipoclass3 is not null or sortcode3 is not null) AND (idsor3 is null))
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'idsor3 non individuato (Codice classificazione 3).'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND  (codtipoclass3 is not null or sortcode3 is not null) AND (idsor3 is null)
--END

 

-------------------------------------------------------------------------------
----- 13 codtipoclass4 /sortcode4 not null e idsor4 is null -------------------- 
-------------------------------------------------------------------------------
 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  (codtipoclass4 is not null or sortcode4 is not null) AND (idsor4 is null))
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'idsor4 non individuato (Codice classificazione 4).'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND  (codtipoclass4 is not null or sortcode4 is not null) AND (idsor4 is null)
--END

 

-------------------------------------------------------------------------------
----- 14 codtipoclass5 /sortcode5 not null e idsor5 is null -------------------- 
-------------------------------------------------------------------------------
 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  (codtipoclass5 is not null or sortcode5 is not null) AND (idsor5 is null))
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow, 'idsor5 non individuato (Codice classificazione 5).'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND  (codtipoclass5 is not null or sortcode5 is not null) AND (idsor5 is null)
--END

 

-------------------------------------------------------------------------------
-----   15 accertamento non individuato  -------------------------------------- 
-------------------------------------------------------------------------------
 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND (anno_accimp IS not NULL OR numero_accimp is  not null)  and E_S = 'E' and acc_idinc is null)
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'accertamento non individuato.'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND (anno_accimp IS not NULL OR numero_accimp is  not null)  and E_S = 'E' and acc_idinc is null
--END



-------------------------------------------------------------------------------
-----   16 impegno non individuato  ------------------------------------------- 
-------------------------------------------------------------------------------
 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND (anno_accimp IS not NULL OR numero_accimp is  not null)  and E_S = 'S' and imp_idexp is null)
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'impegno non individuato.'
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
	AND (anno_accimp IS not NULL OR numero_accimp is  not null)  and E_S = 'S' and imp_idexp is null
--END

-------------------------------------------------------------------------------
----- 17 manager  non individuato ------------------------------------------ 
-------------------------------------------------------------------------------

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--            and idman is not  null and not exists (select * from manager M where M.idman = idman) )
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'(idman) Responsabile non individuato '
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
     and idman is not  null and not exists (select * from manager M where M.idman = idman)    
--END

-------------------------------------------------------------------------------
----- 18 conto finanziario accertamento non coerente--------------------------- 
-------------------------------------------------------------------------------

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  acc_idfin is not null  AND idfin is not null  and acc_idfin <> idfin  )
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'Voce bilancio incoerente '
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
    AND  acc_idfin is not null  AND idfin is not null  and acc_idfin <> idfin  
--END

----------------------------------------------------------------- 
----- 19 UPB accertamento non coerente--------------------------- 
----------------------------------------------------------------- 

--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  acc_idupb is not null  AND idupb is not null  and acc_idupb <> idupb  )
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'Upb incoerente '
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
    AND  acc_idupb is not null  AND idupb is not null  and acc_idupb <> idupb 
--END

----------------------------------------------------------------- 
----- 20 conto finanziario impegno non coerente------------------ 
----------------------------------------------------------------- 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  imp_idfin is not null  AND idfin is not null  and imp_idfin <> idfin  )
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'Voce bilancio incoerente '
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
    AND  imp_idfin is not null  AND idfin is not null  and imp_idfin <> idfin  
--END

----------------------------------------------------------------- 
----- 21 UPB impegno non coerente-------------------------------- 
----------------------------------------------------------------- 
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND  imp_idupb is not null  AND idupb is not null  and imp_idupb <> idupb  )
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'Upb incoerente '
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
    AND  imp_idupb is not null  AND idupb is not null  and imp_idupb <> idupb 
--END

----------------------------------------------------------------- 
----- 22 cod cassiere non valorizzato---------------------------- 
-----------------------------------------------------------------
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--           AND manrev = 'S' and cod_cassiere  is null )
--BEGIN
	--INSERT INTO #errors 
	--SELECT idimportflow,'(cod_cassiere) codice cassiere non valorizzato '
	--FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
 --   AND manrev = 'S' and cod_cassiere  is null
--END
 
 
----------------------------------------------------------------- 
----- 23   cassiere non trovato --------------------------------- 
-----------------------------------------------------------------
--IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
--            and cod_cassiere  is not null and idtreasurer is null)
--BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'cassiere non trovato  '
	FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
    and cod_cassiere  is not null and idtreasurer is null
--END
 
----------------------------------------------------------------- 
----- 24 importazione padre non trovata ------------------------- 
-----------------------------------------------------------------
 IF EXISTS (SELECT * FROM import_flowview WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
              and idimportflow_parent  is not null and not exists
     (select * from import_flow I where I.idimportflow = idimportflow_parent ))

 BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'importazione padre non trovata'
	FROM import_flow WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
    and idimportflow_parent  is not null and not exists
     (select * from import_flow I where I.idimportflow = import_flow.idimportflow_parent )
END
 
 ----------------------------------------------------------------- 
----- 25  sospeso uscita non coperto ------------------------- 
-----------------------------------------------------------------
 IF EXISTS (SELECT * FROM import_flow WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
              and nbill  is not null and E_S='S' 
			and isnull ( 
						(select total from bill B where B.billkind='D' and B.ybill=@ayear and B.nbill = import_flow.nbill)
						,0)
				<> isnull( 
						(select sum(importo) from import_flow I2 where I2.esercizio = @ayear AND I2.id_liq is null and  I2.id_inc is null 
							and I2.nbill  = import_flow.nbill  and I2.E_S='S' )
					,0) )

 BEGIN
	INSERT INTO #errors 
	SELECT idimportflow, 'sospeso uscita non coperto. Num.' + convert(varchar(8), nbill) 
	FROM import_flow WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
              and nbill  is not null and E_S='S' 
			and isnull ( 
						(select total from bill B where B.billkind='D' and B.ybill=@ayear and B.nbill = import_flow.nbill)
						,0)
				<> isnull( 
						(select sum(importo) from import_flow I2 where I2.esercizio = @ayear AND I2.id_liq is null and  I2.id_inc is null 
							and I2.nbill  = import_flow.nbill  and I2.E_S='S' )
					,0)
END
 
 ----------------------------------------------------------------- 
----- 26  sospeso entrata non coperto ------------------------- 
-----------------------------------------------------------------
 IF EXISTS (SELECT * FROM import_flow WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
              and nbill  is not null and E_S='E' 
			and isnull ( 
						(select total from bill B where B.billkind='C' and B.ybill=@ayear and B.nbill = import_flow.nbill)
						,0)
				<> isnull( 
						(select sum(importo) from import_flow I2 where I2.esercizio = @ayear AND I2.id_liq is null and  I2.id_inc is null 
							and I2.nbill  = import_flow.nbill  and I2.E_S='E' )
					,0) )

 BEGIN
	INSERT INTO #errors 
	SELECT idimportflow,'sospeso entrata non coperto'
	FROM import_flow WHERE esercizio = @ayear AND id_liq is null and  id_inc is null 
              and nbill  is not null and E_S='E' 
			and isnull ( 
						(select total from bill B where B.billkind='C' and B.ybill=@ayear and B.nbill = import_flow.nbill)
						,0)
				<> isnull( 
						(select sum(importo) from import_flow I2 where I2.esercizio = @ayear AND I2.id_liq is null and  I2.id_inc is null 
							and I2.nbill  = import_flow.nbill  and I2.E_S='E' )
					,0)
END

SELECT * FROM #errors
END
 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

