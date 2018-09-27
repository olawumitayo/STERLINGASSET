
function CustomerFormatter(value, row, index) {
    return [
      
        '<a style="color:white" class="edit btn btn-sm btn-warning mr-2"  title="Edit Customer">'
        + '<i class="now-ui-icons ui-2_settings-90"></i>'+'</a>' +
        '<a  style="color:white" title="Remove Customer" class="remove btn btn-sm btn-danger">'
        +'<i class="now-ui-icons ui-1_simple-remove"></i></a>'+
        '</a> '
    ].join('');
}
function dateFormatter(value, row, $element) {
    var format = moment(value).format("DD MMMM, YYYY");
    var html = '<div>' + format + '</div>';
    return html;
}
window.CustomerEvents = {
   
    'click .edit': function (e, value, row, index) {
       
        if (row.state = true) {          
            var data = JSON.stringify(row);        
            $('#CustomerId').val(row.customerId);
            $('#CustomerFirstName').val(row.customerFirstName);
            $('#CustomerLastName').val(row.customerLastName);
            $('#ddlCustomerGender').val(row.CustomerSex);
            $('#CustomerAddress').val(row.customerAddress);
            $('#CustomerPhoneNo').val(row.customerPhoneNo);
            $('#CustomerDob').val(row.customerDob);
            $('#ddlCustomerStatus').val(row.customerStatus);
            $('#AddNewCustomer').modal('show'); 
            $('#btnCustomerUpdate').html('  <i class="now-ui-icons ui-1_check"></i> Update Record');
        }
    },
    'click .remove': function (e, value, row, index) {
        info = JSON.stringify(row);
        console.log(info);        
        debugger
        $('#ID').val(row.Id);
        $.ajax({
            url: 'Customer/DeleteCustomer',
            type: 'POST',
            data: { ID: row.customerId},
            success: function (data) {
                swal({
                    title: "Are you sure?",
                    text: "You are about to delete this record!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#ff9800",
                    confirmButtonText: "Yes, proceed",
                    cancelButtonText: "No, cancel!",
                    showLoaderOnConfirm: true,
                    preConfirm: function () {
                        return new Promise(function (resolve) {
                            setTimeout(function () {
                                resolve();
                            }, 4000);
                        });
                    }
                }).then(function (isConfirm) {
                    if (isConfirm) {
                      
                        $.notify("Deleted Successfully", {
                            animate: {
                                enter: 'animated flipInY',
                                exit: 'animated flipOutX'
                            }
                        });
                        $('#customerTable').
                            bootstrapTable(
                            'refresh', { url: 'Customer/listcustomer' });

                        //return false;
                    }
                    else {
                        swal("Customer", "You cancelled add customer.", "error");
                    }
                     $('#customerTable').
                            bootstrapTable(
                                'refresh', { url: 'Customer/listCustomer' });
                });
                return

            },

            error: function (e) {
                //alert("An exception occured!");
                swal("An exception occured!");
            }
        });
    }

};

$(document).ready(function ($) {

    $('#btnCustomerUpdate').on('click', function () {
        debugger
        updateCustomer();
    });

});
function updateCustomer() {
    debugger   
    var json_data = {};
    json_data.CustomerId = $('#CustomerId').val();
    json_data.CustomerFirstName = $('#CustomerFirstName').val();
    json_data.CustomerLastName = $('#CustomerLastName').val();
    json_data.CustomerSex = $('#ddlCustomerStatus').val();
    json_data.CustomerAddress = $('#CustomerAddress').val();
    json_data.CustomerPhoneNo = $('#CustomerPhoneNo').val();
    json_data.CustomerDob = $('#CustomerDob').val();
    json_data.CustomerStatus = $('#ddlCustomerGender').val();

    $("input[type=submit]").attr("disabled", "disabled");  

    $('#frmCustomer').validate({

         errorPlacement: function (error, element) {
            $.notify({
                icon: "now-ui-icons travel_info",
                message: error.text(),
            }, {
                    type: 'danger',
                    placement: {
                        from: 'top',
                        align: 'right'
                    }
                });
        },
        submitHandler: function (form) {
            swal({
                title: "Are you sure?",
                text: "Customer will be updated!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#ff9800",
                confirmButtonText: "Yes, continue",
                cancelButtonText: "No, stop!",
                showLoaderOnConfirm: true,
                preConfirm: function () {
                    return new Promise(function (resolve) {
                        setTimeout(function () {
                            resolve();
                        }, 4000);
                    });
                }
            }).then(function (isConfirm) {
                if (isConfirm) {
                    $("#btnCustomerUpdate").attr("disabled", "disabled");
                    debugger
                    $.ajax({
                        url: 'Customer/UpdateCustomer',
                        type: 'POST',
                        data: json_data,
                        dataType: "json",                       
                        success: function (result) {
                            
                            if (result.toString != '' && result != null) {
                                swal({ title: 'Update Customer', text: 'Customer updated successfully!', type: 'success' }).then(function () { clear(); });
                       
                                $('#customerTable').
                                    bootstrapTable(
                                    'refresh', { url: 'Customer/listcustomer' });

                                $("#btnCustomerUpdate").removeAttr("disabled");
                            }
                            else {
                                swal({ title: 'Update Customer', text: 'Something went wrong: </br>' + result.toString(), type: 'error' }).then(function () { clear(); });
                                $("#btnCustomerUpdate").removeAttr("disabled");
                            }
                        },
                        error: function (e) {
                            swal({ title: 'Update Customer', text: 'Customer update encountered an error', type: 'error' }).then(function () { clear(); });
                            $("#btnCustomerUpdate").removeAttr("disabled");
                        }
                    });
                }
            });
        }

    },
        function (dismiss) {
            swal('Update Customer', 'You cancelled Customer update.', 'error');
            $("#btnCustomerUpdate").removeAttr("disabled");
        });

}



