$(document).ready(function () {
	function a(a) {
		a.requestFullscreen ? a.requestFullscreen() : a.mozRequestFullScreen ? a.mozRequestFullScreen() : a.webkitRequestFullscreen ? a.webkitRequestFullscreen() : a.msRequestFullscreen && a.msRequestFullscreen()
	}
	$("body").on("click", "[data-ma-action]", function (b) {
		b.preventDefault();
		var c = $(this),
			d = c.data("ma-action"),
			e = "";
		switch (d) {
			case "aside-open":
				e = c.data("ma-target"), c.addClass("toggled"), $(e).addClass("toggled"), $(".content, .header").append('<div class="ma-backdrop" data-ma-action="aside-close" data-ma-target=' + e + " />");
				break;
			case "aside-close":
				e = c.data("ma-target"), $('[data-ma-action="aside-open"], ' + e).removeClass("toggled"), $(".content, .header").find(".ma-backdrop").remove();
				break;
		}
	})
});

/* ------------- Sidebar toggle menu -------------*/
$('body').on('click', '.navigation__sub > a', function (e) {
    e.preventDefault();

    $(this).parent().toggleClass('navigation__sub--toggled');
    $(this).next('ul').slideToggle(250);
});

/* ------------- Alert -------------*/
function jsOpenAlert(title, message, type){
    $.notify({
        icon: "",
        title: title,
        message: message,
        url: ""
    },{
        element: 'body',
        type: type,
        allow_dismiss: true,
        placement: {
            from: "top",
            align: "center"
        },
        offset: {
            x: 20,
            y: 20
        },
        spacing: 10,
        z_index: 1031,
        delay: 250000,
        timer: 1000,
        url_target: '_blank',
        mouse_over: false,
        animate: {
            enter: "animated fadeInDown",
            exit: "animated fadeOutUp"
        },
        template: '<div data-notify="container" class="alert alert-dismissible alert-{0} alert--notify" role="alert">' +
        			'<span data-notify="icon"></span> ' +
					'<span data-notify="title">{1}</span> ' +
					'<span data-notify="message">{2}</span>' +
					'<div class="progress" data-notify="progressbar">' +
					'<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
					'</div>' +
					'<a href="{3}" target="{4}" data-notify="url"></a>' +
					'<button type="button" aria-hidden="true" data-notify="dismiss" class="alert--notify__close">X</button>' +
					'</div>'
    });
}

/* ------------- LOADING ------------- */
function jsLoading(flag){

    if(flag){

        var fundo = document.createElement('div');
        fundo.id = 'loadingFundo';
        fundo.className = 'loadingFundoPreto';
        $('body').append(fundo);

        var loader = document.createElement('div');
        loader.id = 'loader';
        $('body').append(loader);

        var shadow = document.createElement('div');
        shadow.id = 'shadow';
        loader.append(shadow);

        var box = document.createElement('div');
        box.id = 'box';
        loader.append(box);
        
    }else{
        $('#loadingFundo').remove();
        $('#loader').remove();
    }
}