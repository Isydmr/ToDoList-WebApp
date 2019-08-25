Create procedure spAddTask     
(      
   @Name VARCHAR(20),     
   @BeginDate datetime,    
   @EndDate datetime,
   @Finished bit
)      
as      
begin      
    Insert into tblTask (Name,BeginDate,EndDate,Finished)     
    Values (@Name,@BeginDate,@EndDate,@Finished)
End