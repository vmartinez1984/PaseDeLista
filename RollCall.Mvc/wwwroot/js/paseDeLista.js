var securityQuestionId;
$("#divEmployee").hide();

function onKeyUp(event) {
    var keycode = event.keyCode;
    if (keycode == '13') {
        searchEmployee();
    }
    if (document.getElementById("employeeNumber").value !== "") {
        document.getElementById("error").innerText = '';
    }
}

setInterval(function () {
    var time;
    var now;

    now = new Date();
    time = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();
    //console.log(time);
    document.getElementById("clock").innerHTML = time;
}, 1000);

function searchEmployee() {
    if (document.getElementById("employeeNumber").value !== "") {
        var url;

        document.getElementById("error").innerText = '';
        awaitMoment();
        url = "api/Employees/" + document.getElementById("employeeNumber").value;
        fetch(url)
            .then(response => {
                console.log(response);
                if (response.ok) {
                    response.json().then(data => {
                        console.log(data);
                        Swal.close();
                        $("#divEmployee").show();
                        document.getElementById("employeeNumber").innerHTML = "";
                        document.getElementById("employeeId").innerHTML = data.id;
                        document.getElementById("pName").innerHTML = data.name + " " + data.lastName;
                        getSecurityQuestion(data.id);
                    });
                } else if (response.status == 404) {
                    response.json().then(data => {
                        //console.log(data);
                        Swal.close();
                        Swal.fire({
                            position: 'center',
                            icon: 'warning',
                            title: data.response,
                            showConfirmButton: false,
                            timer: 1500
                        });
                        document.getElementById("employeeNumber").value = '';
                    });
                }
            })
            .catch(error => {
                console.log(error);
                anErrorOcurred();
            });
    } else {
        document.getElementById("error").innerText = "Anote un número";
    }
}

function getSecurityQuestion(employeeId) {
    var url;

    url = "api/SecurityQuestions/Employee/" + employeeId + "/RandomSecurityQuestion";
    fetch(url)
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw response.error;
            }
        })
        .then(securityQuestion => {
            //console.log(data);
            securityQuestionId = securityQuestion.id;
            document.getElementById("pSecurityQuestion").innerHTML = securityQuestion.question;
        })
        .catch(error => {
            console.log(error);
        });
}

function verifyAnswer() {
    var url;
    var data;

    awaitMoment();
    data = {
        SecurityQuestionId: securityQuestionId,
        Answer: document.getElementById("answer").value,
        AsistanceStatusId: getAsistanceStatusId()
    }
    url = "api/Asistances/Register";
    fetch(url, {
        method: "post",
        body: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw response.error;
            }
        })
        .then(register => {
            //console.log(register);
            if (register.isRegister) {
                $("#divEmployee").hide();
                document.getElementById("employeeNumber").value = "";
                document.getElementById("pSecurityQuestion").innerHTML = "";
                document.getElementById("pName").innerHTML = " ";
                loggedData();
            } else {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Intente nuevamente',
                    showConfirmButton: false,
                    timer: 1500
                });
            }
        })
        .catch(error => {
            console.log(error);
            anErrorOcurred();
        });
}

function getAsistanceStatusId() {
    var assistanceStatus;
    var asistanceStatusId;

    assistanceStatus = document.getElementsByName("AssistanceStatus");
    for (i = 0; i < assistanceStatus.length; i++) {
        if (assistanceStatus[i].checked) {
            asistanceStatusId = assistanceStatus[i].value;
        }
    }

    return asistanceStatusId;
}

function anErrorOcurred() {
    Swal.fire({
        title: 'Ocurrio un error',
        icon: 'error'
    });
}

function loggedData() {
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: 'Datos registrados',
        showConfirmButton: false,
        timer: 1500
    });
}

function awaitMoment() {
    Swal.fire({
        icon: 'info',
        title: 'Un momento por favor...',
        allowOutsideClick: false,
        showConfirmButton: false
    });
}