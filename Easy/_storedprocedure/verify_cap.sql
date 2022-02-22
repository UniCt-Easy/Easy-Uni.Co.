
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


if exists (select * from dbo.sysobjects where id = object_id(N'[verify_cap]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [verify_cap]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  PROCEDURE verify_cap (
@idreg 	     int,
@codenostand varchar(20),
@codestand   varchar(20),
@res int out
) AS
BEGIN

declare @cap varchar(5)

select @cap =  case when address.idaddress is null then null
					 when address.idaddress is not null and geo.idagency is null then 'q_no'
					 when flagforeign='N'  then 'q_ok'
					 else 'q_ok' 
				end 
	from registryaddress 
	left outer join address on address.idaddress =registryaddress.idaddresskind
	left outer join geo_city_agency geo 
	     on  geo.value = @cap
	    AND  geo.idagency = 3 
	    AND  geo.stop IS  NULL
	where idreg=@idreg and  registryaddress.stop is null
				 and registryaddress.active ='S' 
				 and address.codeaddress=@codenostand
				 
if (@cap='q_ok') return 0
if (@cap ='q_no') return 1
	



select @cap =  case  when geo.idagency is null then 'q_no'
					 when flagforeign='N'  then 'q_ok'
					 else 'q_ok' 
				end 
	from registryaddress 
	left outer join address on address.idaddress =registryaddress.idaddresskind
	left outer join geo_city_agency geo 
	     on  geo.value = @cap
	    AND  geo.idagency = 3 
	    AND  geo.stop IS  NULL
	where idreg=@idreg and  registryaddress.stop is null
				 and registryaddress.active ='S' 
				 and address.codeaddress=@codestand

if (@cap='q_ok') return 0
return 1


END
