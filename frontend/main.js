window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
})

const functionApiUrl = 'https://mhresumevisitorcount.azurewebsites.net/api/GetResumeCounter?code=3vcOb1BYfcsks6fXQ7dQT7fs--pDzgNxF1qNrDGCiP8OAzFuRugw4A==';
const localFunctionApi = 'http://localhost:5001/api/GetResumeCounter';


const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response =>{
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}