// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


console.log("Sending 1st request...")
fetch("Json/FetchData")
    .then((response) => {
        if (response.ok) {
            return response.json()
        }
        throw new Error("1st response not ok...")
    })
    .then((json) => {
        console.log("1st JSON reçu: " + JSON.stringify(json))
    })
    .catch((error) => {
        console.log(error)
    });

console.log("Sending 2nd request...")
fetch("./Json/FetchData")
    .then((response) => {
        if (response.ok) {
            return response.json()
        }
        throw new Error("2nd response not ok...")
    })
    .then((json) => {
        console.log("2nd JSON reçu: " + JSON.stringify(json))
    })
    .catch((error) => {
        console.log(error)
    });

console.log("Sending 3rd request...")
fetch("~/Json/FetchData")
    .then((response) => {
        if (response.ok) {
            return response.json()
        }
        throw new Error("3rd response not ok...")
    })
    .then((json) => {
        console.log("3rd JSON reçu: " + JSON.stringify(json))
    })
    .catch((error) => {
        console.log(error)
    });

console.log("Sending 4th request...")
fetch("/Json/FetchData")
    .then((response) => {
        if (response.ok) {
            return response.json()
        }
        throw new Error("4th response not ok...")
    })
    .then((json) => {
        console.log("4th JSON reçu: " + JSON.stringify(json))
    })
    .catch((error) => {
        console.log(error)
    });

console.log("Sending 5th request...")
fetch(BASE_URL + "/Json/FetchData")
    .then((response) => {
        if (response.ok) {
            return response.json()
        }
        throw new Error("5th response not ok...")
    })
    .then((json) => {
        console.log("5th JSON reçu: " + JSON.stringify(json))
    })
    .catch((error) => {
        console.log(error)
    });
