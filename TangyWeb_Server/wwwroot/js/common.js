window.ShowToastr = (type,message) => {
    if(type === "success"){
        toastr.success(message,"Operation Successful", {timeout: 5000});
    }
    else if(type === "error"){
        toastr.error(message,"Operation Failed", {timeout: 5000});
    }
}

window.ShowSweetAlert = (type,message) => {
    if(type === "success"){
        Swal.fire(
            'Success Notification!',
            message,
            'success'
        );
    }
    else if(type === "error"){
        Swal.fire(
            'Error Notification!',
            message,
            'error'
        );
    }
}

function ShowDeleteConfirmationModel() {
     $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModel() {
    $('#deleteConfirmationModal').modal('hide');
}