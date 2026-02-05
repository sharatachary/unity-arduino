// Flex Sensor - SpectraSymbol 0006 22 55

const int flexPin = A0;

void setup() {
  Serial.begin(9600);
}

void loop() {
  int flexValue = analogRead(flexPin);

  Serial.print("Flex value: ");
  Serial.println(flexValue);

  delay(100); // small delay for readability
}
