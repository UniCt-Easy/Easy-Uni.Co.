
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicont() {
		MetaPage.apply(this, ['rendicont', 'default', true]);
        this.name = 'Scheda di rendicontazione / registro elettronico';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_rendicont.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicont,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-rendicont_default");
				var arraydef = [];
				
				arraydef.push(this.manage_lezione_title());
				arraydef.push(this.managerendicont_default_title());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				_.forEach(this.getDataTable("rendicontaltro").rows, function (r) {
					var title = r.ore + ' ore';
					if(r.idrendicontaltrokind) {
						var tipoRows = self.getDataTable("rendicontaltrokind").select(self.q.eq('idrendicontaltrokind', r.idrendicontaltrokind));
						title += ' per ' + tipoRows[0].title;
					}
					r['!title'] = title;
				});				this.managerendicont_default_title();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicont_default");
				var arraydef = [];
				
				arraydef.push(this.manage_lezione_title());
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			//afterClear

			
			afterLink: function () {
				var self = this;
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar7').fullCalendar('rerenderEvents');
				});
				$('.nav-tabs').on('shown.bs.tab', function (e) {
					$('#calendar8').fullCalendar('rerenderEvents');
				});
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-rendicont_default");
				$('#rendicont_default_aa').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#rendicont_default_aa').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#rendicont_default_aa').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Anno accademico');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			afterFill: function () {
				//afterFillin

				var self = this;
				if (!this.isEmpty()) {
					// carica tutte le attività dell'utente. seve per visualizzarle sul calendario
					var filter = self.q.and(
						self.q.eq("idreg", this.state.currentRow.idreg_docenti),
						self.q.eq("idrendicontaltro",0)
					);
					return this.getExternalEventForCalendar(filter, $("[data-tag='rendicontaltro.default.default']")).then(function () {
						var filterLez = self.q.and(
							self.q.eq("idreg", self.state.currentRow.idreg_docenti),
							self.q.eq("idlezione", 0)
						);
						return self.getExternalEventForCalendar(filterLez, $("[data-tag='lezione.rendicont.rendicont']")).then(function () {
							return MetaPage.prototype.afterFill.call(self);
						});

					});
				}
				return MetaPage.prototype.afterFill.call(this);
			},

			manage_lezione_title: function () {
				var self = this;
				//titolo delle lezioni
				var def = appMeta.Deferred('getlezioneTitle');
				var filter = this.q.and(this.q.isNotNull('idlezione'), this.q.eq('idreg', this.state.currentRow.idreg_docenti));
				appMeta.getData.runSelect("getcalendareventview",
					"color, title, start, stop, ore, idlezione, idassetdiary, idrendicontattivitaprogetto", filter, null)
					.then(function (dt) {

						_.forEach(self.getDataTable("lezione").rows, function (r) {

							var currLezioneEvent = _.find(dt.rows, function (row) {
								return row.idlezione === r.idlezione;
							});

							r['!title'] = currLezioneEvent.title;

						});

						def.resolve();
					});
				return def.promise();
			},

			managerendicont_default_title: function () {
				this.state.currentRow.title = "Rendicontazione " + this.state.currentRow.aa;


			},

			children: ['lezione', 'rendicontaltro'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('rendicont', 'default', metaPage_rendicont);

}());
