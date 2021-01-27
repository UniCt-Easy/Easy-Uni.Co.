
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


if not exists(select * from finlookup)
Begin
	insert into finlookup(oldidfin, newidfin,ct,cu,lt,lu)
	select O.idfin, N.idfin,getdate(),'script',getdate(),'script'
	from fin O
	join fin N
		on O.codefin = N.codefin
		and (O.flag & 1) = (N.flag & 1)
		and O.ayear +1 = N.ayear	
End
GO
