#include <iostream>
#include <unistd.h>

int main() {
    std::cout << "програма стартувала. PID: " << getpid() << std::endl;

    pid_t pid = fork();

    if (pid == -1) {
        std::cerr << "fork() не спрацював коректно" << std::endl;
        return 1;
    }

    std::cout << "процес після fork(). PID: " << getpid() << std::endl;

    sleep(30);

    return 0;
}
