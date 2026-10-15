## День 1: JavaScript Fundamentals
- [ ] Типи даних, let/const, scope, hoisting (45 хв)
- [ ] Functions, arrow functions, closures, this (60 хв)
- [ ] Destructuring, spread/rest, array methods (60 хв)
- [ ] Promises, async/await, event loop, error handling (90 хв)
- [ ] Практика: 3–4 задачі на JavaScript (75 хв)
- [ ] Усні технічні запитання та розбір помилок (30 хв)

## День 2: React + Frontend
- [ ] JSX, components, props, component composition (45 хв)
- [ ] useState, events, controlled forms (60 хв)
- [ ] useEffect, dependencies, cleanup (60 хв)
- [ ] Rendering, keys, lifting state up, Context basics (45 хв)
- [ ] Практика: Task Tracker на React (105 хв)
- [ ] HTML/CSS responsive basics, DevTools (30 хв)
- [ ] Interview questions + debugging React (15 хв)

## День 3: Backend + Interview
- [ ] Node.js, Express, routing, middleware (60 хв)
- [ ] HTTP, REST, CRUD, JSON, status codes (45 хв)
- [ ] Практика: REST API + інтеграція frontend (75 хв)
- [ ] Git/GitHub workflow, branches, PR (30 хв)
- [ ] Unit testing + AI code verification (45 хв)
- [ ] TypeScript, SQL, Docker, CI/CD — швидкий огляд (30 хв)
- [ ] Mock interview: теорія + coding + поведінкові питання (75 хв)

---

Для позиції Junior Web Full-Stack (IRC306365) я б пріоритезував навички за трьома критеріями:

1. Важливість для вакансії — наскільки явно технологія згадується у Required Skills і Responsibilities.
2. Ймовірність перевірки на інтерв'ю — моя оцінка, а не статистика конкретної компанії.
3. Практична залежність — що потрібно знати, щоб реалізувати повноцінну frontend/backend фічу.

## 1. Матриця пріоритетів

## P0 — Критично важливі

Глибоке розуміння + практика

| JavaScript ES6+          | Types, scope, closures, functions, arrays/objects, destructuring, spread/rest, modules, Promises, async/await, event loop, error handling |
| ------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------- |
| React                    | JSX, components, props, state, `useState`, `useEffect`, forms, lists/keys, conditional rendering, lifting state up                        |
| HTTP / REST / JSON       | GET, POST, PATCH, DELETE, status codes, fetch, request/response, loading/error handling                                                   |
| Node.js + Express basics | Routes, middleware, REST endpoints, input validation, asynchronous operations                                                             |

## P1 — Високий пріоритет

Вміти використовувати

| HTML / CSS           | Semantic HTML, Flexbox, Grid, responsive design, forms                                   |
| -------------------- | ---------------------------------------------------------------------------------------- |
| Git / GitHub         | Branching, commits, pull requests, merge conflicts, code review                          |
| Debugging            | Browser DevTools, Network tab, breakpoints, backend logs, troubleshooting                |
| AI coding assistants | Prompting, code review, verification, testing AI-generated code                          |
| English / Teamwork   | Technical explanations, clarifying questions, stand-ups, discussing bugs and PR feedback |

## P2 — Бажані навички

Основи + невеликі приклади

| TypeScript       | Types, interfaces, optional properties, type inference            |
| ---------------- | ----------------------------------------------------------------- |
| SQL / NoSQL      | CRUD, SELECT, JOIN basics, relational vs document databases       |
| Testing          | Unit tests, Jest/Vitest, React Testing Library, mocking basics    |
| State management | React Context, коли потрібні Redux/Zustand, local vs global state |

## P3 — Достатньо концептуального розуміння

| Docker | Images, containers, Dockerfile, навіщо контейнеризація |
| ------ | ------------------------------------------------------ |
| CI/CD  | Pipeline, build, test, deploy, GitHub Actions basics   |
| Cloud  | Базове розуміння AWS/Azure/GCP, deployment і hosting   |

## 2. Розподіл часу на підготовку

Якщо залишаємо наш бюджет 18 годин, я пропоную такий розподіл. Це навчальна рекомендація, а не прогноз запитань інтерв'ю.

18 годин підготовки

Git / AI / Testing

JavaScript

Mock interview / English

Node.js / HTTP / REST

Preferred skills

React

Практика integration / debugging

| JavaScript ES6+ / async           | 4 год  |
| --------------------------------- | ------ |
| React                             | 4 год  |
| Node.js / Express / HTTP          | 3 год  |
| Integration / debugging           | 2 год  |
| Git / AI workflow / testing       | 2 год  |
| TypeScript / SQL / інші preferred | 1 год  |
| Mock interview / English          | 2 год  |
| Разом                             | 18 год |

## 3. Що саме потрібно вміти продемонструвати

Для Junior-позиції важливо не лише знати визначення, а й уміти виконати невелику задачу.

| Напрям      | Мінімальний практичний результат                                       |
| ----------- | ---------------------------------------------------------------------- |
| JavaScript  | Написати `filter`/`map`, пояснити Promise, знайти помилку в async-коді |
| React       | Самостійно створити компонент зі state, формою та завантаженням даних  |
| Node.js     | Створити REST endpoint із валідацією та правильними HTTP codes         |
| Integration | Під'єднати React до Express API, обробити loading/error                |
| Git         | Створити branch, commit, PR і пояснити diff                            |
| Testing     | Написати тест для бізнес-правила та негативного сценарію               |
| AI          | Пояснити, як перевіряв AI-generated code, а не просто скопіював його   |
| English     | За 1–2 хвилини пояснити реалізовану фічу та свій debugging process     |

## 4. Як застосувати це до ItemFlow

Наш ItemFlow уже дозволяє охопити основні теми через один проєкт.

1. Item Catalog API — JavaScript, Node.js, Express, REST.
2. Item Catalog UI — React, hooks, props, responsive CSS.
3. Create/Edit Item — forms, validation, state, POST/PATCH.
4. Stock IN/OUT — бізнес-логіка, error handling, debugging.
5. Tests + Pull Request — testing, GitHub, AI code review.

Приділити увагу JavaScript asynchronous programming, React state/hooks та frontend/backend integration. Саме вони пов'язують найбільше обов'язкових вимог вакансії.
