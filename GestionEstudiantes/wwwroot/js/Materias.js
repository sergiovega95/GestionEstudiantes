$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName(
            "__RequestVerificationToken"
        )[0].value
    }
});

var isEdition = false;

function AddModeGrid()
{
    $("#TableMateria").dxDataGrid("instance").addRow();
    isEdition = false;   
}

async function CodigoUnico(e)
{
    var valido = true;

    if (!isEdition)
    {
        var codigo = e.value;

        if (codigo != null && codigo != "") {
            valido = await $.ajax({
                method: "GET",
                url: "/Materias?handler=VerificarCodigoUnico",
                data: { materiaCode: codigo }
            });
        }
    }   

    return valido;
}

function SetEditmode()
{
    isEdition = true;
}
