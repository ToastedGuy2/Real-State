// Make Data Tables work
// @ts-check
$(document).ready(function () {
    $('#itemsTable').DataTable();
});

let showPopUp = () => {
    let title = "Add Food";
    let url = "/Item/Add";
    let httpMethod = "GET";
    let xhr = new XMLHttpRequest();
    //Giving the instructions, how should it do the request
    xhr.open(httpMethod, url);
    // What to do after getting a response 
    let innerResponseToTheModal = () => {
        let partialView = xhr.response;
        let modalTittle = document.querySelector(".modal-title");
        modalTittle.textContent = title;
        let modalBody = document.querySelector(".modal-body");
        modalBody.innerHTML = partialView;
        $.validator.unobtrusive.parse("#addForm");
        let categorySelect = document.getElementById("CategoryId");
        let refreshBrands = evt => {
            let brandSelect = document.getElementById("BrandId");
            let categoryIdSelected = categorySelect.value;
            let url = `/api/${categoryIdSelected}/Brand`;
            let httpMethod = "GET";
            let xhr = new XMLHttpRequest();
            xhr.open(httpMethod, url);
            xhr.onload = () => {
                brandSelect.innerHTML = "";
                let brands = JSON.parse(xhr.response);
                for (let index = 0; index < brands.length; index++) {
                    const brand = brands[index];
                    let option = document.createElement('option');
                    option.setAttribute('value', brand.id);
                    option.appendChild(document.createTextNode(brand.name));
                    brandSelect.appendChild(option);
                }
            }
            xhr.send();
        }
        categorySelect.addEventListener("change", refreshBrands);
        let submitForm = document.getElementById("addForm")
        submitForm.addEventListener("submit", formSubmit);
    }
    xhr.onload = innerResponseToTheModal;
    xhr.send();
}
let addBtn = document.getElementById('addBtn');
addBtn.addEventListener('click', showPopUp);

// After
let formSubmit = e => {
    e.preventDefault();
    var url = "/Item/Add";
    var request = new XMLHttpRequest();
    request.open('POST', url, true);
    let whatToDo = () => {
        // request successful
        // we can use server response to our request now
        let result = JSON.parse(request.response);
        if (result.isValid) {
            $('#modal').on('hidden.bs.modal', function (e) {
                let tableBody = document.querySelector("#itemsTable tbody");
                tableBody.innerHTML = "";
                let xhr = new XMLHttpRequest();
                xhr.open("GET", "/api/Item");
                xhr.onload = () => {
                    let items = JSON.parse(xhr.response);
                    for (let i = 0; i < items.length; i++) {
                        const item = items[i];
                        let row = document.createElement("tr");
                        let nameTd = document.createElement("td");
                        nameTd.textContent = item.name;
                        let priceTd = document.createElement("td");
                        priceTd.textContent = item.price;
                        let categoryTd = document.createElement("td");
                        categoryTd.textContent = item.category;
                        let brandTd = document.createElement("td");
                        brandTd.textContent = item.brand;
                        row.appendChild(nameTd);
                        row.appendChild(priceTd);
                        row.appendChild(categoryTd);
                        row.appendChild(brandTd);
                        tableBody.appendChild(row);
                    }
                }
                const notyf = new Notyf({
                    position: {
                        x: 'right',
                        y: 'top',
                    }
                });
                notyf.success("Item successfully inserted");

            })
            $('#modal').modal('hide');
        } else {
            let modalBody = document.querySelector(".modal-body");
            modalBody.innerHTML = result.html;
            $.validator.unobtrusive.parse("#addForm");
        }
    }
    request.onload = whatToDo;

    request.send(new FormData(e.target)); // create FormData from form that triggered event
}