#include <iostream>
#include <pthread.h>

// потокова функція рахує суму перших 100 натуральних чисел
void* sumFunction(void*) {

    // результат створюємо в heap, щоб він існував і після завершення функції
    int* sum = new int(0);

    for (int i = 1; i <= 100; i++) {
        *sum += i;
    }

    // завершуємо потік і передаємо адресу результату назад у main()
    pthread_exit(sum);
}

int main() {

    pthread_t thread;

    // створюємо потік, який виконає sumFunction()
    pthread_create(&thread, nullptr, sumFunction, nullptr);

    // pthread_self() → ID потоку, який зараз виконує цей код
    // тут цей код виконує main thread
    pthread_t currentThread = pthread_self();

    // перевіряємо, чи main thread і створений thread не є одним і тим самим потоком
    if (pthread_equal(currentThread, thread)) {

        std::cout << "Потік не може синхронізуватися сам із собою" << std::endl;

    } else {

        std::cout << "Потоки різні. Виконуємо pthread_join()" << std::endl;

        void* result;

        // чекаємо завершення thread і отримуємо те,
        // що він передав через pthread_exit()
        pthread_join(thread, &result);

        // result має тип void*, тому перетворюємо його назад у int*
        int sum = *static_cast<int*>(result);

        std::cout << "Сума перших 100 натуральних чисел: "
                  << sum << std::endl;

        // пам'ять була створена через new у sumFunction(),
        // тому після використання її потрібно звільнити
        delete static_cast<int*>(result);
    }

    return 0;
}
