## Python-first стек із модульною монолітною архітектурою. Він дозволить реалізувати робочий POC, а згодом розширити систему в дипломній роботі.

## Рекомендований технологічний стек

| Компонент        | Технологія                | Призначення                                    |
| ---------------- | ------------------------- | ---------------------------------------------- |
| Frontend         | React + TypeScript + Vite | Інтерфейси студента та викладача               |
| Backend / API    | Python + FastAPI          | REST API, користувачі, модулі, сесії           |
| Learning Engine  | Python                    | Керування навчальними сценаріями               |
| AI Agent Runtime | Python + LangGraph        | Оркестрація агента та навчальних процесів      |
| LLM              | OpenAI API                | Генерація пояснень, питань, аналіз відповідей  |
| RAG              | LlamaIndex                | Пошук інформації в навчальних матеріалах       |
| Database         | PostgreSQL + pgvector     | Зберігання даних і векторний пошук             |
| ORM              | SQLAlchemy + Alembic      | Робота з БД та міграціями                      |
| Validation       | Pydantic                  | Валідація API та структурованих результатів ШІ |
| Testing          | pytest                    | Модульні та інтеграційні тести                 |
| Infrastructure   | Docker Compose            | Локальне розгортання системи                   |

## Архітектурні рішення

- Modular Monolith — одна серверна програма з незалежними внутрішніми модулями.
- Configurable Learning Modules — навчальні блоки з власними матеріалами, цілями та правилами поведінки ШІ.
- Shared Agent Runtime — спільна інфраструктура ШІ для всіх навчальних модулів.
- Rule-based Adaptation + LLM Assessment — ШІ аналізує відповіді, а Learning Engine приймає рішення щодо подальшого сценарію.

[image](https://www.google.com/s2/favicons?domain=https://reference.langchain.com\&sz=32)

LangChain Reference

+1




Фінальний вибір для POC:

`React + TypeScript → FastAPI → Python Learning Engine + LangGraph → OpenAI API → PostgreSQL + pgvector`
