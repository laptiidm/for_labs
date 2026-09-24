#include <iostream>
#include <unistd.h>

int main() {
    std::cout << "Програма стартувала. PID: " << getpid() << std::endl;

    pid_t pid = fork();

    if (pid == -1) {
        std::cerr << "fork() не спрацював коректно" << std::endl;
        return 1;
    }

    if (pid == 0) {
        std::cout << "Дочірній процес. PID: " << getpid()
                  << ", PPID: " << getppid() << std::endl;
    } else {
        std::cout << "Батьківський процес. PID: " << getpid()
                  << ", PID дочірнього процесу: " << pid << std::endl;
    }

    return 0;
}
