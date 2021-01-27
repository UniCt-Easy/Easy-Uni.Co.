
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


-- CREAZIONE VISTA proceedstransmissionview
IF EXISTS(select * from sysobjects where id = object_id(N'[proceedstransmissionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceedstransmissionview]
GO

CREATE  VIEW proceedstransmissionview 
	(
	kproceedstransmission,
	yproceedstransmission,
	nproceedstransmission,
	idman,
	manager,
	idtreasurer,
	codetreasurer,
	treasurer,
	transmissiondate,
	total,
	transmissionkind,
	streamdate,
	flagtransmissionenabled,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu,
	ct,
	lu,
	lt
	)
	AS SELECT
	proceedstransmission.kproceedstransmission,
	proceedstransmission.yproceedstransmission,
 	proceedstransmission.nproceedstransmission,
	proceedstransmission.idman,
	manager.title,
	proceedstransmission.idtreasurer,
	treasurer.codetreasurer,
	treasurer.description,
 	proceedstransmission.transmissiondate,
	ISNULL((SELECT SUM(ISNULL(total,0)) FROM proceedsview d 
	WHERE d.kproceedstransmission = proceedstransmission.kproceedstransmission),0),
	proceedstransmission.transmissionkind,
	proceedstransmission.streamdate,
	proceedstransmission.flagtransmissionenabled,
	treasurer.idsor01,
	treasurer.idsor02,
	treasurer.idsor03,
	treasurer.idsor04,
	treasurer.idsor05,
	proceedstransmission.cu,
	proceedstransmission.ct,
	proceedstransmission.lu,
	proceedstransmission.lt
	FROM proceedstransmission 
	LEFT OUTER JOIN manager 
	ON manager.idman = proceedstransmission.idman
	LEFT OUTER JOIN treasurer 
	ON treasurer.idtreasurer = proceedstransmission.idtreasurer

 

GO

