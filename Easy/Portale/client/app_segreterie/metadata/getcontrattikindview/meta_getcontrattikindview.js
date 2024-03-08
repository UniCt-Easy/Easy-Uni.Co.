(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_getcontrattikindview() {
        MetaData.apply(this, ["getcontrattikindview"]);
        this.name = 'meta_getcontrattikindview';
    }

    meta_getcontrattikindview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcontrattikindview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 10, 50);
						this.describeAColumn(table, 'costolordoannuo', 'Costolordoannuo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'costolordoannuo_ck', 'Costolordoannuo_ck', 'fixed.2', 30, null);
						this.describeAColumn(table, 'costolordoannuo_inq', 'Costolordoannuo_inq', 'fixed.2', 40, null);
						this.describeAColumn(table, 'costolordoannuo_stip', 'Costolordoannuo_stip', 'fixed.2', 50, null);
						this.describeAColumn(table, 'costomese', 'Costomese', 'fixed.2', 60, null);
						this.describeAColumn(table, 'costoora', 'Costoora', 'fixed.2', 70, null);
						this.describeAColumn(table, 'oremaxdidatempoparziale', 'Oremaxdidatempoparziale', null, 90, null);
						this.describeAColumn(table, 'oremaxdidatempopieno', 'Oremaxdidatempopieno', null, 100, null);
						this.describeAColumn(table, 'oremaxgg', 'Oremaxgg', null, 110, null);
						this.describeAColumn(table, 'oremaxtempoparziale', 'Oremaxtempoparziale', null, 120, null);
						this.describeAColumn(table, 'oremaxtempopieno', 'Oremaxtempopieno', null, 130, null);
						this.describeAColumn(table, 'oremindidatempoparziale', 'Oremindidatempoparziale', null, 140, null);
						this.describeAColumn(table, 'oremindidatempopieno', 'Oremindidatempopieno', null, 150, null);
						this.describeAColumn(table, 'parttime', 'Parttime', null, 160, null);
						this.describeAColumn(table, 'tempdef', 'Tempdef', null, 170, null);
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

    window.appMeta.addMeta('getcontrattikindview', new meta_getcontrattikindview('getcontrattikindview'));

	}());
