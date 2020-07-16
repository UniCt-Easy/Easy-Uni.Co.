/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿IF NOT EXISTS(SELECT * FROM foreigncountry WHERE idforeigncountry LIKE 'Z%')
BEGIN
	-- Parte 14. Tabelle FOREIGNCOUNTRY, FOREIGNALLOWANCERULE, ITINERATIONLAP
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('1', 'Z200')
	INSERT INTO #temp VALUES('2', 'Z100')
	INSERT INTO #temp VALUES('3', 'Z301')
	INSERT INTO #temp VALUES('4', 'Z512')
	INSERT INTO #temp VALUES('5', 'Z302')
	INSERT INTO #temp VALUES('6', 'Z203')
	INSERT INTO #temp VALUES('7', 'Z600')
	INSERT INTO #temp VALUES('8', 'Z700')
	INSERT INTO #temp VALUES('9', 'Z102')
	INSERT INTO #temp VALUES('10', 'Z102/V')
	INSERT INTO #temp VALUES('11', 'Z502')
	INSERT INTO #temp VALUES('12', 'Z204')
	INSERT INTO #temp VALUES('13', 'Z249')
	INSERT INTO #temp VALUES('14', 'Z522')
	INSERT INTO #temp VALUES('15', 'Z103')
	INSERT INTO #temp VALUES('16', 'Z103/B')
	INSERT INTO #temp VALUES('17', 'Z107')
	INSERT INTO #temp VALUES('18', 'Z205')
	INSERT INTO #temp VALUES('19', 'Z206/OLD')
	INSERT INTO #temp VALUES('20', 'Z601')
	INSERT INTO #temp VALUES('21', 'Z358')
	INSERT INTO #temp VALUES('22', 'Z602')
	INSERT INTO #temp VALUES('23', 'Z104')
	INSERT INTO #temp VALUES('24', 'Z305')
	INSERT INTO #temp VALUES('25', 'Z208')
	INSERT INTO #temp VALUES('26', 'Z306')
	INSERT INTO #temp VALUES('27', 'Z401')
	INSERT INTO #temp VALUES('28', 'Z307')
	INSERT INTO #temp VALUES('29', 'Z105')
	INSERT INTO #temp VALUES('30', 'Z308')
	INSERT INTO #temp VALUES('31', 'Z309')
	INSERT INTO #temp VALUES('32', 'Z603')
	INSERT INTO #temp VALUES('33', 'Z210')
	INSERT INTO #temp VALUES('34', 'Z217')
	INSERT INTO #temp VALUES('35', 'Z211')
	INSERT INTO #temp VALUES('36', 'Z604')
	INSERT INTO #temp VALUES('37', 'Z310')
	INSERT INTO #temp VALUES('38', 'Z311')
	INSERT INTO #temp VALUES('39', 'Z214')
	INSERT INTO #temp VALUES('40', 'Z213')
	INSERT INTO #temp VALUES('41', 'Z503')
	INSERT INTO #temp VALUES('42', 'Z313')
	INSERT INTO #temp VALUES('43', 'Z504')
	INSERT INTO #temp VALUES('44', 'Z314')
	INSERT INTO #temp VALUES('45', 'Z526')
	INSERT INTO #temp VALUES('46', 'Z505')
	INSERT INTO #temp VALUES('47', 'Z605')
	INSERT INTO #temp VALUES('48', 'Z336')
	INSERT INTO #temp VALUES('49', 'Z506')
	INSERT INTO #temp VALUES('50', 'Z215')
	INSERT INTO #temp VALUES('51', 'Z315')
	INSERT INTO #temp VALUES('52', 'Z704')
	INSERT INTO #temp VALUES('53', 'Z216')
	INSERT INTO #temp VALUES('54', 'Z109')
	INSERT INTO #temp VALUES('55', 'Z109/H')
	INSERT INTO #temp VALUES('56', 'Z110')
	INSERT INTO #temp VALUES('57', 'Z110/P')
	INSERT INTO #temp VALUES('58', 'Z316')
	INSERT INTO #temp VALUES('59', 'Z317')
	INSERT INTO #temp VALUES('60', 'Z112/BB')
	INSERT INTO #temp VALUES('62', 'Z112')
	INSERT INTO #temp VALUES('63', 'Z318')
	INSERT INTO #temp VALUES('64', 'Z507')
	INSERT INTO #temp VALUES('65', 'Z219')
	INSERT INTO #temp VALUES('66', 'Z219/T')
	INSERT INTO #temp VALUES('67', 'Z361')
	INSERT INTO #temp VALUES('68', 'Z220')
	INSERT INTO #temp VALUES('69', 'Z114')
	INSERT INTO #temp VALUES('70', 'Z114/L')
	INSERT INTO #temp VALUES('71', 'Z115')
	INSERT INTO #temp VALUES('72', 'Z524')
	INSERT INTO #temp VALUES('73', 'Z509')
	INSERT INTO #temp VALUES('74', 'Z319')
	INSERT INTO #temp VALUES('75', 'Z321')
	INSERT INTO #temp VALUES('76', 'Z320')
	INSERT INTO #temp VALUES('77', 'Z606')
	INSERT INTO #temp VALUES('78', 'Z510')
	INSERT INTO #temp VALUES('79', 'Z511')
	INSERT INTO #temp VALUES('80', 'Z221')
	INSERT INTO #temp VALUES('81', 'Z222')
	INSERT INTO #temp VALUES('82', 'Z223')
	INSERT INTO #temp VALUES('83', 'Z224')
	INSERT INTO #temp VALUES('84', 'Z225')
	INSERT INTO #temp VALUES('85', 'Z116')
	INSERT INTO #temp VALUES('86', 'Z117')
	INSERT INTO #temp VALUES('87', 'Z226')
	INSERT INTO #temp VALUES('88', 'Z118/OLD')
	INSERT INTO #temp VALUES('89', 'Z322')
	INSERT INTO #temp VALUES('90', 'Z731')
	INSERT INTO #temp VALUES('91', 'Z227')
	INSERT INTO #temp VALUES('92', 'Z228')
	INSERT INTO #temp VALUES('93', 'Z359')
	INSERT INTO #temp VALUES('94', 'Z229')
	INSERT INTO #temp VALUES('95', 'Z325')
	INSERT INTO #temp VALUES('96', 'Z326')
	INSERT INTO #temp VALUES('97', 'Z119')
	INSERT INTO #temp VALUES('98', 'Z120')
	INSERT INTO #temp VALUES('99', 'Z327')
	INSERT INTO #temp VALUES('100', 'Z328')
	INSERT INTO #temp VALUES('101', 'Z247')
	INSERT INTO #temp VALUES('102', 'Z232')
	INSERT INTO #temp VALUES('103', 'Z329')
	INSERT INTO #temp VALUES('104', 'Z121')
	INSERT INTO #temp VALUES('105', 'Z330')
	INSERT INTO #temp VALUES('106', 'Z331')
	INSERT INTO #temp VALUES('107', 'Z332')
	INSERT INTO #temp VALUES('108', 'Z514')
	INSERT INTO #temp VALUES('109', 'Z123')
	INSERT INTO #temp VALUES('110', 'Z233')
	INSERT INTO #temp VALUES('111', 'Z333')
	INSERT INTO #temp VALUES('112', 'Z713')
	INSERT INTO #temp VALUES('113', 'Z234')
	INSERT INTO #temp VALUES('114', 'Z515')
	INSERT INTO #temp VALUES('115', 'Z334')
	INSERT INTO #temp VALUES('116', 'Z335')
	INSERT INTO #temp VALUES('117', 'Z125')
	INSERT INTO #temp VALUES('118', 'Z719')
	INSERT INTO #temp VALUES('119', 'Z126')
	INSERT INTO #temp VALUES('120', 'Z235')
	INSERT INTO #temp VALUES('121', 'Z236')
	INSERT INTO #temp VALUES('122', 'Z516')
	INSERT INTO #temp VALUES('123', 'Z730')
	INSERT INTO #temp VALUES('124', 'Z610')
	INSERT INTO #temp VALUES('125', 'Z611')
	INSERT INTO #temp VALUES('126', 'Z127')
	INSERT INTO #temp VALUES('127', 'Z128')
	INSERT INTO #temp VALUES('128', 'Z237')
	INSERT INTO #temp VALUES('129', 'Z129')
	INSERT INTO #temp VALUES('130', 'Z338')
	INSERT INTO #temp VALUES('131', 'Z527')
	INSERT INTO #temp VALUES('132', 'Z528')
	INSERT INTO #temp VALUES('133', 'Z724')
	INSERT INTO #temp VALUES('134', 'Z726')
	INSERT INTO #temp VALUES('135', 'Z341')
	INSERT INTO #temp VALUES('136', 'Z342')
	INSERT INTO #temp VALUES('137', 'Z343')
	INSERT INTO #temp VALUES('138', 'Z344')
	INSERT INTO #temp VALUES('139', 'Z248')
	INSERT INTO #temp VALUES('140', 'Z240')
	INSERT INTO #temp VALUES('141', 'Z345')
	INSERT INTO #temp VALUES('142', 'Z131')
	INSERT INTO #temp VALUES('143', 'Z131/M')
	INSERT INTO #temp VALUES('144', 'Z209')
	INSERT INTO #temp VALUES('145', 'Z404')
	INSERT INTO #temp VALUES('146', 'Z404/N')
	INSERT INTO #temp VALUES('147', 'Z404/W')
	INSERT INTO #temp VALUES('148', 'Z347')
	INSERT INTO #temp VALUES('149', 'Z348')
	INSERT INTO #temp VALUES('150', 'Z608')
	INSERT INTO #temp VALUES('151', 'Z132')
	INSERT INTO #temp VALUES('152', 'Z133')
	INSERT INTO #temp VALUES('153', 'Z133/GB')
	INSERT INTO #temp VALUES('154', 'Z349')
	INSERT INTO #temp VALUES('155', 'Z357')
	INSERT INTO #temp VALUES('156', 'Z241')
	INSERT INTO #temp VALUES('157', 'Z351')
	INSERT INTO #temp VALUES('158', 'Z728')
	INSERT INTO #temp VALUES('159', 'Z612')
	INSERT INTO #temp VALUES('160', 'Z352')
	INSERT INTO #temp VALUES('161', 'Z243')
	INSERT INTO #temp VALUES('162', 'Z354')
	INSERT INTO #temp VALUES('163', 'Z732')
	INSERT INTO #temp VALUES('164', 'Z353')
	INSERT INTO #temp VALUES('165', 'Z134')
	INSERT INTO #temp VALUES('166', 'Z613')
	INSERT INTO #temp VALUES('167', 'Z733')
	INSERT INTO #temp VALUES('168', 'Z614')
	INSERT INTO #temp VALUES('169', 'Z251')
	INSERT INTO #temp VALUES('170', 'Z246')
	INSERT INTO #temp VALUES('171', 'Z250')
	INSERT INTO #temp VALUES('172', 'Z312/OLD')
	INSERT INTO #temp VALUES('173', 'Z355')
	INSERT INTO #temp VALUES('174', 'Z337')
	INSERT INTO #temp VALUES('175', 'Z153')
	INSERT INTO #temp VALUES('176', 'Z149')
	INSERT INTO #temp VALUES('177', 'Z148')
	INSERT INTO #temp VALUES('178', 'Z150')
	INSERT INTO #temp VALUES('179', 'Z252')
	INSERT INTO #temp VALUES('180', 'Z253')
	INSERT INTO #temp VALUES('181', 'Z139')
	INSERT INTO #temp VALUES('182', 'Z156')
	INSERT INTO #temp VALUES('183', 'Z368')
	INSERT INTO #temp VALUES('184', 'Z144')
	INSERT INTO #temp VALUES('185', 'Z254')
	INSERT INTO #temp VALUES('186', 'Z255')
	INSERT INTO #temp VALUES('187', 'Z256')
	INSERT INTO #temp VALUES('188', 'Z145')
	INSERT INTO #temp VALUES('189', 'Z146')
	INSERT INTO #temp VALUES('190', 'Z140')
	INSERT INTO #temp VALUES('191', 'Z154')
	INSERT INTO #temp VALUES('192', 'Z154/M')
	INSERT INTO #temp VALUES('193', 'Z155')
	INSERT INTO #temp VALUES('194', 'Z257')
	INSERT INTO #temp VALUES('195', 'Z258')
	INSERT INTO #temp VALUES('196', 'Z259')
	INSERT INTO #temp VALUES('197', 'Z138')
	INSERT INTO #temp VALUES('198', 'Z300')
	INSERT INTO #temp VALUES('199', 'Z716')
	INSERT INTO #temp VALUES('200', 'Z312')
	INSERT INTO #temp VALUES('201', 'Z206')
	INSERT INTO #temp VALUES('202', 'Z118')

	UPDATE foreigncountry
	SET idforeigncountry = #temp.newvalue
	FROM #temp WHERE idforeigncountry = #temp.oldvalue
	
	UPDATE foreignallowancerule
	SET idforeigncountry = #temp.newvalue
	FROM #temp WHERE idforeigncountry = #temp.oldvalue

	UPDATE itinerationlap
	SET idforeigncountry = #temp.newvalue
	FROM #temp WHERE idforeigncountry = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM reduction WHERE idreduction IN ('25', '33', '50', '66', '75', '100'))
