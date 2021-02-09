let ItemId = document.getElementById('ItemId').value;
let xhr = new XMLHttpRequest();
xhr.open('GET', `https://localhost:5001/Item/GetSubCategoriesByItemId?ItemId=${ItemId}`, true);
xhr.onload = () => {
    if (xhr.status === 200) {
        let subCategories = JSON.parse(xhr.response);
        let html = subCategories.reduce((acc, cur) => {
            return acc + `<div class="custom-control custom-checkbox">
  <input type="checkbox" class="custom-control-input" checked readonly>
  <label class="custom-control-label" >${cur.SubCategory.Name}</label>
</div>`;
        }, '');
        let div = document.getElementById('subcategories');
        div.innerHTML = html;
    }
}
xhr.send();
