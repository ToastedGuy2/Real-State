// const axios = require('axios').default;
//@ts-check
const features = Array.from(document.getElementsByClassName("form-check-input"));
features.forEach(feature => {
    feature.addEventListener("change", evt => {
        axios.get('/api/houses').then(({
            data
        }) => {
            let filterList = []; // Filter house list
            let selectedFeatures = Array.from(document.querySelectorAll('input[name=feature]:checked')).map(f => f.value);
            selectedFeatures.forEach(feature => {
                for (let i = 0; i < data.length; i++) {
                    const house = data[i];
                    if (house.features.includes(feature)) {
                        filterList.push(house)
                        data.splice(i, 1);
                        i--;
                    }
                }
            });
            let selectedProvinces = Array.from(document.querySelectorAll('input[name=province]:checked')).map(p => p.value);
            selectedProvinces.forEach(province => {
                for (let i = 0; i < data.length; i++) {
                    const house = data[i];
                    if (house.province === province) {
                        filterList.push(house)
                        data.splice(i, 1);
                        i--;
                    }
                }
            });
            if (selectedFeatures.length === 0 && selectedProvinces.length === 0) {
                filterList = data;
            }
            filterList = filterList.sort((a, b) => a.price - b.price);
            console.log(filterList)

        });
        // .catch((err) => {
        //     const notyf = new Notyf({
        //         position: {
        //             x: 'right',
        //             y: 'top',
        //         }
        //     });
        //     notyf.error("Oops, something gone wrong, please refresh the page!!!")
        // });
    })
})


document.getElementById('rent-link').classList.add('current-page');