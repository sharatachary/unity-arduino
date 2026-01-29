// Touch Sensor

const int touchPin = 2;

void setup() {
  Serial.begin(9600);
  pinMode(touchPin, INPUT);
}

void loop() {
  int touchState = digitalRead(touchPin);

  if (touchState == HIGH) {
    Serial.println(1);   // touch detected
  } else {
    Serial.println(0);   // no touch
  }

  delay(100);
}