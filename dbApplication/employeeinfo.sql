-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 17 Lut 2021, 17:41
-- Wersja serwera: 10.4.17-MariaDB
-- Wersja PHP: 7.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `employeeinfo`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `employee`
--

CREATE TABLE `employee` (
  `ID` int(11) NOT NULL,
  `Name` text COLLATE utf8_polish_ci NOT NULL,
  `Gender` int(11) NOT NULL,
  `WorkingTime` int(11) NOT NULL,
  `Position` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `employee`
--

INSERT INTO `employee` (`ID`, `Name`, `Gender`, `WorkingTime`, `Position`) VALUES
(1, 'John Doe', 1, 1, 1),
(2, 'Jessica Kowalsky', 2, 1, 2),
(3, 'Marek Zuckerburg', 1, 3, 3),
(4, 'Jermaine Coal', 1, 2, 2),
(5, 'Jessica Grey', 2, 3, 3),
(6, 'Ron Weasley', 1, 1, 2),
(7, 'Aaron Paul', 1, 2, 2),
(8, 'Monica Doe', 2, 2, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `gender`
--

CREATE TABLE `gender` (
  `ID` int(11) NOT NULL,
  `Gender` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `gender`
--

INSERT INTO `gender` (`ID`, `Gender`) VALUES
(1, 'Male'),
(2, 'Female');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `position`
--

CREATE TABLE `position` (
  `ID` int(11) NOT NULL,
  `Position` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `position`
--

INSERT INTO `position` (`ID`, `Position`) VALUES
(1, 'Boss'),
(2, 'Programmer'),
(3, 'Trainee');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `workingtime`
--

CREATE TABLE `workingtime` (
  `ID` int(11) NOT NULL,
  `WorkingTime` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `workingtime`
--

INSERT INTO `workingtime` (`ID`, `WorkingTime`) VALUES
(1, 'Fulltime'),
(2, 'Parttime'),
(3, 'Practice');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Position` (`Position`),
  ADD KEY `WorkingTime` (`WorkingTime`),
  ADD KEY `Gender` (`Gender`);

--
-- Indeksy dla tabeli `gender`
--
ALTER TABLE `gender`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `position`
--
ALTER TABLE `position`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `workingtime`
--
ALTER TABLE `workingtime`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `employee`
--
ALTER TABLE `employee`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT dla tabeli `gender`
--
ALTER TABLE `gender`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `position`
--
ALTER TABLE `position`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `workingtime`
--
ALTER TABLE `workingtime`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`Position`) REFERENCES `position` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `employee_ibfk_2` FOREIGN KEY (`WorkingTime`) REFERENCES `workingtime` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `employee_ibfk_3` FOREIGN KEY (`Gender`) REFERENCES `gender` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
