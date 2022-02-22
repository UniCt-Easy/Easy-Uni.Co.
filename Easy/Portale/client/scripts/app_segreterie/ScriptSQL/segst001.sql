
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


-- AUDITCHECK SEGST001

-- GENERAZIONE DATI PER audit --
IF not exists(SELECT * FROM [audit] WHERE idaudit = 'SEGST001')
INSERT INTO [audit] (idaudit,consequence,flagsystem,lt,lu,severity,title) VALUES ('SEGST001',null,'N',{ts '2020-07-21 18:20:15.233'},'assistenza5','E','SEGST001 - Univocità dell''associazione UPB / Workpackage.')
GO

-- FINE GENERAZIONE SCRIPT --
delete from auditcheck where (idaudit='SEGST001')
GO

-- GENERAZIONE DATI PER auditcheck --
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('SEGST001','1','I','workpackageupb','S','S','S','N','N',{ts '2020-07-21 18:19:55.123'},'assistenza5','L''UPB risulta già  associato ad un''altro Workpackage.','N','[(select count(*) from workpackageupb
where idupb= %<workpackageupb.idupb>%)]{I} =1
')
INSERT INTO [auditcheck] (idaudit,idcheck,opkind,tablename,flag_both,flag_cash,flag_comp,flag_credit,flag_proceeds,lt,lu,message,precheck,sqlcmd) VALUES ('SEGST001','1','U','workpackageupb','S','S','S','N','N',{ts '2020-07-21 18:19:44.407'},'assistenza5','L''UPB risulta già  associato ad un''altro Workpackage.','N','[(select count(*) from workpackageupb
where idupb= %<workpackageupb.idupb>%)]{I} =1
')
GO

-- FINE GENERAZIONE SCRIPT --

