let dropButt = document.querySelector('.MenuButton');
let menuContent = document.querySelector('.MenuDrop');
    dropButt.addEventListener('click', () => 
    {
        if(menuContent.style.display === "")
    {
        menuContent.style.display="block";
    } 
        else 
        {
            menuContent.style.display = "";
        }
    }
)

function JokeResult()
{
   let ResultLocation = document.querySelector(".Result");
   ResultLocation.style.visibility = 'visible';
}

function getJoke()
{
    axios(
    {
      method: 'get',
      url: 'https://v2.jokeapi.dev/joke/Programming'
    }
    )
   .then(function (response) 
    {
    let type = response.data.type;
    let placement = document.querySelector(".Joke");
    let ResultLocation = document.querySelector(".Result");
    ResultLocation.style.visibility = 'hidden'
    if(type.includes("single", 0) )
    {
        let joke = response.data.joke
        placement.innerText = joke;
    }
        else if (type.includes("twopart", 0))
        {
            let setup = response.data.setup;
            let delivery = response.data.delivery;
            placement.innerText = setup;
            let ResultLocation = document.querySelector(".Result");
            ResultLocation.style.visibility = 'hidden'
            ResultLocation.innerText = delivery;
            setTimeout(JokeResult, 4000);
        }
            else
            {
            placement.innerText = "try again in a few moments";
        }
    }
    )
    .catch(function (error) 
    {
        console.log("error: try again in a few moments.");
    }  
    );
}   

window.onload = getJoke;

var count = 0;
//This should complete the turn a perfect 360 after 4 clicks 
function creativeButt()
    {
       if (count == 0) {
        document.getElementsByTagName('body')[0].style.transform = 'rotate(69deg)';
       }
       else if (count == 1) {
        document.getElementsByTagName('body')[0].style.transform = 'rotate(90deg)';
       }
       else if (count == 2) {
        document.getElementsByTagName('body')[0].style.transform = 'rotate(180deg)';
       }
       //removed 270deg flip since the button sometimes will no longer be visible depending on your
       //browser window size
       else {
        document.getElementsByTagName('body')[0].style.transform = 'rotate(0deg)';
        count=-1;
       }
      clicked = false;
      count++;
    } 