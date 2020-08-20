var tickets;
var dataTable;
document.getElementById("searchIdButton").click();




/* --------------------------------------------CUSTOM SEARCH BAŞLANGIÇ----------------------------------------------  */
var customConditions = {
    condition: "custom",
    conditionValues: [],
    date: { startDate: "", endDate: "" },
    range: {min:"",max:""}
};//Custom Search Conditions'ın ön tanımlı hali.


var ticketsDataSource;
var customChildCompanyDiv, customChildStatusDiv, customChildTypeDiv
    , customChildPriorityDiv, customChildDepartmentDiv, customChildOwnerDiv, customChildSubjectDiv, customChildDemirbasDiv
    , customChildSeriNoDiv, customChildUrunDiv;




function checkBoxControl(checkbox) {

    var customSearchWrapperDiv = document.getElementById("customSearchWrapperDiv");


    if (checkbox.checked == true) {
        var checkboxID = checkbox.getAttribute("id");
        switch (checkboxID) {
            case "customSearchCompany":
                var customSearchCompanyDiv = document.getElementById("customSearchCompanyDiv");

                if (customChildCompanyDiv != undefined) {
                    customChildCompanyDiv.style.display = "block";
                    customChildCompanyDiv = customSearchWrapperDiv.appendChild(customChildCompanyDiv);
                }
                else {
                    customSearchCompanyDiv.style.display = "block";
                    customChildCompanyDiv = customSearchWrapperDiv.appendChild(customSearchCompanyDiv);
                }
                break;

            case "customSearchStatus":
                var customSearchStatusDiv = document.getElementById("customSearchStatusDiv");

                if (customChildStatusDiv != undefined) {
                    customChildStatusDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customChildStatusDiv);
                }
                else {
                    customSearchStatusDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customSearchStatusDiv);
                }
                break;

            case "customSearchType":
                var customSearchTypeDiv = document.getElementById("customSearchTypeDiv");

                if (customChildTypeDiv != undefined) {
                    customChildTypeDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customChildTypeDiv);
                }
                else {
                    customSearchTypeDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customSearchTypeDiv);
                }
                break;

            case "customSearchPriority":
                var customSearchPriorityDiv = document.getElementById("customSearchPriorityDiv");

                if (customChildPriorityDiv != undefined) {
                    customChildPriorityDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customChildPriorityDiv);
                }
                else {
                    customSearchPriorityDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customSearchPriorityDiv);
                }
                break;
            case "customSearchDepartment":
                var customSearchDepartmentDiv = document.getElementById("customSearchDepartmentDiv");

                if (customChildDepartmentDiv != undefined) {
                    customChildDepartmentDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customChildDepartmentDiv);
                }
                else {
                    customSearchDepartmentDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customSearchDepartmentDiv);
                }
                break;
            case "customSearchOwner":
                var customSearchOwnerDiv = document.getElementById("customSearchOwnerDiv");

                if (customChildOwnerDiv != undefined) {
                    customChildOwnerDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customChildOwnerDiv);
                }
                else {
                    customSearchOwnerDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customSearchOwnerDiv);
                }
                break;
            case "customSearchSubject":
                var customSearchSubjectDiv = document.getElementById("customSearchSubjectDiv");

                if (customChildSubjectDiv != undefined) {
                    customChildSubjectDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customChildSubjectDiv);
                }
                else {
                    customSearchSubjectDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customSearchSubjectDiv);
                }
                break;
            case "customSearchDemirbas":
                var customSearchDemirbasDiv = document.getElementById("customSearchDemirbasDiv");

                if (customChildDemirbasDiv != undefined) {
                    customChildDemirbasDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customChildDemirbasDiv);
                }
                else {
                    customSearchDemirbasDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customSearchDemirbasDiv);
                }
                break;
            case "customSearchSeriNo":
                var customSearchSeriNoDiv = document.getElementById("customSearchSeriNoDiv");

                if (customChildSeriNoDiv != undefined) {
                    customChildSeriNoDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customChildSeriNoDiv);
                }
                else {
                    customSearchSeriNoDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customSearchSeriNoDiv);
                }
                break;
            case "customSearchUrun":
                var customSearchUrunDiv = document.getElementById("customSearchUrunDiv");

                if (customChildUrunDiv != undefined) {
                    customChildUrunDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customChildUrunDiv);
                }
                else {
                    customSearchUrunDiv.style.display = "block";
                    customSearchWrapperDiv.appendChild(customSearchUrunDiv);
                }
                break;
            default:
                break;
        }

    }
    else {
        var checkboxID = checkbox.getAttribute("id");
        switch (checkboxID) {
            case "customSearchCompany":
                var customSearchCompanyDiv = document.getElementById("customSearchCompanyDiv");
                if (customChildCompanyDiv != undefined) {
                    customChildCompanyDiv.style.display = "none";
                    customSearchWrapperDiv.removeChild(customChildCompanyDiv);
                }
                else {
                    customSearchCompanyDiv.style.display = "none";
                    customChildCompanyDiv = customSearchWrapperDiv.removeChild(customSearchCompanyDiv);
                }
                break;

            case "customSearchStatus":
                var customSearchStatusDiv = document.getElementById("customSearchStatusDiv");
                if (customChildStatusDiv != undefined) {
                    customChildStatusDiv.style.display = "none";
                    customChildStatusDiv = customSearchWrapperDiv.removeChild(customChildStatusDiv);
                }
                else {
                    customSearchStatusDiv.style.display = "none";
                    customChildStatusDiv = customSearchWrapperDiv.removeChild(customSearchStatusDiv);
                }
                break;
            case "customSearchType":
                var customSearchTypeDiv = document.getElementById("customSearchTypeDiv");
                if (customChildTypeDiv != undefined) {
                    customChildTypeDiv.style.display = "none";
                    customChildTypeDiv = customSearchWrapperDiv.removeChild(customChildTypeDiv);
                }
                else {
                    customSearchTypeDiv.style.display = "none";
                    customChildTypeDiv = customSearchWrapperDiv.removeChild(customSearchTypeDiv);
                }
                break;
            case "customSearchPriority":
                var customSearchPriorityDiv = document.getElementById("customSearchPriorityDiv");
                if (customChildPriorityDiv != undefined) {
                    customChildPriorityDiv.style.display = "none";
                    customChildPriorityDiv = customSearchWrapperDiv.removeChild(customChildPriorityDiv);
                }
                else {
                    customSearchPriorityDiv.style.display = "none";
                    customChildPriorityDiv = customSearchWrapperDiv.removeChild(customSearchPriorityDiv);
                }
                break;
            case "customSearchDepartment":
                var customSearchDepartmentDiv = document.getElementById("customSearchDepartmentDiv");
                if (customChildDepartmentDiv != undefined) {
                    customChildDepartmentDiv.style.display = "none";
                    customChildDepartmentDiv = customSearchWrapperDiv.removeChild(customChildDepartmentDiv);
                }
                else {
                    customSearchDepartmentDiv.style.display = "none";
                    customChildDepartmentDiv = customSearchWrapperDiv.removeChild(customSearchDepartmentDiv);
                }
                break;
            case "customSearchOwner":
                var customSearchOwnerDiv = document.getElementById("customSearchOwnerDiv");
                if (customChildOwnerDiv != undefined) {
                    customChildOwnerDiv.style.display = "none";
                    customChildOwnerDiv = customSearchWrapperDiv.removeChild(customChildOwnerDiv);
                }
                else {
                    customSearchOwnerDiv.style.display = "none";
                    customChildOwnerDiv = customSearchWrapperDiv.removeChild(customSearchOwnerDiv);
                }
                break;
            case "customSearchSubject":
                var customSearchSubjectDiv = document.getElementById("customSearchSubjectDiv");
                if (customChildSubjectDiv != undefined) {
                    customChildSubjectDiv.style.display = "none";
                    customChildSubjectDiv = customSearchWrapperDiv.removeChild(customChildSubjectDiv);
                }
                else {
                    customSearchSubjectDiv.style.display = "none";
                    customChildSubjectDiv = customSearchWrapperDiv.removeChild(customSearchSubjectDiv);
                }
                break;
            case "customSearchDemirbas":
                var customSearchDemirbasDiv = document.getElementById("customSearchDemirbasDiv");
                if (customChildDemirbasDiv != undefined) {
                    customChildDemirbasDiv.style.display = "none";
                    customChildDemirbasDiv = customSearchWrapperDiv.removeChild(customChildDemirbasDiv);
                }
                else {
                    customSearchDemirbasDiv.style.display = "none";
                    customChildDemirbasDiv = customSearchWrapperDiv.removeChild(customSearchDemirbasDiv);
                }
                break;
            case "customSearchSeriNo":
                var customSearchSeriNoDiv = document.getElementById("customSearchSeriNoDiv");
                if (customChildSeriNoDiv != undefined) {
                    customChildSeriNoDiv.style.display = "none";
                    customChildSeriNoDiv = customSearchWrapperDiv.removeChild(customChildSeriNoDiv);
                }
                else {
                    customSearchSeriNoDiv.style.display = "none";
                    customChildSeriNoDiv = customSearchWrapperDiv.removeChild(customSearchSeriNoDiv);
                }
                break;
            case "customSearchUrun":
                var customSearchUrunDiv = document.getElementById("customSearchUrunDiv");
                if (customChildUrunDiv != undefined) {
                    customChildUrunDiv.style.display = "none";
                    customChildUrunDiv = customSearchWrapperDiv.removeChild(customChildUrunDiv);
                }
                else {
                    customSearchUrunDiv.style.display = "none";
                    customChildUrunDiv = customSearchWrapperDiv.removeChild(customSearchUrunDiv);
                }
                break;

            default:
                break;
        }

    }
}

