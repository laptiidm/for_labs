

# **Лабораторна робота №3**

**Тема:** Робота з Arduino. Керування світлодіодом (маячком).

---

## **1. Тема роботи**

Дослідження принципів роботи з цифровими виходами Arduino та створення програми для керування світлодіодом із використанням затримок.

---

## **2. Конкретні завдання**

### **Завдання 1:**

Зробити так, щоб маячок світився **0,5 секунди**, а пауза між спалахами дорівнювала **1 секунді**.

### **Завдання 2:**

Змінити код так, щоб маячок **вмикався на 3 секунди після запуску пристрою**, а потім **блимав у стандартному режимі** (як у завданні 1).

---

## **3. Коди програм**

### **Код до завдання 1 (0.5 c ON, 1 c OFF)**

```cpp
void setup() {
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  digitalWrite(LED_BUILTIN, HIGH);  // LED on
  delay(500);                      // 0.5 s

  digitalWrite(LED_BUILTIN, LOW);   // LED off
  delay(1000);                     // 1 s pause
}
```

---

### **Код до завдання 2 (після старту 3 c світиться, потім блимає)**

```cpp
void setup() {
  pinMode(LED_BUILTIN, OUTPUT);

  digitalWrite(LED_BUILTIN, HIGH);  // LED on 3 seconds at startup
  delay(3000);
}

void loop() {
  digitalWrite(LED_BUILTIN, HIGH);
  delay(500);

  digitalWrite(LED_BUILTIN, LOW);
  delay(1000);
}
```

---


