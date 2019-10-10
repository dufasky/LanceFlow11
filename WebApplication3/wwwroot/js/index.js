
$(document).ready(function(){
  /*variable for checking if navicon is active*/
  var isNavActive = false;

  /*change main menu statement by add or remove class*/
  $("#nav-open").click(function(){
    if (isNavActive == true) {
      $("header").removeClass("header-responsive");
      isNavActive = false;
    }
    else{
      $("header").addClass("header-responsive");
      isNavActive = true;
    }
  });

  /*animate hiding of main menu*/
  $("#nav-close").click(function(){
    $(".nav-menu").slideUp();
  });

  /*script for gallery functionality*/
  var imgIndex;
	var imgCount = $('.galleryImage').length;
	$('.galleryImage').click(function(){
    $(".imageBox").attr("src",$(this).attr('src'));
    $(".fullSizeImage").fadeIn(500);
		imgIndex = $(this).data( "index" );
  });

  /*click for next image*/
	$('.floatRight').click(function(){
		imgIndex++;
		if (imgIndex == (imgCount+1)) {
			imgIndex = 1;
		}
		$(".imageBox").attr("src",$('[data-index="'+imgIndex+'"]').attr('src'));
	});

  /*click for previous image*/
	$('.floatLeft').click(function(){
		imgIndex--;
		if (imgIndex == 0) {
			imgIndex = 4;
		}
		$(".imageBox").attr("src",$('[data-index="'+imgIndex+'"]').attr('src'));
	});

  /*close gallery modal window*/
  $('.closeBtn').click(function(){
    $(".fullSizeImage").fadeOut(500);
  });

  /*smooth scroll to section*/
  $("a").on('click', function(event) {

    if (this.hash !== "") {

    event.preventDefault();

      $('html, body').animate({
        scrollTop: $(this.hash).offset().top-30
      }, 800, function(){});
    }
  });
});
