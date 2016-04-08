$(document).ready(function(){
	$(window).on("scroll", function(){
		if ($(window).scrollTop() >= $('.logo--wrapper').height()) {
			$("header").addClass("sticky");
		}else{
			$("header").removeClass("sticky");
		}
	});
	$('.header__nav').click(function(){
		if ($(window).width() < 1024) {
			if ($(this).hasClass('active')) {
				$('.header__nav').removeClass('active');
			} else {
				$('.header__nav').addClass('active');
			}
		}
	});
});