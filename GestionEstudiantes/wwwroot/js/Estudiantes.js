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
    try
    {
        var form = $("#FormEstudiante").dxForm("instance");
        var valido = form.validate().isValid;

        if (valido)
        {
            var data = form.option("formData");
            await EnviarServidor(data);
            EsconderFormulario();
            await Swal.fire(
                'Información',
                'Registro guardado exitosamente',
                'success'
            )
        }

    }
    catch (error)
    {
        await Swal.fire(
            'Información',
            'Algo salió mal',
            'error'
        )
    }    
}

async function EnviarServidor(dataformulario)
{     
   
   var respuesta = await $.ajax({
            method: "POST",
            url: "/Estudiantes?handler=CrearEstudiante",
            data: dataformulario
        });              
   var form = $("#FormEstudiante").dxForm("instance").resetValues();
   $("#TableEstudiantes").dxDataGrid("instance").refresh();  
       
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

function NuevoEstudiante()
{
    isEdition = false;
    $("#divgridEstudiantes").hide();   
    $("#divformEstudiante").show();
    $("#FormEstudiante").dxForm("instance").resetValues();
    $("#FormEstudiante").dxForm("instance").option("readOnly", false);
}

function EsconderFormulario()
{
    $("#divformEstudiante").hide();
    $("#divgridEstudiantes").show();
    $("#FormEstudiante").dxForm("instance").resetValues();
    $("#FormEstudiante").dxForm("instance").option("formData", null);
    $("#TableEstudiantes").dxDataGrid("instance").refresh();   
    $("#FormEstudiante").dxForm("instance").option("readOnly", false);
    $("#btnGuardar").dxButton("instance").option("visible", true);
}

async function EditStudentFromGrid(e) {

    isEdition = true;

    var IdStudent = e.row.data.Id;

    var dataStudent = await $.ajax({
        method: "GET",
        url: "/Estudiantes?handler=GetEstudianteById",
        data: { IdEstudiante: IdStudent }
    });

    if (dataStudent!=null)
    {        
        $("#FormEstudiante").dxForm("instance").option("formData", dataStudent);
        $("#FormEstudiante").dxForm("instance").getEditor("TipoDocumento").option("readOnly", true);
        $("#FormEstudiante").dxForm("instance").getEditor("Documento").option("readOnly", true);

        $("#divgridEstudiantes").hide();
        $("#divformEstudiante").show();
    }    
}

async function VerEstudianteFromGrid(e)
{
    isEdition = true;

    var IdStudent = e.row.data.Id;

    var dataStudent = await $.ajax({
        method: "GET",
        url: "/Estudiantes?handler=GetEstudianteById",
        data: { IdEstudiante: IdStudent }
    });

    if (dataStudent != null)
    {  
        $("#FormEstudiante").dxForm("instance").option("formData", dataStudent);
        $("#FormEstudiante").dxForm("instance").option("readOnly", true);
        $("#btnGuardar").dxButton("instance").option("visible", false);
        $("#divgridEstudiantes").hide();
        $("#divformEstudiante").show();
    }  
}