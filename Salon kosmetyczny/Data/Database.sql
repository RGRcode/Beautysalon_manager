CREATE TABLE Klienci(
                        Id INT IDENTITY (1,1) PRIMARY KEY,
                        Imie NVARCHAR(100) NOT NULL,
                        Nazwisko NVARCHAR(100) NOT NULL,
                        NrTelefonu NVARCHAR(15) NOT NULL,
                        Email NVARCHAR(100)
);

CREATE TABLE Kategorie_produktow(
                                    Id INT IDENTITY (1,1) PRIMARY KEY,
                                    Nazwa NVARCHAR(100) NOT NULL
);

CREATE TABLE Produkty(
                         Id INT IDENTITY (1,1) PRIMARY KEY,
                         KategoriaId INT NOT NULL,
                         Nazwa NVARCHAR(100),
                         Marka NVARCHAR(100),
                         AktualnyStan DECIMAL(10,2) NOT NULL DEFAULT 0,
                         MinimalnyStan DECIMAL(10,2) NOT NULL DEFAULT 0,
                         JednostkaMiary NVARCHAR(20) NOT NULL,
                         Cena DECIMAL(10,2) NOT NULL,

                         FOREIGN KEY (KategoriaId) REFERENCES Kategorie_produktow(Id)
);

CREATE TABLE Zabiegi(
                        Id INT IDENTITY (1,1) PRIMARY KEY,
                        Nazwa NVARCHAR(100) NOT NULL,
                        Opis NVARCHAR(500),
                        CzasTrwania INT NOT NULL,
                        Cena DECIMAL(10,2) NOT NULL
);


CREATE TABLE Sklad_zabiegu(
                              ZabiegId INT NOT NULL,
                              ProduktId INT NOT NULL,
                              WymaganaIlość DECIMAL(10,2) NOT NULL,

                              PRIMARY KEY (ZabiegId, ProduktId),
                              FOREIGN KEY (ZabiegId) REFERENCES Zabiegi(Id),
                              FOREIGN KEY (ProduktId) REFERENCES Produkty(Id)
);

CREATE TABLE Wizyty(
                       Id INT IDENTITY (1,1) PRIMARY KEY,
                       KlientId INT NOT NULL,
                       ZabiegId INT NOT NULL,
                       DataCzasWizyty DATETIME2 NOT NULL,
                       CenaOstateczna DECIMAL(10,2) NOT NULL,

                       FOREIGN KEY (KlientId) REFERENCES Klienci(Id),
                       FOREIGN KEY (ZabiegId) REFERENCES Zabiegi(Id)
);


INSERT INTO Kategorie_produktow (Nazwa) VALUES
                                            (N'Kwasy i peeelingi chemiczne'),
                                            (N'Kremi, maski i sera'),
                                            (N'Materiały jednorazowe'),
                                            (N'Akcesoria zabiegowe i kartridże');

INSERT INTO Produkty(KategoriaId, Nazwa, Marka,AktualnyStan,MinimalnyStan, JednostkaMiary, Cena) VALUES
                                                                                                     (1,'Kwas trójfazowy BioRePeelCl3',N'BioRePeel',35.00, 15.00, N'ml',280.00),
                                                                                                     (1, N'Kwas migdałowy 40%', N'Apis', 12.00, 20.00, N'ml', 65.00),
                                                                                                     (1, N'Neutralizator do kwasów', N'Apis', 150.00, 50.00, N'ml', 45.00),
                                                                                                     (2, N'Krem łagodzący po zabiegach', N'Charmine Rose', 200.00, 50.00, N'ml', 110.00),
                                                                                                     (2, N'Maska algowa z ceramidami', N'Apis', 450.00, 100.00, N'ml', 75.00),
                                                                                                     (2, N'Serum z witaminą C', N'Charmine Rose', 15.00, 15.00, N'ml', 140.00),
                                                                                                     (3, N'Ręczniki jednorazowe włókninowe', N'MedComfort', 120.00, 50.00, N'szt', 35.00),
                                                                                                     (3, N'Waciki bezpyłowe', N'CleanBeauty', 300.00, 100.00, N'szt', 18.00),
                                                                                                     (3, N'Rękawiczki nitrylowe (para)', N'Mercator', 8.00, 20.00, N'szt', 40.00),
                                                                                                     (4, N'Kartridż jednorazowy do mezoterapii mikroigłowej', N'Dr.Pen', 25.00, 10.00, N'szt', 15.00);


INSERT INTO Zabiegi (nazwa, opis, czastrwania, cena) VALUES
                                                         (N'Oczyszczanie wodorowe + BioRePeel', N'Głębokie oczyszczanie skóry połączone z biostymulującją kwasem BioRePeel',60,300.00),
                                                         (N'Eksfoliacja kwasem migdałowym', N'Delikatny zabieg złuszczający i rozjaśniający z maską algową.', 45, 200.00),
                                                         (N'Mezoterapia mikroigłowa twarzy', N'Mikronakłuwanie skóry z ampułką witaminową i kremem łagodzącym.', 75, 350.00);

INSERT INTO Klienci(imie, nazwisko, nrtelefonu, email) VALUES
                                                           (N'Anna', N'Kowalska', N'500100200', N'anna.kowalska@example.com'),
                                                           (N'Karolina', N'Nowak', N'600200300', N'k.nowak@example.com'),
                                                           (N'Magdalena', N'Wiśniewska', N'700300400', N'magda.w@example.com'),
                                                           (N'Joanna', N'Wójcik', N'505606707', N'joanna.wojcik@example.com'),
                                                           (N'Aleksandra', N'Kamińska', N'888999000', NULL);

INSERT INTO Sklad_zabiegu(ZabiegId, ProduktId, WymaganaIlość) VALUES
                                                                  (1, 1, 5.00),
                                                                  (1, 4, 10.00),
                                                                  (1, 7, 5.00),
                                                                  (1, 9, 1.00);

INSERT INTO Sklad_zabiegu (ZabiegId, ProduktId, WymaganaIlość) VALUES
                                                                   (2, 2, 10.00),
                                                                   (2, 3, 15.00),
                                                                   (2, 5, 30.00),
                                                                   (2, 7, 3.00);

INSERT INTO Sklad_zabiegu (ZabiegId, ProduktId, WymaganaIlość) VALUES
                                                                   (3, 10, 1.00),
                                                                   (3, 6, 5.00),
                                                                   (3, 4, 10.00),
                                                                   (3, 7, 4.00),
                                                                   (3, 9, 1.00);

INSERT INTO Wizyty (KlientId, ZabiegId, DataCzasWizyty, CenaOstateczna) VALUES
                                                                            (1, 1, '2026-12-23 15:00:00', 300.00),
                                                                            (2, 3, '2026-12-30 17:30:00', 350.00);

