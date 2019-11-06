using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Verwaltet einen Eintrag in der Sprechstundentabelle
    /// Basisklasse für TeacherWithDetail
    /// </summary>
    public class Teacher : IComparable
    {
       // Name;Tag;EH;Zeit;Raum;Bemerkung
       public string _name { get; set; }
       private string _day;
       private string _hour;
       private string _room;
       private string _time;

       public Teacher(string name, string day, string hour, string room, string time) {
            this._name = name;
            this._day = day;
            this._hour = hour;
            this._room = room;
            this._time = time;
       }

       public virtual string GetHtmlForName() {
            return getConvertedName(_name);
       }

        public string GetTeacherHtmlRow() {
            string result = "";

            result += "<tr>";
            result += $"<th align=\"left\">{GetHtmlForName()}</th>";
            result += $"<th align=\"left\">{_day}</th>";
            result += $"<th align=\"left\">{_time}</th>";
            result += $"<th align=\"left\">{_room}</th>";
            result += "</tr>";

            return result;
        }

        public int CompareTo(object obj) {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return base.ToString ();
        }

        public string getConvertedName(string name) {
            name = name.Replace ("Ö", "&Ouml;");
            name = name.Replace ("ö", "&ouml;");
            name = name.Replace ("Ä", "&Auml;");
            name = name.Replace ("ä", "&auml;");
            name = name.Replace ("Ü", "&Uuml;");
            name = name.Replace ("ü", "&uuml;");
            return name;
        }
    }
}