BEGIN
	-- Parte 2. Tabelle REDUCTION, ITINERATIONLAP, ITINERATIONREFUNDKINDGROUPREDUCION, REDUCTIONRULEDETAIL
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)
	
	INSERT INTO #temp VALUES('RID25%', '25')
	INSERT INTO #temp VALUES('RID33%', '33')
	INSERT INTO #temp VALUES('RID50%', '50')
	INSERT INTO #temp VALUES('RID66%', '66')
	INSERT INTO #temp VALUES('RID75%', '75')
	INSERT INTO #temp VALUES('RID100%', '100')

	UPDATE reduction
	SET idreduction = #temp.newvalue
	FROM #temp WHERE idreduction = #temp.oldvalue
	
	UPDATE itinerationlap
	SET idreduction = #temp.newvalue
	FROM #temp WHERE idreduction = #temp.oldvalue
	
	UPDATE itinerationrefundkindgroupreduction
	SET idreduction = #temp.newvalue
	FROM #temp WHERE idreduction = #temp.oldvalue
	
	UPDATE reductionruledetail
	SET idreduction = #temp.newvalue
	FROM #temp WHERE idreduction = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM itinerationrefundkind WHERE iditinerationrefundkind IN ('07_FLY', '07_HOTEL', '07_BUS',
