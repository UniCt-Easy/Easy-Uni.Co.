
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_carico_sub1_rc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_carico_sub1_rc]
GO

CREATE    PROCEDURE [rpt_buono_carico_sub1_rc]
@ayear int,
@idassetloadkind int,
@nassetload int
AS
BEGIN
SELECT
	assetload.idassetloadkind,
	assetload.yassetload,
	assetload.nassetload,
	assetloadexpense.idexp,
	fin.codefin,
	fin.title,
	expense.ymov,
	payment.npay,
	CONVERT(datetime,payment.printdate) as printdate
FROM assetloadexpense
JOIN assetload
	ON assetload.idassetload = assetloadexpense.idassetload
JOIN expense 
	ON assetloadexpense.idexp = expense.idexp
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN expenseyear 
	ON expense.idexp = expenseyear.idexp
JOIN fin
	ON fin.idfin= expenseyear.idfin
JOIN payment
	ON expenselast.kpay = payment.kpay
WHERE assetload.idassetloadkind = @idassetloadkind
	AND assetload.yassetload = @ayear
	AND assetload.nassetload = @nassetload
	AND expenseyear.ayear = @ayear
ORDER BY expense.ymov, payment.printdate, payment.npay
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
