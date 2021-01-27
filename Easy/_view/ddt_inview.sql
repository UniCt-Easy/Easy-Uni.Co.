
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


IF EXISTS(select * from sysobjects where id = object_id(N'[ddt_inview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [ddt_inview]
GO


CREATE   VIEW [ddt_inview](
idddt_in,
adate,
yddt_in,
nddt_in,
idreg,
registry,
terms,
idddt_in_motive,
ddt_in_motive,
idstore,
store
)
AS 
SELECT
	ddt_in.idddt_in,
	ddt_in.adate,
	ddt_in.yddt_in,
	ddt_in.nddt_in,
	ddt_in.idreg,
	registry.title,
	ddt_in.terms,
	ddt_in.idddt_in_motive,
	ddt_in_motive.description,
	ddt_in.idstore,
	store.description
FROM ddt_in
LEFT OUTER JOIN registry
	ON ddt_in.idreg = registry.idreg
LEFT OUTER JOIN store
	ON ddt_in.idstore = store.idstore
LEFT OUTER JOIN ddt_in_motive
	ON ddt_in.idddt_in_motive = ddt_in_motive.idddt_in_motive


GO


