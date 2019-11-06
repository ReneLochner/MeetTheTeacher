using MeetTheTeacher.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetTheTeacher.Test
{
    [TestClass()]
    public class ControllerTests
    {
        [TestMethod()]
        public void C01_Count_SomeTeachers_ShouldReturnCountOfTeachersWithDetails()
        {
            // Arrange
            string[] teachersText =
            {
                "BILLINGER Franz; Montag; 4.EH; 10:55 - 11:45 h; 142; ; Dipl.Päd.Dipl.- HTL - Ing.; FOL",
                "BODENSTORFER Bernhard; Freitag; 4.EH; 10:55 - 11:45 h; 254; ; DI Mag. Dr.; Vl.",
                "BRENN Rosemarie; Freitag; 2.EH; 08:55 - 09:45 h; E05; ; Mag.; Vl.",
                "BUCEK Michael; Donnerstag; 9.EH; 15:30 - 16:20 h; 103; ; DI; Prof.",
                "BUGNER Sorin; Stammschule; ; ; ; ; Dr. ; Prof.",
                "DENKMAIR Rainer; Mittwoch; 3.EH; 10:00 - 10:50 h; 131; ; DI; Prof.",
                "DRAXLBAUER Josef; Montag; 5.EH; 11:50 - 12:40 h; 237; ; Mag.; Prof."
            };
            string[] detailsText =
            {
                "Billinger Franz; 2219",
                "Brenn Rosemarie; 2361",
                "Bucek Michael; 2224",
                "Bugner Sorin; 2225"
            };
            Controller controller = new Controller(teachersText, detailsText);
            // Act
            int count = controller.CountTeachersWithDetails;
            // Assert
            Assert.AreEqual(4, count);
        }

        [TestMethod()]
        public void C02_Count_SomeTeachers_ShouldReturnCountOfTeachersWithoutDetails()
        {
            // Arrange
            string[] teachersText =
            {
                "BILLINGER Franz; Montag; 4.EH; 10:55 - 11:45 h; 142; ; Dipl.Päd.Dipl.- HTL - Ing.; FOL",
                "BODENSTORFER Bernhard; Freitag; 4.EH; 10:55 - 11:45 h; 254; ; DI Mag. Dr.; Vl.",
                "BRENN Rosemarie; Freitag; 2.EH; 08:55 - 09:45 h; E05; ; Mag.; Vl.",
                "BUCEK Michael; Donnerstag; 9.EH; 15:30 - 16:20 h; 103; ; DI; Prof.",
                "BUGNER Sorin; Stammschule; ; ; ; ; Dr. ; Prof.",
                "DENKMAIR Rainer; Mittwoch; 3.EH; 10:00 - 10:50 h; 131; ; DI; Prof.",
                "DRAXLBAUER Josef; Montag; 5.EH; 11:50 - 12:40 h; 237; ; Mag.; Prof."
            };
            string[] detailsText =
            {
                "Billinger Franz; 2219",
                "Brenn Rosemarie; 2361",
                "Bucek Michael; 2224",
                "Bugner Sorin; 2225"
            };
            Controller controller = new Controller(teachersText, detailsText);
            // Act
            int count = controller.CountTeachersWithoutDetails;
            // Assert
            Assert.AreEqual(3, count);
        }

        [TestMethod()]
        public void C03_Count_SomeTeachers_ShouldReturnCountOfAllTeachers()
        {
            // Arrange
            string[] teachersText =
            {
                "BILLINGER Franz; Montag; 4.EH; 10:55 - 11:45 h; 142; ; Dipl.Päd.Dipl.- HTL - Ing.; FOL",
                "BODENSTORFER Bernhard; Freitag; 4.EH; 10:55 - 11:45 h; 254; ; DI Mag. Dr.; Vl.",
                "BRENN Rosemarie; Freitag; 2.EH; 08:55 - 09:45 h; E05; ; Mag.; Vl.",
                "BUCEK Michael; Donnerstag; 9.EH; 15:30 - 16:20 h; 103; ; DI; Prof.",
                "BUGNER Sorin; Stammschule; ; ; ; ; Dr. ; Prof.",
                "DENKMAIR Rainer; Mittwoch; 3.EH; 10:00 - 10:50 h; 131; ; DI; Prof.",
                "DRAXLBAUER Josef; Montag; 5.EH; 11:50 - 12:40 h; 237; ; Mag.; Prof."
            };
            string[] detailsText =
            {
                "Billinger Franz; 2219",
                "Brenn Rosemarie; 2361",
                "Bucek Michael; 2224",
                "Bugner Sorin; 2225"
            };
            Controller controller = new Controller(teachersText, detailsText);
            // Act
            int count = controller.Count;
            // Assert
            Assert.AreEqual(7, count);
        }

        [TestMethod()]
        public void C04_Count_TeachersAfterIgnore_ShouldReturnCountOfAllTeachers()
        {
            // Arrange
            string[] teachersText =
            {
                "BILLINGER Franz; Montag; 4.EH; 10:55 - 11:45 h; 142; ; Dipl.Päd.Dipl.- HTL - Ing.; FOL",
                "BODENSTORFER Bernhard; Freitag; 4.EH; 10:55 - 11:45 h; 254; ; DI Mag. Dr.; Vl.",
                "BRENN Rosemarie; Freitag; 2.EH; 08:55 - 09:45 h; E05; ; Mag.; Vl.",
                "BUCEK Michael; Donnerstag; 9.EH; 15:30 - 16:20 h; 103; ; DI; Prof.",
                "BUGNER Sorin; Stammschule; ; ; ; ; Dr. ; Prof.",
                "DENKMAIR Rainer; Mittwoch; 3.EH; 10:00 - 10:50 h; 131; ; DI; Prof.",
                "DRAXLBAUER Josef; Montag; 5.EH; 11:50 - 12:40 h; 237; ; Mag.; Prof."
            };
            string[] detailsText =
            {
                "Billinger Franz; 2219",
                "Brenn Rosemarie; 2361",
                "Bucek Michael; 2224",
                "Bugner Sorin; 2225"
            };
            string[] ignoredTeachers =
            {
                "BRENN Rosemarie",
                "DENKMAIR Rainer"
            };
            Controller controller = new Controller(teachersText, detailsText);
            // Act
            controller.DeleteIgnoredTeachers(ignoredTeachers);
            int count = controller.Count;
            // Assert
            Assert.AreEqual(5, count);
        }

        [TestMethod()]
        public void C05_Count_TeachersAfterIgnoreCaseInsensitive_ShouldReturnCountOfAllTeachers()
        {
            // Arrange
            string[] teachersText =
            {
                "BILLINGER Franz; Montag; 4.EH; 10:55 - 11:45 h; 142; ; Dipl.Päd.Dipl.- HTL - Ing.; FOL",
                "BODENSTORFER Bernhard; Freitag; 4.EH; 10:55 - 11:45 h; 254; ; DI Mag. Dr.; Vl.",
                "BRENN Rosemarie; Freitag; 2.EH; 08:55 - 09:45 h; E05; ; Mag.; Vl.",
                "BUCEK Michael; Donnerstag; 9.EH; 15:30 - 16:20 h; 103; ; DI; Prof.",
                "BUGNER Sorin; Stammschule; ; ; ; ; Dr. ; Prof.",
                "DENKMAIR Rainer; Mittwoch; 3.EH; 10:00 - 10:50 h; 131; ; DI; Prof.",
                "DRAXLBAUER Josef; Montag; 5.EH; 11:50 - 12:40 h; 237; ; Mag.; Prof."
            };
            string[] detailsText =
            {
                "Billinger Franz; 2219",
                "Brenn Rosemarie; 2361",
                "Bucek Michael; 2224",
                "Bugner Sorin; 2225"
            };
            string[] ignoredTeachers =
            {
                "brenn Rosemarie",
                "DENKMAIR Rainer"
            };
            Controller controller = new Controller(teachersText, detailsText);
            // Act
            controller.DeleteIgnoredTeachers(ignoredTeachers);
            int count = controller.Count;
            // Assert
            Assert.AreEqual(5, count);
        }
    }

}
