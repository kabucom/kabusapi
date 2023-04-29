import urllib.request
import json
import pprint

obj = { 'Password': '123456',
        'Symbol': '9433',
        'Exchange': 1,
        'SecurityType': 1,
        'Side': '1',
        'CashMargin': 3,
        'MarginTradeType': 1,
        'DelivType': 2,
        'AccountType': 2,
        'Qty': 200,
        'ClosePositions': [
                            {'HoldID':'E20200924*****','Qty':100},
                            {'HoldID':'E20200924*****','Qty':100}
                          ],
        'FrontOrderType': 30,
        'Price': 2762.5,
        'ExpireDay': 0,
        'ReverseLimitOrder': {
                               'TriggerSec': 2, #1.発注銘柄 2.NK225指数 3.TOPIX指数
                               'TriggerPrice': 30000,
                               'UnderOver': 2, #1.以下 2.以上
                               'AfterHitOrderType': 2, #1.成行 2.指値 3. 不成
                               'AfterHitPrice': 8435
                               }
       }
json_data = json.dumps(obj).encode('utf-8')

url = 'http://localhost:18080/kabusapi/sendorder'
req = urllib.request.Request(url, json_data, method='POST')
req.add_header('Content-Type', 'application/json')
req.add_header('X-API-KEY', 'ed94b0d34f9441c3931621e55230e402')

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
