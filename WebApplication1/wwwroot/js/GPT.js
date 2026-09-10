function sendMessage() {
    var userInput = document.getElementById("userinput").value;
    if (userInput.trim() !== "") {
        // Display the user's message
        displayMessage(userInput, 'user');
        document.getElementById("userinput").value = '';

        var botResponse = myDisplay(userInput);

    }
}

async function myDisplay(userInput) {
    let myPromise = new Promise(function (resolve) {
        resolve(getAPIResponce(userInput));

    });
    var x = await myPromise;
    return (x);
}
function displayMessage(message, sender) {
    var messageElement = document.createElement("div");
    messageElement.classList.add("chat-message");
    messageElement.classList.add(sender);

    var messageContent = document.createElement("p");
    messageContent.textContent = message;

    messageElement.appendChild(messageContent);
    document.getElementById("chat-box").appendChild(messageElement);

    // Scroll to the bottom of the chat
    document.getElementById("chat-box").scrollTop = document.getElementById("chat-box").scrollHeight;
}

function generateResponse(userMessage) {
    console.log(userMessage)

    return userMessage;

}


function getAPIResponce(query) {
    console.log("in getAPIResponse")
    fetch("http://127.0.0.1:8000/api/v1/chat", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ "query": query })

    })
        .then((response) => response.json())
        .then((json) => {


            displayMessage(json.response, 'bot');
        });
}