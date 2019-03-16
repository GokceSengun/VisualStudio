
var map_1;
var map_2;
var circle_1;
var circle_2;
var marker_1;
var marker_2;
var currentlatlng = new google.maps.LatLng(41.093003253733286, 29.003301409881715);
var infowindow;
var radius;
var geocoder;
function loadMap_1() {

    //setLatLongValue();

    var mapOptions = {
        zoom: 10,
        center: currentlatlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP

    };

    setMarker_1();


    map_1 = new google.maps.Map(document.getElementById('map_1'), mapOptions);

    google.maps.event.addDomListener(map_1, 'click', function (e) {

        currentlatlng = e.latLng;

        if (currentlatlng) {

            map_1.panTo(currentlatlng);
            //setLatLongValue();
            setMarker_1();
        }
    });

}
function loadMap_2() {

    //setLatLongValue();

    var mapOptions = {
        zoom: 10,
        center: currentlatlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP

    };

    setMarker_2();

    map_2 = new google.maps.Map(document.getElementById('map_2'), mapOptions);

    google.maps.event.addDomListener(map_2, 'click', function (e) {

        currentlatlng = e.latLng;

        if (currentlatlng) {

            map_2.panTo(currentlatlng);
            //setLatLongValue();
            setMarker_2();
        }
    });

}
function setMarker_1() {

    if (marker_1 != undefined)
        marker_1.setMap(null);
    marker_1 = new google.maps.Marker({
        position: currentlatlng,
        draggable: true,
        map: map_1
    });

    if (marker_1) {
        google.maps.event.addDomListener(marker_1, "dragend", function () {
            currentlatlng = marker_1.getPosition();
            setLatLongValue();
            drawCircle_1();
        });
        drawCircle_1();
    }
  

    if (infowindow) {
        infowindow.close();
    }

    google.maps.event.addListener(marker_1, "click", function () {

        var data = '<div>Current LatLong:</div><div>' + currentlatlng + '</div>';

        infowindow = new google.maps.InfoWindow({
            content: data,
            position: currentlatlng
        });

        infowindow.open(map_1);
    });
}

function setMarker_2() {

    if (marker_2 != undefined)
        marker_2.setMap(null);

        marker_2 = new google.maps.Marker({
        position: currentlatlng,
        draggable: true,
        map: map_2
    });

    if (marker_2) {
        google.maps.event.addDomListener(marker_2, "dragend", function () {
            currentlatlng = marker_2.getPosition();
            setLatLongValue();
            drawCircle_2();
        });
        drawCircle_2();
    }

    if (infowindow) {
        infowindow.close();
    }

    google.maps.event.addListener(marker_2, "click", function () {

        var data = '<div>Current LatLong:</div><div>' + currentlatlng + '</div>';

        infowindow = new google.maps.InfoWindow({
            content: data,
            position: currentlatlng
        });

        infowindow.open(map_2);
    });
}
function drawCircle_1() {

    if (circle_1 != undefined)
        circle_1.setMap(null);

    if (parseInt(jQuery('#silider_1').val() == 0)) {
        radius = 500;
    } else
        radius = parseInt(jQuery('#silider_1').val() * 100 * 100 * 5) + 500;

    document.getElementById('txt_range_1').innerHTML = radius + " m";


    var options = {
        strokeColor: '#800000',
        strokeOpacity: 1.0,
        strokeWeight: 1,
        fillColor: '#C64D45',
        fillOpacity: 0.5,
        map: map_1,
        center: currentlatlng,
        radius: radius
    };

    circle_1 = new google.maps.Circle(options);
    SetLocation(currentlatlng,radius);
}

function drawCircle_2() {

    if (circle_2 != undefined)
        circle_2.setMap(null);

    if (parseInt(jQuery('#silider_2').val() == 0)) {
        radius = 500;
    } else
        radius = parseInt(jQuery('#silider_2').val() * 100 * 100 * 5) + 500;

    document.getElementById('txt_range_2').innerHTML = radius + " m";


    var options = {
        strokeColor: '#800000',
        strokeOpacity: 1.0,
        strokeWeight: 1,
        fillColor: '#C64D45',
        fillOpacity: 0.5,
        map: map_2,
        center: currentlatlng,
        radius: radius
    };

    circle_2 = new google.maps.Circle(options);
}

function setLatLongValue() {

    jQuery('#txtPointA1').val(currentlatlng.lat());
    jQuery('#txtPointA2').val(currentlatlng.lng());

}

function getLatLongValue() {

    if (jQuery('#txtPointA1').val() != '' && !isNaN(jQuery('#txtPointA1').val()) && parseInt(jQuery('#txtPointA1').val()) > 0) {
        if (jQuery('#txtPointA2').val() != '' && !isNaN(jQuery('#txtPointA2').val()) && parseInt(jQuery('#txtPointA2').val()) > 0) {
            currentlatlng = new google.maps.LatLng(jQuery('#txtPointA1').val(), jQuery('#txtPointA2').val());
            map.panTo(currentlatlng);
            setMarker();
        }
    }
}

function codeAddress() {
    debugger;
    geocoder = new google.maps.Geocoder();
    var address = document.getElementById('txtAddress').value;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            currentlatlng = results[0].geometry.location;
            setMarker();
        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}




