var url = new URL('http://localhost:18080/kabusapi/positions');
url.searchParams.append('product', 0);     // product - 0:すべて、1:現物、2:信用、3:先物、4:OP
// url.searchParams.append('symbol', '9433'); // symbol='xxxx'
var apikey = 'a68e2d55951b4756a3131f7942974eeb';

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
