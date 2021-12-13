// Global Variables
const Validator = require("../../lib/node_modules/validatorjs");

let stepper;
document.addEventListener("DOMContentLoaded", function () {
  stepper = new Stepper(document.querySelector(".bs-stepper"));
});
document.getElementById("previous-btn").addEventListener("click", (evt) => {
  stepper.to(1);
});
// Luxon
const DateTime = luxon.DateTime;
// Flatpickr instance
const fpInstance = flatpickr("#From", {
  defaultDate: "today",
  dateFormat: "m.d.Y",
  minDate: "today",
  maxDate: new Date().fp_incr(7), // 14 days from now
});
// Card
var card = new Card({
  // a selector or DOM element for the form where users will
  // be entering their information
  form: document.getElementById("credit-card-form"), // *required*
  // a selector or DOM element for the container
  // where you want the card to appear
  container: ".card-wrapper", // *required*

  formSelectors: {
    numberInput: "input#number", // optional — default input[name="number"]
    expiryInput: "input#expiry", // optional — default input[name="expiry"]
    cvcInput: "input#cvc", // optional — default input[name="cvc"]
    nameInput: "input#name", // optional - defaults input[name="name"]
  },

  width: "100%", // optional — default 350px
  formatting: true, // optional - default true

  // Strings for translation - optional
  messages: {
    validDate: "valid\nthru", // optional - default 'valid\nthru'
    monthYear: "mm/yyyy", // optional - default 'month/year'
  },

  // Default placeholders for rendered fields - optional
  placeholders: {
    number: "•••• •••• •••• ••••",
    name: "Full Name",
    expiry: "••/••",
    cvc: "•••",
  },

  masks: {
    cardNumber: "•", // optional - mask card number
  },
});

// Inputs
const fromInput = document.getElementById("From");

const toInput = document.getElementById("To");

const monthsInput = document.getElementById("Months");

const changeDate = (dateStr) => {
  // To
  let monthsToStay = Number(monthsInput.value);
  let toDate = DateTime.fromFormat(dateStr, "MM.dd.yyyy").plus({
    months: monthsToStay,
  });
  toInput.value = toDate.toFormat("MM.dd.yyyy");
};
const changeCosts = () => {
  const houseId = document.getElementById("HouseId").value;
  const nMonths = Number(monthsInput.value);
  const selectedServices = Array.from(
    document.querySelectorAll("input[name=service]:checked")
  );
  const servicesId = selectedServices.map((s) => s.value);
  let queryString = `/api/generateInvoice?houseId=${houseId}&monthsToStay=${nMonths}`;
  servicesId.forEach((serviceId) => (queryString += `&service=${serviceId}`));
  axios.get(queryString).then(({ data }) => {
    document.getElementById("homeSubTotal").textContent = currency(
      data.homeSubTotal
    ).format();
    document.getElementById("serviceSubTotal").textContent = currency(
      data.serviceSubTotal
    ).format();
    document.getElementById("subTotal").textContent = currency(
      data.subTotal
    ).format();
    document.getElementById("tax").textContent = currency(data.tax).format();
    document.getElementById("total").textContent = currency(
      data.total
    ).format();
  });
};

const changeDateAndCosts = () => {
  changeDate(fromInput.value);
  changeCosts();
};

const rent_details_validation = (e) => {
  data = {
    from: fromInput.value,
    months: monthsInput.value,
  };
  rules = {
    from: "required",
    months: "required|integer|min:1",
  };
  validation = new Validator(data, rules);
  if (validation.fails()) {
    const from = validation.errors.get("from");
    const months = validation.errors.get("months");
    if (from.length > 0) {
      fromInput.classList.add("is-invalid");
      document.getElementById("from-error-message").textContent = from[0];
    } else {
      fromInput.classList.remove("is-invalid");
      document.getElementById("from-error-message").innerText = "";
    }
    if (months.length > 0) {
      monthsInput.classList.add("is-invalid");
      document.getElementById("months-error-message").innerText = months[0];
    } else {
      monthsInput.classList.remove("is-invalid");
      document.getElementById("months-error-message").textContent = "";
    }
  } else {
    fromInput.classList.remove("is-invalid");
    monthsInput.classList.remove("is-invalid");
    stepper.next();
  }
};
document
  .getElementById("next-btn")
  .addEventListener("click", rent_details_validation);

// Events
// From value has changed so we change to value
fpInstance.config.onChange.push((selectedDates, dateStr, instance) => {
  changeDate(dateStr);
});
// Customer is changing the months input value, so we updated to and costs
monthsInput.addEventListener("change", changeDateAndCosts);
// Services checkbox has changed
Array.from(document.getElementsByName("service")).forEach((s) =>
  s.addEventListener("change", changeDateAndCosts)
);

// Remove gray background color in from input
fromInput.style.backgroundColor = "#fff";
// fromInput.readOnly = false;

document.getElementById("confirmation-btn").addEventListener("click", (evt) => {
  const card_number = document.getElementById("number");
  const name_on_card = document.getElementById("name");
  const expiry_date = document.getElementById("expiry");
  const security_code = document.getElementById("cvc");

  data = {
    card_number: card_number.value,
    name_on_card: name_on_card.value,
    expiry_date: expiry_date.value,
    security_code: security_code.value,
  };
  rules = {
    card_number: "required",
    name_on_card: "required",
    expiry_date: "required",
    security_code: "required",
  };
  validation = new Validator(data, rules);
  if (validation.passes()) {
    return document.getElementById("rent-form").submit();
  }
  //   const get_error = validation.errors.get;
  const card_number_error = validation.errors.first("card_number");
  const name_on_card_error = validation.errors.first("name_on_card");
  const expiry_date_error = validation.errors.first("expiry_date");
  const security_code_error = validation.errors.first("security_code");
  if (card_number_error) {
    card_number.classList.add("is-invalid");
    card_number.parentElement.querySelector(".invalid-feedback").innerText =
      card_number_error;
  } else {
    card_number.classList.remove("is-invalid");
  }
  if (name_on_card_error) {
    name_on_card.classList.add("is-invalid");
    name_on_card.parentElement.querySelector(".invalid-feedback").innerText =
      name_on_card_error;
  } else {
    name_on_card.classList.remove("is-invalid");
  }
  if (expiry_date_error) {
    expiry_date.classList.add("is-invalid");
    expiry_date.parentElement.querySelector(".invalid-feedback").innerText =
      expiry_date_error;
  } else {
    expiry_date.classList.remove("is-invalid");
  }
  if (security_code_error) {
    security_code.classList.add("is-invalid");
    security_code.parentElement.querySelector(".invalid-feedback").innerText =
      security_code_error;
  } else {
    security_code.classList.remove("is-invalid");
  }
});
