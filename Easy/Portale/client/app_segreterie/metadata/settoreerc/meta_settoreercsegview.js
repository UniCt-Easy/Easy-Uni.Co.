(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_settoreercsegview() {
        MetaData.apply(this, ["settoreercsegview"]);
        this.name = 'meta_settoreercsegview';
    }

    meta_settoreercsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_settoreercsegview,
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
					case 'seg':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'settoreerc_description', 'Descrizione', null, 30, 2048);
						this.describeAColumn(table, 'settoreerc_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'settoreerc_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsettoreerc"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "settoreerc_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('settoreercsegview', new meta_settoreercsegview('settoreercsegview'));

	}());
