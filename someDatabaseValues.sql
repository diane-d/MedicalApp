INSERT INTO dbo.Patients (FirstName, LastName, PhoneNUmber, Email, DateOfBirth, Pathologies) VALUES
('Diane', 'Djunga', '0123456789', 'diane@diane.fr', '1997-06-09 00:00', 'Naime pas les crèpes'),
('Océane', 'Hostin', '0123456789', 'oceane@oceane.fr', '1999-01-01 00:00', 'Naime pas les champignons'),
('Emeline', 'Pal', '0123456789', 'emeline@emeline.fr', '1999-02-19 00:00', 'Naime pas les oignons');


INSERT INTO dbo.Physicians (FirstName, LastName, PhoneNUmber, Email) VALUES
('John', 'Doe', '0123456789', 'john@john.fr'),
('Janette', 'Doe', '0123456789', 'janette@janette.fr');


INSERT INTO dbo.Examinations (PatientId, PhysicianId, DateAndTime, Observations) VALUES
(1, 1, '2020-01-17 00:00', 'Naime vraiment pas les crèpes dis donc !'),
(2, 2, '2020-01-16 00:00', 'Naime vraiment pas les champignons dis donc !'),
(3, 2, '2020-01-15 00:00', 'Naime vraiment pas les oignons dis donc !'),
(3, 1, '2020-01-14 00:00', 'Naime vraiment pas les oignons dis donc olalala !');
