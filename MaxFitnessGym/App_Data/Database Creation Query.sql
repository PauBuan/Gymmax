DROP TABLE IF EXISTS Transactions;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Subscription;

CREATE TABLE Customer(
	ID INT NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100),
	PhoneNumber BIGINT
);

CREATE TABLE Subscription(
	ID INT NOT NULL PRIMARY KEY,
	SubscriptionName NVARCHAR(100) NOT NULL,
	Payment MONEY NOT NULL,
	Duration INT NOT NULL
);

CREATE TABLE Transactions(
	ID NVARCHAR(5) NOT NULL PRIMARY KEY,
	Customer INT NOT NULL,
	Subscription INT NOT NULL,
	DateOfPurchase DATE NOT NULL,
	FOREIGN KEY (Customer) REFERENCES Customer(ID),
	FOREIGN KEY (Subscription) REFERENCES Subscription(ID)
);

INSERT INTO Customer(ID, FirstName, LastName, PhoneNumber) VALUES
	(0001, 'Dummy Account', 'LastName', 0284410396),
	(0002, 'David Joseph', 'Cortez', 09354857654),
	(0003, 'Ezekial', 'Talampas', 09117351261),
	(0004, 'Angelo Justine', 'Kamachi', 0919686606),
	(0005, 'Paulo', 'Buan', 09468873782);
INSERT INTO Subscription(ID, SubscriptionName, Payment, Duration) VALUES
	(0001, 'Session', 50, 1),
	(0002, 'Weekly', 150, 7),
	(0003, 'Bi-Monthly', 250, 15),
	(0004, 'Monthly', 500, 30);
INSERT INTO Transactions(ID, Customer, Subscription, DateOfPurchase) VALUES
	('T0001', 0001, 0001, '03/05/2024'),
	('T0002', 0002, 0002, '03/07/2024'),
	('T0003', 0003, 0003, '03/10/2024'),
	('T0004', 0004, 0004, '03/15/2024');