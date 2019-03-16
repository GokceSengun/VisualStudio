/**
 * Created by MahmutDuva on 21/04/14.
 */
$(document).ready(function(){
    $('.select_ios').click(function(){
        $('.select_ios').addClass('slc');
        $('.select_ios').siblings().removeClass('slc');
        $('.samsung_empty').css('display','none');
        $('.samsung').css('display','none');
        $('.iphone_empty').css('display','block');
        $('.iphone').css('display','block');
        $('.iphone_ct').css('display','block');
        $('.samsung_ct').css('display','none');
        $('.selectLogo').css('display','block');


    });
    $('.select_android').click(function(){
        $('.select_android').addClass('slc');
        $('.select_android').siblings().removeClass('slc');
        $('.samsung_empty').css('display','block');
        $('.samsung').css('display','block');
        $('.iphone_empty').css('display','none');
        $('.iphone').css('display','none');
        $('.iphone_ct').css('display','none');
        $('.samsung_ct').css('display','block');
        $('.selectLogo').css('display','none');


    });



    $('.colorPalet li input[type="checkbox"]').click('true',function(){
        if( $(this).attr("checked")=="checked" )
        {
            $(this).parent('li').siblings().children('input[type="checkbox"]').attr('checked', false);
            $.fn.iphoneUpdate();
        }
        else
        {
            $.fn.iphoneGetBack();
        }

    });
    $('.paging li').click(function(){
        $.fn.iphoneUpdate();
    });
    $.fn.iphoneUpdate = function(){
        var checkSelected = $('.colorPalet li input[type="checkbox"]:checked');
        var mainColor = $(checkSelected).next('.b').attr('color');
        var colorType = $(checkSelected).next('.b').attr('type');
        var oneColor = $(checkSelected).siblings('ul.color').children('li.k:nth-child(1)').attr('color');
        var twoColor = $(checkSelected).siblings('ul.color').children('li.k:nth-child(2)').attr('color');
        var threeColor = $(checkSelected).siblings('ul.color').children('li.k:nth-child(3)').attr('color');
        var fourColor = $(checkSelected).siblings('ul.color').children('li.k:nth-child(4)').attr('color');
        var fiveColor = $(checkSelected).siblings('ul.color').children('li.k:nth-child(5)').attr('color');
        var sixColor = $(checkSelected).siblings('ul.color').children('li.k:nth-child(6)').attr('color');

        $('.header, .header_d').css('background-color',mainColor);
        $('.cnt .main .exp').css('background-color',mainColor);
        $('.cnt .main_bt').css('background-color',oneColor);
        $('ul.list_product li h1').css('color',threeColor);
        $('ul.list_product li p').css('color',threeColor);
        $('ul.list_product li span').css('color',oneColor);
        $('.iphone_empty .sb').css('color',oneColor);

        $('.detail h1').css('color',oneColor);
        $('.detail p').css('color',fourColor);
        $('.detail span').css('color',oneColor);
        $('.detail button').css('background-color',oneColor);
        $('.detail button').css('border-color',oneColor);
        $('.detail button').css('color',twoColor);

        $('.category h1').css('color',oneColor);
        $('.category p').css('color',oneColor);
        $('.category .bottom p').css('color',threeColor);
        $('.category span').css('color',oneColor);
        if(colorType == 'k')
        {
            if ($('.samsung_empty .header img.logo').attr('src') == '')
                $('.samsung_empty .header img.logo,.samsung_empty .header_d img.logo').attr('src', 'Scripts/img/android_logo_white.png')

            $('.iphone_empty .header img.logo').attr('src', 'Scripts/img/logo_white.png');

            $('.header img.menu').attr('src', 'Scripts/img/menu_icon_white.png');
            $('.header .search').attr('src', 'Scripts/img/search_white_icon@2x.png');
            $('.header_d img.back').attr('src', 'Scripts/img/back_white.png');
            $('.header_d img.share').attr('src', 'Scripts/img/share_white.png');
            $('.header_d img.sort').attr('src', 'Scripts/img/sort_white.png');
            $('.header,.header_d').addClass('whiteStatusBar');
            $('.header,.header_d').removeClass('blackStatusBar');
            $('.header_d .left, .header_d .center, .header_d .right').css('color','#ffffff');

            $('.samsung_empty .header p.appname,.samsung_empty .header_d p.appname').css('color','#ffffff');

        }
        else
        {

            $('.samsung_empty .header img.logo,.samsung_empty .header_d img.logo').attr('src', 'Scripts/img/android_logo_black.png')

            $('.samsung_empty .header p.appname,.samsung_empty .header_d p.appname').css('color','#000000');
            $('.iphone_empty .header img.logo').attr('src', 'Scripts/img/logo_black.png')

            $('.header img.menu').attr('src', 'Scripts/img/menu_icon_black.png');
            $('.header .search').attr('src', 'Scripts/img/search_black_icon@2x.png');
            $('.header_d img.back').attr('src', 'Scripts/img/back_black.png');
            $('.header_d img.share').attr('src', 'Scripts/img/share_black.png');
            $('.header_d img.sort').attr('src', 'Scripts/img/sort_black.png');



            $('.header,.header_d').addClass('blackStatusBar');
            $('.header, .header_d').removeClass('whiteStatusBar');
            $('.header_d .left,.iphone_empty .header_d .center,.header_d .right').css('color','#000000');

        }


    };
    $.fn.iphoneGetBack = function(){
        $('.iphone_empty .sb').css('color','#333');
        $('.iphone_empty .header').css('background-color', '#ffffff');
        $('.iphone_empty .header_d').css('background-color', '#f0f0f0');

        $('.samsung_empty .header').css('background-color', '#ffffff');
        $('.samsung_empty .header_d').css('background-color', '#f0f0f0');

        $('.samsung_empty .detail h1,.samsung_empty .detail span,.samsung_empty .detail p').css('color', '#000');
        $('.iphone_empty .detail h1,.iphone_empty .detail span,.iphone_empty .detail p').css('color', '#000');
        $('.iphone_empty .detail button,.samsung_empty .detail button').css({
            'color': '#000',
            'border-radius': '5px',
            'border': '1px solid #000000',
            'background-color': '#f9f9f9'
        });
        $('.iphone_empty .bottom h1,.iphone_empty .bottom span,.samsung_empty .bottom h1,.samsung_empty .bottom span').css('color', '#000');

        $('.cnt .main .exp').css('background-color','#676767');
        $('.cnt .main_bt').css('background-color','#f0f0f0');
        $('ul.list_product li h1').css('color','#000');
        $('ul.list_product li p').css('color','#000');
        $('ul.list_product li span').css('color', '#000');

        $('.iphone_empty .header img.logo').attr('src', 'Scripts/img/logo_black.png')

        $('.header img.menu').attr('src', 'Scripts/img/menu_icon_black.png');
        $('.header .search').attr('src', 'Scripts/img/search_black_icon@2x.png');
        $('.header_d img.back').attr('src', 'Scripts/img/back_black.png');
        $('.header_d img.share').attr('src', 'Scripts/img/share_black.png');
        $('.header_d img.sort').attr('src', 'Scripts/img/sort_black.png');
        $('.samsung_empty .header p.appname,.samsung_empty .header_d p.appname').css('color', '#000000');
        $('.header_d .left,.iphone_empty .header_d .center,.header_d .right').css('color', '#000000');
        $('.header,.header_d').addClass('blackStatusBar');
        $('.header, .header_d').removeClass('whiteStatusBar');
        $('.header_d .left,.iphone_empty .header_d .center,.header_d .right').css('color', '#000000');

    };
    $.fn.iphoneUpdate();
});