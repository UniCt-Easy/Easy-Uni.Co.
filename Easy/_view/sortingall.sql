-- CREAZIONE VISTA sortingall
IF EXISTS(select * from sysobjects where id = object_id(N'[sortingall]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sortingall]
GO





--setuser 'amm'
--clear_table_info 'sortingusable'

--select * from sortingall

CREATE        VIEW [sortingall]

AS SELECT
	* from sorting





GO
