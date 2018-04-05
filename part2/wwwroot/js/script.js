$(".item").first().addClass("active");

var paused = false;

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
    document.getElementById("prev_btn").setAttribute("disabled", "true");
    document.getElementById("next_btn").setAttribute("disabled", "true");
    $('.right').hide();
    $('.left').hide();      
  } else {
    document.getElementById("prev_btn").removeAttribute("disabled");
    document.getElementById("next_btn").removeAttribute("disabled");
    $('.right').show();   
    $('.left').show();   
  }
}

function pausePlay() {
}

function nextImage() {
  currIndex = (currIndex + 1) % imgkeys.length;
  index = imgkeys[currIndex];
  displayImage(imageObjects[index], imageObjects[index].caption, transition);
}

$(window).load(function(){
  document.getElementById("start_btn").addEventListener("click", pauseplayListener);
  document.getElementById("next_btn").addEventListener("click", nextImage);
  document.getElementById("prev_btn").addEventListener("click", prevImage);

  document.getElementById("mySwitch").addEventListener('change', function() {
    switchListener(this.checked);
  });

});

function prevImage() {
  currIndex--;
  if (currIndex < 0) {
    currIndex = imgkeys.length - 1;
  }
  index = imgkeys[currIndex];
  displayImage(imageObjects[index], imageObjects[index].caption, transition);
}