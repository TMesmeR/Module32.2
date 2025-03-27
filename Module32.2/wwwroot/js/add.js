function ProcessForm(){
    let data = new FormData();
    
    data.set("Form", document.querySelector('[name="Form"]').value);
    data.set("Text", document.querySelector('[name="Text"]').value);
    
    let postRequest = new XMLHttpRequest();
    postRequest.open("POST",document.URL,true);
    postRequest.send(data);
    
    postRequest.onload = function () 
    {
        let data = new FormData();

        data.set("Form", document.querySelector('[name="Form"]').value);
        data.set("Text", document.querySelector('[name="Text"]').value);

        let postRequest = new XMLHttpRequest();
        postRequest.open("POST", document.URL, true);
        postRequest.send(data);

        postRequest.onload = function() {
            let serverMessage = this.response;
            let element = document.querySelector(".message-container");

            // Очищаем контейнер
            element.innerHTML = '';

            // Создаем элементы как в оригинале
            let breakElement = document.createElement("br");
            let paragraph = document.createElement("h5");
            paragraph.style.textAlign = "center";
            paragraph.innerText = serverMessage;

            // Добавляем элементы в контейнер
            element.appendChild(breakElement);
            element.appendChild(paragraph);
        }
    }
}