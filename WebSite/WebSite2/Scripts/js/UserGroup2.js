function AddNewTitle() {

    var Title = $("#userGroupTitle").val();
    if (Title == "") {
        return;
    }

    $.ajax({
        type: 'POST',
        data: "{'Title':'" + Title + "'}",
        url: 'CreateUserGroup2.aspx/CreateUserGroupTitle',
        contentType: 'application/json; charset:utf-8',
        dataType: 'json',
        success: function (result) {

            var jsonResult = jQuery.parseJSON(result.d);
            var Code = jsonResult.Code;
            var Message = jsonResult.Message;

            if (Code == "0") {
                alert("Title has been saved.");
                document.getElementById("btnTitleSave").disabled = true;
                $("#RadioGroup").toggle("show");
                //$("#popup").dialog();
                //$('#myModal').modal('show');
                $("#subdiv").toggle("show");
                $("#btnTitleSave").toggle("hide");
                google.maps.event.trigger(map, "resize");
            }
            else {
                alert(Message);
            }


        },

        error: function () {
            //Error

        }, complete: function () {
            //Completed
        }
    });
}

function GetTagList() {
    debugger;
    $("#tagplatformdiv").show("slow");
    $("#usagediv").hide("slow");
    $.ajax({
        type: 'POST',
        url: 'CreateUserGroup2.aspx/GetTagList',
        contentType: 'application/json; charset:utf-8',
        dataType: 'json',
        success: function (result) {
            var jsonResult = jQuery.parseJSON(result.d);
            var Code = jsonResult.Code;
            var Message = jsonResult.Message;

            if (Code == "0") {
                var html = "";

                $.each(jsonResult.allTags, function (jsonKey, jsonValue) {
                    html += "<option value=\"" + jsonValue.TagId + "\">" + jsonValue.TagName + "</option>";
                });
                $("#TagSelector").html(html);
                //$('#btnGroupAdd').attr("onClick", "AddUserGroupTag(); return false;");
            }
            else {
                alert(Message);
            }

        },

        error: function () {
            //Error

        }, complete: function () {
            try {
                $("#tagList").selectmenu('refresh');
            }
            catch (e) {

            }
        }
    });
}

function GetPlatformList() {
    debugger;
    $("#tagplatformdiv").show("slow");
    $("#usagediv").hide("slow");
    $.ajax({
        type: 'POST',
        url: 'CreateUserGroup2.aspx/GetPlatformList',
        contentType: 'application/json; charset:utf-8',
        dataType: 'json',
        success: function (result) {
            var jsonResult = jQuery.parseJSON(result.d);
            var Code = jsonResult.Code;
            var Message = jsonResult.Message;

            if (Code == "0") {
                var html = "";

                $.each(jsonResult.allPlatforms, function (jsonKey, jsonValue) {

                    html += "<option value=\"" + jsonValue.PId + "\">" + jsonValue.PlatformName + "</option>";
                });
                $("#PlatformSelector").html(html);
                //$('#btnGroupAdd').attr("onClick", "AddUserGroupPlatform(); return false;");
            }
            else {
                alert(Message);
            }


        },

        error: function () {
            //Error

        }, complete: function () {
            try {
                $("#tagList").selectmenu('refresh');
            }
            catch (e) {

            }
        }
    });

}

function GetCities() {
    debugger;
    $("#tagplatformdiv").show("slow");
    $("#usagediv").hide("slow");
    $.ajax({
        type: 'POST',
        url: 'CreateUserGroup2.aspx/GetCities',
        contentType: 'application/json; charset:utf-8',
        dataType: 'json',
        success: function (result) {
            var jsonResult = jQuery.parseJSON(result.d);
            var Code = jsonResult.Code;
            var Message = jsonResult.Message;

            if (Code == "0") {
                var html = "";

                $.each(jsonResult.Cities, function (jsonKey, jsonValue) {

                    html += "<option value=\"" + jsonValue.CityId + "\">" + jsonValue.Name + "</option>";
                });
                $("#city_select").html(html);
                //$('#btnGroupAdd').attr("onClick", "AddUserGroupPlatform(); return false;");
            }
            else {
                alert(Message);
            }


        },

        error: function () {
            //Error

        }, complete: function () {
            try {
                $("#tagList").selectmenu('refresh');
            }
            catch (e) {

            }
        }
    });

}

