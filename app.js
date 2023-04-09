const computerChoiceDisplay = document.getElementById("computer-choice");
const userChoiceDisplay = document.getElementById("user-choice");
const resultDisplay = document.getElementById("result");

const possibleChoice = document.querySelectorAll("button");
let userChoice;
let computerChoice;
let result;


possibleChoice.forEach(element => {
    element.addEventListener("click", (e) => {
        userChoice = e.target.id
        userChoiceDisplay.innerHTML = userChoice;
        generateComputerChoice();
        getResult(userChoice, computerChoice);
    });
});

const generateComputerChoice = () => {
    const randomNumber = Math.floor(Math.random() * possibleChoice.length) + 1;
    const choice = {
        1: "rock",
        2: "paper",
        3: "scissor"
    }
    computerChoice = choice[randomNumber];

    computerChoiceDisplay.innerHTML = computerChoice;
}

const getResult = (user, computer) => {
    if (user === computer)
    {
        result = 'Draw';
    }

    else 
        if (user === 'rock' && computer === "scissor")
        {
            result = 'You Won!';
        }
        else if (user === 'rock' && computer === "paper")
        {
            result = "You Lost!";
        }
        else if (user === 'scissor' && computer === "paper")
        {
            result = "You Won!";
        }
        else if (user === 'scissor' && computer === 'rock')
        {
            result = "You Lost!";
        }
        else if (user === 'paper' && computer === "rock")
        {
            result = "You Won!"
        }
        else if (user === 'paper' && computer === "scissor")
        {
            result = "You Lost!";
        }
    
    resultDisplay.innerHTML = result;


}

