function DropdownFunction() {
  document.getElementById("dropdown").classList.toggle("show");
}

window.onclick = function(e) {
if (!e.target.matches('.dropbtn')) {
var dropdown = document.getElementById("dropdown");
  if (dropdown.classList.contains('show')) {
    dropdown.classList.remove('show');
  }
}
}

function apiPage(){
window.location = 'https://v2.jokeapi.dev/joke/Programming';
}

function getNewJoke() {
axios({
  method: 'get',
  url: 'https://v2.jokeapi.dev/joke/Programming?type=twopart'
})
  .then(function (response) {

    let setup = document.querySelector(".joke");
    let delivery = document.querySelector(".delivery");
    delivery.innerText = ""
    setup.innerText = "";
    setup.innerText = response.data.setup;
    setTimeout(function (){
      delivery.innerText = response.data.delivery;
    }, 4000, response)
    })
  .catch(function (error){
    console.log(error);
  });
}

window.onload = getNewJoke()