function GetTımeIntervals() {
    debugger;
    $("#tagplatformdiv").show("slow");
    $("#usagediv").hide("slow");
    $.ajax({
        type: 'POST',
        url: 'CreateUserGroup2.aspx/GetTimeIntervals',
        contentType: 'application/json; charset:utf-8',
        dataType: 'json',
        success: function (result) {
            var jsonResult = jQuery.parseJSON(result.d);
            var Code = jsonResult.Code;
            var Message = jsonResult.Message;

            if (Code == "0") {
                var html = "";

                $.each(jsonResult.TimeList, function (jsonKey, jsonValue) {

                    html += "<option value=\"" + jsonValue.TimeIntervalId + "\">" + jsonValue.Name + "</option>";
                });
                $("#Loc_timeList").html(html);
                //$('#btnGroupAdd').attr("onClick", "AddUserGroupPlatform(); return false;");
            }
            else {
                alert(Message);
            }


        },

        error: function () {
            //Error

        }, complete: function () {
            try {
                $("#tagList").selectmenu('refresh');
            }
            catch (e) {

            }
        }
    });

}

function IncludeOpenAppOnChange() {
    var isChecked = $("#IncludeOpenApp").is(':checked');

    $("#Select1").prop('disabled', !isChecked);
    $("#Select2").prop('disabled', !isChecked);
    $("#txt_openAppValue").prop('disabled', !isChecked);

}

function IncludeTotalTimeOnChange() {
    var isChecked = $("#includeTotalTime").is(':checked');

    $("#Select3").prop('disabled', !isChecked);
    $("#Select4").prop('disabled', !isChecked);
    $("#txt_totalTimeValue").prop('disabled', !isChecked);

}

function IncludeAvarageTimeOnChange() {
    var isChecked = $("#includeAvarageTime").is(':checked');

    $("#Select5").prop('disabled', !isChecked);
    $("#Select6").prop('disabled', !isChecked);
    $("#txt_avarageTimeValue").prop('disabled', !isChecked);

}

function IncludeınstallAppOnChange() {
    var isChecked = $("#includeInstallApp").is(':checked');

    $("#Select7").prop('disabled', !isChecked);
    $("#Select8").prop('disabled', !isChecked);
    $("#txt_installAppValue").prop('disabled', !isChecked);

}

function SaveAllOfProporties() {
    debugger;
    var obj = new Object();
    obj.includeOpenApp = $("#IncludeOpenApp").is(':checked');
    obj.openAppTime = $("#Select1").val();
    obj.openAppRate = $("#Select2").val();
    obj.openAppValue = $("#txt_openAppValue").val();

    obj.includeTotalTime = $("#includeTotalTime").is(':checked');
    obj.totalTimeTime = $("#Select3").val();
    obj.totalTimeRate = $("#Select4").val();
    obj.totalTimeValue = $("#txt_totalTimeValue").val();

    obj.includeAvarageTime = $("#includeAvarageTime").is(':checked');
    obj.avarageTimeTime = $("#Select5").val();
    obj.avarageTimeRate = $("#Select6").val();
    obj.avarageTimeValue = $("#txt_avarageTimeValue").val();

    obj.includeInstallApp = $("#includeInstallApp").is(':checked');
    obj.installAppTime = $("#Select7").val();
    obj.installAppRate = $("#Select8").val();
    obj.installAppValue = $("#txt_installAppValue").val();


    obj.tagList = $("#TagSelector").val();
    obj.platformId = $("#PlatformSelector").val();

    //string isCityLocation, string cityId, string longitude, string latitude, string range
    obj.isCityLocation = !($("#isCity").is(':checked'));
    obj.cityId = $("#city_select").val();
    obj.longitude = currentlatlng.A;
    obj.latitude = currentlatlng.k;
    obj.range = radius;
    obj.timeInterval = $("#Loc_timeList").val();

    obj.isLocGroup = document.getElementById("locPush").checked;

    var objJson = JSON.stringify(obj);

    $.ajax({
        type: 'POST',
        data: objJson,
        url: 'CreateUserGroup2.aspx/AddUserGroupUsage',
        contentType: 'application/json; charset:utf-8',
        dataType: 'json',
        success: function (result) {
            debugger;
            var jsonResult = jQuery.parseJSON(result.d);
            var Code = jsonResult.Code;
            var Message = jsonResult.Message;
            var html = "";
            if (Code == "0") {
                alert("Saved");
                window.location = "UserGroups.aspx";
            }
            else {
                alert(Message);
            }


        },

        error: function () {
            debugger;

        }, complete: function () {
            //complete
        }
    });

}

function CityOnChange() {
    var isChecked = $("#isCity").is(':checked');
    
    if (!isChecked) {
        $("#mapDiv").hide("slow");
        $("#cityDiv").show("slow");
    } else {
        $("#mapDiv").show("slow");
        $("#cityDiv").hide("slow");
        google.maps.event.trigger(map, "resize");
    }
}

function LocSwitchOnChange() {

    if (document.getElementById("locPush").checked) {
        $("#locDiv").show("slow");
    }
    else {
        $("#locDiv").hide("slow");
    }
}

