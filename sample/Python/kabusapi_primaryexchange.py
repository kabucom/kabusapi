import urllib.request
import json
import pprint

url = 'http://localhost:18080/kabusapi/primaryexchange/9433'
req = urllib.request.Request(url, method='GET')
req.add_header('Content-Type', 'application/json')
req.add_header('X-API-KEY', '43e7cc3611fd476db35e93c36a3f77ef')

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