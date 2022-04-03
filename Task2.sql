CREATE TABLE Products(
	ProductId int IDENTITY(1,1) CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED,
	Name varchar(50) NOT NULL
)

CREATE TABLE Categories(
	CategoryId int IDENTITY(1,1) CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED,
	Name varchar(50) NOT NULL
)

CREATE TABLE ProductsCategories(
	Id int IDENTITY(1,1) CONSTRAINT [PK_ProductsCategories] PRIMARY KEY CLUSTERED,
	ProductId int CONSTRAINT FK_ProductsCategories_ProductId FOREIGN KEY (ProductId) REFERENCES Products (ProductId),
	CategoryId int CONSTRAINT FK_ProductsCategories_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories (CategoryId)
)

CREATE INDEX IX_ProductsCategories_ProductId ON ProductsCategories (ProductId);
CREATE INDEX IX_ProductsCategories_CategoryId ON ProductsCategories (CategoryId);

insert into Categories (name) values ('Спорт');
insert into Categories (name) values ('Обувь');
insert into Categories (name) values ('Продукты');

insert into Products (name) values ('Мяч');
insert into Products (name) values ('Коньки');
insert into Products (name) values ('Кроссовки');
insert into Products (name) values ('Хлеб');
insert into Products (name) values ('Молоко');
insert into Products (name) values ('Телевизор');

insert into ProductsCategories(ProductId, CategoryId) values (1,1);
insert into ProductsCategories(ProductId, CategoryId) values (2,1);
insert into ProductsCategories(ProductId, CategoryId) values (3,1);
insert into ProductsCategories(ProductId, CategoryId) values (3,2);
insert into ProductsCategories(ProductId, CategoryId) values (4,3);
insert into ProductsCategories(ProductId, CategoryId) values (5,3);

SELECT p.Name as ProductName, c.Name as CategoryName
FROM Products p left join ProductsCategories pc on p.ProductId=pc.ProductId
	left join Categories c on pc.CategoryId=c.CategoryId