// Global Variables

// Libraries
// Luxon
const DateTime = luxon.DateTime;
// Flatpickr instance

const fpInstance = flatpickr("#From", {
    defaultDate: "today",
    dateFormat: "m.d.Y",
    minDate: "today",
    maxDate: new Date().fp_incr(14) // 14 days from now
});
// Inputs
const fromInput = document.getElementById('From');

const toInput = document.getElementById('To');

const monthsInput = document.getElementById('Months');

// Spans for costs
const subTotalSpan = document.getElementById('subTotal');
const ivaSpan = document.getElementById('iva');
const totalSpan = document.getElementById('total');

// Default values
const housePrice = parseFloat(document.getElementById('House_Price').value);
let nodeServices = document.getElementsByName('service');
let serviceList = Array.prototype.slice.call(nodeServices)


const changeCosts = () => {
    subTotalSpan.textContent = "$" + currency(rentSubTotal());
    ivaSpan.textContent = "$" + currency(rentIva());
    totalSpan.textContent = "$" + currency(rentTotal());
}

const changeDate = dateStr => {
    // To
    let monthsToStay = Number(monthsInput.value)
    let toDate = DateTime.fromFormat(dateStr, "MM.dd.yyyy").plus({
        months: monthsToStay
    });
    toInput.value = toDate.toFormat('MM.dd.yyyy');
}

const changeDateAndCosts = () => {
    changeDate(fromInput.value);
    changeCosts();
}

// Events
// From value has changed so we change to value
fpInstance.config.onChange.push((selectedDates, dateStr, instance) => {
    changeDate(dateStr);

})
// Customer is changing the months input value, so we updated to and costs
monthsInput.addEventListener('change', changeDateAndCosts);
// Services checkbox has changed
serviceList.forEach(s => s.addEventListener('change', changeDateAndCosts));




// Remove gray background color in from input
fromInput.style.backgroundColor = "#fff";