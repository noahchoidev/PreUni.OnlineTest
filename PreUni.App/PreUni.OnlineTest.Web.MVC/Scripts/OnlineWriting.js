
//Create WritingSearchFilterModel Object
function WritingSearchFilterModel() {

    this.TestTypeID = $('#selectTest').val();
    this.Year = $('#selectYear').val();
    this.Term = $('#selectTerm').val();
    this.TestNo = $('#selectTestNo').val();
    this.BranchCode = $('#selectBranch').val();
    this.ClassID = $('#selectClass').val();
    this.IsFinish = $('#selectCompleted').val();
    this.IsMarked = $('#selectMarked').val();
    this.IsGeneralTest = IsGeneralTest();
}

//Create BranchSelectionTriggerModel Object
function BranchSelectionTriggerModel() {

    selectTest = document.getElementById("selectTest");
    this.TestType = selectTest.options[selectTest.selectedIndex].text;

    this.Year = $('#selectYear').val();
    this.Term = $('#selectTerm').val();
}

//Create ClassModel Object
function ClassSelectionTriggerModel() {

    var selectTest = document.getElementById("selectTest");

    this.TestType = selectTest.options[selectTest.selectedIndex].text;
    this.Year = $('#selectYear').val();
    this.Term = $('#selectTerm').val();
    this.BranchCode = $('#selectBranch').val();
}

function ListenChangesFromSearchControlFrom(filteringModel) {

    // Try uploading info
    let url = "/Assessment/GetAllWritingOfStudent";
    $.ajax({
        url: url,
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify({ WritingSearchFilterModel: filteringModel }),
        success: function (data) {

            $('.Search-Content-List').html(data).trigger("create");
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }
    });
}

function SetWritingModelFilterCookie(CookieNaame,WritingSearchFilterModel) {

    let url = "/Assessment/SetWritingModelFilterCookie";
    $.ajax({
        url: url,
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify({ CookieNaame: CookieNaame, WritingSearchFilterModel: WritingSearchFilterModel }),
        success: function (data) {
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }
    });
}

// Register change event in SelectBox
$('.ChangeEventForSearch').on('change', function (e) {
    // Initialize the object filter
    var writingSearchFilterModel = new WritingSearchFilterModel();
    ListenChangesFromSearchControlFrom(writingSearchFilterModel);

    // Create a Writing Filtering Cookie to store
    SetWritingModelFilterCookie("WritingFilterCookie",writingSearchFilterModel);
}); //

// Register change event in SelectBox
$('.ReChangeEventForSearch').on('change', function (e) {
    // Initialize the object filter
    var writingSearchFilterModel = new WritingSearchFilterModel();
    ListenChangesFromSearchControlFrom(writingSearchFilterModel);

    // Create a Writing Filtering Cookie to store
    SetWritingModelFilterCookie("ReWritingFilterCookie", writingSearchFilterModel);
});

$('.BranchTriggerEvent').on('change', function (e) {
    SetBranchesSelectBox();
});

// This trigger event is to fire off whenever 'Branch' from selection chagnes
$('.ClassTriggerEvent').on('change', function (e) {
    SetClassSelectBox();

    // Create a model
    var writingSearchFilterModel = new WritingSearchFilterModel();
    // Create a Writing Filtering Cookie to store
    SetWritingModelFilterCookie("WritingFilterCookie", writingSearchFilterModel);
});

// This trigger event is to fire off whenever 'Branch' from selection chagnes
$('.ReClassTriggerEvent').on('change', function (e) {
    SetClassSelectBox();

    // Create a model
    var writingSearchFilterModel = new WritingSearchFilterModel();
    // Create a Writing Filtering Cookie to store
    SetWritingModelFilterCookie("ReWritingFilterCookie", writingSearchFilterModel);
});

$('.BranchClassEvent').on('change', function (e) {

    // Class should be dependant on the branch, 
    // thus a condition below is not going to be acceptable.
    if ($('#selectBranch').val() === ''
        && $('#selectClass').val() !== '') {

        $('#selectClass').val('');
        $('#selectClass').empty();
        $('#selectClass').append($("<option></option>").attr("value", "").text("--Branch All--"));
    }
});

function SetBranchSelection(BranchModelList) {

    $('#selectBranch').empty();
    $('#selectBranch').append($("<option></option>").attr("value", "").text("--Branch All--"));

    $.each(BranchModelList, function (index, item) {
        //Fill out the select boxes
        $('#selectBranch').append($("<option></option>").attr("value", item.BranchCode).text(item.BranchName));
    });
}

