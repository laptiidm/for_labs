#include "print_up.h"

#include <cctype>
#include <iostream>

void print_up(const std::string& text)
{
    for (char ch : text) {
        std::cout << static_cast<char>(
            std::toupper(static_cast<unsigned char>(ch))
        );
    }

    std::cout << std::endl;
}
