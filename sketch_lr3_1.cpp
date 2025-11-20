bool blinking = false;
unsigned long prev = 0;
bool ledState = false;

void setup() {
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  if (Serial.available()) {
    char c = Serial.read();
    if (c == 's') blinking = true;
    if (c == 'x') {
      blinking = false;
      digitalWrite(LED_BUILTIN, LOW);
    }
  }

  if (!blinking) return;

  if (millis() - prev >= (ledState ? 500 : 1000)) {
    prev = millis();
    ledState = !ledState;
    digitalWrite(LED_BUILTIN, ledState);
  }
}
