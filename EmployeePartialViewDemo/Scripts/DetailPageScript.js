var PostBackURL = '/Home/Details';
$(function () {
    $(".anchorDetail").click(function () {
        $.ajax({
            type: "GET",
            url: PostBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });
    $("#closebtn").click(function () {
        $('#myModal').modal('hide');
    });
});


function Delete(id) {
    debugger;
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: '/Home/DeleteEmployee/',
            type: "Get",
            contentType: "application/json;charset=UTF-8",
            dataType: "html",
            data: { "Id": id },
            success: function (response) {
                if (response) {
                    alert("Deleted successfully");
                    LoadResources();
                }
                else
                {
                    alert("Employee could not be deleted!");
                    LoadResources();
                }
                
                //$("#empList").html(data);
            },
            error: function (errormessage) {
                //alert(errormessage.responseText);
            }
        });
    }
}

