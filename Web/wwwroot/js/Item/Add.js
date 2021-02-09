let categorySelect = document.getElementById('CategoryId');
let subcategoriesDiv = document.getElementById('subcategories');

let oncePageIsLoaded = () => {
    let categoryId = categorySelect.value;
    let xhr = new XMLHttpRequest();
    xhr.open('GET', `https://localhost:5001/Item/GetSubCategories?categoryId=${categoryId}`, false);
    let fillDivWithSubcategories = () => {
        if (xhr.status === 200) {
            let response = xhr.response;
            let subCategories = JSON.parse(response);
            let checkboxes = '';
            subCategories.forEach(subcategory =>
                checkboxes += `<div class="custom-control custom-checkbox"><input type="checkbox"  name="subcategories" value="${subcategory.SubCategoryId}"  id="${subcategory.SubCategoryId}" class="custom-control-input"><label class="custom-control-label" for="${subcategory.SubCategoryId}">${subcategory.Name}</label></div>`)
            subcategoriesDiv.innerHTML = checkboxes;
        }
    }
    xhr.onload = fillDivWithSubcategories;
    xhr.send(`categoryId=${categoryId}`);
}
window.onload = oncePageIsLoaded;

let reloadSubcategories = () =>
{
    let categoryId = categorySelect.value;
    let xhr = new XMLHttpRequest();
    xhr.open('GET', `https://localhost:5001/Item/GetSubCategories?categoryId=${categoryId}`, true);
    let fillDivWithSubcategories = () => {
        if (xhr.status === 200) {
            let response = xhr.response;
            let subCategories = JSON.parse(response);
            let checkboxes = '';
            subCategories.forEach(subcategory =>
                checkboxes += `<div class="custom-control custom-checkbox"><input type="checkbox"  name="subcategories" value="${subcategory.SubCategoryId}"  id="${subcategory.SubCategoryId}" class="custom-control-input"><label class="custom-control-label" for="${subcategory.SubCategoryId}">${subcategory.Name}</label></div>`)
            subcategoriesDiv.innerHTML = checkboxes;
        }
    }
    xhr.onload = fillDivWithSubcategories;
    xhr.send(`categoryId=${categoryId}`);
}
categorySelect.addEventListener('change',reloadSubcategories)

// let inputFile = document.getElementById("File");
// let validateContent= () =>
// {
//     let fileName = inputFile.value;
//     let idxDot = fileName.lastIndexOf(".") + 1;
//     let extFile = fileName.substr(idxDot, fileName.length).toLowerCase();
//     if (extFile=="jpg" || extFile=="jpeg" || extFile=="png"){
//         //TO DO
//     }else{
//         // alert("Only jpg/jpeg and png files are allowed!");
//         let span = document.getElementById('InputTagSpan');
//         span.textContent = "Only jpg/jpeg and png files are allowed!";
//     }
// }
// inputFile.addEventListener('change',validateContent);
