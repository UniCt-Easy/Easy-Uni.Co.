if OBJECTPROPERTY(object_id('rpt_riepilogo_ritenute_applicate1'), 'IsProcedure') = 1
	drop procedure rpt_riepilogo_ritenute_applicate1
go


CREATE                             PROCEDURE [rpt_riepilogo_ritenute_applicate1]
  @ayear                 smallint, 
  @registry              varchar(100), 
  @tax                   varchar(20),
  @datebegin             smalldatetime,
  @dateend               smalldatetime
AS
  BEGIN
      SELECT
        registry.title as 'title',
        tax.description as 'description',
        'imponibilelordo'    = SUM(tabella.taxablegross),
        'imponibilenetto'    = SUM(tabella.taxablenet),
        'ritdipendente'      = SUM(tabella.employtax),
        'ritamministrazione' = SUM(tabella.admintax),
	'detrazioni applicate' = SUM(tabella.abatements)
      FROM 
      	(select max(isnull(E.taxablegross,0)) as 'taxablegross',
	        sum(isnull(E.taxablenet,0))   as 'taxablenet',
	        sum(isnull(E.employtax,0))    as 'employtax',
	        sum(isnull(E.admintax,0))     as 'admintax',
		sum(isnull(E.abatements,0))   as 'abatements',
                E.idexp,
                E.taxcode,
	        expense.idreg
       	 from expensetaxview as E
         JOIN expense ON expense.idexp = E.idexp
         WHERE expense.ymov = @ayear  AND
               E.datetaxpay BETWEEN @datebegin AND @dateend 
         group by expense.idreg,E.idexp,E.taxcode)  as tabella
       join registry on tabella.idreg = registry.idreg 
       join tax on tabella.taxcode = tax.taxcode
       where title like @registry AND
       description like @tax
       GROUP BY title, description
       ORDER BY description, title
  END