function customSelectionOfCompany() {

    var listDOM;
    var companyDOM;
    var listItemDOM;
    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;


    var customCondition = {
        conditionName: "",
        searchIdValue: "",
        searchText: "",

    };

    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    list = document.getElementById("customSelectedCompanyList");
    company = document.getElementById("customSelectionCompany");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "customCompanyDivider" + company.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", "Company" + company.options[company.selectedIndex].value);
    buttonTagDOM.setAttribute("onclick", "customDeselectOfCompany('Company" + company.options[company.selectedIndex].value + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + company.options[company.selectedIndex].text));
    spanTagDOM.setAttribute("id", company.selectedIndex);



    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    var customCondition = {
        conditionName: "",
        searchIdValue: "",
        searchText: "",

    };


    customCondition.searchIdValue = company.options[company.selectedIndex].value;
    customCondition.conditionName = "company";

    // console.log(company.options[company.selectedIndex].value);

    //Opsiyonu pasifleştirme...
    company.options[company.selectedIndex].disabled = true;
    addCustomSearchCondition(customCondition);


}
function customDeselectOfCompany(id, dividerId) {

    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var span = listItem.firstChild;
    var company = document.getElementById("customSelectionCompany");
    var list = document.getElementById("customSelectedCompanyList");
    var ulParent = button.parentNode.parentNode;

    var idOfButton = button.getAttribute("id");
    var conditionName = idOfButton.substring(0, 7).toLowerCase(); //Company{idnumber}'den Company i alıyorum conditionValuestan silerken kullanıcam. 
    var actualValueOfSelection = idOfButton.substring(7);

    customDeleteSearchCondition(conditionName, actualValueOfSelection);
    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    company.options[span.getAttribute("id")].disabled = false;
    company.options[0].selected = true;

}

