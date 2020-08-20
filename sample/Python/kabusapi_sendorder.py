import urllib.request
import json
import pprint

obj = { 'Password': '123456',
        'Symbol': '8001',
        'Exchange': 1,
        'SecurityType': 1,
        'FrontOrderType': 10,
        'TimeInForce': 0,
        'Side': '2',
        'CashMargin': 1,
        'MarginTradeType': 1,
        'DelivType': 2,
        'FundType': 'AA',
        'AccountType': 2,
        'Qty': 100,
        'ClosePositionOrder': 1,
        'ClosePositions': None,
        'Price': 0,
        'ExpireDay': 20200717 }
json_data = json.dumps(obj).encode('utf-8')

url = 'http://localhost:18080/kabusapi/sendorder'
req = urllib.request.Request(url, json_data, method='POST')
req.add_header('Content-Type', 'application/json')
req.add_header('X-API-KEY', 'e629f7e6073b40488d0d134dae4e60ac')

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
