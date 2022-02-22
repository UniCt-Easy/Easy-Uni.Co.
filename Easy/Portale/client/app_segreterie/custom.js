
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


/* On scroll fixed menÃ¹ */
$(document).scroll(function () {
	//alert($('.navbar').hasClass('fixed-navbar'));
	if ($(window).scrollTop() > 38 && $('#toolbar').hasClass('fixed-navbar') == false) {
		$('#toolbar').addClass('fixed-navbar');
		$('#metaRoot').addClass('fixed-metaRoot');
	}
	else if ($(window).scrollTop() <= 38) {
		$('#toolbar').removeClass('fixed-navbar');
		$('#metaRoot').removeClass('fixed-metaRoot');
	}
});

$(document).ready(function () {

	//*************************ELENCO FORM ********************

	var last = 0;

	$('.form-control').focusin(function (event) {
		if (!last) {
			last = $(this).parent().parent().attr('id');
		}
		else {
			if ($(this).parent().parent().attr('id') !== last) {
				alert('validazione di ' + last);
				last = $(this).parent().parent().attr('id');
			}
		}
	});

	$('a').focusin(function (event) {
		if (last) {
			alert('validazione di ' + last);
			last = null;
		}
	});

	//*************************WIZARD ********************

	var navListItems = $('div.setup-panel div a'),
		allWells = $('.setup-content'),
		allPrevBtn = $('.prevBtn'),
		allNextBtn = $('.nextBtn');

	allWells.hide();

	navListItems.click(function (e) {
		e.preventDefault();
		var $target = $($(this).attr('href')),
			$item = $(this);

		if (!$item.hasClass('disabled')) {
			navListItems.removeClass('btn-primary').addClass('btn-default');
			$item.addClass('btn-primary');
			allWells.hide();
			$target.show();
			$target.find('input:eq(0)').focus();
		}
	});

	allNextBtn.click(function () {
		var curStep = $(this).closest(".setup-content"),
			curStepBtn = curStep.attr("id"),
			nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
			curInputs = curStep.find("input[type='text'],input[type='url']"),
			isValid = true;

		$(".form-group").removeClass("has-error");
		for (var i = 0; i < curInputs.length; i++) {
			if (!curInputs[i].validity.valid) {
				isValid = false;
				$(curInputs[i]).closest(".form-group").addClass("has-error");
			}
		}

		if (isValid)
			nextStepWizard.removeAttr('disabled').trigger('click');
	});

	$('div.setup-panel div a.btn-primary').trigger('click');

});


/**
 * @module CustomUtils
 * @description
 * Contains the common methods useful for the web app
 */
(function () {

	/**
	 * @constructor CustomUtils
	 * @description
	 * Utilities for web app developed wth MDLW
	 */
	function CustomUtils() {
		"use strict";
	}

	CustomUtils.prototype = {
		constructor: CustomUtils,
		/**
		 * Read a query url string and returns a dictionary with key values
		 * @returns {{}}
		 */
		getUrlVars: function () {
			var vars = {};
			window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
				vars[key] = value;
			});
			return vars;
		},

		getSQLStringFromDateTime: function (d) {
			return '' + d.getFullYear() + _.padStart((d.getMonth() + 1), 2, '0') + _.padStart(d.getDate(), 2, '0') + ' ' +
				_.padStart(d.getHours(), 2, '0') + ':' + _.padStart(d.getMinutes(),2,'0') + ':000';
		}
	};



	appMeta.customUtils = new CustomUtils();
}());
