#include <iostream>
#include <unistd.h>

extern char **environ; // передають новій програмі поточні environment variables

int main() {
    std::cout << "основна програма. PID: " << getpid() << std::endl;

    pid_t pid = fork();

    if (pid == -1) {
        std::cerr << "fork() не спрацював коректно" << std::endl;
        return 1;
    }

    if (pid == 0) {
        std::cout << "дочірній процес. PID: " << getpid()
                  << ". запускаємо ls..." << std::endl;

        char arg0[] = "ls";
        char arg1[] = "-la";
        char* args[] = {arg0, arg1, nullptr}; // nullptr вказує на кінець масиву 

        // execve() → "у цьому child замість моєї програми запусти ls"
        // Якщо execve() успішно спрацював, другий рядок ніколи не виконається.
        execve("/bin/ls", args, environ);

        std::cerr << "execve() не спрацював коректно" << std::endl;
        return 1;
    }

    std::cout << "батьківський процес. PID: " << getpid()
              << ", child PID: " << pid << std::endl;

    return 0;
}
