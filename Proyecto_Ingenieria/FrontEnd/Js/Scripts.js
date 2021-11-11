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
    cedula=document.getElementById("ced").value;
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
    })
    .catch(function(err) {
        console.error(err);
    });
}