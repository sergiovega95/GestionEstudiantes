$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});


//Guarda y valida mi formulario
async function Salvar()
{
    var form = $("#FormEstudiante").dxForm("instance");
    var valido = form.validate().isValid;

    if (valido)
    {
        
        var data = form.option("formData");
        await EnviarServidor(data);
        
        
    }
}

async function EnviarServidor(dataformulario)
{      
    try
    {
        var respuesta = await $.ajax({
            method: "POST",
            url: "/Estudiantes?handler=CrearEstudiante",
            data: dataformulario
        });
              
        var form = $("#FormEstudiante").dxForm("instance").resetValues();
        $("#TableEstudiantes").dxDataGrid("instance").refresh();
    }
    catch (error)
    {
        alert("algo salio mal");
    }
   
        
}

function VerificarMayorEdad(e)
{
    console.log(e);
    var valido = true;

    var edad = e.value;

    if (edad<18)
    {
        valido = false;
    }

    return valido;
}

async function ValidarIdentificacionUnica(e)
{
    try {

        var identificacion = e.value;

        var idTipoDocumento = $("#FormEstudiante").dxForm("instance").getEditor("TipoDocumento").option("value").Id;

        if (idTipoDocumento!=0)
        {
            var valido = await $.ajax({
                method: "GET",
                url: "/Estudiantes?handler=VerificarIdentificacion",
                data: { Idtipodocumento: idTipoDocumento, documento: identificacion }
            });
        }      

        return valido;
    }
    catch (error) {

    }
}

function EditarEstudianteFromGrid(e)
{
    console.log(e);
}