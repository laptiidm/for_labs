# **Лабораторна робота №6**

---

## **Мета роботи**

Запрограмувати три світлодіоди таким чином, щоб вони **послідовно перемикалися**,
а жовтий світлодіод **мигав тричі** у середині циклу.
Пояснити фізичні процеси, що при цьому відбуваються.

---

## **Обладнання**

* Arduino Uno
* 3 світлодіоди (червоний, жовтий, зелений)
* 3 резистори по 220 Ом
* Breadboard
* Провідники (male-male)
* Симулятор **Wokwi**

---

## **Принцип роботи**

1. **Зелений світлодіод** світиться протягом заданого інтервалу.
2. Після нього **жовтий світлодіод** три рази швидко блимає.
3. **Червоний світлодіод** світиться протягом заданого інтервалу.
4. Цикл повторюється нескінченно.

---

## **Схема підключення**

* Червоний LED → **Pin 13** через резистор
* Жовтий LED → **Pin 12** через резистор
* Зелений LED → **Pin 11** через резистор
* Катоди всіх світлодіодів → **GND**

---

## **Програма (sketch.ino)**

```cpp
#define RED_LED 13
#define YELLOW_LED 12
#define GREEN_LED 11

#define NORMAL_DELAY_MS 2000
#define BLINK_DELAY_MS 300
#define BLINK_COUNT 3

void setup() {
  pinMode(RED_LED, OUTPUT);
  pinMode(YELLOW_LED, OUTPUT);
  pinMode(GREEN_LED, OUTPUT);
  digitalWrite(RED_LED, LOW);
  digitalWrite(YELLOW_LED, LOW);
  digitalWrite(GREEN_LED, LOW);
}

void yellow_blink() {
  for (int i = 0; i < BLINK_COUNT; i++) {
    digitalWrite(YELLOW_LED, HIGH);
    delay(BLINK_DELAY_MS);
    digitalWrite(YELLOW_LED, LOW);
    delay(BLINK_DELAY_MS);
  }
}

void loop() {
  digitalWrite(GREEN_LED, HIGH);
  delay(NORMAL_DELAY_MS);
  digitalWrite(GREEN_LED, LOW);
  delay(500);

  yellow_blink();

  digitalWrite(RED_LED, HIGH);
  delay(NORMAL_DELAY_MS);
  digitalWrite(RED_LED, LOW);
  delay(500);
}
```

---

## **diagram.json (Wokwi)**

```json
{
  "version": 1,
  "author": "AI Assistant",
  "editor": "wokwi",
  "parts": [
    {
      "type": "wokwi-arduino-uno",
      "id": "uno",
      "top": 0,
      "left": 0
    },
    {
      "type": "wokwi-breadboard-half",
      "id": "bb1",
      "top": 150,
      "left": 100
    },
    {
      "type": "wokwi-led",
      "id": "led_red",
      "top": 170,
      "left": 200,
      "attrs": { "color": "red" }
    },
    {
      "type": "wokwi-resistor",
      "id": "res_red",
      "top": 150,
      "left": 230,
      "attrs": { "value": "220" }
    },
    {
      "type": "wokwi-led",
      "id": "led_yellow",
      "top": 170,
      "left": 260,
      "attrs": { "color": "yellow" }
    },
    {
      "type": "wokwi-resistor",
      "id": "res_yellow",
      "top": 150,
      "left": 290,
      "attrs": { "value": "220" }
    },
    {
      "type": "wokwi-led",
      "id": "led_green",
      "top": 170,
      "left": 320,
      "attrs": { "color": "green" }
    },
    {
      "type": "wokwi-resistor",
      "id": "res_green",
      "top": 150,
      "left": 350,
      "attrs": { "value": "220" }
    }
  ],
  "connections": [
    ["uno:GND.1", "bb1:black.neg", "black", ["v-65", "h200"]],

    ["uno:13", "res_red:1", "red"],
    ["res_red:2", "led_red:A", "red"],
    ["led_red:C", "bb1:black.neg", "black"],

    ["uno:12", "res_yellow:1", "yellow"],
    ["res_yellow:2", "led_yellow:A", "yellow"],
    ["led_yellow:C", "bb1:black.neg", "black"],

    ["uno:11", "res_green:1", "green"],
    ["res_green:2", "led_green:A", "green"],
    ["led_green:C", "bb1:black.neg", "black"]
  ]
}
```

---

## **Фізичні процеси, що спостерігаються**

* При подачі напруги на анод світлодіода струм проходить через p-n перехід, у якому відбувається рекомбінація електронів і дірок.
* Цей процес супроводжується випромінюванням фотонів — світінням.
* Затримки (`delay()`) створюють часові інтервали включення/вимкнення.
* Швидке вмикання/вимикання (мерехтіння) створює періодичне світіння з видимою пульсацією.

---

## **Висновки**

У даній роботі було реалізовано керування трьома світлодіодами, які вмикаються послідовно, а жовтий — додатково мерехтить.
Під час роботи було вивчено фізичні процеси у світлодіодах та застосовано принципи часових затримок у мікроконтролерах.

---

Якщо хочеш — можу підготувати PDF або зробити ще компактнішу версію звіту.
