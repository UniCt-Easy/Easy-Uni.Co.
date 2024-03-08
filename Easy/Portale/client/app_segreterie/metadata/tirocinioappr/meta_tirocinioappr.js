(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tirocinioappr() {
        MetaData.apply(this, ["tirocinioappr"]);
        this.name = 'meta_tirocinioappr';
    }

    meta_tirocinioappr.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirocinioappr,
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
						this.describeAColumn(table, 'approvazione', 'Approvazione', null, 20, null);
						this.describeAColumn(table, 'dataora', 'Dataora', 'g', 30, null);
						this.describeAColumn(table, '!idtirocinioapprkind_tirocinioapprkind_title', 'Tipo di approvazione', null, 51, null);
						objCalcFieldConfig['!idtirocinioapprkind_tirocinioapprkind_title'] = { tableNameLookup:'tirocinioapprkind', columnNameLookup:'title', columnNamekey:'idtirocinioapprkind' };
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
               var def = appMeta.Deferred("getNewRow-meta_tirocinioappr");

				//$getNewRowInside$

				dt.autoIncrement('idtirocinioappr', { minimum: 99990001 });

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

    window.appMeta.addMeta('tirocinioappr', new meta_tirocinioappr('tirocinioappr'));

	}());
