$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});

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
            $("#TableMateriaXEstudiante").dxDataGrid("instance").refresh();
        }
        else
        {
            idEstudiante = 0;      

            await Swal.fire(
                'Atención',
                `No se encontró el estudiante matrículado con la identificación ${documentoEstudiante}`,
                'info'
            )   

            $("#TableMateriaXEstudiante").dxDataGrid("instance").refresh();
        }
    }
}

function MandarIdEstudiante(action , info) {
        

    if (action == "load" || action == "insert")
    {

        info.data.idEstudiante = idEstudiante;
    }
}