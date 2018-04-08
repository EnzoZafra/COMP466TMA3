$(".item").first().addClass("active");

var paused = false;
var randflag = false;
var picindex = 0;
var interval;

function pauseplayListener() {
  paused = !paused;
  if (paused) {
    $('#slideshowcarousel').carousel('pause');
  } 
  else {
    $('#slideshowcarousel').carousel('cycle');
  }
}

function switchListener(isChecked) {
  if (isChecked) {
    $('.right').hide();
    $('.left').hide();   
    random();   
  } else {
    $('.right').show();   
    $('.left').show();   
    sequential();
  }
}

// https://stackoverflow.com/questions/20436561/bootstrap3-carousel-picking-random-next-slide
function random() {
    randflag = true; 
    // remove data-interval from carousel
    $('#slideshowcarousel').carousel('pause');
  
    picindex = Math.floor((Math.random() * $('.item').length));
    var rand = picindex;
    $('#slideshowcarousel').carousel(picindex);
    $('#slideshowcarousel').fadeIn(1000);
    interval = setInterval(function() { 
        if (!randflag) {
            clearInterval(interval);
        }
        while (rand == picindex) {
            rand = Math.floor((Math.random() * $('.item').length));
        }
        picindex = rand;
        $('#slideshowcarousel').carousel(rand);
    },2000);
}

function sequential() {
    randflag = false; 
    $('#slideshowcarousel').carousel('cycle');
}

$(window).load(function(){
  document.getElementById("start_btn").addEventListener("click", pauseplayListener);
  document.getElementById("mySwitch").addEventListener('change', function() {
    switchListener(this.checked);
  });

});