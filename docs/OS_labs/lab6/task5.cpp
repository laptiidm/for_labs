#include <iostream>
#include <pthread.h>

//void   → "нічого"
//void*  → "адреса чогось, але тип цього чогось поки невідомий"
// ці дві потрібні як точки входу для потоків
void* threadFunction1(void*) { // pthread_create() вимагає щоб потокова функція мала саме такий формат
    std::cout << "Перший потік виконується" << std::endl;
    return nullptr;
}

void* threadFunction2(void*) {
    std::cout << "Другий потік виконується" << std::endl;
    return nullptr; // функція завершилась і не повертає ніякого корисного результату
                    // оскільки тип повернення void* (вказівник на будь-який тип) ми маємо повернути nullptr
}

int main() {
    pthread_t thread1; //pthread_t  → тип для ідентифікатора потоку
    pthread_t thread2;

    pthread_create(&thread1, nullptr, threadFunction1, nullptr); // створи поток thread1, який виконає threadFunction1() без передачі аргументів (nullptr - заглушка)
    pthread_create(&thread2, nullptr, threadFunction2, nullptr);

    pthread_join(thread1, nullptr); // pthread_join() → "чекай поки thread1 завершиться"
    pthread_join(thread2, nullptr);

    std::cout << "Обидва потоки завершили роботу" << std::endl;

    return 0;
}
