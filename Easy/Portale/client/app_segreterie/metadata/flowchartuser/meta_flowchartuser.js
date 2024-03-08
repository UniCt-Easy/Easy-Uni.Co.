(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_flowchartuser() {
        MetaData.apply(this, ["flowchartuser"]);
        this.name = 'meta_flowchartuser';
    }

    meta_flowchartuser.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_flowchartuser,
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
					case 'seg':
						this.describeAColumn(table, 'idcustomuser', 'Utente', null, 10, 50);
						this.describeAColumn(table, 'start', 'Data inizio validità', null, 210, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 220, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["idcustomuser"].caption = "Utente";
						table.columns["start"].caption = "Data inizio validità";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_flowchartuser");

				//$getNewRowInside$
				dt.autoIncrement('ndetail', { minimum: 99990001, selector: ["idflowchart"] });


				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "idcustomuser asc , title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('flowchartuser', new meta_flowchartuser('flowchartuser'));

	}());
