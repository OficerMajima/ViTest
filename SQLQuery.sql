SET ANSI_PADDING ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE DATABASE [PaymentOrderDb]
GO

USE [PaymentOrderDb]
GO

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    AmountPaid DECIMAL(18, 2) NOT NULL DEFAULT 0
);
GO

CREATE TABLE MoneyArrivals (
    ArrivalId INT PRIMARY KEY IDENTITY(1,1),
    ArrivalDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    RemainingAmount DECIMAL(18, 2) NOT NULL
);
GO

CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    ArrivalId INT NOT NULL,
    PaymentAmount DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ArrivalId) REFERENCES MoneyArrivals(ArrivalId)
);
GO

CREATE OR ALTER TRIGGER [dbo].[trg_UpdateOrderAndMoneyArrival]
ON [dbo].[Payments]
AFTER INSERT
AS
BEGIN
    DECLARE @OrderID INT, @ArrivalID INT, @PaymentAmount DECIMAL(18, 2), @PaymentID INT, @PaymentDifference DECIMAL(18, 2);

    SELECT @OrderID = OrderID, @ArrivalID = ArrivalID, @PaymentAmount = PaymentAmount, @PaymentID = PaymentID
    FROM inserted;

	SELECT @PaymentDifference = (SELECT TotalAmount FROM Orders WHERE OrderID = @OrderID) - (SELECT AmountPaid FROM Orders WHERE OrderID = @OrderID) 

		IF @PaymentAmount <= 0 OR @PaymentDifference <= 0
		BEGIN
			RAISERROR('Сумма должна быть больше нуля', 16, 1);
			ROLLBACK TRANSACTION;
			RETURN;
		END

		IF @PaymentAmount > (SELECT RemainingAmount FROM MoneyArrivals WHERE ArrivalID = @ArrivalID)
		BEGIN
			RAISERROR(' Недостаточно средств в приходе.', 16, 1);
			ROLLBACK TRANSACTION;
			RETURN;
		END

		IF @PaymentAmount > @PaymentDifference   
		BEGIN
			SET @PaymentAmount = @PaymentDifference;
		END

 	UPDATE Orders
	SET AmountPaid = AmountPaid + @PaymentAmount
	WHERE OrderID = @OrderID;

	UPDATE MoneyArrivals
	SET RemainingAmount = RemainingAmount - @PaymentAmount
	WHERE ArrivalID = @ArrivalID;
END;
GO

INSERT INTO MoneyArrivals (ArrivalDate, TotalAmount, RemainingAmount)
VALUES ('2010-10-10', 500, 500)

INSERT INTO Orders (OrderDate, TotalAmount, AmountPaid)
VALUES ('2010-10-10', 300, 0)