function customSelectionOfStatus() {

    var listDOM;
    var companyDOM;
    var listItemDOM;
    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;

    var customCondition = {
        conditionName: "",
        searchIdValue: "",
        searchText: "",

    };

    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("customSelectedStatusList");
    var status = document.getElementById("customSelectionStatus");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "customStatusDivider" + status.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", "Status" + status.options[status.selectedIndex].value);
    buttonTagDOM.setAttribute("onclick", "customDeselectOfStatus('Status" + status.options[status.selectedIndex].value + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + status.options[status.selectedIndex].text));
    spanTagDOM.setAttribute("id", status.selectedIndex);



    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);


    customCondition.searchIdValue = status.options[status.selectedIndex].value;
    customCondition.conditionName = "status";

    // console.log(company.options[company.selectedIndex].value);

    //Opsiyonu pasifleştirme...
    status.options[status.selectedIndex].disabled = true;
    addCustomSearchCondition(customCondition);


}
function customDeselectOfStatus(id, dividerId) {

    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var span = listItem.firstChild;
    var status = document.getElementById("customSelectionStatus");
    var list = document.getElementById("customSelectedStatusList");
    var ulParent = button.parentNode.parentNode;

    var idOfButton = button.getAttribute("id");
    var conditionName = idOfButton.substring(0, 6).toLowerCase(); //Status{idnumber}'den Company i alıyorum conditionValuestan silerken kullanıcam. 
    var actualValueOfSelection = idOfButton.substring(6);

    customDeleteSearchCondition(conditionName, actualValueOfSelection);


    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    status.options[span.getAttribute("id")].disabled = false;//Status3 gibi gelen id yi sadece sondaki index numarasını almak için substring yapıyorum -- Gülmeyin mecburdum buna :( --)
    status.options[0].selected = true;

}

function customSelectionOfType() {

    var listDOM;
    var companyDOM;
    var listItemDOM;
    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;


    var customCondition = {
        conditionName: "",
        searchIdValue: "",
        searchText: "",

    };


    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("customSelectedTypeList");
    var type = document.getElementById("customSelectionType");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "customTypeDivider" + type.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", "Type" + type.options[type.selectedIndex].value);
    buttonTagDOM.setAttribute("onclick", "customDeselectOfType('Type" + type.options[type.selectedIndex].value + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + type.options[type.selectedIndex].text));
    spanTagDOM.setAttribute("id", type.selectedIndex);



    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    

    customCondition.searchIdValue = type.options[type.selectedIndex].value;
    customCondition.conditionName = "type";

    // console.log(company.options[company.selectedIndex].value);

    //Opsiyonu pasifleştirme...
    type.options[type.selectedIndex].disabled = true;
    addCustomSearchCondition(customCondition);


}
function customDeselectOfType(id, dividerId) {

    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var span = listItem.firstChild;
    var type = document.getElementById("customSelectionType");
    var list = document.getElementById("customSelectedTypeList");
    var ulParent = button.parentNode.parentNode;

    var idOfButton = button.getAttribute("id");
    var conditionName = idOfButton.substring(0, 4).toLowerCase(); //Type{idnumber}'den Company i alıyorum conditionValuestan silerken kullanıcam. 
    var actualValueOfSelection = idOfButton.substring(4);

    customDeleteSearchCondition(conditionName, actualValueOfSelection);

    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    type.options[span.getAttribute("id")].disabled = false; //Type3 gibi gelen id yi sadece sondaki index numarasını almak için substring yapıyorum -- Gülmeyin mecburdum buna :( --)
    type.options[0].selected = true;

}

function customSelectionOfPriority() {

    var listDOM;
    var companyDOM;
    var listItemDOM;
    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;



    var customCondition = {
        conditionName: "",
        searchIdValue: "",
        searchText: "",

    };



    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("customSelectedPriorityList");
    var priority = document.getElementById("customSelectionPriority");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "customPriorityDivider" + priority.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", "Priority" + priority.options[priority.selectedIndex].value);
    buttonTagDOM.setAttribute("onclick", "customDeselectOfPriority('Priority" + priority.options[priority.selectedIndex].value + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + priority.options[priority.selectedIndex].text));
    spanTagDOM.setAttribute("id", priority.selectedIndex);



    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    

    customCondition.searchIdValue = priority.options[priority.selectedIndex].value;
    customCondition.conditionName = "priority";

    // console.log(company.options[company.selectedIndex].value);

    //Opsiyonu pasifleştirme...
    priority.options[priority.selectedIndex].disabled = true;
    addCustomSearchCondition(customCondition);


}
function customDeselectOfPriority(id, dividerId) {

    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var span = listItem.firstChild;
    var priority = document.getElementById("customSelectionPriority");
    var list = document.getElementById("customSelectedPriorityList");
    var ulParent = button.parentNode.parentNode;


    var idOfButton = button.getAttribute("id");
    var conditionName = idOfButton.substring(0, 8).toLowerCase(); //Priority{idnumber}'den Company i alıyorum conditionValuestan silerken kullanıcam. 
    var actualValueOfSelection = idOfButton.substring(8);

    customDeleteSearchCondition(conditionName, actualValueOfSelection);


    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    priority.options[span.getAttribute("id")].disabled = false;//Priority3 gibi gelen id yi sadece sondaki index numarasını almak için substring yapıyorum -- Gülmeyin mecburdum buna :( --)
    priority.options[0].selected = true;

}

