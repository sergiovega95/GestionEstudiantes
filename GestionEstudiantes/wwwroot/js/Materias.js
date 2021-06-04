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
    isEdition = false; 
    $("#TableMateria").dxDataGrid("instance").addRow();     
    $("#TableMateria").dxDataGrid("instance").columnOption("Code", "allowEditing", true);
    $("#TableMateria").dxDataGrid("instance").columnOption("Estado.Id", "allowEditing", false);
}

async function CodigoUnico(e)
{
    var valido = true;

    if (!isEdition)
    {
        var codigo = e.value;

        if (codigo != null && codigo != "")
        {
            valido = await $.ajax({
                method: "GET",
                url: "/Materias?handler=VerificarCodigoUnico",
                data: { materiaCode: codigo }
            });
        }
    }   

    return valido;
}

function SetEditmode(e)
{   
    isEdition = true;
    $("#TableMateria").dxDataGrid("instance").columnOption("Code", "allowEditing", false);
    $("#TableMateria").dxDataGrid("instance").columnOption("Estado.Id", "allowEditing", true);
}

function EditorPreparado(e)
{
    if (e.dataField === "Estado.Id" && e.parentType === "dataRow")
    {
        if (!isEdition) {
            e.editorOptions.value = 1;
            e.row.data.Estado = { Id: 1 };
        }

    }
}
