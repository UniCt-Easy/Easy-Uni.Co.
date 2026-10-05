/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using metadatalibrary;
using metaeasylibrary;
using movimentofunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FlussoStudentiService
{
	public class FlussoStudentiPostDataService: IFlussoStudentiPostData
	{
		Easy_DataAccess _conn;
		IMessageLogger _logger;

		public FlussoStudentiPostDataService(Easy_DataAccess conn, IMessageLogger logger)
		{
			_conn = conn;
			_logger = logger;
		}

		public bool runGaPostData(GestioneAutomatismi ga, MetaDataDispatcher dispatcher)
		{
			ProcedureMessageCollection resMess = ga.doPostService(dispatcher as MetaDataDispatcher);

			string errore = "";

			var hashSet = new HashSet<string>();
			if (resMess?.Count > 0)
			{
				// Controlla se tutte le regole sono in "avvertimento"

				if (resMess is EasyProcedureMessageCollection easyCollection)
				{
					var listaMessaggi = easyCollection.Cast<EasyProcedureMessage>().ToList();
					bool tuttiAvvertimenti = listaMessaggi.All(item => item.ErrorType.Trim().ToLower() == "avvertimento");

					if (!tuttiAvvertimenti)
					{
						errore = "Regole bloccanti scattate durante il salvataggio:\r\n";
						foreach (EasyProcedureMessage item in easyCollection)
						{
							if (item.ErrorType != "avvertimento")
							{
								hashSet.Add(CreateEmailMessaggeEasy(item));
							}
						}

						errore += string.Join(Environment.NewLine, hashSet);
					}
					else
					{
						// Tutte le regole sono in avvertimento
						_logger.Info("Regole scattate durante il salvataggio:");
						foreach (EasyProcedureMessage item in easyCollection)
						{							
							_logger.Info(CreateEmailMessaggeEasy(item));
						}
					}
				}
				else if (resMess is ProcedureMessageCollection procedureCollection)
				{
					var listaMessaggi = procedureCollection.Cast<ProcedureMessage>().ToList();
					bool tuttiAvvertimenti = listaMessaggi.All(item => item.CanIgnore);

					if (!tuttiAvvertimenti)
					{
						errore = "Regole bloccanti scattate durante il salvataggio:\r\n";
						foreach (ProcedureMessage item in procedureCollection)
						{
							if (!item.CanIgnore)
							{
								hashSet.Add(CreateEmailMessagge(item));
							}
						}

						errore += string.Join(Environment.NewLine, hashSet);
					}
					else
					{
						// Tutte le regole sono in avvertimento
						_logger.Info("Regole scattate durante il salvataggio:");
						foreach (ProcedureMessage item in procedureCollection)
						{
							_logger.Info(CreateEmailMessagge(item));
						}
					}
				}
			}

			if (!string.IsNullOrEmpty(errore))
			{
				_logger.Error(errore);
				return false;
			}

			return true;
		}

		public bool runPostData(DataSet DS)
		{
			var post = new Easy_PostData_NoBL();
			post.initClass(DS, _conn);
			post.autoIgnore = true;
			//if (!post.DO_POST()) return;

			var resSave = post.DO_POST_SERVICE();

			string errore = "";

			var hashSet = new HashSet<string>();
			if (resSave?.Count > 0)
			{
				// Controlla se tutte le regole sono in "avvertimento"

				if (resSave is EasyProcedureMessageCollection easyCollection)
				{
					var listaMessaggi = easyCollection.Cast<EasyProcedureMessage>().ToList();
					bool tuttiAvvertimenti = listaMessaggi.All(item => item.ErrorType.Trim().ToLower() == "avvertimento");

					if (!tuttiAvvertimenti)
					{
						errore = "Regole bloccanti scattate durante il salvataggio:\r\n";
						foreach (EasyProcedureMessage item in easyCollection)
						{
							if (item.ErrorType != "avvertimento")
							{								
								hashSet.Add(CreateEmailMessaggeEasy(item));
							}
						}

						errore += string.Join(Environment.NewLine, hashSet);
					}
					else
					{
						// Tutte le regole sono in avvertimento
						_logger.Info("Regole scattate durante il salvataggio:");
						foreach (EasyProcedureMessage item in easyCollection)
						{							
							_logger.Info(CreateEmailMessaggeEasy(item));
						}
					}
				}
				else if (resSave is ProcedureMessageCollection procedureCollection)
				{
					var listaMessaggi = procedureCollection.Cast<ProcedureMessage>().ToList();
					bool tuttiAvvertimenti = listaMessaggi.All(item => item.CanIgnore);

					if (!tuttiAvvertimenti)
					{
						errore = "Regole bloccanti scattate durante il salvataggio:\r\n";
						foreach (ProcedureMessage item in procedureCollection)
						{							
							if (!item.CanIgnore)
							{								
								hashSet.Add(CreateEmailMessagge(item));
							}
						}

						errore += string.Join(Environment.NewLine, hashSet);
					}
					else
					{
						// Tutte le regole sono in avvertimento
						_logger.Info("Regole scattate durante il salvataggio:");
						foreach (ProcedureMessage item in procedureCollection)
						{
							_logger.Info(CreateEmailMessagge(item));
						}
					}
				}
			}

			if (!string.IsNullOrEmpty(errore))
			{
				_logger.Error(errore);
				return false;
			}

			return true;
		}

		private string ConvertCarriages(string S)
		{
			S = S.Replace("\r", "\n");
			S = S.Replace("\n\n", "\n");
			S = S.Replace("\n", "\r\n");
			return S;
		}

		private string CreateEmailMessaggeEasy(EasyProcedureMessage item)
		{
			string flagSystem = item.flagsystem ? "di SISTEMA" : "NON di SISTEMA";
			string prePost = item.PostMsgs ? "post" : "pre";
			string msg = ConvertCarriages(item.LongMess);

			string id = "";
			if (item.TableName == null || item.Operation == null || item.EnforcementNumber == null)
			{
				id = item.CanIgnore ? "System warning" : "dberror";
			}
			else
			{
				id = $"{prePost}/{item.TableName}/{item.Operation.Substring(0, 1)}/{item.EnforcementNumber}";
			}

			return $"{flagSystem} - {item.AuditID} - {id} - {item.ErrorType} - {msg}";
		}

		private string CreateEmailMessagge(ProcedureMessage item)
		{
			string prePost = item.PostMsgs ? "post" : "pre";
			string msg = ConvertCarriages(item.LongMess);

			string id = $"{prePost}/{(item.CanIgnore ? "System warning" : "dberror")}";

			return $"{id} - {msg}";
		}
	}
}
