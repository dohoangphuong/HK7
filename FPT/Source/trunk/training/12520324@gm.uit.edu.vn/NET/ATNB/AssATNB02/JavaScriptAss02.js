function myFunctionCheck(iID, iTitle, iFirst, iLast, iBirth, iAddress, iRegistration,
            iFines1, iFines2, iTotalfines, iLastlend) {
    var id = document.getElementById(iID).value;
    var title = document.getElementById(iTitle).value;
    var first = document.getElementById(iFirst).value;
    var last = document.getElementById(iLast).value;
    var birth = document.getElementById(iBirth).value;
    var address = document.getElementById(iAddress).value;
    var registration = document.getElementById(iRegistration).value;
    var fines1 = document.getElementById(iFines1).value;
    var fines2 = document.getElementById(iFines2).value;
    var totalfines = document.getElementById(iTotalfines).value;
    var lastlend = document.getElementById(iLastlend).value;

    var show = "BORROWER INFORMATION" + "<p>" +
                "Borrower ID: " + id + "<br>" +
                "Name: " + title + ". " + first + " " + last + "<br>" +
                "Date of Birth: " + birth + "<br>" +
                "Address: " + address + "<br>" +
                "Registration Date: " + registration + "<br>" +
                "Total Fines Due: " + totalfines + "<br>" +
                "Last Lend Date: " + lastlend;

    document.getElementById("show").innerHTML = show;
}