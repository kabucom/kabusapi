import urllib.request
import json
import pprint

url = 'http://localhost:18080/kabusapi/orders'
params = { 'product': 0 }               # product - 0:すべて、1:現物、2:信用、3:先物、4:OP
#params['id'] = '20201207A02N04830518' # id='xxxxxxxxxxxxxxxxxxxx'
#params['updtime'] = 20201101123456    # updtime=yyyyMMddHHmmss
#params['details'] =  'false'          # details='true'/'false'
#params['symbol'] = '9433'             # symbol='xxxx'
#params['state'] = 5                   # state - 1:待機（発注待機）、2:処理中（発注送信中）、3:処理済（発注済・訂正済）、4:訂正取消送信中、5:終了（発注エラー・取消済・全約定・失効・期限切れ）
#params['side'] = '2'                  # side - '1':売、'2':買
#params['cashmargin'] = 3              # cashmargin - 2:新規、3:返済

req = urllib.request.Request('{}?{}'.format(url, urllib.parse.urlencode(params)), method='GET')
req.add_header('Content-Type', 'application/json')
req.add_header('X-API-KEY', '37b96984a496419ebc2abcffa29728d4')

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
