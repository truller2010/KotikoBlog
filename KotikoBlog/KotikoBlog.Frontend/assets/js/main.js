// Hello.
//
// This is The Scripts used for Antelope Minimal Blog Theme
//
//

function main() {

(function () {
   'use strict';

    // Smooth Scroll To Top
    //==========================================
    $(function() {
      $('.scroll').on("click",function(){
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
          var target = $(this.hash);
          target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
          if (target.length) {
            $('html,body').animate({
              scrollTop: target.offset().top - 100
            }, 1000);
            return false;
          }
        }
      });
    });

    // Header Slider Disable Auto Slide
    //==========================================
    /* Header Slider Layout #1 */
    $('#header-slider.carousel.layout-one').carousel({
        interval: 3000
    });
    /* Header Slider Layout #2 */
    $('#header-slider.carousel.layout-two').carousel({
        interval: false
    });
    
 	  // Slider Toggle
    //==========================================
    $('.thumb-block').on("click",function() {
        $('.thumb-block.active').removeClass('active');
        $(this).addClass('active');
    });

}());


}
main();