function customSelectionOfDepartment() {

    var listDOM;
    var companyDOM;
    var listItemDOM;
    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;


    var customCondition = {
        conditionName: "",
        searchIdValue: "",
        searchText: "",

    };

    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("customSelectedDepartmentList");
    var department = document.getElementById("customSelectionDepartment");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "customDepartmentDivider" + department.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", "Department" + department.options[department.selectedIndex].value);
    buttonTagDOM.setAttribute("onclick", "customDeselectOfDepartment('Department" + department.options[department.selectedIndex].value + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + department.options[department.selectedIndex].text));
    spanTagDOM.setAttribute("id", department.selectedIndex);



    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    customCondition.searchIdValue = department.options[department.selectedIndex].value;
    customCondition.conditionName = "department";

    // console.log(company.options[company.selectedIndex].value);

    //Opsiyonu pasifleştirme...
    department.options[department.selectedIndex].disabled = true;
    addCustomSearchCondition(customCondition);


}
function customDeselectOfDepartment(id, dividerId) {

    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var span = listItem.firstChild;
    var department = document.getElementById("customSelectionDepartment");
    var list = document.getElementById("customSelectedDepartmentList");
    var ulParent = button.parentNode.parentNode;


    var idOfButton = button.getAttribute("id");
    var conditionName = idOfButton.substring(0, 10).toLowerCase(); //Department{idnumber}'den Company i alıyorum conditionValuestan silerken kullanıcam. 
    var actualValueOfSelection = idOfButton.substring(10);

    customDeleteSearchCondition(conditionName, actualValueOfSelection);

    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    department.options[span.getAttribute("id")].disabled = false;//Department3 gibi gelen id yi sadece sondaki index numarasını almak için substring yapıyorum -- Gülmeyin mecburdum buna :( --)
    department.options[0].selected = true;

}

function customSelectionOfOwner() {

    var listDOM;
    var companyDOM;
    var listItemDOM;
    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;



    var customCondition = {
        conditionName: "",
        searchIdValue: "",
        searchText: "",

    };



    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("customSelectedOwnerList");
    var owner = document.getElementById("customSelectionOwner");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "customOwnerDivider" + owner.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", "Owner" + owner.options[owner.selectedIndex].value);
    buttonTagDOM.setAttribute("onclick", "customDeselectOfOwner('Owner" + owner.options[owner.selectedIndex].value + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + owner.options[owner.selectedIndex].text));
    spanTagDOM.setAttribute("id", owner.selectedIndex);



    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    
    customCondition.searchIdValue = owner.options[owner.selectedIndex].value;
    customCondition.conditionName = "owner";

    // console.log(company.options[company.selectedIndex].value);

    //Opsiyonu pasifleştirme...
    owner.options[owner.selectedIndex].disabled = true;
    addCustomSearchCondition(customCondition);


}
function customDeselectOfOwner(id, dividerId) {

    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var span = listItem.firstChild;
    var owner = document.getElementById("customSelectionOwner");
    var list = document.getElementById("customSelectedOwnerList");
    var ulParent = button.parentNode.parentNode;

    var idOfButton = button.getAttribute("id");
    var conditionName = idOfButton.substring(0, 5).toLowerCase(); //Owner{idnumber}'den Company i alıyorum conditionValuestan silerken kullanıcam. 
    var actualValueOfSelection = idOfButton.substring(5);

    customDeleteSearchCondition(conditionName, actualValueOfSelection);
    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    owner.options[span.getAttribute("id")].disabled = false;//Owner3 gibi gelen id yi sadece sondaki index numarasını almak için substring yapıyorum -- Gülmeyin mecburdum buna :( --)
    owner.options[0].selected = true;

}
function customDepartmentSelectionOfOwner() {
    var selectionDepartmentOfOwner = document.getElementById("customSelectionDepartmentOfOwner");
    var selectionOwner = document.getElementById("customSelectionOwner");


    var idOfDepartment = selectionDepartmentOfOwner.options[selectionDepartmentOfOwner.selectedIndex].value;//Deparmenttaki value ile
    //owner select optionlardaki class nameleri karşılaştırıp eşleşenleri block eşleşmeyenleri none display yapıyorum.



    var allChildrensOfOwnerList = selectionOwner.children;

    var classesInOrderToDisplayBlock = document.getElementsByClassName(idOfDepartment);

    //Önce Tüm Ownerlar görünmez olur
    for (var i = 0; i < allChildrensOfOwnerList.length; i++) {

        if (idOfDepartment.localeCompare("all") == 0) {
            allChildrensOfOwnerList[i].style.display = "block";
        }
        else {
            allChildrensOfOwnerList[i].style.display = "none";
        }


    }

    //Sonra ilgili departmana ait ownerlar görünür olur.
    for (var i = 0; i < classesInOrderToDisplayBlock.length; i++) {

        classesInOrderToDisplayBlock[i].style.display = "block";

    }


}


//Input fieldların eklenme özelliği farklı.
function customSelectionOfInput(inputField) {

    var customCondition = {
        conditionName: "",
        searchIdValue: "",
        searchText: "",

    };

    switch (inputField.getAttribute("id")) {

        case "searchBySubjectInput":
            for (var i = 0; i < customConditions.conditionValues.length; i++) {
                if (customConditions.conditionValues[i].conditionName.localeCompare("subject") == 0) {
                    customConditions.conditionValues[i].searchValue = inputField.value;
                    console.log(inputField.value);
                }    
            }
            break;
        case "searchByDemirbasInput":
            for (var i = 0; i < customConditions.conditionValues.length; i++) {
                if (customConditions.conditionValues[i].conditionName.localeCompare("demirbas") == 0) {
                    customConditions.conditionValues[i].searchValue = inputField.value;
                    console.log(inputField.value);
                }
            }
            break;
        case "searchBySeriNoInput":
            for (var i = 0; i < customConditions.conditionValues.length; i++) {
                if (customConditions.conditionValues[i].conditionName.localeCompare("serino") == 0) {
                    customConditions.conditionValues[i].searchValue = inputField.value;
                    console.log(inputField.value);
                }
            }
            break;
        case "searchByUrunInput":
            for (var i = 0; i < customConditions.conditionValues.length; i++) {
                if (customConditions.conditionValues[i].conditionName.localeCompare("urun") == 0) {
                    customConditions.conditionValues[i].searchValue = inputField.value;
                    console.log(inputField.value);
                }
            }
            break;

        default:
            break;
    }

}


