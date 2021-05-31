$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});

var isEdition = false;


//Guarda y valida mi formulario
async function Salvar()
{
    var form = $("#FormEstudiante").dxForm("instance");
    var valido = form.validate().isValid;

    if (valido)
    {
        
        var data = form.option("formData");
        await EnviarServidor(data);        
        await Swal.fire(
            'Atención',
            'Estudiante guardado correctamente',
            'success'
        )

        $("#FormEstudiante").dxForm("instance").option("readOnly", false);      
        isEdition = false;
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
        await Swal.fire(
            'Atención',
            'Ocurrió un error inesperado',
            'error'
        )

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

        if (isEdition)
        {
            return true;
        }

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

function EsconderGrid()
{
    $("#divgrid").hide();
    $("#divformulario").show();
    $("#FormEstudiante").dxForm("instance").resetValues();
    $("#FormEstudiante").dxForm("instance").option("formData",null);
}

function EsconderFormulario()
{
    $("#divformulario").hide();
    $("#divgrid").show();   
    $("#FormEstudiante").dxForm("instance").resetValues();
    $("#FormEstudiante").dxForm("instance").option("readOnly", false);
    $("#btnsalvar").dxButton("instance").option("disabled", false)
    $("#FormEstudiante").dxForm("instance").option("formData", null);
    $("#TableEstudiantes").dxDataGrid("instance").refresh();
}

async function EditarEstudianteFromGrid(e)
{

    try
    {
        var idEstudiante = e.row.data.Id;

        var estudiante = await $.ajax({
            method: "GET",
            url: "/Estudiantes?handler=ObtenerEstudiante",
            data: { idEstudiante: idEstudiante }
        });
                            
        if (estudiante == null)
        {
            await Swal.fire(
                'Atención',
                'Estudiante no encontrado',
                'info'
            )

            return;
        }
        else
        {
            $("#divgrid").hide();
            $("#divformulario").show();
            $("#FormEstudiante").dxForm("instance").resetValues();
            $("#FormEstudiante").dxForm("instance").option("formData", estudiante);
            $("#FormEstudiante").dxForm("instance").getEditor("TipoDocumento").option("readOnly", true);
            $("#FormEstudiante").dxForm("instance").getEditor("Documento").option("readOnly", true);
            isEdition = true;
        }
    }
    catch (error)
    {
        await Swal.fire(
            'Atención',
            'Ocurrió un error inesperado',
            'error'
        )
    }
    
   
}

async function VerEstudianteFromGrid(e)
{
    EditarEstudianteFromGrid(e);
    $("#FormEstudiante").dxForm("instance").option("readOnly", true);
    $("#btnsalvar").dxButton("instance").option("disabled", true)
    isEdition = true;
}