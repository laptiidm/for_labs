#include <iostream>
#include <pthread.h>

// тут збережемо ідентифікатори двох потоків
pthread_t id1;
pthread_t id2;

void* threadFunction1(void*) {
    id1 = pthread_self(); // pthread_self() → повертає ID поточного потоку

    std::cout << "Перший потік виконується" << std::endl;

    return nullptr;
}

void* threadFunction2(void*) {
    id2 = pthread_self();

    std::cout << "Другий потік виконується" << std::endl;

    return nullptr;
}

int main() {
    pthread_t thread1;
    pthread_t thread2;

    pthread_create(&thread1, nullptr, threadFunction1, nullptr);
    pthread_create(&thread2, nullptr, threadFunction2, nullptr);

    // чекаємо, щоб обидва потоки точно записали свої ID у id1 та id2
    pthread_join(thread1, nullptr);
    pthread_join(thread2, nullptr);

    // pthread_equal() використовується для правильного порівняння pthread_t
    if (pthread_equal(id1, id2)) {
        std::cout << "Потоки мають однакові ідентифікатори" << std::endl;
    } else {
        std::cout << "Потоки мають різні ідентифікатори" << std::endl;
    }

    return 0;
}
