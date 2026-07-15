(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiar() {
        MetaData.apply(this, ["dichiar"]);
        this.name = 'meta_dichiar';
    }

    meta_dichiar.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiar,
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
					case 'titolo_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico della dichiarazione', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_titolo_seg$
						break;
					case 'disabil_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_disabil_seg$
						break;
					case 'altre_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_altre_seg$
						break;
					case 'altrititoli_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 580, 9);
						this.describeAColumn(table, 'date', 'Data', null, 590, null);
//$objCalcFieldConfig_altrititoli_seg$
						break;
					case 'isee_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_isee_seg$
						break;
					case 'seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_seg$
						break;
					case 'isee_stu':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_isee_stu$
						break;
					case 'altrititoli_stu':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_altrititoli_stu$
						break;
					case 'titolo_stu':
						this.describeAColumn(table, 'aa', 'Anno accademico della dichiarazione', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data della dichiarazione', null, 20, null);
//$objCalcFieldConfig_titolo_stu$
						break;
					case 'disabil_stu':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'date', 'Data', null, 30, null);
//$objCalcFieldConfig_disabil_stu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'titolo_seg':
						table.columns["aa"].caption = "Anno accademico della dichiarazione";
//$innerSetCaptionConfig_titolo_seg$
						break;
					case 'isee_seg':
						table.columns["aa"].caption = "Anno Accademico";
						table.columns["date"].caption = "Data";
						table.columns["extension"].caption = "Tabella che estende il record";
						table.columns["iddichiarkind"].caption = "Tipologia";
						table.columns["idreg"].caption = "Studente";
						table.columns["protanno"].caption = "Anno Protocollo";
						table.columns["protnumero"].caption = "Numero Protocollo";
//$innerSetCaptionConfig_isee_seg$
						break;
					case 'isee_stu':
//$innerSetCaptionConfig_isee_stu$
						break;
					case 'altrititoli_stu':
//$innerSetCaptionConfig_altrititoli_stu$
						break;
					case 'titolo_stu':
						table.columns["date"].caption = "Data della dichiarazione";
//$innerSetCaptionConfig_titolo_stu$
						break;
					case 'disabil_stu':
//$innerSetCaptionConfig_disabil_stu$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_dichiar");

				//$getNewRowInside$

				dt.autoIncrement('iddichiar', { minimum: 99990001 });

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

    window.appMeta.addMeta('dichiar', new meta_dichiar('dichiar'));

	}());
