import urllib.request
import json
import pprint

obj = { 'APIPassword': 'qwerty' }
json_data = json.dumps(obj).encode('utf8')

url = 'http://localhost:18080/kabusapi/token'
req = urllib.request.Request(url, json_data, method='POST')
req.add_header('Content-Type', 'application/json')

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
