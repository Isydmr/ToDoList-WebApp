Create procedure spUpdateTask     
(      
   @TaskId INTEGER,    
   @Name VARCHAR(20),     
   @BeginDate datetime,    
   @EndDate datetime,
   @Finished bit
)      
as      
begin      
   Update tblTask       
   set Name=@Name,      
   BeginDate=@BeginDate,      
   EndDate=@EndDate,
   Finished=@Finished
   where TaskId=@TaskId
End