var ListSecurityQuestions = new Array();

$("#spanValidationOfList").hide();
function addSecurityQuestion() {
    var textAnswer;
    var textQuestion;

    textAnswer = document.getElementById("answer");
    textQuestion = document.getElementById("question");
    if (validateSecurityQuestion(textAnswer, textQuestion))
        return;
    securityQuestion = new Object();
    securityQuestion.answer = textAnswer.value;
    securityQuestion.question = textQuestion.value;
    ListSecurityQuestions.push(securityQuestion);
    textAnswer.value = "";
    textQuestion.value = "";
    setInputSecurityQuestion();
    setListSecurityQuestion();
    $("#spanValidationOfList").hide();
    textQuestion.focus();
    console.log(ListSecurityQuestions);
}

function validateSecurityQuestion(textAnswer, textQuestion) {
    $("#answerValidation").hide();
    $("#questionValidation").hide();
    if (textAnswer.value == "") {
        $("#answerValidation").show();
        document.getElementById("answerValidation").innerText = "El campo no puede ir vacio";
    }
    if (textQuestion.value == "") {
        $("#questionValidation").show();
        document.getElementById("questionValidation").innerText = "El campo no puede ir vacio";
    }
    if (textAnswer.value == "" || textQuestion.value == "") {
        return true;
    } else {
        return false;
    }
}

function setInputSecurityQuestion() {
    document.getElementById("divListSecurityQuestions").innerHTML = "";
    for (i = 0; i < ListSecurityQuestions.length; i++) {
        var inputHiddenQuestion;
        var inputHiddenAnswer;

        inputHiddenQuestion = document.createElement("input");
        inputHiddenQuestion.setAttribute("type", "hidden");
        inputHiddenQuestion.setAttribute("name", "securityQuestions[" + i + "].Question");
        inputHiddenQuestion.value = ListSecurityQuestions[i].question;
        document.getElementById("divListSecurityQuestions").appendChild(inputHiddenQuestion);

        inputHiddenAnswer = document.createElement("input");
        inputHiddenAnswer.setAttribute("type", "hidden");
        inputHiddenAnswer.setAttribute("name", "securityQuestions[" + i + "].Answer");
        inputHiddenAnswer.value = ListSecurityQuestions[i].answer;
        document.getElementById("divListSecurityQuestions").appendChild(inputHiddenAnswer);
    }
}

function setListSecurityQuestion() {
    document.getElementById("tbody").innerHTML = "";
    for (i = 0; i < ListSecurityQuestions.length; i++) {
        //console.log(ListSecurityQuestions[i].answer);
        var code;

        code = "<tr>";
        code += "<td>" + ListSecurityQuestions[i].question + "</td>";
        code += "<td>" + ListSecurityQuestions[i].answer + "</td>";
        code += "<td><button type='button' class='btn btn-danger' onclick='deleteSecurityQuestion(" + i + ")'><i class='fa fa-times'></i></button></td>"
        code += "</tr>";

        document.getElementById("tbody").innerHTML += code;
    }
}

function deleteSecurityQuestion(index) {
    //console.log(index);
    ListSecurityQuestions.splice(index, 1);
    setInputSecurityQuestion();
    setListSecurityQuestion();
}

document.getElementById("formEmployee").addEventListener("submit", verifyListSecurityQuestions);

function verifyListSecurityQuestions(event) {
    debugger;
    if (ListSecurityQuestions.length < 5) {
        $("#spanValidationOfList").show();
        document.getElementById("spanValidationOfList").innerText = "Agregue " + (5 - ListSecurityQuestions.length) + " Preguntas de seguridad"
        event.preventDefault();
    }
}

function verifyEmptyQuestion() {
    if (document.getElementById("question").value.length > 0) {
        $("#questionValidation").hide();
    }
}

function verifyEmptyAnswer(e) {
    if (document.getElementById("answer").value.length > 0) {
        $("#answerValidation").hide();
    }
    if (e.key === 'Enter' || e.keyCode === 13) {
        addSecurityQuestion();
    }
}