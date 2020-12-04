namespace SchoolPlanner.Entities {
    public class ActivityData
    {
        public string clas { get; set; }
        public string day { get; set; }
        public string group { get; set; }
        public string room { get; set; }
        public int slot { get; set; }
        public string teacher { get; set; }

        public ActivityData() {}

        public ActivityData(string room, int slot, string day, string group, string clas, string teacher) {
            this.room = room;
            this.slot = slot;
            this.day = day;
            this.clas = clas;
            this.group = group;
            this.teacher = teacher;
        }
    }
}