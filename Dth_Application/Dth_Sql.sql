CREATE TABLE UserDetails (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    UserName VARCHAR(100),
    mail_iD VARCHAR(100),
    number VARCHAR(15),
    wallet_balance VARCHAR(100)
);

CREATE TABLE Pack_Details(
	Pack_iD VARCHAR(100),
    Pack_name VARCHAR(100),
    Price VARCHAR(100),
    Validity VARCHAR(100),
    No_of_channels VARCHAR(100)
);
CREATE TABLE Recharge_History(
    User_Id VARCHAR(100),
    Recharge_Id INT AUTO_INCREMENT PRIMARY KEY,
    Pack_ID  VARCHAR(100),
    Recharge_Amount DOUBLE,
    Recharge_Date datetime,
    Valid_Time DATETIME,
    No_of_channels INT
);



INSERT INTO Recharge_History 
VALUES ('1001', '101', 'RC150', 150, '2024-02-02', DATE_ADD('2024-02-02', INTERVAL 28 DAY), 100);

drop table userdetails;
ALTER TABLE Recharge_History MODIFY COLUMN Recharge_Id VARCHAR(100);
ALTER TABLE Recharge_History Add Column Wallet_Balance DOUBLE;
delete from recharge_history;
delete from userdetails;

select * from userdetails




