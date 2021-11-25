const password = document.getElementById('password');
const button = document.getElementById('button');

button.addEventListener('click',encript);

function encript(){
    let new_password = btoa(password.value)
    console.log(new_password);
}
