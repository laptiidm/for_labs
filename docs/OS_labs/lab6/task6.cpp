#include <iostream>
#include <pthread.h>

// створюємо структуру щоб "запакувати" декілька чисел в один об'єкт
// pthread_create() дозволяє передати у потокову функцію тільки один аргумент типу void*
struct Numbers {
    int a;
    int b;
    int c;
};

//void   → "нічого"
//void*  → "адреса чогось, але тип цього чогось поки невідомий"
// ці дві потрібні як точки входу для потоків

void* threadFunction1(void* arg) { // arg → адреса даних, які ми передали через pthread_create()

    // arg має тип void*, тому ми не можемо напряму звернутися до a, b, c
    // кажемо компілятору: "насправді arg вказує на структуру Numbers"
    Numbers* numbers = static_cast<Numbers*>(arg);

    int sum = numbers->a + numbers->b + numbers->c;

    std::cout << "Перший потік. Сума чисел: " << sum << std::endl;

    return nullptr; // потік завершився і нічого корисного назад не повертає
}

void* threadFunction2(void* arg) {

    // так само перетворюємо void* назад у Numbers*
    Numbers* numbers = static_cast<Numbers*>(arg);

    int product = numbers->a * numbers->b * numbers->c;

    std::cout << "Другий потік. Добуток чисел: " << product << std::endl;

    return nullptr;
}

int main() {
    pthread_t thread1; // pthread_t → тип для ідентифікатора потоку
    pthread_t thread2;

    // створюємо конкретний набір чисел
    Numbers numbers = {2, 3, 4};

    // &numbers → адреса структури numbers
    // саме ця адреса потрапить у параметр void* arg функції threadFunction1()
    pthread_create(&thread1, nullptr, threadFunction1, &numbers);

    // обидва потоки отримують адресу тієї самої структури numbers
    pthread_create(&thread2, nullptr, threadFunction2, &numbers);

    pthread_join(thread1, nullptr); // чекай поки thread1 завершиться
    pthread_join(thread2, nullptr); // чекай поки thread2 завершиться

    std::cout << "Обидва потоки завершили роботу" << std::endl;

    return 0;
}
