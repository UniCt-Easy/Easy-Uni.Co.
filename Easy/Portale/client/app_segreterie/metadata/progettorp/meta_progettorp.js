(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettorp() {
        MetaData.apply(this, ["progettorp"]);
        this.name = 'meta_progettorp';
    }

    meta_progettorp.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettorp,
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
					case 'default':
						this.describeAColumn(table, 'start', 'Data di inizio', null, 30, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 40, null);
						this.describeAColumn(table, 'datefilter', 'Filtra i costi per:', null, 50, null);
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
						table.columns["datefilter"].caption = "Filtra i costi per:";
						table.columns["start"].caption = "Data di inizio";
						table.columns["stop"].caption = "Data di fine";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettorp");

				//$getNewRowInside$

				dt.autoIncrement('idprogettorp', { minimum: 99990001 });

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

    window.appMeta.addMeta('progettorp', new meta_progettorp('progettorp'));

	}());
