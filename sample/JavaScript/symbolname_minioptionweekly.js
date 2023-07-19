var url = new URL('http://localhost:18080/kabusapi/symbolname/minioptionweekly');
url.searchParams.append('DerivMonth', 202306);
url.searchParams.append('DerivWeekly', 1);
url.searchParams.append('PutOrCall', 'P');
url.searchParams.append('StrikePrice', 27250);

var apikey = 'f643cf55b53843a08bcb5bf5b2f8b591';

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
