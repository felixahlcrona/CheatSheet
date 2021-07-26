// https://k6.io/docs/getting-started/installation/
// API/http loadtesting
// Simply download binary https://dl.k6.io/msi/k6-latest-amd64.msi
// Write a test and open CMD in the same folder as test
// In CMD type " K6 run file.js" 

import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    //Virtual users
    vus: 10,
    duration: '5s'
};

// Make a GET request to your API
export default () => {
    http.get('https://localhost:44361/WeatherForecast/GetRequestSingleton')

};

