CREATE DATABASE QuanLyQuanCafe3
GO	

USE QuanLyQuanCafe3
GO

-- Food
-- Table
-- FoodCategory
-- Accounts
-- Bills
-- BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'    --Trống || Có người
)
GO

CREATE TABLE Accounts
(
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Admin',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0 --1: admin || 0: staff
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên', 
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0 

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: đã thanh toán || 0:chưa thanh toán

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

INSERT INTO dbo.Accounts
(
    UserName,
    DisplayName,
    PassWord,
    Type
)
VALUES
(   N'Admin', -- UserName - nvarchar(100)
    N'Admin', -- DisplayName - nvarchar(100)
    N'1', -- PassWord - nvarchar(1000)
    1    -- Type - int
    )

INSERT INTO dbo.Accounts
(
    UserName,
    DisplayName,
    PassWord,
    Type
)
VALUES
(   N'staff', -- UserName - nvarchar(100)
    N'staff', -- DisplayName - nvarchar(100)
    N'1', -- PassWord - nvarchar(1000)
    0    -- Type - int
    )
go


CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Accounts WHERE UserName = @userName
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = N'Admin' -- nvarchar(100)
GO


CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Accounts WHERE UserName = @userName AND PassWord = @passWord
END
GO

--Thêm bàn
DECLARE @i INT = 0

WHILE @i <= 10 
BEGIN
    INSERT dbo.TableFood ( name)VALUES ( N'Bàn ' + CAST(@i AS nvarchar(100)))
	SET @i =@i + 1
END
GO

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood

GO


--Thêm Category

INSERT dbo.FoodCategory (name)
VALUES (N'Cafe')

INSERT dbo.FoodCategory (name)
VALUES (N'Trà')

INSERT dbo.FoodCategory (name)
VALUES (N'Nước ép')

INSERT dbo.FoodCategory (name)
VALUES (N'Sinh tố')

INSERT dbo.FoodCategory (name)
VALUES (N'Bánh tráng miệng')

--Thêm món ăn

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Caremen Chảy', 1, 49000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Capuchino', 1, 45000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Latte', 1, 440000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Ngọc Viễn Đông', 1, 44000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Phin Sữa Đá', 1, 44000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Phin Đen Đá', 1, 35000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Phin Bọt Biển', 1, 35000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Hồng Trà Chanh', 2, 40000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Trà Hoa Hồng', 2, 50000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Latte Trà Xanh', 2, 45000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Trà Đào Sữa', 2, 40000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Táo và dâu ép', 3, 50000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Thơm và dâu ép', 3, 50000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Táo ép', 3, 45000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Dâu ép', 3, 55000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Cam ép', 3, 45000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Dứa ép', 3, 45000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Sinh tố Chanh', 4, 40000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Sinh tố Xoài', 4, 55000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Sinh tố Dâu', 4, 55000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Sinh tố Bơ', 4, 45000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Sinh tố Mãng Cầu', 4, 55000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Sinh tố Dưa hấu', 4, 50000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Sinh tố Chuối', 4, 50000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Bánh mì', 5, 17000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Bánh Choco Trà Xanh', 5, 17000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Panna Cotta chanh dây', 5, 17000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Bánh Tiramisu', 5, 17000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Bánh sừng bò sô cô la bơ', 5, 17000)

INSERT dbo.Food ( name, idCategory, price )
VALUES (   N'Bánh sừng bò', 5, 17000)
GO

--Thêm Bill

INSERT dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    NULL, -- DateCheckOut - date
    3,         -- idTable - int
    0          -- status - int
    )

INSERT dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    NULL, -- DateCheckOut - date
    4,         -- idTable - int
    0          -- status - int
    )

    

INSERT dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    GETDATE(), -- DateCheckOut - date
    5,         -- idTable - int
    1          -- status - int
    )



--Thêm BillInfo

INSERT dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   5, -- idBill - int
    1, -- idFood - int
    2  -- count - int
    )

INSERT dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   5, -- idBill - int
    3, -- idFood - int
    4  -- count - int
    )

INSERT dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   5, -- idBill - int
    5, -- idFood - int
    1  -- count - int
    )

INSERT dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   6, -- idBill - int
    1, -- idFood - int
    2  -- count - int
    )

INSERT dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   6, -- idBill - int
    6, -- idFood - int
    2  -- count - int
    )

INSERT dbo.BillInfo
(
    idBill,
    idFood,
    count
)
VALUES
(   6, -- idBill - int
    5, -- idFood - int
    2  -- count - int
    )
GO



CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
    INSERT dbo.Bill
    (
        DateCheckIn,
        DateCheckOut,
        idTable,
        status,
		discount
    )
    VALUES
    (   GETDATE(), -- DateCheckIn - date
        NULL, -- DateCheckOut - date
        @idTable, -- idTable - int
        0, -- status - int
		0
        )
END
GO

CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1

	SELECT @isExitsBillInfo =id , @foodCount = b.count  
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0) 
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT dbo.BillInfo
		(idBill, idFood, count)
		VALUES ( @idBill, 
		@idFood, 
		@count)
    END
END
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill = idBill FROM Inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0

	UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END
GO


CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
    
	SELECT @idBill = id FROM Inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill 

	DECLARE @count INT = 0

	SELECT @count = COUNT(*) FROM	 dbo.Bill WHERE idTable = @idTable AND status = 0

	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

ALTER TABLE dbo.Bill
ADD discount INT 

UPDATE dbo.Bill SET discount = 0
GO

ALTER TABLE dbo.Bill ADD totalPrice FLOAT

DELETE FROM dbo.BillInfo
DELETE FROM dbo.Bill

GO

CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date 
AS
BEGIN
	SELECT t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1 AND t.id = b.idTable
END
GO




CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @passWord NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT

	SELECT @isRightPass = COUNT(*) FROM dbo.Accounts WHERE USERName = @userName AND PassWord = @passWord

	IF(@isRightPass = 1)
	BEGIN
		IF(@newPassword = NULL OR @newPassword = '')
		BEGIN 
			UPDATE dbo.Accounts SET DisplayName = @displayName WHERE UserName = @userName
		END
		ELSE
			UPDATE dbo.Accounts SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	END
END
GO

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT 
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted

	DECLARE @idTable INT 
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill

	DECLARE @count INT = 0

	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0

	IF(@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

--CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER INT DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END


--SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'muc') + '%'



