using System.Collections.Generic;
using SchoolPlanner.Models;

namespace SchoolPlanner.Models
{
    public class RoomModel
    {
        private string roomName;
        private Dictionary<string, ActivityModel> roomActivity;

        public string getRoomName() {
            return this.roomName;
        }

        public void setRoomName(string roomName) {
            this.roomName = roomName;
        }

    }

}