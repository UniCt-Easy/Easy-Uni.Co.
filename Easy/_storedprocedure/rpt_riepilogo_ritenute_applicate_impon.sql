
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_riepilogo_ritenute_applicate_impon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_riepilogo_ritenute_applicate_impon]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [rpt_riepilogo_ritenute_applicate_impon]
  @ayear int, 
  @idreg int, 
  @tax   int,
  @start datetime,
  @stop  datetime,
  @mode  char(1),
  @suppressrow char(1),    --> E' un check che chieda se si intende visualizzare o nascondere le ritenute applicate e poi annullate nel periodo    
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
  BEGIN
/*
@mode è un radio button di selezione modalità, in cui si sceglie se:
1) visualizza tutti i dettagli - T
2) visualizza i dettagli raggruppati per applicato/annullato - R
3) visualizza solo saldo ( applicato-annullato ) - S

I raggruppamenti ovviamente si intendono anche  per creditore
*/

        CREATE TABLE #spesa  (idexp int, idreg int, datetaxpay datetime)
-- La data di applicazione è quella decisa in Config, di solito è la data di Tx del mandato
        INSERT INTO #spesa   (idexp, idreg, datetaxpay)

     	SELECT 
                E.idexp,        --> idexp dei movimenti interessati
                expense.idreg,
                E.datetaxpay
       	FROM expensetaxview AS E
		JOIN expense 
			ON expense.idexp = E.idexp
		join expenseyear	
			on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
		join upb	
			on expenseyear.idupb = upb.idupb
        WHERE expense.ymov = @ayear          
                AND (E.taxcode = @tax OR @tax IS NULL)
                AND E.datetaxpay is not null
                AND (E.datetaxpay BETWEEN @start AND @stop )
                AND ( expense.idreg = @idreg OR @idreg IS NULL )
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
        GROUP BY expense.idreg,E.idexp, E.datetaxpay

CREATE TABLE #tax
(
        idreg int,
	cf varchar(16),
        p_iva varchar(15),
        taxcode int,
        taxablegross decimal(19,2),
        taxablenet decimal(19,2),
        employtax decimal(19,2),
        admintax decimal(19,2),
        abatements decimal(19,2),
        idexp int,
        stop datetime,datetaxpay datetime,
        rowkind char
)

--        1) Prendere le righe che hanno Data Inizio Validità NULL
-- Applica nel periodo
 
INSERT INTO #tax
(
        taxablegross,
        taxablenet,
        employtax,
        admintax,
        abatements,
        idexp,
        taxcode,
        idreg,
        datetaxpay,
        stop,
        rowkind
)
SELECT 
        max(isnull(E.taxablegross,0)),
        isnull(sum(E.taxablenet),0),
        isnull(sum(E.employtax),0),
        isnull(sum(E.admintax),0),
        isnull(sum(E.abatements),0),
        E.idexp,
        E.taxcode,
        S.idreg,
        S.datetaxpay,
        E.stop,
        1
FROM expensetaxofficial E
JOIN #spesa S 
        ON S.idexp = E.idexp
WHERE  (E.taxcode = @tax OR @tax IS NULL)
			AND E.start IS NULL
GROUP BY E.idexp,S.idreg,E.taxcode, E.stop,S.datetaxpay 
-- Raggruppare anche per start e/o stop  mi serve per distinguere le correzioni, 
-- se ho inserito 2 correzioni IRPEF nella stampa devo vedere 2 correzioni

/*        2) Prendere le righe che hanno Data Inizio Validità compresa nel range di date di input        */
-- Correzioni fatte nel periodo

INSERT INTO #tax
(
        taxablegross,
        taxablenet,
        employtax,
        admintax,
        abatements,
        idexp,
        taxcode,
        idreg,
        datetaxpay,
        stop,
        rowkind
)
SELECT 
        max(isnull(E.taxablegross,0)),
        isnull(sum(E.taxablenet),0),
        isnull(sum(E.employtax),0),
        isnull(sum(E.admintax),0),
        isnull(sum(E.abatements),0),
        E.idexp,
        E.taxcode,
        S.idreg,
        E.start,
        E.stop,
        case when ( @mode ='T' ) 
                then 2        -- si desidera tutti i dettagli 
                else 1        -- si desidera rggrupparli   
        end
FROM expensetaxofficial E
JOIN expense S 
        ON S.idexp = E.idexp
join expenseyear	
		on S.idexp = expenseyear.idexp and S.ymov = expenseyear.ayear
join upb	
	on expenseyear.idupb = upb.idupb
