var url = new URL('http://localhost:18080/kabusapi/symbolname/future');
url.searchParams.append('FutureCode', 'NK225');
url.searchParams.append('DerivMonth', 202012);

var apikey = '4e34e8aae72542e9afa0ce67d483eeee';

fetch(url, {
  method: 'GET',
  headers: {
    'Content-Type': 'application/json',
    'X-API-KEY': apikey,
  }
})
  .then(response => {
    if (response.ok) {
      console.log(response.status, response.statusText);
      for (var pair of response.headers.entries()) {
         console.log(pair[0] + ': ' + pair[1]);
      }
      response.json().then(data => {console.log(data)});
    } else {
      console.log(response.status, response.statusText);
      response.json().then(data => {console.log(data)});
    }
  })
  .catch(e => {
    console.log(e.message);
  });
