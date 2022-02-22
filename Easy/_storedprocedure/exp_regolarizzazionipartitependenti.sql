
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_regolarizzazionipartitependenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_regolarizzazionipartitependenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec exp_regolarizzazionipartitependenti 2020, {d '2020-12-31'} 
CREATE procedure exp_regolarizzazionipartitependenti( 
	@ayear int,
	@adate datetime,
	@kind char(1)
	) as
begin
	SELECT 
		BT.nbill as'N.Partita pendente', 
		BT.amount 'Importo singola regolarizzazione',
		BT.adate as 'Data regolarizzazione',
		CASE ISNULL(B.active,'S')
			WHEN 'S' THEN 
			isnull(B.total,0) -  
			isnull(B.reduction,0) -	
			isnull((SELECT SUM(BT2.amount)
				FROM billtransaction BT2
				WHERE BT2.nbill = B.nbill 
						and BT2.ybilltran= B.ybill
						and BT2.kind = B.billkind),0) 
					ELSE 0
		END	as 'Importo da regolarizzare(Bolletta)',
		CASE ISNULL(B.active,'S')
		WHEN 'S' THEN 
			isnull((SELECT SUM(BT3.amount)
					FROM billtransaction BT3
					WHERE BT3.nbill = B.nbill 
							and BT3.ybilltran= B.ybill
							and BT3.kind = B.billkind),0) 
			ELSE			isnull(B.total,0) -  			isnull(B.reduction,0) 
		END 	as 'Importo regolarizzato(Bolletta)'

	FROM billtransaction BT 
	join bill B
		on B.nbill = BT.nbill and BT.ybilltran = B.ybill AND BT.kind = B.billkind
	WHERE BT.ybilltran = @ayear
			and BT.adate<= @adate
			and B.billkind = @kind
	order by BT.nbill , BT.adate			

end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
