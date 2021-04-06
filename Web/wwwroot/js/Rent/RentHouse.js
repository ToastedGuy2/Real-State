// Global Variables
let stepper;
document.addEventListener('DOMContentLoaded', function () {
    stepper = new Stepper(document.querySelector('.bs-stepper'))
})
document.getElementById('next-btn').addEventListener('click', evt => {
    stepper.next()
});
document.getElementById('previous-btn').addEventListener('click', evt => {
    stepper.to(1);
});
// Luxon
const DateTime = luxon.DateTime;
// Flatpickr instance
const fpInstance = flatpickr("#From", {
    defaultDate: "today",
    dateFormat: "m.d.Y",
    minDate: "today",
    maxDate: new Date().fp_incr(7) // 14 days from now
});
// Card
var card = new Card({
    // a selector or DOM element for the form where users will
    // be entering their information
    form: document.getElementById('credit-card-form'), // *required*
    // a selector or DOM element for the container
    // where you want the card to appear
    container: '.card-wrapper', // *required*

    formSelectors: {
        numberInput: 'input#number', // optional — default input[name="number"]
        expiryInput: 'input#expiry', // optional — default input[name="expiry"]
        cvcInput: 'input#cvc', // optional — default input[name="cvc"]
        nameInput: 'input#name' // optional - defaults input[name="name"]
    },

    width: '100%', // optional — default 350px
    formatting: true, // optional - default true

    // Strings for translation - optional
    messages: {
        validDate: 'valid\nthru', // optional - default 'valid\nthru'
        monthYear: 'mm/yyyy', // optional - default 'month/year'
    },

    // Default placeholders for rendered fields - optional
    placeholders: {
        number: '•••• •••• •••• ••••',
        name: 'Full Name',
        expiry: '••/••',
        cvc: '•••'
    },

    masks: {
        cardNumber: '•' // optional - mask card number
    },

});


// Inputs
const fromInput = document.getElementById('From');

const toInput = document.getElementById('To');

const monthsInput = document.getElementById('Months');

const changeDate = dateStr => {
    // To
    let monthsToStay = Number(monthsInput.value)
    let toDate = DateTime.fromFormat(dateStr, "MM.dd.yyyy").plus({
        months: monthsToStay
    });
    toInput.value = toDate.toFormat('MM.dd.yyyy');
}
const changeCosts = () => {
    const houseId = document.getElementById('HouseId').value;
    const nMonths = Number(monthsInput.value);
    const selectedServices = Array.from(document.querySelectorAll('input[name=service]:checked'))
    const servicesId = selectedServices.map(s => s.value);
    let queryString = `/api/generateInvoice?houseId=${houseId}&monthsToStay=${nMonths}`;
    servicesId.forEach(serviceId => queryString += `&service=${serviceId}`);
    axios.get(queryString).then(({
        data
    }) => {
        document.getElementById('homeSubTotal').textContent = currency(data.homeSubTotal).format();
        document.getElementById('serviceSubTotal').textContent = currency(data.serviceSubTotal).format();
        document.getElementById('subTotal').textContent = currency(data.subTotal).format();
        document.getElementById('tax').textContent = currency(data.tax).format();
        document.getElementById('total').textContent = currency(data.total).format();
    });
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
Array.from(document.getElementsByName('service')).forEach(s => s.addEventListener('change', changeDateAndCosts));

// Remove gray background color in from input
fromInput.style.backgroundColor = "#fff";
// fromInput.readOnly = false;

document.getElementById('confirmation-btn').addEventListener('click', evt => {
    document.getElementById('rent-form').submit();
});

// function isMonthInputValid() {
//     let months = fromInput.value;
//     if (months === "") {
//         return false;
//     }
//     if (months)

// }