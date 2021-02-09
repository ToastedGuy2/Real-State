let categorySelect = document.getElementById("CategoryId");
let subCatDiv = document.getElementById("subcategories");

let ShowAllSubCategories = () => {
    let categoryId = categorySelect.value;
    let xhr = new XMLHttpRequest();
    xhr.open('GET', `https://localhost:5001/Item/GetSubCategories?categoryId=${categoryId}`, true);
    let subCategories = [];
    let fillDivWithCheckboxes = () => {
        if (xhr.status === 200) {
            let json = JSON.parse(xhr.response);
            subCategories = json;
            subCatDiv.innerHTML = subCategories.reduce((prev, cur) => {
                return prev + `<div class="custom-control custom-checkbox">
                            <input type="checkbox"  name="subcategories" value="${cur.SubCategoryId}" class="custom-control-input" id="${cur.SubCategoryId}">
                            <label class="custom-control-label" for="${cur.SubCategoryId}">${cur.Name}
                            </label>
                        </div>`
            }, "");
        }
    };
    xhr.onload = fillDivWithCheckboxes;
    xhr.send();
}

let AddingCheckedAttribute = () => {
    let ItemIdInput = document.getElementById("ItemId");
    let ItemId = ItemIdInput.value;
    let xhr = new XMLHttpRequest();
    xhr.open('GET', `https://localhost:5001/Item/GetSubCategoriesByItemId?ItemId=${ItemId}`, true);
    let ItemSubCategories = [];
    xhr.onload = () => {
        if (xhr.status === 200) {
            ItemSubCategories = JSON.parse(xhr.response);
            let subCategories = ItemSubCategories.map(psc => psc.SubCategory);
            subCategories.forEach(subCat => {
                let input = document.getElementById(`${subCat.SubCategoryId}`);
                if (input !== null) {
                    input.checked = true;
                }
            })
        }
    }
    xhr.send();
}

let ShowCheckedSubCategories = () => {
    ShowAllSubCategories();
    AddingCheckedAttribute();

}

window.addEventListener('load', ShowCheckedSubCategories);
categorySelect.addEventListener('change', ShowCheckedSubCategories); 
