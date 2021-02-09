let categorySelect = document.getElementById("CategoryId");
let ItemIdInput = document.getElementById("ItemId");
let subCatDiv = document.getElementById("subcategories");
let GetAllSubCategories = () => {
    let categoryId = categorySelect.value;
    let xhr = new XMLHttpRequest();
    xhr.open('GET', `https://localhost:5001/Item/GetSubCategories?categoryId=${categoryId}`, false);
    let subCategories = [];
    let ajaxRequest = () => {
        if (xhr.status === 200) {
            let json = JSON.parse(xhr.response);
            subCategories = json;
        }
    };
    xhr.onload = ajaxRequest;
    xhr.send();
    return subCategories;
}

let GetItemSubCategories = () => {
    let ItemId = ItemIdInput.value;
    let xhr = new XMLHttpRequest();
    xhr.open('GET', `https://localhost:5001/Item/GetSubCategoriesByItemId?ItemId=${ItemId}`, false);
    let ItemSubCategories = [];
    xhr.onload = () => {
        if (xhr.status === 200)
            ItemSubCategories = JSON.parse(xhr.response);
    }
    xhr.send();
    return ItemSubCategories;
}

let GetSubCategoriesFromItemSubCategories = () => {
    let ItemSubCategories = GetItemSubCategories();
    return ItemSubCategories.map(psc => psc.SubCategory);
}
let showSubCategoriesWhetherAreCheckedOrNot = () => {
    let allSubCats = GetAllSubCategories();
    let allInputs = allSubCats.reduce((prev, cur) => {
        return prev + `<div class="custom-control custom-checkbox">
                            <input type="checkbox"  name="subcategories" value="${cur.SubCategoryId}" class="custom-control-input" id="${cur.SubCategoryId}">
                            <label class="custom-control-label" for="${cur.SubCategoryId}">${cur.Name}
                            </label>
                        </div>`
    }, "")
    subCatDiv.innerHTML = allInputs;
    let proSubCats = GetSubCategoriesFromItemSubCategories();
    proSubCats.forEach(subCat => {
        let input = document.getElementById(`${subCat.SubCategoryId}`);
        if(input !==null){
            input.checked = true;
        }
    })
}

window.addEventListener('load', showSubCategoriesWhetherAreCheckedOrNot);
categorySelect.addEventListener('change', showSubCategoriesWhetherAreCheckedOrNot); 
