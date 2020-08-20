var socket = new WebSocket('ws://localhost:18080/kabusapi/websocket');

// 接続時のイベント
socket.onopen = function (evt) {
  console.log('Connected');
};

// 切断時のイベント
socket.onclose = function (evt) {
  console.log('Disconnected: ' + evt.data);
};

// メッセージ受信時のイベント
socket.onmessage = function (evt) {
  console.log(evt.data);
};

// エラー発生時のイベント
socket.onerror = function (evt) {
  console.log('Error: ' + evt.data);
};
