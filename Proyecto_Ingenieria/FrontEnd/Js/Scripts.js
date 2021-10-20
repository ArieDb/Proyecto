function verificar() {
    var sexo = document.getElementById("sexo").value;
    var nom = document.getElementById("nom").value;
    var edad = document.getElementById("edad").value;

    var suma = parseInt(edad) + 10;
    alert(suma)


    mensaje("su nombre es: " + nom + " y su sexo es :" + sexo + "  su edad es: " + edad)
}

function mensaje(texto) {
    //DHTML
    divmensajes = document.getElementById("Mensajes");
    textomensaje = document.createTextNode(texto);

    divnuevo = document.createElement("div");
    divnuevo.setAttribute("class", "Fondomensaje");
    //divnuevo.setAttribute("id","unico");

    divnuevo.appendChild(textomensaje);
    divmensajes.appendChild(divnuevo);

}