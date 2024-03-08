(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_getcontrattikindviewdefaultview() {
        MetaData.apply(this, ["getcontrattikindviewdefaultview"]);
        this.name = 'meta_getcontrattikindviewdefaultview';
    }

    meta_getcontrattikindviewdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcontrattikindviewdefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 1000, 50);
						this.describeAColumn(table, 'getcontrattikindview_costolordoannuo', 'Costolordoannuo', 'fixed.2', 2000, null);
						this.describeAColumn(table, 'getcontrattikindview_costolordoannuo_ck', 'Costolordoannuo_ck', 'fixed.2', 3000, null);
						this.describeAColumn(table, 'getcontrattikindview_costolordoannuo_inq', 'Costolordoannuo_inq', 'fixed.2', 4000, null);
						this.describeAColumn(table, 'getcontrattikindview_costolordoannuo_stip', 'Costolordoannuo_stip', 'fixed.2', 5000, null);
						this.describeAColumn(table, 'getcontrattikindview_costomese', 'Costomese', 'fixed.2', 6000, null);
						this.describeAColumn(table, 'getcontrattikindview_costoora', 'Costoora', 'fixed.2', 7000, null);
						this.describeAColumn(table, 'position_title', 'Identificativo', null, 8200, 50);
						this.describeAColumn(table, 'getcontrattikindview_oremaxdidatempoparziale', 'Oremaxdidatempoparziale', null, 9000, null);
						this.describeAColumn(table, 'getcontrattikindview_oremaxdidatempopieno', 'Oremaxdidatempopieno', null, 10000, null);
						this.describeAColumn(table, 'getcontrattikindview_oremaxgg', 'Oremaxgg', null, 11000, null);
						this.describeAColumn(table, 'getcontrattikindview_oremaxtempoparziale', 'Oremaxtempoparziale', null, 12000, null);
						this.describeAColumn(table, 'getcontrattikindview_oremaxtempopieno', 'Oremaxtempopieno', null, 13000, null);
						this.describeAColumn(table, 'getcontrattikindview_oremindidatempoparziale', 'Oremindidatempoparziale', null, 14000, null);
						this.describeAColumn(table, 'getcontrattikindview_oremindidatempopieno', 'Oremindidatempopieno', null, 15000, null);
						this.describeAColumn(table, 'getcontrattikindview_parttime', 'Parttime', null, 16000, null);
						this.describeAColumn(table, 'getcontrattikindview_tempdef', 'Tempdef', null, 17000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcontrattokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('getcontrattikindviewdefaultview', new meta_getcontrattikindviewdefaultview('getcontrattikindviewdefaultview'));

	}());
