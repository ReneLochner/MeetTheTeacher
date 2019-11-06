using System;
using System.Collections.Generic;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Verwaltung der Lehrer (mit und ohne Detailinfos)
    /// </summary>
    public class Controller
    {
        private readonly List<Teacher> _teachers;
        private readonly Dictionary<string, int> _details;

        /// <summary>
        /// Liste für Sprechstunden und Dictionary für Detailseiten anlegen
        /// </summary>
        public Controller(string[] teacherLines, string[] detailsLines)
        {
            _teachers = new List<Teacher> ();
            _details = new Dictionary<string, int> ();

            InitDetails (detailsLines);
            InitTeachers (teacherLines);
        }

        public int Count => _teachers.Count;

        public int CountTeachersWithoutDetails => _teachers.Count - _details.Count;


        /// <summary>
        /// Anzahl der Lehrer mit Detailinfos in der Liste
        /// </summary>
        public int CountTeachersWithDetails =>  _details.Count;

        /// <summary>
        /// Aus dem Text der Sprechstundendatei werden alle Lehrersprechstunden 
        /// eingelesen. Dabei wird für Lehrer, die eine Detailseite haben
        /// ein TeacherWithDetails-Objekt und für andere Lehrer ein Teacher-Objekt angelegt.
        /// </summary>
        /// <returns>Anzahl der eingelesenen Lehrer</returns>
        private void InitTeachers(string[] lines)
        {
             foreach (string line in lines) {
                string[] parts = line.Split (";");
                if (parts.Length >= 5) {
                    string name = parts[0];
                    string day = parts[1];
                    string hour = parts[2];
                    string time = parts[3];
                    string room = parts[4];
                    bool createdDetailTeacher = false;
                    foreach (KeyValuePair<string, int> detail in _details) {
                        if (line.ToLower ().Contains (detail.Key.ToLower ())) {
                            TeacherWithDetail teacherWidthDetail = new TeacherWithDetail (name, day, hour, time, room, detail.Value);
                            _teachers.Add (teacherWidthDetail);
                            createdDetailTeacher = true;
                        }
                    }
                    if(!createdDetailTeacher) {
                        Teacher teacher = new Teacher (name, day, hour, time, room);
                        _teachers.Add (teacher);
                    }
                }
            }
        }


        /// <summary>
        /// Lehrer, deren Name in der Datei IgnoredTeachers steht werden aus der Liste 
        /// entfernt
        /// </summary>
        public void DeleteIgnoredTeachers(string[] names)
        {
            List<Teacher> teachersToDelete = new List<Teacher>();

           foreach(Teacher teacher in _teachers) {
                foreach(string name in names) {
                    if(name.ToLower().Equals(teacher._name.ToLower())) {
                        teachersToDelete.Add (teacher);
                    }
                }
            }

           foreach(Teacher teacherToDelete in teachersToDelete) {
                _teachers.Remove (teacherToDelete);
            }
        }

        /// <summary>
        /// Sucht Lehrer in Lehrerliste nach dem Namen
        /// </summary>
        /// <param name="teacherName"></param>
        /// <returns>Index oder -1, falls nicht gefunden</returns>
        private int FindIndexForTeacher(string teacherName)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Ids der Detailseiten für Lehrer die eine
        /// derartige Seite haben einlesen.
        /// </summary>
        private void InitDetails(string[] lines)
        {
            foreach (string line in lines) {
                string[] parts = line.Split (";");

                if (parts.Length >= 2) {
                    // "BILLINGER Franz; Montag; 4.EH; 10:55 - 11:45 h; 142; ; Dipl.Päd.Dipl.- HTL - Ing.; FOL",
                    string name = parts[0];
                    int id = Int32.Parse(parts[1]);

                    _details.Add (name, id);
                }
            }
        }

        /// <summary>
        /// HTML-Tabelle der ganzen Lehrer aufbereiten.
        /// </summary>
        /// <returns>Text für die Html-Tabelle</returns>
        public string GetHtmlTable()
        {
            string result = "<table id=\"tabelle\">";
            result += "<tr>";
            result += "<th align=\"center\">Name</th>";
            result += "<th align=\"center\">Tag</th>";
            result += "<th align=\"center\">Zeit</th>";
            result += "<th align=\"center\">Raum</th>";
            result += "</tr>";

            for(int i = 1; i < _teachers.Count; i++) {
                if(_teachers[i].GetType () == typeof (TeacherWithDetail)) {
                    result += ((TeacherWithDetail) _teachers[i]).GetTeacherHtmlRow ();
                } else {
                    result += _teachers[i].GetTeacherHtmlRow ();
                }
            }

            result += "</table>";
            return result;
        }

    }
}
