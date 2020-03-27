function LoadResources()
{
    $.ajax({
        url: '/Home/GetResultByAjax',
        datatype: "json",
        type: "GET",
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (response) {
            $("#empList").html(response);
        },
        error: function (xhr) {
            JSON.stringify('error');
            alert('error');
        }
    });
}
$(document).ready(function ()
{   
    LoadResources();
});