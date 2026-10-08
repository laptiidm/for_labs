* **Арифметика**

  * `+` — додавання
  * `-` — віднімання
  * `*` — множення
  * `/` — ділення
  * `//` — цілочисельне ділення
  * `mod` — остача від ділення

```prolog
X is 10 + 5.
```

* **Порівняння чисел**

  * `>` — більше
  * `<` — менше
  * `>=` — більше або дорівнює
  * `=<` — менше або дорівнює
  * `=:=` — арифметично дорівнює
  * `=\=` — арифметично не дорівнює

```prolog
Age >= 18.
X =:= 10.
```

Зверни увагу: у Prolog саме `=<`, а не `<=`.

* **Уніфікація / робота зі значеннями**

  * `=` — спробувати зробити два терми однаковими
  * `\=` — не можуть бути уніфіковані
  * `is` — обчислити арифметичний вираз

```prolog
X = 10.
Y is X + 5.
```

Особливо важливо не плутати:

```prolog
X = 2 + 3.
```

дасть фактично:

```text
X = 2+3
```

А:

```prolog
X is 2 + 3.
```

дасть:

```text
X = 5
```

* **Логічні оператори**

  * `,` — AND
  * `;` — OR
  * `\+` — NOT

Наприклад:

```prolog
city(Name, People, Square),
People > 500000,
Square > 100.
```

це:

> місто існує **і** населення > 500000 **і** площа > 100.

OR:

```prolog
People > 1000000 ; People < 300000.
```

NOT:

```prolog
\+ special(ivan, doctor).
```

* **Правила**

  * `:-` — «якщо»

```prolog
big_city(Name) :-
    city(Name, People, _),
    People > 1000000.
```

Читається:

> `Name` є великим містом, **якщо** є такий факт `city(...)` і населення більше мільйона.

* **Cut**

  * `!` — зупиняє backtracking у певній точці.

```prolog
max(X, Y, X) :-
    X >= Y, !.
```

`!` вже трохи складніший: якщо використати його невдало, Prolog може перестати шукати інші правильні варіанти.

Основні: `:-`, `,`, `;`, `is`, `>`, `<`, `>=`, `=<`, `=`, `\=`, `=:=`, `=\=`.


---


## 1. Special

```prolog
special(anna, doctor).
special(ivan, programmer).
special(olena, teacher).
special(petro, engineer).
special(maria, designer).
special(oleh, lawyer).
special(natalia, accountant).
special(andriy, architect).
special(serhiy, driver).
special(iryna, journalist).
special(nataly, doctor).
special(elen, doctor).

popular_profession(Profession) :-
    findall(Name, special(Name, Profession), People),
    length(People, Count),
    Count > 1.
```

## 2. City

```prolog
city(kyiv, 2967000, 839).
city(kharkiv, 1421000, 350).
city(odesa, 1010000, 162).
city(dnipro, 968000, 405).
city(lviv, 717000, 149).
city(zaporizhzhia, 710000, 331).
city(kryvyi_rih, 603000, 430).
city(mykolaiv, 470000, 260).
city(vinnytsia, 370000, 113).
city(khmelnytskyi, 274000, 93).

big_city(Name) :-
    city(Name, People, _),
    People > 1000000.

large_area(Name) :-
    city(Name, _, Square),
    Square > 300.

medium_city(Name) :-
    city(Name, People, _),
    People >= 500000,
    People =< 1000000.

dense_city(Name) :-
    city(Name, People, Square),
    Density is People / Square,
    Density > 5000.

denser_than(City1, City2) :-
    city(City1, People1, Square1),
    city(City2, People2, Square2),
    Density1 is People1 / Square1,
    Density2 is People2 / Square2,
    Density1 > Density2.
```

## 3. Film

```prolog
film('The Matrix', 1999, sci_fi).
film('Titanic', 1997, drama).
film('The Godfather', 1972, crime).
film('Interstellar', 2014, sci_fi).
film('Gladiator', 2000, action).
film('The Shining', 1980, horror).
film('Forrest Gump', 1994, drama).
film('Avatar', 2009, sci_fi).
film('Joker', 2019, drama).
film('Inception', 2010, sci_fi).

modern_film(Title) :-
    film(Title, Year, _),
    Year >= 2010.

classic_film(Title) :-
    film(Title, Year, _),
    Year < 1990.

modern_sci_fi(Title) :-
    film(Title, Year, sci_fi),
    Year >= 2000.

old_drama(Title) :-
    film(Title, Year, drama),
    Year < 2000.

same_genre(Film1, Film2) :-
    film(Film1, _, Type),
    film(Film2, _, Type),
    Film1 \= Film2.

older_than(Film1, Film2) :-
    film(Film1, Year1, _),
    film(Film2, Year2, _),
    Year1 < Year2.

older_same_genre(Film1, Film2) :-
    film(Film1, Year1, Type),
    film(Film2, Year2, Type),
    Film1 \= Film2,
    Year1 < Year2.
```

