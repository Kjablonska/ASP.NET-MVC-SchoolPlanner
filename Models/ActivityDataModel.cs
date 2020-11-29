namespace ActivityData.Models
{
    public class ActivityDataModel
    {
        private string room;
        private string group;
        private string clas;
        private int slot;
        private string day;
        private string teacher;

        public ActivityDataModel() {}
        public ActivityDataModel(string room, string group, string clas, int slot, string day, string teacher)
        {
            this.room = room;
            this.group = group;
            this.clas = clas;
            this.slot = slot;
            this.day = day;
            this.teacher = teacher;
        }

        public string getRoom()
        {
            return this.room;
        }

        public void setRoom(string room)
        {
            this.room = room;
        }

        public string getGroup()
        {
            return this.group;
        }

        public void setGroup(string group)
        {
            this.group = group;
        }

        public string getClas()
        {
            return this.clas;
        }

        public void setClas(string clas)
        {
            this.clas = clas;
        }

        public int getSlot()
        {
            return this.slot;
        }

        public void setSlot(int slot)
        {
            this.slot = slot;
        }

        public string getDay()
        {
            return this.day;
        }

        public void setDay(string day)
        {
            this.day = day;
        }

        public string getTeacher()
        {
            return this.teacher;
        }

        public void setTeacher(string teacher)
        {
            this.teacher = teacher;
        }

    }
}