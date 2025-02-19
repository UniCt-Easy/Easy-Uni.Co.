
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_siope_expensesorted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_siope_expensesorted]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--exp_siope_expensesorted 2017
CREATE procedure exp_siope_expensesorted (@ayear int) as
begin
	declare @DenominazioneDipartimento varchar(500)

	SET  @DenominazioneDipartimento  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe')
	
	
DECLARE @codesorkind_siopespese varchar(20)
SELECT  @codesorkind_siopespese  =  
CASE  
	WHEN  (@ayear<= 2006) THEN  'SIOPE'
	WHEN  (@ayear BETWEEN 2007 AND 2017) THEN  '07U_SIOPE'
	ELSE   'SIOPE_U_18'
END

	
	SELECT @DenominazioneDipartimento as 'Dipartimento', sorting as 'Classificazione spese', sortcode as 'Siope spese', sum(amount) as 'Importo'
	FROM expensesortedview WHERE (codesorkind=@codesorkind_siopespese) AND (ayear=@ayear) group by idsor, sortcode, sorting order by sortcode
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
