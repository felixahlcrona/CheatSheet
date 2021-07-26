// https://k6.io/docs/getting-started/installation/
// API/http loadtesting
// Simply download binary https://dl.k6.io/msi/k6-latest-amd64.msi
// Write a test and open CMD in the same folder as test
// In CMD type " K6 run file.js" 

import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '2m', target: 100 }, // below normal load
        { duration: '5m', target: 100 },
        { duration: '2m', target: 200 }, // normal load
        { duration: '5m', target: 200 },
        { duration: '2m', target: 300 }, // Around breaking point
        { duration: '5m', target: 300 },
        { duration: '10m', target: 0 }, // Scale down, 
    ],
};

const API_BASE_URL = 'https://localhost:44361/';

export default () => {
    http.batch([
        ['GET', `${API_BASE_URL}/GetRequestSingleton`],
        ['GET', `${API_BASE_URL}/GetRequestNewInstance`],
    ]);
};
