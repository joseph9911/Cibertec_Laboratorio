function closeModal(option) {
    $("button[data-dismiss='modal']").click();
    $('.modal-body').html('');
    modifyModalClasses(option);
    location.reload();
}

function getModalContent(url) {
    modifyModalClasses('');
    $.get(url, function (data) {        
        $('.modal-body').html(data);        
    });
}

function modifyModalClasses(option) {
    $('#successMessage').addClass('hidden');
    $('#deleteMessage').addClass('hidden');
    $('#editMessage').addClass('hidden');
    if (option === "create") 
        $('#successMessage').removeClass('hidden');            
    else if (option === "delete")
        $('#deleteMessage').removeClass('hidden');
    else if (option === "edit")
        $('#editMessage').removeClass('hidden');
}