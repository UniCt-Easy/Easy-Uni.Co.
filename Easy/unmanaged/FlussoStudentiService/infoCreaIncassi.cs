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

using meta_estimatedetail;
using meta_flussocreditidetail;
using meta_flussoincassidetail;
using meta_income;
using meta_incomeyear;
using meta_invoicedetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlussoStudentiService
{
	public class infoCreaIncassi
	{
		public Dictionary<string, List<flussocreditidetailRow>> creditiPerIuv =
				new Dictionary<string, List<flussocreditidetailRow>>();

		public Dictionary<string, List<flussocreditidetailRow>> creditiPerUniqueFormCode =
				new Dictionary<string, List<flussocreditidetailRow>>();

		public Dictionary<string, List<estimatedetailRow>> dettContrattoPerUniqueFormCode =
				new Dictionary<string, List<estimatedetailRow>>();

		public Dictionary<string, List<invoicedetailRow>> dettFatturaPerUniqueFormCode =
				new Dictionary<string, List<invoicedetailRow>>();

		public Dictionary<string, bool> messaggioBollettinoMancante = new Dictionary<string, bool>();


		/// <summary>
		/// Informazioni per ogni flusso incassi, indicizzata su idflusso
		/// </summary>
		public Dictionary<int, infoIncasso> flussoIncassiAmounts = new Dictionary<int, infoIncasso>();

		public Dictionary<int, decimal> availableByIdInc = new Dictionary<int, decimal>();
		public Dictionary<int, incomeRow> incomeByIdInc = new Dictionary<int, incomeRow>();
		public Dictionary<int, incomeyearRow> incomeYearByIdInc = new Dictionary<int, incomeyearRow>();

		public Dictionary<int, List<flussoincassidetailRow>> dettFlussoIncassiPerIdFlusso =
				new Dictionary<int, List<flussoincassidetailRow>>();

		/// <summary>
		/// Indicizza un dett.incassi per idflusso
		/// </summary>
		/// <param name="r"></param>
		public void addDettFlussoIncassi(flussoincassidetailRow r)
		{
			if (!dettFlussoIncassiPerIdFlusso.ContainsKey(r.idflusso))
			{
				dettFlussoIncassiPerIdFlusso[r.idflusso] = new List<flussoincassidetailRow>();
			}

			dettFlussoIncassiPerIdFlusso[r.idflusso].Add(r);
		}

		/// <summary>
		/// Indicizza un dett.c.attivo per iduniqueformcode
		/// </summary>
		/// <param name="r"></param>
		public void addDettContratto(estimatedetailRow r)
		{
			if (r.iduniqueformcode != null)
			{
				if (!dettContrattoPerUniqueFormCode.ContainsKey(r.iduniqueformcode))
				{
					dettContrattoPerUniqueFormCode[r.iduniqueformcode] = new List<estimatedetailRow>();
				}

				dettContrattoPerUniqueFormCode[r.iduniqueformcode].Add(r);
			}
		}

		/// <summary>
		/// Indicizza un dett. fattura per codice iduniqueformcode
		/// </summary>
		/// <param name="r"></param>
		public void addDettFattura(invoicedetailRow r)
		{
			if (r.iduniqueformcode != null)
			{
				if (!dettFatturaPerUniqueFormCode.ContainsKey(r.iduniqueformcode))
				{
					dettFatturaPerUniqueFormCode[r.iduniqueformcode] = new List<invoicedetailRow>();
				}

				dettFatturaPerUniqueFormCode[r.iduniqueformcode].Add(r);
			}
		}

		/// <summary>
		/// Indicizza un dettaglio credito per iuv
		/// </summary>
		/// <param name="r"></param>
		public void addDettFlussoCrediti(flussocreditidetailRow r)
		{
			if (r.iuv != null)
			{
				if (!creditiPerIuv.ContainsKey(r.iuv)) creditiPerIuv[r.iuv] = new List<flussocreditidetailRow>();
				creditiPerIuv[r.iuv].Add(r);
			}

			if (r.iduniqueformcode != null)
			{
				if (!creditiPerUniqueFormCode.ContainsKey(r.iduniqueformcode))
					creditiPerUniqueFormCode[r.iduniqueformcode] = new List<flussocreditidetailRow>();
				creditiPerUniqueFormCode[r.iduniqueformcode].Add(r);
			}
		}
	}
}
