// const axios = require('axios').default;
//@ts-check
const features = Array.from(document.getElementsByName("feature"));
features.forEach(feature => {
    feature.addEventListener("change", evt => {
        // let houseCards = document.getElementById("houseCards");
        // houseCards.ad
        axios.get("/api/houses").then(({
            data
        }) => {
            let housesToDisplay = [];
            let checkedFeatures = features.filter(feature => feature.checked);
            if (checkedFeatures.length === 0) {
                housesToDisplay = data;
            } else {
                let featureValues = checkedFeatures.map(feature => feature.value);
                for (let i = 0; i < featureValues.length; i++) {
                    const featureId = Number(featureValues[i]);
                    for (let j = 0; j < data.length; j++) {
                        const house = data[j];
                        if (house.featuresId.some(id => id === featureId)) {
                            housesToDisplay.push(house);
                            data.splice(j, 1);
                            j = -1;
                        }
                    }
                }
            }
            return housesToDisplay;
        }).then(houses => {
            let houseCards = document.getElementById("houseCards");
            let numberFormatter = new Intl.NumberFormat("es-MX");
            let houseCardsList = "";
            houses.forEach(house => {
                houseCardsList +=
                    `<div class="col-lg-3 col-md-6 col-sm-6 mb-3">
                                <div class="card">
                                    <img src="${house.imageUrl}" class="card-img-top">
                                    <div class="card-body">
                                        <h3 class="card-title mb-2">₡${numberFormatter.format(house.price)}/month</h3>
                                        <h6 class="card-subtitle mb-2 text-muted"><i class="fas fa-bed"></i> ${house.bedrooms} Bedroom --- <i class="fas fa-toilet-paper"></i>
                                            ${house.bathrooms} Bathroom
                                        </h6>
                                        <p class="card-text"> ${house.name} - ${house.province.name} </p>
                                        <p class="card-text">  </p>
                                        <a href="${house.rentMeUrl}" class="btn btn-outline-primary btn-sm w-100 see-details-btn"><i
                                                class="fas fa-eye"></i> See more
                                            details</a>
                                    </div>
                                </div>
                         </div>`
            });
            houseCards.innerHTML = houseCardsList;
        });
    })
})






// // const axios = require('axios').default;
// //@ts-check
// const features = Array.from(document.getElementsByName("feature"));
// features.forEach(feature => {
//     feature.addEventListener("change", evt => {
//         if (evt.target.checked) {
//             let checkedFeatures = features.filter(feature => feature.checked);
//             let featureValues = checkedFeatures.map(feature => feature.value);
//             axios.get('/api/houses').then(result => {
//                 let houses = result.data;
//                 let filteredHouses = [];
//                 if (featureValues.length === 0) {
//                     filteredHouses = houses;
//                 } else {
//                     for (let i = 0; i < featureValues.length; i++) {
//                         const featureId = Number(featureValues[i]);
//                         for (let j = 0; j < houses.length; j++) {
//                             const house = houses[j];
//                             if (house.featuresId.some(id => id === featureId)) {
//                                 filteredHouses.push(house);
//                             }
//                         }

//                     }
//                 }

//                 return filteredHouses;
//             }).then(houses => {
//                 let houseCards = document.getElementById("houseCards");
//                 let numberFormatter = new Intl.NumberFormat("es-MX");
//                 let houseCardsList = "";
//                 houses.forEach(house => {
//                     houseCardsList +=
//                         `<div class="col-lg-3 col-md-6 col-sm-6 mb-3">
//                                 <div class="card">
//                                     <img src="${house.imageUrl}" class="card-img-top">
//                                     <div class="card-body">
//                                         <h3 class="card-title mb-2">₡${numberFormatter.format(house.price)}/month</h3>
//                                         <h6 class="card-subtitle mb-2 text-muted"><i class="fas fa-bed"></i> ${house.bedrooms} Bedroom --- <i class="fas fa-toilet-paper"></i>
//                                             ${house.bathrooms} Bathroom
//                                         </h6>
//                                         <p class="card-text"> ${house.name} - ${house.province.name} </p>
//                                         <p class="card-text">  </p>
//                                         <a href="${house.rentMeUrl}" class="btn btn-outline-primary btn-sm w-100"><i
//                                                 class="fas fa-eye"></i> See more
//                                             details</a>
//                                     </div>
//                                 </div>
//                          </div>`
//                 });
//                 houseCards.innerHTML = houseCardsList;
//             });
//         }
//     });
// });