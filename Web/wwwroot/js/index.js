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