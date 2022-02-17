

$(() => {
    LoadData();

    var Connection = new signalR.HubConnectionBuilder().withUrl("/dashboards").build();
    Connection.start();
    Connection.on("LoadProducts", function () {
        LoadData();
    })
    LoadData();

    function LoadData() {

        var tr = '';

        $.ajax({
            url: '/DashBoard/GetProducts',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
                      <td>${v.ModelNo}</td>
                      <td>${v.AssetName}</td>
                      <td>${v.Location}</td>
                      <td>${v.Cost}</td>
                     </tr>`
                })

                $("#tablebody").html(tr)
            },
            error: (error) => {
                console.log(error);
            }
        })
        
    }
})