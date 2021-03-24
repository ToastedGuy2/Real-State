const objNode = document.createElement("div");
// objNode.style.width  = "100vw";
objNode.style.height = "100vh";
document.body.appendChild(objNode);
// const intViewportWidth  = objNode.offsetWidth;
const intViewportHeight = objNode.offsetHeight;
document.body.removeChild(objNode);

const navbarHeight = document.querySelector('.navbar').offsetHeight;
const jumbotron = document.getElementById('jumbotron');
jumbotron.style.height = intViewportHeight - navbarHeight + "px";

document.getElementById('search-province-form').addEventListener('submit', (event) => {
    let provinceSelect = document.getElementById('SelectedProvince');
    if (provinceSelect.value == '0') {
        event.preventDefault();
        const notyf = new Notyf({
            position: {
                x: 'right',
                y: 'top',
            }
        });
        notyf.error("Hey, you must pick a province!!!")
    }
})