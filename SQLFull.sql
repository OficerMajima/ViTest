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

CREATE OR ALTER PROCEDURE [dbo].[AddPayment]
    @OrderId INT,
    @ArrivalId INT,
	@PaymentAmount DECIMAL
AS
BEGIN
    INSERT INTO Payments(OrderId, ArrivalId, PaymentAmount)
    VALUES (@OrderId, @ArrivalId, @PaymentAmount);
END
GO

CREATE OR ALTER PROCEDURE [dbo].[AddOrder]
    @OrderDate DATETIME,
    @TotalAmount DECIMAL,
	@AmountPaid DECIMAL
AS
BEGIN
    INSERT INTO Orders(OrderDate, TotalAmount, AmountPaid)
    VALUES (@OrderDate, @TotalAmount, @AmountPaid);
END
GO

CREATE OR ALTER PROCEDURE [dbo].[AddArrival]
    @ArrivalDate DATETIME,
    @TotalAmount DECIMAL,
	@RemainingAmount DECIMAL
AS
BEGIN
    INSERT INTO MoneyArrivals(ArrivalDate, TotalAmount, RemainingAmount)
    VALUES (@ArrivalDate, @TotalAmount, @RemainingAmount);
END
GO

CREATE OR ALTER TRIGGER [dbo].[trg_UpdateOrderAndMoneyArrival]
ON [dbo].[Payments]
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OrderID INT,
            @ArrivalID INT,
            @PaymentAmount DECIMAL(18, 2),
            @PaymentDifference DECIMAL(18, 2);
    
    DECLARE @ErrorMessage NVARCHAR(255);
    DECLARE @ValidCount INT = 0;

    DECLARE db_cursor CURSOR FOR
    SELECT OrderID, ArrivalID, PaymentAmount
    FROM inserted;

    OPEN db_cursor;
    FETCH NEXT FROM db_cursor INTO @OrderID, @ArrivalID, @PaymentAmount;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @PaymentDifference = (SELECT TotalAmount - AmountPaid FROM Orders WHERE OrderID = @OrderID);

        IF @PaymentAmount <= 0 
        BEGIN
            SET @ErrorMessage = 'Ошибка: Сумма платежа должна быть больше нуля для OrderID: ' + CAST(@OrderID AS NVARCHAR);
            RAISERROR(@ErrorMessage, 16, 1);
        END
        ELSE IF @PaymentDifference <= 0
        BEGIN
            SET @ErrorMessage = 'Ошибка: Полная сумма уже оплачена для OrderID: ' + CAST(@OrderID AS NVARCHAR);
            RAISERROR(@ErrorMessage, 16, 1);
        END
        ELSE IF @PaymentAmount > (SELECT RemainingAmount FROM MoneyArrivals WHERE ArrivalID = @ArrivalID)
        BEGIN
            SET @ErrorMessage = 'Ошибка: Недостаточно средств для ArrivalID: ' + CAST(@ArrivalID AS NVARCHAR);
            RAISERROR(@ErrorMessage, 16, 1);
        END
        ELSE
        BEGIN

            INSERT INTO Payments (OrderID, ArrivalID, PaymentAmount)
            VALUES (@OrderID, @ArrivalID, @PaymentAmount);
            
            UPDATE Orders
            SET AmountPaid = AmountPaid + @PaymentAmount
            WHERE OrderID = @OrderID;

            UPDATE MoneyArrivals
            SET RemainingAmount = RemainingAmount - @PaymentAmount
            WHERE ArrivalID = @ArrivalID;

            SET @ValidCount = @ValidCount + 1;
        END

        FETCH NEXT FROM db_cursor INTO @OrderID, @ArrivalID, @PaymentAmount;
    END

    CLOSE db_cursor;
    DEALLOCATE db_cursor;
    PRINT 'Обработано валидных записей: ' + CAST(@ValidCount AS NVARCHAR);
END;
GO