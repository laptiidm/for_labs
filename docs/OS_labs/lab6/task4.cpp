#include <iostream>
#include <unistd.h>
#include <sys/wait.h>

int main() {
    pid_t pid = fork();

    if (pid == -1) {
        std::cerr << "fork() не спрацював коректно" << std::endl;
        return 1;
    }

    if (pid == 0) {
        std::cout << "Дочірній процес почав виконуватися. PID: "
                  << getpid() << std::endl;

        sleep(2);

        std::cout << "Дочірній процес працює..." << std::endl;

        sleep(2);

        std::cout << "Дочірній процес завершується." << std::endl;
    } else {
        std::cout << "Батьківський процес почав виконуватися. PID: "
                  << getpid() << std::endl;

        wait(nullptr);

        std::cout << "Дочірній процес завершився. Батьківський процес продовжує роботу."
                  << std::endl;
    }

    return 0;
}
