USE DB;

INSERT INTO EquipmentTypes (Name, Description) VALUES
('Laptop', 'Portable computer'),
('Monitor', 'Display screen'),
('Printer', 'Printing device'),
('Phone', 'Desktop phone'),
('Server', 'Server equipment');

INSERT INTO Departments (Name, Code, ParentDepartmentId) VALUES
('Management', 'MGT', NULL),
('IT Department', 'IT', NULL),
('Sales', 'SAL', NULL),
('HR', 'HR', NULL),
('Finance', 'FIN', NULL);

INSERT INTO Employees (FirstName, LastName, MiddleName, Position, DepartmentId, HireDate, Phone, Email) VALUES
('John', 'Smith', 'A.', 'Director', 1, '2020-01-15', '+1-555-0100', 'john.smith@company.com'),
('Sarah', 'Johnson', 'B.', 'IT Manager', 2, '2021-03-10', '+1-555-0101', 'sarah.johnson@company.com'),
('Michael', 'Brown', 'C.', 'Sales Manager', 3, '2022-02-20', '+1-555-0102', 'michael.brown@company.com'),
('Emma', 'Davis', 'D.', 'HR Specialist', 4, '2022-05-12', '+1-555-0103', 'emma.davis@company.com'),
('Robert', 'Wilson', 'E.', 'Accountant', 5, '2023-01-30', '+1-555-0104', 'robert.wilson@company.com');

INSERT INTO Equipment (InventoryNumber, Name, EquipmentTypeId, PurchaseDate, Price, Status, CurrentOwnerId, Location) VALUES
('IT001', 'Dell Laptop', 1, '2023-01-10', 1200.00, 'In Use', 2, 'Room 301'),
('IT002', 'Samsung Monitor', 2, '2023-02-15', 350.00, 'In Use', 2, 'Room 301'),
('MGT001', 'HP Printer', 3, '2022-11-20', 280.00, 'In Use', 1, 'Room 101'),
('SAL001', 'Cisco Phone', 4, '2023-03-01', 150.00, 'In Use', 3, 'Room 201'),
('FIN001', 'Dell Server', 5, '2023-04-10', 2500.00, 'In Storage', NULL, 'Server Room');

INSERT INTO EquipmentHistory (EquipmentId, FromEmployeeId, ToEmployeeId, TransferDate, Reason) VALUES
(1, NULL, 2, '2023-01-12 10:00:00', 'New laptop assigned'),
(2, NULL, 2, '2023-02-20 14:30:00', 'New monitor assigned'),
(3, NULL, 1, '2022-11-25 09:15:00', 'Office printer installed'),
(4, NULL, 3, '2023-03-05 11:00:00', 'Phone for sales department'),
(5, NULL, NULL, '2023-04-12 13:45:00', 'Server installation');