using System.Collections.Generic;

namespace ADPv2.Translator {

	/// <summary>
	/// Mapping definiti staticamente per mantenere la compatibilità con il codice preesistente
	/// </summary>
	public static class Mappings {
		/// <summary>
		/// Associazioni tra nome campi nel nuovo formato di trasmissione e nomi delle tabelle di traduzione.
		/// </summary>
		public static readonly Dictionary<FieldName, string> Tables = new Dictionary<FieldName, string> {
			{ FieldName.OggettoIncarico, "apactivitykind" },
			{ FieldName.TipologiaNorma, "referencerule"},
			{ FieldName.AmbitoTematico, "thematicscope" },
			{ FieldName.ServizioIstituzionePubblica, "publicinstitutionservice" },
		};

		/// <summary>
		/// Associazioni tra coppia di nome campo e ruolo, e nome della colonna sulla tabella di traduzione.
		/// </summary>
		public static readonly Dictionary<KeyValuePair<FieldName, TRole>, string> Columns = new Dictionary<KeyValuePair<FieldName, TRole>, string> {
			{ new KeyValuePair<FieldName, TRole>(FieldName.OggettoIncarico, TRole.Consulente), "idconsultant"},
			{ new KeyValuePair<FieldName, TRole>(FieldName.OggettoIncarico, TRole.Dipendente), "idemployee"},
			{ new KeyValuePair<FieldName, TRole>(FieldName.TipologiaNorma, TRole.Consulente), "idtipologianorma"},
			{ new KeyValuePair<FieldName, TRole>(FieldName.TipologiaNorma, TRole.Dipendente), "idtipologianorma"},
			{ new KeyValuePair<FieldName, TRole>(FieldName.AmbitoTematico, TRole.Consulente), "idconsultant" },
			{ new KeyValuePair<FieldName, TRole>(FieldName.AmbitoTematico, TRole.Dipendente), "idemployee" },
			{ new KeyValuePair<FieldName, TRole>(FieldName.ServizioIstituzionePubblica, TRole.Consulente), "idservizio" },
			{ new KeyValuePair<FieldName, TRole>(FieldName.ServizioIstituzionePubblica, TRole.Dipendente), "idservizio" },
		};
	}

	/// <summary>
	/// Traduzioni definite staticamente per mantenere la compatibilità con il codice preesistente
	/// </summary>
	public static class Translations {
		/// <summary>
		/// Associazioni tra vecchi codici trasmessi secondo la tabella "apregistrykind" e gli attuali codici
		/// </summary>
		public static Dictionary<string, EnumTipoSoggettoConferente> SoggettoConferente = new Dictionary<string, EnumTipoSoggettoConferente> {
			{ "1", EnumTipoSoggettoConferente.Pubblico },
			{ "2", EnumTipoSoggettoConferente.Privato },
			{ "3", EnumTipoSoggettoConferente.Privato },
			{ "4", EnumTipoSoggettoConferente.Privato },
			{ "5", EnumTipoSoggettoConferente.Privato },
		};

		/// <summary>
		/// Associazioni tra vecchi codici trasmessi secondo la tabella "apmanager" e gli attuali codici
		/// </summary>
		public static Dictionary<string, EnumQualificaPercettore> QualificaPercettore = new Dictionary<string, EnumQualificaPercettore> {
			{ "1", EnumQualificaPercettore.Dirigente },
			{ "2", EnumQualificaPercettore.NonDirigente },
			{ "103", EnumQualificaPercettore.NonDirigente }, // aggiunto per compatibilità col passato
		};
	}
}
