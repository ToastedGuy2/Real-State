const notyf = new Notyf({
    position: {
        x: 'right',
        y: 'top',
    }
});
notyf.success("Transaction Complete");

document.getElementById('rent-link').classList.add('current');
