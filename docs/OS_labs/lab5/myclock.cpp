#include <iostream>
#include <ctime>

using namespace std;

void showCurrentTime()
{
    time_t currentTime = time(nullptr);

    cout << "Поточний час: " << ctime(&currentTime);
}

int main()
{
    cout << "Студент: Laptii Dmytro" << endl;

    showCurrentTime();

    return 0;
}