function addCustomSearchCondition(customCondition) {

    customConditions.conditionValues.push(customCondition); //Condition'ın listeye eklenmesi.
    console.log(customConditions);

}
function customDeleteSearchCondition(conditionName, actualValueOfSelection) {


    for (var i = 0; i < customConditions.conditionValues.length; i++) {
        //console.log(customConditions.conditionValues[i].conditionName);
        if (customConditions.conditionValues[i].conditionName.localeCompare(conditionName) == 0 && (customConditions.conditionValues[i].searchIdValue.localeCompare(actualValueOfSelection) == 0 || customConditions.conditionValues[i].searchText.localeCompare(actualValueOfSelection) == 0)) {
            console.log("Silinen Condition :" + customConditions.conditionValues[i].conditionName + " " + customConditions.conditionValues[i].searchIdValue);
            customConditions.conditionValues.splice(i, 1);
        }
    }
    for (var i = 0; i < customConditions.conditionValues.length; i++) {
        console.log("Elemanlar :" + customConditions.conditionValues[i].conditionName + " " + customConditions.conditionValues[i].searchIdValue);

    }
    console.log("//////////////***************/////////////////////////*******************/////////////////*****************");
}

function customSendSearchConditions(){

    console.log(JSON.stringify(customConditions));

    if (customConditions.length < 1) {
        alert("Hiçbir koşul seçilmedi");
        return;
    }

    $.ajax({
        url: "/getCustomSearchResult"
        , method: 'POST'
        , contentType: 'application/json'
        , dataType: 'json'
        , data: JSON.stringify(customConditions)
        , success: function (result) {

            dataTable.clear().draw();
            dataTable.rows.add(result).draw();


            for (var i = 0; i < result.length; i++) {

                console.log("Bilet IDLERİ : " + result[i].biletBasligi);
            }

        }
        , error: function (requestObject, error, errorThrown) {
            console.log(requestObject.status);
        }
    });


}

























/* --------------------------------------------CUSTOM SEARCH SONU----------------------------------------------  */
/* --------------------------------------------CUSTOM SEARCH HARİCİ BAŞLANGIÇ----------------------------------------------  */
/* --------------------------------------------CUSTOM SEARCH SONU----------------------------------------------  */
/* --------------------------------------------CUSTOM SEARCH HARİCİ BAŞLANGIÇ----------------------------------------------  */
/* --------------------------------------------CUSTOM SEARCH SONU----------------------------------------------  */
/* --------------------------------------------CUSTOM SEARCH HARİCİ BAŞLANGIÇ----------------------------------------------  */
/* --------------------------------------------CUSTOM SEARCH SONU----------------------------------------------  */
/* --------------------------------------------CUSTOM SEARCH HARİCİ BAŞLANGIÇ----------------------------------------------  */
/* --------------------------------------------CUSTOM SEARCH SONU----------------------------------------------  */
/* --------------------------------------------CUSTOM SEARCH HARİCİ BAŞLANGIÇ----------------------------------------------  */

var conditions = [];

function changeSearchCondition(page, element, header) {

    var i, j, page, element, allContents, allButtons, header, headerElement;

    var button = document.getElementById(element);

    headerElement = document.getElementById("searchHeader");
    headerElement.innerHTML = "Search Ticket By : " + header

    allContents = document.getElementsByClassName("searchConditionDiv");
    allButtons = document.getElementsByClassName("searchConditionButtons");


    for (var i = 0; i < allContents.length; i++) {
        allContents[i].style.display = "none";
    }
    for (var j = 0; j < allButtons.length; j++) {
        allButtons[j].classList.remove('searchConditionLinkActive');

    }


    document.getElementById(page).style.display = "block";
    button.classList.add('searchConditionLinkActive');


}

function selectionOfCompany() {

    var listDOM;
    var companyDOM;
    var listItemDOM;
    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;

    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    list = document.getElementById("selectedCompanyList");
    company = document.getElementById("selectionCompany");
    var searchByCompanyStartDate = document.getElementById("searchByCompanyStartDate");
    var searchByCompanyEndDate = document.getElementById("searchByCompanyEndDate");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "divider" + company.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", company.selectedIndex);
    buttonTagDOM.setAttribute("onclick", "deselectOfCompany('" + company.selectedIndex + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + company.options[company.selectedIndex].text));
    spanTagDOM.setAttribute("id", company.selectedIndex);



    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    var tempObj = {};
    var conditionValues = [];
    tempObj.startDate = searchByCompanyStartDate.value;
    tempObj.endDate = searchByCompanyEndDate.value;
    tempObj.searchValue = company.options[company.selectedIndex].value;
    conditionValues.push(tempObj);

    // console.log(company.options[company.selectedIndex].value);

    //Opsiyonu pasifleştirme...
    company.options[company.selectedIndex].disabled = true;
    addSearchCondition("company", "" + company.selectedIndex, conditionValues);


}
function deselectOfCompany(id, dividerId) {

    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var company = document.getElementById("selectionCompany");
    var list = document.getElementById("selectedCompanyList");
    var ulParent = button.parentNode.parentNode;

    deleteSearchCondition(button);
    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    company.options[id].disabled = false;
    company.options[0].selected = true;

}

