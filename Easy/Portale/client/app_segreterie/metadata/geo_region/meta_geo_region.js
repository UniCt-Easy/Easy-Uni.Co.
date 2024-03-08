(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_geo_region() {
        MetaData.apply(this, ["geo_region"]);
        this.name = 'meta_geo_region';
    }

    meta_geo_region.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_region,
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
					case 'segchild':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
//$objCalcFieldConfig_segchild$
						break;
					case 'seg':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
//$objCalcFieldConfig_seg$
						break;
					case 'default':
						this.describeAColumn(table, 'start', 'Inizio validità', null, 10, null);
						this.describeAColumn(table, 'stop', 'Fine validità', null, 20, null);
						this.describeAColumn(table, 'title', 'Regione', null, 30, 50);
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
					case 'segchild':
						table.columns["idnation"].caption = "Nazione";
//$innerSetCaptionConfig_segchild$
						break;
					case 'seg':
						table.columns["idnation"].caption = "Nazione";
//$innerSetCaptionConfig_seg$
						break;
					case 'default':
						table.columns["idnation"].caption = "Nazione";
						table.columns["start"].caption = "Inizio validità";
						table.columns["stop"].caption = "Fine validità";
						table.columns["title"].caption = "Regione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_geo_region");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idregion', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segchild": {
						return "title asc ";
					}
					case "seg": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('geo_region', new meta_geo_region('geo_region'));

	}());
