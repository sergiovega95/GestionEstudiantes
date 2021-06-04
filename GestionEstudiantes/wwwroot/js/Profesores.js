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
    $("#TableProfesores").dxDataGrid("instance").addRow();     
    $("#TableProfesores").dxDataGrid("instance").columnOption("TipoDocumento.Id", "allowEditing", true);
    $("#TableProfesores").dxDataGrid("instance").columnOption("Documento", "allowEditing", true);
    $("#TableProfesores").dxDataGrid("instance").columnOption("Estado.Id", "allowEditing", false);
    
}

function EditorPreparado(e)
{
    if (e.dataField === "Estado.Id" && e.parentType === "dataRow")
    {
        if (!isEdition)
        {
            e.editorOptions.value = 1;            
            e.row.data.Estado = { Id: 1 };
        }        
        
    }
}

async function IdentificacionUnica(e)
{
    var valido = true;

    if (!isEdition)
    {
        var identificacion = e.value;

        if (identificacion != null && identificacion != "")
        {
            var idTipoDocumento = $("#SelectTipoDocumento").dxSelectBox("instance").option("value");

            if (idTipoDocumento!=0)
            {
                valido = await $.ajax({
                    method: "GET",
                    url: "/Profesores?handler=IdentificacionUnica",
                    data: { idTipoDocumento: idTipoDocumento, documento: identificacion }
                });
            }           
        }
    }   

    return valido;
}

function SetEditmode(e)
{   
    isEdition = true;
    $("#TableProfesores").dxDataGrid("instance").columnOption("TipoDocumento.Id", "allowEditing", false);
    $("#TableProfesores").dxDataGrid("instance").columnOption("Documento", "allowEditing", false);
    $("#TableProfesores").dxDataGrid("instance").columnOption("Estado.Id", "allowEditing", true);
}
