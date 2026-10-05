(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiardisabilsuppkinddefaultview() {
        MetaData.apply(this, ["dichiardisabilsuppkinddefaultview"]);
        this.name = 'meta_dichiardisabilsuppkinddefaultview';
    }

    meta_dichiardisabilsuppkinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiardisabilsuppkinddefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'title', 'Tipologia', null, 2000, 50);
						this.describeAColumn(table, 'dichiardisabilsuppkind_description', 'Descrizione', null, 3000, 256);
						this.describeAColumn(table, 'dichiardisabilsuppkind_active', 'Attivo', null, 4000, null);
						this.describeAColumn(table, 'dichiardisabilsuppkind_sortcode', 'Ordinamento', null, 5000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddichiardisabilsuppkind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					case "default": {
						return "title desc, dichiardisabilsuppkind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('dichiardisabilsuppkinddefaultview', new meta_dichiardisabilsuppkinddefaultview('dichiardisabilsuppkinddefaultview'));

	}());
