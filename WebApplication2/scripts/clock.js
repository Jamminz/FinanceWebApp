
function init() {
    //creates an area to display the clock without refreshing the whole screen
    timeShow = document.createTextNode("");
    //gets the element by the id of 'clock'
    document.getElementById("clock").appendChild(timeShow);
}

function clockUpdate() {
    var time = new Date();

    var hours = time.getHours();
    var minutes = time.getMinutes();
    var seconds = time.getSeconds();

    //Add 0's to time if needed 
    minutes = (minutes < 10 ? "0" : "") + minutes;
    seconds = (seconds < 10 ? "0" : "") + seconds;

    // AM or PM
    var amOrPm = (hours < 12) ? "AM" : "PM";

    //24 hour to 12 hour
    hours = (hours > 12) ? hours - 12 : hours;

    //Make sure hours is never 00:00 for 12AM
    hours = (hours == 0) ? hours = 12 : hours;

    //string to display
    var timeString = hours + ":" + minutes + ":" + seconds + " " + amOrPm;

    // Update the time displayed
    document.getElementById("clock").firstChild.nodeValue = timeString;
}