
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


(function () {

   var MetaData = window.appMeta.MetaSegreterieData;

   function meta_perfvalutazionepersonale() {
      MetaData.apply(this, ["perfvalutazionepersonale"]);
      this.name = 'meta_perfvalutazionepersonale';
   }

   meta_perfvalutazionepersonale.prototype = _.extend(
      new MetaData(),
      {
         constructor: meta_perfvalutazionepersonale,
         superClass: MetaData.prototype,

         describeColumns: function (table, listType) {
            var nPos = 1;
            var objCalcFieldConfig = {};
            var self = this;
            _.forEach(table.columns, function (c) {
               self.describeAColumn(table, c.name, '', null, -1, null);
            });
            switch (listType) {
               default:
                  return this.superClass.describeColumns(table, listType);
               case 'default':
						this.describeAColumn(table, 'year', 'Anno solare', null, 30, null);
						this.describeAColumn(table, 'risultato', 'Percentuale risultato', 'fixed.2', 40, null);
						this.describeAColumn(table, 'pesoperfuo', 'Peso della valutazione della performance dell’unità organizzativa', 'fixed.2', 90, null);
						this.describeAColumn(table, 'percperfuo', 'Percentuale di completamento dell’unità organizzativa', 'fixed.2', 100, null);
						this.describeAColumn(table, 'pesocomportamenti', 'Peso della valutazione della performance dei comportamenti attesi', 'fixed.2', 120, null);
						this.describeAColumn(table, 'perccomportamenti', 'Percentuale di completamento dei comportamenti attesi', 'fixed.2', 130, null);
						this.describeAColumn(table, 'pesoobiettivi', 'Peso della valutazione della performance degli obiettivi individuali', 'fixed.2', 150, null);
						this.describeAColumn(table, 'percobiettivi', 'Percentuale di completamento degli obiettivi individuali', 'fixed.2', 160, null);
//$objCalcFieldConfig_default$
                  break;
               //$objCalcFieldConfig$
            }
            table['customObjCalculateFields'] = objCalcFieldConfig;
            appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
            return appMeta.Deferred("describeColumns").resolve();
         },


         setCaption: function (table, edittype) {
            switch (edittype) {
               case 'default':
                  table.columns["idperfschedastatus"].caption = "Stato";
                  table.columns["idreg"].caption = "Valutato";
                  table.columns["idreg_val"].caption = "Valutatore";
                  table.columns["risultato"].caption = "Percentuale risultato";
                  table.columns["year"].caption = "Anno solare";
                  table.columns["perccomportamenti"].caption = "Percentuale di completamento dei comportamenti attesi";
                  table.columns["percobiettivi"].caption = "Percentuale di completamento degli obiettivi individuali";
                  table.columns["percperfuo"].caption = "Percentuale di completamento dell’unità organizzativa";
                  table.columns["pesocomportamenti"].caption = "Peso della valutazione della performance dei comportamenti attesi";
                  table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi individuali";
                  table.columns["pesoperfuo"].caption = "Peso della valutazione della performance dell’unità organizzativa";
                  						table.columns["idperfschedastatus"].caption = "Stato";
						table.columns["idreg"].caption = "Valutato";
						table.columns["idreg_val"].caption = "Valutatore";
						table.columns["perccomportamenti"].caption = "Percentuale di completamento dei comportamenti attesi";
						table.columns["percobiettivi"].caption = "Percentuale di completamento degli obiettivi individuali";
						table.columns["percperfuo"].caption = "Percentuale di completamento dell’unità organizzativa";
						table.columns["pesocomportamenti"].caption = "Peso della valutazione della performance dei comportamenti attesi";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi individuali";
						table.columns["pesoperfuo"].caption = "Peso della valutazione della performance dell’unità organizzativa";
						table.columns["risultato"].caption = "Percentuale risultato";
						table.columns["year"].caption = "Anno solare";
						
						table.columns["idreg_appr"].caption = "Approvatore";
						table.columns["idafferenza"].caption = "Afferenza";
//$innerSetCaptionConfig_default$
                  break;
               //$innerSetCaptionConfig$
            }
         },
         isValid: function (r) {

            //Aggiungere calcolo media
            var self = this;
            if ((r.current.pesoperfuo + r.current.pesocomportamenti + r.current.pesoobiettivi) > 100) {
               return self.getPromiseIsValidObject("Attenzione la somma dei pesi non corrisponde al 100%", "risultato", "risultato", r);
            }

            return this.superClass.isValid.call(this, r);

            //altre tabelle dataset
            //var ds = r.table.dataset;

         },

         getNewRow: function (parentRow, dt, editType) {
            var def = appMeta.Deferred("getNewRow-meta_perfvalutazionepersonale");

            //$getNewRowInside$

            dt.autoIncrement('idperfvalutazionepersonale', { minimum: 99990001 });

            // metto i default
            return this.superClass.getNewRow(parentRow, dt, editType)
               .then(function (dtRow) {
                  //$getNewRowDefault$
                  return def.resolve(dtRow);
               });
         },


         //$isValidFunction$

         //$getStaticFilter$

         //$getSorting$

      });

   window.appMeta.addMeta('perfvalutazionepersonale', new meta_perfvalutazionepersonale('perfvalutazionepersonale'));

}());
