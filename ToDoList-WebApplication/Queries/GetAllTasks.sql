Create procedure spGetAllTasks
as    
Begin    
    select *    
    from tblTask 
    order by TaskId    
End