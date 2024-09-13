import urllib.request
import json
import pprint

obj = { 'Symbol': '5104',
        'Exchange': 1,
        'SecurityType': 1,
        'Side': '1',
        'CashMargin': 2,
        'MarginTradeType': 3,
        'MarginPremiumUnit': 422,
        'DelivType': 0,
        'AccountType': 2,
        'Qty': 100,
        'FrontOrderType': 20,
        'Price': 425,
        'ExpireDay': 0
      }
json_data = json.dumps(obj).encode('utf-8')

url = 'http://localhost:18080/kabusapi/sendorder'
req = urllib.request.Request(url, json_data, method='POST')
req.add_header('Content-Type', 'application/json')
req.add_header('X-API-KEY', '08894aa62c7b4624858cf5fe2efc184e')

try:
    with urllib.request.urlopen(req) as res:
        print(res.status, res.reason)
        for header in res.getheaders():
            print(header)
        print()
        content = json.loads(res.read())
        pprint.pprint(content)
except urllib.error.HTTPError as e:
    print(e)
    content = json.loads(e.read())
    pprint.pprint(content)
except Exception as e:
    print(e)
