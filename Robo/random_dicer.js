/*
кидання кубика

- input.onButtonPressed(Button.A, ...) -> обробляє натискання кнопки A
- randint(1, 6) -> випадкове число від 1 до 6
- basic.showNumber(dice) -> показує результат на LED-дисплеї
*/

input.onButtonPressed(Button.A, function () {
    let dice = randint(1, 6)
    basic.showNumber(dice)
})
