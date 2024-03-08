
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine_RUP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine_RUP]
GO

SET QUOTED_IDENTIFIER ON	
GO
SET ANSI_NULLS ON 
GO
--setuser'amministrazione'
--setuser'amm'
--rpt_buono_ordine_RUP 2021, 9, 'ACQCOMM' , '2022-17-10'
CREATE PROCEDURE rpt_buono_ordine_RUP
    @ayear INT,
    @ninv INT,
    @codeinvkind VARCHAR(20),
	@sessiondate DATETIME
AS
BEGIN
    DECLARE @arrivalprotocolnum VARCHAR(50);
    DECLARE @protocoldate DATETIME;
	DECLARE @doc VARCHAR(100);
    DECLARE @adate  DATETIME;
    DECLARE @idreg INT;
    DECLARE @idmankind VARCHAR(50);
    DECLARE @nman INT;
    DECLARE @codefin VARCHAR(150);
    DECLARE @finance VARCHAR(200);
    DECLARE @cigcode VARCHAR(200);
    DECLARE @description VARCHAR(400);
    DECLARE @durcdoc VARCHAR(200);
    DECLARE @durcstart DATETIME;
    DECLARE @durcstop DATETIME;
	DECLARE @refdate DATETIME;
    DECLARE @dataordine DATETIME;
    DECLARE @idregrup INT;
    DECLARE @rup VARCHAR(100);
    DECLARE @yman INT;
	DECLARE @idinvkind INT 
	DECLARE @protocolnum int
    -- setuser 'amministrazione'
    -- exec rpt_buono_ordine 2017, 'X', 'GENERALE', 1, 1, NULL, 'N', 'N', {ts '2017-12-31 00:00:00'}, 'N', NULL, NULL, NULL, NULL, NULL
    IF (@ayear = 0)
    BEGIN
        SET @ayear = '1900';
    END;
	
    -- Fatture
    SELECT DISTINCT i.idreg, i.idinvkind,
           i.yman,
           i.nman,
		   inv.ninv,
		   inv.doc,
           i.codeinvkind,
           i.idmankind,
		   i.manrownum,
		   i.idepexp,
		   m.idreg_rupanac,
		   rupanac.title as rup,
		   m.cigcode,
		   m.description as descordine,
           m.adate as dataordine,  
           i.mandetaildescription,
           number,
           i.taxable, --  prezzounitario
           tax,
           rate AS iva,
           Imponibile = number * i.taxable - (number * i.taxable) * ISNULL(i.discount, 0),
           CONVERT(DECIMAL(19, 2), number * i.taxable - (number * i.taxable) * ISNULL(i.discount, 0) + i.tax) AS ImpTotale,
           i.discount AS Sconto,
           inv.arrivalprotocolnum,
           inv.protocoldate,
            inv.adate as adate,
		   inv.docdate,-- CONVERT(VARCHAR, inv.docdate, 103) as docdate,
           i.registry,
           inv.description,
           i.detaildescription,
           i.rownum,
		   dateadd(day,isnull(inv.paymentexpiring,0),	case 
		when (inv.idexpirationkind=1) then inv.adate
		when (inv.idexpirationkind=2) then inv.docdate
		when (inv.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(inv.docdate) ,inv.docdate)))
		when (inv.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(inv.adate) ,inv.adate)))
		when (inv.idexpirationkind=5) then inv.adate
		when (inv.idexpirationkind=6) then inv.protocoldate
	end
	) AS datascadenza
	,i.codeupb
	,i.ivakind
    INTO #fatture
    FROM invoicedetailview i
        JOIN invoice inv
            ON inv.yinv = i.yinv
               AND inv.ninv = i.ninv
               AND inv.idinvkind = i.idinvkind
		LEFT OUTER JOIN mandate m on 
				i.idmankind = m.idmankind 
				AND i.yman = m.yman 
				AND i.nman = m.nman 
		LEFT OUTER JOIN registry rupanac on 
		m.idreg_rupanac = rupanac.idreg
    WHERE
         (i.yinv = @ayear)
        AND i.ninv = @ninv
        AND codeinvkind = @codeinvkind
    ORDER BY i.codeinvkind,
             i.nman;

			 
    SELECT DISTINCT
           @idreg = idreg
    FROM #fatture;

    SELECT DISTINCT
           @idinvkind = idinvkind
    FROM #fatture;
	
    SELECT top 1
           @adate = docdate
    FROM #fatture;
   
    SELECT DISTINCT
           @ninv = ninv
    FROM #fatture;

	-- SELECT @refdate = @sessiondate
	SELECT @refdate = GETDATE()

 
    SELECT top 1
		   @durcdoc = doc,
           @durcstart = start,
           @durcstop = stop
    FROM dbo.registrydurcview
    WHERE idreg = @idreg
          --AND stop >= @refdate
		  order by stop desc;

 SELECT @protocolnum = protocolnum FROM ivaregister 
 WHERE ninv = @ninv AND yinv = @ayear AND idinvkind = @idinvkind

	--- impegni di budget di
    SELECT DISTINCT
		   #fatture.idmankind,
		   #fatture.yman,
		   #fatture.nman,
		   #fatture.manrownum,
		   EPX.idrelated,
		   EPX.idacc,
           EPX.codeacc,
		   EPX.account,
		   EPX.idupb,
           EPX.codeupb,
		   EPX.upb,
           EPX.yepexp,
           EPX.nepexp
    INTO #impegnibudget
    FROM #fatture 
		LEFT OUTER JOIN epexpview EPX ON 
		  EPX.idepexp = #fatture.idepexp
		  AND EPX.ayear = (SELECT min(ayear) from epexpyear where epexpyear.idepexp = EPX.idepexp )

    -- SELECT * FROM #impegnibudget
    SELECT DISTINCT
		   #fatture.idmankind,
		   #fatture.yman,
		   #fatture.nman,
		   #fatture.manrownum,
		   EPX.idfin,
		   EPX.codefin,
           EPX.finance,
		   EPX_iva.idfin   as idfin_iva,
		   EPX_iva.codefin as codefin_iva,
           EPX_iva.finance as finance_iva,
		   EPX.idupb,
           EPX.codeupb,
		   EPX.upb,
		   EPX_iva.idupb as idupb_iva ,
           EPX_iva.codeupb as codeupb_iva,
		   EPX_iva.upb as upb_iva,
		   MD.yexpimpo,
           MD.nexpimpo,
		   MD.yexpiva,
           MD.nexpiva
    INTO #impegnifinanziari
    FROM #fatture 
	LEFT OUTER JOIN mandatedetailview MD ON 
		   MD.nman = #fatture.nman
          AND MD.yman = #fatture.yman 
          AND MD.idmankind = #fatture.idmankind
		  AND MD.rownum = #fatture.manrownum
	LEFT OUTER JOIN expenseview EPX ON 
		  EPX.idexp = MD.idexp_taxable 
		  AND EPX.ayear =    (SELECT min(ayear) from expenseyear where expenseyear.idexp = EPX.idexp )
	LEFT OUTER JOIN expenseview EPX_iva ON 
		  EPX_iva.idexp = MD.idexp_iva 
		  AND EPX_iva.ayear =   (SELECT min(ayear) from expenseyear where expenseyear.idexp = EPX_iva.idexp)
	  

 IF ( @refdate between isnull(@durcstart,{d '1900-01-01'}) and isnull(@durcstop, {d '2079-01-01'})	)
 BEGIN
	SELECT @refdate as refdate,
		(SELECT top 1 cigcode  FROM #fatture  where cigcode is not null ) AS cigcode,
           description AS descordine,
		   #fatture.doc,
           CONVERT(VARCHAR, docdate, 103) AS datafattura,
           #impegnifinanziari.codefin AS codefin,
           #impegnifinanziari.finance AS finance,
		   #impegnifinanziari.codefin_iva AS codefin_iva,
           #impegnifinanziari.finance_iva AS finance_iva,
           @durcdoc AS durcdoc,
           case when @durcstart is not null then  CONVERT(VARCHAR, @durcstart, 103) 
		   else null
		   end     AS durcstart,
           case when @durcstop is not null then  CONVERT(VARCHAR, @durcstop, 103) 
		   else null 
		   end AS durcstop,
           rup,
           #fatture.idreg,
           #fatture.yman,
           #fatture.nman,
		   CONVERT(VARCHAR, #fatture.dataordine, 103) as dataordine,
		   #fatture.manrownum,
		   mandetaildescription,
           ninv,
           codeinvkind,
           #fatture.idmankind,
           registry,
           description AS descrfattura,
           detaildescription AS descrDettFattura,
           number,
           taxable, --  prezzounitario
           tax,
           iva,
           Imponibile,
           ImpTotale,
           Sconto,
           --arrivalprotocolnum,
		   @protocolnum AS protocolnum,
           CONVERT(VARCHAR, protocoldate, 103) AS protocoldate,
           CONVERT(VARCHAR,  #fatture.adate, 103) AS adate,
           #fatture.rownum,
           #impegnibudget.codeacc,
           #impegnibudget.account,
           #impegnibudget.idrelated,
           #impegnibudget.yepexp,
           #impegnibudget.nepexp,
		   CONVERT(VARCHAR, datascadenza, 103) AS datascadenza, 
		   isnull(#impegnibudget.codeupb,#impegnifinanziari.codeupb) as codeupb,
		   ivakind
    FROM #fatture
        LEFT OUTER JOIN #impegnibudget
          ON #impegnibudget.nman = #fatture.nman
          AND #impegnibudget.yman = #fatture.yman 
          AND #impegnibudget.idmankind = #fatture.idmankind
		  AND #impegnibudget.manrownum = #fatture.manrownum
		 LEFT OUTER JOIN #impegnifinanziari
          ON #impegnifinanziari.nman = #fatture.nman
          AND #impegnifinanziari.yman = #fatture.yman 
          AND #impegnifinanziari.idmankind = #fatture.idmankind
		  AND #impegnifinanziari.manrownum = #fatture.manrownum 
    ORDER BY #fatture.rownum;
	END
	ELSE
	BEGIN
		SELECT 
		@refdate as refdate,
		'' AS cigcode,
        '' AS descordine,
		'' AS doc,
	    NULL AS datafattura,
        '' AS codefin,
        '' AS finance,
		'' AS codefin_iva,
        '' AS  finance_iva,
        @durcdoc AS durcdoc,
       NULL AS  durcstart,
        NULL AS  durcstop,
        '' AS   rup,
        NULL AS idreg,
        NULL AS yman,
		NULL AS nman,
		NULL AS dataordine,
	    NULL AS manrownum,
	    '' AS mandetaildescription,
        NULL AS ninv,
        '' AS  codeinvkind,
        '' AS idmankind,
        '' AS registry,
        NULL AS descrfattura,
        '' AS  descrDettFattura,
        NULL AS  number,
        NULL AS taxable, --  prezzounitario
        NULL AS tax,
        NULL AS iva,
        NULL AS Imponibile,
        NULL AS ImpTotale,
        NULL AS  Sconto,
           --arrivalprotocolnum,
		@protocolnum AS protocolnum,
       NULL AS   protocoldate,
	   NULL  AS  adate,
       NULL AS rownum,
       '' AS codeacc,
       '' AS account,
       '' AS idrelated,
       NULL AS yepexp,
       NULL AS nepexp,
	   NULL  AS  datascadenza, 
	   '' AS  codeupb,
       '' AS  ivakind
	END
 

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 


 
