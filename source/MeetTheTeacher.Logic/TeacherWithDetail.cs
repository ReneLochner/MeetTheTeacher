using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Klasse, die einen Detaileintrag mit Link auf dem Namen realisiert.
    /// </summary>
    public class TeacherWithDetail : Teacher {
        private int _id { get; set; }

        public TeacherWithDetail(string name, string day, string hour, string room, string time, int id) : base (name, day, hour, room, time) {
            this._id = id;
        }

        public override string GetHtmlForName() {
            return $"<a href=\"?id={_id}\">{this.getConvertedName (_name)}</a>";
        }
    }
}