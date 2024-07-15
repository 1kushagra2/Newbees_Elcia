package com.example.atry;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.namespace.R;

import org.java_websocket.client.WebSocketClient;
import org.java_websocket.handshake.ServerHandshake;
import java.net.URI;
import java.net.URISyntaxException;

public class MainActivity extends AppCompatActivity {

    private WebSocketClient mWebSocketClient;
    private Button button1, button2, button3;
    private TextView timerTextView;
    private boolean isTimerRunning = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        button1 = findViewById(R.id.button1);
        button2 = findViewById(R.id.button2);
        button3 = findViewById(R.id.button3);
        timerTextView = findViewById(R.id.timerTextView);

        button1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isTimerRunning) {
                    sendWebSocketMessage("option=1");
                    startTimer(10000); // 10 seconds timer
                }
            }
        });

        button2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isTimerRunning) {
                    sendWebSocketMessage("option=2");
                    startTimer(10000); // 10 seconds timer
                }
            }
        });

        button3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isTimerRunning) {
                    sendWebSocketMessage("option=3");
                    startTimer(10000); // 10 seconds timer
                }
            }
        });

        connectWebSocket();
    }

    private void connectWebSocket() {
        URI uri;
        try {
            uri = new URI("ws://192.168.84.128:81");
        } catch (URISyntaxException e) {
            e.printStackTrace();
            return;
        }

        mWebSocketClient = new WebSocketClient(uri) {
            @Override
            public void onOpen(ServerHandshake handshakedata) {
                Log.i("WebSocket", "Opened");
            }

            @Override
            public void onMessage(String message) {
                Log.i("WebSocket", "Received: " + message);
            }

            @Override
            public void onClose(int code, String reason, boolean remote) {
                Log.i("WebSocket", "Closed: " + reason);
            }

            @Override
            public void onError(Exception ex) {
                Log.i("WebSocket", "Error: " + ex.getMessage());
            }
        };
        mWebSocketClient.connect();
    }

    private void sendWebSocketMessage(String message) {
        if (mWebSocketClient != null && mWebSocketClient.isOpen()) {
            mWebSocketClient.send(message);
        }
    }

    private void startTimer(long milliseconds) {
        isTimerRunning = true;
        disableButtons();
        new CountDownTimer(milliseconds, 1000) {

            public void onTick(long millisUntilFinished) {
                timerTextView.setText("seconds remaining: " + millisUntilFinished / 1000);
            }

            public void onFinish() {
                timerTextView.setText("Done!");
                isTimerRunning = false;
                enableButtons();
            }
        }.start();
    }

    private void disableButtons() {
        button1.setEnabled(false);
        button2.setEnabled(false);
        button3.setEnabled(false);
    }

    private void enableButtons() {
        button1.setEnabled(true);
        button2.setEnabled(true);
        button3.setEnabled(true);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (mWebSocketClient != null) {
            mWebSocketClient.close();
        }
    }
}
