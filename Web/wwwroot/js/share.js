let htmlTag = document.querySelector('html');
let htmlTagHeight = htmlTag.offsetHeight;
let viewHeight = document.getElementById('viewport').offsetHeight;
if (htmlTagHeight < viewHeight) {
    htmlTag.style.height = viewHeight + "px";
}


