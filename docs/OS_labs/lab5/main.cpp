#include "print_up.h"

#include <iostream>
#include <string>

int main(int argc, char *argv[])
{
    if (argc < 2) {
        std::cout << "Usage: ./print_up_program \"text\"" << std::endl;
        return 1;
    }

    std::string text = argv[1];

    print_up(text);

    return 0;
}
