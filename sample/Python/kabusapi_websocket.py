import sys
import websocket
import _thread

def on_message(ws, message):
    print('--- RECV MSG. --- ')
    print(message)

def on_error(ws, error):
    print('--- ERROR --- ')
    print(error)

def on_close(ws):
    print('--- DISCONNECTED --- ')

def on_open(ws):
    print('--- CONNECTED --- ')
    def run(*args):
        while(True):
            line = sys.stdin.readline()
            if line != '':
                print('closing...')
                ws.close()
    _thread.start_new_thread(run, ())

url = 'ws://localhost:18080/kabusapi/websocket'
# websocket.enableTrace(True)
ws = websocket.WebSocketApp(url,
                          on_message = on_message,
                          on_error = on_error,
                          on_close = on_close)
ws.on_open = on_open
ws.run_forever()
