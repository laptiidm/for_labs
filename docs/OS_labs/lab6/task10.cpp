#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <dirent.h>
#include <pthread.h>

// слово або фраза, яку шукаємо
// глобальна, щоб усі потоки могли її бачити
std::string searchText;


// функція, яку буде виконувати кожен потік
void* searchInFile(void* arg) {

    // pthread_create передає void*
    // ми знаємо, що там насправді адреса std::string з назвою файлу
    std::string* fileName = static_cast<std::string*>(arg);

    std::ifstream file(*fileName);

    std::string line;
    bool found = false;

    // читаємо файл рядок за рядком
    while (std::getline(file, line)) {

        // якщо find() не повернув npos - текст знайдено
        if (line.find(searchText) != std::string::npos) {

            std::cout << "Знайдено у файлі "
                      << *fileName
                      << ": "
                      << line
                      << std::endl;

            found = true;
        }
    }

    if (!found) {
        std::cout << "У файлі "
                  << *fileName
                  << " нічого не знайдено"
                  << std::endl;
    }

    return nullptr;
}


int main() {

    std::cout << "Введіть слово або фразу: ";
    std::getline(std::cin, searchText);

    // список знайдених txt-файлів
    std::vector<std::string> files;

    // відкриваємо поточний каталог "."
    DIR* directory = opendir(".");

    if (directory == nullptr) {
        std::cerr << "Не вдалося відкрити каталог" << std::endl;
        return 1;
    }

    dirent* entry;

    // читаємо всі файли каталогу
    while ((entry = readdir(directory)) != nullptr) {

        std::string fileName = entry->d_name;

        // перевіряємо чи файл закінчується на .txt
        if (fileName.size() >= 4 &&
            fileName.substr(fileName.size() - 4) == ".txt") {

            files.push_back(fileName);
        }
    }

    closedir(directory);

    std::cout << "Знайдено текстових файлів: "
              << files.size()
              << std::endl;

    // створюємо стільки pthread_t, скільки є файлів
    std::vector<pthread_t> threads(files.size());

    // для кожного txt-файлу створюємо окремий потік
    for (size_t i = 0; i < files.size(); i++) {

        pthread_create(
            &threads[i],
            nullptr,
            searchInFile,
            &files[i]
        );
    }

    // чекаємо завершення всіх потоків
    for (size_t i = 0; i < threads.size(); i++) {
        pthread_join(threads[i], nullptr);
    }

    std::cout << "Пошук завершено" << std::endl;

    return 0;
}
