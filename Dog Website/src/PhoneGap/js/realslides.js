$(document).ready(function(){
	var noOfChildren = $(".slides .slide .slide").length;
	var currentSlide = 1;

	var nextSlide = function() {
		var currentScroll = $('.slideshow__window').scrollLeft();
		if (currentSlide != noOfChildren){
			$('.next-slide').unbind('click', nextSlide);
			currentScroll += 300;
			currentSlide++;
			$('.slide').removeClass('active');
			$('.slides .slide:nth-child(' + currentSlide.toString() + ')').addClass('active');
			$('.slideshow__window').animate({
				scrollLeft: currentScroll
			}, 400, function(){
				$('.next-slide').bind('click', nextSlide);
			});
		}
		growText();
	};
	function prevSlide() {
		var currentScroll = $('.slideshow__window').scrollLeft();
		if (currentSlide != 1){
			$('.prev-slide').unbind('click', prevSlide);
			currentScroll -= 300;
			currentSlide--;
			$('.slide').removeClass('active');
			$('.slides .slide:nth-child(' + currentSlide.toString() + ')').addClass('active');
			$('.slideshow__window').animate({
				scrollLeft: currentScroll
			}, 400, function() {
				$('.prev-slide').bind('click', prevSlide);
			});
		}
		growText();
	};
	function grow() {
		var current = $('.slideshow__inner .slide:nth-child(' + currentSlide.toString() + ') .slide__img');
		var currentThumb = $('.thumbnail--slider #'+current.attr('id'));
		var Src = current.attr('src');
		var breed = Src.split('/')[1].split('-');
		var newSrc = 'images/' + breed[0] + '-';

		if(current.hasClass('puppy')){
			newSrc += 'adult.jpg';
			newName = 'Shrink';
			current.removeClass('puppy');
			currentThumb.removeClass('puppy');
		} else {
			newSrc += 'puppy.jpg';
			newName = 'Grow';
			current.addClass('puppy');
			currentThumb.addClass('puppy');
		}
		current.fadeOut();
		setTimeout(function(){
			current.attr('src', newSrc);
			currentThumb.attr('src', newSrc);
		}, 400);
		current.fadeIn();
		$('.grow').html(newName);
	}

	function growText() {
		var current = $('.slide:nth-child(' + currentSlide.toString() + ') .slide__img');
		var newName = current.hasClass("puppy") ? "Grow" : "Shrink";
		$(".grow").html(newName);
	}

	function sizeThumbs(){
	//resize each idea image so it is a good sized/centered thumbnail
		$(".slide__img").each(function(index) {
			var slideNumber = index + 1;
			var container = $('<div class="thumbnail" slide-number="'+ slideNumber +'"></div>');
			var maxWidth = 100;
			var maxHeight = 100;
			var width = $(this).width();
			var height = $(this).height();
			var clone = $(this).clone();

			if((width/maxWidth) < (height/maxHeight)){
				var multiplier = maxWidth/width;
				var newHeight = height * multiplier;

				clone.css("width", maxWidth);
				clone.css("height", newHeight);

				var heightD = (maxHeight - newHeight)/2;
				clone.css("margin-top", heightD+"px");
				clone.css("margin-bottom", heightD+"px");
			}else{
				var multiplier = maxHeight/height;
				var newWidth = width * multiplier;

				clone.css("width", newWidth);
				clone.css("height", maxHeight);

				var widthD = (maxWidth - width)/2;
				clone.css("margin-left", widthD+"px");
				clone.css("margin-right", widthD+"px");
			}
			container.append(clone);
			$(".thumbnail--slider").append(container);
		});
	}

	function goTo(slideToGo) {
		$('.slide').removeClass('active');
		var newScroll = (slideToGo - 1) * 300;
		$('.slideshow__window').animate({
				scrollLeft: newScroll
			}, 400);
		currentSlide = slideToGo;
		$('.slides .slide:nth-child(' + currentSlide.toString() + ')').addClass('active');
	}

	
	setTimeout(sizeThumbs(),500);


	$('.next-slide').click(nextSlide);
	$('.prev-slide').click(prevSlide);
	$('.slideshow__window').swipeleft(nextSlide);
	$('.slideshow__window').swiperight(prevSlide);
	$('.grow').click(grow);
	$('.thumbnail').click(function(){
		var slide = $(this).attr('slide-number');
		goTo(slide);
	});
});