WHERE  (E.taxcode = @tax OR @tax IS NULL)
        AND E.start between @start and @stop
        AND ( S.idreg = @idreg OR @idreg IS NULL )
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
 GROUP BY E.idexp,S.idreg,E.taxcode, E.start, E.stop

--        3) Prendere le righe che hanno Data Fine Validità compresa nel range di date di input;
-- Annullamenti fatti nel periodo

INSERT INTO #tax
(
        E.taxablegross,
	E.taxablenet,
        E.employtax,
        E.admintax,
        E.abatements,
        idexp,
        taxcode,
        idreg,
        datetaxpay, 
        stop,
        rowkind
)
SELECT 
        max(isnull(E.taxablegross,0)),
        isnull(sum(E.taxablenet),0),
        isnull(sum(E.employtax),0),
        isnull(sum(E.admintax),0),
        isnull(sum(E.abatements),0),
        E.idexp,
        E.taxcode,
        S.idreg,        
        E.start,
        E.stop,
        3
FROM expensetaxofficial E
JOIN expense S 
        ON S.idexp = E.idexp
join expenseyear	
		on S.idexp = expenseyear.idexp and S.ymov = expenseyear.ayear
join upb	
	on expenseyear.idupb = upb.idupb
WHERE  (E.taxcode = @tax OR @tax IS NULL)
        AND E.stop between @start and @stop
        AND ( S.idreg = @idreg OR @idreg IS NULL )
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY E.idexp,S.idreg,E.taxcode, E.start, E.stop

-- select * from #tax where taxcode  =7
IF (@suppressrow = 'S')
Begin
-- Se si è deciso di nascondere le ritenute la cui applicabilità è stata annullata nel periodo 
        DELETE FROM #tax 
        WHERE  (
                isnull(datetaxpay,@start) between @start AND @stop 
                AND isnull(stop,'01-01-2099') between @start and @stop 
                )
End

-- select * from #tax where taxcode  =7

IF (@mode='T')
Begin
        SELECT
                registry.title,
        	ISNULL(registry.cf, registry.foreigncf) as 'cf',
                registry.p_iva,
                #tax.taxcode,
                tax.description,
                #tax.taxablegross as imponibilelordo,
                #tax.taxablenet as imponibilenetto,
                #tax.employtax as ritdipendente,
                #tax.admintax as ritamministrazione,
                #tax.abatements as 'detrazioni applicate',
                #tax.rowkind,
-- per le ritenute applicate inquanto correzioni, visualizziamo nel report la data inizio della correzione
-- per le ritenute annullate visualizziamo nel report la data di fine Validità della ritenuta
                CASE 
                        when ( #tax.rowkind = 1 ) then null        
                        when ( #tax.rowkind = 2 ) then #tax.datetaxpay      
                        when ( #tax.rowkind = 3 ) then  null
                END AS  datetaxpay, 
                CASE 
                        when ( #tax.rowkind = 1 ) then null        
                        when ( #tax.rowkind = 2 ) then null      
                        when ( #tax.rowkind = 3 ) then #tax.stop
                END AS stop             
        FROM #tax
        JOIN tax
                ON tax.taxcode = #tax.taxcode
        JOIN registry
                ON #tax.idreg = registry.idreg
        ORDER BY registry.title,#tax.rowkind,#tax.taxcode
End 
ELSE
-- (@mode='R') OR(@mode = 'S')--nel report ci sarà la riga dei dettagli e la riga dle saldo se @mode =S la rig adei dettagli sarà nascosta
Begin
        SELECT
                registry.title,
        	ISNULL(registry.cf, registry.foreigncf) as 'cf',
                registry.p_iva,
                #tax.taxcode,
                tax.description,
                SUM(#tax.taxablegross) as imponibilelordo,
                SUM(#tax.taxablenet) as imponibilenetto,
                SUM(#tax.employtax) as ritdipendente,
                SUM(#tax.admintax) as ritamministrazione,
                SUM(#tax.abatements) 'detrazioni applicate',
                #tax.rowkind,
-- In caso di scelta della modalitò Raggruppa o saldo le date non saranno visualizzate, perchè i dettagli saranno raggruppati.
                NULL as datetaxpay, 
                NULL as stop
        FROM #tax
        JOIN tax
                ON tax.taxcode = #tax.taxcode
        JOIN registry
                ON #tax.idreg = registry.idreg
        GROUP BY registry.title, ISNULL(registry.cf, registry.foreigncf), registry.p_iva, #tax.taxcode,tax.description,#tax.rowkind 
        ORDER BY registry.title,#tax.rowkind,#tax.taxcode
End        

 

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