function selectionOfStatus() {



    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;

    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("selectedStatusList");
    var status = document.getElementById("selectionStatus");
    var searchByStatusStartDate = document.getElementById("searchByStatusStartDate");
    var searchByStatusEndDate = document.getElementById("searchByStatusEndDate");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "divider" + status.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);


    spanTagDOM.appendChild(document.createTextNode("" + status.options[status.selectedIndex].text));

    spanTagDOM.setAttribute("id", status.options[status.selectedIndex].value);


    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", status.selectedIndex);
    buttonTagDOM.setAttribute("onclick", "deselectOfStatus('" + status.selectedIndex + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");


    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));



    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    var tempObj = {};
    var conditionValues = [];
    tempObj.startDate = searchByStatusStartDate.value;
    tempObj.endDate = searchByStatusEndDate.value;
    tempObj.searchValue = status.options[status.selectedIndex].value;
    conditionValues.push(tempObj);

    //Opsiyonu pasifleştirme...
    status.options[status.selectedIndex].disabled = true;
    addSearchCondition("status", "" + status.selectedIndex, conditionValues);


}
function deselectOfStatus(id, dividerId) {
    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);



    var listItem = button.parentNode;
    var status = document.getElementById("selectionStatus");
    var ulParent = button.parentNode.parentNode;




    deleteSearchCondition(button);
    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    status.options[id].disabled = false;
    status.options[0].selected = true;
}

function selectionOfDepartment() {



    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;

    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("selectedDepartmentList");
    var department = document.getElementById("selectionDepartment");
    var searchByDepartmentStartDate = document.getElementById("searchByDepartmentStartDate");
    var searchByDepartmentEndDate = document.getElementById("searchByDepartmentEndDate");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "divider" + department.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", department.selectedIndex);
    buttonTagDOM.setAttribute("onclick", "deselectOfDepartment('" + department.selectedIndex + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + department.options[department.selectedIndex].text));
    spanTagDOM.setAttribute("id", department.options[department.selectedIndex].value);

    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    var tempObj = {};
    var conditionValues = [];
    tempObj.startDate = searchByDepartmentStartDate.value;
    tempObj.endDate = searchByDepartmentEndDate.value;
    tempObj.searchValue = department.options[department.selectedIndex].value;
    conditionValues.push(tempObj);

    //Opsiyonu pasifleştirme...
    department.options[department.selectedIndex].disabled = true;
    addSearchCondition("department", "" + department.selectedIndex, conditionValues);


}
function deselectOfDepartment(id, dividerId) {
    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var department = document.getElementById("selectionDepartment");
    var ulParent = button.parentNode.parentNode;

    deleteSearchCondition(button);
    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    department.options[id].disabled = false;
    department.options[0].selected = true;
}

function selectionOfType() {



    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;

    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("selectedTypeList");
    var type = document.getElementById("selectionType");
    var searchByTypeStartDate = document.getElementById("searchByTypeStartDate");
    var searchByTypeEndDate = document.getElementById("searchByTypeEndDate");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "divider" + type.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", type.selectedIndex);
    buttonTagDOM.setAttribute("onclick", "deselectOfType('" + type.selectedIndex + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + type.options[type.selectedIndex].text));
    spanTagDOM.setAttribute("id", type.options[type.selectedIndex].value);
    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    var tempObj = {};
    var conditionValues = [];
    tempObj.startDate = searchByTypeStartDate.value;
    tempObj.endDate = searchByTypeEndDate.value;
    tempObj.searchValue = type.options[type.selectedIndex].value;
    conditionValues.push(tempObj);

    //Opsiyonu pasifleştirme...
    type.options[type.selectedIndex].disabled = true;
    addSearchCondition("type", "" + type.selectedIndex, conditionValues);


}
function deselectOfType(id, dividerId) {
    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var type = document.getElementById("selectionType");
    var ulParent = button.parentNode.parentNode;

    deleteSearchCondition(button);
    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    type.options[id].disabled = false;
    type.options[0].selected = true;
}

function selectionOfPriority() {



    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;

    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("selectedPriorityList");
    var priority = document.getElementById("selectionPriority");
    var searchByPriorityStartDate = document.getElementById("searchByPriorityStartDate");
    var searchByPriorityEndDate = document.getElementById("searchByPriorityEndDate");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "divider" + priority.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", priority.selectedIndex);
    buttonTagDOM.setAttribute("onclick", "deselectOfPriority('" + priority.selectedIndex + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + priority.options[priority.selectedIndex].text));
    spanTagDOM.setAttribute("id", priority.options[priority.selectedIndex].value);

    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);

    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    var tempObj = {};
    var conditionValues = [];
    tempObj.startDate = searchByPriorityStartDate.value;
    tempObj.endDate = searchByPriorityEndDate.value;
    tempObj.searchValue = priority.options[priority.selectedIndex].value;
    conditionValues.push(tempObj);

    //Opsiyonu pasifleştirme...
    priority.options[priority.selectedIndex].disabled = true;
    addSearchCondition("priority", "" + priority.selectedIndex, conditionValues);


}
function deselectOfPriority(id, dividerId) {

    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var priority = document.getElementById("selectionPriority");
    var ulParent = button.parentNode.parentNode;

    deleteSearchCondition(button);
    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    priority.options[id].disabled = false;
    priority.options[0].selected = true;

}

