
function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}

var button = document.querySelector('.anotherjoke');
writeJoke();
function writeJoke() {
    {
        let joke = document.querySelector(".telljoke")
        joke.innerHTML = "THINKING OF A GOOD JOKE...";
        fetch('https://v2.jokeapi.dev/joke/Programming').then(response => response.json()).then(sleeper(4000)) /* sleeps for 4 seconds*/
            .then(data => {
                let joke = document.querySelector(".telljoke")
                joke.innerHTML = data;
            })
            .catch(function (error) {
                let joke = document.querySelector(".telljoke")
                joke.innerText = "THERE WAS AN ERROR, TRY AGAIN.";
            });
    }
}

button.addEventListener("click", writeJoke);
function sleeper(ms) {
    return function (response) {
        return new Promise(resolve => setTimeout(() => resolve(response), ms));
    };
}