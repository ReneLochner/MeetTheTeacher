using MeetTheTeacher.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetTheTeacher.Test
{
    [TestClass()]
    public class TeacherTests
    {
        [TestMethod()]
        public void T01_GetHtmlForName_TeacherWithoutDetails_ShouldReturnNoLink()
        {
            // Arrange
            Teacher teacher = new Teacher("TeacherA", "MO", "10:00-10:50", "3", "1234");
            // Act
            string html = teacher.GetHtmlForName();
            // Assert
            Assert.AreEqual("TeacherA", html);
        }


        [TestMethod()]
        public void T02_GetHtmlForName_TeacherWithDetails_ShouldReturnNoLink()
        {
            // Arrange
            TeacherWithDetail teacher = new TeacherWithDetail("TeacherA", "MO", "10:00-10:50", "3", "1234", 999);
            // Act
            string html = teacher.GetHtmlForName();
            // Assert
            Assert.AreEqual("<a href=\"?id=999\">TeacherA</a>", html);
        }
    }
}
