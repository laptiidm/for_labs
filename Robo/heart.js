/**
 * мигаюче серце
 * 
 * - basic.forever(...) -> нескінченний цикл
 * 
 * - basic.showIcon(IconNames.Heart) -> показує іконку "серце"
 * 
 * - basic.pause(500) -> затримка 0,5 сек
 * 
 * - basic.clearScreen() -> гасить екран
 * 
 * - знову пауза -> створює ефект миготіння
 */
basic.forever(function () {
    basic.showIcon(IconNames.Heart)
    basic.pause(500)
    basic.clearScreen()
    basic.pause(500)
})