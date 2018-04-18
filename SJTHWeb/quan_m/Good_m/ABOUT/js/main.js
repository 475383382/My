;(function () {
	
	'use strict';



	// iPad and iPod detection	
	var isiPad = function(){
		return (navigator.platform.indexOf("iPad") != -1);
	};

	var isiPhone = function(){
	    return (
			(navigator.platform.indexOf("<i></i>Phone") != -1) || 
			(navigator.platform.indexOf("iPod") != -1)
	    );
	};

	var fullHeight = function() {
		if ( !isiPad() && !isiPhone() ) {
			$('.js-fullheight').css('height', $(window).height());
			$(window).resize(function(){
				$('.js-fullheight').css('height', $(window).height());
			})
		}
	};

	var sliderMain = function() {
		
	  	$('#fanda-home .flexslider').flexslider({
			animation: "fade",
			slideshowSpeed: 5000
	  	});

	  	$('#fanda-home .flexslider .slides > li').css('height', $(window).height());	
	  	$(window).resize(function(){
	  		$('#fanda-home .flexslider .slides > li').css('height', $(window).height());	
	  	});

	  	$('.js-fanda-next').on('click', function(event){

	  		event.preventDefault();
	  		$('html, body').animate({
				scrollTop: $(this).closest('#fanda-home').next().offset().top
			}, 800, 'easeOutExpo');
	  		
	  	});

	};

	var sliderTestimony = function() {

		$('#fanda-testimony .flexslider').flexslider({
			animation: "slide",
			slideshowSpeed: 5000,
			directionNav: false,
			controlNav: true,
			smoothHeight: true,
			reverse: true
	  	});

	}

	var offcanvasMenu = function() {

		
		$('#fanda-offcanvas').append($('#fanda-main-nav').clone());

		setTimeout(function(){
			$('#fanda-offcanvas').prepend('<a href="#" class="js-fanda-offcanvas-close fanda-offcanvas-close" />');
			$('#fanda-offcanvas #fanda-main-nav').attr('id', '');
		}, 200);
		
	};
	
	// Window Scroll
	/*var windowScroll = function() {
		var lastScrollTop = 0;

		$(window).scroll(function(event){

		   	var header = $('#fanda-header'),
				scrlTop = $(this).scrollTop();

			if ( scrlTop > 100 && scrlTop <= 2000 ) {
				header.addClass('navbar-fixed-top fanda-animated slideInDown');
			} else if ( scrlTop <= 100) {
				if ( header.hasClass('navbar-fixed-top') ) {
					header.addClass('navbar-fixed-top fanda-animated slideOutUp');
					setTimeout(function(){
						header.removeClass('navbar-fixed-top fanda-animated slideInDown slideOutUp');
					}, 100 );
				}
			} 
			
		});
	};*/

	var mainMenuSticky = function() {
		
		var sticky = $('.js-sticky');

		sticky.css('height', sticky.height());
		$(window).resize(function(){
			sticky.css('height', sticky.height());
		});

		var $section = $('.fanda-main-nav');
		
		$section.waypoint(function(direction) {
		  	
		  	if (direction === 'down') {

			    	$section.css({
			    		'position' : 'fixed',
			    		'top' : 0,
			    		'width' : '100%',
			    		'z-index' : 99999
			    	}).addClass('fanda-shadow');;

			}

		}, {
	  		offset: '0px'
		});

		$('.js-sticky').waypoint(function(direction) {
		  	if (direction === 'up') {
		    	$section.attr('style', '').removeClass('fanda-shadow');
		  	}
		}, {
		  	offset: function() { return -$(this.element).height() + 69; }
		});

	};

	// Click outside of offcanvass
	var mobileMenuOutsideClick = function() {

		$(document).click(function (e) {
	    var container = $("#fanda-offcanvas, .js-fanda-nav-toggle, .js-fanda-offcanvas-close");
	    if (!container.is(e.target) && container.has(e.target).length === 0) {
	    	if ( $('body').hasClass('offcanvas-visible') ) {

	    		$('body').removeClass('fanda-overflow offcanvas-visible');

	    		$('.js-fanda-nav-toggle').removeClass('active');
	    	}
	    }
		});

		$('body').on('click', '.js-fanda-offcanvas-close', function(event){
			
			if ( $('body').hasClass('offcanvas-visible') ) {
	    		$('body').removeClass('fanda-overflow offcanvas-visible');
	    		$('.js-fanda-nav-toggle').removeClass('active');
	    	}

	    	event.preventDefault();

		});

	};
	
	// Parallax
	var parallax = function() {

		$(window).stellar();

	};


	// Redirect page 
	var redirectPage = function(url) {
		
		window.location = url;

	}

	var pageTransition = function() {

		$("body").css("display", "none");
		
		
		$("body").fadeIn(2000);
		
		$("a.transition").click(function(event){
		  	event.preventDefault();
		  	var linkLocation = this.href;

		  	$("body").fadeOut(2000, redirectPage);      
		  	
		  	redirectPage(linkLocation);
		});
			
	};


	// Burger Menu
	var burgerMenu = function() {

		$('body').on('click', '.js-fanda-nav-toggle', function(event){

			var $this = $(this);

			$('body').toggleClass('fanda-overflow offcanvas-visible');
			$this.toggleClass('active');
			event.preventDefault();

		});

	};
	
	
	
	
	

	var scrolledWindow = function() {

		var lastScrollTop = 0;

		$(window).scroll(function(event){

		   	var header = $('#fanda-header'),
				scrlTop = $(this).scrollTop();

			if ( scrlTop > 100 && scrlTop <= 2000 ) {
				header.addClass('navbar-fixed-top fanda-animated slideInDown');
			} else if ( scrlTop <= 100) {
				if ( header.hasClass('navbar-fixed-top') ) {
					header.addClass('navbar-fixed-top fanda-animated slideOutUp');
					setTimeout(function(){
						header.removeClass('navbar-fixed-top fanda-animated slideInDown slideOutUp');
					}, 100 );
				}
			} 
			
		});

		$(window).resize(function() {
			if ( $('body').hasClass('offcanvas-visible') ) {
		   	$('body').removeClass('offcanvas-visible');
		   	$('.js-fanda-nav-toggle').removeClass('active');
		   }
		});
		
	};


	var goToTop = function() {

		$('.js-gotop').on('click', function(event){
			
			event.preventDefault();

			$('html, body').animate({
				scrollTop: $('html').offset().top
			}, 500);
			
			return false;
		});
	
	};


	// Page Nav
	var clickMenu = function() {
		var topVal = ( $(window).width() < 769 ) ? 0 : 58;

		$(window).resize(function(){
			topVal = ( $(window).width() < 769 ) ? 0 : 58;		
		});

	

		


	};

	// Reflect scrolling in navigation
	var navActive = function(section) {
		
		$('#fanda-main-nav li, #fanda-offcanvas li').removeClass('active');
		$('#fanda-main-nav, #fanda-offcanvas').find('a[data-nav-section="'+section+'"]').closest('li').addClass('active');
		
	};

	var navigationSection = function() {

		var $section = $('div[data-section]');
		
		$section.waypoint(function(direction) {
		  	if (direction === 'down') {
		    	navActive($(this.element).data('section'));
		  	}

		}, {
	  		offset: '150px'
		});

		$section.waypoint(function(direction) {
		  	if (direction === 'up') {
		    	navActive($(this.element).data('section'));
		  	}
		}, {
		  	offset: function() { return -$(this.element).height() + 155; }
		});

	};



	var contentWayPoint = function() {
		var i = 0;
		$('.animate-box').waypoint( function( direction ) {

			if( direction === 'down' && !$(this.element).hasClass('animated') ) {
				
				i++;

				$(this.element).addClass('item-animate');
				setTimeout(function(){
					
					$('body .animate-box.item-animate').each(function(k){
						var el = $(this);
						setTimeout( function () {
							el.addClass('fadeInUp animated');
							el.removeClass('item-animate');
						},  k * 200, 'easeInOutExpo' );
					});
					
				}, 100);
				
			}

		} , { offset: '85%' } );


	};


	// Document on load.
	$(function(){

		pageTransition();
		fullHeight();
		sliderMain();
		sliderTestimony();
		offcanvasMenu();
		mainMenuSticky();
		mobileMenuOutsideClick();
		parallax();
		burgerMenu();
		scrolledWindow();
		clickMenu();
		navigationSection();
		goToTop();
		


		// Animations
		contentWayPoint();
		
		

	});


}());