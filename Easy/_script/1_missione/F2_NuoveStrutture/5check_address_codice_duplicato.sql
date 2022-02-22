
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



IF exists(SELECT * FROM [auditcheck] WHERE idaudit = 'SYSTM001' AND idcheck = '2' AND opkind = 'I' AND tablename = 'address')
UPDATE [auditcheck] SET flag_both = 'S',flag_cash = 'S',flag_comp = 'S',flag_credit = 'N',flag_proceeds = 'N',lt = {ts '2007-11-13 16:08:23.377'},lu = 'SARA',message = 'Codice del tipo di indirizzo %<codeaddress>% già esistente',precheck = 'S',sqlcmd = '[(SELECT count(*) 
from address 
where codeaddress = %<address.codeaddress>%)]{I} = 0' WHERE idaudit = 'SYSTM001' AND idcheck = '2' AND opkind = 'I' AND tablename = 'address'
ELSE
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('SYSTM001','2','I','address','S','S','S','N','N',{ts '2007-11-13 16:08:23.377'},'SARA','Codice del tipo di indirizzo %<codeaddress>% già esistente','S','[(SELECT count(*) 
from address 
where codeaddress = %<address.codeaddress>%)]{I} = 0')
GO
