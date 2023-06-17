# MindBoxTestBackendTask

В самом репозитории представлена первая часть тестового задания

В README представлена вторая часть часть тестового задания

Запрос для создания схемы БД 

```
CREATE TABLE product (
    id bigserial PRIMARY KEY,
  	name varchar
);

CREATE TABLE category (
    id bigserial PRIMARY KEY,
  	name varchar
);

CREATE TABLE products_categories (
    id bigserial PRIMARY KEY,
  	product_id bigint REFERENCES Product(id),
  	category_id bigint REFERENCES Category(id)
);

INSERT INTO product VALUES 
(1, 'Я первый товар и у меня есть категории'),
(2, 'Я второй товар и у меня нету категорий');

INSERT INTO category VALUES 
(1, 'Почему я первая категория?'),
(2, 'Потому что я вторая категория');

INSERT INTO products_categories VALUES 
(1, 1, 1),
(2, 1, 2);
```

Запрос для получения всех пар «Имя продукта – Имя категории». 
Если у продукта нет категорий, то его имя все равно выводится, однако в качестве имени категории выводится "Категория не найдена" для повышения читаемости.
```
SELECT product.name AS "product_name",
CASE
    WHEN products_categories.category_id IS NULL THEN 'Категория не найдена'
    ELSE category.name
END AS "category_name"
FROM product
LEFT JOIN products_categories ON products_categories.product_id = product.id
LEFT JOIN category ON products_categories.category_id = category.id
```

Для проверки работы предлагаю воспользоваться следующим сервисом - https://www.db-fiddle.com/ (не забудьте в выпадающем окне слева сверху указать базу данных PostgreSQL v15)
