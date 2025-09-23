/*
Програма-компас для micro:bit

- basic.forever(...)  -> нескінченний цикл (аналог блоку "постійно")
- input.compassHeading() -> читає напрям у градусах (0..359), -1003 = помилка/потрібна калібровка
- if/else -> ділимо коло на сектори по 90°: N, E, S, W
- basic.showString("N") -> виводить букву на LED-дисплеї (можна замінити на showArrow)
- basic.pause(1000) -> пауза, щоб зменшити мерехтіння і частоту оновлення
*/

basic.forever(function () {
    let direction = input.compassHeading()
    if (direction < 45 || direction > 315) {
        basic.showString("N")
    } else if (direction < 135) {
        basic.showString("E")
    } else if (direction < 225) {
        basic.showString("S")
    } else {
        basic.showString("W")
    }
    basic.pause(1000)
})



