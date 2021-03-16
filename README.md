# SchoolPlannerapplication built using ASP.NET MVC
Project done for EGUI course at Warsaw University of Technology.  

## Description
Application was built using ASP.NET MVC and Razor.  
  * The user can edit dictionaries - add and remove classes, rooms, teachers and groups.
  * If any of dictionary input will be deleted, related activity will be deleted as well.
  * User can add new activity by clicking on the table slot.
  * If newly added activity overlaps with already existing one - for instance if user added in the different room but on the same slot and day the same group, older activity will be removed.
  * User can edit table entry by clicking on it. There will be displayed more informations about selected entry and ability to edit it.
  * "unassign" button is available only if selected entry has assigned any data.


## Assumptions  
  * School data is being read from .json file named "data.json". If the file does not exists, such file will be created.
  * If the file is empty, empty School Planner will be initialized.
  * Input data must not inconsistent.
  * Input data can be empty.

## Build&run  
dotnet build; dotnet run;

## Demo  

![alt text](https://github.com/Kjablonska/ASP.NET-MVC-SchoolPlanner/blob/master/assets/school-planner-net.gif?raw=true)  

**Main view**  
Main view contains time table and menu. From this page the user can select dictionary to display and add/edit any timeslot on the timetable.  
![alt text](https://github.com/Kjablonska/ASP.NET-MVC-SchoolPlanner/blob/master/assets/main-view.png?raw=true)  

**Activity view**  
Activity view shows details of the selected timetable entry. It allows for edition - for already assigned entries there is a possibility to 'Unassign'.  
![alt text](https://github.com/Kjablonska/ASP.NET-MVC-SchoolPlanner/blob/master/assets/activity-view.png?raw=true)  

**Dictionary view**  
Dictionary view presents the content of the selected dictionary. It allows to entries edition/removal.  
![alt text](https://github.com/Kjablonska/ASP.NET-MVC-SchoolPlanner/blob/master/assets/dictionary-view.png?raw=true)

**Edition view**
Edition of dictionary entry view.  
![alt text](https://github.com/Kjablonska/ASP.NET-MVC-SchoolPlanner/blob/master/assets/edit-view.png?raw=true)
