
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


INSERT [dbo].[progettoattachkind] ([idprogettoattachkind], [idprogettokind], [ct], [cu], [lt], [lu], [title]) VALUES (1, 1, CAST(N'2020-06-15T18:48:53.933' AS DateTime), N'riccardotest{0001}', CAST(N'2020-06-15T18:48:53.933' AS DateTime), N'riccardotest{0001}', N'Bando di finanziamento')
GO
INSERT [dbo].[progettoattachkind] ([idprogettoattachkind], [idprogettokind], [ct], [cu], [lt], [lu], [title]) VALUES (2, 1, CAST(N'2020-06-15T18:48:53.983' AS DateTime), N'riccardotest{0001}', CAST(N'2020-06-15T18:48:53.983' AS DateTime), N'riccardotest{0001}', N'Decreto direttoriale')
GO
INSERT [dbo].[progettokind] ([idprogettokind], [ct], [cu], [description], [idprogettoactivitykind], [lt], [lu], [oredivisionecostostipendio], [title], [idcorsostudio]) VALUES (1, CAST(N'2020-07-22T12:19:51.667' AS DateTime), N'riccardotest{1}', N'I Progetti di Ricerca di Interesse Nazionale (in acronimo PRIN), in Italia, indicano proposte di progetti di ricerca scientifica a finanziamento pubblico.
Istituiti con legge 27 dicembre 1997, n. 449 sono finanziate periodicamente dal Ministero dell''Istruzione, dell''Università e della Ricerca in Italia e cofinanziate dagli atenei di appartenenza del coordinatore scientifico nazionale e dei responsabili delle unità di ricerca. I contenuti, i temi e i metodi dei programmi di ricerca scientifica sono liberamente scelti dai proponenti.', 1, CAST(N'2021-01-18T15:27:37.350' AS DateTime), N'ferdinando.giannetti{SEGADM}', 1720, N'PRIN', N'N')
GO
INSERT [dbo].[progettokind] ([idprogettokind], [ct], [cu], [description], [idprogettoactivitykind], [lt], [lu], [oredivisionecostostipendio], [title], [idcorsostudio]) VALUES (2, CAST(N'2020-07-22T12:19:51.667' AS DateTime), N'riccardotest{1}', N'Horizon 2020', 1, CAST(N'2020-10-02T18:35:58.653' AS DateTime), N'zemignani{1}', 1720, N'Horizon 2020', N'N')
GO
INSERT [dbo].[progettokind] ([idprogettokind], [ct], [cu], [description], [idprogettoactivitykind], [lt], [lu], [oredivisionecostostipendio], [title], [idcorsostudio]) VALUES (3, CAST(N'2020-07-22T12:19:51.667' AS DateTime), N'riccardotest{1}', NULL, 1, CAST(N'2020-07-22T12:19:51.667' AS DateTime), N'riccardotest{1}', 1720, N'POR', N'N')
GO
INSERT [dbo].[progettokind] ([idprogettokind], [ct], [cu], [description], [idprogettoactivitykind], [lt], [lu], [oredivisionecostostipendio], [title], [idcorsostudio]) VALUES (4, CAST(N'2020-07-22T12:19:51.667' AS DateTime), N'riccardotest{1}', NULL, 1, CAST(N'2020-07-22T12:19:51.667' AS DateTime), N'riccardotest{1}', 1720, N'PON', N'N')
GO
INSERT [dbo].[progettokind] ([idprogettokind], [ct], [cu], [description], [idprogettoactivitykind], [lt], [lu], [oredivisionecostostipendio], [title], [idcorsostudio]) VALUES (7, CAST(N'2020-11-20T09:15:45.040' AS DateTime), N'riccardotest{ADMSEG1}', N'Attività legata alla erogazione di un Master', 3, CAST(N'2020-11-20T09:15:45.040' AS DateTime), N'riccardotest{ADMSEG1}', 1720, N'Master', N'S')
GO
INSERT [dbo].[progettotestokind] ([idprogettotestokind], [idprogettokind], [ct], [cu], [lt], [lu], [sortcode], [titolo]) VALUES (1, 1, CAST(N'2020-05-26T18:20:47.133' AS DateTime), N'riccardotest{0001}', CAST(N'2020-05-26T18:20:47.133' AS DateTime), N'riccardotest{0001}', 7, N'Parole chiave')
GO
INSERT [dbo].[progettotestokind] ([idprogettotestokind], [idprogettokind], [ct], [cu], [lt], [lu], [sortcode], [titolo]) VALUES (2, 1, CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', 10, N'Sintetica descrizione della proposta')
GO
INSERT [dbo].[progettotestokind] ([idprogettotestokind], [idprogettokind], [ct], [cu], [lt], [lu], [sortcode], [titolo]) VALUES (3, 1, CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', 101, N'Abstract')
GO
INSERT [dbo].[progettotestokind] ([idprogettotestokind], [idprogettokind], [ct], [cu], [lt], [lu], [sortcode], [titolo]) VALUES (4, 1, CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', 102, N'Descrizione dettagliata del progetto: obiettivi che il progetto si propone di raggiungere e loro interesse per l’avanzamento della conoscenza, stato dell’arte, metodologia della proposta')
GO
INSERT [dbo].[progettotestokind] ([idprogettotestokind], [idprogettokind], [ct], [cu], [lt], [lu], [sortcode], [titolo]) VALUES (5, 1, CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', 103, N'Articolazione del progetto, con individuazione del ruolo delle singole unità di ricerca in funzione degli obiettivi previsti, e relative modalità di integrazione e collaborazione')
GO
INSERT [dbo].[progettotestokind] ([idprogettotestokind], [idprogettokind], [ct], [cu], [lt], [lu], [sortcode], [titolo]) VALUES (6, 1, CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', 104, N'Eventuali potenzialità applicative, impatto scientifico e/o tecnologico e/o sociale e/o economico')
GO
INSERT [dbo].[progettotestokind] ([idprogettotestokind], [idprogettokind], [ct], [cu], [lt], [lu], [sortcode], [titolo]) VALUES (7, 1, CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', 106, N'Bibliografia')
GO
INSERT [dbo].[progettotestokind] ([idprogettotestokind], [idprogettokind], [ct], [cu], [lt], [lu], [sortcode], [titolo]) VALUES (8, 1, CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', 201, N'Finanziamenti nazionali e internazionali già acquisiti come Principal Investigator')
GO
INSERT [dbo].[progettotestokind] ([idprogettotestokind], [idprogettokind], [ct], [cu], [lt], [lu], [sortcode], [titolo]) VALUES (9, 1, CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', CAST(N'2020-05-26T18:20:47.197' AS DateTime), N'riccardotest{0001}', 202, N'Riconoscimenti nazionali e internazionali ricevuti')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (1, 1, NULL, NULL, N'Personale dipendente a tempo indeterminato', NULL, NULL, N'Voce A.1')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (2, 1, NULL, NULL, N'Personale appositamente da reclutare', NULL, NULL, N'Voce A.2.1')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (3, 1, NULL, NULL, N'Spese generali', NULL, NULL, N'Voce B')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (4, 1, NULL, NULL, N'Attrezzature, strumentazioni, e prodotti software', NULL, NULL, N'Voce C')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (5, 1, NULL, NULL, N'Servizi di consulenza e simili', NULL, NULL, N'Voce D')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (6, 1, NULL, NULL, N'Altri costi di esercizio', NULL, NULL, N'Voce E')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (7, 1, NULL, NULL, N'Quota premiale', NULL, NULL, N'Voce F')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (8, 2, NULL, NULL, NULL, NULL, NULL, N'Personnel (A) own costs')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (9, 2, NULL, NULL, NULL, NULL, NULL, N'Personnel (A) third parties')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (10, 2, NULL, NULL, NULL, NULL, NULL, N'Travel and subsistence (B) own costs')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (11, 2, NULL, NULL, NULL, NULL, NULL, N'Travel and subsistence (B) third parties')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (12, 2, NULL, NULL, NULL, NULL, NULL, N'Durable equipment (C) own costs')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (13, 2, NULL, NULL, NULL, NULL, NULL, N'Durable equipment (C) third parties')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (14, 2, NULL, NULL, NULL, NULL, NULL, N'Consumables (D) own costs')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (15, 2, NULL, NULL, NULL, NULL, NULL, N'Consumables (D) third parties')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (16, 2, NULL, NULL, NULL, NULL, NULL, N'Other Specific Costs (E) own costs')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (17, 2, NULL, NULL, NULL, NULL, NULL, N'Other Specific Costs (E) third parties')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (18, 2, NULL, NULL, NULL, NULL, NULL, N'Subcontracts  (F) own costs')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (19, 2, NULL, NULL, NULL, NULL, NULL, N'Subcontracts  (F) third parties')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (20, 2, NULL, NULL, N'A+B+C+D+E+F', NULL, NULL, N'Total Direct Costs (G) own costs')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (21, 2, NULL, NULL, N'A+B+C+D+E+F', NULL, NULL, N'Total Direct Costs (G) third parties')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (22, 2, NULL, NULL, N' G-F', NULL, NULL, N'Overheads (H) own costs')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (23, 2, NULL, NULL, N'G-F', NULL, NULL, N'Overheads (H) third parties')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (24, 2, NULL, NULL, N'G+H', NULL, NULL, N'Total (I) own costs')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (25, 2, NULL, NULL, N'G+H', NULL, NULL, N'Total (I) third parties')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (26, 3, NULL, NULL, NULL, NULL, NULL, N'5.1.1 SPESE PER IL PERSONALE CALCOLATE SECONDO UNITA’ DI COSTI STANDARD')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (27, 3, NULL, NULL, NULL, NULL, NULL, N'5.1.2 SPESE PER IL PERSONALE CALCOLATE A COSTI REALI Personale dipendente')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (28, 3, NULL, NULL, NULL, NULL, NULL, N'5.1.2 SPESE PER IL PERSONALE CALCOLATE A COSTI REALI Personale Parasubordinato')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (29, 3, NULL, NULL, NULL, NULL, NULL, N'5.2. APPORTI IN NATURA ASSIMILABILI A PRESTAZIONI VOLONTARIE RESE DA TITOLARI, SOCI E AMMINISTRATORI')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (30, 3, NULL, NULL, NULL, NULL, NULL, N'5.3. SPESE PER ACQUISTO DI MACCHINARI E ATTREZZATURE NELL’AMBITO DI PROGETTI D’INVESTIMENTO')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (31, 3, NULL, NULL, NULL, NULL, NULL, N'5.4. SPESE PER STRUMENTAZIONI E ATTREZZATURE UTILIZZATE NELL’AMBITO DI PROGETTI DI RICERCA E SVILUPPO a) Acquisto attrezzature')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (32, 3, NULL, NULL, N'(costo x % di ammortamento x giorni di utilizzo x % di utilizzo) / 365 (o giorni dell’anno dall’acquisto al 31/12)', NULL, NULL, N'5.4. SPESE PER STRUMENTAZIONI E ATTREZZATURE UTILIZZATE NELL’AMBITO DI PROGETTI DI RICERCA E SVILUPPO b) Ammortamento')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (33, 3, NULL, NULL, NULL, NULL, NULL, N'5.4. SPESE PER STRUMENTAZIONI E ATTREZZATURE UTILIZZATE NELL’AMBITO DI PROGETTI DI RICERCA E SVILUPPO c) Locazione finanziaria (Leasing)')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (34, 3, NULL, NULL, NULL, NULL, NULL, N'5.4. SPESE PER STRUMENTAZIONI E ATTREZZATURE UTILIZZATE NELL’AMBITO DI PROGETTI DI RICERCA E SVILUPPO d) Noleggio (Locazione semplice)')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (35, 3, NULL, NULL, NULL, NULL, NULL, N'5.5. SPESE PER SERVIZI DI CONSULENZA E SERVIZI EQUIVALENTI')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (36, 3, NULL, NULL, NULL, NULL, NULL, N'5.6. SPESE TECNICHE PER PROGETTAZIONE, DIREZIONE LAVORI, COLLAUDO E CERTIFICAZIONE')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (37, 3, NULL, NULL, NULL, NULL, NULL, N'5.7. SPESE PER MATERIALI, FORNITURE E PRODOTTI ANALOGHI')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (38, 3, NULL, NULL, NULL, NULL, NULL, N'5.8. INSTALLAZIONE E POSA IN OPERA DEGLI IMPIANTI')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (39, 3, NULL, NULL, NULL, NULL, NULL, N'5.9. OPERE MURARIE')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (40, 3, NULL, NULL, NULL, NULL, NULL, N'5.10. SPESE DI VIAGGIO')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (41, 3, NULL, NULL, NULL, NULL, NULL, N'5.11. COMUNICAZIONE E DISSEMINAZIONE DEI RISULTATI')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (42, 3, NULL, NULL, NULL, NULL, NULL, N'5.12. COMUNICAZIONE, PROMOZIONE E ANIMAZIONE DEI POLI DI INNOVAZIONE')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (43, 3, NULL, NULL, NULL, NULL, NULL, N'5.13. DIRITTI DI PROPRIETÀ INTELLETTUALE')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (44, 3, NULL, NULL, N'15% delle spese di personale rendicontate in ogni singola dichiarazione di spesa.', NULL, NULL, N'5.14.1. SPESE GENERALI IMPUTATE A TASSO FORFETTARIO')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (45, 3, NULL, NULL, NULL, NULL, NULL, N'5.14.2. SPESE GENERALI RENDICONTATE A COSTI REALI')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (46, 4, NULL, NULL, NULL, NULL, NULL, N'Ammortamento')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (47, 4, NULL, NULL, NULL, NULL, NULL, N'Contributi in natura')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (48, 4, NULL, NULL, NULL, NULL, NULL, N'Spese generali')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (49, 4, NULL, NULL, NULL, NULL, NULL, N'Acquisto di materiale usato')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (50, 4, NULL, NULL, NULL, NULL, NULL, N'Acquisto di terreni')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (51, 4, NULL, NULL, NULL, NULL, NULL, N'Acquisto di edifici')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (52, 4, NULL, NULL, NULL, NULL, NULL, N'IVA, oneri e altre imposte e tasse')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (53, 4, NULL, NULL, NULL, NULL, NULL, N'Spese di assistenza tecnica')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (54, 4, NULL, NULL, NULL, NULL, NULL, N'Altre spese connesse alle singole operazioni')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (55, 4, NULL, NULL, NULL, NULL, NULL, N'Altre spese connesse alle singole operazioni: Personale')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (56, 4, NULL, NULL, NULL, NULL, NULL, N'Altre spese connesse alle singole operazioni: Spese di viaggio')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (57, 4, NULL, NULL, NULL, NULL, NULL, N'Altre spese connesse alle singole operazioni: Investimenti (attrezzature, macchinari, ecc)')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (58, 4, NULL, NULL, NULL, NULL, NULL, N'Altre spese connesse alle singole operazioni: Investimenti infrastrutturali')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (59, 4, NULL, NULL, NULL, NULL, NULL, N'Altre spese connesse alle singole operazioni: Servizi esterni (o prestazioni di servizio)')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (60, 4, NULL, NULL, NULL, NULL, NULL, N'Altre spese connesse alle singole operazioni: Spese per riunioni')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (61, 4, NULL, NULL, NULL, NULL, NULL, N'Altre spese connesse alle singole operazioni: Informazione e pubblicità')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (62, 4, NULL, NULL, NULL, NULL, NULL, N'Altre spese connesse alle singole operazioni: Spese delle autorità pubbliche relative alla realizzazione delle operazioni')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (63, 4, NULL, NULL, NULL, NULL, NULL, N'Spese relative a strumenti di ingegneria finanziaria')
GO
INSERT [dbo].[progettotipocostokind] ([idprogettotipocostokind], [idprogettokind], [ct], [cu], [description], [lt], [lu], [title]) VALUES (82, 7, CAST(N'2020-11-20T09:16:34.773' AS DateTime), N'riccardotest{ADMSEG1}', NULL, CAST(N'2020-11-20T09:16:34.773' AS DateTime), N'riccardotest{ADMSEG1}', N'Costi')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (1, 1, N'Workpackage unico')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (2, 2, N'RTD & innovation activities')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (3, 2, N'Demonstration activities')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (4, 2, N'Training activities')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (5, 2, N'Consortium management activities')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (6, 2, N'Specific activities (for NOE, CA, SSA, ecc.)')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (7, 3, N'Workpackage unico')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (8, 4, N'Workpackage unico')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (14, 7, N'Didattica')
GO
INSERT [dbo].[workpackagekind] ([idworkpackagekind], [idprogettokind], [title]) VALUES (15, 7, N'Laboratori')
GO
