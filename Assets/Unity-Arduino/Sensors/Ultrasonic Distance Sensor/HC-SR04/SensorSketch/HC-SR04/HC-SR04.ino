// Ultrasonic Distance Sensor

const int trigPin = 10;
const int echoPin = 13;
const float MS_TO_CMS = 1.0 / 29 / 2;

long cm;

void setup() {
  Serial.begin(9600);

  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
}

void loop() {
  
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  cm = pulseIn(echoPin, HIGH) * MS_TO_CMS;
  
  Serial.print(cm);
  Serial.println();

  delay(500);
}
