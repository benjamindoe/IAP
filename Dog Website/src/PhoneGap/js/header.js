$(document).on('ready pagechange', function(){
	$(window).on("scroll", function(){
		if ($(window).scrollTop() >= $('.ui-page-active .logo--wrapper').height()) {
			$("header").addClass("sticky");
		}else{
			$("header").removeClass("sticky");
		}
	});
	$('.header__nav').off().on("click", function(){
		if ($(this).hasClass('active')) {
			$(this).removeClass('active');
		} else {
			$(this).addClass('active');
		}
	});
});