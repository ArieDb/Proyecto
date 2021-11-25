function guardar()
{   
  var request = new Request('https://localhost:44315/api/Values', {
        method: 'Post',
        
       headers: {
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
      body: JSON.stringify({
        cedula: document.getElementById("ced").value,
        nombre: document.getElementById("nom").value,
        edad: parseInt(document.getElementById("edad").value),
        
     //   surname: "Swift"
    })
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        alert(data);
    })
    .catch(function(err) {
        console.error(err);
    });
}

function eliminar()
{   
    ced=document.getElementById("ced").value;
  var request = new Request('https://localhost:44315/api/Values/'+ced, {
        method: 'Delete',
        
       headers: {
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },

    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        alert(data);
        document.getElementById("ced").value="";
    })
    .catch(function(err) {
        console.error(err);
    });
}

function consultar()
{   
    ced=document.getElementById("ced").value;
    dir='https://localhost:44315/api/Values/';
    if(ced!= "")
    dir='https://localhost:44315/api/Values/'+ced;

  var request = new Request(dir, {
        method: 'Get',
        
       headers: {
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },

    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        alert(data);
        cabecera();

    })
    .catch(function(err) {
        console.error(err);
    });
}

function cabecera()
{

divmensajes=Document.getElementById("Mensajes");

div1=document.createElement("div");
div1.setArttribute("id","cabecera");
div1.setArttribute("class","cabecera");
texto=document.createTextNode("cedula");
div1.appendChild(texto);

div2=document.createElement("div");
div2.setArttribute("id","cabecera");
div2.setArttribute("class","cabecera");
texto=document.createTextNode("nombre");
div2.appendChild(texto);

div3=document.createElement("div");
div3.setArttribute("id","cabecera");
div3.setArttribute("class","cabecera");
texto=document.createTextNode("edad");
div3.appendChild(texto);

divmensajes.appendChild(div1);
divmensajes.appendChild(div2);
divmensajes.appendChild(div3);

}