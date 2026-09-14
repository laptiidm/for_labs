#include <cstdio>
#include <cstring>

int main(int argc, char *argv[])
{
    if (argc != 3) {
        std::fprintf(
            stderr,
            "Використання: %s <вхідний_файл> <вихідний_файл>\n",
            argv[0]
        );
        return 1;
    }

    FILE *input = std::fopen(argv[1], "r");

    if (input == nullptr) {
        std::fprintf(
            stderr,
            "Помилка: не вдалося відкрити вхідний файл %s\n",
            argv[1]
        );
        return 1;
    }

    char buffer[1024];
    int lineCount = 0;

    while (std::fgets(buffer, sizeof(buffer), input) != nullptr) {
        lineCount++;
    }

    int width = 1;
    int temp = lineCount;

    while (temp >= 10) {
        width++;
        temp /= 10;
    }

    std::fseek(input, 0, SEEK_SET);

    FILE *output = std::fopen(argv[2], "w");

    if (output == nullptr) {
        std::fprintf(
            stderr,
            "Помилка: не вдалося створити вихідний файл %s\n",
            argv[2]
        );
        std::fclose(input);
        return 1;
    }

    int lineNumber = 1;

    while (std::fgets(buffer, sizeof(buffer), input) != nullptr) {
        std::fprintf(output, "%*d. %s", width, lineNumber, buffer);
        lineNumber++;
    }

    std::fclose(input);
    std::fclose(output);

    std::printf("Файл створено: %s\n", argv[2]);

    return 0;
}
