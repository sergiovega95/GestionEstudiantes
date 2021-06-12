$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});

var isEdition = false;
var idEstudiante = 0;

async function BuscarEstudiante()
{
    var instanceForm = $("#formBusquedaEstudiante").dxForm("instance");

    if (instanceForm.validate().isValid)
    {
        var documentoEstudiante = $("#txtestudiante").dxTextBox("instance").option("value");

        var infoestudiante = await $.ajax({
            method: "GET",
            url: "/MateriasEstudiante?handler=ObtenerInformacionEstudiante",
            data: { documento: documentoEstudiante }
        });

        if (infoestudiante != null)
        {
            idEstudiante = infoestudiante.Id;
            $("#formmateriasestudiante").dxForm("instance").option("visible", true);
        }
        else
        {
            idEstudiante = 0;

            await Swal.fire(
                'Atención',
                `No se encontró el estudiante matrículado con la identificación ${documentoEstudiante}`,
                'info'
            )

            $("#formmateriasestudiante").dxForm("instance").option("visible", false);
        }

        var selectBoxDataSource = $("#selectMateria").dxSelectBox("getDataSource");
        selectBoxDataSource.reload();  
    }
}

function MandarIdEstudiante(action, info)
{
    if (action == "load")
    {
        info.data.idEstudiante = idEstudiante;
    }
}

function BuscarNotas()
{
    $("#TableNotas").dxDataGrid("instance").refresh();
}

function MandarIdMateriaEstudiante(action, info) {

    var idMateriaEstudiante = 0

    if ($("#selectMateria").dxSelectBox("instance").option("value")!=null)
    {
        idMateriaEstudiante = $("#selectMateria").dxSelectBox("instance").option("value").Id;

    }

    if (action == "load" || action =="insert")
    {
       

        info.data.idEstudianteXMateria = idMateriaEstudiante;
    }
}