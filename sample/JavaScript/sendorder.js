var data = {
  'Password': '123456',
  'Symbol': '8001',
  'Exchange': 1,
  'SecurityType': 1,
  'FrontOrderType': 10,
  'Side': '2',
  'CashMargin': 1,
  'DelivType': 2,
  'FundType': 'AA',
  'AccountType': 2,
  'Qty': 300,
  'Price': 0,
  'ExpireDay': 20200715
}
var url = 'http://localhost:18080/kabusapi/sendorder';
var apikey = 'a68e2d55951b4756a3131f7942974eeb';

fetch(url, {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
    'X-API-KEY': apikey,
  },
  body: JSON.stringify(data)
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
