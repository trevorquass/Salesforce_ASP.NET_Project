

function GetLat(address) {
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': address }, function (results, status) {
        return results[0].geometry.location.lat();
    }); 
}