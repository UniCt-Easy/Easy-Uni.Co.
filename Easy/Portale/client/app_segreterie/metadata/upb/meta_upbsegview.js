(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_upbsegview() {
        MetaData.apply(this, ["upbsegview"]);
        this.name = 'meta_upbsegview';
    }

    meta_upbsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_upbsegview,
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
						this.describeAColumn(table, 'codeupb', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'upb_title', 'Denominazione', null, 20, 150);
						this.describeAColumn(table, 'upb_active', 'Attivo', null, 30, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idupb"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "upb_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('upbsegview', new meta_upbsegview('upbsegview'));

	}());
