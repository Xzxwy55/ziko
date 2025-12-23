USE DB;

ALTER TABLE Departments 
ADD CONSTRAINT FK_Departments_Parent 
FOREIGN KEY (ParentDepartmentId) 
REFERENCES Departments(Id);

ALTER TABLE Employees 
ADD CONSTRAINT FK_Employees_Department 
FOREIGN KEY (DepartmentId) 
REFERENCES Departments(Id);

ALTER TABLE Equipment 
ADD CONSTRAINT FK_Equipment_EquipmentType 
FOREIGN KEY (EquipmentTypeId) 
REFERENCES EquipmentTypes(Id);

ALTER TABLE Equipment 
ADD CONSTRAINT FK_Equipment_Employee 
FOREIGN KEY (CurrentOwnerId) 
REFERENCES Employees(Id);

ALTER TABLE EquipmentHistory 
ADD CONSTRAINT FK_EquipmentHistory_Equipment 
FOREIGN KEY (EquipmentId) 
REFERENCES Equipment(Id);

ALTER TABLE EquipmentHistory 
ADD CONSTRAINT FK_EquipmentHistory_FromEmployee 
FOREIGN KEY (FromEmployeeId) 
REFERENCES Employees(Id);

ALTER TABLE EquipmentHistory 
ADD CONSTRAINT FK_EquipmentHistory_ToEmployee 
FOREIGN KEY (ToEmployeeId) 
REFERENCES Employees(Id);