function SetBranchSelectionFromAjax(model) {

    let url = "/Assessment/GetBranchForSelectOptions";
    $.ajax({
        url: url,
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify({ triggerModel: model }),
        success: function (data) {

            if (data.length === 0)
                return;

            SetBranchSelection(data);
            InitializeBranchSelectionFromCookie();
            SetClassSelectBox();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var responseTitle = $(jqXHR.responseText).filter('title').get(0);
            alert($(responseTitle).text() + "\n" + formatErrorMessage(jqXHR, errorThrown));

            if (errorThrown === 'Unauthorized')
                window.location = "~/Account/Login";
        }
    });
}

function SetClassSelection(ClassModelList) {

    $('#selectClass').empty();
    $('#selectClass').append($("<option></option>").attr("value", "").text("--Class All--"));

    $.each(ClassModelList, function (index, item) {
        //Fill out the select boxes
        $('#selectClass').append($("<option></option>").attr("value", item.ClassID).text(item.ClassName));
    });
}

function SetClassSelectionFromAjax(model) {

    let url = "/Assessment/GetClassForSelectOptions/";
    $.ajax({
        url: url,
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify({ triggerModel: model }),
        success: function (data) {

            if (data.length === 0)
                return;

            SetClassSelection(data);
            InitializeSearchingClassFromCookie();

            var writingSearchFilterModel = new WritingSearchFilterModel();
            ListenChangesFromSearchControlFrom(writingSearchFilterModel);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var responseTitle = $(jqXHR.responseText).filter('title').get(0);
            alert($(responseTitle).text() + "\n" + formatErrorMessage(jqXHR, errorThrown));

            if (errorThrown === 'Unauthorized')
                window.location = '/Account/Login';
        }
    });
}

// Select=Branch is affected by Year,Term,TestType.
function SetBranchesSelectBox() {
    var triggerModel = new BranchSelectionTriggerModel();

    if (triggerModel.TestType === ""
        || triggerModel.Year === ""
        || triggerModel.Term === "")
        return;

    SetBranchSelectionFromAjax(triggerModel);
}

// * Select-Class is affected by TestType,Year,Term,Branch
//  -TODO: future successor should change
//  -by breaking down it a meaningful fragment like above Ajax functions.
function SetClassSelectBox() {

    var triggerModel = new ClassSelectionTriggerModel();

    if (triggerModel.Year === ""
        || triggerModel.Term === ""
        || triggerModel.TestType === ""
        || triggerModel.BranchCode === "")
        return;

    // Ajax Call
    SetClassSelectionFromAjax(triggerModel);
}

function InitializeTermTest(selectedTerm) {
    $('#selectTerm').val(selectedTerm);
}

function InitializeTestNo(selectedTeestNo) {
    // -1 means null
    if (selectedTeestNo === -1)
        $('#selectTestNo').val('');
    else
        $('#selectTestNo').val(selectedTeestNo);
}

function InitializeGeneralTestTab(IsGeneralTest) {

    if (IsGeneralTest === "True") {
        $('#General_Radio').parent().addClass('active');
        $('#General_Radio').prop('checked', 'checked');
    }
    else {
        $('#Retest_Radio').parent().addClass('active');
        $('#Retest_Radio').prop('checked', 'checked');
    }
}

function InitializeBranchSelectionFromCookie(cookieName) {

    // Get baranch-data from cookie data
    // ex>2,2020,2,-1,,-1,-1
    var branchcode = GetWritingSearchFilterValueFromIndexOf(cookieName,4);
    if (branchcode === -1)
        return;

    $('#selectBranch').val(branchcode);
}

function InitializeSearchingClassFromCookie(cookieName) {

    // Get baranch-data from cookie data
    // ex>2,2020,2,-1,,-1,-1
    var classID = GetWritingSearchFilterValueFromIndexOf(cookieName,5);

    if (classID === -1 || classID === '') {
        $('#selectClass').val('');
        return;
    }
    $('#selectClass').val(classID);
}

function IsGeneralTest() {

    var radios = document.getElementsByName('RetestAvailability');

    for (var i = 0, length = radios.length; i < length; i++) {

        if (radios[i].checked) {
            return radios[i].value;
        }
    }
    return "";
}

// ******************************** Cookie processing *******************************
function getCookie(cookieName) {

    var name = cookieName + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');

    for (var i = 0; i < ca.length; i++) {

        var c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function GetWritingSearchFilterValueFromIndexOf(cookieName,index) {

    var idx = parseInt(index);
    if (idx === '')
        return;

    var WritingFilterCookie = getCookie(cookieName); // "WritingFilterCookie"
    if (WritingFilterCookie === '')
        return -1;

    // ex> 2,2020,2,-1,,-1,-1
    var arr = WritingFilterCookie.split(',');
    for (var i = 0; i < arr.length; i++) {

        if (i === idx)
            return arr[i];
    }
    return -1;
}

function SetCookie() {

    var cookie = document.cookie;
    document.getElementById("ShowCookie").innerHTML = getCookie("NoahCookie");
}
// ./******************************** Cookie processing *******************************