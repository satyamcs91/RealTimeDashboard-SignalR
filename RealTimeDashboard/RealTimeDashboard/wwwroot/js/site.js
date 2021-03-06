

$(() => {
   
    
    var Connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build();
    Connection.start();
    Connection.on("RefreshEmployees", function (result) {  
        var divs = '' ;
        var obj = $.parseJSON(result);
        var count = Object.keys(obj.DispatchGatesList).length;
        console.log(count);
        if (count == 0) {
            divs += `
                     <div class=" align-content-center" style="position: relative;left: 37%; top: 123px;" >No Content available. Waiting for the Packlist  </div>
                     `

        } else {
            for (var i = 0; i < obj.DispatchGatesList.length; i++) {
                var DispatchGateInfo = obj.DispatchGatesList[i];

                divs += [` <div class="flex-sm-fill m-1 p-1 bg-white " style="border: 3px solid grey">
            <div id="gateno"  class="bg-primary  py-3">
                <h3  class="text-center text-white">${DispatchGateInfo.GateNo}</h3>
                <div class="h6 m-0 text-white text-break px-3 py-1">PackList No : ${DispatchGateInfo.PacklistNo} </div>
            </div>
            <div class="bg-white pt-1 mb-0">
                <div class="card border-0" style="width:50%; float:right">
                    <div id="Total" class="bg-primary py-2"><div class="h6 m-0 text-white px-3">Total :  ${DispatchGateInfo.Total} </div></div>
                    <div class="bg-danger py-2"><div class="h6 m-0 text-white px-3">Pending :  ${DispatchGateInfo.Pending}  </div> </div>
                    <div id="Dispatched" class="bg-success py-2"> <div class="h6 m-0 text-white px-3">Dispatched :  ${DispatchGateInfo.Dispatched}  </div> </div>
                    <div id="TagCollected" class="py-2" style="background-color:darkorange"><div class="h6 m-0 text-white px-3">Tag Collected :  ${DispatchGateInfo.RFIDTagCollected} </div></div>
                </div>
                <div class="card border-0 bg-white  pt-1 mb-0 truckdata">
                     <div id="BatchNo" class="h6 m-2 text-black px-0"> Batch No : ${DispatchGateInfo.BatchInfos[0].BatchNo} </div>
                     <div id="ProducedOn" class="h6 m-2 text-black px-0"> Produced On :  ${DispatchGateInfo.BatchInfos[0].ProducedOn} </div>
                     <div id="RFIDNo" class="h6 m-2 text-black px-0"> RFID No :  ${DispatchGateInfo.BatchInfos[0].RFIDNo} </div>
                     <div id="TruckNo" class="h6 m-2 text-primary px-0"> <b>Truck No : ${DispatchGateInfo.BatchInfos[0].TruckNo} </b> </div>
                </div>
            </div>

            <div class="table-responsive ">
                <table class="table table-bordered table-striped table-sm">
                    <thead class="visually-hidden bg-secondary">
                        <tr>
                            <th scope="col">Batch No</th>
                            <th scope="col">RFID No</th>
                            <th scope="col">Wt</th>
                            <th scope="col">Len</th>
                            <th scope="col">Wid</th>
                        </tr>
                    </thead>
                    <tbody id="tblbody">`].join("\n");

                for (var j = 0; j < DispatchGateInfo.BatchInfos.length; j++) {
                    var BatchWiseInfo = DispatchGateInfo.BatchInfos[j];
                    if (BatchWiseInfo.FoundStatus == "Red") {
                        divs += [
                            `<tr style=background-color:crimson;color:white>
                                    <td>${BatchWiseInfo.BatchNo}</td>
                                    <td>${BatchWiseInfo.RFIDNo}</td>
                                    <td>${BatchWiseInfo.Weight}</td>
                                    <td>${BatchWiseInfo.Length}</td>
                                    <td>${BatchWiseInfo.Width}</td>
                                </tr>`
                        ].join("\n");
                    }
                    else if (BatchWiseInfo.FoundStatus == "Blue") {
                        if (BatchWiseInfo.RFIDTagCollectedStatus == "False") {
                            divs += [
                                `<tr style=background-color:cornflowerblue>
                                    <td>${BatchWiseInfo.BatchNo}</td>
                                    <td>${BatchWiseInfo.RFIDNo}</td>
                                    <td>${BatchWiseInfo.Weight}</td>
                                    <td>${BatchWiseInfo.Length}</td>
                                    <td>${BatchWiseInfo.Width}</td>
                                </tr>`
                            ].join("\n");
                        }
                        else if (BatchWiseInfo.RFIDTagCollectedStatus == "True") {
                            divs += [
                                `<tr style=background-color:lightgreen>
                                    <td>${BatchWiseInfo.BatchNo}</td>
                                    <td>${BatchWiseInfo.RFIDNo}</td>
                                    <td>${BatchWiseInfo.Weight}</td>
                                    <td>${BatchWiseInfo.Length}</td>
                                    <td>${BatchWiseInfo.Width}</td>
                                </tr>`
                            ].join("\n");
                        }
                    }
                    else {
                        divs += [
                            `<tr>
                                    <td>${BatchWiseInfo.BatchNo}</td>
                                    <td>${BatchWiseInfo.RFIDNo}</td>
                                    <td>${BatchWiseInfo.Weight}</td>
                                    <td>${BatchWiseInfo.Length}</td>
                                    <td>${BatchWiseInfo.Width}</td>
                                </tr>`
                        ].join("\n");
                    }
                }
                divs += ['</tbody></table>'].join("\n");
                divs += ['</div>', '</div>', '</div>'].join("\n");
            }
        }
        $('#section').html(divs)
       
    })

   

        

              


   
})


   

