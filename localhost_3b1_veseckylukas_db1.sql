--
-- Databáze: `4b1_veseckylukas_db1`
--
CREATE DATABASE IF NOT EXISTS `4b1_veseckylukas_db1` DEFAULT CHARACTER SET utf8 COLLATE utf8_czech_ci;
USE `4b1_veseckylukas_db1`;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbAdmins`
--

CREATE TABLE `tbAdmins` (
  `Id` int(11) NOT NULL,
  `Username` varchar(20) COLLATE utf8_czech_ci NOT NULL,
  `Password` mediumtext COLLATE utf8_czech_ci NOT NULL,
  `Email` varchar(60) COLLATE utf8_czech_ci NOT NULL,
  `RepeatPeriod` text COLLATE utf8_czech_ci DEFAULT NULL,
  `LastEmail` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbAdmins`
--

INSERT INTO `tbAdmins` (`Id`, `Username`, `Password`, `Email`, `RepeatPeriod`, `LastEmail`) VALUES
(1, 'Adamin', '$2a$13$3lyzMH/Hy1gWUrkdqDre3eQ4XrKXRBixOnlDdhf4vGH0dSSRVLHa.', 'adaminuv@mail.adm', '30 10 * * ?', '2023-06-04 18:36:02'),
(38, 'Fuller', '$2a$13$duc2nwjhM2d5AI3wZ5P2weXhHfKZ.RglnYcpqFvi3V05cx3vQUgFa', 'Andrew.Fuller@dbnw.Fp', '* * * * ?', '2023-06-15 20:58:02'),
(41, 'fooo', '$2a$13$uqmuvRD4Gml4i3NdqLDYmO9.BZIeGhw0G5fGucll9X3SRnOJ1VZdm', 'foo@bar.baz', '0 0 1 * ?', '2023-06-05 12:53:01'),
(42, 'marcel', '$2a$13$JnVArh2ETIk.faGXxoHO3OzS8vfjEEvpKaDDEaX40nv1EFj5Li1wS', 'marcel@je.gayy', '0 0 1 * ?', '2023-06-05 13:10:13'),
(43, 'marcel', '$2a$13$z5Za4OmXxBkorls3lPNtLOgwzNZ.Ix7HiSbn9ORtaWF3Ks1tKZtMy', 'marcel@je.gayy', '0 0 1 * ?', '2023-06-05 13:10:17'),
(44, 'marcel', '$2a$13$xqUB6WKq0kKrh3k0Xtvy7O2DWyoOXLczmDWaYVsaG/gDOmD1lWPry', 'marcel@je.gay', '0 0 1 * ?', '2023-06-05 13:13:36'),
(45, 'jirka', '$2a$13$AuMf.p98pH11HPtLg92KYOiK4hAQtyEUpHmXkyY0ISe/s0i6sFn4e', 'jirkuv@mail.yt', '* * * * ?', '2023-06-15 20:58:02');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbConfigs`
--

CREATE TABLE `tbConfigs` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Type` char(4) COLLATE utf8_czech_ci NOT NULL,
  `RepeatPeriod` text COLLATE utf8_czech_ci DEFAULT NULL,
  `ExpirationDate` datetime DEFAULT NULL,
  `Compress` bit(1) DEFAULT b'0',
  `Retention` int(11) DEFAULT 0,
  `PackageSize` int(11) DEFAULT 0,
  `CreatedBy` int(11) DEFAULT NULL,
  `Status` bit(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbConfigs`
--

INSERT INTO `tbConfigs` (`Id`, `Name`, `Type`, `RepeatPeriod`, `ExpirationDate`, `Compress`, `Retention`, `PackageSize`, `CreatedBy`, `Status`) VALUES
(87, 'KASDASDAA', 'full', '* * * * ?', '2023-05-16 00:00:00', b'1', 4, 3, 1, b'0'),
(100, 'TestConfig', 'full', '* * ? * 1', '2024-05-22 12:39:21', b'0', 3, 2, 1, b'1'),
(102, 'KASDASD', 'full', '* * * * ?', '2024-04-24 17:40:28', b'0', 2, 3, 1, b'0'),
(103, 'configTestFooBar', 'full', '* * * * ?', '2024-04-24 17:40:28', b'0', 2, 2, 1, b'0'),
(104, 'stoctverka', 'full', '* * * * ?', '2025-04-22 00:00:00', b'0', 0, 3, 1, b'1'),
(105, 'Test2705', 'full', '* * * * ?', '2024-05-22 12:39:21', b'0', 2, 3, 1, b'1'),
(107, 'stosedma', 'diff', '0/2 * * * ?', '2025-04-24 17:40:28', b'0', 2, 3, 1, b'0'),
(109, 'TestFTP', 'full', '* * * * ?', '2025-04-21 00:00:00', b'0', 5, 5, 1, b'1');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbDestinations`
--

CREATE TABLE `tbDestinations` (
  `Id` int(11) NOT NULL,
  `IdConfig` int(11) DEFAULT NULL,
  `Type` bit(1) NOT NULL,
  `Path` text COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbDestinations`
--

INSERT INTO `tbDestinations` (`Id`, `IdConfig`, `Type`, `Path`) VALUES
(391, 100, b'0', 'C:/DestPath/DestPath'),
(405, 102, b'0', 'C:\\Destpath'),
(410, 105, b'0', 'C:\\dest1'),
(413, 103, b'0', 'C:\\Users\\veseckylukas\\Desktop\\dest1'),
(414, 103, b'0', 'C:\\Users\\veseckylukas\\Desktop\\dest2'),
(442, 104, b'0', 'C:\\Users\\vesec\\Desktop\\dest1'),
(443, 104, b'1', 'ftp://marcel:gat@9.9.9.9:21//gay/gayaaa'),
(452, 87, b'1', 'ftp://marcel:gay@1.1.1.1:21//gaasd/asdas/qwera'),
(453, 87, b'1', 'ftp://marcel:gay@1.1.1.1:21//asdas/qwera'),
(457, 109, b'1', 'ftp://A:123456@192.168.160.159:21//destination');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbGroups`
--

CREATE TABLE `tbGroups` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbGroups`
--

INSERT INTO `tbGroups` (`Id`, `Name`) VALUES
(233, 'AhojTest'),
(171, 'Group 12'),
(159, 'Group 13'),
(89, 'Group name'),
(169, 'NotRootGroup'),
(234, 'pc_1123'),
(223, 'pc_ComputerName'),
(225, 'pc_DATI'),
(237, 'pc_DESKTOP-Q5FLQQ4'),
(229, 'pc_L108PC15'),
(238, 'pc_L108PC16'),
(232, 'pc_L211PC15'),
(236, 'pc_LUKAS-DESKTOPPC'),
(222, 'pc_LUKASVESANB'),
(212, 'pc_PC11'),
(239, 'ricijeteplej');

--
-- Spouště `tbGroups`
--
DELIMITER $$
CREATE TRIGGER `trPreventDeleteGroupAfterDelete` AFTER DELETE ON `tbGroups` FOR EACH ROW BEGIN   
    
    If left(old.Name, 3) = 'pc_' and (SELECT count(*) from tbPCs where concat('pc_', name) = old.Name) > 0 THEN
    	        SIGNAL SQLSTATE '45000' 
            SET MESSAGE_TEXT = 'Cannot delete a root group.';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trPreventGroupRenameBeforeUpdate` BEFORE UPDATE ON `tbGroups` FOR EACH ROW BEGIN
    If left(old.Name, 3) = 'pc_' and (SELECT count(*) from tbPCs where concat('pc_', name) = old.Name) > 0 THEN
        SIGNAL SQLSTATE '45000' 
            SET MESSAGE_TEXT = 'Cannot rename root PC Group.';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trPreventInsertGroupBeforeInsert` BEFORE INSERT ON `tbGroups` FOR EACH ROW BEGIN
    IF (LOWER(LEFT(NEW.Name, 3)) = 'pc_' AND NOT
        (SELECT COUNT(*) FROM tbPCs WHERE Name = RIGHT(NEW.Name, CHAR_LENGTH(NEW.Name) - 3)) > 0) THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Cannot add group with name starting with pc_. This name is reserved for root groups.';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbPCGroups`
--

CREATE TABLE `tbPCGroups` (
  `IdGroup` int(11) NOT NULL,
  `IdPC` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbPCGroups`
--

INSERT INTO `tbPCGroups` (`IdGroup`, `IdPC`) VALUES
(169, 210),
(212, 210),
(222, 221),
(223, 223),
(225, 225),
(229, 229),
(232, 232),
(234, 233),
(236, 236),
(237, 237),
(238, 238),
(239, 210),
(239, 221),
(239, 223);

--
-- Spouště `tbPCGroups`
--
DELIMITER $$
CREATE TRIGGER `trDenyInsertPCInGroupAfterInsert` BEFORE INSERT ON `tbPCGroups` FOR EACH ROW BEGIN
    DECLARE group_name VARCHAR(50);

        SELECT name INTO group_name FROM tbGroups WHERE id = NEW.idGroup;

		    IF (LOWER(LEFT(group_name, 3)) = 'pc_' AND NOT
        (SELECT COUNT(*) FROM tbPCs WHERE Name = RIGHT(group_name, CHAR_LENGTH(group_name) - 3)) > 0) THEN
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Cannot insert PC in a root group.';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trPreventDeletePCGroup` BEFORE DELETE ON `tbPCGroups` FOR EACH ROW BEGIN
    DECLARE group_name VARCHAR(50);

    SELECT name INTO group_name FROM tbGroups WHERE id = old.idGroup;

    IF left(group_name, 3) = 'pc_' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Cannot delete PC from its root group.';
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trPreventUpdatePCGroup` BEFORE UPDATE ON `tbPCGroups` FOR EACH ROW BEGIN
    DECLARE group_name VARCHAR(50);

    SELECT name INTO group_name FROM tbGroups WHERE id = old.idGroup;

    IF left(group_name, 3) = 'pc_' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Cannot remove PC from its root group.';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbPCs`
--

CREATE TABLE `tbPCs` (
  `Id` int(11) NOT NULL,
  `Name` varchar(20) COLLATE utf8_czech_ci DEFAULT NULL,
  `MacAddress` varchar(12) COLLATE utf8_czech_ci NOT NULL,
  `IpAddress` varchar(15) COLLATE utf8_czech_ci NOT NULL,
  `Status` char(1) COLLATE utf8_czech_ci NOT NULL DEFAULT 'q'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbPCs`
--

INSERT INTO `tbPCs` (`Id`, `Name`, `MacAddress`, `IpAddress`, `Status`) VALUES
(210, 'PC11', '000BD063C226', '128.0.25.24', 't'),
(221, 'LUKASVESANB', '00090FAA0001', '192.168.91.16', 't'),
(223, 'ComputerName', '001122334455', '1.1.1.23', 'q'),
(225, 'DATI', '00090FAA0001', '192.168.91.16', 't'),
(229, 'L108PC15', '30D042E6D82F', '192.168.105.15', 't'),
(232, 'L211PC15', '1866DA144F90', '192.168.108.15', 't'),
(233, '1123', 'B88584A33FF4', '192.168.101.15', 't'),
(236, 'LUKAS-DESKTOPPC', '00090FAA0001', '192.168.91.21', 't'),
(237, 'DESKTOP-Q5FLQQ4', '00090FAA0001', '192.168.91.29', 't'),
(238, 'L108PC16', '30D042E6C793', '192.168.105.16', 't');

--
-- Spouště `tbPCs`
--
DELIMITER $$
CREATE TRIGGER `trCreateGroupAfterInsert` AFTER INSERT ON `tbPCs` FOR EACH ROW BEGIN
    DECLARE group_count INT;
    DECLARE group_id INT DEFAULT 0;
    SELECT COUNT(*) INTO group_count FROM tbGroups WHERE Name = NEW.Name;
    
    IF group_count > 0 THEN
        SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Cannot insert the PC because a group with the same name already exists';
    ELSE
        INSERT INTO tbGroups (Name) VALUES (Concat('pc_', NEW.Name));
        SET group_id = LAST_INSERT_ID();
        INSERT INTO tbPCGroups (idPC, idGroup) VALUES (NEW.id, group_id);
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trDeleteGroupAfterPCDelete` AFTER DELETE ON `tbPCs` FOR EACH ROW BEGIN
    IF (select count(*) from tbGroups where concat('pc_',OLD.Name) = tbGroups.Name) = 1 THEN
        DELETE FROM tbGroups WHERE Name = concat('pc_',OLD.Name);
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trUpdateGroupNameAfterUpdate` AFTER UPDATE ON `tbPCs` FOR EACH ROW BEGIN
	DECLARE group_count INT;

	if not OLD.Name = New.Name then
	SELECT COUNT(*) INTO group_count FROM tbGroups WHERE Name = concat('pc_',NEW.Name);
	
	if group_count > 0 then
        SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Cannot update the PC because a group with the same name already exists';
	else
		UPDATE tbGroups SET Name = concat('pc_',NEW.Name) WHERE Name = concat('pc_',old.Name);
	end if;
	end if;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbReports`
--

CREATE TABLE `tbReports` (
  `Id` int(11) NOT NULL,
  `IdPc` int(11) NOT NULL,
  `IdConfig` int(11) NOT NULL,
  `Status` char(1) COLLATE utf8_czech_ci NOT NULL,
  `ReportTime` datetime NOT NULL,
  `Description` text COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbReports`
--

INSERT INTO `tbReports` (`Id`, `IdPc`, `IdConfig`, `Status`, `ReportTime`, `Description`) VALUES
(76, 236, 104, 'w', '2023-06-03 18:53:04', '[\"Source(Id:Daemon.Models.Source) does not exist.\",\"Source(Id:Daemon.Models.Source) does not exist.\"]'),
(90, 237, 109, 't', '2023-06-04 22:20:11', NULL),
(91, 237, 109, 't', '2023-06-04 22:24:00', NULL),
(96, 238, 109, 't', '2023-06-05 15:12:00', NULL),
(97, 238, 109, 't', '2023-06-05 15:13:00', NULL),
(98, 238, 109, 't', '2023-06-05 15:37:00', NULL),
(99, 238, 109, 't', '2023-06-05 15:38:00', NULL),
(100, 238, 109, 't', '2023-06-05 15:39:00', NULL),
(101, 238, 109, 't', '2023-06-05 15:40:00', NULL);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbSnapshots`
--

CREATE TABLE `tbSnapshots` (
  `IdConfig` int(11) NOT NULL,
  `ComputerId` int(11) NOT NULL,
  `Snapshot` longtext COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbSnapshots`
--

INSERT INTO `tbSnapshots` (`IdConfig`, `ComputerId`, `Snapshot`) VALUES
(102, 210, NULL),
(103, 229, NULL),
(104, 232, NULL),
(104, 233, NULL),
(104, 236, NULL),
(109, 238, NULL);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbSources`
--

CREATE TABLE `tbSources` (
  `Id` int(11) NOT NULL,
  `IdConfig` int(11) DEFAULT NULL,
  `Path` text COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbSources`
--

INSERT INTO `tbSources` (`Id`, `IdConfig`, `Path`) VALUES
(463, 100, 'C:/path/path'),
(478, 102, 'C:\\path\\longerPath'),
(479, 102, 'C:\\secondPath'),
(486, 105, 'C:\\source1'),
(490, 103, 'C:\\Users\\veseckylukas\\Desktop\\source1'),
(491, 103, 'C:\\Users\\veseckylukas\\Desktop\\source2'),
(504, 104, 'C:\\Users\\vesec\\Desktop\\source1'),
(505, 104, 'C:\\Users\\veseckylukas\\Desktop\\source2'),
(506, 104, 'C:\\Users\\veseckylukas\\Desktop\\source3'),
(510, 109, 'C:\\Users\\gazikmarcel\\Desktop\\testdest');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbTasks`
--

CREATE TABLE `tbTasks` (
  `IdConfig` int(11) NOT NULL,
  `IdGroup` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbTasks`
--

INSERT INTO `tbTasks` (`IdConfig`, `IdGroup`) VALUES
(102, 212),
(103, 229),
(104, 232),
(104, 234),
(104, 236),
(109, 238);

--
-- Spouště `tbTasks`
--
DELIMITER $$
CREATE TRIGGER `trDeleteSnapshots` AFTER DELETE ON `tbTasks` FOR EACH ROW BEGIN
    DELETE FROM tbSnapshots
    WHERE idConfig = OLD.idConfig
        AND ComputerId IN (SELECT idPC FROM tbPCGroups WHERE idGroup = OLD.idGroup);
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trInsertSnapshots` AFTER INSERT ON `tbTasks` FOR EACH ROW BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE pc_id INT;
    DECLARE cur CURSOR FOR
        SELECT idPC
        FROM tbPCGroups
        WHERE idGroup = NEW.idGroup;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    OPEN cur;

    read_loop: LOOP
        FETCH cur INTO pc_id;
        IF done THEN
            LEAVE read_loop;
        END IF;

        INSERT INTO tbSnapshots (idConfig, ComputerId)
        VALUES (NEW.idConfig, pc_id);
    END LOOP;

    CLOSE cur;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktura tabulky `tbTokens`
--

CREATE TABLE `tbTokens` (
  `idAdmin` int(11) NOT NULL,
  `Token` mediumtext COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `tbAdmins`
--
ALTER TABLE `tbAdmins`
  ADD PRIMARY KEY (`Id`);

--
-- Klíče pro tabulku `tbConfigs`
--
ALTER TABLE `tbConfigs`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CreatedBy` (`CreatedBy`);

--
-- Klíče pro tabulku `tbDestinations`
--
ALTER TABLE `tbDestinations`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `tbDestinations_ibfk_1` (`IdConfig`);

--
-- Klíče pro tabulku `tbGroups`
--
ALTER TABLE `tbGroups`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Klíče pro tabulku `tbPCGroups`
--
ALTER TABLE `tbPCGroups`
  ADD PRIMARY KEY (`IdGroup`,`IdPC`),
  ADD KEY `tbPcGroups_ibfk_1` (`IdPC`),
  ADD KEY `idGroup` (`IdGroup`);

--
-- Klíče pro tabulku `tbPCs`
--
ALTER TABLE `tbPCs`
  ADD PRIMARY KEY (`Id`) USING BTREE,
  ADD UNIQUE KEY `UniquePCName` (`Name`),
  ADD KEY `MACAddress` (`MacAddress`);

--
-- Klíče pro tabulku `tbReports`
--
ALTER TABLE `tbReports`
  ADD PRIMARY KEY (`Id`);

--
-- Klíče pro tabulku `tbSnapshots`
--
ALTER TABLE `tbSnapshots`
  ADD PRIMARY KEY (`IdConfig`,`ComputerId`),
  ADD KEY `fk_tbPCs_idPC` (`ComputerId`),
  ADD KEY `fk_tbConfigs_idConfig` (`IdConfig`) USING BTREE;

--
-- Klíče pro tabulku `tbSources`
--
ALTER TABLE `tbSources`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `tbSources_ibfk_1` (`IdConfig`);

--
-- Klíče pro tabulku `tbTasks`
--
ALTER TABLE `tbTasks`
  ADD PRIMARY KEY (`IdGroup`,`IdConfig`),
  ADD KEY `tbTasks_ibfk_2` (`IdConfig`),
  ADD KEY `tbTasks_ibfk1` (`IdGroup`) USING BTREE;

--
-- Klíče pro tabulku `tbTokens`
--
ALTER TABLE `tbTokens`
  ADD PRIMARY KEY (`idAdmin`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `tbAdmins`
--
ALTER TABLE `tbAdmins`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=46;

--
-- AUTO_INCREMENT pro tabulku `tbConfigs`
--
ALTER TABLE `tbConfigs`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=110;

--
-- AUTO_INCREMENT pro tabulku `tbDestinations`
--
ALTER TABLE `tbDestinations`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=458;

--
-- AUTO_INCREMENT pro tabulku `tbGroups`
--
ALTER TABLE `tbGroups`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=240;

--
-- AUTO_INCREMENT pro tabulku `tbPCs`
--
ALTER TABLE `tbPCs`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=239;

--
-- AUTO_INCREMENT pro tabulku `tbReports`
--
ALTER TABLE `tbReports`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT pro tabulku `tbSources`
--
ALTER TABLE `tbSources`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=511;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `tbDestinations`
--
ALTER TABLE `tbDestinations`
  ADD CONSTRAINT `tbDestinations_ibfk_1` FOREIGN KEY (`IdConfig`) REFERENCES `tbConfigs` (`Id`) ON DELETE CASCADE;

--
-- Omezení pro tabulku `tbPCGroups`
--
ALTER TABLE `tbPCGroups`
  ADD CONSTRAINT `tbPCGroups_ibfk_1` FOREIGN KEY (`IdPC`) REFERENCES `tbPCs` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `tbPCGroups_ibfk_2` FOREIGN KEY (`IdGroup`) REFERENCES `tbGroups` (`Id`) ON DELETE CASCADE;

--
-- Omezení pro tabulku `tbSnapshots`
--
ALTER TABLE `tbSnapshots`
  ADD CONSTRAINT `fk_tbConfigs_idConfig` FOREIGN KEY (`IdConfig`) REFERENCES `tbConfigs` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_tbPCs_idPC` FOREIGN KEY (`ComputerId`) REFERENCES `tbPCs` (`Id`) ON DELETE CASCADE;

--
-- Omezení pro tabulku `tbSources`
--
ALTER TABLE `tbSources`
  ADD CONSTRAINT `tbSources_ibfk_1` FOREIGN KEY (`IdConfig`) REFERENCES `tbConfigs` (`Id`) ON DELETE CASCADE;

--
-- Omezení pro tabulku `tbTasks`
--
ALTER TABLE `tbTasks`
  ADD CONSTRAINT `tbTasks_ibfk_1` FOREIGN KEY (`IdGroup`) REFERENCES `tbGroups` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `tbTasks_ibfk_2` FOREIGN KEY (`IdConfig`) REFERENCES `tbConfigs` (`Id`) ON DELETE CASCADE;

--
-- Omezení pro tabulku `tbTokens`
--
ALTER TABLE `tbTokens`
  ADD CONSTRAINT `tbConfigs_ibFk_ontbAdmins` FOREIGN KEY (`idAdmin`) REFERENCES `tbAdmins` (`Id`) ON DELETE CASCADE;
