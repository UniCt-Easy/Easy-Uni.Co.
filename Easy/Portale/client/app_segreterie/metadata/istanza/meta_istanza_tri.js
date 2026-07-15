(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_tri() {
        MetaData.apply(this, ["istanza_tri"]);
        this.name = 'meta_istanza_tri';
    }

    meta_istanza_tri.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_tri,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'tri_seg':
						this.describeAColumn(table, 'aaprimaiscr', 'Anno accademico di prima iscrizione', null, 510, 9);
//$objCalcFieldConfig_tri_seg$
						break;
					case 'tri_stu':
						this.describeAColumn(table, 'aaprimaiscr', 'Anno accademico di prima iscrizione', null, 510, 9);
//$objCalcFieldConfig_tri_stu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'tri_seg':
						table.columns["aaprimaiscr"].caption = "Anno accademico di prima iscrizione";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddichiar_titolo"].caption = "Dichiarazione di titolo di studio in corso";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idreg"].caption = "Studente";
						table.columns["idreg_istituti"].caption = "Istituto di provenienza";
//$innerSetCaptionConfig_tri_seg$
						break;
					case 'tri_stu':
//$innerSetCaptionConfig_tri_stu$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_tri");

				//$getNewRowInside$


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

    window.appMeta.addMeta('istanza_tri', new meta_istanza_tri('istanza_tri'));

	}());
