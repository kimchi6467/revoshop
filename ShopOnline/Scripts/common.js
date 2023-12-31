﻿jQuery(document).ready(function () {
    "use strict";

    $(document).on('click', '.filte-cate', function (e) {
        $(".filter-container").addClass("show_block");
    });
    $(document).on('click', '.close_filter', function (e) {
        $(".filter-container").removeClass("show_block");
    });
    $(document).on('click', '#sort-by ul', function (e) {
        $('#sort-by ul ul').toggleClass('show_block');
    });
    jQuery('.toggle').click(function () {
        if (jQuery('.submenu').is(":hidden")) {
            jQuery('.submenu').slideDown("fast");
        } else {
            jQuery('.submenu').slideUp("fast");
        }
        return false;
    });



    /*  Phone Menu  */

    jQuery(".topnav").accordion({
        accordion: false,
        speed: 300,
        closedSign: '+',
        openedSign: '-'
    });

    $("#nav > li").hover(function () {
        var el = $(this).find(".level0-wrapper");
        el.hide();
        el.css("left", "0");
        el.stop(true, true).delay(150).fadeIn(300, "easeOutCubic");
    }, function () {
        $(this).find(".level0-wrapper").stop(true, true).delay(300).fadeOut(300, "easeInCubic");
    });
    var scrolled = false;

    jQuery("#nav li.level0.drop-menu").mouseover(function () {
        if (jQuery(window).width() >= 740) {
            jQuery(this).children('ul.level1').fadeIn(100);
        }
        return false;
    }).mouseleave(function () {
        if (jQuery(window).width() >= 740) {
            jQuery(this).children('ul.level1').fadeOut(100);
        }
        return false;
    });
    jQuery("#nav li.level0.drop-menu li").mouseover(function () {
        if (jQuery(window).width() >= 740) {
            jQuery(this).children('ul').css({ top: 0, left: "165px" });
            var offset = jQuery(this).offset();
            if (offset && (jQuery(window).width() < offset.left + 325)) {
                jQuery(this).children('ul').removeClass("right-sub");
                jQuery(this).children('ul').addClass("left-sub");
                jQuery(this).children('ul').css({ top: 0, left: "-167px" });
            } else {
                jQuery(this).children('ul').removeClass("left-sub");
                jQuery(this).children('ul').addClass("right-sub");
            }
            jQuery(this).children('ul').fadeIn(100);
        }
    }).mouseleave(function () {
        if (jQuery(window).width() >= 740) {
            jQuery(this).children('ul').fadeOut(100);
        }
    });
    jQuery("#new-collection-slider .slider-items").owlCarousel({
        items: 5, //10 items above 1000px browser width
        itemsDesktop: [1024, 5], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("#best-seller-slider .slider-items").owlCarousel({
        items: 4, //10 items above 1000px browser width
        itemsDesktop: [1024, 4], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("#featured-product-slider .slider-items").owlCarousel({
        items: 4, //10 items above 1000px browser width
        itemsDesktop: [1024, 4], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });

    jQuery("#featured-slider .slider-items").owlCarousel({
        items: 4, //10 items above 1000px browser width
        itemsDesktop: [1024, 4], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("#recommend-slider .slider-items").owlCarousel({
        items: 6, //10 items above 1000px browser width
        itemsDesktop: [1024, 4], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("#brand-logo-slider .slider-items").owlCarousel({
        autoplay: true,
        items: 4, //10 items above 1000px browser width
        itemsDesktop: [1024, 4], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("#category-desc-slider .slider-items").owlCarousel({
        autoplay: true,
        items: 1, //10 items above 1000px browser width
        itemsDesktop: [1024, 1], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 1], // 3 items betweem 900px and 601px
        itemsTablet: [600, 1], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("#more-views-slider .slider-items").owlCarousel({
        autoplay: true,
        items: 5, //10 items above 1000px browser width
        itemsDesktop: [1024, 4], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("#related-products-slider .slider-items").owlCarousel({
        items: 4, //10 items above 1000px browser width
        itemsDesktop: [1024, 4], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("#upsell-products-slider .slider-items").owlCarousel({
        items: 4, //10 items above 1000px browser width
        itemsDesktop: [1024, 4], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("#more-views-slider .slider-items").owlCarousel({
        autoplay: true,
        items: 3, //10 items above 1000px browser width
        itemsDesktop: [1024, 4], //5 items between 1024px and 901px
        itemsDesktopSmall: [900, 3], // 3 items betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0;
        itemsMobile: [320, 1],
        navigation: true,
        navigationText: ["<a class=\"flex-prev\"></a>", "<a class=\"flex-next\"></a>"],
        slideSpeed: 500,
        pagination: false
    });
    jQuery("ul.accordion li.parent, ul.accordion li.parents, ul#magicat li.open").each(function () {
        jQuery(this).append('<em class="open-close">&nbsp;</em>');
    });
    jQuery('ul.accordion, ul#magicat').accordionNew();
    jQuery("ul.accordion li.active, ul#magicat li.active").each(function () {
        jQuery(this).children().next("div").css('display', 'block');
    });


});


function slideEffectAjax() {
    var ww = $(window).width();
    if (ww > 960) {
        $('.top-cart-contain').mouseenter(function () {
            $(this).find(".top-cart-content").stop(true, true).slideDown();
        });

        $('.top-cart-contain').mouseleave(function () {
            $(this).find(".top-cart-content").stop(true, true).slideUp();
        });
    } else {
        $('.top-cart-contain').click(function () {
            $(this).find(".top-cart-content").toggle(300);
        });
    }
}


$(document).ready(function () {
    slideEffectAjax();
});

/*Double click go to link menu*/
var wDW = $(window).width();
if (wDW < 1199) {
    $('#left-menu li:has(ul)').doubleTapToGo();
    $('#nav li:has(ul)').doubleTapToGo();
}


/* Mega Menu */

var isTouchDevice = ('ontouchstart' in window) || (navigator.msMaxTouchPoints > 0);
jQuery(window).on("load", function () {
    if (isTouchDevice) {
        jQuery('#nav a.level-top').click(function (e) {
            $t = jQuery(this);
            $parent = $t.parent();
            if ($parent.hasClass('parent')) {
                if (!$t.hasClass('menu-ready')) {
                    jQuery('#nav a.level-top').removeClass('menu-ready');
                    $t.addClass('menu-ready');
                    return false;
                }
                else {
                    $t.removeClass('menu-ready');
                }
            }
        });
    }
    //on load
    jQuery().UItoTop();
});

$(window).scroll(function () {
    if ($(this).scrollTop() > 1) {
        $('nav').addClass("sticky");
    }
    else {
        $('nav').removeClass("sticky");
    }
});

/* UItoTop */

(function ($) {
    jQuery.fn.UItoTop = function (options) {
        var defaults = {
            text: '',
            min: 200,
            inDelay: 600,
            outDelay: 400,
            containerID: 'toTop',
            containerHoverID: 'toTopHover',
            scrollSpeed: 1200,
            easingType: 'linear'
        };

        var settings = $.extend(defaults, options);
        var containerIDhash = '#' + settings.containerID;
        var containerHoverIDHash = '#' + settings.containerHoverID;
        jQuery('body').append('<a href="#" id="' + settings.containerID + '">' + settings.text + '</a>');
        jQuery(containerIDhash).hide().click(function () {
            jQuery('html, body').animate({ scrollTop: 0 }, settings.scrollSpeed, settings.easingType);
            jQuery('#' + settings.containerHoverID, this).stop().animate({ 'opacity': 0 }, settings.inDelay, settings.easingType);
            return false;
        })
			.prepend('<span id="' + settings.containerHoverID + '"></span>')
			.hover(function () {
			    jQuery(containerHoverIDHash, this).stop().animate({
			        'opacity': 1
			    }, 600, 'linear');
			}, function () {
			    jQuery(containerHoverIDHash, this).stop().animate({
			        'opacity': 0
			    }, 700, 'linear');
			});

        jQuery(window).scroll(function () {
            var sd = $(window).scrollTop();
            if (typeof document.body.style.maxHeight === "undefined") {
                jQuery(containerIDhash).css({
                    'position': 'absolute',
                    'top': $(window).scrollTop() + $(window).height() - 50
                });
            }
            if (sd > settings.min)
                jQuery(containerIDhash).fadeIn(settings.inDelay);
            else
                jQuery(containerIDhash).fadeOut(settings.Outdelay);
        });

    };
})(jQuery);


jQuery.extend(jQuery.easing,
			  {
			      easeInCubic: function (x, t, b, c, d) {
			          return c * (t /= d) * t * t + b;
			      },
			      easeOutCubic: function (x, t, b, c, d) {
			          return c * ((t = t / d - 1) * t * t + 1) + b;
			      },
			  });

(function (jQuery) {
    jQuery.fn.extend({
        accordion: function () {
            return this.each(function () {

                function activate(el, effect) {
                    jQuery(el).siblings(panelSelector)[(effect || activationEffect)](((effect == "show") ? activationEffectSpeed : false), function () {
                        jQuery(el).parents().show();
                    });
                }
            });
        }
    });
})
(jQuery);

jQuery(function ($) {
    $('.accordion').accordion();
    $('.accordion').each(function (index) {
        var activeItems = $(this).find('li.active');
        activeItems.each(function (i) {
            $(this).children('ul').css('display', 'block');
            if (i == activeItems.length - 1) {
                $(this).addClass("current");
            }
        });
    });

});

/*  Responsive Menu  */

(function ($) {
    $.fn.extend({
        accordion: function (options) {
            var defaults = {
                accordion: 'true',
                speed: 300,
                closedSign: '[+]',
                openedSign: '[-]'
            };
            var opts = $.extend(defaults, options);
            var $this = $(this);
            $this.find("li").each(function () {
                if ($(this).find("ul").size() != 0) {
                    $(this).find("a:first").after("<em>" + opts.closedSign + "</em>");
                    if ($(this).find("a:first").attr('href') == "#") {
                        $(this).find("a:first").click(function () { return false; });
                    }
                }
            });
            $this.find("li em").click(function () {
                if ($(this).parent().find("ul").size() != 0) {
                    if (opts.accordion) {
                        //Do nothing when the list is open
                        if (!$(this).parent().find("ul").is(':visible')) {
                            parents = $(this).parent().parents("ul");
                            visible = $this.find("ul:visible");
                            visible.each(function (visibleIndex) {
                                var close = true;
                                parents.each(function (parentIndex) {
                                    if (parents[parentIndex] == visible[visibleIndex]) {
                                        close = false;
                                        return false;
                                    }
                                });
                                if (close) {
                                    if ($(this).parent().find("ul") != visible[visibleIndex]) {
                                        $(visible[visibleIndex]).slideUp(opts.speed, function () {
                                            $(this).parent("li").find("em:first").html(opts.closedSign);
                                        });
                                    }
                                }
                            });
                        }
                    }
                    if ($(this).parent().find("ul:first").is(":visible")) {
                        $(this).parent().find("ul:first").slideUp(opts.speed, function () {
                            $(this).parent("li").find("em:first").delay(opts.speed).html(opts.closedSign);
                        });
                    } else {
                        $(this).parent().find("ul:first").slideDown(opts.speed, function () {
                            $(this).parent("li").find("em:first").delay(opts.speed).html(opts.openedSign);
                        });
                    }
                }
            });
        }
    });
})(jQuery);

/* Sidebar Dropdown */

(function (jQuery) {
    jQuery.fn.extend({
        accordionNew: function () {
            return this.each(function () {
                var jQueryul = jQuery(this),
					elementDataKey = 'accordiated',
					activeClassName = 'active',
					activationEffect = 'slideToggle',
					panelSelector = 'ul, div',
					activationEffectSpeed = 'fast',
					itemSelector = 'li';
                if (jQueryul.data(elementDataKey))
                    return false;
                jQuery.each(jQueryul.find('ul, li>div'), function () {
                    jQuery(this).data(elementDataKey, true);
                    jQuery(this).hide();
                });
                jQuery.each(jQueryul.find('em.open-close'), function () {
                    jQuery(this).click(function (e) {
                        activate(this, activationEffect);
                        return void (0);
                    });
                    jQuery(this).bind('activate-node', function () {
                        jQueryul.find(panelSelector).not(jQuery(this).parents()).not(jQuery(this).siblings()).slideUp(activationEffectSpeed);
                        activate(this, 'slideDown');
                    });
                });
                var active = (location.hash) ? jQueryul.find('a[href=' + location.hash + ']')[0] : jQueryul.find('li.current a')[0];
                if (active) {
                    activate(active, false);
                }
                function activate(el, effect) {
                    jQuery(el).parent(itemSelector).siblings().removeClass(activeClassName).children(panelSelector).slideUp(activationEffectSpeed);
                    jQuery(el).siblings(panelSelector)[(effect || activationEffect)](((effect == "show") ? activationEffectSpeed : false), function () {
                        if (jQuery(el).siblings(panelSelector).is(':visible')) {
                            jQuery(el).parents(itemSelector).not(jQueryul.parents()).addClass(activeClassName);
                        } else {
                            jQuery(el).parent(itemSelector).removeClass(activeClassName);
                        }
                        if (effect == 'show') {
                            jQuery(el).parents(itemSelector).not(jQueryul.parents()).addClass(activeClassName);
                        }
                        jQuery(el).parents().show();
                    });
                }
            });
        }
    });
})(jQuery);



/* top search */

$('.search_text').click(function () {
    $(this).next().slideToggle(200);
    $('.list_search').show();
})


$('.list_search .search_item').on('click', function (e) {
    $('.list_search').hide();

    var optionSelected = $(this);

    /*
  var id = optionSelected.attr('data-coll-id');
  var handle = optionSelected.attr('data-coll-handle');
  var coll_name = optionSelected.attr('data-coll-name');
  */

    var title = optionSelected.text();
    //var filter = '(collectionid:product' + (id == 0 ? '>=0' : ('=' + id)) + ')';


    //console.log(coll_name);
    $('.search_text').text(title);

    /*
  $('.ultimate-search .collection_id').val(filter);
  $('.ultimate-search .collection_handle').val(handle);
  $('.ultimate-search .collection_name').val(coll_name);
  */

    $(".search-text").focus();
    optionSelected.addClass('active').siblings().removeClass('active');
    //console.log($('.kd_search_text').innerWidth());


    //$('.list_search').slideToggle(0);

    /*
  sessionStorage.setItem('last_search', JSON.stringify({
    title: title,
    handle: handle,
    filter: filter,
    name: coll_name
  }));
  */
});


$('.header_search form button').click(function (e) {
    e.preventDefault();
    searchCollection();
    setSearchStorage('.header_search form');
});

$('#mb_search').click(function () {
    $('.mb_header_search').slideToggle('fast');
});

$('.fi-title.drop-down').click(function () {
    $(this).toggleClass('opentab');
});



function searchCollection(e) {
    var collectionId = $('.list_search .search_item.active').attr('data-coll-id');
    var searchVal = $('.header_search input[type="search"]').val();
    console.log(searchVal);


    var url = '';
    if (collectionId == 0) {
        url = '/search?q=' + searchVal;
    }
    else {
        url = '/search?q=' + searchVal;
        /*
		if(searchVal != '') {
		  url = '/search?type=product&q=' + searchVal + '&filter=(collectionid:product=' + collectionId + ')';
		}
		else {
		  url = '/search?type=product&q=filter=(collectionid:product=' + collectionId + ')';
		}
    */
    }
    window.location = url;
}


/*** Search Storage ****/


function setSearchStorage(form_id) {
    var seach_input = $(form_id).find('.search-text').val();
    var search_collection = $(form_id).find('.list_search .search_item.active').attr('data-coll-id');
    sessionStorage.setItem('search_input', seach_input);
    sessionStorage.setItem('search_collection', search_collection);
}
function getSearchStorage(form_id) {
    var search_input_st = ''; // sessionStorage.getItem('search_input');
    var search_collection_st = ''; // sessionStorage.getItem('search_collection');
    if (sessionStorage.search_input != '') {
        search_input_st = sessionStorage.search_input;
    }
    if (sessionStorage.search_collection != '') {
        search_collection_st = sessionStorage.search_collection;
    }
    $(form_id).find('.search-text').val(search_input_st);
    $(form_id).find('.search_item[data-coll-id="' + search_collection_st + '"]').addClass('active').siblings().removeClass('active');
    var search_key = $(form_id).find('.search_item[data-coll-id="' + search_collection_st + '"]').text();
    if (search_key != '') {
        $(form_id).find('.collection-selector .search_text').text(search_key);
    }
    //$(form_id).find('.search_collection option[value="'+search_collection_st+'"]').prop('selected', true);
}
function resetSearchStorage() {
    sessionStorage.removeItem('search_input');
    sessionStorage.removeItem('search_collection');
}
$(window).load(function () {
    getSearchStorage('.header_search form');
    resetSearchStorage();
});

$(document).ready(function () {
    $('.spverticalmenu').click(function () {
        $(this).next('div').slideToggle();
    });
});