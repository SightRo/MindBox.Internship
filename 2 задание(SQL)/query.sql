SELECT P.Name AS 'Продукт', C.Name AS 'Категория'
FROM Products P
         LEFT JOIN ProductsCategories PC on P.Id = PC.ProductId
         LEFT JOIN Categories C on PC.CategoryId = C.Id