$(document).ready(function ($) {

    $('#btnCustomer').on('click', function () {
        debugger      
       
            addCustomer();   
 
    });

});
function addCustomer() {
    debugger
    $('#btnCustomerUpdate').hide();
    $("input[type=submit]").attr("disabled", "disabled");
    $('#frmCustomer').validate({
        messages: {
            CustomerFirstName: { required: "First Name is required" },
            CustomerLastName: { required: "Last Name is required" },
            CustomerPhoneNo: { required: "PhoneNo is required" },
            CustomerSex: { required: "Gender is required" },       
            CustomerDob: { required: "Date of Birth is required" }
        },
        errorPlacement: function (error, element) {
            $.notify({
                icon: "now-ui-icons travel_info",
                message: error.text(),
            }, {
                    type: 'danger',
                    placement: {
                        from: 'top',
                        align: 'right'
                    }
                });
        },
        submitHandler: function (form) {
            swal({
                title: "Are you sure?",
                text: "Customer will be Added!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#ff9800",
                confirmButtonText: "Yes, continue",
                cancelButtonText: "No, stop!",
                showLoaderOnConfirm: true,
                preConfirm: function () {
                    return new Promise(function (resolve) {
                        setTimeout(function () {
                            resolve();
                        }, 4000);
                    });
                }
            }).then(function (isConfirm) {
                if (isConfirm) {
                    $("#btnCustomer").attr("disabled", "disabled");
                    debugger
                    var json_data = {};
                    json_data.CustomerId = $('#CustomerId').val();
                    json_data.CustomerFirstName = $('#CustomerFirstName').val();
                    json_data.CustomerLastName = $('#CustomerLastName').val();
                    json_data.CustomerSex = $('#ddlCustomerStatus').val();
                    json_data.CustomerAddress = $('#CustomerAddress').val();
                    json_data.CustomerPhoneNo = $('#CustomerPhoneNo').val();
                    json_data.CustomerDob = $('#CustomerDob').val();
                    json_data.CustomerStatus = $('#ddlCustomerGender').val();

                    $.ajax({
                        url: 'Customer/AddCustomer',
                        type: 'POST',
                        data: json_data,
                        dataType: "json",                      
                        success: function (result) {                           
                            if (result.toString != '' && result != null) {
                                swal({ title: 'Add Customer', text: 'Customer added successfully!', type: 'success' }).then(function () { clear(); });

                                $('#customerTable').
                                    bootstrapTable(
                                    'refresh', { url: 'Customer/listcustomer' });

                                $("#btnCustomer").removeAttr("disabled");
                            }
                            else {
                                swal({ title: 'Add Customer', text: 'Something went wrong: </br>' + result.toString(), type: 'error' }).then(function () { clear(); });
                                $("#btnCustomer").removeAttr("disabled");
                            }
                        },
                        error: function (e) {
                            swal({ title: 'Add Customer', text: 'Adding Customer encountered an error', type: 'error' }).then(function () { clear(); });
                            $("#btnCustomer").removeAttr("disabled");
                        }
                    });
                }
            });
        }

    },
        function (dismiss) {
            swal('Add Customer', 'You cancelled add Customer.', 'error');
            $("#btnCustomer").removeAttr("disabled");
        });

}

function reloadpage() {
    location.reload();
}

function clear() {
    $('#CustomerId').val('');
    $('#CustomerFirstName').val('');
    $('#CustomerLastName').val('');
    $('#CustomerAddress').val('');
    $('#CustomerPhoneNo').val('');
    $('#CustomerSex').val('');
    $('#CustomerDob').val('');
    $('#CustomerStatus').val('');
}

$('#customerTable').on('expand-row.bs.table', function (e, index, row, $detail) {
    $detail.html('Loading request...');

    var htmlData = '';
    var header = '<div>';
    var footer = '</div>';
    htmlData = htmlData + header;

    debugger

    var html =
        '<h8>' +
        '<p style="text-align:left">' +
        '<strong>Full Name:</strong>&nbsp' + row.CustomerFirstName + ' ' + row.CustomerLastName + '<p>' +
        ' <strong>Address: </strong>&nbsp' + row.CustomerAddress + '' + '<p>' +
        '<strong>PhoneNo:</strong>&nbsp' + row.CustomerPhoneNo + ' </div>';

    htmlData = htmlData + html;
    htmlData = htmlData + footer;
    $detail.html(htmlData);
});



