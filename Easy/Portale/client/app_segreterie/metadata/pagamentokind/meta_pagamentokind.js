(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pagamentokind() {
        MetaData.apply(this, ["pagamentokind"]);
        this.name = 'meta_pagamentokind';
    }

    meta_pagamentokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pagamentokind,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'sortcode', 'Sortcode', null, 40, null);
//$objCalcFieldConfig_default$
						break;
					case 'seg':
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'sortcode', 'Sortcode', null, 40, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pagamentokind");

				//$getNewRowInside$

				dt.autoIncrement('idpagamentokind', { minimum: 99990001 });

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
					case "default": {
						return "title asc ";
					}
					case "seg": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pagamentokind', new meta_pagamentokind('pagamentokind'));

	}());
