--Create TABLE Inventory
--(
--    ItemName VARCHAR (50) PRIMARY KEY,
--    Quantity INT NOT NULL,
--	Price Decimal NOT NULL
--);

CREATE TABLE Store
(
    [Location] VARCHAR(30) NOT NULL,
	ItemName VARCHAR(50) NOT NULL,
	Quantity INT NOT NULL,
	Price MONEY NOT NULL,
);

CREATE TABLE Customers
(
	CustomerId INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR (20) NOT NULL,
    LastName VARCHAR (20) NOT NULL
);

CREATE TABLE Orders
(
   StoreLocation VARCHAR(30),
   OrderId INT,
   OrderDate DATETIME2 PRIMARY KEY,
   FirstName VARCHAR(30),
   LastName VARCHAR(30)
);

INSERT Store ([Location], ItemName, Quantity, Price) 
Values 
('Milwaukee, WI', 'Apples', 50, 1),
('Milwaukee, WI', 'Bananas', 50, 1),
('Milwaukee, WI', 'Bread', 25, 2),
('Milwaukee, WI', 'Milk', 25, 2),
('Milwaukee, WI', 'Chicken pieces', 25, 3),
('Milwaukee, WI', 'Potato Chips', 15, 2),
('Milwaukee, WI', 'Pizza', 20, 4),
('Milwaukee, WI', 'Chocolate Chip Cookie', 50, 1);

INSERT Store ([Location], ItemName, Quantity, Price) 
Values 
('Madison, WI', 'Apples', 50, 1),
('Madison, WI', 'Bananas', 50, 1),
('Madison, WI', 'Bread', 25, 2),
('Madison, WI', 'Milk', 25, 2),
('Madison, WI', 'Chicken pieces', 25, 3),
('Madison, WI', 'Potato Chips', 15, 2),
('Madison, WI', 'Pizza', 20, 4),
('Madison, WI', 'Chocolate Chip Cookie', 50, 1);


INSERT Customers (FirstName, LastName)
VALUES
('Bobby', 'Hill'),
('Christian', 'Yelich'),
('Giannis', 'Antetokounmpo');

DROP TABLE Customers;

SELECT * From Customers WHERE FirstName = 'Bobby';