function selectionOfOwner() {

    var spanTagDOM;
    var buttonTagDOM;
    var iconTagDOM;
    var listItemDOM;
    var listDividerDOM;

    //Seçilen Şirketlerin Seçileceği Liste ve Seçilen Şirket
    var list = document.getElementById("selectedOwnerList");
    var owner = document.getElementById("selectionOwner");
    var searchByOwnerStartDate = document.getElementById("searchByOwnerStartDate");
    var searchByOwnerEndDate = document.getElementById("searchByOwnerEndDate");

    listItemDOM = document.createElement("LI");
    spanTagDOM = document.createElement("SPAN");
    buttonTagDOM = document.createElement("BUTTON");

    iconTagDOM = document.createElement("i");
    iconTagDOM.classList.add("fas");
    iconTagDOM.classList.add("fa-trash-alt");
    iconTagDOM.classList.add("mr-2");

    var dividerIdText = "divider" + owner.selectedIndex;
    listDividerDOM = document.createElement("div");
    listDividerDOM.classList.add("dropdown-divider");
    listDividerDOM.setAttribute("id", dividerIdText);

    buttonTagDOM.classList.add("btn");
    buttonTagDOM.classList.add("btn-danger");
    buttonTagDOM.classList.add("float-right");
    buttonTagDOM.setAttribute("id", owner.selectedIndex);
    buttonTagDOM.setAttribute("onclick", "deselectOfOwner('" + owner.selectedIndex + "','" + dividerIdText + "')");
    buttonTagDOM.setAttribute("type", "button");



    //Elemanlar iç içe ekleniyor.
    buttonTagDOM.appendChild(iconTagDOM);
    buttonTagDOM.appendChild(document.createTextNode("Sil"));

    spanTagDOM.appendChild(document.createTextNode("" + owner.options[owner.selectedIndex].text));
    spanTagDOM.setAttribute("id", owner.options[owner.selectedIndex].value);

    listItemDOM.appendChild(spanTagDOM);
    listItemDOM.appendChild(buttonTagDOM);


    list.appendChild(listItemDOM);
    list.appendChild(listDividerDOM);

    var tempObj = {};
    var conditionValues = [];
    tempObj.startDate = searchByOwnerStartDate.value;
    tempObj.endDate = searchByOwnerEndDate.value;
    tempObj.searchValue = owner.options[owner.selectedIndex].value;
    conditionValues.push(tempObj);



    //Opsiyonu pasifleştirme...
    owner.options[owner.selectedIndex].disabled = true;
    addSearchCondition("owner", "" + owner.selectedIndex, conditionValues);

}
function deselectOfOwner(id, dividerId) {

    var button = document.getElementById(id);
    var divider = document.getElementById(dividerId);

    var listItem = button.parentNode;
    var owner = document.getElementById("selectionOwner");
    var ulParent = button.parentNode.parentNode;

    deleteSearchCondition(button);
    ulParent.removeChild(listItem);
    ulParent.removeChild(divider);
    owner.options[id].disabled = false;
    owner.options[0].selected = true;

}

function searchById() {

    var idSearchInput = document.getElementById("searchByIdInput");

    var tempObj = {};
    var conditionValues = [];
    tempObj.searchValue = idSearchInput.value;
    conditionValues.push(tempObj);
    addSearchCondition("id", "", conditionValues);
    sendSearchConditions();
}

function searchBySubject() {
    var subjectSearchInput = document.getElementById("searchBySubjectInput");
    var subjectSearchInputStartDate = document.getElementById("searchBySubjectStartDate");
    var subjectSearchInputEndDate = document.getElementById("searchBySubjectEndDate");

    var tempObj = {};
    var conditionValues = [];
    tempObj.startDate = subjectSearchInputStartDate.value;
    tempObj.endDate = subjectSearchInputStartDate.value;
    tempObj.searchValue = subjectSearchInput.value;
    conditionValues.push(tempObj);

    addSearchCondition("subject", "", conditionValues);
    sendSearchConditions();
}

function searchByDate() {
    var searchDateStartDateInput = document.getElementById("searchByDateStartDate");
    var searchDateEndDateInput = document.getElementById("searchByDateEndDate");

    var tempObj = {};
    var conditionValues = [];
    tempObj.startDate = searchDateStartDateInput.value;
    tempObj.endDate = searchDateStartDateInput.value;
    conditionValues.push(tempObj);
    addSearchCondition("date", "", conditionValues);
}


