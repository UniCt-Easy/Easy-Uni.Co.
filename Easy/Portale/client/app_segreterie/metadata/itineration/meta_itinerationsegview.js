(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_itinerationsegview() {
        MetaData.apply(this, ["itinerationsegview"]);
        this.name = 'meta_itinerationsegview';
    }

    meta_itinerationsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_itinerationsegview,
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
						this.describeAColumn(table, 'description', 'Motivazione', null, 1000, 150);
						this.describeAColumn(table, 'itineration_location', 'Località di destinazione', null, 2000, 65);
						this.describeAColumn(table, 'itineration_start', 'Data inizio', 'g', 4000, null);
						this.describeAColumn(table, 'itineration_stop', 'Data fine', 'g', 5000, null);
						this.describeAColumn(table, 'upb_title', 'UPB', null, 54200, 150);
						this.describeAColumn(table, 'itineration_nitineration', 'Numero', null, 58000, null);
						this.describeAColumn(table, 'itineration_yitineration', 'Anno esercizio', null, 80000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iditineration"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "itineration_starttime asc , itineration_stoptime asc ";
					}
					case "seg": {
						return "itineration_start asc , itineration_stop asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('itinerationsegview', new meta_itinerationsegview('itinerationsegview'));

	}());