'07_MOBRENT', '07_FUEL', '07_CONFERENCE', '07_BERTH', '07_BOAT', '07_MEAL', '07_FEE', '07_BED', '07_EXTRA',
'07_CAB', '07_TRAIN', '07_WAGONLIT'))
BEGIN
	-- Parte 2. Tabelle ITINERATIONREFUNDKIND, ITINERATIONREFUND
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('AEREO', '07_FLY')
	INSERT INTO #temp VALUES('ALBERGHI', '07_HOTEL')
	INSERT INTO #temp VALUES('AUTOBUS', '07_BUS')
	INSERT INTO #temp VALUES('AUTONOLEGG', '07_MOBRENT')
	INSERT INTO #temp VALUES('CARBURANTI', '07_FUEL')
	INSERT INTO #temp VALUES('CONGRESSI', '07_CONFERENCE')
	INSERT INTO #temp VALUES('CUCCETTA', '07_BERTH')
	INSERT INTO #temp VALUES('NAVE', '07_BOAT')
	INSERT INTO #temp VALUES('PASTI', '07_MEAL')
	INSERT INTO #temp VALUES('PEDAGGI', '07_FEE')
	INSERT INTO #temp VALUES('POSTOLETTO', '07_BED')
	INSERT INTO #temp VALUES('SUPPLEMENT', '07_EXTRA')
	INSERT INTO #temp VALUES('TAXI', '07_CAB')
	INSERT INTO #temp VALUES('TRENO', '07_TRAIN')
	INSERT INTO #temp VALUES('VAGONLETTO', '07_WAGONLIT')

	UPDATE itinerationrefundkind
	SET iditinerationrefundkind = #temp.newvalue
	FROM #temp WHERE iditinerationrefundkind = #temp.oldvalue
	
	UPDATE itinerationrefund
	SET iditinerationrefundkind = #temp.newvalue
	FROM #temp WHERE iditinerationrefundkind = #temp.oldvalue
	
	DROP TABLE #temp
END
GO
	