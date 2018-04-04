// Write your JavaScript code.
function updateTimezone()
{
    var temp = new Date().getTimezoneOffset()/60;
    var timezone = Intl.DateTimeFormat().resolvedOptions().timeZone
    document.getElementById('timezone').innerHTML = "Your timezone: " + timezone;
}