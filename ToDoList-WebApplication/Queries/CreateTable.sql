Create table tblTask(    
    TaskId int IDENTITY(1,1) NOT NULL,    
    Name varchar(20) NOT NULL,    
    BeginDate datetime NOT NULL,    
    EndDate datetime,
	Finished bit
)