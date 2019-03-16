$(document).ready(function (e) {

    var currentlink = window.location.pathname.split('/')[3];
    if (currentlink == 'AddCompany') {
        $('a[href*="AddCompany' + '"]').parent('li').addClass('active');

        $('a[href*="AddCompany' + '"]').parent('li').siblings().removeClass('active');
    }
    else if (currentlink == 'CalculateRate') {
        
        $('a[href*="CalculateRate' + '"]').parent('li').addClass('active');

        $('a[href*="CalculateRate' + '"]').parent('li').siblings().removeClass('active');
    }
    else if (currentlink == 'CompanyList') {
        $('a[href*="CompanyList' + '"]').parent('li').addClass('active');

        $('a[href*="CompanyList' + '"]').parent('li').siblings().removeClass('active');
    }
    else if (currentlink == 'EditCompany') {
        $('a[href*="EditCompany' + '"]').parent('li').addClass('active');

        $('a[href*="EditCompany' + '"]').parent('li').siblings().removeClass('active');
    }
    else {
        $('#mainPageLink').parent('li').addClass('active');

        $('#mainPageLink').parent('li').siblings().removeClass('active');
    }

});