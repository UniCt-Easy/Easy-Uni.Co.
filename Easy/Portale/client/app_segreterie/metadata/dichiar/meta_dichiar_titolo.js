(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiar_titolo() {
        MetaData.apply(this, ["dichiar_titolo"]);
        this.name = 'meta_dichiar_titolo';
    }

    meta_dichiar_titolo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiar_titolo,
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
					case 'titolo_stu':
						return this.superClass.describeColumns(table, listType);
//$objCalcFieldConfig_titolo_stu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'titolo_stu':
						table.columns["idtitolostudio"].caption = "Titolo di studio";
//$innerSetCaptionConfig_titolo_stu$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_dichiar_titolo");

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

    window.appMeta.addMeta('dichiar_titolo', new meta_dichiar_titolo('dichiar_titolo'));

	}());
