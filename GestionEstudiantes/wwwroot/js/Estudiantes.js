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
    try {

        var form = $("#FormEstudiante").dxForm("instance");
        var valido = form.validate().isValid;

        if (valido) {

            var dataformulario = form.option("formData");
            await $.ajax({ method: "POST", url: "/Estudiantes?handler=CrearEstudiante", data: dataformulario });
            $("#FormEstudiante").dxForm("instance").resetValues();
        }

    }
    catch (error) {

    }
    
}

//Valida que un documento sea unico
async function DocumentoUnico(e)
{
    try
    {
       
        return await $.ajax({ method: "GET", url: "/Estudiantes?handler=VerificarIdentificacionUnica", data: { identificacion: e.value} });
    }
    catch (error)
    {
        return false;
    }
}
