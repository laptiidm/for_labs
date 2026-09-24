#include <iostream>
#include <pthread.h>

// структура для передачі двох чисел у потоки
struct Numbers {
    int a;
    int b;
};

// перший потік обчислює суму
void* sumFunction(void* arg) {
    // перетворюємо void* назад у Numbers*
    Numbers* numbers = static_cast<Numbers*>(arg);

    // результат створюємо в heap, щоб він не зник після завершення функції
    int* result = new int;

    *result = numbers->a + numbers->b;

    std::cout << "Сума: " << *result << std::endl;

    // pthread_exit() завершує потік і передає адресу результату назад
    pthread_exit(result);
}

// другий потік обчислює добуток
void* productFunction(void* arg) {
    Numbers* numbers = static_cast<Numbers*>(arg);

    int* result = new int;

    *result = numbers->a * numbers->b;

    std::cout << "Добуток: " << *result << std::endl;

    pthread_exit(result);
}

int main() {
    pthread_t thread1;
    pthread_t thread2;

    Numbers numbers = {2, 3};

    pthread_create(&thread1, nullptr, sumFunction, &numbers);
    pthread_create(&thread2, nullptr, productFunction, &numbers);

    // сюди pthread_join() отримає те, що потоки передали через pthread_exit()
    void* result1;
    void* result2;

    pthread_join(thread1, &result1);
    pthread_join(thread2, &result2);

    // pthread_join повернув void*, тому перетворюємо назад у int*
    int sum = *static_cast<int*>(result1);
    int product = *static_cast<int*>(result2);

    std::cout << "Сума в main: " << sum << std::endl;
    std::cout << "Добуток в main: " << product << std::endl;

    // порівнюємо результати двох потоків
    if (sum > product) {
        std::cout << "Сума більша за добуток" << std::endl;
    } else if (sum < product) {
        std::cout << "Добуток більший за суму" << std::endl;
    } else {
        std::cout << "Сума і добуток рівні" << std::endl;
    }

    // result був створений через new, тому пам'ять потрібно звільнити
    delete static_cast<int*>(result1);
    delete static_cast<int*>(result2);

    return 0;
}
