
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


CREATE PROCEDURE rpt_buono_ordine_RUP
    @ayear INT,
    @ninv INT,
    @codeinvkind VARCHAR(20)
AS
BEGIN
    DECLARE @arrivalprotocolnum VARCHAR(50);
    DECLARE @protocoldate SMALLDATETIME;
    DECLARE @adate SMALLDATETIME;
    DECLARE @idreg INT;
    DECLARE @idmankind VARCHAR(50);
    DECLARE @nman INT;
    DECLARE @codefin VARCHAR(150);
    DECLARE @finance VARCHAR(200);
    DECLARE @cigcode VARCHAR(200);
    DECLARE @description VARCHAR(400);
    DECLARE @durcdoc VARCHAR(200);
    DECLARE @durcstart SMALLDATETIME;
    DECLARE @durcstop SMALLDATETIME;
    DECLARE @dataordine SMALLDATETIME;
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
           i.ninv,
           i.codeinvkind,
           i.idmankind,
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
           inv.adate,
		   inv.docdate,
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
	, i.ivakind
    INTO #fatture
    FROM invoicedetailview i
        JOIN invoice inv
            ON inv.yinv = i.yinv
               AND inv.ninv = i.ninv
               AND inv.idinvkind = i.idinvkind
    WHERE
         (i.yinv = @ayear)
        AND i.ninv = @ninv
        AND codeinvkind = @codeinvkind
    ORDER BY i.codeinvkind,
             i.nman;

    -- SELECT * FROM #fatture
    SELECT DISTINCT
           @idreg = idreg
    FROM #fatture;

    SELECT DISTINCT
           @idinvkind = idinvkind
    FROM #fatture;

    SELECT DISTINCT
           @yman = yman
    FROM #fatture;
    SELECT DISTINCT
           @adate = docdate
    FROM #fatture;
    SELECT DISTINCT
           @idmankind = idmankind
    FROM #fatture;
    SELECT DISTINCT
           @ninv = ninv
    FROM #fatture;
    SELECT DISTINCT
           @nman = nman
    FROM #fatture;


    SELECT @durcdoc = doc,
           @durcstart = start,
           @durcstop = stop
    FROM dbo.registrydurcview
    WHERE idreg = @idreg
          AND stop >= @adate;


 SELECT @protocolnum = protocolnum FROM ivaregister 
 WHERE ninv = @ninv AND yinv = @ayear AND idinvkind = @idinvkind

    -- impegni di budget
    SELECT account.idacc,
           account.codeacc,
           account.title,
           idrelated,
           yepexp,
           nepexp
    INTO #impegnibudget
    FROM epexpview
        JOIN account
            ON account.idacc = epexpview.idacc
               AND account.ayear = epexpview.ayear
    WHERE 
        idrelated LIKE 
        'man§' + @idmankind + '§' + CONVERT(VARCHAR(4), @yman) + '§' + CONVERT(VARCHAR(4), @nman) + '§' + '%'
        AND nphase = 2;

    -- SELECT * FROM #impegnibudget
    SELECT @codefin = codefin,
           @finance = finance
    FROM expensemandateview
    WHERE nman = @nman
          AND yman = @ayear
          AND idmankind = @idmankind;

    SELECT @cigcode = cigcode,
           @description = description,
           @dataordine = CONVERT(VARCHAR, adate, 103),
           @idregrup = idreg_rupanac
    FROM mandate
    WHERE nman = @nman
          AND yman = @yman
          AND idmankind = @idmankind;

    SELECT @rup = r.title
    FROM dbo.registry r
    WHERE r.idreg = @idregrup;

    SELECT DISTINCT @cigcode AS cigcode,
           @description AS descordine,
           CONVERT(VARCHAR, @adate, 103) AS datafattura,
           @codefin AS codefin,
           @finance AS finance,
           @durcdoc AS durcdoc,
           CONVERT(VARCHAR, @durcstart, 103) AS durcstart,
           CONVERT(VARCHAR, @durcstop, 103) AS durcstop,
           @rup AS rup,
           idreg,
           yman,
           nman,
           @dataordine AS dataordine,
           ninv,
           codeinvkind,
           idmankind,
           mandetaildescription,
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
           CONVERT(VARCHAR, adate, 103) AS adate,
           rownum,
        --   idacc,
           codeacc,
           title,
           idrelated,
           yepexp,
           nepexp,
		   CONVERT(VARCHAR, datascadenza, 103) AS datascadenza, 
		   codeupb,
		   ivakind
    FROM #fatture
        LEFT OUTER JOIN #impegnibudget
            ON idrelated = 'man§' + idmankind + '§' + CONVERT(VARCHAR(4), yman) + '§' + CONVERT(VARCHAR(4), nman) + '§'
                           + CONVERT(VARCHAR(4), rownum)
    ORDER BY rownum;


END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


