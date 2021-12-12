// const axios = require('axios').default;
//@ts-check
const features = Array.from(
  document.getElementsByClassName("form-check-input")
);
features.forEach((feature) => {
  feature.addEventListener("change", (evt) => {
    axios
      .get("/api/houses")
      .then(({ data }) => {
        let filterList = []; // Filter house list
        let selectedFeatures = Array.from(
          document.querySelectorAll("input[name=feature]:checked")
        ).map((f) => f.value);
        selectedFeatures.forEach((feature) => {
          for (let i = 0; i < data.length; i++) {
            const house = data[i];
            if (house.features.includes(feature)) {
              filterList.push(house);
              data.splice(i, 1);
              i--;
            }
          }
        });
        let selectedProvinces = Array.from(
          document.querySelectorAll("input[name=province]:checked")
        ).map((p) => p.value);
        selectedProvinces.forEach((province) => {
          for (let i = 0; i < data.length; i++) {
            const house = data[i];
            if (house.province === province) {
              filterList.push(house);
              data.splice(i, 1);
              i--;
            }
          }
        });
        if (selectedFeatures.length === 0 && selectedProvinces.length === 0) {
          filterList = data;
        }
        filterList = filterList.sort((a, b) => a.price - b.price);

        let card_list = filterList.reduce((accumulator, current) => {
          return (
            accumulator +
            `<div class="col-sm-6 col-md-12 col-lg-6 col-xl-4 mb-3">
                    <div class="card">
                        <img src="${current.imageUrl}" class="card-img-top">
                        <div class="card-body">
                            <input type="hidden" name="houseId" value="${
                              current.houseId
                            }">
                            <h2 class="card-title secondary-color mb-2">${currency(
                              current.price
                            ).format()}</h2>
                            <p class="card-subtitle mb-2 d-flex">
                                <span><i class="fas fa-bed"></i> ${
                                  current.bedrooms
                                } Bd</span> 
                                <span class="mx-1 mx-md-2"><i class="fas fa-toilet-paper"></i> ${
                                  current.bathrooms
                                } Ba </span>
                                <span><i class="fas fa-ruler-combined"></i> ${
                                  current.size
                                } sqft</span>
                            </p>
                            <p class="card-text"> <span><i class="fas fa-search-location"></i> ${
                              current.province
                            }</span> </p>
                                <div class="d-flex justify-content-end align-items-center">
                                    <div>
                                        <a href="/Rent/House/${
                                          current.houseId
                                        }" class="btn btn-danger"><i
                                            class="fas fa-truck-moving"></i> Rent</a>
                                        <a href="/House/Details/${
                                          current.houseId
                                        }" class="btn btn-outline-info"><i
                                            class="fas fa-info-circle"></i> Info</a>
                                    </div>
                                </div>
                        </div>
                    </div>
            </div>`
          );
        }, "");
        document.getElementById("house-list").innerHTML = card_list;

        Array.from(document.getElementsByClassName("card")).forEach((card) => {
          card.addEventListener("click", (event) => {
            let selectedCard = event.currentTarget;
            let inputId = selectedCard.children[1].children[0];
            let active_card = document.querySelector(".card-active");
            if (active_card !== null) {
              active_card.classList.remove("card-active");
            }
            selectedCard.classList.add("card-active");
            axios.get(`/api/houses/${inputId.value}`).then(({ data }) => {
              document
                .getElementById("home-details-example")
                .classList.remove("d-flex");
              document
                .getElementById("home-details-example")
                .classList.add("d-none");
              document
                .getElementById("home-details")
                .classList.remove("d-none");
              document.getElementById("home-details").classList.add("d-block");

              document.getElementById("home-picture").src = data.imageUrl;
              document.getElementById("home-name").innerHTML = data.name;
              document.getElementById("home-price").innerHTML = currency(
                data.price
              ).format();
              document.getElementById("home-description").innerHTML =
                data.description;
              document.getElementById("home-bedrooms").innerHTML =
                data.bedrooms;
              document.getElementById("home-bathrooms").innerHTML =
                data.bathrooms;
              document.getElementById("home-size").innerHTML =
                data.size + " sqft";
              document.getElementById("home-province").innerHTML =
                data.province;
            });
          });
        });
      }) //;
      .catch((err) => {
        const notyf = new Notyf({
          position: {
            x: "right",
            y: "top",
          },
        });
        notyf.error("Oops, Something gone wrong, please refresh the page!!!");
      });
  });
});

document.getElementById("rent-link").classList.add("current-page");
Array.from(document.getElementsByClassName("card")).forEach((card) => {
  card.addEventListener("click", (event) => {
    let selectedCard = event.currentTarget;
    let inputId = selectedCard.children[1].children[0];
    let active_card = document.querySelector(".card-active");
    if (active_card !== null) {
      active_card.classList.remove("card-active");
    }
    selectedCard.classList.add("card-active");
    axios.get(`/api/houses/${inputId.value}`).then(({ data }) => {
      document
        .getElementById("home-details-example")
        .classList.remove("d-flex");
      document.getElementById("home-details-example").classList.add("d-none");
      document.getElementById("home-details").classList.remove("d-none");
      document.getElementById("home-details").classList.add("d-block");

      document.getElementById("home-picture").src = data.imageUrl;
      document.getElementById("home-name").innerHTML = data.name;
      document.getElementById("home-price").innerHTML = currency(
        data.price
      ).format();
      document.getElementById("home-description").innerHTML = data.description;
      document.getElementById("home-bedrooms").innerHTML = data.bedrooms;
      document.getElementById("home-bathrooms").innerHTML = data.bathrooms;
      document.getElementById("home-size").innerHTML = data.size + " sqft";
      document.getElementById("home-province").innerHTML = data.province;
    });
  });
});
document.querySelector(".card").click();
const dropdown_menu_event = (e) => {
  const t = e.target;
  const checkbox = t.querySelector("input");
  console.log(checkbox);
  console.log(checkbox.value);
};
Array.from(document.querySelectorAll(".dropdown-menu")).forEach((i) => {
  i.addEventListener("click", dropdown_menu_event);
});
// Array.from(document.querySelectorAll(".dropdown-menu form")).forEach((i) => {
//   i.addEventListener("click", dropdown_menu_event);
// });
