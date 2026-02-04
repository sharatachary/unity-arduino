// Rotatory Encoder. - HW-040

#define CLK 2
#define DT  3
#define SW  4

int counter = 0;

// Encoder debounce
int lastCLK;
unsigned long lastEncTime = 0;
const unsigned long encDebounce = 5; // ms

// Button debounce
int lastBtnState = HIGH;
unsigned long lastBtnTime = 0;
const unsigned long btnDebounce = 50; // ms

int dir = 0;

void setup() {
  Serial.begin(9600);

  pinMode(CLK, INPUT_PULLUP);
  pinMode(DT, INPUT_PULLUP);
  pinMode(SW, INPUT_PULLUP);

  lastCLK = digitalRead(CLK);

  Serial.println("Rotary Encoder Ready");
}

void loop() {
  handleEncoder();
  handleButton();
}

// ================= ENCODER =================
void handleEncoder() {
  int currentCLK = digitalRead(CLK);
  dir = 0;

  if (currentCLK != lastCLK) {
    if (millis() - lastEncTime > encDebounce) {
      if (digitalRead(DT) != currentCLK) {
        dir = 1;
      } else {
        dir = -1;
      }
      counter += dir;
      
      Serial.print(dir);
      Serial.print("|");
      Serial.println(counter);

      lastEncTime = millis();
    }
  }

  lastCLK = currentCLK;
}

// ================= BUTTON =================
void handleButton() {
  int btnState = digitalRead(SW);

  if (btnState != lastBtnState) {
    if (millis() - lastBtnTime > btnDebounce) {
      if (btnState == LOW) {
        Serial.println("Button Pressed");
      }
      lastBtnTime = millis();
    }
  }

  lastBtnState = btnState;
}

