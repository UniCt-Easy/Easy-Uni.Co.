(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tirociniopropostosegview() {
        MetaData.apply(this, ["tirociniopropostosegview"]);
        this.name = 'meta_tirociniopropostosegview';
    }

    meta_tirociniopropostosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirociniopropostosegview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 1000, -1);
						this.describeAColumn(table, 'aoo_title', 'Area organizzativa omogenea', null, 4200, 1024);
						this.describeAColumn(table, 'registryreferente_title', 'Referente', null, 5300, 101);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura dell\'istituto', null, 6100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Struttura dell\'istituto', null, 6220, 50);
						this.describeAColumn(table, 'tirocinioproposto_ore', 'Ore', null, 8000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg_referente", "idtirocinioproposto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tirociniopropostosegview', new meta_tirociniopropostosegview('tirociniopropostosegview'));

	}());
