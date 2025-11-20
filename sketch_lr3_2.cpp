// LED: 3 секунди постійно, потім блимає
// ON 0.5s, OFF 1s

void setup() {
  pinMode(LED_BUILTIN, OUTPUT);

  // після запуску – світиться 3 секунди
  digitalWrite(LED_BUILTIN, HIGH);
  delay(3000);                
}

void loop() {
  // стандартний режим блимання як у прикладі з 1ї частини
  digitalWrite(LED_BUILTIN, HIGH);  
  delay(500);                       

  digitalWrite(LED_BUILTIN, LOW);   
  delay(1000);                      
}
