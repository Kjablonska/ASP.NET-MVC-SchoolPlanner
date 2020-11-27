using System;
using System.Collections.Generic;

namespace SchoolPlanner.Models
{
    public class SchoolData
    {
        Dictionary<string, int> DAY_TO_INT = new Dictionary<string, int> { { "Monday", 0 }, { "Tuesday", 1 }, { "Wednesday", 2 }, { "Thursday", 3 }, { "Friday", 4 } };
        private List<string> roomList;
        private List<string> classesList;
        private List<string> groupsList;
        private List<string> teachersList;

        public List<string> getRoomList()
        {
            return this.roomList;
        }

        public void setRoomList(List<string> roomList)
        {
            this.roomList = roomList;
        }

        public List<string> getClassesList()
        {
            return this.classesList;
        }

        public void setClassesList(List<string> classesList)
        {
            this.classesList = classesList;
        }

        public List<string> getGroupsList()
        {
            return this.groupsList;
        }

        public void setGroupsList(List<string> groupsList)
        {
            this.groupsList = groupsList;
        }

        public List<string> getTeachersList()
        {
            return this.teachersList;
        }

        public void setTeachersList(List<string> teachersList)
        {
            this.teachersList = teachersList;
        }

    }
}
