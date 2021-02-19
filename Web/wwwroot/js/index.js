let freeHeight = document.getElementById('viewport').offsetHeight;
let navbarHeight = document.querySelector('.navbar').offsetHeight;
let background_div = document.getElementById('hobbit-background-image');
background_div.style.height = freeHeight - navbarHeight + "px";