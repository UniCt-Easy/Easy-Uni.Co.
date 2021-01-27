
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_assetgrant]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_assetgrant]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--closeyear_assetgrant 2016,null, null ,'C'
CREATE      PROCEDURE [closeyear_assetgrant]
(
	 @ayear int,
	 @idasset int, -- null su tutti
	 @idpiece int, -- null su tutti
	 @kind char(1) --'V' --> Visualizza Risconti da Creare, 'C' --> Crea Risconti su DB
)
AS BEGIN

	-------------------------------------------------------------------------------------
	-------------------------- Ammortamenti Cespiti -------------------------------------
	-------------------------------------------------------------------------------------

--sp_help assetgrant
--sp_help assetamortizationview
 
 

create table #assetgrandetailtocreate
 (idasset int,
  idpiece int, 
  idgrant int,
  doc varchar(35),
  docdate datetime,
  namortization int,  
  amortizationquota float,
  amount decimal(19,2), 
  codeinventoryamortization varchar(20),
  inventoryamortization varchar(50),
  inventory varchar(50), 
  ninventory int,
  codeinv varchar(50),
  inventorytree varchar(150),
  loaddescription varchar(150),
  description varchar(150),
  assetvalue decimal(19,2),
  adate smalldatetime )

insert into #assetgrandetailtocreate
(
  idasset,
  idpiece, 
  idgrant ,
  doc,
  docdate,
  namortization,  
  amortizationquota,
  amount, 
  codeinventoryamortization,
  inventoryamortization,
  inventory, 
  ninventory,
  codeinv,
  inventorytree,
  loaddescription,
  description,
  assetvalue,
  adate
  ) 
select 
  assetgrant.idasset,
  assetgrant.idpiece, 
  assetgrant.idgrant ,
  assetgrant.doc,
  assetgrant.docdate,
  assetamortizationview.namortization ,  
  assetamortizationview.amortizationquota,
  assetgrant.amount, 
  assetamortizationview.codeinventoryamortization,
  assetamortizationview.inventoryamortization,
  assetamortizationview.inventory, 
  assetamortizationview.ninventory,
  assetamortizationview.codeinv,
  assetamortizationview.inventorytree,
  assetamortizationview. loaddescription,
  assetamortizationview.description,
  assetamortizationview. assetvalue,
  assetamortizationview.adate 
from  assetamortizationview 
join  assetgrant on  assetgrant.idasset = assetamortizationview.idasset 
 and  assetgrant.idpiece = assetamortizationview.idpiece 
where year(assetamortizationview.adate) = @ayear  and assetgrant.ygrant <= @ayear
and   official = 'S' 
and   (assetgrant.idasset = @idasset OR @idasset is null)
and   (assetgrant.idpiece = @idpiece OR @idpiece is null)
and   not  exists (select * from assetgrantdetail 
                   where assetgrant.idasset = assetgrantdetail.idasset and
				         assetgrant.idpiece = assetgrantdetail.idpiece and  
						 assetgrant.idgrant = assetgrantdetail.idgrant and  
					     assetgrantdetail.ydetail  = @ayear  )
order by assetgrant.idgrant, assetgrant.idasset, assetgrant.idpiece, assetamortizationview.namortization

if (@kind = 'V')
begin
	select   
		     #assetgrandetailtocreate.inventory as 'Inventario', 
			 #assetgrandetailtocreate.ninventory as 'Numero Inventario',
			 #assetgrandetailtocreate.codeinv as 'Cod. Class. Inventariale',
			 #assetgrandetailtocreate.inventorytree as 'Class. Inventariale',
			 #assetgrandetailtocreate.loaddescription as 'Descr. Cespite ',
			 #assetgrandetailtocreate.idasset as '.#idasset',
			 #assetgrandetailtocreate.idpiece as '.#idpiece', 
			 #assetgrandetailtocreate.codeinventoryamortization 'Cod. Tipo Ammortamento',
			 #assetgrandetailtocreate.inventoryamortization as 'Tipo Ammortamento',
			 #assetgrandetailtocreate.namortization  as 'Numero Ammortamento',  
			 #assetgrandetailtocreate.adate as 'Data Ammortamento', 
			 #assetgrandetailtocreate.amortizationquota as 'Quota Ammortamento',
			 #assetgrandetailtocreate.description as 'Descrizione Ammortamento' ,
			 #assetgrandetailtocreate.idgrant as 'Numero Contributo' ,
			 #assetgrandetailtocreate.doc as 'Contributo - Doc. Collegato' ,
			 #assetgrandetailtocreate.docdate as 'Contributo - Data Doc.Collegato' ,
			 #assetgrandetailtocreate.adate as 'Data Contabile Ammortamento' ,
			 #assetgrandetailtocreate.amount as 'Importo Contributo' ,
			 -#assetgrandetailtocreate.amount*#assetgrandetailtocreate.amortizationquota as 'Importo Risconto'

 from #assetgrandetailtocreate
end


if (@kind = 'C')  --crea
begin
	insert into assetgrantdetail 
	(
		idasset,
		idpiece,
		idgrant,
		iddetail,
		amount,
		idgrantload,
		ydetail,
		ct,
		cu,
		lt,
		lu
	)
	select 
		#assetgrandetailtocreate.idasset,
		#assetgrandetailtocreate.idpiece,
		#assetgrandetailtocreate.idgrant,
		isnull((select max(iddetail) from assetgrantdetail T 
		where T.idasset = #assetgrandetailtocreate.idasset  and T.idpiece = #assetgrandetailtocreate.idpiece
		and  T.idgrant = #assetgrandetailtocreate.idgrant ),0) +1,
		-#assetgrandetailtocreate.amortizationquota * #assetgrandetailtocreate.amount,
		null,
		@ayear,
		GetDate(),
		'close_assetgrantdetail',
		GetDate(),
		'close_assetgrantdetail' 
	from  #assetgrandetailtocreate
select 'OK'
end

drop table #assetgrandetailtocreate


END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

