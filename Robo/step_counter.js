/*
лічильник кроків

- змінна steps -> зберігає кількість кроків
- input.onGesture(Gesture.Shake, ...) -> виконується, коли micro:bit "трясуть"
- steps += 1 -> збільшує лічильник на 1
- basic.showNumber(steps) -> показує поточне значення на LED-дисплеї
*/

let steps = 0

input.onGesture(Gesture.Shake, function () {
    steps += 1
    basic.showNumber(steps)
})