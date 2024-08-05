CREATE DATABASE Project;
GO
USE Project;

CREATE TABLE Cards (
  	CardNumber BIGINT UNIQUE NOT NULL,
	CardType VARCHAR(35) NOT NULL,
    Name VARCHAR(35) NULL,
    Surname VARCHAR(35) NULL,
	PESEL BIGINT NULL,
	CardExpiryDate VARCHAR(7) NOT NULL,
	CardAccountNumber VARCHAR(28) NOT NULL,
	Amount DECIMAL(5, 2) NOT NULL,
	CardPaid BIT NOT NULL DEFAULT 0
);

insert into Cards (CardNumber, CardType, CardExpiryDate, CardAccountNumber, Amount) values (1234567837933093, 'nonpersonalized', '2023-08', 'PL63114018343076667446531595', 0.00);
insert into Cards (CardNumber, CardType, CardExpiryDate, CardAccountNumber, Amount) values (1234567854845183, 'nonpersonalized', '2023-09', 'PL41114079402031311768242350', 151.62);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567830954305, 'personalized', 'Amadeusz', 'Kwiatkowski', 61040304376, '2024-01', 'PL51114045587174232566249016', 81.72);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567832204438, 'personalized', 'Jerzy', 'Przybylski', 73122295867, '2024-03', 'PL33114076053795939065350688', 0.00);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567817378371, 'personalized', 'Bogumi³a', 'Urbañska', 25912813537, '2024-03', 'PL94114056309724598705352846', 104.05);
insert into Cards (CardNumber, CardType, CardExpiryDate, CardAccountNumber, Amount) values (1234567896079855, 'nonpersonalized', '2023-09', 'PL13114004207966427131738909', 147.43);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567861142689, 'personalized', 'Dominik', 'Szymczak', 37052492761, '2023-10', 'PL72114050890551688787299967', 1.74);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567835430480, 'personalized', 'Amelia', 'Mazur', 89911289412, '2023-09', 'PL83114069724130590995487856', 64.79);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567889170577, 'personalized', 'Nina', 'Sikorska', 99483097401, '2024-03', 'PL39114012674941041349170362', 160.41);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567895792881, 'personalized', 'Julita', 'Gajewska', 08042358323, '2024-04', 'PL84114011953252368251649537', 0.98);
insert into Cards (CardNumber, CardType, CardExpiryDate, CardAccountNumber, Amount) values (1234567802135514, 'nonpersonalized', '2024-06', 'PL73114042266339759284598925', 0.00);
insert into Cards (CardNumber, CardType, CardExpiryDate, CardAccountNumber, Amount) values (1234567803764786, 'nonpersonalized', '2023-12', 'PL27114063634156419255958613', 193.44);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567827529735, 'personalized', 'Julita', 'Gajewska', 08042358323, '2024-05', 'PL62114011829585422379588078', 198.35);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567841939586, 'personalized', 'Alicja', 'Makowska', 85842466494, '2024-02', 'PL52114002990452083903047783', 11.49);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567842440290, 'personalized', 'Jadwiga', 'Malinowska', 76102595386, '2023-11', 'PL06114086572820193782987016', 200.00);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567867691150, 'personalized', 'Karol', 'Kalinowski', 60032339073, '2024-02', 'PL17114089474578356019363855', 102.71);
insert into Cards (CardNumber, CardType, Name, Surname, PESEL, CardExpiryDate, CardAccountNumber, Amount) values (1234567837612208, 'personalized', 'Amadeusz', 'Kwiatkowski', 61040304376, '2024-03', 'PL30114092509688203535054221', 33.88);
insert into Cards (CardNumber, CardType, CardExpiryDate, CardAccountNumber, Amount) values (1234567876299126, 'nonpersonalized', '2024-02', 'PL27114031603863491844999365', 10.01);
insert into Cards (CardNumber, CardType, CardExpiryDate, CardAccountNumber, Amount) values (1234567899036363, 'nonpersonalized', '2023-07', 'PL62114045610665232385197177', 4.12);
insert into Cards (CardNumber, CardType, CardExpiryDate, CardAccountNumber, Amount) values (1234567899036399, 'nonpersonalized', '2020-07', 'PL62114053403667227476438715', 144.12);



CREATE TABLE Payments (
  	CardNumber BIGINT NOT NULL,
	Name VARCHAR(35) NULL,
    Surname VARCHAR(35) NULL,
	AccountNumber VARCHAR(26) NOT NULL,
	Amount DECIMAL(5, 2) NOT NULL,
	Effected BIT NOT NULL DEFAULT 0);

INSERT INTO Payments (
CardNumber, 
Name, 
Surname, 
AccountNumber,
Amount
) 
VALUES
(123456, 
'Jan', 
'Kowalski', 
12345678912345678912345678,
200.00
);

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(35) NOT NULL,
	Password VARCHAR(35) NOT NULL,
	Role VARCHAR(35) NOT NULL
);

