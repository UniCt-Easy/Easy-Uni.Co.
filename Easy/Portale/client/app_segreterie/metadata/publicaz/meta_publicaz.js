(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_publicaz() {
        MetaData.apply(this, ["publicaz"]);
        this.name = 'meta_publicaz';
    }

    meta_publicaz.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_publicaz,
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
					case 'docenti':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 512);
						this.describeAColumn(table, 'title2', 'Sottotitolo', null, 30, 512);
						this.describeAColumn(table, 'annopub', 'Anno pubblicazione', null, 40, null);
						this.describeAColumn(table, 'editore', 'Editore', null, 50, 150);
//$objCalcFieldConfig_docenti$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 512);
						this.describeAColumn(table, 'title2', 'Sottotitolo', null, 30, 512);
						this.describeAColumn(table, 'annopub', 'Anno pubblicazione', null, 40, null);
						this.describeAColumn(table, 'editore', 'Editore', null, 50, 150);
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
					case 'default':
						table.columns["abstractstring"].caption = "Abstract";
						table.columns["annocopyright"].caption = "Anno Copyright";
						table.columns["annopub"].caption = "Anno pubblicazione";
						table.columns["idcity"].caption = "Comune";
						table.columns["idcity_ed"].caption = "Comune editore";
						table.columns["idnation_ed"].caption = "Nazionalità editore";
						table.columns["idnation_lang"].caption = "Lingua";
						table.columns["idpublicaz"].caption = "Codice Istituto";
						table.columns["isbn"].caption = "ISBN";
						table.columns["numrivista"].caption = "Numero Rivista";
						table.columns["pagestart"].caption = "Inizio a pagina";
						table.columns["pagestop"].caption = "fine a pagina";
						table.columns["pagetot"].caption = "Numero di pagine";
						table.columns["title"].caption = "Titolo";
						table.columns["title2"].caption = "Sottotitolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_publicaz");

				//$getNewRowInside$

				dt.autoIncrement('idpublicaz', { minimum: 99990001 });

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
					case "docenti": {
						return "title asc , title2 asc ";
					}
					case "default": {
						return "title asc , title2 asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('publicaz', new meta_publicaz('publicaz'));

	}());