function addSearchCondition(cnd, indexVal, conditionValues) {

    var selectOption;
    var selectedList;

    var obj = {
        condition: cnd,
        selectIndex: indexVal,
        actualValue: conditionValues // {}
    };

    for (var i = 0; i < conditions.length; i++) {


        if (obj.condition.localeCompare(conditions[i].condition) != 0) {//gelen obj deki condition ile listemizdeki condition farklı olursa şartları sıfırlıyoruz
            alert("Şartlar Farklı");
            for (var j = 0; j < conditions.length; j++) {//Farklı bir condition durumu seçildiğinde diğer tüm selectlerdeki seçilmişleri aktifleştirme.
                switch (conditions[j].condition) {

                    case "status" || "id" || "subject" || "date"://Arama condition'ı id,subject olursa da diğer conditionlardaki listeleri temizle
                        // ilker array'e göre ilgili ul yş guncekkeyen fonk yaz
                        selectOption = document.getElementById("selectionStatus");
                        selectOption.options[conditions[j].selectIndex].disabled = false;
                        selectOption.options[0].selected = true;
                        selectedList = document.getElementById("selectedStatusList");
                        while (selectedList.firstChild) {
                            selectedList.removeChild(selectedList.firstChild);
                        }
                        break;
                    case "department" || "id" || "subject" || "date"://Arama condition'ı id,subject olursa da diğer conditionlardaki listeleri temizle
                        selectOption = document.getElementById("selectionDepartment");
                        selectOption.options[conditions[j].selectIndex].disabled = false;
                        selectOption.options[0].selected = true;
                        selectedList = document.getElementById("selectedDepartmentList");
                        while (selectedList.firstChild) {
                            selectedList.removeChild(selectedList.firstChild);
                        }
                        break;
                    case "type" || "id" || "subject" || "date"://Arama condition'ı id,subject olursa da diğer conditionlardaki listeleri temizle
                        selectOption = document.getElementById("selectionType");
                        selectOption.options[conditions[j].selectIndex].disabled = false;
                        selectOption.options[0].selected = true;
                        selectedList = document.getElementById("selectedTypeList");
                        while (selectedList.firstChild) {
                            selectedList.removeChild(selectedList.firstChild);
                        }
                        break;
                    case "priority" || "id" || "subject" || "date"://Arama condition'ı id,subject olursa da diğer conditionlardaki listeleri temizle
                        selectOption = document.getElementById("selectionPriority");
                        selectOption.options[conditions[j].selectIndex].disabled = false;
                        selectOption.options[0].selected = true;
                        selectedList = document.getElementById("selectedPriorityList");
                        while (selectedList.firstChild) {
                            selectedList.removeChild(selectedList.firstChild);
                        }
                        break;
                    case "company" || "id" || "subject" || "date"://Arama condition'ı id,subject olursa da diğer conditionlardaki listeleri temizle
                        selectOption = document.getElementById("selectionCompany");
                        selectOption.options[conditions[j].selectIndex].disabled = false;
                        selectOption.options[0].selected = true;
                        selectedList = document.getElementById("selectedCompanyList");
                        while (selectedList.firstChild) {
                            selectedList.removeChild(selectedList.firstChild);
                        }
                        break;
                    case "owner" || "id" || "subject" || "date"://Arama condition'ı id,subject olursa da diğer conditionlardaki listeleri temizle
                        selectOption = document.getElementById("selectionOwner");
                        selectOption.options[conditions[j].selectIndex].disabled = false;
                        selectOption.options[0].selected = true;
                        selectedList = document.getElementById("selectedOwnerList");
                        while (selectedList.firstChild) {
                            selectedList.removeChild(selectedList.firstChild);
                        }
                        break;


                    default:
                }
            }

            for (var i = 0; i <= conditions.length; i++) {
                conditions.pop();
            }
            conditions.pop();//En son eleman da çıkarılıyor.
        }
    }

    if (conditions.length > 0 && (conditions[0].condition == "id" || conditions[0].condition == "subject" || conditions[0].condition == "date")) {
        //id numara ile arama yapıldığında listeye eklenen id numarası ikinci bir arama yapıldığında kalıyor.Bunu önlemek adına bu kod parçası yazılmıştır.
        while (conditions.length > 0) {//Liste tamamen temizlenir.Tek bir id numarası ile arama yapmak adına.
            conditions.shift();
        }
    }

    conditions.push(obj); //Condition'ın listeye eklenmesi.
}

function deleteSearchCondition(button) {

    var spanCondition = button.parentNode.firstChild;
    var id = spanCondition.getAttribute("id");

    for (var i = 0; i < conditions.length; i++) {
        if (conditions[i].selectIndex.localeCompare(id) == 0) {
            conditions.splice(i, 1);//Listeden Conditionı siliyoruz.
            break;
        }
    }



}


function departmentSelectionOfOwner() {
    var selectionDepartmentOfOwner = document.getElementById("selectionDepartmentOfOwner");
    var selectionOwner = document.getElementById("selectionOwner");


    var idOfDepartment = selectionDepartmentOfOwner.options[selectionDepartmentOfOwner.selectedIndex].value;//Deparmenttaki value ile
    //owner select optionlardaki class nameleri karşılaştırıp eşleşenleri block eşleşmeyenleri none display yapıyorum.



    var allChildrensOfOwnerList = selectionOwner.children;

    var classesInOrderToDisplayBlock = document.getElementsByClassName(idOfDepartment);

    //Önce Tüm Ownerlar görünmez olur
    for (var i = 0; i < allChildrensOfOwnerList.length; i++) {

        if (idOfDepartment.localeCompare("all") == 0) {
            allChildrensOfOwnerList[i].style.display = "block";
        }
        else {
            allChildrensOfOwnerList[i].style.display = "none";
        }


    }

    //Sonra ilgili departmana ait ownerlar görünür olur.
    for (var i = 0; i < classesInOrderToDisplayBlock.length; i++) {

        classesInOrderToDisplayBlock[i].style.display = "block";

    }


}



function sendSearchConditions() {

    console.log(JSON.stringify(conditions));

    if (conditions.length < 1) {
        alert("Hiçbir koşul seçilmedi");
        return;
    }

    $.ajax({
        url: "/getsearchresult"
        , method: 'POST'
        , contentType: 'application/json'
        , dataType: 'json'
        , data: JSON.stringify(conditions)
        , success: function (result) {

            dataTable.clear().draw();
            dataTable.rows.add(result).draw();


            for (var i = 0; i < result.length; i++) {
                
                console.log("Bilet IDLERİ : "+result[i].biletBasligi);
            }

        }
        , error: function (requestObject, error, errorThrown) {
            console.log(requestObject.status);
        }
    });
}



$(document).ready(function () {


    dataTable = $('#table_id').DataTable({
        "language": {
            "emptyTable": "SONUÇ BULUNAMADI"
        },

        "responsive": true,
        "columns": [
            {
                "data": "id",
                "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                    $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.id + "</a>");
                }
            },
            {
                "data": "date",
                "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                    $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.date + "</a>");
                }
            },

            {
                "data": "subject",
                "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                    $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.subject + "</a>");
                }
            },
            {
                "data": "company",
                "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                    $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.company + "</a>");
                }
            },
            {
                "data": "priority",
                "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                    $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.priority + "</a>");
                }
            },
            {
                "data": "owner",
                "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                    $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.owner + "</a>");
                }
            },
            {
                "data": "due",
                "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                    $(nTd).html("<a style='text-decoration:none;font-size:14px;' href='showTicket/" + oData.id + "'>" + oData.due + "</a>");
                }
            }
        ],

        "rowCallback": function (row, data, index) {
            if (data[2] == "Dusuk") {
                $('td', row).css('background-color', 'Red');
            }
            else if (data[2] == "Dusuk") {
                $('td', row).css('background-color', 'Orange');
            }
        }
    });





});






