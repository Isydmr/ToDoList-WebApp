Create procedure spDeleteTask     
(      
   @TaskId int      
)      
as       
begin      
   Delete from tblTask where TaskId=@TaskId
End